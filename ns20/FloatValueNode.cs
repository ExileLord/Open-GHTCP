using System;
using ns18;

namespace ns20
{
	public class FloatValueNode : AbstractTreeNode2
	{
		public float float_0;

		public FloatValueNode()
		{
			vmethod_0();
		}

		public FloatValueNode(float float_1)
		{
			float_0 = float_1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 34;
		}

		public override object vmethod_7()
		{
			return float_0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(float_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			float_0 = BitConverter.ToSingle(byte_0, 0);
		}

		public override string GetText()
		{
			return string.Concat((double)float_0);
		}

		public override string GetNodeText()
		{
			return "Float Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 4;
		}

		public static float smethod_0(FloatValueNode class313_0)
		{
			return class313_0.float_0;
		}
	}
}
