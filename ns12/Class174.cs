using ns1;
using ns8;
using System;

namespace ns12
{
	public class Class174 : Class172
	{
		private readonly float float_0;

		private readonly int int_0;

		public Class174(int int_1, float float_1)
		{
			this.int_0 = int_1;
			this.float_0 = float_1;
		}

		public override void vmethod_0(Class13 class13_0)
		{
			float[] array = class13_0.float_0;
			int num = class13_0.method_0();
			int num2 = class13_0.method_2();
			float num3 = 0f;
			switch (this.int_0)
			{
			case 1:
				num3 = Class15.smethod_9(array, num, num2);
				break;
			case 2:
				num3 = Class15.smethod_4(array, num, num2);
				break;
			case 3:
				num3 = 1f;
				break;
			}
			float num4 = this.float_0 / num3;
			for (int i = num; i < num + num2; i++)
			{
				array[i] = class13_0.vmethod_1(i, array[i], array[i] * num4);
			}
		}
	}
}
