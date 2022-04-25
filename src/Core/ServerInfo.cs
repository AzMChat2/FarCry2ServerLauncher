using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace GSL
{
	public sealed class ServerInfo : INotifyPropertyChanged
	{
		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		public ServerInfo(ServerConfig config, string serverName)
		{
			Config = config;
			Players = new PlayerCollection();
			PlayerMessages = new PlayerMessageCollection();
			ChatMessages = new ChatMessageCollection();
			ConsoleMessages = new ConsoleMessagesCollection();
			ServerName = serverName;
			AutoStart = DateTime.MaxValue;
			StartTimeout = DateTime.MaxValue;
		}

		public ServerConfig Config { get; private set; }
		public PlayerCollection Players { get; private set; }
		public PlayerMessageCollection PlayerMessages { get; private set; }
		public ChatMessageCollection ChatMessages { get; private set; }
		public ConsoleMessagesCollection ConsoleMessages { get; private set; }
		public string ServerName { get; private set; }

		public DateTime AutoStart { get; set; }
		public DateTime StartTimeout { get; set; }
		public DateTime NextMessage { get; set; }
		public DateTime StatusChanged { get; private set; }

		public bool Paused { get; set; }
		public bool StopAtNoPlayers { get; set; }
		public bool StopAfterMatch { get; set; }
		public bool IsDisconnected { get; set; }

		private bool _isRunning;
		public bool IsRunning
		{
			get { return _isRunning; }
			set
			{
				if (_isRunning != value)
				{
					_isRunning = value;
					OnPropertyChanged("IsRunning");
					Trace.WriteLineIf(TS.Verbose, "Is Running: " + _isRunning, TS.Categories.Debug);
				}
			}
		}

		private bool _isStarting;
		public bool IsStarting
		{
			get { return _isStarting; }
			set
			{
				if (_isStarting != value)
				{
					_isStarting = value;
					OnPropertyChanged("IsStarting");
					Trace.WriteLineIf(TS.Verbose, "Is Starting: " + _isStarting, TS.Categories.Debug);
				}
			}
		}

		private string _currentMap;
		public string CurrentMap
		{
			get { return _currentMap; }
			set
			{
				if (_currentMap != value)
				{
					_currentMap = value;
					OnPropertyChanged("CurrentMap");
					Trace.WriteLineIf(TS.Verbose, "Current Map: " + _currentMap, TS.Categories.Debug);
				}
			}
		}

		private ServerStates _status;
		public ServerStates Status
		{
			get { return _status; }
			set
			{
				if (_status != value)
				{
					StatusChanged = DateTime.Now;
					_status = value;
					OnPropertyChanged("Status");
					Trace.WriteLineIf(TS.Verbose, "Status: " + _status, TS.Categories.Debug);
				}
			}
		}
	}
}
