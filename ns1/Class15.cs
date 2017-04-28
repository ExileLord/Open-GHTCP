using System;

namespace ns1
{
	public static class Class15
	{
		private static readonly double double_0 = 1.0 / Math.Log(Math.Pow(2.0, 0.083333333333333329));

		private static readonly double double_1 = 1.0 / Math.Log(2.0);

		public static int int_0 = 64;

		private static readonly int[] int_1 = {
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

		public static int int_2 = 30;

		public static float smethod_0(float float_0)
		{
			return (float)smethod_1(float_0);
		}

		public static double smethod_1(double double_2)
		{
			return Math.Max(8.6858896380650368 * Math.Log(Math.Abs(double_2)), -200.0);
		}

		public static float smethod_2(float[] float_0, float float_1)
		{
			float result;
			try
			{
				result = float_0[(int)float_1 % float_0.Length];
			}
			catch (IndexOutOfRangeException)
			{
				result = 0f;
			}
			return result;
		}

		public static float smethod_3(float[] float_0, float[] float_1, float float_2)
		{
			if (float_2 < float_0[0])
			{
				return float_1[0];
			}
			for (int i = 1; i < float_0.Length; i++)
			{
				if (float_0[i] > float_2)
				{
					float num = float_0[i] - float_0[i - 1];
					float num2 = float_1[i] - float_1[i - 1];
					return float_1[i - 1] + (float_2 - float_0[i - 1]) / num * num2;
				}
			}
			return float_1[float_1.Length - 1];
		}

		public static float smethod_4(float[] float_0, int int_3, int int_4)
		{
			float num = 0f;
			for (int i = 0; i < int_4; i++)
			{
				num += float_0[int_3 + i] * float_0[int_3 + i];
			}
			return (float)Math.Sqrt(num / int_4);
		}

		public static float smethod_5(float float_0, float float_1, float float_2)
		{
			return (float_0 * float_2 + float_1) / (float_2 + 1f);
		}

		public static void smethod_6(float[] float_0, int int_3, int int_4, float float_1)
		{
			float num = float_0[int_3];
			for (int i = int_3; i < int_3 + int_4; i++)
			{
				num = smethod_5(num, float_0[i], float_1);
				float_0[i] = num;
			}
			num = float_0[int_3 + int_4 - 1];
			for (int j = int_3 + int_4 - 1; j >= int_3; j--)
			{
				num = smethod_5(num, float_0[j], float_1);
				float_0[j] = num;
			}
		}

		public static void smethod_7(float[] float_0, int int_3, int int_4)
		{
			try
			{
				smethod_6(float_0, int_3 - int_4 / 2, int_4, 1.5f);
			}
			catch (Exception)
			{
			}
		}

		public static void smethod_8(float[] float_0, int int_3)
		{
			smethod_7(float_0, int_3, int_2);
		}

		public static float smethod_9(float[] float_0, int int_3, int int_4)
		{
			float num = 0f;
			for (int i = 0; i < int_4; i++)
			{
				float num2 = Math.Abs(float_0[int_3 + i]);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}
	}
}
