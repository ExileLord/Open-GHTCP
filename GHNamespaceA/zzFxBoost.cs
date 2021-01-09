using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceA
{
    //This is probably the "speed boost" part of GHTCP
    public class ZzFxBoost : QbEditor
    {
        private readonly ZzPakNode2 _class3180;

        private readonly bool _bool0;

        public ZzFxBoost(ZzPakNode2 class3181)
        {
            _class3180 = class3181;
            StructItemQbKey @class = ((StructureHeaderNode) _class3180.ZzGetNode1("scripts\\guitar\\guitar_events.qb")
                .zzFindNode(new StructItemQbKey("event", "star_power_on"))
                .Parent).zzFindNode(new StructItemQbKey("scr"));
            _bool0 = (@class.method_8() == "guitarevent_starpoweron");
        }

        public override void CreateCustomMenu()
        {
            ZzGenericNode1 @class = _class3180.ZzGetNode1("scripts\\guitar\\guitar_events.qb");
            ((StructureHeaderNode) @class.zzFindNode(new StructItemQbKey("event", "star_power_on")).Parent)
                .zzFindNode(new StructItemQbKey("scr"))
                .method_9(_bool0 ? "guitarevent_starpoweroff" : "guitarevent_starpoweron");
            if (!_bool0)
            {
                @class.zzFindNode(new ScriptRootNode("hit_note_fx")).Int0 =
                    QbSongClass1.AddKeyToDictionary("hit_note_fx_empty");
                @class.zzFindNode(new ScriptRootNode("guitarevent_starsequencebonus")).Int0 =
                    QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus_empty");
                @class.zzFindNode(new ScriptRootNode("guitarevent_multiplier4xon_spawned")).Int0 =
                    QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned_empty");
                @class.zzFindNode(new ScriptRootNode("first_gem_fx")).Int0 =
                    QbSongClass1.AddKeyToDictionary("first_gem_fx_empty");
                @class.zzFindNode(new ScriptRootNode("hit_note_fx_original")).Int0 =
                    QbSongClass1.AddKeyToDictionary("hit_note_fx");
                @class.zzFindNode(new ScriptRootNode("guitarevent_starsequencebonus_original")).Int0 =
                    QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus");
                @class.zzFindNode(new ScriptRootNode("guitarevent_multiplier4xon_spawned_original")).Int0 =
                    QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned");
                @class.zzFindNode(new ScriptRootNode("first_gem_fx_original")).Int0 =
                    QbSongClass1.AddKeyToDictionary("first_gem_fx");
                return;
            }
            @class.zzFindNode(new ScriptRootNode("hit_note_fx")).Int0 =
                QbSongClass1.AddKeyToDictionary("hit_note_fx_original");
            @class.zzFindNode(new ScriptRootNode("guitarevent_starsequencebonus")).Int0 =
                QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus_original");
            @class.zzFindNode(new ScriptRootNode("guitarevent_multiplier4xon_spawned")).Int0 =
                QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned_original");
            @class.zzFindNode(new ScriptRootNode("first_gem_fx")).Int0 =
                QbSongClass1.AddKeyToDictionary("first_gem_fx_original");
            ScriptRootNode class2 = @class.zzFindNode(new ScriptRootNode("hit_note_fx_empty"));
            if (class2 != null)
            {
                class2.Int0 = QbSongClass1.AddKeyToDictionary("hit_note_fx");
            }
            else
            {
                @class.addChild(new ScriptRootNode("hit_note_fx", "scripts\\guitar\\guitar_events.qb",
                    new QbScriptNode()));
            }
            class2 = @class.zzFindNode(new ScriptRootNode("guitarevent_starsequencebonus_empty"));
            if (class2 != null)
            {
                class2.Int0 = QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus");
            }
            else
            {
                @class.addChild(new ScriptRootNode("guitarevent_starsequencebonus", "scripts\\guitar\\guitar_events.qb",
                    new QbScriptNode()));
            }
            class2 = @class.zzFindNode(new ScriptRootNode("guitarevent_multiplier4xon_spawned_empty"));
            if (class2 != null)
            {
                class2.Int0 = QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned");
            }
            else
            {
                @class.addChild(new ScriptRootNode("guitarevent_multiplier4xon_spawned",
                    "scripts\\guitar\\guitar_events.qb", new QbScriptNode()));
            }
            class2 = @class.zzFindNode(new ScriptRootNode("first_gem_fx_empty"));
            if (class2 != null)
            {
                class2.Int0 = QbSongClass1.AddKeyToDictionary("first_gem_fx");
                return;
            }
            @class.addChild(new ScriptRootNode("first_gem_fx", "scripts\\guitar\\guitar_events.qb",
                new QbScriptNode()));
        }

        public override string ToString()
        {
            return (_bool0 ? "Apply" : "Remove") + " Speed Boost";
        }

        public override bool Equals(QbEditor other)
        {
            return other is ZzFxBoost && (other as ZzFxBoost)._bool0 == _bool0;
        }
    }
}