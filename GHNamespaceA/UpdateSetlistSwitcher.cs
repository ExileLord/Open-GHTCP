using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GuitarHero.Songlist;

namespace GHNamespaceA
{
    public class UpdateSetlistSwitcher : QbEditor
    {
        private readonly Gh3Songlist _gh3Songlist0;

        private readonly ZzPakNode2 _class3180;

        private readonly bool _bool0;

        public UpdateSetlistSwitcher(ZzPakNode2 class3181, Gh3Songlist gh3Songlist1, bool bool1)
        {
            _class3180 = class3181;
            _gh3Songlist0 = gh3Songlist1;
            _bool0 = bool1;
        }

        public override void CreateCustomMenu()
        {
            ZzGenericNode1 @class = _class3180.ZzGetNode1(
                "scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb");
            @class
                .zzFindNode(new ArrayPointerRootNode("custom_menu_setlist_switcher_progressions_" +
                                                   (_bool0 ? "gha" : "gh3")))
                .method_8(_gh3Songlist0.method_7());
        }

        public override string ToString()
        {
            return "Update Setlist Switcher";
        }

        public override bool Equals(QbEditor other)
        {
            return other is UpdateSetlistSwitcher;
        }
    }
}