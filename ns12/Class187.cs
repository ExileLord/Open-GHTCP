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
			if (this.int_2 < int_3)
			{
				if (this.int_0 == this.int_1)
				{
					return -1;
				}
				this.uint_0 |= (uint)((uint)((int)(this.byte_0[this.int_0++] & 255) | (int)(this.byte_0[this.int_0++] & 255) << 8) << this.int_2);
				this.int_2 += 16;
			}
			return (int)((ulong)this.uint_0 & (ulong)((long)((1 << int_3) - 1)));
		}

		public void method_1(int int_3)
		{
			this.uint_0 >>= int_3;
			this.int_2 -= int_3;
		}

		public int method_2()
		{
			return this.int_2;
		}

		public int method_3()
		{
			return this.int_1 - this.int_0 + (this.int_2 >> 3);
		}

		public void method_4()
		{
			this.uint_0 >>= (this.int_2 & 7);
			this.int_2 &= -8;
		}

		public bool method_5()
		{
			return this.int_0 == this.int_1;
		}

		public int method_6(byte[] byte_1, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((this.int_2 & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num = 0;
			while (this.int_2 > 0 && int_4 > 0)
			{
				byte_1[int_3++] = (byte)this.uint_0;
				this.uint_0 >>= 8;
				this.int_2 -= 8;
				int_4--;
				num++;
			}
			if (int_4 == 0)
			{
				return num;
			}
			int num2 = this.int_1 - this.int_0;
			if (int_4 > num2)
			{
				int_4 = num2;
			}
			Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
			this.int_0 += int_4;
			if ((this.int_0 - this.int_1 & 1) != 0)
			{
				this.uint_0 = (uint)(this.byte_0[this.int_0++] & 255);
				this.int_2 = 8;
			}
			return num + int_4;
		}

		public void method_7()
		{
			this.uint_0 = 0u;
			this.int_2 = 0;
			this.int_1 = 0;
			this.int_0 = 0;
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
			if (this.int_0 < this.int_1)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = int_3 + int_4;
			if (int_3 <= num && num <= byte_1.Length)
			{
				if ((int_4 & 1) != 0)
				{
					this.uint_0 |= (uint)((uint)(byte_1[int_3++] & 255) << this.int_2);
					this.int_2 += 8;
				}
				this.byte_0 = byte_1;
				this.int_0 = int_3;
				this.int_1 = num;
				return;
			}
			throw new ArgumentOutOfRangeException("count");
		}
	}
}
