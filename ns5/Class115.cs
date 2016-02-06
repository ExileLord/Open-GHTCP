using System;

namespace ns5
{
	public class Class115
	{
		private byte[] byte_0 = new byte[2048];

		private int int_0;

		private int int_1;

		public virtual int vmethod_0()
		{
			return this.int_0;
		}

		public virtual bool vmethod_1()
		{
			return ((int)this.byte_0[this.int_0 >> 3] << (this.int_0++ & 7) & 128) != 0;
		}

		public virtual void vmethod_2(byte[] byte_1, int int_2, int int_3)
		{
			if (this.vmethod_0() > 4096)
			{
				this.method_0((this.vmethod_0() - 4096) / 8);
			}
			if (this.byte_0.Length - this.int_1 / 8 < int_3 + 8)
			{
				byte[] dst = new byte[(this.byte_0.Length + int_3) * 2];
				Buffer.BlockCopy(this.byte_0, 0, dst, 0, this.int_1 / 8);
				Buffer.BlockCopy(byte_1, int_2, dst, this.int_1 / 8, int_3);
				this.byte_0 = dst;
			}
			else
			{
				Buffer.BlockCopy(byte_1, int_2, this.byte_0, this.int_1 / 8, int_3);
			}
			this.int_1 += int_3 * 8;
		}

		public void method_0(int int_2)
		{
			Buffer.BlockCopy(this.byte_0, int_2, this.byte_0, 0, this.byte_0.Length - int_2);
			this.int_1 -= int_2 * 8;
			this.int_0 -= int_2 * 8;
		}

		public virtual void vmethod_3(int int_2)
		{
			this.int_0 = int_2;
		}

		public int method_1()
		{
			return this.int_1 - this.int_0;
		}

		public int method_2(int int_2)
		{
			int num = this.int_0 >> 3;
			int num2 = (int)this.byte_0[num++];
			int i;
			for (i = int_2 - (8 - (this.int_0 & 7)); i > 0; i -= 8)
			{
				num2 = (num2 << 8 | (int)(this.byte_0[num++] & 255));
			}
			num2 = (num2 >> -i & (1 << int_2) - 1);
			this.int_0 += int_2;
			if (this.method_1() < 0)
			{
				throw new ApplicationException("Buffer underflow");
			}
			return num2;
		}

		public int method_3(int int_2)
		{
			int num = this.int_0 >> 3;
			int num2 = (int)this.byte_0[num++];
			int i;
			for (i = int_2 - (8 - (this.int_0 & 7)); i > 0; i -= 8)
			{
				num2 = (num2 << 8 | (int)(this.byte_0[num++] & 255));
			}
			return num2 >> -i & (1 << int_2) - 1;
		}
	}
}
