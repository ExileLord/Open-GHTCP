using ns0;
using System;
using System.IO;

namespace ns1
{
	public class Stream3 : Stream1
	{
		private readonly Stream1 stream1_0;

		private readonly long long_0;

		private readonly long long_1;

		private long long_2;

		public override bool CanRead
		{
			get
			{
				return this.stream1_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.stream1_0.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.stream1_0.CanWrite;
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
				if (value < 0L || value >= this.long_1)
				{
					throw new IOException("Seeking position out of range.");
				}
				this.stream1_0.Position = (this.long_2 = this.long_0 + value);
			}
		}

		private long method_0()
		{
			return Math.Max(this.long_0 + this.long_1 - this.long_2, 0L);
		}

		private Stream3(Stream1 stream1_1)
		{
			this.stream1_0 = stream1_1;
			this.stream_0 = stream1_1;
			this.waveFormat_0 = stream1_1.vmethod_0();
		}

		public Stream3(Stream1 stream1_1, long long_3, long long_4) : this(stream1_1)
		{
			if (0L > long_3)
			{
				throw new ArgumentException("Start Offset is out of range.");
			}
			if (stream1_1.Length < long_4)
			{
				throw new ArgumentException("End Offset is out of range.");
			}
			if (long_3 >= long_4)
			{
				throw new ArgumentException("Start/End Offset are out of range.");
			}
			this.long_1 = long_4 - long_3;
			Stream arg_63_0 = this.stream1_0;
			this.long_0 = long_3;
			this.long_2 = long_3;
			arg_63_0.Position = long_3;
		}

		public Stream3(Stream1 stream1_1, TimeSpan timeSpan_0, TimeSpan timeSpan_1) : this(stream1_1, (long)Convert.ToInt32((double)(stream1_1.vmethod_0().int_0 * (int)stream1_1.vmethod_0().short_1) * timeSpan_0.TotalSeconds), (long)Convert.ToInt32((double)(stream1_1.vmethod_0().int_0 * (int)stream1_1.vmethod_0().short_1) * timeSpan_1.TotalSeconds))
		{
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override int vmethod_3(IntPtr intptr_0, int int_2)
		{
			int result;
			lock (this.stream1_0)
			{
				if (this.vmethod_2().Position != this.long_2)
				{
					this.vmethod_2().Position = this.long_2;
				}
				int_2 = (int)Math.Min((long)int_2, this.method_0());
				int num = this.stream1_0.vmethod_3(intptr_0, int_2);
				this.long_2 += (long)num;
				result = num;
			}
			return result;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (this.stream1_0)
			{
				if (this.vmethod_2().Position != this.long_2)
				{
					this.vmethod_2().Position = this.long_2;
				}
				count = (int)Math.Min((long)count, this.method_0());
				int num = this.stream1_0.Read(buffer, offset, count);
				this.long_2 += (long)num;
				result = num;
			}
			return result;
		}

		public override int vmethod_4(float[] float_0, int int_2, int int_3)
		{
			int result;
			lock (this.stream1_0)
			{
				if (this.vmethod_2().Position != this.long_2)
				{
					this.vmethod_2().Position = this.long_2;
				}
				int_3 = (int)Math.Min((long)int_3, this.method_0() >> 2);
				int num = this.stream1_0.vmethod_4(float_0, int_2, int_3);
				this.long_2 += (long)((long)num << 2);
				result = num;
			}
			return result;
		}

		public override float[][] vmethod_5(int int_2)
		{
			float[][] result;
			lock (this.stream1_0)
			{
				if (this.vmethod_2().Position != this.long_2)
				{
					this.vmethod_2().Position = this.long_2;
				}
				int_2 = (int)Math.Min((long)int_2, (this.method_0() >> 2) / (long)this.waveFormat_0.short_0);
				if (int_2 == 0)
				{
					result = null;
				}
				else
				{
					float[][] array = this.stream1_0.vmethod_5(int_2);
					if (array != null && array.Length >= 1)
					{
						this.long_2 += (long)((array[0].Length << 2) * array.Length);
						result = array;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}
	}
}
