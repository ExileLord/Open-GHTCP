using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;
using GHNamespaceG;
using GuitarHero.Songlist;

namespace GHNamespaceA
{
    public class ZzSetListParser : QbEditor
    {
        private readonly ZzPakNode2 _class3180;

        private readonly Gh3Songlist _gh3Songlist0;

        private readonly bool _bool0;

        public ZzSetListParser(ZzPakNode2 class3181, Gh3Songlist gh3Songlist1, bool bool1)
        {
            _class3180 = class3181;
            _gh3Songlist0 = gh3Songlist1;
            _bool0 = bool1;
        }

        public override void vmethod_0()
        {
            var text = "scripts\\guitar\\guitar_progression.qb";
            ZzGenericNode1 @class = _class3180.ZzGetNode1(text);
            _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_career_songs")));
            _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_general_songs")));
            if (!_bool0)
            {
                _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_generalp2_songs")));
                _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_generalp2_songs_coop")));
            }
            _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("p1_career_progression")));
            if (!_bool0)
            {
                _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("p2_career_progression")));
            }
            _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("bonus_progression")));
            _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("download_progression")));
            _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("general_progression")));
            if (!_bool0)
            {
                _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("generalp2_progression")));
                _gh3Songlist0.method_5(text, @class.method_5(new StructurePointerRootNode("p2_coop_progression")));
            }
            @class = _class3180.ZzGetNode1(text = "scripts\\guitar\\guitar_download.qb");
            _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_download_songs")));
            if (!_bool0)
            {
                @class = _class3180.ZzGetNode1(text = "scripts\\guitar\\guitar_coop.qb");
                _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_coopcareer_songs")));
            }
            @class = _class3180.ZzGetNode1(text = "scripts\\guitar\\store_data.qb");
            _gh3Songlist0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_bonus_songs")));
            if (_class3180.method_6(text = "scripts\\guitar\\custom_menu\\guitar_custom_progression.qb"))
            {
                @class = _class3180.ZzGetNode1(text);
                var num = @class.method_5(new IntegerRootNode("custom_setlist_bitmask")).method_7();
                for (var i = 0; i < 32; i++)
                {
                    if (num >> i != 0)
                    {
                        _gh3Songlist0.method_4(text,
                                @class.method_5(new StructurePointerRootNode("gh3_custom" + (i + 1) + "_songs")))
                            .CustomBit = 1 << i;
                        _gh3Songlist0.method_5(text,
                            @class.method_5(new StructurePointerRootNode("custom" + (i + 1) + "_progression")));
                    }
                }
                _gh3Songlist0.CustomBitMask = num;
            }
            @class = _class3180.ZzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb");
            _gh3Songlist0.method_6((StructureArrayNode) @class
                .method_5(new ArrayPointerRootNode("custom_menu_setlist_switcher_progressions_" +
                                                   (_bool0 ? "gha" : "gh3")))
                .method_7());
        }

        public override string ToString()
        {
            return "Parse Setlists";
        }

        public override bool Equals(QbEditor other)
        {
            return other is ZzSetListParser;
        }
    }
}