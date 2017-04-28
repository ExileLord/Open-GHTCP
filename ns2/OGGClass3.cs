namespace ns2
{
	public class OGGClass3
	{
		private static readonly int[] int_0 = {
			0,
			1,
			3,
			7,
			15,
			31,
			63,
			127,
			255,
			511,
			1023,
			2047,
			4095,
			8191,
			16383,
			32767,
			65535,
			131071,
			262143,
			524287,
			1048575,
			2097151,
			4194303,
			8388607,
			16777215,
			33554431,
			67108863,
			134217727,
			268435455,
			536870911,
			1073741823,
			2147483647,
			-1
		};

		private int int_1;

		private byte[] byte_0;

		private int int_2;

		private int int_3;

		private int int_4;

		public void method_0()
		{
			byte_0 = new byte[256];
			int_1 = 0;
			byte_0[0] = 0;
			int_4 = 256;
		}

		public void method_1()
		{
			byte_0 = null;
		}

		public int method_2(int int_5)
		{
			int num = int_0[int_5];
			int_5 += int_2;
			if (int_3 + 4 >= int_4 && int_3 + (int_5 - 1) / 8 >= int_4)
			{
				return -1;
			}
			int num2 = (byte_0[int_1] & 255) >> int_2;
			if (int_5 > 8)
			{
				num2 |= (byte_0[int_1 + 1] & 255) << 8 - int_2;
				if (int_5 > 16)
				{
					num2 |= (byte_0[int_1 + 2] & 255) << 16 - int_2;
					if (int_5 > 24)
					{
						num2 |= (byte_0[int_1 + 3] & 255) << 24 - int_2;
						if (int_5 > 32 && int_2 != 0)
						{
							num2 |= (byte_0[int_1 + 4] & 255) << 32 - int_2;
						}
					}
				}
			}
			return num2 & num;
		}

		public void method_3(int int_5)
		{
			int_5 += int_2;
			int_1 += int_5 / 8;
			int_3 += int_5 / 8;
			int_2 = (int_5 & 7);
		}

		public void method_4(byte[] byte_1, int int_5, int int_6)
		{
			int_1 = int_5;
			byte_0 = byte_1;
			int_3 = 0;
			int_2 = 0;
			int_4 = int_6;
		}

		public void method_5(byte[] byte_1, int int_5)
		{
			int num = 0;
			while (int_5-- != 0)
			{
				byte_1[num++] = (byte)method_6(8);
			}
		}

		public int method_6(int int_5)
		{
			int num = int_0[int_5];
			int_5 += int_2;
			int num2;
			if (int_3 + 4 >= int_4)
			{
				num2 = -1;
				if (int_3 + (int_5 - 1) / 8 >= int_4)
				{
					int_1 += int_5 / 8;
					int_3 += int_5 / 8;
					int_2 = (int_5 & 7);
					return num2;
				}
			}
			num2 = (byte_0[int_1] & 255) >> int_2;
			if (int_5 > 8)
			{
				num2 |= (byte_0[int_1 + 1] & 255) << 8 - int_2;
				if (int_5 > 16)
				{
					num2 |= (byte_0[int_1 + 2] & 255) << 16 - int_2;
					if (int_5 > 24)
					{
						num2 |= (byte_0[int_1 + 3] & 255) << 24 - int_2;
						if (int_5 > 32 && int_2 != 0)
						{
							num2 |= (byte_0[int_1 + 4] & 255) << 32 - int_2;
						}
					}
				}
			}
			num2 &= num;
			int_1 += int_5 / 8;
			int_3 += int_5 / 8;
			int_2 = (int_5 & 7);
			return num2;
		}

		public int method_7()
		{
			int result;
			if (int_3 >= int_4)
			{
				result = -1;
				int_2++;
				if (int_2 > 7)
				{
					int_2 = 0;
					int_1++;
					int_3++;
				}
				return result;
			}
			result = (byte_0[int_1] >> int_2 & 1);
			int_2++;
			if (int_2 > 7)
			{
				int_2 = 0;
				int_1++;
				int_3++;
			}
			return result;
		}
	}
}
