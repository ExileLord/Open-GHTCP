using ns10;

namespace ns2
{
	public class Class26 : Class24
	{
		public override int vmethod_3(OGGClass6 class71_0, object object_0, float[][] float_0, int[] int_1, int int_2)
		{
			var num = 0;
			for (var i = 0; i < int_2; i++)
			{
				if (int_1[i] != 0)
				{
					float_0[num++] = float_0[i];
				}
			}
			if (num != 0)
			{
				return smethod_0(class71_0, object_0, float_0, num, 1);
			}
			return 0;
		}
	}
}
