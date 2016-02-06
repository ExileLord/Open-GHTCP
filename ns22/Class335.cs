using System;

namespace ns22
{
	public abstract class Class335
	{
		public int int_0;

		public int method_0()
		{
			return this.int_0;
		}

		public static int smethod_0(Class335 class335_0, Class335 class335_1)
		{
			if (!(class335_0 is Class336) || !(class335_1 is Class336) || class335_0.method_0() != class335_1.method_0())
			{
				return class335_0.method_0() - class335_1.method_0();
			}
			bool flag = ((Class336)class335_0).method_5();
			bool flag2 = ((Class336)class335_1).method_5();
			if (flag && !flag2)
			{
				return 1;
			}
			if (flag2 && !flag)
			{
				return -1;
			}
			return 0;
		}
	}
}
