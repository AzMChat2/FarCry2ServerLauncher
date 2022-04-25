using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GSL
{
	[Serializable]
	public class Option
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public string Command { get; set; }
		[XmlAttribute]
		public string Value{ get; set; }
	}
}
