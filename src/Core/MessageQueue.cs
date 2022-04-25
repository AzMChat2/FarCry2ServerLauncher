using System.Collections.Generic;
using System.Threading;

namespace GSL
{
	public class MessageQueue
	{
		protected ManualResetEvent _messagesWaiting = new ManualResetEvent(false);
		protected Queue<string> _messages = new Queue<string>();

		public void Enqueue(string message)
		{
			lock (_messages)
			{
				_messages.Enqueue(message);
				_messagesWaiting.Set();
			}
		}

		public string Dequeue()
		{
			string retVal = null;

			if (_messagesWaiting.WaitOne(Settings.Values.ProcessInterval))
			{
				lock (_messages)
				{
					retVal = _messages.Dequeue();
					if (_messages.Count == 0) _messagesWaiting.Reset();
				}
			}

			return retVal;
		}

	}
}
