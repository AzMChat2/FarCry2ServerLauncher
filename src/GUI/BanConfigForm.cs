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
	public partial class BanConfigForm : Form
	{
		public static void Show(IWin32Window owner, ServerConfig serverSettings)
		{
			BanConfigForm form = new BanConfigForm(serverSettings.BanConfig.Clone());

			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				serverSettings.BanConfig = form._dataSource;
			}
		}

		private BanConfig _dataSource;
		private BindingSource _gridSource;

		private BanConfigForm(BanConfig dataSource)
		{
			InitializeComponent();
			_dataSource = dataSource;
			BindControls();
		}

		private void BindControls()
		{
			_gridSource = new BindingSource();
			_gridSource.DataSource = _dataSource.BanLengths;
			grdBanLength.AutoGenerateColumns = false;
			grdBanLength.DataSource = _gridSource;

			chkBanSwearing.DataBindings.Add("Checked", _dataSource, "BanSwearing");
			chkBanTeamKill.DataBindings.Add("Checked", _dataSource, "BanTeamKill");

			numWarnings.DataBindings.Add("Value", _dataSource, "Warnings");
			numMaxWarnings.DataBindings.Add("Value", _dataSource, "MaxWarnings");
			numBanHistory.DataBindings.Add("Value", _dataSource, "BanHistory");

			txtWarnTeamKill.Text = _dataSource.TeamKillWarningMessages.Count == 0 ? string.Empty : _dataSource.TeamKillWarningMessages[0];
			txtWarnSwearing.Text = _dataSource.SwearingWarningMessages.Count == 0 ? string.Empty : _dataSource.SwearingWarningMessages[0];
			txtWarnMisconduct.Text = _dataSource.MisconductWarningMessages.Count == 0 ? string.Empty : _dataSource.MisconductWarningMessages[0];
			txtBanTeamKill.Text = _dataSource.MisconductWarningMessages.Count == 0 ? string.Empty : _dataSource.MisconductWarningMessages[0];
			txtBanSwearing.Text = _dataSource.SwearingBanMessages.Count == 0 ? string.Empty : _dataSource.SwearingBanMessages[0];
			txtBanMisconduct.Text = _dataSource.MisconductBanMessages.Count == 0 ? string.Empty : _dataSource.MisconductBanMessages[0];
			txtBannedKick.Text = _dataSource.BannedMessages.Count == 0 ? string.Empty : _dataSource.BannedMessages[0];
		}

		private void btnWarnTeamKill_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.TeamKillWarningMessages, "Team Kill Warning Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtWarnTeamKill.Text = _dataSource.TeamKillWarningMessages.Count == 0 ? string.Empty : _dataSource.TeamKillWarningMessages[0];
		}

		private void btnWarnSwearing_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.SwearingWarningMessages, "Swearing Warning Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtWarnSwearing.Text = _dataSource.SwearingWarningMessages.Count == 0 ? string.Empty : _dataSource.SwearingWarningMessages[0];
		}

		private void btnWarnMisconduct_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.MisconductWarningMessages, "Misconduct Warning Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtWarnMisconduct.Text = _dataSource.MisconductWarningMessages.Count == 0 ? string.Empty : _dataSource.MisconductWarningMessages[0];
		}

		private void btnBanTeamKill_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.TeamKillBanMessages, "Team Kill Ban Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtBanTeamKill.Text = _dataSource.TeamKillBanMessages.Count == 0 ? string.Empty : _dataSource.TeamKillBanMessages[0];
		}

		private void btnBanSwearing_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.SwearingBanMessages, "Swearing Ban Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtBanSwearing.Text = _dataSource.SwearingBanMessages.Count == 0 ? string.Empty : _dataSource.SwearingBanMessages[0];
		}

		private void btnBanMisconduct_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.MisconductBanMessages, "Misconduct Ban Message", "Message Line", "Use {0} as place holder for Player Name.");
			txtBanMisconduct.Text = _dataSource.MisconductBanMessages.Count == 0 ? string.Empty : _dataSource.MisconductBanMessages[0];
		}

		private void btnBannedKick_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.BannedMessages, "Kicking Banned Player Message", "Message Line", "Use {0} as place holder for Player Name.\r\nUse {1} as place holder for Reason.\r\nUse {2} as place holder for ban expiration date");
			txtBannedKick.Text = _dataSource.BannedMessages.Count == 0 ? string.Empty : _dataSource.BannedMessages[0];
		}

		private void btnSwearWords_Click(object sender, EventArgs e)
		{
			StringListForm.Show(this, _dataSource.SwearWords, "Swear Words or Phrases", "Word or Phrase", string.Empty);
		}
	}
}
