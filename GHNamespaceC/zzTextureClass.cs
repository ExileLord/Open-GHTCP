using System;
using System.Drawing;
using System.IO;
using GHNamespace7;
using NeversoftTools.Texture.DDS;

namespace GHNamespaceC
{
    public class ZzTextureClass
    {
        //Nonsense names for now to help me remember which is which
        public struct Tom
        {
            public float Float0;

            public float Float1;

            public float Float2;

            public float Float3;

            public static Tom smethod_0(float float4, Tom struct870)
            {
                return smethod_1(struct870, float4);
            }

            public static Tom smethod_1(Tom struct870, float float4)
            {
                Tom result;
                result.Float0 = float4 * struct870.Float0;
                result.Float1 = float4 * struct870.Float1;
                result.Float2 = float4 * struct870.Float2;
                result.Float3 = float4 * struct870.Float3;
                return result;
            }

            public static Tom smethod_2(Tom struct870, Tom struct871)
            {
                Tom result;
                result.Float0 = struct870.Float0 + struct871.Float0;
                result.Float1 = struct870.Float1 + struct871.Float1;
                result.Float2 = struct870.Float2 + struct871.Float2;
                result.Float3 = struct870.Float3 + struct871.Float3;
                return result;
            }
        }

        public struct Jerry
        {
            public ushort Ushort0;

            public ushort Ushort1;

            public uint Uint0;

            public static Jerry smethod_0(BinaryReader binaryReader0)
            {
                Jerry result;
                result.Ushort0 = binaryReader0.ReadUInt16();
                result.Ushort1 = binaryReader0.ReadUInt16();
                result.Uint0 = binaryReader0.ReadUInt32();
                return result;
            }

            public void method_0(BinaryWriter binaryWriter0)
            {
                binaryWriter0.Write(Ushort0);
                binaryWriter0.Write(Ushort1);
                binaryWriter0.Write(Uint0);
            }
        }

        private static readonly byte[] Byte0 = new byte[32];

        private static readonly byte[] Byte1 = new byte[64];

        private static byte[,] _byte2 = new byte[256, 2];

        private static byte[,] _byte3 = new byte[256, 2];

        private static readonly byte[] Byte4 = new byte[272];

        private static readonly byte[] Byte5 = new byte[272];

        private static bool _bool0;

        private static void smethod_0()
        {
            for (var i = 0; i < 32; i++)
            {
                Byte0[i] = (byte) (i << 3 | i >> 2);
            }
            for (var j = 0; j < 64; j++)
            {
                Byte1[j] = (byte) (j << 2 | j >> 4);
            }
            for (var k = 0; k < 272; k++)
            {
                var int_ = smethod_11(k - 8, 0, 255);
                Byte4[k] = Byte0[smethod_2(int_, 31)];
                Byte5[k] = Byte1[smethod_2(int_, 63)];
            }
            smethod_1(ref _byte2, Byte0, 32);
            smethod_1(ref _byte3, Byte1, 64);
            _bool0 = true;
        }

        private static void smethod_1(ref byte[,] byte6, byte[] byte7, int int0)
        {
            for (var i = 0; i < 256; i++)
            {
                var num = 256;
                for (var j = 0; j < int0; j++)
                {
                    for (var k = 0; k < int0; k++)
                    {
                        int num2 = byte7[j];
                        int num3 = byte7[k];
                        var num4 = Math.Abs(num3 + smethod_2(num2 - num3, 85) - i);
                        if (num4 < num)
                        {
                            byte6[i, 0] = (byte) k;
                            byte6[i, 1] = (byte) j;
                            num = num4;
                        }
                    }
                }
            }
        }

        private static int smethod_2(int int0, int int1)
        {
            var num = int0 * int1 + 128;
            return num + (num >> 8) >> 8;
        }

        private static Color smethod_3(ushort ushort0)
        {
            var num = (ushort0 & 63488) >> 11;
            var num2 = (ushort0 & 2016) >> 5;
            var num3 = ushort0 & 31;
            return Color.FromArgb(0, Byte0[num], Byte1[num2], Byte0[num3]);
        }

        private static ushort smethod_4(Color color0)
        {
            return (ushort) ((smethod_2(color0.R, 31) << 11) + (smethod_2(color0.G, 63) << 5) +
                             smethod_2(color0.B, 31));
        }

        private static Color smethod_5(Color color0, Color color1, int int0)
        {
            return Color.FromArgb(color0.R + smethod_2(color1.R - color0.R, int0),
                color0.G + smethod_2(color1.G - color0.G, int0), color0.B + smethod_2(color1.B - color0.B, int0));
        }

        private static void smethod_6(ref Color[] color0, ushort ushort0, ushort ushort1)
        {
            color0[0] = smethod_3(ushort0);
            color0[1] = smethod_3(ushort1);
            color0[2] = smethod_5(color0[0], color0[1], 85);
            color0[3] = smethod_5(color0[0], color0[1], 170);
        }

        private static Color[] smethod_7(Color[] color0)
        {
            var array = new Color[color0.Length];
            var array2 = new int[3, 4];
            var array3 = new int[3, 4];
            for (var i = 0; i < 4; i++)
            {
                var num = i * 4;
                var b = Byte4[color0[num].B + (3 * array3[0, 1] + 5 * array3[0, 0] >> 4) + 8];
                array2[0, 0] = color0[num].B - b;
                var b2 = Byte5[color0[num].G + (3 * array3[1, 1] + 5 * array3[1, 0] >> 4) + 8];
                array2[1, 0] = color0[num].G - b2;
                var b3 = Byte4[color0[num].R + (3 * array3[2, 1] + 5 * array3[2, 0] >> 4) + 8];
                array2[2, 0] = color0[num].R - b3;
                array[num] = Color.FromArgb(b3, b2, b);
                b =
                    Byte4[
                        color0[num + 1].B +
                        (7 * array2[0, 0] + 3 * array3[0, 2] + 5 * array3[0, 1] + array3[0, 0] >> 4) + 8];
                array2[0, 1] = color0[num + 1].B - b;
                b2 =
                    Byte5[
                        color0[num + 1].G +
                        (7 * array2[1, 0] + 3 * array3[1, 2] + 5 * array3[1, 1] + array3[1, 0] >> 4) + 8];
                array2[1, 1] = color0[num + 1].G - b2;
                b3 =
                    Byte4[
                        color0[num + 1].R +
                        (7 * array2[2, 0] + 3 * array3[2, 2] + 5 * array3[2, 1] + array3[2, 0] >> 4) + 8];
                array2[2, 1] = color0[num + 1].R - b3;
                array[num + 1] = Color.FromArgb(b3, b2, b);
                b =
                    Byte4[
                        color0[num + 2].B +
                        (7 * array2[0, 1] + 3 * array3[0, 3] + 5 * array3[0, 2] + array3[0, 1] >> 4) + 8];
                array2[0, 2] = color0[num + 2].B - b;
                b2 =
                    Byte5[
                        color0[num + 2].G +
                        (7 * array2[1, 1] + 3 * array3[1, 3] + 5 * array3[1, 2] + array3[1, 1] >> 4) + 8];
                array2[1, 2] = color0[num + 2].G - b2;
                b3 =
                    Byte4[
                        color0[num + 2].R +
                        (7 * array2[2, 1] + 3 * array3[2, 3] + 5 * array3[2, 2] + array3[2, 1] >> 4) + 8];
                array2[2, 2] = color0[num + 2].R - b3;
                array[num + 2] = Color.FromArgb(b3, b2, b);
                b = Byte4[color0[num + 3].B + (7 * array2[0, 2] + 5 * array3[0, 3] + array3[0, 2] >> 4) + 8];
                array2[0, 3] = color0[num + 3].B - b;
                b2 = Byte5[color0[num + 3].G + (7 * array2[1, 2] + 5 * array3[1, 3] + array3[1, 2] >> 4) + 8];
                array2[1, 3] = color0[num + 3].G - b2;
                b3 = Byte4[color0[num + 3].R + (7 * array2[2, 2] + 5 * array3[2, 3] + array3[2, 2] >> 4) + 8];
                array2[2, 3] = color0[num + 3].R - b3;
                array[num + 3] = Color.FromArgb(b3, b2, b);
                var array4 = array2;
                array2 = array3;
                array3 = array4;
            }
            return array;
        }

        private static uint smethod_8(Color[] color0, Color[] color1, bool bool1)
        {
            var num = 0u;
            var num2 = color1[0].R - color1[1].R;
            var num3 = color1[0].G - color1[1].G;
            var num4 = color1[0].B - color1[1].B;
            var array = new int[16];
            for (var i = 0; i < 16; i++)
            {
                array[i] = color0[i].R * num2 + color0[i].G * num3 + color0[i].B * num4;
            }
            var array2 = new int[4];
            for (var j = 0; j < 4; j++)
            {
                array2[j] = color1[j].R * num2 + color1[j].G * num3 + color1[j].B * num4;
            }
            var num5 = array2[1] + array2[3] >> 1;
            var num6 = array2[3] + array2[2] >> 1;
            var num7 = array2[2] + array2[0] >> 1;
            if (!bool1)
            {
                for (var k = 15; k >= 0; k--)
                {
                    num <<= 2;
                    var num8 = array[k];
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
                var array3 = new int[4];
                var array4 = new int[4];
                num5 <<= 4;
                num6 <<= 4;
                num7 <<= 4;
                for (var l = 0; l < 4; l++)
                {
                    var num9 = (array[l * 4] << 4) + (3 * array4[1] + 5 * array4[0]);
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
                    var num11 = num10;
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
                    var array5 = array3;
                    array3 = array4;
                    array4 = array5;
                    num |= (uint) num11 << l * 8;
                }
            }
            return num;
        }

        private static void smethod_9(Color[] block, out ushort max16, out ushort min16)
        {
            var num = 4;
            var array = new int[3];
            var array2 = new int[3];
            var array3 = new int[3];
            for (var i = 0; i < 3; i++)
            {
                int num4;
                int num3;
                var num2 = num3 = (num4 = (block[0].ToArgb() >> i * 8 & 255));
                for (var j = 1; j < 16; j++)
                {
                    var b = (byte) (block[j].ToArgb() >> i * 8 & 255);
                    num3 += b;
                    num2 = Math.Min(num2, b);
                    num4 = Math.Max(num4, b);
                }
                array[i] = num3 + 8 >> 4;
                array2[i] = num2;
                array3[i] = num4;
            }
            var array4 = new int[6];
            for (var k = 0; k < 6; k++)
            {
                array4[k] = 0;
            }
            for (var l = 0; l < 16; l++)
            {
                var num5 = block[l].R - array[2];
                var num6 = block[l].G - array[1];
                var num7 = block[l].B - array[0];
                array4[0] += num5 * num5;
                array4[1] += num5 * num6;
                array4[2] += num5 * num7;
                array4[3] += num6 * num6;
                array4[4] += num6 * num7;
                array4[5] += num7 * num7;
            }
            var array5 = new float[6];
            for (var m = 0; m < 6; m++)
            {
                array5[m] = array4[m] / 255f;
            }
            float num8 = array3[2] - array2[2];
            float num9 = array3[1] - array2[1];
            float num10 = array3[0] - array2[0];
            for (var n = 0; n < num; n++)
            {
                var num11 = num8 * array5[0] + num9 * array5[1] + num10 * array5[2];
                var num12 = num8 * array5[1] + num9 * array5[3] + num10 * array5[4];
                var num13 = num8 * array5[2] + num9 * array5[4] + num10 * array5[5];
                num8 = num11;
                num9 = num12;
                num10 = num13;
            }
            var num14 = Math.Max(Math.Max(Math.Abs(num8), Math.Abs(num9)), Math.Abs(num10));
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
            var num18 = 2147483647;
            var num19 = -2147483647;
            var color = default(Color);
            var color2 = default(Color);
            for (var num20 = 0; num20 < 16; num20++)
            {
                var num21 = block[num20].R * num15 + block[num20].G * num16 + block[num20].B * num17;
                if (num21 < num18)
                {
                    num18 = num21;
                    color = block[num20];
                }
                if (num21 > num19)
                {
                    num19 = num21;
                    color2 = block[num20];
                }
            }
            max16 = smethod_4(color2);
            min16 = smethod_4(color);
        }

        private static bool smethod_10(Color[] color0, ref ushort ushort0, ref ushort ushort1, uint uint0)
        {
            int[] array =
            {
                3,
                0,
                2,
                1
            };
            int[] array2 =
            {
                589824,
                2304,
                262402,
                66562
            };
            var num = 0;
            var num2 = uint0;
            var arg300 = 0;
            var num3 = 0;
            var num4 = 0;
            var num5 = arg300;
            var arg380 = 0;
            var num6 = 0;
            var num7 = 0;
            var num8 = arg380;
            var i = 0;
            while (i < 16)
            {
                var num9 = (int) (num2 & 3u);
                var num10 = array[num9];
                int r = color0[i].R;
                int g = color0[i].G;
                int b = color0[i].B;
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
            var num11 = num >> 16;
            var num12 = num >> 8 & 255;
            var num13 = num & 255;
            if (num12 != 0 && num11 != 0)
            {
                if (num11 * num12 != num13 * num13)
                {
                    var num14 = 0.3647059f / (num11 * num12 - num13 * num13);
                    var num15 = num14 * 63f / 31f;
                    var num16 = ushort1;
                    var num17 = ushort0;
                    ushort0 =
                        (ushort) (smethod_11(Convert.ToInt32((num5 * num12 - num8 * num13) * num14 + 0.5f), 0,
                                      31) << 11);
                    ushort0 =
                        (ushort) (ushort0 | smethod_11(Convert.ToInt32((num4 * num12 - num7 * num13) * num15 + 0.5f), 0,
                                      63) << 5);
                    ushort0 =
                        (ushort) (ushort0 | smethod_11(Convert.ToInt32((num3 * num12 - num6 * num13) * num14 + 0.5f), 0,
                                      31));
                    ushort1 =
                        (ushort) (smethod_11(Convert.ToInt32((num8 * num11 - num5 * num13) * num14 + 0.5f), 0,
                                      31) << 11);
                    ushort1 =
                        (ushort) (ushort1 | smethod_11(Convert.ToInt32((num7 * num11 - num4 * num13) * num15 + 0.5f), 0,
                                      63) << 5);
                    ushort1 =
                        (ushort) (ushort1 | smethod_11(Convert.ToInt32((num6 * num11 - num3 * num13) * num14 + 0.5f), 0,
                                      31));
                    return num16 != ushort1 || num17 != ushort0;
                }
            }
            return false;
        }

        private static int smethod_11(int int0, int int1, int int2)
        {
            if (int0 >= int2)
            {
                return int2;
            }
            if (int0 > int1)
            {
                return int0;
            }
            return int1;
        }

        private static Jerry smethod_12(Color[] color0, bool bool1)
        {
            var array = new Color[16];
            var color = new Color[4];
            uint num2;
            var num = num2 = (uint) color0[0].ToArgb();
            for (var i = 1; i < 16; i++)
            {
                num2 = Math.Min(num2, (uint) color0[i].ToArgb());
                num = Math.Max(num, (uint) color0[i].ToArgb());
            }
            ushort num3;
            ushort num4;
            uint num5;
            if (num2 != num)
            {
                if (bool1)
                {
                    array = smethod_7(color0);
                }
                smethod_9(bool1 ? array : color0, out num3, out num4);
                if (num3 != num4)
                {
                    smethod_6(ref color, num3, num4);
                    num5 = smethod_8(color0, color, bool1);
                }
                else
                {
                    num5 = 0u;
                }
                if (smethod_10(bool1 ? array : color0, ref num3, ref num4, num5))
                {
                    if (num3 != num4)
                    {
                        smethod_6(ref color, num3, num4);
                        num5 = smethod_8(color0, color, bool1);
                    }
                    else
                    {
                        num5 = 0u;
                    }
                }
            }
            else
            {
                int r = color0[0].R;
                int g = color0[0].G;
                int b = color0[0].B;
                num5 = 2863311530u;
                num3 = Convert.ToUInt16(_byte2[r, 0] << 11 | _byte3[g, 0] << 5 | _byte2[b, 0]);
                num4 = Convert.ToUInt16(_byte2[r, 1] << 11 | _byte3[g, 1] << 5 | _byte2[b, 1]);
            }
            if (num3 < num4)
            {
                var num6 = num3;
                num3 = num4;
                num4 = num6;
                num5 ^= 1431655765u;
            }
            Jerry result;
            result.Ushort0 = num3;
            result.Ushort1 = num4;
            result.Uint0 = num5;
            return result;
        }

        private static int smethod_13(float float0, int int0)
        {
            var num = Convert.ToInt32(float0 + 0.5f);
            if (num < 0)
            {
                num = 0;
            }
            else if (num > int0)
            {
                num = int0;
            }
            return num;
        }

        private static byte[] smethod_14(Color[] color0)
        {
            var array = new byte[8];
            for (var i = 0; i < 8; i++)
            {
                var float_ = color0[2 * i].A * 0.05882353f;
                var float2 = color0[2 * i + 1].A * 0.05882353f;
                var num = smethod_13(float_, 15);
                var num2 = smethod_13(float2, 15);
                array[i] = (byte) (num | num2 << 4);
            }
            return array;
        }

        private static byte[] smethod_15(Color[] color0)
        {
            var array = new byte[8];
            var num = 0;
            byte b2;
            var b = b2 = color0[0].A;
            for (var i = 1; i < 16; i++)
            {
                b2 = Math.Min(b2, color0[i].A);
                b = Math.Max(b, color0[i].A);
            }
            array[num++] = b;
            array[num++] = b2;
            var num2 = b - b2;
            var num3 = b2 * 7 - (num2 >> 1);
            var num4 = num2 * 4;
            var num5 = num2 * 2;
            var num6 = 0;
            var num7 = 0;
            for (var j = 0; j < 16; j++)
            {
                var num8 = color0[j].A * 7 - num3;
                var num9 = num4 - num8 >> 31;
                var num10 = num9 & 4;
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
                    array[num++] = (byte) num7;
                    num7 >>= 8;
                    num6 -= 8;
                }
            }
            return array;
        }

        public static void smethod_16(Bitmap bitmap0, BinaryWriter binaryWriter0, ImgPixelFormat imgpixelFormat0,
            bool bool1)
        {
            var height = bitmap0.Height;
            var width = bitmap0.Width;
            if (!_bool0)
            {
                smethod_0();
            }
            for (var i = 0; i < height; i += 4)
            {
                for (var j = 0; j < width; j += 4)
                {
                    var array = new Color[16];
                    var num = 0;
                    for (var k = 0; k < 4; k++)
                    {
                        for (var l = 0; l < 4; l++)
                        {
                            if (j + l < width && i + k < height)
                            {
                                array[num++] = bitmap0.GetPixel(j + l, i + k);
                            }
                        }
                    }
                    if (imgpixelFormat0 == ImgPixelFormat.Dxt3)
                    {
                        binaryWriter0.Write(smethod_14(array));
                    }
                    else if (imgpixelFormat0 == ImgPixelFormat.Dxt5)
                    {
                        binaryWriter0.Write(smethod_15(array));
                    }
                    smethod_12(array, bool1).method_0(binaryWriter0);
                }
            }
        }

        public static void smethod_17(BinaryReader binaryReader0, ImageRelatedClass class2190,
            ImgPixelFormat imgpixelFormat0)
        {
            var array = new Tom[16];
            var num = class2190.method_1();
            var num2 = class2190.method_0();
            for (var i = 0; i < num; i += 4)
            {
                for (var j = 0; j < num2; j += 4)
                {
                    if (imgpixelFormat0 == ImgPixelFormat.Dxt3)
                    {
                        var array2 = new ushort[4];
                        for (var k = 0; k < 4; k++)
                        {
                            for (var l = 0; l < 4; l++)
                            {
                                if (l == 0)
                                {
                                    array2[k] = binaryReader0.ReadUInt16();
                                }
                                array[k * 4 + l].Float0 = (array2[k] & 15) / 15f;
                                var expr74Cp0 = array2;
                                var expr74Cp1 = k;
                                expr74Cp0[expr74Cp1] = (ushort) (expr74Cp0[expr74Cp1] >> 4);
                            }
                        }
                    }
                    else if (imgpixelFormat0 == ImgPixelFormat.Dxt5)
                    {
                        var array3 = binaryReader0.ReadBytes(2);
                        var array4 = binaryReader0.ReadBytes(6);
                        var array5 = new float[8];
                        array5[0] = array3[0] / 255f;
                        array5[1] = array3[1] / 255f;
                        var num3 = 4;
                        if (array3[0] > array3[1])
                        {
                            num3 = 6;
                        }
                        else
                        {
                            array5[6] = 0f;
                            array5[7] = 1f;
                        }
                        var num4 = 1f / (num3 + 1);
                        for (var m = 0; m < num3; m++)
                        {
                            var num5 = (num3 - m) * num4;
                            var num6 = (m + 1) * num4;
                            array5[m + 2] = num5 * array3[0] + num6 * array3[1];
                        }
                        for (var n = 0; n < 16; n++)
                        {
                            //Console.WriteLine("Broken");
                            var div = (n * 3) / 8;
                            var rem = (n * 3) % 8;
                            var b = (byte) ((array4[div] >> rem) & 7);
                            if (rem > 5)
                            {
                                var b2 = (byte) ((array4[div + 1] << (8 - rem)) & 0xFF);
                                b |= (byte) (b2 & 7);
                            }
                            array[n].Float0 = array5[b];
                        }
                    }
                    var @struct = Jerry.smethod_0(binaryReader0);
                    var array6 = new Tom[4];
                    array6[0].Float1 = ((@struct.Ushort0 & 63488) >> 11) / 31f;
                    array6[0].Float2 = ((@struct.Ushort0 & 2016) >> 5) / 63f;
                    array6[0].Float3 = (@struct.Ushort0 & 31) / 31f;
                    array6[1].Float1 = ((@struct.Ushort1 & 63488) >> 11) / 31f;
                    array6[1].Float2 = ((@struct.Ushort1 & 2016) >> 5) / 63f;
                    array6[1].Float3 = (@struct.Ushort1 & 31) / 31f;
                    if (imgpixelFormat0 == ImgPixelFormat.Dxt1 && @struct.Ushort0 <= @struct.Ushort1)
                    {
                        array6[2] = Tom.smethod_1(Tom.smethod_2(array6[0], array6[1]), 0.5f);
                        array6[3] = default(Tom);
                    }
                    else
                    {
                        array6[2] = Tom.smethod_1(Tom.smethod_2(Tom.smethod_0(2f, array6[0]), array6[1]), 0.333333343f);
                        array6[3] = Tom.smethod_1(Tom.smethod_2(array6[0], Tom.smethod_0(2f, array6[1])), 0.333333343f);
                    }
                    for (var num9 = 0; num9 < 4; num9++)
                    {
                        for (var num10 = 0; num10 < 4; num10++)
                        {
                            if (j + num10 < num2 && i + num9 < num)
                            {
                                var point = new Point(j + num10, i + num9);
                                var num11 = @struct.Uint0 & 3u;
                                if (imgpixelFormat0 == ImgPixelFormat.Dxt1)
                                {
                                    class2190.method_6(point,
                                        Color.FromArgb((byte) (array6[(int) ((UIntPtr) num11)].Float0 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float1 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float2 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float3 * 255f)));
                                }
                                else
                                {
                                    class2190.method_6(point,
                                        Color.FromArgb((byte) (array[num9 * 4 + num10].Float0 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float1 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float2 * 255f),
                                            (byte) (array6[(int) ((UIntPtr) num11)].Float3 * 255f)));
                                }
                            }
                            @struct.Uint0 >>= 2;
                        }
                    }
                }
            }
        }
    }
}