using System;

namespace ns7
{
	public class Class139
	{
		public static void smethod_0(int[] int_0, int int_1, int int_2, int[] int_3, int int_4)
		{
			switch (int_2)
			{
			case 0:
				for (int i = 0; i < int_1; i++)
				{
					int_3[i + int_4] = int_0[i];
				}
				return;
			case 1:
				for (int j = 0; j < int_1; j++)
				{
					int_3[j + int_4] = int_0[j] + int_3[j + int_4 - 1];
				}
				return;
			case 2:
				for (int k = 0; k < int_1; k++)
				{
					int_3[k + int_4] = int_0[k] + (int_3[k + int_4 - 1] << 1) - int_3[k + int_4 - 2];
				}
				return;
			case 3:
				for (int l = 0; l < int_1; l++)
				{
					int_3[l + int_4] = int_0[l] + ((int_3[l + int_4 - 1] - int_3[l + int_4 - 2] << 1) + (int_3[l + int_4 - 1] - int_3[l + int_4 - 2])) + int_3[l + int_4 - 3];
				}
				return;
			case 4:
				for (int m = 0; m < int_1; m++)
				{
					int_3[m + int_4] = int_0[m] + (int_3[m + int_4 - 1] + int_3[m + int_4 - 3] << 2) - ((int_3[m + int_4 - 2] << 2) + (int_3[m + int_4 - 2] << 1)) - int_3[m + int_4 - 4];
				}
				return;
			default:
				return;
			}
		}
	}
}
