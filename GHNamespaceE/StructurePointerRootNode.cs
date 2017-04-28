using GHNamespaceC;
using GHNamespaceF;

namespace GHNamespaceE
{
	public class StructurePointerRootNode : ProbablyRootNode
	{
		public StructurePointerRootNode()
		{
			vmethod_0();
		}

		public StructurePointerRootNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public StructurePointerRootNode(int int2)
		{
			Int0 = int2;
			vmethod_0();
		}

		public StructurePointerRootNode(int int2, string string0, StructureHeaderNode class2860) : this(int2, QbSongClass1.AddKeyToDictionary(string0), class2860)
		{
		}

		public StructurePointerRootNode(int int2, int int3, StructureHeaderNode class2860)
		{
			Int0 = int2;
			Int1 = int3;
			Nodes.Add(class2860);
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

		public void method_8(StructureHeaderNode class2860)
		{
			if (Nodes.Count != 0)
			{
				Nodes[0] = class2860;
				return;
			}
			Nodes.Add(class2860);
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
