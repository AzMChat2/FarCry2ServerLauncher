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
	public partial class BannedPlayersForm : Form
	{
		public static void ShowBannedPlayers(IWin32Window owner)
		{
			BannedPlayersForm form = new BannedPlayersForm(BanCollection.Current.Clone());
			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				BanCollection.Save(form._dataSource);
			}
		}

		private BanCollection _dataSource;
		private BindingSource _gridSource;

		private BannedPlayersForm(BanCollection dataSource)
		{
			InitializeComponent();

			_dataSource = dataSource;
			_gridSource = new BindingSource();
			_gridSource.DataSource = _dataSource;
			grdBanned.AutoGenerateColumns = false;
			grdBanned.DataSource = _gridSource;
		}
	}
}
