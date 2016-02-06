using GuitarHero.Songlist;
using GuitarHero.Tier;
using ns19;
using ns20;
using ns21;
using System;
using System.Collections.Generic;

namespace GuitarHero.Setlist
{
	[Serializable]
	public class GH3Setlist
	{
		public string path;

		public string prefix = "";

		public string initial_movie;

		public List<GH3Tier> tiers = new List<GH3Tier>();

		public int CustomBit;

		public GH3Setlist()
		{
		}

		public GH3Setlist(Class286 class286_0, GH3Songlist gh3Songlist_0)
		{
			this.method_5(class286_0, gh3Songlist_0);
		}

		public List<GH3Tier> method_0()
		{
			return this.tiers;
		}

		public void method_1(GH3Setlist gh3Setlist_0)
		{
			this.initial_movie = gh3Setlist_0.initial_movie;
			this.tiers = gh3Setlist_0.tiers;
		}

		public string method_2()
		{
			return this.path;
		}

		public void method_3(string string_0)
		{
			this.path = string_0;
		}

		public bool method_4()
		{
			return this.CustomBit != 0;
		}

		public void method_5(Class286 class286_0, GH3Songlist gh3Songlist_0)
		{
			Class305 @class;
			this.prefix = (((@class = class286_0.method_5<Class305>(new Class305("prefix"))) != null) ? @class.method_8() : "general");
			this.initial_movie = (((@class = class286_0.method_5<Class305>(new Class305("initial_movie"))) != null) ? @class.method_8() : "");
			Class299 class2;
			int num = ((class2 = class286_0.method_5<Class299>(new Class299("num_tiers"))) != null) ? class2.method_8() : 0;
			try
			{
				for (int i = 1; i <= num; i++)
				{
					this.tiers.Add(new GH3Tier(class286_0.method_5<Class302>(new Class302("tier" + i)).method_8(), gh3Songlist_0));
				}
			}
			catch
			{
				throw new Exception(this.path + " setlist is corrupt: Tier/s missing.");
			}
		}

		public Class286 method_6()
		{
			Class286 @class = new Class286();
			@class.method_3(new Class305("prefix", this.prefix));
			@class.method_3(new Class299("num_tiers", this.tiers.Count));
			@class.method_3(new Class305("initial_movie", this.initial_movie));
			for (int i = 0; i < this.tiers.Count; i++)
			{
				@class.method_3(new Class302("tier" + (i + 1), this.tiers[i].method_3()));
			}
			return @class;
		}
	}
}
