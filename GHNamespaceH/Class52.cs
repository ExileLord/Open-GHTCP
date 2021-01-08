using System;

namespace GHNamespaceH
{
    public class Class52
    {
        public byte[] Byte0;

        private int _int0;

        private int _int1;

        private int _int2;

        private int _int4;

        private int _int5;

        private readonly Class48 _class480 = new Class48();

        private readonly byte[] _byte1 = new byte[4];

        public int method_0()
        {
            Byte0 = null;
            return 0;
        }

        public int method_1(int int6)
        {
            if (_int2 != 0)
            {
                _int1 -= _int2;
                if (_int1 > 0)
                {
                    Buffer.BlockCopy(Byte0, _int2, Byte0, 0, _int1);
                }
                _int2 = 0;
            }
            if (int6 > _int0 - _int1)
            {
                var num = int6 + _int1 + 4096;
                if (Byte0 != null)
                {
                    var dst = new byte[num];
                    Buffer.BlockCopy(Byte0, 0, dst, 0, Byte0.Length);
                    Byte0 = dst;
                }
                else
                {
                    Byte0 = new byte[num];
                }
                _int0 = num;
            }
            return _int1;
        }

        public int method_2(int int6)
        {
            if (_int1 + int6 > _int0)
            {
                return -1;
            }
            _int1 += int6;
            return 0;
        }

        public int method_3(Class48 class481)
        {
            var num = _int2;
            var num2 = _int1 - _int2;
            if (_int4 == 0)
            {
                if (num2 < 27)
                {
                    return 0;
                }
                if (Byte0[num] == 79 && Byte0[num + 1] == 103 && Byte0[num + 2] == 103)
                {
                    if (Byte0[num + 3] == 83)
                    {
                        var num3 = (Byte0[num + 26] & 255) + 27;
                        if (num2 < num3)
                        {
                            return 0;
                        }
                        for (var i = 0; i < (Byte0[num + 26] & 255); i++)
                        {
                            _int5 += Byte0[num + 27 + i] & 255;
                        }
                        _int4 = num3;
                        goto IL_11E;
                    }
                }
                _int4 = 0;
                _int5 = 0;
                var num4 = 0;
                for (var j = 0; j < num2 - 1; j++)
                {
                    if (Byte0[num + 1 + j] == 79)
                    {
                        num4 = num + 1 + j;
                        goto IL_108;
                    }
                }
                IL_108:
                if (num4 == 0)
                {
                    num4 = _int1;
                }
                _int2 = num4;
                return -(num4 - num);
            }
            IL_11E:
            if (_int5 + _int4 > num2)
            {
                return 0;
            }
            lock (_byte1)
            {
                Buffer.BlockCopy(Byte0, num + 22, _byte1, 0, 4);
                Byte0[num + 22] = 0;
                Byte0[num + 23] = 0;
                Byte0[num + 24] = 0;
                Byte0[num + 25] = 0;
                var @class = _class480;
                @class.Byte0 = Byte0;
                @class.Int0 = num;
                @class.Int1 = _int4;
                @class.Byte1 = Byte0;
                @class.Int2 = num + _int4;
                @class.Int3 = _int5;
                @class.method_7();
                if (_byte1[0] == Byte0[num + 22] && _byte1[1] == Byte0[num + 23] && _byte1[2] == Byte0[num + 24])
                {
                    if (_byte1[3] == Byte0[num + 25])
                    {
                        goto IL_2B0;
                    }
                }
                Buffer.BlockCopy(_byte1, 0, Byte0, num + 22, 4);
                _int4 = 0;
                _int5 = 0;
                var num4 = 0;
                for (var k = 0; k < num2 - 1; k++)
                {
                    if (Byte0[num + 1 + k] == 79)
                    {
                        num4 = num + 1 + k;
                        goto IL_28C;
                    }
                }
                IL_28C:
                if (num4 == 0)
                {
                    num4 = _int1;
                }
                _int2 = num4;
                return -(num4 - num);
            }
            IL_2B0:
            num = _int2;
            if (class481 != null)
            {
                class481.Byte0 = Byte0;
                class481.Int0 = num;
                class481.Int1 = _int4;
                class481.Byte1 = Byte0;
                class481.Int2 = num + _int4;
                class481.Int3 = _int5;
            }
            _int2 += (num2 = _int4 + _int5);
            _int4 = 0;
            _int5 = 0;
            return num2;
        }

        public int method_4()
        {
            _int1 = 0;
            _int2 = 0;
            _int4 = 0;
            _int5 = 0;
            return 0;
        }

        public void method_5()
        {
        }
    }
}