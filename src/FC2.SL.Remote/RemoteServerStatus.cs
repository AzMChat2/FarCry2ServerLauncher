using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FC2.SL.Remote
{
	public class RemoteServerStatus
	{
		[XmlAttribute]
		public string ServerName { get; set; }

		[XmlAttribute]
		public string CurrentMap { get; set; }

		[XmlAttribute]
		public string StatusDescription { get; set; }

		[XmlElement("Player")]
		public PlayerStatus[] Players { get; set; }

		[XmlElement("ConsoleLine")]
		public string[] ConsoleLines { get; set; }

		[XmlElement("MessageLine")]
		public string[] MessageLines { get; set; }

		[XmlElement("KillLogLine")]
		public string[] KillLogLines { get; set; }
	}
}
