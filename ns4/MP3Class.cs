using System;
using System.IO;
using System.Runtime.InteropServices;
using ns0;
using ns5;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Decoding;

namespace ns4
{
	public class MP3Class : GenericAudioStream
	{
		private readonly int int_2;

		private readonly double double_0;

		private readonly long long_0;

		private long long_1;

		private zzSoundClass class107_0;

		private readonly zzSoundClass81[] class81_0;

		private readonly Class82 class82_0;

		private int int_3 = -1;

		private readonly int int_4 = -1;

		private readonly short short_0 = -1;

		private readonly object object_0 = new object();

		public override bool CanRead
		{
			get
			{
				return fileStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return fileStream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return fileStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return long_0;
			}
		}

		public override long Position
		{
			get
			{
				return long_1;
			}
			set
			{
				lock (object_0)
				{
					long_1 = value;
					fileStream.Position = int_2;
					class82_0.method_6();
					class82_0.method_7();
					for (var i = 0; i < class81_0.Length; i++)
					{
						class81_0[i].method_0().method_6();
					}
					if (long_1 != 0L)
					{
						var num = (long)(value / double_0 + int_2);
						var @class = class82_0.method_3();
						while (fileStream.Position + @class.int_12 * class81_0.Length < num)
						{
							for (var j = 0; j < class81_0.Length; j++)
							{
								class82_0.method_7();
								@class = class82_0.method_3();
								if (@class == null)
								{
									return;
								}
							}
						}
						try
						{
							int_3 = @class.method_21();
							class81_0[0].method_5(@class, class82_0);
						}
						finally
						{
							class82_0.method_7();
						}
						for (var k = 1; k < class81_0.Length; k++)
						{
							if (!method_1(k))
							{
								break;
							}
						}
					}
				}
			}
		}

		public MP3Class(Stream stream_1, int int_5, Enum4 enum4_0) : this(stream_1, int_5, enum4_0, 4096)
		{
		}

		public MP3Class(Stream stream_1, int int_5, Enum4 enum4_0, int int_6)
		{
			class81_0 = new zzSoundClass81[int_5];
			for (var i = 0; i < class81_0.Length; i++)
			{
				class81_0[i] = new zzSoundClass81(new Class104(enum4_0));
			}
			fileStream = stream_1;
			class82_0 = new Class82(fileStream, int_6);
			int_2 = class82_0.method_2();
			long_0 = -1L;
			class107_0 = null;
			if (!method_0())
			{
				throw new Mp3Exception("Mp3 Decoder: Cannot read header.");
			}
			short_0 = 0;
			for (var j = 0; j < class81_0.Length; j++)
			{
				short_0 += (short)class81_0[j].method_2();
			}
			int_4 = class81_0[0].method_1();
			waveFormat_0 = new WaveFormat(int_4, short_0);
			double_0 = waveFormat_0.int_0 * (waveFormat_0.short_1 / class81_0.Length) / (int_3 / 8.0);
			long_1 = 0L;
			if (class107_0 != null && class107_0.method_10())
			{
				long_0 = Convert.ToInt64(class107_0.method_18((int)(fileStream.Length - int_2) / class81_0.Length) * (waveFormat_0.int_0 * (waveFormat_0.short_1 / 1000.0)));
			}
			if (long_0 <= 0L)
			{
				long_0 = (long)((fileStream.Length - int_2) * double_0);
			}
		}

		public override void Flush()
		{
			fileStream.Flush();
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
			class82_0.method_1();
			fileStream.Close();
		}

		public override int vmethod_3(IntPtr intptr_0, int int_5)
		{
			int_5 >>= 2;
			var array = new float[int_5];
			var num = vmethod_4(array, 0, int_5);
			Marshal.Copy(array, 0, intptr_0, num);
			return num << 2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (class81_0.Length == 1)
			{
				int result;
				lock (object_0)
				{
					var num = 0;
					do
					{
						if (class81_0[0].method_0().method_0() <= 0)
						{
							if (!method_1(0))
							{
								break;
							}
						}
						num += class81_0[0].method_0().method_2(buffer, offset + num, count - num);
					}
					while (num < count);
					long_1 += num;
					result = num;
				}
				return result;
			}
			count >>= 2;
			var array = new float[count];
			var num2 = vmethod_4(array, 0, count);
			Buffer.BlockCopy(array, 0, buffer, offset, num2);
			return num2 << 2;
		}

		public override int vmethod_4(float[] float_0, int int_5, int int_6)
		{
			if (class81_0.Length == 1)
			{
				int result;
				lock (object_0)
				{
					var num = 0;
					do
					{
						if (class81_0[0].method_0().method_0() <= 0)
						{
							if (!method_1(0))
							{
								break;
							}
						}
						num += class81_0[0].method_0().method_1(float_0, int_5 + num, int_6 - num);
					}
					while (num < int_6);
					long_1 += (long)num << 2;
					result = num;
				}
				return result;
			}
			var array = vmethod_5(int_6 / waveFormat_0.short_0);
			if (array == null)
			{
				return 0;
			}
			var num2 = 0;
			var array2 = array;
			for (var i = 0; i < array2.Length; i++)
			{
				var array3 = array2[i];
				num2 = Math.Max(array3.Length, num2);
			}
			num2 *= waveFormat_0.short_0;
			var num3 = array.Length;
			for (var j = 0; j < num3; j++)
			{
				var array4 = array[j];
				var k = 0;
				var num4 = int_5 + j;
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
			lock (object_0)
			{
				int num = vmethod_0().short_0;
				var array = new float[num][];
				for (var i = 0; i < num; i++)
				{
					array[i] = new float[int_5];
				}
				int_5 *= num;
				var num2 = 0;
				do
				{
					if (class81_0[0].method_0().method_0() <= 0)
					{
						if (!method_0())
						{
							break;
						}
					}
					var num3 = 0;
					var int_6 = num2 / class81_0.Length;
					var int_7 = (int_5 - num2) / class81_0.Length;
					for (var j = 0; j < class81_0.Length; j++)
					{
						var array2 = new float[class81_0[j].method_2()][];
						var k = 0;
						while (k < array2.Length)
						{
							array2[k] = array[num3];
							k++;
							num3++;
						}
						num2 += class81_0[j].method_0().method_3(array2, int_6, int_7);
					}
				}
				while (num2 < int_5);
				long_1 += (long)num2 << 2;
				result = array;
			}
			return result;
		}

		public bool method_0()
		{
			for (var i = 0; i < class81_0.Length; i++)
			{
				if (!method_1(i))
				{
					return false;
				}
			}
			return true;
		}

		public bool method_1(int int_5)
		{
			var @class = class82_0.method_3();
			if (@class == null)
			{
				return false;
			}
			if (class107_0 == null)
			{
				class107_0 = @class;
			}
			try
			{
				int_3 = @class.method_21();
				class81_0[int_5].method_5(@class, class82_0);
			}
			finally
			{
				class82_0.method_7();
			}
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Close();
			}
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
