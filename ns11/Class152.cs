using System;

namespace ns11
{
	public class Class152
	{
		private byte[] byte_0;

		private int int_0;

		public virtual int vmethod_0()
		{
			return this.int_0;
		}

		public Class152(int int_1)
		{
			if (int_1 <= 0)
			{
				int_1 = 256;
			}
			this.byte_0 = new byte[int_1];
			this.int_0 = 0;
		}

		public virtual void vmethod_1(byte byte_1)
		{
			this.byte_0[this.int_0++] = byte_1;
		}

		public virtual byte[] vmethod_2()
		{
			return this.byte_0;
		}

		public virtual byte vmethod_3(int int_1)
		{
			return this.byte_0[int_1];
		}
	}
}
