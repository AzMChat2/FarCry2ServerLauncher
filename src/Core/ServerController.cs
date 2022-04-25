using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Xml;

namespace GSL
{
	public sealed class ServerController : WorkerThread, INotifyPropertyChanged
	{
		private static int _ControllerCount;

		private List<string> _teamKillers = new List<string>();
		private ServerSettings _serverSettings;

		public ServerController(ServerConfig config, ServerSettings serverSettings)
			: base(string.Format(CultureInfo.CurrentCulture, "Server_{0}", ++_ControllerCount))
		{
			Config = config;
			_teamKillers = new List<string>();
			_serverSettings = serverSettings;
			Players = new PlayerCollection();
			PlayerMessages = new PlayerMessageCollection();
			ChatMessages = new ChatMessageCollection();
			ConsoleMessages = new ConsoleMessagesCollection();
			AutoStart = DateTime.MaxValue;
			StartTimeout = DateTime.MaxValue;
			RemoteServer.Register(this);
		}

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		public ServerInterface Interface { get; private set; }
		public ServerConfig Config { get; set; }

		public PlayerCollection Players { get; private set; }
		public PlayerMessageCollection PlayerMessages { get; private set; }
		public ChatMessageCollection ChatMessages { get; private set; }
		public ConsoleMessagesCollection ConsoleMessages { get; private set; }

		public DateTime AutoStart { get; private set; }
		public DateTime StartTimeout { get; private set; }
		public DateTime NextMessage { get; private set; }
		public DateTime StatusChanged { get; private set; }

		public bool Paused { get; set; }
		public bool StopAtNoPlayers { get; set; }
		public bool StopAfterMatch { get; set; }
		public bool IsDisconnected { get; set; }

		private bool _gameRunning;
		public bool GameRunning
		{
			get { return _gameRunning; }
			set
			{
				if (_gameRunning != value)
				{
					_gameRunning = value;
					OnPropertyChanged("GameRunning");
					Trace.WriteLineIf(TS.Verbose, "Game Running: " + _gameRunning, TS.Categories.Debug);
				}
			}
		}

		private bool _isStarting;
		public bool IsStarting
		{
			get { return _isStarting; }
			set
			{
				if (_isStarting != value)
				{
					_isStarting = value;
					OnPropertyChanged("IsStarting");
					Trace.WriteLineIf(TS.Verbose, "Is Starting: " + _isStarting, TS.Categories.Debug);
				}
			}
		}

		private string _currentMap;
		public string CurrentMap
		{
			get { return _currentMap; }
			set
			{
				if (_currentMap != value)
				{
					_currentMap = value;
					OnPropertyChanged("CurrentMap");
					Trace.WriteLineIf(TS.Verbose, "Current Map: " + _currentMap, TS.Categories.Debug);
				}
			}
		}

		private ServerStates _status;
		public ServerStates Status
		{
			get { return _status; }
			set
			{
				if (_status != value)
				{
					StatusChanged = DateTime.Now;
					_status = value;
					OnPropertyChanged("Status");
					Trace.WriteLineIf(TS.Verbose, "Status: " + _status, TS.Categories.Debug);
				}
			}
		}

		public string ServerName
		{
			get { return _serverSettings.ServerName; }
		}

		public void ChangeSettings(ServerSettings newSettings, bool applyNow)
		{
			_serverSettings = newSettings;
			if ((applyNow) && (GameRunning))
			{
				Interface.ChangeSettings(newSettings);
			}
		}

		public void StartServer()
		{
			Interface = new ServerInterface(_serverSettings);

			Interface.ProcessException += new EventHandler<ExceptionEventArgs>(Interface_ProcessException);

			Interface.ServerStarted += new EventHandler(Interface_ServerStarted);
			Interface.ServerStopped += new EventHandler(Interface_ServerStopped);
			Interface.ServerDied += new EventHandler<ServerDiedEventArgs>(Interface_ServerDied);

			Interface.PlayerConnected += new EventHandler<PlayerEventArgs>(Interface_PlayerConnected);
			Interface.PlayerDisconnected += new EventHandler<PlayerEventArgs>(Interface_PlayerDisconnected);
			Interface.PlayerJoinedMatch += new EventHandler<PlayerEventArgs>(Interface_PlayerJoinedMatch);
			Interface.PlayerKilled += new EventHandler<KillEventArgs>(Interface_PlayerKilled);
			Interface.PlayerMessageRecieved += new EventHandler<PlayerMessageEventArgs>(Interface_PlayerMessageRecieved);
			Interface.PlayerSuicided += new EventHandler<PlayerEventArgs>(Interface_PlayerSuicided);
			Interface.PlayerTeamAssigned += new EventHandler<TeamAssignedEventArgs>(Interface_PlayerTeamAssigned);

			Interface.ConsoleMessageRecieved += new EventHandler<ConsoleMessageEventArgs>(Interface_ConsoleMessageRecieved);
			Interface.LobbyEntered += new EventHandler(Interface_LobbyEntered);
			Interface.LobbyExited += new EventHandler(Interface_LobbyExited);
			Interface.MatchEnded += new EventHandler(Interface_MatchEnded);
			Interface.MatchStarted += new EventHandler(Interface_MatchStarted);
			Interface.MapChanged += new EventHandler<MapChangedEventArgs>(Interface_MapChanged);
			Interface.StatusChanged += new EventHandler<StatusChangedEventArgs>(Interface_StatusChanged);

			Interface.Start();
		}

		private void Interface_StatusChanged(object sender, StatusChangedEventArgs e)
		{
			Status = e.Status;
		}

		private void Interface_MapChanged(object sender, MapChangedEventArgs e)
		{
			CurrentMap = e.MapName;
		}

		public void StopServer()
		{
			Interface.StopProcess();
		}

		private void Interface_MatchStarted(object sender, EventArgs e)
		{
			SetNextMessageTimes();
		}

		private void Interface_MatchEnded(object sender, EventArgs e)
		{
			OutputStats();
			if (StopAfterMatch)
			{
				Trace.WriteLineIf(TS.Info, "Stopping server at end of match, as requested.", TS.Categories.Event);
				Interface.StopProcess();
			}
		}

		private void Interface_LobbyExited(object sender, EventArgs e)
		{
			Interface.GetMapName();
			Interface.GetPlayerList();
		}

		private void Interface_LobbyEntered(object sender, EventArgs e)
		{
			if ((IsStarting) && (Config.MiscConfig.AutoRestart))
			{
				AutoStart = DateTime.MaxValue;
				StartTimeout = DateTime.MaxValue;
				Interface.HideServerConsole();
			}
			IsStarting = false;

			AdjustMinPlayers();

			Thread.Sleep(100);
			Interface.GetMapName();
		}

		private void AdjustMinPlayers()
		{
			if (Config.MiscConfig.AutoAdjustMinPlayers)
			{
				GameSetting minPlayerSetting = _serverSettings.GameSettings.Find(item => item.Name.Equals("Minimum Players", StringComparison.OrdinalIgnoreCase));

				int minPlayersValue = (minPlayerSetting == null) ? 2 : int.Parse(minPlayerSetting.Value);
				int playerCount = Players.CountIf(item => item.IsConnected);
				int minPlayers = (playerCount * Config.MiscConfig.MinPlayerPercent) / 100;

				if (minPlayers < minPlayersValue) minPlayers = minPlayersValue;
				Interface.SetMinimumPlayers(minPlayers);
			}
		}

		private void Interface_ProcessException(object sender, ExceptionEventArgs e)
		{
			OnProcessException(e.Exception);
		}

		private void Interface_ConsoleMessageRecieved(object sender, ConsoleMessageEventArgs e)
		{
			ConsoleMessages.Add(e.Message);
		}

		private void Interface_PlayerTeamAssigned(object sender, TeamAssignedEventArgs e)
		{
			Player player = Players[e.PlayerName];
			if (player != null)
			{
				player.Team = e.Team;
			}
		}

		private void Interface_PlayerSuicided(object sender, PlayerEventArgs e)
		{
			ProcessSuicide(e.PlayerName);
		}

		private void Interface_PlayerMessageRecieved(object sender, PlayerMessageEventArgs e)
		{
			ProcessPlayerMessage(e.PlayerName, e.Message);
		}

		private void Interface_PlayerKilled(object sender, KillEventArgs e)
		{
			ProcessKill(e.KillerName, e.VictimName);
		}

		private void Interface_PlayerJoinedMatch(object sender, PlayerEventArgs e)
		{
			Interface.GetPlayerList();
			if (BanCollection.Current.IsBanned(e.PlayerName, DateTime.Now))
			{
				GenerateBanMessage(e.PlayerName);
			}
			else
			{
				ProcessWelcomeMessage(e.PlayerName);
			}
		}

		private void Interface_PlayerDisconnected(object sender, PlayerEventArgs e)
		{
			RemovePlayerFromList(e.PlayerName);
			if (Status == ServerStates.In_Lobby) AdjustMinPlayers();
		}

		private void Interface_PlayerConnected(object sender, PlayerEventArgs e)
		{
			AddPlayerToList(e.PlayerName);
			if (Status == ServerStates.In_Lobby) AdjustMinPlayers();
		}

		private void Interface_ServerDied(object sender, ServerDiedEventArgs e)
		{
			Trace.WriteLineIf(TS.Error, e.ProcessStats, TS.Categories.Critical);
			ProcessServerStop();
			if (Config.MiscConfig.AutoRestart)
			{
				AutoStart = DateTime.Now.AddSeconds(Config.MiscConfig.RestartWait);
			}
		}

		private void Interface_ServerStopped(object sender, EventArgs e)
		{
			ProcessServerStop();
		}

		private void ProcessServerStop()
		{
			IsStarting = false;
			GameRunning = false;
			Players.ForEach(item => item.IsConnected = false);
			OutputStats();
			Interface = null;
		}

		private void Interface_ServerStarted(object sender, EventArgs e)
		{
			GameRunning = true;
			IsStarting = true;
			StopAfterMatch = false;
			StopAtNoPlayers = false;
			IsDisconnected = false;
			if (Config.MiscConfig.AutoRestart)
			{
				StartTimeout = DateTime.Now.AddSeconds(Config.MiscConfig.StartTimeout);
			}
		}

		protected override void Execute()
		{
			Trace.WriteLineIf(TS.Info, "Server Controller thread started", TS.Categories.Event);
			ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, "Server Controller thread started"));

			while (!Stopping)
			{
				if (!Paused)
				{
					try
					{
						if (GameRunning) 
						{
							if (Players.Exists(item => item.IsConnected))
							{
								if (Status == ServerStates.In_Match) SendNextServerMessage();
								SendPlayerMessages();
								_teamKillers.Clear();
								BanCollection.Current.RemoveOldBans(DateTime.Now);
							}

							if ((Config.MiscConfig.AutoRestart) && (DateTime.Now >= StartTimeout))
							{
								Trace.WriteLineIf(TS.Warning, "Server did not start within the specified timeout.", TS.Categories.Warning);
								ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, "Server did not start within the specified timeout."));
								AutoStart = DateTime.Now.AddSeconds(Config.MiscConfig.RestartWait);
								StopServer();
							}
						}
						else if ((Config.MiscConfig.AutoRestart) && (DateTime.Now >= AutoStart))
						{
							Trace.WriteLineIf(TS.Warning, "Attempting to Auto Restart Server.", TS.Categories.Event);
							ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, "Attempting to Auto Restart Server."));
							StartServer();
						}
					}
					catch (Exception ex)
					{
						string msg = string.Format(CultureInfo.CurrentCulture, "Processing Exception\r\n{0}", ex);
						Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
						ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Error, msg));
					}
				}
				Thread.Sleep(GSL.Settings.Values.ProcessInterval);
			}
			if (Interface != null) Interface.StopProcess();
		}

		private void GenerateAdminBanKickMessage(Player player)
		{
			string msg = string.Format(CultureInfo.CurrentCulture, "Kicking banned player {0}", player.Name);
			Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
			ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));

			PlayerMessage warning = new PlayerMessage(player.Name, DateTime.Now);
			Config.BanConfig.MisconductBanMessages.ForEach(item => warning.Messages.Add(string.Format(CultureInfo.CurrentCulture, item, player.Name, "Game Misconduct")));

			if (warning.Messages.Count != 0)
			{
				PlayerMessages.Add(warning);
			}
		}

		private void GenerateMisconductWarning(Player player)
		{
			WarnPlayer(player, "Game Misconduct", Config.BanConfig.MisconductWarningMessages, Config.BanConfig.MisconductBanMessages);
		}

		private void GenerateSwearWarning(Player player)
		{
			if (Config.BanConfig.BanSwearing)
			{
				WarnPlayer(player, "Using Foul Language", Config.BanConfig.SwearingWarningMessages, Config.BanConfig.SwearingBanMessages);
			}
		}

		private void GenerateTeamKillWarning(Player player)
		{
			if (Config.BanConfig.BanTeamKill)
			{
				WarnPlayer(player, "Team Killing", Config.BanConfig.TeamKillWarningMessages, Config.BanConfig.TeamKillBanMessages);
			}
		}

		public void WarnPlayer(Player player, string reason, List<string> warnMessages, List<string> banMessages)
		{
			PlayerMessage warning = new PlayerMessage(player.Name, DateTime.Now);
			player.MapWarnings++;

			if ((player.MapWarnings >= Config.BanConfig.Warnings) || (player.TotalWarnings >= Config.BanConfig.MaxWarnings))
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Banning {0} for {1}", player.Name, reason);
				Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
				banMessages.ForEach(item => warning.Messages.Add(string.Format(CultureInfo.CurrentCulture, item, player.Name)));
				BanPlayer(player, reason);
			}
			else
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Warning {0} for {1}", player.Name, reason);
				Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
				warnMessages.ForEach(item => warning.Messages.Add(string.Format(CultureInfo.CurrentCulture, item, player.Name)));
			}

			if (warning.Messages.Count != 0)
			{
				PlayerMessages.Add(warning);
			}
		}

		private void SendPlayerMessages()
		{
			DateTime currentTime = DateTime.Now;
			PlayerMessages.FindAll(item => (currentTime >= item.TimeToSend)).ForEach(item => SendWarning(item));
			PlayerMessages.RemoveAll(item => (currentTime >= item.TimeToSend));
		}

		private void SendWarning(PlayerMessage warning)
		{
			warning.Messages.ForEach(item => Interface.Tell(warning.PlayerName, item));
		}

		private void SendNextServerMessage()
		{
			if (DateTime.Now >= NextMessage)
			{
				ServerMessage message = Config.MiscConfig.ServerMessages.Find(item => DateTime.Now >= item.NextMessage);
				if (message != null)
				{
					Interface.Say(message.Message);
					message.LastMessage = DateTime.Now;
					NextMessage = NextMessage.AddSeconds(Config.MiscConfig.MessageWait);
				}
			}
		}

		private void SetNextMessageTimes()
		{
			Config.MiscConfig.ServerMessages.ForEach(item => item.SetInitialTime(DateTime.Now));
		}

		private void GenerateBanMessage(string playerName)
		{
			Ban ban = BanCollection.Current[playerName, DateTime.Now];

			if ((ban != null) && (Config.BanConfig.BannedMessages.Count != 0))
			{
				PlayerMessage banMessage = new PlayerMessage(playerName, DateTime.Now);
				Config.BanConfig.BannedMessages.ForEach(item => banMessage.Messages.Add(string.Format(CultureInfo.CurrentCulture, item, playerName, ban.Reason, ban.ExpiresOn)));
				PlayerMessages.Add(banMessage);
			}

			KickPlayer(Players[playerName]);
		}

		private void OutputStats()
		{
			if ((Config.MiscConfig.LogStats) && (Players.HasStats))
			{
				Trace.WriteLineIf(TS.Info, "Writing Player Statistics File", TS.Categories.Event);
				try
				{
					Utilities.CheckDirectoryExists(Config.MiscConfig.StatsFile);
					string filename = string.Format(CultureInfo.CurrentCulture, "{0}.{1}.{2:yyyyMMddhhmmss}.xml", Config.MiscConfig.StatsFile, CurrentMap, DateTime.Now);
					using (XmlTextWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
					{
						writer.WriteStartDocument();
						writer.WriteStartElement("XmlData");

						Players.WriteStats(writer, CurrentMap, DateTime.Now);

						writer.WriteEndElement();
						writer.WriteEndDocument();
						writer.Close();
					}
					Players.UpdateStats();
				}
				catch (Exception ex)
				{
					Trace.WriteLineIf(TS.Error, "Error in OutputStats\r\n" + ex.ToString(), TS.Categories.Error);
				}
			}
		}

		private void ProcessWelcomeMessage(string playerName)
		{
			if (Config.MiscConfig.WelcomeMessages.Count != 0)
			{
				Trace.WriteLineIf(TS.Info, string.Format(CultureInfo.CurrentCulture, "Welcoming {0} to server", playerName), TS.Categories.Event);
				PlayerMessage welcome = new PlayerMessage(playerName, DateTime.Now.AddSeconds(30));
				Config.MiscConfig.WelcomeMessages.ForEach(item => welcome.Messages.Add(string.Format(CultureInfo.CurrentCulture, item, playerName, _serverSettings.ServerName)));
				if (welcome.Messages.Count != 0)
				{
					PlayerMessages.Add(welcome);
				}
			}
		}

		private void ProcessSuicide(string playerName)
		{
			Players[playerName].MapSuicides++;
		}

		private void ProcessKill(string killerName, string victimName)
		{
			Player killer = Players[killerName];
			Player victim = Players[victimName];

			if ((killer.Team != Teams.None) && (killer.Team == victim.Team))
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "{0} ({1}) team killed {2} ({3})", killer.Name, killer.Team, victim.Name, victim.Team);
				Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));

				if (!_teamKillers.Contains(killer.Name))
				{
					_teamKillers.Add(killer.Name);
					GenerateTeamKillWarning(killer);
					killer.MapTeamKills++;
				}
			}
			else
			{
				killer.MapKills++;
				victim.MapDeaths++;
			}
		}

		public void ProcessPlayerMessage(string playerName, string message)
		{
			if (message.StartsWith("SRV", StringComparison.OrdinalIgnoreCase))
			{
				User admin = Config.Users.Find(item => item.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
				if (admin != null)
				{
					ProcessServerCommand(message, admin);
					return;
				}
			}

			if (Config.BanConfig.BanSwearing && ContainsSwearing(message))
			{
				Player player = Players[playerName];
				if (player != null)
				{
					string msg = string.Format(CultureInfo.CurrentCulture, "{0} used foul language.", player.Name);
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					GenerateSwearWarning(player);
				}
			}

			ChatMessages.Add(new ChatMessage(playerName, message));
		}

		private bool ContainsSwearing(string message)
		{
			bool retVal = false;

			foreach (string item in Config.BanConfig.SwearWords)
			{
				if (!string.IsNullOrEmpty(item))
				{
					if (message.IndexOf(item, StringComparison.OrdinalIgnoreCase) != -1)
					{
						retVal = true;
						break;
					}
				}
			}

			return retVal;
		}

		private void RemovePlayerFromList(string playerName)
		{
			if (playerName.Equals("Anonymous"))
			{
				Trace.WriteLineIf(TS.Warning, "Disconnected from UbiSoft's servers.", TS.Categories.Warning);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, "Disconnected from UbiSoft's servers."));
				if (StopAfterMatch)
				{
					Trace.WriteLineIf(TS.Info, "Stopping server at end of match, as requested.", TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, "Stopping server at end of match, as requested."));
					Interface.StopProcess();
				}
			}
			else
			{
				Player player = Players[playerName];
				player.Team = Teams.None;
				player.IsConnected = false;

				if (!player.HasStats && (player.TotalWarnings == 0) && (player.KickCount == 0))
				{
					Players.Remove(player);
				}
			}

			if (StopAtNoPlayers && !Players.Exists(item => item.IsConnected))
			{
				Trace.WriteLineIf(TS.Info, "Stopping server with zero players, as requested.", TS.Categories.Event);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, "Stopping server with zero players, as requested."));
				Interface.StopProcess();
			}

		}

		private void AddPlayerToList(string playerName)
		{
			Player player = Players[playerName];
			if (player == null)
			{
				player = new Player();
				player.Name = playerName;
				player.Team = Teams.None;
				Players.Add(player);
			}
			player.IsConnected = true;
		}

		public void BanPlayer(Player player, string reason)
		{
			User user = Config.Users.Find(item => item.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase));

			if (user != null)
			{
				if (user.IsClanMember)
				{
					string msg = string.Format(CultureInfo.CurrentCulture, "Unable to ban clan member {0} for {1}.", player.Name, reason);
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, msg));
					return;
				}
				else if (user.IsAdmin)
				{
					string msg = string.Format(CultureInfo.CurrentCulture, "Unable to ban admin player {0} for {1}.", player.Name, reason);
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, msg));
					return;
				}
			}

			try
			{
				BanLength banLen = Config.BanConfig.BanLengths.GetBanLength(BanCollection.Current.GetBanCount(player.Name) + 1);
				Ban ban = new Ban();

				ban.PlayerName = player.Name;
				ban.Reason = reason;
				if (banLen.Type.Equals("Max"))
				{
					ban.ExpiresOn = DateTime.MaxValue;
					ban.RemoveOn = DateTime.MaxValue;
				}
				else
				{
					ban.ExpiresOn = DateTime.Now.Add(banLen.Length);
					ban.RemoveOn = ban.ExpiresOn.AddDays(Config.BanConfig.BanHistory);
				}

				BanCollection.Current.Add(ban);

				// v1.0.11: Update prior ban's "Remove On" date to new ban's "Remove On" date.
				List<Ban> priors = BanCollection.Current.FindAll(item => item.PlayerName.Equals(player.Name, StringComparison.OrdinalIgnoreCase));
				priors.ForEach(item => item.RemoveOn = ban.RemoveOn);

				// v1.0.11: Reset Current and Total Warnings after ban
				player.MapWarnings = 0;
			}
			catch (Exception ex)
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Error generating ban of player {0} for {1}.\r\n{2}", player.Name, reason, ex);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
				ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Error, msg));
			}

			KickPlayer(player);

			// v1.0.12: Inform other players that the player was banned and why.
			Interface.Say(string.Format(CultureInfo.CurrentCulture, "{0} has been autobanned", player.Name));
			Interface.Say(string.Format(CultureInfo.CurrentCulture, "for {0}", reason));
		}

		public void KickPlayer(Player player)
		{
			User user = Config.Users.Find(item => item.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase));

			if ((user == null) || !(user.IsAdmin || user.IsClanMember))
			{
				player.KickCount++;
				if (player.KickCount > 3)
				{
					Interface.BanPlayer(player.Name);
				}
				else
				{
					Interface.KickPlayer(player.Name);
				}
			}
		}

		private void ProcessServerCommand(string message, User admin)
		{
			if (message.StartsWith("SRV_BAN", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanBanPlayer)
				{
					Player player = Players[message.Substring(7).Trim()];
					string msg = admin.Name + " banning " + player.Name + "for misconduct";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					GenerateAdminBanKickMessage(player);
					BanPlayer(player, "Game Misconduct");
				}
			}
			else if (message.StartsWith("SRV_KICK", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanKickPlayer)
				{
					Player player = Players[message.Substring(8).Trim()];
					string msg = admin.Name + " kicking " + player.Name + "for misconduct";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					GenerateAdminBanKickMessage(player);
					KickPlayer(player);
				}
			}
			else if (message.StartsWith("SRV_WARN", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanWarnPlayer)
				{
					Player player = Players[message.Substring(8).Trim()];
					string msg = admin.Name + " warning " + player.Name + "for misconduct";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					GenerateMisconductWarning(player);
				}
			}
			else if (message.StartsWith("SRV_SKIP", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanSkipMap)
				{
					string msg = admin.Name + " Skipping Map";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.SkipMap();
				}
			}
			else if (message.StartsWith("SRV_SHUFFLE", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanShuffleTeams)
				{
					string msg = admin.Name + " Shuffling Teams";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.ShuffleTeams();
				}
			}
			else if (message.StartsWith("SRV_END", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanEndMatch)
				{
					string msg = admin.Name + " Ending Match";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.EndMatch();
				}
			}
			else if (message.StartsWith("SRV_EXTEND", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanExtendMatch)
				{
					string msg = admin.Name + " Extending Match";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.ExtendMatch();
				}
			}
			else if (message.StartsWith("SRV_RESTART", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.CanRestartMatch)
				{
					string msg = admin.Name + " Restarting Match";
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.RestartMatch();
				}
			}
			else if (message.StartsWith("SRV_SETSETTING", StringComparison.OrdinalIgnoreCase))
			{
				if (admin.FullAdmin)
				{
					string setting = message.Substring(15);
					string msg = admin.Name + " Changing parameter: " + setting;
					Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
					ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Event, msg));
					Interface.SendCommand("SetSetting " + setting);
				}
			}
		}
	}
}
