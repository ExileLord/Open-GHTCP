using ns0;
using ns1;

namespace ns8
{
	public abstract class Class172 : Interface5
	{
		public abstract void vmethod_0(Class13 class13_0);

		public void imethod_0(Class13[] class13_0)
		{
			for (int i = 0; i < class13_0.Length; i++)
			{
				Class13 class13_ = class13_0[i];
				vmethod_0(class13_);
			}
		}
	}
}
