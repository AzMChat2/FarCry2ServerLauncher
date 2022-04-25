namespace GSL
{
	partial class RemoteConfigForm
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
			this.sfdKeyFile = new System.Windows.Forms.SaveFileDialog();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			this.lblFilename = new System.Windows.Forms.Label();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.btnFilename = new System.Windows.Forms.Button();
			this.lblIPAddress = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(387, 261);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(306, 261);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// sfdKeyFile
			// 
			this.sfdKeyFile.Filter = "Key Files|*.key";
			// 
			// chkEnabled
			// 
			this.chkEnabled.AutoSize = true;
			this.chkEnabled.Location = new System.Drawing.Point(12, 12);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(166, 17);
			this.chkEnabled.TabIndex = 0;
			this.chkEnabled.Text = "Enable Remote Client Access";
			this.chkEnabled.UseVisualStyleBackColor = true;
			// 
			// lblFilename
			// 
			this.lblFilename.AutoSize = true;
			this.lblFilename.Location = new System.Drawing.Point(9, 41);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(126, 13);
			this.lblFilename.TabIndex = 3;
			this.lblFilename.Text = "Encryption Key Filename:";
			// 
			// txtFilename
			// 
			this.txtFilename.Location = new System.Drawing.Point(12, 57);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(419, 20);
			this.txtFilename.TabIndex = 4;
			// 
			// btnFilename
			// 
			this.btnFilename.Location = new System.Drawing.Point(437, 55);
			this.btnFilename.Name = "btnFilename";
			this.btnFilename.Size = new System.Drawing.Size(25, 23);
			this.btnFilename.TabIndex = 5;
			this.btnFilename.Text = "...";
			this.btnFilename.UseVisualStyleBackColor = true;
			this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
			// 
			// lblIPAddress
			// 
			this.lblIPAddress.AutoSize = true;
			this.lblIPAddress.Location = new System.Drawing.Point(251, 13);
			this.lblIPAddress.Name = "lblIPAddress";
			this.lblIPAddress.Size = new System.Drawing.Size(98, 13);
			this.lblIPAddress.TabIndex = 1;
			this.lblIPAddress.Text = "Current IP Address:";
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(355, 10);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(107, 20);
			this.txtIPAddress.TabIndex = 2;
			// 
			// RemoteConfigForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(474, 296);
			this.ControlBox = false;
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.lblIPAddress);
			this.Controls.Add(this.btnFilename);
			this.Controls.Add(this.txtFilename);
			this.Controls.Add(this.lblFilename);
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RemoteConfigForm";
			this.ShowInTaskbar = false;
			this.Text = "Remote Configuration";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.SaveFileDialog sfdKeyFile;
		private System.Windows.Forms.CheckBox chkEnabled;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.Button btnFilename;
		private System.Windows.Forms.Label lblIPAddress;
		private System.Windows.Forms.TextBox txtIPAddress;
	}
}