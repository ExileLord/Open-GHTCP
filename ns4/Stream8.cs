using ns0;
using ns5;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Decoding;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ns4
{
	public class Stream8 : Stream1
	{
		private readonly int int_2;

		private readonly double double_0;

		private readonly long long_0;

		private long long_1;

		private Class107 class107_0;

		private readonly Class81[] class81_0;

		private readonly Class82 class82_0;

		private int int_3 = -1;

		private readonly int int_4 = -1;

		private readonly short short_0 = -1;

		private readonly object object_0 = new object();

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
					this.stream_0.Position = (long)this.int_2;
					this.class82_0.method_6();
					this.class82_0.method_7();
					for (int i = 0; i < this.class81_0.Length; i++)
					{
						this.class81_0[i].method_0().method_6();
					}
					if (this.long_1 != 0L)
					{
						long num = (long)((double)value / this.double_0 + (double)this.int_2);
						Class107 @class = this.class82_0.method_3();
						while (this.stream_0.Position + (long)(@class.int_12 * this.class81_0.Length) < num)
						{
							for (int j = 0; j < this.class81_0.Length; j++)
							{
								this.class82_0.method_7();
								@class = this.class82_0.method_3();
								if (@class == null)
								{
									return;
								}
							}
						}
						try
						{
							this.int_3 = @class.method_21();
							this.class81_0[0].method_5(@class, this.class82_0);
						}
						finally
						{
							this.class82_0.method_7();
						}
						for (int k = 1; k < this.class81_0.Length; k++)
						{
							if (!this.method_1(k))
							{
								break;
							}
						}
					}
				}
			}
		}

		public Stream8(Stream stream_1, int int_5, Enum4 enum4_0) : this(stream_1, int_5, enum4_0, 4096)
		{
		}

		public Stream8(Stream stream_1, int int_5, Enum4 enum4_0, int int_6)
		{
			this.class81_0 = new Class81[int_5];
			for (int i = 0; i < this.class81_0.Length; i++)
			{
				this.class81_0[i] = new Class81(new Class104(enum4_0));
			}
			this.stream_0 = stream_1;
			this.class82_0 = new Class82(this.stream_0, int_6);
			this.int_2 = this.class82_0.method_2();
			this.long_0 = -1L;
			this.class107_0 = null;
			if (!this.method_0())
			{
				throw new Mp3Exception("Mp3 Decoder: Cannot read header.");
			}
			this.short_0 = 0;
			for (int j = 0; j < this.class81_0.Length; j++)
			{
				this.short_0 += (short)this.class81_0[j].method_2();
			}
			this.int_4 = this.class81_0[0].method_1();
			this.waveFormat_0 = new WaveFormat(this.int_4, (int)this.short_0);
			this.double_0 = (double)(this.waveFormat_0.int_0 * ((int)this.waveFormat_0.short_1 / this.class81_0.Length)) / ((double)this.int_3 / 8.0);
			this.long_1 = 0L;
			if (this.class107_0 != null && this.class107_0.method_10())
			{
				this.long_0 = Convert.ToInt64(this.class107_0.method_18((int)(this.stream_0.Length - (long)this.int_2) / this.class81_0.Length) * ((double)this.waveFormat_0.int_0 * ((double)this.waveFormat_0.short_1 / 1000.0)));
			}
			if (this.long_0 <= 0L)
			{
				this.long_0 = (long)((double)(this.stream_0.Length - (long)this.int_2) * this.double_0);
			}
		}

		public override void Flush()
		{
			this.stream_0.Flush();
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
			this.stream_0.Close();
		}

		public override int vmethod_3(IntPtr intptr_0, int int_5)
		{
			int_5 >>= 2;
			float[] array = new float[int_5];
			int num = this.vmethod_4(array, 0, int_5);
			Marshal.Copy(array, 0, intptr_0, num);
			return num << 2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.class81_0.Length == 1)
			{
				int result;
				lock (this.object_0)
				{
					int num = 0;
					do
					{
						if (this.class81_0[0].method_0().method_0() <= 0)
						{
							if (!this.method_1(0))
							{
								break;
							}
						}
						num += this.class81_0[0].method_0().method_2(buffer, offset + num, count - num);
					}
					while (num < count);
					this.long_1 += (long)num;
					result = num;
				}
				return result;
			}
			count >>= 2;
			float[] array = new float[count];
			int num2 = this.vmethod_4(array, 0, count);
			Buffer.BlockCopy(array, 0, buffer, offset, num2);
			return num2 << 2;
		}

		public override int vmethod_4(float[] float_0, int int_5, int int_6)
		{
			if (this.class81_0.Length == 1)
			{
				int result;
				lock (this.object_0)
				{
					int num = 0;
					do
					{
						if (this.class81_0[0].method_0().method_0() <= 0)
						{
							if (!this.method_1(0))
							{
								break;
							}
						}
						num += this.class81_0[0].method_0().method_1(float_0, int_5 + num, int_6 - num);
					}
					while (num < int_6);
					this.long_1 += (long)((long)num << 2);
					result = num;
				}
				return result;
			}
			float[][] array = this.vmethod_5(int_6 / (int)this.waveFormat_0.short_0);
			if (array == null)
			{
				return 0;
			}
			int num2 = 0;
			float[][] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				float[] array3 = array2[i];
				num2 = Math.Max(array3.Length, num2);
			}
			num2 *= (int)this.waveFormat_0.short_0;
			int num3 = array.Length;
			for (int j = 0; j < num3; j++)
			{
				float[] array4 = array[j];
				int k = 0;
				int num4 = int_5 + j;
				while (k < array4.Length)
				{
					float_0[num4] = array4[k];
					k++;
					num4 += num3;
				}
			}
			return num2;
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
					if (this.class81_0[0].method_0().method_0() <= 0)
					{
						if (!this.method_0())
						{
							break;
						}
					}
					int num3 = 0;
					int int_6 = num2 / this.class81_0.Length;
					int int_7 = (int_5 - num2) / this.class81_0.Length;
					for (int j = 0; j < this.class81_0.Length; j++)
					{
						float[][] array2 = new float[this.class81_0[j].method_2()][];
						int k = 0;
						while (k < array2.Length)
						{
							array2[k] = array[num3];
							k++;
							num3++;
						}
						num2 += this.class81_0[j].method_0().method_3(array2, int_6, int_7);
					}
				}
				while (num2 < int_5);
				this.long_1 += (long)((long)num2 << 2);
				result = array;
			}
			return result;
		}

		public bool method_0()
		{
			for (int i = 0; i < this.class81_0.Length; i++)
			{
				if (!this.method_1(i))
				{
					return false;
				}
			}
			return true;
		}

		public bool method_1(int int_5)
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
				this.class81_0[int_5].method_5(@class, this.class82_0);
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
