using System;
using System.IO;
using SharpAudio.ASC;

namespace ns1
{
	public class Stream15 : Stream14
	{
		public override bool CanRead => Stream0.CanRead;

	    public override bool CanSeek => Stream0.CanSeek;

	    public override bool CanWrite => Stream0.CanWrite;

	    public override long Length => Stream0.Length;

	    public override long Position
		{
			get => Stream0.Position;
	        set => Stream0.Position = value;
	    }

		public Stream15()
		{
		}

		public Stream15(Stream stream1, WaveFormat waveFormat1)
		{
			Stream0 = stream1;
			WaveFormat0 = waveFormat1;
		}

		public override void SetLength(long value)
		{
			Stream0.SetLength(value);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return Stream0.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (!CanRead)
			{
				throw new NotSupportedException();
			}
			return Stream0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			Stream0.Write(buffer, offset, count);
		}
	}
}
