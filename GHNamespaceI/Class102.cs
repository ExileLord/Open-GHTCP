namespace GHNamespaceI
{
    public class Class102
    {
        private static readonly int Int0 = 32767;

        private int _int1;

        private int _int2;

        private int _int3;

        private readonly int[] _int4 = new int[32768];

        public Class102()
        {
            _int1 = 0;
            _int2 = 0;
            _int3 = 0;
        }

        public int method_0()
        {
            return _int2;
        }

        public int method_1(int int5)
        {
            _int2 += int5;
            var num = 0;
            var num2 = _int3;
            if (num2 + int5 < 32768)
            {
                while (int5-- > 0)
                {
                    num <<= 1;
                    num |= ((_int4[num2++] != 0) ? 1 : 0);
                }
            }
            else
            {
                while (int5-- > 0)
                {
                    num <<= 1;
                    num |= ((_int4[num2] != 0) ? 1 : 0);
                    num2 = (num2 + 1 & Int0);
                }
            }
            _int3 = num2;
            return num;
        }

        public int method_2()
        {
            _int2++;
            var result = _int4[_int3];
            _int3 = (_int3 + 1 & Int0);
            return result;
        }

        public void method_3(int int5)
        {
            var num = _int1;
            _int4[num++] = (int5 & 128);
            _int4[num++] = (int5 & 64);
            _int4[num++] = (int5 & 32);
            _int4[num++] = (int5 & 16);
            _int4[num++] = (int5 & 8);
            _int4[num++] = (int5 & 4);
            _int4[num++] = (int5 & 2);
            _int4[num++] = (int5 & 1);
            if (num == 32768)
            {
                _int1 = 0;
                return;
            }
            _int1 = num;
        }

        public void method_4(int int5)
        {
            _int2 -= int5;
            _int3 -= int5;
            if (_int3 < 0)
            {
                _int3 += 32768;
            }
        }

        public void method_5(int int5)
        {
            var num = int5 << 3;
            _int2 -= num;
            _int3 -= num;
            if (_int3 < 0)
            {
                _int3 += 32768;
            }
        }
    }
}