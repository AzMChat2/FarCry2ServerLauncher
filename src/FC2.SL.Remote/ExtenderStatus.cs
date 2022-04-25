using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FC2.SL.Remote
{
	public class ExtenderStatus
	{
		[XmlElement]
		public UserRights User { get; set; }
		[XmlElement("Server")]
		public RemoteServerStatus[] Servers { get; set; }
	}
}
