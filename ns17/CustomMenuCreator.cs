using System;
using ns16;
using ns18;
using ns19;
using ns20;
using ns21;

namespace ns17
{
	public class CustomMenuCreator : QbEditor
	{
		private readonly zzPakNode2 class318_0;

		private bool bool_0;

		private readonly bool bool_1;

		public CustomMenuCreator(zzPakNode2 class318_1, bool bool_2)
		{
			class318_0 = class318_1;
			bool_1 = bool_2;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + ToString() + " -=-");
			if (!bool_0)
			{
				bool_0 = class318_0.method_6("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb");
			}
			if (!bool_0)
			{
				Console.WriteLine("Creating Custom Menu.");
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_menu"));
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_gem_scale.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_gem_scale"));
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_credits.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_menu_credits"));
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_menu_cutoff_viewer"));
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_gfx_options.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_menu_gfx_options"));
				class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb", zzQbScriptZipperClass.smethod_3("guitar_custom_menu_setlist_switcher"));
				zzGenericNode1 @class = class318_0.zzGetNode1(bool_1 ? "scripts\\guitar\\menu\\menu_main.qb" : "scripts\\guitar\\guitar_menu.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("create_main_menu")));
				@class = class318_0.zzGetNode1("scripts\\guitar\\guitar_progression.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("get_progression_globals")));
				@class = class318_0.zzGetNode1("scripts\\guitar\\guitar_gems.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("load_venue")));
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("start_gem_scroller")));
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("kill_gem_scroller")));
				@class = class318_0.zzGetNode1("scripts\\guitar\\guitar_events.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("guitarevent_songwon_spawned")));
				@class = class318_0.zzGetNode1("scripts\\game\\net\\guitar_net.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("net_write_single_player_stats")));
				@class = class318_0.zzGetNode1("scripts\\guitar\\guitar_globaltags.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("setup_globaltags")));
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("setup_songtags")));
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("push_bandtags")));
				@class = class318_0.zzGetNode1("scripts\\guitar\\menu\\menu_credits.qb");
				zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("scrolling_list_add_item")));
				if (!bool_1)
				{
					zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("start_team_photos")));
				}
				if (bool_1)
				{
					@class = class318_0.zzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb");
					zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("custom_menu_cutoff_viewer_create_paper")));
					zzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("custom_menu_cutoff_viewer_create_poster")));
				}
				@class = class318_0.zzGetNode1("scripts\\guitar\\menu\\main_menu_flow.qb");
				var class2 = new StructureHeaderNode();
				class2.method_3(new TagStructureNode("action", "select_custom_menu"));
				class2.method_3(new TagStructureNode("flow_state", "custom_menu_fs"));
				class2.method_3(new TagStructureNode(0, "transition_right"));
				@class.method_5(new StructurePointerRootNode("main_menu_fs")).method_5(new ArrayPointerNode("actions")).method_8().method_3(class2);
			}
		}

		public override string ToString()
		{
			return "Create Custom Menu";
		}

		public override bool Equals(QbEditor other)
		{
			return other is CustomMenuCreator;
		}
	}
}
