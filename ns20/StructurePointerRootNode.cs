using ns19;
using ns21;

namespace ns20
{
	public class StructurePointerRootNode : ProbablyRootNode
	{
		public StructurePointerRootNode()
		{
			vmethod_0();
		}

		public StructurePointerRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public StructurePointerRootNode(int int_2)
		{
			int_0 = int_2;
			vmethod_0();
		}

		public StructurePointerRootNode(int int_2, string string_0, StructureHeaderNode class286_0) : this(int_2, QbSongClass1.AddKeyToDictionary(string_0), class286_0)
		{
		}

		public StructurePointerRootNode(int int_2, int int_3, StructureHeaderNode class286_0)
		{
			int_0 = int_2;
			int_1 = int_3;
			Nodes.Add(class286_0);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 6;
		}

		public StructureHeaderNode method_7()
		{
			if (Nodes.Count != 0)
			{
				return (StructureHeaderNode)FirstNode;
			}
			return null;
		}

		public void method_8(StructureHeaderNode class286_0)
		{
			if (Nodes.Count != 0)
			{
				Nodes[0] = class286_0;
				return;
			}
			Nodes.Add(class286_0);
		}

		public override string GetNodeText()
		{
			return "Structure Pointer Root";
		}

		public override byte vmethod_16()
		{
			return 10;
		}
	}
}
