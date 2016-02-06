using ns7;
using System;

namespace ns6
{
	public class Class138 : Class137
	{
		public int int_0;

		public Class143 class143_0;

		public virtual void vmethod_0(Class144 class144_0, int int_1, int int_2, Class140 class140_0, int[] int_3)
		{
			int num = 0;
			int num2 = 1 << int_2;
			int num3 = (int_2 > 0) ? (class140_0.int_0 >> int_2) : (class140_0.int_0 - int_1);
			this.class143_0.vmethod_0(Math.Max(6, int_2));
			this.class143_0.int_0 = new int[num2];
			for (int i = 0; i < num2; i++)
			{
				int num4 = class144_0.vmethod_10(4);
				this.class143_0.int_0[i] = num4;
				if (num4 < 15)
				{
					int num5 = (int_2 == 0 || i > 0) ? num3 : (num3 - int_1);
					class144_0.vmethod_17(int_3, num, num5, num4);
					num += num5;
				}
				else
				{
					num4 = class144_0.vmethod_10(5);
					this.class143_0.int_1[i] = num4;
					int j = (int_2 == 0 || i > 0) ? 0 : int_1;
					while (j < num3)
					{
						int_3[num] = class144_0.vmethod_12(num4);
						j++;
						num++;
					}
				}
			}
		}
	}
}
