namespace GSL
{
	partial class ServerSettingsForm
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
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.pnlProperties = new System.Windows.Forms.Panel();
			this.grpProperties = new System.Windows.Forms.GroupBox();
			this.btnMapRotation = new System.Windows.Forms.Button();
			this.txtMapRotation = new System.Windows.Forms.TextBox();
			this.lblMapRotation = new System.Windows.Forms.Label();
			this.btnConfigFile = new System.Windows.Forms.Button();
			this.txtConfigFile = new System.Windows.Forms.TextBox();
			this.lblConfigFile = new System.Windows.Forms.Label();
			this.lblServerMode = new System.Windows.Forms.Label();
			this.lblGameMode = new System.Windows.Forms.Label();
			this.cboServerMode = new System.Windows.Forms.ComboBox();
			this.cboGameMode = new System.Windows.Forms.ComboBox();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.lblServerName = new System.Windows.Forms.Label();
			this.pnlSettings = new System.Windows.Forms.Panel();
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.pnlSettingsGrid = new System.Windows.Forms.Panel();
			this.dlgConfigFile = new System.Windows.Forms.SaveFileDialog();
			this.pnlButtons.SuspendLayout();
			this.pnlProperties.SuspendLayout();
			this.grpProperties.SuspendLayout();
			this.pnlSettings.SuspendLayout();
			this.grpSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Controls.Add(this.btnOk);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtons.Location = new System.Drawing.Point(0, 389);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(592, 32);
			this.pnlButtons.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(514, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(433, 6);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// pnlProperties
			// 
			this.pnlProperties.Controls.Add(this.grpProperties);
			this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlProperties.Location = new System.Drawing.Point(0, 0);
			this.pnlProperties.Name = "pnlProperties";
			this.pnlProperties.Padding = new System.Windows.Forms.Padding(5);
			this.pnlProperties.Size = new System.Drawing.Size(592, 132);
			this.pnlProperties.TabIndex = 0;
			// 
			// grpProperties
			// 
			this.grpProperties.Controls.Add(this.btnMapRotation);
			this.grpProperties.Controls.Add(this.txtMapRotation);
			this.grpProperties.Controls.Add(this.lblMapRotation);
			this.grpProperties.Controls.Add(this.btnConfigFile);
			this.grpProperties.Controls.Add(this.txtConfigFile);
			this.grpProperties.Controls.Add(this.lblConfigFile);
			this.grpProperties.Controls.Add(this.lblServerMode);
			this.grpProperties.Controls.Add(this.lblGameMode);
			this.grpProperties.Controls.Add(this.cboServerMode);
			this.grpProperties.Controls.Add(this.cboGameMode);
			this.grpProperties.Controls.Add(this.txtServerName);
			this.grpProperties.Controls.Add(this.lblServerName);
			this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpProperties.Location = new System.Drawing.Point(5, 5);
			this.grpProperties.Name = "grpProperties";
			this.grpProperties.Size = new System.Drawing.Size(582, 122);
			this.grpProperties.TabIndex = 0;
			this.grpProperties.TabStop = false;
			this.grpProperties.Text = "Server Properties";
			// 
			// btnMapRotation
			// 
			this.btnMapRotation.Location = new System.Drawing.Point(551, 89);
			this.btnMapRotation.Name = "btnMapRotation";
			this.btnMapRotation.Size = new System.Drawing.Size(24, 23);
			this.btnMapRotation.TabIndex = 11;
			this.btnMapRotation.Text = "...";
			this.btnMapRotation.UseVisualStyleBackColor = true;
			this.btnMapRotation.Click += new System.EventHandler(this.btnMapRotation_Click);
			// 
			// txtMapRotation
			// 
			this.txtMapRotation.Location = new System.Drawing.Point(110, 91);
			this.txtMapRotation.Name = "txtMapRotation";
			this.txtMapRotation.ReadOnly = true;
			this.txtMapRotation.Size = new System.Drawing.Size(438, 20);
			this.txtMapRotation.TabIndex = 10;
			// 
			// lblMapRotation
			// 
			this.lblMapRotation.AutoSize = true;
			this.lblMapRotation.Location = new System.Drawing.Point(7, 94);
			this.lblMapRotation.Name = "lblMapRotation";
			this.lblMapRotation.Size = new System.Drawing.Size(74, 13);
			this.lblMapRotation.TabIndex = 9;
			this.lblMapRotation.Text = "Map Rotation:";
			// 
			// btnConfigFile
			// 
			this.btnConfigFile.Location = new System.Drawing.Point(551, 63);
			this.btnConfigFile.Name = "btnConfigFile";
			this.btnConfigFile.Size = new System.Drawing.Size(24, 23);
			this.btnConfigFile.TabIndex = 8;
			this.btnConfigFile.Text = "...";
			this.btnConfigFile.UseVisualStyleBackColor = true;
			this.btnConfigFile.Click += new System.EventHandler(this.btnConfigFile_Click);
			// 
			// txtConfigFile
			// 
			this.txtConfigFile.Location = new System.Drawing.Point(110, 65);
			this.txtConfigFile.Name = "txtConfigFile";
			this.txtConfigFile.Size = new System.Drawing.Size(438, 20);
			this.txtConfigFile.TabIndex = 7;
			// 
			// lblConfigFile
			// 
			this.lblConfigFile.AutoSize = true;
			this.lblConfigFile.Location = new System.Drawing.Point(7, 68);
			this.lblConfigFile.Name = "lblConfigFile";
			this.lblConfigFile.Size = new System.Drawing.Size(91, 13);
			this.lblConfigFile.TabIndex = 6;
			this.lblConfigFile.Text = "Configuration File:";
			// 
			// lblServerMode
			// 
			this.lblServerMode.AutoSize = true;
			this.lblServerMode.Location = new System.Drawing.Point(472, 21);
			this.lblServerMode.Name = "lblServerMode";
			this.lblServerMode.Size = new System.Drawing.Size(71, 13);
			this.lblServerMode.TabIndex = 4;
			this.lblServerMode.Text = "Server Mode:";
			// 
			// lblGameMode
			// 
			this.lblGameMode.AutoSize = true;
			this.lblGameMode.Location = new System.Drawing.Point(311, 22);
			this.lblGameMode.Name = "lblGameMode";
			this.lblGameMode.Size = new System.Drawing.Size(68, 13);
			this.lblGameMode.TabIndex = 2;
			this.lblGameMode.Text = "Game Mode:";
			// 
			// cboServerMode
			// 
			this.cboServerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboServerMode.FormattingEnabled = true;
			this.cboServerMode.Items.AddRange(new object[] {
            "LAN",
            "Online",
            "Ranked"});
			this.cboServerMode.Location = new System.Drawing.Point(475, 37);
			this.cboServerMode.Name = "cboServerMode";
			this.cboServerMode.Size = new System.Drawing.Size(100, 21);
			this.cboServerMode.TabIndex = 5;
			this.cboServerMode.SelectedIndexChanged += new System.EventHandler(this.cboServerMode_SelectedIndexChanged);
			// 
			// cboGameMode
			// 
			this.cboGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGameMode.FormattingEnabled = true;
			this.cboGameMode.Items.AddRange(new object[] {
            "Deathmatch",
            "Team Deathmatch",
            "Capture The Diamond",
            "Uprising"});
			this.cboGameMode.Location = new System.Drawing.Point(314, 38);
			this.cboGameMode.Name = "cboGameMode";
			this.cboGameMode.Size = new System.Drawing.Size(155, 21);
			this.cboGameMode.TabIndex = 3;
			this.cboGameMode.SelectedIndexChanged += new System.EventHandler(this.cboGameMode_SelectedIndexChanged);
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(8, 38);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new System.Drawing.Size(300, 20);
			this.txtServerName.TabIndex = 1;
			// 
			// lblServerName
			// 
			this.lblServerName.AutoSize = true;
			this.lblServerName.Location = new System.Drawing.Point(5, 22);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(72, 13);
			this.lblServerName.TabIndex = 0;
			this.lblServerName.Text = "Server Name:";
			// 
			// pnlSettings
			// 
			this.pnlSettings.Controls.Add(this.grpSettings);
			this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSettings.Location = new System.Drawing.Point(0, 132);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.pnlSettings.Size = new System.Drawing.Size(592, 257);
			this.pnlSettings.TabIndex = 1;
			// 
			// grpSettings
			// 
			this.grpSettings.Controls.Add(this.lblDescription);
			this.grpSettings.Controls.Add(this.pnlSettingsGrid);
			this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSettings.Location = new System.Drawing.Point(5, 0);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(582, 257);
			this.grpSettings.TabIndex = 0;
			this.grpSettings.TabStop = false;
			this.grpSettings.Text = "Server Settings";
			// 
			// lblDescription
			// 
			this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDescription.Location = new System.Drawing.Point(328, 16);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(251, 238);
			this.lblDescription.TabIndex = 1;
			// 
			// pnlSettingsGrid
			// 
			this.pnlSettingsGrid.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSettingsGrid.Location = new System.Drawing.Point(3, 16);
			this.pnlSettingsGrid.Name = "pnlSettingsGrid";
			this.pnlSettingsGrid.Size = new System.Drawing.Size(325, 238);
			this.pnlSettingsGrid.TabIndex = 0;
			// 
			// dlgConfigFile
			// 
			this.dlgConfigFile.Filter = "Xml Files|*.xml";
			this.dlgConfigFile.OverwritePrompt = false;
			// 
			// ServerSettingsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(592, 421);
			this.ControlBox = false;
			this.Controls.Add(this.pnlSettings);
			this.Controls.Add(this.pnlProperties);
			this.Controls.Add(this.pnlButtons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ServerSettingsForm";
			this.ShowInTaskbar = false;
			this.Text = "Edit Server Settings";
			this.pnlButtons.ResumeLayout(false);
			this.pnlProperties.ResumeLayout(false);
			this.grpProperties.ResumeLayout(false);
			this.grpProperties.PerformLayout();
			this.pnlSettings.ResumeLayout(false);
			this.grpSettings.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Panel pnlProperties;
		private System.Windows.Forms.GroupBox grpProperties;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.ComboBox cboServerMode;
		private System.Windows.Forms.ComboBox cboGameMode;
		private System.Windows.Forms.Label lblServerMode;
		private System.Windows.Forms.Label lblGameMode;
		private System.Windows.Forms.Button btnConfigFile;
		private System.Windows.Forms.TextBox txtConfigFile;
		private System.Windows.Forms.Label lblConfigFile;
		private System.Windows.Forms.Button btnMapRotation;
		private System.Windows.Forms.TextBox txtMapRotation;
		private System.Windows.Forms.Label lblMapRotation;
		private System.Windows.Forms.Panel pnlSettings;
		private System.Windows.Forms.GroupBox grpSettings;
		private System.Windows.Forms.SaveFileDialog dlgConfigFile;
		private System.Windows.Forms.Panel pnlSettingsGrid;
		private System.Windows.Forms.Label lblDescription;

	}
}