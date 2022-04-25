using System;
using System.IO;
using System.Xml.Serialization;

namespace GSL
{
	[Serializable]
	public sealed class ServerConfig
	{
		private static XmlSerializer serializer = new XmlSerializer(typeof(ServerConfig));

		public static void SaveSettings(ServerConfig settings, string fileName)
		{
			using (Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				serializer.Serialize(stream, settings);
				stream.Close();
			}
		}

		public static ServerConfig LoadSettings(string fileName)
		{
			ServerConfig retVal = null;

			if (File.Exists(fileName))
			{
				using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
				{
					retVal = (ServerConfig)serializer.Deserialize(stream);
					stream.Close();
				}
			}
			else
			{
				retVal = new ServerConfig();
				retVal.SetDefaults();
			}

			return retVal;
		}

		public ServerConfig()
		{
			Users = new UserCollection();
			MiscConfig = new MiscConfig();
			BanConfig = new BanConfig();
		}

		[XmlElement("Player")]
		public UserCollection Users { get; set; }

		[XmlElement]
		public MiscConfig MiscConfig { get; set; }

		[XmlElement]
		public BanConfig BanConfig { get; set; }

		[XmlElement]
		public RemoteConfig RemoteConfig { get; set; }

		private void SetDefaults()
		{
			MiscConfig.SetDefaults();
			BanConfig.SetDefaults();
		}
	}

	public sealed class MiscConfig
	{
		public MiscConfig()
		{
			ServerMessages = new ServerMessageCollection();
			WelcomeMessages = new MessageCollection();
			ServerGameSettings = new ServerSettingsCollection();
		}

		[XmlElement("Welcome")]
		public MessageCollection WelcomeMessages { get; set; }

		[XmlElement("ServerMessage")]
		public ServerMessageCollection ServerMessages { get; set; }

		[XmlElement("GameServer")]
		public ServerSettingsCollection ServerGameSettings { get; set; }

		[XmlAttribute]
		public bool AutoRestart { get; set; }

		[XmlAttribute]
		public bool LogStats { get; set; }

		[XmlAttribute]
		public string StatsFile { get; set; }

		[XmlAttribute]
		public int RestartWait { get; set; }

		[XmlAttribute]
		public int StartTimeout { get; set; }

		[XmlAttribute]
		public int MessageWait { get; set; }

		[XmlAttribute]
		public bool AutoAdjustMinPlayers { get; set; }

		[XmlAttribute]
		public int MinPlayerPercent { get; set; }

		public void SetDefaults()
		{
			WelcomeMessages.Add("Welcome {0} to the");
			WelcomeMessages.Add("{1} server.");

			AutoRestart = true;
			LogStats = true;
			StatsFile = "Stats";
			RestartWait = 120;
			StartTimeout = 120;
			MessageWait = 1;
		}

		public static void CopyValues(MiscConfig source, MiscConfig target)
		{
			source.ServerGameSettings.ForEach(item => CopyValues(item, target));
		}

		private static void CopyValues(ServerSettings source, MiscConfig target)
		{
			ServerSettings setting = target.ServerGameSettings.Find(item => (item.ServerName == source.ServerName));
			if (setting != null) ServerSettings.CopyValues(source, setting);
		}
	}

	[Serializable]
	public sealed class BanConfig
	{
		public BanConfig()
		{
			BanLengths = new BanLengthCollection();
			SwearWords = new MessageCollection();

			TeamKillBanMessages = new MessageCollection();
			TeamKillWarningMessages = new MessageCollection();

			SwearingBanMessages = new MessageCollection();
			SwearingWarningMessages = new MessageCollection();

			MisconductBanMessages = new MessageCollection();
			MisconductWarningMessages = new MessageCollection();

			BannedMessages = new MessageCollection();
		}

		[XmlAttribute]
		public bool BanSwearing { get; set; }

		[XmlAttribute]
		public bool BanTeamKill { get; set; }

		[XmlAttribute]
		public int Warnings { get; set; }

		[XmlAttribute]
		public int MaxWarnings { get; set; }

		[XmlAttribute]
		public int BanHistory { get; set; }

		[XmlElement("BanLength")]
		public BanLengthCollection BanLengths { get; set; }

		[XmlElement("SwearWord")]
		public MessageCollection SwearWords { get; set; }

		[XmlElement("BannedMessage")]
		public MessageCollection BannedMessages { get; set; }

		[XmlElement("TeamKillWarning")]
		public MessageCollection TeamKillWarningMessages { get; set; }

		[XmlElement("TeamKillBan")]
		public MessageCollection TeamKillBanMessages { get; set; }

		[XmlElement("SwearingWarning")]
		public MessageCollection SwearingWarningMessages { get; set; }

		[XmlElement("SwearingBan")]
		public MessageCollection SwearingBanMessages { get; set; }

		[XmlElement("MisconductWarning")]
		public MessageCollection MisconductWarningMessages { get; set; }

		[XmlElement("MisconductBan")]
		public MessageCollection MisconductBanMessages { get; set; }

		#region Defaults
		public void SetDefaults()
		{
			BanSwearing = true;
			BanTeamKill = true;
			Warnings = 5;
			MaxWarnings = 50;
			BanHistory = 3;

			BanLength first = new BanLength();
			first.BanNumber = 1;
			first.Value = 1;
			first.Type = "Hours";
			BanLengths.Add(first);

			BanLength second = new BanLength();
			second.BanNumber = 2;
			second.Value = 1;
			second.Type = "Days";
			BanLengths.Add(second);

			BanLength third = new BanLength();
			third.BanNumber = 3;
			third.Value = 1;
			third.Type = "Weeks";
			BanLengths.Add(third);

			BanLength fourth = new BanLength();
			fourth.BanNumber = 4;
			fourth.Value = 1;
			fourth.Type = "Months";
			BanLengths.Add(fourth);

			SwearWords.Add("fuck");
			SwearWords.Add("shit");
			SwearWords.Add("asshole");

			TeamKillWarningMessages.Add("ATTENTION {0}");
			TeamKillWarningMessages.Add("WARNING! Team Killing is not allowed!");
			TeamKillWarningMessages.Add("Team Killers will be banned.");
			TeamKillWarningMessages.Add("You have been warned.");

			SwearingWarningMessages.Add("ATTENTION {0}");
			SwearingWarningMessages.Add("WARNING! Swearing is not allowed!");
			SwearingWarningMessages.Add("Players using foul language will be");
			SwearingWarningMessages.Add("banned.  You have been warned.");

			MisconductWarningMessages.Add("ATTENTION {0}");
			MisconductWarningMessages.Add("WARNING! Misconduct is not tolerated!");
			MisconductWarningMessages.Add("Obey in-game administrators.");
			MisconductWarningMessages.Add("You have been warned.");

			TeamKillBanMessages.Add("ATTENTION {0}");
			TeamKillBanMessages.Add("You have been banned from this server");
			TeamKillBanMessages.Add("You were banned for Team Killing");

			SwearingBanMessages.Add("ATTENTION {0}");
			SwearingBanMessages.Add("You have been banned from this server");
			SwearingBanMessages.Add("You were banned for Foul Language");

			MisconductBanMessages.Add("ATTENTION {0}");
			MisconductBanMessages.Add("You have been banned from this server");
			MisconductBanMessages.Add("You were banned for Misconduct");

			BannedMessages.Add("ATTENTION {0}");
			BannedMessages.Add("You have been banned from this server");
			BannedMessages.Add("This ban will expire after {2}");
			BannedMessages.Add("You were banned for this reason:");
			BannedMessages.Add("{1}");
		}
		#endregion
	}

	public class RemoteConfig
	{
		[XmlAttribute]
		public bool Enabled { get; set; }
		[XmlAttribute]
		public string KeyFilename { get; set; }
	}
}
