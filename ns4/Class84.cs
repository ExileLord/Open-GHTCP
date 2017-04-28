using System;

namespace ns4
{
	public class Class84
	{
		private readonly int[] int_0;

		private readonly int int_1;

		private readonly int int_2;

		private readonly float[][] float_0;

		private int int_3;

		private int int_4;

		public int method_0()
		{
			return int_4 - int_3;
		}

		public Class84(int int_5)
		{
			int_1 = int_5;
			int_2 = int_1 << 2;
			int_0 = new int[int_1];
			float_0 = new float[int_1][];
			for (var i = 0; i < int_1; i++)
			{
				float_0[i] = new float[1152];
			}
			method_6();
		}

		public int method_1(float[] float_1, int int_5, int int_6)
		{
			int_6 <<= 2;
			var num = method_0();
			var num2 = (int_6 > num) ? num : (int_6 - int_6 % int_2);
			if (int_1 == 1)
			{
				Buffer.BlockCopy(float_0[0], int_3, float_1, int_5 << 2, num2);
			}
			else
			{
				var num3 = int_3 / int_2;
				var num4 = num2 / int_2 + num3;
				for (var i = 0; i < int_1; i++)
				{
					var array = float_0[i];
					var j = num3;
					var num5 = int_5 + i;
					while (j < num4)
					{
						float_1[num5] = array[j];
						j++;
						num5 += int_1;
					}
				}
			}
			int_3 += num2;
			return num2 >> 2;
		}

		public int method_2(byte[] byte_0, int int_5, int int_6)
		{
			var num = method_0();
			var num2 = (int_6 > num) ? num : int_6;
			if (int_1 == 1)
			{
				Buffer.BlockCopy(float_0[0], int_3, byte_0, int_5, num2);
			}
			else
			{
				var array = new float[num2 >> 2];
				method_1(array, 0, array.Length);
				Buffer.BlockCopy(array, 0, byte_0, int_5, num2);
			}
			int_3 += num2;
			return num2;
		}

		public int method_3(float[][] float_1, int int_5, int int_6)
		{
			int_5 <<= 2;
			int_6 <<= 2;
			var num = method_0();
			var num2 = (int_6 > num) ? num : (int_6 - int_6 % int_2);
			if (int_1 == 1)
			{
				Buffer.BlockCopy(float_0[0], int_3, float_1[0], int_5, num2);
			}
			else
			{
				var srcOffset = int_3 / int_1;
				var count = num2 / int_1;
				int_5 /= int_1;
				for (var i = 0; i < float_1.Length; i++)
				{
					Buffer.BlockCopy(float_0[i], srcOffset, float_1[i], int_5, count);
				}
			}
			int_3 += num2;
			return num2 >> 2;
		}

		public void method_4(int int_5, float[] float_1)
		{
			if (int_5 < int_1 && int_0[int_5] < 4608)
			{
				Buffer.BlockCopy(float_1, 0, float_0[int_5], int_0[int_5], 128);
				int_0[int_5] += 128;
			}
		}

		public void method_5()
		{
			int_3 = 0;
			int_4 = int_0[0] * int_1;
		}

		public void method_6()
		{
			int_3 = 0;
			int_4 = 0;
			Array.Clear(int_0, 0, int_1);
		}
	}
}
