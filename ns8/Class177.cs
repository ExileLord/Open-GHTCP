using ns0;
using ns1;

namespace ns8
{
	public abstract class Class177 : Interface5
	{
		public abstract void vmethod_0(Class13 class13_0, Class13 class13_1, Class13 class13_2);

		public void imethod_0(Class13[] class13_0)
		{
			for (int i = 0; i < class13_0.Length; i += 3)
			{
				vmethod_0(class13_0[i], class13_0[i + 1], class13_0[i + 2]);
			}
		}
	}
}
