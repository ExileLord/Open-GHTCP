using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;

namespace ns15
{
	public class Class247 : QbEditor
	{
		private readonly GH3Songlist gh3Songlist_0;

		private readonly zzPakNode2 class318_0;

		public Class247(zzPakNode2 class318_1, GH3Songlist gh3Songlist_1)
		{
			class318_0 = class318_1;
			gh3Songlist_0 = gh3Songlist_1;
		}

		public override void vmethod_0()
		{
			zzGenericNode1 class308_ = class318_0.zzGetNode1("scripts\\guitar\\songlist.qb");
			gh3Songlist_0.method_13(class308_);
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
