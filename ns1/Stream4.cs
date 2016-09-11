using ns0;
using SharpAudio.ASC;
using System;
using System.Runtime.InteropServices;

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

		private readonly Stream4.Delegate0 delegate0_0;

		private readonly Stream4.Delegate1 delegate1_0;

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
				return this.long_0;
			}
		}

		public override long Position
		{
			get
			{
				long position = this.stream1_0.Position;
				if (!this.bool_0)
				{
					return position;
				}
				return (long)((double)position * this.double_0);
			}
			set
			{
				this.stream1_0.Position = (this.bool_0 ? ((long)((double)value / this.double_0)) : value);
			}
		}

		public Stream4(GenericAudioStream stream1_1, int int_4)
		{
			this.stream1_0 = stream1_1;
			this.fileStream = stream1_1;
			this.waveFormat_0 = stream1_1.vmethod_0();
			this.int_3 = int_4 + 7 >> 3;
			this.int_2 = this.waveFormat_0.short_2 + 7 >> 3;
			this.bool_1 = (this.waveFormat_0.waveFormatTag_0 == WaveFormatTag.IEEEFloat);
			this.bool_0 = (this.waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM || this.int_2 != this.int_3);
			if (!this.bool_0)
			{
				this.delegate1_0 = new Stream4.Delegate1(this.stream1_0.Read);
				this.long_0 = stream1_1.Length;
				return;
			}
			this.waveFormat_0 = new WaveFormat(stream1_1.vmethod_0().int_0, int_4, (int)stream1_1.vmethod_0().short_0);
			this.double_0 = (double)this.int_3 / (double)this.int_2;
			this.long_0 = (long)((double)stream1_1.Length * this.double_0);
			if (!this.bool_1)
			{
				switch (this.int_3)
				{
				case 1:
					switch (this.int_2)
					{
					case 2:
						this.delegate1_0 = new Stream4.Delegate1(this.method_2);
						return;
					case 3:
						this.delegate1_0 = new Stream4.Delegate1(this.method_1);
						return;
					case 4:
						this.delegate1_0 = new Stream4.Delegate1(this.method_0);
						return;
					default:
						return;
					}
					break;
				case 2:
					switch (this.int_2)
					{
					case 1:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_8);
						break;
					case 3:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_7);
						break;
					case 4:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_6);
						break;
					}
					break;
				case 3:
					switch (this.int_2)
					{
					case 1:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_5);
						break;
					case 2:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_4);
						break;
					case 4:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_3);
						break;
					}
					break;
				case 4:
					switch (this.int_2)
					{
					case 1:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_2);
						break;
					case 2:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_1);
						break;
					case 3:
						this.delegate0_0 = new Stream4.Delegate0(Stream4.smethod_0);
						break;
					}
					break;
				}
				this.delegate1_0 = new Stream4.Delegate1(this.method_3);
				return;
			}
			switch (this.int_3)
			{
			case 1:
				this.delegate1_0 = new Stream4.Delegate1(this.method_7);
				return;
			case 2:
				this.delegate1_0 = new Stream4.Delegate1(this.method_6);
				return;
			case 3:
				this.delegate1_0 = new Stream4.Delegate1(this.method_5);
				return;
			case 4:
				this.delegate1_0 = new Stream4.Delegate1(this.method_4);
				return;
			default:
				return;
			}
		}

		private int method_0(byte[] byte_0, int int_4, int int_5)
		{
			byte[] array = new byte[int_5 << 2];
			int num = this.stream1_0.Read(array, 0, array.Length);
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
			int num = this.stream1_0.Read(array, 0, array.Length);
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
			int num = this.stream1_0.Read(array, 0, array.Length);
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
			byte[] array = new byte[(int)((double)int_5 / this.double_0)];
			int num = this.stream1_0.Read(array, 0, array.Length);
			int i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(this.delegate0_0(array, i), 0, byte_0, int_4, this.int_3);
				i += this.int_2;
				int_4 += this.int_3;
			}
			return (int)((double)num * this.double_0);
		}

		private int method_4(byte[] byte_0, int int_4, int int_5)
		{
			float[] array = new float[int_5 >> 2];
			int num = this.stream1_0.vmethod_4(array, 0, array.Length);
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
			int num = this.stream1_0.vmethod_4(array, 0, array.Length);
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
			int num = this.stream1_0.vmethod_4(array, 0, array.Length);
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
			int num = this.stream1_0.vmethod_4(array, 0, array.Length);
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
			int num = this.Read(array, 0, int_4);
			Marshal.Copy(array, 0, intptr_0, num);
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.delegate1_0(buffer, offset, count);
		}

		public override int vmethod_4(float[] float_0, int int_4, int int_5)
		{
			return this.stream1_0.vmethod_4(float_0, int_4, int_5);
		}

		public override float[][] vmethod_5(int int_4)
		{
			return this.stream1_0.vmethod_5(int_4);
		}
	}
}
