using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace GSL
{
	public partial class ServerSettingsForm : Form
	{
		public static bool Show(IWin32Window owner, ServerSettings serverSettings)
		{
			bool retVal = false;

			ServerSettingsForm form = new ServerSettingsForm(serverSettings);
			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				retVal = true;
				serverSettings.GameSettings.Validate();
			}

			return retVal;
		}

		private ServerSettings _dataSource;
		private GameSettingsGrid _settingsGrid;

		public ServerSettingsForm(ServerSettings dataSource)
		{
			InitializeComponent();

			_dataSource = dataSource;

			_settingsGrid = new GameSettingsGrid();
			pnlSettingsGrid.Controls.Add(_settingsGrid);
			_settingsGrid.Dock = DockStyle.Fill;
			_settingsGrid.DataSource = _dataSource.GameSettings;
			_settingsGrid.RowChanged += new EventHandler(_settingsGrid_RowChanged);

			txtServerName.DataBindings.Add("Text", _dataSource, "ServerName");
			txtConfigFile.DataBindings.Add("Text", _dataSource, "Filename");
			txtMapRotation.Text = _dataSource.MapRotation.GetRotationDisplay();

			cboGameMode.SelectedIndex = (int)_dataSource.GameMode;
			cboServerMode.SelectedIndex = (int)_dataSource.ServerMode;
		}

		private void _settingsGrid_RowChanged(object sender, EventArgs e)
		{
			lblDescription.Text = string.Format(CultureInfo.CurrentCulture, "{0}\r\n{1}\r\n\r\nDefault Value: {2}",
				_settingsGrid.SelectedSetting.Name, _settingsGrid.SelectedSetting.Description, _settingsGrid.SelectedSetting.DefaultValue);
		}

		private void btnConfigFile_Click(object sender, EventArgs e)
		{
			dlgConfigFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Games\Far Cry 2\Server\";
			dlgConfigFile.FileName = _dataSource.Filename;
			if (dlgConfigFile.ShowDialog(this) == DialogResult.OK)
			{
				_dataSource.Filename = dlgConfigFile.FileName;
				txtConfigFile.Text = dlgConfigFile.FileName;

				if (File.Exists(_dataSource.Filename) &&
					(MessageBox.Show("Load server settings from file?", "File exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
				{
					_dataSource.Load();
					txtMapRotation.Text = _dataSource.MapRotation.GetRotationDisplay();
					txtServerName.DataBindings["Text"].ReadValue();
					_settingsGrid.DataSource = _dataSource.GameSettings;
				}
			}
		}

		private void btnMapRotation_Click(object sender, EventArgs e)
		{
			MapRotationForm.Show(this, _dataSource);
			txtMapRotation.Text = _dataSource.MapRotation.GetRotationDisplay();
		}

		private void ShowHelp(GameSetting setting)
		{
			StringBuilder description = new StringBuilder();

			description.AppendLine(setting.Name);
			description.AppendLine();
			description.AppendLine(setting.Description);
			description.AppendLine();
			description.Append("Default Value: ");
			description.AppendLine(setting.DefaultValue);
			description.AppendLine();
			description.Append("Valid Values: ");

			if (setting.ValidValues.Count != 0)
			{
				foreach (ValidValue validValue in setting.ValidValues)
				{
					description.Append(validValue.Value);
					if (!string.IsNullOrEmpty(validValue.Description))
					{
						description.Append(" - ");
						description.Append(validValue.Description);
					}
					description.Append("; ");
				}
				description.Remove(description.Length - 2, 2);
			}
			description.AppendLine();

			lblDescription.Text = description.ToString();
		}

		private void cboGameMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			_dataSource.ChangeGameMode((GameModes)cboGameMode.SelectedIndex);
			_settingsGrid.DataSource = _dataSource.GameSettings;
		}

		private void cboServerMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			_dataSource.ChangeServerMode((ServerModes)cboServerMode.SelectedIndex);
			_settingsGrid.DataSource = _dataSource.GameSettings;
		}
	}
}
