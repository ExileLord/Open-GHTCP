using ns18;
using ns21;

namespace ns20
{
	public class IntegerStructureNode : zzUnkNode295
	{
		public IntegerStructureNode()
		{
			vmethod_0();
		}

		public IntegerStructureNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public IntegerStructureNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public IntegerStructureNode(string string_0, int int_1) : this(QbSongClass1.AddKeyToDictionary(string_0), int_1)
		{
		}

		public IntegerStructureNode(int int_1, int int_2)
		{
			int_0 = int_1;
			Nodes.Add(new IntegerValueNode(int_2));
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
				return ((IntegerValueNode)FirstNode).int_0;
			}
			return 0;
		}

		public void method_9(int int_1)
		{
			if (Nodes.Count != 0)
			{
				((IntegerValueNode)FirstNode).int_0 = int_1;
				return;
			}
			Nodes.Add(new IntegerValueNode(int_1));
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
