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
	public partial class GameSettingsGrid : UserControl
	{
		public event EventHandler RowChanged;
		private void OnRowChanged()
		{
			if (RowChanged != null) RowChanged.Invoke(this, new EventArgs());
		}

		public GameSettingsGrid()
		{
			InitializeComponent();
		}

		public GameSetting SelectedSetting { get; private set; }

		private List<GameSettingRow> _rows = new List<GameSettingRow>();
		private GameSettingCollection _dataSource;
		public GameSettingCollection DataSource
		{
			get { return _dataSource; }
			set
			{
				_dataSource = value;

				pnlDisplay.SuspendLayout();
				_rows.ForEach(item => pnlDisplay.Controls.Remove(item));
				_rows.Clear();
				_dataSource.ForEach(item => pnlDisplay.Controls.Add(CreateRow(item)));
				pnlDisplay.ResumeLayout();
			}
		}

		private GameSettingRow CreateRow(GameSetting item)
		{
			GameSettingRow retVal = new GameSettingRow();
			retVal.Location = new Point(0, _rows.Count * 25);
			retVal.DataSource = item;
			retVal.RowEntered += new EventHandler(retVal_RowEntered);
			_rows.Add(retVal);
			return retVal;
		}

		private void retVal_RowEntered(object sender, EventArgs e)
		{
			SelectedSetting = ((GameSettingRow)sender).DataSource;
			OnRowChanged();
		}

	}
}
