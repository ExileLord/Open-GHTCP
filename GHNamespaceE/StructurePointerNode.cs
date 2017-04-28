using GHNamespaceC;
using GHNamespaceF;

namespace GHNamespaceE
{
	public class StructurePointerNode : ZzUnkNode300
	{
		public StructurePointerNode()
		{
			vmethod_0();
		}

		public StructurePointerNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public StructurePointerNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public StructurePointerNode(string string0, StructureHeaderNode class2860) : this(QbSongClass1.AddKeyToDictionary(string0), class2860)
		{
		}

		public StructurePointerNode(int int1, StructureHeaderNode class2860)
		{
			Int0 = int1;
			Nodes.Add(class2860);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 27;
		}

		public StructureHeaderNode method_8()
		{
			if (Nodes.Count != 0)
			{
				return (StructureHeaderNode)FirstNode;
			}
			return null;
		}

		public override string GetNodeText()
		{
			return "Structure Pointer";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 21;
			}
			return 138;
		}
	}
}
