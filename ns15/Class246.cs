using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using ns21;

namespace ns15
{
	public class Class246 : QbEditor
	{
		private GH3Songlist gh3Songlist_0;

		private zzPakNode2 class318_0;

		private string string_0;

		private int int_0;

		private bool bool_0;

		public Class246(int int_1, zzPakNode2 class318_1, GH3Songlist gh3Songlist_1, bool bool_1)
		{
			string_0 = gh3Songlist_1.class214_0.method_0(int_1);
			int_0 = int_1;
			class318_0 = class318_1;
			gh3Songlist_0 = gh3Songlist_1;
			bool_0 = bool_1;
		}

		public override void vmethod_0()
		{
			string text;
			zzGenericNode1 @class;
			if (!class318_0.method_6(text = "scripts\\guitar\\custom_menu\\guitar_custom_progression.qb"))
			{
				class318_0.method_0(text, new zzGenericNode1());
				@class = class318_0.zzGetNode1(text);
				@class.method_3(new IntegerRootNode("custom_setlist_bitmask", text, 0));
			}
			else
			{
				@class = class318_0.zzGetNode1(text);
			}
			if (bool_0)
			{
				@class.method_3(new StructurePointerRootNode(int_0, text, gh3Songlist_0.dictionary_1[int_0].method_1()));
				@class.method_3(new StructurePointerRootNode(gh3Songlist_0.method_10(int_0), text, gh3Songlist_0.method_11(int_0).method_6()));
			}
			else
			{
				try
				{
					@class.method_5(new StructurePointerRootNode(int_0)).Remove();
					@class.method_5(new StructurePointerRootNode(gh3Songlist_0.method_10(int_0))).Remove();
				}
				catch
				{
				}
				gh3Songlist_0.CustomBitMask &= ~gh3Songlist_0.method_11(int_0).CustomBit;
				gh3Songlist_0.gh3SetlistList.Remove(gh3Songlist_0.method_10(int_0));
				gh3Songlist_0.dictionary_1.Remove(int_0);
				gh3Songlist_0.class214_0.Remove(gh3Songlist_0.class214_0.method_0(int_0));
			}
			@class.method_5(new IntegerRootNode("custom_setlist_bitmask")).method_8(gh3Songlist_0.CustomBitMask);
		}

		public override string ToString()
		{
			return (bool_0 ? "Create" : "Delete") + " Setlist: " + string_0;
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class246 && (other as Class246).int_0 == int_0;
		}
	}
}
