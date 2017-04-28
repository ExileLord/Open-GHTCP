using ns1;
using ns8;

namespace ns12
{
	public class Class174 : Class172
	{
		private readonly float float_0;

		private readonly int int_0;

		public Class174(int int_1, float float_1)
		{
			int_0 = int_1;
			float_0 = float_1;
		}

		public override void vmethod_0(Class13 class13_0)
		{
			var array = class13_0.float_0;
			var num = class13_0.method_0();
			var num2 = class13_0.method_2();
			var num3 = 0f;
			switch (int_0)
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
			var num4 = float_0 / num3;
			for (var i = num; i < num + num2; i++)
			{
				array[i] = class13_0.vmethod_1(i, array[i], array[i] * num4);
			}
		}
	}
}
