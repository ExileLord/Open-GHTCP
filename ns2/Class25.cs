using ns10;

namespace ns2
{
	public class Class25 : Class24
	{
		public override int vmethod_3(OGGClass6 class71_0, object object_0, float[][] float_0, int[] int_1, int int_2)
		{
			var num = 0;
			while (num < int_2 && int_1[num] == 0)
			{
				num++;
			}
			if (num == int_2)
			{
				return 0;
			}
			return smethod_1(class71_0, object_0, float_0, int_2);
		}
	}
}
