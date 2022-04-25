using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace GSL
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Thread.CurrentThread.Name = "Main";
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch (ObjectDisposedException) { } // This happens if the user shuts down the extender without stopping the servers first... 
			catch (Exception ex)
			{
				#region Message
				string msg = @"An unhandled exception occured in the Extender.
The Far Cry 2 Server may still be running, but all extended functionality has been stopped.
The Far Cry 2 Server will need to be shut down before restarting the Extender.

{0}";
				#endregion
				MessageBox.Show(string.Format(msg, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
				Trace.WriteLineIf(TS.Error, string.Format("Program.Main()\r\n{0}", ex), TS.Categories.Error);
			}
			finally
			{
				Trace.Flush();
				Trace.Close();
			}
		}
	}
}
