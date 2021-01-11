namespace GHNamespaceI
{
    public class Class101
    {
        private short _short0;

        public Class101()
        {
            _short0 = -1;
        }

        public void method_0(int int0, int int1)
        {
            int num = 1 << int1 - 1;
            do
            {
                if ((_short0 & 32768) == 0 ^ (int0 & num) == 0)
                {
                    _short0 = (short) (_short0 << 1);
                    _short0 ^= -32763;
                }
                else
                {
                    _short0 = (short) (_short0 << 1);
                }
            } while ((num >>= 1) != 0);
        }

        public short method_1()
        {
            short result = _short0;
            _short0 = -1;
            return result;
        }
    }
}