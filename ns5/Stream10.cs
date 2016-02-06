using ns0;
using ns1;
using SharpAudio.ASC;
using System;
using System.IO;

namespace ns5
{
	public class Stream10 : Stream1
	{
		public int int_2;

		public double double_0;

		private bool bool_0;

		private int int_3;

		private readonly object object_0 = new object();

		private readonly Class111 class111_0 = new Class111();

		private int int_4 = -1;

		private int int_5 = -1;

		private short short_0 = -1;

		private MemoryStream memoryStream_0;

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
				return (long)((double)(this.stream_0.Length - (long)this.int_2) * this.double_0);
			}
		}

		public override long Position
		{
			get
			{
				return (long)((double)(this.stream_0.Position - (long)this.int_2) * this.double_0) - this.memoryStream_0.Length + this.memoryStream_0.Position;
			}
			set
			{
				this.stream_0.Position = (long)((double)value / this.double_0 + (double)this.int_2);
				this.memoryStream_0.Position = this.memoryStream_0.Length;
			}
		}

		public Stream10(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public Stream10(Stream stream_1) : this(stream_1, 4096)
		{
		}

		public Stream10(Stream stream_1, int int_6) : this(stream_1, int_6, true)
		{
		}

		public Stream10(Stream stream_1, int int_6, bool bool_1)
		{
			this.int_3 = (bool_1 ? 2 : 4);
			this.stream_0 = stream_1;
			this.bool_0 = bool_1;
			this.memoryStream_0 = new MemoryStream();
			if (!this.method_0())
			{
				throw new Exception("Ac3 Decoder: Cannot read header.");
			}
			this.int_2 = (int)stream_1.Position;
			this.waveFormat_0 = (bool_1 ? new WaveFormat(this.int_5, 16, (int)this.short_0) : new WaveFormat(this.int_5, (int)this.short_0));
			this.double_0 = (double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1) / ((double)this.int_4 / 8.0);
		}

		public override Class16 vmethod_1()
		{
			return new Class16(this.waveFormat_0, (uint)this.Position, (uint)this.Length);
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek((long)((double)offset / this.double_0) + (long)((origin == SeekOrigin.Begin) ? this.int_2 : 0), origin);
		}

		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (this.object_0)
			{
				int num = 0;
				do
				{
					if (this.memoryStream_0.Position == this.memoryStream_0.Length)
					{
						if (!this.method_0())
						{
							break;
						}
					}
					num += this.memoryStream_0.Read(buffer, offset + num, count - num);
				}
				while (num < count);
				result = num;
			}
			return result;
		}

		public override void Close()
		{
			this.stream_0.Close();
		}

		public bool method_0()
		{
			byte[] array = new byte[1792];
			this.stream_0.Read(array, 0, 1792);
			this.memoryStream_0 = new MemoryStream();
			this.class111_0.vmethod_0(array, this.memoryStream_0);
			this.short_0 = 2;
			this.int_5 = this.class111_0.int_2;
			this.int_4 = this.class111_0.int_3 / 1000;
			if (this.memoryStream_0.Length == 0L)
			{
				return false;
			}
			this.memoryStream_0.Position = 0L;
			return true;
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Close();
			}
		}

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
