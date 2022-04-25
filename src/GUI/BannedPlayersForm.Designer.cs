namespace GSL
{
	partial class BannedPlayersForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grdBanned = new System.Windows.Forms.DataGridView();
			this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Expires = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Remove = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdBanned)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(497, 329);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(416, 329);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// grdBanned
			// 
			this.grdBanned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdBanned.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Reason,
            this.Expires,
            this.Remove});
			this.grdBanned.Location = new System.Drawing.Point(12, 12);
			this.grdBanned.Name = "grdBanned";
			this.grdBanned.RowHeadersWidth = 25;
			this.grdBanned.Size = new System.Drawing.Size(560, 311);
			this.grdBanned.TabIndex = 0;
			// 
			// PlayerName
			// 
			this.PlayerName.DataPropertyName = "PlayerName";
			this.PlayerName.HeaderText = "Player Name";
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Width = 110;
			// 
			// Reason
			// 
			this.Reason.DataPropertyName = "Reason";
			this.Reason.HeaderText = "Ban Reason";
			this.Reason.MaxInputLength = 40;
			this.Reason.Name = "Reason";
			this.Reason.Width = 200;
			// 
			// Expires
			// 
			this.Expires.DataPropertyName = "ExpiresOn";
			dataGridViewCellStyle3.Format = "g";
			dataGridViewCellStyle3.NullValue = null;
			this.Expires.DefaultCellStyle = dataGridViewCellStyle3;
			this.Expires.HeaderText = "Expires On";
			this.Expires.Name = "Expires";
			this.Expires.ToolTipText = "Date Ban Expires";
			// 
			// Remove
			// 
			this.Remove.DataPropertyName = "RemoveOn";
			dataGridViewCellStyle4.Format = "g";
			dataGridViewCellStyle4.NullValue = null;
			this.Remove.DefaultCellStyle = dataGridViewCellStyle4;
			this.Remove.HeaderText = "Remove On";
			this.Remove.Name = "Remove";
			this.Remove.ToolTipText = "Date Ban will be removed from History";
			// 
			// BannedPlayersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 364);
			this.ControlBox = false;
			this.Controls.Add(this.grdBanned);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "BannedPlayersForm";
			this.ShowInTaskbar = false;
			this.Text = "Banned Players";
			((System.ComponentModel.ISupportInitialize)(this.grdBanned)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.DataGridView grdBanned;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
		private System.Windows.Forms.DataGridViewTextBoxColumn Expires;
		private System.Windows.Forms.DataGridViewTextBoxColumn Remove;
	}
}