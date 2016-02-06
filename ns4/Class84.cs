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
			return this.int_4 - this.int_3;
		}

		public Class84(int int_5)
		{
			this.int_1 = int_5;
			this.int_2 = this.int_1 << 2;
			this.int_0 = new int[this.int_1];
			this.float_0 = new float[this.int_1][];
			for (int i = 0; i < this.int_1; i++)
			{
				this.float_0[i] = new float[1152];
			}
			this.method_6();
		}

		public int method_1(float[] float_1, int int_5, int int_6)
		{
			int_6 <<= 2;
			int num = this.method_0();
			int num2 = (int_6 > num) ? num : (int_6 - int_6 % this.int_2);
			if (this.int_1 == 1)
			{
				Buffer.BlockCopy(this.float_0[0], this.int_3, float_1, int_5 << 2, num2);
			}
			else
			{
				int num3 = this.int_3 / this.int_2;
				int num4 = num2 / this.int_2 + num3;
				for (int i = 0; i < this.int_1; i++)
				{
					float[] array = this.float_0[i];
					int j = num3;
					int num5 = int_5 + i;
					while (j < num4)
					{
						float_1[num5] = array[j];
						j++;
						num5 += this.int_1;
					}
				}
			}
			this.int_3 += num2;
			return num2 >> 2;
		}

		public int method_2(byte[] byte_0, int int_5, int int_6)
		{
			int num = this.method_0();
			int num2 = (int_6 > num) ? num : int_6;
			if (this.int_1 == 1)
			{
				Buffer.BlockCopy(this.float_0[0], this.int_3, byte_0, int_5, num2);
			}
			else
			{
				float[] array = new float[num2 >> 2];
				this.method_1(array, 0, array.Length);
				Buffer.BlockCopy(array, 0, byte_0, int_5, num2);
			}
			this.int_3 += num2;
			return num2;
		}

		public int method_3(float[][] float_1, int int_5, int int_6)
		{
			int_5 <<= 2;
			int_6 <<= 2;
			int num = this.method_0();
			int num2 = (int_6 > num) ? num : (int_6 - int_6 % this.int_2);
			if (this.int_1 == 1)
			{
				Buffer.BlockCopy(this.float_0[0], this.int_3, float_1[0], int_5, num2);
			}
			else
			{
				int srcOffset = this.int_3 / this.int_1;
				int count = num2 / this.int_1;
				int_5 /= this.int_1;
				for (int i = 0; i < float_1.Length; i++)
				{
					Buffer.BlockCopy(this.float_0[i], srcOffset, float_1[i], int_5, count);
				}
			}
			this.int_3 += num2;
			return num2 >> 2;
		}

		public void method_4(int int_5, float[] float_1)
		{
			if (int_5 < this.int_1 && this.int_0[int_5] < 4608)
			{
				Buffer.BlockCopy(float_1, 0, this.float_0[int_5], this.int_0[int_5], 128);
				this.int_0[int_5] += 128;
				return;
			}
		}

		public void method_5()
		{
			this.int_3 = 0;
			this.int_4 = this.int_0[0] * this.int_1;
		}

		public void method_6()
		{
			this.int_3 = 0;
			this.int_4 = 0;
			Array.Clear(this.int_0, 0, this.int_1);
		}
	}
}
