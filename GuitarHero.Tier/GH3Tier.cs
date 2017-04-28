using System;
using System.Collections.Generic;
using GuitarHero.Songlist;
using ns18;
using ns19;
using ns20;
using ns21;

namespace GuitarHero.Tier
{
	[Serializable]
	public class GH3Tier
	{
		public string title = "";

		public string completion_movie = "";

		public string level = "No Preset Stage";

		public string setlist_icon = "No Icon";

		public List<GH3Song> songs = new List<GH3Song>();

		public int defaultunlocked;

		public bool encorep1;

		public bool encorep2;

		public bool aerosmith_encore_p1;

		public bool boss;

		public bool nocash;

		public bool unlockall;

		public GH3Tier()
		{
		}

		public GH3Tier(StructureHeaderNode class286_0, GH3Songlist gh3Songlist_0)
		{
			method_2(class286_0, gh3Songlist_0);
		}

		public List<GH3Song> method_0()
		{
			return songs;
		}

		public void method_1(GH3Tier gh3Tier_0)
		{
			title = gh3Tier_0.title;
			completion_movie = gh3Tier_0.completion_movie;
			level = gh3Tier_0.level;
			setlist_icon = gh3Tier_0.setlist_icon;
			songs = gh3Tier_0.songs;
			defaultunlocked = gh3Tier_0.defaultunlocked;
			encorep1 = gh3Tier_0.encorep1;
			encorep2 = gh3Tier_0.encorep2;
			aerosmith_encore_p1 = gh3Tier_0.aerosmith_encore_p1;
			boss = gh3Tier_0.boss;
			nocash = gh3Tier_0.nocash;
			unlockall = gh3Tier_0.unlockall;
		}

		public override string ToString()
		{
			return title ?? "[No Title]";
		}

		public void method_2(StructureHeaderNode class286_0, GH3Songlist gh3Songlist_0)
		{
			UnicodeStructureNode @class;
			title = (((@class = class286_0.method_5(new UnicodeStructureNode("title"))) != null) ? @class.method_8() : "");
			AsciiStructureNode class2;
			completion_movie = (((class2 = class286_0.method_5(new AsciiStructureNode("completion_movie"))) != null) ? class2.method_8() : "");
			IntegerStructureNode class3;
			defaultunlocked = (((class3 = class286_0.method_5(new IntegerStructureNode("defaultunlocked"))) != null) ? class3.method_8() : 0);
			TagStructureNode class4;
			level = (((class4 = class286_0.method_5(new TagStructureNode("level"))) != null) ? class4.method_8() : "No Preset Stage");
			setlist_icon = (((class4 = class286_0.method_5(new TagStructureNode("setlist_icon"))) != null) ? class4.method_8() : "No Icon");
			encorep1 = (class286_0.method_5(new TagStructureNode(0, "encorep1")) != null);
			encorep2 = (class286_0.method_5(new TagStructureNode(0, "encorep2")) != null);
			aerosmith_encore_p1 = (class286_0.method_5(new TagStructureNode(0, "aerosmith_encore_p1")) != null);
			boss = (class286_0.method_5(new TagStructureNode(0, "boss")) != null);
			nocash = (class286_0.method_5(new TagStructureNode(0, "nocash")) != null);
			unlockall = (class286_0.method_5(new TagStructureNode(0, "unlockall")) != null);
			ArrayPointerNode class5 = new ArrayPointerNode("songs");
			if (class286_0.method_6(ref class5) && !(class5.method_8() is FloatListNode))
			{
				foreach (string current in class5.method_8().method_8<string>())
				{
					if (gh3Songlist_0.ContainsKey(current))
					{
						songs.Add(gh3Songlist_0[current]);
					}
					else
					{
						Console.WriteLine("Song (" + current + ") skipped: does not exist in the songlist.");
					}
				}
			}
		}

		public StructureHeaderNode method_3()
		{
			StructureHeaderNode @class = new StructureHeaderNode();
			@class.method_3(new UnicodeStructureNode("title", title));
			if (songs.Count == 0)
			{
				@class.method_3(new ArrayPointerNode("songs", new FloatListNode(true)));
			}
			else
			{
				List<int> list = new List<int>();
				foreach (GH3Song current in songs)
				{
					list.Add(QbSongClass1.AddKeyToDictionary(current.name));
				}
				@class.method_3(new ArrayPointerNode("songs", new TagArray(list)));
			}
			if (boss)
			{
				@class.method_3(new TagStructureNode(0, "boss"));
			}
			if (encorep1)
			{
				@class.method_3(new TagStructureNode(0, "encorep1"));
			}
			if (encorep2)
			{
				@class.method_3(new TagStructureNode(0, "encorep2"));
			}
			if (aerosmith_encore_p1)
			{
				@class.method_3(new TagStructureNode(0, "aerosmith_encore_p1"));
			}
			if (level != null && level != "No Preset Stage")
			{
				@class.method_3(new TagStructureNode("level", level));
			}
			if (defaultunlocked != 0)
			{
				@class.method_3(new IntegerStructureNode("defaultunlocked", defaultunlocked));
			}
			if (!completion_movie.Equals(""))
			{
				@class.method_3(new AsciiStructureNode("completion_movie", completion_movie));
			}
			if (!setlist_icon.Equals("No Icon"))
			{
				@class.method_3(new TagStructureNode("setlist_icon", setlist_icon));
			}
			if (nocash)
			{
				@class.method_3(new TagStructureNode(0, "nocash"));
			}
			if (unlockall)
			{
				@class.method_3(new TagStructureNode(0, "unlockall"));
			}
			return @class;
		}
	}
}
