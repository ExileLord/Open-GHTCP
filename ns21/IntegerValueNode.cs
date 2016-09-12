using ns18;
using System;

namespace ns21
{
	public class IntegerValueNode : AbstractTreeNode2
	{
		public int int_0;

		public IntegerValueNode()
		{
			this.vmethod_0();
		}

		public IntegerValueNode(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 33;
		}

		public override object vmethod_7()
		{
			return this.int_0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(this.int_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.int_0 = BitConverter.ToInt32(byte_0, 0);
		}

		public override string GetText()
		{
			return string.Concat(this.int_0);
		}

		public override string GetNodeText()
		{
			return "Integer Value";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 4;
		}
	}
}
