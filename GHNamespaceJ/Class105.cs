using System;

namespace GHNamespaceJ
{
    public class Class105
    {
        public static readonly float Float0 = float.NegativeInfinity;

        public static readonly Class105 Class1050 = new Class105();

        public static readonly int Num1 = 32;

        private readonly float[] _float1 = new float[Num1];

        public float[] method_0()
        {
            var array = new float[Num1];
            var i = 0;
            var num = Num1;
            while (i < num)
            {
                array[i] = smethod_1(_float1[i]);
                i++;
            }
            return array;
        }

        public void method_1(float[] float2)
        {
            method_3();
            var num = (float2.Length > Num1) ? Num1 : float2.Length;
            for (var i = 0; i < num; i++)
            {
                _float1[i] = smethod_0(float2[i]);
            }
        }

        public void method_2(Class105 class1051)
        {
            if (class1051 != this)
            {
                method_1(class1051._float1);
            }
        }

        public void method_3()
        {
            for (var i = 0; i < Num1; i++)
            {
                _float1[i] = 0f;
            }
        }

        private static float smethod_0(float float2)
        {
            if (float2 == Float0)
            {
                return float2;
            }
            if (float2 > 1f)
            {
                return 1f;
            }
            if (float2 < -1f)
            {
                return -1f;
            }
            return float2;
        }

        public static float smethod_1(float float2)
        {
            if (float2 == Float0)
            {
                return 0f;
            }
            return (float) Math.Pow(2.0, float2);
        }
    }
}