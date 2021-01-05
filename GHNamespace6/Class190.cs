using System;
using Compression;
using GHNamespace5;

namespace GHNamespace6
{
    public class Class190
    {
        private class Class191
        {
            public readonly short[] Short0;

            public byte[] Byte0;

            public readonly int Int0;

            public int Int1;

            private short[] _short1;

            private readonly int[] _int2;

            private readonly int _int3;

            private readonly Class190 _class1900;

            public Class191(Class190 class1901, int int4, int int5, int int6)
            {
                _class1900 = class1901;
                Int0 = int5;
                _int3 = int6;
                Short0 = new short[int4];
                _int2 = new int[int6];
            }

            public void method_0()
            {
                for (var i = 0; i < Short0.Length; i++)
                {
                    Short0[i] = 0;
                }
                _short1 = null;
                Byte0 = null;
            }

            public void method_1(int int4)
            {
                _class1900.Class1890.method_5(_short1[int4] & 65535, Byte0[int4]);
            }

            public void method_2(short[] short2, byte[] byte1)
            {
                _short1 = short2;
                Byte0 = byte1;
            }

            public void method_3()
            {
                var array = new int[_int3];
                var num = 0;
                _short1 = new short[Short0.Length];
                for (var i = 0; i < _int3; i++)
                {
                    array[i] = num;
                    num += _int2[i] << 15 - i;
                }
                for (var j = 0; j < Int1; j++)
                {
                    int num2 = Byte0[j];
                    if (num2 > 0)
                    {
                        _short1[j] = smethod_0(array[num2 - 1]);
                        array[num2 - 1] += 1 << 16 - num2;
                    }
                }
            }

            public void method_4()
            {
                var num = Short0.Length;
                var array = new int[num];
                var i = 0;
                var num2 = 0;
                for (var j = 0; j < num; j++)
                {
                    int num3 = Short0[j];
                    if (num3 != 0)
                    {
                        var num4 = i++;
                        int num5;
                        while (num4 > 0 && Short0[array[num5 = (num4 - 1) / 2]] > num3)
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
                    var num6 = (num2 < 2) ? (++num2) : 0;
                    array[i++] = num6;
                }
                Int1 = Math.Max(num2 + 1, Int0);
                var num7 = i;
                var array2 = new int[4 * i - 2];
                var array3 = new int[2 * i - 1];
                var num8 = num7;
                for (var k = 0; k < i; k++)
                {
                    var num9 = array[k];
                    array2[2 * k] = num9;
                    array2[2 * k + 1] = -1;
                    array3[k] = Short0[num9] << 8;
                    array[k] = k;
                }
                do
                {
                    var num10 = array[0];
                    var num11 = array[--i];
                    var num12 = 0;
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
                    var num13 = array3[num11];
                    while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
                    {
                        array[l] = array[num12];
                    }
                    array[l] = num11;
                    var num14 = array[0];
                    num11 = num8++;
                    array2[2 * num11] = num10;
                    array2[2 * num11 + 1] = num14;
                    var num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
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
                } while (i > 1);
                if (array[0] != array2.Length / 2 - 1)
                {
                    throw new SharpZipBaseException("Heap invariant violated");
                }
                method_8(array2);
            }

            public int method_5()
            {
                var num = 0;
                for (var i = 0; i < Short0.Length; i++)
                {
                    num += Short0[i] * Byte0[i];
                }
                return num;
            }

            public void method_6(Class191 class1910)
            {
                var num = -1;
                var i = 0;
                while (i < Int1)
                {
                    var num2 = 1;
                    int num3 = Byte0[i];
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
                            var expr_3BCp0 = class1910.Short0;
                            var expr_3BCp1 = num3;
                            expr_3BCp0[expr_3BCp1] += 1;
                            num2 = 0;
                        }
                    }
                    num = num3;
                    i++;
                    while (i < Int1)
                    {
                        if (num != Byte0[i])
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
                        var expr_8CCp0 = class1910.Short0;
                        var expr_8CCp1 = num;
                        expr_8CCp0[expr_8CCp1] += (short) num2;
                    }
                    else if (num != 0)
                    {
                        var exprAdCp0 = class1910.Short0;
                        var exprAdCp1 = 16;
                        exprAdCp0[exprAdCp1] += 1;
                    }
                    else if (num2 <= 10)
                    {
                        var exprCfCp0 = class1910.Short0;
                        var exprCfCp1 = 17;
                        exprCfCp0[exprCfCp1] += 1;
                    }
                    else
                    {
                        var exprEcCp0 = class1910.Short0;
                        var exprEcCp1 = 18;
                        exprEcCp0[exprEcCp1] += 1;
                    }
                }
            }

            public void method_7(Class191 class1910)
            {
                var num = -1;
                var i = 0;
                while (i < Int1)
                {
                    var num2 = 1;
                    int num3 = Byte0[i];
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
                            class1910.method_1(num3);
                            num2 = 0;
                        }
                    }
                    num = num3;
                    i++;
                    while (i < Int1)
                    {
                        if (num != Byte0[i])
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
                            class1910.method_1(num);
                        }
                    }
                    else if (num != 0)
                    {
                        class1910.method_1(16);
                        _class1900.Class1890.method_5(num2 - 3, 2);
                    }
                    else if (num2 <= 10)
                    {
                        class1910.method_1(17);
                        _class1900.Class1890.method_5(num2 - 3, 3);
                    }
                    else
                    {
                        class1910.method_1(18);
                        _class1900.Class1890.method_5(num2 - 11, 7);
                    }
                }
            }

            private void method_8(int[] int4)
            {
                Byte0 = new byte[Short0.Length];
                var num = int4.Length / 2;
                var num2 = (num + 1) / 2;
                var num3 = 0;
                for (var i = 0; i < _int3; i++)
                {
                    _int2[i] = 0;
                }
                var array = new int[num];
                array[num - 1] = 0;
                for (var j = num - 1; j >= 0; j--)
                {
                    if (int4[2 * j + 1] != -1)
                    {
                        var num4 = array[j] + 1;
                        if (num4 > _int3)
                        {
                            num4 = _int3;
                            num3++;
                        }
                        array[int4[2 * j]] = (array[int4[2 * j + 1]] = num4);
                    }
                    else
                    {
                        var num5 = array[j];
                        _int2[num5 - 1]++;
                        Byte0[int4[2 * j]] = (byte) array[j];
                    }
                }
                if (num3 == 0)
                {
                    return;
                }
                var num6 = _int3 - 1;
                while (true)
                {
                    if (_int2[--num6] != 0)
                    {
                        do
                        {
                            _int2[num6]--;
                            _int2[++num6]++;
                            num3 -= 1 << _int3 - 1 - num6;
                        } while (num3 > 0 && num6 < _int3 - 1);
                        if (num3 <= 0)
                        {
                            break;
                        }
                    }
                }
                _int2[_int3 - 1] += num3;
                _int2[_int3 - 2] -= num3;
                var num7 = 2 * num2;
                for (var num8 = _int3; num8 != 0; num8--)
                {
                    var k = _int2[num8 - 1];
                    while (k > 0)
                    {
                        var num9 = 2 * int4[num7++];
                        if (int4[num9 + 1] == -1)
                        {
                            Byte0[int4[num9]] = (byte) num8;
                            k--;
                        }
                    }
                }
            }
        }

        private static readonly int[] Int0;

        private static readonly byte[] Byte0;

        private static readonly short[] Short0;

        private static readonly byte[] Byte1;

        private static readonly short[] Short1;

        private static readonly byte[] Byte2;

        public Class189 Class1890;

        private readonly Class191 _class1910;

        private readonly Class191 _class1911;

        private readonly Class191 _class1912;

        private readonly short[] _short2;

        private readonly byte[] _byte3;

        private int _int1;

        private int _int2;

        static Class190()
        {
            Int0 = new[]
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
            Byte0 = new byte[]
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
            Short0 = new short[286];
            Byte1 = new byte[286];
            var i = 0;
            while (i < 144)
            {
                Short0[i] = smethod_0(48 + i << 8);
                Byte1[i++] = 8;
            }
            while (i < 256)
            {
                Short0[i] = smethod_0(256 + i << 7);
                Byte1[i++] = 9;
            }
            while (i < 280)
            {
                Short0[i] = smethod_0(-256 + i << 9);
                Byte1[i++] = 7;
            }
            while (i < 286)
            {
                Short0[i] = smethod_0(-88 + i << 8);
                Byte1[i++] = 8;
            }
            Short1 = new short[30];
            Byte2 = new byte[30];
            for (i = 0; i < 30; i++)
            {
                Short1[i] = smethod_0(i << 11);
                Byte2[i] = 5;
            }
        }

        public Class190(Class189 class1891)
        {
            Class1890 = class1891;
            _class1910 = new Class191(this, 286, 257, 15);
            _class1911 = new Class191(this, 30, 1, 15);
            _class1912 = new Class191(this, 19, 4, 7);
            _short2 = new short[16384];
            _byte3 = new byte[16384];
        }

        public void method_0()
        {
            _int1 = 0;
            _int2 = 0;
            _class1910.method_0();
            _class1911.method_0();
            _class1912.method_0();
        }

        public void method_1(int int3)
        {
            _class1912.method_3();
            _class1910.method_3();
            _class1911.method_3();
            Class1890.method_5(_class1910.Int1 - 257, 5);
            Class1890.method_5(_class1911.Int1 - 1, 5);
            Class1890.method_5(int3 - 4, 4);
            for (var i = 0; i < int3; i++)
            {
                Class1890.method_5(_class1912.Byte0[Int0[i]], 3);
            }
            _class1910.method_7(_class1912);
            _class1911.method_7(_class1912);
        }

        public void method_2()
        {
            for (var i = 0; i < _int1; i++)
            {
                var num = _byte3[i] & 255;
                int num2 = _short2[i];
                if (num2-- != 0)
                {
                    var num3 = smethod_1(num);
                    _class1910.method_1(num3);
                    var num4 = (num3 - 261) / 4;
                    if (num4 > 0 && num4 <= 5)
                    {
                        Class1890.method_5(num & (1 << num4) - 1, num4);
                    }
                    var num5 = smethod_2(num2);
                    _class1911.method_1(num5);
                    num4 = num5 / 2 - 1;
                    if (num4 > 0)
                    {
                        Class1890.method_5(num2 & (1 << num4) - 1, num4);
                    }
                }
                else
                {
                    _class1910.method_1(num);
                }
            }
            _class1910.method_1(256);
        }

        public void method_3(byte[] byte4, int int3, int int4, bool bool0)
        {
            Class1890.method_5(bool0 ? 1 : 0, 3);
            Class1890.method_4();
            Class1890.method_1(int4);
            Class1890.method_1(~int4);
            Class1890.method_2(byte4, int3, int4);
            method_0();
        }

        public void method_4(byte[] byte4, int int3, int int4, bool bool0)
        {
            var expr15Cp0 = _class1910.Short0;
            var expr15Cp1 = 256;
            expr15Cp0[expr15Cp1] += 1;
            _class1910.method_4();
            _class1911.method_4();
            _class1910.method_6(_class1912);
            _class1911.method_6(_class1912);
            _class1912.method_4();
            var num = 4;
            for (var i = 18; i > num; i--)
            {
                if (_class1912.Byte0[Int0[i]] > 0)
                {
                    num = i + 1;
                }
            }
            var num2 = 14 + num * 3 + _class1912.method_5() + _class1910.method_5() + _class1911.method_5() + _int2;
            var num3 = _int2;
            for (var j = 0; j < 286; j++)
            {
                num3 += _class1910.Short0[j] * Byte1[j];
            }
            for (var k = 0; k < 30; k++)
            {
                num3 += _class1911.Short0[k] * Byte2[k];
            }
            if (num2 >= num3)
            {
                num2 = num3;
            }
            if (int3 >= 0 && int4 + 4 < num2 >> 3)
            {
                method_3(byte4, int3, int4, bool0);
                return;
            }
            if (num2 == num3)
            {
                Class1890.method_5(2 + (bool0 ? 1 : 0), 3);
                _class1910.method_2(Short0, Byte1);
                _class1911.method_2(Short1, Byte2);
                method_2();
                method_0();
                return;
            }
            Class1890.method_5(4 + (bool0 ? 1 : 0), 3);
            method_1(num);
            method_2();
            method_0();
        }

        public bool method_5()
        {
            return _int1 >= 16384;
        }

        public bool method_6(int int3)
        {
            _short2[_int1] = 0;
            _byte3[_int1++] = (byte) int3;
            var expr39Cp0 = _class1910.Short0;
            expr39Cp0[int3] += 1;
            return method_5();
        }

        public bool method_7(int int3, int int4)
        {
            _short2[_int1] = (short) int3;
            _byte3[_int1++] = (byte) (int4 - 3);
            var num = smethod_1(int4 - 3);
            var expr45Cp0 = _class1910.Short0;
            var expr45Cp1 = num;
            expr45Cp0[expr45Cp1] += 1;
            if (num >= 265 && num < 285)
            {
                _int2 += (num - 261) / 4;
            }
            var num2 = smethod_2(int3 - 1);
            var expr93Cp0 = _class1911.Short0;
            var expr93Cp1 = num2;
            expr93Cp0[expr93Cp1] += 1;
            if (num2 >= 4)
            {
                _int2 += num2 / 2 - 1;
            }
            return method_5();
        }

        public static short smethod_0(int int3)
        {
            return (short) (Byte0[int3 & 15] << 12 | Byte0[int3 >> 4 & 15] << 8 | Byte0[int3 >> 8 & 15] << 4 |
                            Byte0[int3 >> 12]);
        }

        private static int smethod_1(int int3)
        {
            if (int3 == 255)
            {
                return 285;
            }
            var num = 257;
            while (int3 >= 8)
            {
                num += 4;
                int3 >>= 1;
            }
            return num + int3;
        }

        private static int smethod_2(int int3)
        {
            var num = 0;
            while (int3 >= 4)
            {
                num += 2;
                int3 >>= 1;
            }
            return num + int3;
        }
    }
}