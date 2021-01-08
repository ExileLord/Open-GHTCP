using System;
using Compression;
using GHNamespace5;

namespace GHNamespace6
{
    public class Class196
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

        private int _int9;

        private bool _bool0;

        private long _long0;

        private long _long1;

        private readonly bool _bool1;

        private readonly Class187 _class1870;

        private readonly Class203 _class2030;

        private Class198 _class1980;

        private Class197 _class1970;

        private Class197 _class1971;

        private readonly Class200 _class2000;

        public Class196() : this(false)
        {
        }

        public Class196(bool bool2)
        {
            _bool1 = bool2;
            _class2000 = new Class200();
            _class1870 = new Class187();
            _class2030 = new Class203();
            _int4 = (bool2 ? 2 : 0);
        }

        public void method_0()
        {
            _int4 = (_bool1 ? 2 : 0);
            _long1 = 0L;
            _long0 = 0L;
            _class1870.method_7();
            _class2030.method_7();
            _class1980 = null;
            _class1970 = null;
            _class1971 = null;
            _bool0 = false;
            _class2000.vmethod_1();
        }

        private bool method_1()
        {
            var num = _class1870.method_0(16);
            if (num < 0)
            {
                return false;
            }
            _class1870.method_1(16);
            num = ((num << 8 | num >> 8) & 65535);
            if (num % 31 != 0)
            {
                throw new SharpZipBaseException("Header checksum illegal");
            }
            if ((num & 3840) != 2048)
            {
                throw new SharpZipBaseException("Compression Method unknown");
            }
            if ((num & 32) == 0)
            {
                _int4 = 2;
            }
            else
            {
                _int4 = 1;
                _int6 = 32;
            }
            return true;
        }

        private bool method_2()
        {
            while (_int6 > 0)
            {
                var num = _class1870.method_0(8);
                if (num < 0)
                {
                    return false;
                }
                _class1870.method_1(8);
                _int5 = (_int5 << 8 | num);
                _int6 -= 8;
            }
            return false;
        }

        private bool method_3()
        {
            var i = _class2030.method_4();
            while (i >= 258)
            {
                int num;
                switch (_int4)
                {
                    case 7:
                        while (((num = _class1970.method_1(_class1870)) & -256) == 0)
                        {
                            _class2030.method_0(num);
                            if (--i < 258)
                            {
                                return true;
                            }
                        }
                        if (num >= 257)
                        {
                            try
                            {
                                _int7 = Int0[num - 257];
                                _int6 = Int1[num - 257];
                            }
                            catch (Exception)
                            {
                                throw new SharpZipBaseException("Illegal rep length code");
                            }
                            goto IL_AC;
                        }
                        if (num < 0)
                        {
                            return false;
                        }
                        _class1971 = null;
                        _class1970 = null;
                        _int4 = 2;
                        return true;
                    case 8:
                        goto IL_AC;
                    case 9:
                        goto IL_FC;
                    case 10:
                        break;
                    default:
                        throw new SharpZipBaseException("Inflater unknown mode");
                }
                IL_13D:
                if (_int6 > 0)
                {
                    _int4 = 10;
                    var num2 = _class1870.method_0(_int6);
                    if (num2 < 0)
                    {
                        return false;
                    }
                    _class1870.method_1(_int6);
                    _int8 += num2;
                }
                _class2030.method_2(_int7, _int8);
                i -= _int7;
                _int4 = 7;
                continue;
                IL_FC:
                num = _class1971.method_1(_class1870);
                if (num >= 0)
                {
                    try
                    {
                        _int8 = Int2[num];
                        _int6 = Int3[num];
                    }
                    catch (Exception)
                    {
                        throw new SharpZipBaseException("Illegal rep dist code");
                    }
                    goto IL_13D;
                }
                return false;
                IL_AC:
                if (_int6 > 0)
                {
                    _int4 = 8;
                    var num3 = _class1870.method_0(_int6);
                    if (num3 < 0)
                    {
                        return false;
                    }
                    _class1870.method_1(_int6);
                    _int7 += num3;
                }
                _int4 = 9;
                goto IL_FC;
            }
            return true;
        }

        private bool method_4()
        {
            while (_int6 > 0)
            {
                var num = _class1870.method_0(8);
                if (num < 0)
                {
                    return false;
                }
                _class1870.method_1(8);
                _int5 = (_int5 << 8 | num);
                _int6 -= 8;
            }
            if ((int) _class2000.vmethod_0() != _int5)
            {
                throw new SharpZipBaseException(string.Concat("Adler chksum doesn't match: ",
                    (int) _class2000.vmethod_0(), " vs. ", _int5));
            }
            _int4 = 12;
            return false;
        }

        private bool method_5()
        {
            switch (_int4)
            {
                case 0:
                    return method_1();
                case 1:
                    return method_2();
                case 2:
                    if (_bool0)
                    {
                        if (_bool1)
                        {
                            _int4 = 12;
                            return false;
                        }
                        _class1870.method_4();
                        _int6 = 32;
                        _int4 = 11;
                        return true;
                    }
                    else
                    {
                        var num = _class1870.method_0(3);
                        if (num < 0)
                        {
                            return false;
                        }
                        _class1870.method_1(3);
                        if ((num & 1) != 0)
                        {
                            _bool0 = true;
                        }
                        switch (num >> 1)
                        {
                            case 0:
                                _class1870.method_4();
                                _int4 = 3;
                                break;
                            case 1:
                                _class1970 = Class197.Class1970;
                                _class1971 = Class197.Class1971;
                                _int4 = 7;
                                break;
                            case 2:
                                _class1980 = new Class198();
                                _int4 = 6;
                                break;
                            default:
                                throw new SharpZipBaseException("Unknown block type " + num);
                        }
                        return true;
                    }
                case 3:
                    if ((_int9 = _class1870.method_0(16)) < 0)
                    {
                        return false;
                    }
                    _class1870.method_1(16);
                    _int4 = 4;
                    break;
                case 4:
                    break;
                case 5:
                    goto IL_1A4;
                case 6:
                    if (!_class1980.method_0(_class1870))
                    {
                        return false;
                    }
                    _class1970 = _class1980.method_1();
                    _class1971 = _class1980.method_2();
                    _int4 = 7;
                    goto IL_228;
                case 7:
                case 8:
                case 9:
                case 10:
                    goto IL_228;
                case 11:
                    return method_4();
                case 12:
                    return false;
                default:
                    throw new SharpZipBaseException("Inflater.Decode unknown mode");
            }
            var num2 = _class1870.method_0(16);
            if (num2 < 0)
            {
                return false;
            }
            _class1870.method_1(16);
            if (num2 != (_int9 ^ 65535))
            {
                throw new SharpZipBaseException("broken uncompressed block");
            }
            _int4 = 5;
            IL_1A4:
            var num3 = _class2030.method_3(_class1870, _int9);
            _int9 -= num3;
            if (_int9 == 0)
            {
                _int4 = 2;
                return true;
            }
            return !_class1870.method_5();
            IL_228:
            return method_3();
        }

        public void method_6(byte[] byte0, int int10, int int11)
        {
            _class1870.method_8(byte0, int10, int11);
            _long1 += int11;
        }

        public int method_7(byte[] byte0, int int10, int int11)
        {
            if (byte0 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (int11 < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count cannot be negative");
            }
            if (int10 < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
            }
            if (int10 + int11 > byte0.Length)
            {
                throw new ArgumentException("count exceeds buffer bounds");
            }
            if (int11 == 0)
            {
                if (!method_10())
                {
                    method_5();
                }
                return 0;
            }
            var num = 0;
            while (true)
            {
                if (_int4 != 11)
                {
                    var num2 = _class2030.method_6(byte0, int10, int11);
                    if (num2 > 0)
                    {
                        _class2000.vmethod_2(byte0, int10, num2);
                        int10 += num2;
                        num += num2;
                        _long0 += num2;
                        int11 -= num2;
                        if (int11 == 0)
                        {
                            return num;
                        }
                    }
                }
                if (!method_5())
                {
                    if (_class2030.method_5() <= 0)
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

        public bool method_8()
        {
            return _class1870.method_5();
        }

        public bool method_9()
        {
            return _int4 == 1 && _int6 == 0;
        }

        public bool method_10()
        {
            return _int4 == 12 && _class2030.method_5() == 0;
        }

        public long method_11()
        {
            return _long0;
        }

        public long method_12()
        {
            return _long1 - method_13();
        }

        public int method_13()
        {
            return _class1870.method_3();
        }
    }
}