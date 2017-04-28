using System;

namespace ns12
{
	public class Class187
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		private int int_2;

		public int method_0(int int_3)
		{
			if (int_2 < int_3)
			{
				if (int_0 == int_1)
				{
					return -1;
				}
				uint_0 |= (uint)(byte_0[int_0++] & 255 | (byte_0[int_0++] & 255) << 8) << int_2;
				int_2 += 16;
			}
			return (int)(uint_0 & (ulong)((1 << int_3) - 1));
		}

		public void method_1(int int_3)
		{
			uint_0 >>= int_3;
			int_2 -= int_3;
		}

		public int method_2()
		{
			return int_2;
		}

		public int method_3()
		{
			return int_1 - int_0 + (int_2 >> 3);
		}

		public void method_4()
		{
			uint_0 >>= (int_2 & 7);
			int_2 &= -8;
		}

		public bool method_5()
		{
			return int_0 == int_1;
		}

		public int method_6(byte[] byte_1, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((int_2 & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num = 0;
			while (int_2 > 0 && int_4 > 0)
			{
				byte_1[int_3++] = (byte)uint_0;
				uint_0 >>= 8;
				int_2 -= 8;
				int_4--;
				num++;
			}
			if (int_4 == 0)
			{
				return num;
			}
			int num2 = int_1 - int_0;
			if (int_4 > num2)
			{
				int_4 = num2;
			}
			Array.Copy(byte_0, int_0, byte_1, int_3, int_4);
			int_0 += int_4;
			if ((int_0 - int_1 & 1) != 0)
			{
				uint_0 = (uint)(byte_0[int_0++] & 255);
				int_2 = 8;
			}
			return num + int_4;
		}

		public void method_7()
		{
			uint_0 = 0u;
			int_2 = 0;
			int_1 = 0;
			int_0 = 0;
		}

		public void method_8(byte[] byte_1, int int_3, int int_4)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (int_0 < int_1)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = int_3 + int_4;
			if (int_3 <= num && num <= byte_1.Length)
			{
				if ((int_4 & 1) != 0)
				{
					uint_0 |= (uint)(byte_1[int_3++] & 255) << int_2;
					int_2 += 8;
				}
				byte_0 = byte_1;
				int_0 = int_3;
				int_1 = num;
				return;
			}
			throw new ArgumentOutOfRangeException("count");
		}
	}
}
