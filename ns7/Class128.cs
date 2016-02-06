using ns6;
using System;

namespace ns7
{
	public class Class128 : Class121
	{
		private int int_0;

		public Class128(Class144 class144_0, int int_1, bool bool_1) : base(bool_1)
		{
			this.int_0 = int_1;
			class144_0.vmethod_15(null, int_1);
		}

		public override string ToString()
		{
			return "Padding (Length=" + this.int_0 + ")";
		}
	}
}
