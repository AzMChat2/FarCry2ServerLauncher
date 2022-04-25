using System;
using System.Runtime.InteropServices;

namespace GSL
{
	internal static class Win32API
	{
		private const int SW_HIDE = 0;

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AttachConsole(int procId);

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeConsole();

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hwnd, int cmdShow);

		public static void HideConsoleWindow(int processId)
		{
			if (AttachConsole(processId))
			{
				IntPtr hWnd = GetConsoleWindow();
				ShowWindow(hWnd, SW_HIDE);
				FreeConsole();
			}
		}
	}
}
