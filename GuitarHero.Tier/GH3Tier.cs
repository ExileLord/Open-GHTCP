using System;
using System.Collections.Generic;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;
using GuitarHero.Songlist;

namespace GuitarHero.Tier
{
    [Serializable]
    public class Gh3Tier
    {
        public string Title = "";

        public string CompletionMovie = "";

        public string Level = "No Preset Stage";

        public string SetlistIcon = "No Icon";

        public List<Gh3Song> Songs = new List<Gh3Song>();

        public int Defaultunlocked;

        public bool Encorep1;

        public bool Encorep2;

        public bool AerosmithEncoreP1;

        public bool Boss;

        public bool Nocash;

        public bool Unlockall;

        public Gh3Tier()
        {
        }

        public Gh3Tier(StructureHeaderNode class2860, Gh3Songlist gh3Songlist0)
        {
            method_2(class2860, gh3Songlist0);
        }

        public List<Gh3Song> method_0()
        {
            return Songs;
        }

        public void method_1(Gh3Tier gh3Tier0)
        {
            Title = gh3Tier0.Title;
            CompletionMovie = gh3Tier0.CompletionMovie;
            Level = gh3Tier0.Level;
            SetlistIcon = gh3Tier0.SetlistIcon;
            Songs = gh3Tier0.Songs;
            Defaultunlocked = gh3Tier0.Defaultunlocked;
            Encorep1 = gh3Tier0.Encorep1;
            Encorep2 = gh3Tier0.Encorep2;
            AerosmithEncoreP1 = gh3Tier0.AerosmithEncoreP1;
            Boss = gh3Tier0.Boss;
            Nocash = gh3Tier0.Nocash;
            Unlockall = gh3Tier0.Unlockall;
        }

        public override string ToString()
        {
            return Title ?? "[No Title]";
        }

        public void method_2(StructureHeaderNode class2860, Gh3Songlist gh3Songlist0)
        {
            UnicodeStructureNode @class;
            Title =
                (((@class = class2860.zzFindNode(new UnicodeStructureNode("title"))) != null) ? @class.method_8() : "");
            AsciiStructureNode class2;
            CompletionMovie = (((class2 = class2860.zzFindNode(new AsciiStructureNode("completion_movie"))) != null)
                ? class2.method_8()
                : "");
            IntegerStructureNode class3;
            Defaultunlocked = (((class3 = class2860.zzFindNode(new IntegerStructureNode("defaultunlocked"))) != null)
                ? class3.method_8()
                : 0);
            StructItemQbKey class4;
            Level = (((class4 = class2860.zzFindNode(new StructItemQbKey("level"))) != null)
                ? class4.method_8()
                : "No Preset Stage");
            SetlistIcon = (((class4 = class2860.zzFindNode(new StructItemQbKey("setlist_icon"))) != null)
                ? class4.method_8()
                : "No Icon");
            Encorep1 = (class2860.zzFindNode(new StructItemQbKey(0, "encorep1")) != null);
            Encorep2 = (class2860.zzFindNode(new StructItemQbKey(0, "encorep2")) != null);
            AerosmithEncoreP1 = (class2860.zzFindNode(new StructItemQbKey(0, "aerosmith_encore_p1")) != null);
            Boss = (class2860.zzFindNode(new StructItemQbKey(0, "boss")) != null);
            Nocash = (class2860.zzFindNode(new StructItemQbKey(0, "nocash")) != null);
            Unlockall = (class2860.zzFindNode(new StructItemQbKey(0, "unlockall")) != null);
            var class5 = new ArrayPointerNode("songs");
            if (class2860.method_6(ref class5) && !(class5.GetFirstChild() is FloatListNode))
            {
                foreach (var current in class5.GetFirstChild().method_8<string>())
                {
                    if (gh3Songlist0.ContainsKey(current))
                    {
                        Songs.Add(gh3Songlist0[current]);
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
            var @class = new StructureHeaderNode();
            @class.addChild(new UnicodeStructureNode("title", Title));
            if (Songs.Count == 0)
            {
                @class.addChild(new ArrayPointerNode("songs", new FloatListNode(true)));
            }
            else
            {
                var list = new List<int>();
                foreach (var current in Songs)
                {
                    list.Add(QbSongClass1.AddKeyToDictionary(current.Name));
                }
                @class.addChild(new ArrayPointerNode("songs", new TagArray(list)));
            }
            if (Boss)
            {
                @class.addChild(new StructItemQbKey(0, "boss"));
            }
            if (Encorep1)
            {
                @class.addChild(new StructItemQbKey(0, "encorep1"));
            }
            if (Encorep2)
            {
                @class.addChild(new StructItemQbKey(0, "encorep2"));
            }
            if (AerosmithEncoreP1)
            {
                @class.addChild(new StructItemQbKey(0, "aerosmith_encore_p1"));
            }
            if (Level != null && Level != "No Preset Stage")
            {
                @class.addChild(new StructItemQbKey("level", Level));
            }
            if (Defaultunlocked != 0)
            {
                @class.addChild(new IntegerStructureNode("defaultunlocked", Defaultunlocked));
            }
            if (!CompletionMovie.Equals(""))
            {
                @class.addChild(new AsciiStructureNode("completion_movie", CompletionMovie));
            }
            if (!SetlistIcon.Equals("No Icon"))
            {
                @class.addChild(new StructItemQbKey("setlist_icon", SetlistIcon));
            }
            if (Nocash)
            {
                @class.addChild(new StructItemQbKey(0, "nocash"));
            }
            if (Unlockall)
            {
                @class.addChild(new StructItemQbKey(0, "unlockall"));
            }
            return @class;
        }
    }
}