namespace GHNamespaceD
{
    public class OggClass3
    {
        private static readonly int[] Int0 =
        {
            0,
            1,
            3,
            7,
            15,
            31,
            63,
            127,
            255,
            511,
            1023,
            2047,
            4095,
            8191,
            16383,
            32767,
            65535,
            131071,
            262143,
            524287,
            1048575,
            2097151,
            4194303,
            8388607,
            16777215,
            33554431,
            67108863,
            134217727,
            268435455,
            536870911,
            1073741823,
            2147483647,
            -1
        };

        private int _int1;

        private byte[] _byte0;

        private int _int2;

        private int _int3;

        private int _int4;

        public void method_0()
        {
            _byte0 = new byte[256];
            _int1 = 0;
            _byte0[0] = 0;
            _int4 = 256;
        }

        public void method_1()
        {
            _byte0 = null;
        }

        public int method_2(int int5)
        {
            int num = Int0[int5];
            int5 += _int2;
            if (_int3 + 4 >= _int4 && _int3 + (int5 - 1) / 8 >= _int4)
            {
                return -1;
            }
            int num2 = (_byte0[_int1] & 255) >> _int2;
            if (int5 > 8)
            {
                num2 |= (_byte0[_int1 + 1] & 255) << 8 - _int2;
                if (int5 > 16)
                {
                    num2 |= (_byte0[_int1 + 2] & 255) << 16 - _int2;
                    if (int5 > 24)
                    {
                        num2 |= (_byte0[_int1 + 3] & 255) << 24 - _int2;
                        if (int5 > 32 && _int2 != 0)
                        {
                            num2 |= (_byte0[_int1 + 4] & 255) << 32 - _int2;
                        }
                    }
                }
            }
            return num2 & num;
        }

        public void method_3(int int5)
        {
            int5 += _int2;
            _int1 += int5 / 8;
            _int3 += int5 / 8;
            _int2 = (int5 & 7);
        }

        public void method_4(byte[] byte1, int int5, int int6)
        {
            _int1 = int5;
            _byte0 = byte1;
            _int3 = 0;
            _int2 = 0;
            _int4 = int6;
        }

        public void method_5(byte[] byte1, int int5)
        {
            int num = 0;
            while (int5-- != 0)
            {
                byte1[num++] = (byte) method_6(8);
            }
        }

        public int method_6(int int5)
        {
            int num = Int0[int5];
            int5 += _int2;
            int num2;
            if (_int3 + 4 >= _int4)
            {
                num2 = -1;
                if (_int3 + (int5 - 1) / 8 >= _int4)
                {
                    _int1 += int5 / 8;
                    _int3 += int5 / 8;
                    _int2 = (int5 & 7);
                    return num2;
                }
            }
            num2 = (_byte0[_int1] & 255) >> _int2;
            if (int5 > 8)
            {
                num2 |= (_byte0[_int1 + 1] & 255) << 8 - _int2;
                if (int5 > 16)
                {
                    num2 |= (_byte0[_int1 + 2] & 255) << 16 - _int2;
                    if (int5 > 24)
                    {
                        num2 |= (_byte0[_int1 + 3] & 255) << 24 - _int2;
                        if (int5 > 32 && _int2 != 0)
                        {
                            num2 |= (_byte0[_int1 + 4] & 255) << 32 - _int2;
                        }
                    }
                }
            }
            num2 &= num;
            _int1 += int5 / 8;
            _int3 += int5 / 8;
            _int2 = (int5 & 7);
            return num2;
        }

        public int method_7()
        {
            int result;
            if (_int3 >= _int4)
            {
                result = -1;
                _int2++;
                if (_int2 > 7)
                {
                    _int2 = 0;
                    _int1++;
                    _int3++;
                }
                return result;
            }
            result = (_byte0[_int1] >> _int2 & 1);
            _int2++;
            if (_int2 > 7)
            {
                _int2 = 0;
                _int1++;
                _int3++;
            }
            return result;
        }
    }
}