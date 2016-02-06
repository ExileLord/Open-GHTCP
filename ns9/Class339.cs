using ns22;
using System;

namespace ns9
{
	public class Class339 : Class335
	{
		private readonly int int_1;

		public Class339(int int_2, int int_3)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
		}

		public int method_1()
		{
			return this.int_1;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} BPM", base.method_0(), Class348.smethod_2((float)this.int_1));
		}
	}
}
