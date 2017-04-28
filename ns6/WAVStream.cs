using System;
using System.IO;
using System.Text;
using ns0;
using SharpAudio.ASC;

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
				return fileStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return long_1;
			}
		}

		public override long Position
		{
			get
			{
				return fileStream.Position - long_0;
			}
			set
			{
				fileStream.Position = long_0 + value;
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
			fileStream = stream_1;
			method_0();
		}

		~WAVStream()
		{
			Dispose();
		}

		private static string smethod_0(BinaryReader binaryReader_0)
		{
			var array = new byte[4];
			binaryReader_0.Read(array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		private void method_0()
		{
			var binaryReader = new BinaryReader(fileStream, Encoding.UTF8);
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
			var num = binaryReader.ReadInt32();
			if (num < 16)
			{
				throw new Exception("Invalid file format (Size of fmt different of 16)");
			}
			waveFormat_0 = new WaveFormat(22050, 16, 2);
			waveFormat_0.waveFormatTag_0 = (WaveFormatTag)binaryReader.ReadInt16();
			waveFormat_0.short_0 = binaryReader.ReadInt16();
			waveFormat_0.int_0 = binaryReader.ReadInt32();
			waveFormat_0.int_1 = binaryReader.ReadInt32();
			waveFormat_0.short_1 = binaryReader.ReadInt16();
			waveFormat_0.short_2 = binaryReader.ReadInt16();
			if (num > 16)
			{
				fileStream.Position += num - 16;
			}
			while (fileStream.Position < fileStream.Length && smethod_0(binaryReader) != "data")
			{
			}
			if (fileStream.Position >= fileStream.Length)
			{
				throw new Exception("Invalid file format (No data chunk)");
			}
			long_1 = binaryReader.ReadInt32();
			long_0 = fileStream.Position;
			Position = 0L;
		}

		public override void Close()
		{
			Dispose();
		}

		public override void Flush()
		{
			fileStream.Flush();
		}

		public override void SetLength(long value)
		{
			long_1 = value;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			fileStream.Write(buffer, offset, count);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return fileStream.Read(buffer, offset, (long_1 > 0L) ? ((int)Math.Min(count, long_1 - Position)) : count);
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && fileStream != null)
			{
				fileStream.Close();
			}
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
