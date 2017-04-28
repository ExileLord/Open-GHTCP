using System.IO;
using Compression.Zip;

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

		public override bool CanTimeout
		{
			get
			{
				return stream_0.CanTimeout;
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

		public Stream25(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			stream_0.Write(buffer, offset, count);
		}

		public override void Close()
		{
			Stream stream = stream_0;
			stream_0 = null;
			if (bool_0 && stream != null)
			{
				bool_0 = false;
				stream.Close();
			}
		}

		public void method_0(long long_0, long long_1, long long_2)
		{
			long position = stream_0.Position;
			method_4(101075792);
			method_6(44L);
			method_2(45);
			method_2(45);
			method_4(0);
			method_4(0);
			method_6(long_0);
			method_6(long_0);
			method_6(long_1);
			method_6(long_2);
			method_4(117853008);
			method_4(0);
			method_6(position);
			method_4(1);
		}

		public void method_1(long long_0, long long_1, long long_2, byte[] byte_0)
		{
			if (long_0 >= 65535L || long_2 >= 4294967295L || long_1 >= 4294967295L)
			{
				method_0(long_0, long_1, long_2);
			}
			method_4(101010256);
			method_2(0);
			method_2(0);
			if (long_0 >= 65535L)
			{
				method_3(65535);
				method_3(65535);
			}
			else
			{
				method_2((short)long_0);
				method_2((short)long_0);
			}
			if (long_1 >= 4294967295L)
			{
				method_5(4294967295u);
			}
			else
			{
				method_4((int)long_1);
			}
			if (long_2 >= 4294967295L)
			{
				method_5(4294967295u);
			}
			else
			{
				method_4((int)long_2);
			}
			int num = (byte_0 != null) ? byte_0.Length : 0;
			if (num > 65535)
			{
				throw new ZipException(string.Format("Comment length({0}) is too long can only be 64K", num));
			}
			method_2(num);
			if (num > 0)
			{
				Write(byte_0, 0, byte_0.Length);
			}
		}

		public void method_2(int int_0)
		{
			stream_0.WriteByte((byte)(int_0 & 255));
			stream_0.WriteByte((byte)(int_0 >> 8 & 255));
		}

		public void method_3(ushort ushort_0)
		{
			stream_0.WriteByte((byte)(ushort_0 & 255));
			stream_0.WriteByte((byte)(ushort_0 >> 8));
		}

		public void method_4(int int_0)
		{
			method_2(int_0);
			method_2(int_0 >> 16);
		}

		public void method_5(uint uint_0)
		{
			method_3((ushort)(uint_0 & 65535u));
			method_3((ushort)(uint_0 >> 16));
		}

		public void method_6(long long_0)
		{
			method_4((int)long_0);
			method_4((int)(long_0 >> 32));
		}
	}
}
