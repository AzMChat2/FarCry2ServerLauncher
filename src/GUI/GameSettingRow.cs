using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSL
{
	public partial class GameSettingRow : UserControl
	{
		public event EventHandler RowEntered;
		private void OnRowEntered()
		{
			if (RowEntered != null) RowEntered.Invoke(this, new EventArgs());
		}

		public GameSettingRow()
		{
			InitializeComponent();
		}

		private GameSetting _dataSource;
		public GameSetting DataSource
		{
			get { return _dataSource; }
			set
			{
				_dataSource = value;
				lblSettingName.DataBindings.Add("Text", _dataSource, "Name");

				if (_dataSource.ValidValues.Count == 0)
				{
					txtValue.DataBindings.Add("Text", _dataSource, "Value");
					cboValue.Visible = false;
				}
				else
				{
					cboValue.DataSource = _dataSource.ValidValues;
					cboValue.DisplayMember = "Display";
					cboValue.ValueMember = "Value";
					cboValue.DataBindings.Add("SelectedValue", _dataSource, "Value");
					txtValue.Visible = false;
				}

			}
		}

		private void cboValue_Enter(object sender, EventArgs e)
		{
			OnRowEntered();
		}

		private void txtValue_Enter(object sender, EventArgs e)
		{
			OnRowEntered();
		}
	}
}
