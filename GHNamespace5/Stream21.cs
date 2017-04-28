using System;
using System.IO;
using Compression.Tar;
using GHNamespace6;

namespace GHNamespace5
{
    public class Stream21 : Stream
    {
        public long Long0;

        public long Long1;

        public byte[] Byte0;

        public Class206 Class2060;

        private Stream _stream0;

        public override bool CanRead => _stream0.CanRead;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => _stream0.Length;

        public override long Position
        {
            get => _stream0.Position;
            set => throw new NotSupportedException("TarInputStream Seek not supported");
        }

        public override void Flush()
        {
            _stream0.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("TarInputStream Seek not supported");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("TarInputStream SetLength not supported");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("TarInputStream Write not supported");
        }

        public override void WriteByte(byte value)
        {
            throw new NotSupportedException("TarInputStream WriteByte not supported");
        }

        public override int ReadByte()
        {
            var array = new byte[1];
            var num = Read(array, 0, 1);
            if (num <= 0)
            {
                return -1;
            }
            return array[0];
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            var num = 0;
            if (Long1 >= Long0)
            {
                return 0;
            }
            long num2 = count;
            if (num2 + Long1 > Long0)
            {
                num2 = Long0 - Long1;
            }
            if (Byte0 != null)
            {
                var num3 = (num2 > (long) Byte0.Length) ? Byte0.Length : ((int) num2);
                Array.Copy(Byte0, 0, buffer, offset, num3);
                if (num3 >= Byte0.Length)
                {
                    Byte0 = null;
                }
                else
                {
                    var num4 = Byte0.Length - num3;
                    var destinationArray = new byte[num4];
                    Array.Copy(Byte0, num3, destinationArray, 0, num4);
                    Byte0 = destinationArray;
                }
                num += num3;
                num2 -= num3;
                offset += num3;
            }
            while (num2 > 0L)
            {
                var array = Class2060.method_2();
                if (array == null)
                {
                    throw new TarException("unexpected EOF with " + num2 + " bytes unread");
                }
                var num5 = (int) num2;
                var num6 = array.Length;
                if (num6 > num5)
                {
                    Array.Copy(array, 0, buffer, offset, num5);
                    Byte0 = new byte[num6 - num5];
                    Array.Copy(array, num5, Byte0, 0, num6 - num5);
                }
                else
                {
                    num5 = num6;
                    Array.Copy(array, 0, buffer, offset, num6);
                }
                num += num5;
                num2 -= num5;
                offset += num5;
            }
            Long1 += num;
            return num;
        }

        public override void Close()
        {
            Class2060.method_8();
        }
    }
}