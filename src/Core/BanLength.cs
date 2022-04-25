using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GSL
{
	[Serializable]
	public sealed class BanLength
	{
		[XmlAttribute]
		public int BanNumber { get; set; }
		[XmlAttribute]
		public int Value { get; set; }
		[XmlAttribute]
		public string Type { get; set; }

		[XmlIgnore]
		public TimeSpan Length
		{
			get
			{
				int totalDays = 0;
				switch (Type.ToLowerInvariant())
				{
					case "hours":
						return new TimeSpan(Value, 0, 0);
					case "max":
						totalDays = 36500;
						break;
					case "days":
						totalDays = Value;
						break;
					case "weeks":
						totalDays = 7 * Value;
						break;
					case "months":
						totalDays = 30 * Value;
						break;
					case "years":
						totalDays = 365 * Value;
						break;
				}

				return new TimeSpan(totalDays, 0, 0, 0);
			}
		}
	}

	public sealed class BanLengthCollection : List<BanLength>
	{
		public BanLength GetBanLength(int banCount)
		{
			BanLength retVal = null;

			List<BanLength> list = FindAll(item => item.BanNumber <= banCount);
			if (list.Count == 0)
			{
				retVal = new BanLength();
				retVal.Type = "Hours";
			}
			else
			{
				list.Sort(BanLengthSort);
				retVal = list[0];
			}

			return retVal;
		}

		private int BanLengthSort(BanLength x, BanLength y)
		{
			return y.BanNumber - x.BanNumber;
		}
	}

}
