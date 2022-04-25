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
	public partial class RegularPlayersForm : Form
	{
		public static void Show(IWin32Window owner, ServerConfig source)
		{
			RegularPlayersForm form = new RegularPlayersForm(source.Users.Clone());

			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				source.Users = form._dataSource;
			}
		}

		private UserCollection _dataSource;
		private BindingSource _gridSource;

		private RegularPlayersForm(UserCollection dataSource)
		{
			InitializeComponent();

			_dataSource = dataSource;
			_gridSource = new BindingSource();
			_gridSource.DataSource = _dataSource;

			grdPlayers.AutoGenerateColumns = false;
			grdPlayers.DataSource = _gridSource;
		}
	}
}
