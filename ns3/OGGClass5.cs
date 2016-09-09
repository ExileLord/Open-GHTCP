using ns10;
using ns2;
using System;

namespace ns3
{
	public class OGGClass5
	{
		private static int int_0 = -136;

		private static int int_1 = -135;

		private static string string_0 = "vorbis";

		private static int int_2 = 1;

		private static int int_3 = 2;

		private static int int_4 = 3;

		private static int int_5 = 1;

		private static int int_6 = 1;

		public int int_7;

		public int int_8;

		public int int_9;

		public int int_10;

		public int int_11;

		public int int_12;

		public int[] int_13 = new int[2];

		public int int_14;

		public int int_15;

		public int int_16;

		public int int_17;

		public int int_18;

		public int int_19;

		public int int_20;

		public Class27[] class27_0;

		public int[] int_21;

		public object[] object_0;

		public int[] int_22;

		public object[] object_1;

		public int[] int_23;

		public object[] object_2;

		public int[] int_24;

		public object[] object_3;

		public OGGClass2[] oggClass2;

		public Class70[] class70_0 = new Class70[64];

		public void method_0()
		{
			this.int_9 = 0;
		}

		public void method_1()
		{
			for (int i = 0; i < this.int_14; i++)
			{
				this.class27_0[i] = null;
			}
			this.class27_0 = null;
			for (int j = 0; j < this.int_15; j++)
			{
				Class34.class34_0[this.int_21[j]].vmethod_2(this.object_0[j]);
			}
			this.object_0 = null;
			for (int k = 0; k < this.int_16; k++)
			{
				Class50.class50_0[this.int_22[k]].vmethod_2(this.object_1[k]);
			}
			this.object_1 = null;
			for (int l = 0; l < this.int_17; l++)
			{
				Class28.class28_0[this.int_23[l]].vmethod_2(this.object_2[l]);
			}
			this.object_2 = null;
			for (int m = 0; m < this.int_18; m++)
			{
				Class23.class23_0[this.int_24[m]].vmethod_2(this.object_3[m]);
			}
			this.object_3 = null;
			for (int n = 0; n < this.int_19; n++)
			{
				if (this.oggClass2[n] != null)
				{
					this.oggClass2[n].method_2();
					this.oggClass2[n] = null;
				}
			}
			this.oggClass2 = null;
			for (int num = 0; num < this.int_20; num++)
			{
				this.class70_0[num].method_0();
			}
		}

		private int method_2(OGGClass3 oggClass3)
		{
			this.int_7 = oggClass3.method_6(32);
			if (this.int_7 != 0)
			{
				return -1;
			}
			this.int_8 = oggClass3.method_6(8);
			this.int_9 = oggClass3.method_6(32);
			this.int_10 = oggClass3.method_6(32);
			this.int_11 = oggClass3.method_6(32);
			this.int_12 = oggClass3.method_6(32);
			this.int_13[0] = 1 << oggClass3.method_6(4);
			this.int_13[1] = 1 << oggClass3.method_6(4);
			if (this.int_9 >= 1 && this.int_8 >= 1 && this.int_13[0] >= 8 && this.int_13[1] >= this.int_13[0])
			{
				if (oggClass3.method_6(1) == 1)
				{
					return 0;
				}
			}
			this.method_1();
			return -1;
		}

		private int method_3(OGGClass3 oggClass3)
		{
			this.int_19 = oggClass3.method_6(8) + 1;
			if (this.oggClass2 == null || this.oggClass2.Length != this.int_19)
			{
				this.oggClass2 = new OGGClass2[this.int_19];
			}
			for (int i = 0; i < this.int_19; i++)
			{
				this.oggClass2[i] = new OGGClass2();
				if (this.oggClass2[i].method_0(oggClass3) != 0)
				{
					this.method_1();
					return -1;
				}
			}
			this.int_16 = oggClass3.method_6(6) + 1;
			if (this.int_22 == null || this.int_22.Length != this.int_16)
			{
				this.int_22 = new int[this.int_16];
			}
			if (this.object_1 == null || this.object_1.Length != this.int_16)
			{
				this.object_1 = new object[this.int_16];
			}
			for (int j = 0; j < this.int_16; j++)
			{
				this.int_22[j] = oggClass3.method_6(16);
				if (this.int_22[j] < 0 || this.int_22[j] >= OGGClass5.int_2)
				{
					this.method_1();
					return -1;
				}
				this.object_1[j] = Class50.class50_0[this.int_22[j]].vmethod_0(this, oggClass3);
				if (this.object_1[j] == null)
				{
					this.method_1();
					return -1;
				}
			}
			this.int_17 = oggClass3.method_6(6) + 1;
			if (this.int_23 == null || this.int_23.Length != this.int_17)
			{
				this.int_23 = new int[this.int_17];
			}
			if (this.object_2 == null || this.object_2.Length != this.int_17)
			{
				this.object_2 = new object[this.int_17];
			}
			for (int k = 0; k < this.int_17; k++)
			{
				this.int_23[k] = oggClass3.method_6(16);
				if (this.int_23[k] < 0 || this.int_23[k] >= OGGClass5.int_3)
				{
					this.method_1();
					return -1;
				}
				this.object_2[k] = Class28.class28_0[this.int_23[k]].vmethod_0(this, oggClass3);
				if (this.object_2[k] == null)
				{
					this.method_1();
					return -1;
				}
			}
			this.int_18 = oggClass3.method_6(6) + 1;
			if (this.int_24 == null || this.int_24.Length != this.int_18)
			{
				this.int_24 = new int[this.int_18];
			}
			if (this.object_3 == null || this.object_3.Length != this.int_18)
			{
				this.object_3 = new object[this.int_18];
			}
			for (int l = 0; l < this.int_18; l++)
			{
				this.int_24[l] = oggClass3.method_6(16);
				if (this.int_24[l] < 0 || this.int_24[l] >= OGGClass5.int_4)
				{
					this.method_1();
					return -1;
				}
				this.object_3[l] = Class23.class23_0[this.int_24[l]].vmethod_0(this, oggClass3);
				if (this.object_3[l] == null)
				{
					this.method_1();
					return -1;
				}
			}
			this.int_15 = oggClass3.method_6(6) + 1;
			if (this.int_21 == null || this.int_21.Length != this.int_15)
			{
				this.int_21 = new int[this.int_15];
			}
			if (this.object_0 == null || this.object_0.Length != this.int_15)
			{
				this.object_0 = new object[this.int_15];
			}
			for (int m = 0; m < this.int_15; m++)
			{
				this.int_21[m] = oggClass3.method_6(16);
				if (this.int_21[m] < 0 || this.int_21[m] >= OGGClass5.int_5)
				{
					this.method_1();
					return -1;
				}
				this.object_0[m] = Class34.class34_0[this.int_21[m]].vmethod_0(this, oggClass3);
				if (this.object_0[m] == null)
				{
					this.method_1();
					return -1;
				}
			}
			this.int_14 = oggClass3.method_6(6) + 1;
			if (this.class27_0 == null || this.class27_0.Length != this.int_14)
			{
				this.class27_0 = new Class27[this.int_14];
			}
			for (int n = 0; n < this.int_14; n++)
			{
				this.class27_0[n] = new Class27();
				this.class27_0[n].int_0 = oggClass3.method_6(1);
				this.class27_0[n].int_1 = oggClass3.method_6(16);
				this.class27_0[n].int_2 = oggClass3.method_6(16);
				this.class27_0[n].int_3 = oggClass3.method_6(8);
				if (this.class27_0[n].int_1 >= OGGClass5.int_6 || this.class27_0[n].int_2 >= OGGClass5.int_6 || this.class27_0[n].int_3 >= this.int_15)
				{
					this.method_1();
					return -1;
				}
			}
			if (oggClass3.method_6(1) != 1)
			{
				this.method_1();
				return -1;
			}
			return 0;
		}

		public int method_4(Class47 class47_0, Class67 class67_0)
		{
			OGGClass3 @class = new OGGClass3();
			if (class67_0 != null)
			{
				@class.method_4(class67_0.byte_0, class67_0.int_0, class67_0.int_1);
				byte[] array = new byte[6];
				int num = @class.method_6(8);
				@class.method_5(array, 6);
				if (array[0] == 118 && array[1] == 111 && array[2] == 114 && array[3] == 98 && array[4] == 105)
				{
					if (array[5] == 115)
					{
						switch (num)
						{
						case 1:
							if (class67_0.int_2 == 0)
							{
								return -1;
							}
							if (this.int_9 != 0)
							{
								return -1;
							}
							return this.method_2(@class);
						case 2:
						case 4:
							return -1;
						case 3:
							if (this.int_9 == 0)
							{
								return -1;
							}
							return class47_0.method_1(@class);
						case 5:
							if (this.int_9 != 0 && class47_0.byte_1 != null)
							{
								return this.method_3(@class);
							}
							return -1;
						default:
							return -1;
						}
					}
				}
				return -1;
			}
			return -1;
		}
	}
}
