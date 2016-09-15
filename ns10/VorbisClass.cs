using ns3;
using System;

namespace ns10
{
	public class VorbisClass
	{
		private static int int_0 = -136;

		private static int int_1 = -135;

		private static string string_0 = "vorbis";

		private static int int_2 = 1;

		private static int int_3 = 2;

		private static int int_4 = 3;

		private static int int_5 = 1;

		private static int int_6 = 1;

		public int[] int_7 = new int[2];

		public int int_8;

		public int int_9;

		public int int_10;

		public int int_11;

		public int int_12;

		public int int_13;

		public int int_14;

		public Class64[] class64_0;

		public int[] int_15;

		public object[] object_0;

		public int[] int_16;

		public object[] object_1;

		public int[] int_17;

		public object[] object_2;

		public int[] int_18;

		public object[] object_3;

		public Class76[] class76_0;

		public Class53[] class53_0 = new Class53[64];

		public void method_0()
		{
			for (int i = 0; i < this.int_8; i++)
			{
				this.class64_0[i] = null;
			}
			this.class64_0 = null;
			for (int j = 0; j < this.int_9; j++)
			{
				Class45.class45_0[this.int_15[j]].vmethod_0(this.object_0[j]);
			}
			this.object_0 = null;
			for (int k = 0; k < this.int_10; k++)
			{
				Class72.class72_0[this.int_16[k]].vmethod_0(this.object_1[k]);
			}
			this.object_1 = null;
			for (int l = 0; l < this.int_11; l++)
			{
				Class41.class41_0[this.int_17[l]].vmethod_0(this.object_2[l]);
			}
			this.object_2 = null;
			for (int m = 0; m < this.int_12; m++)
			{
				Class57.class57_0[this.int_18[m]].vmethod_0(this.object_3[m]);
			}
			this.object_3 = null;
			for (int n = 0; n < this.int_13; n++)
			{
				if (this.class76_0[n] != null)
				{
					this.class76_0[n].method_0();
					this.class76_0[n] = null;
				}
			}
			this.class76_0 = null;
			for (int num = 0; num < this.int_14; num++)
			{
				this.class53_0[num].method_0();
			}
		}
	}
}
