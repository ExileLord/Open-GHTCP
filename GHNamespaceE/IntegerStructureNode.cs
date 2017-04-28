using GHNamespaceB;
using GHNamespaceF;

namespace GHNamespaceE
{
	public class IntegerStructureNode : ZzUnkNode295
	{
		public IntegerStructureNode()
		{
			vmethod_0();
		}

		public IntegerStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public IntegerStructureNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public IntegerStructureNode(string string0, int int1) : this(QbSongClass1.AddKeyToDictionary(string0), int1)
		{
		}

		public IntegerStructureNode(int int1, int int2)
		{
			Int0 = int1;
			Nodes.Add(new IntegerValueNode(int2));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 23;
		}

		public int method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((IntegerValueNode)FirstNode).Int0;
			}
			return 0;
		}

		public void method_9(int int1)
		{
			if (Nodes.Count != 0)
			{
				((IntegerValueNode)FirstNode).Int0 = int1;
				return;
			}
			Nodes.Add(new IntegerValueNode(int1));
		}

		public override string GetNodeText()
		{
			return "Integer Structure";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 3;
			}
			return 129;
		}
	}
}
