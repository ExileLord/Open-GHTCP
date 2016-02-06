using System;

namespace ns2
{
	public class Class31
	{
		public int int_0;

		public int[] int_1 = new int[31];

		public int[] int_2 = new int[16];

		public int[] int_3 = new int[16];

		public int[] int_4 = new int[16];

		public int[][] int_5 = new int[16][];

		public int int_6;

		public int[] int_7 = new int[65];

		public Class31()
		{
			for (int i = 0; i < this.int_5.Length; i++)
			{
				this.int_5[i] = new int[8];
			}
		}

		public void method_0()
		{
			this.int_1 = null;
			this.int_2 = null;
			this.int_3 = null;
			this.int_4 = null;
			this.int_5 = null;
			this.int_7 = null;
		}
	}
}
