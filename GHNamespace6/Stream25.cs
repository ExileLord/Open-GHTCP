using System.IO;
using Compression.Zip;

namespace GHNamespace6
{
    public class Stream25 : Stream
    {
        private bool _bool0;

        private Stream _stream0;

        public override bool CanRead => _stream0.CanRead;

        public override bool CanSeek => _stream0.CanSeek;

        public override bool CanTimeout => _stream0.CanTimeout;

        public override bool CanWrite => _stream0.CanWrite;

        public override long Length => _stream0.Length;

        public override long Position
        {
            get => _stream0.Position;
            set => _stream0.Position = value;
        }

        public Stream25(Stream stream1)
        {
            _stream0 = stream1;
        }

        public override void Flush()
        {
            _stream0.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream0.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream0.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream0.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream0.Write(buffer, offset, count);
        }

        public override void Close()
        {
            var stream = _stream0;
            _stream0 = null;
            if (_bool0 && stream != null)
            {
                _bool0 = false;
                stream.Close();
            }
        }

        public void method_0(long long0, long long1, long long2)
        {
            var position = _stream0.Position;
            method_4(101075792);
            method_6(44L);
            method_2(45);
            method_2(45);
            method_4(0);
            method_4(0);
            method_6(long0);
            method_6(long0);
            method_6(long1);
            method_6(long2);
            method_4(117853008);
            method_4(0);
            method_6(position);
            method_4(1);
        }

        public void method_1(long long0, long long1, long long2, byte[] byte0)
        {
            if (long0 >= 65535L || long2 >= 4294967295L || long1 >= 4294967295L)
            {
                method_0(long0, long1, long2);
            }
            method_4(101010256);
            method_2(0);
            method_2(0);
            if (long0 >= 65535L)
            {
                method_3(65535);
                method_3(65535);
            }
            else
            {
                method_2((short) long0);
                method_2((short) long0);
            }
            if (long1 >= 4294967295L)
            {
                method_5(4294967295u);
            }
            else
            {
                method_4((int) long1);
            }
            if (long2 >= 4294967295L)
            {
                method_5(4294967295u);
            }
            else
            {
                method_4((int) long2);
            }
            var num = (byte0 != null) ? byte0.Length : 0;
            if (num > 65535)
            {
                throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", num));
            }
            method_2(num);
            if (num > 0)
            {
                Write(byte0, 0, byte0.Length);
            }
        }

        public void method_2(int int0)
        {
            _stream0.WriteByte((byte) (int0 & 255));
            _stream0.WriteByte((byte) (int0 >> 8 & 255));
        }

        public void method_3(ushort ushort0)
        {
            _stream0.WriteByte((byte) (ushort0 & 255));
            _stream0.WriteByte((byte) (ushort0 >> 8));
        }

        public void method_4(int int0)
        {
            method_2(int0);
            method_2(int0 >> 16);
        }

        public void method_5(uint uint0)
        {
            method_3((ushort) (uint0 & 65535u));
            method_3((ushort) (uint0 >> 16));
        }

        public void method_6(long long0)
        {
            method_4((int) long0);
            method_4((int) (long0 >> 32));
        }
    }
}