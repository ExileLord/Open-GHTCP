using System;

namespace ns7
{
	public class Class143
	{
		public int[] int_0;

		public int[] int_1;

		public int int_2;

		public virtual void vmethod_0(int int_3)
		{
			if (this.int_2 >= int_3)
			{
				return;
			}
			this.int_0 = new int[1 << int_3];
			this.int_1 = new int[1 << int_3];
			this.int_2 = int_3;
		}
	}
}
