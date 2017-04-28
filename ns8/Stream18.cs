using System;
using System.IO;

namespace ns8
{
	public class Stream18 : Stream
	{
		private Stream _stream0;

		private readonly long _long0;

		private readonly long _long1;

		private long _long2;

		public override bool CanRead => method_0().CanRead;

	    public override bool CanSeek => method_0().CanSeek;

	    public override bool CanWrite => method_0().CanWrite;

	    public override long Length => _long1;

	    public override long Position
		{
			get => _long2 - _long0;
	        set
			{
				if (Position < 0L)
				{
					throw new ArgumentException("Position < 0");
				}
				_long2 = _long0 + value;
			}
		}

		public Stream method_0()
		{
			return _stream0;
		}

		private void method_1(Stream stream1)
		{
			_stream0 = stream1;
		}

		private long method_2()
		{
			return Math.Max(_long0 + _long1 - _long2, 0L);
		}

		public Stream18(Stream stream1, long long3, long long4)
		{
			method_1(stream1);
			_long0 = long3;
			_long1 = long4;
			_long2 = long3;
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
				if (method_0().Position != _long2)
				{
					method_0().Seek(_long2, SeekOrigin.Begin);
				}
				count = (int)Math.Min(count, method_2());
				var num = method_0().Read(buffer, offset, count);
				_long2 += num;
				result = num;
			}
			return result;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			lock (method_0())
			{
				if (method_0().Position != _long2)
				{
					method_0().Seek(_long2, SeekOrigin.Begin);
				}
				if (count > method_2())
				{
					throw new EndOfStreamException();
				}
				method_0().Write(buffer, offset, count);
				_long2 += count;
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Current:
				offset += _long2 - _long0;
				break;
			case SeekOrigin.End:
				offset += _long1;
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
