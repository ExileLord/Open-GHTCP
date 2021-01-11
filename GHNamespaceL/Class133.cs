using System;
using GHNamespaceK;

namespace GHNamespaceL
{
    public class Class133 : Class131
    {
        private readonly int[] _int1;

        public Class133(Class144 class1440, Class140 class1401, Class136 class1360, int int2,
            int int3) : base(class1401, int3)
        {
            _int1 = class1360.vmethod_2();
            for (int i = 0; i < class1401.Int0; i++)
            {
                _int1[i] = class1440.vmethod_12(int2);
            }
            Buffer.BlockCopy(_int1, 0, class1360.vmethod_0(), 0, class1401.Int0 << 2);
        }

        public override string ToString()
        {
            return "ChannelVerbatim: WastedBits=" + Int0;
        }
    }
}