using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GHNamespace2;
using SharpAudio.ASC;

namespace GHNamespace1
{
    public class Stream2 : GenericAudioStream
    {
        private readonly List<GenericAudioStream> _list0;

        private readonly Class12 _class120;

        private readonly long _long0;

        private long _long1;

        private readonly bool _bool0;

        private readonly int _int2;

        private readonly Enum2 _enum20;

        private readonly bool _bool1;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _long0;

        public override long Position
        {
            get => _long1;
            set
            {
                double num = value / (double) (WaveFormat0.int_0 * WaveFormat0.short_1);
                for (int i = 0; i < _list0.Count; i++)
                {
                    long num2 = Convert.ToInt64(_list0[i].vmethod_0().int_0 * _list0[i].vmethod_0().short_1 * num);
                    _list0[i].Position = ((_list0[i].Length < num2) ? _list0[i].Length : num2);
                }
                _long1 = value;
            }
        }

        public Stream2(GenericAudioStream[] stream10) : this(Enum2.Flag26, stream10)
        {
        }

        public Stream2(Enum2 enum21, GenericAudioStream[] stream10) : this(enum21, 0, false, stream10)
        {
        }

        public Stream2(Enum2 enum21, ushort ushort0, bool bool2, GenericAudioStream[] stream10)
        {
            _list0 = new List<GenericAudioStream>();
            _class120 = new Class12(new INterface5[0]);
            //base..ctor();
            _enum20 = enum21;
            _bool1 = bool2;
            _list0.AddRange(stream10);
            _bool0 = (stream10.Length == 1 && stream10[0].vmethod_0().short_0 == 1 && ushort0 < 2);
            _long1 = 0L;
            _long0 = stream10[0].Length;
            int val = 0;
            int num = 0;
            for (int i = 0; i < stream10.Length; i++)
            {
                GenericAudioStream stream = stream10[i];
                val = Math.Max(val, stream.vmethod_0().int_0);
                if (_bool1)
                {
                    num += stream.vmethod_0().short_0;
                }
                else
                {
                    num = Math.Max(num, stream.vmethod_0().short_0);
                }
                stream.Position = _long1;
            }
            WaveFormat0 = new WaveFormat(val,
                (ushort0 != 0) ? ushort0 : Math.Min(num, smethod_0(_enum20) * (_bool1 ? stream10.Length : 1)));
            for (int j = 0; j < stream10.Length; j++)
            {
                GenericAudioStream stream2 = stream10[j];
                _long0 = Math.Max(_long0,
                    Convert.ToInt64(
                        WaveFormat0.int_0 * WaveFormat0.short_1 * stream2.vmethod_1().TimeSpan0.TotalSeconds));
            }
            _int2 = WaveFormat0.short_0 << 2;
        }

        public Stream2(GenericAudioStream stream10, INterface5[] interface50) : this(Enum2.Flag26, stream10,
            interface50)
        {
        }

        public Stream2(Enum2 enum21, GenericAudioStream stream10, INterface5[] interface50) : this(enum21, 0, stream10,
            interface50)
        {
        }

        public Stream2(Enum2 enum21, ushort ushort0, GenericAudioStream stream10, INterface5[] interface50)
        {
            _list0 = new List<GenericAudioStream>();
            _class120 = new Class12(new INterface5[0]);
            //base..ctor();
            _enum20 = enum21;
            _bool1 = false;
            WaveFormat0 = new WaveFormat(stream10.vmethod_0().int_0,
                (ushort0 != 0) ? ushort0 : Math.Min(stream10.vmethod_0().short_0, smethod_0(_enum20)));
            _list0.Add(stream10);
            _long1 = 0L;
            stream10.Position = 0L;
            _long0 = Convert.ToInt64(WaveFormat0.int_0 * WaveFormat0.short_1 *
                                     stream10.vmethod_1().TimeSpan0.TotalSeconds);
            method_0(interface50);
            _bool0 = (stream10.vmethod_0().short_0 == 1 && ushort0 < 2);
            _int2 = WaveFormat0.short_0 << 2;
        }

        public void method_0(INterface5[] interface50)
        {
            _class120.AddRange(interface50);
        }

        public override int vmethod_3(IntPtr intptr0, int int3)
        {
            int3 >>= 2;
            float[] array = new float[int3];
            int num = vmethod_4(array, 0, int3);
            Marshal.Copy(array, 0, intptr0, num);
            return num << 2;
        }

        public override int vmethod_4(float[] float0, int int3, int int4)
        {
            if (_long1 >= _long0)
            {
                return 0;
            }
            int num = 0;
            int int5 = (int) (_long1 >> 2);
            if (_bool0)
            {
                num = _list0[0].vmethod_4(float0, int3, int4);
                if (num == 0)
                {
                    _long1 = _long0;
                    return 0;
                }
                _class120.imethod_0(new[]
                {
                    new Class13(int5, float0, int3, num)
                });
                _long1 += (long) num << 2;
                return num;
            }
            float[][] array = vmethod_5(int4 / WaveFormat0.short_0);
            if (array == null)
            {
                return 0;
            }
            float[][] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                float[] array3 = array2[i];
                num = Math.Max(array3.Length, num);
            }
            num *= WaveFormat0.short_0;
            int num2 = array.Length;
            for (int j = 0; j < num2; j++)
            {
                float[] array4 = array[j];
                int k = 0;
                int num3 = int3 + j;
                while (k < array4.Length)
                {
                    float0[num3] = array4[k];
                    k++;
                    num3 += num2;
                }
            }
            return num;
        }

        public override float[][] vmethod_5(int int3)
        {
            if (_long1 >= _long0)
            {
                return null;
            }
            int num = (int) (_long1 >> 2);
            if (_bool0)
            {
                float[][] array = _list0[0].vmethod_5(int3);
                if (array == null)
                {
                    _long1 = _long0;
                    return null;
                }
                _class120.imethod_0(new[]
                {
                    new Class13(num, array[0])
                });
                _long1 += array[0].Length * _int2;
                return array;
            }
            int num2 = 0;
            int num3 = 0;
            List<Class13> list = new List<Class13>();
            List<int> list2 = new List<int>();
            int i = 0;
            while (i < _list0.Count)
            {
                float[][] array2;
                if (_list0[i].vmethod_0().int_0 < WaveFormat0.int_0)
                {
                    array2 = _list0[i]
                        .vmethod_5((int) (int3 * (_list0[i].vmethod_0().int_0 / (double) WaveFormat0.int_0)));
                    if (array2 != null)
                    {
                        float float_ = _list0[i].vmethod_0().int_0 / (float) WaveFormat0.int_0;
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if ((_enum20 & (Enum2) (1 << j)) != 0)
                            {
                                Class13 @class = new Class13(num / WaveFormat0.short_0, array2[j]);
                                smethod_1(@class, float_);
                                array2[j] = @class.Float0;
                            }
                        }
                        goto IL_19F;
                    }
                }
                else
                {
                    array2 = _list0[i].vmethod_5(int3);
                    if (array2 != null)
                    {
                        goto IL_19F;
                    }
                }
                IL_32F:
                i++;
                continue;
                IL_19F:
                if (!_bool1)
                {
                    if (array2.Length < WaveFormat0.short_0)
                    {
                        float[][] array3 = new float[WaveFormat0.short_0][];
                        Array.Copy(array2, array3, array2.Length);
                        int k = array2.Length;
                        int num4 = 0;
                        while (k < array3.Length)
                        {
                            if ((_enum20 & (Enum2) (1 << k - array2.Length)) != 0)
                            {
                                array3[k] = new float[array2[num4].Length];
                                Buffer.BlockCopy(array2[num4], 0, array3[k], 0, array2[num4].Length << 2);
                            }
                            k++;
                            num4 = (num4 + 1) % array2.Length;
                        }
                        array2 = array3;
                    }
                    num3 = 0;
                }
                for (int l = 0; l < array2.Length; l++)
                {
                    if ((_enum20 & (Enum2) (1 << l)) != 0)
                    {
                        if (num3 >= list.Count)
                        {
                            list.Add(new Class13(num / WaveFormat0.short_0, array2[l]));
                            list2.Add(1);
                            num2 = Math.Max(num2, array2[l].Length);
                        }
                        else
                        {
                            List<int> list3;
                            int index;
                            (list3 = list2)[index = num3] = list3[index] + 1;
                            Class13 class2 = list[num3];
                            Class13 class3 = new Class13(num / WaveFormat0.short_0, array2[l]);
                            if (num2 < array2[l].Length)
                            {
                                smethod_2(class3, class2);
                                list[num3] = class3;
                                num2 = array2[l].Length;
                            }
                            else
                            {
                                smethod_2(class2, class3);
                            }
                        }
                        num3 = (num3 + 1) % WaveFormat0.short_0;
                    }
                }
                goto IL_32F;
            }
            if (list.Count == 0)
            {
                _long1 = _long0;
                return null;
            }
            int num5 = 0;
            while (num5 < list.Count && list2[num5] > 1)
            {
                smethod_3(list[num5], 1f / list2[num5]);
                num5++;
            }
            _class120.imethod_0(list.ToArray());
            float[][] array4 = new float[list.Count][];
            for (int m = 0; m < array4.Length; m++)
            {
                array4[m] = list[m].Float0;
            }
            _long1 += num2 * _int2;
            return array4;
        }

        private static int smethod_0(Enum2 enum21)
        {
            int num = 0;
            for (int num2 = (int) enum21; num2 != 0; num2 &= num2 - 1)
            {
                num++;
            }
            return num;
        }

        private static void smethod_1(Class13 class130, float float0)
        {
            float[] float_ = class130.Float0;
            int num = class130.method_0();
            int num2 = class130.method_2();
            int num3 = (int) (num2 / float0);
            float[] array = new float[float_.Length - num2 + num3];
            Buffer.BlockCopy(float_, 0, array, 0, num << 2);
            double num4 = num;
            int num5 = num;
            while (num5 < num + num3 && (int) num4 + 1 < float_.Length)
            {
                array[num5] = Class15.smethod_2(float_, (float) num4);
                num4 += float0;
                num5++;
            }
            Buffer.BlockCopy(float_, num + num2 << 2, array, num + num3 << 2, float_.Length - num - num2 << 2);
            class130.Float0 = array;
        }

        private static void smethod_2(Class13 class130, Class13 class131)
        {
            int num = class130.method_0();
            int num2 = class130.method_2();
            int num3 = class131.method_0();
            if (class131.Bool0)
            {
                try
                {
                    for (int i = 0; i < num2; i++)
                    {
                        class130.vmethod_3(class130.vmethod_4(num + i) + class131.vmethod_4(num3 + i), num + i);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        private static void smethod_3(Class13 class130, float float0)
        {
            float[] float_ = class130.Float0;
            int num = class130.method_0();
            int num2 = class130.method_2();
            try
            {
                for (int i = num; i < num + num2; i++)
                {
                    float_[i] = class130.vmethod_1(i, float_[i], float0 * float_[i]);
                }
                Class15.smethod_8(float_, num);
                Class15.smethod_8(float_, num + num2);
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            count >>= 2;
            float[] array = new float[count];
            int num = vmethod_4(array, 0, count);
            Buffer.BlockCopy(array, 0, buffer, offset, num);
            return num << 2;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            foreach (GenericAudioStream current in _list0)
            {
                current.Close();
            }
            _class120.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _class120.Clear();
                foreach (GenericAudioStream current in _list0)
                {
                    current.Dispose();
                }
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Stream2()
        {
            Dispose(false);
        }
    }
}