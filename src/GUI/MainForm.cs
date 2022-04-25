using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using AppSettings = GSL.Properties.Settings;

namespace GSL
{
	public partial class MainForm : Form
	{
		private const string NewServerTab = "New...";
		private List<StatusViewer> _statusViewers = new List<StatusViewer>();
		private ServerConfig _serverConfig;
		private TabPage _newTab;

		public MainForm()
		{
			InitializeComponent();

			_newTab = tabFirst;
			try
			{
				_serverConfig = ServerConfig.LoadSettings(AppSettings.Default.SettingsFile);
				RemoteServer.Initialize(_serverConfig);
				LoadServers();
			}
			catch (Exception ex)
			{
				string msg = string.Format("Error loading server configuration.\r\n{0}", ex);
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			dlgSaveFile.FileName = AppSettings.Default.SettingsFile;
			dlgOpenFile.FileName = AppSettings.Default.SettingsFile;
		}

		private void LoadServers()
		{
			if (_serverConfig.MiscConfig.ServerGameSettings.Count == 0)
			{
				AddNewServer();
			}
			else
			{
				_serverConfig.MiscConfig.ServerGameSettings.ForEach(item => LoadServer(item));
			}
		}

		private void LoadServer(ServerSettings settings)
		{
			try
			{
				settings.Load();
				NewServerLauncher(_newTab, settings);
				_newTab = new TabPage(NewServerTab);
				tabServers.TabPages.Add(_newTab);
			}
			catch (Exception ex)
			{
				string msg = string.Format("An error occured while loading server settings from file '{0}.'\r\n{1}", settings.Filename, ex);
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void NewServerLauncher(TabPage page, ServerSettings settings)
		{
			StatusViewer view = new StatusViewer();
			view.Initialize(_serverConfig, settings);
			_statusViewers.Add(view);
			page.Text = settings.ServerName;
			page.SuspendLayout();
			page.Controls.Clear();
			page.Controls.Add(view);
			view.Dock = DockStyle.Fill;
			page.ResumeLayout();
		}

		private void Server_ServerNameUpdated(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateTabNames));
			}
			else
			{
				UpdateTabNames();
			}
		}

		private void UpdateTabNames()
		{
			for (int idx = 0; idx < _statusViewers.Count; idx++)
			{
				tabServers.TabPages[idx].Text = _statusViewers[idx].ServerName;
			}
		}

		private void loadMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (dlgOpenFile.ShowDialog(this) == DialogResult.OK)
				{
					_serverConfig = ServerConfig.LoadSettings(dlgOpenFile.FileName);
					LoadServers();
					AppSettings.Default.SettingsFile = dlgOpenFile.FileName;
					AppSettings.Default.Save();

					_statusViewers.ForEach(item =>
					{
						item.Server.Config = _serverConfig;
					});
				}
			}
			catch (Exception ex)
			{
				HandleException("Error loading Server Settings from file.\r\n{0}", ex);
			}
		}

		private void saveMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (dlgSaveFile.ShowDialog(this) == DialogResult.OK)
				{
					ServerConfig.SaveSettings(_serverConfig, dlgSaveFile.FileName);
					AppSettings.Default.SettingsFile = dlgSaveFile.FileName;
					AppSettings.Default.Save();
				}
			}
			catch (Exception ex)
			{
				HandleException("Error saving Server Settings to file.\r\n{0}", ex);
			}
		}

		private void banMenuItem_Click(object sender, EventArgs e)
		{
			BanConfigForm.Show(this, _serverConfig);
		}

		private void playersMenuItem_Click(object sender, EventArgs e)
		{
			RegularPlayersForm.Show(this, _serverConfig);
		}

		private void miscMenuItem_Click(object sender, EventArgs e)
		{
			if (MiscConfigForm.Show(this, _serverConfig))
			{
				for (int idx = 0; idx < _serverConfig.MiscConfig.ServerGameSettings.Count; idx++)
				{
					if (idx < _statusViewers.Count)
					{
						_statusViewers[idx].UpdateSettings(_serverConfig.MiscConfig.ServerGameSettings[idx], false);
					}
					else
					{
						LoadServer(_serverConfig.MiscConfig.ServerGameSettings[idx]);
					}
				}
			}
		}

		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox.ShowAboutBox(this);
		}

		private void bannedPlayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BannedPlayersForm.ShowBannedPlayers(this);
		}

		private void onlineMenuItem_Click(object sender, EventArgs e)
		{
			Process process = new Process();
			process.StartInfo.FileName = "http://www.azchatfield.net/FarCry2/ServerLauncher/";
			process.Start();
		}

		private void tabServers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabServers.SelectedTab == _newTab)
			{
				if (!AddNewServer())
				{
					int idx = (tabServers.SelectedIndex - 1);
					if (idx >= 0) tabServers.SelectedIndex = idx;
				}
			}
		}

		private bool AddNewServer()
		{
			bool retVal = false;

			ServerSettings newServer = new ServerSettings();
			if (ServerSettingsForm.Show(this, newServer))
			{
				newServer.Save();
				LoadServer(newServer);
				_serverConfig.MiscConfig.ServerGameSettings.Add(newServer);
				retVal = true;
			}

			return retVal;
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private static void HandleException(string format, Exception ex)
		{
			string msg = string.Format(format, ex);

			Trace.WriteLineIf(TS.Error, string.Empty, string.Empty);
			Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);

			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			#region Message
			string msg = @"The Extender is currently controlling at least one Game Server.
Closing the Extender will stop these games.

Are you sure you wish to exit?";
			#endregion

			if (_statusViewers.Exists(item => item.Server.GameRunning) &&
				(MessageBox.Show(msg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No))
			{
				e.Cancel = true;
			}
			else
			{
				_statusViewers.ForEach(item => item.Server.StopProcess());
				RemoteServer.Close();
			}
		}

		private void btnNewServer_Click(object sender, EventArgs e)
		{
			AddNewServer();
		}

		private void remoteConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RemoteConfigForm.Show(this, _serverConfig))
			{
				NotifyRemoteServer();
			}
		}

		private void NotifyRemoteServer()
		{
			if (_serverConfig.RemoteConfig.Enabled)
			{
				RemoteServer.StartServer();
			}
			else
			{
				RemoteServer.StopServer();
			}
		}
	}
}
