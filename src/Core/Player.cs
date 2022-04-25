using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using FC2.SL.Remote;
using System.Xml.Serialization;

namespace GSL
{
	public sealed class Player : PlayerStatus
	{
		[XmlIgnore]
		public Teams Team { get; set; }
		[XmlIgnore]
		public bool IsConnected { get; set; }
		[XmlIgnore]
		public int KickCount { get; set; }
		[XmlIgnore]
		public bool HasStats { get { return ((MapKills + MapDeaths + MapSuicides + MapTeamKills) != 0); } }

		public void WriteStats(XmlWriter writer, string mapName, DateTime date)
		{
			writer.WriteStartElement("PlayerStat");

			writer.WriteAttribute("PlayerName", Name);
			writer.WriteAttribute("MapName", mapName);
			writer.WriteAttribute("Date", date);
			writer.WriteAttribute("Kills", MapKills);
			writer.WriteAttribute("Deaths", MapDeaths);
			writer.WriteAttribute("Suicides", MapSuicides);
			writer.WriteAttribute("TeamKills", MapTeamKills);

			writer.WriteEndElement();
		}
	}

	public sealed class PlayerCollection : ListEx<Player>
	{
		public Player this[string playerName]
		{
			get
			{
				Player retVal = Find(item => item.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
				if (retVal == null)
				{
					retVal = new Player();
					retVal.Name = playerName;
					Add(retVal);
				}
				return retVal;
			}
		}

		public void WriteStats(XmlWriter writer, string mapName, DateTime date)
		{
			FindAll(item => item.HasStats).ForEach(item => item.WriteStats(writer, mapName, date));
		}

		public bool HasStats
		{
			get { return Exists(item => item.HasStats); } 
		}

		public void UpdateStats()
		{
			FindAll(item => item.HasStats).ForEach(item => item.UpdateStats());
		}

		public void Sort(string columnName)
		{
			try
			{
				switch (columnName)
				{
					case "Team":
						Sort((a, b) => a.Team.CompareTo(b.Team));
						break;
					case "IsConnected":
						Sort((a, b) => a.IsConnected.CompareTo(b.IsConnected));
						break;
					case "KickCount":
						Sort((a, b) => a.KickCount.CompareTo(b.KickCount));
						break;
					case "HasStats":
						Sort((a, b) => a.HasStats.CompareTo(b.HasStats));
						break;
					case "MatchesPlayed ":
						Sort((a, b) => a.MatchesPlayed.CompareTo(b.MatchesPlayed));
						break;
					case "MapKills":
						Sort((a, b) => a.MapKills.CompareTo(b.MapKills));
						break;
					case "MapDeaths":
						Sort((a, b) => a.MapDeaths.CompareTo(b.MapDeaths));
						break;
					case "MapSuicides":
						Sort((a, b) => a.MapSuicides.CompareTo(b.MapSuicides));
						break;
					case "MapTeamKills":
						Sort((a, b) => a.MapTeamKills.CompareTo(b.MapTeamKills));
						break;
					case "MapWarnings":
						Sort((a, b) => a.MapWarnings.CompareTo(b.MapWarnings));
						break;
					case "PreviousKills":
						Sort((a, b) => a.PreviousKills.CompareTo(b.PreviousKills));
						break;
					case "TotalKills":
						Sort((a, b) => a.TotalKills.CompareTo(b.TotalKills));
						break;
					case "PreviousDeaths":
						Sort((a, b) => a.PreviousDeaths.CompareTo(b.PreviousDeaths));
						break;
					case "TotalDeaths":
						Sort((a, b) => a.TotalDeaths.CompareTo(b.TotalDeaths));
						break;
					case "PreviousSuicides":
						Sort((a, b) => a.PreviousSuicides.CompareTo(b.PreviousSuicides));
						break;
					case "TotalSuicides":
						Sort((a, b) => a.TotalSuicides.CompareTo(b.TotalSuicides));
						break;
					case "PreviousTeamKills":
						Sort((a, b) => a.PreviousTeamKills.CompareTo(b.PreviousTeamKills));
						break;
					case "TotalTeamKills":
						Sort((a, b) => a.TotalTeamKills.CompareTo(b.TotalTeamKills));
						break;
					case "PreviousWarnings":
						Sort((a, b) => a.PreviousWarnings.CompareTo(b.PreviousWarnings));
						break;
					case "TotalWarnings":
						Sort((a, b) => a.TotalWarnings.CompareTo(b.TotalWarnings));
						break;
					case "Name":
					default:
						Sort((a, b) => a.Name.CompareTo(b.Name));
						break;
				}
			}
			catch { }
		}
	}
}


