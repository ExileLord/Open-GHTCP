using System;
using System.IO;
using Compression.Tar;

namespace ns13
{
	public class Stream24 : Stream
	{
		private long long_0;

		private int int_0;

		private bool bool_0;

		public long long_1;

		public byte[] byte_0;

		public byte[] byte_1;

		public Class206 class206_0;

		public Stream stream_0;

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

		public override long Seek(long offset, SeekOrigin origin)
		{
			return stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			stream_0.SetLength(value);
		}

		public override int ReadByte()
		{
			return stream_0.ReadByte();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream_0.Read(buffer, offset, count);
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

		public void method_0()
		{
			if (method_1())
			{
				method_2();
			}
			method_3();
		}

		public override void Close()
		{
			if (!bool_0)
			{
				bool_0 = true;
				method_0();
				class206_0.method_8();
			}
		}

		private bool method_1()
		{
			return long_0 < long_1;
		}

		public void method_2()
		{
			if (int_0 > 0)
			{
				Array.Clear(byte_1, int_0, byte_1.Length - int_0);
				class206_0.method_4(byte_1);
				long_0 += int_0;
				int_0 = 0;
			}
			if (long_0 < long_1)
			{
				string string_ = string.Format("Entry closed at '{0}' before the '{1}' bytes specified in the header were written", long_0, long_1);
				throw new TarException(string_);
			}
		}

		public override void WriteByte(byte value)
		{
			Write(new[]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("offset and count combination is invalid");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (long_0 + count > long_1)
			{
				string message = string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes", count, long_1);
				throw new ArgumentOutOfRangeException("count", message);
			}
			if (int_0 > 0)
			{
				if (int_0 + count >= byte_0.Length)
				{
					int num = byte_0.Length - int_0;
					Array.Copy(byte_1, 0, byte_0, 0, int_0);
					Array.Copy(buffer, offset, byte_0, int_0, num);
					class206_0.method_4(byte_0);
					long_0 += byte_0.Length;
					offset += num;
					count -= num;
					int_0 = 0;
				}
				else
				{
					Array.Copy(buffer, offset, byte_1, int_0, count);
					offset += count;
					int_0 += count;
					count -= count;
				}
			}
			while (count > 0)
			{
				if (count < byte_0.Length)
				{
					Array.Copy(buffer, offset, byte_1, int_0, count);
					int_0 += count;
					return;
				}
				class206_0.method_5(buffer, offset);
				int num2 = byte_0.Length;
				long_0 += num2;
				count -= num2;
				offset += num2;
			}
		}

		private void method_3()
		{
			Array.Clear(byte_0, 0, byte_0.Length);
			class206_0.method_4(byte_0);
		}
	}
}
