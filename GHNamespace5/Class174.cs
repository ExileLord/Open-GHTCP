using GHNamespace2;
using GHNamespaceM;

namespace GHNamespace5
{
    public class Class174 : Class172
    {
        private readonly float _float0;

        private readonly int _int0;

        public Class174(int int1, float float1)
        {
            _int0 = int1;
            _float0 = float1;
        }

        public override void vmethod_0(Class13 class130)
        {
            float[] array = class130.Float0;
            int num = class130.method_0();
            int num2 = class130.method_2();
            float num3 = 0f;
            switch (_int0)
            {
                case 1:
                    num3 = Class15.smethod_9(array, num, num2);
                    break;
                case 2:
                    num3 = Class15.smethod_4(array, num, num2);
                    break;
                case 3:
                    num3 = 1f;
                    break;
            }
            float num4 = _float0 / num3;
            for (int i = num; i < num + num2; i++)
            {
                array[i] = class130.vmethod_1(i, array[i], array[i] * num4);
            }
        }
    }
}