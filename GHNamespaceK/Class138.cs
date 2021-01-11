using System;
using GHNamespaceL;

namespace GHNamespaceK
{
    public class Class138 : Class137
    {
        public int Int0;

        public Class143 Class1430;

        public virtual void vmethod_0(Class144 class1440, int int1, int int2, Class140 class1400, int[] int3)
        {
            int num = 0;
            int num2 = 1 << int2;
            int num3 = (int2 > 0) ? (class1400.Int0 >> int2) : (class1400.Int0 - int1);
            Class1430.vmethod_0(Math.Max(6, int2));
            Class1430.Int0 = new int[num2];
            for (int i = 0; i < num2; i++)
            {
                int num4 = class1440.vmethod_10(4);
                Class1430.Int0[i] = num4;
                if (num4 < 15)
                {
                    int num5 = (int2 == 0 || i > 0) ? num3 : (num3 - int1);
                    class1440.vmethod_17(int3, num, num5, num4);
                    num += num5;
                }
                else
                {
                    num4 = class1440.vmethod_10(5);
                    Class1430.Int1[i] = num4;
                    int j = (int2 == 0 || i > 0) ? 0 : int1;
                    while (j < num3)
                    {
                        int3[num] = class1440.vmethod_12(num4);
                        j++;
                        num++;
                    }
                }
            }
        }
    }
}