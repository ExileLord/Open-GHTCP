using SharpAudio.ASC;
using System;
using System.IO;

namespace ns1
{
	public class Stream15 : Stream14
	{
		public override bool CanRead
		{
			get
			{
				return this.stream_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.stream_0.CanSeek;
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
				return this.stream_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.stream_0.Position;
			}
			set
			{
				this.stream_0.Position = value;
			}
		}

		public Stream15()
		{
		}

		public Stream15(Stream stream_1, WaveFormat waveFormat_1)
		{
			this.stream_0 = stream_1;
			this.waveFormat_0 = waveFormat_1;
		}

		public override void SetLength(long value)
		{
			this.stream_0.SetLength(value);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (!this.CanRead)
			{
				throw new NotSupportedException();
			}
			return this.stream_0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.stream_0.Write(buffer, offset, count);
		}
	}
}
