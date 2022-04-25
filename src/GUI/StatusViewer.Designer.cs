namespace GSL
{
	partial class StatusViewer
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusViewer));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuNoFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuConnected = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBanPlayer = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuKickPlayer = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWarnPlayer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.chatWithPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuStopNoPlayers = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStopEndRound = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStopNow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.extendMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.endMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.shuffleTeamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.skipMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.editSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusImages = new System.Windows.Forms.ImageList(this.components);
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.tabViewer = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.pnlInteraction = new System.Windows.Forms.Panel();
			this.txtChatAll = new System.Windows.Forms.TextBox();
			this.pnlSayCommand = new System.Windows.Forms.Panel();
			this.txtSay = new System.Windows.Forms.TextBox();
			this.btnSay = new System.Windows.Forms.Button();
			this.splt = new System.Windows.Forms.Splitter();
			this.txtKillLog = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlPlayers = new System.Windows.Forms.Panel();
			this.grdPlayers = new System.Windows.Forms.DataGridView();
			this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MapKills = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MapDeaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MapSuicides = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MapTeamKills = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MapWarns = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalKills = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalDeaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalSuicides = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalTeamKills = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalWarns = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MatchesPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Connected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.btnRefreshGrid = new System.Windows.Forms.Button();
			this.btnResume = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.lblStatusIcon = new System.Windows.Forms.Label();
			this.btnLaunch = new System.Windows.Forms.Button();
			this.lblCountDown = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblServerName = new System.Windows.Forms.Label();
			this.tabConsole = new System.Windows.Forms.TabPage();
			this.pnlConsole = new System.Windows.Forms.Panel();
			this.pnlConsoleOptions = new System.Windows.Forms.Panel();
			this.grpCategories = new System.Windows.Forms.GroupBox();
			this.chkDebug = new System.Windows.Forms.CheckBox();
			this.chkWarnings = new System.Windows.Forms.CheckBox();
			this.chkErrors = new System.Windows.Forms.CheckBox();
			this.chkEvents = new System.Windows.Forms.CheckBox();
			this.chkKills = new System.Windows.Forms.CheckBox();
			this.chkChat = new System.Windows.Forms.CheckBox();
			this.chkGame = new System.Windows.Forms.CheckBox();
			this.grpSources = new System.Windows.Forms.GroupBox();
			this.chkExtender = new System.Windows.Forms.CheckBox();
			this.chkGameServer = new System.Windows.Forms.CheckBox();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.txtCommand = new System.Windows.Forms.TextBox();
			this.btnCommand = new System.Windows.Forms.Button();
			this.menuFilter.SuspendLayout();
			this.stopMenu.SuspendLayout();
			this.tabViewer.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.pnlInteraction.SuspendLayout();
			this.pnlSayCommand.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlPlayers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).BeginInit();
			this.tabConsole.SuspendLayout();
			this.pnlConsoleOptions.SuspendLayout();
			this.grpCategories.SuspendLayout();
			this.grpSources.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuFilter
			// 
			this.menuFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNoFilter,
            this.mnuConnected,
            this.mnuSeparator1,
            this.mnuBanPlayer,
            this.mnuKickPlayer,
            this.mnuWarnPlayer,
            this.toolStripSeparator3,
            this.chatWithPlayerToolStripMenuItem});
			this.menuFilter.Name = "menuFilter";
			this.menuFilter.Size = new System.Drawing.Size(193, 148);
			// 
			// mnuNoFilter
			// 
			this.mnuNoFilter.Name = "mnuNoFilter";
			this.mnuNoFilter.Size = new System.Drawing.Size(192, 22);
			this.mnuNoFilter.Text = "Remove Filter";
			this.mnuNoFilter.Click += new System.EventHandler(this.mnuNoFilter_Click);
			// 
			// mnuConnected
			// 
			this.mnuConnected.Checked = true;
			this.mnuConnected.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mnuConnected.Name = "mnuConnected";
			this.mnuConnected.Size = new System.Drawing.Size(192, 22);
			this.mnuConnected.Text = "Show Connected Only";
			this.mnuConnected.Click += new System.EventHandler(this.mnuConnected_Click);
			// 
			// mnuSeparator1
			// 
			this.mnuSeparator1.Name = "mnuSeparator1";
			this.mnuSeparator1.Size = new System.Drawing.Size(189, 6);
			// 
			// mnuBanPlayer
			// 
			this.mnuBanPlayer.Name = "mnuBanPlayer";
			this.mnuBanPlayer.Size = new System.Drawing.Size(192, 22);
			this.mnuBanPlayer.Text = "Ban Player";
			this.mnuBanPlayer.Click += new System.EventHandler(this.mnuBanPlayer_Click);
			// 
			// mnuKickPlayer
			// 
			this.mnuKickPlayer.Name = "mnuKickPlayer";
			this.mnuKickPlayer.Size = new System.Drawing.Size(192, 22);
			this.mnuKickPlayer.Text = "Kick Player";
			this.mnuKickPlayer.Click += new System.EventHandler(this.mnuKickPlayer_Click);
			// 
			// mnuWarnPlayer
			// 
			this.mnuWarnPlayer.Name = "mnuWarnPlayer";
			this.mnuWarnPlayer.Size = new System.Drawing.Size(192, 22);
			this.mnuWarnPlayer.Text = "Warn Player";
			this.mnuWarnPlayer.Click += new System.EventHandler(this.mnuWarnPlayer_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
			// 
			// chatWithPlayerToolStripMenuItem
			// 
			this.chatWithPlayerToolStripMenuItem.Name = "chatWithPlayerToolStripMenuItem";
			this.chatWithPlayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.chatWithPlayerToolStripMenuItem.Text = "Chat with Player";
			this.chatWithPlayerToolStripMenuItem.Click += new System.EventHandler(this.chatWithPlayerToolStripMenuItem_Click);
			// 
			// stopMenu
			// 
			this.stopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStopNoPlayers,
            this.mnuStopEndRound,
            this.mnuStopNow,
            this.toolStripSeparator1,
            this.extendMatchToolStripMenuItem,
            this.endMatchToolStripMenuItem,
            this.restartMatchToolStripMenuItem,
            this.toolStripSeparator2,
            this.shuffleTeamsToolStripMenuItem,
            this.skipMapToolStripMenuItem,
            this.toolStripSeparator4,
            this.editSettingsToolStripMenuItem});
			this.stopMenu.Name = "stopMenu";
			this.stopMenu.Size = new System.Drawing.Size(177, 220);
			// 
			// mnuStopNoPlayers
			// 
			this.mnuStopNoPlayers.Name = "mnuStopNoPlayers";
			this.mnuStopNoPlayers.Size = new System.Drawing.Size(176, 22);
			this.mnuStopNoPlayers.Text = "Stop at zero players";
			this.mnuStopNoPlayers.Click += new System.EventHandler(this.mnuStopNoPlayers_Click);
			// 
			// mnuStopEndRound
			// 
			this.mnuStopEndRound.Name = "mnuStopEndRound";
			this.mnuStopEndRound.Size = new System.Drawing.Size(176, 22);
			this.mnuStopEndRound.Text = "Stop at match end";
			this.mnuStopEndRound.Click += new System.EventHandler(this.mnuStopEndRound_Click);
			// 
			// mnuStopNow
			// 
			this.mnuStopNow.Name = "mnuStopNow";
			this.mnuStopNow.Size = new System.Drawing.Size(176, 22);
			this.mnuStopNow.Text = "Stop Now";
			this.mnuStopNow.Click += new System.EventHandler(this.mnuStopNow_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
			// 
			// extendMatchToolStripMenuItem
			// 
			this.extendMatchToolStripMenuItem.Name = "extendMatchToolStripMenuItem";
			this.extendMatchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.extendMatchToolStripMenuItem.Text = "Extend Match";
			this.extendMatchToolStripMenuItem.Click += new System.EventHandler(this.extendMatchToolStripMenuItem_Click);
			// 
			// endMatchToolStripMenuItem
			// 
			this.endMatchToolStripMenuItem.Name = "endMatchToolStripMenuItem";
			this.endMatchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.endMatchToolStripMenuItem.Text = "End Match";
			this.endMatchToolStripMenuItem.Click += new System.EventHandler(this.endMatchToolStripMenuItem_Click);
			// 
			// restartMatchToolStripMenuItem
			// 
			this.restartMatchToolStripMenuItem.Name = "restartMatchToolStripMenuItem";
			this.restartMatchToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.restartMatchToolStripMenuItem.Text = "Restart Match";
			this.restartMatchToolStripMenuItem.Click += new System.EventHandler(this.restartMatchToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
			// 
			// shuffleTeamsToolStripMenuItem
			// 
			this.shuffleTeamsToolStripMenuItem.Name = "shuffleTeamsToolStripMenuItem";
			this.shuffleTeamsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.shuffleTeamsToolStripMenuItem.Text = "Shuffle Teams";
			this.shuffleTeamsToolStripMenuItem.Click += new System.EventHandler(this.shuffleTeamsToolStripMenuItem_Click);
			// 
			// skipMapToolStripMenuItem
			// 
			this.skipMapToolStripMenuItem.Name = "skipMapToolStripMenuItem";
			this.skipMapToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.skipMapToolStripMenuItem.Text = "Skip Map";
			this.skipMapToolStripMenuItem.Click += new System.EventHandler(this.skipMapToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
			// 
			// editSettingsToolStripMenuItem
			// 
			this.editSettingsToolStripMenuItem.Name = "editSettingsToolStripMenuItem";
			this.editSettingsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.editSettingsToolStripMenuItem.Text = "Edit Settings";
			this.editSettingsToolStripMenuItem.Click += new System.EventHandler(this.editSettingsToolStripMenuItem_Click);
			// 
			// StatusImages
			// 
			this.StatusImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImages.ImageStream")));
			this.StatusImages.TransparentColor = System.Drawing.Color.White;
			this.StatusImages.Images.SetKeyName(0, "Green");
			this.StatusImages.Images.SetKeyName(1, "Yellow");
			this.StatusImages.Images.SetKeyName(2, "Red");
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Interval = 1000;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// tabViewer
			// 
			this.tabViewer.Controls.Add(this.tabMain);
			this.tabViewer.Controls.Add(this.tabConsole);
			this.tabViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabViewer.Location = new System.Drawing.Point(0, 0);
			this.tabViewer.Name = "tabViewer";
			this.tabViewer.SelectedIndex = 0;
			this.tabViewer.Size = new System.Drawing.Size(1034, 635);
			this.tabViewer.TabIndex = 0;
			this.tabViewer.SelectedIndexChanged += new System.EventHandler(this.tabViewer_SelectedIndexChanged);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.pnlInteraction);
			this.tabMain.Controls.Add(this.splitter1);
			this.tabMain.Controls.Add(this.pnlHeader);
			this.tabMain.Location = new System.Drawing.Point(4, 22);
			this.tabMain.Name = "tabMain";
			this.tabMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabMain.Size = new System.Drawing.Size(1026, 609);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Status";
			this.tabMain.UseVisualStyleBackColor = true;
			// 
			// pnlInteraction
			// 
			this.pnlInteraction.Controls.Add(this.txtChatAll);
			this.pnlInteraction.Controls.Add(this.pnlSayCommand);
			this.pnlInteraction.Controls.Add(this.splt);
			this.pnlInteraction.Controls.Add(this.txtKillLog);
			this.pnlInteraction.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlInteraction.Location = new System.Drawing.Point(3, 218);
			this.pnlInteraction.Name = "pnlInteraction";
			this.pnlInteraction.Size = new System.Drawing.Size(1020, 388);
			this.pnlInteraction.TabIndex = 7;
			// 
			// txtChatAll
			// 
			this.txtChatAll.BackColor = System.Drawing.Color.Black;
			this.txtChatAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtChatAll.ForeColor = System.Drawing.Color.Yellow;
			this.txtChatAll.Location = new System.Drawing.Point(0, 0);
			this.txtChatAll.Multiline = true;
			this.txtChatAll.Name = "txtChatAll";
			this.txtChatAll.ReadOnly = true;
			this.txtChatAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChatAll.Size = new System.Drawing.Size(740, 366);
			this.txtChatAll.TabIndex = 0;
			this.txtChatAll.WordWrap = false;
			// 
			// pnlSayCommand
			// 
			this.pnlSayCommand.Controls.Add(this.txtSay);
			this.pnlSayCommand.Controls.Add(this.btnSay);
			this.pnlSayCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSayCommand.Location = new System.Drawing.Point(0, 366);
			this.pnlSayCommand.Name = "pnlSayCommand";
			this.pnlSayCommand.Size = new System.Drawing.Size(740, 22);
			this.pnlSayCommand.TabIndex = 16;
			// 
			// txtSay
			// 
			this.txtSay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSay.Location = new System.Drawing.Point(0, 0);
			this.txtSay.MaxLength = 40;
			this.txtSay.Name = "txtSay";
			this.txtSay.Size = new System.Drawing.Size(698, 20);
			this.txtSay.TabIndex = 0;
			this.txtSay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSay_KeyDown);
			// 
			// btnSay
			// 
			this.btnSay.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSay.Location = new System.Drawing.Point(698, 0);
			this.btnSay.Name = "btnSay";
			this.btnSay.Size = new System.Drawing.Size(42, 22);
			this.btnSay.TabIndex = 1;
			this.btnSay.Text = "Say";
			this.btnSay.UseVisualStyleBackColor = true;
			this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
			// 
			// splt
			// 
			this.splt.Dock = System.Windows.Forms.DockStyle.Right;
			this.splt.Location = new System.Drawing.Point(740, 0);
			this.splt.Name = "splt";
			this.splt.Size = new System.Drawing.Size(5, 388);
			this.splt.TabIndex = 1;
			this.splt.TabStop = false;
			// 
			// txtKillLog
			// 
			this.txtKillLog.BackColor = System.Drawing.Color.Black;
			this.txtKillLog.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtKillLog.ForeColor = System.Drawing.Color.Yellow;
			this.txtKillLog.Location = new System.Drawing.Point(745, 0);
			this.txtKillLog.Multiline = true;
			this.txtKillLog.Name = "txtKillLog";
			this.txtKillLog.ReadOnly = true;
			this.txtKillLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtKillLog.Size = new System.Drawing.Size(275, 388);
			this.txtKillLog.TabIndex = 2;
			this.txtKillLog.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(3, 213);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1020, 5);
			this.splitter1.TabIndex = 0;
			this.splitter1.TabStop = false;
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.pnlPlayers);
			this.pnlHeader.Controls.Add(this.btnRefreshGrid);
			this.pnlHeader.Controls.Add(this.btnResume);
			this.pnlHeader.Controls.Add(this.btnPause);
			this.pnlHeader.Controls.Add(this.lblStatusIcon);
			this.pnlHeader.Controls.Add(this.btnLaunch);
			this.pnlHeader.Controls.Add(this.lblCountDown);
			this.pnlHeader.Controls.Add(this.lblStatus);
			this.pnlHeader.Controls.Add(this.lblServerName);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(3, 3);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1020, 210);
			this.pnlHeader.TabIndex = 1;
			// 
			// pnlPlayers
			// 
			this.pnlPlayers.Controls.Add(this.grdPlayers);
			this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPlayers.Location = new System.Drawing.Point(0, 63);
			this.pnlPlayers.Name = "pnlPlayers";
			this.pnlPlayers.Size = new System.Drawing.Size(1020, 147);
			this.pnlPlayers.TabIndex = 8;
			// 
			// grdPlayers
			// 
			this.grdPlayers.AllowUserToAddRows = false;
			this.grdPlayers.AllowUserToDeleteRows = false;
			this.grdPlayers.CausesValidation = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Team,
            this.MapKills,
            this.MapDeaths,
            this.MapSuicides,
            this.MapTeamKills,
            this.MapWarns,
            this.TotalKills,
            this.TotalDeaths,
            this.TotalSuicides,
            this.TotalTeamKills,
            this.TotalWarns,
            this.MatchesPlayed,
            this.Connected});
			this.grdPlayers.ContextMenuStrip = this.menuFilter;
			this.grdPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdPlayers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.grdPlayers.Location = new System.Drawing.Point(0, 0);
			this.grdPlayers.MultiSelect = false;
			this.grdPlayers.Name = "grdPlayers";
			this.grdPlayers.RowHeadersVisible = false;
			this.grdPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.grdPlayers.Size = new System.Drawing.Size(1020, 147);
			this.grdPlayers.TabIndex = 6;
			this.grdPlayers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayers_CellMouseDown);
			this.grdPlayers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayers_ColumnHeaderMouseClick);
			this.grdPlayers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdPlayers_DataError);
			// 
			// PlayerName
			// 
			this.PlayerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.PlayerName.DataPropertyName = "Name";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.PlayerName.DefaultCellStyle = dataGridViewCellStyle2;
			this.PlayerName.HeaderText = "Player Name";
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.ReadOnly = true;
			this.PlayerName.Width = 120;
			// 
			// Team
			// 
			this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Team.DataPropertyName = "Team";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.Team.DefaultCellStyle = dataGridViewCellStyle3;
			this.Team.HeaderText = "Team";
			this.Team.Name = "Team";
			this.Team.ReadOnly = true;
			this.Team.Width = 50;
			// 
			// MapKills
			// 
			this.MapKills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MapKills.DataPropertyName = "MapKills";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MapKills.DefaultCellStyle = dataGridViewCellStyle4;
			this.MapKills.HeaderText = "Map Kill";
			this.MapKills.Name = "MapKills";
			this.MapKills.ReadOnly = true;
			this.MapKills.ToolTipText = "Current Map Kills";
			this.MapKills.Width = 35;
			// 
			// MapDeaths
			// 
			this.MapDeaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MapDeaths.DataPropertyName = "MapDeaths";
			this.MapDeaths.HeaderText = "Map Dths";
			this.MapDeaths.Name = "MapDeaths";
			this.MapDeaths.ReadOnly = true;
			this.MapDeaths.ToolTipText = "Current Map Deaths";
			this.MapDeaths.Width = 30;
			// 
			// MapSuicides
			// 
			this.MapSuicides.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MapSuicides.DataPropertyName = "MapSuicides";
			this.MapSuicides.HeaderText = "Map Scid";
			this.MapSuicides.Name = "MapSuicides";
			this.MapSuicides.ReadOnly = true;
			this.MapSuicides.ToolTipText = "Current Map Suicides";
			this.MapSuicides.Width = 30;
			// 
			// MapTeamKills
			// 
			this.MapTeamKills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MapTeamKills.DataPropertyName = "MapTeamKills";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MapTeamKills.DefaultCellStyle = dataGridViewCellStyle5;
			this.MapTeamKills.HeaderText = "Map TK";
			this.MapTeamKills.Name = "MapTeamKills";
			this.MapTeamKills.ReadOnly = true;
			this.MapTeamKills.ToolTipText = "Current Map Team Kills";
			this.MapTeamKills.Width = 30;
			// 
			// MapWarns
			// 
			this.MapWarns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MapWarns.DataPropertyName = "MapWarnings";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MapWarns.DefaultCellStyle = dataGridViewCellStyle6;
			this.MapWarns.HeaderText = "Map Wrn";
			this.MapWarns.Name = "MapWarns";
			this.MapWarns.ToolTipText = "Current Map Warnings";
			this.MapWarns.Width = 30;
			// 
			// TotalKills
			// 
			this.TotalKills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.TotalKills.DataPropertyName = "TotalKills";
			this.TotalKills.HeaderText = "Tot Kill";
			this.TotalKills.Name = "TotalKills";
			this.TotalKills.ReadOnly = true;
			this.TotalKills.ToolTipText = "Total Kills";
			this.TotalKills.Width = 35;
			// 
			// TotalDeaths
			// 
			this.TotalDeaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.TotalDeaths.DataPropertyName = "TotalDeaths";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TotalDeaths.DefaultCellStyle = dataGridViewCellStyle7;
			this.TotalDeaths.HeaderText = "Tot Dths";
			this.TotalDeaths.Name = "TotalDeaths";
			this.TotalDeaths.ReadOnly = true;
			this.TotalDeaths.ToolTipText = "Total Deaths";
			this.TotalDeaths.Width = 35;
			// 
			// TotalSuicides
			// 
			this.TotalSuicides.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.TotalSuicides.DataPropertyName = "TotalSuicides";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TotalSuicides.DefaultCellStyle = dataGridViewCellStyle8;
			this.TotalSuicides.HeaderText = "Tot Scid";
			this.TotalSuicides.Name = "TotalSuicides";
			this.TotalSuicides.ReadOnly = true;
			this.TotalSuicides.ToolTipText = "Total Suicides";
			this.TotalSuicides.Width = 35;
			// 
			// TotalTeamKills
			// 
			this.TotalTeamKills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.TotalTeamKills.DataPropertyName = "TotalTeamKills";
			this.TotalTeamKills.HeaderText = "Tot TK";
			this.TotalTeamKills.Name = "TotalTeamKills";
			this.TotalTeamKills.ReadOnly = true;
			this.TotalTeamKills.ToolTipText = "Total Team Kills";
			this.TotalTeamKills.Width = 35;
			// 
			// TotalWarns
			// 
			this.TotalWarns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.TotalWarns.DataPropertyName = "TotalWarnings";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TotalWarns.DefaultCellStyle = dataGridViewCellStyle9;
			this.TotalWarns.HeaderText = "Tot Wrn";
			this.TotalWarns.Name = "TotalWarns";
			this.TotalWarns.ToolTipText = "Total Warnings";
			this.TotalWarns.Width = 35;
			// 
			// MatchesPlayed
			// 
			this.MatchesPlayed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.MatchesPlayed.DataPropertyName = "MatchesPlayed";
			this.MatchesPlayed.HeaderText = "M.P.";
			this.MatchesPlayed.Name = "MatchesPlayed";
			this.MatchesPlayed.ReadOnly = true;
			this.MatchesPlayed.ToolTipText = "Matches Played";
			this.MatchesPlayed.Width = 30;
			// 
			// Connected
			// 
			this.Connected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Connected.DataPropertyName = "IsConnected";
			this.Connected.HeaderText = "Cnd";
			this.Connected.Name = "Connected";
			this.Connected.ReadOnly = true;
			this.Connected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Connected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Connected.ToolTipText = "Connected";
			this.Connected.Width = 30;
			// 
			// btnRefreshGrid
			// 
			this.btnRefreshGrid.Location = new System.Drawing.Point(3, 34);
			this.btnRefreshGrid.Name = "btnRefreshGrid";
			this.btnRefreshGrid.Size = new System.Drawing.Size(75, 23);
			this.btnRefreshGrid.TabIndex = 3;
			this.btnRefreshGrid.Text = "Refresh &Grid";
			this.btnRefreshGrid.UseVisualStyleBackColor = true;
			this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
			// 
			// btnResume
			// 
			this.btnResume.Location = new System.Drawing.Point(3, 8);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(75, 23);
			this.btnResume.TabIndex = 1;
			this.btnResume.Text = "&Resume";
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Visible = false;
			this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
			// 
			// btnPause
			// 
			this.btnPause.Location = new System.Drawing.Point(3, 8);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(75, 23);
			this.btnPause.TabIndex = 7;
			this.btnPause.Text = "&Pause";
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Visible = false;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// lblStatusIcon
			// 
			this.lblStatusIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatusIcon.ContextMenuStrip = this.stopMenu;
			this.lblStatusIcon.ImageIndex = 1;
			this.lblStatusIcon.ImageList = this.StatusImages;
			this.lblStatusIcon.Location = new System.Drawing.Point(957, 0);
			this.lblStatusIcon.Name = "lblStatusIcon";
			this.lblStatusIcon.Size = new System.Drawing.Size(60, 60);
			this.lblStatusIcon.TabIndex = 6;
			// 
			// btnLaunch
			// 
			this.btnLaunch.Location = new System.Drawing.Point(3, 8);
			this.btnLaunch.Name = "btnLaunch";
			this.btnLaunch.Size = new System.Drawing.Size(75, 23);
			this.btnLaunch.TabIndex = 4;
			this.btnLaunch.Text = "&Start";
			this.btnLaunch.UseVisualStyleBackColor = true;
			this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
			// 
			// lblCountDown
			// 
			this.lblCountDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCountDown.Location = new System.Drawing.Point(0, 43);
			this.lblCountDown.Name = "lblCountDown";
			this.lblCountDown.Size = new System.Drawing.Size(1020, 20);
			this.lblCountDown.TabIndex = 4;
			this.lblCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblStatus
			// 
			this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblStatus.Location = new System.Drawing.Point(0, 23);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(1020, 20);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "Current Status: Not Launched";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblServerName
			// 
			this.lblServerName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblServerName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblServerName.Location = new System.Drawing.Point(0, 0);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(1020, 23);
			this.lblServerName.TabIndex = 0;
			this.lblServerName.Text = "Far Cry 2 Server";
			this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabConsole
			// 
			this.tabConsole.Controls.Add(this.pnlConsole);
			this.tabConsole.Controls.Add(this.pnlConsoleOptions);
			this.tabConsole.Controls.Add(this.pnlCommand);
			this.tabConsole.Location = new System.Drawing.Point(4, 22);
			this.tabConsole.Name = "tabConsole";
			this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
			this.tabConsole.Size = new System.Drawing.Size(1026, 609);
			this.tabConsole.TabIndex = 1;
			this.tabConsole.Text = "Console";
			this.tabConsole.UseVisualStyleBackColor = true;
			// 
			// pnlConsole
			// 
			this.pnlConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlConsole.Location = new System.Drawing.Point(3, 76);
			this.pnlConsole.Name = "pnlConsole";
			this.pnlConsole.Size = new System.Drawing.Size(1020, 508);
			this.pnlConsole.TabIndex = 10;
			// 
			// pnlConsoleOptions
			// 
			this.pnlConsoleOptions.Controls.Add(this.grpCategories);
			this.pnlConsoleOptions.Controls.Add(this.grpSources);
			this.pnlConsoleOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlConsoleOptions.Location = new System.Drawing.Point(3, 3);
			this.pnlConsoleOptions.Name = "pnlConsoleOptions";
			this.pnlConsoleOptions.Size = new System.Drawing.Size(1020, 73);
			this.pnlConsoleOptions.TabIndex = 0;
			// 
			// grpCategories
			// 
			this.grpCategories.Controls.Add(this.chkDebug);
			this.grpCategories.Controls.Add(this.chkWarnings);
			this.grpCategories.Controls.Add(this.chkErrors);
			this.grpCategories.Controls.Add(this.chkEvents);
			this.grpCategories.Controls.Add(this.chkKills);
			this.grpCategories.Controls.Add(this.chkChat);
			this.grpCategories.Controls.Add(this.chkGame);
			this.grpCategories.Location = new System.Drawing.Point(161, 3);
			this.grpCategories.Name = "grpCategories";
			this.grpCategories.Size = new System.Drawing.Size(417, 64);
			this.grpCategories.TabIndex = 0;
			this.grpCategories.TabStop = false;
			this.grpCategories.Text = "Message Categories";
			// 
			// chkDebug
			// 
			this.chkDebug.AutoSize = true;
			this.chkDebug.Checked = true;
			this.chkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDebug.Location = new System.Drawing.Point(336, 19);
			this.chkDebug.Name = "chkDebug";
			this.chkDebug.Size = new System.Drawing.Size(44, 17);
			this.chkDebug.TabIndex = 6;
			this.chkDebug.Text = "Info";
			this.chkDebug.UseVisualStyleBackColor = true;
			this.chkDebug.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkWarnings
			// 
			this.chkWarnings.AutoSize = true;
			this.chkWarnings.Checked = true;
			this.chkWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkWarnings.Location = new System.Drawing.Point(226, 41);
			this.chkWarnings.Name = "chkWarnings";
			this.chkWarnings.Size = new System.Drawing.Size(71, 17);
			this.chkWarnings.TabIndex = 5;
			this.chkWarnings.Text = "Warnings";
			this.chkWarnings.UseVisualStyleBackColor = true;
			this.chkWarnings.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkErrors
			// 
			this.chkErrors.AutoSize = true;
			this.chkErrors.Checked = true;
			this.chkErrors.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkErrors.Location = new System.Drawing.Point(226, 19);
			this.chkErrors.Name = "chkErrors";
			this.chkErrors.Size = new System.Drawing.Size(53, 17);
			this.chkErrors.TabIndex = 4;
			this.chkErrors.Text = "Errors";
			this.chkErrors.UseVisualStyleBackColor = true;
			this.chkErrors.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkEvents
			// 
			this.chkEvents.AutoSize = true;
			this.chkEvents.Checked = true;
			this.chkEvents.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEvents.Location = new System.Drawing.Point(122, 41);
			this.chkEvents.Name = "chkEvents";
			this.chkEvents.Size = new System.Drawing.Size(59, 17);
			this.chkEvents.TabIndex = 3;
			this.chkEvents.Text = "Events";
			this.chkEvents.UseVisualStyleBackColor = true;
			this.chkEvents.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkKills
			// 
			this.chkKills.AutoSize = true;
			this.chkKills.Checked = true;
			this.chkKills.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkKills.Location = new System.Drawing.Point(122, 18);
			this.chkKills.Name = "chkKills";
			this.chkKills.Size = new System.Drawing.Size(44, 17);
			this.chkKills.TabIndex = 2;
			this.chkKills.Text = "Kills";
			this.chkKills.UseVisualStyleBackColor = true;
			this.chkKills.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkChat
			// 
			this.chkChat.AutoSize = true;
			this.chkChat.Checked = true;
			this.chkChat.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkChat.Location = new System.Drawing.Point(15, 42);
			this.chkChat.Name = "chkChat";
			this.chkChat.Size = new System.Drawing.Size(48, 17);
			this.chkChat.TabIndex = 1;
			this.chkChat.Text = "Chat";
			this.chkChat.UseVisualStyleBackColor = true;
			this.chkChat.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// chkGame
			// 
			this.chkGame.AutoSize = true;
			this.chkGame.Checked = true;
			this.chkGame.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkGame.Location = new System.Drawing.Point(15, 19);
			this.chkGame.Name = "chkGame";
			this.chkGame.Size = new System.Drawing.Size(54, 17);
			this.chkGame.TabIndex = 0;
			this.chkGame.Text = "Game";
			this.chkGame.UseVisualStyleBackColor = true;
			this.chkGame.CheckedChanged += new System.EventHandler(this.UpdateCategoryFilter);
			// 
			// grpSources
			// 
			this.grpSources.Controls.Add(this.chkExtender);
			this.grpSources.Controls.Add(this.chkGameServer);
			this.grpSources.Location = new System.Drawing.Point(3, 3);
			this.grpSources.Name = "grpSources";
			this.grpSources.Size = new System.Drawing.Size(152, 64);
			this.grpSources.TabIndex = 1;
			this.grpSources.TabStop = false;
			this.grpSources.Text = "Message Sources";
			// 
			// chkExtender
			// 
			this.chkExtender.AutoSize = true;
			this.chkExtender.Checked = true;
			this.chkExtender.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkExtender.Location = new System.Drawing.Point(23, 42);
			this.chkExtender.Name = "chkExtender";
			this.chkExtender.Size = new System.Drawing.Size(68, 17);
			this.chkExtender.TabIndex = 1;
			this.chkExtender.Text = "Extender";
			this.chkExtender.UseVisualStyleBackColor = true;
			this.chkExtender.CheckedChanged += new System.EventHandler(this.UpdateSourceFilter);
			// 
			// chkGameServer
			// 
			this.chkGameServer.AutoSize = true;
			this.chkGameServer.Checked = true;
			this.chkGameServer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkGameServer.Location = new System.Drawing.Point(23, 19);
			this.chkGameServer.Name = "chkGameServer";
			this.chkGameServer.Size = new System.Drawing.Size(88, 17);
			this.chkGameServer.TabIndex = 0;
			this.chkGameServer.Text = "Game Server";
			this.chkGameServer.UseVisualStyleBackColor = true;
			this.chkGameServer.CheckedChanged += new System.EventHandler(this.UpdateSourceFilter);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.txtCommand);
			this.pnlCommand.Controls.Add(this.btnCommand);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(3, 584);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Size = new System.Drawing.Size(1020, 22);
			this.pnlCommand.TabIndex = 9;
			// 
			// txtCommand
			// 
			this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCommand.Location = new System.Drawing.Point(0, 0);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(960, 20);
			this.txtCommand.TabIndex = 0;
			this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
			// 
			// btnCommand
			// 
			this.btnCommand.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCommand.Location = new System.Drawing.Point(960, 0);
			this.btnCommand.Name = "btnCommand";
			this.btnCommand.Size = new System.Drawing.Size(60, 22);
			this.btnCommand.TabIndex = 1;
			this.btnCommand.Text = "Execute";
			this.btnCommand.UseVisualStyleBackColor = true;
			this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
			// 
			// StatusViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.tabViewer);
			this.Name = "StatusViewer";
			this.Size = new System.Drawing.Size(1034, 635);
			this.Resize += new System.EventHandler(this.StatusViewer_Resize);
			this.menuFilter.ResumeLayout(false);
			this.stopMenu.ResumeLayout(false);
			this.tabViewer.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.pnlInteraction.ResumeLayout(false);
			this.pnlInteraction.PerformLayout();
			this.pnlSayCommand.ResumeLayout(false);
			this.pnlSayCommand.PerformLayout();
			this.pnlHeader.ResumeLayout(false);
			this.pnlPlayers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).EndInit();
			this.tabConsole.ResumeLayout(false);
			this.pnlConsoleOptions.ResumeLayout(false);
			this.grpCategories.ResumeLayout(false);
			this.grpCategories.PerformLayout();
			this.grpSources.ResumeLayout(false);
			this.grpSources.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			this.pnlCommand.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList StatusImages;
		private System.Windows.Forms.Timer tmrUpdate;
		private System.Windows.Forms.ContextMenuStrip stopMenu;
		private System.Windows.Forms.ToolStripMenuItem mnuStopNoPlayers;
		private System.Windows.Forms.ToolStripMenuItem mnuStopEndRound;
		private System.Windows.Forms.ContextMenuStrip menuFilter;
		private System.Windows.Forms.ToolStripMenuItem mnuConnected;
		private System.Windows.Forms.ToolStripMenuItem mnuNoFilter;
		private System.Windows.Forms.ToolStripSeparator mnuSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuBanPlayer;
		private System.Windows.Forms.ToolStripMenuItem mnuKickPlayer;
		private System.Windows.Forms.ToolStripMenuItem mnuWarnPlayer;
		private System.Windows.Forms.ToolStripMenuItem mnuStopNow;
		private System.Windows.Forms.TabControl tabViewer;
		private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.Panel pnlInteraction;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Button btnRefreshGrid;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Label lblStatusIcon;
		private System.Windows.Forms.Button btnLaunch;
		private System.Windows.Forms.Label lblCountDown;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.TabPage tabConsole;
		private System.Windows.Forms.Panel pnlConsoleOptions;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.TextBox txtCommand;
		private System.Windows.Forms.Button btnCommand;
		private System.Windows.Forms.Panel pnlSayCommand;
		private System.Windows.Forms.TextBox txtSay;
		private System.Windows.Forms.Button btnSay;
		private System.Windows.Forms.Splitter splt;
		private System.Windows.Forms.TextBox txtKillLog;
		private System.Windows.Forms.TextBox txtChatAll;
		private System.Windows.Forms.GroupBox grpCategories;
		private System.Windows.Forms.CheckBox chkDebug;
		private System.Windows.Forms.CheckBox chkWarnings;
		private System.Windows.Forms.CheckBox chkErrors;
		private System.Windows.Forms.CheckBox chkEvents;
		private System.Windows.Forms.CheckBox chkKills;
		private System.Windows.Forms.CheckBox chkChat;
		private System.Windows.Forms.CheckBox chkGame;
		private System.Windows.Forms.GroupBox grpSources;
		private System.Windows.Forms.CheckBox chkExtender;
		private System.Windows.Forms.CheckBox chkGameServer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem extendMatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem endMatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restartMatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem shuffleTeamsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem skipMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem chatWithPlayerToolStripMenuItem;
		private System.Windows.Forms.Panel pnlConsole;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem editSettingsToolStripMenuItem;
		private System.Windows.Forms.Panel pnlPlayers;
		private System.Windows.Forms.DataGridView grdPlayers;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Team;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapKills;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapDeaths;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapSuicides;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapTeamKills;
		private System.Windows.Forms.DataGridViewTextBoxColumn MapWarns;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalKills;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalDeaths;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalSuicides;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalTeamKills;
		private System.Windows.Forms.DataGridViewTextBoxColumn TotalWarns;
		private System.Windows.Forms.DataGridViewTextBoxColumn MatchesPlayed;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Connected;

	}
}
