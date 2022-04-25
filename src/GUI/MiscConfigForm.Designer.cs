namespace GSL
{
	partial class MiscConfigForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpAutoRestart = new System.Windows.Forms.GroupBox();
			this.lblStartTimeout = new System.Windows.Forms.Label();
			this.lblRestartWait = new System.Windows.Forms.Label();
			this.numStartTimeout = new System.Windows.Forms.NumericUpDown();
			this.numRestartWait = new System.Windows.Forms.NumericUpDown();
			this.chkAutoRestart = new System.Windows.Forms.CheckBox();
			this.grpServers = new System.Windows.Forms.GroupBox();
			this.btnAddServer = new System.Windows.Forms.Button();
			this.grdServers = new System.Windows.Forms.DataGridView();
			this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnEditServer = new System.Windows.Forms.DataGridViewButtonColumn();
			this.grpMessages = new System.Windows.Forms.GroupBox();
			this.lblMessages = new System.Windows.Forms.Label();
			this.grdMessages = new System.Windows.Forms.DataGridView();
			this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblWelcomeMsg = new System.Windows.Forms.Label();
			this.btnWelcome = new System.Windows.Forms.Button();
			this.txtWelcome = new System.Windows.Forms.TextBox();
			this.lblMessageWait = new System.Windows.Forms.Label();
			this.numMessageWait = new System.Windows.Forms.NumericUpDown();
			this.grpLogStats = new System.Windows.Forms.GroupBox();
			this.btnStatsLog = new System.Windows.Forms.Button();
			this.txtStatsLog = new System.Windows.Forms.TextBox();
			this.chkStatsLog = new System.Windows.Forms.CheckBox();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.chkAutoAdjustMinPlayers = new System.Windows.Forms.CheckBox();
			this.numMinPlayerPercent = new System.Windows.Forms.NumericUpDown();
			this.grpAutoRestart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStartTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestartWait)).BeginInit();
			this.grpServers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdServers)).BeginInit();
			this.grpMessages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMessageWait)).BeginInit();
			this.grpLogStats.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMinPlayerPercent)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(507, 413);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(426, 413);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// grpAutoRestart
			// 
			this.grpAutoRestart.Controls.Add(this.lblStartTimeout);
			this.grpAutoRestart.Controls.Add(this.lblRestartWait);
			this.grpAutoRestart.Controls.Add(this.numStartTimeout);
			this.grpAutoRestart.Controls.Add(this.numRestartWait);
			this.grpAutoRestart.Controls.Add(this.chkAutoRestart);
			this.grpAutoRestart.Location = new System.Drawing.Point(12, 12);
			this.grpAutoRestart.Name = "grpAutoRestart";
			this.grpAutoRestart.Size = new System.Drawing.Size(281, 99);
			this.grpAutoRestart.TabIndex = 0;
			this.grpAutoRestart.TabStop = false;
			this.grpAutoRestart.Text = "Auto Restart";
			// 
			// lblStartTimeout
			// 
			this.lblStartTimeout.AutoSize = true;
			this.lblStartTimeout.Location = new System.Drawing.Point(22, 70);
			this.lblStartTimeout.Name = "lblStartTimeout";
			this.lblStartTimeout.Size = new System.Drawing.Size(172, 13);
			this.lblStartTimeout.TabIndex = 3;
			this.lblStartTimeout.Text = "Seconds to wait for Server to Start:";
			// 
			// lblRestartWait
			// 
			this.lblRestartWait.AutoSize = true;
			this.lblRestartWait.Location = new System.Drawing.Point(34, 44);
			this.lblRestartWait.Name = "lblRestartWait";
			this.lblRestartWait.Size = new System.Drawing.Size(160, 13);
			this.lblRestartWait.TabIndex = 1;
			this.lblRestartWait.Text = "Seconds to Wait Before Restart:";
			// 
			// numStartTimeout
			// 
			this.numStartTimeout.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.numStartTimeout.Location = new System.Drawing.Point(200, 68);
			this.numStartTimeout.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
			this.numStartTimeout.Name = "numStartTimeout";
			this.numStartTimeout.Size = new System.Drawing.Size(75, 20);
			this.numStartTimeout.TabIndex = 4;
			// 
			// numRestartWait
			// 
			this.numRestartWait.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.numRestartWait.Location = new System.Drawing.Point(200, 42);
			this.numRestartWait.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
			this.numRestartWait.Name = "numRestartWait";
			this.numRestartWait.Size = new System.Drawing.Size(75, 20);
			this.numRestartWait.TabIndex = 2;
			// 
			// chkAutoRestart
			// 
			this.chkAutoRestart.AutoSize = true;
			this.chkAutoRestart.Location = new System.Drawing.Point(6, 19);
			this.chkAutoRestart.Name = "chkAutoRestart";
			this.chkAutoRestart.Size = new System.Drawing.Size(241, 17);
			this.chkAutoRestart.TabIndex = 0;
			this.chkAutoRestart.Text = "Auto Restart when Anonymous Disconnected";
			this.chkAutoRestart.UseVisualStyleBackColor = true;
			// 
			// grpServers
			// 
			this.grpServers.Controls.Add(this.btnAddServer);
			this.grpServers.Controls.Add(this.grdServers);
			this.grpServers.Location = new System.Drawing.Point(301, 12);
			this.grpServers.Name = "grpServers";
			this.grpServers.Size = new System.Drawing.Size(281, 197);
			this.grpServers.TabIndex = 4;
			this.grpServers.TabStop = false;
			this.grpServers.Text = "Game Servers";
			// 
			// btnAddServer
			// 
			this.btnAddServer.Location = new System.Drawing.Point(200, 167);
			this.btnAddServer.Name = "btnAddServer";
			this.btnAddServer.Size = new System.Drawing.Size(75, 23);
			this.btnAddServer.TabIndex = 1;
			this.btnAddServer.Text = "&Add Server";
			this.btnAddServer.UseVisualStyleBackColor = true;
			this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
			// 
			// grdServers
			// 
			this.grdServers.AllowUserToAddRows = false;
			this.grdServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.btnEditServer});
			this.grdServers.Location = new System.Drawing.Point(6, 19);
			this.grdServers.MultiSelect = false;
			this.grdServers.Name = "grdServers";
			this.grdServers.RowHeadersWidth = 21;
			this.grdServers.Size = new System.Drawing.Size(269, 142);
			this.grdServers.TabIndex = 0;
			this.grdServers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdServers_CellMouseClick);
			// 
			// ServerName
			// 
			this.ServerName.DataPropertyName = "ServerName";
			this.ServerName.HeaderText = "Server Name";
			this.ServerName.Name = "ServerName";
			this.ServerName.ReadOnly = true;
			this.ServerName.Width = 200;
			// 
			// btnEditServer
			// 
			this.btnEditServer.HeaderText = "";
			this.btnEditServer.Name = "btnEditServer";
			this.btnEditServer.Text = "...";
			this.btnEditServer.ToolTipText = "Edit Server Settings";
			this.btnEditServer.UseColumnTextForButtonValue = true;
			this.btnEditServer.Width = 25;
			// 
			// grpMessages
			// 
			this.grpMessages.Controls.Add(this.lblMessages);
			this.grpMessages.Controls.Add(this.grdMessages);
			this.grpMessages.Controls.Add(this.lblWelcomeMsg);
			this.grpMessages.Controls.Add(this.btnWelcome);
			this.grpMessages.Controls.Add(this.txtWelcome);
			this.grpMessages.Controls.Add(this.lblMessageWait);
			this.grpMessages.Controls.Add(this.numMessageWait);
			this.grpMessages.Location = new System.Drawing.Point(12, 215);
			this.grpMessages.Name = "grpMessages";
			this.grpMessages.Size = new System.Drawing.Size(570, 191);
			this.grpMessages.TabIndex = 5;
			this.grpMessages.TabStop = false;
			this.grpMessages.Text = "Messages";
			// 
			// lblMessages
			// 
			this.lblMessages.AutoSize = true;
			this.lblMessages.Location = new System.Drawing.Point(6, 37);
			this.lblMessages.Name = "lblMessages";
			this.lblMessages.Size = new System.Drawing.Size(92, 13);
			this.lblMessages.TabIndex = 5;
			this.lblMessages.Text = "Server Messages:";
			// 
			// grdMessages
			// 
			this.grdMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Message,
            this.Delay,
            this.Interval});
			this.grdMessages.Location = new System.Drawing.Point(6, 53);
			this.grdMessages.Name = "grdMessages";
			this.grdMessages.RowHeadersWidth = 25;
			this.grdMessages.Size = new System.Drawing.Size(558, 132);
			this.grdMessages.TabIndex = 6;
			// 
			// Message
			// 
			this.Message.DataPropertyName = "Message";
			this.Message.HeaderText = "Message";
			this.Message.MaxInputLength = 40;
			this.Message.Name = "Message";
			this.Message.Width = 300;
			// 
			// Delay
			// 
			this.Delay.DataPropertyName = "Delay";
			this.Delay.HeaderText = "Delay";
			this.Delay.Name = "Delay";
			// 
			// Interval
			// 
			this.Interval.DataPropertyName = "Interval";
			this.Interval.HeaderText = "Interval";
			this.Interval.Name = "Interval";
			// 
			// lblWelcomeMsg
			// 
			this.lblWelcomeMsg.AutoSize = true;
			this.lblWelcomeMsg.Location = new System.Drawing.Point(295, 16);
			this.lblWelcomeMsg.Name = "lblWelcomeMsg";
			this.lblWelcomeMsg.Size = new System.Drawing.Size(101, 13);
			this.lblWelcomeMsg.TabIndex = 2;
			this.lblWelcomeMsg.Text = "Welcome Message:";
			// 
			// btnWelcome
			// 
			this.btnWelcome.Location = new System.Drawing.Point(539, 11);
			this.btnWelcome.Name = "btnWelcome";
			this.btnWelcome.Size = new System.Drawing.Size(25, 23);
			this.btnWelcome.TabIndex = 4;
			this.btnWelcome.Text = "...";
			this.btnWelcome.UseVisualStyleBackColor = true;
			this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
			// 
			// txtWelcome
			// 
			this.txtWelcome.Location = new System.Drawing.Point(402, 13);
			this.txtWelcome.Name = "txtWelcome";
			this.txtWelcome.ReadOnly = true;
			this.txtWelcome.Size = new System.Drawing.Size(140, 20);
			this.txtWelcome.TabIndex = 3;
			// 
			// lblMessageWait
			// 
			this.lblMessageWait.AutoSize = true;
			this.lblMessageWait.Location = new System.Drawing.Point(10, 16);
			this.lblMessageWait.Name = "lblMessageWait";
			this.lblMessageWait.Size = new System.Drawing.Size(185, 13);
			this.lblMessageWait.TabIndex = 0;
			this.lblMessageWait.Text = "Seconds to Wait Between Messages:";
			// 
			// numMessageWait
			// 
			this.numMessageWait.Location = new System.Drawing.Point(201, 14);
			this.numMessageWait.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numMessageWait.Name = "numMessageWait";
			this.numMessageWait.Size = new System.Drawing.Size(75, 20);
			this.numMessageWait.TabIndex = 1;
			// 
			// grpLogStats
			// 
			this.grpLogStats.Controls.Add(this.btnStatsLog);
			this.grpLogStats.Controls.Add(this.txtStatsLog);
			this.grpLogStats.Controls.Add(this.chkStatsLog);
			this.grpLogStats.Location = new System.Drawing.Point(11, 140);
			this.grpLogStats.Name = "grpLogStats";
			this.grpLogStats.Size = new System.Drawing.Size(282, 69);
			this.grpLogStats.TabIndex = 3;
			this.grpLogStats.TabStop = false;
			this.grpLogStats.Text = "Player Statistics";
			// 
			// btnStatsLog
			// 
			this.btnStatsLog.Location = new System.Drawing.Point(250, 40);
			this.btnStatsLog.Name = "btnStatsLog";
			this.btnStatsLog.Size = new System.Drawing.Size(25, 23);
			this.btnStatsLog.TabIndex = 2;
			this.btnStatsLog.Text = "...";
			this.btnStatsLog.UseVisualStyleBackColor = true;
			this.btnStatsLog.Click += new System.EventHandler(this.btnStatsLog_Click);
			// 
			// txtStatsLog
			// 
			this.txtStatsLog.Location = new System.Drawing.Point(8, 42);
			this.txtStatsLog.Name = "txtStatsLog";
			this.txtStatsLog.Size = new System.Drawing.Size(245, 20);
			this.txtStatsLog.TabIndex = 1;
			// 
			// chkStatsLog
			// 
			this.chkStatsLog.AutoSize = true;
			this.chkStatsLog.Location = new System.Drawing.Point(6, 19);
			this.chkStatsLog.Name = "chkStatsLog";
			this.chkStatsLog.Size = new System.Drawing.Size(172, 17);
			this.chkStatsLog.TabIndex = 0;
			this.chkStatsLog.Text = "Log Player Statistics to Xml File";
			this.chkStatsLog.UseVisualStyleBackColor = true;
			// 
			// dlgSaveFile
			// 
			this.dlgSaveFile.Filter = "Stats Logs|*.xml";
			// 
			// chkAutoAdjustMinPlayers
			// 
			this.chkAutoAdjustMinPlayers.AutoSize = true;
			this.chkAutoAdjustMinPlayers.Location = new System.Drawing.Point(11, 118);
			this.chkAutoAdjustMinPlayers.Name = "chkAutoAdjustMinPlayers";
			this.chkAutoAdjustMinPlayers.Size = new System.Drawing.Size(210, 17);
			this.chkAutoAdjustMinPlayers.TabIndex = 1;
			this.chkAutoAdjustMinPlayers.Text = "Percent of players ready to start match:";
			this.chkAutoAdjustMinPlayers.UseVisualStyleBackColor = true;
			// 
			// numMinPlayerPercent
			// 
			this.numMinPlayerPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numMinPlayerPercent.Location = new System.Drawing.Point(228, 117);
			this.numMinPlayerPercent.Name = "numMinPlayerPercent";
			this.numMinPlayerPercent.Size = new System.Drawing.Size(65, 20);
			this.numMinPlayerPercent.TabIndex = 2;
			this.numMinPlayerPercent.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// MiscConfigForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(594, 448);
			this.ControlBox = false;
			this.Controls.Add(this.numMinPlayerPercent);
			this.Controls.Add(this.chkAutoAdjustMinPlayers);
			this.Controls.Add(this.grpLogStats);
			this.Controls.Add(this.grpMessages);
			this.Controls.Add(this.grpServers);
			this.Controls.Add(this.grpAutoRestart);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MiscConfigForm";
			this.ShowInTaskbar = false;
			this.Text = "Miscellaneous Configuration";
			this.grpAutoRestart.ResumeLayout(false);
			this.grpAutoRestart.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStartTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRestartWait)).EndInit();
			this.grpServers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdServers)).EndInit();
			this.grpMessages.ResumeLayout(false);
			this.grpMessages.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMessageWait)).EndInit();
			this.grpLogStats.ResumeLayout(false);
			this.grpLogStats.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMinPlayerPercent)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox grpAutoRestart;
		private System.Windows.Forms.Label lblStartTimeout;
		private System.Windows.Forms.Label lblRestartWait;
		private System.Windows.Forms.NumericUpDown numStartTimeout;
		private System.Windows.Forms.NumericUpDown numRestartWait;
		private System.Windows.Forms.CheckBox chkAutoRestart;
		private System.Windows.Forms.GroupBox grpServers;
		private System.Windows.Forms.DataGridView grdServers;
		private System.Windows.Forms.GroupBox grpMessages;
		private System.Windows.Forms.GroupBox grpLogStats;
		private System.Windows.Forms.Button btnStatsLog;
		private System.Windows.Forms.TextBox txtStatsLog;
		private System.Windows.Forms.CheckBox chkStatsLog;
		private System.Windows.Forms.Button btnWelcome;
		private System.Windows.Forms.TextBox txtWelcome;
		private System.Windows.Forms.Label lblMessageWait;
		private System.Windows.Forms.NumericUpDown numMessageWait;
		private System.Windows.Forms.Label lblMessages;
		private System.Windows.Forms.DataGridView grdMessages;
		private System.Windows.Forms.Label lblWelcomeMsg;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn Message;
		private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
		private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
		private System.Windows.Forms.DataGridViewButtonColumn btnEditServer;
		private System.Windows.Forms.Button btnAddServer;
		private System.Windows.Forms.CheckBox chkAutoAdjustMinPlayers;
		private System.Windows.Forms.NumericUpDown numMinPlayerPercent;
	}
}