using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;

namespace ns17
{
	public class zzSetListUpdater : QbEditor
	{
		private readonly GH3Songlist gh3Songlist_0;

		private readonly zzPakNode2 class318_0;

		private readonly string string_0;

		private readonly int int_0;

		public zzSetListUpdater(int int_1, zzPakNode2 class318_1, GH3Songlist gh3Songlist_1)
		{
			string_0 = gh3Songlist_1.method_8(int_1);
			int_0 = int_1;
			class318_0 = class318_1;
			gh3Songlist_0 = gh3Songlist_1;
		}

		public override void vmethod_0()
		{
			zzGenericNode1 @class = class318_0.zzGetNode1(gh3Songlist_0.gh3SetlistList[int_0].method_2());
			@class.method_5(new StructurePointerRootNode(int_0)).method_8(gh3Songlist_0.gh3SetlistList[int_0].method_6());
		}

		public override string ToString()
		{
			return "Update Setlist: " + string_0;
		}

		public override bool Equals(QbEditor other)
		{
			return other is zzSetListUpdater && (other as zzSetListUpdater).int_0 == int_0;
		}
	}
}
