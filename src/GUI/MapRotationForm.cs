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
	public partial class MapRotationForm : Form
	{
		public static void Show(IWin32Window owner, ServerSettings settings)
		{
			Cursor defaultCursor = ((Form)owner).Cursor;
			((Form)owner).Cursor = Cursors.WaitCursor;

			MapGameModes gameMode = MapGameModes.DM;

			switch (settings.GameMode)
			{
				case GameModes.TeamDeathmatch:
					gameMode = MapGameModes.TDM;
					break;
				case GameModes.Ctf:
					gameMode = MapGameModes.CTD;
					break;
				case GameModes.Uprising:
					gameMode = MapGameModes.UP;
					break;
			}

			MapRotationForm form = new MapRotationForm(gameMode);

			MapInfoCollection.AvailableMaps.ForEach(item => { item.Include = false; item.Order = int.MaxValue; });
			settings.MapRotation.ForEach(item => SelectFromAvailableMaps(item));

			((Form)owner).Cursor = defaultCursor;
			if (form.ShowDialog(owner) == DialogResult.OK)
			{
				settings.MapRotation = MapInfoCollection.AvailableMaps.GetSortedList();
				//settings.MapRotation.AddRange(MapInfoCollection.AvailableMaps.FindAll(item => item.Include));
			}
		}

		private static void SelectFromAvailableMaps(MapInfo selectedMap)
		{
			MapInfo map = MapInfoCollection.AvailableMaps.Find(item => item.Name.Equals(selectedMap.Name, StringComparison.OrdinalIgnoreCase) && item.Category.Equals(selectedMap.Category, StringComparison.OrdinalIgnoreCase));
			if (map != null)
			{
				map.Include = true;
				map.Order = selectedMap.Order;
			}
		}

		private MapGameModes _gameMode;
		private MapInfoCollection _gridSource;
		private MapInfoCollection _listSource;
		private MapInfo _selectedMap;

		private MapRotationForm(MapGameModes gameMode)
		{
			_gameMode = gameMode;
			InitializeComponent();
			grdAvailableMaps.AutoGenerateColumns = false;
			cboMapTypeFilter.SelectedIndex = 2;
		}

		private void RefreshGrid()
		{
			MapTypes mapType = (MapTypes)(cboMapTypeFilter.SelectedIndex + 1);
			_gridSource = MapInfoCollection.AvailableMaps.GetMaps(mapType, _gameMode);
			grdAvailableMaps.DataSource = _gridSource;
		}

		private void grdAvailableMaps_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if ((e.RowIndex >= 0) && (e.RowIndex < _gridSource.Count))
			{
				DisplayMapInfo(_gridSource[e.RowIndex]);
			}
		}

		private void DisplayMapInfo(MapInfo mapInfo)
		{
			if (mapInfo != null)
			{
				lblMapInfo.Text = string.Format("Name: {0}\r\nCategory: {1}\r\nSize: {2}\r\nGame Modes: {3}\r\nAuthor: {4}\r\nCreator: {5}",
					mapInfo.Name, mapInfo.Category, mapInfo.MapSize, mapInfo.GameModes, mapInfo.Author, mapInfo.Creator);
				pbxMapImage.Image = mapInfo.Screenshot;
			}
		}

		private void cboMapTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshGrid();
		}

		private void btnTop_Click(object sender, EventArgs e)
		{
			MoveToTop();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			MoveUp();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			MoveDown();
		}

		private void btnBottom_Click(object sender, EventArgs e)
		{
			MoveToBottom();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			Remove();
		}

		private void MoveToTop()
		{
			MapInfo selectedMap = GetSelectedMapFromList();
			if (selectedMap != null)
			{
				for (int idx = 0; idx < _listSource.Count; idx++)
				{
					if (_listSource[idx] == selectedMap)
					{
						_listSource[idx].Order = 1;
						break;
					}
					else
					{
						_listSource[idx].Order++;
					}
				}
				RefreshList();
			}
		}

		private void MoveUp()
		{
			MapInfo selectedMap = GetSelectedMapFromList();
			if ((selectedMap != null) && (selectedMap.Order != 1))
			{
				int idx = _listSource.IndexOf(selectedMap);
				_listSource[idx - 1].Order++;
				selectedMap.Order--;
				RefreshList();
			}
		}

		private void MoveDown()
		{
			MapInfo selectedMap = GetSelectedMapFromList();
			if ((selectedMap != null) && (selectedMap.Order != _listSource.Count))
			{
				int idx = _listSource.IndexOf(selectedMap);
				_listSource[idx + 1].Order--;
				selectedMap.Order++;
				RefreshList();
			}
		}

		private void MoveToBottom()
		{
			MapInfo selectedMap = GetSelectedMapFromList();
			if (selectedMap != null)
			{
				for (int idx = (_listSource.Count - 1); idx >= 0; idx--)
				{
					if (_listSource[idx] == selectedMap)
					{
						_listSource[idx].Order = _listSource.Count;
						break;
					}
					else
					{
						_listSource[idx].Order--;
					}
				}
				RefreshList();
			}
		}

		private void Remove()
		{
			MapInfo selectedMap = GetSelectedMapFromList();
			if (selectedMap != null)
			{
				string msg = string.Format("Are you sure you want to remove '{0}' from the map rotation?", selectedMap.Name);
				if (MessageBox.Show(this, msg, "Remove Map?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					selectedMap.Include = false;
					selectedMap.Order = int.MaxValue;
					RefreshList();
				}
			}
		}

		private bool _refreshingList;
		private void RefreshList()
		{
			_refreshingList = true;
			_listSource = _gridSource.GetSortedList();
			lstSelectedMaps.DataSource = _listSource;
			lstSelectedMaps.DisplayMember = "Name";
			_refreshingList = false;

			if (_listSource.Count != 0)
			{
				if (_selectedMap == null)
				{
					lstSelectedMaps.SelectedIndex = 0;
				}
				else
				{
					lstSelectedMaps.SelectedIndex = _listSource.IndexOf(_selectedMap);
				}
			}
		}

		private MapInfo GetSelectedMapFromList()
		{
			_selectedMap = null;

			if ((lstSelectedMaps.SelectedIndex >= 0) && (lstSelectedMaps.SelectedIndex < _listSource.Count))
			{
				_selectedMap = _listSource[lstSelectedMaps.SelectedIndex];
			}

			return _selectedMap;
		}

		private void lstSelectedMaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_refreshingList)	DisplayMapInfo(GetSelectedMapFromList());
		}

		private void lstSelectedMaps_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.Up)
				{
					MoveUp();
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Down)
				{
					MoveDown();
					e.Handled = true;
					e.SuppressKeyPress = true;
				}
			}
			else if ((e.KeyCode == Keys.Delete) && !(e.Shift || e.Alt))
			{
				Remove();
			}
		}

		private void tabMapRotation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabMapRotation.SelectedTab == tpgSelectedMaps)
			{
				RefreshList();
			}
			else
			{
				_selectedMap = null;
			}
		}
	}
}
