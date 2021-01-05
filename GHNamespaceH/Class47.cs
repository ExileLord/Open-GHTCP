using GHNamespaceD;

namespace GHNamespaceH
{
    public class Class47
    {
        private static string _string0 = "vorbis";

        private static int _int0 = -130;

        public byte[][] Byte0;

        public int[] Int1;

        public int Int2;

        public byte[] Byte1;

        public void method_0()
        {
            Byte0 = null;
            Int2 = 0;
            Byte1 = null;
        }

        public int method_1(OggClass3 class380)
        {
            var num = class380.method_6(32);
            if (num < 0)
            {
                method_2();
                return -1;
            }
            Byte1 = new byte[num + 1];
            class380.method_5(Byte1, num);
            Int2 = class380.method_6(32);
            if (Int2 < 0)
            {
                method_2();
                return -1;
            }
            Byte0 = new byte[Int2 + 1][];
            Int1 = new int[Int2 + 1];
            for (var i = 0; i < Int2; i++)
            {
                var num2 = class380.method_6(32);
                if (num2 < 0)
                {
                    method_2();
                    return -1;
                }
                Int1[i] = num2;
                Byte0[i] = new byte[num2 + 1];
                class380.method_5(Byte0[i], num2);
            }
            if (class380.method_6(1) != 1)
            {
                method_2();
                return -1;
            }
            return 0;
        }

        public void method_2()
        {
            for (var i = 0; i < Int2; i++)
            {
                Byte0[i] = null;
            }
            Byte0 = null;
            Byte1 = null;
        }
    }
}