using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GSL
{
	[Serializable]
	public sealed class ServerMessage
	{
		public ServerMessage()
		{
			Interval = 300;
		}

		[XmlAttribute("Message")]
		public string Message { get; set; }

		[XmlAttribute]
		public int Interval { get; set; }

		[XmlAttribute]
		public int Delay { get; set; }

		public void SetInitialTime(DateTime time)
		{
			LastMessage = time.AddSeconds(Delay - Interval);
		}

		[XmlIgnore]
		public DateTime LastMessage { get; set; }

		[XmlIgnore]
		public DateTime NextMessage
		{
			get { return LastMessage.AddSeconds(Interval); }
		}
	}

	public sealed class ServerMessageCollection : ListEx<ServerMessage> { }

	public sealed class MessageCollection : ListEx<string> { }
}
