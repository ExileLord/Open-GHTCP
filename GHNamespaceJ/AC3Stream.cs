using System;
using System.IO;
using GHNamespace1;
using GHNamespace2;
using SharpAudio.ASC;

namespace GHNamespaceJ
{
    public class Ac3Stream : GenericAudioStream
    {
        public int Int2;

        public double Double0;

        private bool _bool0;

        private int _int3;

        private readonly object _object0 = new object();

        private readonly Ac3Class1 _class1110 = new Ac3Class1();

        private int _int4 = -1;

        private int _int5 = -1;

        private short _short0 = -1;

        private MemoryStream _memoryStream0;

        public override bool CanRead => FileStream.CanRead;

        public override bool CanSeek => FileStream.CanSeek;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => (long) ((FileStream.Length - Int2) * Double0);

        public override long Position
        {
            get => (long) ((FileStream.Position - Int2) * Double0) - _memoryStream0.Length + _memoryStream0.Position;
            set
            {
                FileStream.Position = (long) (value / Double0 + Int2);
                _memoryStream0.Position = _memoryStream0.Length;
            }
        }

        public Ac3Stream(string string0) : this(File.OpenRead(string0))
        {
        }

        public Ac3Stream(Stream stream1) : this(stream1, 4096)
        {
        }

        public Ac3Stream(Stream stream1, int int6) : this(stream1, int6, true)
        {
        }

        public Ac3Stream(Stream stream1, int int6, bool bool1)
        {
            _int3 = (bool1 ? 2 : 4);
            FileStream = stream1;
            _bool0 = bool1;
            _memoryStream0 = new MemoryStream();
            if (!method_0())
            {
                throw new Exception("Ac3 Decoder: Cannot read header.");
            }
            Int2 = (int) stream1.Position;
            WaveFormat0 = (bool1 ? new WaveFormat(_int5, 16, _short0) : new WaveFormat(_int5, _short0));
            Double0 = WaveFormat0.int_0 * WaveFormat0.short_1 / (_int4 / 8.0);
        }

        public override Class16 vmethod_1()
        {
            return new Class16(WaveFormat0, (uint) Position, (uint) Length);
        }

        public override void Flush()
        {
            FileStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return FileStream.Seek((long) (offset / Double0) + ((origin == SeekOrigin.Begin) ? Int2 : 0), origin);
        }

        public override void SetLength(long value)
        {
            throw new InvalidOperationException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result;
            lock (_object0)
            {
                var num = 0;
                do
                {
                    if (_memoryStream0.Position == _memoryStream0.Length)
                    {
                        if (!method_0())
                        {
                            break;
                        }
                    }
                    num += _memoryStream0.Read(buffer, offset + num, count - num);
                } while (num < count);
                result = num;
            }
            return result;
        }

        public override void Close()
        {
            FileStream.Close();
        }

        public bool method_0()
        {
            var array = new byte[1792];
            FileStream.Read(array, 0, 1792);
            _memoryStream0 = new MemoryStream();
            _class1110.vmethod_0(array, _memoryStream0);
            _short0 = 2;
            _int5 = _class1110.Int2;
            _int4 = _class1110.Int3 / 1000;
            if (_memoryStream0.Length == 0L)
            {
                return false;
            }
            _memoryStream0.Position = 0L;
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