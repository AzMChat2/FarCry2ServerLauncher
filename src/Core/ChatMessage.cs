using System;
using System.Collections.Generic;

namespace GSL
{
	public sealed class ChatMessage
	{
		public ChatMessage(string playerName, string message)
		{
			MessageTime = DateTime.Now;
			PlayerName = playerName;
			Message = message;
		}

		public DateTime MessageTime { get; private set; }
		public string PlayerName { get; private set; }
		public string Message { get; private set; }
	}

	public sealed class ChatMessageCollection : ListBuffer<ChatMessage>
	{
		public List<ChatMessage> GetMessagesFromPlayer(string playerName)
		{
			return FindAll(item => item.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
		}
	}
}
