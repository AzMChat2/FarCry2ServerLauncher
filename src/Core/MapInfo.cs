using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace GSL
{

	#region MapInfo
	[XmlType("Map")]
	public sealed class MapInfo
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public string Author { get; set; }
		[XmlAttribute]
		public string Creator { get; set; }
		[XmlAttribute]
		public string FileName { get; set; }
		[XmlAttribute]
		public string Category { get; set; }
		[XmlAttribute]
		public MapSizes MapSize { get; set; }
		[XmlAttribute]
		public MapTypes MapType { get; set; }
		[XmlAttribute]
		public MapGameModes MapGameMode { get; set; }
		[XmlAttribute]
		public int Order { get; set; }

		[XmlIgnore]
		public string GameModes
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if ((MapGameMode & MapGameModes.DM) != 0) sb.Append("DM ");
				if ((MapGameMode & MapGameModes.TDM) != 0) sb.Append("TDM ");
				if ((MapGameMode & MapGameModes.CTD) != 0) sb.Append("CTD ");
				if ((MapGameMode & MapGameModes.UP) != 0) sb.Append("Uprising");

				return sb.ToString();
			}
		}

		[XmlIgnore]
		public Image Screenshot { get; set; }
		[XmlIgnore]
		public bool Include { get; set; }

	}
	#endregion

	#region Collection
	public sealed class MapInfoCollection : ListEx<MapInfo>
	{
		public MapInfoCollection() : base() { }
		public MapInfoCollection(IEnumerable<MapInfo> collection) : base(collection) { }

		private static MapInfoCollection _availableMaps;
		public static MapInfoCollection AvailableMaps
		{
			get
			{
				if (_availableMaps == null)
				{
					_availableMaps = MapInfoLoader.GetMaps();
				}
				return _availableMaps;
			}
		}

		public static void RefreshAvailableMaps()
		{
			_availableMaps = MapInfoLoader.GetMaps();
		}

		public MapInfoCollection GetMaps(MapTypes mapType, MapGameModes gameMode)
		{
			return new MapInfoCollection(FindAll(item => ((item.MapType & mapType) != 0) && ((item.MapGameMode & gameMode) != 0)));
		}

		public string GetRotationDisplay()
		{
			StringBuilder retVal = new StringBuilder();

			ForEach(item => retVal.AppendFormat("{0}; ", item.Name));
			if (retVal.Length > 2) retVal.Remove(retVal.Length - 2, 2);

			return retVal.ToString();
		}

		public string GetRotationSetting()
		{
			string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Games\Far Cry 2\";
			StringBuilder retVal = new StringBuilder();

			ForEach(item => retVal.AppendFormat("{0};", item.FileName.Replace(baseDirectory, string.Empty)));

			if (retVal.Length > 1) retVal.Remove(retVal.Length - 1, 1);

			return retVal.ToString();
		}

		public MapInfoCollection GetSortedList()
		{
			_maxKey = 1000;
			SortedList<int, MapInfo> sorter = new SortedList<int, MapInfo>();
			ForEach(item => AddToSorter(sorter, item));

			MapInfoCollection retVal = new MapInfoCollection();
			for (int idx = 0; idx < sorter.Count; idx++)
			{
				MapInfo item = sorter.Values[idx];
				item.Order = idx + 1;
				retVal.Add(item);
			}
			return retVal;
		}

		private int _maxKey;
		private void AddToSorter(SortedList<int, MapInfo> sorter, MapInfo item)
		{
			if (item.Include)
			{
				if (sorter.ContainsKey(item.Order)) item.Order = _maxKey++;
				sorter.Add(item.Order, item);
			}
		}
	}
	#endregion

	#region Loader
	internal static class MapInfoLoader
	{
		private static char[] NullChar = new char[1];
		private static string RootMapDirectory;

		internal static MapInfoCollection GetMaps()
		{
			try
			{
				MapInfoCollection retVal = LoadOriginalMaps();

				RootMapDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\My Games\Far Cry 2\User Maps\";
				Utilities.CheckDirectoryExists(RootMapDirectory);
				LoadMapsFromDirectory(retVal, RootMapDirectory);

				return retVal;
			}
			catch (IOException ex)
			{
				Trace.WriteLineIf(TS.Error, string.Format(CultureInfo.CurrentCulture, "Error loading custom maps.\r\n{0}", ex), TS.Categories.Error);
				return null;
			}
		}

		private static MapInfoCollection LoadOriginalMaps()
		{
			MapInfoCollection retVal = null;

			XmlSerializer serializer = new XmlSerializer(typeof(MapInfoCollection));

			using (Stream stream = Utilities.GetResourceStream("\\XmlResources\\OriginalMaps.xml")) 
			{
				retVal = (MapInfoCollection)serializer.Deserialize(stream);
				stream.Close();
			}

			retVal.ForEach(item => LoadOriginalMapImage(item));
			return retVal;
		}

		private static void LoadOriginalMapImage(MapInfo item)
		{
			string resourceName = string.Format("\\ImageResources\\{0}.png", item.Name.Replace("'", string.Empty).Replace(" ", string.Empty));
			using (Stream stream = Utilities.GetResourceStream(resourceName))
			{
				item.Screenshot = Image.FromStream(stream);
				stream.Close();
			}
		}

		private static void LoadMapsFromDirectory(MapInfoCollection list, string directoryName)
		{
			string[] files = Directory.GetFiles(directoryName, "*.fc2map");
			string category = directoryName.Replace(RootMapDirectory, string.Empty).Replace("\\", ".");
			if (string.IsNullOrEmpty(category)) category = "User Maps";

			foreach (string filename in files)
			{
				MapInfo item = GetMapInfo(filename, category);
				if (item != null) list.Add(item);
			}

			string[] directories = Directory.GetDirectories(directoryName);
			foreach (string directory in directories)
			{
				LoadMapsFromDirectory(list, directory);
			}
		}

		private static MapInfo GetMapInfo(string mapFileName, string category)
		{
			MapInfo retVal = new MapInfo();
			retVal.Category = category;
			retVal.MapType = MapTypes.Custom;
			retVal.FileName = mapFileName;

			try
			{
				using (FileStream stream = File.OpenRead(mapFileName))
				{
					ReadAhead(stream, 28);
					retVal.Creator = ReadString(stream);
					ReadAhead(stream, 8);
					retVal.Author = ReadString(stream);
					retVal.Name = ReadString(stream);
					//retVal.ID = ReadInt64(stream);
					//ReadAhead(stream, 72);
					ReadAhead(stream, 80);
					retVal.MapSize = (MapSizes)ReadInt32(stream);
					ReadAhead(stream, 4);
					retVal.MapGameMode = (MapGameModes)ReadInt32(stream);
					retVal.Screenshot = ReadImage(stream);

					stream.Close();
				}
			}
			catch (IOException ex)
			{
				retVal = null;
				string msg = string.Format(CultureInfo.CurrentCulture, "Error reading map file '{0}'.\r\n{1}", mapFileName, ex.Message);
				Trace.WriteLineIf(TS.Error, msg, TS.Categories.Error);
			}

			return retVal;
		}

		private static string ReadString(Stream stream)
		{
			int strLen = ReadInt32(stream);
			byte[] buffer = new byte[strLen];
			stream.Read(buffer, 0, strLen);

			string retVal = Encoding.UTF8.GetString(buffer);
			return retVal.TrimEnd(NullChar);
		}

		private static int ReadInt32(Stream stream)
		{
			byte[] buffer = new byte[4];
			stream.Read(buffer, 0, 4);
			return BitConverter.ToInt32(buffer, 0);
		}

		private static long ReadInt64(Stream stream)
		{
			byte[] buffer = new byte[8];
			stream.Read(buffer, 0, 8);
			return BitConverter.ToInt64(buffer, 0);
		}

		private static Image ReadImage(Stream stream)
		{
			Image retVal = null;

			int width = ReadInt32(stream);
			int height = ReadInt32(stream);
			int num3 = ReadInt32(stream);
			int num4 = ReadInt32(stream);

			int count = (((width * height) * num3) * num4) / 8;

			if (count > 0)
			{
				byte[] buffer = new byte[count];
				stream.Read(buffer, 0, count);
				Bitmap bitmap = new Bitmap(width, height);
				BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
				Marshal.Copy(buffer, 0, bitmapdata.Scan0, count);
				bitmap.UnlockBits(bitmapdata);
				retVal = bitmap;
			}

			return retVal;
		}

		private static void ReadAhead(Stream stream, long count)
		{
			stream.Seek(count, SeekOrigin.Current);
		}
	}
	#endregion
}

