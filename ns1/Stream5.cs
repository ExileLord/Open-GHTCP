using System;
using System.IO;
using ns0;
using SharpAudio.ASC;

namespace ns1
{
	public class Stream5 : GenericAudioStream
	{
		public override bool CanRead
		{
			get
			{
				return fileStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return fileStream.CanSeek;
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
				return fileStream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return fileStream.Position;
			}
			set
			{
				fileStream.Position = value;
			}
		}

		public Stream5()
		{
		}

		public Stream5(Stream stream_1, WaveFormat waveFormat_1)
		{
			fileStream = stream_1;
			waveFormat_0 = waveFormat_1;
		}

		public override void SetLength(long value)
		{
			fileStream.SetLength(value);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return fileStream.Seek(offset, origin);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return fileStream.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (!CanWrite)
			{
				throw new NotSupportedException();
			}
			fileStream.Write(buffer, offset, count);
		}
	}
}
