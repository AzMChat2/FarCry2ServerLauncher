using System;

namespace GSL
{
	public sealed class ConsoleMessage
	{
		public ConsoleMessage(ConsoleSources source, MessageCategories category, string message)
		{
			TimeStamp = DateTime.Now;
			Source = source;
			Category = category;
			Message = message;
		}

		public DateTime TimeStamp { get; private set; }
		public ConsoleSources Source { get; private set; }
		public MessageCategories Category { get; private set; }
		public string Message { get; private set; }
	}

	public sealed class ConsoleMessagesCollection : ListBuffer<ConsoleMessage>
	{
	}
}
