using System.Collections.Generic;
using System.Xml.Serialization;
using FC2.SL.Remote;

namespace GSL
{
	[XmlType("Player")]
	public sealed class User : UserRights
	{
		[XmlIgnore]
		public string Password { get; set; }
		[XmlAttribute]
		public bool IsClanMember { get; set; }
		[XmlIgnore]
		public bool IsAdmin
		{
			get
			{
				return CanBanPlayer || CanWarnPlayer || CanKickPlayer ||
					CanEndMatch || CanRestartMatch || CanExtendMatch ||
					CanSkipMap || CanShuffleTeams;
			}
		}
	}

	public sealed class UserCollection : ListEx<User> { }
}
