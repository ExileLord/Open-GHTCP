using GHNamespaceJ;

namespace GHNamespaceI
{
    public class Class93 : Class92
    {
        public class Class98 : Class94
        {
            public static readonly float[] Float1;

            public static readonly float[] Float2;

            public static readonly float[] Float3;

            public static readonly int[] Int0;

            public static readonly float[][] Float4;

            public static readonly float[] Float5;

            public static readonly float[] Float6;

            public static readonly float[] Float7;

            public static readonly float[][] Float8;

            public static readonly int[] Int1;

            public static readonly float[] Float9;

            public static readonly float[] Float10;

            public static readonly float[] Float11;

            public static readonly int[] Int2;

            public static readonly float[] Float12;

            public static readonly float[] Float13;

            public static readonly float[] Float14;

            public static readonly int[] Int3;

            public static readonly float[] Float15;

            public static readonly float[] Float16;

            public static readonly float[] Float17;

            public static readonly int[] Int4;

            public static readonly float[][] Float18;

            public static readonly float[] Float19;

            public static readonly float[] Float20;

            public static readonly float[] Float21;

            public readonly int Int5;

            public int Int6;

            public int Int7;

            public float Float22;

            public float Float23;

            public float Float24;

            public readonly int[] Int8;

            public readonly float[][] Float25;

            public readonly float[] Float26;

            public int Int9;

            public int Int10;

            public readonly float[] Float27;

            public readonly float[] Float28;

            public readonly float[] Float29;

            public Class98(int int11)
            {
                int[] array = new int[1];
                Int8 = array;
                Float25 = new float[2][];
                float[] array2 = new float[1];
                Float26 = array2;
                Float27 = new float[3];
                float[] array3 = new float[1];
                Float28 = array3;
                float[] array4 = new float[1];
                Float29 = array4;
                //base..ctor();
                Int5 = int11;
                Int10 = 0;
                Int9 = 0;
            }

            public virtual int vmethod_4(ZzSoundClass class1070)
            {
                if (class1070.method_3() == Enum3.Const1)
                {
                    int num = class1070.method_5();
                    if (class1070.method_8() != Enum5.Const3)
                    {
                        if (num == 4)
                        {
                            num = 1;
                        }
                        else
                        {
                            num -= 4;
                        }
                    }
                    if (num != 1)
                    {
                        if (num != 2)
                        {
                            if (Int5 <= 10)
                            {
                                return 4;
                            }
                            if (Int5 > 22)
                            {
                                return 2;
                            }
                            return 3;
                        }
                    }
                    if (Int5 > 1)
                    {
                        return 3;
                    }
                    return 4;
                }
                if (Int5 <= 3)
                {
                    return 4;
                }
                if (Int5 > 10)
                {
                    return 2;
                }
                return 3;
            }

            public virtual void vmethod_5(ZzSoundClass class1070, int int11, int int12, float[] float30, int[] int13,
                float[] float31, float[] float32)
            {
                int num = class1070.method_5();
                if (class1070.method_8() != Enum5.Const3)
                {
                    if (num == 4)
                    {
                        num = 1;
                    }
                    else
                    {
                        num -= 4;
                    }
                }
                if (num != 1)
                {
                    if (num != 2)
                    {
                        if (Int5 <= 2)
                        {
                            Float25[int12] = Float4[int11];
                            float30[0] = Float5[int11];
                            int13[0] = Int0[int11];
                            float31[0] = Float6[int11];
                            float32[0] = Float7[int11];
                            return;
                        }
                        Float25[int12] = Float8[int11];
                        if (Int5 <= 10)
                        {
                            float30[0] = Float9[int11];
                            int13[0] = Int1[int11];
                            float31[0] = Float10[int11];
                            float32[0] = Float11[int11];
                            return;
                        }
                        if (Int5 <= 22)
                        {
                            float30[0] = Float12[int11];
                            int13[0] = Int2[int11];
                            float31[0] = Float13[int11];
                            float32[0] = Float14[int11];
                            return;
                        }
                        float30[0] = Float15[int11];
                        int13[0] = Int3[int11];
                        float31[0] = Float16[int11];
                        float32[0] = Float17[int11];
                        return;
                    }
                }
                Float25[int12] = Float18[int11];
                float30[0] = Float19[int11];
                int13[0] = Int4[int11];
                float31[0] = Float20[int11];
                float32[0] = Float21[int11];
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                int num = vmethod_4(class1070);
                Int6 = class820.method_13(num);
                if (class1010 != null)
                {
                    class1010.method_0(Int6, num);
                }
            }

            public virtual void vmethod_6(Class82 class820, Class101 class1010)
            {
                if (Int6 == 0)
                {
                    return;
                }
                Int7 = class820.method_13(2);
                if (class1010 != null)
                {
                    class1010.method_0(Int7, 2);
                }
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                if (Int6 == 0)
                {
                    return;
                }
                switch (Int7)
                {
                    case 0:
                        Float22 = Float0[class820.method_13(6)];
                        Float23 = Float0[class820.method_13(6)];
                        Float24 = Float0[class820.method_13(6)];
                        break;
                    case 1:
                        Float22 = (Float23 = Float0[class820.method_13(6)]);
                        Float24 = Float0[class820.method_13(6)];
                        break;
                    case 2:
                        Float22 = (Float23 = (Float24 = Float0[class820.method_13(6)]));
                        break;
                    case 3:
                        Float22 = Float0[class820.method_13(6)];
                        Float23 = (Float24 = Float0[class820.method_13(6)]);
                        break;
                }
                vmethod_5(class1070, Int6, 0, Float26, Int8, Float28, Float29);
            }

            public override bool vmethod_2(Class82 class820)
            {
                if (Int6 != 0)
                {
                    if (Float25[0] != null)
                    {
                        int num = class820.method_13(Int8[0]);
                        num += num << 1;
                        float[] array = Float27;
                        float[] array2 = Float25[0];
                        int num2 = 0;
                        int num3 = num;
                        if (num3 > array2.Length - 3)
                        {
                            num3 = array2.Length - 3;
                        }
                        array[num2] = array2[num3];
                        num3++;
                        num2++;
                        array[num2] = array2[num3];
                        num3++;
                        num2++;
                        array[num2] = array2[num3];
                    }
                    else
                    {
                        Float27[0] = class820.method_13(Int8[0]) * Float26[0] - 1f;
                        Float27[1] = class820.method_13(Int8[0]) * Float26[0] - 1f;
                        Float27[2] = class820.method_13(Int8[0]) * Float26[0] - 1f;
                    }
                }
                Int10 = 0;
                return ++Int9 == 12;
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                if (Int6 != 0 && enum40 != Enum4.Const2)
                {
                    float num = Float27[Int10];
                    if (Float25[0] == null)
                    {
                        num = (num + Float29[0]) * Float28[0];
                    }
                    if (Int9 <= 4)
                    {
                        num *= Float22;
                    }
                    else if (Int9 <= 8)
                    {
                        num *= Float23;
                    }
                    else
                    {
                        num *= Float24;
                    }
                    class800.method_2(num, Int5);
                }
                return ++Int10 == 3;
            }

            static Class98()
            {
                Float1 = new[]
                {
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    0f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    0f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0.6666667f,
                    0f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    0f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    0f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f
                };
                Float2 = new[]
                {
                    -0.8f,
                    -0.8f,
                    -0.8f,
                    -0.4f,
                    -0.8f,
                    -0.8f,
                    0f,
                    -0.8f,
                    -0.8f,
                    0.4f,
                    -0.8f,
                    -0.8f,
                    0.8f,
                    -0.8f,
                    -0.8f,
                    -0.8f,
                    -0.4f,
                    -0.8f,
                    -0.4f,
                    -0.4f,
                    -0.8f,
                    0f,
                    -0.4f,
                    -0.8f,
                    0.4f,
                    -0.4f,
                    -0.8f,
                    0.8f,
                    -0.4f,
                    -0.8f,
                    -0.8f,
                    0f,
                    -0.8f,
                    -0.4f,
                    0f,
                    -0.8f,
                    0f,
                    0f,
                    -0.8f,
                    0.4f,
                    0f,
                    -0.8f,
                    0.8f,
                    0f,
                    -0.8f,
                    -0.8f,
                    0.4f,
                    -0.8f,
                    -0.4f,
                    0.4f,
                    -0.8f,
                    0f,
                    0.4f,
                    -0.8f,
                    0.4f,
                    0.4f,
                    -0.8f,
                    0.8f,
                    0.4f,
                    -0.8f,
                    -0.8f,
                    0.8f,
                    -0.8f,
                    -0.4f,
                    0.8f,
                    -0.8f,
                    0f,
                    0.8f,
                    -0.8f,
                    0.4f,
                    0.8f,
                    -0.8f,
                    0.8f,
                    0.8f,
                    -0.8f,
                    -0.8f,
                    -0.8f,
                    -0.4f,
                    -0.4f,
                    -0.8f,
                    -0.4f,
                    0f,
                    -0.8f,
                    -0.4f,
                    0.4f,
                    -0.8f,
                    -0.4f,
                    0.8f,
                    -0.8f,
                    -0.4f,
                    -0.8f,
                    -0.4f,
                    -0.4f,
                    -0.4f,
                    -0.4f,
                    -0.4f,
                    0f,
                    -0.4f,
                    -0.4f,
                    0.4f,
                    -0.4f,
                    -0.4f,
                    0.8f,
                    -0.4f,
                    -0.4f,
                    -0.8f,
                    0f,
                    -0.4f,
                    -0.4f,
                    0f,
                    -0.4f,
                    0f,
                    0f,
                    -0.4f,
                    0.4f,
                    0f,
                    -0.4f,
                    0.8f,
                    0f,
                    -0.4f,
                    -0.8f,
                    0.4f,
                    -0.4f,
                    -0.4f,
                    0.4f,
                    -0.4f,
                    0f,
                    0.4f,
                    -0.4f,
                    0.4f,
                    0.4f,
                    -0.4f,
                    0.8f,
                    0.4f,
                    -0.4f,
                    -0.8f,
                    0.8f,
                    -0.4f,
                    -0.4f,
                    0.8f,
                    -0.4f,
                    0f,
                    0.8f,
                    -0.4f,
                    0.4f,
                    0.8f,
                    -0.4f,
                    0.8f,
                    0.8f,
                    -0.4f,
                    -0.8f,
                    -0.8f,
                    0f,
                    -0.4f,
                    -0.8f,
                    0f,
                    0f,
                    -0.8f,
                    0f,
                    0.4f,
                    -0.8f,
                    0f,
                    0.8f,
                    -0.8f,
                    0f,
                    -0.8f,
                    -0.4f,
                    0f,
                    -0.4f,
                    -0.4f,
                    0f,
                    0f,
                    -0.4f,
                    0f,
                    0.4f,
                    -0.4f,
                    0f,
                    0.8f,
                    -0.4f,
                    0f,
                    -0.8f,
                    0f,
                    0f,
                    -0.4f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0.4f,
                    0f,
                    0f,
                    0.8f,
                    0f,
                    0f,
                    -0.8f,
                    0.4f,
                    0f,
                    -0.4f,
                    0.4f,
                    0f,
                    0f,
                    0.4f,
                    0f,
                    0.4f,
                    0.4f,
                    0f,
                    0.8f,
                    0.4f,
                    0f,
                    -0.8f,
                    0.8f,
                    0f,
                    -0.4f,
                    0.8f,
                    0f,
                    0f,
                    0.8f,
                    0f,
                    0.4f,
                    0.8f,
                    0f,
                    0.8f,
                    0.8f,
                    0f,
                    -0.8f,
                    -0.8f,
                    0.4f,
                    -0.4f,
                    -0.8f,
                    0.4f,
                    0f,
                    -0.8f,
                    0.4f,
                    0.4f,
                    -0.8f,
                    0.4f,
                    0.8f,
                    -0.8f,
                    0.4f,
                    -0.8f,
                    -0.4f,
                    0.4f,
                    -0.4f,
                    -0.4f,
                    0.4f,
                    0f,
                    -0.4f,
                    0.4f,
                    0.4f,
                    -0.4f,
                    0.4f,
                    0.8f,
                    -0.4f,
                    0.4f,
                    -0.8f,
                    0f,
                    0.4f,
                    -0.4f,
                    0f,
                    0.4f,
                    0f,
                    0f,
                    0.4f,
                    0.4f,
                    0f,
                    0.4f,
                    0.8f,
                    0f,
                    0.4f,
                    -0.8f,
                    0.4f,
                    0.4f,
                    -0.4f,
                    0.4f,
                    0.4f,
                    0f,
                    0.4f,
                    0.4f,
                    0.4f,
                    0.4f,
                    0.4f,
                    0.8f,
                    0.4f,
                    0.4f,
                    -0.8f,
                    0.8f,
                    0.4f,
                    -0.4f,
                    0.8f,
                    0.4f,
                    0f,
                    0.8f,
                    0.4f,
                    0.4f,
                    0.8f,
                    0.4f,
                    0.8f,
                    0.8f,
                    0.4f,
                    -0.8f,
                    -0.8f,
                    0.8f,
                    -0.4f,
                    -0.8f,
                    0.8f,
                    0f,
                    -0.8f,
                    0.8f,
                    0.4f,
                    -0.8f,
                    0.8f,
                    0.8f,
                    -0.8f,
                    0.8f,
                    -0.8f,
                    -0.4f,
                    0.8f,
                    -0.4f,
                    -0.4f,
                    0.8f,
                    0f,
                    -0.4f,
                    0.8f,
                    0.4f,
                    -0.4f,
                    0.8f,
                    0.8f,
                    -0.4f,
                    0.8f,
                    -0.8f,
                    0f,
                    0.8f,
                    -0.4f,
                    0f,
                    0.8f,
                    0f,
                    0f,
                    0.8f,
                    0.4f,
                    0f,
                    0.8f,
                    0.8f,
                    0f,
                    0.8f,
                    -0.8f,
                    0.4f,
                    0.8f,
                    -0.4f,
                    0.4f,
                    0.8f,
                    0f,
                    0.4f,
                    0.8f,
                    0.4f,
                    0.4f,
                    0.8f,
                    0.8f,
                    0.4f,
                    0.8f,
                    -0.8f,
                    0.8f,
                    0.8f,
                    -0.4f,
                    0.8f,
                    0.8f,
                    0f,
                    0.8f,
                    0.8f,
                    0.4f,
                    0.8f,
                    0.8f,
                    0.8f,
                    0.8f,
                    0.8f
                };
                Float3 = new[]
                {
                    -0.8888889f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0f,
                    -0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    0f,
                    -0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    0f,
                    -0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    0f,
                    -0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0f,
                    -0.8888889f,
                    -0.6666667f,
                    0f,
                    -0.8888889f,
                    -0.444444448f,
                    0f,
                    -0.8888889f,
                    -0.222222224f,
                    0f,
                    -0.8888889f,
                    0f,
                    0f,
                    -0.8888889f,
                    0.222222224f,
                    0f,
                    -0.8888889f,
                    0.444444448f,
                    0f,
                    -0.8888889f,
                    0.6666667f,
                    0f,
                    -0.8888889f,
                    0.8888889f,
                    0f,
                    -0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    0f,
                    0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    0f,
                    0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    0f,
                    0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    0f,
                    0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    0.8888889f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    0f,
                    -0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    0f,
                    -0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    0f,
                    -0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.444444448f,
                    0f,
                    -0.6666667f,
                    -0.222222224f,
                    0f,
                    -0.6666667f,
                    0f,
                    0f,
                    -0.6666667f,
                    0.222222224f,
                    0f,
                    -0.6666667f,
                    0.444444448f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    0.8888889f,
                    0f,
                    -0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    0f,
                    0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    0f,
                    0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    0f,
                    0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    0f,
                    -0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    0f,
                    -0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    0f,
                    -0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    0f,
                    -0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    0f,
                    -0.444444448f,
                    -0.6666667f,
                    0f,
                    -0.444444448f,
                    -0.444444448f,
                    0f,
                    -0.444444448f,
                    -0.222222224f,
                    0f,
                    -0.444444448f,
                    0f,
                    0f,
                    -0.444444448f,
                    0.222222224f,
                    0f,
                    -0.444444448f,
                    0.444444448f,
                    0f,
                    -0.444444448f,
                    0.6666667f,
                    0f,
                    -0.444444448f,
                    0.8888889f,
                    0f,
                    -0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    0f,
                    0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    0f,
                    0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    0f,
                    0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    0f,
                    0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    0f,
                    -0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    0f,
                    -0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    0f,
                    -0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    0f,
                    -0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    0f,
                    -0.222222224f,
                    -0.6666667f,
                    0f,
                    -0.222222224f,
                    -0.444444448f,
                    0f,
                    -0.222222224f,
                    -0.222222224f,
                    0f,
                    -0.222222224f,
                    0f,
                    0f,
                    -0.222222224f,
                    0.222222224f,
                    0f,
                    -0.222222224f,
                    0.444444448f,
                    0f,
                    -0.222222224f,
                    0.6666667f,
                    0f,
                    -0.222222224f,
                    0.8888889f,
                    0f,
                    -0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    0f,
                    0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    0f,
                    0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    0f,
                    0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    0f,
                    0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0f,
                    -0.6666667f,
                    -0.8888889f,
                    0f,
                    -0.444444448f,
                    -0.8888889f,
                    0f,
                    -0.222222224f,
                    -0.8888889f,
                    0f,
                    0f,
                    -0.8888889f,
                    0f,
                    0.222222224f,
                    -0.8888889f,
                    0f,
                    0.444444448f,
                    -0.8888889f,
                    0f,
                    0.6666667f,
                    -0.8888889f,
                    0f,
                    0.8888889f,
                    -0.8888889f,
                    0f,
                    -0.8888889f,
                    -0.6666667f,
                    0f,
                    -0.6666667f,
                    -0.6666667f,
                    0f,
                    -0.444444448f,
                    -0.6666667f,
                    0f,
                    -0.222222224f,
                    -0.6666667f,
                    0f,
                    0f,
                    -0.6666667f,
                    0f,
                    0.222222224f,
                    -0.6666667f,
                    0f,
                    0.444444448f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    0.8888889f,
                    -0.6666667f,
                    0f,
                    -0.8888889f,
                    -0.444444448f,
                    0f,
                    -0.6666667f,
                    -0.444444448f,
                    0f,
                    -0.444444448f,
                    -0.444444448f,
                    0f,
                    -0.222222224f,
                    -0.444444448f,
                    0f,
                    0f,
                    -0.444444448f,
                    0f,
                    0.222222224f,
                    -0.444444448f,
                    0f,
                    0.444444448f,
                    -0.444444448f,
                    0f,
                    0.6666667f,
                    -0.444444448f,
                    0f,
                    0.8888889f,
                    -0.444444448f,
                    0f,
                    -0.8888889f,
                    -0.222222224f,
                    0f,
                    -0.6666667f,
                    -0.222222224f,
                    0f,
                    -0.444444448f,
                    -0.222222224f,
                    0f,
                    -0.222222224f,
                    -0.222222224f,
                    0f,
                    0f,
                    -0.222222224f,
                    0f,
                    0.222222224f,
                    -0.222222224f,
                    0f,
                    0.444444448f,
                    -0.222222224f,
                    0f,
                    0.6666667f,
                    -0.222222224f,
                    0f,
                    0.8888889f,
                    -0.222222224f,
                    0f,
                    -0.8888889f,
                    0f,
                    0f,
                    -0.6666667f,
                    0f,
                    0f,
                    -0.444444448f,
                    0f,
                    0f,
                    -0.222222224f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    0.222222224f,
                    0f,
                    0f,
                    0.444444448f,
                    0f,
                    0f,
                    0.6666667f,
                    0f,
                    0f,
                    0.8888889f,
                    0f,
                    0f,
                    -0.8888889f,
                    0.222222224f,
                    0f,
                    -0.6666667f,
                    0.222222224f,
                    0f,
                    -0.444444448f,
                    0.222222224f,
                    0f,
                    -0.222222224f,
                    0.222222224f,
                    0f,
                    0f,
                    0.222222224f,
                    0f,
                    0.222222224f,
                    0.222222224f,
                    0f,
                    0.444444448f,
                    0.222222224f,
                    0f,
                    0.6666667f,
                    0.222222224f,
                    0f,
                    0.8888889f,
                    0.222222224f,
                    0f,
                    -0.8888889f,
                    0.444444448f,
                    0f,
                    -0.6666667f,
                    0.444444448f,
                    0f,
                    -0.444444448f,
                    0.444444448f,
                    0f,
                    -0.222222224f,
                    0.444444448f,
                    0f,
                    0f,
                    0.444444448f,
                    0f,
                    0.222222224f,
                    0.444444448f,
                    0f,
                    0.444444448f,
                    0.444444448f,
                    0f,
                    0.6666667f,
                    0.444444448f,
                    0f,
                    0.8888889f,
                    0.444444448f,
                    0f,
                    -0.8888889f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    -0.444444448f,
                    0.6666667f,
                    0f,
                    -0.222222224f,
                    0.6666667f,
                    0f,
                    0f,
                    0.6666667f,
                    0f,
                    0.222222224f,
                    0.6666667f,
                    0f,
                    0.444444448f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    0.8888889f,
                    0.6666667f,
                    0f,
                    -0.8888889f,
                    0.8888889f,
                    0f,
                    -0.6666667f,
                    0.8888889f,
                    0f,
                    -0.444444448f,
                    0.8888889f,
                    0f,
                    -0.222222224f,
                    0.8888889f,
                    0f,
                    0f,
                    0.8888889f,
                    0f,
                    0.222222224f,
                    0.8888889f,
                    0f,
                    0.444444448f,
                    0.8888889f,
                    0f,
                    0.6666667f,
                    0.8888889f,
                    0f,
                    0.8888889f,
                    0.8888889f,
                    0f,
                    -0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    0f,
                    -0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    0f,
                    -0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    0f,
                    -0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    0f,
                    -0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    0f,
                    0.222222224f,
                    -0.6666667f,
                    0f,
                    0.222222224f,
                    -0.444444448f,
                    0f,
                    0.222222224f,
                    -0.222222224f,
                    0f,
                    0.222222224f,
                    0f,
                    0f,
                    0.222222224f,
                    0.222222224f,
                    0f,
                    0.222222224f,
                    0.444444448f,
                    0f,
                    0.222222224f,
                    0.6666667f,
                    0f,
                    0.222222224f,
                    0.8888889f,
                    0f,
                    0.222222224f,
                    -0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    -0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    -0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    -0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    0f,
                    0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    0f,
                    0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    0f,
                    0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    0f,
                    0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    0f,
                    -0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    -0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    0f,
                    -0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    -0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    0f,
                    -0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    -0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    0f,
                    -0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    -0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    0f,
                    0.444444448f,
                    -0.6666667f,
                    0f,
                    0.444444448f,
                    -0.444444448f,
                    0f,
                    0.444444448f,
                    -0.222222224f,
                    0f,
                    0.444444448f,
                    0f,
                    0f,
                    0.444444448f,
                    0.222222224f,
                    0f,
                    0.444444448f,
                    0.444444448f,
                    0f,
                    0.444444448f,
                    0.6666667f,
                    0f,
                    0.444444448f,
                    0.8888889f,
                    0f,
                    0.444444448f,
                    -0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    -0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    -0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    -0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    0f,
                    0.222222224f,
                    0.444444448f,
                    0.222222224f,
                    0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    -0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    -0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    -0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    -0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    0f,
                    0.444444448f,
                    0.444444448f,
                    0.222222224f,
                    0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    0f,
                    0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    0f,
                    0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    0f,
                    -0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    -0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    -0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    0f,
                    -0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    -0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    0f,
                    -0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    -0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    -0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    0f,
                    -0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    -0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    -0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    0f,
                    0.6666667f,
                    -0.6666667f,
                    0f,
                    0.6666667f,
                    -0.444444448f,
                    0f,
                    0.6666667f,
                    -0.222222224f,
                    0f,
                    0.6666667f,
                    0f,
                    0f,
                    0.6666667f,
                    0.222222224f,
                    0f,
                    0.6666667f,
                    0.444444448f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    0.8888889f,
                    0f,
                    0.6666667f,
                    -0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    -0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    -0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    -0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    0f,
                    0.222222224f,
                    0.6666667f,
                    0.222222224f,
                    0.222222224f,
                    0.6666667f,
                    0.444444448f,
                    0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    -0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    -0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    -0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    -0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    0f,
                    0.444444448f,
                    0.6666667f,
                    0.222222224f,
                    0.444444448f,
                    0.6666667f,
                    0.444444448f,
                    0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    -0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    -0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    -0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    -0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    0f,
                    0.6666667f,
                    0.6666667f,
                    0.222222224f,
                    0.6666667f,
                    0.6666667f,
                    0.444444448f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    0f,
                    0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    0f,
                    -0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    -0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    -0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    -0.8888889f,
                    0.8888889f,
                    0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    -0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    0f,
                    -0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    -0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    -0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    -0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    0f,
                    -0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    -0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    -0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    -0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    0f,
                    -0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    -0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    -0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    -0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    0f,
                    0.8888889f,
                    -0.6666667f,
                    0f,
                    0.8888889f,
                    -0.444444448f,
                    0f,
                    0.8888889f,
                    -0.222222224f,
                    0f,
                    0.8888889f,
                    0f,
                    0f,
                    0.8888889f,
                    0.222222224f,
                    0f,
                    0.8888889f,
                    0.444444448f,
                    0f,
                    0.8888889f,
                    0.6666667f,
                    0f,
                    0.8888889f,
                    0.8888889f,
                    0f,
                    0.8888889f,
                    -0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    -0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    -0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    -0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    0f,
                    0.222222224f,
                    0.8888889f,
                    0.222222224f,
                    0.222222224f,
                    0.8888889f,
                    0.444444448f,
                    0.222222224f,
                    0.8888889f,
                    0.6666667f,
                    0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    -0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    -0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    -0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    -0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    0f,
                    0.444444448f,
                    0.8888889f,
                    0.222222224f,
                    0.444444448f,
                    0.8888889f,
                    0.444444448f,
                    0.444444448f,
                    0.8888889f,
                    0.6666667f,
                    0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    -0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    -0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    -0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    -0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    0f,
                    0.6666667f,
                    0.8888889f,
                    0.222222224f,
                    0.6666667f,
                    0.8888889f,
                    0.444444448f,
                    0.6666667f,
                    0.8888889f,
                    0.6666667f,
                    0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    -0.8888889f,
                    0.8888889f,
                    0.8888889f,
                    -0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    -0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    -0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    0f,
                    0.8888889f,
                    0.8888889f,
                    0.222222224f,
                    0.8888889f,
                    0.8888889f,
                    0.444444448f,
                    0.8888889f,
                    0.8888889f,
                    0.6666667f,
                    0.8888889f,
                    0.8888889f,
                    0.8888889f,
                    0.8888889f,
                    0.8888889f
                };
                Int0 = new[]
                {
                    0,
                    5,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14,
                    15,
                    16
                };
                Float5 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    0.000122070313f,
                    6.10351563E-05f,
                    3.05175781E-05f
                };
                Float6 = new[]
                {
                    0f,
                    1.33333337f,
                    1.14285719f,
                    1.06666672f,
                    1.032258f,
                    1.01587307f,
                    1.007874f,
                    1.00392163f,
                    1.00195694f,
                    1.00097752f,
                    1.00048852f,
                    1.00024426f,
                    1.00012207f,
                    1.000061f,
                    1.00003052f,
                    1.00001526f
                };
                Float7 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    0.000122070313f,
                    6.103516E-05f,
                    3.051758E-05f
                };
                Int1 = new[]
                {
                    0,
                    5,
                    7,
                    3,
                    10,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    16
                };
                Float9 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    0.25f,
                    0.125f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    3.05175781E-05f
                };
                Float10 = new[]
                {
                    0f,
                    1.33333337f,
                    1.6f,
                    1.14285719f,
                    1.77777779f,
                    1.06666672f,
                    1.032258f,
                    1.01587307f,
                    1.007874f,
                    1.00392163f,
                    1.00195694f,
                    1.00097752f,
                    1.00048852f,
                    1.00024426f,
                    1.00012207f,
                    1.00001526f
                };
                Float11 = new[]
                {
                    0f,
                    0.5f,
                    0.5f,
                    0.25f,
                    0.5f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    3.051758E-05f
                };
                Int2 = new[]
                {
                    0,
                    5,
                    7,
                    3,
                    10,
                    4,
                    5,
                    16
                };
                Float12 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    0.25f,
                    0.125f,
                    0.125f,
                    0.0625f,
                    3.05175781E-05f
                };
                Float13 = new[]
                {
                    0f,
                    1.33333337f,
                    1.6f,
                    1.14285719f,
                    1.77777779f,
                    1.06666672f,
                    1.032258f,
                    1.00001526f
                };
                Float14 = new[]
                {
                    0f,
                    0.5f,
                    0.5f,
                    0.25f,
                    0.5f,
                    0.125f,
                    0.0625f,
                    3.051758E-05f
                };
                Int3 = new[]
                {
                    0,
                    5,
                    7,
                    16
                };
                Float15 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    3.05175781E-05f
                };
                Float16 = new[]
                {
                    0f,
                    1.33333337f,
                    1.6f,
                    1.00001526f
                };
                Float17 = new[]
                {
                    0f,
                    0.5f,
                    0.5f,
                    3.051758E-05f
                };
                Int4 = new[]
                {
                    0,
                    5,
                    7,
                    10,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14,
                    15
                };
                Float19 = new[]
                {
                    0f,
                    0.5f,
                    0.25f,
                    0.125f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    0.000122070313f,
                    6.10351563E-05f
                };
                Float20 = new[]
                {
                    0f,
                    1.33333337f,
                    1.6f,
                    1.77777779f,
                    1.06666672f,
                    1.032258f,
                    1.01587307f,
                    1.007874f,
                    1.00392163f,
                    1.00195694f,
                    1.00097752f,
                    1.00048852f,
                    1.00024426f,
                    1.00012207f,
                    1.000061f,
                    1.00003052f
                };
                Float21 = new[]
                {
                    0f,
                    0.5f,
                    0.5f,
                    0.5f,
                    0.125f,
                    0.0625f,
                    0.03125f,
                    0.015625f,
                    0.0078125f,
                    0.00390625f,
                    0.001953125f,
                    0.0009765625f,
                    0.00048828125f,
                    0.000244140625f,
                    0.000122070313f,
                    6.103516E-05f
                };
                float[][] array = new float[16][];
                array[1] = Float1;
                Float4 = array;
                float[][] array2 = new float[16][];
                array2[1] = Float1;
                array2[2] = Float2;
                array2[4] = Float3;
                Float8 = array2;
                float[][] array3 = new float[16][];
                array3[1] = Float1;
                array3[2] = Float2;
                array3[3] = Float3;
                Float18 = array3;
            }
        }

        public class Class99 : Class98
        {
            public int Int11;

            public float Float30;

            public float Float31;

            public float Float32;

            public Class99(int int12) : base(int12)
            {
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                base.vmethod_0(class820, class1070, class1010);
            }

            public override void vmethod_6(Class82 class820, Class101 class1010)
            {
                if (Int6 == 0)
                {
                    return;
                }
                Int7 = class820.method_13(2);
                Int11 = class820.method_13(2);
                if (class1010 != null)
                {
                    class1010.method_0(Int7, 2);
                    class1010.method_0(Int11, 2);
                }
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                if (Int6 == 0)
                {
                    return;
                }
                base.vmethod_1(class820, class1070);
                switch (Int11)
                {
                    case 0:
                        Float30 = Float0[class820.method_13(6)];
                        Float31 = Float0[class820.method_13(6)];
                        Float32 = Float0[class820.method_13(6)];
                        return;
                    case 1:
                        Float30 = (Float31 = Float0[class820.method_13(6)]);
                        Float32 = Float0[class820.method_13(6)];
                        return;
                    case 2:
                        Float30 = (Float31 = (Float32 = Float0[class820.method_13(6)]));
                        return;
                    case 3:
                        Float30 = Float0[class820.method_13(6)];
                        Float31 = (Float32 = Float0[class820.method_13(6)]);
                        return;
                    default:
                        return;
                }
            }

            public override bool vmethod_2(Class82 class820)
            {
                return base.vmethod_2(class820);
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                if (Int6 != 0)
                {
                    float num = Float27[Int10];
                    if (Float25[0] == null)
                    {
                        num = (num + Float29[0]) * Float28[0];
                    }
                    if (enum40 == Enum4.Const0)
                    {
                        float num2 = num;
                        if (Int9 <= 4)
                        {
                            num *= Float22;
                            num2 *= Float30;
                        }
                        else if (Int9 <= 8)
                        {
                            num *= Float23;
                            num2 *= Float31;
                        }
                        else
                        {
                            num *= Float24;
                            num2 *= Float32;
                        }
                        class800.method_2(num, Int5);
                        class801.method_2(num2, Int5);
                    }
                    else if (enum40 == Enum4.Const1)
                    {
                        if (Int9 <= 4)
                        {
                            num *= Float22;
                        }
                        else if (Int9 <= 8)
                        {
                            num *= Float23;
                        }
                        else
                        {
                            num *= Float24;
                        }
                        class800.method_2(num, Int5);
                    }
                    else
                    {
                        if (Int9 <= 4)
                        {
                            num *= Float30;
                        }
                        else if (Int9 <= 8)
                        {
                            num *= Float31;
                        }
                        else
                        {
                            num *= Float32;
                        }
                        class800.method_2(num, Int5);
                    }
                }
                return ++Int10 == 3;
            }
        }

        public class Class100 : Class98
        {
            public int Int11;

            public int Int12;

            public float Float30;

            public float Float31;

            public float Float32;

            public int[] Int13;

            public float[] Float33;

            public float[] Float34;

            public float[] Float35;

            public float[] Float36;

            public Class100(int int14) : base(int14)
            {
                int[] array = new int[1];
                Int13 = array;
                float[] array2 = new float[1];
                Float33 = array2;
                float[] array3 = new float[1];
                Float35 = array3;
                float[] array4 = new float[1];
                Float36 = array4;
                //base..ctor(int_14);
                Float34 = new float[3];
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                int num = vmethod_4(class1070);
                Int6 = class820.method_13(num);
                Int11 = class820.method_13(num);
                if (class1010 != null)
                {
                    class1010.method_0(Int6, num);
                    class1010.method_0(Int11, num);
                }
            }

            public override void vmethod_6(Class82 class820, Class101 class1010)
            {
                if (Int6 != 0)
                {
                    Int7 = class820.method_13(2);
                    if (class1010 != null)
                    {
                        class1010.method_0(Int7, 2);
                    }
                }
                if (Int11 != 0)
                {
                    Int12 = class820.method_13(2);
                    if (class1010 != null)
                    {
                        class1010.method_0(Int12, 2);
                    }
                }
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                base.vmethod_1(class820, class1070);
                if (Int11 != 0)
                {
                    switch (Int12)
                    {
                        case 0:
                            Float30 = Float0[class820.method_13(6)];
                            Float31 = Float0[class820.method_13(6)];
                            Float32 = Float0[class820.method_13(6)];
                            break;
                        case 1:
                            Float30 = (Float31 = Float0[class820.method_13(6)]);
                            Float32 = Float0[class820.method_13(6)];
                            break;
                        case 2:
                            Float30 = (Float31 = (Float32 = Float0[class820.method_13(6)]));
                            break;
                        case 3:
                            Float30 = Float0[class820.method_13(6)];
                            Float31 = (Float32 = Float0[class820.method_13(6)]);
                            break;
                    }
                    vmethod_5(class1070, Int11, 1, Float33, Int13, Float35, Float36);
                }
            }

            public override bool vmethod_2(Class82 class820)
            {
                bool result = base.vmethod_2(class820);
                if (Int11 != 0)
                {
                    if (Float25[1] != null)
                    {
                        int num = class820.method_13(Int13[0]);
                        num += num << 1;
                        float[] array = Float34;
                        float[] array2 = Float25[1];
                        int num2 = num;
                        array[0] = array2[num2++];
                        array[1] = array2[num2++];
                        array[2] = array2[num2];
                    }
                    else
                    {
                        Float34[0] = class820.method_13(Int13[0]) * Float33[0] - 1f;
                        Float34[1] = class820.method_13(Int13[0]) * Float33[0] - 1f;
                        Float34[2] = class820.method_13(Int13[0]) * Float33[0] - 1f;
                    }
                }
                return result;
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                bool result = base.vmethod_3(enum40, class800, class801);
                if (Int11 != 0 && enum40 != Enum4.Const1)
                {
                    float num = Float34[Int10 - 1];
                    if (Float25[1] == null)
                    {
                        num = (num + Float36[0]) * Float35[0];
                    }
                    if (Int9 <= 4)
                    {
                        num *= Float30;
                    }
                    else if (Int9 <= 8)
                    {
                        num *= Float31;
                    }
                    else
                    {
                        num *= Float32;
                    }
                    if (enum40 == Enum4.Const0)
                    {
                        class801.method_2(num, Int5);
                    }
                    else
                    {
                        class800.method_2(num, Int5);
                    }
                }
                return result;
            }
        }

        public override void vmethod_1()
        {
            switch (Enum50)
            {
                case Enum5.Const1:
                {
                    int i;
                    for (i = 0; i < Class1070.method_26(); i++)
                    {
                        Class940[i] = new Class100(i);
                    }
                    while (i < Int0)
                    {
                        Class940[i] = new Class99(i);
                        i++;
                    }
                    return;
                }
                case Enum5.Const3:
                    for (int i = 0; i < Int0; i++)
                    {
                        Class940[i] = new Class98(i);
                    }
                    return;
            }
            for (int i = 0; i < Int0; i++)
            {
                Class940[i] = new Class100(i);
            }
        }

        public override void vmethod_3()
        {
            for (int i = 0; i < Int0; i++)
            {
                ((Class98) Class940[i]).vmethod_6(Class820, Class1010);
            }
        }
    }
}