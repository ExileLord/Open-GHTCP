using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GuitarHero.Songlist;

namespace GHNamespaceA
{
    public class ZzSetListUpdater : QbEditor
    {
        private readonly Gh3Songlist _gh3Songlist0;

        private readonly ZzPakNode2 _class3180;

        private readonly string _string0;

        private readonly int _int0;

        public ZzSetListUpdater(int int1, ZzPakNode2 class3181, Gh3Songlist gh3Songlist1)
        {
            _string0 = gh3Songlist1.method_8(int1);
            _int0 = int1;
            _class3180 = class3181;
            _gh3Songlist0 = gh3Songlist1;
        }

        public override void vmethod_0()
        {
            ZzGenericNode1 @class = _class3180.ZzGetNode1(_gh3Songlist0.Gh3SetlistList[_int0].method_2());
            @class.method_5(new StructurePointerRootNode(_int0))
                .method_8(_gh3Songlist0.Gh3SetlistList[_int0].method_6());
        }

        public override string ToString()
        {
            return "Update Setlist: " + _string0;
        }

        public override bool Equals(QbEditor other)
        {
            return other is ZzSetListUpdater && (other as ZzSetListUpdater)._int0 == _int0;
        }
    }
}