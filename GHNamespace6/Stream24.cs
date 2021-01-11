using System;
using System.IO;
using Compression.Tar;

namespace GHNamespace6
{
    public class Stream24 : Stream
    {
        private long _long0;

        private int _int0;

        private bool _bool0;

        public long Long1;

        public byte[] Byte0;

        public byte[] Byte1;

        public Class206 Class2060;

        public Stream Stream0;

        public override bool CanRead => Stream0.CanRead;

        public override bool CanSeek => Stream0.CanSeek;

        public override bool CanWrite => Stream0.CanWrite;

        public override long Length => Stream0.Length;

        public override long Position
        {
            get => Stream0.Position;
            set => Stream0.Position = value;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream0.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream0.SetLength(value);
        }

        public override int ReadByte()
        {
            return Stream0.ReadByte();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Stream0.Read(buffer, offset, count);
        }

        public override void Flush()
        {
            Stream0.Flush();
        }

        public void method_0()
        {
            if (method_1())
            {
                method_2();
            }
            method_3();
        }

        public override void Close()
        {
            if (!_bool0)
            {
                _bool0 = true;
                method_0();
                Class2060.method_8();
            }
        }

        private bool method_1()
        {
            return _long0 < Long1;
        }

        public void method_2()
        {
            if (_int0 > 0)
            {
                Array.Clear(Byte1, _int0, Byte1.Length - _int0);
                Class2060.method_4(Byte1);
                _long0 += _int0;
                _int0 = 0;
            }
            if (_long0 < Long1)
            {
                string string_ = string.Format(
                    "Entry closed at '{0}' before the '{1}' bytes specified in the header were written", _long0, Long1);
                throw new TarException(string_);
            }
        }

        public override void WriteByte(byte value)
        {
            Write(new[]
            {
                value
            }, 0, 1);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
            }
            if (buffer.Length - offset < count)
            {
                throw new ArgumentException("offset and count combination is invalid");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Cannot be negative");
            }
            if (_long0 + count > Long1)
            {
                string message = string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes", count,
                    Long1);
                throw new ArgumentOutOfRangeException("count", message);
            }
            if (_int0 > 0)
            {
                if (_int0 + count >= Byte0.Length)
                {
                    int num = Byte0.Length - _int0;
                    Array.Copy(Byte1, 0, Byte0, 0, _int0);
                    Array.Copy(buffer, offset, Byte0, _int0, num);
                    Class2060.method_4(Byte0);
                    _long0 += Byte0.Length;
                    offset += num;
                    count -= num;
                    _int0 = 0;
                }
                else
                {
                    Array.Copy(buffer, offset, Byte1, _int0, count);
                    offset += count;
                    _int0 += count;
                    count -= count;
                }
            }
            while (count > 0)
            {
                if (count < Byte0.Length)
                {
                    Array.Copy(buffer, offset, Byte1, _int0, count);
                    _int0 += count;
                    return;
                }
                Class2060.method_5(buffer, offset);
                int num2 = Byte0.Length;
                _long0 += num2;
                count -= num2;
                offset += num2;
            }
        }

        private void method_3()
        {
            Array.Clear(Byte0, 0, Byte0.Length);
            Class2060.method_4(Byte0);
        }
    }
}