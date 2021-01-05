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

        [NonSerialized] public static bool Bool0;

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
            Name = class3020.zzFindNode(new AsciiStructureNode("name")).method_8().ToLower();
            if (Name != null && !Name.Equals(""))
            {
                UnicodeStructureNode @class;
                Title = (((@class = class3020.zzFindNode(new UnicodeStructureNode("title"))) != null)
                    ? @class.method_8()
                    : "");
                Artist = (((@class = class3020.zzFindNode(new UnicodeStructureNode("artist"))) != null)
                    ? @class.method_8()
                    : "");
                Year = (((@class = class3020.zzFindNode(new UnicodeStructureNode("year"))) != null)
                    ? @class.method_8()
                    : "");
                Bassist = (((@class = class3020.zzFindNode(new UnicodeStructureNode("bassist"))) != null)
                    ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(@class.method_8())
                    : "Generic Bassist");
                AsciiStructureNode class2;
                Countoff = (((class2 = class3020.zzFindNode(new AsciiStructureNode("countoff"))) != null)
                    ? class2.method_8()
                    : "");
                FloatStructureNode class3;
                BandVol = (((class3 = class3020.zzFindNode(new FloatStructureNode("band_playback_volume"))) != null)
                    ? class3.method_8()
                    : 0f);
                GuitarVol = (((class3 = class3020.zzFindNode(new FloatStructureNode("guitar_playback_volume"))) != null)
                    ? class3.method_8()
                    : 0f);
                HammerOn = (((class3 = class3020.zzFindNode(new FloatStructureNode("hammer_on_measure_scale"))) != null)
                    ? class3.method_8()
                    : 0f);
                IntegerStructureNode class4;
                GemOffset = (((class4 = class3020.zzFindNode(new IntegerStructureNode("gem_offset"))) != null)
                    ? class4.method_8()
                    : 0);
                FretbarOffset = (((class4 = class3020.zzFindNode(new IntegerStructureNode("fretbar_offset"))) != null)
                    ? class4.method_8()
                    : 0);
                InputOffset = (((class4 = class3020.zzFindNode(new IntegerStructureNode("input_offset"))) != null)
                    ? class4.method_8()
                    : 0);
                OriginalArtist = ((class4 = class3020.zzFindNode(new IntegerStructureNode("original_artist"))) != null &&
                                  class4.method_8() == 1);
                Leaderboard = ((class4 = class3020.zzFindNode(new IntegerStructureNode("leaderboard"))) != null &&
                               class4.method_8() == 1);
                NotBass = ((class4 = class3020.zzFindNode(new IntegerStructureNode("rhythm_track"))) != null &&
                           class4.method_8() == 1);
                StructItemQbKey class5;
                Keyboard = ((class5 = class3020.zzFindNode(new StructItemQbKey("keyboard"))) != null &&
                            class5.method_8() == "true");
                Singer = (((class5 = class3020.zzFindNode(new StructItemQbKey("singer"))) != null)
                    ? class5.method_8()
                    : "");
                Boss = (((class5 = class3020.zzFindNode(new StructItemQbKey("boss"))) != null) ? class5.method_8() : "");
                Version = (((class5 = class3020.zzFindNode(new StructItemQbKey("version"))) != null)
                    ? Convert.ToInt32(string.Concat(class5.method_8()[2]))
                    : 3);
                UseCoopNotetracks = (class3020.zzFindNode(new StructItemQbKey(0, "use_coop_notetracks")) != null);
                NoRhythmTrack = (class3020.zzFindNode(new StructItemQbKey(0, "no_rhythm_track")) != null);
                try
                {
                    ArtistText = class3020.zzFindNode(new FileTagStructureNode("artist_text"))
                        .method_8()
                        .Equals("artist_text_by");
                    return;
                }
                catch
                {
                    ArtistText = (((@class = class3020.zzFindNode(new UnicodeStructureNode("artist_text"))) != null)
                        ? @class.method_8()
                        : "by");
                    return;
                }
            }
            throw new Exception("songlist.qb");
        }

        public virtual StructurePointerNode vmethod_5()
        {
            var @class = new StructureHeaderNode();
            @class.addChild(new StructItemQbKey("checksum", Name));
            @class.addChild(new AsciiStructureNode("name", Name));
            @class.addChild(new UnicodeStructureNode("title", Title));
            @class.addChild(new UnicodeStructureNode("artist", Artist.Equals("") ? " " : Artist));
            @class.addChild(new UnicodeStructureNode("year", Year.Equals("") ? " " : Year));
            if (ArtistText is bool)
            {
                @class.addChild(new FileTagStructureNode("artist_text",
                    ((bool) ArtistText) ? "artist_text_by" : "artist_text_as_made_famous_by"));
            }
            else if (ArtistText is string)
            {
                @class.addChild(new UnicodeStructureNode("artist_text", (string) ArtistText));
            }
            @class.addChild(new IntegerStructureNode("original_artist", OriginalArtist ? 1 : 0));
            if (Version == 0)
            {
                Version = 3;
            }
            @class.addChild(new StructItemQbKey("version", "gh" + Version));
            @class.addChild(new IntegerStructureNode("leaderboard", Leaderboard ? 1 : 0));
            if (GemOffset != 0)
            {
                @class.addChild(new IntegerStructureNode("gem_offset", GemOffset));
            }
            if (FretbarOffset != 0)
            {
                @class.addChild(new IntegerStructureNode("fretbar_offset", FretbarOffset));
            }
            if (InputOffset != 0)
            {
                @class.addChild(new IntegerStructureNode("input_offset", InputOffset));
            }
            if (!Singer.Equals(""))
            {
                @class.addChild(new StructItemQbKey("singer", Singer));
            }
            if (!Boss.Equals(""))
            {
                @class.addChild(new StructItemQbKey("boss", Boss));
            }
            if (!Keyboard)
            {
                @class.addChild(new StructItemQbKey("keyboard", "false"));
            }
            if (!Bassist.Equals("Generic Bassist"))
            {
                @class.addChild(new UnicodeStructureNode("bassist", Bassist));
            }
            if (!Countoff.Equals(""))
            {
                @class.addChild(new AsciiStructureNode("countoff", Countoff));
            }
            @class.addChild(new IntegerStructureNode("rhythm_track", NotBass ? 1 : 0));
            if (BandVol != 0f)
            {
                @class.addChild(new FloatStructureNode("band_playback_volume", BandVol));
            }
            if (GuitarVol != 0f)
            {
                @class.addChild(new FloatStructureNode("guitar_playback_volume", GuitarVol));
            }
            if (HammerOn != 0f)
            {
                @class.addChild(new FloatStructureNode("hammer_on_measure_scale", HammerOn));
            }
            if (UseCoopNotetracks)
            {
                @class.addChild(new StructItemQbKey(0, "use_coop_notetracks"));
            }
            if (NoRhythmTrack)
            {
                @class.addChild(new StructItemQbKey(0, "no_rhythm_track"));
            }
            return new StructurePointerNode(Name, @class);
        }
    }
}