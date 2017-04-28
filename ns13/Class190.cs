using System;
using Compression;
using ns12;

namespace ns13
{
	public class Class190
	{
		private class Class191
		{
			public short[] short_0;

			public byte[] byte_0;

			public int int_0;

			public int int_1;

			private short[] short_1;

			private int[] int_2;

			private int int_3;

			private Class190 class190_0;

			public Class191(Class190 class190_1, int int_4, int int_5, int int_6)
			{
				class190_0 = class190_1;
				int_0 = int_5;
				int_3 = int_6;
				short_0 = new short[int_4];
				int_2 = new int[int_6];
			}

			public void method_0()
			{
				for (int i = 0; i < short_0.Length; i++)
				{
					short_0[i] = 0;
				}
				short_1 = null;
				byte_0 = null;
			}

			public void method_1(int int_4)
			{
				class190_0.class189_0.method_5(short_1[int_4] & 65535, byte_0[int_4]);
			}

			public void method_2(short[] short_2, byte[] byte_1)
			{
				short_1 = short_2;
				byte_0 = byte_1;
			}

			public void method_3()
			{
				int[] array = new int[int_3];
				int num = 0;
				short_1 = new short[short_0.Length];
				for (int i = 0; i < int_3; i++)
				{
					array[i] = num;
					num += int_2[i] << 15 - i;
				}
				for (int j = 0; j < int_1; j++)
				{
					int num2 = byte_0[j];
					if (num2 > 0)
					{
						short_1[j] = smethod_0(array[num2 - 1]);
						array[num2 - 1] += 1 << 16 - num2;
					}
				}
			}

			public void method_4()
			{
				int num = short_0.Length;
				int[] array = new int[num];
				int i = 0;
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					int num3 = short_0[j];
					if (num3 != 0)
					{
						int num4 = i++;
						int num5;
						while (num4 > 0 && short_0[array[num5 = (num4 - 1) / 2]] > num3)
						{
							array[num4] = array[num5];
							num4 = num5;
						}
						array[num4] = j;
						num2 = j;
					}
				}
				while (i < 2)
				{
					int num6 = (num2 < 2) ? (++num2) : 0;
					array[i++] = num6;
				}
				int_1 = Math.Max(num2 + 1, int_0);
				int num7 = i;
				int[] array2 = new int[4 * i - 2];
				int[] array3 = new int[2 * i - 1];
				int num8 = num7;
				for (int k = 0; k < i; k++)
				{
					int num9 = array[k];
					array2[2 * k] = num9;
					array2[2 * k + 1] = -1;
					array3[k] = short_0[num9] << 8;
					array[k] = k;
				}
				do
				{
					int num10 = array[0];
					int num11 = array[--i];
					int num12 = 0;
					int l;
					for (l = 1; l < i; l = l * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					int num13 = array3[num11];
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
					int num14 = array[0];
					num11 = num8++;
					array2[2 * num11] = num10;
					array2[2 * num11 + 1] = num14;
					int num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
					num13 = (array3[num11] = array3[num10] + array3[num14] - num15 + 1);
					num12 = 0;
					for (l = 1; l < i; l = num12 * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
				}
				while (i > 1);
				if (array[0] != array2.Length / 2 - 1)
				{
					throw new SharpZipBaseException("Heap invariant violated");
				}
				method_8(array2);
			}

			public int method_5()
			{
				int num = 0;
				for (int i = 0; i < short_0.Length; i++)
				{
					num += short_0[i] * byte_0[i];
				}
				return num;
			}

			public void method_6(Class191 class191_0)
			{
				int num = -1;
				int i = 0;
				while (i < int_1)
				{
					int num2 = 1;
					int num3 = byte_0[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							short[] expr_3B_cp_0 = class191_0.short_0;
							int expr_3B_cp_1 = num3;
							expr_3B_cp_0[expr_3B_cp_1] += 1;
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < int_1)
					{
						if (num != byte_0[i])
						{
							break;
						}
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						short[] expr_8C_cp_0 = class191_0.short_0;
						int expr_8C_cp_1 = num;
						expr_8C_cp_0[expr_8C_cp_1] += (short)num2;
					}
					else if (num != 0)
					{
						short[] expr_AD_cp_0 = class191_0.short_0;
						int expr_AD_cp_1 = 16;
						expr_AD_cp_0[expr_AD_cp_1] += 1;
					}
					else if (num2 <= 10)
					{
						short[] expr_CF_cp_0 = class191_0.short_0;
						int expr_CF_cp_1 = 17;
						expr_CF_cp_0[expr_CF_cp_1] += 1;
					}
					else
					{
						short[] expr_EC_cp_0 = class191_0.short_0;
						int expr_EC_cp_1 = 18;
						expr_EC_cp_0[expr_EC_cp_1] += 1;
					}
				}
			}

			public void method_7(Class191 class191_0)
			{
				int num = -1;
				int i = 0;
				while (i < int_1)
				{
					int num2 = 1;
					int num3 = byte_0[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							class191_0.method_1(num3);
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < int_1)
					{
						if (num != byte_0[i])
						{
							break;
						}
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						while (num2-- > 0)
						{
							class191_0.method_1(num);
						}
					}
					else if (num != 0)
					{
						class191_0.method_1(16);
						class190_0.class189_0.method_5(num2 - 3, 2);
					}
					else if (num2 <= 10)
					{
						class191_0.method_1(17);
						class190_0.class189_0.method_5(num2 - 3, 3);
					}
					else
					{
						class191_0.method_1(18);
						class190_0.class189_0.method_5(num2 - 11, 7);
					}
				}
			}

			private void method_8(int[] int_4)
			{
				byte_0 = new byte[short_0.Length];
				int num = int_4.Length / 2;
				int num2 = (num + 1) / 2;
				int num3 = 0;
				for (int i = 0; i < int_3; i++)
				{
					int_2[i] = 0;
				}
				int[] array = new int[num];
				array[num - 1] = 0;
				for (int j = num - 1; j >= 0; j--)
				{
					if (int_4[2 * j + 1] != -1)
					{
						int num4 = array[j] + 1;
						if (num4 > int_3)
						{
							num4 = int_3;
							num3++;
						}
						array[int_4[2 * j]] = (array[int_4[2 * j + 1]] = num4);
					}
					else
					{
						int num5 = array[j];
						int_2[num5 - 1]++;
						byte_0[int_4[2 * j]] = (byte)array[j];
					}
				}
				if (num3 == 0)
				{
					return;
				}
				int num6 = int_3 - 1;
				while (true)
				{
					if (int_2[--num6] != 0)
					{
						do
						{
							int_2[num6]--;
							int_2[++num6]++;
							num3 -= 1 << int_3 - 1 - num6;
						}
						while (num3 > 0 && num6 < int_3 - 1);
						if (num3 <= 0)
						{
							break;
						}
					}
				}
				int_2[int_3 - 1] += num3;
				int_2[int_3 - 2] -= num3;
				int num7 = 2 * num2;
				for (int num8 = int_3; num8 != 0; num8--)
				{
					int k = int_2[num8 - 1];
					while (k > 0)
					{
						int num9 = 2 * int_4[num7++];
						if (int_4[num9 + 1] == -1)
						{
							byte_0[int_4[num9]] = (byte)num8;
							k--;
						}
					}
				}
			}
		}

		private static readonly int[] int_0;

		private static readonly byte[] byte_0;

		private static short[] short_0;

		private static byte[] byte_1;

		private static short[] short_1;

		private static byte[] byte_2;

		public Class189 class189_0;

		private Class191 class191_0;

		private Class191 class191_1;

		private Class191 class191_2;

		private short[] short_2;

		private byte[] byte_3;

		private int int_1;

		private int int_2;

		static Class190()
		{
			int_0 = new[]
			{
				16,
				17,
				18,
				0,
				8,
				7,
				9,
				6,
				10,
				5,
				11,
				4,
				12,
				3,
				13,
				2,
				14,
				1,
				15
			};
			byte_0 = new byte[]
			{
				0,
				8,
				4,
				12,
				2,
				10,
				6,
				14,
				1,
				9,
				5,
				13,
				3,
				11,
				7,
				15
			};
			short_0 = new short[286];
			byte_1 = new byte[286];
			int i = 0;
			while (i < 144)
			{
				short_0[i] = smethod_0(48 + i << 8);
				byte_1[i++] = 8;
			}
			while (i < 256)
			{
				short_0[i] = smethod_0(256 + i << 7);
				byte_1[i++] = 9;
			}
			while (i < 280)
			{
				short_0[i] = smethod_0(-256 + i << 9);
				byte_1[i++] = 7;
			}
			while (i < 286)
			{
				short_0[i] = smethod_0(-88 + i << 8);
				byte_1[i++] = 8;
			}
			short_1 = new short[30];
			byte_2 = new byte[30];
			for (i = 0; i < 30; i++)
			{
				short_1[i] = smethod_0(i << 11);
				byte_2[i] = 5;
			}
		}

		public Class190(Class189 class189_1)
		{
			class189_0 = class189_1;
			class191_0 = new Class191(this, 286, 257, 15);
			class191_1 = new Class191(this, 30, 1, 15);
			class191_2 = new Class191(this, 19, 4, 7);
			short_2 = new short[16384];
			byte_3 = new byte[16384];
		}

		public void method_0()
		{
			int_1 = 0;
			int_2 = 0;
			class191_0.method_0();
			class191_1.method_0();
			class191_2.method_0();
		}

		public void method_1(int int_3)
		{
			class191_2.method_3();
			class191_0.method_3();
			class191_1.method_3();
			class189_0.method_5(class191_0.int_1 - 257, 5);
			class189_0.method_5(class191_1.int_1 - 1, 5);
			class189_0.method_5(int_3 - 4, 4);
			for (int i = 0; i < int_3; i++)
			{
				class189_0.method_5(class191_2.byte_0[int_0[i]], 3);
			}
			class191_0.method_7(class191_2);
			class191_1.method_7(class191_2);
		}

		public void method_2()
		{
			for (int i = 0; i < int_1; i++)
			{
				int num = byte_3[i] & 255;
				int num2 = short_2[i];
				if (num2-- != 0)
				{
					int num3 = smethod_1(num);
					class191_0.method_1(num3);
					int num4 = (num3 - 261) / 4;
					if (num4 > 0 && num4 <= 5)
					{
						class189_0.method_5(num & (1 << num4) - 1, num4);
					}
					int num5 = smethod_2(num2);
					class191_1.method_1(num5);
					num4 = num5 / 2 - 1;
					if (num4 > 0)
					{
						class189_0.method_5(num2 & (1 << num4) - 1, num4);
					}
				}
				else
				{
					class191_0.method_1(num);
				}
			}
			class191_0.method_1(256);
		}

		public void method_3(byte[] byte_4, int int_3, int int_4, bool bool_0)
		{
			class189_0.method_5(bool_0 ? 1 : 0, 3);
			class189_0.method_4();
			class189_0.method_1(int_4);
			class189_0.method_1(~int_4);
			class189_0.method_2(byte_4, int_3, int_4);
			method_0();
		}

		public void method_4(byte[] byte_4, int int_3, int int_4, bool bool_0)
		{
			short[] expr_15_cp_0 = class191_0.short_0;
			int expr_15_cp_1 = 256;
			expr_15_cp_0[expr_15_cp_1] += 1;
			class191_0.method_4();
			class191_1.method_4();
			class191_0.method_6(class191_2);
			class191_1.method_6(class191_2);
			class191_2.method_4();
			int num = 4;
			for (int i = 18; i > num; i--)
			{
				if (class191_2.byte_0[int_0[i]] > 0)
				{
					num = i + 1;
				}
			}
			int num2 = 14 + num * 3 + class191_2.method_5() + class191_0.method_5() + class191_1.method_5() + int_2;
			int num3 = int_2;
			for (int j = 0; j < 286; j++)
			{
				num3 += class191_0.short_0[j] * byte_1[j];
			}
			for (int k = 0; k < 30; k++)
			{
				num3 += class191_1.short_0[k] * byte_2[k];
			}
			if (num2 >= num3)
			{
				num2 = num3;
			}
			if (int_3 >= 0 && int_4 + 4 < num2 >> 3)
			{
				method_3(byte_4, int_3, int_4, bool_0);
				return;
			}
			if (num2 == num3)
			{
				class189_0.method_5(2 + (bool_0 ? 1 : 0), 3);
				class191_0.method_2(short_0, byte_1);
				class191_1.method_2(short_1, byte_2);
				method_2();
				method_0();
				return;
			}
			class189_0.method_5(4 + (bool_0 ? 1 : 0), 3);
			method_1(num);
			method_2();
			method_0();
		}

		public bool method_5()
		{
			return int_1 >= 16384;
		}

		public bool method_6(int int_3)
		{
			short_2[int_1] = 0;
			byte_3[int_1++] = (byte)int_3;
			short[] expr_39_cp_0 = class191_0.short_0;
			expr_39_cp_0[int_3] += 1;
			return method_5();
		}

		public bool method_7(int int_3, int int_4)
		{
			short_2[int_1] = (short)int_3;
			byte_3[int_1++] = (byte)(int_4 - 3);
			int num = smethod_1(int_4 - 3);
			short[] expr_45_cp_0 = class191_0.short_0;
			int expr_45_cp_1 = num;
			expr_45_cp_0[expr_45_cp_1] += 1;
			if (num >= 265 && num < 285)
			{
				int_2 += (num - 261) / 4;
			}
			int num2 = smethod_2(int_3 - 1);
			short[] expr_93_cp_0 = class191_1.short_0;
			int expr_93_cp_1 = num2;
			expr_93_cp_0[expr_93_cp_1] += 1;
			if (num2 >= 4)
			{
				int_2 += num2 / 2 - 1;
			}
			return method_5();
		}

		public static short smethod_0(int int_3)
		{
			return (short)(byte_0[int_3 & 15] << 12 | byte_0[int_3 >> 4 & 15] << 8 | byte_0[int_3 >> 8 & 15] << 4 | byte_0[int_3 >> 12]);
		}

		private static int smethod_1(int int_3)
		{
			if (int_3 == 255)
			{
				return 285;
			}
			int num = 257;
			while (int_3 >= 8)
			{
				num += 4;
				int_3 >>= 1;
			}
			return num + int_3;
		}

		private static int smethod_2(int int_3)
		{
			int num = 0;
			while (int_3 >= 4)
			{
				num += 2;
				int_3 >>= 1;
			}
			return num + int_3;
		}
	}
}
