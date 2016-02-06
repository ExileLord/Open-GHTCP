using ns0;
using ns1;
using System;

namespace ns8
{
	public abstract class Class175 : Interface5
	{
		public abstract void vmethod_0(Class13 class13_0);

		public abstract void vmethod_1(Class13 class13_0, Class13 class13_1);

		public void imethod_0(Class13[] class13_0)
		{
			if (class13_0.Length == 1)
			{
				this.vmethod_0(class13_0[0]);
				return;
			}
			for (int i = 1; i < class13_0.Length; i++)
			{
				this.vmethod_1(class13_0[0], class13_0[i]);
			}
		}
	}
}
