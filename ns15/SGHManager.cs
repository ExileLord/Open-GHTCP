using System.Collections.Generic;
using System.IO;
using GuitarHero.Setlist;
using GuitarHero.Songlist;
using GuitarHero.Tier;
using ns13;
using ns16;
using ns20;
using ns21;

namespace ns15
{
	public class SGHManager
	{
		private GH3Songlist gh3SongList;

		public GH3Setlist setlistToExport;

		private string string_0;

		private string saveLocation;

		public SGHManager(GH3Songlist gh3Songlist_1, GH3Setlist gh3Setlist_1, string string_2) : this(gh3Songlist_1, gh3Setlist_1, string_2, null)
		{
		}

		public SGHManager(GH3Songlist gh3Songlist_1, GH3Setlist gh3Setlist_1, string saveLocation, string string_3)
		{
			gh3SongList = gh3Songlist_1;
			setlistToExport = gh3Setlist_1;
			string_0 = string_3;
			this.saveLocation = saveLocation;
		}

		public void method_0()
		{
			byte[] byte_;
			ZIPManager.smethod_3(saveLocation, out byte_, "songs.info", "SGH9ZIP2PASS4MXKR");
			zzGenericNode1 @class = new zzGenericNode1("songs", KeyGenerator.smethod_8(byte_, "SNG4AES4KEY9MXKR"));
			foreach (StructurePointerNode class302_ in @class.Nodes)
			{
				GH3Song gH3Song = new GH3Song(class302_);
				gH3Song.editable = true;
				gh3SongList.method_0(gH3Song, string_0 != null);
			}
			ZIPManager.smethod_3(saveLocation, out byte_, "setlist.info", "SGH9ZIP2PASS4MXKR");
			setlistToExport.method_1(new GH3Setlist((StructureHeaderNode)new zzGenericNode1("setlist", KeyGenerator.smethod_8(byte_, "SET4AES4KEY9MXKR")).Nodes[0], gh3SongList));
			if (string_0 != null)
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				foreach (GH3Tier current in setlistToExport.tiers)
				{
					foreach (GH3Song current2 in current.songs)
					{
						if (current2.editable)
						{
							list.Add(current2.name + "_song.pak.xen");
							list2.Add(string_0 + "songs\\" + current2.name + "_song.pak.xen");
							list.Add(current2.name + ".dat.xen");
							list2.Add(string_0 + "music\\" + current2.name + ".dat.xen");
							list.Add(current2.name + ".fsb.xen");
							list2.Add(string_0 + "music\\" + current2.name + ".fsb.xen");
						}
					}
				}
				ZIPManager.smethod_11(saveLocation, list2, list, "SGH9ZIP2PASS4MXKR");
			}
		}

		public void method_1()
		{
			List<Stream> fileStreamList = new List<Stream>();
			Stream stream = new MemoryStream();
			KeyGenerator.smethod_1(new zzGenericNode1("setlist", setlistToExport.method_6()).method_8(), stream, "SET4AES4KEY9MXKR");
			List<string> fileNameList = new List<string>();
			List<StructurePointerNode> list3 = new List<StructurePointerNode>();
			foreach (GH3Tier current in setlistToExport.tiers)
			{
				foreach (GH3Song current2 in current.songs)
				{
					if (current2.editable)
					{
						list3.Add(current2.vmethod_5());
						if (string_0 != null && File.Exists(string_0 + "songs\\" + current2.name + "_song.pak.xen") && File.Exists(string_0 + "music\\" + current2.name + ".dat.xen") && File.Exists(string_0 + "music\\" + current2.name + ".fsb.xen"))
						{
							fileNameList.Add(current2.name + "_song.pak.xen");
							fileStreamList.Add(File.OpenRead(string_0 + "songs\\" + current2.name + "_song.pak.xen"));
							fileNameList.Add(current2.name + ".dat.xen");
							fileStreamList.Add(File.OpenRead(string_0 + "music\\" + current2.name + ".dat.xen"));
							fileNameList.Add(current2.name + ".fsb.xen");
							fileStreamList.Add(File.OpenRead(string_0 + "music\\" + current2.name + ".fsb.xen"));
						}
					}
				}
			}
			Stream stream2 = new MemoryStream();
			KeyGenerator.smethod_1(new zzGenericNode1("songs", list3.ToArray()).method_8(), stream2, "SNG4AES4KEY9MXKR");
			fileNameList.Add("setlist.info");
			fileStreamList.Add(stream);
			fileNameList.Add("songs.info");
			fileStreamList.Add(stream2);
			ZIPManager.smethod_0(fileNameList, saveLocation, "SGH9ZIP2PASS4MXKR", fileStreamList.ToArray());
		}
	}
}
