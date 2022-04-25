namespace GSL
{
	partial class ChatForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.pnlCommand.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.txtMessage);
			this.pnlCommand.Controls.Add(this.btnSend);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(0, 241);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Size = new System.Drawing.Size(371, 22);
			this.pnlCommand.TabIndex = 10;
			// 
			// txtMessage
			// 
			this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMessage.Location = new System.Drawing.Point(0, 0);
			this.txtMessage.MaxLength = 40;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(311, 20);
			this.txtMessage.TabIndex = 0;
			this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
			// 
			// btnSend
			// 
			this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSend.Location = new System.Drawing.Point(311, 0);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(60, 22);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtConsole
			// 
			this.txtConsole.BackColor = System.Drawing.Color.Black;
			this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtConsole.ForeColor = System.Drawing.Color.Yellow;
			this.txtConsole.Location = new System.Drawing.Point(0, 0);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ReadOnly = true;
			this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtConsole.Size = new System.Drawing.Size(371, 241);
			this.txtConsole.TabIndex = 11;
			this.txtConsole.WordWrap = false;
			// 
			// ChatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 263);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.pnlCommand);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChatForm";
			this.Text = "ChatForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
			this.pnlCommand.ResumeLayout(false);
			this.pnlCommand.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtConsole;
	}
}