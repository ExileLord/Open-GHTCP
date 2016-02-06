using ns18;
using System;

namespace ns20
{
	public class Class313 : Class310
	{
		public float float_0;

		public Class313()
		{
			this.vmethod_0();
		}

		public Class313(float float_1)
		{
			this.float_0 = float_1;
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 34;
		}

		public override object vmethod_7()
		{
			return this.float_0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(this.float_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.float_0 = BitConverter.ToSingle(byte_0, 0);
		}

		public override string vmethod_3()
		{
			return string.Concat((double)this.float_0);
		}

		public override string vmethod_5()
		{
			return "Float Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 4;
		}

		public static float smethod_0(Class313 class313_0)
		{
			return class313_0.float_0;
		}
	}
}
