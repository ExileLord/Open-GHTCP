using System;
using System.IO;

namespace ns8
{
	public class Stream18 : Stream
	{
		private Stream stream_0;

		private readonly long long_0;

		private readonly long long_1;

		private long long_2;

		public override bool CanRead
		{
			get
			{
				return method_0().CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return method_0().CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return method_0().CanWrite;
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
				return long_2 - long_0;
			}
			set
			{
				if (Position < 0L)
				{
					throw new ArgumentException("Position < 0");
				}
				long_2 = long_0 + value;
			}
		}

		public Stream method_0()
		{
			return stream_0;
		}

		private void method_1(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		private long method_2()
		{
			return Math.Max(long_0 + long_1 - long_2, 0L);
		}

		public Stream18(Stream stream_1, long long_3, long long_4)
		{
			method_1(stream_1);
			long_0 = long_3;
			long_1 = long_4;
			long_2 = long_3;
		}

		public override void Flush()
		{
			lock (method_0())
			{
				method_0().Flush();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (method_0())
			{
				if (method_0().Position != long_2)
				{
					method_0().Seek(long_2, SeekOrigin.Begin);
				}
				count = (int)Math.Min(count, method_2());
				int num = method_0().Read(buffer, offset, count);
				long_2 += num;
				result = num;
			}
			return result;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			lock (method_0())
			{
				if (method_0().Position != long_2)
				{
					method_0().Seek(long_2, SeekOrigin.Begin);
				}
				if (count > method_2())
				{
					throw new EndOfStreamException();
				}
				method_0().Write(buffer, offset, count);
				long_2 += count;
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Current:
				offset += long_2 - long_0;
				break;
			case SeekOrigin.End:
				offset += long_1;
				break;
			}
			Position = offset;
			return Position;
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}
	}
}
