using NeversoftTools.Texture.DDS;
using ns14;
using System;
using System.Drawing;
using System.IO;

namespace ns19
{
	public class UnkGfxClass1
	{
		public struct Struct87
		{
			public float float_0;

			public float float_1;

			public float float_2;

			public float float_3;

			public static UnkGfxClass1.Struct87 smethod_0(float float_4, UnkGfxClass1.Struct87 struct87_0)
			{
				return UnkGfxClass1.Struct87.smethod_1(struct87_0, float_4);
			}

			public static UnkGfxClass1.Struct87 smethod_1(UnkGfxClass1.Struct87 struct87_0, float float_4)
			{
				UnkGfxClass1.Struct87 result;
				result.float_0 = float_4 * struct87_0.float_0;
				result.float_1 = float_4 * struct87_0.float_1;
				result.float_2 = float_4 * struct87_0.float_2;
				result.float_3 = float_4 * struct87_0.float_3;
				return result;
			}

			public static UnkGfxClass1.Struct87 smethod_2(UnkGfxClass1.Struct87 struct87_0, UnkGfxClass1.Struct87 struct87_1)
			{
				UnkGfxClass1.Struct87 result;
				result.float_0 = struct87_0.float_0 + struct87_1.float_0;
				result.float_1 = struct87_0.float_1 + struct87_1.float_1;
				result.float_2 = struct87_0.float_2 + struct87_1.float_2;
				result.float_3 = struct87_0.float_3 + struct87_1.float_3;
				return result;
			}
		}

		public struct Struct88
		{
			public ushort ushort_0;

			public ushort ushort_1;

			public uint uint_0;

			public static UnkGfxClass1.Struct88 smethod_0(BinaryReader binaryReader_0)
			{
				UnkGfxClass1.Struct88 result;
				result.ushort_0 = binaryReader_0.ReadUInt16();
				result.ushort_1 = binaryReader_0.ReadUInt16();
				result.uint_0 = binaryReader_0.ReadUInt32();
				return result;
			}

			public void method_0(BinaryWriter binaryWriter_0)
			{
				binaryWriter_0.Write(this.ushort_0);
				binaryWriter_0.Write(this.ushort_1);
				binaryWriter_0.Write(this.uint_0);
			}
		}

		private static byte[] byte_0 = new byte[32];

		private static byte[] byte_1 = new byte[64];

		private static byte[,] byte_2 = new byte[256, 2];

		private static byte[,] byte_3 = new byte[256, 2];

		private static byte[] byte_4 = new byte[272];

		private static byte[] byte_5 = new byte[272];

		private static bool bool_0 = false;

		private static void smethod_0()
		{
			for (int i = 0; i < 32; i++)
			{
				UnkGfxClass1.byte_0[i] = (byte)(i << 3 | i >> 2);
			}
			for (int j = 0; j < 64; j++)
			{
				UnkGfxClass1.byte_1[j] = (byte)(j << 2 | j >> 4);
			}
			for (int k = 0; k < 272; k++)
			{
				int int_ = UnkGfxClass1.smethod_11(k - 8, 0, 255);
				UnkGfxClass1.byte_4[k] = UnkGfxClass1.byte_0[UnkGfxClass1.smethod_2(int_, 31)];
				UnkGfxClass1.byte_5[k] = UnkGfxClass1.byte_1[UnkGfxClass1.smethod_2(int_, 63)];
			}
			UnkGfxClass1.smethod_1(ref UnkGfxClass1.byte_2, UnkGfxClass1.byte_0, 32);
			UnkGfxClass1.smethod_1(ref UnkGfxClass1.byte_3, UnkGfxClass1.byte_1, 64);
			UnkGfxClass1.bool_0 = true;
		}

		private static void smethod_1(ref byte[,] byte_6, byte[] byte_7, int int_0)
		{
			for (int i = 0; i < 256; i++)
			{
				int num = 256;
				for (int j = 0; j < int_0; j++)
				{
					for (int k = 0; k < int_0; k++)
					{
						int num2 = (int)byte_7[j];
						int num3 = (int)byte_7[k];
						int num4 = Math.Abs(num3 + UnkGfxClass1.smethod_2(num2 - num3, 85) - i);
						if (num4 < num)
						{
							byte_6[i, 0] = (byte)k;
							byte_6[i, 1] = (byte)j;
							num = num4;
						}
					}
				}
			}
		}

		private static int smethod_2(int int_0, int int_1)
		{
			int num = int_0 * int_1 + 128;
			return num + (num >> 8) >> 8;
		}

		private static Color smethod_3(ushort ushort_0)
		{
			int num = (ushort_0 & 63488) >> 11;
			int num2 = (ushort_0 & 2016) >> 5;
			int num3 = (int)(ushort_0 & 31);
			return Color.FromArgb(0, (int)UnkGfxClass1.byte_0[num], (int)UnkGfxClass1.byte_1[num2], (int)UnkGfxClass1.byte_0[num3]);
		}

		private static ushort smethod_4(Color color_0)
		{
			return (ushort)((UnkGfxClass1.smethod_2((int)color_0.R, 31) << 11) + (UnkGfxClass1.smethod_2((int)color_0.G, 63) << 5) + UnkGfxClass1.smethod_2((int)color_0.B, 31));
		}

		private static Color smethod_5(Color color_0, Color color_1, int int_0)
		{
			return Color.FromArgb((int)color_0.R + UnkGfxClass1.smethod_2((int)(color_1.R - color_0.R), int_0), (int)color_0.G + UnkGfxClass1.smethod_2((int)(color_1.G - color_0.G), int_0), (int)color_0.B + UnkGfxClass1.smethod_2((int)(color_1.B - color_0.B), int_0));
		}

		private static void smethod_6(ref Color[] color_0, ushort ushort_0, ushort ushort_1)
		{
			color_0[0] = UnkGfxClass1.smethod_3(ushort_0);
			color_0[1] = UnkGfxClass1.smethod_3(ushort_1);
			color_0[2] = UnkGfxClass1.smethod_5(color_0[0], color_0[1], 85);
			color_0[3] = UnkGfxClass1.smethod_5(color_0[0], color_0[1], 170);
		}

		private static Color[] smethod_7(Color[] color_0)
		{
			Color[] array = new Color[color_0.Length];
			int[,] array2 = new int[3, 4];
			int[,] array3 = new int[3, 4];
			for (int i = 0; i < 4; i++)
			{
				int num = i * 4;
				byte b = UnkGfxClass1.byte_4[(int)color_0[num].B + (3 * array3[0, 1] + 5 * array3[0, 0] >> 4) + 8];
				array2[0, 0] = (int)(color_0[num].B - b);
				byte b2 = UnkGfxClass1.byte_5[(int)color_0[num].G + (3 * array3[1, 1] + 5 * array3[1, 0] >> 4) + 8];
				array2[1, 0] = (int)(color_0[num].G - b2);
				byte b3 = UnkGfxClass1.byte_4[(int)color_0[num].R + (3 * array3[2, 1] + 5 * array3[2, 0] >> 4) + 8];
				array2[2, 0] = (int)(color_0[num].R - b3);
				array[num] = Color.FromArgb((int)b3, (int)b2, (int)b);
				b = UnkGfxClass1.byte_4[(int)color_0[num + 1].B + (7 * array2[0, 0] + 3 * array3[0, 2] + 5 * array3[0, 1] + array3[0, 0] >> 4) + 8];
				array2[0, 1] = (int)(color_0[num + 1].B - b);
				b2 = UnkGfxClass1.byte_5[(int)color_0[num + 1].G + (7 * array2[1, 0] + 3 * array3[1, 2] + 5 * array3[1, 1] + array3[1, 0] >> 4) + 8];
				array2[1, 1] = (int)(color_0[num + 1].G - b2);
				b3 = UnkGfxClass1.byte_4[(int)color_0[num + 1].R + (7 * array2[2, 0] + 3 * array3[2, 2] + 5 * array3[2, 1] + array3[2, 0] >> 4) + 8];
				array2[2, 1] = (int)(color_0[num + 1].R - b3);
				array[num + 1] = Color.FromArgb((int)b3, (int)b2, (int)b);
				b = UnkGfxClass1.byte_4[(int)color_0[num + 2].B + (7 * array2[0, 1] + 3 * array3[0, 3] + 5 * array3[0, 2] + array3[0, 1] >> 4) + 8];
				array2[0, 2] = (int)(color_0[num + 2].B - b);
				b2 = UnkGfxClass1.byte_5[(int)color_0[num + 2].G + (7 * array2[1, 1] + 3 * array3[1, 3] + 5 * array3[1, 2] + array3[1, 1] >> 4) + 8];
				array2[1, 2] = (int)(color_0[num + 2].G - b2);
				b3 = UnkGfxClass1.byte_4[(int)color_0[num + 2].R + (7 * array2[2, 1] + 3 * array3[2, 3] + 5 * array3[2, 2] + array3[2, 1] >> 4) + 8];
				array2[2, 2] = (int)(color_0[num + 2].R - b3);
				array[num + 2] = Color.FromArgb((int)b3, (int)b2, (int)b);
				b = UnkGfxClass1.byte_4[(int)color_0[num + 3].B + (7 * array2[0, 2] + 5 * array3[0, 3] + array3[0, 2] >> 4) + 8];
				array2[0, 3] = (int)(color_0[num + 3].B - b);
				b2 = UnkGfxClass1.byte_5[(int)color_0[num + 3].G + (7 * array2[1, 2] + 5 * array3[1, 3] + array3[1, 2] >> 4) + 8];
				array2[1, 3] = (int)(color_0[num + 3].G - b2);
				b3 = UnkGfxClass1.byte_4[(int)color_0[num + 3].R + (7 * array2[2, 2] + 5 * array3[2, 3] + array3[2, 2] >> 4) + 8];
				array2[2, 3] = (int)(color_0[num + 3].R - b3);
				array[num + 3] = Color.FromArgb((int)b3, (int)b2, (int)b);
				int[,] array4 = array2;
				array2 = array3;
				array3 = array4;
			}
			return array;
		}

		private static uint smethod_8(Color[] color_0, Color[] color_1, bool bool_1)
		{
			uint num = 0u;
			int num2 = (int)(color_1[0].R - color_1[1].R);
			int num3 = (int)(color_1[0].G - color_1[1].G);
			int num4 = (int)(color_1[0].B - color_1[1].B);
			int[] array = new int[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = (int)color_0[i].R * num2 + (int)color_0[i].G * num3 + (int)color_0[i].B * num4;
			}
			int[] array2 = new int[4];
			for (int j = 0; j < 4; j++)
			{
				array2[j] = (int)color_1[j].R * num2 + (int)color_1[j].G * num3 + (int)color_1[j].B * num4;
			}
			int num5 = array2[1] + array2[3] >> 1;
			int num6 = array2[3] + array2[2] >> 1;
			int num7 = array2[2] + array2[0] >> 1;
			if (!bool_1)
			{
				for (int k = 15; k >= 0; k--)
				{
					num <<= 2;
					int num8 = array[k];
					if (num8 < num6)
					{
						num |= ((num8 < num5) ? 1u : 3u);
					}
					else
					{
						num |= ((num8 < num7) ? 2u : 0u);
					}
				}
			}
			else
			{
				int[] array3 = new int[4];
				int[] array4 = new int[4];
				num5 <<= 4;
				num6 <<= 4;
				num7 <<= 4;
				for (int l = 0; l < 4; l++)
				{
					int num9 = (array[l * 4] << 4) + (3 * array4[1] + 5 * array4[0]);
					int num10;
					if (num9 < num6)
					{
						num10 = ((num9 < num5) ? 1 : 3);
					}
					else
					{
						num10 = ((num9 < num7) ? 2 : 0);
					}
					array3[0] = array[l * 4] - array2[num10];
					int num11 = num10;
					num9 = (array[l * 4 + 1] << 4) + (7 * array3[0] + 3 * array4[2] + 5 * array4[1] + array4[0]);
					if (num9 < num6)
					{
						num10 = ((num9 < num5) ? 1 : 3);
					}
					else
					{
						num10 = ((num9 < num7) ? 2 : 0);
					}
					array3[1] = array[l * 4 + 1] - array2[num10];
					num11 |= num10 << 2;
					num9 = (array[l * 4 + 2] << 4) + (7 * array3[1] + 3 * array4[3] + 5 * array4[2] + array4[1]);
					if (num9 < num6)
					{
						num10 = ((num9 < num5) ? 1 : 3);
					}
					else
					{
						num10 = ((num9 < num7) ? 2 : 0);
					}
					array3[2] = array[l * 4 + 2] - array2[num10];
					num11 |= num10 << 4;
					num9 = (array[l * 4 + 3] << 4) + (7 * array3[2] + 5 * array4[3] + array4[2]);
					if (num9 < num6)
					{
						num10 = ((num9 < num5) ? 1 : 3);
					}
					else
					{
						num10 = ((num9 < num7) ? 2 : 0);
					}
					array3[3] = array[l * 4 + 3] - array2[num10];
					num11 |= num10 << 6;
					int[] array5 = array3;
					array3 = array4;
					array4 = array5;
					num |= (uint)((uint)num11 << l * 8);
				}
			}
			return num;
		}

		private static void smethod_9(Color[] block, out ushort max16, out ushort min16)
		{
			int num = 4;
			int[] array = new int[3];
			int[] array2 = new int[3];
			int[] array3 = new int[3];
			for (int i = 0; i < 3; i++)
			{
				int num4;
				int num3;
				int num2 = num3 = (num4 = (block[0].ToArgb() >> i * 8 & 255));
				for (int j = 1; j < 16; j++)
				{
					byte b = (byte)(block[j].ToArgb() >> i * 8 & 255);
					num3 += (int)b;
					num2 = Math.Min(num2, (int)b);
					num4 = Math.Max(num4, (int)b);
				}
				array[i] = num3 + 8 >> 4;
				array2[i] = num2;
				array3[i] = num4;
			}
			int[] array4 = new int[6];
			for (int k = 0; k < 6; k++)
			{
				array4[k] = 0;
			}
			for (int l = 0; l < 16; l++)
			{
				int num5 = (int)block[l].R - array[2];
				int num6 = (int)block[l].G - array[1];
				int num7 = (int)block[l].B - array[0];
				array4[0] += num5 * num5;
				array4[1] += num5 * num6;
				array4[2] += num5 * num7;
				array4[3] += num6 * num6;
				array4[4] += num6 * num7;
				array4[5] += num7 * num7;
			}
			float[] array5 = new float[6];
			for (int m = 0; m < 6; m++)
			{
				array5[m] = (float)array4[m] / 255f;
			}
			float num8 = (float)(array3[2] - array2[2]);
			float num9 = (float)(array3[1] - array2[1]);
			float num10 = (float)(array3[0] - array2[0]);
			for (int n = 0; n < num; n++)
			{
				float num11 = num8 * array5[0] + num9 * array5[1] + num10 * array5[2];
				float num12 = num8 * array5[1] + num9 * array5[3] + num10 * array5[4];
				float num13 = num8 * array5[2] + num9 * array5[4] + num10 * array5[5];
				num8 = num11;
				num9 = num12;
				num10 = num13;
			}
			float num14 = Math.Max(Math.Max(Math.Abs(num8), Math.Abs(num9)), Math.Abs(num10));
			int num15;
			int num16;
			int num17;
			if (num14 < 4f)
			{
				num15 = 148;
				num16 = 300;
				num17 = 58;
			}
			else
			{
				num14 = 512f / num14;
				num15 = Convert.ToInt32(num8 * num14);
				num16 = Convert.ToInt32(num9 * num14);
				num17 = Convert.ToInt32(num10 * num14);
			}
			int num18 = 2147483647;
			int num19 = -2147483647;
			Color color_ = default(Color);
			Color color_2 = default(Color);
			for (int num20 = 0; num20 < 16; num20++)
			{
				int num21 = (int)block[num20].R * num15 + (int)block[num20].G * num16 + (int)block[num20].B * num17;
				if (num21 < num18)
				{
					num18 = num21;
					color_ = block[num20];
				}
				if (num21 > num19)
				{
					num19 = num21;
					color_2 = block[num20];
				}
			}
			max16 = UnkGfxClass1.smethod_4(color_2);
			min16 = UnkGfxClass1.smethod_4(color_);
		}

		private static bool smethod_10(Color[] color_0, ref ushort ushort_0, ref ushort ushort_1, uint uint_0)
		{
			int[] array = new int[]
			{
				3,
				0,
				2,
				1
			};
			int[] array2 = new int[]
			{
				589824,
				2304,
				262402,
				66562
			};
			int num = 0;
			uint num2 = uint_0;
			int arg_30_0 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = arg_30_0;
			int arg_38_0 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = arg_38_0;
			int i = 0;
			while (i < 16)
			{
				int num9 = (int)(num2 & 3u);
				int num10 = array[num9];
				int r = (int)color_0[i].R;
				int g = (int)color_0[i].G;
				int b = (int)color_0[i].B;
				num += array2[num9];
				num5 += num10 * r;
				num4 += num10 * g;
				num3 += num10 * b;
				num8 += r;
				num7 += g;
				num6 += b;
				i++;
				num2 >>= 2;
			}
			num8 = 3 * num8 - num5;
			num7 = 3 * num7 - num4;
			num6 = 3 * num6 - num3;
			int num11 = num >> 16;
			int num12 = num >> 8 & 255;
			int num13 = num & 255;
			if (num12 != 0 && num11 != 0)
			{
				if (num11 * num12 != num13 * num13)
				{
					float num14 = 0.3647059f / (float)(num11 * num12 - num13 * num13);
					float num15 = num14 * 63f / 31f;
					ushort num16 = ushort_1;
					ushort num17 = ushort_0;
					ushort_0 = (ushort)(UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num5 * num12 - num8 * num13) * num14 + 0.5f), 0, 31) << 11);
					ushort_0 = (ushort)((int)ushort_0 | UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num4 * num12 - num7 * num13) * num15 + 0.5f), 0, 63) << 5);
					ushort_0 = (ushort)((int)ushort_0 | UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num3 * num12 - num6 * num13) * num14 + 0.5f), 0, 31));
					ushort_1 = (ushort)(UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num8 * num11 - num5 * num13) * num14 + 0.5f), 0, 31) << 11);
					ushort_1 = (ushort)((int)ushort_1 | UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num7 * num11 - num4 * num13) * num15 + 0.5f), 0, 63) << 5);
					ushort_1 = (ushort)((int)ushort_1 | UnkGfxClass1.smethod_11(Convert.ToInt32((float)(num6 * num11 - num3 * num13) * num14 + 0.5f), 0, 31));
					return num16 != ushort_1 || num17 != ushort_0;
				}
			}
			return false;
		}

		private static int smethod_11(int int_0, int int_1, int int_2)
		{
			if (int_0 >= int_2)
			{
				return int_2;
			}
			if (int_0 > int_1)
			{
				return int_0;
			}
			return int_1;
		}

		private static UnkGfxClass1.Struct88 smethod_12(Color[] color_0, bool bool_1)
		{
			Color[] array = new Color[16];
			Color[] color_ = new Color[4];
			uint num2;
			uint num = num2 = (uint)color_0[0].ToArgb();
			for (int i = 1; i < 16; i++)
			{
				num2 = Math.Min(num2, (uint)color_0[i].ToArgb());
				num = Math.Max(num, (uint)color_0[i].ToArgb());
			}
			ushort num3;
			ushort num4;
			uint num5;
			if (num2 != num)
			{
				if (bool_1)
				{
					array = UnkGfxClass1.smethod_7(color_0);
				}
				UnkGfxClass1.smethod_9(bool_1 ? array : color_0, out num3, out num4);
				if (num3 != num4)
				{
					UnkGfxClass1.smethod_6(ref color_, num3, num4);
					num5 = UnkGfxClass1.smethod_8(color_0, color_, bool_1);
				}
				else
				{
					num5 = 0u;
				}
				if (UnkGfxClass1.smethod_10(bool_1 ? array : color_0, ref num3, ref num4, num5))
				{
					if (num3 != num4)
					{
						UnkGfxClass1.smethod_6(ref color_, num3, num4);
						num5 = UnkGfxClass1.smethod_8(color_0, color_, bool_1);
					}
					else
					{
						num5 = 0u;
					}
				}
			}
			else
			{
				int r = (int)color_0[0].R;
				int g = (int)color_0[0].G;
				int b = (int)color_0[0].B;
				num5 = 2863311530u;
				num3 = Convert.ToUInt16((int)UnkGfxClass1.byte_2[r, 0] << 11 | (int)UnkGfxClass1.byte_3[g, 0] << 5 | (int)UnkGfxClass1.byte_2[b, 0]);
				num4 = Convert.ToUInt16((int)UnkGfxClass1.byte_2[r, 1] << 11 | (int)UnkGfxClass1.byte_3[g, 1] << 5 | (int)UnkGfxClass1.byte_2[b, 1]);
			}
			if (num3 < num4)
			{
				ushort num6 = num3;
				num3 = num4;
				num4 = num6;
				num5 ^= 1431655765u;
			}
			UnkGfxClass1.Struct88 result;
			result.ushort_0 = num3;
			result.ushort_1 = num4;
			result.uint_0 = num5;
			return result;
		}

		private static int smethod_13(float float_0, int int_0)
		{
			int num = Convert.ToInt32(float_0 + 0.5f);
			if (num < 0)
			{
				num = 0;
			}
			else if (num > int_0)
			{
				num = int_0;
			}
			return num;
		}

		private static byte[] smethod_14(Color[] color_0)
		{
			byte[] array = new byte[8];
			for (int i = 0; i < 8; i++)
			{
				float float_ = (float)color_0[2 * i].A * 0.05882353f;
				float float_2 = (float)color_0[2 * i + 1].A * 0.05882353f;
				int num = UnkGfxClass1.smethod_13(float_, 15);
				int num2 = UnkGfxClass1.smethod_13(float_2, 15);
				array[i] = (byte)(num | num2 << 4);
			}
			return array;
		}

		private static byte[] smethod_15(Color[] color_0)
		{
			byte[] array = new byte[8];
			int num = 0;
			byte b2;
			byte b = b2 = color_0[0].A;
			for (int i = 1; i < 16; i++)
			{
				b2 = Math.Min(b2, color_0[i].A);
				b = Math.Max(b, color_0[i].A);
			}
			array[num++] = b;
			array[num++] = b2;
			int num2 = (int)(b - b2);
			int num3 = (int)(b2 * 7) - (num2 >> 1);
			int num4 = num2 * 4;
			int num5 = num2 * 2;
			int num6 = 0;
			int num7 = 0;
			for (int j = 0; j < 16; j++)
			{
				int num8 = (int)(color_0[j].A * 7) - num3;
				int num9 = num4 - num8 >> 31;
				int num10 = num9 & 4;
				num8 -= (num4 & num9);
				num9 = num5 - num8 >> 31;
				num10 += (num9 & 2);
				num8 -= (num5 & num9);
				num9 = num2 - num8 >> 31;
				num10 += (num9 & 1);
				num10 = (-num10 & 7);
				num10 ^= Convert.ToInt32(2 > num10);
				num7 |= num10 << num6;
				if ((num6 += 3) >= 8)
				{
					array[num++] = (byte)num7;
					num7 >>= 8;
					num6 -= 8;
				}
			}
			return array;
		}

		public static void smethod_16(Bitmap bitmap_0, BinaryWriter binaryWriter_0, IMGPixelFormat imgpixelFormat_0, bool bool_1)
		{
			int height = bitmap_0.Height;
			int width = bitmap_0.Width;
			if (!UnkGfxClass1.bool_0)
			{
				UnkGfxClass1.smethod_0();
			}
			for (int i = 0; i < height; i += 4)
			{
				for (int j = 0; j < width; j += 4)
				{
					Color[] array = new Color[16];
					int num = 0;
					for (int k = 0; k < 4; k++)
					{
						for (int l = 0; l < 4; l++)
						{
							if (j + l < width && i + k < height)
							{
								array[num++] = bitmap_0.GetPixel(j + l, i + k);
							}
						}
					}
					if (imgpixelFormat_0 == IMGPixelFormat.Dxt3)
					{
						binaryWriter_0.Write(UnkGfxClass1.smethod_14(array));
					}
					else if (imgpixelFormat_0 == IMGPixelFormat.Dxt5)
					{
						binaryWriter_0.Write(UnkGfxClass1.smethod_15(array));
					}
					UnkGfxClass1.smethod_12(array, bool_1).method_0(binaryWriter_0);
				}
			}
		}

		public static void smethod_17(BinaryReader binaryReader_0, Class219 class219_0, IMGPixelFormat imgpixelFormat_0)
		{
			UnkGfxClass1.Struct87[] array = new UnkGfxClass1.Struct87[16];
			int num = class219_0.method_1();
			int num2 = class219_0.method_0();
			for (int i = 0; i < num; i += 4)
			{
				for (int j = 0; j < num2; j += 4)
				{
					if (imgpixelFormat_0 == IMGPixelFormat.Dxt3)
					{
						ushort[] array2 = new ushort[4];
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 4; l++)
							{
								if (l == 0)
								{
									array2[k] = binaryReader_0.ReadUInt16();
								}
								array[k * 4 + l].float_0 = (float)(array2[k] & 15) / 15f;
								ushort[] expr_74_cp_0 = array2;
								int expr_74_cp_1 = k;
								expr_74_cp_0[expr_74_cp_1] = (ushort)(expr_74_cp_0[expr_74_cp_1] >> 4);
							}
						}
					}
					else if (imgpixelFormat_0 == IMGPixelFormat.Dxt5)
					{
						byte[] array3 = binaryReader_0.ReadBytes(2);
						byte[] array4 = binaryReader_0.ReadBytes(6);
						float[] array5 = new float[8];
						array5[0] = (float)array3[0] / 255f;
						array5[1] = (float)array3[1] / 255f;
						int num3 = 4;
						if (array3[0] > array3[1])
						{
							num3 = 6;
						}
						else
						{
							array5[6] = 0f;
							array5[7] = 1f;
						}
						float num4 = 1f / (float)(num3 + 1);
						for (int m = 0; m < num3; m++)
						{
							float num5 = (float)(num3 - m) * num4;
							float num6 = (float)(m + 1) * num4;
							array5[m + 2] = num5 * (float)array3[0] + num6 * (float)array3[1];
						}
						for (int n = 0; n < 16; n++)
						{
							int num7 = n * 3 / 8;
							int num8 = n * 3 % 8;
							byte b = (byte)(array4[num7] >> num8 & 7);
							if (num8 > 5)
							{
								byte b2 = (byte)((int)array4[num7 + 1] << 8 - num8 & 255);
                                b |= (byte)(b2 & 7);
							}
							array[n].float_0 = array5[(int)b];
						}
					}
					UnkGfxClass1.Struct88 @struct = UnkGfxClass1.Struct88.smethod_0(binaryReader_0);
					UnkGfxClass1.Struct87[] array6 = new UnkGfxClass1.Struct87[4];
					array6[0].float_1 = (float)((@struct.ushort_0 & 63488) >> 11) / 31f;
					array6[0].float_2 = (float)((@struct.ushort_0 & 2016) >> 5) / 63f;
					array6[0].float_3 = (float)(@struct.ushort_0 & 31) / 31f;
					array6[1].float_1 = (float)((@struct.ushort_1 & 63488) >> 11) / 31f;
					array6[1].float_2 = (float)((@struct.ushort_1 & 2016) >> 5) / 63f;
					array6[1].float_3 = (float)(@struct.ushort_1 & 31) / 31f;
					if (imgpixelFormat_0 == IMGPixelFormat.Dxt1 && @struct.ushort_0 <= @struct.ushort_1)
					{
						array6[2] = UnkGfxClass1.Struct87.smethod_1(UnkGfxClass1.Struct87.smethod_2(array6[0], array6[1]), 0.5f);
						array6[3] = default(UnkGfxClass1.Struct87);
					}
					else
					{
						array6[2] = UnkGfxClass1.Struct87.smethod_1(UnkGfxClass1.Struct87.smethod_2(UnkGfxClass1.Struct87.smethod_0(2f, array6[0]), array6[1]), 0.333333343f);
						array6[3] = UnkGfxClass1.Struct87.smethod_1(UnkGfxClass1.Struct87.smethod_2(array6[0], UnkGfxClass1.Struct87.smethod_0(2f, array6[1])), 0.333333343f);
					}
					for (int num9 = 0; num9 < 4; num9++)
					{
						for (int num10 = 0; num10 < 4; num10++)
						{
							if (j + num10 < num2 && i + num9 < num)
							{
								Point point_ = new Point(j + num10, i + num9);
								uint num11 = @struct.uint_0 & 3u;
								if (imgpixelFormat_0 == IMGPixelFormat.Dxt1)
								{
									class219_0.method_6(point_, Color.FromArgb((int)((byte)(array6[(int)((UIntPtr)num11)].float_0 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_1 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_2 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_3 * 255f))));
								}
								else
								{
									class219_0.method_6(point_, Color.FromArgb((int)((byte)(array[num9 * 4 + num10].float_0 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_1 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_2 * 255f)), (int)((byte)(array6[(int)((UIntPtr)num11)].float_3 * 255f))));
								}
							}
							@struct.uint_0 >>= 2;
						}
					}
				}
			}
		}
	}
}
