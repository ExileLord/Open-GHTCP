using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ns0;
using ns11;
using ns6;
using SharpAudio.ASC;
using SharpAudio.ASC.Flac.LibFlac;
using SharpAudio.ASC.Flac.LibFlac.frame;

namespace ns7
{
	public class FLACStream : GenericAudioStream
	{
		private static readonly byte[] byte_0 = {
			73,
			68,
			51
		};

		private readonly Class144 class144_0;

		private readonly Class136[] class136_0;

		private int int_2;

		private int int_3;

		private int int_4;

		private long long_0;

		private Class122 class122_0;

		private readonly Class151 class151_0 = new Class151();

		private readonly byte[] byte_1 = new byte[2];

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
				return long_2;
			}
		}

		public override long Position
		{
			get
			{
				return long_1 * waveFormat_0.short_1;
			}
			set
			{
				bool_0 = false;
				if (!method_11(value / waveFormat_0.short_1))
				{
					fileStream.Position = fileStream.Length;
					class144_0.vmethod_2();
					method_5();
					long_1 = (long_0 = class122_0.vmethod_3());
					int_10 = 0;
				}
			}
		}

		public Class136[] method_0()
		{
			return class136_0;
		}

		public FLACStream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public FLACStream(Stream stream_1)
		{
			class136_0 = new Class136[8];
			fileStream = stream_1;
			class144_0 = new Class144(stream_1);
			int_4 = 0;
			long_0 = 0L;
			method_1();
			waveFormat_0 = new WaveFormat(class122_0.vmethod_6(), class122_0.vmethod_7(), class122_0.vmethod_8());
			long_3 = fileStream.Position;
			long_4 = fileStream.Length;
			long_2 = class122_0.vmethod_3() * waveFormat_0.short_1;
			method_5();
		}

		private Class121[] method_1()
		{
			method_2();
			var list = new List<Class121>(10);
			Class121 @class;
			do
			{
				list.Add(@class = method_3());
			}
			while (!@class.vmethod_0());
			return list.ToArray();
		}

		private void method_2()
		{
			var num = 0;
			var i = 0;
			while (i < 4)
			{
				var num2 = class144_0.vmethod_10(8);
				if (num2 == Class145.byte_0[i])
				{
					i++;
					num = 0;
				}
				else
				{
					if (num2 != byte_0[num])
					{
						throw new IOException("Could not find Stream Sync");
					}
					num++;
					i = 0;
					if (num == 3)
					{
						method_4();
						num = 0;
					}
				}
			}
		}

		private Class121 method_3()
		{
			var flag = class144_0.vmethod_10(1) != 0;
			var num = class144_0.vmethod_10(7);
			var num2 = class144_0.vmethod_10(24);
			Class121 result;
			if (num == 0)
			{
				class122_0 = new Class122(class144_0, num2, flag);
				result = class122_0;
			}
			else if (num == 3)
			{
				class127_0 = new Class127(class144_0, num2, flag);
				result = class127_0;
			}
			else if (num == 2)
			{
				result = new Class124(class144_0, num2, flag);
			}
			else if (num == 1)
			{
				result = new Class128(class144_0, num2, flag);
			}
			else if (num == 4)
			{
				result = new Class129(class144_0, num2, flag);
			}
			else if (num == 5)
			{
				result = new Class125(class144_0, num2, flag);
			}
			else if (num == 6)
			{
				result = new Class123(class144_0, num2, flag);
			}
			else
			{
				result = new Class126(class144_0, num2, flag);
			}
			return result;
		}

		private void method_4()
		{
			class144_0.vmethod_12(8);
			class144_0.vmethod_12(8);
			class144_0.vmethod_12(8);
			var num = 0;
			for (var i = 0; i < 4; i++)
			{
				var num2 = class144_0.vmethod_10(8);
				num <<= 7;
				num |= (num2 & 127);
			}
			class144_0.vmethod_15(null, num);
		}

		private Class151 method_5()
		{
			int_10 = 0;
			try
			{
				Class151 result;
				while (true)
				{
					method_7();
					if (!bool_0)
					{
						try
						{
							method_8();
							result = class151_0;
							return result;
						}
						catch (FrameDecodeException)
						{
							int_11++;
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
				bool_0 = true;
			}
			return null;
		}

		private void method_6(int int_12, int int_13)
		{
			if (int_12 <= int_2 && int_13 <= int_3)
			{
				return;
			}
			for (var i = 0; i < 8; i++)
			{
				class136_0[i] = null;
			}
			for (var j = 0; j < int_13; j++)
			{
				class136_0[j] = new Class136(int_12);
			}
			int_2 = int_12;
			int_3 = int_13;
		}

		private void method_7()
		{
			var flag = true;
			if (class122_0 != null && class122_0.vmethod_3() != 0L && long_0 >= class122_0.vmethod_3())
			{
				bool_0 = true;
				return;
			}
// 			if (this.class144_0.vmethod_1())
// 			{
// 				goto IL_5F;
// 			}
// 			this.class144_0.vmethod_10(this.class144_0.vmethod_4());
            if (!class144_0.vmethod_1())
            {
                class144_0.vmethod_10(class144_0.vmethod_4());
            }
            
			try
			{
				while (true)
				{
				    var num = class144_0.vmethod_10(8);
					if (num == 255)
					{
						byte_1[0] = (byte)num;
						num = class144_0.vmethod_11(8);
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
				byte_1[1] = (byte)class144_0.vmethod_10(8);
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
			var num = Class150.smethod_0(byte_1[0], 0);
			num = Class150.smethod_0(byte_1[1], num);
			class144_0.vmethod_3(num);
			try
			{
				class151_0.class140_0 = new Class140(class144_0, byte_1, class122_0);
			}
			catch (BadHeaderException arg)
			{
				Console.WriteLine("Found bad header: " + arg);
				throw new FrameDecodeException("Bad Frame Header: " + arg);
			}
			method_6(class151_0.class140_0.int_0, class151_0.class140_0.int_2);
			for (var i = 0; i < class151_0.class140_0.int_2; i++)
			{
				var num2 = class151_0.class140_0.int_4;
				switch (class151_0.class140_0.int_3)
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
					method_9(i, num2);
				}
				catch (IOException ex)
				{
					Console.WriteLine("ReadSubframe: " + ex);
					throw ex;
				}
			}
			method_10();
			num = class144_0.vmethod_0();
			class151_0.vmethod_1((short)class144_0.vmethod_10(16));
			if (num == class151_0.vmethod_0())
			{
				switch (class151_0.class140_0.int_3)
				{
				case 1:
					for (var j = 0; j < class151_0.class140_0.int_0; j++)
					{
						class136_0[1].vmethod_0()[j] = class136_0[0].vmethod_0()[j] - class136_0[1].vmethod_0()[j];
					}
					break;
				case 2:
					for (var j = 0; j < class151_0.class140_0.int_0; j++)
					{
						class136_0[0].vmethod_0()[j] += class136_0[1].vmethod_0()[j];
					}
					break;
				case 3:
					for (var j = 0; j < class151_0.class140_0.int_0; j++)
					{
						var num3 = class136_0[0].vmethod_0()[j];
						var num4 = class136_0[1].vmethod_0()[j];
						num3 <<= 1;
						if ((num4 & 1) != 0)
						{
							num3++;
						}
						var num5 = num3 + num4;
						var num6 = num3 - num4;
						class136_0[0].vmethod_0()[j] = num5 >> 1;
						class136_0[1].vmethod_0()[j] = num6 >> 1;
					}
					break;
				}
			}
			else
			{
				Console.WriteLine("CRC Error: " + Convert.ToString(num & 65535, 16) + " vs " + Convert.ToString(class151_0.vmethod_0() & 65535, 16));
				for (var i = 0; i < class151_0.class140_0.int_2; i++)
				{
					for (var k = 0; k < class151_0.class140_0.int_0; k++)
					{
						class136_0[i].vmethod_0()[k] = 0;
					}
				}
			}
			int_5 = class151_0.class140_0.int_2;
			int_6 = class151_0.class140_0.int_3;
			int_7 = class151_0.class140_0.int_4;
			int_8 = class151_0.class140_0.int_1;
			int_9 = class151_0.class140_0.int_0;
			long_0 += class151_0.class140_0.int_0;
		}

		private void method_9(int int_12, int int_13)
		{
			var num = class144_0.vmethod_10(8);
			var flag = (num & 1) != 0;
			num &= 254;
			var num2 = 0;
			if (flag)
			{
				num2 = class144_0.vmethod_16() + 1;
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
				class151_0.class131_0[int_12] = new Class132(class144_0, class151_0.class140_0, class136_0[int_12], int_13, num2);
				goto IL_1AB;
			case 2:
				class151_0.class131_0[int_12] = new Class133(class144_0, class151_0.class140_0, class136_0[int_12], int_13, num2);
				goto IL_1AB;
			}
			if (num < 16)
			{
				throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " + Convert.ToString(num & 255, 16));
			}
			if (num <= 24)
			{
				class151_0.class131_0[int_12] = new Class134(class144_0, class151_0.class140_0, class136_0[int_12], int_13, num2, num >> 1 & 7);
			}
			else
			{
				if (num < 64)
				{
					throw new FrameDecodeException("ReadSubframe Bad Subframe Type: " + Convert.ToString(num & 255, 16));
				}
				class151_0.class131_0[int_12] = new Class135(class144_0, class151_0.class140_0, class136_0[int_12], int_13, num2, (num >> 1 & 31) + 1);
			}
			IL_1AB:
			if (flag)
			{
				num = class151_0.class131_0[int_12].vmethod_0();
				for (var i = 0; i < class151_0.class140_0.int_0; i++)
				{
					class136_0[int_12].vmethod_0()[i] <<= num;
				}
			}
		}

		private void method_10()
		{
			if (!class144_0.vmethod_1())
			{
				var num = class144_0.vmethod_10(class144_0.vmethod_4());
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
				fileStream.Position = long_3;
				class144_0.vmethod_2();
				int_10 = 0;
				long_0 = 0L;
				long_1 = 0L;
				method_5();
				return true;
			}
			var num = class122_0.vmethod_3();
			var num2 = class122_0.vmethod_2();
			var num3 = class122_0.vmethod_1();
			var num4 = class122_0.vmethod_5();
			var num5 = class122_0.vmethod_4();
			var num6 = class151_0.class140_0.int_2;
			var num7 = class151_0.class140_0.int_4;
			if (num6 == 0)
			{
				num6 = class122_0.vmethod_8();
			}
			if (num7 == 0)
			{
				num7 = class122_0.vmethod_7();
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
			var num9 = long_3;
			var num10 = 0L;
			var num11 = long_4;
			var num12 = (num > 0L) ? num : long_5;
			if (class127_0 != null)
			{
				var num13 = num9;
				var num14 = num11;
				var num15 = num10;
				var num16 = num12;
				var num17 = class127_0.vmethod_1();
				var num18 = num17 - 1;
				while (num18 >= 0 && (class127_0.class142_0[num18].long_0 <= -1L || class127_0.class142_0[num18].int_0 <= 0 || (num > 0L && class127_0.class142_0[num18].long_0 >= num) || class127_0.class142_0[num18].long_0 > long_5))
				{
					num18--;
				}
				if (num18 >= 0)
				{
					num13 = long_3 + class127_0.class142_0[num18].long_1;
					num15 = class127_0.class142_0[num18].long_0;
				}
				num18 = 0;
				while (num18 < num17 && (class127_0.class142_0[num18].long_0 <= -1L || class127_0.class142_0[num18].int_0 <= 0 || (num > 0L && class127_0.class142_0[num18].long_0 >= num) || class127_0.class142_0[num18].long_0 <= long_5))
				{
					num18++;
				}
				if (num18 < num17)
				{
					num14 = long_3 + class127_0.class142_0[num18].long_1;
					num16 = class127_0.class142_0[num18].long_0;
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
			var flag = true;
			while (num10 < num12 && num9 <= num11)
			{
				var num19 = num9 + (long)((long_5 - num10) / (double)(num12 - num10) * (num11 - num9)) - num8;
				if (num19 >= num11)
				{
					num19 = num11 - 1L;
				}
				if (num19 < num9)
				{
					fileStream.Position = num19;
					class144_0.vmethod_2();
					for (var i = 0; i < 10; i++)
					{
						if (method_5() == null)
						{
							return false;
						}
						if (class151_0.class140_0.long_0 <= long_5 && class151_0.class140_0.long_0 + class151_0.class140_0.int_0 > long_5)
						{
							long_0 = class151_0.class140_0.long_0 + class151_0.class140_0.int_0;
							int_10 = (int)(long_5 - class151_0.class140_0.long_0);
							long_1 = long_5;
							return true;
						}
					}
					return false;
				}
				fileStream.Position = num19;
				class144_0.vmethod_2();
				if (method_5() == null)
				{
					return false;
				}
				var num20 = class151_0.class140_0.long_0;
				if (num20 <= long_5 && num20 + class151_0.class140_0.int_0 > long_5)
				{
					long_0 = num20 + class151_0.class140_0.int_0;
					int_10 = (int)(long_5 - num20);
					long_1 = long_5;
					return true;
				}
				if (0L != num20 && (num20 + class151_0.class140_0.int_0 < num12 || !flag))
				{
					flag = false;
					if (num20 < num10)
					{
						return false;
					}
					if (long_5 < num20)
					{
						num12 = num20 + class151_0.class140_0.int_0;
						num11 = fileStream.Position;
						num8 = (int)(2L * (num11 - num19) / 3L + 16L);
					}
					else
					{
						num10 = num20 + class151_0.class140_0.int_0;
						num9 = fileStream.Position;
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
			class144_0.vmethod_2();
			fileStream.Close();
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

		public override int vmethod_3(IntPtr intptr_0, int int_12)
		{
			if (bool_0)
			{
				return 0;
			}
			var array = new byte[int_12];
			var num = Read(array, 0, int_12);
			if (num == 0)
			{
				return 0;
			}
			Marshal.Copy(array, 0, intptr_0, num);
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (bool_0)
			{
				return 0;
			}
			var num = offset;
			var num2 = offset + count;
			int short_ = waveFormat_0.short_0;
			var num3 = waveFormat_0.short_2 / 8;
			int short_2 = waveFormat_0.short_1;
			do
			{
				var num4 = class151_0.class140_0.int_0 - int_10;
				if (num4 > 0)
				{
					if (num4 * short_2 > num2 - num)
					{
						num4 = (num2 - num) / short_2;
					}
					for (var i = 0; i < short_; i++)
					{
						var array = method_0()[i].vmethod_0();
						if (waveFormat_0.short_2 == 8)
						{
							var j = int_10;
							var num5 = num + i;
							var num6 = j + num4;
							while (j < num6)
							{
								buffer[num5] = (byte)(array[j] + 128);
								j++;
								num5 += short_2;
							}
						}
						else
						{
							var k = int_10 << 2;
							var num7 = num + num3 * i;
							var num8 = k + (num4 << 2);
							while (k < num8)
							{
								Buffer.BlockCopy(array, k, buffer, num7, num3);
								k += 4;
								num7 += short_2;
							}
						}
					}
					long_1 += num4;
					int_10 += num4;
					num += num4 * short_2;
					if (num >= num2)
					{
						break;
					}
				}
			}
			while (method_5() != null);
			return num - offset;
		}

		public override int vmethod_4(float[] float_0, int int_12, int int_13)
		{
			if (bool_0)
			{
				return 0;
			}
			var num = int_12;
			var num2 = int_12 + int_13;
			int short_ = waveFormat_0.short_0;
			do
			{
				var num3 = class151_0.class140_0.int_0 - int_10;
				if (num3 > 0)
				{
					if (num3 > num2 - num)
					{
						num3 = num2 - num;
					}
					for (var i = 0; i < short_; i++)
					{
						var array = method_0()[i].vmethod_0();
						var short_2 = waveFormat_0.short_2;
						if (short_2 <= 16)
						{
							if (short_2 != 8)
							{
								if (short_2 == 16)
								{
									var j = int_10;
									var num4 = num + i;
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
								var k = int_10;
								var num5 = num + i;
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
								var l = int_10;
								var num6 = num + i;
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
							var m = int_10;
							var num7 = num + i;
							while (m < num3)
							{
								float_0[num7] = Class11.smethod_11(Struct8.smethod_1(array[m]));
								m++;
								num7 += short_;
							}
						}
					}
					long_1 += num3;
					int_10 += num3;
					num += num3 * short_;
					if (num >= num2)
					{
						break;
					}
				}
			}
			while (method_5() != null);
			return num - int_12;
		}

		public override float[][] vmethod_5(int int_12)
		{
			if (bool_0)
			{
				return null;
			}
			var array = new float[waveFormat_0.short_0][];
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = new float[int_12];
			}
			var num = 0;
			do
			{
				var num2 = class151_0.class140_0.int_0 - int_10;
				if (num2 > 0)
				{
					if (num2 > int_12 - num)
					{
						num2 = int_12 - num;
					}
					for (var j = 0; j < array.Length; j++)
					{
						var array2 = array[j];
						var array3 = method_0()[j].vmethod_0();
						var short_ = waveFormat_0.short_2;
						if (short_ <= 16)
						{
							if (short_ != 8)
							{
								if (short_ == 16)
								{
									var k = num;
									var num3 = int_10;
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
								var l = num;
								var num4 = int_10;
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
								var m = num;
								var num5 = int_10;
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
							var n = num;
							var num6 = int_10;
							while (n < num2)
							{
								array2[n] = Class11.smethod_11(Struct8.smethod_1(array3[num6]));
								n++;
								num6++;
							}
						}
					}
					num += num2;
					long_1 += num2;
					int_10 += num2;
					if (num >= int_12)
					{
						break;
					}
				}
			}
			while (method_5() != null);
			if (num == 0)
			{
				return null;
			}
			if (num < int_12)
			{
				for (var num7 = 0; num7 < array.Length; num7++)
				{
					Array.Resize(ref array[num7], num);
				}
			}
			return array;
		}
	}
}
