using ns0;
using ns1;

namespace ns12
{
	public abstract class Class178 : INterface5
	{
		public abstract void vmethod_0(Class13 class130, Class13 class131);

		public abstract void vmethod_1(Class13 class130, Class13 class131, Class13 class132);

		public void imethod_0(Class13[] class130)
		{
			if (class130.Length == 2)
			{
				vmethod_0(class130[0], class130[1]);
				return;
			}
			if (class130.Length == 3)
			{
				vmethod_1(class130[0], class130[1], class130[2]);
			}
		}
	}
}
