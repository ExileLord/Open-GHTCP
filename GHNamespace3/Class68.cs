using System;
using System.Runtime.CompilerServices;

namespace GHNamespace3
{
    public class Class68
    {
        private int _int0;

        private int _int1;

        private float[] _float0;

        private int[] _int2;

        private float _float1;

        private float[] _float2 = new float[1024];

        private float[] _float3 = new float[1024];

        public void method_0(int int3)
        {
            _int2 = new int[int3 / 4];
            _float0 = new float[int3 + int3 / 4];
            _int1 = (int) Math.Round(Math.Log(int3) / Math.Log(2.0));
            _int0 = int3;
            var num = 0;
            var num2 = 1;
            var num3 = 0 + int3 / 2;
            var num4 = num3 + 1;
            var num5 = num3 + int3 / 2;
            var num6 = num5 + 1;
            for (var i = 0; i < int3 / 4; i++)
            {
                _float0[num + i * 2] = (float) Math.Cos(3.1415926535897931 / int3 * (4 * i));
                _float0[num2 + i * 2] = -(float) Math.Sin(3.1415926535897931 / int3 * (4 * i));
                _float0[num3 + i * 2] = (float) Math.Cos(3.1415926535897931 / (2 * int3) * (2 * i + 1));
                _float0[num4 + i * 2] = (float) Math.Sin(3.1415926535897931 / (2 * int3) * (2 * i + 1));
            }
            for (var j = 0; j < int3 / 8; j++)
            {
                _float0[num5 + j * 2] = (float) Math.Cos(3.1415926535897931 / int3 * (4 * j + 2));
                _float0[num6 + j * 2] = -(float) Math.Sin(3.1415926535897931 / int3 * (4 * j + 2));
            }
            var num7 = (1 << _int1 - 1) - 1;
            var num8 = 1 << _int1 - 2;
            for (var k = 0; k < int3 / 8; k++)
            {
                var num9 = 0;
                var num10 = 0;
                while ((uint) num8 >> num10 != 0u)
                {
                    if (((uint) num8 >> num10 & (ulong) k) != 0uL)
                    {
                        num9 |= 1 << num10;
                    }
                    num10++;
                }
                _int2[k * 2] = (~num9 & num7);
                _int2[k * 2 + 1] = num9;
            }
            _float1 = 4f / int3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void method_1(float[] float4, float[] float5)
        {
            if (_float2.Length < _int0 / 2)
            {
                _float2 = new float[_int0 / 2];
            }
            if (_float3.Length < _int0 / 2)
            {
                _float3 = new float[_int0 / 2];
            }
            var array = _float2;
            var float6 = _float3;
            var num = (int) ((uint) _int0 >> 1);
            var num2 = (int) ((uint) _int0 >> 2);
            var num3 = (int) ((uint) _int0 >> 3);
            var num4 = 1;
            var num5 = 0;
            var num6 = num;
            for (var i = 0; i < num3; i++)
            {
                num6 -= 2;
                array[num5++] = -float4[num4 + 2] * _float0[num6 + 1] - float4[num4] * _float0[num6];
                array[num5++] = float4[num4] * _float0[num6 + 1] - float4[num4 + 2] * _float0[num6];
                num4 += 4;
            }
            num4 = num - 4;
            for (var i = 0; i < num3; i++)
            {
                num6 -= 2;
                array[num5++] = float4[num4] * _float0[num6 + 1] + float4[num4 + 2] * _float0[num6];
                array[num5++] = float4[num4] * _float0[num6] - float4[num4 + 2] * _float0[num6 + 1];
                num4 -= 4;
            }
            var array2 = method_2(array, float6, _int0, num, num2, num3);
            var num7 = 0;
            var num8 = num;
            var num9 = num2;
            var num10 = num9 - 1;
            var num11 = num2 + num;
            var num12 = num11 - 1;
            for (var j = 0; j < num2; j++)
            {
                var num13 = array2[num7] * _float0[num8 + 1] - array2[num7 + 1] * _float0[num8];
                var num14 = -(array2[num7] * _float0[num8] + array2[num7 + 1] * _float0[num8 + 1]);
                float5[num9] = -num13;
                float5[num10] = num13;
                float5[num11] = num14;
                float5[num12] = num14;
                num9++;
                num10--;
                num11++;
                num12--;
                num7 += 2;
                num8 += 2;
            }
        }

        public float[] method_2(float[] float4, float[] float5, int int3, int int4, int int5, int int6)
        {
            var num = int5;
            var num2 = 0;
            var num3 = int4;
            for (var i = 0; i < int5; i++)
            {
                var num4 = float4[num] - float4[num2];
                float5[int5 + i] = float4[num++] + float4[num2++];
                var num5 = float4[num] - float4[num2];
                num3 -= 4;
                float5[i++] = num4 * _float0[num3] + num5 * _float0[num3 + 1];
                float5[i] = num5 * _float0[num3] - num4 * _float0[num3 + 1];
                float5[int5 + i] = float4[num++] + float4[num2++];
            }
            for (var j = 0; j < _int1 - 3; j++)
            {
                var num6 = (int) ((uint) int3 >> j + 2);
                var num7 = 1 << j + 3;
                var num8 = int4 - 2;
                num3 = 0;
                var num9 = 0;
                while (num9 < (uint) num6 >> 2)
                {
                    var num10 = num8;
                    var num11 = num10 - (num6 >> 1);
                    var num12 = _float0[num3];
                    var num13 = _float0[num3 + 1];
                    num8 -= 2;
                    num6++;
                    for (var k = 0; k < 2 << j; k++)
                    {
                        var num14 = float5[num10] - float5[num11];
                        float4[num10] = float5[num10] + float5[num11];
                        var num15 = float5[++num10] - float5[++num11];
                        float4[num10] = float5[num10] + float5[num11];
                        float4[num11] = num15 * num12 - num14 * num13;
                        float4[num11 - 1] = num14 * num12 + num15 * num13;
                        num10 -= num6;
                        num11 -= num6;
                    }
                    num6--;
                    num3 += num7;
                    num9++;
                }
                var array = float5;
                float5 = float4;
                float4 = array;
            }
            var num16 = int3;
            var num17 = 0;
            var num18 = 0;
            var num19 = int4 - 1;
            for (var l = 0; l < int6; l++)
            {
                var num20 = _int2[num17++];
                var num21 = _int2[num17++];
                var num22 = float5[num20] - float5[num21 + 1];
                var num23 = float5[num20 - 1] + float5[num21];
                var num24 = float5[num20] + float5[num21 + 1];
                var num25 = float5[num20 - 1] - float5[num21];
                var num26 = num22 * _float0[num16];
                var num27 = num23 * _float0[num16++];
                var num28 = num22 * _float0[num16];
                var num29 = num23 * _float0[num16++];
                float4[num18++] = (num24 + num28 + num27) * 0.5f;
                float4[num19--] = (-num25 + num29 - num26) * 0.5f;
                float4[num18++] = (num25 + num29 - num26) * 0.5f;
                float4[num19--] = (num24 - num28 - num27) * 0.5f;
            }
            return float4;
        }
    }
}