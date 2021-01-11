using GHNamespaceH;

namespace GHNamespace3
{
    public class VorbisClass
    {
        public int[] Int7 = new int[2];

        public int Int8;

        public int Int9;

        public int Int10;

        public int Int11;

        public int Int12;

        public int Int13;

        public int Int14;

        public Class64[] Class640;

        public int[] Int15;

        public object[] Object0;

        public int[] Int16;

        public object[] Object1;

        public int[] Int17;

        public object[] Object2;

        public int[] Int18;

        public object[] Object3;

        public Class76[] Class760;

        public Class53[] Class530 = new Class53[64];

        public void method_0()
        {
            for (int i = 0; i < Int8; i++)
            {
                Class640[i] = null;
            }
            Class640 = null;
            for (int j = 0; j < Int9; j++)
            {
                Class45.Class450[Int15[j]].vmethod_0(Object0[j]);
            }
            Object0 = null;
            for (int k = 0; k < Int10; k++)
            {
                Class72.Class720[Int16[k]].vmethod_0(Object1[k]);
            }
            Object1 = null;
            for (int l = 0; l < Int11; l++)
            {
                Class41.Class410[Int17[l]].vmethod_0(Object2[l]);
            }
            Object2 = null;
            for (int m = 0; m < Int12; m++)
            {
                Class57.Class570[Int18[m]].vmethod_0(Object3[m]);
            }
            Object3 = null;
            for (int n = 0; n < Int13; n++)
            {
                if (Class760[n] != null)
                {
                    Class760[n].method_0();
                    Class760[n] = null;
                }
            }
            Class760 = null;
            for (int num = 0; num < Int14; num++)
            {
                Class530[num].method_0();
            }
        }
    }
}