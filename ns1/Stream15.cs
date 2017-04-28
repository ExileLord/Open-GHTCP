using System;
using System.IO;
using SharpAudio.ASC;

namespace ns1
{
	public class Stream15 : Stream14
	{
		public override bool CanRead
		{
			get
			{
				return stream_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return stream_0.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return stream_0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return stream_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				stream_0.Position = value;
			}
		}

		public Stream15()
		{
		}

		public Stream15(Stream stream_1, WaveFormat waveFormat_1)
		{
			stream_0 = stream_1;
			waveFormat_0 = waveFormat_1;
		}

		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (!CanRead)
			{
				throw new NotSupportedException();
			}
			return stream_0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}
	}
}
