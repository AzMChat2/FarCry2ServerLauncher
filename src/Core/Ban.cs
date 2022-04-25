using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace GSL
{
	[Serializable]
	public sealed class Ban
	{
		[XmlAttribute]
		public string PlayerName { get; set; }
		[XmlAttribute]
		public string Reason { get; set; }
		[XmlAttribute]
		public DateTime ExpiresOn { get; set; }
		[XmlAttribute]
		public DateTime RemoveOn { get; set; }
	}

	[Serializable]
	public sealed class BanCollection : ListEx<Ban>
	{
		private static DateTime _lastModified;
		private static BanCollection _current;
		public static BanCollection Current
		{
			get
			{
				if (_current == null)
				{
					_current = Load();
					if (_current == null)
					{
						// File doesn't exist, create a new collection and then save it.
						_current = new BanCollection();
						Save(_current);
					}
				}
				else
				{
					CheckCurrent();
				}
				return _current;
			}
		}

		private static void CheckCurrent()
		{
			if (File.Exists(Settings.Values.BannedPlayerFile))
			{
				FileInfo info = new FileInfo(Settings.Values.BannedPlayerFile);
				if (info.LastWriteTime > _lastModified)
				{
					BanCollection newList = Load();
					if (newList == null)
					{
						// Banned player list is corrupt...
						Save(_current);
					}
					else
					{
						_current = newList;
						_lastModified = info.LastWriteTime;
					}
				}
			}
			else if (_current != null)
			{
				Save(_current);
			}
		}

		private static XmlSerializer _serializer = new XmlSerializer(typeof(BanCollection));

		public static void Save(BanCollection collection)
		{
			try
			{
				Utilities.CheckDirectoryExists(Settings.Values.BannedPlayerFile);

				using (Stream stream = File.Open(Settings.Values.BannedPlayerFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
				{
					_serializer.Serialize(stream, collection);
					stream.Close();
				}

				if (collection != _current) _current = collection; // If saving from Banned Player Form.

				_lastModified = DateTime.Now;
				FileInfo info = new FileInfo(Settings.Values.BannedPlayerFile);
				info.LastWriteTime = _lastModified;
			}
			catch (Exception ex)
			{
				Trace.WriteLineIf(TS.Error, "Error in OutputStats\r\n" + ex.ToString(), TS.Categories.Error);
			}
		}

		private static BanCollection Load()
		{
			BanCollection retVal = null;

			try
			{
				if (File.Exists(Settings.Values.BannedPlayerFile))
				{
					using (Stream stream = File.Open(Settings.Values.BannedPlayerFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						retVal = (BanCollection)_serializer.Deserialize(stream);
						stream.Close();
					}
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLineIf(TS.Error, "Error in OutputStats\r\n" + ex.ToString(), TS.Categories.Error);
			}

			return retVal;
		}

		public BanCollection() { }

		public override void Add(Ban item)
		{
			base.Add(item);
			if (this == _current)	Save(_current);
		}

		public override void AddRange(IEnumerable<Ban> collection)
		{
			base.AddRange(collection);
			if (this == _current) Save(_current);
		}

		[XmlIgnore]
		public Ban this[string playerName, DateTime date]
		{
			get
			{
				Ban retVal = null;

				List<Ban> list = FindAll(item => IsMatch(item, playerName, date));
				if (list.Count != 0)
				{
					list.Sort(BanSort);
					retVal = list[0];
				}

				return retVal;
			}
		}

		private int BanSort(Ban x, Ban y)
		{
			return Convert.ToInt32(y.ExpiresOn.Subtract(x.ExpiresOn).TotalDays);
		}


		public bool IsBanned(string playerName, DateTime date)
		{
			return Exists(item => IsMatch(item, playerName, date));
		}

		public int GetBanCount(string playerName)
		{
			return CountIf(item => item.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
		}

		public void RemoveOldBans(DateTime date)
		{
			RemoveAll(item => item.RemoveOn <= date);
		}

		private static bool IsMatch(Ban ban, string playerName, DateTime date)
		{
			return (ban.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase) && (ban.ExpiresOn > date));
		}
	}
}
