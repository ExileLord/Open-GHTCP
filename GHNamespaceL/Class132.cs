using GHNamespaceK;

namespace GHNamespaceL
{
    public class Class132 : Class131
    {
        private readonly int _int1;

        public Class132(Class144 class1440, Class140 class1401, Class136 class1360, int int2,
            int int3) : base(class1401, int3)
        {
            _int1 = class1440.vmethod_12(int2);
            for (int i = 0; i < class1401.Int0; i++)
            {
                class1360.vmethod_0()[i] = _int1;
            }
        }

        public override string ToString()
        {
            return string.Concat("ChannelConstant: Value=", _int1, " WastedBits=", Int0);
        }
    }
}