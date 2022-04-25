using System;
using System.IO;
using System.Reflection;
using System.Net;
using System.Text.RegularExpressions;

namespace GSL
{
	public static class Utilities
	{
		public static void CheckDirectoryExists(string directory)
		{
			int idx = directory.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase);
			if (idx != -1)
			{
				string path = directory.Substring(0, idx);
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
		}

		private static string _localPath;
		public static string LocalPath
		{
			get
			{
				if (_localPath == null) _localPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				return _localPath;
			}
		}

		public static Stream GetResourceStream(string resourceName)
		{
			string fileName =  IOUtilities.CombinePath(LocalPath, resourceName);
			return File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		public static void ClearFile(string filename)
		{
			if (File.Exists(filename)) File.Delete(filename);
		}

		private static Regex ipAddressRegex = new Regex(@"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?", RegexOptions.Compiled);

		public static IPAddress GetPublicIPAddress()
		{
			IPAddress retVal = IPAddress.None;

			using (WebClient client = new WebClient())
			{
				string ipAddress = client.DownloadString("http://checkip.dyndns.org/");
				Match match = ipAddressRegex.Match(ipAddress);
				if (match.Success)
				{
					retVal = IPAddress.Parse(match.Value);
				}
			}

			return retVal;
		}
	}
}
