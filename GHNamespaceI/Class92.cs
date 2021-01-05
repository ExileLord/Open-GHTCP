using GHNamespaceJ;
using SharpAudio.ASC.Mp3.Decoding;

namespace GHNamespaceI
{
    public class Class92 : INterface7
    {
        public abstract class Class94
        {
            public static readonly float[] Float0 =
            {
                2f,
                1.587401f,
                1.25992107f,
                1f,
                0.7937005f,
                0.629960537f,
                0.5f,
                0.396850258f,
                0.314980268f,
                0.25f,
                0.198425129f,
                0.157490134f,
                0.125f,
                0.0992125645f,
                0.07874507f,
                0.0625f,
                0.0496062823f,
                0.0393725336f,
                0.03125f,
                0.0248031411f,
                0.0196862668f,
                0.015625f,
                0.0124015706f,
                0.009843133f,
                0.0078125f,
                0.00620078528f,
                0.00492156669f,
                0.00390625f,
                0.00310039264f,
                0.00246078335f,
                0.001953125f,
                0.00155019632f,
                0.00123039167f,
                0.0009765625f,
                0.00077509816f,
                0.000615195837f,
                0.00048828125f,
                0.00038754908f,
                0.000307597918f,
                0.000244140625f,
                0.00019377454f,
                0.000153798959f,
                0.000122070313f,
                9.688727E-05f,
                7.689948E-05f,
                6.10351563E-05f,
                4.8443635E-05f,
                3.844974E-05f,
                3.05175781E-05f,
                2.42218175E-05f,
                1.922487E-05f,
                1.52587891E-05f,
                1.21109088E-05f,
                9.612435E-06f,
                7.62939453E-06f,
                6.05545438E-06f,
                4.80621748E-06f,
                3.81469727E-06f,
                3.02772719E-06f,
                2.40310874E-06f,
                1.90734863E-06f,
                1.51386359E-06f,
                1.20155437E-06f,
                0f
            };

            public abstract void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010);

            public abstract void vmethod_1(Class82 class820, ZzSoundClass class1070);

            public abstract bool vmethod_2(Class82 class820);

            public abstract bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801);
        }

        public class Class95 : Class94
        {
            public static readonly float[] Float1 =
            {
                0f,
                0.6666667f,
                0.2857143f,
                0.13333334f,
                0.06451613f,
                0.0317460336f,
                0.0157480314f,
                0.007843138f,
                0.0039138943f,
                0.00195503421f,
                0.0009770396f,
                0.0004884005f,
                0.000244170427f,
                0.000122077763f,
                6.103702E-05f
            };

            public static readonly float[] Float2 =
            {
                0f,
                -0.6666667f,
                -0.857142866f,
                -0.933333337f,
                -0.9677419f,
                -0.984127f,
                -0.992126f,
                -0.996078432f,
                -0.99804306f,
                -0.9990225f,
                -0.9995115f,
                -0.9997558f,
                -0.9998779f,
                -0.999938965f,
                -0.9999695f
            };

            public readonly int Int0;

            public int Int1;

            public int Int2;

            public float Float3;

            public int Int3;

            public float Float4;

            public float Float5;

            public float Float6;

            public Class95(int int4)
            {
                Int0 = int4;
                Int1 = 0;
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                if ((Int2 = class820.method_13(4)) == 15)
                {
                    throw new DecoderException(DecoderError.IllegalSubbandAllocation, null);
                }
                if (class1010 != null)
                {
                    class1010.method_0(Int2, 4);
                }
                if (Int2 != 0)
                {
                    Int3 = Int2 + 1;
                    Float5 = Float1[Int2];
                    Float6 = Float2[Int2];
                }
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                if (Int2 != 0)
                {
                    Float3 = Float0[class820.method_13(6)];
                }
            }

            public override bool vmethod_2(Class82 class820)
            {
                if (Int2 != 0)
                {
                    Float4 = class820.method_13(Int3);
                }
                if (++Int1 == 12)
                {
                    Int1 = 0;
                    return true;
                }
                return false;
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                if (Int2 != 0 && enum40 != Enum4.Const2)
                {
                    var float_ = (Float4 * Float5 + Float6) * Float3;
                    class800.method_2(float_, Int0);
                }
                return true;
            }
        }

        public class Class96 : Class95
        {
            public float Float7;

            public Class96(int int4) : base(int4)
            {
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                base.vmethod_0(class820, class1070, class1010);
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                if (Int2 == 0)
                {
                    return;
                }
                Float3 = Float0[class820.method_13(6)];
                Float7 = Float0[class820.method_13(6)];
            }

            public override bool vmethod_2(Class82 class820)
            {
                return base.vmethod_2(class820);
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                if (Int2 != 0)
                {
                    Float4 = Float4 * Float5 + Float6;
                    switch (enum40)
                    {
                        case Enum4.Const0:
                            class800.method_2(Float4 * Float3, Int0);
                            class801.method_2(Float4 * Float7, Int0);
                            break;
                        case Enum4.Const1:
                            class800.method_2(Float4 * Float3, Int0);
                            break;
                        default:
                            class800.method_2(Float4 * Float7, Int0);
                            break;
                    }
                }
                return true;
            }
        }

        public class Class97 : Class95
        {
            public int Int4;

            public float Float7;

            public int Int5;

            public float Float8;

            public float Float9;

            public float Float10;

            public Class97(int int6) : base(int6)
            {
            }

            public override void vmethod_0(Class82 class820, ZzSoundClass class1070, Class101 class1010)
            {
                Int2 = class820.method_13(4);
                Int4 = class820.method_13(4);
                if (class1010 != null)
                {
                    class1010.method_0(Int2, 4);
                    class1010.method_0(Int4, 4);
                }
                if (Int2 != 0)
                {
                    Int3 = Int2 + 1;
                    Float5 = Float1[Int2];
                    Float6 = Float2[Int2];
                }
                if (Int4 != 0)
                {
                    Int5 = Int4 + 1;
                    Float9 = Float1[Int4];
                    Float10 = Float2[Int4];
                }
            }

            public override void vmethod_1(Class82 class820, ZzSoundClass class1070)
            {
                if (Int2 != 0)
                {
                    Float3 = Float0[class820.method_13(6)];
                }
                if (Int4 != 0)
                {
                    Float7 = Float0[class820.method_13(6)];
                }
            }

            public override bool vmethod_2(Class82 class820)
            {
                var result = base.vmethod_2(class820);
                if (Int4 != 0)
                {
                    Float8 = class820.method_13(Int5);
                }
                return result;
            }

            public override bool vmethod_3(Enum4 enum40, Class80 class800, Class80 class801)
            {
                base.vmethod_3(enum40, class800, class801);
                if (Int4 != 0 && enum40 != Enum4.Const1)
                {
                    var num = (Float8 * Float9 + Float10) * Float7;
                    if (enum40 == Enum4.Const0)
                    {
                        class801.method_2(num, Int0);
                    }
                    else
                    {
                        class800.method_2(num, Int0);
                    }
                }
                return true;
            }
        }

        public Class82 Class820;

        public ZzSoundClass Class1070;

        public Class80 Class800;

        public Class80 Class801;

        public Class84 Class840;

        public Enum4 Enum40;

        public Enum5 Enum50;

        public int Int0;

        public Class94[] Class940;

        public readonly Class101 Class1010;

        public Class92()
        {
            Class1010 = new Class101();
        }

        public virtual void vmethod_0(Class82 class821, ZzSoundClass class1071, Class80 class802, Class80 class803,
            Class84 class841, Enum4 enum41)
        {
            Class820 = class821;
            Class1070 = class1071;
            Class800 = class802;
            Class801 = class803;
            Class840 = class841;
            Enum40 = enum41;
        }

        public virtual void imethod_0()
        {
            try
            {
                Int0 = Class1070.method_25();
                Class940 = new Class94[32];
                Enum50 = Class1070.method_8();
                vmethod_1();
                vmethod_2();
                vmethod_3();
                if (Class1010 != null || Class1070.method_12())
                {
                    vmethod_4();
                    vmethod_5();
                }
            }
            catch
            {
            }
        }

        public virtual void vmethod_1()
        {
            if (Enum50 == Enum5.Const3)
            {
                for (var i = 0; i < Int0; i++)
                {
                    Class940[i] = new Class95(i);
                }
                return;
            }
            if (Enum50 == Enum5.Const1)
            {
                int i;
                for (i = 0; i < Class1070.method_26(); i++)
                {
                    Class940[i] = new Class97(i);
                }
                while (i < Int0)
                {
                    Class940[i] = new Class96(i);
                    i++;
                }
                return;
            }
            for (var i = 0; i < Int0; i++)
            {
                Class940[i] = new Class97(i);
            }
        }

        public virtual void vmethod_2()
        {
            for (var i = 0; i < Int0; i++)
            {
                Class940[i].vmethod_0(Class820, Class1070, Class1010);
            }
        }

        public virtual void vmethod_3()
        {
        }

        public virtual void vmethod_4()
        {
            for (var i = 0; i < Int0; i++)
            {
                Class940[i].vmethod_1(Class820, Class1070);
            }
        }

        public virtual void vmethod_5()
        {
            var flag = false;
            var flag2 = false;
            var @enum = Class1070.method_8();
            do
            {
                for (var i = 0; i < Int0; i++)
                {
                    flag = Class940[i].vmethod_2(Class820);
                }
                do
                {
                    for (var i = 0; i < Int0; i++)
                    {
                        flag2 = Class940[i].vmethod_3(Enum40, Class800, Class801);
                    }
                    Class800.method_22(Class840);
                    if (Enum40 == Enum4.Const0 && @enum != Enum5.Const3)
                    {
                        Class801.method_22(Class840);
                    }
                } while (!flag2);
            } while (!flag);
        }
    }
}