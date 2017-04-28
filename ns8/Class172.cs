using ns0;
using ns1;

namespace ns8
{
	public abstract class Class172 : INterface5
	{
		public abstract void vmethod_0(Class13 class130);

		public void imethod_0(Class13[] class130)
		{
			for (var i = 0; i < class130.Length; i++)
			{
				var class13 = class130[i];
				vmethod_0(class13);
			}
		}
	}
}
