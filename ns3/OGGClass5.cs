using ns10;
using ns2;

namespace ns3
{
	public class OggClass5
	{
		private static int _int0 = -136;

		private static int _int1 = -135;

		private static string _string0 = "vorbis";

		private static readonly int Int2 = 1;

		private static readonly int Int3 = 2;

		private static readonly int Int4 = 3;

		private static readonly int Int5 = 1;

		private static readonly int Int6 = 1;

		public int Int7;

		public int Int8;

		public int Int9;

		public int Int10;

		public int Int11;

		public int Int12;

		public int[] Int13 = new int[2];

		public int Int14;

		public int Int15;

		public int Int16;

		public int Int17;

		public int Int18;

		public int Int19;

		public int Int20;

		public Class27[] Class270;

		public int[] Int21;

		public object[] Object0;

		public int[] Int22;

		public object[] Object1;

		public int[] Int23;

		public object[] Object2;

		public int[] Int24;

		public object[] Object3;

		public OggClass2[] OggClass2;

		public Class70[] Class700 = new Class70[64];

		public void method_0()
		{
			Int9 = 0;
		}

		public void method_1()
		{
			for (var i = 0; i < Int14; i++)
			{
				Class270[i] = null;
			}
			Class270 = null;
			for (var j = 0; j < Int15; j++)
			{
				Class34.Class340[Int21[j]].vmethod_2(Object0[j]);
			}
			Object0 = null;
			for (var k = 0; k < Int16; k++)
			{
				Class50.Class500[Int22[k]].vmethod_2(Object1[k]);
			}
			Object1 = null;
			for (var l = 0; l < Int17; l++)
			{
				Class28.Class280[Int23[l]].vmethod_2(Object2[l]);
			}
			Object2 = null;
			for (var m = 0; m < Int18; m++)
			{
				Class23.Class230[Int24[m]].vmethod_2(Object3[m]);
			}
			Object3 = null;
			for (var n = 0; n < Int19; n++)
			{
				if (OggClass2[n] != null)
				{
					OggClass2[n].method_2();
					OggClass2[n] = null;
				}
			}
			OggClass2 = null;
			for (var num = 0; num < Int20; num++)
			{
				Class700[num].method_0();
			}
		}

		private int method_2(OggClass3 oggClass3)
		{
			Int7 = oggClass3.method_6(32);
			if (Int7 != 0)
			{
				return -1;
			}
			Int8 = oggClass3.method_6(8);
			Int9 = oggClass3.method_6(32);
			Int10 = oggClass3.method_6(32);
			Int11 = oggClass3.method_6(32);
			Int12 = oggClass3.method_6(32);
			Int13[0] = 1 << oggClass3.method_6(4);
			Int13[1] = 1 << oggClass3.method_6(4);
			if (Int9 >= 1 && Int8 >= 1 && Int13[0] >= 8 && Int13[1] >= Int13[0])
			{
				if (oggClass3.method_6(1) == 1)
				{
					return 0;
				}
			}
			method_1();
			return -1;
		}

		private int method_3(OggClass3 oggClass3)
		{
			Int19 = oggClass3.method_6(8) + 1;
			if (OggClass2 == null || OggClass2.Length != Int19)
			{
				OggClass2 = new OggClass2[Int19];
			}
			for (var i = 0; i < Int19; i++)
			{
				OggClass2[i] = new OggClass2();
				if (OggClass2[i].method_0(oggClass3) != 0)
				{
					method_1();
					return -1;
				}
			}
			Int16 = oggClass3.method_6(6) + 1;
			if (Int22 == null || Int22.Length != Int16)
			{
				Int22 = new int[Int16];
			}
			if (Object1 == null || Object1.Length != Int16)
			{
				Object1 = new object[Int16];
			}
			for (var j = 0; j < Int16; j++)
			{
				Int22[j] = oggClass3.method_6(16);
				if (Int22[j] < 0 || Int22[j] >= Int2)
				{
					method_1();
					return -1;
				}
				Object1[j] = Class50.Class500[Int22[j]].vmethod_0(this, oggClass3);
				if (Object1[j] == null)
				{
					method_1();
					return -1;
				}
			}
			Int17 = oggClass3.method_6(6) + 1;
			if (Int23 == null || Int23.Length != Int17)
			{
				Int23 = new int[Int17];
			}
			if (Object2 == null || Object2.Length != Int17)
			{
				Object2 = new object[Int17];
			}
			for (var k = 0; k < Int17; k++)
			{
				Int23[k] = oggClass3.method_6(16);
				if (Int23[k] < 0 || Int23[k] >= Int3)
				{
					method_1();
					return -1;
				}
				Object2[k] = Class28.Class280[Int23[k]].vmethod_0(this, oggClass3);
				if (Object2[k] == null)
				{
					method_1();
					return -1;
				}
			}
			Int18 = oggClass3.method_6(6) + 1;
			if (Int24 == null || Int24.Length != Int18)
			{
				Int24 = new int[Int18];
			}
			if (Object3 == null || Object3.Length != Int18)
			{
				Object3 = new object[Int18];
			}
			for (var l = 0; l < Int18; l++)
			{
				Int24[l] = oggClass3.method_6(16);
				if (Int24[l] < 0 || Int24[l] >= Int4)
				{
					method_1();
					return -1;
				}
				Object3[l] = Class23.Class230[Int24[l]].vmethod_0(this, oggClass3);
				if (Object3[l] == null)
				{
					method_1();
					return -1;
				}
			}
			Int15 = oggClass3.method_6(6) + 1;
			if (Int21 == null || Int21.Length != Int15)
			{
				Int21 = new int[Int15];
			}
			if (Object0 == null || Object0.Length != Int15)
			{
				Object0 = new object[Int15];
			}
			for (var m = 0; m < Int15; m++)
			{
				Int21[m] = oggClass3.method_6(16);
				if (Int21[m] < 0 || Int21[m] >= Int5)
				{
					method_1();
					return -1;
				}
				Object0[m] = Class34.Class340[Int21[m]].vmethod_0(this, oggClass3);
				if (Object0[m] == null)
				{
					method_1();
					return -1;
				}
			}
			Int14 = oggClass3.method_6(6) + 1;
			if (Class270 == null || Class270.Length != Int14)
			{
				Class270 = new Class27[Int14];
			}
			for (var n = 0; n < Int14; n++)
			{
				Class270[n] = new Class27();
				Class270[n].Int0 = oggClass3.method_6(1);
				Class270[n].Int1 = oggClass3.method_6(16);
				Class270[n].Int2 = oggClass3.method_6(16);
				Class270[n].Int3 = oggClass3.method_6(8);
				if (Class270[n].Int1 >= Int6 || Class270[n].Int2 >= Int6 || Class270[n].Int3 >= Int15)
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

		public int method_4(Class47 class470, Class67 class670)
		{
			var @class = new OggClass3();
			if (class670 != null)
			{
				@class.method_4(class670.Byte0, class670.Int0, class670.Int1);
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
							if (class670.Int2 == 0)
							{
								return -1;
							}
							if (Int9 != 0)
							{
								return -1;
							}
							return method_2(@class);
						case 2:
						case 4:
							return -1;
						case 3:
							if (Int9 == 0)
							{
								return -1;
							}
							return class470.method_1(@class);
						case 5:
							if (Int9 != 0 && class470.Byte1 != null)
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
