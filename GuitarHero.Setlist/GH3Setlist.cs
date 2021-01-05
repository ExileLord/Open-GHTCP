using System;
using System.Collections.Generic;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;
using GuitarHero.Songlist;
using GuitarHero.Tier;

namespace GuitarHero.Setlist
{
    [Serializable]
    public class Gh3Setlist
    {
        public string Path;

        public string Prefix = "";

        public string InitialMovie;

        public List<Gh3Tier> Tiers = new List<Gh3Tier>();

        public int CustomBit;

        public Gh3Setlist()
        {
        }

        public Gh3Setlist(StructureHeaderNode class2860, Gh3Songlist gh3Songlist0)
        {
            method_5(class2860, gh3Songlist0);
        }

        public List<Gh3Tier> method_0()
        {
            return Tiers;
        }

        public void method_1(Gh3Setlist gh3Setlist0)
        {
            InitialMovie = gh3Setlist0.InitialMovie;
            Tiers = gh3Setlist0.Tiers;
        }

        public string method_2()
        {
            return Path;
        }

        public void method_3(string string0)
        {
            Path = string0;
        }

        public bool method_4()
        {
            return CustomBit != 0;
        }

        public void method_5(StructureHeaderNode class2860, Gh3Songlist gh3Songlist0)
        {
            AsciiStructureNode @class;
            Prefix = (((@class = class2860.zzFindNode(new AsciiStructureNode("prefix"))) != null)
                ? @class.method_8()
                : "general");
            InitialMovie = (((@class = class2860.zzFindNode(new AsciiStructureNode("initial_movie"))) != null)
                ? @class.method_8()
                : "");
            IntegerStructureNode class2;
            var num = ((class2 = class2860.zzFindNode(new IntegerStructureNode("num_tiers"))) != null)
                ? class2.method_8()
                : 0;
            try
            {
                for (var i = 1; i <= num; i++)
                {
                    Tiers.Add(new Gh3Tier(class2860.zzFindNode(new StructurePointerNode("tier" + i)).method_8(),
                        gh3Songlist0));
                }
            }
            catch
            {
                throw new Exception(Path + " setlist is corrupt: Tier/s missing.");
            }
        }

        public StructureHeaderNode method_6()
        {
            var @class = new StructureHeaderNode();
            @class.addChild(new AsciiStructureNode("prefix", Prefix));
            @class.addChild(new IntegerStructureNode("num_tiers", Tiers.Count));
            @class.addChild(new AsciiStructureNode("initial_movie", InitialMovie));
            for (var i = 0; i < Tiers.Count; i++)
            {
                @class.addChild(new StructurePointerNode("tier" + (i + 1), Tiers[i].method_3()));
            }
            return @class;
        }
    }
}