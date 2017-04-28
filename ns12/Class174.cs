using ns1;
using ns8;

namespace ns12
{
	public class Class174 : Class172
	{
		private readonly float _float0;

		private readonly int _int0;

		public Class174(int int1, float float1)
		{
			_int0 = int1;
			_float0 = float1;
		}

		public override void vmethod_0(Class13 class130)
		{
			var array = class130.Float0;
			var num = class130.method_0();
			var num2 = class130.method_2();
			var num3 = 0f;
			switch (_int0)
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
			var num4 = _float0 / num3;
			for (var i = num; i < num + num2; i++)
			{
				array[i] = class130.vmethod_1(i, array[i], array[i] * num4);
			}
		}
	}
}
