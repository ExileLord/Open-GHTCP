using System;
using GHNamespaceB;

namespace GHNamespaceF
{
	public class IntegerValueNode : AbstractTreeNode2
	{
		public int Int0;

		public IntegerValueNode()
		{
			vmethod_0();
		}

		public IntegerValueNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 33;
		}

		public override object vmethod_7()
		{
			return Int0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(Int0);
		}

		public override void vmethod_9(byte[] byte0)
		{
			Int0 = BitConverter.ToInt32(byte0, 0);
		}

		public override string GetText()
		{
			return string.Concat(Int0);
		}

		public override string GetNodeText()
		{
			return "Integer Value";
		}

		public override void vmethod_2(ref int int1)
		{
			int1 += 4;
		}
	}
}
