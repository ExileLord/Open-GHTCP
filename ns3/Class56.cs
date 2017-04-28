using System;
using ns10;

namespace ns3
{
	public class Class56
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int[] int_3;

		private long[] long_0;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private readonly byte[] byte_1 = new byte[282];

		private int int_8;

		public int int_9;

		private int int_10;

		private int int_11;

		private int int_12;

		private long long_1;

		private long long_2;

		public Class56()
		{
			method_0();
		}

		~Class56()
		{
			method_2();
		}

		private void method_0()
		{
			int_0 = 16384;
			byte_0 = new byte[int_0];
			int_4 = 1024;
			int_3 = new int[int_4];
			long_0 = new long[int_4];
		}

		public void method_1(int int_13)
		{
			if (byte_0 == null)
			{
				method_0();
			}
			else
			{
				for (var i = 0; i < byte_0.Length; i++)
				{
					byte_0[i] = 0;
				}
				for (var j = 0; j < int_3.Length; j++)
				{
					int_3[j] = 0;
				}
				for (var k = 0; k < long_0.Length; k++)
				{
					long_0[k] = 0L;
				}
			}
			int_11 = int_13;
		}

		public void method_2()
		{
			byte_0 = null;
			int_3 = null;
			long_0 = null;
		}

		private void method_3(int int_13)
		{
			if (int_0 <= int_1 + int_13)
			{
				int_0 += int_13 + 1024;
				var dst = new byte[int_0];
				Buffer.BlockCopy(byte_0, 0, dst, 0, byte_0.Length);
				byte_0 = dst;
			}
		}

		private void method_4(int int_13)
		{
			if (int_4 <= int_5 + int_13)
			{
				int_4 += int_13 + 32;
				var dst = new int[int_4];
				Buffer.BlockCopy(int_3, 0, dst, 0, int_3.Length << 2);
				int_3 = dst;
				var dst2 = new long[int_4];
				Buffer.BlockCopy(long_0, 0, dst2, 0, long_0.Length << 3);
				long_0 = dst2;
			}
		}

		public int method_5(Class67 class67_0)
		{
			var num = int_7;
			if (int_6 <= num)
			{
				return 0;
			}
			if ((int_3[num] & 1024) != 0)
			{
				int_7++;
				long_1 += 1L;
				return -1;
			}
			var num2 = int_3[num] & 255;
			class67_0.byte_0 = byte_0;
			class67_0.int_0 = int_2;
			class67_0.int_3 = (int_3[num] & 512);
			class67_0.int_2 = (int_3[num] & 256);
			var num3 = 0 + num2;
			while (num2 == 255)
			{
				var num4 = int_3[++num];
				num2 = (num4 & 255);
				if ((num4 & 512) != 0)
				{
					class67_0.int_3 = 512;
				}
				num3 += num2;
			}
			class67_0.long_1 = long_1;
			class67_0.long_0 = long_0[num];
			class67_0.int_1 = num3;
			int_2 += num3;
			int_7 = num + 1;
			long_1 += 1L;
			return 1;
		}

		public bool method_6(Class48 class48_0)
		{
			var array = class48_0.byte_0;
			var num = class48_0.int_0;
			var src = class48_0.byte_1;
			var num2 = class48_0.int_2;
			var num3 = class48_0.int_3;
			var i = 0;
			var num4 = class48_0.method_0();
			var num5 = class48_0.method_1();
			var num6 = class48_0.method_2();
			var num7 = class48_0.method_3();
			var num8 = class48_0.method_4();
			var num9 = class48_0.method_5();
			var num10 = class48_0.method_6();
			var num11 = array[num + 26] & 255;
			var num12 = int_7;
			var num13 = int_2;
			if (num13 != 0)
			{
				int_1 -= num13;
				if (int_1 != 0)
				{
					Buffer.BlockCopy(byte_0, num13, byte_0, 0, int_1);
				}
				int_2 = 0;
			}
			if (num12 != 0)
			{
				if (int_5 - num12 != 0)
				{
					Buffer.BlockCopy(int_3, num12 << 2, int_3, 0, int_5 - num12 << 2);
					Buffer.BlockCopy(long_0, num12 << 3, long_0, 0, int_5 - num12 << 3);
				}
				int_5 -= num12;
				int_6 -= num12;
				int_7 = 0;
			}
			if (num9 != int_11)
			{
				return false;
			}
			if (num4 > 0)
			{
				return false;
			}
			method_4(num11 + 1);
			if (num10 != int_12)
			{
				for (var j = int_6; j < int_5; j++)
				{
					int_1 -= (int_3[j] & 255);
				}
				int_5 = int_6;
				if (int_12 != -1)
				{
					int_3[int_5++] = 1024;
					int_6++;
				}
				if (num5 != 0)
				{
					num6 = 0;
					while (i < num11)
					{
						var num14 = array[num + 27 + i] & 255;
						num2 += num14;
						num3 -= num14;
						if (num14 < 255)
						{
							i++;
							break;
						}
						i++;
					}
				}
			}
			if (num3 != 0)
			{
				method_3(num3);
				Buffer.BlockCopy(src, num2, byte_0, int_1, num3);
				int_1 += num3;
			}
			var num15 = -1;
			while (i < num11)
			{
				var num16 = array[num + 27 + i] & 255;
				int_3[int_5] = num16;
				long_0[int_5] = -1L;
				if (num6 != 0)
				{
					int_3[int_5] |= 256;
					num6 = 0;
				}
				if (num16 < 255)
				{
					num15 = int_5;
				}
				int_5++;
				i++;
				if (num16 < 255)
				{
					int_6 = int_5;
				}
			}
			if (num15 != -1)
			{
				long_0[num15] = num8;
			}
			if (num7 != 0)
			{
				int_9 = 1;
				if (int_5 > 0)
				{
					int_3[int_5 - 1] |= 512;
				}
			}
			int_12 = num10 + 1;
			return true;
		}

		public bool method_7()
		{
			int_1 = 0;
			int_2 = 0;
			int_5 = 0;
			int_6 = 0;
			int_7 = 0;
			int_8 = 0;
			int_9 = 0;
			int_10 = 0;
			int_12 = -1;
			long_1 = 0L;
			long_2 = 0L;
			return true;
		}
	}
}
