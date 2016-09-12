using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;

namespace ns17
{
	public class Class254 : Class245
	{
		private Class318 class318_0;

		private bool bool_0;

		private bool bool_1;

		public Class254(Class318 class318_1, bool bool_2)
		{
			this.class318_0 = class318_1;
			this.bool_1 = bool_2;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + this.ToString() + " -=-");
			if (!this.bool_0)
			{
				this.bool_0 = this.class318_0.method_6("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb");
			}
			if (!this.bool_0)
			{
				Console.WriteLine("Creating Custom Menu.");
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb", Class372.smethod_3("guitar_custom_menu"));
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_gem_scale.qb", Class372.smethod_3("guitar_custom_gem_scale"));
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_credits.qb", Class372.smethod_3("guitar_custom_menu_credits"));
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb", Class372.smethod_3("guitar_custom_menu_cutoff_viewer"));
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_gfx_options.qb", Class372.smethod_3("guitar_custom_menu_gfx_options"));
				this.class318_0.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb", Class372.smethod_3("guitar_custom_menu_setlist_switcher"));
				zzGenericNode1 @class = this.class318_0.method_8(this.bool_1 ? "scripts\\guitar\\menu\\menu_main.qb" : "scripts\\guitar\\guitar_menu.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("create_main_menu")));
				@class = this.class318_0.method_8("scripts\\guitar\\guitar_progression.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("get_progression_globals")));
				@class = this.class318_0.method_8("scripts\\guitar\\guitar_gems.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("load_venue")));
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("start_gem_scroller")));
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("kill_gem_scroller")));
				@class = this.class318_0.method_8("scripts\\guitar\\guitar_events.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_songwon_spawned")));
				@class = this.class318_0.method_8("scripts\\game\\net\\guitar_net.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("net_write_single_player_stats")));
				@class = this.class318_0.method_8("scripts\\guitar\\guitar_globaltags.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("setup_globaltags")));
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("setup_songtags")));
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("push_bandtags")));
				@class = this.class318_0.method_8("scripts\\guitar\\menu\\menu_credits.qb");
				Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("scrolling_list_add_item")));
				if (!this.bool_1)
				{
					Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("start_team_photos")));
				}
				if (this.bool_1)
				{
					@class = this.class318_0.method_8("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb");
					Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("custom_menu_cutoff_viewer_create_paper")));
					Class372.smethod_1(@class.method_5<ScriptRootNode>(new ScriptRootNode("custom_menu_cutoff_viewer_create_poster")));
				}
				@class = this.class318_0.method_8("scripts\\guitar\\menu\\main_menu_flow.qb");
				StructureHeaderNode class2 = new StructureHeaderNode();
				class2.method_3(new Class296("action", "select_custom_menu"));
				class2.method_3(new Class296("flow_state", "custom_menu_fs"));
				class2.method_3(new Class296(0, "transition_right"));
				@class.method_5<StructurePointerRootNode>(new StructurePointerRootNode("main_menu_fs")).method_5<Class301>(new Class301("actions")).method_8().method_3(class2);
			}
		}

		public override string ToString()
		{
			return "Create Custom Menu";
		}

		public override bool Equals(Class245 other)
		{
			return other is Class254;
		}
	}
}
