using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FC2.SL.Remote;
using System.ServiceModel;
using System.Globalization;

namespace GSL
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class RemoteServer : ServerBase
	{
		private static RemoteServer _instance;
		private static ServiceHost _host;
		private static ServerConfig _config;

		public static void Initialize(ServerConfig config)
		{
			_instance = new RemoteServer();
			_config = config;
		}

		public static void StartServer()
		{
			if (_host == null)
			{
				_host = new ServiceHost(_instance);
				_host.Open();
			}
		}

		public static void StopServer()
		{
			if (_host != null)
			{
				try
				{
					_host.Close();
				}
				catch { }

				Dispose(_host);
				_host = null;
			}
		}

		public static void Register(ServerController controller)
		{
			_instance._servers.Add(controller);
		}

		public static void Close()
		{
			StopServer();
			if (_instance != null)
			{
				_instance._servers.Clear();
				_instance = null;
			}
			_config = null;
		}

		private static void Dispose(IDisposable disposableObject)
		{
			try
			{
				if (disposableObject != null)
				{
					disposableObject.Dispose();
				}
			}
			catch { }
		}


		private RemoteServer() { }

		private ListEx<ServerController> _servers = new ListEx<ServerController>();

		protected override ExtenderStatus GetStatus(Request request)
		{
			ExtenderStatus retVal = new ExtenderStatus();
			retVal.User = GetUserInfo(request);

			if (retVal.User != null)
			{
				if (!string.IsNullOrEmpty(request.ServerName) && !string.IsNullOrEmpty(request.Command))
				{
					ProcessRequest(request, retVal.User);
				}
				retVal.Servers = GetServerStats();
			}
			return retVal;
		}

		private RemoteServerStatus[] GetServerStats()
		{
			List<RemoteServerStatus> retVal = new List<RemoteServerStatus>();

			_servers.ForEach(item => retVal.Add(GetServerStats(item)));

			return retVal.ToArray();
		}

		private RemoteServerStatus GetServerStats(ServerController server)
		{
			RemoteServerStatus retVal = new RemoteServerStatus();

			retVal.ServerName = server.ServerName;
			retVal.CurrentMap = server.CurrentMap;
			retVal.ConsoleLines = GetConsoleLines(server.ConsoleMessages);
			retVal.KillLogLines = GetKillLogLines(server.ConsoleMessages);
			retVal.MessageLines = GetMessageLines(server.ChatMessages);
			retVal.Players = GetPlayers(server.Players);
			retVal.StatusDescription = GetStatusDescription(server);

			return retVal;
		}

		private string GetStatusDescription(ServerController server)
		{
			TimeSpan ts = server.StatusChanged.Subtract(DateTime.Now);
			return string.Format(CultureInfo.InvariantCulture, "Current Status: {0}\r\n{0}:{1:00}",
				server.Status, ((ts.Hours * 60) + ts.Minutes), ts.Seconds).Replace('_', ' ');
		}

		private PlayerStatus[] GetPlayers(PlayerCollection playerCollection)
		{
			return playerCollection.FindAll(item => item.IsConnected).ToArray();
		}

		private string[] GetMessageLines(ChatMessageCollection messages)
		{
			List<string> retVal = new List<string>();

			int startIndex = messages.Count - 100;
			if (startIndex < 0) startIndex = 0;

			for (int idx = startIndex; idx < messages.Count; idx++)
			{
				retVal.Add(string.Format(CultureInfo.InvariantCulture, "{0:hh:mm:ss} {1}:  {2}", messages[idx].MessageTime, messages[idx].PlayerName, messages[idx].Message));
			}

			return retVal.ToArray();
		}

		private string[] GetKillLogLines(ConsoleMessagesCollection messages)
		{
			List<string> retVal = new List<string>();

			List<ConsoleMessage> kills = messages.FindAll(item => item.Category == MessageCategories.Kill);

			int startIndex = kills.Count - 100;
			if (startIndex < 0) startIndex = 0;

			for (int idx = startIndex; idx < kills.Count; idx++)
			{
				retVal.Add(string.Format(CultureInfo.InvariantCulture, "{0:hh:mm:ss} {1}{2}", kills[idx].TimeStamp, kills[idx].Message));
			}

			return retVal.ToArray();
		}

		private string[] GetConsoleLines(ConsoleMessagesCollection messages)
		{
			List<string> retVal = new List<string>();

			int startIndex = messages.Count - 100;
			if (startIndex < 0) startIndex = 0;

			for (int idx = startIndex; idx < messages.Count; idx++)
			{
				retVal.Add(string.Format(CultureInfo.InvariantCulture, "{0:hh:mm:ss} {1} - {2}: {3}{4}", messages[idx].TimeStamp, messages[idx].Source, messages[idx].Category, messages[idx].Message));
			}

			return retVal.ToArray();
		}

		private UserRights GetUserInfo(Request request)
		{
			User retVal = null;
			
			User user = _config.Users.Find(item => item.Name.Equals(request.UserName));
			if (user.Password == request.Password) retVal = user;

			return retVal;
		}

		private void ProcessRequest(Request request, UserRights user)
		{
			if (user != null)
			{
				ServerController server = _servers.Find(item => item.ServerName.Equals(request.ServerName, StringComparison.OrdinalIgnoreCase));

				if (server != null)
				{
					if (request.Command.StartsWith("srv_", StringComparison.OrdinalIgnoreCase))
					{
						server.ProcessPlayerMessage(request.UserName, request.Command);
					}
					else if (user.FullAdmin || request.Command.StartsWith("say", StringComparison.OrdinalIgnoreCase))
					{
						if (request.Command.Equals("stop_server", StringComparison.OrdinalIgnoreCase))
						{
							if (server.GameRunning) server.Interface.StopProcess();
						}
						else if (request.Command.Equals("start_server", StringComparison.OrdinalIgnoreCase))
						{
							if (!server.GameRunning) server.StartServer();
						}
						else
						{
							if (server.GameRunning) server.Interface.SendCommand(request.Command);
						}
					}
				}
			}
		}

		private Player GetPlayer(ServerController server, string playerName)
		{
			return server.Players.Find(item => item.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
		}
	}
}
