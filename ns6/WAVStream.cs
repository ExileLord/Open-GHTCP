using ns0;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Text;

namespace ns6
{
	public class WAVStream : GenericAudioStream
	{
		private long long_0;

		private long long_1;

		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.fileStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this.long_1;
			}
		}

		public override long Position
		{
			get
			{
				return this.fileStream.Position - this.long_0;
			}
			set
			{
				this.fileStream.Position = this.long_0 + value;
			}
		}

		public WAVStream()
		{
		}

		public WAVStream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public WAVStream(Stream stream_1)
		{
			this.fileStream = stream_1;
			this.method_0();
		}

		~WAVStream()
		{
			this.Dispose();
		}

		private static string smethod_0(BinaryReader binaryReader_0)
		{
			byte[] array = new byte[4];
			binaryReader_0.Read(array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		private void method_0()
		{
			BinaryReader binaryReader = new BinaryReader(this.fileStream, Encoding.UTF8);
			if (WAVStream.smethod_0(binaryReader) != "RIFF")
			{
				throw new Exception("Invalid file format (No Tag RIFF)");
			}
			binaryReader.ReadInt32();
			if (WAVStream.smethod_0(binaryReader) != "WAVE")
			{
				throw new Exception("Invalid file format (No Tag WAVE)");
			}
			if (WAVStream.smethod_0(binaryReader) != "fmt ")
			{
				throw new Exception("Invalid file format (No Tag fmt)");
			}
			int num = binaryReader.ReadInt32();
			if (num < 16)
			{
				throw new Exception("Invalid file format (Size of fmt different of 16)");
			}
			this.waveFormat_0 = new WaveFormat(22050, 16, 2);
			this.waveFormat_0.waveFormatTag_0 = (WaveFormatTag)binaryReader.ReadInt16();
			this.waveFormat_0.short_0 = binaryReader.ReadInt16();
			this.waveFormat_0.int_0 = binaryReader.ReadInt32();
			this.waveFormat_0.int_1 = binaryReader.ReadInt32();
			this.waveFormat_0.short_1 = binaryReader.ReadInt16();
			this.waveFormat_0.short_2 = binaryReader.ReadInt16();
			if (num > 16)
			{
				this.fileStream.Position += (long)(num - 16);
			}
			while (this.fileStream.Position < this.fileStream.Length && WAVStream.smethod_0(binaryReader) != "data")
			{
			}
			if (this.fileStream.Position >= this.fileStream.Length)
			{
				throw new Exception("Invalid file format (No data chunk)");
			}
			this.long_1 = (long)binaryReader.ReadInt32();
			this.long_0 = this.fileStream.Position;
			this.Position = 0L;
		}

		public override void Close()
		{
			this.Dispose();
		}

		public override void Flush()
		{
			this.fileStream.Flush();
		}

		public override void SetLength(long value)
		{
			this.long_1 = value;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.fileStream.Write(buffer, offset, count);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.fileStream.Read(buffer, offset, (this.long_1 > 0L) ? ((int)Math.Min((long)count, this.long_1 - this.Position)) : count);
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && this.fileStream != null)
			{
				this.fileStream.Close();
			}
		}

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
