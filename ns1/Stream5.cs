using ns0;
using SharpAudio.ASC;
using System;
using System.IO;

namespace ns1
{
	public class Stream5 : GenericAudioStream
	{
		public override bool CanRead
		{
			get
			{
				return this.fileStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.fileStream.CanSeek;
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
				return this.fileStream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.fileStream.Position;
			}
			set
			{
				this.fileStream.Position = value;
			}
		}

		public Stream5()
		{
		}

		public Stream5(Stream stream_1, WaveFormat waveFormat_1)
		{
			this.fileStream = stream_1;
			this.waveFormat_0 = waveFormat_1;
		}

		public override void SetLength(long value)
		{
			this.fileStream.SetLength(value);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.fileStream.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.fileStream.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (!this.CanWrite)
			{
				throw new NotSupportedException();
			}
			this.fileStream.Write(buffer, offset, count);
		}
	}
}
