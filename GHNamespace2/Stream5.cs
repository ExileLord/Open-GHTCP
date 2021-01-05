using System;
using System.IO;
using GHNamespace1;
using SharpAudio.ASC;

namespace GHNamespace2
{
    public class Stream5 : GenericAudioStream
    {
        public override bool CanRead => FileStream.CanRead;

        public override bool CanSeek => FileStream.CanSeek;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => FileStream.Length;

        public override long Position
        {
            get => FileStream.Position;
            set => FileStream.Position = value;
        }

        public Stream5()
        {
        }

        public Stream5(Stream stream1, WaveFormat waveFormat1)
        {
            FileStream = stream1;
            WaveFormat0 = waveFormat1;
        }

        public override void SetLength(long value)
        {
            FileStream.SetLength(value);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return FileStream.Seek(offset, origin);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return FileStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (!CanWrite)
            {
                throw new NotSupportedException();
            }
            FileStream.Write(buffer, offset, count);
        }
    }
}