using GHNamespace3;

namespace GHNamespaceD
{
	public class Class25 : Class24
	{
		public override int vmethod_3(OggClass6 class710, object object0, float[][] float0, int[] int1, int int2)
		{
			var num = 0;
			while (num < int2 && int1[num] == 0)
			{
				num++;
			}
			if (num == int2)
			{
				return 0;
			}
			return smethod_1(class710, object0, float0, int2);
		}
	}
}
