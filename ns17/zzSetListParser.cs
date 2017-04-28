using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using ns21;
using ns22;

namespace ns17
{
	public class zzSetListParser : QbEditor
	{
		private readonly zzPakNode2 class318_0;

		private readonly GH3Songlist gh3Songlist_0;

		private readonly bool bool_0;

		public zzSetListParser(zzPakNode2 class318_1, GH3Songlist gh3Songlist_1, bool bool_1)
		{
			class318_0 = class318_1;
			gh3Songlist_0 = gh3Songlist_1;
			bool_0 = bool_1;
		}

		public override void vmethod_0()
		{
			var text = "scripts\\guitar\\guitar_progression.qb";
			zzGenericNode1 @class = class318_0.zzGetNode1(text);
			gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_career_songs")));
			gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_general_songs")));
			if (!bool_0)
			{
				gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_generalp2_songs")));
				gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_generalp2_songs_coop")));
			}
			gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("p1_career_progression")));
			if (!bool_0)
			{
				gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("p2_career_progression")));
			}
			gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("bonus_progression")));
			gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("download_progression")));
			gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("general_progression")));
			if (!bool_0)
			{
				gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("generalp2_progression")));
				gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("p2_coop_progression")));
			}
			@class = class318_0.zzGetNode1(text = "scripts\\guitar\\guitar_download.qb");
			gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_download_songs")));
			if (!bool_0)
			{
				@class = class318_0.zzGetNode1(text = "scripts\\guitar\\guitar_coop.qb");
				gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_coopcareer_songs")));
			}
			@class = class318_0.zzGetNode1(text = "scripts\\guitar\\store_data.qb");
			gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_bonus_songs")));
			if (class318_0.method_6(text = "scripts\\guitar\\custom_menu\\guitar_custom_progression.qb"))
			{
				@class = class318_0.zzGetNode1(text);
				var num = @class.method_5(new IntegerRootNode("custom_setlist_bitmask")).method_7();
				for (var i = 0; i < 32; i++)
				{
					if (num >> i != 0)
					{
						gh3Songlist_0.method_4(text, @class.method_5(new StructurePointerRootNode("gh3_custom" + (i + 1) + "_songs"))).CustomBit = 1 << i;
						gh3Songlist_0.method_5(text, @class.method_5(new StructurePointerRootNode("custom" + (i + 1) + "_progression")));
					}
				}
				gh3Songlist_0.CustomBitMask = num;
			}
			@class = class318_0.zzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb");
			gh3Songlist_0.method_6((StructureArrayNode)@class.method_5(new ArrayPointerRootNode("custom_menu_setlist_switcher_progressions_" + (bool_0 ? "gha" : "gh3"))).method_7());
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
