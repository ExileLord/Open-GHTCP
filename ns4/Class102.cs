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
			int_1 = 0;
			int_2 = 0;
			int_3 = 0;
		}

		public int method_0()
		{
			return int_2;
		}

		public int method_1(int int_5)
		{
			int_2 += int_5;
			var num = 0;
			var num2 = int_3;
			if (num2 + int_5 < 32768)
			{
				while (int_5-- > 0)
				{
					num <<= 1;
					num |= ((int_4[num2++] != 0) ? 1 : 0);
				}
			}
			else
			{
				while (int_5-- > 0)
				{
					num <<= 1;
					num |= ((int_4[num2] != 0) ? 1 : 0);
					num2 = (num2 + 1 & int_0);
				}
			}
			int_3 = num2;
			return num;
		}

		public int method_2()
		{
			int_2++;
			var result = int_4[int_3];
			int_3 = (int_3 + 1 & int_0);
			return result;
		}

		public void method_3(int int_5)
		{
			var num = int_1;
			int_4[num++] = (int_5 & 128);
			int_4[num++] = (int_5 & 64);
			int_4[num++] = (int_5 & 32);
			int_4[num++] = (int_5 & 16);
			int_4[num++] = (int_5 & 8);
			int_4[num++] = (int_5 & 4);
			int_4[num++] = (int_5 & 2);
			int_4[num++] = (int_5 & 1);
			if (num == 32768)
			{
				int_1 = 0;
				return;
			}
			int_1 = num;
		}

		public void method_4(int int_5)
		{
			int_2 -= int_5;
			int_3 -= int_5;
			if (int_3 < 0)
			{
				int_3 += 32768;
			}
		}

		public void method_5(int int_5)
		{
			var num = int_5 << 3;
			int_2 -= num;
			int_3 -= num;
			if (int_3 < 0)
			{
				int_3 += 32768;
			}
		}
	}
}
