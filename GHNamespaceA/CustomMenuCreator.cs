using System;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceA
{
    public class CustomMenuCreator : QbEditor
    {
        private readonly ZzPakNode2 _zzQbPak;

        private bool _created;

        private readonly bool _isGHA;

        public CustomMenuCreator(ZzPakNode2 zzQbPak, bool isGHA)
        {
            _zzQbPak = zzQbPak;
            _isGHA = isGHA;
        }

        public override void CreateCustomMenu()
        {
            Console.WriteLine("-=- " + ToString() + " -=-");
            if (!_created)
            {
                _created = _zzQbPak.zzQbFileExists("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb");
            }
            if (!_created)
            {
                Console.WriteLine("Creating Custom Menu.");
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_menu.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_menu"));
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_gem_scale.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_gem_scale"));
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_menu_credits.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_menu_credits"));
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_menu_cutoff_viewer"));
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_menu_gfx_options.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_menu_gfx_options"));
                _zzQbPak.zzCreateQbFileFrom("scripts\\guitar\\custom_menu\\guitar_custom_menu_setlist_switcher.qb",
                    zzEmbeddedResourceDB.unpackQbFile("guitar_custom_menu_setlist_switcher"));
                ZzGenericNode1 activeQbFile = _zzQbPak.ZzGetNode1(_isGHA
                    ? "scripts\\guitar\\menu\\menu_main.qb"
                    : "scripts\\guitar\\guitar_menu.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("create_main_menu")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\guitar_progression.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("get_progression_globals")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\guitar_gems.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("load_venue")));
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("start_gem_scroller")));
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("kill_gem_scroller")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\guitar_events.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("guitarevent_songwon_spawned")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\game\\net\\guitar_net.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("net_write_single_player_stats")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\guitar_globaltags.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("setup_globaltags")));
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("setup_songtags")));
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("push_bandtags")));
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\menu\\menu_credits.qb");
                zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("scrolling_list_add_item")));
                if (!_isGHA)
                {
                    zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(new ScriptRootNode("start_team_photos")));
                }
                if (_isGHA)
                {
                    activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\custom_menu\\guitar_custom_menu_cutoff_viewer.qb");
                    zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(
                        new ScriptRootNode("custom_menu_cutoff_viewer_create_paper")));
                    zzEmbeddedResourceDB.unpackQbScriptTo(activeQbFile.zzFindNode(
                        new ScriptRootNode("custom_menu_cutoff_viewer_create_poster")));
                }
                activeQbFile = _zzQbPak.ZzGetNode1("scripts\\guitar\\menu\\main_menu_flow.qb");
                var customMenuFS = new StructureHeaderNode();
                customMenuFS.addChild(new StructItemQbKey("action", "select_custom_menu"));
                customMenuFS.addChild(new StructItemQbKey("flow_state", "custom_menu_fs"));
                customMenuFS.addChild(new StructItemQbKey(0, "transition_right"));
                activeQbFile.zzFindNode(new StructurePointerRootNode("main_menu_fs"))
                    .zzFindNode(new ArrayPointerNode("actions"))
                    .GetFirstChild()
                    .addChild(customMenuFS);
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