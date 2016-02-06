using ns7;
using System;

namespace ns6
{
	public class Class124 : Class121
	{
		private readonly byte[] byte_0 = new byte[4];

		private readonly byte[] byte_1;

		public Class124(Class144 class144_0, int int_0, bool bool_1) : base(bool_1)
		{
			class144_0.vmethod_15(this.byte_0, 4);
			int_0 -= 4;
			if (int_0 > 0)
			{
				this.byte_1 = new byte[int_0];
				class144_0.vmethod_15(this.byte_1, int_0);
			}
		}
	}
}
