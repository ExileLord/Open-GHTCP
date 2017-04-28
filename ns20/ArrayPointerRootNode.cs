using ns18;
using ns19;

namespace ns20
{
	public class ArrayPointerRootNode : ProbablyRootNode
	{
		public ArrayPointerRootNode()
		{
			vmethod_0();
		}

		public ArrayPointerRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public ArrayPointerRootNode(int int_2)
		{
			int_0 = int_2;
			vmethod_0();
		}

		public ArrayPointerRootNode(string string_0, string string_1, AbsTreeNode1_1 class276_0) : this(QbSongClass1.AddKeyToDictionary(string_0), QbSongClass1.AddKeyToDictionary(string_1), class276_0)
		{
		}

		public ArrayPointerRootNode(string string_0, int int_2, AbsTreeNode1_1 class276_0) : this(QbSongClass1.AddKeyToDictionary(string_0), int_2, class276_0)
		{
		}

		public ArrayPointerRootNode(int int_2, int int_3, AbsTreeNode1_1 class276_0)
		{
			int_0 = int_2;
			int_1 = int_3;
			Nodes.Add(class276_0);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 7;
		}

		public AbsTreeNode1_1 method_7()
		{
			if (Nodes.Count != 0)
			{
				return (AbsTreeNode1_1)FirstNode;
			}
			return null;
		}

		public void method_8(AbsTreeNode1_1 class276_0)
		{
			if (Nodes.Count != 0)
			{
				Nodes[0] = class276_0;
				return;
			}
			Nodes.Add(class276_0);
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
