using System;

namespace ns12
{
	public class Class188
	{
		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		private int int_2;

		public Class188() : this(4096)
		{
		}

		public Class188(int int_3)
		{
			this.byte_0 = new byte[int_3];
		}

		public void method_0()
		{
			this.int_2 = 0;
			this.int_1 = 0;
			this.int_0 = 0;
		}

		public void method_1(int int_3)
		{
			this.byte_0[this.int_1++] = (byte)int_3;
			this.byte_0[this.int_1++] = (byte)(int_3 >> 8);
		}

		public void method_2(byte[] byte_1, int int_3, int int_4)
		{
			Array.Copy(byte_1, int_3, this.byte_0, this.int_1, int_4);
			this.int_1 += int_4;
		}

		public int method_3()
		{
			return this.int_2;
		}

		public void method_4()
		{
			if (this.int_2 > 0)
			{
				this.byte_0[this.int_1++] = (byte)this.uint_0;
				if (this.int_2 > 8)
				{
					this.byte_0[this.int_1++] = (byte)(this.uint_0 >> 8);
				}
			}
			this.uint_0 = 0u;
			this.int_2 = 0;
		}

		public void method_5(int int_3, int int_4)
		{
			this.uint_0 |= (uint)((uint)int_3 << this.int_2);
			this.int_2 += int_4;
			if (this.int_2 >= 16)
			{
				this.byte_0[this.int_1++] = (byte)this.uint_0;
				this.byte_0[this.int_1++] = (byte)(this.uint_0 >> 8);
				this.uint_0 >>= 16;
				this.int_2 -= 16;
			}
		}

		public void method_6(int int_3)
		{
			this.byte_0[this.int_1++] = (byte)(int_3 >> 8);
			this.byte_0[this.int_1++] = (byte)int_3;
		}

		public bool method_7()
		{
			return this.int_1 == 0;
		}

		public int method_8(byte[] byte_1, int int_3, int int_4)
		{
			if (this.int_2 >= 8)
			{
				this.byte_0[this.int_1++] = (byte)this.uint_0;
				this.uint_0 >>= 8;
				this.int_2 -= 8;
			}
			if (int_4 > this.int_1 - this.int_0)
			{
				int_4 = this.int_1 - this.int_0;
				Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
				this.int_0 = 0;
				this.int_1 = 0;
			}
			else
			{
				Array.Copy(this.byte_0, this.int_0, byte_1, int_3, int_4);
				this.int_0 += int_4;
			}
			return int_4;
		}
	}
}
