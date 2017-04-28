using System;

namespace ns12
{
	public class Class188
	{
		private readonly byte[] byte_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		private int int_2;

		public Class188() : this(4096)
		{
		}

		public Class188(int int_3)
		{
			byte_0 = new byte[int_3];
		}

		public void method_0()
		{
			int_2 = 0;
			int_1 = 0;
			int_0 = 0;
		}

		public void method_1(int int_3)
		{
			byte_0[int_1++] = (byte)int_3;
			byte_0[int_1++] = (byte)(int_3 >> 8);
		}

		public void method_2(byte[] byte_1, int int_3, int int_4)
		{
			Array.Copy(byte_1, int_3, byte_0, int_1, int_4);
			int_1 += int_4;
		}

		public int method_3()
		{
			return int_2;
		}

		public void method_4()
		{
			if (int_2 > 0)
			{
				byte_0[int_1++] = (byte)uint_0;
				if (int_2 > 8)
				{
					byte_0[int_1++] = (byte)(uint_0 >> 8);
				}
			}
			uint_0 = 0u;
			int_2 = 0;
		}

		public void method_5(int int_3, int int_4)
		{
			uint_0 |= (uint)int_3 << int_2;
			int_2 += int_4;
			if (int_2 >= 16)
			{
				byte_0[int_1++] = (byte)uint_0;
				byte_0[int_1++] = (byte)(uint_0 >> 8);
				uint_0 >>= 16;
				int_2 -= 16;
			}
		}

		public void method_6(int int_3)
		{
			byte_0[int_1++] = (byte)(int_3 >> 8);
			byte_0[int_1++] = (byte)int_3;
		}

		public bool method_7()
		{
			return int_1 == 0;
		}

		public int method_8(byte[] byte_1, int int_3, int int_4)
		{
			if (int_2 >= 8)
			{
				byte_0[int_1++] = (byte)uint_0;
				uint_0 >>= 8;
				int_2 -= 8;
			}
			if (int_4 > int_1 - int_0)
			{
				int_4 = int_1 - int_0;
				Array.Copy(byte_0, int_0, byte_1, int_3, int_4);
				int_0 = 0;
				int_1 = 0;
			}
			else
			{
				Array.Copy(byte_0, int_0, byte_1, int_3, int_4);
				int_0 += int_4;
			}
			return int_4;
		}
	}
}
