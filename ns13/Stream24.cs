using Compression.Tar;
using System;
using System.IO;

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

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this.stream_0.SetLength(value);
		}

		public override int ReadByte()
		{
			return this.stream_0.ReadByte();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.stream_0.Read(buffer, offset, count);
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public void method_0()
		{
			if (this.method_1())
			{
				this.method_2();
			}
			this.method_3();
		}

		public override void Close()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.method_0();
				this.class206_0.method_8();
			}
		}

		private bool method_1()
		{
			return this.long_0 < this.long_1;
		}

		public void method_2()
		{
			if (this.int_0 > 0)
			{
				Array.Clear(this.byte_1, this.int_0, this.byte_1.Length - this.int_0);
				this.class206_0.method_4(this.byte_1);
				this.long_0 += (long)this.int_0;
				this.int_0 = 0;
			}
			if (this.long_0 < this.long_1)
			{
				string string_ = string.Format("Entry closed at '{0}' before the '{1}' bytes specified in the header were written", this.long_0, this.long_1);
				throw new TarException(string_);
			}
		}

		public override void WriteByte(byte value)
		{
			this.Write(new byte[]
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
			if (this.long_0 + (long)count > this.long_1)
			{
				string message = string.Format("request to write '{0}' bytes exceeds size in header of '{1}' bytes", count, this.long_1);
				throw new ArgumentOutOfRangeException("count", message);
			}
			if (this.int_0 > 0)
			{
				if (this.int_0 + count >= this.byte_0.Length)
				{
					int num = this.byte_0.Length - this.int_0;
					Array.Copy(this.byte_1, 0, this.byte_0, 0, this.int_0);
					Array.Copy(buffer, offset, this.byte_0, this.int_0, num);
					this.class206_0.method_4(this.byte_0);
					this.long_0 += (long)this.byte_0.Length;
					offset += num;
					count -= num;
					this.int_0 = 0;
				}
				else
				{
					Array.Copy(buffer, offset, this.byte_1, this.int_0, count);
					offset += count;
					this.int_0 += count;
					count -= count;
				}
			}
			while (count > 0)
			{
				if (count < this.byte_0.Length)
				{
					Array.Copy(buffer, offset, this.byte_1, this.int_0, count);
					this.int_0 += count;
					return;
				}
				this.class206_0.method_5(buffer, offset);
				int num2 = this.byte_0.Length;
				this.long_0 += (long)num2;
				count -= num2;
				offset += num2;
			}
		}

		private void method_3()
		{
			Array.Clear(this.byte_0, 0, this.byte_0.Length);
			this.class206_0.method_4(this.byte_0);
		}
	}
}
