namespace GSL
{
	partial class GameSettingRow
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
			this.lblSettingName = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.cboValue = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblSettingName
			// 
			this.lblSettingName.Location = new System.Drawing.Point(3, 6);
			this.lblSettingName.Name = "lblSettingName";
			this.lblSettingName.Size = new System.Drawing.Size(150, 19);
			this.lblSettingName.TabIndex = 0;
			this.lblSettingName.Text = "Setting Name:";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(159, 4);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(138, 20);
			this.txtValue.TabIndex = 1;
			this.txtValue.Enter += new System.EventHandler(this.txtValue_Enter);
			// 
			// cboValue
			// 
			this.cboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboValue.FormattingEnabled = true;
			this.cboValue.Location = new System.Drawing.Point(159, 3);
			this.cboValue.Name = "cboValue";
			this.cboValue.Size = new System.Drawing.Size(141, 21);
			this.cboValue.TabIndex = 2;
			this.cboValue.Enter += new System.EventHandler(this.cboValue_Enter);
			// 
			// GameSettingRow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cboValue);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.lblSettingName);
			this.Name = "GameSettingRow";
			this.Size = new System.Drawing.Size(300, 25);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSettingName;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.ComboBox cboValue;
	}
}
