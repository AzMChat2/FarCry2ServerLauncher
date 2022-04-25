using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FC2.SL.Remote
{
	[XmlType("Player")]
	public class PlayerStatus : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		[XmlAttribute]
		public string Name { get; set; }

		[XmlAttribute]
		public int MatchesPlayed { get; set; }

		private int _mapKills;
		[XmlAttribute]
		public int MapKills
		{
			get { return _mapKills; }
			set
			{
				_mapKills = value;
				OnPropertyChanged("MapKills");
				OnPropertyChanged("TotalKills");
			}
		}

		private int _mapDeaths;
		[XmlAttribute]
		public int MapDeaths
		{
			get { return _mapDeaths; }
			set
			{
				_mapDeaths = value;
				OnPropertyChanged("MapDeaths");
				OnPropertyChanged("TotalDeaths");
			}
		}

		private int _mapSuicides;
		[XmlAttribute]
		public int MapSuicides
		{
			get { return _mapSuicides; }
			set
			{
				_mapSuicides = value;
				OnPropertyChanged("MapSuicides");
				OnPropertyChanged("TotalSuicides");
			}
		}

		private int _mapTeamKills;
		[XmlAttribute]
		public int MapTeamKills
		{
			get { return _mapTeamKills; }
			set
			{
				_mapTeamKills = value;
				OnPropertyChanged("MapTeamKills");
				OnPropertyChanged("TotalTeamKills");
			}
		}

		private int _mapWarnings;
		[XmlAttribute]
		public int MapWarnings
		{
			get { return _mapWarnings; }
			set
			{
				_mapWarnings = value;
				OnPropertyChanged("MapWarnings");
				OnPropertyChanged("TotalWarnings");
			}
		}

		[XmlAttribute]
		public int PreviousKills { get; set; }
		[XmlIgnore]
		public int TotalKills { get { return PreviousKills + MapKills; } }

		[XmlAttribute]
		public int PreviousDeaths { get; set; }
		[XmlIgnore]
		public int TotalDeaths { get { return PreviousDeaths + MapDeaths; } }

		[XmlAttribute]
		public int PreviousSuicides { get; set; }
		[XmlIgnore]
		public int TotalSuicides { get { return PreviousSuicides + MapSuicides; } }

		[XmlAttribute]
		public int PreviousTeamKills { get; set; }
		[XmlIgnore]
		public int TotalTeamKills { get { return PreviousTeamKills + MapTeamKills; } }

		[XmlAttribute]
		public int PreviousWarnings { get; set; }
		[XmlIgnore]
		public int TotalWarnings { get { return PreviousWarnings + MapWarnings; } }

		public void UpdateStats()
		{
			PreviousKills += MapKills;
			PreviousDeaths += MapDeaths;
			PreviousSuicides += MapSuicides;
			PreviousTeamKills += MapTeamKills;
			PreviousWarnings += MapWarnings;

			MapKills = 0;
			MapDeaths = 0;
			MapSuicides = 0;
			MapTeamKills = 0;
			MapWarnings = 0;

			MatchesPlayed++;
			OnPropertyChanged("MatchesPlayed");
		}
	}
}