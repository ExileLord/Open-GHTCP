using System;
using System.IO;
using System.Runtime.InteropServices;
using GHNamespace1;
using GHNamespaceJ;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Decoding;

namespace GHNamespaceI
{
    public class Mp3Stream : GenericAudioStream
    {
        private readonly int _int2;

        private readonly double _double0;

        private readonly long _long0;

        private long _long1;

        private ZzSoundClass _class1070;

        private readonly Class83 _class830;

        private readonly ZzSoundClass81 _class810;

        private readonly Class82 _class820;

        private int _int3 = -1;

        private readonly int _int4 = -1;

        private readonly short _short0 = -1;

        private readonly object _object0 = new object();

        public override bool CanRead => FileStream.CanRead;

        public override bool CanSeek => FileStream.CanSeek;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => _long0;

        public override long Position
        {
            get { return _long1; }
            set
            {
                lock (_object0)
                {
                    _long1 = value;
                    if (_long1 == 0L)
                    {
                        FileStream.Position = _int2;
                    }
                    else if (_class830 != null)
                    {
                        FileStream.Position = _int2 + _class830.method_0(value / (double) _long0);
                    }
                    else
                    {
                        FileStream.Position = (long) (value / _double0 + _int2);
                    }
                    _class820.method_6();
                    _class820.method_7();
                    _class810.method_0().method_6();
                }
            }
        }

        public Mp3Stream(string string0) : this(File.OpenRead(string0))
        {
        }

        public Mp3Stream(Stream stream1) : this(stream1, Enum4.Const0, 4096)
        {
        }

        public Mp3Stream(Stream stream1, Enum4 enum40) : this(stream1, enum40, 4096)
        {
        }

        public Mp3Stream(Stream stream1, Enum4 enum40, int int5)
        {
            _class810 = new ZzSoundClass81(new Class104(enum40));
            FileStream = stream1;
            _class820 = new Class82(FileStream, int5);
            _int2 = _class820.method_2();
            _long0 = -1L;
            _class1070 = null;
            if (!method_0())
            {
                throw new Mp3Exception("Mp3 Decoder: Cannot read header.");
            }
            _short0 = (short) _class810.method_2();
            _int4 = _class810.method_1();
            WaveFormat0 = new WaveFormat(_int4, _short0);
            _double0 = WaveFormat0.int_0 * WaveFormat0.short_1 / (_int3 / 8.0);
            _long1 = 0L;
            if (_class1070 != null && _class1070.method_10())
            {
                _long0 = Convert.ToInt64(_class1070.method_18((int) (FileStream.Length - _int2)) *
                                         (WaveFormat0.int_0 * (WaveFormat0.short_1 / 1000.0)));
                _class830 = _class1070.method_11();
                if (_class830 != null && _class830.Int2 == -1)
                {
                    _class830.Int2 = (int) (FileStream.Length - _int2);
                }
            }
            if (_long0 <= 0L)
            {
                _long0 = (long) ((FileStream.Length - _int2) * _double0);
            }
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
            _class820.method_1();
            FileStream.Close();
        }

        public override int vmethod_3(IntPtr intptr0, int int5)
        {
            int5 >>= 2;
            var array = new float[int5];
            var num = vmethod_4(array, 0, int5);
            Marshal.Copy(array, 0, intptr0, num);
            return num << 2;
        }

        public override int vmethod_4(float[] float0, int int5, int int6)
        {
            int result;
            lock (_object0)
            {
                var num = 0;
                do
                {
                    if (_class810.method_0().method_0() <= 0)
                    {
                        if (!method_0())
                        {
                            break;
                        }
                    }
                    num += _class810.method_0().method_1(float0, int5 + num, int6 - num);
                } while (num < int6);
                _long1 += (long) num << 2;
                result = num;
            }
            return result;
        }

        public override float[][] vmethod_5(int int5)
        {
            float[][] result;
            lock (_object0)
            {
                int num = vmethod_0().short_0;
                var array = new float[num][];
                for (var i = 0; i < num; i++)
                {
                    array[i] = new float[int5];
                }
                int5 *= num;
                var num2 = 0;
                do
                {
                    if (_class810.method_0().method_0() <= 0)
                    {
                        if (!method_0())
                        {
                            break;
                        }
                    }
                    num2 += _class810.method_0().method_3(array, num2, int5 - num2);
                } while (num2 < int5);
                _long1 += (long) num2 << 2;
                result = array;
            }
            return result;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result;
            lock (_object0)
            {
                var num = 0;
                do
                {
                    if (_class810.method_0().method_0() <= 0)
                    {
                        if (!method_0())
                        {
                            break;
                        }
                    }
                    num += _class810.method_0().method_2(buffer, offset + num, count - num);
                } while (num < count);
                _long1 += num;
                result = num;
            }
            return result;
        }

        public bool method_0()
        {
            var @class = _class820.method_3();
            if (@class == null)
            {
                return false;
            }
            if (_class1070 == null)
            {
                _class1070 = @class;
            }
            try
            {
                _int3 = @class.method_21();
                _class810.method_5(@class, _class820);
            }
            finally
            {
                _class820.method_7();
            }
            return true;
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
    }
}