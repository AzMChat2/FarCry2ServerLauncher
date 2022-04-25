using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GSL
{
	public sealed class ServerResources 
	{
		private static ServerResources _instance;
		public static ServerResources I
		{
			get
			{
				if (_instance == null)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(ServerResources));
					using (Stream stream = File.OpenRead(Settings.Values.ServerResourceFile))
					{
						_instance = (ServerResources)serializer.Deserialize(stream);
						stream.Close();
					}
				}
				return _instance;
			}
		}

		#region Commands
		[XmlElement]
		public string SkipMapCommand { get; set; }
		[XmlElement]
		public string ShuffleTeamsCommand { get; set; }
		[XmlElement]
		public string ExtendMatchCommand { get; set; }
		[XmlElement]
		public string EndMatchCommand { get; set; }
		[XmlElement]
		public string RestartMatchCommand { get; set; }
		[XmlElement]
		public string KickPlayerCommand { get; set; }
		[XmlElement]
		public string BanPlayerCommand { get; set; }
		[XmlElement]
		public string TellPlayerCommand { get; set; }
		[XmlElement]
		public string SayCommand { get; set; }
		[XmlElement]
		public string GetMapNameCommand { get; set; }
		[XmlElement]
		public string GetPlayerListCommand { get; set; }
		#endregion

		#region Messages
		[XmlElement]
		public string PlayerConnectedMessage { get; set; }
		[XmlElement]
		public string PlayerJoinedMatchMessage { get; set; }
		[XmlElement]
		public string PlayerDisconnectedMessage { get; set; }
		[XmlElement]
		public string PlayerKilledMessage { get; set; }
		[XmlElement]
		public string PlayerSuicideMessage { get; set; }
		[XmlElement]
		public string PlayerSaidMessage { get; set; }
		[XmlElement]
		public string EnteringLobbyMessage { get; set; }
		[XmlElement]
		public string LeavingLobbyMessage { get; set; }
		[XmlElement]
		public string MatchStartedMessage { get; set; }
		[XmlElement]
		public string MatchEndedMessage { get; set; }
		[XmlElement]
		public string GameMessage { get; set; }
		[XmlElement]
		public string CurrentMapMessage { get; set; }
		[XmlElement]
		public string TeamAPRMessage { get; set; }
		[XmlElement]
		public string TeamUFLLMessage { get; set; }
		[XmlElement]
		public string TeamOtherMessage { get; set; }
		#endregion

	}
}
