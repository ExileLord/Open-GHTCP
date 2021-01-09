using System;
using GHNamespace5;

namespace GHNamespace6
{
    public class Class194
    {
        private int _int0;

        private readonly bool _bool0;

        private int _int1;

        private long _long0;

        private readonly Class189 _class1890;

        private readonly Class184 _class1840;

        public Class194() : this(-1, false)
        {
        }

        public Class194(int int2, bool bool1)
        {
            if (int2 == -1)
            {
                int2 = 6;
            }
            else if (int2 < 0 || int2 > 9)
            {
                throw new ArgumentOutOfRangeException("level");
            }
            _class1890 = new Class189();
            _class1840 = new Class184(_class1890);
            _bool0 = bool1;
            method_8(Enum29.Const0);
            method_7(int2);
            method_0();
        }

        public void method_0()
        {
            _int1 = (_bool0 ? 16 : 0);
            _long0 = 0L;
            _class1890.method_0();
            _class1840.method_3();
        }

        public long method_1()
        {
            return _long0;
        }

        public void method_2()
        {
            _int1 |= 4;
        }

        public void method_3()
        {
            _int1 |= 12;
        }

        public bool method_4()
        {
            return _int1 == 30 && _class1890.method_7();
        }

        public bool method_5()
        {
            return _class1840.method_2();
        }

        public void method_6(byte[] byte0, int int2, int int3)
        {
            if ((_int1 & 8) != 0)
            {
                throw new InvalidOperationException("Finish() already called");
            }
            _class1840.method_1(byte0, int2, int3);
        }

        public void method_7(int int2)
        {
            if (int2 == -1)
            {
                int2 = 6;
            }
            else if (int2 < 0 || int2 > 9)
            {
                throw new ArgumentOutOfRangeException("level");
            }
            if (_int0 != int2)
            {
                _int0 = int2;
                _class1840.method_6(int2);
            }
        }

        public void method_8(Enum29 enum290)
        {
            _class1840.method_5(enum290);
        }

        public int method_9(byte[] byte0, int int2, int int3)
        {
            int num = int3;
            if (_int1 == 127)
            {
                throw new InvalidOperationException("Deflater closed");
            }
            if (_int1 < 16)
            {
                int num2 = 30720;
                int num3 = _int0 - 1 >> 1;
                if (num3 < 0 || num3 > 3)
                {
                    num3 = 3;
                }
                num2 |= num3 << 6;
                if ((_int1 & 1) != 0)
                {
                    num2 |= 32;
                }
                num2 += 31 - num2 % 31;
                _class1890.method_6(num2);
                if ((_int1 & 1) != 0)
                {
                    int num4 = _class1840.method_4();
                    _class1840.ResetAdler();
                    _class1890.method_6(num4 >> 16);
                    _class1890.method_6(num4 & 65535);
                }
                _int1 = (16 | (_int1 & 12));
            }
            while (true)
            {
                int num5 = _class1890.method_8(byte0, int2, int3);
                int2 += num5;
                _long0 += num5;
                int3 -= num5;
                if (int3 == 0 || _int1 == 30)
                {
                    goto IL_1E2;
                }
                if (!_class1840.method_0((_int1 & 4) != 0, (_int1 & 8) != 0))
                {
                    if (_int1 == 16)
                    {
                        break;
                    }
                    if (_int1 == 20)
                    {
                        if (_int0 != 0)
                        {
                            for (int i = 8 + (-_class1890.method_3() & 7); i > 0; i -= 10)
                            {
                                _class1890.method_5(2, 10);
                            }
                        }
                        _int1 = 16;
                    }
                    else if (_int1 == 28)
                    {
                        _class1890.method_4();
                        if (!_bool0)
                        {
                            int num6 = _class1840.method_4();
                            _class1890.method_6(num6 >> 16);
                            _class1890.method_6(num6 & 65535);
                        }
                        _int1 = 30;
                    }
                }
            }
            return num - int3;
            IL_1E2:
            return num - int3;
        }
    }
}