using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GSL
{
	[Serializable]
	public sealed class GameServerLauncherException : Exception
	{
		public GameServerLauncherException() { }
		public GameServerLauncherException(string message) : base(message) { }
		public GameServerLauncherException(string message, Exception inner) : base(message, inner) { }
		protected GameServerLauncherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
