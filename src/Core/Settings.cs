using System.Xml.Serialization;
using Echis.Configuration;

namespace GSL
{
	public sealed class Settings : SettingsBase<Settings>
	{
		[XmlAttribute]
		public string BannedPlayerFile { get; set; }

		[XmlAttribute]
		public int ProcessInterval { get; set; }

		[XmlAttribute]
		public string ServerExe { get; set; }
	
		[XmlAttribute]
		public string ServerResourceFile { get; set;}
	}
}
