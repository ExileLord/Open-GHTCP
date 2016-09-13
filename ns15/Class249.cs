using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;

namespace ns15
{
	public class Class249 : Class245
	{
		private zzPakNode2 class318_0;

		private bool bool_0;

		public Class249(zzPakNode2 class318_1)
		{
			this.class318_0 = class318_1;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + this.ToString() + " -=-");
			zzGenericNode1 @class = this.class318_0.method_8("scripts\\guitar\\menu\\menu_cheats.qb");
			foreach (StructureHeaderNode current in @class.method_5<ArrayPointerRootNode>(new ArrayPointerRootNode("guitar_hero_cheats")).method_7().method_8<StructureHeaderNode>())
			{
				bool flag = current.method_5<TagStructureNode>(new TagStructureNode("name", "unlockall")) != null;
				bool flag2 = current.method_5<TagStructureNode>(new TagStructureNode("name", "unlockalleverything")) != null;
				IntegerArrayNode class2 = current.method_5<ArrayPointerNode>(new ArrayPointerNode("unlock_pattern")).method_8() as IntegerArrayNode;
				if (class2.Nodes.Count == 1)
				{
					this.bool_0 = true;
					Console.WriteLine("QB Database is already edited.");
					break;
				}
				class2.method_12(new int[]
				{
					flag ? 4096 : (flag2 ? 256 : 65536)
				});
			}
		}

		public override string ToString()
		{
			return "Modify Cheats";
		}

		public override bool Equals(Class245 other)
		{
			return other is Class249;
		}
	}
}
