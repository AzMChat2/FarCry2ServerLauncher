namespace GSL
{
	partial class BanConfigForm
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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpMessages = new System.Windows.Forms.GroupBox();
			this.lblWarnTeamKill = new System.Windows.Forms.Label();
			this.txtWarnTeamKill = new System.Windows.Forms.TextBox();
			this.btnWarnTeamKill = new System.Windows.Forms.Button();
			this.btnWarnSwearing = new System.Windows.Forms.Button();
			this.txtWarnSwearing = new System.Windows.Forms.TextBox();
			this.lblWarnSwearing = new System.Windows.Forms.Label();
			this.btnWarnMisconduct = new System.Windows.Forms.Button();
			this.txtWarnMisconduct = new System.Windows.Forms.TextBox();
			this.lblWarnMisconduct = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBanMisconduct = new System.Windows.Forms.Button();
			this.txtBanMisconduct = new System.Windows.Forms.TextBox();
			this.lblBanMisconduct = new System.Windows.Forms.Label();
			this.btnBanSwearing = new System.Windows.Forms.Button();
			this.txtBanSwearing = new System.Windows.Forms.TextBox();
			this.lblBanSwearing = new System.Windows.Forms.Label();
			this.btnBanTeamKill = new System.Windows.Forms.Button();
			this.txtBanTeamKill = new System.Windows.Forms.TextBox();
			this.lblBanTeamKilling = new System.Windows.Forms.Label();
			this.btnBannedKick = new System.Windows.Forms.Button();
			this.txtBannedKick = new System.Windows.Forms.TextBox();
			this.lblBannedKick = new System.Windows.Forms.Label();
			this.grpBanOptions = new System.Windows.Forms.GroupBox();
			this.chkBanTeamKill = new System.Windows.Forms.CheckBox();
			this.chkBanSwearing = new System.Windows.Forms.CheckBox();
			this.numWarnings = new System.Windows.Forms.NumericUpDown();
			this.numMaxWarnings = new System.Windows.Forms.NumericUpDown();
			this.numBanHistory = new System.Windows.Forms.NumericUpDown();
			this.lblWarnings = new System.Windows.Forms.Label();
			this.lblMaxWarnings = new System.Windows.Forms.Label();
			this.lblBanHistory = new System.Windows.Forms.Label();
			this.btnSwearWords = new System.Windows.Forms.Button();
			this.grdBanLength = new System.Windows.Forms.DataGridView();
			this.BanNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.grpMessages.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpBanOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWarnings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWarnings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBanHistory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdBanLength)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(426, 349);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(507, 349);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// grpMessages
			// 
			this.grpMessages.Controls.Add(this.btnWarnMisconduct);
			this.grpMessages.Controls.Add(this.txtWarnMisconduct);
			this.grpMessages.Controls.Add(this.lblWarnMisconduct);
			this.grpMessages.Controls.Add(this.btnWarnSwearing);
			this.grpMessages.Controls.Add(this.txtWarnSwearing);
			this.grpMessages.Controls.Add(this.lblWarnSwearing);
			this.grpMessages.Controls.Add(this.btnWarnTeamKill);
			this.grpMessages.Controls.Add(this.txtWarnTeamKill);
			this.grpMessages.Controls.Add(this.lblWarnTeamKill);
			this.grpMessages.Location = new System.Drawing.Point(279, 12);
			this.grpMessages.Name = "grpMessages";
			this.grpMessages.Size = new System.Drawing.Size(303, 142);
			this.grpMessages.TabIndex = 1;
			this.grpMessages.TabStop = false;
			this.grpMessages.Text = "Warning Messages";
			// 
			// lblWarnTeamKill
			// 
			this.lblWarnTeamKill.AutoSize = true;
			this.lblWarnTeamKill.Location = new System.Drawing.Point(6, 16);
			this.lblWarnTeamKill.Name = "lblWarnTeamKill";
			this.lblWarnTeamKill.Size = new System.Drawing.Size(171, 13);
			this.lblWarnTeamKill.TabIndex = 0;
			this.lblWarnTeamKill.Text = "Warning Message for Team Killing:";
			// 
			// txtWarnTeamKill
			// 
			this.txtWarnTeamKill.Location = new System.Drawing.Point(6, 32);
			this.txtWarnTeamKill.Name = "txtWarnTeamKill";
			this.txtWarnTeamKill.ReadOnly = true;
			this.txtWarnTeamKill.Size = new System.Drawing.Size(271, 20);
			this.txtWarnTeamKill.TabIndex = 1;
			// 
			// btnWarnTeamKill
			// 
			this.btnWarnTeamKill.Location = new System.Drawing.Point(273, 30);
			this.btnWarnTeamKill.Name = "btnWarnTeamKill";
			this.btnWarnTeamKill.Size = new System.Drawing.Size(24, 23);
			this.btnWarnTeamKill.TabIndex = 2;
			this.btnWarnTeamKill.Text = "...";
			this.btnWarnTeamKill.UseVisualStyleBackColor = true;
			this.btnWarnTeamKill.Click += new System.EventHandler(this.btnWarnTeamKill_Click);
			// 
			// btnWarnSwearing
			// 
			this.btnWarnSwearing.Location = new System.Drawing.Point(273, 69);
			this.btnWarnSwearing.Name = "btnWarnSwearing";
			this.btnWarnSwearing.Size = new System.Drawing.Size(24, 23);
			this.btnWarnSwearing.TabIndex = 5;
			this.btnWarnSwearing.Text = "...";
			this.btnWarnSwearing.UseVisualStyleBackColor = true;
			this.btnWarnSwearing.Click += new System.EventHandler(this.btnWarnSwearing_Click);
			// 
			// txtWarnSwearing
			// 
			this.txtWarnSwearing.Location = new System.Drawing.Point(6, 71);
			this.txtWarnSwearing.Name = "txtWarnSwearing";
			this.txtWarnSwearing.ReadOnly = true;
			this.txtWarnSwearing.Size = new System.Drawing.Size(271, 20);
			this.txtWarnSwearing.TabIndex = 4;
			// 
			// lblWarnSwearing
			// 
			this.lblWarnSwearing.AutoSize = true;
			this.lblWarnSwearing.Location = new System.Drawing.Point(6, 55);
			this.lblWarnSwearing.Name = "lblWarnSwearing";
			this.lblWarnSwearing.Size = new System.Drawing.Size(155, 13);
			this.lblWarnSwearing.TabIndex = 3;
			this.lblWarnSwearing.Text = "Warning Message for Swearing";
			// 
			// btnWarnMisconduct
			// 
			this.btnWarnMisconduct.Location = new System.Drawing.Point(273, 108);
			this.btnWarnMisconduct.Name = "btnWarnMisconduct";
			this.btnWarnMisconduct.Size = new System.Drawing.Size(24, 23);
			this.btnWarnMisconduct.TabIndex = 8;
			this.btnWarnMisconduct.Text = "...";
			this.btnWarnMisconduct.UseVisualStyleBackColor = true;
			this.btnWarnMisconduct.Click += new System.EventHandler(this.btnWarnMisconduct_Click);
			// 
			// txtWarnMisconduct
			// 
			this.txtWarnMisconduct.Location = new System.Drawing.Point(6, 110);
			this.txtWarnMisconduct.Name = "txtWarnMisconduct";
			this.txtWarnMisconduct.ReadOnly = true;
			this.txtWarnMisconduct.Size = new System.Drawing.Size(271, 20);
			this.txtWarnMisconduct.TabIndex = 7;
			// 
			// lblWarnMisconduct
			// 
			this.lblWarnMisconduct.AutoSize = true;
			this.lblWarnMisconduct.Location = new System.Drawing.Point(6, 94);
			this.lblWarnMisconduct.Name = "lblWarnMisconduct";
			this.lblWarnMisconduct.Size = new System.Drawing.Size(237, 13);
			this.lblWarnMisconduct.TabIndex = 6;
			this.lblWarnMisconduct.Text = "Warning Message for Misconduct (SRV_WARN)";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnBannedKick);
			this.groupBox1.Controls.Add(this.txtBannedKick);
			this.groupBox1.Controls.Add(this.lblBannedKick);
			this.groupBox1.Controls.Add(this.btnBanMisconduct);
			this.groupBox1.Controls.Add(this.txtBanMisconduct);
			this.groupBox1.Controls.Add(this.lblBanMisconduct);
			this.groupBox1.Controls.Add(this.btnBanSwearing);
			this.groupBox1.Controls.Add(this.txtBanSwearing);
			this.groupBox1.Controls.Add(this.lblBanSwearing);
			this.groupBox1.Controls.Add(this.btnBanTeamKill);
			this.groupBox1.Controls.Add(this.txtBanTeamKill);
			this.groupBox1.Controls.Add(this.lblBanTeamKilling);
			this.groupBox1.Location = new System.Drawing.Point(279, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(303, 183);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Ban Messages";
			// 
			// btnBanMisconduct
			// 
			this.btnBanMisconduct.Location = new System.Drawing.Point(273, 108);
			this.btnBanMisconduct.Name = "btnBanMisconduct";
			this.btnBanMisconduct.Size = new System.Drawing.Size(24, 23);
			this.btnBanMisconduct.TabIndex = 8;
			this.btnBanMisconduct.Text = "...";
			this.btnBanMisconduct.UseVisualStyleBackColor = true;
			this.btnBanMisconduct.Click += new System.EventHandler(this.btnBanMisconduct_Click);
			// 
			// txtBanMisconduct
			// 
			this.txtBanMisconduct.Location = new System.Drawing.Point(6, 110);
			this.txtBanMisconduct.Name = "txtBanMisconduct";
			this.txtBanMisconduct.ReadOnly = true;
			this.txtBanMisconduct.Size = new System.Drawing.Size(271, 20);
			this.txtBanMisconduct.TabIndex = 7;
			// 
			// lblBanMisconduct
			// 
			this.lblBanMisconduct.AutoSize = true;
			this.lblBanMisconduct.Location = new System.Drawing.Point(6, 94);
			this.lblBanMisconduct.Name = "lblBanMisconduct";
			this.lblBanMisconduct.Size = new System.Drawing.Size(271, 13);
			this.lblBanMisconduct.TabIndex = 6;
			this.lblBanMisconduct.Text = "Ban Message for Misconduct (SRV_WARN/SRV_BAN)";
			// 
			// btnBanSwearing
			// 
			this.btnBanSwearing.Location = new System.Drawing.Point(273, 69);
			this.btnBanSwearing.Name = "btnBanSwearing";
			this.btnBanSwearing.Size = new System.Drawing.Size(24, 23);
			this.btnBanSwearing.TabIndex = 5;
			this.btnBanSwearing.Text = "...";
			this.btnBanSwearing.UseVisualStyleBackColor = true;
			this.btnBanSwearing.Click += new System.EventHandler(this.btnBanSwearing_Click);
			// 
			// txtBanSwearing
			// 
			this.txtBanSwearing.Location = new System.Drawing.Point(6, 71);
			this.txtBanSwearing.Name = "txtBanSwearing";
			this.txtBanSwearing.ReadOnly = true;
			this.txtBanSwearing.Size = new System.Drawing.Size(271, 20);
			this.txtBanSwearing.TabIndex = 4;
			// 
			// lblBanSwearing
			// 
			this.lblBanSwearing.AutoSize = true;
			this.lblBanSwearing.Location = new System.Drawing.Point(6, 55);
			this.lblBanSwearing.Name = "lblBanSwearing";
			this.lblBanSwearing.Size = new System.Drawing.Size(134, 13);
			this.lblBanSwearing.TabIndex = 3;
			this.lblBanSwearing.Text = "Ban Message for Swearing";
			// 
			// btnBanTeamKill
			// 
			this.btnBanTeamKill.Location = new System.Drawing.Point(273, 30);
			this.btnBanTeamKill.Name = "btnBanTeamKill";
			this.btnBanTeamKill.Size = new System.Drawing.Size(24, 23);
			this.btnBanTeamKill.TabIndex = 2;
			this.btnBanTeamKill.Text = "...";
			this.btnBanTeamKill.UseVisualStyleBackColor = true;
			this.btnBanTeamKill.Click += new System.EventHandler(this.btnBanTeamKill_Click);
			// 
			// txtBanTeamKill
			// 
			this.txtBanTeamKill.Location = new System.Drawing.Point(6, 32);
			this.txtBanTeamKill.Name = "txtBanTeamKill";
			this.txtBanTeamKill.ReadOnly = true;
			this.txtBanTeamKill.Size = new System.Drawing.Size(271, 20);
			this.txtBanTeamKill.TabIndex = 1;
			// 
			// lblBanTeamKilling
			// 
			this.lblBanTeamKilling.AutoSize = true;
			this.lblBanTeamKilling.Location = new System.Drawing.Point(6, 16);
			this.lblBanTeamKilling.Name = "lblBanTeamKilling";
			this.lblBanTeamKilling.Size = new System.Drawing.Size(147, 13);
			this.lblBanTeamKilling.TabIndex = 0;
			this.lblBanTeamKilling.Text = "Ban Message for Team Killing";
			// 
			// btnBannedKick
			// 
			this.btnBannedKick.Location = new System.Drawing.Point(273, 147);
			this.btnBannedKick.Name = "btnBannedKick";
			this.btnBannedKick.Size = new System.Drawing.Size(24, 23);
			this.btnBannedKick.TabIndex = 11;
			this.btnBannedKick.Text = "...";
			this.btnBannedKick.UseVisualStyleBackColor = true;
			this.btnBannedKick.Click += new System.EventHandler(this.btnBannedKick_Click);
			// 
			// txtBannedKick
			// 
			this.txtBannedKick.Location = new System.Drawing.Point(6, 149);
			this.txtBannedKick.Name = "txtBannedKick";
			this.txtBannedKick.ReadOnly = true;
			this.txtBannedKick.Size = new System.Drawing.Size(271, 20);
			this.txtBannedKick.TabIndex = 10;
			// 
			// lblBannedKick
			// 
			this.lblBannedKick.AutoSize = true;
			this.lblBannedKick.Location = new System.Drawing.Point(6, 133);
			this.lblBannedKick.Name = "lblBannedKick";
			this.lblBannedKick.Size = new System.Drawing.Size(208, 13);
			this.lblBannedKick.TabIndex = 9;
			this.lblBannedKick.Text = "Message when banned player joins server:";
			// 
			// grpBanOptions
			// 
			this.grpBanOptions.Controls.Add(this.grdBanLength);
			this.grpBanOptions.Controls.Add(this.btnSwearWords);
			this.grpBanOptions.Controls.Add(this.lblBanHistory);
			this.grpBanOptions.Controls.Add(this.lblMaxWarnings);
			this.grpBanOptions.Controls.Add(this.lblWarnings);
			this.grpBanOptions.Controls.Add(this.numBanHistory);
			this.grpBanOptions.Controls.Add(this.numMaxWarnings);
			this.grpBanOptions.Controls.Add(this.numWarnings);
			this.grpBanOptions.Controls.Add(this.chkBanSwearing);
			this.grpBanOptions.Controls.Add(this.chkBanTeamKill);
			this.grpBanOptions.Location = new System.Drawing.Point(12, 12);
			this.grpBanOptions.Name = "grpBanOptions";
			this.grpBanOptions.Size = new System.Drawing.Size(261, 331);
			this.grpBanOptions.TabIndex = 0;
			this.grpBanOptions.TabStop = false;
			this.grpBanOptions.Text = "Ban Options";
			// 
			// chkBanTeamKill
			// 
			this.chkBanTeamKill.AutoSize = true;
			this.chkBanTeamKill.Location = new System.Drawing.Point(6, 19);
			this.chkBanTeamKill.Name = "chkBanTeamKill";
			this.chkBanTeamKill.Size = new System.Drawing.Size(135, 17);
			this.chkBanTeamKill.TabIndex = 0;
			this.chkBanTeamKill.Text = "Ban for killing teamates";
			this.chkBanTeamKill.UseVisualStyleBackColor = true;
			// 
			// chkBanSwearing
			// 
			this.chkBanSwearing.AutoSize = true;
			this.chkBanSwearing.Location = new System.Drawing.Point(6, 42);
			this.chkBanSwearing.Name = "chkBanSwearing";
			this.chkBanSwearing.Size = new System.Drawing.Size(155, 17);
			this.chkBanSwearing.TabIndex = 1;
			this.chkBanSwearing.Text = "Ban for using foul language";
			this.chkBanSwearing.UseVisualStyleBackColor = true;
			// 
			// numWarnings
			// 
			this.numWarnings.Location = new System.Drawing.Point(205, 69);
			this.numWarnings.Name = "numWarnings";
			this.numWarnings.Size = new System.Drawing.Size(50, 20);
			this.numWarnings.TabIndex = 4;
			// 
			// numMaxWarnings
			// 
			this.numMaxWarnings.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numMaxWarnings.Location = new System.Drawing.Point(205, 95);
			this.numMaxWarnings.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numMaxWarnings.Name = "numMaxWarnings";
			this.numMaxWarnings.Size = new System.Drawing.Size(50, 20);
			this.numMaxWarnings.TabIndex = 6;
			// 
			// numBanHistory
			// 
			this.numBanHistory.Location = new System.Drawing.Point(205, 121);
			this.numBanHistory.Name = "numBanHistory";
			this.numBanHistory.Size = new System.Drawing.Size(50, 20);
			this.numBanHistory.TabIndex = 8;
			// 
			// lblWarnings
			// 
			this.lblWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWarnings.AutoSize = true;
			this.lblWarnings.Location = new System.Drawing.Point(46, 71);
			this.lblWarnings.Name = "lblWarnings";
			this.lblWarnings.Size = new System.Drawing.Size(153, 13);
			this.lblWarnings.TabIndex = 3;
			this.lblWarnings.Text = "Maximum Warnings per Match:";
			// 
			// lblMaxWarnings
			// 
			this.lblMaxWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaxWarnings.AutoSize = true;
			this.lblMaxWarnings.Location = new System.Drawing.Point(70, 97);
			this.lblMaxWarnings.Name = "lblMaxWarnings";
			this.lblMaxWarnings.Size = new System.Drawing.Size(129, 13);
			this.lblMaxWarnings.TabIndex = 5;
			this.lblMaxWarnings.Text = "Maximum Warnings Total:";
			// 
			// lblBanHistory
			// 
			this.lblBanHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblBanHistory.AutoSize = true;
			this.lblBanHistory.Location = new System.Drawing.Point(30, 123);
			this.lblBanHistory.Name = "lblBanHistory";
			this.lblBanHistory.Size = new System.Drawing.Size(169, 13);
			this.lblBanHistory.TabIndex = 7;
			this.lblBanHistory.Text = "Days to retain ban after Expiration:";
			// 
			// btnSwearWords
			// 
			this.btnSwearWords.Location = new System.Drawing.Point(158, 38);
			this.btnSwearWords.Name = "btnSwearWords";
			this.btnSwearWords.Size = new System.Drawing.Size(97, 23);
			this.btnSwearWords.TabIndex = 2;
			this.btnSwearWords.Text = "Swear Words...";
			this.btnSwearWords.UseVisualStyleBackColor = true;
			this.btnSwearWords.Click += new System.EventHandler(this.btnSwearWords_Click);
			// 
			// grdBanLength
			// 
			this.grdBanLength.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdBanLength.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BanNumber,
            this.Value,
            this.Type});
			this.grdBanLength.Location = new System.Drawing.Point(6, 148);
			this.grdBanLength.Name = "grdBanLength";
			this.grdBanLength.RowHeadersWidth = 25;
			this.grdBanLength.Size = new System.Drawing.Size(249, 169);
			this.grdBanLength.TabIndex = 9;
			// 
			// BanNumber
			// 
			this.BanNumber.DataPropertyName = "BanNumber";
			this.BanNumber.HeaderText = "Ban #";
			this.BanNumber.Name = "BanNumber";
			this.BanNumber.Width = 60;
			// 
			// Value
			// 
			this.Value.DataPropertyName = "Value";
			this.Value.HeaderText = "Value";
			this.Value.Name = "Value";
			this.Value.Width = 75;
			// 
			// Type
			// 
			this.Type.DataPropertyName = "Type";
			this.Type.HeaderText = "Unit";
			this.Type.Items.AddRange(new object[] {
            "Hours",
            "Days",
            "Weeks",
            "Months",
            "Years",
            "Max"});
			this.Type.Name = "Type";
			this.Type.Width = 75;
			// 
			// BanConfigForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(594, 384);
			this.ControlBox = false;
			this.Controls.Add(this.grpBanOptions);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpMessages);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "BanConfigForm";
			this.ShowInTaskbar = false;
			this.Text = "Modify Ban Configuration";
			this.grpMessages.ResumeLayout(false);
			this.grpMessages.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpBanOptions.ResumeLayout(false);
			this.grpBanOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWarnings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWarnings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBanHistory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdBanLength)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grpMessages;
		private System.Windows.Forms.Button btnWarnTeamKill;
		private System.Windows.Forms.TextBox txtWarnTeamKill;
		private System.Windows.Forms.Label lblWarnTeamKill;
		private System.Windows.Forms.Button btnWarnMisconduct;
		private System.Windows.Forms.TextBox txtWarnMisconduct;
		private System.Windows.Forms.Label lblWarnMisconduct;
		private System.Windows.Forms.Button btnWarnSwearing;
		private System.Windows.Forms.TextBox txtWarnSwearing;
		private System.Windows.Forms.Label lblWarnSwearing;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnBannedKick;
		private System.Windows.Forms.TextBox txtBannedKick;
		private System.Windows.Forms.Label lblBannedKick;
		private System.Windows.Forms.Button btnBanMisconduct;
		private System.Windows.Forms.TextBox txtBanMisconduct;
		private System.Windows.Forms.Label lblBanMisconduct;
		private System.Windows.Forms.Button btnBanSwearing;
		private System.Windows.Forms.TextBox txtBanSwearing;
		private System.Windows.Forms.Label lblBanSwearing;
		private System.Windows.Forms.Button btnBanTeamKill;
		private System.Windows.Forms.TextBox txtBanTeamKill;
		private System.Windows.Forms.Label lblBanTeamKilling;
		private System.Windows.Forms.GroupBox grpBanOptions;
		private System.Windows.Forms.Label lblBanHistory;
		private System.Windows.Forms.Label lblMaxWarnings;
		private System.Windows.Forms.Label lblWarnings;
		private System.Windows.Forms.NumericUpDown numBanHistory;
		private System.Windows.Forms.NumericUpDown numMaxWarnings;
		private System.Windows.Forms.NumericUpDown numWarnings;
		private System.Windows.Forms.CheckBox chkBanSwearing;
		private System.Windows.Forms.CheckBox chkBanTeamKill;
		private System.Windows.Forms.Button btnSwearWords;
		private System.Windows.Forms.DataGridView grdBanLength;
		private System.Windows.Forms.DataGridViewTextBoxColumn BanNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewComboBoxColumn Type;
	}
}