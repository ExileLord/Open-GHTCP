using ns18;
using ns19;
using System;

namespace ns20
{
	public class ArrayPointerRootNode : ProbablyRootNode
	{
		public ArrayPointerRootNode()
		{
			this.vmethod_0();
		}

		public ArrayPointerRootNode(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public ArrayPointerRootNode(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public ArrayPointerRootNode(string string_0, string string_1, AbsTreeNode1_1 class276_0) : this(QbSongClass1.smethod_9(string_0), QbSongClass1.smethod_9(string_1), class276_0)
		{
		}

		public ArrayPointerRootNode(string string_0, int int_2, AbsTreeNode1_1 class276_0) : this(QbSongClass1.smethod_9(string_0), int_2, class276_0)
		{
		}

		public ArrayPointerRootNode(int int_2, int int_3, AbsTreeNode1_1 class276_0)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(class276_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 7;
		}

		public AbsTreeNode1_1 method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return (AbsTreeNode1_1)base.FirstNode;
			}
			return null;
		}

		public void method_8(AbsTreeNode1_1 class276_0)
		{
			if (base.Nodes.Count != 0)
			{
				base.Nodes[0] = class276_0;
				return;
			}
			base.Nodes.Add(class276_0);
		}

		public override string GetNodeText()
		{
			return "Array Pointer Root";
		}

		public override byte vmethod_16()
		{
			return 12;
		}
	}
}
