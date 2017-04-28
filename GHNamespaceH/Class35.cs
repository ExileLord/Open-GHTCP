using GHNamespace3;
using GHNamespaceD;

namespace GHNamespaceH
{
    public class Class35 : Class34
    {
        private readonly object _object0 = new object();

        private float[][] _float0;

        private int[] _int0;

        private int[] _int1;

        private object[] _object1;

        public override void vmethod_2(object object2)
        {
        }

        public override object vmethod_1(OggClass1 class660, Class27 class270, object object2)
        {
            var class49 = class660.OggClass5;
            var @class = new Class55();
            var class2 = @class.Class540 = (Class54) object2;
            @class.Class270 = class270;
            @class.Object0 = new object[class2.Int0];
            @class.Object1 = new object[class2.Int0];
            @class.Object2 = new object[class2.Int0];
            @class.Class500 = new Class50[class2.Int0];
            @class.Class280 = new Class28[class2.Int0];
            @class.Class230 = new Class23[class2.Int0];
            for (var i = 0; i < class2.Int0; i++)
            {
                var num = class2.Int2[i];
                var num2 = class2.Int3[i];
                var num3 = class2.Int4[i];
                @class.Class500[i] = Class50.Class500[class49.Int22[num]];
                @class.Object0[i] = @class.Class500[i].vmethod_1(class660, class270, class49.Object1[num]);
                @class.Class280[i] = Class28.Class280[class49.Int23[num2]];
                @class.Object1[i] = @class.Class280[i].vmethod_1(class660, class270, class49.Object2[num2]);
                @class.Class230[i] = Class23.Class230[class49.Int24[num3]];
                @class.Object2[i] = @class.Class230[i].vmethod_1(class660, class270, class49.Object3[num3]);
            }
            if (class49.Int20 == 0)
            {
            }
            @class.Int0 = class49.Int8;
            return @class;
        }

        public override object vmethod_0(OggClass5 class490, OggClass3 class380)
        {
            var @class = new Class54();
            if (class380.method_6(1) != 0)
            {
                @class.Int0 = class380.method_6(4) + 1;
            }
            else
            {
                @class.Int0 = 1;
            }
            if (class380.method_6(1) != 0)
            {
                @class.Int6 = class380.method_6(8) + 1;
                for (var i = 0; i < @class.Int6; i++)
                {
                    var num = @class.Int7[i] = class380.method_6(smethod_0(class490.Int8));
                    var num2 = @class.Int8[i] = class380.method_6(smethod_0(class490.Int8));
                    if (num < 0 || num2 < 0 || num == num2 || num >= class490.Int8 || num2 >= class490.Int8)
                    {
                        @class.method_0();
                        return null;
                    }
                }
            }
            if (class380.method_6(2) > 0)
            {
                @class.method_0();
                return null;
            }
            if (@class.Int0 > 1)
            {
                for (var j = 0; j < class490.Int8; j++)
                {
                    @class.Int1[j] = class380.method_6(4);
                    if (@class.Int1[j] >= @class.Int0)
                    {
                        @class.method_0();
                        return null;
                    }
                }
            }
            for (var k = 0; k < @class.Int0; k++)
            {
                @class.Int2[k] = class380.method_6(8);
                if (@class.Int2[k] >= class490.Int16)
                {
                    @class.method_0();
                    return null;
                }
                @class.Int3[k] = class380.method_6(8);
                if (@class.Int3[k] >= class490.Int17)
                {
                    @class.method_0();
                    return null;
                }
                @class.Int4[k] = class380.method_6(8);
                if (@class.Int4[k] >= class490.Int18)
                {
                    @class.method_0();
                    return null;
                }
            }
            return @class;
        }

        public override int vmethod_3(OggClass6 class710, object object2)
        {
            int result;
            lock (_object0)
            {
                var class66 = class710.OggClass1;
                var class49 = class66.OggClass5;
                var @class = (Class55) object2;
                var class54 = @class.Class540;
                var class27 = @class.Class270;
                var num = class710.Int3 = class49.Int13[class710.Int1];
                var array = class66.Float2[class710.Int1][class710.Int0][class710.Int2][class27.Int1];
                if (_float0 == null || _float0.Length < class49.Int8)
                {
                    _float0 = new float[class49.Int8][];
                    _int1 = new int[class49.Int8];
                    _int0 = new int[class49.Int8];
                    _object1 = new object[class49.Int8];
                }
                for (var i = 0; i < class49.Int8; i++)
                {
                    var array2 = class710.Float0[i];
                    var num2 = class54.Int1[i];
                    _object1[i] = @class.Class280[num2].vmethod_3(class710, @class.Object1[num2], _object1[i]);
                    if (_object1[i] != null)
                    {
                        _int1[i] = 1;
                    }
                    else
                    {
                        _int1[i] = 0;
                    }
                    for (var j = 0; j < num / 2; j++)
                    {
                        array2[j] = 0f;
                    }
                }
                for (var k = 0; k < class54.Int6; k++)
                {
                    if (_int1[class54.Int7[k]] != 0 || _int1[class54.Int8[k]] != 0)
                    {
                        _int1[class54.Int7[k]] = 1;
                        _int1[class54.Int8[k]] = 1;
                    }
                }
                for (var l = 0; l < class54.Int0; l++)
                {
                    var num3 = 0;
                    for (var m = 0; m < class49.Int8; m++)
                    {
                        if (class54.Int1[m] == l)
                        {
                            if (_int1[m] != 0)
                            {
                                _int0[num3] = 1;
                            }
                            else
                            {
                                _int0[num3] = 0;
                            }
                            _float0[num3++] = class710.Float0[m];
                        }
                    }
                    @class.Class230[l].vmethod_3(class710, @class.Object2[l], _float0, _int0, num3);
                }
                for (var n = class54.Int6 - 1; n >= 0; n--)
                {
                    var array3 = class710.Float0[class54.Int7[n]];
                    var array4 = class710.Float0[class54.Int8[n]];
                    for (var num4 = 0; num4 < num / 2; num4++)
                    {
                        var num5 = array3[num4];
                        var num6 = array4[num4];
                        if (num5 > 0f)
                        {
                            if (num6 > 0f)
                            {
                                array3[num4] = num5;
                                array4[num4] = num5 - num6;
                            }
                            else
                            {
                                array4[num4] = num5;
                                array3[num4] = num5 + num6;
                            }
                        }
                        else if (num6 > 0f)
                        {
                            array3[num4] = num5;
                            array4[num4] = num5 + num6;
                        }
                        else
                        {
                            array4[num4] = num5;
                            array3[num4] = num5 - num6;
                        }
                    }
                }
                for (var num7 = 0; num7 < class49.Int8; num7++)
                {
                    var array5 = class710.Float0[num7];
                    var num8 = class54.Int1[num7];
                    @class.Class280[num8].vmethod_4(class710, @class.Object1[num8], _object1[num7], array5);
                }
                for (var num9 = 0; num9 < class49.Int8; num9++)
                {
                    var array6 = class710.Float0[num9];
                    ((Class68) class66.Object0[class710.Int1][0]).method_1(array6, array6);
                }
                for (var num10 = 0; num10 < class49.Int8; num10++)
                {
                    var array7 = class710.Float0[num10];
                    if (_int1[num10] != 0)
                    {
                        for (var num11 = 0; num11 < num; num11++)
                        {
                            array7[num11] *= array[num11];
                        }
                    }
                    else
                    {
                        for (var num12 = 0; num12 < num; num12++)
                        {
                            array7[num12] = 0f;
                        }
                    }
                }
                result = 0;
            }
            return result;
        }

        private static int smethod_0(int int2)
        {
            var num = 0;
            while (int2 > 1)
            {
                num++;
                int2 = (int) ((uint) int2 >> 1);
            }
            return num;
        }
    }
}