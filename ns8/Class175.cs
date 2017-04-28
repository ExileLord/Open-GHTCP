using ns0;
using ns1;

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
				vmethod_0(class13_0[0]);
				return;
			}
			for (int i = 1; i < class13_0.Length; i++)
			{
				vmethod_1(class13_0[0], class13_0[i]);
			}
		}
	}
}
