using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GuitarHero.Songlist;

namespace GHNamespace8
{
	public class Class247 : QbEditor
	{
		private readonly Gh3Songlist _gh3Songlist0;

		private readonly ZzPakNode2 _class3180;

		public Class247(ZzPakNode2 class3181, Gh3Songlist gh3Songlist1)
		{
			_class3180 = class3181;
			_gh3Songlist0 = gh3Songlist1;
		}

		public override void vmethod_0()
		{
			ZzGenericNode1 class308 = _class3180.ZzGetNode1("scripts\\guitar\\songlist.qb");
			_gh3Songlist0.method_13(class308);
		}

		public override string ToString()
		{
			return "Update Songlist";
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class247;
		}
	}
}
