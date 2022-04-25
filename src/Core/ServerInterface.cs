using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.IO;

namespace GSL
{
	public sealed class ServerInterface : WorkerThread
	{
		private static int _InterfaceCount;

		private Process _process;
		private Thread _reader;
		private string _processStats;
		private ServerSettings _serverSettings;

		private int _playerCount;
		private string _currentMap;
		private DateTime _statusChanged;
		private ServerStates _currentStatus;
		private Teams _currentTeam;
		private bool _gettingTeamList;
		private DateTime _lastMessage;

		public ServerInterface(ServerSettings serverSettings)
			: base(string.Format(CultureInfo.CurrentCulture, "ServerInterface_{0}", ++_InterfaceCount))
		{
			_serverSettings = serverSettings;
		}

		internal void ChangeSettings(ServerSettings newSettings)
		{
			using (StreamReader reader = new StreamReader(newSettings.GetConfigFile()))
			{
				_serverSettings = newSettings;
				EndMatch();
				while (!reader.EndOfStream)
				{
					SendCommand(reader.ReadLine());
				}
			}
		}

		#region Execute
		protected override void Execute()
		{
			using (_process = new Process())
			{
				string configFile = _serverSettings.GetConfigFile();

				_process.StartInfo.FileName = Settings.Values.ServerExe;
				_process.StartInfo.Arguments = string.Format(CultureInfo.InvariantCulture, "-dedicated \"{0}\" -noredirectstdin", configFile);
				_process.StartInfo.UseShellExecute = false;
				_process.StartInfo.RedirectStandardInput = true;
				_process.StartInfo.RedirectStandardOutput = true;

				_lastMessage = DateTime.Now;

				if (_process.Start())
				{
					OnServerStarted();
					Thread.Sleep(1000);

					//HideServerConsole();

					_reader = new Thread(ReadConsole);
					_reader.Start();

					while (!_process.WaitForExit(1000))
					{
						UpdateServerProcessStats();
						if (_lastMessage < DateTime.Now.AddMinutes(-1))
						{
							OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Warning, "No message recieved from game server for over 1 minute.");
							GetMapName();
							Thread.Sleep(100);
						}

						if ((Stopping) || (_lastMessage < DateTime.Now.AddMinutes(-5)))
						{
							_process.Kill();
						}
					}
				}
				else
				{
					Trace.WriteLineIf(TS.Warning, "Server Process failed to start.", TS.Categories.Warning);
					OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Error, "Server Process failed to start.");
				}

				if (Stopping)
				{
					OnServerStopped();
				}
				else
				{
					StringBuilder message = new StringBuilder();

					try
					{
						message.AppendFormat("{0:yyyyMMdd hh:mm:ss} - Server Died.\r\n", _process.ExitTime);
						message.AppendFormat("\tExit Code:\t{0}\r\n", _process.ExitCode);
						message.Append(_processStats);
					}
					catch { }

					OnServerDied(message.ToString());
				}
			}
		}

		public void HideServerConsole()
		{
			try
			{
				Win32API.HideConsoleWindow(_process.Id);
			}
			catch (Exception ex)
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Error attempting to hide console window.\r\n{0}", ex.Message);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
				OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Error, msg);
			}
		}
		#endregion

		#region Message Processing
		private void ReadConsole()
		{
			while (!_process.StandardOutput.EndOfStream)
			{
				string message = _process.StandardOutput.ReadLine();
				if (!string.IsNullOrEmpty(message))
				{
					try
					{
						_lastMessage = DateTime.Now;
						ProcessMessage(GetMessagePart(message));
					}
					catch (Exception ex)
					{
						OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Error, ex.Message);
					}
				}
			}
		}

		private void ProcessMessage(string message)
		{
			if (message.StartsWith(ServerResources.I.CurrentMapMessage, StringComparison.OrdinalIgnoreCase))
			{
				int idx = message.IndexOf(":", StringComparison.OrdinalIgnoreCase) + 1;
				OnMapChanged(message.Substring(idx).Trim());
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
			}
			else if (message.StartsWith(ServerResources.I.GameMessage, StringComparison.OrdinalIgnoreCase))
			{
				int idx = message.IndexOf(":", StringComparison.OrdinalIgnoreCase) + 1;
				ProcessGameMessage(message.Substring(idx).Trim());
			}
			else 
			{
				if (_gettingTeamList) ProcessTeamListMessage(message);
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Info, message);
			}
		}

		private void ProcessGameMessage(string message)
		{
			if (message.Contains(ServerResources.I.PlayerSaidMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Chat, message);
				ProcessPlayerMessage(message);
			}
			else if (message.Contains(ServerResources.I.PlayerKilledMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Kill, message);
				ProcessKillMessage(message);
			}
			else if (message.Contains(ServerResources.I.PlayerSuicideMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Kill, message);
				OnPlayerSuicided(message.Replace(ServerResources.I.PlayerSuicideMessage, string.Empty).Trim());
			}
			else if (message.EndsWith(ServerResources.I.PlayerConnectedMessage, StringComparison.OrdinalIgnoreCase))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				OnPlayerConnected(message.Replace(ServerResources.I.PlayerConnectedMessage, string.Empty).Trim());
			}
			else if (message.EndsWith(ServerResources.I.PlayerJoinedMatchMessage, StringComparison.OrdinalIgnoreCase))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Game, message);
				OnPlayerJoinedMatch(message.Replace(ServerResources.I.PlayerJoinedMatchMessage, string.Empty).Trim());
			}
			else if (message.EndsWith(ServerResources.I.PlayerDisconnectedMessage, StringComparison.OrdinalIgnoreCase))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				OnPlayerDisconnected(message.Replace(ServerResources.I.PlayerDisconnectedMessage, string.Empty).Trim());
			}
			else if (message.Contains(ServerResources.I.EnteringLobbyMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				if (_currentStatus == ServerStates.Started) _process.StandardInput.WriteLine("bogus");
				OnLobbyEntered();
			}
			else if (message.Contains(ServerResources.I.LeavingLobbyMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				OnLobbyExited();
			}
			else if (message.Contains(ServerResources.I.MatchStartedMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				OnMatchStarted();
			}
			else if (message.Contains(ServerResources.I.MatchEndedMessage))
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Event, message);
				OnMatchEnded();
			}
			else
			{
				OnConsoleMessageRecieved(ConsoleSources.GameServer, MessageCategories.Game, message);
			}
		}

		private void ProcessKillMessage(string message)
		{
			message = message.Substring(0, (message.Length - 1));
			message = message.Replace(ServerResources.I.PlayerKilledMessage, "~");
			string[] parts = message.Split('~');
			if (parts.Length == 2)
			{
				OnPlayerKilled(parts[0].Trim(), parts[1].Trim());
			}
		}

		private void ProcessPlayerMessage(string message)
		{
			message = message.Replace(ServerResources.I.PlayerSaidMessage, "|");
			string[] parts = message.Split('|');
			if (parts.Length >= 2)
			{
				OnPlayerMessageRecieved(parts[0].Trim(), string.Join("|", parts, 1, parts.Length - 1).Trim());
			}
		}

		private void ProcessTeamListMessage(string message)
		{
			if (message.StartsWith(ServerResources.I.TeamAPRMessage, StringComparison.OrdinalIgnoreCase))
			{
				_currentTeam = Teams.APR;
			}
			else if (message.StartsWith(ServerResources.I.TeamUFLLMessage, StringComparison.OrdinalIgnoreCase))
			{
				_currentTeam = Teams.UFLL;
			}
			else if (message.StartsWith(ServerResources.I.TeamOtherMessage, StringComparison.OrdinalIgnoreCase))
			{
				_currentTeam = Teams.None;
				_gettingTeamList = false;
			}
			else
			{
				if (message.IndexOf(" ", StringComparison.OrdinalIgnoreCase) == -1)
				{
					OnPlayerTeamAssigned(message, _currentTeam);
				}
			}
		}

		private static string GetMessagePart(string message)
		{
			int idx = message.IndexOf("-", StringComparison.OrdinalIgnoreCase) + 1;
			return message.Substring(idx).Trim();
		}
		#endregion

		#region Events
		public event EventHandler ServerStarted;
		private void OnServerStarted()
		{
			Trace.WriteLineIf(TS.Info, "Server Started", TS.Categories.Event);
			OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Event, "Server Started");
			if (ServerStarted != null) ServerStarted.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.Started);
		}

		public event EventHandler ServerStopped;
		private void OnServerStopped()
		{
			Trace.WriteLineIf(TS.Info, "Server Stopped", TS.Categories.Event);
			OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Event, "Server Stopped");
			if (ServerStopped != null) ServerStopped.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.Stopped);
		}

		public event EventHandler<ServerDiedEventArgs> ServerDied;
		private void OnServerDied(string processStats)
		{
			string msg = string.Format(CultureInfo.CurrentCulture, "Server Died\r\n{0}", processStats);
			Trace.WriteLineIf(TS.Info, msg, TS.Categories.Event);
			OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Warning, msg);
			if (ServerDied != null) ServerDied.Invoke(this, new ServerDiedEventArgs(processStats));
			OnStatusChanged(ServerStates.Dead);
		}

		public event EventHandler<PlayerEventArgs> PlayerConnected;
		private void OnPlayerConnected(string playerName)
		{
			_playerCount++;
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' connected.", playerName), TS.Categories.Event);
			if (PlayerConnected != null) PlayerConnected.Invoke(this, new PlayerEventArgs(playerName));
		}

		public event EventHandler<PlayerEventArgs> PlayerJoinedMatch;
		private void OnPlayerJoinedMatch(string playerName)
		{
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' joined the match.", playerName), TS.Categories.Event);
			if (PlayerJoinedMatch != null) PlayerJoinedMatch.Invoke(this, new PlayerEventArgs(playerName));
		}

		public event EventHandler<PlayerEventArgs> PlayerDisconnected;
		private void OnPlayerDisconnected(string playerName)
		{
			_playerCount--;
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' disconnected.", playerName), TS.Categories.Event);
			if (PlayerDisconnected != null) PlayerDisconnected.Invoke(this, new PlayerEventArgs(playerName));
		}

		public event EventHandler<PlayerEventArgs> PlayerSuicided;
		private void OnPlayerSuicided(string playerName)
		{
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' commited suicide.", playerName), TS.Categories.Event);
			if (PlayerSuicided != null) PlayerSuicided.Invoke(this, new PlayerEventArgs(playerName));
		}

		public event EventHandler<PlayerMessageEventArgs> PlayerMessageRecieved;
		private void OnPlayerMessageRecieved(string playerName, string message)
		{
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' said '{1}'.", playerName, message), TS.Categories.Event);
			if (PlayerMessageRecieved != null) PlayerMessageRecieved.Invoke(this, new PlayerMessageEventArgs(playerName, message));
		}

		public event EventHandler<KillEventArgs> PlayerKilled;
		private void OnPlayerKilled(string killerName, string victimName)
		{
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' killed '{1}'.", killerName, victimName), TS.Categories.Event);
			if (PlayerKilled != null) PlayerKilled.Invoke(this, new KillEventArgs(killerName, victimName));
		}

		public event EventHandler<TeamAssignedEventArgs> PlayerTeamAssigned;
		private void OnPlayerTeamAssigned(string playerName, Teams team)
		{
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Player '{0}' assigned to '{1}' team.", playerName, team), TS.Categories.Event);
			if (PlayerTeamAssigned != null) PlayerTeamAssigned.Invoke(this, new TeamAssignedEventArgs(playerName, team));
		}

		public event EventHandler<ConsoleMessageEventArgs> ConsoleMessageRecieved;
		private void OnConsoleMessageRecieved(ConsoleSources source, MessageCategories category, string message)
		{
			Trace.WriteLineIf(TS.Info, string.Format(CultureInfo.CurrentCulture, "CM_{0}_{1}: {2}", source, category, message), TS.Categories.Event);
			if (ConsoleMessageRecieved != null) ConsoleMessageRecieved.Invoke(this, new ConsoleMessageEventArgs(new ConsoleMessage(source, category, message)));
		}

		public event EventHandler<MapChangedEventArgs> MapChanged;
		private void OnMapChanged(string mapName)
		{
			_currentMap = mapName;
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Map changed to '{0}'.", mapName), TS.Categories.Event);
			if (MapChanged != null) MapChanged.Invoke(this, new MapChangedEventArgs(mapName));
		}

		public event EventHandler<StatusChangedEventArgs> StatusChanged;
		private void OnStatusChanged(ServerStates status)
		{
			_statusChanged = DateTime.Now;
			_currentStatus = status;
			Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Status changed to '{0}'.", status), TS.Categories.Event);
			if (StatusChanged != null) StatusChanged.Invoke(this, new StatusChangedEventArgs(status));
		}

		public event EventHandler MatchStarted;
		private void OnMatchStarted()
		{
			Trace.WriteLineIf(TS.Verbose, "MatchStarted", TS.Categories.Event);
			if (MatchStarted != null) MatchStarted.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.In_Match);
		}

		public event EventHandler MatchEnded;
		private void OnMatchEnded()
		{
			Trace.WriteLineIf(TS.Verbose, "MatchEnded", TS.Categories.Event);
			if (MatchEnded != null) MatchEnded.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.Post_Match_Waiting);
		}

		public event EventHandler LobbyEntered;
		private void OnLobbyEntered()
		{
			Trace.WriteLineIf(TS.Verbose, "LobbyEntered", TS.Categories.Event);
			if (LobbyEntered != null) LobbyEntered.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.In_Lobby);
		}

		public event EventHandler LobbyExited;
		private void OnLobbyExited()
		{
			Trace.WriteLineIf(TS.Verbose, "LobbyExited", TS.Categories.Event);
			if (LobbyExited != null) LobbyExited.Invoke(this, new EventArgs());
			OnStatusChanged(ServerStates.Pre_Match_Waiting);
		}
		#endregion

		#region Commands
		public void SendCommand(string command)
		{
			if (!string.IsNullOrEmpty(command))
			{
				Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Sending command: {0}", command), TS.Categories.Event);
				_process.StandardInput.WriteLine(command);
				OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Info, command);
			}
		}

		public void Say(string message)
		{
			if (!string.IsNullOrEmpty(message))
			{
				message = TrimMessage(message);
				string command = string.Format(CultureInfo.CurrentCulture, ServerResources.I.SayCommand, message);
				Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Saying: {0}", message), TS.Categories.Debug);
				_process.StandardInput.WriteLine(command);
				OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Info, command);
			}
		}

		public void Tell(string playerName, string message)
		{
			if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(message))
			{
				message = TrimMessage(message);
				string command = string.Format(CultureInfo.CurrentCulture, ServerResources.I.TellPlayerCommand, playerName, message);
				Trace.WriteLineIf(TS.Verbose, string.Format(CultureInfo.CurrentCulture, "Telling {0}: {1}", playerName, message), TS.Categories.Debug);
				_process.StandardInput.WriteLine(command);
				OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Info, command);
			}
		}

		public void SkipMap()
		{
			SendCommand(ServerResources.I.SkipMapCommand);
			SendCommand(ServerResources.I.GetMapNameCommand);
		}

		public void ExtendMatch()
		{
			SendCommand(ServerResources.I.ExtendMatchCommand);
		}

		public void RestartMatch()
		{
			SendCommand(ServerResources.I.RestartMatchCommand);
		}

		public void EndMatch()
		{
			SendCommand(ServerResources.I.EndMatchCommand);
		}

		public void KickPlayer(string playerName)
		{
			SendCommand(string.Format(CultureInfo.CurrentCulture, ServerResources.I.KickPlayerCommand, playerName));
		}

		public void BanPlayer(string playerName)
		{
			SendCommand(string.Format(CultureInfo.CurrentCulture, ServerResources.I.BanPlayerCommand, playerName));
		}

		public void ShuffleTeams()
		{
			SendCommand(ServerResources.I.ShuffleTeamsCommand);
		}

		public void GetMapName()
		{
			SendCommand(ServerResources.I.GetMapNameCommand);
		}

		public void GetPlayerList()
		{
			_gettingTeamList = true;
			_currentTeam = Teams.None;
			SendCommand(ServerResources.I.GetPlayerListCommand);
		}

		public void SetMinimumPlayers(int value)
		{
			SendCommand(string.Format(CultureInfo.InvariantCulture, "SetSetting minplayers {0}", value));
		}

		#endregion

		#region Helper Methods
		private static string TrimMessage(string message)
		{
			string retVal = message.Trim();

			if (retVal.Length > 40)
			{
				retVal = retVal.Substring(0, 40);
			}

			return retVal;
		}

		private void UpdateServerProcessStats()
		{
			try
			{
				StringBuilder message = new StringBuilder();

#warning TODO: Fix timespan format strings?

				message.AppendFormat("\tTotal Players:\t{0}\r\n", _playerCount);
				message.AppendFormat("\tMap Name:\t{0}\r\n", _currentMap);
				message.AppendFormat("\t{0}:\t{1}\r\n", _currentStatus, DateTime.Now.Subtract(_statusChanged));

				message.AppendFormat("\tHandleCount:\t{0}\r\n", _process.HandleCount);

				message.AppendFormat("\tPrivate Memory Size:\t{0}\r\n", _process.PrivateMemorySize64);
				message.AppendFormat("\tPaged System Memory Size:\t{0}\r\n", _process.PagedSystemMemorySize64);
				message.AppendFormat("\tNon-Paged System Memory Size:\t{0}\r\n", _process.NonpagedSystemMemorySize64);
				message.AppendFormat("\tPaged Memory Size:\t{0}\r\n", _process.PagedMemorySize64);
				message.AppendFormat("\tPeak Paged Memory Size:\t{0}\r\n", _process.PeakPagedMemorySize64);
				message.AppendFormat("\tVirtual Memory Size:\t{0}\r\n", _process.VirtualMemorySize64);
				message.AppendFormat("\tPeak Virtual Memory Size:\t{0}\r\n", _process.PeakVirtualMemorySize64);

				message.AppendFormat("\tWorking Set:\t{0}\r\n", _process.WorkingSet64);
				message.AppendFormat("\tPeak Working Set:\t{0}\r\n", _process.PeakWorkingSet64);

				message.AppendFormat("\tPrivileged Processor Time:\t{0}\r\n", _process.PrivilegedProcessorTime);
				message.AppendFormat("\tTotal Processor Time:\t{0}\r\n", _process.TotalProcessorTime);
				message.AppendFormat("\tUser Processor Time:\t{0}\r\n", _process.UserProcessorTime);

				_processStats = message.ToString();
			}
			catch (Exception ex)
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Error retrieving Server Process Stats.\r\n{0}", ex);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
				OnConsoleMessageRecieved(ConsoleSources.Extender, MessageCategories.Error, msg);
			}
		}
		#endregion

	}
}
