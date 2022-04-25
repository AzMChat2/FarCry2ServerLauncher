using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FC2.SL.Remote
{

	public class UserRights
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public bool IsRemoteUser { get; set; }
		[XmlAttribute]
		public bool FullAdmin { get; set; }
		[XmlAttribute]
		public bool CanBanPlayer { get; set; }
		[XmlAttribute]
		public bool CanWarnPlayer { get; set; }
		[XmlAttribute]
		public bool CanKickPlayer { get; set; }
		[XmlAttribute]
		public bool CanEndMatch { get; set; }
		[XmlAttribute]
		public bool CanRestartMatch { get; set; }
		[XmlAttribute]
		public bool CanExtendMatch { get; set; }
		[XmlAttribute]
		public bool CanSkipMap { get; set; }
		[XmlAttribute]
		public bool CanShuffleTeams { get; set; }
	}
}
