using System;

namespace GHNamespace2
{
    public struct Struct11
    {
        private readonly int _int0;

        private readonly int _int1;

        public Struct11(int int2, int int3)
        {
            _int0 = int2;
            _int1 = int3;
        }

        public Struct11 method_0(Struct11 struct110)
        {
            var num = Math.Max(_int0, struct110._int0);
            var num2 = Math.Min(_int1, struct110._int1);
            if (num2 > num)
            {
                return new Struct11(num, num2);
            }
            return new Struct11(-1, -1);
        }

        public bool method_1()
        {
            return _int0 == -1 || _int1 == -1;
        }

        public int method_2()
        {
            return _int0;
        }

        public int method_3()
        {
            return _int1 - _int0;
        }
    }
}