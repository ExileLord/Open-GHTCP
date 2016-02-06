using ns15;
using ns18;
using ns19;
using ns20;
using ns21;
using System;
using System.Globalization;

namespace GuitarHero.Songlist
{
	[Serializable]
	public class GH3Song : Interface16
	{
		public bool editable;

		public bool visible = true;

		public bool leaderboard;

		public bool original_artist;

		public bool not_bass;

		public bool no_rhythm_track;

		public bool use_coop_notetracks;

		public bool keyboard;

		public float band_vol;

		public float guitar_vol;

		public float hammer_on;

		public int gem_offset;

		public int fretbar_offset;

		public int input_offset;

		public int version = 3;

		public string name = "";

		public string title = "";

		public string artist = "";

		public string year = "";

		public string countoff = "sticks_tiny";

		public string bassist = "Generic Bassist";

		public string singer = "";

		public string boss = "";

		public object artist_text = true;

		[NonSerialized]
		public static bool bool_0;

		public GH3Song()
		{
		}

		public GH3Song(Class302 class302_0)
		{
			this.vmethod_4(class302_0);
		}

		public GH3Song(string string_0)
		{
			this.title = string_0;
			this.name = string_0;
			this.leaderboard = true;
			this.editable = true;
		}

		public virtual void vmethod_0(Interface16 interface16_0)
		{
			if (interface16_0 is GH3Song)
			{
				GH3Song gH3Song = interface16_0 as GH3Song;
				this.original_artist = gH3Song.original_artist;
				this.not_bass = gH3Song.not_bass;
				this.no_rhythm_track = gH3Song.no_rhythm_track;
				this.use_coop_notetracks = gH3Song.use_coop_notetracks;
				this.keyboard = gH3Song.keyboard;
				this.band_vol = gH3Song.band_vol;
				this.guitar_vol = gH3Song.guitar_vol;
				this.hammer_on = gH3Song.hammer_on;
				this.gem_offset = gH3Song.gem_offset;
				this.fretbar_offset = gH3Song.fretbar_offset;
				this.input_offset = gH3Song.input_offset;
				this.version = gH3Song.version;
				this.title = gH3Song.title;
				this.artist = gH3Song.artist;
				this.year = gH3Song.year;
				this.countoff = gH3Song.countoff;
				this.bassist = gH3Song.bassist;
				this.singer = gH3Song.singer;
				this.boss = gH3Song.boss;
				this.artist_text = gH3Song.artist_text;
			}
		}

		public bool vmethod_1()
		{
			return this.editable;
		}

		public void vmethod_2(bool bool_1)
		{
			this.editable = bool_1;
		}

		public bool method_0()
		{
			return this.visible;
		}

		public void method_1(bool bool_1)
		{
			this.visible = bool_1;
		}

		public string vmethod_3()
		{
			return this.name;
		}

		public override string ToString()
		{
			if (GH3Song.bool_0 && this.title != null)
			{
				return this.title;
			}
			return this.name;
		}

		public virtual void vmethod_4(Class302 class302_0)
		{
			this.name = class302_0.method_5<Class305>(new Class305("name")).method_8().ToLower();
			if (this.name != null && !this.name.Equals(""))
			{
				Class307 @class;
				this.title = (((@class = class302_0.method_5<Class307>(new Class307("title"))) != null) ? @class.method_8() : "");
				this.artist = (((@class = class302_0.method_5<Class307>(new Class307("artist"))) != null) ? @class.method_8() : "");
				this.year = (((@class = class302_0.method_5<Class307>(new Class307("year"))) != null) ? @class.method_8() : "");
				this.bassist = (((@class = class302_0.method_5<Class307>(new Class307("bassist"))) != null) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(@class.method_8()) : "Generic Bassist");
				Class305 class2;
				this.countoff = (((class2 = class302_0.method_5<Class305>(new Class305("countoff"))) != null) ? class2.method_8() : "");
				Class297 class3;
				this.band_vol = (((class3 = class302_0.method_5<Class297>(new Class297("band_playback_volume"))) != null) ? class3.method_8() : 0f);
				this.guitar_vol = (((class3 = class302_0.method_5<Class297>(new Class297("guitar_playback_volume"))) != null) ? class3.method_8() : 0f);
				this.hammer_on = (((class3 = class302_0.method_5<Class297>(new Class297("hammer_on_measure_scale"))) != null) ? class3.method_8() : 0f);
				Class299 class4;
				this.gem_offset = (((class4 = class302_0.method_5<Class299>(new Class299("gem_offset"))) != null) ? class4.method_8() : 0);
				this.fretbar_offset = (((class4 = class302_0.method_5<Class299>(new Class299("fretbar_offset"))) != null) ? class4.method_8() : 0);
				this.input_offset = (((class4 = class302_0.method_5<Class299>(new Class299("input_offset"))) != null) ? class4.method_8() : 0);
				this.original_artist = ((class4 = class302_0.method_5<Class299>(new Class299("original_artist"))) != null && class4.method_8() == 1);
				this.leaderboard = ((class4 = class302_0.method_5<Class299>(new Class299("leaderboard"))) != null && class4.method_8() == 1);
				this.not_bass = ((class4 = class302_0.method_5<Class299>(new Class299("rhythm_track"))) != null && class4.method_8() == 1);
				Class296 class5;
				this.keyboard = ((class5 = class302_0.method_5<Class296>(new Class296("keyboard"))) != null && class5.method_8() == "true");
				this.singer = (((class5 = class302_0.method_5<Class296>(new Class296("singer"))) != null) ? class5.method_8() : "");
				this.boss = (((class5 = class302_0.method_5<Class296>(new Class296("boss"))) != null) ? class5.method_8() : "");
				this.version = (((class5 = class302_0.method_5<Class296>(new Class296("version"))) != null) ? Convert.ToInt32(string.Concat(class5.method_8()[2])) : 3);
				this.use_coop_notetracks = (class302_0.method_5<Class296>(new Class296(0, "use_coop_notetracks")) != null);
				this.no_rhythm_track = (class302_0.method_5<Class296>(new Class296(0, "no_rhythm_track")) != null);
				try
				{
					this.artist_text = class302_0.method_5<Class298>(new Class298("artist_text")).method_8().Equals("artist_text_by");
					return;
				}
				catch
				{
					this.artist_text = (((@class = class302_0.method_5<Class307>(new Class307("artist_text"))) != null) ? @class.method_8() : "by");
					return;
				}
			}
			throw new Exception("songlist.qb");
		}

		public virtual Class302 vmethod_5()
		{
			Class286 @class = new Class286();
			@class.method_3(new Class296("checksum", this.name));
			@class.method_3(new Class305("name", this.name));
			@class.method_3(new Class307("title", this.title));
			@class.method_3(new Class307("artist", this.artist.Equals("") ? " " : this.artist));
			@class.method_3(new Class307("year", this.year.Equals("") ? " " : this.year));
			if (this.artist_text is bool)
			{
				@class.method_3(new Class298("artist_text", ((bool)this.artist_text) ? "artist_text_by" : "artist_text_as_made_famous_by"));
			}
			else if (this.artist_text is string)
			{
				@class.method_3(new Class307("artist_text", (string)this.artist_text));
			}
			@class.method_3(new Class299("original_artist", this.original_artist ? 1 : 0));
			if (this.version == 0)
			{
				this.version = 3;
			}
			@class.method_3(new Class296("version", "gh" + this.version));
			@class.method_3(new Class299("leaderboard", this.leaderboard ? 1 : 0));
			if (this.gem_offset != 0)
			{
				@class.method_3(new Class299("gem_offset", this.gem_offset));
			}
			if (this.fretbar_offset != 0)
			{
				@class.method_3(new Class299("fretbar_offset", this.fretbar_offset));
			}
			if (this.input_offset != 0)
			{
				@class.method_3(new Class299("input_offset", this.input_offset));
			}
			if (!this.singer.Equals(""))
			{
				@class.method_3(new Class296("singer", this.singer));
			}
			if (!this.boss.Equals(""))
			{
				@class.method_3(new Class296("boss", this.boss));
			}
			if (!this.keyboard)
			{
				@class.method_3(new Class296("keyboard", "false"));
			}
			if (!this.bassist.Equals("Generic Bassist"))
			{
				@class.method_3(new Class307("bassist", this.bassist));
			}
			if (!this.countoff.Equals(""))
			{
				@class.method_3(new Class305("countoff", this.countoff));
			}
			@class.method_3(new Class299("rhythm_track", this.not_bass ? 1 : 0));
			if (this.band_vol != 0f)
			{
				@class.method_3(new Class297("band_playback_volume", this.band_vol));
			}
			if (this.guitar_vol != 0f)
			{
				@class.method_3(new Class297("guitar_playback_volume", this.guitar_vol));
			}
			if (this.hammer_on != 0f)
			{
				@class.method_3(new Class297("hammer_on_measure_scale", this.hammer_on));
			}
			if (this.use_coop_notetracks)
			{
				@class.method_3(new Class296(0, "use_coop_notetracks"));
			}
			if (this.no_rhythm_track)
			{
				@class.method_3(new Class296(0, "no_rhythm_track"));
			}
			return new Class302(this.name, @class);
		}
	}
}
