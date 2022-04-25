using System;
using System.Collections.Generic;

namespace GSL
{
	public sealed class PlayerMessage
	{
		public PlayerMessage(string playerName, DateTime timeToSend)
		{
			PlayerName = playerName;
			Messages = new MessageCollection();
			TimeToSend = timeToSend;
		}

		public string PlayerName { get; private set; }
		public MessageCollection Messages { get; private set; }
		public DateTime TimeToSend { get; private set; }
	}

	public sealed class PlayerMessageCollection : ListEx<PlayerMessage> { }
}
