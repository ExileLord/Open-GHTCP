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
	public class SghManager
	{
		private readonly Gh3Songlist _gh3SongList;

		public Gh3Setlist SetlistToExport;

		private readonly string _string0;

		private readonly string _saveLocation;

		public SghManager(Gh3Songlist gh3Songlist1, Gh3Setlist gh3Setlist1, string string2) : this(gh3Songlist1, gh3Setlist1, string2, null)
		{
		}

		public SghManager(Gh3Songlist gh3Songlist1, Gh3Setlist gh3Setlist1, string saveLocation, string string3)
		{
			_gh3SongList = gh3Songlist1;
			SetlistToExport = gh3Setlist1;
			_string0 = string3;
			this._saveLocation = saveLocation;
		}

		public void ImportSGH()
		{
			byte[] byte_;
			ZipManager.ExtractBytesFrom(_saveLocation, out byte_, "songs.info", "SGH9ZIP2PASS4MXKR");
			var @class = new ZzGenericNode1("songs", KeyGenerator.smethod_8(byte_, "SNG4AES4KEY9MXKR"));
			foreach (StructurePointerNode class302 in @class.Nodes)
			{
			    var gH3Song = new Gh3Song(class302) {Editable = true};
			    _gh3SongList.method_0(gH3Song, _string0 != null);
			}
			ZipManager.ExtractBytesFrom(_saveLocation, out byte_, "setlist.info", "SGH9ZIP2PASS4MXKR");
			SetlistToExport.method_1(new Gh3Setlist((StructureHeaderNode)new ZzGenericNode1("setlist", KeyGenerator.smethod_8(byte_, "SET4AES4KEY9MXKR")).Nodes[0], _gh3SongList));
		    if (_string0 == null) return;
		    var list = new List<string>();
		    var list2 = new List<string>();
		    foreach (var current in SetlistToExport.Tiers)
		    {
		        foreach (var current2 in current.Songs)
		        {
		            if (!current2.Editable) continue;
		            list.Add(current2.Name + "_song.pak.xen");
		            list2.Add(_string0 + "songs\\" + current2.Name + "_song.pak.xen");
		            list.Add(current2.Name + ".dat.xen");
		            list2.Add(_string0 + "music\\" + current2.Name + ".dat.xen");
		            list.Add(current2.Name + ".fsb.xen");
		            list2.Add(_string0 + "music\\" + current2.Name + ".fsb.xen");
		        }
		    }
		    ZipManager.smethod_11(_saveLocation, list2, list, "SGH9ZIP2PASS4MXKR");
		}

		public void method_1()
		{
			var fileStreamList = new List<Stream>();
			Stream stream = new MemoryStream();
			KeyGenerator.smethod_1(new ZzGenericNode1("setlist", SetlistToExport.method_6()).method_8(), stream, "SET4AES4KEY9MXKR");
			var fileNameList = new List<string>();
			var list3 = new List<StructurePointerNode>();
			foreach (var current in SetlistToExport.Tiers)
			{
				foreach (var current2 in current.Songs)
				{
					if (current2.Editable)
					{
						list3.Add(current2.vmethod_5());
						if (_string0 != null && File.Exists(_string0 + "songs\\" + current2.Name + "_song.pak.xen") && File.Exists(_string0 + "music\\" + current2.Name + ".dat.xen") && File.Exists(_string0 + "music\\" + current2.Name + ".fsb.xen"))
						{
							fileNameList.Add(current2.Name + "_song.pak.xen");
							fileStreamList.Add(File.OpenRead(_string0 + "songs\\" + current2.Name + "_song.pak.xen"));
							fileNameList.Add(current2.Name + ".dat.xen");
							fileStreamList.Add(File.OpenRead(_string0 + "music\\" + current2.Name + ".dat.xen"));
							fileNameList.Add(current2.Name + ".fsb.xen");
							fileStreamList.Add(File.OpenRead(_string0 + "music\\" + current2.Name + ".fsb.xen"));
						}
					}
				}
			}
			Stream stream2 = new MemoryStream();
			KeyGenerator.smethod_1(new ZzGenericNode1("songs", list3.ToArray()).method_8(), stream2, "SNG4AES4KEY9MXKR");
			fileNameList.Add("setlist.info");
			fileStreamList.Add(stream);
			fileNameList.Add("songs.info");
			fileStreamList.Add(stream2);
			ZipManager.smethod_0(fileNameList, _saveLocation, "SGH9ZIP2PASS4MXKR", fileStreamList.ToArray());
		}
	}
}
