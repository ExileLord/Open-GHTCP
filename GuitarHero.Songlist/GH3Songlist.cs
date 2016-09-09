using GuitarHero.Setlist;
using GuitarHero.Tier;
using ns14;
using ns18;
using ns20;
using ns21;
using ns22;
using System;
using System.Collections.Generic;

namespace GuitarHero.Songlist
{
	[Serializable]
	public class GH3Songlist : SortedDictionary<string, GH3Song>
	{
		[NonSerialized]
		public Dictionary<int, GH3Setlist> gh3SetlistList = new Dictionary<int, GH3Setlist>();

		[NonSerialized]
		public Dictionary<int, GHLink> dictionary_1 = new Dictionary<int, GHLink>();

		[NonSerialized]
		public Class214<string, int> class214_0 = new Class214<string, int>();

		public int CustomBitMask;

		public bool HideUsed;

		public bool HideUnEditable;

		public static List<int> IgnoreSongs = new List<int>(new int[]
		{
			Class327.smethod_9("synctest"),
			Class327.smethod_9("mutetest"),
			Class327.smethod_9("synctestplaytoaudio"),
			Class327.smethod_9("synctestaudioandvisual"),
			Class327.smethod_9("tutorial_1b"),
			Class327.smethod_9("tutorial_1c"),
			Class327.smethod_9("tutorial_1d"),
			Class327.smethod_9("tutorial_1e"),
			Class327.smethod_9("tutorial_2a"),
			Class327.smethod_9("tutorial_2b"),
			Class327.smethod_9("tutorial_2c"),
			Class327.smethod_9("tutorial_3a"),
			Class327.smethod_9("tutorial_3b"),
			Class327.smethod_9("tutorial_3c"),
			Class327.smethod_9("tutorial_3d"),
			Class327.smethod_9("tutorial_4c"),
			Class327.smethod_9("tutorial_4e"),
			Class327.smethod_9("credits"),
			Class327.smethod_9("kingsandqueenscredits"),
			Class327.smethod_9("timrapptest")
		});

		public GH3Songlist(Class308 class308_0, GH3Songlist gh3Songlist_0)
		{
			this.method_12(class308_0, gh3Songlist_0);
		}

		public void Add(GH3Song gh3Song_0)
		{
			if (!base.ContainsKey(gh3Song_0.vmethod_3()))
			{
				base.Add(gh3Song_0.vmethod_3(), gh3Song_0);
				Class327.smethod_9(gh3Song_0.vmethod_3());
			}
		}

		public void method_0(GH3Song gh3Song_0, bool bool_0)
		{
			if (!base.ContainsKey(gh3Song_0.vmethod_3()))
			{
				base.Add(gh3Song_0.vmethod_3(), gh3Song_0);
				Class327.smethod_9(gh3Song_0.vmethod_3());
				return;
			}
			if (base[gh3Song_0.vmethod_3()].vmethod_1() && bool_0)
			{
				base[gh3Song_0.vmethod_3()].vmethod_0(gh3Song_0);
			}
		}

		public List<int> method_1(GH3Song gh3Song_0)
		{
			List<int> list = new List<int>();
			foreach (int current in this.gh3SetlistList.Keys)
			{
				foreach (GH3Tier current2 in this.gh3SetlistList[current].method_0())
				{
					if (current2.method_0().Contains(gh3Song_0))
					{
						current2.method_0().Remove(gh3Song_0);
						if (!list.Contains(current))
						{
							list.Add(current);
						}
					}
				}
			}
			base.Remove(gh3Song_0.vmethod_3());
			return list;
		}

		public GH3Song[] getSongs()
		{
			List<GH3Song> songList = new List<GH3Song>(base.Values);
			if (songList.Count != 0)
			{
				if (this.HideUsed)
				{
					foreach (GH3Setlist current in this.gh3SetlistList.Values)
					{
						foreach (GH3Tier current2 in current.method_0())
						{
							foreach (GH3Song current3 in current2.method_0())
							{
								if (songList.Contains(current3))
								{
									songList.Remove(current3);
								}
							}
						}
					}
				}
				if (this.HideUnEditable)
				{
					foreach (GH3Song current4 in base.Values)
					{
						if (!current4.vmethod_1())
						{
							songList.Remove(current4);
						}
					}
				}
				foreach (GH3Song current5 in base.Values)
				{
					if (!current5.method_0())
					{
						songList.Remove(current5);
					}
				}
			}
			return songList.ToArray();
		}

		public bool method_3(string string_0)
		{
			return base.ContainsKey(string_0);
		}

		public GH3Setlist method_4(string string_0, Class266 class266_0)
		{
			GH3Setlist gH3Setlist = new GH3Setlist(class266_0.method_7(), this);
			gH3Setlist.method_3(string_0);
			this.gh3SetlistList.Add(class266_0.int_0, gH3Setlist);
			return gH3Setlist;
		}

		public GHLink method_5(string string_0, Class266 class266_0)
		{
			GHLink gHLink = new GHLink(string_0, class266_0.method_7());
			this.dictionary_1.Add(class266_0.int_0, gHLink);
			return gHLink;
		}

		public void method_6(Class292 class292_0)
		{
			foreach (Class286 @class in class292_0.Nodes)
			{
				int num = @class.method_5<Class296>(new Class296("tag")).method_10();
				if (this.dictionary_1.ContainsKey(num))
				{
					this.class214_0.Add(@class.method_5<Class307>(new Class307("text")).method_8(), num);
				}
			}
		}

		public Class292 method_7()
		{
			Class292 @class = new Class292();
			foreach (string current in this.class214_0.Keys)
			{
				@class.method_3(new Class286(new List<Class294>
				{
					new Class296("tag", this.class214_0[current]),
					new Class307("text", current)
				}));
			}
			return @class;
		}

		public string method_8(int int_0)
		{
			foreach (int current in this.dictionary_1.Keys)
			{
				if (this.dictionary_1[current].setlist == int_0)
				{
					return this.class214_0.method_0(current);
				}
			}
			return "No Name";
		}

		public int method_9(string string_0)
		{
			return this.dictionary_1[this.class214_0[string_0]].setlist;
		}

		public int method_10(int int_0)
		{
			return this.dictionary_1[int_0].setlist;
		}

		public GH3Setlist method_11(int int_0)
		{
			return this.gh3SetlistList[this.dictionary_1[int_0].setlist];
		}

		public void method_12(Class308 class308_0, GH3Songlist gh3Songlist_0)
		{
			Class286 @class = class308_0.method_5<Class266>(new Class266("permanent_songlist_props")).method_7();
			bool flag = class308_0.method_5<Class296>(new Class296("band")) != null;
			base.Clear();
			foreach (Class302 class2 in @class.Nodes)
			{
				GH3Song gH3Song = flag ? new GHASong(class2) : new GH3Song(class2);
				if (gh3Songlist_0 != null)
				{
					gH3Song.vmethod_2(!gh3Songlist_0.method_3(gH3Song.vmethod_3()));
				}
				gH3Song.method_1(!GH3Songlist.IgnoreSongs.Contains(class2.int_0));
				this.Add(gH3Song);
			}
		}

		public void method_13(Class308 class308_0)
		{
			List<int> list = new List<int>();
			List<Class294> list2 = new List<Class294>();
			foreach (string current in base.Keys)
			{
				list.Add(Class327.smethod_9(current));
				list2.Add(base[current].vmethod_5());
			}
			((Class281)class308_0.method_5<Class267>(new Class267("gh3_songlist")).method_7()).method_12(list);
			class308_0.method_5<Class266>(new Class266("permanent_songlist_props")).method_7().method_9(list2);
		}
	}
}
