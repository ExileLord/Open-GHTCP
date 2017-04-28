using System;
using System.IO;
using System.Runtime.InteropServices;
using ns0;
using ns5;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Decoding;

namespace ns4
{
	public class MP3Stream : GenericAudioStream
	{
		private readonly int int_2;

		private readonly double double_0;

		private readonly long long_0;

		private long long_1;

		private zzSoundClass class107_0;

		private readonly Class83 class83_0;

		private readonly zzSoundClass81 class81_0;

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
					if (long_1 == 0L)
					{
						fileStream.Position = int_2;
					}
					else if (class83_0 != null)
					{
						fileStream.Position = int_2 + class83_0.method_0(value / (double)long_0);
					}
					else
					{
						fileStream.Position = (long)(value / double_0 + int_2);
					}
					class82_0.method_6();
					class82_0.method_7();
					class81_0.method_0().method_6();
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
            class81_0 = new zzSoundClass81(new Class104(enum4_0));
			fileStream = stream_1;
			class82_0 = new Class82(fileStream, int_5);
			int_2 = class82_0.method_2();
			long_0 = -1L;
			class107_0 = null;
			if (!method_0())
			{
				throw new Mp3Exception("Mp3 Decoder: Cannot read header.");
			}
			short_0 = (short)class81_0.method_2();
			int_4 = class81_0.method_1();
			waveFormat_0 = new WaveFormat(int_4, short_0);
			double_0 = waveFormat_0.int_0 * waveFormat_0.short_1 / (int_3 / 8.0);
			long_1 = 0L;
			if (class107_0 != null && class107_0.method_10())
			{
				long_0 = Convert.ToInt64(class107_0.method_18((int)(fileStream.Length - int_2)) * (waveFormat_0.int_0 * (waveFormat_0.short_1 / 1000.0)));
				class83_0 = class107_0.method_11();
				if (class83_0 != null && class83_0.int_2 == -1)
				{
					class83_0.int_2 = (int)(fileStream.Length - int_2);
				}
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
			float[] array = new float[int_5];
			int num = vmethod_4(array, 0, int_5);
			Marshal.Copy(array, 0, intptr_0, num);
			return num << 2;
		}

		public override int vmethod_4(float[] float_0, int int_5, int int_6)
		{
			int result;
			lock (object_0)
			{
				int num = 0;
				do
				{
					if (class81_0.method_0().method_0() <= 0)
					{
						if (!method_0())
						{
							break;
						}
					}
					num += class81_0.method_0().method_1(float_0, int_5 + num, int_6 - num);
				}
				while (num < int_6);
				long_1 += (long)num << 2;
				result = num;
			}
			return result;
		}

		public override float[][] vmethod_5(int int_5)
		{
			float[][] result;
			lock (object_0)
			{
				int num = vmethod_0().short_0;
				float[][] array = new float[num][];
				for (int i = 0; i < num; i++)
				{
					array[i] = new float[int_5];
				}
				int_5 *= num;
				int num2 = 0;
				do
				{
					if (class81_0.method_0().method_0() <= 0)
					{
						if (!method_0())
						{
							break;
						}
					}
					num2 += class81_0.method_0().method_3(array, num2, int_5 - num2);
				}
				while (num2 < int_5);
				long_1 += (long)num2 << 2;
				result = array;
			}
			return result;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (object_0)
			{
				int num = 0;
				do
				{
					if (class81_0.method_0().method_0() <= 0)
					{
						if (!method_0())
						{
							break;
						}
					}
					num += class81_0.method_0().method_2(buffer, offset + num, count - num);
				}
				while (num < count);
				long_1 += num;
				result = num;
			}
			return result;
		}

		public bool method_0()
		{
			zzSoundClass @class = class82_0.method_3();
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
				class81_0.method_5(@class, class82_0);
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
