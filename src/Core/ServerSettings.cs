using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GSL
{
	public sealed class ServerSettings
	{
		private static XmlSerializer mapRotationSerializer = new XmlSerializer(typeof(MapInfoCollection));
		
		public ServerSettings()
		{
			MapRotation = new MapInfoCollection();
			GameMode = GameModes.Deathmatch;
			ServerMode = ServerModes.Lan;
			GameSettings = GameSettingCollection.Load(GameMode, ServerMode);
			GameSettings.Validate();
		}

		[XmlAttribute]
		public string ServerName { get; set; }
		[XmlAttribute]
		public string Filename { get; set; }
		[XmlIgnore]
		public MapInfoCollection MapRotation { get; set; }
		[XmlIgnore]
		public GameModes GameMode { get; set; }
		[XmlIgnore]
		public ServerModes ServerMode { get; set; }
		[XmlIgnore]
		public GameSettingCollection GameSettings { get; set; }

		public void ChangeGameMode(GameModes newGameMode)
		{
			if (GameMode != newGameMode)
			{
				ApplyNewMode(GameSettingCollection.Load(newGameMode, ServerMode));
				GameMode = newGameMode;
			}
		}

		public void ChangeServerMode(ServerModes newServerMode)
		{
			if (ServerMode != newServerMode)
			{
				ApplyNewMode(GameSettingCollection.Load(GameMode, newServerMode));
				ServerMode = newServerMode;
			}
		}

		private void ApplyNewMode(GameSettingCollection newModeSettings)
		{
			newModeSettings.ForEach(item => ApplyNewMode(item));
			GameSettings.RemoveAll(item => !CheckNewMode(newModeSettings, item));
		}

		private bool CheckNewMode(GameSettingCollection newModeSettings, GameSetting setting)
		{
			return (newModeSettings.Exists(item => item.Command.Equals(setting.Command, StringComparison.OrdinalIgnoreCase)));
		}

		private void ApplyNewMode(GameSetting newSetting)
		{
			GameSetting setting = GameSettings.Find(item => item.Command.Equals(newSetting.Command, StringComparison.OrdinalIgnoreCase));
			if (setting == null)
			{
				setting = newSetting;
				GameSettings.Add(setting);
			}
			else
			{
				setting.DefaultValue = newSetting.DefaultValue;
				setting.ValidValues = newSetting.ValidValues;
			}
			setting.Validate();
		}

		public void Load()
		{
			try
			{
				using (Stream stream = File.OpenRead(Filename))
				{
					using (XmlTextReader reader = new XmlTextReader(stream))
					{
						while (reader.Read())
						{
							if (reader.IsStartElement("Settings"))
							{
								ReadXml(reader);
							}

							if (reader.IsStartElement("MapRotation") && reader.Read())
							{
								MapRotation = (MapInfoCollection)mapRotationSerializer.Deserialize(reader);
							}
						}
						reader.Close();
					}
				}
			}
			catch (IOException ex)
			{
				string msg =  string.Format(CultureInfo.CurrentCulture, "Error loading Server Settings from file '{0}.'\r\n{1}", Filename, ex);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
				throw;
			}
		}

		public void Save()
		{
			try
			{
				if (string.IsNullOrEmpty(Filename))
				{
					Filename = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Games\Far Cry 2\Server\" + Scrub(ServerName);
				}

				using (XmlTextWriter writer = new XmlTextWriter(Filename, ASCIIEncoding.ASCII))
				{
					writer.Formatting = Formatting.Indented;

					writer.WriteStartDocument();
					writer.WriteStartElement("Settings");
					WriteXml(writer);
					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
			}
			catch (IOException ex)
			{
				string msg = string.Format(CultureInfo.CurrentCulture, "Error saving Server Settings to file '{0}.'\r\n{1}", Filename, ex);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
				throw;
			}
		}

		private string Scrub(string ServerName)
		{
			string[] badChars = new string[] { "/", "\\", ":", "*", "?", "\"", "<", ">", "|" };
			string retVal = ServerName.Replace(" ", "_");
			foreach (string badChar in badChars)
			{
				retVal = retVal.Replace(badChar, string.Empty);
			}
			return retVal;
		}

		public void ReadXml(XmlReader reader)
		{
			GameMode = (GameModes)reader.GetIntAttribute("GameMode");
			ServerMode = (ServerModes)reader.GetIntAttribute("ServerMode");
			if (string.IsNullOrEmpty(ServerName)) ServerName = reader.GetAttribute("ServerName");
			GameSettings = GameSettingCollection.Load(GameMode, ServerMode);
			GameSettings.ReadXml(reader);
			GameSettings.Validate();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttribute("ServerName", ServerName);
			writer.WriteAttribute("GameMode", (int)GameMode);
			writer.WriteAttribute("ServerMode", (int)ServerMode);
			GameSettings.ForEach(item => item.WriteXml(writer));

			writer.WriteStartElement("MapRotation");
			mapRotationSerializer.Serialize(writer, MapRotation);
			writer.WriteEndElement();
		}

		public string GetConfigFile()
		{
			GameSettings.Validate();

			string filename = Filename.Replace(".xml", ".cfg");
			Utilities.ClearFile(filename);

			using (StreamWriter writer = new StreamWriter(filename))
			{
				writer.WriteLine("SetSetting server_name {0}", ServerName);
				writer.WriteLine("SetSetting gamemode {0}", GameMode);
				writer.WriteLine("SetSetting map_cycle_limit {0}", MapRotation.Count);
				writer.WriteLine("SetSetting map_cycle {0}", MapRotation.GetRotationSetting());
				writer.WriteLine("SetSetting network_type {0}", NetworkType);
				writer.WriteLine("SetSetting ranked_match {0}", RankedSetting);

				GameSettings.ForEach(item => WriteIfNotEmpty(item, writer));
			}

			return filename;
		}

		private void WriteIfNotEmpty(GameSetting setting, StreamWriter writer)
		{
			if (!string.IsNullOrEmpty(setting.Value))
			{
				writer.WriteLine("{0} {1}", setting.Command, setting.Value);
			}
		}

		private string NetworkType
		{
			get { return ServerMode == ServerModes.Lan ? "2" : "1"; }
		}

		private string RankedSetting
		{
			get { return ServerMode == ServerModes.Ranked ? "1" : "0"; }
		}

		public static void CopyValues(ServerSettings source, ServerSettings target)
		{
			target.ServerMode = source.ServerMode;
			target.GameMode = source.GameMode;
			target.MapRotation.Clear();
			source.MapRotation.ForEach(item => target.MapRotation.Add(item));
			source.GameSettings.ForEach(item => CopyValue(item, target));
		}

		private static void CopyValue(GameSetting source, ServerSettings target)
		{
			GameSetting setting = target.GameSettings.Find(item => (item.Command == source.Command));
			if (setting != null) setting.Value = source.Value;
		}


	}

	public sealed class ServerSettingsCollection : ListEx<ServerSettings>
	{
	}

}
