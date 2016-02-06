using System;

namespace ns6
{
	public class Class130
	{
		public static void smethod_0(int[] int_0, int int_1, int[] int_2, int int_3, int int_4, int[] int_5, int int_6)
		{
			for (int i = 0; i < int_1; i++)
			{
				int num = 0;
				for (int j = 0; j < int_3; j++)
				{
					num += int_2[j] * int_5[int_6 + i - j - 1];
				}
				int_5[int_6 + i] = int_0[i] + (num >> int_4);
			}
		}

		public static void smethod_1(int[] int_0, int int_1, int[] int_2, int int_3, int int_4, int[] int_5, int int_6)
		{
			for (int i = 0; i < int_1; i++)
			{
				long num = 0L;
				for (int j = 0; j < int_3; j++)
				{
					num += (long)int_2[j] * (long)int_5[int_6 + i - j - 1];
				}
				int_5[int_6 + i] = int_0[i] + (int)(num >> int_4);
			}
		}
	}
}
