using GHNamespace1;
using ns1;

namespace ns8
{
	public abstract class Class177 : INterface5
	{
		public abstract void vmethod_0(Class13 class130, Class13 class131, Class13 class132);

		public void imethod_0(Class13[] class130)
		{
			for (var i = 0; i < class130.Length; i += 3)
			{
				vmethod_0(class130[i], class130[i + 1], class130[i + 2]);
			}
		}
	}
}
