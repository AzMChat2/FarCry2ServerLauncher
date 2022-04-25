using System;

namespace GSL
{
	public sealed class ServerDiedEventArgs : EventArgs
	{
		public ServerDiedEventArgs(string processStats)
		{
			ProcessStats = processStats;
		}

		public string ProcessStats { get; private set; }
	}

	public sealed class PlayerEventArgs : EventArgs
	{
		public PlayerEventArgs(string playerName)
		{
			PlayerName = playerName;
		}

		public string PlayerName { get; private set; }
	}

	public sealed class KillEventArgs : EventArgs
	{
		public KillEventArgs(string killerName, string victimName)
		{
			KillerName = killerName;
			VictimName = victimName;
		}

		public string KillerName { get; private set; }
		public string VictimName { get; private set; }
	}

	public sealed class TeamAssignedEventArgs : EventArgs
	{
		public TeamAssignedEventArgs(string playerName, Teams team)
		{
			PlayerName = playerName;
			Team = team;
		}

		public string PlayerName { get; private set; }
		public Teams Team { get; private set; }
	}

	public sealed class MapChangedEventArgs : EventArgs
	{
		public MapChangedEventArgs(string mapName)
		{
			MapName = mapName;
		}

		public string MapName { get; private set; }
	}

	public sealed class PlayerMessageEventArgs : EventArgs
	{
		public PlayerMessageEventArgs(string playerName, string message)
		{
			PlayerName = playerName;
			Message = message;
		}

		public string PlayerName { get; private set; }
		public string Message { get; private set; }
	}

	public sealed class ConsoleMessageEventArgs : EventArgs
	{
		public ConsoleMessageEventArgs(ConsoleMessage message)
		{
			Message = message;
		}

		public ConsoleMessage Message { get; private set; }
	}

	public sealed class StatusChangedEventArgs : EventArgs
	{
		public StatusChangedEventArgs(ServerStates status)
		{
			Status = status;
		}

		public ServerStates Status { get; private set; }
	}
}
