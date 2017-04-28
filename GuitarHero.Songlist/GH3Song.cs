using System;
using System.Globalization;
using GHNamespace8;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GuitarHero.Songlist
{
	[Serializable]
	public class Gh3Song : INterface16
	{
		public bool Editable;

		public bool Visible = true;

		public bool Leaderboard;

		public bool OriginalArtist;

		public bool NotBass;

		public bool NoRhythmTrack;

		public bool UseCoopNotetracks;

		public bool Keyboard;

		public float BandVol;

		public float GuitarVol;

		public float HammerOn;

		public int GemOffset;

		public int FretbarOffset;

		public int InputOffset;

		public int Version = 3;

		public string Name = "";

		public string Title = "";

		public string Artist = "";

		public string Year = "";

		public string Countoff = "sticks_tiny";

		public string Bassist = "Generic Bassist";

		public string Singer = "";

		public string Boss = "";

		public object ArtistText = true;

		[NonSerialized]
		public static bool Bool0;

		public Gh3Song()
		{
		}

		public Gh3Song(StructurePointerNode class3020)
		{
			vmethod_4(class3020);
		}

		public Gh3Song(string string0)
		{
			Title = string0;
			Name = string0;
			Leaderboard = true;
			Editable = true;
		}

		public virtual void vmethod_0(INterface16 interface160)
		{
			if (interface160 is Gh3Song)
			{
				var gH3Song = interface160 as Gh3Song;
				OriginalArtist = gH3Song.OriginalArtist;
				NotBass = gH3Song.NotBass;
				NoRhythmTrack = gH3Song.NoRhythmTrack;
				UseCoopNotetracks = gH3Song.UseCoopNotetracks;
				Keyboard = gH3Song.Keyboard;
				BandVol = gH3Song.BandVol;
				GuitarVol = gH3Song.GuitarVol;
				HammerOn = gH3Song.HammerOn;
				GemOffset = gH3Song.GemOffset;
				FretbarOffset = gH3Song.FretbarOffset;
				InputOffset = gH3Song.InputOffset;
				Version = gH3Song.Version;
				Title = gH3Song.Title;
				Artist = gH3Song.Artist;
				Year = gH3Song.Year;
				Countoff = gH3Song.Countoff;
				Bassist = gH3Song.Bassist;
				Singer = gH3Song.Singer;
				Boss = gH3Song.Boss;
				ArtistText = gH3Song.ArtistText;
			}
		}

		public bool IsEditable()
		{
			return Editable;
		}

		public void SetEditable(bool bool1)
		{
			Editable = bool1;
		}

		public bool IsVisible()
		{
			return Visible;
		}

		public void SetVisible(bool bool1)
		{
			Visible = bool1;
		}

		public string GetSongName()
		{
			return Name;
		}

		public override string ToString()
		{
			if (Bool0 && Title != null)
			{
				return Title;
			}
			return Name;
		}

		public virtual void vmethod_4(StructurePointerNode class3020)
		{
			Name = class3020.method_5(new AsciiStructureNode("name")).method_8().ToLower();
			if (Name != null && !Name.Equals(""))
			{
				UnicodeStructureNode @class;
				Title = (((@class = class3020.method_5(new UnicodeStructureNode("title"))) != null) ? @class.method_8() : "");
				Artist = (((@class = class3020.method_5(new UnicodeStructureNode("artist"))) != null) ? @class.method_8() : "");
				Year = (((@class = class3020.method_5(new UnicodeStructureNode("year"))) != null) ? @class.method_8() : "");
				Bassist = (((@class = class3020.method_5(new UnicodeStructureNode("bassist"))) != null) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(@class.method_8()) : "Generic Bassist");
				AsciiStructureNode class2;
				Countoff = (((class2 = class3020.method_5(new AsciiStructureNode("countoff"))) != null) ? class2.method_8() : "");
				FloatStructureNode class3;
				BandVol = (((class3 = class3020.method_5(new FloatStructureNode("band_playback_volume"))) != null) ? class3.method_8() : 0f);
				GuitarVol = (((class3 = class3020.method_5(new FloatStructureNode("guitar_playback_volume"))) != null) ? class3.method_8() : 0f);
				HammerOn = (((class3 = class3020.method_5(new FloatStructureNode("hammer_on_measure_scale"))) != null) ? class3.method_8() : 0f);
				IntegerStructureNode class4;
				GemOffset = (((class4 = class3020.method_5(new IntegerStructureNode("gem_offset"))) != null) ? class4.method_8() : 0);
				FretbarOffset = (((class4 = class3020.method_5(new IntegerStructureNode("fretbar_offset"))) != null) ? class4.method_8() : 0);
				InputOffset = (((class4 = class3020.method_5(new IntegerStructureNode("input_offset"))) != null) ? class4.method_8() : 0);
				OriginalArtist = ((class4 = class3020.method_5(new IntegerStructureNode("original_artist"))) != null && class4.method_8() == 1);
				Leaderboard = ((class4 = class3020.method_5(new IntegerStructureNode("leaderboard"))) != null && class4.method_8() == 1);
				NotBass = ((class4 = class3020.method_5(new IntegerStructureNode("rhythm_track"))) != null && class4.method_8() == 1);
				TagStructureNode class5;
				Keyboard = ((class5 = class3020.method_5(new TagStructureNode("keyboard"))) != null && class5.method_8() == "true");
				Singer = (((class5 = class3020.method_5(new TagStructureNode("singer"))) != null) ? class5.method_8() : "");
				Boss = (((class5 = class3020.method_5(new TagStructureNode("boss"))) != null) ? class5.method_8() : "");
				Version = (((class5 = class3020.method_5(new TagStructureNode("version"))) != null) ? Convert.ToInt32(string.Concat(class5.method_8()[2])) : 3);
				UseCoopNotetracks = (class3020.method_5(new TagStructureNode(0, "use_coop_notetracks")) != null);
				NoRhythmTrack = (class3020.method_5(new TagStructureNode(0, "no_rhythm_track")) != null);
				try
				{
					ArtistText = class3020.method_5(new FileTagStructureNode("artist_text")).method_8().Equals("artist_text_by");
					return;
				}
				catch
				{
					ArtistText = (((@class = class3020.method_5(new UnicodeStructureNode("artist_text"))) != null) ? @class.method_8() : "by");
					return;
				}
			}
			throw new Exception("songlist.qb");
		}

		public virtual StructurePointerNode vmethod_5()
		{
			var @class = new StructureHeaderNode();
			@class.method_3(new TagStructureNode("checksum", Name));
			@class.method_3(new AsciiStructureNode("name", Name));
			@class.method_3(new UnicodeStructureNode("title", Title));
			@class.method_3(new UnicodeStructureNode("artist", Artist.Equals("") ? " " : Artist));
			@class.method_3(new UnicodeStructureNode("year", Year.Equals("") ? " " : Year));
			if (ArtistText is bool)
			{
				@class.method_3(new FileTagStructureNode("artist_text", ((bool)ArtistText) ? "artist_text_by" : "artist_text_as_made_famous_by"));
			}
			else if (ArtistText is string)
			{
				@class.method_3(new UnicodeStructureNode("artist_text", (string)ArtistText));
			}
			@class.method_3(new IntegerStructureNode("original_artist", OriginalArtist ? 1 : 0));
			if (Version == 0)
			{
				Version = 3;
			}
			@class.method_3(new TagStructureNode("version", "gh" + Version));
			@class.method_3(new IntegerStructureNode("leaderboard", Leaderboard ? 1 : 0));
			if (GemOffset != 0)
			{
				@class.method_3(new IntegerStructureNode("gem_offset", GemOffset));
			}
			if (FretbarOffset != 0)
			{
				@class.method_3(new IntegerStructureNode("fretbar_offset", FretbarOffset));
			}
			if (InputOffset != 0)
			{
				@class.method_3(new IntegerStructureNode("input_offset", InputOffset));
			}
			if (!Singer.Equals(""))
			{
				@class.method_3(new TagStructureNode("singer", Singer));
			}
			if (!Boss.Equals(""))
			{
				@class.method_3(new TagStructureNode("boss", Boss));
			}
			if (!Keyboard)
			{
				@class.method_3(new TagStructureNode("keyboard", "false"));
			}
			if (!Bassist.Equals("Generic Bassist"))
			{
				@class.method_3(new UnicodeStructureNode("bassist", Bassist));
			}
			if (!Countoff.Equals(""))
			{
				@class.method_3(new AsciiStructureNode("countoff", Countoff));
			}
			@class.method_3(new IntegerStructureNode("rhythm_track", NotBass ? 1 : 0));
			if (BandVol != 0f)
			{
				@class.method_3(new FloatStructureNode("band_playback_volume", BandVol));
			}
			if (GuitarVol != 0f)
			{
				@class.method_3(new FloatStructureNode("guitar_playback_volume", GuitarVol));
			}
			if (HammerOn != 0f)
			{
				@class.method_3(new FloatStructureNode("hammer_on_measure_scale", HammerOn));
			}
			if (UseCoopNotetracks)
			{
				@class.method_3(new TagStructureNode(0, "use_coop_notetracks"));
			}
			if (NoRhythmTrack)
			{
				@class.method_3(new TagStructureNode(0, "no_rhythm_track"));
			}
			return new StructurePointerNode(Name, @class);
		}
	}
}
