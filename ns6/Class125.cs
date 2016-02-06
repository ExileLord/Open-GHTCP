using ns7;
using System;

namespace ns6
{
	public class Class125 : Class121
	{
		public byte[] byte_0 = new byte[129];

		public long long_0;

		public bool bool_1;

		public int int_0;

		public Class147[] class147_0;

		public Class125(Class144 class144_0, int int_1, bool bool_2) : base(bool_2)
		{
			class144_0.vmethod_15(this.byte_0, 128);
			this.long_0 = class144_0.vmethod_13(64);
			this.bool_1 = (class144_0.vmethod_10(1) != 0);
			class144_0.vmethod_5(2071);
			this.int_0 = class144_0.vmethod_10(8);
			if (this.int_0 > 0)
			{
				this.class147_0 = new Class147[this.int_0];
				for (int i = 0; i < this.int_0; i++)
				{
					this.class147_0[i] = new Class147(class144_0);
				}
			}
		}
	}
}
