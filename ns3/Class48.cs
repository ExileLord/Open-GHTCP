using System;

namespace ns3
{
	public class Class48
	{
		public byte[] byte_0;

		public int int_0;

		public int int_1;

		public byte[] byte_1;

		public int int_2;

		public int int_3;

		private static readonly uint[] uint_0 = new uint[256];

		public Class48()
		{
			uint num = 0u;
			while (num < (ulong)uint_0.Length)
			{
				uint_0[(int)((UIntPtr)num)] = smethod_0(num);
				num += 1u;
			}
		}

		private static uint smethod_0(uint uint_1)
		{
			uint num = uint_1 << 24;
			for (int i = 0; i < 8; i++)
			{
				if ((num & 2147483648u) != 0u)
				{
					num = (num << 1 ^ 79764919u);
				}
				else
				{
					num <<= 1;
				}
			}
			return num & 4294967295u;
		}

		public int method_0()
		{
			return byte_0[int_0 + 4] & 255;
		}

		public int method_1()
		{
			return byte_0[int_0 + 5] & 1;
		}

		public int method_2()
		{
			return byte_0[int_0 + 5] & 2;
		}

		public int method_3()
		{
			return byte_0[int_0 + 5] & 4;
		}

		public long method_4()
		{
			long num = byte_0[int_0 + 13] & 255;
			num = (num << 8 | byte_0[int_0 + 12] & 255);
			num = (num << 8 | byte_0[int_0 + 11] & 255);
			num = (num << 8 | byte_0[int_0 + 10] & 255);
			num = (num << 8 | byte_0[int_0 + 9] & 255);
			num = (num << 8 | byte_0[int_0 + 8] & 255);
			num = (num << 8 | byte_0[int_0 + 7] & 255);
			return num << 8 | byte_0[int_0 + 6] & 255;
		}

		public int method_5()
		{
			return byte_0[int_0 + 14] & 255 | (byte_0[int_0 + 15] & 255) << 8 | (byte_0[int_0 + 16] & 255) << 16 | (byte_0[int_0 + 17] & 255) << 24;
		}

		public int method_6()
		{
			return byte_0[int_0 + 18] & 255 | (byte_0[int_0 + 19] & 255) << 8 | (byte_0[int_0 + 20] & 255) << 16 | (byte_0[int_0 + 21] & 255) << 24;
		}

		public void method_7()
		{
			uint num = 0u;
			for (int i = 0; i < int_1; i++)
			{
				uint num2 = (uint)(byte_0[int_0 + i] & 255);
				uint num3 = num >> 24 & 255u;
				num = (num << 8 ^ uint_0[(int)((UIntPtr)(num2 ^ num3))]);
			}
			for (int j = 0; j < int_3; j++)
			{
				uint num2 = (uint)(byte_1[int_2 + j] & 255);
				uint num3 = num >> 24 & 255u;
				num = (num << 8 ^ uint_0[(int)((UIntPtr)(num2 ^ num3))]);
			}
			byte_0[int_0 + 22] = (byte)num;
			byte_0[int_0 + 23] = (byte)(num >> 8);
			byte_0[int_0 + 24] = (byte)(num >> 16);
			byte_0[int_0 + 25] = (byte)(num >> 24);
		}
	}
}
