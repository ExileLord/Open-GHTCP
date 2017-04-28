using System.Runtime.InteropServices;

namespace ns10
{
	public class Class77
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct Struct15
		{
			[FieldOffset(0)]
			public float float_0;

			[FieldOffset(0)]
			public int int_0;
		}

		private static float float_0 = 3.14159274f;

		public static void smethod_0(float[] float_1, int[] int_0, int int_1, int int_2, float[] float_2, int int_3, float float_3, float float_4)
		{
			var num = float_0 / int_2;
			int i;
			for (i = 0; i < int_3; i++)
			{
				float_2[i] = Class69.smethod_0(float_2[i]);
			}
			var num2 = int_3 / 2 * 2;
			i = 0;
			while (i < int_1)
			{
				var @struct = default(Struct15);
				var num3 = int_0[i];
				var num4 = 0.707106769f;
				var num5 = 0.707106769f;
				var num6 = Class69.smethod_0(num * num3);
				for (var j = 0; j < num2; j += 2)
				{
					num5 *= float_2[j] - num6;
					num4 *= float_2[j + 1] - num6;
				}
				if ((int_3 & 1) != 0)
				{
					num5 *= float_2[int_3 - 1] - num6;
					num5 *= num5;
					num4 *= num4 * (1f - num6 * num6);
				}
				else
				{
					num5 *= num5 * (1f + num6);
					num4 *= num4 * (1f - num6);
				}
				num5 = num4 + num5;
				@struct.float_0 = num5;
				var num7 = @struct.int_0;
				var num8 = 2147483647 & num7;
				var num9 = 0;
				if (num8 < 2139095040 && num8 != 0)
				{
					if (num8 < 8388608)
					{
						num5 *= 33554432f;
						@struct.float_0 = num5;
						num7 = @struct.int_0;
						num8 = (2147483647 & num7);
						num9 = -25;
					}
					num9 += (int)(((uint)num8 >> 23) - 126u);
					num7 = (int)((num7 & 2155872255L) | 1056964608L);
					@struct.int_0 = num7;
					num5 = @struct.float_0;
				}
				num5 = Class69.smethod_3(float_3 * Class69.smethod_1(num5) * Class69.smethod_2(num9 + int_3) - float_4);
				do
				{
					float_1[i] *= num5;
					i++;
					if (i >= int_1)
					{
						break;
					}
				}
				while (int_0[i] == num3);
			}
		}
	}
}
