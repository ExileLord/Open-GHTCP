using ns10;
using ns2;

namespace ns3
{
	public class OGGClass5
	{
		private static int int_0 = -136;

		private static int int_1 = -135;

		private static string string_0 = "vorbis";

		private static readonly int int_2 = 1;

		private static readonly int int_3 = 2;

		private static readonly int int_4 = 3;

		private static readonly int int_5 = 1;

		private static readonly int int_6 = 1;

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
			int_9 = 0;
		}

		public void method_1()
		{
			for (var i = 0; i < int_14; i++)
			{
				class27_0[i] = null;
			}
			class27_0 = null;
			for (var j = 0; j < int_15; j++)
			{
				Class34.class34_0[int_21[j]].vmethod_2(object_0[j]);
			}
			object_0 = null;
			for (var k = 0; k < int_16; k++)
			{
				Class50.class50_0[int_22[k]].vmethod_2(object_1[k]);
			}
			object_1 = null;
			for (var l = 0; l < int_17; l++)
			{
				Class28.class28_0[int_23[l]].vmethod_2(object_2[l]);
			}
			object_2 = null;
			for (var m = 0; m < int_18; m++)
			{
				Class23.class23_0[int_24[m]].vmethod_2(object_3[m]);
			}
			object_3 = null;
			for (var n = 0; n < int_19; n++)
			{
				if (oggClass2[n] != null)
				{
					oggClass2[n].method_2();
					oggClass2[n] = null;
				}
			}
			oggClass2 = null;
			for (var num = 0; num < int_20; num++)
			{
				class70_0[num].method_0();
			}
		}

		private int method_2(OGGClass3 oggClass3)
		{
			int_7 = oggClass3.method_6(32);
			if (int_7 != 0)
			{
				return -1;
			}
			int_8 = oggClass3.method_6(8);
			int_9 = oggClass3.method_6(32);
			int_10 = oggClass3.method_6(32);
			int_11 = oggClass3.method_6(32);
			int_12 = oggClass3.method_6(32);
			int_13[0] = 1 << oggClass3.method_6(4);
			int_13[1] = 1 << oggClass3.method_6(4);
			if (int_9 >= 1 && int_8 >= 1 && int_13[0] >= 8 && int_13[1] >= int_13[0])
			{
				if (oggClass3.method_6(1) == 1)
				{
					return 0;
				}
			}
			method_1();
			return -1;
		}

		private int method_3(OGGClass3 oggClass3)
		{
			int_19 = oggClass3.method_6(8) + 1;
			if (oggClass2 == null || oggClass2.Length != int_19)
			{
				oggClass2 = new OGGClass2[int_19];
			}
			for (var i = 0; i < int_19; i++)
			{
				oggClass2[i] = new OGGClass2();
				if (oggClass2[i].method_0(oggClass3) != 0)
				{
					method_1();
					return -1;
				}
			}
			int_16 = oggClass3.method_6(6) + 1;
			if (int_22 == null || int_22.Length != int_16)
			{
				int_22 = new int[int_16];
			}
			if (object_1 == null || object_1.Length != int_16)
			{
				object_1 = new object[int_16];
			}
			for (var j = 0; j < int_16; j++)
			{
				int_22[j] = oggClass3.method_6(16);
				if (int_22[j] < 0 || int_22[j] >= int_2)
				{
					method_1();
					return -1;
				}
				object_1[j] = Class50.class50_0[int_22[j]].vmethod_0(this, oggClass3);
				if (object_1[j] == null)
				{
					method_1();
					return -1;
				}
			}
			int_17 = oggClass3.method_6(6) + 1;
			if (int_23 == null || int_23.Length != int_17)
			{
				int_23 = new int[int_17];
			}
			if (object_2 == null || object_2.Length != int_17)
			{
				object_2 = new object[int_17];
			}
			for (var k = 0; k < int_17; k++)
			{
				int_23[k] = oggClass3.method_6(16);
				if (int_23[k] < 0 || int_23[k] >= int_3)
				{
					method_1();
					return -1;
				}
				object_2[k] = Class28.class28_0[int_23[k]].vmethod_0(this, oggClass3);
				if (object_2[k] == null)
				{
					method_1();
					return -1;
				}
			}
			int_18 = oggClass3.method_6(6) + 1;
			if (int_24 == null || int_24.Length != int_18)
			{
				int_24 = new int[int_18];
			}
			if (object_3 == null || object_3.Length != int_18)
			{
				object_3 = new object[int_18];
			}
			for (var l = 0; l < int_18; l++)
			{
				int_24[l] = oggClass3.method_6(16);
				if (int_24[l] < 0 || int_24[l] >= int_4)
				{
					method_1();
					return -1;
				}
				object_3[l] = Class23.class23_0[int_24[l]].vmethod_0(this, oggClass3);
				if (object_3[l] == null)
				{
					method_1();
					return -1;
				}
			}
			int_15 = oggClass3.method_6(6) + 1;
			if (int_21 == null || int_21.Length != int_15)
			{
				int_21 = new int[int_15];
			}
			if (object_0 == null || object_0.Length != int_15)
			{
				object_0 = new object[int_15];
			}
			for (var m = 0; m < int_15; m++)
			{
				int_21[m] = oggClass3.method_6(16);
				if (int_21[m] < 0 || int_21[m] >= int_5)
				{
					method_1();
					return -1;
				}
				object_0[m] = Class34.class34_0[int_21[m]].vmethod_0(this, oggClass3);
				if (object_0[m] == null)
				{
					method_1();
					return -1;
				}
			}
			int_14 = oggClass3.method_6(6) + 1;
			if (class27_0 == null || class27_0.Length != int_14)
			{
				class27_0 = new Class27[int_14];
			}
			for (var n = 0; n < int_14; n++)
			{
				class27_0[n] = new Class27();
				class27_0[n].int_0 = oggClass3.method_6(1);
				class27_0[n].int_1 = oggClass3.method_6(16);
				class27_0[n].int_2 = oggClass3.method_6(16);
				class27_0[n].int_3 = oggClass3.method_6(8);
				if (class27_0[n].int_1 >= int_6 || class27_0[n].int_2 >= int_6 || class27_0[n].int_3 >= int_15)
				{
					method_1();
					return -1;
				}
			}
			if (oggClass3.method_6(1) != 1)
			{
				method_1();
				return -1;
			}
			return 0;
		}

		public int method_4(Class47 class47_0, Class67 class67_0)
		{
			var @class = new OGGClass3();
			if (class67_0 != null)
			{
				@class.method_4(class67_0.byte_0, class67_0.int_0, class67_0.int_1);
				var array = new byte[6];
				var num = @class.method_6(8);
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
							if (int_9 != 0)
							{
								return -1;
							}
							return method_2(@class);
						case 2:
						case 4:
							return -1;
						case 3:
							if (int_9 == 0)
							{
								return -1;
							}
							return class47_0.method_1(@class);
						case 5:
							if (int_9 != 0 && class47_0.byte_1 != null)
							{
								return method_3(@class);
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
