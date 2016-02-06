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
				return this.method_0().CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.method_0().CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.method_0().CanWrite;
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
				return this.long_2 - this.long_0;
			}
			set
			{
				if (this.Position < 0L)
				{
					throw new ArgumentException("Position < 0");
				}
				this.long_2 = this.long_0 + value;
			}
		}

		public Stream method_0()
		{
			return this.stream_0;
		}

		private void method_1(Stream stream_1)
		{
			this.stream_0 = stream_1;
		}

		private long method_2()
		{
			return Math.Max(this.long_0 + this.long_1 - this.long_2, 0L);
		}

		public Stream18(Stream stream_1, long long_3, long long_4)
		{
			this.method_1(stream_1);
			this.long_0 = long_3;
			this.long_1 = long_4;
			this.long_2 = long_3;
		}

		public override void Flush()
		{
			lock (this.method_0())
			{
				this.method_0().Flush();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (this.method_0())
			{
				if (this.method_0().Position != this.long_2)
				{
					this.method_0().Seek(this.long_2, SeekOrigin.Begin);
				}
				count = (int)Math.Min((long)count, this.method_2());
				int num = this.method_0().Read(buffer, offset, count);
				this.long_2 += (long)num;
				result = num;
			}
			return result;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			lock (this.method_0())
			{
				if (this.method_0().Position != this.long_2)
				{
					this.method_0().Seek(this.long_2, SeekOrigin.Begin);
				}
				if ((long)count > this.method_2())
				{
					throw new EndOfStreamException();
				}
				this.method_0().Write(buffer, offset, count);
				this.long_2 += (long)count;
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Current:
				offset += this.long_2 - this.long_0;
				break;
			case SeekOrigin.End:
				offset += this.long_1;
				break;
			}
			this.Position = offset;
			return this.Position;
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}
	}
}
