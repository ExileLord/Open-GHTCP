using System;

namespace GHNamespace5
{
    public class Class187
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
            if (int4 < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            if ((_int2 & 7) != 0)
            {
                throw new InvalidOperationException("Bit buffer is not byte aligned!");
            }
            var num = 0;
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
            var num2 = _int1 - _int0;
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

        public void method_7()
        {
            _uint0 = 0u;
            _int2 = 0;
            _int1 = 0;
            _int0 = 0;
        }

        public void method_8(byte[] byte1, int int3, int int4)
        {
            if (byte1 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (int3 < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
            }
            if (int4 < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Cannot be negative");
            }
            if (_int0 < _int1)
            {
                throw new InvalidOperationException("Old input was not completely processed");
            }
            var num = int3 + int4;
            if (int3 <= num && num <= byte1.Length)
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
            throw new ArgumentOutOfRangeException("count");
        }
    }
}