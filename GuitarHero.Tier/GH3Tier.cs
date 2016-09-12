using GuitarHero.Songlist;
using ns18;
using ns19;
using ns20;
using ns21;
using System;
using System.Collections.Generic;

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
			this.method_2(class286_0, gh3Songlist_0);
		}

		public List<GH3Song> method_0()
		{
			return this.songs;
		}

		public void method_1(GH3Tier gh3Tier_0)
		{
			this.title = gh3Tier_0.title;
			this.completion_movie = gh3Tier_0.completion_movie;
			this.level = gh3Tier_0.level;
			this.setlist_icon = gh3Tier_0.setlist_icon;
			this.songs = gh3Tier_0.songs;
			this.defaultunlocked = gh3Tier_0.defaultunlocked;
			this.encorep1 = gh3Tier_0.encorep1;
			this.encorep2 = gh3Tier_0.encorep2;
			this.aerosmith_encore_p1 = gh3Tier_0.aerosmith_encore_p1;
			this.boss = gh3Tier_0.boss;
			this.nocash = gh3Tier_0.nocash;
			this.unlockall = gh3Tier_0.unlockall;
		}

		public override string ToString()
		{
			return this.title ?? "[No Title]";
		}

		public void method_2(StructureHeaderNode class286_0, GH3Songlist gh3Songlist_0)
		{
			UnicodeStructureNode @class;
			this.title = (((@class = class286_0.method_5<UnicodeStructureNode>(new UnicodeStructureNode("title"))) != null) ? @class.method_8() : "");
			Class305 class2;
			this.completion_movie = (((class2 = class286_0.method_5<Class305>(new Class305("completion_movie"))) != null) ? class2.method_8() : "");
			IntegerStructureNode class3;
			this.defaultunlocked = (((class3 = class286_0.method_5<IntegerStructureNode>(new IntegerStructureNode("defaultunlocked"))) != null) ? class3.method_8() : 0);
			Class296 class4;
			this.level = (((class4 = class286_0.method_5<Class296>(new Class296("level"))) != null) ? class4.method_8() : "No Preset Stage");
			this.setlist_icon = (((class4 = class286_0.method_5<Class296>(new Class296("setlist_icon"))) != null) ? class4.method_8() : "No Icon");
			this.encorep1 = (class286_0.method_5<Class296>(new Class296(0, "encorep1")) != null);
			this.encorep2 = (class286_0.method_5<Class296>(new Class296(0, "encorep2")) != null);
			this.aerosmith_encore_p1 = (class286_0.method_5<Class296>(new Class296(0, "aerosmith_encore_p1")) != null);
			this.boss = (class286_0.method_5<Class296>(new Class296(0, "boss")) != null);
			this.nocash = (class286_0.method_5<Class296>(new Class296(0, "nocash")) != null);
			this.unlockall = (class286_0.method_5<Class296>(new Class296(0, "unlockall")) != null);
			Class301 class5 = new Class301("songs");
			if (class286_0.method_6<Class301>(ref class5) && !(class5.method_8() is FloatListNode))
			{
				foreach (string current in class5.method_8().method_8<string>())
				{
					if (gh3Songlist_0.ContainsKey(current))
					{
						this.songs.Add(gh3Songlist_0[current]);
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
			@class.method_3(new UnicodeStructureNode("title", this.title));
			if (this.songs.Count == 0)
			{
				@class.method_3(new Class301("songs", new FloatListNode(true)));
			}
			else
			{
				List<int> list = new List<int>();
				foreach (GH3Song current in this.songs)
				{
					list.Add(QbSongClass1.smethod_9(current.name));
				}
				@class.method_3(new Class301("songs", new TagArray(list)));
			}
			if (this.boss)
			{
				@class.method_3(new Class296(0, "boss"));
			}
			if (this.encorep1)
			{
				@class.method_3(new Class296(0, "encorep1"));
			}
			if (this.encorep2)
			{
				@class.method_3(new Class296(0, "encorep2"));
			}
			if (this.aerosmith_encore_p1)
			{
				@class.method_3(new Class296(0, "aerosmith_encore_p1"));
			}
			if (this.level != null && this.level != "No Preset Stage")
			{
				@class.method_3(new Class296("level", this.level));
			}
			if (this.defaultunlocked != 0)
			{
				@class.method_3(new IntegerStructureNode("defaultunlocked", this.defaultunlocked));
			}
			if (!this.completion_movie.Equals(""))
			{
				@class.method_3(new Class305("completion_movie", this.completion_movie));
			}
			if (!this.setlist_icon.Equals("No Icon"))
			{
				@class.method_3(new Class296("setlist_icon", this.setlist_icon));
			}
			if (this.nocash)
			{
				@class.method_3(new Class296(0, "nocash"));
			}
			if (this.unlockall)
			{
				@class.method_3(new Class296(0, "unlockall"));
			}
			return @class;
		}
	}
}
