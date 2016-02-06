using Compression;
using Compression.Zip;
using ns13;
using System;
using System.IO;

namespace ns12
{
	public class Stream19 : Stream
	{
		public Class196 class196_0;

		public Class201 class201_0;

		public Stream stream_0;

		public long long_0;

		private bool bool_0;

		private bool bool_1 = true;

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
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				return (long)this.class201_0.method_0();
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
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		public Stream19(Stream stream_1, Class196 class196_1) : this(stream_1, class196_1, 4096)
		{
		}

		public Stream19(Stream stream_1, Class196 class196_1, int int_0)
		{
			if (stream_1 == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (class196_1 == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (int_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.stream_0 = stream_1;
			this.class196_0 = class196_1;
			this.class201_0 = new Class201(stream_1, int_0);
		}

		public long method_0(long long_1)
		{
			if (long_1 < 0L)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this.stream_0.CanSeek)
			{
				this.stream_0.Seek(long_1, SeekOrigin.Current);
				return long_1;
			}
			int num = 2048;
			if (long_1 < 2048L)
			{
				num = (int)long_1;
			}
			byte[] array = new byte[num];
			return (long)this.stream_0.Read(array, 0, array.Length);
		}

		public void method_1()
		{
			this.class201_0.method_12(null);
		}

		public void method_2()
		{
			this.class201_0.method_4();
			this.class201_0.method_3(this.class196_0);
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		public override void Close()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				if (this.bool_1)
				{
					this.stream_0.Close();
				}
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.class196_0.method_9())
			{
				throw new SharpZipBaseException("Need a dictionary");
			}
			int num = count;
			while (true)
			{
				int num2 = this.class196_0.method_7(buffer, offset, num);
				offset += num2;
				num -= num2;
				if (num == 0 || this.class196_0.method_10())
				{
					goto IL_69;
				}
				if (this.class196_0.method_8())
				{
					this.method_2();
				}
				else if (num2 == 0)
				{
					break;
				}
			}
			throw new ZipException("Dont know what to do");
			IL_69:
			return count - num;
		}
	}
}
