using System.Collections.Generic;
using System.IO;
using GuitarHero.Songlist;
using GuitarHero.Tier;
using ns13;
using ns16;
using ns20;
using ns21;

namespace ns17
{
	public class TghManager
	{
		private readonly Gh3Songlist _gh3Songlist0;

		public Gh3Tier Gh3Tier0;

		private readonly string _string0;

		private readonly string _string1;

		public TghManager(Gh3Songlist gh3Songlist1, Gh3Tier gh3Tier1, string string2) : this(gh3Songlist1, gh3Tier1, string2, null)
		{
		}

		public TghManager(Gh3Songlist gh3Songlist1, Gh3Tier gh3Tier1, string string2, string string3)
		{
			_gh3Songlist0 = gh3Songlist1;
			Gh3Tier0 = gh3Tier1;
			_string0 = string3;
			_string1 = string2;
		}

		public void method_0()
		{
			byte[] byte_;
			ZipManager.ExtractBytesFrom(_string1, out byte_, "songs.info", "TGH9ZIP2PASS4MXKR");
			var @class = new ZzGenericNode1("songs", KeyGenerator.smethod_8(byte_, "SNG4AES4KEY9MXKR"));
			foreach (StructurePointerNode class302 in @class.Nodes)
			{
				var gH3Song = new Gh3Song(class302);
				gH3Song.Editable = true;
				_gh3Songlist0.method_0(gH3Song, _string0 != null);
			}
			ZipManager.ExtractBytesFrom(_string1, out byte_, "tier.info", "TGH9ZIP2PASS4MXKR");
			Gh3Tier0.method_1(new Gh3Tier((StructureHeaderNode)new ZzGenericNode1("tier", KeyGenerator.smethod_8(byte_, "TIR4AES4KEY9MXKR")).Nodes[0], _gh3Songlist0));
			if (_string0 != null)
			{
				var list = new List<string>();
				var list2 = new List<string>();
				foreach (var current in Gh3Tier0.Songs)
				{
					if (current.Editable)
					{
						list.Add(current.Name + "_song.pak.xen");
						list2.Add(_string0 + "songs\\" + current.Name + "_song.pak.xen");
						list.Add(current.Name + ".dat.xen");
						list2.Add(_string0 + "music\\" + current.Name + ".dat.xen");
						list.Add(current.Name + ".fsb.xen");
						list2.Add(_string0 + "music\\" + current.Name + ".fsb.xen");
					}
				}
				ZipManager.smethod_11(_string1, list2, list, "TGH9ZIP2PASS4MXKR");
			}
		}

		public void method_1()
		{
			var list = new List<Stream>();
			Stream stream = new MemoryStream();
			KeyGenerator.smethod_1(new ZzGenericNode1("tier", Gh3Tier0.method_3()).method_8(), stream, "TIR4AES4KEY9MXKR");
			var list2 = new List<string>();
			var list3 = new List<StructurePointerNode>();
			foreach (var current in Gh3Tier0.Songs)
			{
				if (current.Editable)
				{
					list3.Add(current.vmethod_5());
					if (_string0 != null && File.Exists(_string0 + "songs\\" + current.Name + "_song.pak.xen") && File.Exists(_string0 + "music\\" + current.Name + ".dat.xen") && File.Exists(_string0 + "music\\" + current.Name + ".fsb.xen"))
					{
						list2.Add(current.Name + "_song.pak.xen");
						list.Add(File.OpenRead(_string0 + "songs\\" + current.Name + "_song.pak.xen"));
						list2.Add(current.Name + ".dat.xen");
						list.Add(File.OpenRead(_string0 + "music\\" + current.Name + ".dat.xen"));
						list2.Add(current.Name + ".fsb.xen");
						list.Add(File.OpenRead(_string0 + "music\\" + current.Name + ".fsb.xen"));
					}
				}
			}
			Stream stream2 = new MemoryStream();
			KeyGenerator.smethod_1(new ZzGenericNode1("songs", list3.ToArray()).method_8(), stream2, "SNG4AES4KEY9MXKR");
			list2.Add("tier.info");
			list.Add(stream);
			list2.Add("songs.info");
			list.Add(stream2);
			ZipManager.smethod_0(list2, _string1, "TGH9ZIP2PASS4MXKR", list.ToArray());
		}
	}
}
