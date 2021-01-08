using System;
using GHNamespace2;
using GHNamespaceM;

namespace GHNamespace5
{
    public class Class173 : Class172
    {
        public enum Enum26
        {
            Const0 = 1,
            Const1,
            Const2
        }

        public enum Enum27
        {
            Const0 = -2,
            Const1 = 1,
            Const2,
            Const3
        }

        private readonly Enum26 _enum260;

        private readonly Enum27 _enum270;

        private readonly bool _bool0;

        private readonly float _float0;

        private readonly float _float1;

        private readonly Struct11[] _struct110;

        public Class173(Enum26 enum261, Enum27 enum271, float float2, bool bool1, Struct11[] struct111)
        {
            _enum260 = enum261;
            _enum270 = enum271;
            _float0 = float2;
            _float1 = 1f - float2;
            _bool0 = bool1;
            _struct110 = struct111;
        }

        public Class173(Enum26 enum261, Struct11[] struct111) : this(enum261, Enum27.Const1, 0f, false, struct111)
        {
        }

        private float method_0(float float2)
        {
            switch (_enum270)
            {
                case Enum27.Const0:
                    return (float) Math.Sqrt(float2);
                case Enum27.Const1:
                    return float2;
                case Enum27.Const2:
                    return float2 * float2;
                case Enum27.Const3:
                    return float2 * float2 * float2;
            }
            return float2;
        }

        public override void vmethod_0(Class13 class130)
        {
            var @struct = new Struct11(class130.Int0 + class130.method_0(),
                class130.Int0 + class130.method_0() + class130.method_2());
            if (_struct110.Length != 0)
            {
                var array = _struct110;
                for (var i = 0; i < array.Length; i++)
                {
                    var struct2 = array[i];
                    var struct3 = struct2.method_0(@struct);
                    if (!struct3.method_1())
                    {
                        method_1(ref class130.Float0, struct3.method_2() - class130.Int0, struct3.method_3(),
                            struct3.method_2() - struct2.method_2(), struct2.method_3());
                    }
                }
                return;
            }
            method_1(ref class130.Float0, class130.method_0(), class130.method_2(), 0, class130.method_2());
        }

        private void method_1(ref float[] float2, int int0, int int1, int int2, float float3)
        {
            switch (_enum260)
            {
                case Enum26.Const0:
                    try
                    {
                        for (var i = 0; i < int1; i++)
                        {
                            float2[int0 + i] *= method_0((int2 + i) / float3) * _float1 + _float0;
                        }
                        if (_bool0)
                        {
                            for (var j = 0; j < int0; j++)
                            {
                                float2[j] *= _float0;
                            }
                        }
                        return;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        return;
                    }
                case Enum26.Const1:
                    break;
                case Enum26.Const2:
                    goto IL_117;
                default:
                    return;
            }
            try
            {
                for (var k = 0; k < int1; k++)
                {
                    float2[int0 + k] *= method_0(1f - (int2 + k) / float3) * _float1 + _float0;
                }
                if (_bool0)
                {
                    for (var l = int0 + int1; l < float2.Length; l++)
                    {
                        float2[l] *= _float0;
                    }
                }
                return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            IL_117:
            var num = int1 / 2;
            float3 = num;
            var array = new float[float2.Length - num];
            try
            {
                for (var m = 0; m < num; m++)
                {
                    float2[int0 + m] = method_0((num - m) / float3) * float2[int0 + m] +
                                       method_0(m / float3) * float2[int0 + num + m];
                }
                for (var n = 0; n < int0 + num; n++)
                {
                    array[n] = float2[n];
                }
                for (var num2 = int0 + int1; num2 < float2.Length; num2++)
                {
                    array[num2 - num] = float2[num2];
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            float2 = array;
        }
    }
}