using System;

namespace ns7
{
	public class Class147
	{
		public long long_0;

		public byte byte_0;

		public byte[] byte_1 = new byte[13];

		public int int_0;

		public int int_1;

		public byte byte_2;

		public Class148[] class148_0;

		public Class147(Class144 class144_0)
		{
			this.long_0 = class144_0.vmethod_13(64);
			this.byte_0 = (byte)class144_0.vmethod_10(8);
			class144_0.vmethod_15(this.byte_1, 12);
			this.int_0 = class144_0.vmethod_10(1);
			this.int_1 = class144_0.vmethod_10(1);
			class144_0.vmethod_5(110);
			this.byte_2 = (byte)class144_0.vmethod_10(8);
			if (this.byte_2 > 0)
			{
				this.class148_0 = new Class148[(int)this.byte_2];
				for (int i = 0; i < (int)this.byte_2; i++)
				{
					this.class148_0[i] = new Class148(class144_0);
				}
			}
		}
	}
}
