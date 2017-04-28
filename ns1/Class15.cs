using System;

namespace ns1
{
	public static class Class15
	{
		private static readonly double Double0 = 1.0 / Math.Log(Math.Pow(2.0, 0.083333333333333329));

		private static readonly double Double1 = 1.0 / Math.Log(2.0);

		public static int Int0 = 64;

		private static readonly int[] Int1 = {
			0,
			100,
			200,
			300,
			400,
			600,
			800,
			1200,
			2400
		};

		public static int Int2 = 30;

		public static float smethod_0(float float0)
		{
			return (float)smethod_1(float0);
		}

		public static double smethod_1(double double2)
		{
			return Math.Max(8.6858896380650368 * Math.Log(Math.Abs(double2)), -200.0);
		}

		public static float smethod_2(float[] float0, float float1)
		{
			float result;
			try
			{
				result = float0[(int)float1 % float0.Length];
			}
			catch (IndexOutOfRangeException)
			{
				result = 0f;
			}
			return result;
		}

		public static float smethod_3(float[] float0, float[] float1, float float2)
		{
			if (float2 < float0[0])
			{
				return float1[0];
			}
			for (var i = 1; i < float0.Length; i++)
			{
				if (float0[i] > float2)
				{
					var num = float0[i] - float0[i - 1];
					var num2 = float1[i] - float1[i - 1];
					return float1[i - 1] + (float2 - float0[i - 1]) / num * num2;
				}
			}
			return float1[float1.Length - 1];
		}

		public static float smethod_4(float[] float0, int int3, int int4)
		{
			var num = 0f;
			for (var i = 0; i < int4; i++)
			{
				num += float0[int3 + i] * float0[int3 + i];
			}
			return (float)Math.Sqrt(num / int4);
		}

		public static float smethod_5(float float0, float float1, float float2)
		{
			return (float0 * float2 + float1) / (float2 + 1f);
		}

		public static void smethod_6(float[] float0, int int3, int int4, float float1)
		{
			var num = float0[int3];
			for (var i = int3; i < int3 + int4; i++)
			{
				num = smethod_5(num, float0[i], float1);
				float0[i] = num;
			}
			num = float0[int3 + int4 - 1];
			for (var j = int3 + int4 - 1; j >= int3; j--)
			{
				num = smethod_5(num, float0[j], float1);
				float0[j] = num;
			}
		}

		public static void smethod_7(float[] float0, int int3, int int4)
		{
			try
			{
				smethod_6(float0, int3 - int4 / 2, int4, 1.5f);
			}
			catch (Exception)
			{
			}
		}

		public static void smethod_8(float[] float0, int int3)
		{
			smethod_7(float0, int3, Int2);
		}

		public static float smethod_9(float[] float0, int int3, int int4)
		{
			var num = 0f;
			for (var i = 0; i < int4; i++)
			{
				var num2 = Math.Abs(float0[int3 + i]);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}
	}
}
