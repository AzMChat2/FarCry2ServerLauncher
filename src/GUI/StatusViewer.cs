using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using WinSize = System.Drawing.Size;
using System.Diagnostics;

namespace GSL
{
	[DesignTimeVisible(true)]
	public partial class StatusViewer : UserControl
	{
		public ServerController Server { get; set; }
		private List<string> _consoleDataSource = new List<string>();
		private BindingSource _playerGridSource = new BindingSource();
		private ServerConfig _serverConfig;
		private ServerSettings _serverSettings;
		private ConsoleSources _sourcesFilter = ConsoleSources.All;
		private MessageCategories _categoryFilter = MessageCategories.All;

		private TextBox txtConsoleMessages;

		public StatusViewer()
		{
			InitializeComponent();
			txtConsoleMessages = new TextBox();
			//InitializeConsole();
		}

		public void Initialize(ServerConfig serverConfig, ServerSettings serverSettings)
		{
			_serverConfig = serverConfig;
			_serverSettings = serverSettings;

			Server = new ServerController(_serverConfig, _serverSettings);
			Server.PropertyChanged += new PropertyChangedEventHandler(Server_PropertyChanged);
			Server.ProcessException += new EventHandler<ExceptionEventArgs>(Server_ProcessException);
			Server.Players.ItemAdded += new EventHandler<ItemEventArgs<Player>>(Server_PlayersItemAdded);
			Server.ConsoleMessages.ItemAdded += new EventHandler<ItemEventArgs<ConsoleMessage>>(ConsoleMessages_ItemAdded);
			Server.ChatMessages.ItemAdded += new EventHandler<ItemEventArgs<ChatMessage>>(ChatMessages_ItemAdded);
			Server.Start();

			_playerGridSource.DataSource = Server.Players;
			grdPlayers.AutoGenerateColumns = false;
			grdPlayers.DataSource = _playerGridSource;

			btnLaunch.Visible = true;
			btnPause.Visible = false;
			btnResume.Visible = false;

			UpdateStatusIcon();
			UpdateStatusLabel();
			lblServerName.Text = ServerName;
			tmrUpdate.Enabled = true;

			DisableForm();
		}

		private void DisableForm()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(DisableForm));
			}
			else
			{
				FormEnabled = false;
			}
		}

		private void EnableForm()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(EnableForm));
			}
			else
			{
				FormEnabled = true;
			}
		}

		private bool FormEnabled
		{
			get { return btnCommand.Enabled; }
			set
			{
				txtSay.Enabled = value;
				txtCommand.Enabled = value;

				btnSay.Enabled = value;
				btnCommand.Enabled = value;

				mnuBanPlayer.Enabled = value;
				mnuKickPlayer.Enabled = value;
				mnuWarnPlayer.Enabled = value;

				mnuStopEndRound.Enabled = value;
				mnuStopNoPlayers.Enabled = value;
				mnuStopNow.Enabled = value;

				extendMatchToolStripMenuItem.Enabled = value;
				endMatchToolStripMenuItem.Enabled = value;
				restartMatchToolStripMenuItem.Enabled = value;

				shuffleTeamsToolStripMenuItem.Enabled = value;
				skipMapToolStripMenuItem.Enabled = value;

				btnLaunch.Visible = !value;
				btnPause.Visible = value;
				btnResume.Visible = false;
			}
		}

		private void BanPlayer(Player player)
		{
			if (player != null)
			{
				if ((player.IsConnected) && (ConfirmPlayerAction(player, "Ban")))
				{
					Server.BanPlayer(player, "Game Misconduct");
				}
			}
		}

		private void KickPlayer(Player player)
		{
			if (player != null)
			{
				if ((player.IsConnected) && (ConfirmPlayerAction(player, "Kick")))
				{
					Server.KickPlayer(player);
				}
			}
		}

		private void WarnPlayer(Player player)
		{
			if (player != null)
			{
				if ((player.IsConnected) && (ConfirmPlayerAction(player, "Warn")))
				{
					Server.WarnPlayer(player, "Game Misconduct", _serverConfig.BanConfig.MisconductWarningMessages, _serverConfig.BanConfig.MisconductBanMessages);
				}
			}
		}

		private void SayToAll()
		{
			if (txtSay.Text.Length != 0)
			{
				Server.Interface.Say(txtSay.Text);
				txtSay.Text = string.Empty;
				txtSay.Focus();
			}
		}

		private CommandHistory commandHistory = new CommandHistory();
		private void SendCommand()
		{
			if (txtCommand.Text.Length != 0)
			{
				commandHistory.Add(txtCommand.Text);
				Server.Interface.SendCommand(txtCommand.Text);
				txtCommand.Text = string.Empty;
				txtCommand.Focus();
				commandHolder = string.Empty;
			}
		}

		private object chatLocker = new object();
		private ChatMessage chatMessage;
		private void AddChatMessage()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(AddChatMessage));
			}
			else
			{
				CheckConsoleLength(txtChatAll);
				txtChatAll.AppendText(string.Format("{0:hh:mm:ss} {1}:  {2}{3}", chatMessage.MessageTime, chatMessage.PlayerName, chatMessage.Message, Environment.NewLine));
				txtChatAll.SelectionStart = txtChatAll.Text.Length;
				txtChatAll.ScrollToCaret();
			}
		}

		private void CheckConsoleLength(TextBox textbox)
		{
			if (textbox.Lines.Length > 500)
			{
				List<string> lines = new List<string>(textbox.Lines);
				lines.RemoveRange(0, lines.Count - 400); // Chop off 100 lines at a time...
				textbox.Lines = lines.ToArray();
			}
		}

		private object consoleLocker = new object();
		private ConsoleMessage consoleMessage;
		private void ProcessConsoleMessage()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(ProcessConsoleMessage));
			}
			else
			{
				if (consoleMessage.Category == MessageCategories.Kill)
				{
					CheckConsoleLength(txtKillLog);
					txtKillLog.AppendText(string.Format("{0:hh:mm:ss} {1}{2}", consoleMessage.TimeStamp, consoleMessage.Message, Environment.NewLine));
					txtKillLog.SelectionStart = txtKillLog.Text.Length;
					txtKillLog.ScrollToCaret();
				}

				if (((consoleMessage.Category & _categoryFilter) != 0) && ((consoleMessage.Source & _sourcesFilter) != 0))
				{
					CheckConsoleLength(txtConsoleMessages);
					txtConsoleMessages.AppendText(string.Format("{0:hh:mm:ss} {1} - {2}: {3}{4}", consoleMessage.TimeStamp, consoleMessage.Source, consoleMessage.Category, consoleMessage.Message, Environment.NewLine));
					txtConsoleMessages.SelectionStart = txtConsoleMessages.Text.Length;
					txtConsoleMessages.ScrollToCaret();
				}
			}
		}

		private void ApplyConsoleFilter()
		{
			List<ConsoleMessage> messages = Server.ConsoleMessages.FindAll(item => MatchesConsoleFilter(item));
			if (messages.Count > 500)
			{
				messages.RemoveRange(0, messages.Count - 480); // Give it a 20 line buffer to fill before truncating to 400 lines...
			}
			StringBuilder sb = new StringBuilder();
			messages.ForEach(item => sb.AppendFormat("{0:hh:mm:ss} {1} - {2}: {3}{4}", item.TimeStamp, item.Source, item.Category, item.Message, Environment.NewLine));
			txtConsoleMessages.Text = sb.ToString();
			txtConsoleMessages.SelectionStart = txtConsoleMessages.Text.Length;
			txtConsoleMessages.ScrollToCaret();
		}

		private bool MatchesConsoleFilter(ConsoleMessage item)
		{
			return (((item.Source & _sourcesFilter) != 0) && ((item.Category & _categoryFilter) != 0));
		}

		public string ServerName
		{
			get { return _serverSettings.ServerName; }
		}

		private void UpdatePlayersGrid()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(ApplyPlayersGridFilter));
			}
			else
			{
				ApplyPlayersGridFilter();
			}
		}

		private void UpdateServerNameLabel()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateServerNameLabel));
			}
			else
			{
				lblServerName.Text = string.Format("{0} - {1}", _serverSettings.ServerName, Server.CurrentMap);
			}
		}

		private void UpdateStatusLabel()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateStatusLabel));
			}
			else
			{
				lblStatus.Text = string.Format("Current Status: {0}", Server.Status).Replace('_', ' ');
			}
		}

		private void UpdateStatusIcon()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateStatusIcon));
			}
			else
			{
				switch (Server.Status)
				{
					case ServerStates.Started:
						lblStatusIcon.ImageIndex = 1;
						break;
					case ServerStates.In_Lobby:
					case ServerStates.In_Match:
					case ServerStates.Post_Match_Waiting:
					case ServerStates.Pre_Match_Waiting:
						lblStatusIcon.ImageIndex = 0;
						break;
					case ServerStates.Not_Started:
					case ServerStates.Dead:
					case ServerStates.Stopped:
						lblStatusIcon.ImageIndex = 2;
						break;
				}
			}
		}

		private void UpdateCountDown()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateCountDown));
			}
			else
			{
				lblCountDown.Text = string.Empty;

				if (Server.IsStarting)
				{
					if (Server.Config.MiscConfig.AutoRestart)
					{
						lblCountDown.Text = string.Format("Start Timeout: {0:N0}", Server.StartTimeout.Subtract(DateTime.Now).TotalSeconds);
					}
				}
				else if (Server.GameRunning)
				{
					TimeSpan ts = DateTime.Now.Subtract(Server.StatusChanged);
					if (Server.Status == ServerStates.In_Match)
					{
						lblCountDown.Text = string.Format("Current Match: {0}:{1:00}", ((ts.Hours * 60) + ts.Minutes), ts.Seconds);
					}
					else if (Server.Status == ServerStates.In_Lobby)
					{
						lblCountDown.Text = string.Format("Waiting in Lobby: {0}:{1:00}", ((ts.Hours * 60) + ts.Minutes), ts.Seconds);
					}
					else
					{
						lblCountDown.Text = string.Format("{2}: {0}:{1:00}", ((ts.Hours * 60) + ts.Minutes), ts.Seconds, Server.Status).Replace("_", " ");
					}
				}
				else if ((Server.AutoStart > DateTime.Now) && (Server.AutoStart != DateTime.MaxValue) && (Server.Config.MiscConfig.AutoRestart))
				{
					lblCountDown.Text = string.Format("Restart Countdown: {0:N0}", Server.AutoStart.Subtract(DateTime.Now).TotalSeconds);
				}
			}
		}

		private Filters _currentFilter = Filters.Connected;
		private enum Filters
		{
			None = 0,
			Connected = 1,
		}

		private void ResetFilterChecks()
		{
			mnuNoFilter.Checked = true;
			mnuConnected.Checked = false;
			_currentFilter = Filters.None;
		}

		private void ApplyPlayersGridFilter()
		{
			switch (_currentFilter)
			{
				case Filters.None:
					_playerGridSource.DataSource = Server.Players;
					break;
				case Filters.Connected:
					_playerGridSource.DataSource = Server.Players.FindAll(item => item.IsConnected);
					break;
			}

			_playerGridSource.ResetBindings(true);
		}

		private void UpdateSourceFilter(object sender, EventArgs e)
		{
			ConsoleSources sourcesFilter = ConsoleSources.None;

			if (chkGameServer.Checked) sourcesFilter |= ConsoleSources.GameServer;
			if (chkExtender.Checked) sourcesFilter |= ConsoleSources.Extender;

			if (_sourcesFilter != sourcesFilter)
			{
				_sourcesFilter = sourcesFilter;
				ApplyConsoleFilter();
			}
		}

		private void UpdateCategoryFilter(object sender, EventArgs e)
		{
			MessageCategories categoryFilter = MessageCategories.None;

			if (chkGame.Checked) categoryFilter |= MessageCategories.Game;
			if (chkChat.Checked) categoryFilter |= MessageCategories.Chat;
			if (chkDebug.Checked) categoryFilter |= MessageCategories.Info;
			if (chkErrors.Checked) categoryFilter |= MessageCategories.Error;
			if (chkEvents.Checked) categoryFilter |= MessageCategories.Event;
			if (chkKills.Checked) categoryFilter |= MessageCategories.Kill;
			if (chkWarnings.Checked) categoryFilter |= MessageCategories.Warning;

			if (_categoryFilter != categoryFilter)
			{
				_categoryFilter = categoryFilter;
				ApplyConsoleFilter();
			}
		}

		private Player GetClickedPlayer()
		{
			Player retVal = null;
			string playerName = null;

			DataGridViewSelectedCellCollection cells = grdPlayers.SelectedCells;

			if (cells.Count == 0)
			{
				DataGridViewSelectedRowCollection rows = grdPlayers.SelectedRows;
				if (rows.Count == 1)
				{
					playerName = (string)(grdPlayers.Rows[rows[0].Index].Cells[0].Value);
				}
			}
			else
			{
				playerName = (string)(grdPlayers.Rows[cells[0].RowIndex].Cells[0].Value);
			}

			if (playerName == null)
			{
				MessageBox.Show("No player selected", "Player Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				retVal = Server.Players[playerName];
				if (!retVal.IsConnected)
				{
					MessageBox.Show(string.Format("Selected player ({0}) is not connected.", playerName), "Player Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			return retVal;
		}

		private void ResetButtons()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(ResetButtons));
			}
			else
			{
				btnLaunch.Visible = true;
				btnPause.Visible = false;
				btnResume.Visible = false;
			}
		}





		private void ChatMessages_ItemAdded(object sender, ItemEventArgs<ChatMessage> e)
		{
			lock (chatLocker)
			{
				chatMessage = e.Item;
				AddChatMessage();
				chatMessage = null;
			}
		}

		private void ConsoleMessages_ItemAdded(object sender, ItemEventArgs<ConsoleMessage> e)
		{
			lock (consoleLocker)
			{
				consoleMessage = e.Item;
				ProcessConsoleMessage();
				consoleMessage = null;
			}
		}

		private void Server_PlayersItemAdded(object sender, ItemEventArgs<Player> e)
		{
			UpdatePlayersGrid();
		}

		private void Server_ProcessException(object sender, ExceptionEventArgs e)
		{
			Server.Interface.StopProcess();
			Server.StopProcess();

			if (e.Exception.GetType() != typeof(ObjectDisposedException)) // This happens if the user shuts down the extender without stopping the servers first... 
			{
				#region Message
				string msg = @"An unhandled exception occured during Extender Processing.
The Far Cry 2 Server has been shut down. You may launch a new session.
{0}";
				#endregion
				MessageBox.Show(string.Format(msg, e.Exception), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void Server_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Status":
				case "GameRunning":
				case "IsStarting":
					UpdateStatusLabel();
					UpdateStatusIcon();
					switch (Server.Status)
					{
						case ServerStates.Started:
							EnableForm();
							break;
						case ServerStates.In_Match:
							UpdatePlayersGrid();
							break;
						case ServerStates.Dead:
						case ServerStates.Stopped:
							ResetButtons();
							Server.Paused = false;
							DisableForm();
							break;
					}
					break;
				case "CurrentMap":
					UpdateServerNameLabel();
					break;
			}
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			UpdateCountDown();
		}

		private void btnResume_Click(object sender, EventArgs e)
		{
			btnPause.Visible = true;
			btnResume.Visible = false;
			Server.Paused = false;
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			btnPause.Visible = false;
			btnResume.Visible = true;
			Server.Paused = true;
		}

		private void InitializeConsole()
		{
			pnlConsole.SuspendLayout();
			tabConsole.SuspendLayout();
			tabViewer.SuspendLayout();
			SuspendLayout();

			pnlConsole.Controls.Clear();
			txtConsoleMessages = new TextBox();

			// 
			// txtConsoleMessages
			// 
			txtConsoleMessages.BackColor = System.Drawing.Color.Black;
			txtConsoleMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			txtConsoleMessages.ForeColor = System.Drawing.Color.Yellow;
			txtConsoleMessages.Location = new System.Drawing.Point(0, 0);
			txtConsoleMessages.Multiline = true;
			txtConsoleMessages.Name = "txtConsoleMessages";
			txtConsoleMessages.ReadOnly = true;
			txtConsoleMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtConsoleMessages.Size = new System.Drawing.Size(1020, 508);
			txtConsoleMessages.TabIndex = 2;
			txtConsoleMessages.WordWrap = false;

			pnlConsole.Controls.Add(txtConsoleMessages);

			pnlConsole.ResumeLayout(false);
			pnlConsole.PerformLayout();
			tabConsole.ResumeLayout(false);
			tabConsole.PerformLayout();
			tabViewer.ResumeLayout(false);
			tabViewer.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void btnLaunch_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Current Status: Not Started";
			InitializeConsole();

			txtConsoleMessages.Text = string.Empty;
			txtChatAll.Text = string.Empty;
			txtKillLog.Text = string.Empty;
		
			Server.StartServer();
		}

		private void grdPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Server.Players.Sort(grdPlayers.Columns[e.ColumnIndex].DataPropertyName);
			ApplyPlayersGridFilter();
		}

		private void mnuStopNoPlayers_Click(object sender, EventArgs e)
		{
			mnuStopNoPlayers.Checked = !mnuStopNoPlayers.Checked;
			Server.StopAtNoPlayers = mnuStopNoPlayers.Checked;
		}

		private void mnuStopEndRound_Click(object sender, EventArgs e)
		{
			mnuStopEndRound.Checked = !mnuStopEndRound.Checked;
			Server.StopAfterMatch = mnuStopEndRound.Checked;
		}

		private void btnRefreshGrid_Click(object sender, EventArgs e)
		{
			ApplyPlayersGridFilter();
		}

		private void mnuNoFilter_Click(object sender, EventArgs e)
		{
			ResetFilterChecks();
			ApplyPlayersGridFilter();
		}

		private void mnuConnected_Click(object sender, EventArgs e)
		{
			mnuConnected.Checked = !mnuConnected.Checked;
			if (mnuConnected.Checked)
			{
				mnuNoFilter.Checked = false;
				_currentFilter = Filters.Connected;
			}
			else
			{
				ResetFilterChecks();
			}
			ApplyPlayersGridFilter();
		}

		private void mnuBanPlayer_Click(object sender, EventArgs e)
		{
			BanPlayer(GetClickedPlayer());
		}

		private void mnuKickPlayer_Click(object sender, EventArgs e)
		{
			KickPlayer(GetClickedPlayer());
		}

		private void mnuWarnPlayer_Click(object sender, EventArgs e)
		{
			WarnPlayer(GetClickedPlayer());
		}

		private bool ConfirmPlayerAction(Player player, string action)
		{
			string msg = string.Format("Are you sure you want to {0} {1}?", action, player.Name);
			return (MessageBox.Show(msg, "Confirm Player Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
		}

		private void grdPlayers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Right) && (e.RowIndex >= 0) && (e.ColumnIndex >= 0))
			{
				grdPlayers.CurrentCell = grdPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex];
			}
		}

		private void btnCommand_Click(object sender, EventArgs e)
		{
			SendCommand();
		}

		private void mnuStopNow_Click(object sender, EventArgs e)
		{
			Server.Interface.StopProcess();
		}

		private void btnSay_Click(object sender, EventArgs e)
		{
			SayToAll();	
		}

		private void txtSay_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SayToAll();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private string commandHolder = string.Empty;
		private void txtCommand_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SendCommand();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Up)
			{
				commandHistory.MoveUp();
				if (commandHistory.HasCommand)
				{
					if ((commandHolder == string.Empty) && (txtCommand.Text != commandHistory.Command))
					{
						commandHolder = txtCommand.Text;
					}
					txtCommand.Text = commandHistory.Command;
				}
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				commandHistory.MoveDown();
				if (commandHistory.HasCommand)
				{
					txtCommand.Text = commandHistory.Command;
				}
				else
				{
					txtCommand.Text = commandHolder;
					commandHolder = string.Empty;
				}
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void extendMatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Server.Interface.ExtendMatch();
		}

		private void endMatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Server.Interface.EndMatch();
		}

		private void restartMatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Server.Interface.RestartMatch();
		}

		private void shuffleTeamsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Server.Interface.ShuffleTeams();
		}

		private void skipMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Server.Interface.SkipMap();
		}

		private void chatWithPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChatForm.Show(GetClickedPlayer().Name, Server);
		}

		private WinSize oldSize;
		private void StatusViewer_Resize(object sender, EventArgs e)
		{
			if (oldSize != WinSize.Empty)
			{
				double pct = ((double)txtKillLog.Size.Width) / ((double)oldSize.Width);
				txtKillLog.Width = (int)(Size.Width * pct);
			}
			oldSize = Size;
		}

		private void tabViewer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabViewer.SelectedTab == tabConsole)
			{
				txtConsoleMessages.SelectionStart = txtConsoleMessages.Text.Length;
				txtConsoleMessages.ScrollToCaret();
			}
			else
			{
				txtChatAll.SelectionStart = txtChatAll.Text.Length;
				txtChatAll.ScrollToCaret();

				txtKillLog.SelectionStart = txtKillLog.Text.Length;
				txtKillLog.ScrollToCaret();
			}
		}

		private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ServerSettings settings = _serverSettings.Clone();
			ServerSettings.CopyValues(_serverSettings, settings);
			if (ServerSettingsForm.Show(this, settings))
			{
				DialogResult result = DialogResult.Yes;

				if (Server.GameRunning)
				{
					#region message
					string msg = @"Apply settings now?
This will required the current match to end, if started.
Selecting No will apply the settings at the next restart.
Selecting cancel will abort all changes.";
					#endregion
					result = MessageBox.Show(msg, "Apply Settings?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
				}

				if (result != DialogResult.Cancel)
				{
					settings.Save();
					UpdateSettings(settings, (result == DialogResult.Yes));
				}
			}
		}

		public void UpdateSettings(ServerSettings settings, bool applyNow)
		{
			_serverSettings = settings;
			UpdateServerNameLabel();
			Server.ChangeSettings(settings, applyNow);
		}

		private void grdPlayers_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.Cancel = true;
			Server.ConsoleMessages.Add(new ConsoleMessage(ConsoleSources.Extender, MessageCategories.Warning, "Players Grid needs to be re-initialized."));
			ReInitGrid();
		}

		private void ReInitGrid()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(ReInitGrid));
			}
			else
			{
				try
				{
					pnlPlayers.SuspendLayout();
					grdPlayers.Columns.Clear();
					pnlPlayers.Controls.Clear();
					grdPlayers = new DataGridView();
					grdPlayers.SuspendLayout();

					grdPlayers.AllowUserToAddRows = false;
					grdPlayers.AllowUserToDeleteRows = false;
					grdPlayers.CausesValidation = false;
					grdPlayers.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle();
					grdPlayers.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
					grdPlayers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
					grdPlayers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					grdPlayers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
					grdPlayers.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
					grdPlayers.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
					grdPlayers.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
					grdPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
					grdPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { PlayerName, Team, MapKills, MapDeaths, MapSuicides, MapTeamKills, MapWarns, TotalKills, TotalDeaths, TotalSuicides, TotalTeamKills, TotalWarns, MatchesPlayed, Connected });
					grdPlayers.ContextMenuStrip = this.menuFilter;
					grdPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
					grdPlayers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
					grdPlayers.Location = new System.Drawing.Point(0, 0);
					grdPlayers.MultiSelect = false;
					grdPlayers.Name = "grdPlayers";
					grdPlayers.RowHeadersVisible = false;
					grdPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
					grdPlayers.Size = new System.Drawing.Size(1020, 147);
					grdPlayers.TabIndex = 6;
					grdPlayers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayers_ColumnHeaderMouseClick);
					grdPlayers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayers_CellMouseDown);
					grdPlayers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdPlayers_DataError);

					pnlPlayers.Controls.Add(grdPlayers);
					grdPlayers.ResumeLayout();
					pnlPlayers.ResumeLayout();

					_playerGridSource.DataSource = Server.Players;
					grdPlayers.AutoGenerateColumns = false;
					grdPlayers.DataSource = _playerGridSource;
				}
				catch (Exception ex)
				{
					string msg = string.Format("An error occured in while reinitializing the players grid.\r\n{0}", ex);
					MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
				}
			}
		}

	}
}
