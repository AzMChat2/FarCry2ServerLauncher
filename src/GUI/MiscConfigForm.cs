using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSL
{
	public partial class MiscConfigForm : Form
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="serverConfig"></param>
		/// <returns>Returns true if one or more ServerSettings have changed.</returns>
		public static bool Show(IWin32Window owner, ServerConfig serverConfig)
		{
			bool retVal = false;

			MiscConfig dataSource = serverConfig.MiscConfig.Clone();
			MiscConfig.CopyValues(serverConfig.MiscConfig, dataSource);
			MiscConfigForm form = new MiscConfigForm(dataSource);

			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				serverConfig.MiscConfig = form._dataSource;
				serverConfig.MiscConfig.ServerGameSettings.ForEach(item => SaveServerSettings(item));
				retVal = form._serverSettingsChanged;
			}

			return retVal;
		}

		private static void SaveServerSettings(ServerSettings serverSettings)
		{
			try
			{
				serverSettings.Save();
			}
			catch (Exception ex)
			{
				string msg = string.Format("An error occured while attempting to write Server Settings File '{0}'.\r\n{1}", serverSettings.Filename, ex);
				MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private MiscConfig _dataSource;
		private BindingSource _messagesSource;
		private BindingSource _serversSource;
		private bool _serverSettingsChanged;

		private MiscConfigForm(MiscConfig dataSource)
		{
			InitializeComponent();

			_dataSource = dataSource;

			_messagesSource = new BindingSource();
			_serversSource = new BindingSource();

			_messagesSource.DataSource = _dataSource.ServerMessages;
			_serversSource.DataSource = _dataSource.ServerGameSettings;

			grdServers.AutoGenerateColumns = false;
			grdMessages.AutoGenerateColumns = false;

			grdMessages.DataSource = _messagesSource;
			grdServers.DataSource = _serversSource;

			chkAutoRestart.DataBindings.Add("Checked", _dataSource, "AutoRestart");
			numRestartWait.DataBindings.Add("Value", _dataSource, "RestartWait");
			numStartTimeout.DataBindings.Add("Value", _dataSource, "StartTimeout");

			chkAutoAdjustMinPlayers.DataBindings.Add("Checked", _dataSource, "AutoAdjustMinPlayers");
			numMinPlayerPercent.DataBindings.Add("Value", _dataSource, "MinPlayerPercent");

			chkStatsLog.DataBindings.Add("Checked", _dataSource, "LogStats");
			txtStatsLog.DataBindings.Add("Text", _dataSource, "StatsFile");

			numMessageWait.DataBindings.Add("Value", _dataSource, "MessageWait");
			UpdateWelcomeText();
		}

		private void UpdateWelcomeText()
		{
			if (_dataSource.WelcomeMessages.Count == 0)
			{
				txtWelcome.Text = string.Empty;
			}
			else
			{
				txtWelcome.Text = _dataSource.WelcomeMessages[0];
			}
		}

		private void btnStatsLog_Click(object sender, EventArgs e)
		{
			dlgSaveFile.FileName = txtStatsLog.Text;
			if (dlgSaveFile.ShowDialog(this) == DialogResult.OK)
			{
				string filename = GetFileName();
				txtStatsLog.Text = filename;
				_dataSource.StatsFile = filename;
			}
		}

		private string GetFileName()
		{
			string retVal = dlgSaveFile.FileName;

			int idx = retVal.LastIndexOf('.');
			if (idx != -1)
			{
				retVal = retVal.Substring(0, idx);
			}

			return retVal;
		}

		private void btnWelcome_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.WelcomeMessages, "Welcome Message", "Message", "Use {0} as place holder for Player Name.\r\nUse {1} as place holder for Server Name.");
		}

		private void grdServers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == 1)
			{
				ServerSettings settings = _dataSource.ServerGameSettings[e.RowIndex].Clone();
				ServerSettings.CopyValues(_dataSource.ServerGameSettings[e.RowIndex], settings);

				if (ServerSettingsForm.Show(this, settings))
				{
					_dataSource.ServerGameSettings[e.RowIndex] = settings;
					_serverSettingsChanged = true;
				}
			}
		}

		private void btnAddServer_Click(object sender, EventArgs e)
		{
			ServerSettings settings = new ServerSettings();
			if (ServerSettingsForm.Show(this, settings))
			{
				_dataSource.ServerGameSettings.Add(settings);
				_serversSource.ResetBindings(false);
				_serverSettingsChanged = true;
			}
		}
	}
}
