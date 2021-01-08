using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GHNamespace1;
using GHNamespace4;
using GHNamespaceK;
using SharpAudio.ASC;
using SharpAudio.ASC.Flac.LibFlac;
using SharpAudio.ASC.Flac.LibFlac.frame;

namespace GHNamespaceL
{
    public class FlacStream : GenericAudioStream
    {
        private static readonly byte[] Byte0 =
        {
            73,
            68,
            51
        };

        private readonly Class144 _class1440;

        private readonly Class136[] _class1360;

        private int _int2;

        private int _int3;

        private long _long0;

        private Class122 _class1220;

        private readonly Class151 _class1510 = new Class151();

        private readonly byte[] _byte1 = new byte[2];

        private int _int5;

        private int _int6;

        private int _int7;

        private int _int8;

        private int _int9;

        private int _int10;

        private long _long1;

        private readonly long _long2;

        private readonly long _long3;

        private readonly long _long4;

        private Class127 _class1270;

        private int _int11;

        private bool _bool0;

        public override bool CanRead => FileStream.CanRead;

        public override bool CanSeek => FileStream.CanSeek;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => _long2;

        public override long Position
        {
            get => _long1 * WaveFormat0.short_1;
            set
            {
                _bool0 = false;
                if (!method_11(value / WaveFormat0.short_1))
                {
                    FileStream.Position = FileStream.Length;
                    _class1440.vmethod_2();
                    method_5();
                    _long1 = (_long0 = _class1220.vmethod_3());
                    _int10 = 0;
                }
            }
        }

        public Class136[] method_0()
        {
            return _class1360;
        }

        public FlacStream(string string0) : this(File.OpenRead(string0))
        {
        }

        public FlacStream(Stream stream1)
        {
            _class1360 = new Class136[8];
            FileStream = stream1;
            _class1440 = new Class144(stream1);
            _long0 = 0L;
            method_1();
            WaveFormat0 = new WaveFormat(_class1220.vmethod_6(), _class1220.vmethod_7(), _class1220.vmethod_8());
            _long3 = FileStream.Position;
            _long4 = FileStream.Length;
            _long2 = _class1220.vmethod_3() * WaveFormat0.short_1;
            method_5();
        }

        private Class121[] method_1()
        {
            method_2();
            var list = new List<Class121>(10);
            Class121 @class;
            do
            {
                list.Add(@class = method_3());
            } while (!@class.vmethod_0());
            return list.ToArray();
        }

        private void method_2()
        {
            var num = 0;
            var i = 0;
            while (i < 4)
            {
                var num2 = _class1440.vmethod_10(8);
                if (num2 == Class145.Byte0[i])
                {
                    i++;
                    num = 0;
                }
                else
                {
                    if (num2 != Byte0[num])
                    {
                        throw new IOException("Could not find Stream Sync");
                    }
                    num++;
                    i = 0;
                    if (num == 3)
                    {
                        method_4();
                        num = 0;
                    }
                }
            }
        }

        private Class121 method_3()
        {
            var flag = _class1440.vmethod_10(1) != 0;
            var num = _class1440.vmethod_10(7);
            var num2 = _class1440.vmethod_10(24);
            Class121 result;
            if (num == 0)
            {
                _class1220 = new Class122(_class1440, num2, flag);
                result = _class1220;
            }
            else if (num == 3)
            {
                _class1270 = new Class127(_class1440, num2, flag);
                result = _class1270;
            }
            else if (num == 2)
            {
                result = new Class124(_class1440, num2, flag);
            }
            else if (num == 1)
            {
                result = new Class128(_class1440, num2, flag);
            }
            else if (num == 4)
            {
                result = new Class129(_class1440, num2, flag);
            }
            else if (num == 5)
            {
                result = new Class125(_class1440, num2, flag);
            }
            else if (num == 6)
            {
                result = new Class123(_class1440, num2, flag);
            }
            else
            {
                result = new Class126(_class1440, num2, flag);
            }
            return result;
        }

        private void method_4()
        {
            _class1440.vmethod_12(8);
            _class1440.vmethod_12(8);
            _class1440.vmethod_12(8);
            var num = 0;
            for (var i = 0; i < 4; i++)
            {
                var num2 = _class1440.vmethod_10(8);
                num <<= 7;
                num |= (num2 & 127);
            }
            _class1440.vmethod_15(null, num);
        }

        private Class151 method_5()
        {
            _int10 = 0;
            try
            {
                Class151 result;
                while (true)
                {
                    method_7();
                    if (!_bool0)
                    {
                        try
                        {
                            method_8();
                            result = _class1510;
                            return result;
                        }
                        catch (FrameDecodeException)
                        {
                            _int11++;
                            continue;
                        }
                    }
                    break;
                }
                result = null;
                return result;
            }
            catch (EndOfStreamException)
            {
                _bool0 = true;
            }
            return null;
        }

        private void method_6(int int12, int int13)
        {
            if (int12 <= _int2 && int13 <= _int3)
            {
                return;
            }
            for (var i = 0; i < 8; i++)
            {
                _class1360[i] = null;
            }
            for (var j = 0; j < int13; j++)
            {
                _class1360[j] = new Class136(int12);
            }
            _int2 = int12;
            _int3 = int13;
        }

        private void method_7()
        {
            var flag = true;
            if (_class1220 != null && _class1220.vmethod_3() != 0L && _long0 >= _class1220.vmethod_3())
            {
                _bool0 = true;
                return;
            }
// 			if (this.class144_0.vmethod_1())
// 			{
// 				goto IL_5F;
// 			}
// 			this.class144_0.vmethod_10(this.class144_0.vmethod_4());
            if (!_class1440.vmethod_1())
            {
                _class1440.vmethod_10(_class1440.vmethod_4());
            }

            try
            {
                while (true)
                {
                    var num = _class1440.vmethod_10(8);
                    if (num == 255)
                    {
                        _byte1[0] = (byte) num;
                        num = _class1440.vmethod_11(8);
                        if (num >> 2 == 62)
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("FindSync LOST_SYNC: " + Convert.ToString(num & 255, 16));
                        flag = false;
                    }
                }
                _byte1[1] = (byte) _class1440.vmethod_10(8);
            }
            catch (EndOfStreamException)
            {
                if (!flag)
                {
                    Console.WriteLine("FindSync LOST_SYNC: Left over data in file");
                }
            }
        }

        private void method_8()
        {
            var num = Class150.smethod_0(_byte1[0], 0);
            num = Class150.smethod_0(_byte1[1], num);
            _class1440.vmethod_3(num);
            try
            {
                _class1510.Class1400 = new Class140(_class1440, _byte1, _class1220);
            }
            catch (BadHeaderException arg)
            {
                Console.WriteLine("Found bad header: " + arg);
                throw new FrameDecodeException("Bad Frame Header: " + arg);
            }
            method_6(_class1510.Class1400.Int0, _class1510.Class1400.Int2);
            for (var i = 0; i < _class1510.Class1400.Int2; i++)
            {
                var num2 = _class1510.Class1400.Int4;
                switch (_class1510.Class1400.Int3)
                {
                    case 1:
                        if (i == 1)
                        {
                            num2++;
                        }
                        break;
                    case 2:
                        if (i == 0)
                        {
                            num2++;
                        }
                        break;
                    case 3:
                        if (i == 1)
                        {
                            num2++;
                        }
                        break;
                }
                try
                {
                    method_9(i, num2);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("ReadSubframe: " + ex);
                    throw ex;
                }
            }
            method_10();
            num = _class1440.vmethod_0();
            _class1510.vmethod_1((short) _class1440.vmethod_10(16));
            if (num == _class1510.vmethod_0())
            {
                switch (_class1510.Class1400.Int3)
                {
                    case 1:
                        for (var j = 0; j < _class1510.Class1400.Int0; j++)
                        {
                            _class1360[1].vmethod_0()[j] = _class1360[0].vmethod_0()[j] - _class1360[1].vmethod_0()[j];
                        }
                        break;
                    case 2:
                        for (var j = 0; j < _class1510.Class1400.Int0; j++)
                        {
                            _class1360[0].vmethod_0()[j] += _class1360[1].vmethod_0()[j];
                        }
                        break;
                    case 3:
                        for (var j = 0; j < _class1510.Class1400.Int0; j++)
                        {
                            var num3 = _class1360[0].vmethod_0()[j];
                            var num4 = _class1360[1].vmethod_0()[j];
                            num3 <<= 1;
                            if ((num4 & 1) != 0)
                            {
                                num3++;
                            }
                            var num5 = num3 + num4;
                            var num6 = num3 - num4;
                            _class1360[0].vmethod_0()[j] = num5 >> 1;
                            _class1360[1].vmethod_0()[j] = num6 >> 1;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("CRC Error: " + Convert.ToString(num & 65535, 16) + " vs " +
                                  Convert.ToString(_class1510.vmethod_0() & 65535, 16));
                for (var i = 0; i < _class1510.Class1400.Int2; i++)
                {
                    for (var k = 0; k < _class1510.Class1400.Int0; k++)
                    {
                        _class1360[i].vmethod_0()[k] = 0;
                    }
                }
            }
            _int5 = _class1510.Class1400.Int2;
            _int6 = _class1510.Class1400.Int3;
            _int7 = _class1510.Class1400.Int4;
            _int8 = _class1510.Class1400.Int1;
            _int9 = _class1510.Class1400.Int0;
            _long0 += _class1510.Class1400.Int0;
        }

        private void method_9(int int12, int int13)
        {
            var num = _class1440.vmethod_10(8);
            var flag = (num & 1) != 0;
            num &= 254;
            var num2 = 0;
            if (flag)
            {
                num2 = _class1440.vmethod_16() + 1;
                int13 -= num2;
            }
            if ((num & 128) != 0)
            {
                Console.WriteLine("ReadSubframe LOST_SYNC: " + Convert.ToString(num & 255, 16));
                throw new FrameDecodeException("ReadSubframe LOST_SYNC: " + Convert.ToString(num & 255, 16));
            }
            switch (num)
            {
                case 0:
                    _class1510.Class1310[int12] = new Class132(_class1440, _class1510.Class1400, _class1360[int12],
                        int13, num2);
                    goto IL_1AB;
                case 2:
                    _class1510.Class1310[int12] = new Class133(_class1440, _class1510.Class1400, _class1360[int12],
                        int13, num2);
                    goto IL_1AB;
            }
            if (num < 16)
            {
                throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " + Convert.ToString(num & 255, 16));
            }
            if (num <= 24)
            {
                _class1510.Class1310[int12] = new Class134(_class1440, _class1510.Class1400, _class1360[int12], int13,
                    num2, num >> 1 & 7);
            }
            else
            {
                if (num < 64)
                {
                    throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " +
                                                   Convert.ToString(num & 255, 16));
                }
                _class1510.Class1310[int12] = new Class135(_class1440, _class1510.Class1400, _class1360[int12], int13,
                    num2, (num >> 1 & 31) + 1);
            }
            IL_1AB:
            if (flag)
            {
                num = _class1510.Class1310[int12].vmethod_0();
                for (var i = 0; i < _class1510.Class1400.Int0; i++)
                {
                    _class1360[int12].vmethod_0()[i] <<= num;
                }
            }
        }

        private void method_10()
        {
            if (!_class1440.vmethod_1())
            {
                var num = _class1440.vmethod_10(_class1440.vmethod_4());
                if (num != 0)
                {
                    Console.WriteLine("ZeroPaddingError: " + Convert.ToString(num, 16));
                    throw new FrameDecodeException("ZeroPaddingError: " + Convert.ToString(num, 16));
                }
            }
        }

        public bool method_11(long long5)
        {
            if (long5 == 0L)
            {
                FileStream.Position = _long3;
                _class1440.vmethod_2();
                _int10 = 0;
                _long0 = 0L;
                _long1 = 0L;
                method_5();
                return true;
            }
            var num = _class1220.vmethod_3();
            var num2 = _class1220.vmethod_2();
            var num3 = _class1220.vmethod_1();
            var num4 = _class1220.vmethod_5();
            var num5 = _class1220.vmethod_4();
            var num6 = _class1510.Class1400.Int2;
            var num7 = _class1510.Class1400.Int4;
            if (num6 == 0)
            {
                num6 = _class1220.vmethod_8();
            }
            if (num7 == 0)
            {
                num7 = _class1220.vmethod_7();
            }
            int num8;
            if (num5 > 0)
            {
                num8 = (num5 + num4) / 2 + 1;
            }
            else if (num2 == num3 && num2 > 0)
            {
                num8 = num2 * num6 * num7 / 8 + 64;
            }
            else
            {
                num8 = 4096 * num6 * num7 / 8 + 64;
            }
            var num9 = _long3;
            var num10 = 0L;
            var num11 = _long4;
            var num12 = (num > 0L) ? num : long5;
            if (_class1270 != null)
            {
                var num13 = num9;
                var num14 = num11;
                var num15 = num10;
                var num16 = num12;
                var num17 = _class1270.vmethod_1();
                var num18 = num17 - 1;
                while (num18 >= 0 && (_class1270.Class1420[num18].Long0 <= -1L ||
                                      _class1270.Class1420[num18].Int0 <= 0 ||
                                      (num > 0L && _class1270.Class1420[num18].Long0 >= num) ||
                                      _class1270.Class1420[num18].Long0 > long5))
                {
                    num18--;
                }
                if (num18 >= 0)
                {
                    num13 = _long3 + _class1270.Class1420[num18].Long1;
                    num15 = _class1270.Class1420[num18].Long0;
                }
                num18 = 0;
                while (num18 < num17 && (_class1270.Class1420[num18].Long0 <= -1L ||
                                         _class1270.Class1420[num18].Int0 <= 0 ||
                                         (num > 0L && _class1270.Class1420[num18].Long0 >= num) ||
                                         _class1270.Class1420[num18].Long0 <= long5))
                {
                    num18++;
                }
                if (num18 < num17)
                {
                    num14 = _long3 + _class1270.Class1420[num18].Long1;
                    num16 = _class1270.Class1420[num18].Long0;
                }
                if (num14 >= num13)
                {
                    num9 = num13;
                    num11 = num14;
                    num10 = num15;
                    num12 = num16;
                }
            }
            if (num12 == num10)
            {
                num12 += 1L;
            }
            var flag = true;
            while (num10 < num12 && num9 <= num11)
            {
                var num19 = num9 + (long) ((long5 - num10) / (double) (num12 - num10) * (num11 - num9)) - num8;
                if (num19 >= num11)
                {
                    num19 = num11 - 1L;
                }
                if (num19 < num9)
                {
                    FileStream.Position = num19;
                    _class1440.vmethod_2();
                    for (var i = 0; i < 10; i++)
                    {
                        if (method_5() == null)
                        {
                            return false;
                        }
                        if (_class1510.Class1400.Long0 <= long5 &&
                            _class1510.Class1400.Long0 + _class1510.Class1400.Int0 > long5)
                        {
                            _long0 = _class1510.Class1400.Long0 + _class1510.Class1400.Int0;
                            _int10 = (int) (long5 - _class1510.Class1400.Long0);
                            _long1 = long5;
                            return true;
                        }
                    }
                    return false;
                }
                FileStream.Position = num19;
                _class1440.vmethod_2();
                if (method_5() == null)
                {
                    return false;
                }
                var num20 = _class1510.Class1400.Long0;
                if (num20 <= long5 && num20 + _class1510.Class1400.Int0 > long5)
                {
                    _long0 = num20 + _class1510.Class1400.Int0;
                    _int10 = (int) (long5 - num20);
                    _long1 = long5;
                    return true;
                }
                if (0L != num20 && (num20 + _class1510.Class1400.Int0 < num12 || !flag))
                {
                    flag = false;
                    if (num20 < num10)
                    {
                        return false;
                    }
                    if (long5 < num20)
                    {
                        num12 = num20 + _class1510.Class1400.Int0;
                        num11 = FileStream.Position;
                        num8 = (int) (2L * (num11 - num19) / 3L + 16L);
                    }
                    else
                    {
                        num10 = num20 + _class1510.Class1400.Int0;
                        num9 = FileStream.Position;
                        num8 = (int) (2L * (num9 - num19) / 3L + 16L);
                    }
                }
                else
                {
                    if (num19 == num9)
                    {
                        return false;
                    }
                    num8 = ((num8 != 0) ? (num8 * 2) : 16);
                }
            }
            return false;
        }

        public override void Flush()
        {
            FileStream.Flush();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void Close()
        {
            _class1440.vmethod_2();
            FileStream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override int vmethod_3(IntPtr intptr0, int int12)
        {
            if (_bool0)
            {
                return 0;
            }
            var array = new byte[int12];
            var num = Read(array, 0, int12);
            if (num == 0)
            {
                return 0;
            }
            Marshal.Copy(array, 0, intptr0, num);
            return num;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_bool0)
            {
                return 0;
            }
            var num = offset;
            var num2 = offset + count;
            int short_ = WaveFormat0.short_0;
            var num3 = WaveFormat0.short_2 / 8;
            int short2 = WaveFormat0.short_1;
            do
            {
                var num4 = _class1510.Class1400.Int0 - _int10;
                if (num4 > 0)
                {
                    if (num4 * short2 > num2 - num)
                    {
                        num4 = (num2 - num) / short2;
                    }
                    for (var i = 0; i < short_; i++)
                    {
                        var array = method_0()[i].vmethod_0();
                        if (WaveFormat0.short_2 == 8)
                        {
                            var j = _int10;
                            var num5 = num + i;
                            var num6 = j + num4;
                            while (j < num6)
                            {
                                buffer[num5] = (byte) (array[j] + 128);
                                j++;
                                num5 += short2;
                            }
                        }
                        else
                        {
                            var k = _int10 << 2;
                            var num7 = num + num3 * i;
                            var num8 = k + (num4 << 2);
                            while (k < num8)
                            {
                                Buffer.BlockCopy(array, k, buffer, num7, num3);
                                k += 4;
                                num7 += short2;
                            }
                        }
                    }
                    _long1 += num4;
                    _int10 += num4;
                    num += num4 * short2;
                    if (num >= num2)
                    {
                        break;
                    }
                }
            } while (method_5() != null);
            return num - offset;
        }

        public override int vmethod_4(float[] float0, int int12, int int13)
        {
            if (_bool0)
            {
                return 0;
            }
            var num = int12;
            var num2 = int12 + int13;
            int short_ = WaveFormat0.short_0;
            do
            {
                var num3 = _class1510.Class1400.Int0 - _int10;
                if (num3 > 0)
                {
                    if (num3 > num2 - num)
                    {
                        num3 = num2 - num;
                    }
                    for (var i = 0; i < short_; i++)
                    {
                        var array = method_0()[i].vmethod_0();
                        var short2 = WaveFormat0.short_2;
                        if (short2 <= 16)
                        {
                            if (short2 != 8)
                            {
                                if (short2 == 16)
                                {
                                    var j = _int10;
                                    var num4 = num + i;
                                    while (j < num3)
                                    {
                                        float0[num4] = Class11.smethod_7((short) array[j]);
                                        j++;
                                        num4 += short_;
                                    }
                                }
                            }
                            else
                            {
                                var k = _int10;
                                var num5 = num + i;
                                while (k < num3)
                                {
                                    float0[num5] = Class11.smethod_3((byte) array[k]);
                                    k++;
                                    num5 += short_;
                                }
                            }
                        }
                        else if (short2 != 24)
                        {
                            if (short2 == 32)
                            {
                                var l = _int10;
                                var num6 = num + i;
                                while (l < num3)
                                {
                                    float0[num6] = Class11.smethod_15(array[l]);
                                    l++;
                                    num6 += short_;
                                }
                            }
                        }
                        else
                        {
                            var m = _int10;
                            var num7 = num + i;
                            while (m < num3)
                            {
                                float0[num7] = Class11.smethod_11(Struct8.smethod_1(array[m]));
                                m++;
                                num7 += short_;
                            }
                        }
                    }
                    _long1 += num3;
                    _int10 += num3;
                    num += num3 * short_;
                    if (num >= num2)
                    {
                        break;
                    }
                }
            } while (method_5() != null);
            return num - int12;
        }

        public override float[][] vmethod_5(int int12)
        {
            if (_bool0)
            {
                return null;
            }
            var array = new float[WaveFormat0.short_0][];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = new float[int12];
            }
            var num = 0;
            do
            {
                var num2 = _class1510.Class1400.Int0 - _int10;
                if (num2 > 0)
                {
                    if (num2 > int12 - num)
                    {
                        num2 = int12 - num;
                    }
                    for (var j = 0; j < array.Length; j++)
                    {
                        var array2 = array[j];
                        var array3 = method_0()[j].vmethod_0();
                        var short_ = WaveFormat0.short_2;
                        if (short_ <= 16)
                        {
                            if (short_ != 8)
                            {
                                if (short_ == 16)
                                {
                                    var k = num;
                                    var num3 = _int10;
                                    while (k < num2)
                                    {
                                        array2[k] = Class11.smethod_7((short) array3[num3]);
                                        k++;
                                        num3++;
                                    }
                                }
                            }
                            else
                            {
                                var l = num;
                                var num4 = _int10;
                                while (l < num2)
                                {
                                    array2[l] = Class11.smethod_3((byte) array3[num4]);
                                    l++;
                                    num4++;
                                }
                            }
                        }
                        else if (short_ != 24)
                        {
                            if (short_ == 32)
                            {
                                var m = num;
                                var num5 = _int10;
                                while (m < num2)
                                {
                                    array2[m] = Class11.smethod_15(array3[num5]);
                                    m++;
                                    num5++;
                                }
                            }
                        }
                        else
                        {
                            var n = num;
                            var num6 = _int10;
                            while (n < num2)
                            {
                                array2[n] = Class11.smethod_11(Struct8.smethod_1(array3[num6]));
                                n++;
                                num6++;
                            }
                        }
                    }
                    num += num2;
                    _long1 += num2;
                    _int10 += num2;
                    if (num >= int12)
                    {
                        break;
                    }
                }
            } while (method_5() != null);
            if (num == 0)
            {
                return null;
            }
            if (num < int12)
            {
                for (var num7 = 0; num7 < array.Length; num7++)
                {
                    Array.Resize(ref array[num7], num);
                }
            }
            return array;
        }
    }
}