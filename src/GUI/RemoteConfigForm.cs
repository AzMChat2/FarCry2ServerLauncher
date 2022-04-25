using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace GSL
{
	public partial class RemoteConfigForm : Form
	{
		public static bool Show(IWin32Window owner, ServerConfig config)
		{
			bool retVal = false;

			RemoteConfig dataSource = (config.RemoteConfig == null) ? new RemoteConfig() : config.RemoteConfig.Clone();
			RemoteConfigForm form = new RemoteConfigForm(dataSource);
			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				config.RemoteConfig = form._dataSource;
				retVal = true;
			}

			return retVal;
		}

		private RemoteConfig _dataSource;
		private RemoteConfigForm(RemoteConfig dataSource)
		{
			InitializeComponent();
			_dataSource = dataSource;

			chkEnabled.DataBindings.Add("Checked", _dataSource, "Enabled");
			txtFilename.DataBindings.Add("Text", _dataSource, "KeyFilename");

			IPAddress address= Utilities.GetPublicIPAddress();

			txtIPAddress.Text = address.ToString();
		}

		private void btnFilename_Click(object sender, EventArgs e)
		{
			sfdKeyFile.FileName = txtFilename.Text;
			if (sfdKeyFile.ShowDialog(this) == DialogResult.OK)
			{
				txtFilename.Text = sfdKeyFile.FileName;
				_dataSource.KeyFilename = sfdKeyFile.FileName;
			}
		}
	}
}
