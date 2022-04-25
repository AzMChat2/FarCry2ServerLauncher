using System;
using Microsoft.ManagedSpy;
using System.Diagnostics;

namespace GSL
{
	public interface IServerInterface
	{
		event EventHandler ServerStarted;
		event EventHandler ServerStopped;

		Process ServerProcess { get; }

		void StartProcess();
		void ClickStartButton();
		void ClickStopButton();
		void SendCommand(string command);
		void SetWindowTitle(string addition);
		void Tell(string playerName, string message);
		void Say(string message);

		string[] GetConsoleMessages();
	}
}
