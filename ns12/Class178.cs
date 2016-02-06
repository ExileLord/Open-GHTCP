using ns0;
using ns1;
using System;

namespace ns12
{
	public abstract class Class178 : Interface5
	{
		public abstract void vmethod_0(Class13 class13_0, Class13 class13_1);

		public abstract void vmethod_1(Class13 class13_0, Class13 class13_1, Class13 class13_2);

		public void imethod_0(Class13[] class13_0)
		{
			if (class13_0.Length == 2)
			{
				this.vmethod_0(class13_0[0], class13_0[1]);
				return;
			}
			if (class13_0.Length == 3)
			{
				this.vmethod_1(class13_0[0], class13_0[1], class13_0[2]);
			}
		}
	}
}
