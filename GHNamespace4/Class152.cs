namespace GHNamespace4
{
    public class Class152
    {
        private readonly byte[] _byte0;

        private int _int0;

        public virtual int vmethod_0()
        {
            return _int0;
        }

        public Class152(int int1)
        {
            if (int1 <= 0)
            {
                int1 = 256;
            }
            _byte0 = new byte[int1];
            _int0 = 0;
        }

        public virtual void vmethod_1(byte byte1)
        {
            _byte0[_int0++] = byte1;
        }

        public virtual byte[] vmethod_2()
        {
            return _byte0;
        }

        public virtual byte vmethod_3(int int1)
        {
            return _byte0[int1];
        }
    }
}