namespace GSL
{
	partial class RegularPlayersForm
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
			this.grdPlayers = new System.Windows.Forms.DataGridView();
			this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Remote = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.FullAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsClan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanWarn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanKick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanBan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanSkipMap = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanEndMatch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanExtend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanRestart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CanShuffle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(507, 339);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(426, 339);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// grdPlayers
			// 
			this.grdPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Remote,
            this.FullAdmin,
            this.Password,
            this.IsClan,
            this.CanWarn,
            this.CanKick,
            this.CanBan,
            this.CanSkipMap,
            this.CanEndMatch,
            this.CanExtend,
            this.CanRestart,
            this.CanShuffle});
			this.grdPlayers.Location = new System.Drawing.Point(12, 12);
			this.grdPlayers.Name = "grdPlayers";
			this.grdPlayers.RowHeadersWidth = 20;
			this.grdPlayers.Size = new System.Drawing.Size(570, 321);
			this.grdPlayers.TabIndex = 7;
			// 
			// PlayerName
			// 
			this.PlayerName.DataPropertyName = "Name";
			this.PlayerName.HeaderText = "Player Name";
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Width = 120;
			// 
			// Remote
			// 
			this.Remote.DataPropertyName = "IsRemoteUser";
			this.Remote.HeaderText = "Rmt";
			this.Remote.Name = "Remote";
			this.Remote.ToolTipText = "Remote User";
			this.Remote.Width = 28;
			// 
			// FullAdmin
			// 
			this.FullAdmin.DataPropertyName = "FullControl";
			this.FullAdmin.HeaderText = "FC";
			this.FullAdmin.Name = "FullAdmin";
			this.FullAdmin.ToolTipText = "Full Remote Control";
			this.FullAdmin.Width = 28;
			// 
			// Password
			// 
			this.Password.DataPropertyName = "Password";
			this.Password.HeaderText = "Password";
			this.Password.Name = "Password";
			this.Password.ToolTipText = "Remote User Password";
			// 
			// IsClan
			// 
			this.IsClan.DataPropertyName = "IsClanMember";
			this.IsClan.HeaderText = "Clan";
			this.IsClan.Name = "IsClan";
			this.IsClan.ToolTipText = "Is Clan Member";
			this.IsClan.Width = 28;
			// 
			// CanWarn
			// 
			this.CanWarn.DataPropertyName = "CanWarnPlayer";
			this.CanWarn.HeaderText = "Wrn";
			this.CanWarn.Name = "CanWarn";
			this.CanWarn.ToolTipText = "Can Warn Player";
			this.CanWarn.Width = 28;
			// 
			// CanKick
			// 
			this.CanKick.DataPropertyName = "CanKickPlayer";
			this.CanKick.HeaderText = "Kick";
			this.CanKick.Name = "CanKick";
			this.CanKick.ToolTipText = "Can Kick Player";
			this.CanKick.Width = 28;
			// 
			// CanBan
			// 
			this.CanBan.DataPropertyName = "CanBanPlayer";
			this.CanBan.HeaderText = "Ban";
			this.CanBan.Name = "CanBan";
			this.CanBan.ToolTipText = "Can Ban Player";
			this.CanBan.Width = 28;
			// 
			// CanSkipMap
			// 
			this.CanSkipMap.DataPropertyName = "CanSkipMap";
			this.CanSkipMap.HeaderText = "Skip";
			this.CanSkipMap.Name = "CanSkipMap";
			this.CanSkipMap.ToolTipText = "Can Skip Map";
			this.CanSkipMap.Width = 28;
			// 
			// CanEndMatch
			// 
			this.CanEndMatch.DataPropertyName = "CanEndMatch";
			this.CanEndMatch.HeaderText = "End";
			this.CanEndMatch.Name = "CanEndMatch";
			this.CanEndMatch.ToolTipText = "Can End Match";
			this.CanEndMatch.Width = 28;
			// 
			// CanExtend
			// 
			this.CanExtend.DataPropertyName = "CanExtendMatch";
			this.CanExtend.HeaderText = "Ext";
			this.CanExtend.Name = "CanExtend";
			this.CanExtend.ToolTipText = "Can Extend Match";
			this.CanExtend.Width = 28;
			// 
			// CanRestart
			// 
			this.CanRestart.DataPropertyName = "CanRestartMatch";
			this.CanRestart.HeaderText = "Rstrt";
			this.CanRestart.Name = "CanRestart";
			this.CanRestart.ToolTipText = "Can Restart Match";
			this.CanRestart.Width = 28;
			// 
			// CanShuffle
			// 
			this.CanShuffle.DataPropertyName = "CanShuffleTeams";
			this.CanShuffle.HeaderText = "Shfl";
			this.CanShuffle.Name = "CanShuffle";
			this.CanShuffle.ToolTipText = "Can Shuffle Teams";
			this.CanShuffle.Width = 28;
			// 
			// RegularPlayersForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(594, 374);
			this.ControlBox = false;
			this.Controls.Add(this.grdPlayers);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RegularPlayersForm";
			this.ShowInTaskbar = false;
			this.Text = "Admin and Clan Players";
			((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.DataGridView grdPlayers;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Remote;
		private System.Windows.Forms.DataGridViewCheckBoxColumn FullAdmin;
		private System.Windows.Forms.DataGridViewTextBoxColumn Password;
		private System.Windows.Forms.DataGridViewCheckBoxColumn IsClan;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanWarn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanKick;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanBan;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanSkipMap;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanEndMatch;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanExtend;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanRestart;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CanShuffle;
	}
}