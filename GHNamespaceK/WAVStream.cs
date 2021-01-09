using System;
using System.IO;
using System.Text;
using GHNamespace1;
using SharpAudio.ASC;

namespace GHNamespaceK
{
    public class WavStream : GenericAudioStream
    {
        private long _long0;

        private long _long1;

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => FileStream.CanWrite;

        public override long Length => _long1;

        public override long Position
        {
            get => FileStream.Position - _long0;
            set => FileStream.Position = _long0 + value;
        }

        public WavStream()
        {
        }

        public WavStream(string string0) : this(File.OpenRead(string0))
        {
        }

        public WavStream(Stream stream1)
        {
            FileStream = stream1;
            method_0();
        }

        ~WavStream()
        {
            Dispose();
        }

        private static string smethod_0(BinaryReader binaryReader0)
        {
            byte[] array = new byte[4];
            binaryReader0.Read(array, 0, array.Length);
            return Encoding.UTF8.GetString(array);
        }

        private void method_0()
        {
            BinaryReader binaryReader = new BinaryReader(FileStream, Encoding.UTF8);
            if (smethod_0(binaryReader) != "RIFF")
            {
                throw new Exception("Invalid file format (No Tag RIFF)");
            }
            binaryReader.ReadInt32();
            if (smethod_0(binaryReader) != "WAVE")
            {
                throw new Exception("Invalid file format (No Tag WAVE)");
            }
            if (smethod_0(binaryReader) != "fmt ")
            {
                throw new Exception("Invalid file format (No Tag fmt)");
            }
            int num = binaryReader.ReadInt32();
            if (num < 16)
            {
                throw new Exception("Invalid file format (Size of fmt different of 16)");
            }
            WaveFormat0 = new WaveFormat(22050, 16, 2)
            {
                waveFormatTag_0 = (WaveFormatTag)binaryReader.ReadInt16(),
                short_0 = binaryReader.ReadInt16(),
                int_0 = binaryReader.ReadInt32(),
                int_1 = binaryReader.ReadInt32(),
                short_1 = binaryReader.ReadInt16(),
                short_2 = binaryReader.ReadInt16()
            };
            if (num > 16)
            {
                FileStream.Position += num - 16;
            }
            while (FileStream.Position < FileStream.Length && smethod_0(binaryReader) != "data")
            {
            }
            if (FileStream.Position >= FileStream.Length)
            {
                throw new Exception("Invalid file format (No data chunk)");
            }
            _long1 = binaryReader.ReadInt32();
            _long0 = FileStream.Position;
            Position = 0L;
        }

        public override void Close()
        {
            Dispose();
        }

        public override void Flush()
        {
            FileStream.Flush();
        }

        public override void SetLength(long value)
        {
            _long1 = value;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            FileStream.Write(buffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return FileStream.Read(buffer, offset, (_long1 > 0L) ? ((int) Math.Min(count, _long1 - Position)) : count);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && FileStream != null)
            {
                FileStream.Close();
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}