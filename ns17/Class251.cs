using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;

namespace ns17
{
	public class Class251 : Class245
	{
		private Class318 class318_0;

		private bool bool_0;

		public Class251(Class318 class318_1)
		{
			this.class318_0 = class318_1;
			Class296 @class = ((Class286)this.class318_0.method_8("scripts\\guitar\\guitar_events.qb").method_5<Class296>(new Class296("event", "star_power_on")).Parent).method_5<Class296>(new Class296("scr"));
			this.bool_0 = (@class.method_8() == "guitarevent_starpoweron");
		}

		public override void vmethod_0()
		{
			Class308 @class = this.class318_0.method_8("scripts\\guitar\\guitar_events.qb");
			((Class286)@class.method_5<Class296>(new Class296("event", "star_power_on")).Parent).method_5<Class296>(new Class296("scr")).method_9(this.bool_0 ? "guitarevent_starpoweroff" : "guitarevent_starpoweron");
			if (!this.bool_0)
			{
				@class.method_5<Class274>(new Class274("hit_note_fx")).int_0 = QbSongClass1.smethod_9("hit_note_fx_empty");
				@class.method_5<Class274>(new Class274("guitarevent_starsequencebonus")).int_0 = QbSongClass1.smethod_9("guitarevent_starsequencebonus_empty");
				@class.method_5<Class274>(new Class274("guitarevent_multiplier4xon_spawned")).int_0 = QbSongClass1.smethod_9("guitarevent_multiplier4xon_spawned_empty");
				@class.method_5<Class274>(new Class274("first_gem_fx")).int_0 = QbSongClass1.smethod_9("first_gem_fx_empty");
				@class.method_5<Class274>(new Class274("hit_note_fx_original")).int_0 = QbSongClass1.smethod_9("hit_note_fx");
				@class.method_5<Class274>(new Class274("guitarevent_starsequencebonus_original")).int_0 = QbSongClass1.smethod_9("guitarevent_starsequencebonus");
				@class.method_5<Class274>(new Class274("guitarevent_multiplier4xon_spawned_original")).int_0 = QbSongClass1.smethod_9("guitarevent_multiplier4xon_spawned");
				@class.method_5<Class274>(new Class274("first_gem_fx_original")).int_0 = QbSongClass1.smethod_9("first_gem_fx");
				return;
			}
			@class.method_5<Class274>(new Class274("hit_note_fx")).int_0 = QbSongClass1.smethod_9("hit_note_fx_original");
			@class.method_5<Class274>(new Class274("guitarevent_starsequencebonus")).int_0 = QbSongClass1.smethod_9("guitarevent_starsequencebonus_original");
			@class.method_5<Class274>(new Class274("guitarevent_multiplier4xon_spawned")).int_0 = QbSongClass1.smethod_9("guitarevent_multiplier4xon_spawned_original");
			@class.method_5<Class274>(new Class274("first_gem_fx")).int_0 = QbSongClass1.smethod_9("first_gem_fx_original");
			Class274 class2 = @class.method_5<Class274>(new Class274("hit_note_fx_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.smethod_9("hit_note_fx");
			}
			else
			{
				@class.method_3(new Class274("hit_note_fx", "scripts\\guitar\\guitar_events.qb", new Class275()));
			}
			class2 = @class.method_5<Class274>(new Class274("guitarevent_starsequencebonus_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.smethod_9("guitarevent_starsequencebonus");
			}
			else
			{
				@class.method_3(new Class274("guitarevent_starsequencebonus", "scripts\\guitar\\guitar_events.qb", new Class275()));
			}
			class2 = @class.method_5<Class274>(new Class274("guitarevent_multiplier4xon_spawned_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.smethod_9("guitarevent_multiplier4xon_spawned");
			}
			else
			{
				@class.method_3(new Class274("guitarevent_multiplier4xon_spawned", "scripts\\guitar\\guitar_events.qb", new Class275()));
			}
			class2 = @class.method_5<Class274>(new Class274("first_gem_fx_empty"));
			if (class2 != null)
			{
				class2.int_0 = QbSongClass1.smethod_9("first_gem_fx");
				return;
			}
			@class.method_3(new Class274("first_gem_fx", "scripts\\guitar\\guitar_events.qb", new Class275()));
		}

		public override string ToString()
		{
			return (this.bool_0 ? "Apply" : "Remove") + " Speed Boost";
		}

		public override bool Equals(Class245 other)
		{
			return other is Class251 && (other as Class251).bool_0 == this.bool_0;
		}
	}
}
