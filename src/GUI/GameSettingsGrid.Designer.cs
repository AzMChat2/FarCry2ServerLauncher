namespace GSL
{
	partial class GameSettingsGrid
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
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.AutoScroll = true;
			this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Size = new System.Drawing.Size(463, 258);
			this.pnlDisplay.TabIndex = 0;
			// 
			// GameSettingsGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlDisplay);
			this.Name = "GameSettingsGrid";
			this.Size = new System.Drawing.Size(463, 258);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlDisplay;
	}
}
