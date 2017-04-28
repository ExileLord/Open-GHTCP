using System.IO;
using AVTools.MpegUtils;
using SharpAudio.ASC.Ac3.Decoding;

namespace ns5
{
	public class AC3Class1
	{
		public int int_0;

		private static double double_0;

		private static double double_1;

		private static double double_2;

		private static double double_3;

		private static double double_4;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private double double_5;

		private double double_6;

		private bool bool_0;

		private int int_8;

		private double double_7 = 200.0;

		public bool bool_1;

		private double double_8;

		private int int_9;

		private bool bool_2;

		private int int_10;

		private int int_11;

		private int int_12;

		private int int_13;

		private int int_14;

		private readonly double[][] double_9 = new double[5][];

		private int int_15;

		private readonly int[] int_16 = new int[5];

		private readonly byte[] byte_0 = new byte[256];

		private readonly byte[][] byte_1 = new byte[5][];

		private readonly byte[] byte_2 = new byte[256];

		private readonly byte[] byte_3 = new byte[256];

		private readonly byte[][] byte_4 = new byte[5][];

		private readonly byte[] byte_5 = new byte[256];

		private int int_17;

		private int int_18;

		private int int_19;

		private readonly int[] int_20 = new int[50];

		private readonly int[] int_21 = new int[5];

		private readonly int[] int_22 = new int[5];

		private readonly int[][] int_23 = new int[5][];

		private int int_24;

		private int int_25;

		private readonly int[] int_26 = new int[50];

		private int int_27;

		private int int_28;

		private int int_29;

		private int int_30 = 1;

		private readonly Class113 class113_0 = new Class113();

		private readonly double[] double_10 = new double[3584];

		private bool bool_3;

		public Class115 class115_0 = new Class115();

		public static readonly int[] int_31;

		public static readonly int[] int_32;

		public static readonly int[] int_33;

		public static readonly double[] double_11;

		public static readonly double[] double_12;

		public byte[] byte_6;

		public byte[] byte_7;

		public byte[] byte_8;

		public int[] int_34;

		public double[] double_13;

		public double[] double_14;

		public double[] double_15;

		public double[] double_16;

		public double[] double_17;

		public double[] double_18;

		public double[] double_19;

		public double[] double_20;

		public double[] double_21;

		public double[] double_22;

		public double[] double_23;

		public Class110 class110_0 = new Class110();

		public static readonly int[] int_35;

		public static readonly int[] int_36;

		public static readonly int[] int_37;

		private static readonly int[] int_38;

		private static readonly int[] int_39;

		private static readonly int[] int_40;

		private static readonly int[][] int_41;

		private static readonly int[] int_42;

		private static readonly byte[] byte_9;

		private static readonly int[] int_43;

		private static readonly int[] int_44;

		private bool bool_4 = true;

		public AC3Class1()
		{
			method_0();
		}

		private void method_0()
		{
			for (var i = 0; i < 5; i++)
			{
				double_9[i] = new double[18];
			}
			for (var j = 0; j < 5; j++)
			{
				byte_1[j] = new byte[256];
			}
			for (var k = 0; k < 5; k++)
			{
				byte_4[k] = new byte[256];
			}
			for (var l = 0; l < 5; l++)
			{
				int_23[l] = new int[50];
			}
			byte_6 = Class114.smethod_0();
			byte_7 = Class114.smethod_1();
			byte_8 = Class114.smethod_2();
			int_34 = Class114.smethod_3();
			double_13 = Class114.smethod_4();
			double_14 = Class114.smethod_5();
			double_15 = Class114.smethod_6();
			double_16 = Class114.smethod_7();
			double_17 = Class114.smethod_8();
			double_18 = Class114.smethod_9();
			double_19 = Class114.smethod_10();
			double_20 = Class114.smethod_11();
			double_21 = Class114.smethod_12();
			double_22 = Class114.smethod_13();
			double_23 = Class114.smethod_14();
		}

		private bool method_1()
		{
			while (class115_0.method_3(16) != 2935)
			{
				class115_0.method_2(8);
				if (class115_0.method_1() <= 56)
				{
					return false;
				}
			}
			class115_0.method_2(16);
			class115_0.method_2(16);
			var num = class115_0.method_2(8);
			var num2 = class115_0.method_2(8);
			var num3 = class115_0.method_2(8);
			var num4 = int_31[num2 >> 3];
			var num5 = num3 >> 5;
			int_1 = ((((num3 & 248) == 80) ? 10 : num5) | (((num3 & int_33[num5]) != 0) ? 16 : 0));
			var num6 = num & 63;
			if (num6 >= 38)
			{
				throw new AC3Exception("Unknown rate");
			}
			int_3 = int_32[num6 >> 1] * 1000 >> num4;
			var num7 = num & 192;
			if (num7 != 0)
			{
				if (num7 != 64)
				{
					if (num7 != 128)
					{
						throw new AC3Exception("Unrecognised sample rate multiplier");
					}
					int_2 = 32000 >> num4;
					int_4 = 6 * int_32[num6 >> 1];
				}
				else
				{
					int_2 = 44100 >> num4;
					int_4 = 2 * (320 * int_32[num6 >> 1] / 147 + (num6 & 1));
				}
			}
			else
			{
				int_2 = 48000 >> num4;
				int_4 = 4 * int_32[num6 >> 1];
			}
			class115_0.vmethod_3(class115_0.vmethod_0() - 56);
			return true;
		}

		private void method_2()
		{
			class115_0.method_2(32);
			int_5 = class115_0.method_2(3);
			class115_0.method_2(5);
			var num = class115_0.method_2(5);
			if (num >= int_31.Length)
			{
				throw new FFMpegException("Illegal half rate");
			}
			int_6 = int_31[num];
			class115_0.method_2(3);
			int_7 = class115_0.method_2(3);
			if (int_7 == 2)
			{
				class115_0.method_2(2);
			}
			double_5 = 0.0;
			if ((int_7 & 1) != 0 && int_7 != 1)
			{
				double_5 = double_11[class115_0.method_2(2)];
			}
			double_6 = 0.0;
			if ((int_7 & 4) != 0)
			{
				double_6 = double_12[class115_0.method_2(2)];
			}
			bool_0 = class115_0.vmethod_1();
			double_7 = 2.0;
			method_10(int_7);
			double_7 *= 2.0;
			double_8 = double_7;
			bool_1 = false;
			var flag = int_7 == 0;
			do
			{
				class115_0.method_2(5);
				if (class115_0.vmethod_1())
				{
					class115_0.method_2(8);
				}
				if (class115_0.vmethod_1())
				{
					int_8 = class115_0.method_2(8);
				}
				if (class115_0.vmethod_1())
				{
					class115_0.method_2(7);
				}
			}
			while (!(flag = !flag));
			class115_0.method_2(2);
			if (class115_0.vmethod_1())
			{
				class115_0.method_2(14);
			}
			if (class115_0.vmethod_1())
			{
				class115_0.method_2(14);
			}
			if (class115_0.vmethod_1())
			{
				var num2 = class115_0.method_2(6);
				class115_0.vmethod_3(class115_0.vmethod_0() + num2 * 8);
			}
		}

		private void method_3()
		{
			var num = int_35[int_7];
			var array = new bool[5];
			for (var i = 0; i < num; i++)
			{
				array[i] = class115_0.vmethod_1();
			}
			var array2 = new bool[5];
			for (var j = 0; j < num; j++)
			{
				array2[j] = class115_0.vmethod_1();
			}
			var flag = int_7 == 0;
			do
			{
				if (class115_0.vmethod_1())
				{
					var num2 = method_8(8);
					if (bool_1)
					{
						double_8 = (((num2 & 31) | 32) << 13) * double_13[2 - (num2 >> 5)] * double_7;
					}
				}
			}
			while (!(flag = !flag));
			if (class115_0.vmethod_1())
			{
				int_9 = 0;
				if (class115_0.vmethod_1())
				{
					for (var k = 0; k < num; k++)
					{
						int_9 |= class115_0.method_2(1) << k;
					}
					switch (int_7)
					{
					case 0:
					case 1:
						throw new AC3Exception("Invalid mode");
					case 2:
						bool_2 = class115_0.vmethod_1();
						break;
					}
					var num3 = class115_0.method_2(4);
					var num4 = class115_0.method_2(4);
					if (num4 + 3 - num3 < 0)
					{
						throw new AC3Exception("Invalid values");
					}
					int_10 = num4 + 3 - num3;
					int_11 = int_36[num3];
					int_12 = num3 * 12 + 37;
					int_13 = num4 * 12 + 73;
					int_14 = 0;
					var num5 = int_10;
					for (var l = 0; l < num5 - 1; l++)
					{
						if (class115_0.vmethod_1())
						{
							int_14 |= 1 << l;
							int_10--;
						}
					}
				}
			}
			if (int_9 != 0)
			{
				var flag2 = false;
				for (var m = 0; m < num; m++)
				{
					if ((int_9 >> m & 1) != 0 && class115_0.vmethod_1())
					{
						flag2 = true;
						var num6 = 3 * class115_0.method_2(2);
						for (var n = 0; n < int_10; n++)
						{
							var num7 = class115_0.method_2(4);
							var num8 = class115_0.method_2(4);
							if (num7 == 15)
							{
								num8 <<= 14;
							}
							else
							{
								num8 = (num8 | 16) << 13;
							}
							double_9[m][n] = num8 * double_13[num7 + num6];
						}
					}
				}
				if (int_7 == 2 && bool_2 && flag2)
				{
					for (var num9 = 0; num9 < int_10; num9++)
					{
						if (class115_0.vmethod_1())
						{
							double_9[1][num9] = -double_9[1][num9];
						}
					}
				}
			}
			if (int_7 == 2 && class115_0.vmethod_1())
			{
				int_15 = 0;
				var num10 = (int_9 != 0) ? int_12 : 253;
				var num11 = 0;
				do
				{
					int_15 |= class115_0.method_2(1) << num11;
				}
				while (int_37[num11++] < num10);
			}
			var num12 = 0;
			var num13 = 0;
			if (int_9 != 0)
			{
				num12 = class115_0.method_2(2);
			}
			var array3 = new int[5];
			for (var num14 = 0; num14 < num; num14++)
			{
				array3[num14] = class115_0.method_2(2);
			}
			if (bool_0)
			{
				num13 = class115_0.method_2(1);
			}
			for (var num15 = 0; num15 < num; num15++)
			{
				if (array3[num15] != 0)
				{
					if ((int_9 >> num15 & 1) != 0)
					{
						int_16[num15] = int_12;
					}
					else
					{
						var num16 = class115_0.method_2(6);
						if (num16 > 60)
						{
							throw new AC3Exception("chbwcod too large");
						}
						int_16[num15] = num16 * 3 + 73;
					}
				}
			}
			var num17 = 0;
			if (num12 != 0)
			{
				num17 = 64;
				var int_ = (int_13 - int_12) / (3 << num12 - 1);
				var byte_ = (byte)(class115_0.method_2(4) << 1);
				method_13(num12, int_, byte_, byte_0, int_12);
			}
			for (var num18 = 0; num18 < num; num18++)
			{
				if (array3[num18] != 0)
				{
					num17 |= 1 << num18;
					var num19 = 3 << array3[num18] - 1;
					var int_2 = (int_16[num18] + num19 - 4) / num19;
					byte_1[num18][0] = (byte)class115_0.method_2(4);
					method_13(array3[num18], int_2, byte_1[num18][0], byte_1[num18], 1);
					class115_0.method_2(2);
				}
			}
			if (num13 != 0)
			{
				num17 |= 32;
				byte_2[0] = (byte)class115_0.method_2(4);
				method_13(num13, 2, byte_2[0], byte_2, 1);
			}
			if (class115_0.vmethod_1())
			{
				num17 = 127;
				int_17 = class115_0.method_2(11);
			}
			if (class115_0.vmethod_1())
			{
				num17 = 127;
				int_27 = class115_0.method_2(6);
				if (int_9 != 0)
				{
					int_18 = class115_0.method_2(7);
				}
				for (var num20 = 0; num20 < num; num20++)
				{
					int_21[num20] = class115_0.method_2(7);
				}
				if (bool_0)
				{
					int_24 = class115_0.method_2(7);
				}
			}
			if (int_9 != 0 && class115_0.vmethod_1())
			{
				num17 |= 64;
				int_28 = 9 - class115_0.method_2(3);
				int_29 = 9 - class115_0.method_2(3);
			}
			if (class115_0.vmethod_1())
			{
				num17 = 127;
				if (int_9 != 0)
				{
					int_19 = class115_0.method_2(2);
				}
				for (var num21 = 0; num21 < num; num21++)
				{
					int_22[num21] = class115_0.method_2(2);
				}
				if (int_9 != 0 && int_19 == 1)
				{
					method_12(int_20);
				}
				for (var num22 = 0; num22 < num; num22++)
				{
					if (int_22[num22] == 1)
					{
						method_12(int_23[num22]);
					}
				}
			}
			if (num17 != 0)
			{
				if (method_5(num))
				{
					for (var num23 = 0; num23 < byte_3.Length; num23++)
					{
						byte_3[num23] = 0;
					}
					for (var num24 = 0; num24 < num; num24++)
					{
						for (var num25 = 0; num25 < byte_4[num24].Length; num25++)
						{
							byte_4[num24][num25] = 0;
						}
					}
					for (var num26 = 0; num26 < byte_5.Length; num26++)
					{
						byte_5[num26] = 0;
					}
				}
				else
				{
					if (int_9 != 0 && (num17 & 64) != 0)
					{
						method_4(int_18, int_19, int_20, int_11, int_12, int_13, int_28 << 8, int_29 << 8, byte_0, byte_3);
					}
					for (var num27 = 0; num27 < num; num27++)
					{
						if ((num17 & 1 << num27) != 0)
						{
							method_4(int_21[num27], int_22[num27], int_23[num27], 0, 0, int_16[num27], 0, 0, byte_1[num27], byte_4[num27]);
						}
					}
					if (bool_0 && (num17 & 32) != 0)
					{
						int_25 = 2;
						method_4(int_24, int_25, int_26, 0, 0, 7, 0, 0, byte_2, byte_5);
					}
				}
			}
			if (class115_0.vmethod_1())
			{
				var num28 = class115_0.method_2(9);
				class115_0.vmethod_3(class115_0.vmethod_0() + num28 * 8);
			}
			var num29 = 256;
			var array4 = new double[5];
			method_11(array4, int_7, double_8, double_5, double_6);
			var flag3 = false;
			class113_0.int_0 = -1;
			class113_0.int_1 = -1;
			class113_0.int_2 = -1;
			for (var num30 = 0; num30 < num; num30++)
			{
				method_7(double_10, num29 + 256 * num30, byte_1[num30], byte_4[num30], class113_0, array4[num30], array2[num30], int_16[num30]);
				int num31;
				if ((int_9 >> num30 & 1) != 0)
				{
					if (!flag3)
					{
						flag3 = true;
						method_9(num, array4, double_10, num29, class113_0, array2);
					}
					num31 = int_13;
				}
				else
				{
					num31 = int_16[num30];
				}
				do
				{
					double_10[num29 + 256 * num30 + num31] = 0.0;
				}
				while (++num31 < 256);
			}
			if (int_7 == 2)
			{
				var num32 = 0;
				var num31 = 13;
				var num33 = (int_16[0] < int_16[1]) ? int_16[0] : int_16[1];
				var num34 = int_15;
				do
				{
					if ((num34 & 1) == 0)
					{
						num34 >>= 1;
						num31 = int_37[num32++];
					}
					else
					{
						num34 >>= 1;
						var num35 = int_37[num32++];
						if (num35 > num33)
						{
							num35 = num33;
						}
						do
						{
							var num36 = double_10[num29 + num31];
							var num37 = double_10[num29 + num31 + 256];
							double_10[num29 + num31] = num36 + num37;
							double_10[num29 + num31 + 256] = num36 - num37;
						}
						while (++num31 < num35);
					}
				}
				while (num31 < num33);
			}
			if (bool_0)
			{
				method_7(double_10, num29 - 256, byte_2, byte_5, class113_0, 0.0, false, 7);
				for (var num38 = 7; num38 < 256; num38++)
				{
					double_10[num29 - 256 + num38] = 0.0;
				}
				class110_0.vmethod_0(double_10, num29 - 256, num29 - 256 + 1536, int_0);
			}
			var num39 = 0;
			if (2 < num)
			{
				num39 = 1;
				while (num39 < num && array[num39] == array[0])
				{
					num39++;
				}
			}
			if (num39 < num)
			{
				if (bool_3)
				{
					bool_3 = false;
				}
				for (num39 = 0; num39 < num; num39++)
				{
					if (array4[num39] != 0.0)
					{
						if (array[num39])
						{
							class110_0.vmethod_1(double_10, num29 + 256 * num39, num29 + 1536 + 256 * num39, int_0);
						}
						else
						{
							class110_0.vmethod_0(double_10, num29 + 256 * num39, num29 + 1536 + 256 * num39, int_0);
						}
					}
					else
					{
						for (var num31 = 0; num31 < 256; num31++)
						{
							double_10[num29 + 256 * num39 + num31] = 0.0;
						}
					}
				}
				return;
			}
			var num40 = 0;
			if (!bool_3)
			{
				bool_3 = true;
			}
			if (array[0])
			{
				for (num39 = 0; num39 < num; num39++)
				{
					class110_0.vmethod_1(double_10, num29 + 256 * num39, num29 + 1536 + 256 * num39, num40);
				}
				return;
			}
			for (num39 = 0; num39 < num; num39++)
			{
				class110_0.vmethod_0(double_10, num29 + 256 * num39, num29 + 1536 + 256 * num39, num40);
			}
		}

		private void method_4(int int_45, int int_46, int[] int_47, int int_48, int int_49, int int_50, int int_51, int int_52, byte[] byte_10, byte[] byte_11)
		{
			var num = 63 + 20 * (int_17 >> 7 & 3) >> int_6;
			var num2 = 128 + 128 * (int_45 & 7);
			var num3 = 15 + 2 * (int_17 >> 9) >> int_6;
			var num4 = int_38[int_17 >> 5 & 3];
			var num5 = int_39[int_17 >> 3 & 3];
			var array = int_41[int_5];
			if (int_46 == 2)
			{
				int_47 = int_42;
			}
			var num6 = int_40[int_17 & 7];
			var num7 = 960 - 64 * int_27 - 4 * (int_45 >> 3) + num6;
			num6 >>= 5;
			var i = int_48;
			var j = int_49;
			if (int_49 == 0)
			{
				var k = 0;
				j = int_50 - 1;
				int num8;
				while (true)
				{
					if (i < j)
					{
						if (byte_10[i + 1] == byte_10[i] - 2)
						{
							k = 384;
						}
						else if (k != 0 && byte_10[i + 1] > byte_10[i])
						{
							k -= 64;
						}
					}
					num8 = 128 * byte_10[i];
					var num9 = num8 + num2 + k;
					if (num8 > num5)
					{
						num9 -= num8 - num5 >> 2;
					}
					if (num9 > array[i >> int_6])
					{
						num9 = array[i >> int_6];
					}
					num9 -= num7 + 128 * int_47[i];
					num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
					num9 -= num6;
					byte_11[i] = byte_9[156 + num9 + 4 * byte_10[i]];
					i++;
					if (i >= 3)
					{
						if (i >= 7)
						{
							break;
						}
						if (byte_10[i] <= byte_10[i - 1])
						{
							break;
						}
					}
				}
				int_51 = num8 + num2;
				int_52 = num8 + num4;
				while (i < 7)
				{
					if (i < j)
					{
						if (byte_10[i + 1] == byte_10[i] - 2)
						{
							k = 384;
						}
						else if (k != 0 && byte_10[i + 1] > byte_10[i])
						{
							k -= 64;
						}
					}
					num8 = 128 * byte_10[i];
					int_51 += num;
					if (int_51 > num8 + num2)
					{
						int_51 = num8 + num2;
					}
					int_52 += num3;
					if (int_52 > num8 + num4)
					{
						int_52 = num8 + num4;
					}
					var num9 = (int_51 + k < int_52) ? (int_51 + k) : int_52;
					if (num8 > num5)
					{
						num9 -= num8 - num5 >> 2;
					}
					if (num9 > array[i >> int_6])
					{
						num9 = array[i >> int_6];
					}
					num9 -= num7 + 128 * int_47[i];
					num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
					num9 -= num6;
					byte_11[i] = byte_9[156 + num9 + 4 * byte_10[i]];
					i++;
				}
				if (int_50 == 7)
				{
					return;
				}
				do
				{
					if (byte_10[i + 1] == byte_10[i] - 2)
					{
						k = 320;
					}
					else if (k != 0 && byte_10[i + 1] > byte_10[i])
					{
						k -= 64;
					}
					num8 = 128 * byte_10[i];
					int_51 += num;
					if (int_51 > num8 + num2)
					{
						int_51 = num8 + num2;
					}
					int_52 += num3;
					if (int_52 > num8 + num4)
					{
						int_52 = num8 + num4;
					}
					var num9 = (int_51 + k < int_52) ? (int_51 + k) : int_52;
					if (num8 > num5)
					{
						num9 -= num8 - num5 >> 2;
					}
					if (num9 > array[i >> int_6])
					{
						num9 = array[i >> int_6];
					}
					num9 -= num7 + 128 * int_47[i];
					num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
					num9 -= num6;
					byte_11[i] = byte_9[156 + num9 + 4 * byte_10[i]];
					i++;
				}
				while (i < 20);
				while (k > 128)
				{
					k -= 128;
					num8 = 128 * byte_10[i];
					int_51 += num;
					if (int_51 > num8 + num2)
					{
						int_51 = num8 + num2;
					}
					int_52 += num3;
					if (int_52 > num8 + num4)
					{
						int_52 = num8 + num4;
					}
					var num9 = (int_51 + k < int_52) ? (int_51 + k) : int_52;
					if (num8 > num5)
					{
						num9 -= num8 - num5 >> 2;
					}
					if (num9 > array[i >> int_6])
					{
						num9 = array[i >> int_6];
					}
					num9 -= num7 + 128 * int_47[i];
					num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
					num9 -= num6;
					byte_11[i] = byte_9[156 + num9 + 4 * byte_10[i]];
					i++;
				}
				j = i;
			}
			do
			{
				var num10 = j;
				var num11 = (int_43[i - 20] < int_50) ? int_43[i - 20] : int_50;
				var num8 = 128 * byte_10[j++];
				while (j < num11)
				{
					var num12 = 128 * byte_10[j++];
					var num13 = num12 - num8;
					switch (num13 >> 9)
					{
					case -6:
					case -5:
					case -4:
					case -3:
					case -2:
						num8 = num12;
						break;
					case -1:
						num8 = num12 + int_44[-num13 >> 1];
						break;
					case 0:
						num8 += int_44[num13 >> 1];
						break;
					}
				}
				int_51 += num;
				if (int_51 > num8 + num2)
				{
					int_51 = num8 + num2;
				}
				int_52 += num3;
				if (int_52 > num8 + num4)
				{
					int_52 = num8 + num4;
				}
				var num9 = (int_51 < int_52) ? int_51 : int_52;
				if (num8 > num5)
				{
					num9 -= num8 - num5 >> 2;
				}
				if (num9 > array[i >> int_6])
				{
					num9 = array[i >> int_6];
				}
				num9 -= num7 + 128 * int_47[i];
				num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
				num9 -= num6;
				i++;
				j = num10;
				do
				{
					byte_11[j] = byte_9[156 + num9 + 4 * byte_10[j]];
				}
				while (++j < num11);
			}
			while (j < int_50);
		}

		private bool method_5(int int_45)
		{
			if (int_27 == 0 && (int_9 == 0 || int_18 >> 3 == 0) && (!bool_0 || int_24 >> 3 == 0))
			{
				for (var i = 0; i < int_45; i++)
				{
					if (int_21[i] >> 3 != 0)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		private int method_6()
		{
			var num = int_34[int_30 >> 8] ^ int_30 << 8;
			if ((num & 32768) != 0)
			{
				num |= -65536;
			}
			else
			{
				num &= 65535;
			}
			int_30 = (num & 65535);
			return num;
		}

		private void method_7(double[] double_24, int int_45, byte[] byte_10, byte[] byte_11, Class113 class113_1, double double_25, bool bool_5, int int_46)
		{
			var array = new double[25];
			for (var i = 0; i <= 24; i++)
			{
				array[i] = double_13[i] * double_25;
			}
			var j = 0;
			while (j < int_46)
			{
				int num = byte_11[j];
				switch (num)
				{
				case -3:
					if (class113_1.int_2 == 0)
					{
						double_24[int_45 + j] = class113_1.vmethod_2()[0] * array[byte_10[j]];
						class113_1.int_2 = -1;
					}
					else
					{
						var num2 = class115_0.method_2(7);
						class113_1.int_2 = 0;
						class113_1.vmethod_2()[0] = double_22[num2];
						double_24[int_45 + j] = double_21[num2] * array[byte_10[j]];
					}
					break;
				case -2:
					if (class113_1.int_1 >= 0)
					{
						double_24[int_45 + j] = class113_1.vmethod_1()[class113_1.int_1] * array[byte_10[j]];
						class113_1.int_1--;
					}
					else
					{
						var num3 = class115_0.method_2(7);
						class113_1.int_1 = 1;
						class113_1.vmethod_1()[0] = double_19[num3];
						class113_1.vmethod_1()[1] = double_18[num3];
						double_24[int_45 + j] = double_17[num3] * array[byte_10[j]];
					}
					break;
				case -1:
					if (class113_1.int_0 >= 0)
					{
						double_24[int_45 + j] = class113_1.vmethod_0()[class113_1.int_0] * array[byte_10[j]];
						class113_1.int_0--;
					}
					else
					{
						var num4 = class115_0.method_2(5);
						class113_1.int_0 = 1;
						class113_1.vmethod_0()[0] = double_16[num4];
						class113_1.vmethod_0()[1] = double_15[num4];
						double_24[int_45 + j] = double_14[num4] * array[byte_10[j]];
					}
					break;
				case 0:
					if (bool_5)
					{
						var num5 = method_6();
						double_24[int_45 + j] = num5 * array[byte_10[j]] * double_2;
					}
					else
					{
						double_24[int_45 + j] = 0.0;
					}
					break;
				case 1:
				case 2:
					goto IL_216;
				case 3:
					double_24[int_45 + j] = double_20[class115_0.method_2(3)] * array[byte_10[j]];
					break;
				case 4:
					double_24[int_45 + j] = double_23[class115_0.method_2(4)] * array[byte_10[j]];
					break;
				default:
					goto IL_216;
				}
				IL_275:
				j++;
				continue;
				IL_216:
				var num6 = method_8(num);
				double_24[int_45 + j] = (num6 << 16 - num) * array[byte_10[j]];
				goto IL_275;
			}
		}

		private int method_8(int int_45)
		{
			var num = class115_0.method_2(int_45);
			if ((num & 1 << int_45 - 1) != 0)
			{
				num |= -1 << int_45;
			}
			return num;
		}

		private void method_9(int int_45, double[] double_24, double[] double_25, int int_46, Class113 class113_1, bool[] bool_5)
		{
			var array = new double[5];
			var array2 = byte_0;
			var array3 = byte_3;
			var num = 0;
			var num2 = int_14;
			var i = int_12;
			while (i < int_13)
			{
				var num3 = i + 12;
				while ((num2 & 1) != 0)
				{
					num2 >>= 1;
					num3 += 12;
				}
				num2 >>= 1;
				for (var j = 0; j < int_45; j++)
				{
					array[j] = double_9[j][num] * double_24[j];
				}
				num++;
				while (i < num3)
				{
					int num4 = array3[i];
					double num5;
					switch (num4)
					{
					case -3:
						if (class113_1.int_2 == 0)
						{
							num5 = class113_1.vmethod_2()[0];
							class113_1.int_2 = -1;
						}
						else
						{
							var num6 = class115_0.method_2(7);
							class113_1.int_2 = 0;
							class113_1.vmethod_2()[0] = double_22[num6];
							num5 = double_21[num6];
						}
						break;
					case -2:
						if (class113_1.int_1 >= 0)
						{
							num5 = class113_1.vmethod_1()[class113_1.int_1];
							class113_1.int_1--;
						}
						else
						{
							var num7 = class115_0.method_2(7);
							class113_1.int_1 = 1;
							class113_1.vmethod_1()[0] = double_19[num7];
							class113_1.vmethod_1()[1] = double_18[num7];
							num5 = double_17[num7];
						}
						break;
					case -1:
						if (class113_1.int_0 >= 0)
						{
							num5 = class113_1.vmethod_0()[class113_1.int_0];
							class113_1.int_0--;
						}
						else
						{
							var num8 = class115_0.method_2(5);
							class113_1.int_0 = 1;
							class113_1.vmethod_0()[0] = double_16[num8];
							class113_1.vmethod_0()[1] = double_15[num8];
							num5 = double_14[num8];
						}
						break;
					case 0:
						num5 = double_2 * double_13[array2[i]];
						for (var k = 0; k < int_45; k++)
						{
							if ((int_9 >> k & 1) != 0)
							{
								if (bool_5[k])
								{
									double_25[int_46 + i + k * 256] = num5 * array[k] * method_6();
								}
								else
								{
									double_25[int_46 + i + k * 256] = 0.0;
								}
							}
						}
						i++;
						break;
					case 1:
					case 2:
						goto IL_27D;
					case 3:
						num5 = double_20[class115_0.method_2(3)];
						break;
					case 4:
						num5 = double_23[class115_0.method_2(4)];
						break;
					default:
						goto IL_27D;
					}
					IL_2BF:
					if (num4 != 0)
					{
						num5 *= double_13[array2[i]];
						for (var l = 0; l < int_45; l++)
						{
							if ((int_9 >> l & 1) != 0)
							{
								double_25[int_46 + i + l * 256] = num5 * array[l];
							}
						}
						i++;
					}
					continue;
					IL_27D:
					num5 = method_8(num4) << 16 - num4;
					goto IL_2BF;
				}
			}
		}

		private void method_10(int int_45)
		{
		}

		private void method_11(double[] double_24, int int_45, double double_25, double double_26, double double_27)
		{
			switch (int_45)
			{
			case 2:
				double_24[0] = double_25;
				double_24[1] = double_25;
				double_24[2] = double_25;
				double_24[3] = double_25;
				double_24[4] = double_25;
				return;
			case 3:
				double_24[0] = double_25;
				double_24[1] = double_25 * double_26;
				double_24[2] = double_25;
				double_24[3] = double_25;
				double_24[4] = double_25;
				return;
			case 4:
				double_24[0] = double_25;
				double_24[1] = double_25;
				double_24[2] = double_25 * double_27 * double_2;
				double_24[3] = double_25;
				double_24[4] = double_25;
				return;
			case 5:
				double_24[0] = double_25;
				double_24[1] = double_25 * double_26;
				double_24[2] = double_25;
				double_24[3] = double_25 * double_27 * double_2;
				double_24[4] = double_25;
				return;
			case 6:
				double_24[0] = double_25;
				double_24[1] = double_25;
				double_24[2] = double_25 * double_27;
				double_24[3] = double_25 * double_27;
				double_24[4] = double_25;
				return;
			case 7:
				double_24[0] = double_25;
				double_24[1] = double_25 * double_26;
				double_24[2] = double_25;
				double_24[3] = double_25 * double_27;
				double_24[4] = double_25 * double_27;
				return;
			default:
				return;
			}
		}

		private void method_12(int[] int_45)
		{
			for (var i = 0; i < int_45.Length; i++)
			{
				int_45[i] = 0;
			}
			var num = class115_0.method_2(3);
			var num2 = 0;
			do
			{
				num2 += class115_0.method_2(5);
				var num3 = class115_0.method_2(4);
				var num4 = class115_0.method_2(3);
				num4 -= ((num4 < 4) ? 4 : 3);
				while (num3-- != 0)
				{
					int_45[num2++] = num4;
				}
			}
			while (num-- != 0);
		}

		private void method_13(int int_45, int int_46, byte byte_10, byte[] byte_11, int int_47)
		{
			while (int_46-- != 0)
			{
				var num = class115_0.method_2(7);
				byte_10 += byte_6[num];
				if ((255 & byte_10) <= 24)
				{
					switch (int_45)
					{
					case 1:
						goto IL_67;
					case 2:
						goto IL_5C;
					case 3:
						byte_11[int_47++] = byte_10;
						byte_11[int_47++] = byte_10;
						goto IL_5C;
					}
					IL_72:
					byte_10 += byte_7[num];
					if ((255 & byte_10) <= 24)
					{
						switch (int_45)
						{
						case 1:
							goto IL_C6;
						case 2:
							goto IL_BB;
						case 3:
							byte_11[int_47++] = byte_10;
							byte_11[int_47++] = byte_10;
							goto IL_BB;
						}
						IL_D1:
						byte_10 += byte_8[num];
						if ((255 & byte_10) <= 24)
						{
							switch (int_45)
							{
							case 1:
								break;
							case 2:
								goto IL_117;
							case 3:
								byte_11[int_47++] = byte_10;
								byte_11[int_47++] = byte_10;
								goto IL_117;
							default:
								continue;
							}
							IL_122:
							byte_11[int_47++] = byte_10;
							continue;
							IL_117:
							byte_11[int_47++] = byte_10;
							goto IL_122;
						}
						throw new AC3Exception("Exponent too large");
						IL_C6:
						byte_11[int_47++] = byte_10;
						goto IL_D1;
						IL_BB:
						byte_11[int_47++] = byte_10;
						goto IL_C6;
					}
					throw new AC3Exception("Exponent too large");
					IL_67:
					byte_11[int_47++] = byte_10;
					goto IL_72;
					IL_5C:
					byte_11[int_47++] = byte_10;
					goto IL_67;
				}
				throw new AC3Exception("Exponent too large");
			}
		}

		public virtual int vmethod_0(byte[] byte_10, Stream stream_0)
		{
			try
			{
				var num = byte_10.Length;
				class115_0.vmethod_2(byte_10, 0, num);
				while (class115_0.method_1() > 56)
				{
					if (bool_4)
					{
						class115_0.vmethod_3(class115_0.vmethod_0() & -8);
						if (!method_1())
						{
							continue;
						}
						bool_4 = false;
					}
					if (class115_0.method_1() < int_4 * 8)
					{
						break;
					}
					var num2 = class115_0.vmethod_0();
					method_2();
					while (class115_0.vmethod_0() - num2 < (int_4 - 7) * 8)
					{
						method_3();
						class110_0.vmethod_2(double_10, 2, stream_0);
					}
					bool_4 = true;
				}
			}
			catch
			{
				bool_4 = true;
				class115_0.vmethod_3(class115_0.vmethod_0() + class115_0.method_1());
			}
			return 0;
		}

		static AC3Class1()
		{
			double_0 = 2.0;
			double_1 = 1.4142135623730951;
			double_2 = 0.70710678118654757;
			double_3 = 0.59460355750136051;
			double_4 = 0.5;
			int_31 = new[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				2,
				3
			};
			int_32 = new[]
			{
				32,
				40,
				48,
				56,
				64,
				80,
				96,
				112,
				128,
				160,
				192,
				224,
				256,
				320,
				384,
				448,
				512,
				576,
				640
			};
			int_33 = new[]
			{
				16,
				16,
				4,
				4,
				4,
				1,
				4,
				1
			};
			double_11 = new[]
			{
				double_2,
				double_3,
				double_4,
				double_3
			};
			double_12 = new[]
			{
				double_2,
				double_4,
				0.0,
				double_4
			};
			int_35 = new[]
			{
				2,
				1,
				2,
				3,
				3,
				4,
				4,
				5,
				1,
				1,
				2
			};
			int_36 = new[]
			{
				31,
				35,
				37,
				39,
				41,
				42,
				43,
				44,
				45,
				45,
				46,
				46,
				47,
				47,
				48,
				48
			};
			int_37 = new[]
			{
				25,
				37,
				61,
				253
			};
			int_38 = new[]
			{
				1344,
				1240,
				1144,
				1040
			};
			int_39 = new[]
			{
				3072,
				1280,
				768,
				256
			};
			int_40 = new[]
			{
				2320,
				2384,
				2448,
				2512,
				2576,
				2704,
				2832,
				5120
			};
			int_42 = new int[50];
			int_41 = Class114.smethod_15();
			byte_9 = Class114.smethod_16();
			int_43 = Class114.smethod_17();
			int_44 = Class114.smethod_18();
		}
	}
}
