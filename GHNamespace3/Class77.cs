using System.Runtime.InteropServices;

namespace GHNamespace3
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

		private static readonly float Float0 = 3.14159274f;

		public static void smethod_0(float[] float1, int[] int0, int int1, int int2, float[] float2, int int3, float float3, float float4)
		{
			var num = Float0 / int2;
			int i;
			for (i = 0; i < int3; i++)
			{
				float2[i] = Class69.smethod_0(float2[i]);
			}
			var num2 = int3 / 2 * 2;
			i = 0;
			while (i < int1)
			{
				var @struct = default(Struct15);
				var num3 = int0[i];
				var num4 = 0.707106769f;
				var num5 = 0.707106769f;
				var num6 = Class69.smethod_0(num * num3);
				for (var j = 0; j < num2; j += 2)
				{
					num5 *= float2[j] - num6;
					num4 *= float2[j + 1] - num6;
				}
				if ((int3 & 1) != 0)
				{
					num5 *= float2[int3 - 1] - num6;
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
				num5 = Class69.smethod_3(float3 * Class69.smethod_1(num5) * Class69.smethod_2(num9 + int3) - float4);
				do
				{
					float1[i] *= num5;
					i++;
					if (i >= int1)
					{
						break;
					}
				}
				while (int0[i] == num3);
			}
		}
	}
}
