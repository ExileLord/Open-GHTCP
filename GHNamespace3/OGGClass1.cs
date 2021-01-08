using System;
using GHNamespaceD;
using GHNamespaceH;

namespace GHNamespace3
{
    public class OggClass1
    {
        private static readonly float Float0 = 3.14159274f;

        private static readonly int Int0 = 1;

        private static readonly int Int1 = 1;

        public int Int2;

        public OggClass5 OggClass5;

        public int Int3;

        private float[][] _float1;

        private int _int4;

        private int _int5;

        private int _int6;

        private int _int8;

        private int _int9;

        private int _int11;

        private long _long0;

        public long Long1;

        private long _long2;

        private long _long3;

        private long _long4;

        private long _long5;

        public float[][][][][] Float2;

        public object[][] Object0;

        public OggClass4[] OggClass4;

        public object[] Object1;

        public OggClass1()
        {
            Object0 = new object[2][];
            Float2 = new float[2][][][][];
            Float2[0] = new float[2][][][];
            Float2[0][0] = new float[2][][];
            Float2[0][1] = new float[2][][];
            Float2[0][0][0] = new float[2][];
            Float2[0][0][1] = new float[2][];
            Float2[0][1][0] = new float[2][];
            Float2[0][1][1] = new float[2][];
            Float2[1] = new float[2][][][];
            Float2[1][0] = new float[2][][];
            Float2[1][1] = new float[2][][];
            Float2[1][0][0] = new float[2][];
            Float2[1][0][1] = new float[2][];
            Float2[1][1][0] = new float[2][];
            Float2[1][1][1] = new float[2][];
        }

        private static int smethod_0(int int12)
        {
            var num = 0;
            while (int12 > 1)
            {
                num++;
                int12 = (int) ((uint) int12 >> 1);
            }
            return num;
        }

        public static float[] smethod_1(int int12, int int13, int int14, int int15)
        {
            var array = new float[int13];
            if (int12 == 0)
            {
                var num = (int13 >> 2) - (int14 >> 1);
                var num2 = int13 - (int13 >> 2) - (int15 >> 1);
                for (var i = 0; i < int14; i++)
                {
                    var num3 = (float) ((i + 0.5) / int14 * Float0 / 2.0);
                    num3 = (float) Math.Sin(num3);
                    num3 *= num3;
                    num3 *= (float) (Float0 / 2.0);
                    num3 = (float) Math.Sin(num3);
                    array[i + num] = num3;
                }
                for (var j = num + int14; j < num2; j++)
                {
                    array[j] = 1f;
                }
                for (var k = 0; k < int15; k++)
                {
                    var num4 = (float) ((int15 - k - 0.5) / int15 * Float0 / 2.0);
                    num4 = (float) Math.Sin(num4);
                    num4 *= num4;
                    num4 *= (float) (Float0 / 2.0);
                    num4 = (float) Math.Sin(num4);
                    array[k + num2] = num4;
                }
                return array;
            }
            return null;
        }

        private int method_0(OggClass5 oggClass5, bool bool0)
        {
            OggClass5 = oggClass5;
            Int3 = smethod_0(oggClass5.Int14);
            Object0[0] = new object[Int0];
            Object0[1] = new object[Int0];
            Object0[0][0] = new Class68();
            Object0[1][0] = new Class68();
            ((Class68) Object0[0][0]).method_0(oggClass5.Int13[0]);
            ((Class68) Object0[1][0]).method_0(oggClass5.Int13[1]);
            Float2[0][0][0] = new float[Int1][];
            Float2[0][0][1] = Float2[0][0][0];
            Float2[0][1][0] = Float2[0][0][0];
            Float2[0][1][1] = Float2[0][0][0];
            Float2[1][0][0] = new float[Int1][];
            Float2[1][0][1] = new float[Int1][];
            Float2[1][1][0] = new float[Int1][];
            Float2[1][1][1] = new float[Int1][];
            for (var i = 0; i < Int1; i++)
            {
                Float2[0][0][0][i] = smethod_1(i, oggClass5.Int13[0], oggClass5.Int13[0] >> 1, oggClass5.Int13[0] >> 1);
                Float2[1][0][0][i] = smethod_1(i, oggClass5.Int13[1], oggClass5.Int13[0] >> 1, oggClass5.Int13[0] >> 1);
                Float2[1][0][1][i] = smethod_1(i, oggClass5.Int13[1], oggClass5.Int13[0] >> 1, oggClass5.Int13[1] >> 1);
                Float2[1][1][0][i] = smethod_1(i, oggClass5.Int13[1], oggClass5.Int13[1] >> 1, oggClass5.Int13[0] >> 1);
                Float2[1][1][1][i] = smethod_1(i, oggClass5.Int13[1], oggClass5.Int13[1] >> 1, oggClass5.Int13[1] >> 1);
            }
            OggClass4 = new OggClass4[oggClass5.Int19];
            for (var j = 0; j < oggClass5.Int19; j++)
            {
                OggClass4[j] = new OggClass4();
                OggClass4[j].method_6(oggClass5.OggClass2[j]);
            }
            _int4 = 8192;
            _float1 = new float[oggClass5.Int8][];
            for (var k = 0; k < oggClass5.Int8; k++)
            {
                _float1[k] = new float[_int4];
            }
            _int8 = 0;
            _int9 = 0;
            _int11 = oggClass5.Int13[1] >> 1;
            _int5 = _int11;
            Object1 = new object[oggClass5.Int14];
            for (var l = 0; l < oggClass5.Int14; l++)
            {
                var num = oggClass5.Class270[l].Int3;
                var num2 = oggClass5.Int21[num];
                Object1[l] = Class34.Class340[num2].vmethod_1(this, oggClass5.Class270[l], oggClass5.Object0[num]);
            }
            return 0;
        }

        public int method_1(OggClass5 oggClass5)
        {
            method_0(oggClass5, false);
            _int6 = _int11;
            _int11 -= (oggClass5.Int13[_int9] >> 2) + (oggClass5.Int13[_int8] >> 2);
            _long0 = -1L;
            Long1 = -1L;
            return 0;
        }

        public int method_2(OggClass6 class710)
        {
            if (_int11 > OggClass5.Int13[1] >> 1 && _int6 > 8192)
            {
                var num = _int11 - (OggClass5.Int13[1] >> 1);
                num = ((_int6 < num) ? _int6 : num);
                _int5 -= num;
                _int11 -= num;
                _int6 -= num;
                if (num != 0)
                {
                    for (var i = 0; i < OggClass5.Int8; i++)
                    {
                        Buffer.BlockCopy(_float1[i], num << 2, _float1[i], 0, _int5 << 2);
                    }
                }
            }
            _int8 = _int9;
            _int9 = class710.Int1;
            _long2 += class710.Int6;
            _long3 += class710.Int7;
            _long4 += class710.Int8;
            _long5 += class710.Int9;
            if (Long1 + 1L != class710.Long1)
            {
                _long0 = -1L;
            }
            Long1 = class710.Long1;
            var num2 = OggClass5.Int13[_int9];
            var num3 = _int11 + (OggClass5.Int13[_int8] >> 2) + (num2 >> 2);
            var num4 = num3 - (num2 >> 1);
            var num5 = num4 + num2;
            var num6 = 0;
            var num7 = 0;
            if (num5 > _int4)
            {
                _int4 = num5 + OggClass5.Int13[1];
                for (var j = 0; j < OggClass5.Int8; j++)
                {
                    var array = new float[_int4];
                    Buffer.BlockCopy(_float1[j], 0, array, 0, _float1[j].Length << 2);
                    _float1[j] = array;
                }
            }
            switch (_int9)
            {
                case 0:
                    num6 = 0;
                    num7 = OggClass5.Int13[0] >> 1;
                    break;
                case 1:
                    num6 = (OggClass5.Int13[1] >> 2) - (OggClass5.Int13[_int8] >> 2);
                    num7 = num6 + (OggClass5.Int13[_int8] >> 1);
                    break;
            }
            for (var k = 0; k < OggClass5.Int8; k++)
            {
                var num8 = num4;
                int l;
                for (l = num6; l < num7; l++)
                {
                    _float1[k][num8 + l] += class710.Float0[k][l];
                }
                while (l < num2)
                {
                    _float1[k][num8 + l] = class710.Float0[k][l];
                    l++;
                }
            }
            if (_long0 == -1L)
            {
                _long0 = class710.Long0;
            }
            else
            {
                _long0 += num3 - _int11;
                if (class710.Long0 != -1L && _long0 != class710.Long0)
                {
                    if (_long0 > class710.Long0 && class710.Int5 != 0)
                    {
                        num3 -= (int) (_long0 - class710.Long0);
                    }
                    _long0 = class710.Long0;
                }
            }
            _int11 = num3;
            _int5 = num5;
            return 0;
        }

        public int method_3()
        {
            if (_int6 < _int11)
            {
                return _int11 - _int6;
            }
            return 0;
        }

        public int method_4(float[] float3, int int12, int int13)
        {
            if (_int6 < _int11)
            {
                var num = _float1.Length;
                var num2 = _int11 - _int6;
                var num3 = (int13 - int12) / num;
                if (num2 > num3)
                {
                    num2 = num3;
                }
                var num4 = _int6 + num2;
                for (var i = 0; i < _float1.Length; i++)
                {
                    var array = _float1[i];
                    var j = _int6;
                    var num5 = int12 + i;
                    while (j < num4)
                    {
                        float3[num5] = array[j];
                        j++;
                        num5 += num;
                    }
                }
                return num2;
            }
            return 0;
        }

        public int method_5(float[][] float3, int int12, int int13)
        {
            if (_int6 < _int11)
            {
                var num = _int11 - _int6;
                if (num > int13 - int12)
                {
                    num = int13 - int12;
                }
                for (var i = 0; i < OggClass5.Int8; i++)
                {
                    Buffer.BlockCopy(_float1[i], _int6 << 2, float3[i], int12 << 2, num << 2);
                }
                return num;
            }
            return 0;
        }

        public int method_6(int int12)
        {
            if (int12 != 0 && _int6 + int12 > _int11)
            {
                return -1;
            }
            _int6 += int12;
            return 0;
        }

        public void method_7()
        {
        }
    }
}