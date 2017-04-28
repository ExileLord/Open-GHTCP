using System;
using System.Runtime.InteropServices;
using ns0;
using SharpAudio.ASC;

namespace ns1
{
	public class Stream4 : GenericAudioStream
	{
		private delegate byte[] Delegate0(byte[] buffer, int index);

		private delegate int Delegate1(byte[] buffer, int index, int count);

		private readonly GenericAudioStream stream1_0;

		private readonly int int_2;

		private readonly int int_3;

		private readonly long long_0;

		private readonly double double_0 = 1.0;

		private readonly bool bool_0;

		private readonly bool bool_1;

		private readonly Delegate0 delegate0_0;

		private readonly Delegate1 delegate1_0;

		public override bool CanRead
		{
			get
			{
				return stream1_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return stream1_0.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return stream1_0.CanWrite;
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
				long position = stream1_0.Position;
				if (!bool_0)
				{
					return position;
				}
				return (long)(position * double_0);
			}
			set
			{
				stream1_0.Position = (bool_0 ? ((long)(value / double_0)) : value);
			}
		}

		public Stream4(GenericAudioStream stream1_1, int int_4)
		{
			stream1_0 = stream1_1;
			fileStream = stream1_1;
			waveFormat_0 = stream1_1.vmethod_0();
			int_3 = int_4 + 7 >> 3;
			int_2 = waveFormat_0.short_2 + 7 >> 3;
			bool_1 = (waveFormat_0.waveFormatTag_0 == WaveFormatTag.IEEEFloat);
			bool_0 = (waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM || int_2 != int_3);
			if (!bool_0)
			{
				delegate1_0 = stream1_0.Read;
				long_0 = stream1_1.Length;
				return;
			}
			waveFormat_0 = new WaveFormat(stream1_1.vmethod_0().int_0, int_4, stream1_1.vmethod_0().short_0);
			double_0 = int_3 / (double)int_2;
			long_0 = (long)(stream1_1.Length * double_0);
			if (!bool_1)
			{
				switch (int_3)
				{
				case 1:
					switch (int_2)
					{
					case 2:
						delegate1_0 = method_2;
						return;
					case 3:
						delegate1_0 = method_1;
						return;
					case 4:
						delegate1_0 = method_0;
						return;
					default:
						return;
					}
					break;
				case 2:
					switch (int_2)
					{
					case 1:
						delegate0_0 = smethod_8;
						break;
					case 3:
						delegate0_0 = smethod_7;
						break;
					case 4:
						delegate0_0 = smethod_6;
						break;
					}
					break;
				case 3:
					switch (int_2)
					{
					case 1:
						delegate0_0 = smethod_5;
						break;
					case 2:
						delegate0_0 = smethod_4;
						break;
					case 4:
						delegate0_0 = smethod_3;
						break;
					}
					break;
				case 4:
					switch (int_2)
					{
					case 1:
						delegate0_0 = smethod_2;
						break;
					case 2:
						delegate0_0 = smethod_1;
						break;
					case 3:
						delegate0_0 = smethod_0;
						break;
					}
					break;
				}
				delegate1_0 = method_3;
				return;
			}
			switch (int_3)
			{
			case 1:
				delegate1_0 = method_7;
				return;
			case 2:
				delegate1_0 = method_6;
				return;
			case 3:
				delegate1_0 = method_5;
				return;
			case 4:
				delegate1_0 = method_4;
				return;
			default:
				return;
			}
		}

		private int method_0(byte[] byte_0, int int_4, int int_5)
		{
			byte[] array = new byte[int_5 << 2];
			int num = stream1_0.Read(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				byte_0[int_4] = Class11.smethod_12(BitConverter.ToInt32(byte_0, i));
				i += 4;
				int_4++;
			}
			return num >> 2;
		}

		private int method_1(byte[] byte_0, int int_4, int int_5)
		{
			byte[] array = new byte[int_5 + int_5 + int_5];
			int num = stream1_0.Read(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				byte_0[int_4] = Class11.smethod_8(Struct8.smethod_2(byte_0, i));
				i += 3;
				int_4++;
			}
			return num / 3;
		}

		private int method_2(byte[] byte_0, int int_4, int int_5)
		{
			byte[] array = new byte[int_5 << 1];
			int num = stream1_0.Read(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				byte_0[int_4] = Class11.smethod_4(BitConverter.ToInt16(byte_0, i));
				i += 2;
				int_4++;
			}
			return num >> 1;
		}

		private static byte[] smethod_0(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_10(Struct8.smethod_2(byte_0, int_4)));
		}

		private static byte[] smethod_1(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_6(BitConverter.ToInt16(byte_0, int_4)));
		}

		private static byte[] smethod_2(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_2(byte_0[int_4]));
		}

		private static byte[] smethod_3(byte[] byte_0, int int_4)
		{
			return Struct8.smethod_4(Class11.smethod_14(BitConverter.ToInt32(byte_0, int_4)));
		}

		private static byte[] smethod_4(byte[] byte_0, int int_4)
		{
			return Struct8.smethod_4(Class11.smethod_5(BitConverter.ToInt16(byte_0, int_4)));
		}

		private static byte[] smethod_5(byte[] byte_0, int int_4)
		{
			return Struct8.smethod_4(Class11.smethod_1(byte_0[int_4]));
		}

		private static byte[] smethod_6(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_13(BitConverter.ToInt32(byte_0, int_4)));
		}

		private static byte[] smethod_7(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_9(Struct8.smethod_2(byte_0, int_4)));
		}

		private static byte[] smethod_8(byte[] byte_0, int int_4)
		{
			return BitConverter.GetBytes(Class11.smethod_0(byte_0[int_4]));
		}

		private int method_3(byte[] byte_0, int int_4, int int_5)
		{
			byte[] array = new byte[(int)(int_5 / double_0)];
			int num = stream1_0.Read(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(delegate0_0(array, i), 0, byte_0, int_4, int_3);
				i += int_2;
				int_4 += int_3;
			}
			return (int)(num * double_0);
		}

		private int method_4(byte[] byte_0, int int_4, int int_5)
		{
			float[] array = new float[int_5 >> 2];
			int num = stream1_0.vmethod_4(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Class11.smethod_25(array[i])), 0, byte_0, int_4, 4);
				i++;
				int_4 += 4;
			}
			return num << 2;
		}

		private int method_5(byte[] byte_0, int int_4, int int_5)
		{
			float[] array = new float[int_5 / 3];
			int num = stream1_0.vmethod_4(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(Struct8.smethod_4(Class11.smethod_23(array[i])), 0, byte_0, int_4, 3);
				i++;
				int_4 += 3;
			}
			return num + num + num;
		}

		private int method_6(byte[] byte_0, int int_4, int int_5)
		{
			float[] array = new float[int_5 >> 1];
			int num = stream1_0.vmethod_4(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Class11.smethod_21(array[i])), 0, byte_0, int_4, 2);
				i++;
				int_4 += 2;
			}
			return num << 1;
		}

		private int method_7(byte[] byte_0, int int_4, int int_5)
		{
			float[] array = new float[int_5];
			int num = stream1_0.vmethod_4(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				byte_0[int_4] = Class11.smethod_17(array[i]);
				i++;
				int_4++;
			}
			return num;
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override int vmethod_3(IntPtr intptr_0, int int_4)
		{
			byte[] array = new byte[int_4];
			int num = Read(array, 0, int_4);
			Marshal.Copy(array, 0, intptr_0, num);
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return delegate1_0(buffer, offset, count);
		}

		public override int vmethod_4(float[] float_0, int int_4, int int_5)
		{
			return stream1_0.vmethod_4(float_0, int_4, int_5);
		}

		public override float[][] vmethod_5(int int_4)
		{
			return stream1_0.vmethod_5(int_4);
		}
	}
}
