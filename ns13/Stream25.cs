using Compression.Zip;
using System;
using System.IO;

namespace ns13
{
	public class Stream25 : Stream
	{
		private bool bool_0;

		private Stream stream_0;

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

		public override bool CanTimeout
		{
			get
			{
				return this.stream_0.CanTimeout;
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

		public Stream25(Stream stream_1)
		{
			this.stream_0 = stream_1;
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this.stream_0.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.stream_0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.stream_0.Write(buffer, offset, count);
		}

		public override void Close()
		{
			Stream stream = this.stream_0;
			this.stream_0 = null;
			if (this.bool_0 && stream != null)
			{
				this.bool_0 = false;
				stream.Close();
			}
		}

		public void method_0(long long_0, long long_1, long long_2)
		{
			long position = this.stream_0.Position;
			this.method_4(101075792);
			this.method_6(44L);
			this.method_2(45);
			this.method_2(45);
			this.method_4(0);
			this.method_4(0);
			this.method_6(long_0);
			this.method_6(long_0);
			this.method_6(long_1);
			this.method_6(long_2);
			this.method_4(117853008);
			this.method_4(0);
			this.method_6(position);
			this.method_4(1);
		}

		public void method_1(long long_0, long long_1, long long_2, byte[] byte_0)
		{
			if (long_0 >= 65535L || long_2 >= 4294967295L || long_1 >= 4294967295L)
			{
				this.method_0(long_0, long_1, long_2);
			}
			this.method_4(101010256);
			this.method_2(0);
			this.method_2(0);
			if (long_0 >= 65535L)
			{
				this.method_3(65535);
				this.method_3(65535);
			}
			else
			{
				this.method_2((int)((short)long_0));
				this.method_2((int)((short)long_0));
			}
			if (long_1 >= 4294967295L)
			{
				this.method_5(4294967295u);
			}
			else
			{
				this.method_4((int)long_1);
			}
			if (long_2 >= 4294967295L)
			{
				this.method_5(4294967295u);
			}
			else
			{
				this.method_4((int)long_2);
			}
			int num = (byte_0 != null) ? byte_0.Length : 0;
			if (num > 65535)
			{
				throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", num));
			}
			this.method_2(num);
			if (num > 0)
			{
				this.Write(byte_0, 0, byte_0.Length);
			}
		}

		public void method_2(int int_0)
		{
			this.stream_0.WriteByte((byte)(int_0 & 255));
			this.stream_0.WriteByte((byte)(int_0 >> 8 & 255));
		}

		public void method_3(ushort ushort_0)
		{
			this.stream_0.WriteByte((byte)(ushort_0 & 255));
			this.stream_0.WriteByte((byte)(ushort_0 >> 8));
		}

		public void method_4(int int_0)
		{
			this.method_2(int_0);
			this.method_2(int_0 >> 16);
		}

		public void method_5(uint uint_0)
		{
			this.method_3((ushort)(uint_0 & 65535u));
			this.method_3((ushort)(uint_0 >> 16));
		}

		public void method_6(long long_0)
		{
			this.method_4((int)long_0);
			this.method_4((int)(long_0 >> 32));
		}
	}
}
