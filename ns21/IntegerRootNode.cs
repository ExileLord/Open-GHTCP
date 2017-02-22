using ns20;
using System;

namespace ns21
{
	public class IntegerRootNode : Class268
	{
		public IntegerRootNode()
		{
			this.vmethod_0();
		}

		public IntegerRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public IntegerRootNode(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public IntegerRootNode(string string_0, string string_1, int int_2) : this(QbSongClass1.AddKeyToDictionary(string_0), QbSongClass1.AddKeyToDictionary(string_1), int_2)
		{
		}

		public IntegerRootNode(int int_2, int int_3, int int_4)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(new IntegerValueNode(int_4));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 2;
		}

		public int method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return ((IntegerValueNode)base.FirstNode).int_0;
			}
			return 0;
		}

		public void method_8(int int_2)
		{
			if (base.Nodes.Count != 0)
			{
				((IntegerValueNode)base.FirstNode).int_0 = int_2;
				return;
			}
			base.Nodes.Add(new IntegerValueNode(int_2));
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
