using ns0;
using ns5;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Decoding;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ns4
{
	public class MP3Stream : GenericAudioStream
	{
		private readonly int int_2;

		private readonly double double_0;

		private readonly long long_0;

		private long long_1;

		private Class107 class107_0;

		private readonly Class83 class83_0;

		private readonly Class81 class81_0;

		private readonly Class82 class82_0;

		private int int_3 = -1;

		private readonly int int_4 = -1;

		private readonly short short_0 = -1;

		private readonly object object_0 = new object();

		public override bool CanRead
		{
			get
			{
				return this.fileStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.fileStream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.fileStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this.long_0;
			}
		}

		public override long Position
		{
			get
			{
				return this.long_1;
			}
			set
			{
				lock (this.object_0)
				{
					this.long_1 = value;
					if (this.long_1 == 0L)
					{
						this.fileStream.Position = (long)this.int_2;
					}
					else if (this.class83_0 != null)
					{
						this.fileStream.Position = (long)(this.int_2 + this.class83_0.method_0((double)value / (double)this.long_0));
					}
					else
					{
						this.fileStream.Position = (long)((double)value / this.double_0 + (double)this.int_2);
					}
					this.class82_0.method_6();
					this.class82_0.method_7();
					this.class81_0.method_0().method_6();
				}
			}
		}

		public MP3Stream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public MP3Stream(Stream stream_1) : this(stream_1, Enum4.const_0, 4096)
		{
		}

		public MP3Stream(Stream stream_1, Enum4 enum4_0) : this(stream_1, enum4_0, 4096)
		{
		}

		public MP3Stream(Stream stream_1, Enum4 enum4_0, int int_5)
		{
            this.class81_0 = new Class81(new Class104(enum4_0));
			this.fileStream = stream_1;
			this.class82_0 = new Class82(this.fileStream, int_5);
			this.int_2 = this.class82_0.method_2();
			this.long_0 = -1L;
			this.class107_0 = null;
			if (!this.method_0())
			{
				throw new Mp3Exception("Mp3 Decoder: Cannot read header.");
			}
			this.short_0 = (short)this.class81_0.method_2();
			this.int_4 = this.class81_0.method_1();
			this.waveFormat_0 = new WaveFormat(this.int_4, (int)this.short_0);
			this.double_0 = (double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1) / ((double)this.int_3 / 8.0);
			this.long_1 = 0L;
			if (this.class107_0 != null && this.class107_0.method_10())
			{
				this.long_0 = Convert.ToInt64(this.class107_0.method_18((int)(this.fileStream.Length - (long)this.int_2)) * ((double)this.waveFormat_0.int_0 * ((double)this.waveFormat_0.short_1 / 1000.0)));
				this.class83_0 = this.class107_0.method_11();
				if (this.class83_0 != null && this.class83_0.int_2 == -1)
				{
					this.class83_0.int_2 = (int)(this.fileStream.Length - (long)this.int_2);
				}
			}
			if (this.long_0 <= 0L)
			{
				this.long_0 = (long)((double)(this.fileStream.Length - (long)this.int_2) * this.double_0);
			}
		}

		public override void Flush()
		{
			this.fileStream.Flush();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void Close()
		{
			this.class82_0.method_1();
			this.fileStream.Close();
		}

		public override int vmethod_3(IntPtr intptr_0, int int_5)
		{
			int_5 >>= 2;
			float[] array = new float[int_5];
			int num = this.vmethod_4(array, 0, int_5);
			Marshal.Copy(array, 0, intptr_0, num);
			return num << 2;
		}

		public override int vmethod_4(float[] float_0, int int_5, int int_6)
		{
			int result;
			lock (this.object_0)
			{
				int num = 0;
				do
				{
					if (this.class81_0.method_0().method_0() <= 0)
					{
						if (!this.method_0())
						{
							break;
						}
					}
					num += this.class81_0.method_0().method_1(float_0, int_5 + num, int_6 - num);
				}
				while (num < int_6);
				this.long_1 += (long)((long)num << 2);
				result = num;
			}
			return result;
		}

		public override float[][] vmethod_5(int int_5)
		{
			float[][] result;
			lock (this.object_0)
			{
				int num = (int)this.vmethod_0().short_0;
				float[][] array = new float[num][];
				for (int i = 0; i < num; i++)
				{
					array[i] = new float[int_5];
				}
				int_5 *= num;
				int num2 = 0;
				do
				{
					if (this.class81_0.method_0().method_0() <= 0)
					{
						if (!this.method_0())
						{
							break;
						}
					}
					num2 += this.class81_0.method_0().method_3(array, num2, int_5 - num2);
				}
				while (num2 < int_5);
				this.long_1 += (long)((long)num2 << 2);
				result = array;
			}
			return result;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (this.object_0)
			{
				int num = 0;
				do
				{
					if (this.class81_0.method_0().method_0() <= 0)
					{
						if (!this.method_0())
						{
							break;
						}
					}
					num += this.class81_0.method_0().method_2(buffer, offset + num, count - num);
				}
				while (num < count);
				this.long_1 += (long)num;
				result = num;
			}
			return result;
		}

		public bool method_0()
		{
			Class107 @class = this.class82_0.method_3();
			if (@class == null)
			{
				return false;
			}
			if (this.class107_0 == null)
			{
				this.class107_0 = @class;
			}
			try
			{
				this.int_3 = @class.method_21();
				this.class81_0.method_5(@class, this.class82_0);
			}
			finally
			{
				this.class82_0.method_7();
			}
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
