using ns18;
using ns21;
using System;

namespace GuitarHero
{
	[Serializable]
	public class GHLink
	{
		public string path;

		public int setlist;

		public int progression;

		public GHLink(int int_0) : this(int_0, -2140143824)
		{
		}

		public GHLink(int int_0, int int_1) : this("scripts\\guitar\\custom_menu\\guitar_custom_progression.qb", int_0, int_1)
		{
		}

		public GHLink(string string_0, int int_0, int int_1)
		{
			this.path = string_0;
			this.setlist = int_0;
			this.progression = int_1;
		}

		public GHLink(string string_0, Class286 class286_0)
		{
			this.path = string_0;
			this.method_0(class286_0);
		}

		public void method_0(Class286 class286_0)
		{
			this.setlist = class286_0.method_5<Class296>(new Class296("tier_global")).method_10();
			this.progression = class286_0.method_5<Class296>(new Class296("progression_global")).method_10();
		}

		public Class286 method_1()
		{
			Class286 @class = new Class286();
			@class.method_3(new Class296("tier_global", this.setlist));
			@class.method_3(new Class296("progression_global", this.progression));
			return @class;
		}
	}
}
