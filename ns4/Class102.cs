using System;

namespace ns4
{
	public class Class102
	{
		private static readonly int int_0 = 32767;

		private int int_1;

		private int int_2;

		private int int_3;

		private readonly int[] int_4 = new int[32768];

		public Class102()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_3 = 0;
		}

		public int method_0()
		{
			return this.int_2;
		}

		public int method_1(int int_5)
		{
			this.int_2 += int_5;
			int num = 0;
			int num2 = this.int_3;
			if (num2 + int_5 < 32768)
			{
				while (int_5-- > 0)
				{
					num <<= 1;
					num |= ((this.int_4[num2++] != 0) ? 1 : 0);
				}
			}
			else
			{
				while (int_5-- > 0)
				{
					num <<= 1;
					num |= ((this.int_4[num2] != 0) ? 1 : 0);
					num2 = (num2 + 1 & Class102.int_0);
				}
			}
			this.int_3 = num2;
			return num;
		}

		public int method_2()
		{
			this.int_2++;
			int result = this.int_4[this.int_3];
			this.int_3 = (this.int_3 + 1 & Class102.int_0);
			return result;
		}

		public void method_3(int int_5)
		{
			int num = this.int_1;
			this.int_4[num++] = (int_5 & 128);
			this.int_4[num++] = (int_5 & 64);
			this.int_4[num++] = (int_5 & 32);
			this.int_4[num++] = (int_5 & 16);
			this.int_4[num++] = (int_5 & 8);
			this.int_4[num++] = (int_5 & 4);
			this.int_4[num++] = (int_5 & 2);
			this.int_4[num++] = (int_5 & 1);
			if (num == 32768)
			{
				this.int_1 = 0;
				return;
			}
			this.int_1 = num;
		}

		public void method_4(int int_5)
		{
			this.int_2 -= int_5;
			this.int_3 -= int_5;
			if (this.int_3 < 0)
			{
				this.int_3 += 32768;
			}
		}

		public void method_5(int int_5)
		{
			int num = int_5 << 3;
			this.int_2 -= num;
			this.int_3 -= num;
			if (this.int_3 < 0)
			{
				this.int_3 += 32768;
			}
		}
	}
}
