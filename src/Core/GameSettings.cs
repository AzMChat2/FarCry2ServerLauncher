using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GSL
{
	public sealed class GameSetting
	{
		public GameSetting()
		{
			ValidValues = new ValidValueCollection();
		}

		[XmlAttribute]
		public string Command { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public string Description { get; set; }
		[XmlAttribute]
		public string DefaultValue { get; set; }
		[XmlElement("ValidValue")]
		public ValidValueCollection ValidValues { get; set; }

		[XmlIgnore]
		public string Value { get; set; }

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("GameSetting");
			writer.WriteAttribute("Command", Command);
			writer.WriteAttribute("Value", Value);
			writer.WriteEndElement();
		}

		public void Validate()
		{
			bool valid = false;

			if (ValidValues.Count == 0)
			{
				valid = true;
			}
			else
			{
				foreach (ValidValue validValue in ValidValues)
				{
					if (validValue.Value.Equals(Value, StringComparison.OrdinalIgnoreCase))
					{
						Value = validValue.Value;
						valid = true;
						break;
					}
				}
			}

			if ((!valid) || string.IsNullOrEmpty(Value))
			{
				Value = DefaultValue;
			}
		}
	}

	public sealed class GameSettingCollection : ListEx<GameSetting>
	{
		public static GameSettingCollection Load(GameModes gameMode, ServerModes serverMode)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(GameSettingCollection));

			string resourceName = string.Format(CultureInfo.CurrentCulture, "\\XmlResources\\{0}_{1}_Settings.xml", gameMode, serverMode);

			using (Stream stream = Utilities.GetResourceStream(resourceName))
			{
				return (GameSettingCollection)serializer.Deserialize(stream);
			}
		}

		public void ReadXml(XmlReader reader)
		{
			while (reader.Read())
			{
				if (reader.IsStartElement("GameSetting"))
				{
					string command = reader.GetAttribute("Command");
					string value = reader.GetAttribute("Value");

					GameSetting setting = Find(item => item.Command == command);
					if (setting != null)
					{
						setting.Value = value;
					}
				}
				else
				{
					break;
				}
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			ForEach(item => item.WriteXml(writer));
		}

		public void Validate()
		{
			ForEach(item => item.Validate());
		}
	}

	public sealed class ValidValue
	{
		[XmlAttribute]
		public string Value { get; set; }
		[XmlAttribute]
		public string Description { get; set; }
		[XmlIgnore]
		public string Display
		{
			get
			{
				if (string.IsNullOrEmpty(Description))
				{
					return Value;
				}
				else
				{
					return string.Format(CultureInfo.InvariantCulture, "{0} - {1}", Value, Description);
				}
			}
		}
	}

	public sealed class ValidValueCollection : ListEx<ValidValue> { }

}
