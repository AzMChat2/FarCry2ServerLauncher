namespace GSL
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabServers = new System.Windows.Forms.TabControl();
			this.tabFirst = new System.Windows.Forms.TabPage();
			this.btnNewServer = new System.Windows.Forms.Button();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.banMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bannedPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miscMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onlineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.tabServers.SuspendLayout();
			this.tabFirst.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabServers
			// 
			this.tabServers.Controls.Add(this.tabFirst);
			this.tabServers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabServers.Location = new System.Drawing.Point(0, 24);
			this.tabServers.Name = "tabServers";
			this.tabServers.SelectedIndex = 0;
			this.tabServers.Size = new System.Drawing.Size(584, 390);
			this.tabServers.TabIndex = 0;
			this.tabServers.SelectedIndexChanged += new System.EventHandler(this.tabServers_SelectedIndexChanged);
			// 
			// tabFirst
			// 
			this.tabFirst.Controls.Add(this.btnNewServer);
			this.tabFirst.Location = new System.Drawing.Point(4, 22);
			this.tabFirst.Name = "tabFirst";
			this.tabFirst.Size = new System.Drawing.Size(576, 364);
			this.tabFirst.TabIndex = 1;
			this.tabFirst.Text = "New...";
			this.tabFirst.UseVisualStyleBackColor = true;
			// 
			// btnNewServer
			// 
			this.btnNewServer.Location = new System.Drawing.Point(6, 6);
			this.btnNewServer.Name = "btnNewServer";
			this.btnNewServer.Size = new System.Drawing.Size(117, 23);
			this.btnNewServer.TabIndex = 0;
			this.btnNewServer.Text = "Add New Server";
			this.btnNewServer.UseVisualStyleBackColor = true;
			this.btnNewServer.Click += new System.EventHandler(this.btnNewServer_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.configMenu,
            this.helpMenu});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(584, 24);
			this.mainMenu.TabIndex = 1;
			this.mainMenu.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenuItem,
            this.saveMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "&File";
			// 
			// loadMenuItem
			// 
			this.loadMenuItem.Name = "loadMenuItem";
			this.loadMenuItem.Size = new System.Drawing.Size(139, 22);
			this.loadMenuItem.Text = "&Load Config";
			this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
			// 
			// saveMenuItem
			// 
			this.saveMenuItem.Name = "saveMenuItem";
			this.saveMenuItem.Size = new System.Drawing.Size(139, 22);
			this.saveMenuItem.Text = "&Save Config";
			this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// configMenu
			// 
			this.configMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.banMenuItem,
            this.bannedPlayersToolStripMenuItem,
            this.playersMenuItem,
            this.miscMenuItem,
            this.remoteConfigToolStripMenuItem});
			this.configMenu.Name = "configMenu";
			this.configMenu.Size = new System.Drawing.Size(55, 20);
			this.configMenu.Text = "&Config";
			// 
			// banMenuItem
			// 
			this.banMenuItem.Name = "banMenuItem";
			this.banMenuItem.Size = new System.Drawing.Size(163, 22);
			this.banMenuItem.Text = "&Ban Config";
			this.banMenuItem.Click += new System.EventHandler(this.banMenuItem_Click);
			// 
			// bannedPlayersToolStripMenuItem
			// 
			this.bannedPlayersToolStripMenuItem.Name = "bannedPlayersToolStripMenuItem";
			this.bannedPlayersToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.bannedPlayersToolStripMenuItem.Text = "Banned Players...";
			this.bannedPlayersToolStripMenuItem.Click += new System.EventHandler(this.bannedPlayersToolStripMenuItem_Click);
			// 
			// playersMenuItem
			// 
			this.playersMenuItem.Name = "playersMenuItem";
			this.playersMenuItem.Size = new System.Drawing.Size(163, 22);
			this.playersMenuItem.Text = "&Players Config";
			this.playersMenuItem.Click += new System.EventHandler(this.playersMenuItem_Click);
			// 
			// miscMenuItem
			// 
			this.miscMenuItem.Name = "miscMenuItem";
			this.miscMenuItem.Size = new System.Drawing.Size(163, 22);
			this.miscMenuItem.Text = "&Misc Config";
			this.miscMenuItem.Click += new System.EventHandler(this.miscMenuItem_Click);
			// 
			// remoteConfigToolStripMenuItem
			// 
			this.remoteConfigToolStripMenuItem.Name = "remoteConfigToolStripMenuItem";
			this.remoteConfigToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.remoteConfigToolStripMenuItem.Text = "&Remote Config";
			this.remoteConfigToolStripMenuItem.Click += new System.EventHandler(this.remoteConfigToolStripMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem,
            this.onlineMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(44, 20);
			this.helpMenu.Text = "&Help";
			// 
			// aboutMenuItem
			// 
			this.aboutMenuItem.Name = "aboutMenuItem";
			this.aboutMenuItem.Size = new System.Drawing.Size(137, 22);
			this.aboutMenuItem.Text = "&About";
			this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
			// 
			// onlineMenuItem
			// 
			this.onlineMenuItem.Name = "onlineMenuItem";
			this.onlineMenuItem.Size = new System.Drawing.Size(137, 22);
			this.onlineMenuItem.Text = "&Online Help";
			this.onlineMenuItem.Click += new System.EventHandler(this.onlineMenuItem_Click);
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = "Xml Config Files|*.xml";
			// 
			// dlgSaveFile
			// 
			this.dlgSaveFile.Filter = "Xml Config Files|*.xml";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 414);
			this.Controls.Add(this.tabServers);
			this.Controls.Add(this.mainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "MChat Far Cry 2 Server Launcher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.tabServers.ResumeLayout(false);
			this.tabFirst.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabServers;
		private System.Windows.Forms.TabPage tabFirst;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configMenu;
		private System.Windows.Forms.ToolStripMenuItem banMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miscMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onlineMenuItem;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.ToolStripMenuItem bannedPlayersToolStripMenuItem;
		private System.Windows.Forms.Button btnNewServer;
		private System.Windows.Forms.ToolStripMenuItem remoteConfigToolStripMenuItem;
	}
}

