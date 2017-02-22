using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;

namespace ns17
{

    //This is probably the "speed boost" part of GHTCP

	public class zzFxBoost : QbEditor
	{
		private zzPakNode2 class318_0;

		private bool bool_0;

		public zzFxBoost(zzPakNode2 class318_1)
		{
			this.class318_0 = class318_1;
			TagStructureNode @class = ((StructureHeaderNode)this.class318_0.zzGetNode1("scripts\\guitar\\guitar_events.qb").method_5<TagStructureNode>(new TagStructureNode("event", "star_power_on")).Parent).method_5<TagStructureNode>(new TagStructureNode("scr"));
			this.bool_0 = (@class.method_8() == "guitarevent_starpoweron");
		}

		public override void vmethod_0()
		{
			zzGenericNode1 @class = this.class318_0.zzGetNode1("scripts\\guitar\\guitar_events.qb");
			((StructureHeaderNode)@class.method_5<TagStructureNode>(new TagStructureNode("event", "star_power_on")).Parent).method_5<TagStructureNode>(new TagStructureNode("scr")).method_9(this.bool_0 ? "guitarevent_starpoweroff" : "guitarevent_starpoweron");
			if (!this.bool_0)
			{
				@class.method_5<ScriptRootNode>(new ScriptRootNode("hit_note_fx")).int_0 = QbSongClass1.AddKeyToDictionary("hit_note_fx_empty");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_starsequencebonus")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus_empty");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_multiplier4xon_spawned")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned_empty");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("first_gem_fx")).int_0 = QbSongClass1.AddKeyToDictionary("first_gem_fx_empty");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("hit_note_fx_original")).int_0 = QbSongClass1.AddKeyToDictionary("hit_note_fx");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_starsequencebonus_original")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_multiplier4xon_spawned_original")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned");
				@class.method_5<ScriptRootNode>(new ScriptRootNode("first_gem_fx_original")).int_0 = QbSongClass1.AddKeyToDictionary("first_gem_fx");
				return;
			}
			@class.method_5<ScriptRootNode>(new ScriptRootNode("hit_note_fx")).int_0 = QbSongClass1.AddKeyToDictionary("hit_note_fx_original");
			@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_starsequencebonus")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus_original");
			@class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_multiplier4xon_spawned")).int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned_original");
			@class.method_5<ScriptRootNode>(new ScriptRootNode("first_gem_fx")).int_0 = QbSongClass1.AddKeyToDictionary("first_gem_fx_original");
			ScriptRootNode class2 = @class.method_5<ScriptRootNode>(new ScriptRootNode("hit_note_fx_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.AddKeyToDictionary("hit_note_fx");
			}
			else
			{
				@class.method_3(new ScriptRootNode("hit_note_fx", "scripts\\guitar\\guitar_events.qb", new QbScriptNode()));
			}
			class2 = @class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_starsequencebonus_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_starsequencebonus");
			}
			else
			{
				@class.method_3(new ScriptRootNode("guitarevent_starsequencebonus", "scripts\\guitar\\guitar_events.qb", new QbScriptNode()));
			}
			class2 = @class.method_5<ScriptRootNode>(new ScriptRootNode("guitarevent_multiplier4xon_spawned_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.AddKeyToDictionary("guitarevent_multiplier4xon_spawned");
			}
			else
			{
				@class.method_3(new ScriptRootNode("guitarevent_multiplier4xon_spawned", "scripts\\guitar\\guitar_events.qb", new QbScriptNode()));
			}
			class2 = @class.method_5<ScriptRootNode>(new ScriptRootNode("first_gem_fx_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.AddKeyToDictionary("first_gem_fx");
				return;
			}
			@class.method_3(new ScriptRootNode("first_gem_fx", "scripts\\guitar\\guitar_events.qb", new QbScriptNode()));
		}

		public override string ToString()
		{
			return (this.bool_0 ? "Apply" : "Remove") + " Speed Boost";
		}

		public override bool Equals(QbEditor other)
		{
			return other is zzFxBoost && (other as zzFxBoost).bool_0 == this.bool_0;
		}
	}
}
