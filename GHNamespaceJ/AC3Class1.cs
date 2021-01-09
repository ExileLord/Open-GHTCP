using System.IO;
using AVTools.MpegUtils;
using SharpAudio.ASC.Ac3.Decoding;

namespace GHNamespaceJ
{
    public class Ac3Class1
    {
        public int Int0;

        private static readonly double Double2;

        private static readonly double Double3;

        private static readonly double Double4;

        public int Int1;

        public int Int2;

        public int Int3;

        public int Int4;

        private int _int5;

        private int _int6;

        private int _int7;

        private double _double5;

        private double _double6;

        private bool _bool0;

        private int _int8;

        private double _double7 = 200.0;

        public bool Bool1;

        private double _double8;

        private int _int9;

        private bool _bool2;

        private int _int10;

        private int _int11;

        private int _int12;

        private int _int13;

        private int _int14;

        private readonly double[][] _double9 = new double[5][];

        private int _int15;

        private readonly int[] _int16 = new int[5];

        private readonly byte[] _byte0 = new byte[256];

        private readonly byte[][] _byte1 = new byte[5][];

        private readonly byte[] _byte2 = new byte[256];

        private readonly byte[] _byte3 = new byte[256];

        private readonly byte[][] _byte4 = new byte[5][];

        private readonly byte[] _byte5 = new byte[256];

        private int _int17;

        private int _int18;

        private int _int19;

        private readonly int[] _int20 = new int[50];

        private readonly int[] _int21 = new int[5];

        private readonly int[] _int22 = new int[5];

        private readonly int[][] _int23 = new int[5][];

        private int _int24;

        private int _int25;

        private readonly int[] _int26 = new int[50];

        private int _int27;

        private int _int28;

        private int _int29;

        private int _int30 = 1;

        private readonly Class113 _class1130 = new Class113();

        private readonly double[] _double10 = new double[3584];

        private bool _bool3;

        public Class115 Class1150 = new Class115();

        public static readonly int[] Int31;

        public static readonly int[] Int32;

        public static readonly int[] Int33;

        public static readonly double[] Double11;

        public static readonly double[] Double12;

        public byte[] Byte6;

        public byte[] Byte7;

        public byte[] Byte8;

        public int[] Int34;

        public double[] Double13;

        public double[] Double14;

        public double[] Double15;

        public double[] Double16;

        public double[] Double17;

        public double[] Double18;

        public double[] Double19;

        public double[] Double20;

        public double[] Double21;

        public double[] Double22;

        public double[] Double23;

        public Class110 Class1100 = new Class110();

        public static readonly int[] Int35;

        public static readonly int[] Int36;

        public static readonly int[] Int37;

        private static readonly int[] Int38;

        private static readonly int[] Int39;

        private static readonly int[] Int40;

        private static readonly int[][] Int41;

        private static readonly int[] Int42;

        private static readonly byte[] Byte9;

        private static readonly int[] Int43;

        private static readonly int[] Int44;

        private bool _bool4 = true;

        public Ac3Class1()
        {
            method_0();
        }

        private void method_0()
        {
            for (int i = 0; i < 5; i++)
            {
                _double9[i] = new double[18];
            }
            for (int j = 0; j < 5; j++)
            {
                _byte1[j] = new byte[256];
            }
            for (int k = 0; k < 5; k++)
            {
                _byte4[k] = new byte[256];
            }
            for (int l = 0; l < 5; l++)
            {
                _int23[l] = new int[50];
            }
            Byte6 = Class114.smethod_0();
            Byte7 = Class114.smethod_1();
            Byte8 = Class114.smethod_2();
            Int34 = Class114.smethod_3();
            Double13 = Class114.smethod_4();
            Double14 = Class114.smethod_5();
            Double15 = Class114.smethod_6();
            Double16 = Class114.smethod_7();
            Double17 = Class114.smethod_8();
            Double18 = Class114.smethod_9();
            Double19 = Class114.smethod_10();
            Double20 = Class114.smethod_11();
            Double21 = Class114.smethod_12();
            Double22 = Class114.smethod_13();
            Double23 = Class114.smethod_14();
        }

        private bool method_1()
        {
            while (Class1150.method_3(16) != 2935)
            {
                Class1150.method_2(8);
                if (Class1150.method_1() <= 56)
                {
                    return false;
                }
            }
            Class1150.method_2(16);
            Class1150.method_2(16);
            int num = Class1150.method_2(8);
            int num2 = Class1150.method_2(8);
            int num3 = Class1150.method_2(8);
            int num4 = Int31[num2 >> 3];
            int num5 = num3 >> 5;
            Int1 = ((((num3 & 248) == 80) ? 10 : num5) | (((num3 & Int33[num5]) != 0) ? 16 : 0));
            int num6 = num & 63;
            if (num6 >= 38)
            {
                throw new Ac3Exception("Unknown rate");
            }
            Int3 = Int32[num6 >> 1] * 1000 >> num4;
            int num7 = num & 192;
            if (num7 != 0)
            {
                if (num7 != 64)
                {
                    if (num7 != 128)
                    {
                        throw new Ac3Exception("Unrecognised sample rate multiplier");
                    }
                    Int2 = 32000 >> num4;
                    Int4 = 6 * Int32[num6 >> 1];
                }
                else
                {
                    Int2 = 44100 >> num4;
                    Int4 = 2 * (320 * Int32[num6 >> 1] / 147 + (num6 & 1));
                }
            }
            else
            {
                Int2 = 48000 >> num4;
                Int4 = 4 * Int32[num6 >> 1];
            }
            Class1150.vmethod_3(Class1150.vmethod_0() - 56);
            return true;
        }

        private void method_2()
        {
            Class1150.method_2(32);
            _int5 = Class1150.method_2(3);
            Class1150.method_2(5);
            int num = Class1150.method_2(5);
            if (num >= Int31.Length)
            {
                throw new FfMpegException("Illegal half rate");
            }
            _int6 = Int31[num];
            Class1150.method_2(3);
            _int7 = Class1150.method_2(3);
            if (_int7 == 2)
            {
                Class1150.method_2(2);
            }
            _double5 = 0.0;
            if ((_int7 & 1) != 0 && _int7 != 1)
            {
                _double5 = Double11[Class1150.method_2(2)];
            }
            _double6 = 0.0;
            if ((_int7 & 4) != 0)
            {
                _double6 = Double12[Class1150.method_2(2)];
            }
            _bool0 = Class1150.vmethod_1();
            _double7 = 2.0;
            method_10(_int7);
            _double7 *= 2.0;
            _double8 = _double7;
            Bool1 = false;
            bool flag = _int7 == 0;
            do
            {
                Class1150.method_2(5);
                if (Class1150.vmethod_1())
                {
                    Class1150.method_2(8);
                }
                if (Class1150.vmethod_1())
                {
                    _int8 = Class1150.method_2(8);
                }
                if (Class1150.vmethod_1())
                {
                    Class1150.method_2(7);
                }
            } while (!(flag = !flag));
            Class1150.method_2(2);
            if (Class1150.vmethod_1())
            {
                Class1150.method_2(14);
            }
            if (Class1150.vmethod_1())
            {
                Class1150.method_2(14);
            }
            if (Class1150.vmethod_1())
            {
                int num2 = Class1150.method_2(6);
                Class1150.vmethod_3(Class1150.vmethod_0() + num2 * 8);
            }
        }

        private void method_3()
        {
            int num = Int35[_int7];
            bool[] array = new bool[5];
            for (int i = 0; i < num; i++)
            {
                array[i] = Class1150.vmethod_1();
            }
            bool[] array2 = new bool[5];
            for (int j = 0; j < num; j++)
            {
                array2[j] = Class1150.vmethod_1();
            }
            bool flag = _int7 == 0;
            do
            {
                if (Class1150.vmethod_1())
                {
                    int num2 = method_8(8);
                    if (Bool1)
                    {
                        _double8 = (((num2 & 31) | 32) << 13) * Double13[2 - (num2 >> 5)] * _double7;
                    }
                }
            } while (!(flag = !flag));
            if (Class1150.vmethod_1())
            {
                _int9 = 0;
                if (Class1150.vmethod_1())
                {
                    for (int k = 0; k < num; k++)
                    {
                        _int9 |= Class1150.method_2(1) << k;
                    }
                    switch (_int7)
                    {
                        case 0:
                        case 1:
                            throw new Ac3Exception("Invalid mode");
                        case 2:
                            _bool2 = Class1150.vmethod_1();
                            break;
                    }
                    int num3 = Class1150.method_2(4);
                    int num4 = Class1150.method_2(4);
                    if (num4 + 3 - num3 < 0)
                    {
                        throw new Ac3Exception("Invalid values");
                    }
                    _int10 = num4 + 3 - num3;
                    _int11 = Int36[num3];
                    _int12 = num3 * 12 + 37;
                    _int13 = num4 * 12 + 73;
                    _int14 = 0;
                    int num5 = _int10;
                    for (int l = 0; l < num5 - 1; l++)
                    {
                        if (Class1150.vmethod_1())
                        {
                            _int14 |= 1 << l;
                            _int10--;
                        }
                    }
                }
            }
            if (_int9 != 0)
            {
                bool flag2 = false;
                for (int m = 0; m < num; m++)
                {
                    if ((_int9 >> m & 1) != 0 && Class1150.vmethod_1())
                    {
                        flag2 = true;
                        int num6 = 3 * Class1150.method_2(2);
                        for (int n = 0; n < _int10; n++)
                        {
                            int num7 = Class1150.method_2(4);
                            int num8 = Class1150.method_2(4);
                            if (num7 == 15)
                            {
                                num8 <<= 14;
                            }
                            else
                            {
                                num8 = (num8 | 16) << 13;
                            }
                            _double9[m][n] = num8 * Double13[num7 + num6];
                        }
                    }
                }
                if (_int7 == 2 && _bool2 && flag2)
                {
                    for (int num9 = 0; num9 < _int10; num9++)
                    {
                        if (Class1150.vmethod_1())
                        {
                            _double9[1][num9] = -_double9[1][num9];
                        }
                    }
                }
            }
            if (_int7 == 2 && Class1150.vmethod_1())
            {
                _int15 = 0;
                int num10 = (_int9 != 0) ? _int12 : 253;
                int num11 = 0;
                do
                {
                    _int15 |= Class1150.method_2(1) << num11;
                } while (Int37[num11++] < num10);
            }
            int num12 = 0;
            int num13 = 0;
            if (_int9 != 0)
            {
                num12 = Class1150.method_2(2);
            }
            int[] array3 = new int[5];
            for (int num14 = 0; num14 < num; num14++)
            {
                array3[num14] = Class1150.method_2(2);
            }
            if (_bool0)
            {
                num13 = Class1150.method_2(1);
            }
            for (int num15 = 0; num15 < num; num15++)
            {
                if (array3[num15] != 0)
                {
                    if ((_int9 >> num15 & 1) != 0)
                    {
                        _int16[num15] = _int12;
                    }
                    else
                    {
                        int num16 = Class1150.method_2(6);
                        if (num16 > 60)
                        {
                            throw new Ac3Exception("chbwcod too large");
                        }
                        _int16[num15] = num16 * 3 + 73;
                    }
                }
            }
            int num17 = 0;
            if (num12 != 0)
            {
                num17 = 64;
                int int_ = (_int13 - _int12) / (3 << num12 - 1);
                byte byte_ = (byte) (Class1150.method_2(4) << 1);
                method_13(num12, int_, byte_, _byte0, _int12);
            }
            for (int num18 = 0; num18 < num; num18++)
            {
                if (array3[num18] != 0)
                {
                    num17 |= 1 << num18;
                    int num19 = 3 << array3[num18] - 1;
                    int int2 = (_int16[num18] + num19 - 4) / num19;
                    _byte1[num18][0] = (byte) Class1150.method_2(4);
                    method_13(array3[num18], int2, _byte1[num18][0], _byte1[num18], 1);
                    Class1150.method_2(2);
                }
            }
            if (num13 != 0)
            {
                num17 |= 32;
                _byte2[0] = (byte) Class1150.method_2(4);
                method_13(num13, 2, _byte2[0], _byte2, 1);
            }
            if (Class1150.vmethod_1())
            {
                num17 = 127;
                _int17 = Class1150.method_2(11);
            }
            if (Class1150.vmethod_1())
            {
                num17 = 127;
                _int27 = Class1150.method_2(6);
                if (_int9 != 0)
                {
                    _int18 = Class1150.method_2(7);
                }
                for (int num20 = 0; num20 < num; num20++)
                {
                    _int21[num20] = Class1150.method_2(7);
                }
                if (_bool0)
                {
                    _int24 = Class1150.method_2(7);
                }
            }
            if (_int9 != 0 && Class1150.vmethod_1())
            {
                num17 |= 64;
                _int28 = 9 - Class1150.method_2(3);
                _int29 = 9 - Class1150.method_2(3);
            }
            if (Class1150.vmethod_1())
            {
                num17 = 127;
                if (_int9 != 0)
                {
                    _int19 = Class1150.method_2(2);
                }
                for (int num21 = 0; num21 < num; num21++)
                {
                    _int22[num21] = Class1150.method_2(2);
                }
                if (_int9 != 0 && _int19 == 1)
                {
                    method_12(_int20);
                }
                for (int num22 = 0; num22 < num; num22++)
                {
                    if (_int22[num22] == 1)
                    {
                        method_12(_int23[num22]);
                    }
                }
            }
            if (num17 != 0)
            {
                if (method_5(num))
                {
                    for (int num23 = 0; num23 < _byte3.Length; num23++)
                    {
                        _byte3[num23] = 0;
                    }
                    for (int num24 = 0; num24 < num; num24++)
                    {
                        for (int num25 = 0; num25 < _byte4[num24].Length; num25++)
                        {
                            _byte4[num24][num25] = 0;
                        }
                    }
                    for (int num26 = 0; num26 < _byte5.Length; num26++)
                    {
                        _byte5[num26] = 0;
                    }
                }
                else
                {
                    if (_int9 != 0 && (num17 & 64) != 0)
                    {
                        method_4(_int18, _int19, _int20, _int11, _int12, _int13, _int28 << 8, _int29 << 8, _byte0,
                            _byte3);
                    }
                    for (int num27 = 0; num27 < num; num27++)
                    {
                        if ((num17 & 1 << num27) != 0)
                        {
                            method_4(_int21[num27], _int22[num27], _int23[num27], 0, 0, _int16[num27], 0, 0,
                                _byte1[num27], _byte4[num27]);
                        }
                    }
                    if (_bool0 && (num17 & 32) != 0)
                    {
                        _int25 = 2;
                        method_4(_int24, _int25, _int26, 0, 0, 7, 0, 0, _byte2, _byte5);
                    }
                }
            }
            if (Class1150.vmethod_1())
            {
                int num28 = Class1150.method_2(9);
                Class1150.vmethod_3(Class1150.vmethod_0() + num28 * 8);
            }
            int num29 = 256;
            double[] array4 = new double[5];
            method_11(array4, _int7, _double8, _double5, _double6);
            bool flag3 = false;
            _class1130.Int0 = -1;
            _class1130.Int1 = -1;
            _class1130.Int2 = -1;
            for (int num30 = 0; num30 < num; num30++)
            {
                method_7(_double10, num29 + 256 * num30, _byte1[num30], _byte4[num30], _class1130, array4[num30],
                    array2[num30], _int16[num30]);
                int num31;
                if ((_int9 >> num30 & 1) != 0)
                {
                    if (!flag3)
                    {
                        flag3 = true;
                        method_9(num, array4, _double10, num29, _class1130, array2);
                    }
                    num31 = _int13;
                }
                else
                {
                    num31 = _int16[num30];
                }
                do
                {
                    _double10[num29 + 256 * num30 + num31] = 0.0;
                } while (++num31 < 256);
            }
            if (_int7 == 2)
            {
                int num32 = 0;
                int num31 = 13;
                int num33 = (_int16[0] < _int16[1]) ? _int16[0] : _int16[1];
                int num34 = _int15;
                do
                {
                    if ((num34 & 1) == 0)
                    {
                        num34 >>= 1;
                        num31 = Int37[num32++];
                    }
                    else
                    {
                        num34 >>= 1;
                        int num35 = Int37[num32++];
                        if (num35 > num33)
                        {
                            num35 = num33;
                        }
                        do
                        {
                            double num36 = _double10[num29 + num31];
                            double num37 = _double10[num29 + num31 + 256];
                            _double10[num29 + num31] = num36 + num37;
                            _double10[num29 + num31 + 256] = num36 - num37;
                        } while (++num31 < num35);
                    }
                } while (num31 < num33);
            }
            if (_bool0)
            {
                method_7(_double10, num29 - 256, _byte2, _byte5, _class1130, 0.0, false, 7);
                for (int num38 = 7; num38 < 256; num38++)
                {
                    _double10[num29 - 256 + num38] = 0.0;
                }
                Class1100.vmethod_0(_double10, num29 - 256, num29 - 256 + 1536, Int0);
            }
            int num39 = 0;
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
                if (_bool3)
                {
                    _bool3 = false;
                }
                for (num39 = 0; num39 < num; num39++)
                {
                    if (array4[num39] != 0.0)
                    {
                        if (array[num39])
                        {
                            Class1100.vmethod_1(_double10, num29 + 256 * num39, num29 + 1536 + 256 * num39, Int0);
                        }
                        else
                        {
                            Class1100.vmethod_0(_double10, num29 + 256 * num39, num29 + 1536 + 256 * num39, Int0);
                        }
                    }
                    else
                    {
                        for (int num31 = 0; num31 < 256; num31++)
                        {
                            _double10[num29 + 256 * num39 + num31] = 0.0;
                        }
                    }
                }
                return;
            }
            int num40 = 0;
            if (!_bool3)
            {
                _bool3 = true;
            }
            if (array[0])
            {
                for (num39 = 0; num39 < num; num39++)
                {
                    Class1100.vmethod_1(_double10, num29 + 256 * num39, num29 + 1536 + 256 * num39, num40);
                }
                return;
            }
            for (num39 = 0; num39 < num; num39++)
            {
                Class1100.vmethod_0(_double10, num29 + 256 * num39, num29 + 1536 + 256 * num39, num40);
            }
        }

        private void method_4(int int45, int int46, int[] int47, int int48, int int49, int int50, int int51, int int52,
            byte[] byte10, byte[] byte11)
        {
            int num = 63 + 20 * (_int17 >> 7 & 3) >> _int6;
            int num2 = 128 + 128 * (int45 & 7);
            int num3 = 15 + 2 * (_int17 >> 9) >> _int6;
            int num4 = Int38[_int17 >> 5 & 3];
            int num5 = Int39[_int17 >> 3 & 3];
            int[] array = Int41[_int5];
            if (int46 == 2)
            {
                int47 = Int42;
            }
            int num6 = Int40[_int17 & 7];
            int num7 = 960 - 64 * _int27 - 4 * (int45 >> 3) + num6;
            num6 >>= 5;
            int i = int48;
            int j = int49;
            if (int49 == 0)
            {
                int k = 0;
                j = int50 - 1;
                int num8;
                while (true)
                {
                    if (i < j)
                    {
                        if (byte10[i + 1] == byte10[i] - 2)
                        {
                            k = 384;
                        }
                        else if (k != 0 && byte10[i + 1] > byte10[i])
                        {
                            k -= 64;
                        }
                    }
                    num8 = 128 * byte10[i];
                    int num9 = num8 + num2 + k;
                    if (num8 > num5)
                    {
                        num9 -= num8 - num5 >> 2;
                    }
                    if (num9 > array[i >> _int6])
                    {
                        num9 = array[i >> _int6];
                    }
                    num9 -= num7 + 128 * int47[i];
                    num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
                    num9 -= num6;
                    byte11[i] = Byte9[156 + num9 + 4 * byte10[i]];
                    i++;
                    if (i >= 3)
                    {
                        if (i >= 7)
                        {
                            break;
                        }
                        if (byte10[i] <= byte10[i - 1])
                        {
                            break;
                        }
                    }
                }
                int51 = num8 + num2;
                int52 = num8 + num4;
                while (i < 7)
                {
                    if (i < j)
                    {
                        if (byte10[i + 1] == byte10[i] - 2)
                        {
                            k = 384;
                        }
                        else if (k != 0 && byte10[i + 1] > byte10[i])
                        {
                            k -= 64;
                        }
                    }
                    num8 = 128 * byte10[i];
                    int51 += num;
                    if (int51 > num8 + num2)
                    {
                        int51 = num8 + num2;
                    }
                    int52 += num3;
                    if (int52 > num8 + num4)
                    {
                        int52 = num8 + num4;
                    }
                    int num9 = (int51 + k < int52) ? (int51 + k) : int52;
                    if (num8 > num5)
                    {
                        num9 -= num8 - num5 >> 2;
                    }
                    if (num9 > array[i >> _int6])
                    {
                        num9 = array[i >> _int6];
                    }
                    num9 -= num7 + 128 * int47[i];
                    num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
                    num9 -= num6;
                    byte11[i] = Byte9[156 + num9 + 4 * byte10[i]];
                    i++;
                }
                if (int50 == 7)
                {
                    return;
                }
                do
                {
                    if (byte10[i + 1] == byte10[i] - 2)
                    {
                        k = 320;
                    }
                    else if (k != 0 && byte10[i + 1] > byte10[i])
                    {
                        k -= 64;
                    }
                    num8 = 128 * byte10[i];
                    int51 += num;
                    if (int51 > num8 + num2)
                    {
                        int51 = num8 + num2;
                    }
                    int52 += num3;
                    if (int52 > num8 + num4)
                    {
                        int52 = num8 + num4;
                    }
                    int num9 = (int51 + k < int52) ? (int51 + k) : int52;
                    if (num8 > num5)
                    {
                        num9 -= num8 - num5 >> 2;
                    }
                    if (num9 > array[i >> _int6])
                    {
                        num9 = array[i >> _int6];
                    }
                    num9 -= num7 + 128 * int47[i];
                    num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
                    num9 -= num6;
                    byte11[i] = Byte9[156 + num9 + 4 * byte10[i]];
                    i++;
                } while (i < 20);
                while (k > 128)
                {
                    k -= 128;
                    num8 = 128 * byte10[i];
                    int51 += num;
                    if (int51 > num8 + num2)
                    {
                        int51 = num8 + num2;
                    }
                    int52 += num3;
                    if (int52 > num8 + num4)
                    {
                        int52 = num8 + num4;
                    }
                    int num9 = (int51 + k < int52) ? (int51 + k) : int52;
                    if (num8 > num5)
                    {
                        num9 -= num8 - num5 >> 2;
                    }
                    if (num9 > array[i >> _int6])
                    {
                        num9 = array[i >> _int6];
                    }
                    num9 -= num7 + 128 * int47[i];
                    num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
                    num9 -= num6;
                    byte11[i] = Byte9[156 + num9 + 4 * byte10[i]];
                    i++;
                }
                j = i;
            }
            do
            {
                int num10 = j;
                int num11 = (Int43[i - 20] < int50) ? Int43[i - 20] : int50;
                int num8 = 128 * byte10[j++];
                while (j < num11)
                {
                    int num12 = 128 * byte10[j++];
                    int num13 = num12 - num8;
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
                            num8 = num12 + Int44[-num13 >> 1];
                            break;
                        case 0:
                            num8 += Int44[num13 >> 1];
                            break;
                    }
                }
                int51 += num;
                if (int51 > num8 + num2)
                {
                    int51 = num8 + num2;
                }
                int52 += num3;
                if (int52 > num8 + num4)
                {
                    int52 = num8 + num4;
                }
                int num9 = (int51 < int52) ? int51 : int52;
                if (num8 > num5)
                {
                    num9 -= num8 - num5 >> 2;
                }
                if (num9 > array[i >> _int6])
                {
                    num9 = array[i >> _int6];
                }
                num9 -= num7 + 128 * int47[i];
                num9 = ((num9 > 0) ? 0 : (-num9 >> 5));
                num9 -= num6;
                i++;
                j = num10;
                do
                {
                    byte11[j] = Byte9[156 + num9 + 4 * byte10[j]];
                } while (++j < num11);
            } while (j < int50);
        }

        private bool method_5(int int45)
        {
            if (_int27 == 0 && (_int9 == 0 || _int18 >> 3 == 0) && (!_bool0 || _int24 >> 3 == 0))
            {
                for (int i = 0; i < int45; i++)
                {
                    if (_int21[i] >> 3 != 0)
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
            int num = Int34[_int30 >> 8] ^ _int30 << 8;
            if ((num & 32768) != 0)
            {
                num |= -65536;
            }
            else
            {
                num &= 65535;
            }
            _int30 = (num & 65535);
            return num;
        }

        private void method_7(double[] double24, int int45, byte[] byte10, byte[] byte11, Class113 class1131,
            double double25, bool bool5, int int46)
        {
            double[] array = new double[25];
            for (int i = 0; i <= 24; i++)
            {
                array[i] = Double13[i] * double25;
            }
            int j = 0;
            while (j < int46)
            {
                int num = byte11[j];
                switch (num)
                {
                    case -3:
                        if (class1131.Int2 == 0)
                        {
                            double24[int45 + j] = class1131.vmethod_2()[0] * array[byte10[j]];
                            class1131.Int2 = -1;
                        }
                        else
                        {
                            int num2 = Class1150.method_2(7);
                            class1131.Int2 = 0;
                            class1131.vmethod_2()[0] = Double22[num2];
                            double24[int45 + j] = Double21[num2] * array[byte10[j]];
                        }
                        break;
                    case -2:
                        if (class1131.Int1 >= 0)
                        {
                            double24[int45 + j] = class1131.vmethod_1()[class1131.Int1] * array[byte10[j]];
                            class1131.Int1--;
                        }
                        else
                        {
                            int num3 = Class1150.method_2(7);
                            class1131.Int1 = 1;
                            class1131.vmethod_1()[0] = Double19[num3];
                            class1131.vmethod_1()[1] = Double18[num3];
                            double24[int45 + j] = Double17[num3] * array[byte10[j]];
                        }
                        break;
                    case -1:
                        if (class1131.Int0 >= 0)
                        {
                            double24[int45 + j] = class1131.vmethod_0()[class1131.Int0] * array[byte10[j]];
                            class1131.Int0--;
                        }
                        else
                        {
                            int num4 = Class1150.method_2(5);
                            class1131.Int0 = 1;
                            class1131.vmethod_0()[0] = Double16[num4];
                            class1131.vmethod_0()[1] = Double15[num4];
                            double24[int45 + j] = Double14[num4] * array[byte10[j]];
                        }
                        break;
                    case 0:
                        if (bool5)
                        {
                            int num5 = method_6();
                            double24[int45 + j] = num5 * array[byte10[j]] * Double2;
                        }
                        else
                        {
                            double24[int45 + j] = 0.0;
                        }
                        break;
                    case 1:
                    case 2:
                        goto IL_216;
                    case 3:
                        double24[int45 + j] = Double20[Class1150.method_2(3)] * array[byte10[j]];
                        break;
                    case 4:
                        double24[int45 + j] = Double23[Class1150.method_2(4)] * array[byte10[j]];
                        break;
                    default:
                        goto IL_216;
                }
                IL_275:
                j++;
                continue;
                IL_216:
                int num6 = method_8(num);
                double24[int45 + j] = (num6 << 16 - num) * array[byte10[j]];
                goto IL_275;
            }
        }

        private int method_8(int int45)
        {
            int num = Class1150.method_2(int45);
            if ((num & 1 << int45 - 1) != 0)
            {
                num |= -1 << int45;
            }
            return num;
        }

        private void method_9(int int45, double[] double24, double[] double25, int int46, Class113 class1131,
            bool[] bool5)
        {
            double[] array = new double[5];
            byte[] array2 = _byte0;
            byte[] array3 = _byte3;
            int num = 0;
            int num2 = _int14;
            int i = _int12;
            while (i < _int13)
            {
                int num3 = i + 12;
                while ((num2 & 1) != 0)
                {
                    num2 >>= 1;
                    num3 += 12;
                }
                num2 >>= 1;
                for (int j = 0; j < int45; j++)
                {
                    array[j] = _double9[j][num] * double24[j];
                }
                num++;
                while (i < num3)
                {
                    int num4 = array3[i];
                    double num5;
                    switch (num4)
                    {
                        case -3:
                            if (class1131.Int2 == 0)
                            {
                                num5 = class1131.vmethod_2()[0];
                                class1131.Int2 = -1;
                            }
                            else
                            {
                                int num6 = Class1150.method_2(7);
                                class1131.Int2 = 0;
                                class1131.vmethod_2()[0] = Double22[num6];
                                num5 = Double21[num6];
                            }
                            break;
                        case -2:
                            if (class1131.Int1 >= 0)
                            {
                                num5 = class1131.vmethod_1()[class1131.Int1];
                                class1131.Int1--;
                            }
                            else
                            {
                                int num7 = Class1150.method_2(7);
                                class1131.Int1 = 1;
                                class1131.vmethod_1()[0] = Double19[num7];
                                class1131.vmethod_1()[1] = Double18[num7];
                                num5 = Double17[num7];
                            }
                            break;
                        case -1:
                            if (class1131.Int0 >= 0)
                            {
                                num5 = class1131.vmethod_0()[class1131.Int0];
                                class1131.Int0--;
                            }
                            else
                            {
                                int num8 = Class1150.method_2(5);
                                class1131.Int0 = 1;
                                class1131.vmethod_0()[0] = Double16[num8];
                                class1131.vmethod_0()[1] = Double15[num8];
                                num5 = Double14[num8];
                            }
                            break;
                        case 0:
                            num5 = Double2 * Double13[array2[i]];
                            for (int k = 0; k < int45; k++)
                            {
                                if ((_int9 >> k & 1) != 0)
                                {
                                    if (bool5[k])
                                    {
                                        double25[int46 + i + k * 256] = num5 * array[k] * method_6();
                                    }
                                    else
                                    {
                                        double25[int46 + i + k * 256] = 0.0;
                                    }
                                }
                            }
                            i++;
                            break;
                        case 1:
                        case 2:
                            goto IL_27D;
                        case 3:
                            num5 = Double20[Class1150.method_2(3)];
                            break;
                        case 4:
                            num5 = Double23[Class1150.method_2(4)];
                            break;
                        default:
                            goto IL_27D;
                    }
                    IL_2BF:
                    if (num4 != 0)
                    {
                        num5 *= Double13[array2[i]];
                        for (int l = 0; l < int45; l++)
                        {
                            if ((_int9 >> l & 1) != 0)
                            {
                                double25[int46 + i + l * 256] = num5 * array[l];
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

        private void method_10(int int45)
        {
        }

        private void method_11(double[] double24, int int45, double double25, double double26, double double27)
        {
            switch (int45)
            {
                case 2:
                    double24[0] = double25;
                    double24[1] = double25;
                    double24[2] = double25;
                    double24[3] = double25;
                    double24[4] = double25;
                    return;
                case 3:
                    double24[0] = double25;
                    double24[1] = double25 * double26;
                    double24[2] = double25;
                    double24[3] = double25;
                    double24[4] = double25;
                    return;
                case 4:
                    double24[0] = double25;
                    double24[1] = double25;
                    double24[2] = double25 * double27 * Double2;
                    double24[3] = double25;
                    double24[4] = double25;
                    return;
                case 5:
                    double24[0] = double25;
                    double24[1] = double25 * double26;
                    double24[2] = double25;
                    double24[3] = double25 * double27 * Double2;
                    double24[4] = double25;
                    return;
                case 6:
                    double24[0] = double25;
                    double24[1] = double25;
                    double24[2] = double25 * double27;
                    double24[3] = double25 * double27;
                    double24[4] = double25;
                    return;
                case 7:
                    double24[0] = double25;
                    double24[1] = double25 * double26;
                    double24[2] = double25;
                    double24[3] = double25 * double27;
                    double24[4] = double25 * double27;
                    return;
                default:
                    return;
            }
        }

        private void method_12(int[] int45)
        {
            for (int i = 0; i < int45.Length; i++)
            {
                int45[i] = 0;
            }
            int num = Class1150.method_2(3);
            int num2 = 0;
            do
            {
                num2 += Class1150.method_2(5);
                int num3 = Class1150.method_2(4);
                int num4 = Class1150.method_2(3);
                num4 -= ((num4 < 4) ? 4 : 3);
                while (num3-- != 0)
                {
                    int45[num2++] = num4;
                }
            } while (num-- != 0);
        }

        private void method_13(int int45, int int46, byte byte10, byte[] byte11, int int47)
        {
            while (int46-- != 0)
            {
                int num = Class1150.method_2(7);
                byte10 += Byte6[num];
                if ((255 & byte10) <= 24)
                {
                    switch (int45)
                    {
                        case 1:
                            goto IL_67;
                        case 2:
                            goto IL_5C;
                        case 3:
                            byte11[int47++] = byte10;
                            byte11[int47++] = byte10;
                            goto IL_5C;
                    }
                    IL_72:
                    byte10 += Byte7[num];
                    if ((255 & byte10) <= 24)
                    {
                        switch (int45)
                        {
                            case 1:
                                goto IL_C6;
                            case 2:
                                goto IL_BB;
                            case 3:
                                byte11[int47++] = byte10;
                                byte11[int47++] = byte10;
                                goto IL_BB;
                        }
                        IL_D1:
                        byte10 += Byte8[num];
                        if ((255 & byte10) <= 24)
                        {
                            switch (int45)
                            {
                                case 1:
                                    break;
                                case 2:
                                    goto IL_117;
                                case 3:
                                    byte11[int47++] = byte10;
                                    byte11[int47++] = byte10;
                                    goto IL_117;
                                default:
                                    continue;
                            }
                            IL_122:
                            byte11[int47++] = byte10;
                            continue;
                            IL_117:
                            byte11[int47++] = byte10;
                            goto IL_122;
                        }
                        throw new Ac3Exception("Exponent too large");
                        IL_C6:
                        byte11[int47++] = byte10;
                        goto IL_D1;
                        IL_BB:
                        byte11[int47++] = byte10;
                        goto IL_C6;
                    }
                    throw new Ac3Exception("Exponent too large");
                    IL_67:
                    byte11[int47++] = byte10;
                    goto IL_72;
                    IL_5C:
                    byte11[int47++] = byte10;
                    goto IL_67;
                }
                throw new Ac3Exception("Exponent too large");
            }
        }

        public virtual int vmethod_0(byte[] byte10, Stream stream0)
        {
            try
            {
                int num = byte10.Length;
                Class1150.vmethod_2(byte10, 0, num);
                while (Class1150.method_1() > 56)
                {
                    if (_bool4)
                    {
                        Class1150.vmethod_3(Class1150.vmethod_0() & -8);
                        if (!method_1())
                        {
                            continue;
                        }
                        _bool4 = false;
                    }
                    if (Class1150.method_1() < Int4 * 8)
                    {
                        break;
                    }
                    int num2 = Class1150.vmethod_0();
                    method_2();
                    while (Class1150.vmethod_0() - num2 < (Int4 - 7) * 8)
                    {
                        method_3();
                        Class1100.vmethod_2(_double10, 2, stream0);
                    }
                    _bool4 = true;
                }
            }
            catch
            {
                _bool4 = true;
                Class1150.vmethod_3(Class1150.vmethod_0() + Class1150.method_1());
            }
            return 0;
        }

        static Ac3Class1()
        {
            Double2 = 0.70710678118654757;
            Double3 = 0.59460355750136051;
            Double4 = 0.5;
            Int31 = new[]
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
            Int32 = new[]
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
            Int33 = new[]
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
            Double11 = new[]
            {
                Double2,
                Double3,
                Double4,
                Double3
            };
            Double12 = new[]
            {
                Double2,
                Double4,
                0.0,
                Double4
            };
            Int35 = new[]
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
            Int36 = new[]
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
            Int37 = new[]
            {
                25,
                37,
                61,
                253
            };
            Int38 = new[]
            {
                1344,
                1240,
                1144,
                1040
            };
            Int39 = new[]
            {
                3072,
                1280,
                768,
                256
            };
            Int40 = new[]
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
            Int42 = new int[50];
            Int41 = Class114.smethod_15();
            Byte9 = Class114.smethod_16();
            Int43 = Class114.smethod_17();
            Int44 = Class114.smethod_18();
        }
    }
}