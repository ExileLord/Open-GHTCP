using GHNamespaceE;

namespace GHNamespaceF
{
	public class IntegerRootNode : Class268
	{
		public IntegerRootNode()
		{
			vmethod_0();
		}

		public IntegerRootNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public IntegerRootNode(int int2)
		{
			Int0 = int2;
			vmethod_0();
		}

		public IntegerRootNode(string string0, string string1, int int2) : this(QbSongClass1.AddKeyToDictionary(string0), QbSongClass1.AddKeyToDictionary(string1), int2)
		{
		}

		public IntegerRootNode(int int2, int int3, int int4)
		{
			Int0 = int2;
			Int1 = int3;
			Nodes.Add(new IntegerValueNode(int4));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 2;
		}

		public int method_7()
		{
			if (Nodes.Count != 0)
			{
				return ((IntegerValueNode)FirstNode).Int0;
			}
			return 0;
		}

		public void method_8(int int2)
		{
			if (Nodes.Count != 0)
			{
				((IntegerValueNode)FirstNode).Int0 = int2;
				return;
			}
			Nodes.Add(new IntegerValueNode(int2));
		}

		public override string GetNodeText()
		{
			return "Integer Root";
		}

		public override byte vmethod_16()
		{
			return 1;
		}
	}
}
