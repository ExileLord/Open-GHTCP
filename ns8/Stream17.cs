using System;
using System.IO;

namespace ns8
{
	public class Stream17 : Stream
	{
		public Stream stream_0;

		public byte[] byte_0;

		private static readonly byte[] byte_1 = new byte[]
		{
			0,
			128,
			64,
			192,
			32,
			160,
			96,
			224,
			16,
			144,
			80,
			208,
			48,
			176,
			112,
			240,
			8,
			136,
			72,
			200,
			40,
			168,
			104,
			232,
			24,
			152,
			88,
			216,
			56,
			184,
			120,
			248,
			4,
			132,
			68,
			196,
			36,
			164,
			100,
			228,
			20,
			148,
			84,
			212,
			52,
			180,
			116,
			244,
			12,
			140,
			76,
			204,
			44,
			172,
			108,
			236,
			28,
			156,
			92,
			220,
			60,
			188,
			124,
			252,
			2,
			130,
			66,
			194,
			34,
			162,
			98,
			226,
			18,
			146,
			82,
			210,
			50,
			178,
			114,
			242,
			10,
			138,
			74,
			202,
			42,
			170,
			106,
			234,
			26,
			154,
			90,
			218,
			58,
			186,
			122,
			250,
			6,
			134,
			70,
			198,
			38,
			166,
			102,
			230,
			22,
			150,
			86,
			214,
			54,
			182,
			118,
			246,
			14,
			142,
			78,
			206,
			46,
			174,
			110,
			238,
			30,
			158,
			94,
			222,
			62,
			190,
			126,
			254,
			1,
			129,
			65,
			193,
			33,
			161,
			97,
			225,
			17,
			145,
			81,
			209,
			49,
			177,
			113,
			241,
			9,
			137,
			73,
			201,
			41,
			169,
			105,
			233,
			25,
			153,
			89,
			217,
			57,
			185,
			121,
			249,
			5,
			133,
			69,
			197,
			37,
			165,
			101,
			229,
			21,
			149,
			85,
			213,
			53,
			181,
			117,
			245,
			13,
			141,
			77,
			205,
			45,
			173,
			109,
			237,
			29,
			157,
			93,
			221,
			61,
			189,
			125,
			253,
			3,
			131,
			67,
			195,
			35,
			163,
			99,
			227,
			19,
			147,
			83,
			211,
			51,
			179,
			115,
			243,
			11,
			139,
			75,
			203,
			43,
			171,
			107,
			235,
			27,
			155,
			91,
			219,
			59,
			187,
			123,
			251,
			7,
			135,
			71,
			199,
			39,
			167,
			103,
			231,
			23,
			151,
			87,
			215,
			55,
			183,
			119,
			247,
			15,
			143,
			79,
			207,
			47,
			175,
			111,
			239,
			31,
			159,
			95,
			223,
			63,
			191,
			127,
			255
		};

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

		public long method_0()
		{
			return this.stream_0.Position % this.byte_0.LongLength;
		}

		public Stream17(Stream stream_1, byte[] byte_2)
		{
			if (stream_1 == null)
			{
				throw new ArgumentNullException("BaseStream", "Fsb Encryption");
			}
			if (byte_2 == null)
			{
				throw new ArgumentNullException("Key", "Fsb Encryption");
			}
			this.stream_0 = stream_1;
			this.byte_0 = byte_2;
		}

		public Stream17(Stream stream_1) : this(stream_1, Stream17.smethod_0(stream_1))
		{
		}

		private static byte[] smethod_0(Stream stream_1)
		{
			long position = stream_1.Position;
			byte[] array = new byte[65536];
			int num = stream_1.Read(array, 0, array.Length);
			Array.Resize<byte>(ref array, num);
			int i = 2;
			while (i < 50)
			{
				byte[] result = Stream17.smethod_1(array, i);
				stream_1.Position = position;
				try
				{
					Class167.smethod_1(stream_1, result);
					goto IL_FD;
				}
				catch
				{
				}
				i++;
				continue;
				IL_FD:
				stream_1.Position = position;
				return result;
			}
			if (num > 1000)
			{
				Array.Resize<byte>(ref array, 1000);
				int j = 2;
				while (j < 50)
				{
					byte[] result2 = Stream17.smethod_1(array, j);
					stream_1.Position = position;
					try
					{
						Class167.smethod_1(stream_1, result2);
						goto IL_9A;
					}
					catch
					{
					}
					j++;
					continue;
					IL_9A:
					stream_1.Position = position;
					return result2;
				}
			}
			if (num > 500)
			{
				Array.Resize<byte>(ref array, 500);
				int k = 2;
				while (k < 50)
				{
					byte[] result3 = Stream17.smethod_1(array, k);
					stream_1.Position = position;
					try
					{
						Class167.smethod_1(stream_1, result3);
						goto IL_EA;
					}
					catch
					{
					}
					k++;
					continue;
					IL_EA:
					stream_1.Position = position;
					return result3;
				}
			}
			stream_1.Position = position;
			return null;
		}

		private static byte[] smethod_1(byte[] byte_2, int int_0)
		{
			byte[] array = new byte[int_0];
			uint[] array2 = new uint[256];
			for (int i = 0; i < int_0; i++)
			{
				Array.Clear(array2, 0, array2.Length);
				int num = 0;
				while (i + num < byte_2.Length)
				{
					array2[(int)byte_2[i + num]] += 1u;
					num += int_0;
				}
				int num2 = 0;
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] >= array2[num2])
					{
						num2 = j;
					}
				}
				array[i] = (byte)num2;
			}
			return array;
		}

		public byte method_1(byte byte_2, ref long long_0)
		{
			byte arg_1A_0 = byte_2;
			byte[] arg_19_0 = this.byte_0;
			long num;
			long_0 = (num = long_0) + 1L;
            byte_2 = (byte)(arg_1A_0 ^ arg_19_0[(int)(checked((IntPtr)num))]);
			if (long_0 == this.byte_0.LongLength)
			{
				long_0 = 0L;
			}
			return byte_2;
		}

		public byte method_2(byte byte_2, ref long long_0)
		{
			return this.method_1(Stream17.byte_1[(int)byte_2], ref long_0);
		}

		public byte method_3(byte byte_2, ref long long_0)
		{
			return Stream17.byte_1[(int)this.method_1(byte_2, ref long_0)];
		}

		public void method_4(byte[] byte_2, int int_0, int int_1, long long_0)
		{
			for (int i = int_0; i < int_1; i++)
			{
				byte_2[i] = this.method_2(byte_2[i], ref long_0);
			}
		}

		public void method_5(byte[] byte_2, int int_0, int int_1, long long_0)
		{
			for (int i = int_0; i < int_1; i++)
			{
				byte_2[i] = this.method_3(byte_2[i], ref long_0);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			long long_ = this.method_0();
			int num = this.stream_0.Read(buffer, offset, count);
			this.method_5(buffer, offset, num, long_);
			return num;
		}

		public override int ReadByte()
		{
			long num = this.method_0();
			return (int)this.method_3(this.byte_0[(int)(checked((IntPtr)this.method_0()))], ref num);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.method_4(buffer, offset, count, this.method_0());
			this.stream_0.Write(buffer, offset, count);
		}

		public override void WriteByte(byte value)
		{
			long num = this.method_0();
			this.stream_0.WriteByte(this.method_2(value, ref num));
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this.stream_0.SetLength(value);
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.stream_0.Close();
			}
			base.Dispose(disposing);
		}
	}
}
