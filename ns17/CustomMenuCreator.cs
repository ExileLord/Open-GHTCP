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
		private readonly ZzPakNode2 _class3180;

		private bool _bool0;

		private readonly bool _bool1;

		public CustomMenuCreator(ZzPakNode2 class3181, bool bool2)
		{
			_class3180 = class3181;
			_bool1 = bool2;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + ToString() + " -=-");
			if (!_bool0)
			{
				_bool0 = _class3180.method_6("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb");
			}
			if (!_bool0)
			{
				Console.WriteLine("Creating Custom Menu.");
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_menu"));
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_gem_scale.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_gem_scale"));
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_credits.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_menu_credits"));
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_menu_cutoff_viewer"));
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_gfx_options.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_menu_gfx_options"));
				_class3180.method_0("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb", ZzQbScriptZipperClass.smethod_3("guitar_custom_menu_setlist_switcher"));
				ZzGenericNode1 @class = _class3180.ZzGetNode1(_bool1 ? "scripts\\guitar\\menu\\menu_main.qb" : "scripts\\guitar\\guitar_menu.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("create_main_menu")));
				@class = _class3180.ZzGetNode1("scripts\\guitar\\guitar_progression.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("get_progression_globals")));
				@class = _class3180.ZzGetNode1("scripts\\guitar\\guitar_gems.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("load_venue")));
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("start_gem_scroller")));
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("kill_gem_scroller")));
				@class = _class3180.ZzGetNode1("scripts\\guitar\\guitar_events.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("guitarevent_songwon_spawned")));
				@class = _class3180.ZzGetNode1("scripts\\game\\net\\guitar_net.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("net_write_single_player_stats")));
				@class = _class3180.ZzGetNode1("scripts\\guitar\\guitar_globaltags.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("setup_globaltags")));
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("setup_songtags")));
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("push_bandtags")));
				@class = _class3180.ZzGetNode1("scripts\\guitar\\menu\\menu_credits.qb");
				ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("scrolling_list_add_item")));
				if (!_bool1)
				{
					ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("start_team_photos")));
				}
				if (_bool1)
				{
					@class = _class3180.ZzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb");
					ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("custom_menu_cutoff_viewer_create_paper")));
					ZzQbScriptZipperClass.smethod_1(@class.method_5(new ScriptRootNode("custom_menu_cutoff_viewer_create_poster")));
				}
				@class = _class3180.ZzGetNode1("scripts\\guitar\\menu\\main_menu_flow.qb");
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
