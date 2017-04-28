using System;
using ns18;

namespace ns20
{
	public class FloatValueNode : AbstractTreeNode2
	{
		public float Float0;

		public FloatValueNode()
		{
			vmethod_0();
		}

		public FloatValueNode(float float1)
		{
			Float0 = float1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 34;
		}

		public override object vmethod_7()
		{
			return Float0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(Float0);
		}

		public override void vmethod_9(byte[] byte0)
		{
			Float0 = BitConverter.ToSingle(byte0, 0);
		}

		public override string GetText()
		{
			return string.Concat((double)Float0);
		}

		public override string GetNodeText()
		{
			return "Float Value";
		}

		public override void vmethod_2(ref int int0)
		{
			int0 += 4;
		}

		public static float smethod_0(FloatValueNode class3130)
		{
			return class3130.Float0;
		}
	}
}
