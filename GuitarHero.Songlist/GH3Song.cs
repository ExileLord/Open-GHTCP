using System;
using System.Globalization;
using ns15;
using ns18;
using ns19;
using ns20;
using ns21;

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

		public GH3Song(StructurePointerNode class302_0)
		{
			vmethod_4(class302_0);
		}

		public GH3Song(string string_0)
		{
			title = string_0;
			name = string_0;
			leaderboard = true;
			editable = true;
		}

		public virtual void vmethod_0(Interface16 interface16_0)
		{
			if (interface16_0 is GH3Song)
			{
				var gH3Song = interface16_0 as GH3Song;
				original_artist = gH3Song.original_artist;
				not_bass = gH3Song.not_bass;
				no_rhythm_track = gH3Song.no_rhythm_track;
				use_coop_notetracks = gH3Song.use_coop_notetracks;
				keyboard = gH3Song.keyboard;
				band_vol = gH3Song.band_vol;
				guitar_vol = gH3Song.guitar_vol;
				hammer_on = gH3Song.hammer_on;
				gem_offset = gH3Song.gem_offset;
				fretbar_offset = gH3Song.fretbar_offset;
				input_offset = gH3Song.input_offset;
				version = gH3Song.version;
				title = gH3Song.title;
				artist = gH3Song.artist;
				year = gH3Song.year;
				countoff = gH3Song.countoff;
				bassist = gH3Song.bassist;
				singer = gH3Song.singer;
				boss = gH3Song.boss;
				artist_text = gH3Song.artist_text;
			}
		}

		public bool isEditable()
		{
			return editable;
		}

		public void setEditable(bool bool_1)
		{
			editable = bool_1;
		}

		public bool isVisible()
		{
			return visible;
		}

		public void setVisible(bool bool_1)
		{
			visible = bool_1;
		}

		public string getSongName()
		{
			return name;
		}

		public override string ToString()
		{
			if (bool_0 && title != null)
			{
				return title;
			}
			return name;
		}

		public virtual void vmethod_4(StructurePointerNode class302_0)
		{
			name = class302_0.method_5(new AsciiStructureNode("name")).method_8().ToLower();
			if (name != null && !name.Equals(""))
			{
				UnicodeStructureNode @class;
				title = (((@class = class302_0.method_5(new UnicodeStructureNode("title"))) != null) ? @class.method_8() : "");
				artist = (((@class = class302_0.method_5(new UnicodeStructureNode("artist"))) != null) ? @class.method_8() : "");
				year = (((@class = class302_0.method_5(new UnicodeStructureNode("year"))) != null) ? @class.method_8() : "");
				bassist = (((@class = class302_0.method_5(new UnicodeStructureNode("bassist"))) != null) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(@class.method_8()) : "Generic Bassist");
				AsciiStructureNode class2;
				countoff = (((class2 = class302_0.method_5(new AsciiStructureNode("countoff"))) != null) ? class2.method_8() : "");
				FloatStructureNode class3;
				band_vol = (((class3 = class302_0.method_5(new FloatStructureNode("band_playback_volume"))) != null) ? class3.method_8() : 0f);
				guitar_vol = (((class3 = class302_0.method_5(new FloatStructureNode("guitar_playback_volume"))) != null) ? class3.method_8() : 0f);
				hammer_on = (((class3 = class302_0.method_5(new FloatStructureNode("hammer_on_measure_scale"))) != null) ? class3.method_8() : 0f);
				IntegerStructureNode class4;
				gem_offset = (((class4 = class302_0.method_5(new IntegerStructureNode("gem_offset"))) != null) ? class4.method_8() : 0);
				fretbar_offset = (((class4 = class302_0.method_5(new IntegerStructureNode("fretbar_offset"))) != null) ? class4.method_8() : 0);
				input_offset = (((class4 = class302_0.method_5(new IntegerStructureNode("input_offset"))) != null) ? class4.method_8() : 0);
				original_artist = ((class4 = class302_0.method_5(new IntegerStructureNode("original_artist"))) != null && class4.method_8() == 1);
				leaderboard = ((class4 = class302_0.method_5(new IntegerStructureNode("leaderboard"))) != null && class4.method_8() == 1);
				not_bass = ((class4 = class302_0.method_5(new IntegerStructureNode("rhythm_track"))) != null && class4.method_8() == 1);
				TagStructureNode class5;
				keyboard = ((class5 = class302_0.method_5(new TagStructureNode("keyboard"))) != null && class5.method_8() == "true");
				singer = (((class5 = class302_0.method_5(new TagStructureNode("singer"))) != null) ? class5.method_8() : "");
				boss = (((class5 = class302_0.method_5(new TagStructureNode("boss"))) != null) ? class5.method_8() : "");
				version = (((class5 = class302_0.method_5(new TagStructureNode("version"))) != null) ? Convert.ToInt32(string.Concat(class5.method_8()[2])) : 3);
				use_coop_notetracks = (class302_0.method_5(new TagStructureNode(0, "use_coop_notetracks")) != null);
				no_rhythm_track = (class302_0.method_5(new TagStructureNode(0, "no_rhythm_track")) != null);
				try
				{
					artist_text = class302_0.method_5(new FileTagStructureNode("artist_text")).method_8().Equals("artist_text_by");
					return;
				}
				catch
				{
					artist_text = (((@class = class302_0.method_5(new UnicodeStructureNode("artist_text"))) != null) ? @class.method_8() : "by");
					return;
				}
			}
			throw new Exception("songlist.qb");
		}

		public virtual StructurePointerNode vmethod_5()
		{
			var @class = new StructureHeaderNode();
			@class.method_3(new TagStructureNode("checksum", name));
			@class.method_3(new AsciiStructureNode("name", name));
			@class.method_3(new UnicodeStructureNode("title", title));
			@class.method_3(new UnicodeStructureNode("artist", artist.Equals("") ? " " : artist));
			@class.method_3(new UnicodeStructureNode("year", year.Equals("") ? " " : year));
			if (artist_text is bool)
			{
				@class.method_3(new FileTagStructureNode("artist_text", ((bool)artist_text) ? "artist_text_by" : "artist_text_as_made_famous_by"));
			}
			else if (artist_text is string)
			{
				@class.method_3(new UnicodeStructureNode("artist_text", (string)artist_text));
			}
			@class.method_3(new IntegerStructureNode("original_artist", original_artist ? 1 : 0));
			if (version == 0)
			{
				version = 3;
			}
			@class.method_3(new TagStructureNode("version", "gh" + version));
			@class.method_3(new IntegerStructureNode("leaderboard", leaderboard ? 1 : 0));
			if (gem_offset != 0)
			{
				@class.method_3(new IntegerStructureNode("gem_offset", gem_offset));
			}
			if (fretbar_offset != 0)
			{
				@class.method_3(new IntegerStructureNode("fretbar_offset", fretbar_offset));
			}
			if (input_offset != 0)
			{
				@class.method_3(new IntegerStructureNode("input_offset", input_offset));
			}
			if (!singer.Equals(""))
			{
				@class.method_3(new TagStructureNode("singer", singer));
			}
			if (!boss.Equals(""))
			{
				@class.method_3(new TagStructureNode("boss", boss));
			}
			if (!keyboard)
			{
				@class.method_3(new TagStructureNode("keyboard", "false"));
			}
			if (!bassist.Equals("Generic Bassist"))
			{
				@class.method_3(new UnicodeStructureNode("bassist", bassist));
			}
			if (!countoff.Equals(""))
			{
				@class.method_3(new AsciiStructureNode("countoff", countoff));
			}
			@class.method_3(new IntegerStructureNode("rhythm_track", not_bass ? 1 : 0));
			if (band_vol != 0f)
			{
				@class.method_3(new FloatStructureNode("band_playback_volume", band_vol));
			}
			if (guitar_vol != 0f)
			{
				@class.method_3(new FloatStructureNode("guitar_playback_volume", guitar_vol));
			}
			if (hammer_on != 0f)
			{
				@class.method_3(new FloatStructureNode("hammer_on_measure_scale", hammer_on));
			}
			if (use_coop_notetracks)
			{
				@class.method_3(new TagStructureNode(0, "use_coop_notetracks"));
			}
			if (no_rhythm_track)
			{
				@class.method_3(new TagStructureNode(0, "no_rhythm_track"));
			}
			return new StructurePointerNode(name, @class);
		}
	}
}
