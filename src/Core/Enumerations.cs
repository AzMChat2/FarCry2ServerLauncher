using System;

namespace GSL
{
	public enum Teams
	{
		None,
		APR,
		UFLL
	}

	public enum ServerModes
	{
		Lan,
		Online,
		Ranked
	}

	public enum GameModes
	{
		Deathmatch,
		TeamDeathmatch,
		Ctf,
		Uprising
	}

	[Flags]
	public enum MapTypes
	{
		Original = 1,
		Custom = 2,
		All = Original | Custom
	}

	[Flags]
	public enum MapGameModes
	{
		DM = 1,
		TDM = 2,
		CTD = 4,
		UP = 8,
		All = DM | TDM | CTD | UP
	}

	public enum MapSizes
	{
		Small,
		Medium,
		Large
	}

	[Flags]
	public enum MessageCategories
	{
		None = 0,
		Game = 1,
		Chat = 2,
		Kill = 4,
		Error = 8,
		Warning = 16,
		Event = 32,
		Info = 64,
		All = Game | Chat | Kill | Error | Warning | Event | Info
	}

	public enum ServerStates
	{
		Not_Started,
		Started,
		In_Lobby,
		Pre_Match_Waiting,
		In_Match,
		Post_Match_Waiting,
		Stopped,
		Dead
	}

	[Flags]
	public enum ConsoleSources
	{
		None = 0,
		GameServer = 1,
		Extender = 2,
		All = GameServer | Extender
	}
}
