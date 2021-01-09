using System;
using System.IO;
using System.Security.Cryptography;

namespace GHNamespace1
{
    public class Class2
    {
        public class Class3
        {
            private static readonly int[] Int0 =
            {
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                13,
                15,
                17,
                19,
                23,
                27,
                31,
                35,
                43,
                51,
                59,
                67,
                83,
                99,
                115,
                131,
                163,
                195,
                227,
                258
            };

            private static readonly int[] Int1 =
            {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                1,
                1,
                1,
                1,
                2,
                2,
                2,
                2,
                3,
                3,
                3,
                3,
                4,
                4,
                4,
                4,
                5,
                5,
                5,
                5,
                0
            };

            private static readonly int[] Int2 =
            {
                1,
                2,
                3,
                4,
                5,
                7,
                9,
                13,
                17,
                25,
                33,
                49,
                65,
                97,
                129,
                193,
                257,
                385,
                513,
                769,
                1025,
                1537,
                2049,
                3073,
                4097,
                6145,
                8193,
                12289,
                16385,
                24577
            };

            private static readonly int[] Int3 =
            {
                0,
                0,
                0,
                0,
                1,
                1,
                2,
                2,
                3,
                3,
                4,
                4,
                5,
                5,
                6,
                6,
                7,
                7,
                8,
                8,
                9,
                9,
                10,
                10,
                11,
                11,
                12,
                12,
                13,
                13
            };

            private int _int4;

            private int _int5;

            private int _int6;

            private int _int7;

            private int _int8;

            private bool _bool0;

            private readonly Class4 _class40;

            private readonly Class5 _class50;

            private Class7 _class70;

            private Class6 _class60;

            private Class6 _class61;

            public Class3(byte[] byte0)
            {
                _class40 = new Class4();
                _class50 = new Class5();
                _int4 = 2;
                _class40.method_7(byte0, 0, byte0.Length);
            }

            private bool method_0()
            {
                int i = _class50.method_4();
                while (i >= 258)
                {
                    int num;
                    switch (_int4)
                    {
                        case 7:
                            while (((num = _class60.method_1(_class40)) & -256) == 0)
                            {
                                _class50.method_0(num);
                                if (--i < 258)
                                {
                                    return true;
                                }
                            }
                            if (num >= 257)
                            {
                                _int6 = Int0[num - 257];
                                _int5 = Int1[num - 257];
                                goto IL_9E;
                            }
                            if (num < 0)
                            {
                                return false;
                            }
                            _class61 = null;
                            _class60 = null;
                            _int4 = 2;
                            return true;
                        case 8:
                            goto IL_9E;
                        case 9:
                            goto IL_EE;
                        case 10:
                            break;
                        default:
                            continue;
                    }
                    IL_121:
                    if (_int5 > 0)
                    {
                        _int4 = 10;
                        int num2 = _class40.method_0(_int5);
                        if (num2 < 0)
                        {
                            return false;
                        }
                        _class40.method_1(_int5);
                        _int7 += num2;
                    }
                    _class50.method_2(_int6, _int7);
                    i -= _int6;
                    _int4 = 7;
                    continue;
                    IL_EE:
                    num = _class61.method_1(_class40);
                    if (num >= 0)
                    {
                        _int7 = Int2[num];
                        _int5 = Int3[num];
                        goto IL_121;
                    }
                    return false;
                    IL_9E:
                    if (_int5 > 0)
                    {
                        _int4 = 8;
                        int num3 = _class40.method_0(_int5);
                        if (num3 < 0)
                        {
                            return false;
                        }
                        _class40.method_1(_int5);
                        _int6 += num3;
                    }
                    _int4 = 9;
                    goto IL_EE;
                }
                return true;
            }

            private bool method_1()
            {
                switch (_int4)
                {
                    case 2:
                    {
                        if (_bool0)
                        {
                            _int4 = 12;
                            return false;
                        }
                            int num = _class40.method_0(3);
                        if (num < 0)
                        {
                            return false;
                        }
                        _class40.method_1(3);
                        if ((num & 1) != 0)
                        {
                            _bool0 = true;
                        }
                        switch (num >> 1)
                        {
                            case 0:
                                _class40.method_4();
                                _int4 = 3;
                                break;
                            case 1:
                                _class60 = Class6.Class60;
                                _class61 = Class6.Class61;
                                _int4 = 7;
                                break;
                            case 2:
                                _class70 = new Class7();
                                _int4 = 6;
                                break;
                        }
                        return true;
                    }
                    case 3:
                        if ((_int8 = _class40.method_0(16)) < 0)
                        {
                            return false;
                        }
                        _class40.method_1(16);
                        _int4 = 4;
                        break;
                    case 4:
                        break;
                    case 5:
                        goto IL_137;
                    case 6:
                        if (!_class70.method_0(_class40))
                        {
                            return false;
                        }
                        _class60 = _class70.method_1();
                        _class61 = _class70.method_2();
                        _int4 = 7;
                        goto IL_1BB;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        goto IL_1BB;
                    case 11:
                        return false;
                    case 12:
                        return false;
                    default:
                        return false;
                }
                int num2 = _class40.method_0(16);
                if (num2 < 0)
                {
                    return false;
                }
                _class40.method_1(16);
                _int4 = 5;
                IL_137:
                int num3 = _class50.method_3(_class40, _int8);
                _int8 -= num3;
                if (_int8 == 0)
                {
                    _int4 = 2;
                    return true;
                }
                return !_class40.method_5();
                IL_1BB:
                return method_0();
            }

            public int method_2(byte[] byte0, int int9, int int10)
            {
                int num = 0;
                while (true)
                {
                    if (_int4 != 11)
                    {
                        int num2 = _class50.method_6(byte0, int9, int10);
                        int9 += num2;
                        num += num2;
                        int10 -= num2;
                        if (int10 == 0)
                        {
                            return num;
                        }
                    }
                    if (!method_1())
                    {
                        if (_class50.method_5() <= 0)
                        {
                            break;
                        }
                        if (_int4 == 11)
                        {
                            break;
                        }
                    }
                }
                return num;
            }
        }

        public class Class4
        {
            private byte[] _byte0;

            private int _int0;

            private int _int1;

            private uint _uint0;

            private int _int2;

            public int method_0(int int3)
            {
                if (_int2 < int3)
                {
                    if (_int0 == _int1)
                    {
                        return -1;
                    }
                    _uint0 |= (uint) (_byte0[_int0++] & 255 | (_byte0[_int0++] & 255) << 8) << _int2;
                    _int2 += 16;
                }
                return (int) (_uint0 & (ulong) ((1 << int3) - 1));
            }

            public void method_1(int int3)
            {
                _uint0 >>= int3;
                _int2 -= int3;
            }

            public int method_2()
            {
                return _int2;
            }

            public int method_3()
            {
                return _int1 - _int0 + (_int2 >> 3);
            }

            public void method_4()
            {
                _uint0 >>= (_int2 & 7);
                _int2 &= -8;
            }

            public bool method_5()
            {
                return _int0 == _int1;
            }

            public int method_6(byte[] byte1, int int3, int int4)
            {
                int num = 0;
                while (_int2 > 0 && int4 > 0)
                {
                    byte1[int3++] = (byte) _uint0;
                    _uint0 >>= 8;
                    _int2 -= 8;
                    int4--;
                    num++;
                }
                if (int4 == 0)
                {
                    return num;
                }
                int num2 = _int1 - _int0;
                if (int4 > num2)
                {
                    int4 = num2;
                }
                Array.Copy(_byte0, _int0, byte1, int3, int4);
                _int0 += int4;
                if ((_int0 - _int1 & 1) != 0)
                {
                    _uint0 = (uint) (_byte0[_int0++] & 255);
                    _int2 = 8;
                }
                return num + int4;
            }

            public void method_7(byte[] byte1, int int3, int int4)
            {
                if (_int0 < _int1)
                {
                    throw new InvalidOperationException();
                }
                int num = int3 + int4;
                if (0 <= int3 && int3 <= num && num <= byte1.Length)
                {
                    if ((int4 & 1) != 0)
                    {
                        _uint0 |= (uint) (byte1[int3++] & 255) << _int2;
                        _int2 += 8;
                    }
                    _byte0 = byte1;
                    _int0 = int3;
                    _int1 = num;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        public class Class5
        {
            private static readonly int Int0 = 32768;

            private static readonly int Int1 = Int0 - 1;

            private readonly byte[] _byte0 = new byte[Int0];

            private int _int2;

            private int _int3;

            public void method_0(int int4)
            {
                if (_int3++ == Int0)
                {
                    throw new InvalidOperationException();
                }
                _byte0[_int2++] = (byte) int4;
                _int2 &= Int1;
            }

            private void method_1(int int4, int int5, int int6)
            {
                while (int5-- > 0)
                {
                    _byte0[_int2++] = _byte0[int4++];
                    _int2 &= Int1;
                    int4 &= Int1;
                }
            }

            public void method_2(int int4, int int5)
            {
                if ((_int3 += int4) > Int0)
                {
                    throw new InvalidOperationException();
                }
                int num = _int2 - int5 & Int1;
                int num2 = Int0 - int4;
                if (num > num2 || _int2 >= num2)
                {
                    method_1(num, int4, int5);
                    return;
                }
                if (int4 <= int5)
                {
                    Array.Copy(_byte0, num, _byte0, _int2, int4);
                    _int2 += int4;
                    return;
                }
                while (int4-- > 0)
                {
                    _byte0[_int2++] = _byte0[num++];
                }
            }

            public int method_3(Class4 class40, int int4)
            {
                int4 = Math.Min(Math.Min(int4, Int0 - _int3), class40.method_3());
                int num = Int0 - _int2;
                int num2;
                if (int4 > num)
                {
                    num2 = class40.method_6(_byte0, _int2, num);
                    if (num2 == num)
                    {
                        num2 += class40.method_6(_byte0, 0, int4 - num);
                    }
                }
                else
                {
                    num2 = class40.method_6(_byte0, _int2, int4);
                }
                _int2 = (_int2 + num2 & Int1);
                _int3 += num2;
                return num2;
            }

            public int method_4()
            {
                return Int0 - _int3;
            }

            public int method_5()
            {
                return _int3;
            }

            public int method_6(byte[] byte1, int int4, int int5)
            {
                int num = _int2;
                if (int5 > _int3)
                {
                    int5 = _int3;
                }
                else
                {
                    num = (_int2 - _int3 + int5 & Int1);
                }
                int num2 = int5;
                int num3 = int5 - num;
                if (num3 > 0)
                {
                    Array.Copy(_byte0, Int0 - num3, byte1, int4, num3);
                    int4 += num3;
                    int5 = num;
                }
                Array.Copy(_byte0, num - int5, byte1, int4, int5);
                _int3 -= num2;
                if (_int3 < 0)
                {
                    throw new InvalidOperationException();
                }
                return num2;
            }
        }

        public class Class6
        {
            private static readonly int Int0;

            private short[] _short0;

            public static Class6 Class60;

            public static Class6 Class61;

            static Class6()
            {
                Int0 = 15;
                byte[] array = new byte[288];
                int i = 0;
                while (i < 144)
                {
                    array[i++] = 8;
                }
                while (i < 256)
                {
                    array[i++] = 9;
                }
                while (i < 280)
                {
                    array[i++] = 7;
                }
                while (i < 288)
                {
                    array[i++] = 8;
                }
                Class60 = new Class6(array);
                array = new byte[32];
                i = 0;
                while (i < 32)
                {
                    array[i++] = 5;
                }
                Class61 = new Class6(array);
            }

            public Class6(byte[] byte0)
            {
                method_0(byte0);
            }

            private void method_0(byte[] byte0)
            {
                int[] array = new int[Int0 + 1];
                int[] array2 = new int[Int0 + 1];
                for (int i = 0; i < byte0.Length; i++)
                {
                    int num = byte0[i];
                    if (num > 0)
                    {
                        array[num]++;
                    }
                }
                int num2 = 0;
                int num3 = 512;
                for (int j = 1; j <= Int0; j++)
                {
                    array2[j] = num2;
                    num2 += array[j] << 16 - j;
                    if (j >= 10)
                    {
                        int num4 = array2[j] & 130944;
                        int num5 = num2 & 130944;
                        num3 += num5 - num4 >> 16 - j;
                    }
                }
                _short0 = new short[num3];
                int num6 = 512;
                for (int k = Int0; k >= 10; k--)
                {
                    int num7 = num2 & 130944;
                    num2 -= array[k] << 16 - k;
                    int num8 = num2 & 130944;
                    for (int l = num8; l < num7; l += 128)
                    {
                        _short0[Class8.smethod_0(l)] = (short) (-num6 << 4 | k);
                        num6 += 1 << k - 9;
                    }
                }
                for (int m = 0; m < byte0.Length; m++)
                {
                    int num9 = byte0[m];
                    if (num9 != 0)
                    {
                        num2 = array2[num9];
                        int num10 = Class8.smethod_0(num2);
                        if (num9 <= 9)
                        {
                            do
                            {
                                _short0[num10] = (short) (m << 4 | num9);
                                num10 += 1 << num9;
                            } while (num10 < 512);
                        }
                        else
                        {
                            int num11 = _short0[num10 & 511];
                            int num12 = 1 << (num11 & 15);
                            num11 = -(num11 >> 4);
                            do
                            {
                                _short0[num11 | num10 >> 9] = (short) (m << 4 | num9);
                                num10 += 1 << num9;
                            } while (num10 < num12);
                        }
                        array2[num9] = num2 + (1 << 16 - num9);
                    }
                }
            }

            public int method_1(Class4 class40)
            {
                int num;
                if ((num = class40.method_0(9)) >= 0)
                {
                    int num2;
                    if ((num2 = _short0[num]) >= 0)
                    {
                        class40.method_1(num2 & 15);
                        return num2 >> 4;
                    }
                    int num3 = -(num2 >> 4);
                    int int_ = num2 & 15;
                    if ((num = class40.method_0(int_)) >= 0)
                    {
                        num2 = _short0[num3 | num >> 9];
                        class40.method_1(num2 & 15);
                        return num2 >> 4;
                    }
                    int num4 = class40.method_2();
                    num = class40.method_0(num4);
                    num2 = _short0[num3 | num >> 9];
                    if ((num2 & 15) <= num4)
                    {
                        class40.method_1(num2 & 15);
                        return num2 >> 4;
                    }
                    return -1;
                }
                else
                {
                    int num5 = class40.method_2();
                    num = class40.method_0(num5);
                    int num2 = _short0[num];
                    if (num2 >= 0 && (num2 & 15) <= num5)
                    {
                        class40.method_1(num2 & 15);
                        return num2 >> 4;
                    }
                    return -1;
                }
            }
        }

        public class Class7
        {
            private static readonly int[] Int0 =
            {
                3,
                3,
                11
            };

            private static readonly int[] Int1 =
            {
                2,
                3,
                7
            };

            private byte[] _byte0;

            private byte[] _byte1;

            private Class6 _class60;

            private int _int2;

            private int _int3;

            private int _int4;

            private int _int5;

            private int _int6;

            private int _int7;

            private byte _byte2;

            private int _int8;

            private static readonly int[] Int9 =
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

            public bool method_0(Class4 class40)
            {
                while (true)
                {
                    switch (_int2)
                    {
                        case 0:
                            _int3 = class40.method_0(5);
                            if (_int3 >= 0)
                            {
                                _int3 += 257;
                                class40.method_1(5);
                                _int2 = 1;
                                goto IL_1DD;
                            }
                            return false;
                        case 1:
                            goto IL_1DD;
                        case 2:
                            goto IL_18F;
                        case 3:
                            goto IL_156;
                        case 4:
                            break;
                        case 5:
                            goto IL_2C;
                        default:
                            continue;
                    }
                    IL_E1:
                    int num;
                    while (((num = _class60.method_1(class40)) & -16) == 0)
                    {
                        _byte1[_int8++] = (_byte2 = (byte) num);
                        if (_int8 == _int6)
                        {
                            return true;
                        }
                    }
                    if (num >= 0)
                    {
                        if (num >= 17)
                        {
                            _byte2 = 0;
                        }
                        _int7 = num - 16;
                        _int2 = 5;
                        goto IL_2C;
                    }
                    return false;
                    IL_156:
                    while (_int8 < _int5)
                    {
                        int num2 = class40.method_0(3);
                        if (num2 < 0)
                        {
                            return false;
                        }
                        class40.method_1(3);
                        _byte0[Int9[_int8]] = (byte) num2;
                        _int8++;
                    }
                    _class60 = new Class6(_byte0);
                    _byte0 = null;
                    _int8 = 0;
                    _int2 = 4;
                    goto IL_E1;
                    IL_2C:
                    int num3 = Int1[_int7];
                    int num4 = class40.method_0(num3);
                    if (num4 < 0)
                    {
                        return false;
                    }
                    class40.method_1(num3);
                    num4 += Int0[_int7];
                    while (num4-- > 0)
                    {
                        _byte1[_int8++] = _byte2;
                    }
                    if (_int8 == _int6)
                    {
                        break;
                    }
                    _int2 = 4;
                    continue;
                    IL_18F:
                    _int5 = class40.method_0(4);
                    if (_int5 >= 0)
                    {
                        _int5 += 4;
                        class40.method_1(4);
                        _byte0 = new byte[19];
                        _int8 = 0;
                        _int2 = 3;
                        goto IL_156;
                    }
                    return false;
                    IL_1DD:
                    _int4 = class40.method_0(5);
                    if (_int4 >= 0)
                    {
                        _int4++;
                        class40.method_1(5);
                        _int6 = _int3 + _int4;
                        _byte1 = new byte[_int6];
                        _int2 = 2;
                        goto IL_18F;
                    }
                    return false;
                }
                return true;
            }

            public Class6 method_1()
            {
                byte[] destinationArray = new byte[_int3];
                Array.Copy(_byte1, 0, destinationArray, 0, _int3);
                return new Class6(destinationArray);
            }

            public Class6 method_2()
            {
                byte[] destinationArray = new byte[_int4];
                Array.Copy(_byte1, _int3, destinationArray, 0, _int4);
                return new Class6(destinationArray);
            }
        }

        public class Class8
        {
            private static readonly int Int1;

            private static readonly int Int2;

            private static readonly int[] _int8;

            private static readonly byte[] Byte0;

            private static readonly short[] Short0;

            private static readonly byte[] Byte1;

            private static readonly short[] Short1;

            private static readonly byte[] Byte2;

            public static short smethod_0(int int9)
            {
                return (short) (Byte0[int9 & 15] << 12 | Byte0[int9 >> 4 & 15] << 8 | Byte0[int9 >> 8 & 15] << 4 |
                                Byte0[int9 >> 12]);
            }

            static Class8()
            {
                Int1 = 286;
                Int2 = 30;
                _int8 = new[]
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
                Short0 = new short[Int1];
                Byte1 = new byte[Int1];
                int i = 0;
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
                while (i < Int1)
                {
                    Short0[i] = smethod_0(-88 + i << 8);
                    Byte1[i++] = 8;
                }
                Short1 = new short[Int2];
                Byte2 = new byte[Int2];
                for (i = 0; i < Int2; i++)
                {
                    Short1[i] = smethod_0(i << 11);
                    Byte2[i] = 5;
                }
            }
        }

        public class Stream0 : MemoryStream
        {
            public int method_0()
            {
                return ReadByte() | ReadByte() << 8;
            }

            public int method_1()
            {
                return method_0() | method_0() << 16;
            }

            public Stream0(byte[] byte0) : base(byte0, false)
            {
            }
        }

        public static byte[] smethod_0(byte[] byte0)
        {
            Stream0 stream = new Stream0(byte0);
            byte[] array = new byte[0];
            int num = stream.method_1();
            if (num == 67324752)
            {
                short num2 = (short) stream.method_0();
                int num3 = stream.method_0();
                int num4 = stream.method_0();
                if (num == 67324752 && num2 == 20 && num3 == 0)
                {
                    if (num4 == 8)
                    {
                        stream.method_1();
                        stream.method_1();
                        stream.method_1();
                        int num5 = stream.method_1();
                        int num6 = stream.method_0();
                        int num7 = stream.method_0();
                        if (num6 > 0)
                        {
                            byte[] buffer = new byte[num6];
                            stream.Read(buffer, 0, num6);
                        }
                        if (num7 > 0)
                        {
                            byte[] buffer2 = new byte[num7];
                            stream.Read(buffer2, 0, num7);
                        }
                        byte[] array2 = new byte[stream.Length - stream.Position];
                        stream.Read(array2, 0, array2.Length);
                        Class3 @class = new Class3(array2);
                        array = new byte[num5];
                        @class.method_2(array, 0, array.Length);
                        goto IL_1FF;
                    }
                }
                throw new FormatException("Wrong Header Signature");
            }
            int num8 = num >> 24;
            num -= num8 << 24;
            if (num != 8223355)
            {
                throw new FormatException("Unknown Header");
            }
            if (num8 == 1)
            {
                int num9 = stream.method_1();
                array = new byte[num9];
                int num11;
                for (int i = 0; i < num9; i += num11)
                {
                    int num10 = stream.method_1();
                    num11 = stream.method_1();
                    byte[] array3 = new byte[num10];
                    stream.Read(array3, 0, array3.Length);
                    Class3 class2 = new Class3(array3);
                    class2.method_2(array, i, num11);
                }
            }
            if (num8 == 2)
            {
                DESCryptoServiceProvider dEsCryptoServiceProvider = new DESCryptoServiceProvider
                {
                    Key = new byte[]
                {
                    162,
                    181,
                    141,
                    204,
                    197,
                    202,
                    205,
                    58
                },
                    IV = new byte[]
                {
                    83,
                    253,
                    177,
                    222,
                    83,
                    112,
                    167,
                    112
                }
                };
                ICryptoTransform cryptoTransform = dEsCryptoServiceProvider.CreateDecryptor();
                byte[] byte_ = cryptoTransform.TransformFinalBlock(byte0, 4, byte0.Length - 4);
                dEsCryptoServiceProvider.Clear();
                array = smethod_0(byte_);
            }
            IL_1FF:
            stream.Close();
            return array;
        }
    }
}