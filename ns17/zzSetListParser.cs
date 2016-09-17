using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using ns21;
using ns22;
using System;

namespace ns17
{
	public class zzSetListParser : QbEditor
	{
		private zzPakNode2 class318_0;

		private GH3Songlist gh3Songlist_0;

		private bool bool_0;

		public zzSetListParser(zzPakNode2 class318_1, GH3Songlist gh3Songlist_1, bool bool_1)
		{
			this.class318_0 = class318_1;
			this.gh3Songlist_0 = gh3Songlist_1;
			this.bool_0 = bool_1;
		}

		public override void vmethod_0()
		{
			string text = "scripts\\guitar\\guitar_progression.qb";
			zzGenericNode1 @class = this.class318_0.zzGetNode1(text);
			this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_career_songs")));
			this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_general_songs")));
			if (!this.bool_0)
			{
				this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_generalp2_songs")));
				this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_generalp2_songs_coop")));
			}
			this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("p1_career_progression")));
			if (!this.bool_0)
			{
				this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("p2_career_progression")));
			}
			this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("bonus_progression")));
			this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("download_progression")));
			this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("general_progression")));
			if (!this.bool_0)
			{
				this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("generalp2_progression")));
				this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("p2_coop_progression")));
			}
			@class = this.class318_0.zzGetNode1(text = "scripts\\guitar\\guitar_download.qb");
			this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_download_songs")));
			if (!this.bool_0)
			{
				@class = this.class318_0.zzGetNode1(text = "scripts\\guitar\\guitar_coop.qb");
				this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_coopcareer_songs")));
			}
			@class = this.class318_0.zzGetNode1(text = "scripts\\guitar\\store_data.qb");
			this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_bonus_songs")));
			if (this.class318_0.method_6(text = "scripts\\guitar\\custom_menu\\guitar_custom_progression.qb"))
			{
				@class = this.class318_0.zzGetNode1(text);
				int num = @class.method_5<IntegerRootNode>(new IntegerRootNode("custom_setlist_bitmask")).method_7();
				for (int i = 0; i < 32; i++)
				{
					if (num >> i != 0)
					{
						this.gh3Songlist_0.method_4(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("gh3_custom" + (i + 1) + "_songs"))).CustomBit = 1 << i;
						this.gh3Songlist_0.method_5(text, @class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("custom" + (i + 1) + "_progression")));
					}
				}
				this.gh3Songlist_0.CustomBitMask = num;
			}
			@class = this.class318_0.zzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb");
			this.gh3Songlist_0.method_6((StructureArrayNode)@class.method_5<ArrayPointerRootNode>(new ArrayPointerRootNode("custom_menu_setlist_switcher_progressions_" + (this.bool_0 ? "gha" : "gh3"))).method_7());
		}

		public override string ToString()
		{
			return "Parse Setlists";
		}

		public override bool Equals(QbEditor other)
		{
			return other is zzSetListParser;
		}
	}
}
