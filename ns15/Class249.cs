using System;
using ns16;
using ns18;
using ns19;
using ns20;
using ns21;

namespace ns15
{
	public class Class249 : QbEditor
	{
		private readonly ZzPakNode2 _class3180;

		private bool _bool0;

		public Class249(ZzPakNode2 class3181)
		{
			_class3180 = class3181;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + ToString() + " -=-");
			ZzGenericNode1 @class = _class3180.ZzGetNode1("scripts\\guitar\\menu\\menu_cheats.qb");
			foreach (var current in @class.method_5(new ArrayPointerRootNode("guitar_hero_cheats")).method_7().method_8<StructureHeaderNode>())
			{
				var flag = current.method_5(new TagStructureNode("name", "unlockall")) != null;
				var flag2 = current.method_5(new TagStructureNode("name", "unlockalleverything")) != null;
				var class2 = current.method_5(new ArrayPointerNode("unlock_pattern")).method_8() as IntegerArrayNode;
				if (class2.Nodes.Count == 1)
				{
					_bool0 = true;
					Console.WriteLine("QB Database is already edited.");
					break;
				}
				class2.method_12(new[]
				{
					flag ? 4096 : (flag2 ? 256 : 65536)
				});
			}
		}

		public override string ToString()
		{
			return "Modify Cheats";
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class249;
		}
	}
}
