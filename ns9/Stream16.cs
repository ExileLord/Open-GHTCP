using ns0;
using ns1;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Lame;
using System;
using System.IO;

namespace ns9
{
	public class Stream16 : Stream15
	{
		private bool bool_0;

		private readonly BE_CONFIG be_CONFIG_0;

		private readonly uint uint_0;

		private readonly uint uint_1;

		private readonly uint uint_2;

		private readonly byte[] byte_0;

		private int int_2;

		private readonly byte[] byte_1;

		public Stream16(Stream stream_1, WaveFormat waveFormat_1, BE_CONFIG be_CONFIG_1) : base(stream_1, waveFormat_1)
		{
			try
			{
				this.be_CONFIG_0 = be_CONFIG_1;
				uint num = Class360.beInitStream(this.be_CONFIG_0, ref this.uint_1, ref this.uint_2, ref this.uint_0);
				if (num != 0u)
				{
					throw new ApplicationException(string.Format("Lame_encDll.beInitStream failed with the error code {0}", num));
				}
				this.byte_0 = new byte[this.uint_1 * 2u];
				this.byte_1 = new byte[this.uint_2];
			}
			catch
			{
				base.Close();
				throw;
			}
		}

		public override int vmethod_0()
		{
			return this.byte_0.Length;
		}

		public void method_1()
		{
			if (!this.bool_0)
			{
				try
				{
					uint num = 0u;
					if (this.int_2 > 0 && Class360.smethod_0(this.uint_0, this.byte_0, 0, (uint)this.int_2, this.byte_1, ref num) == 0u && num > 0u)
					{
						base.Write(this.byte_1, 0, (int)num);
					}
					num = 0u;
					if (Class360.beDeinitStream(this.uint_0, this.byte_1, ref num) == 0u && num > 0u)
					{
						base.Write(this.byte_1, 0, (int)num);
					}
				}
				finally
				{
					Class360.beCloseStream(this.uint_0);
				}
			}
			this.bool_0 = true;
		}

		public override void Close()
		{
			this.method_1();
			base.Close();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			uint num = 0u;
			while (count > 0)
			{
				if (this.int_2 > 0)
				{
					int num2 = Math.Min(count, this.byte_0.Length - this.int_2);
					Buffer.BlockCopy(buffer, offset, this.byte_0, this.int_2, num2);
					this.int_2 += num2;
					offset += num2;
					count -= num2;
					if (this.int_2 >= this.byte_0.Length)
					{
						this.int_2 = 0;
						uint num3 = Class360.smethod_1(this.uint_0, this.byte_0, this.byte_1, ref num);
						if (num3 != 0u)
						{
							throw new ApplicationException("Lame_encDll.EncodeChunk failed with the error code " + num3);
						}
						if (num > 0u)
						{
							this.stream_0.Write(this.byte_1, 0, (int)num);
						}
					}
				}
				else if (count >= this.byte_0.Length)
				{
					uint num3 = Class360.smethod_0(this.uint_0, buffer, offset, (uint)this.byte_0.Length, this.byte_1, ref num);
					if (num3 != 0u)
					{
						throw new ApplicationException("Lame_encDll.EncodeChunk failed with the error code " + num3);
					}
					if (num > 0u)
					{
						this.stream_0.Write(this.byte_1, 0, (int)num);
					}
					count -= this.byte_0.Length;
					offset += this.byte_0.Length;
				}
				else
				{
					Buffer.BlockCopy(buffer, offset, this.byte_0, 0, count);
					this.int_2 = count;
					offset += count;
					count = 0;
				}
			}
		}

		public static Class16 smethod_0(Stream1 stream1_0, Stream stream_1, int int_3, int int_4)
		{
			WaveFormat waveFormat = stream1_0.vmethod_0();
			if (waveFormat.waveFormatTag_0 != WaveFormatTag.PCM || waveFormat.short_2 != 16)
			{
				stream1_0 = new Stream4(stream1_0, 16);
				waveFormat = stream1_0.vmethod_0();
			}
			Stream16 stream = new Stream16(stream_1, waveFormat, (waveFormat.int_0 == int_3) ? new BE_CONFIG(waveFormat, (uint)int_4) : new BE_CONFIG(waveFormat, (uint)int_4, (uint)int_3));
			uint uint_ = (uint)stream.vmethod_1().Position;
			byte[] array = new byte[stream.method_0() * 2];
			Class16 result;
			try
			{
				int count;
				while ((count = stream1_0.Read(array, 0, array.Length)) > 0)
				{
					stream.Write(array, 0, count);
				}
				result = new Class16(new WaveFormat(int_3, (int)waveFormat.short_0), uint_, (uint)stream.vmethod_1().Length, int_4 * 1000);
			}
			finally
			{
				stream.method_1();
			}
			return result;
		}

		public static Class16 smethod_1(Stream stream_1, Class16 class16_0, int int_3)
		{
			return Stream16.smethod_2(stream_1, class16_0.timeSpan_0, class16_0.method_3(), int_3, false);
		}

		public static Class16 smethod_2(Stream stream_1, TimeSpan timeSpan_0, int int_3, int int_4, bool bool_1)
		{
			WaveFormat waveFormat = new WaveFormat(int_3, 16, bool_1 ? 2 : 1);
			Stream16 stream = new Stream16(stream_1, waveFormat, new BE_CONFIG(waveFormat, (uint)int_4));
			uint uint_ = (uint)stream.vmethod_1().Position;
			byte[] array = new byte[stream.method_0() * 2];
			Class16 result;
			try
			{
				int num = 0;
				int num2 = (int)(timeSpan_0.TotalSeconds * (double)waveFormat.int_1);
				int count;
				while ((count = Math.Min(num2 - num - array.Length, array.Length)) > 0)
				{
					stream.Write(array, 0, count);
					num += array.Length;
				}
				result = new Class16(waveFormat, uint_, (uint)stream.vmethod_1().Length, int_4 * 1000);
			}
			finally
			{
				stream.method_1();
			}
			return result;
		}
	}
}
