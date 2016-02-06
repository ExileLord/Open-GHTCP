using ns0;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Text;

namespace ns6
{
	public class Stream11 : Stream1
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
				return this.stream_0.CanWrite;
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
				return this.stream_0.Position - this.long_0;
			}
			set
			{
				this.stream_0.Position = this.long_0 + value;
			}
		}

		public Stream11()
		{
		}

		public Stream11(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public Stream11(Stream stream_1)
		{
			this.stream_0 = stream_1;
			this.method_0();
		}

		~Stream11()
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
			BinaryReader binaryReader = new BinaryReader(this.stream_0, Encoding.UTF8);
			if (Stream11.smethod_0(binaryReader) != "RIFF")
			{
				throw new Exception("Invalid file format (No Tag RIFF)");
			}
			binaryReader.ReadInt32();
			if (Stream11.smethod_0(binaryReader) != "WAVE")
			{
				throw new Exception("Invalid file format (No Tag WAVE)");
			}
			if (Stream11.smethod_0(binaryReader) != "fmt ")
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
				this.stream_0.Position += (long)(num - 16);
			}
			while (this.stream_0.Position < this.stream_0.Length && Stream11.smethod_0(binaryReader) != "data")
			{
			}
			if (this.stream_0.Position >= this.stream_0.Length)
			{
				throw new Exception("Invalid file format (No data chunk)");
			}
			this.long_1 = (long)binaryReader.ReadInt32();
			this.long_0 = this.stream_0.Position;
			this.Position = 0L;
		}

		public override void Close()
		{
			this.Dispose();
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override void SetLength(long value)
		{
			this.long_1 = value;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.stream_0.Write(buffer, offset, count);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.stream_0.Read(buffer, offset, (this.long_1 > 0L) ? ((int)Math.Min((long)count, this.long_1 - this.Position)) : count);
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && this.stream_0 != null)
			{
				this.stream_0.Close();
			}
		}

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
