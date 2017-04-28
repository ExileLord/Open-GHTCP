namespace GHNamespaceK
{
    public class Class130
    {
        public static void smethod_0(int[] int0, int int1, int[] int2, int int3, int int4, int[] int5, int int6)
        {
            for (var i = 0; i < int1; i++)
            {
                var num = 0;
                for (var j = 0; j < int3; j++)
                {
                    num += int2[j] * int5[int6 + i - j - 1];
                }
                int5[int6 + i] = int0[i] + (num >> int4);
            }
        }

        public static void smethod_1(int[] int0, int int1, int[] int2, int int3, int int4, int[] int5, int int6)
        {
            for (var i = 0; i < int1; i++)
            {
                var num = 0L;
                for (var j = 0; j < int3; j++)
                {
                    num += int2[j] * (long) int5[int6 + i - j - 1];
                }
                int5[int6 + i] = int0[i] + (int) (num >> int4);
            }
        }
    }
}