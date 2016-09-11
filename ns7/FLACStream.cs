using ns0;
using ns11;
using ns6;
using SharpAudio.ASC;
using SharpAudio.ASC.Flac.LibFlac;
using SharpAudio.ASC.Flac.LibFlac.frame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ns7
{
	public class FLACStream : GenericAudioStream
	{
		private static readonly byte[] byte_0 = new byte[]
		{
			73,
			68,
			51
		};

		private Class144 class144_0;

		private Class136[] class136_0;

		private int int_2;

		private int int_3;

		private int int_4;

		private long long_0;

		private Class122 class122_0;

		private Class151 class151_0 = new Class151();

		private byte[] byte_1 = new byte[2];

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private int int_9;

		private int int_10;

		private long long_1;

		private readonly long long_2;

		private readonly long long_3;

		private readonly long long_4;

		private Class127 class127_0;

		private int int_11;

		private bool bool_0;

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
				return this.long_2;
			}
		}

		public override long Position
		{
			get
			{
				return this.long_1 * (long)this.waveFormat_0.short_1;
			}
			set
			{
				this.bool_0 = false;
				if (!this.method_11(value / (long)this.waveFormat_0.short_1))
				{
					this.fileStream.Position = this.fileStream.Length;
					this.class144_0.vmethod_2();
					this.method_5();
					this.long_1 = (this.long_0 = this.class122_0.vmethod_3());
					this.int_10 = 0;
				}
			}
		}

		public Class136[] method_0()
		{
			return this.class136_0;
		}

		public FLACStream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public FLACStream(Stream stream_1)
		{
			this.class136_0 = new Class136[8];
			this.fileStream = stream_1;
			this.class144_0 = new Class144(stream_1);
			this.int_4 = 0;
			this.long_0 = 0L;
			this.method_1();
			this.waveFormat_0 = new WaveFormat(this.class122_0.vmethod_6(), this.class122_0.vmethod_7(), this.class122_0.vmethod_8());
			this.long_3 = this.fileStream.Position;
			this.long_4 = this.fileStream.Length;
			this.long_2 = this.class122_0.vmethod_3() * (long)this.waveFormat_0.short_1;
			this.method_5();
		}

		private Class121[] method_1()
		{
			this.method_2();
			List<Class121> list = new List<Class121>(10);
			Class121 @class;
			do
			{
				list.Add(@class = this.method_3());
			}
			while (!@class.vmethod_0());
			return list.ToArray();
		}

		private void method_2()
		{
			int num = 0;
			int i = 0;
			while (i < 4)
			{
				int num2 = this.class144_0.vmethod_10(8);
				if (num2 == (int)Class145.byte_0[i])
				{
					i++;
					num = 0;
				}
				else
				{
					if (num2 != (int)FLACStream.byte_0[num])
					{
						throw new IOException("Could not find Stream Sync");
					}
					num++;
					i = 0;
					if (num == 3)
					{
						this.method_4();
						num = 0;
					}
				}
			}
		}

		private Class121 method_3()
		{
			bool flag = this.class144_0.vmethod_10(1) != 0;
			int num = this.class144_0.vmethod_10(7);
			int num2 = this.class144_0.vmethod_10(24);
			Class121 result;
			if (num == 0)
			{
				this.class122_0 = new Class122(this.class144_0, num2, flag);
				result = this.class122_0;
			}
			else if (num == 3)
			{
				this.class127_0 = new Class127(this.class144_0, num2, flag);
				result = this.class127_0;
			}
			else if (num == 2)
			{
				result = new Class124(this.class144_0, num2, flag);
			}
			else if (num == 1)
			{
				result = new Class128(this.class144_0, num2, flag);
			}
			else if (num == 4)
			{
				result = new Class129(this.class144_0, num2, flag);
			}
			else if (num == 5)
			{
				result = new Class125(this.class144_0, num2, flag);
			}
			else if (num == 6)
			{
				result = new Class123(this.class144_0, num2, flag);
			}
			else
			{
				result = new Class126(this.class144_0, num2, flag);
			}
			return result;
		}

		private void method_4()
		{
			this.class144_0.vmethod_12(8);
			this.class144_0.vmethod_12(8);
			this.class144_0.vmethod_12(8);
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				int num2 = this.class144_0.vmethod_10(8);
				num <<= 7;
				num |= (num2 & 127);
			}
			this.class144_0.vmethod_15(null, num);
		}

		private Class151 method_5()
		{
			this.int_10 = 0;
			try
			{
				Class151 result;
				while (true)
				{
					this.method_7();
					if (!this.bool_0)
					{
						try
						{
							this.method_8();
							result = this.class151_0;
							return result;
						}
						catch (FrameDecodeException)
						{
							this.int_11++;
							continue;
						}
						break;
					}
					break;
				}
				result = null;
				return result;
			}
			catch (EndOfStreamException)
			{
				this.bool_0 = true;
			}
			return null;
		}

		private void method_6(int int_12, int int_13)
		{
			if (int_12 <= this.int_2 && int_13 <= this.int_3)
			{
				return;
			}
			for (int i = 0; i < 8; i++)
			{
				this.class136_0[i] = null;
			}
			for (int j = 0; j < int_13; j++)
			{
				this.class136_0[j] = new Class136(int_12);
			}
			this.int_2 = int_12;
			this.int_3 = int_13;
		}

		private void method_7()
		{
			bool flag = true;
			if (this.class122_0 != null && this.class122_0.vmethod_3() != 0L && this.long_0 >= this.class122_0.vmethod_3())
			{
				this.bool_0 = true;
				return;
			}
// 			if (this.class144_0.vmethod_1())
// 			{
// 				goto IL_5F;
// 			}
// 			this.class144_0.vmethod_10(this.class144_0.vmethod_4());
            if (!this.class144_0.vmethod_1())
            {
                this.class144_0.vmethod_10(this.class144_0.vmethod_4());
            }
            
			try
			{
				while (true)
				{
					IL_5F:
					int num = this.class144_0.vmethod_10(8);
					if (num == 255)
					{
						this.byte_1[0] = (byte)num;
						num = this.class144_0.vmethod_11(8);
						if (num >> 2 == 62)
						{
							break;
						}
					}
					if (flag)
					{
						Console.WriteLine("FindSync LOST_SYNC: " + Convert.ToString(num & 255, 16));
						flag = false;
					}
				}
				this.byte_1[1] = (byte)this.class144_0.vmethod_10(8);
			}
			catch (EndOfStreamException)
			{
				if (!flag)
				{
					Console.WriteLine("FindSync LOST_SYNC: Left over data in file");
				}
			}
		}

		private void method_8()
		{
			short num = Class150.smethod_0(this.byte_1[0], 0);
			num = Class150.smethod_0(this.byte_1[1], num);
			this.class144_0.vmethod_3(num);
			try
			{
				this.class151_0.class140_0 = new Class140(this.class144_0, this.byte_1, this.class122_0);
			}
			catch (BadHeaderException arg)
			{
				Console.WriteLine("Found bad header: " + arg);
				throw new FrameDecodeException("Bad Frame Header: " + arg);
			}
			this.method_6(this.class151_0.class140_0.int_0, this.class151_0.class140_0.int_2);
			for (int i = 0; i < this.class151_0.class140_0.int_2; i++)
			{
				int num2 = this.class151_0.class140_0.int_4;
				switch (this.class151_0.class140_0.int_3)
				{
				case 1:
					if (i == 1)
					{
						num2++;
					}
					break;
				case 2:
					if (i == 0)
					{
						num2++;
					}
					break;
				case 3:
					if (i == 1)
					{
						num2++;
					}
					break;
				}
				try
				{
					this.method_9(i, num2);
				}
				catch (IOException ex)
				{
					Console.WriteLine("ReadSubframe: " + ex);
					throw ex;
				}
			}
			this.method_10();
			num = this.class144_0.vmethod_0();
			this.class151_0.vmethod_1((short)this.class144_0.vmethod_10(16));
			if (num == this.class151_0.vmethod_0())
			{
				switch (this.class151_0.class140_0.int_3)
				{
				case 1:
					for (int j = 0; j < this.class151_0.class140_0.int_0; j++)
					{
						this.class136_0[1].vmethod_0()[j] = this.class136_0[0].vmethod_0()[j] - this.class136_0[1].vmethod_0()[j];
					}
					break;
				case 2:
					for (int j = 0; j < this.class151_0.class140_0.int_0; j++)
					{
						this.class136_0[0].vmethod_0()[j] += this.class136_0[1].vmethod_0()[j];
					}
					break;
				case 3:
					for (int j = 0; j < this.class151_0.class140_0.int_0; j++)
					{
						int num3 = this.class136_0[0].vmethod_0()[j];
						int num4 = this.class136_0[1].vmethod_0()[j];
						num3 <<= 1;
						if ((num4 & 1) != 0)
						{
							num3++;
						}
						int num5 = num3 + num4;
						int num6 = num3 - num4;
						this.class136_0[0].vmethod_0()[j] = num5 >> 1;
						this.class136_0[1].vmethod_0()[j] = num6 >> 1;
					}
					break;
				}
			}
			else
			{
				Console.WriteLine("CRC Error: " + Convert.ToString((int)num & 65535, 16) + " vs " + Convert.ToString((int)this.class151_0.vmethod_0() & 65535, 16));
				for (int i = 0; i < this.class151_0.class140_0.int_2; i++)
				{
					for (int k = 0; k < this.class151_0.class140_0.int_0; k++)
					{
						this.class136_0[i].vmethod_0()[k] = 0;
					}
				}
			}
			this.int_5 = this.class151_0.class140_0.int_2;
			this.int_6 = this.class151_0.class140_0.int_3;
			this.int_7 = this.class151_0.class140_0.int_4;
			this.int_8 = this.class151_0.class140_0.int_1;
			this.int_9 = this.class151_0.class140_0.int_0;
			this.long_0 += (long)this.class151_0.class140_0.int_0;
		}

		private void method_9(int int_12, int int_13)
		{
			int num = this.class144_0.vmethod_10(8);
			bool flag = (num & 1) != 0;
			num &= 254;
			int num2 = 0;
			if (flag)
			{
				num2 = this.class144_0.vmethod_16() + 1;
				int_13 -= num2;
			}
			if ((num & 128) != 0)
			{
				Console.WriteLine("ReadSubframe LOST_SYNC: " + Convert.ToString(num & 255, 16));
				throw new FrameDecodeException("ReadSubframe LOST_SYNC: " + Convert.ToString(num & 255, 16));
			}
			switch (num)
			{
			case 0:
				this.class151_0.class131_0[int_12] = new Class132(this.class144_0, this.class151_0.class140_0, this.class136_0[int_12], int_13, num2);
				goto IL_1AB;
			case 2:
				this.class151_0.class131_0[int_12] = new Class133(this.class144_0, this.class151_0.class140_0, this.class136_0[int_12], int_13, num2);
				goto IL_1AB;
			}
			if (num < 16)
			{
				throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " + Convert.ToString(num & 255, 16));
			}
			if (num <= 24)
			{
				this.class151_0.class131_0[int_12] = new Class134(this.class144_0, this.class151_0.class140_0, this.class136_0[int_12], int_13, num2, num >> 1 & 7);
			}
			else
			{
				if (num < 64)
				{
					throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " + Convert.ToString(num & 255, 16));
				}
				this.class151_0.class131_0[int_12] = new Class135(this.class144_0, this.class151_0.class140_0, this.class136_0[int_12], int_13, num2, (num >> 1 & 31) + 1);
			}
			IL_1AB:
			if (flag)
			{
				num = this.class151_0.class131_0[int_12].vmethod_0();
				for (int i = 0; i < this.class151_0.class140_0.int_0; i++)
				{
					this.class136_0[int_12].vmethod_0()[i] <<= num;
				}
			}
		}

		private void method_10()
		{
			if (!this.class144_0.vmethod_1())
			{
				int num = this.class144_0.vmethod_10(this.class144_0.vmethod_4());
				if (num != 0)
				{
					Console.WriteLine("ZeroPaddingError: " + Convert.ToString(num, 16));
					throw new FrameDecodeException("ZeroPaddingError: " + Convert.ToString(num, 16));
				}
			}
		}

		public bool method_11(long long_5)
		{
			if (long_5 == 0L)
			{
				this.fileStream.Position = this.long_3;
				this.class144_0.vmethod_2();
				this.int_10 = 0;
				this.long_0 = 0L;
				this.long_1 = 0L;
				this.method_5();
				return true;
			}
			long num = this.class122_0.vmethod_3();
			int num2 = this.class122_0.vmethod_2();
			int num3 = this.class122_0.vmethod_1();
			int num4 = this.class122_0.vmethod_5();
			int num5 = this.class122_0.vmethod_4();
			int num6 = this.class151_0.class140_0.int_2;
			int num7 = this.class151_0.class140_0.int_4;
			if (num6 == 0)
			{
				num6 = this.class122_0.vmethod_8();
			}
			if (num7 == 0)
			{
				num7 = this.class122_0.vmethod_7();
			}
			int num8;
			if (num5 > 0)
			{
				num8 = (num5 + num4) / 2 + 1;
			}
			else if (num2 == num3 && num2 > 0)
			{
				num8 = num2 * num6 * num7 / 8 + 64;
			}
			else
			{
				num8 = 4096 * num6 * num7 / 8 + 64;
			}
			long num9 = this.long_3;
			long num10 = 0L;
			long num11 = this.long_4;
			long num12 = (num > 0L) ? num : long_5;
			if (this.class127_0 != null)
			{
				long num13 = num9;
				long num14 = num11;
				long num15 = num10;
				long num16 = num12;
				int num17 = this.class127_0.vmethod_1();
				int num18 = num17 - 1;
				while (num18 >= 0 && (this.class127_0.class142_0[num18].long_0 <= -1L || this.class127_0.class142_0[num18].int_0 <= 0 || (num > 0L && this.class127_0.class142_0[num18].long_0 >= num) || this.class127_0.class142_0[num18].long_0 > long_5))
				{
					num18--;
				}
				if (num18 >= 0)
				{
					num13 = this.long_3 + this.class127_0.class142_0[num18].long_1;
					num15 = this.class127_0.class142_0[num18].long_0;
				}
				num18 = 0;
				while (num18 < num17 && (this.class127_0.class142_0[num18].long_0 <= -1L || this.class127_0.class142_0[num18].int_0 <= 0 || (num > 0L && this.class127_0.class142_0[num18].long_0 >= num) || this.class127_0.class142_0[num18].long_0 <= long_5))
				{
					num18++;
				}
				if (num18 < num17)
				{
					num14 = this.long_3 + this.class127_0.class142_0[num18].long_1;
					num16 = this.class127_0.class142_0[num18].long_0;
				}
				if (num14 >= num13)
				{
					num9 = num13;
					num11 = num14;
					num10 = num15;
					num12 = num16;
				}
			}
			if (num12 == num10)
			{
				num12 += 1L;
			}
			bool flag = true;
			while (num10 < num12 && num9 <= num11)
			{
				long num19 = num9 + (long)((double)(long_5 - num10) / (double)(num12 - num10) * (double)(num11 - num9)) - (long)num8;
				if (num19 >= num11)
				{
					num19 = num11 - 1L;
				}
				if (num19 < num9)
				{
					this.fileStream.Position = num19;
					this.class144_0.vmethod_2();
					for (int i = 0; i < 10; i++)
					{
						if (this.method_5() == null)
						{
							return false;
						}
						if (this.class151_0.class140_0.long_0 <= long_5 && this.class151_0.class140_0.long_0 + (long)this.class151_0.class140_0.int_0 > long_5)
						{
							this.long_0 = this.class151_0.class140_0.long_0 + (long)this.class151_0.class140_0.int_0;
							this.int_10 = (int)(long_5 - this.class151_0.class140_0.long_0);
							this.long_1 = long_5;
							return true;
						}
					}
					return false;
				}
				this.fileStream.Position = num19;
				this.class144_0.vmethod_2();
				if (this.method_5() == null)
				{
					return false;
				}
				long num20 = this.class151_0.class140_0.long_0;
				if (num20 <= long_5 && num20 + (long)this.class151_0.class140_0.int_0 > long_5)
				{
					this.long_0 = num20 + (long)this.class151_0.class140_0.int_0;
					this.int_10 = (int)(long_5 - num20);
					this.long_1 = long_5;
					return true;
				}
				if (0L != num20 && (num20 + (long)this.class151_0.class140_0.int_0 < num12 || !flag))
				{
					flag = false;
					if (num20 < num10)
					{
						return false;
					}
					if (long_5 < num20)
					{
						num12 = num20 + (long)this.class151_0.class140_0.int_0;
						num11 = this.fileStream.Position;
						num8 = (int)(2L * (num11 - num19) / 3L + 16L);
					}
					else
					{
						num10 = num20 + (long)this.class151_0.class140_0.int_0;
						num9 = this.fileStream.Position;
						num8 = (int)(2L * (num9 - num19) / 3L + 16L);
					}
				}
				else
				{
					if (num19 == num9)
					{
						return false;
					}
					num8 = ((num8 != 0) ? (num8 * 2) : 16);
				}
			}
			return false;
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
			this.class144_0.vmethod_2();
			this.fileStream.Close();
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

		public override int vmethod_3(IntPtr intptr_0, int int_12)
		{
			if (this.bool_0)
			{
				return 0;
			}
			byte[] array = new byte[int_12];
			int num = this.Read(array, 0, int_12);
			if (num == 0)
			{
				return 0;
			}
			Marshal.Copy(array, 0, intptr_0, num);
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.bool_0)
			{
				return 0;
			}
			int num = offset;
			int num2 = offset + count;
			int short_ = (int)this.waveFormat_0.short_0;
			int num3 = (int)(this.waveFormat_0.short_2 / 8);
			int short_2 = (int)this.waveFormat_0.short_1;
			do
			{
				int num4 = this.class151_0.class140_0.int_0 - this.int_10;
				if (num4 > 0)
				{
					if (num4 * short_2 > num2 - num)
					{
						num4 = (num2 - num) / short_2;
					}
					for (int i = 0; i < short_; i++)
					{
						int[] array = this.method_0()[i].vmethod_0();
						if (this.waveFormat_0.short_2 == 8)
						{
							int j = this.int_10;
							int num5 = num + i;
							int num6 = j + num4;
							while (j < num6)
							{
								buffer[num5] = (byte)(array[j] + 128);
								j++;
								num5 += short_2;
							}
						}
						else
						{
							int k = this.int_10 << 2;
							int num7 = num + num3 * i;
							int num8 = k + (num4 << 2);
							while (k < num8)
							{
								Buffer.BlockCopy(array, k, buffer, num7, num3);
								k += 4;
								num7 += short_2;
							}
						}
					}
					this.long_1 += (long)num4;
					this.int_10 += num4;
					num += num4 * short_2;
					if (num >= num2)
					{
						break;
					}
				}
			}
			while (this.method_5() != null);
			return num - offset;
		}

		public override int vmethod_4(float[] float_0, int int_12, int int_13)
		{
			if (this.bool_0)
			{
				return 0;
			}
			int num = int_12;
			int num2 = int_12 + int_13;
			int short_ = (int)this.waveFormat_0.short_0;
			do
			{
				int num3 = this.class151_0.class140_0.int_0 - this.int_10;
				if (num3 > 0)
				{
					if (num3 > num2 - num)
					{
						num3 = num2 - num;
					}
					for (int i = 0; i < short_; i++)
					{
						int[] array = this.method_0()[i].vmethod_0();
						short short_2 = this.waveFormat_0.short_2;
						if (short_2 <= 16)
						{
							if (short_2 != 8)
							{
								if (short_2 == 16)
								{
									int j = this.int_10;
									int num4 = num + i;
									while (j < num3)
									{
										float_0[num4] = Class11.smethod_7((short)array[j]);
										j++;
										num4 += short_;
									}
								}
							}
							else
							{
								int k = this.int_10;
								int num5 = num + i;
								while (k < num3)
								{
									float_0[num5] = Class11.smethod_3((byte)array[k]);
									k++;
									num5 += short_;
								}
							}
						}
						else if (short_2 != 24)
						{
							if (short_2 == 32)
							{
								int l = this.int_10;
								int num6 = num + i;
								while (l < num3)
								{
									float_0[num6] = Class11.smethod_15(array[l]);
									l++;
									num6 += short_;
								}
							}
						}
						else
						{
							int m = this.int_10;
							int num7 = num + i;
							while (m < num3)
							{
								float_0[num7] = Class11.smethod_11(Struct8.smethod_1(array[m]));
								m++;
								num7 += short_;
							}
						}
					}
					this.long_1 += (long)num3;
					this.int_10 += num3;
					num += num3 * short_;
					if (num >= num2)
					{
						break;
					}
				}
			}
			while (this.method_5() != null);
			return num - int_12;
		}

		public override float[][] vmethod_5(int int_12)
		{
			if (this.bool_0)
			{
				return null;
			}
			float[][] array = new float[(int)this.waveFormat_0.short_0][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new float[int_12];
			}
			int num = 0;
			do
			{
				int num2 = this.class151_0.class140_0.int_0 - this.int_10;
				if (num2 > 0)
				{
					if (num2 > int_12 - num)
					{
						num2 = int_12 - num;
					}
					for (int j = 0; j < array.Length; j++)
					{
						float[] array2 = array[j];
						int[] array3 = this.method_0()[j].vmethod_0();
						short short_ = this.waveFormat_0.short_2;
						if (short_ <= 16)
						{
							if (short_ != 8)
							{
								if (short_ == 16)
								{
									int k = num;
									int num3 = this.int_10;
									while (k < num2)
									{
										array2[k] = Class11.smethod_7((short)array3[num3]);
										k++;
										num3++;
									}
								}
							}
							else
							{
								int l = num;
								int num4 = this.int_10;
								while (l < num2)
								{
									array2[l] = Class11.smethod_3((byte)array3[num4]);
									l++;
									num4++;
								}
							}
						}
						else if (short_ != 24)
						{
							if (short_ == 32)
							{
								int m = num;
								int num5 = this.int_10;
								while (m < num2)
								{
									array2[m] = Class11.smethod_15(array3[num5]);
									m++;
									num5++;
								}
							}
						}
						else
						{
							int n = num;
							int num6 = this.int_10;
							while (n < num2)
							{
								array2[n] = Class11.smethod_11(Struct8.smethod_1(array3[num6]));
								n++;
								num6++;
							}
						}
					}
					num += num2;
					this.long_1 += (long)num2;
					this.int_10 += num2;
					if (num >= int_12)
					{
						break;
					}
				}
			}
			while (this.method_5() != null);
			if (num == 0)
			{
				return null;
			}
			if (num < int_12)
			{
				for (int num7 = 0; num7 < array.Length; num7++)
				{
					Array.Resize<float>(ref array[num7], num);
				}
			}
			return array;
		}
	}
}
