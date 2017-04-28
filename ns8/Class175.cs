using ns0;
using ns1;

namespace ns8
{
	public abstract class Class175 : INterface5
	{
		public abstract void vmethod_0(Class13 class130);

		public abstract void vmethod_1(Class13 class130, Class13 class131);

		public void imethod_0(Class13[] class130)
		{
			if (class130.Length == 1)
			{
				vmethod_0(class130[0]);
				return;
			}
			for (var i = 1; i < class130.Length; i++)
			{
				vmethod_1(class130[0], class130[i]);
			}
		}
	}
}
