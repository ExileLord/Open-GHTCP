using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using ns21;
using System;

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
			this.string_0 = gh3Songlist_1.class214_0.method_0(int_1);
			this.int_0 = int_1;
			this.class318_0 = class318_1;
			this.gh3Songlist_0 = gh3Songlist_1;
			this.bool_0 = bool_1;
		}

		public override void vmethod_0()
		{
			string text;
			zzGenericNode1 @class;
			if (!this.class318_0.method_6(text = "scripts\\guitar\\custom_menu\\guitar_custom_progression.qb"))
			{
				this.class318_0.method_0(text, new zzGenericNode1());
				@class = this.class318_0.zzGetNode1(text);
				@class.method_3(new IntegerRootNode("custom_setlist_bitmask", text, 0));
			}
			else
			{
				@class = this.class318_0.zzGetNode1(text);
			}
			if (this.bool_0)
			{
				@class.method_3(new StructurePointerRootNode(this.int_0, text, this.gh3Songlist_0.dictionary_1[this.int_0].method_1()));
				@class.method_3(new StructurePointerRootNode(this.gh3Songlist_0.method_10(this.int_0), text, this.gh3Songlist_0.method_11(this.int_0).method_6()));
			}
			else
			{
				try
				{
					@class.method_5<StructurePointerRootNode>(new StructurePointerRootNode(this.int_0)).Remove();
					@class.method_5<StructurePointerRootNode>(new StructurePointerRootNode(this.gh3Songlist_0.method_10(this.int_0))).Remove();
				}
				catch
				{
				}
				this.gh3Songlist_0.CustomBitMask &= ~this.gh3Songlist_0.method_11(this.int_0).CustomBit;
				this.gh3Songlist_0.gh3SetlistList.Remove(this.gh3Songlist_0.method_10(this.int_0));
				this.gh3Songlist_0.dictionary_1.Remove(this.int_0);
				this.gh3Songlist_0.class214_0.Remove(this.gh3Songlist_0.class214_0.method_0(this.int_0));
			}
			@class.method_5<IntegerRootNode>(new IntegerRootNode("custom_setlist_bitmask")).method_8(this.gh3Songlist_0.CustomBitMask);
		}

		public override string ToString()
		{
			return (this.bool_0 ? "Create" : "Delete") + " Setlist: " + this.string_0;
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class246 && (other as Class246).int_0 == this.int_0;
		}
	}
}
