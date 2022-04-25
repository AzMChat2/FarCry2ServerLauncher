using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FC2.SL.Remote
{
	public class Request
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Command { get; set; }
		public string ServerName { get; set; }
	}
}
