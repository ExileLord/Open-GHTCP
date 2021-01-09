using System;
using GHNamespace5;

namespace GHNamespace6
{
    public class Class203
    {
        private readonly byte[] _byte0 = new byte[32768];

        private int _int0;

        private int _int1;

        public void method_0(int int2)
        {
            if (_int1++ == 32768)
            {
                throw new InvalidOperationException("Window full");
            }
            _byte0[_int0++] = (byte) int2;
            _int0 &= 32767;
        }

        private void method_1(int int2, int int3, int int4)
        {
            while (int3-- > 0)
            {
                _byte0[_int0++] = _byte0[int2++];
                _int0 &= 32767;
                int2 &= 32767;
            }
        }

        public void method_2(int int2, int int3)
        {
            if ((_int1 += int2) > 32768)
            {
                throw new InvalidOperationException("Window full");
            }
            int num = _int0 - int3 & 32767;
            int num2 = 32768 - int2;
            if (num > num2 || _int0 >= num2)
            {
                method_1(num, int2, int3);
                return;
            }
            if (int2 <= int3)
            {
                Array.Copy(_byte0, num, _byte0, _int0, int2);
                _int0 += int2;
                return;
            }
            while (int2-- > 0)
            {
                _byte0[_int0++] = _byte0[num++];
            }
        }

        public int method_3(Class187 class1870, int int2)
        {
            int2 = Math.Min(Math.Min(int2, 32768 - _int1), class1870.method_3());
            int num = 32768 - _int0;
            int num2;
            if (int2 > num)
            {
                num2 = class1870.method_6(_byte0, _int0, num);
                if (num2 == num)
                {
                    num2 += class1870.method_6(_byte0, 0, int2 - num);
                }
            }
            else
            {
                num2 = class1870.method_6(_byte0, _int0, int2);
            }
            _int0 = (_int0 + num2 & 32767);
            _int1 += num2;
            return num2;
        }

        public int method_4()
        {
            return 32768 - _int1;
        }

        public int method_5()
        {
            return _int1;
        }

        public int method_6(byte[] byte1, int int2, int int3)
        {
            int num = _int0;
            if (int3 > _int1)
            {
                int3 = _int1;
            }
            else
            {
                num = (_int0 - _int1 + int3 & 32767);
            }
            int num2 = int3;
            int num3 = int3 - num;
            if (num3 > 0)
            {
                Array.Copy(_byte0, 32768 - num3, byte1, int2, num3);
                int2 += num3;
                int3 = num;
            }
            Array.Copy(_byte0, num - int3, byte1, int2, int3);
            _int1 -= num2;
            if (_int1 < 0)
            {
                throw new InvalidOperationException();
            }
            return num2;
        }

        public void method_7()
        {
            _int0 = 0;
            _int1 = 0;
        }
    }
}