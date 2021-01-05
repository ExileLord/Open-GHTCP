using System;
using System.Collections.Generic;
using GHNamespace7;
using GHNamespaceB;
using GHNamespaceE;
using GHNamespaceF;
using GHNamespaceG;
using GuitarHero.Setlist;

namespace GuitarHero.Songlist
{
    [Serializable]
    public class Gh3Songlist : SortedDictionary<string, Gh3Song>
    {
        [NonSerialized] public Dictionary<int, Gh3Setlist> Gh3SetlistList = new Dictionary<int, Gh3Setlist>();

        [NonSerialized] public Dictionary<int, GhLink> Dictionary1 = new Dictionary<int, GhLink>();

        [NonSerialized] public ZzCollection214<string, int> Class2140 = new ZzCollection214<string, int>();

        public int CustomBitMask;

        public bool HideUsed;

        public bool HideUnEditable;

        public static List<int> IgnoreSongs = new List<int>(new[]
        {
            QbSongClass1.AddKeyToDictionary("synctest"),
            QbSongClass1.AddKeyToDictionary("mutetest"),
            QbSongClass1.AddKeyToDictionary("synctestplaytoaudio"),
            QbSongClass1.AddKeyToDictionary("synctestaudioandvisual"),
            QbSongClass1.AddKeyToDictionary("tutorial_1b"),
            QbSongClass1.AddKeyToDictionary("tutorial_1c"),
            QbSongClass1.AddKeyToDictionary("tutorial_1d"),
            QbSongClass1.AddKeyToDictionary("tutorial_1e"),
            QbSongClass1.AddKeyToDictionary("tutorial_2a"),
            QbSongClass1.AddKeyToDictionary("tutorial_2b"),
            QbSongClass1.AddKeyToDictionary("tutorial_2c"),
            QbSongClass1.AddKeyToDictionary("tutorial_3a"),
            QbSongClass1.AddKeyToDictionary("tutorial_3b"),
            QbSongClass1.AddKeyToDictionary("tutorial_3c"),
            QbSongClass1.AddKeyToDictionary("tutorial_3d"),
            QbSongClass1.AddKeyToDictionary("tutorial_4c"),
            QbSongClass1.AddKeyToDictionary("tutorial_4e"),
            QbSongClass1.AddKeyToDictionary("credits"),
            QbSongClass1.AddKeyToDictionary("kingsandqueenscredits"),
            QbSongClass1.AddKeyToDictionary("timrapptest")
        });

        public Gh3Songlist(ZzGenericNode1 class3080, Gh3Songlist gh3Songlist0)
        {
            FindEditableSongs(class3080, gh3Songlist0);
        }

        public void Add(Gh3Song gh3Song0)
        {
            if (!ContainsKey(gh3Song0.GetSongName()))
            {
                base.Add(gh3Song0.GetSongName(), gh3Song0);
                QbSongClass1.AddKeyToDictionary(gh3Song0.GetSongName());
            }
        }

        public void method_0(Gh3Song gh3Song0, bool bool0)
        {
            if (!ContainsKey(gh3Song0.GetSongName()))
            {
                base.Add(gh3Song0.GetSongName(), gh3Song0);
                QbSongClass1.AddKeyToDictionary(gh3Song0.GetSongName());
                return;
            }
            if (base[gh3Song0.GetSongName()].IsEditable() && bool0)
            {
                base[gh3Song0.GetSongName()].vmethod_0(gh3Song0);
            }
        }

        public List<int> method_1(Gh3Song gh3Song0)
        {
            var list = new List<int>();
            foreach (var current in Gh3SetlistList.Keys)
            {
                foreach (var current2 in Gh3SetlistList[current].method_0())
                {
                    if (current2.method_0().Contains(gh3Song0))
                    {
                        current2.method_0().Remove(gh3Song0);
                        if (!list.Contains(current))
                        {
                            list.Add(current);
                        }
                    }
                }
            }
            Remove(gh3Song0.GetSongName());
            return list;
        }

        public Gh3Song[] GetSongs()
        {
            var songList = new List<Gh3Song>(Values);
            if (songList.Count != 0)
            {
                if (HideUsed)
                {
                    foreach (var current in Gh3SetlistList.Values)
                    {
                        foreach (var current2 in current.method_0())
                        {
                            foreach (var current3 in current2.method_0())
                            {
                                if (songList.Contains(current3))
                                {
                                    songList.Remove(current3);
                                }
                            }
                        }
                    }
                }
                if (HideUnEditable)
                {
                    foreach (var current4 in Values)
                    {
                        if (!current4.IsEditable())
                        {
                            songList.Remove(current4);
                        }
                    }
                }
                foreach (var current5 in Values)
                {
                    if (!current5.IsVisible())
                    {
                        songList.Remove(current5);
                    }
                }
            }
            return songList.ToArray();
        }

        public bool method_3(string string0)
        {
            return ContainsKey(string0);
        }

        public Gh3Setlist method_4(string string0, StructurePointerRootNode class2660)
        {
            var gH3Setlist = new Gh3Setlist(class2660.method_7(), this);
            gH3Setlist.method_3(string0);
            Gh3SetlistList.Add(class2660.Int0, gH3Setlist);
            return gH3Setlist;
        }

        public GhLink method_5(string string0, StructurePointerRootNode class2660)
        {
            var gHLink = new GhLink(string0, class2660.method_7());
            Dictionary1.Add(class2660.Int0, gHLink);
            return gHLink;
        }

        public void method_6(StructureArrayNode class2920)
        {
            foreach (StructureHeaderNode @class in class2920.Nodes)
            {
                var num = @class.zzFindNode(new StructItemQbKey("tag")).method_10();
                if (Dictionary1.ContainsKey(num))
                {
                    Class2140.Add(@class.zzFindNode(new UnicodeStructureNode("text")).method_8(), num);
                }
            }
        }

        public StructureArrayNode method_7()
        {
            var @class = new StructureArrayNode();
            foreach (var current in Class2140.Keys)
            {
                @class.addChild(new StructureHeaderNode(new List<ZzUnkNode294>
                {
                    new StructItemQbKey("tag", Class2140[current]),
                    new UnicodeStructureNode("text", current)
                }));
            }
            return @class;
        }

        public string method_8(int int0)
        {
            foreach (var current in Dictionary1.Keys)
            {
                if (Dictionary1[current].Setlist == int0)
                {
                    return Class2140.method_0(current);
                }
            }
            return "No Name";
        }

        public int method_9(string string0)
        {
            return Dictionary1[Class2140[string0]].Setlist;
        }

        public int method_10(int int0)
        {
            return Dictionary1[int0].Setlist;
        }

        public Gh3Setlist method_11(int int0)
        {
            return Gh3SetlistList[Dictionary1[int0].Setlist];
        }

        public void FindEditableSongs(ZzGenericNode1 class3080, Gh3Songlist gh3Songlist0)
        {
            var @class = class3080.zzFindNode(new StructurePointerRootNode("permanent_songlist_props")).method_7();
            var flag = class3080.zzFindNode(new StructItemQbKey("band")) != null;
            Clear();
            foreach (StructurePointerNode class2 in @class.Nodes)
            {
                var gH3Song = flag ? new GhaSong(class2) : new Gh3Song(class2);
                if (gh3Songlist0 != null)
                {
                    gH3Song.SetEditable(!gh3Songlist0.method_3(gH3Song.GetSongName()));
                }
                gH3Song.SetVisible(!IgnoreSongs.Contains(class2.Int0));
                Add(gH3Song);
            }
        }

        public void method_13(ZzGenericNode1 class3080)
        {
            var list = new List<int>();
            var list2 = new List<ZzUnkNode294>();
            foreach (var current in Keys)
            {
                list.Add(QbSongClass1.AddKeyToDictionary(current));
                list2.Add(base[current].vmethod_5());
            }
            ((TagArray) class3080.zzFindNode(new ArrayPointerRootNode("gh3_songlist")).method_7()).method_12(list);
            class3080.zzFindNode(new StructurePointerRootNode("permanent_songlist_props")).method_7().method_9(list2);
        }
    }
}