using System;

namespace GHNamespace5
{
    public class Class188
    {
        private readonly byte[] _byte0;

        private int _int0;

        private int _int1;

        private uint _uint0;

        private int _int2;

        public Class188() : this(4096)
        {
        }

        public Class188(int int3)
        {
            _byte0 = new byte[int3];
        }

        public void method_0()
        {
            _int2 = 0;
            _int1 = 0;
            _int0 = 0;
        }

        public void method_1(int int3)
        {
            _byte0[_int1++] = (byte) int3;
            _byte0[_int1++] = (byte) (int3 >> 8);
        }

        public void method_2(byte[] byte1, int int3, int int4)
        {
            Array.Copy(byte1, int3, _byte0, _int1, int4);
            _int1 += int4;
        }

        public int method_3()
        {
            return _int2;
        }

        public void method_4()
        {
            if (_int2 > 0)
            {
                _byte0[_int1++] = (byte) _uint0;
                if (_int2 > 8)
                {
                    _byte0[_int1++] = (byte) (_uint0 >> 8);
                }
            }
            _uint0 = 0u;
            _int2 = 0;
        }

        public void method_5(int int3, int int4)
        {
            _uint0 |= (uint) int3 << _int2;
            _int2 += int4;
            if (_int2 >= 16)
            {
                _byte0[_int1++] = (byte) _uint0;
                _byte0[_int1++] = (byte) (_uint0 >> 8);
                _uint0 >>= 16;
                _int2 -= 16;
            }
        }

        public void method_6(int int3)
        {
            _byte0[_int1++] = (byte) (int3 >> 8);
            _byte0[_int1++] = (byte) int3;
        }

        public bool method_7()
        {
            return _int1 == 0;
        }

        public int method_8(byte[] byte1, int int3, int int4)
        {
            if (_int2 >= 8)
            {
                _byte0[_int1++] = (byte) _uint0;
                _uint0 >>= 8;
                _int2 -= 8;
            }
            if (int4 > _int1 - _int0)
            {
                int4 = _int1 - _int0;
                Array.Copy(_byte0, _int0, byte1, int3, int4);
                _int0 = 0;
                _int1 = 0;
            }
            else
            {
                Array.Copy(_byte0, _int0, byte1, int3, int4);
                _int0 += int4;
            }
            return int4;
        }
    }
}