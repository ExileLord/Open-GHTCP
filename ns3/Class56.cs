using ns10;
using System;

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
			this.method_0();
		}

		~Class56()
		{
			this.method_2();
		}

		private void method_0()
		{
			this.int_0 = 16384;
			this.byte_0 = new byte[this.int_0];
			this.int_4 = 1024;
			this.int_3 = new int[this.int_4];
			this.long_0 = new long[this.int_4];
		}

		public void method_1(int int_13)
		{
			if (this.byte_0 == null)
			{
				this.method_0();
			}
			else
			{
				for (int i = 0; i < this.byte_0.Length; i++)
				{
					this.byte_0[i] = 0;
				}
				for (int j = 0; j < this.int_3.Length; j++)
				{
					this.int_3[j] = 0;
				}
				for (int k = 0; k < this.long_0.Length; k++)
				{
					this.long_0[k] = 0L;
				}
			}
			this.int_11 = int_13;
		}

		public void method_2()
		{
			this.byte_0 = null;
			this.int_3 = null;
			this.long_0 = null;
		}

		private void method_3(int int_13)
		{
			if (this.int_0 <= this.int_1 + int_13)
			{
				this.int_0 += int_13 + 1024;
				byte[] dst = new byte[this.int_0];
				Buffer.BlockCopy(this.byte_0, 0, dst, 0, this.byte_0.Length);
				this.byte_0 = dst;
			}
		}

		private void method_4(int int_13)
		{
			if (this.int_4 <= this.int_5 + int_13)
			{
				this.int_4 += int_13 + 32;
				int[] dst = new int[this.int_4];
				Buffer.BlockCopy(this.int_3, 0, dst, 0, this.int_3.Length << 2);
				this.int_3 = dst;
				long[] dst2 = new long[this.int_4];
				Buffer.BlockCopy(this.long_0, 0, dst2, 0, this.long_0.Length << 3);
				this.long_0 = dst2;
			}
		}

		public int method_5(Class67 class67_0)
		{
			int num = this.int_7;
			if (this.int_6 <= num)
			{
				return 0;
			}
			if ((this.int_3[num] & 1024) != 0)
			{
				this.int_7++;
				this.long_1 += 1L;
				return -1;
			}
			int num2 = this.int_3[num] & 255;
			class67_0.byte_0 = this.byte_0;
			class67_0.int_0 = this.int_2;
			class67_0.int_3 = (this.int_3[num] & 512);
			class67_0.int_2 = (this.int_3[num] & 256);
			int num3 = 0 + num2;
			while (num2 == 255)
			{
				int num4 = this.int_3[++num];
				num2 = (num4 & 255);
				if ((num4 & 512) != 0)
				{
					class67_0.int_3 = 512;
				}
				num3 += num2;
			}
			class67_0.long_1 = this.long_1;
			class67_0.long_0 = this.long_0[num];
			class67_0.int_1 = num3;
			this.int_2 += num3;
			this.int_7 = num + 1;
			this.long_1 += 1L;
			return 1;
		}

		public bool method_6(Class48 class48_0)
		{
			byte[] array = class48_0.byte_0;
			int num = class48_0.int_0;
			byte[] src = class48_0.byte_1;
			int num2 = class48_0.int_2;
			int num3 = class48_0.int_3;
			int i = 0;
			int num4 = class48_0.method_0();
			int num5 = class48_0.method_1();
			int num6 = class48_0.method_2();
			int num7 = class48_0.method_3();
			long num8 = class48_0.method_4();
			int num9 = class48_0.method_5();
			int num10 = class48_0.method_6();
			int num11 = (int)(array[num + 26] & 255);
			int num12 = this.int_7;
			int num13 = this.int_2;
			if (num13 != 0)
			{
				this.int_1 -= num13;
				if (this.int_1 != 0)
				{
					Buffer.BlockCopy(this.byte_0, num13, this.byte_0, 0, this.int_1);
				}
				this.int_2 = 0;
			}
			if (num12 != 0)
			{
				if (this.int_5 - num12 != 0)
				{
					Buffer.BlockCopy(this.int_3, num12 << 2, this.int_3, 0, this.int_5 - num12 << 2);
					Buffer.BlockCopy(this.long_0, num12 << 3, this.long_0, 0, this.int_5 - num12 << 3);
				}
				this.int_5 -= num12;
				this.int_6 -= num12;
				this.int_7 = 0;
			}
			if (num9 != this.int_11)
			{
				return false;
			}
			if (num4 > 0)
			{
				return false;
			}
			this.method_4(num11 + 1);
			if (num10 != this.int_12)
			{
				for (int j = this.int_6; j < this.int_5; j++)
				{
					this.int_1 -= (this.int_3[j] & 255);
				}
				this.int_5 = this.int_6;
				if (this.int_12 != -1)
				{
					this.int_3[this.int_5++] = 1024;
					this.int_6++;
				}
				if (num5 != 0)
				{
					num6 = 0;
					while (i < num11)
					{
						int num14 = (int)(array[num + 27 + i] & 255);
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
				this.method_3(num3);
				Buffer.BlockCopy(src, num2, this.byte_0, this.int_1, num3);
				this.int_1 += num3;
			}
			int num15 = -1;
			while (i < num11)
			{
				int num16 = (int)(array[num + 27 + i] & 255);
				this.int_3[this.int_5] = num16;
				this.long_0[this.int_5] = -1L;
				if (num6 != 0)
				{
					this.int_3[this.int_5] |= 256;
					num6 = 0;
				}
				if (num16 < 255)
				{
					num15 = this.int_5;
				}
				this.int_5++;
				i++;
				if (num16 < 255)
				{
					this.int_6 = this.int_5;
				}
			}
			if (num15 != -1)
			{
				this.long_0[num15] = num8;
			}
			if (num7 != 0)
			{
				this.int_9 = 1;
				if (this.int_5 > 0)
				{
					this.int_3[this.int_5 - 1] |= 512;
				}
			}
			this.int_12 = num10 + 1;
			return true;
		}

		public bool method_7()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_5 = 0;
			this.int_6 = 0;
			this.int_7 = 0;
			this.int_8 = 0;
			this.int_9 = 0;
			this.int_10 = 0;
			this.int_12 = -1;
			this.long_1 = 0L;
			this.long_2 = 0L;
			return true;
		}
	}
}
