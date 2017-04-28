using System;
using ns18;
using ns21;

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
			path = string_0;
			setlist = int_0;
			progression = int_1;
		}

		public GHLink(string string_0, StructureHeaderNode class286_0)
		{
			path = string_0;
			method_0(class286_0);
		}

		public void method_0(StructureHeaderNode class286_0)
		{
			setlist = class286_0.method_5(new TagStructureNode("tier_global")).method_10();
			progression = class286_0.method_5(new TagStructureNode("progression_global")).method_10();
		}

		public StructureHeaderNode method_1()
		{
			StructureHeaderNode @class = new StructureHeaderNode();
			@class.method_3(new TagStructureNode("tier_global", setlist));
			@class.method_3(new TagStructureNode("progression_global", progression));
			return @class;
		}
	}
}
