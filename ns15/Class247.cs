using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using System;

namespace ns15
{
	public class Class247 : Class245
	{
		private readonly GH3Songlist gh3Songlist_0;

		private readonly zzPakNode2 class318_0;

		public Class247(zzPakNode2 class318_1, GH3Songlist gh3Songlist_1)
		{
			this.class318_0 = class318_1;
			this.gh3Songlist_0 = gh3Songlist_1;
		}

		public override void vmethod_0()
		{
			zzGenericNode1 class308_ = this.class318_0.method_8("scripts\\guitar\\songlist.qb");
			this.gh3Songlist_0.method_13(class308_);
		}

		public override string ToString()
		{
			return "Update Songlist";
		}

		public override bool Equals(Class245 other)
		{
			return other is Class247;
		}
	}
}
