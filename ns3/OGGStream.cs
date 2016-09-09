using ns0;
using ns10;
using ns2;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ns3
{
	public class OGGStream : GenericAudioStream
	{
		private static int int_2 = 8500;

		private static int int_3;

		private static int int_4 = 1;

		private static int int_5 = 2;

		private static int int_6 = -1;

		private static int int_7 = -2;

		private static int int_8 = -3;

		private static int int_9 = -128;

		private static int int_10 = -129;

		private static int int_11 = -130;

		private static int int_12 = -131;

		private static int int_13 = -132;

		private static int int_14 = -133;

		private static int int_15 = -134;

		private static int int_16 = -135;

		private static int int_17 = -136;

		private static int int_18 = -137;

		private static int int_19 = -138;

		private bool bool_0;

		private long long_0;

		private readonly Class52 class52_0 = new Class52();

		private int int_20;

		private long[] long_1;

		private long[] long_2;

		private int[] int_21;

		private long[] long_3;

		private OGGClass5[] oggClass5;

		private Class47[] class47_0;

		private long long_4;

		private long long_5;

		private bool bool_1;

		private int int_22;

		private int int_23;

		private double double_0;

		private float float_0;

		private float float_1;

		private readonly Class56 class56_0;

		private readonly OGGClass1 oggClass1;

		private readonly OGGClass6 oggClass6;

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
				return this.long_5;
			}
		}

		public override long Position
		{
			get
			{
				return this.method_19() * (long)this.waveFormat_0.short_1;
			}
			set
			{
				try
				{
					if (this.method_18(value / (long)this.waveFormat_0.short_1) < 0)
					{
						this.method_17(Convert.ToInt32((double)value / this.double_0));
					}
				}
				catch
				{
				}
			}
		}

		private OGGStream()
		{
			this.class56_0 = new Class56();
			this.oggClass1 = new OGGClass1();
			this.oggClass6 = new OGGClass6(this.oggClass1);
		}

		public OGGStream(string fileName) : this()
		{
			FileStream fileData = null;
			try
			{
                fileData = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
			catch (Exception ex)
			{
				throw new Exception0("OggStream: " + ex.Message);
			}
            int num = this.method_9(fileData, null, 0);
            if (num == -1)
			{
				throw new Exception0("OggStream: open return -1");
			}
		}

		public OGGStream(Stream stream_1) : this(stream_1, null, 0)
		{
		}

		public OGGStream(Stream stream_1, byte[] byte_0, int int_24) : this()
		{
			int num = this.method_9(stream_1, byte_0, int_24);
			if (num == -1)
			{
				throw new Exception0("OggStream: open return -1");
			}
		}

		private int method_0(Class48 class48_0, long long_6)
		{
			if (long_6 > 0L)
			{
				long_6 += this.long_0;
			}
			while (long_6 <= 0L || this.long_0 < long_6)
			{
				int num = this.class52_0.method_3(class48_0);
				if (num < 0)
				{
					this.long_0 -= (long)num;
				}
				else
				{
					if (num != 0)
					{
						int result = (int)this.long_0;
						this.long_0 += (long)num;
						return result;
					}
					if (long_6 == 0L)
					{
						return OGGStream.int_6;
					}
					int num2 = this.method_7();
					if (num2 == 0)
					{
						return OGGStream.int_7;
					}
					if (num2 < 0)
					{
						return OGGStream.int_9;
					}
				}
			}
			return OGGStream.int_6;
		}

		private int method_1(Class48 class48_0)
		{
			long num = this.long_0;
			int num2 = -1;
			int num3;
			while (num2 == -1)
			{
				num -= (long)OGGStream.int_2;
				if (num < 0L)
				{
					num = 0L;
				}
				this.method_8(num);
				while (this.long_0 < num + (long)OGGStream.int_2)
				{
					num3 = this.method_0(class48_0, num + (long)OGGStream.int_2 - this.long_0);
					if (num3 == OGGStream.int_9)
					{
						return OGGStream.int_9;
					}
					if (num3 < 0)
					{
						break;
					}
					num2 = num3;
				}
			}
			this.method_8((long)num2);
			num3 = this.method_0(class48_0, (long)OGGStream.int_2);
			if (num3 < 0)
			{
				return OGGStream.int_10;
			}
			return num2;
		}

		private int method_2(OGGClass5 oggClass5, Class47 class47_1, int[] int_24, Class48 class48_0)
		{
			Class48 @class = new Class48();
			Class67 class67_ = new Class67();
			if (class48_0 == null)
			{
				int num = this.method_0(@class, (long)OGGStream.int_2);
				if (num == OGGStream.int_9)
				{
					return OGGStream.int_9;
				}
				if (num < 0)
				{
					return OGGStream.int_13;
				}
				class48_0 = @class;
			}
			if (int_24 != null)
			{
				int_24[0] = class48_0.method_5();
			}
			this.class56_0.method_1(class48_0.method_5());
			oggClass5.method_0();
			class47_1.method_0();
			int i = 0;
			while (i < 3)
			{
				this.class56_0.method_6(class48_0);
				while (i < 3)
				{
					int num2 = this.class56_0.method_5(class67_);
					if (num2 == 0)
					{
						break;
					}
					if (num2 == -1)
					{
						Console.Error.WriteLine("Corrupt header in logical bitstream.");
						oggClass5.method_1();
						class47_1.method_2();
						this.class56_0.method_2();
						return -1;
					}
					if (oggClass5.method_4(class47_1, class67_) != 0)
					{
						Console.Error.WriteLine("Illegal header in logical bitstream.");
						oggClass5.method_1();
						class47_1.method_2();
						this.class56_0.method_2();
						return -1;
					}
					i++;
				}
				if (i < 3 && this.method_0(class48_0, 1L) < 0)
				{
					Console.Error.WriteLine("Missing header in logical bitstream.");
					oggClass5.method_1();
					class47_1.method_2();
					this.class56_0.method_2();
					return -1;
				}
			}
			return 0;
		}

		private void method_3(OGGClass5 class49_1, Class47 class47_1, int int_24)
		{
			Class48 @class = new Class48();
            this.oggClass5 = new OGGClass5[this.int_20];
			this.class47_0 = new Class47[this.int_20];
			this.long_2 = new long[this.int_20];
			this.long_3 = new long[this.int_20];
			this.int_21 = new int[this.int_20];
			int i = 0;
			while (i < this.int_20)
			{
                if (class49_1 != null && class47_1 != null && i == 0)
				{
					this.oggClass5[i] = class49_1;
					this.class47_0[i] = class47_1;
					this.long_2[i] = (long)int_24;
				}
				else
				{
					this.method_8(this.long_1[i]);
					if (this.method_2(this.oggClass5[i], this.class47_0[i], null, null) == -1)
					{
						Console.Error.WriteLine("Error opening logical bitstream #" + (i + 1) + "\n");
						this.long_2[i] = -1L;
					}
					else
					{
						this.long_2[i] = this.long_0;
						this.class56_0.method_2();
					}
				}
                long long_ = this.long_1[i + 1];
				this.method_8(long_);
				long num2;
                while (true)
				{
                    int num = this.method_1(@class);
                    if (num == -1)
					{
						goto Block_6;
					}
                    num2 = @class.method_4();
                    if (num2 != -1L)
					{
						goto Block_5;
					}
                }
            IL_189:
				i++;
                continue;
				Block_5:
                this.int_21[i] = @class.method_5();
                this.long_3[i] = num2;
				goto IL_189;
				Block_6:
				Console.Error.WriteLine("Could not find last page of logical bitstream #" + i + "\n");
                this.oggClass5[i].method_1();
				this.class47_0[i].method_2();
				goto IL_189;
			}
		}

		private int method_4()
		{
			if (this.bool_1)
			{
				return 1;
			}
            this.oggClass1.method_1(this.oggClass5[0]);
            this.oggClass6.method_0(this.oggClass1);
            this.bool_1 = true;
			return 0;
		}

		private void method_5()
		{
			this.class56_0.method_2();
			this.oggClass1.method_7();
			this.oggClass6.method_1();
			this.bool_1 = false;
			this.float_0 = 0f;
			this.float_1 = 0f;
		}

		private int method_6(int int_24)
		{
            Class48 @class = new Class48();
			Class67 class2;
			long num2;
			while (true)
			{
                if (this.bool_1)
				{
                    class2 = new Class67();
					int num = this.class56_0.method_5(class2);
					if (num > 0)
					{
						num2 = class2.long_0;
						if (this.oggClass6.method_2(class2) == 0)
						{
							goto Block_11;
						}
					}
				}
                if (int_24 == 0)
				{
					return 0;
				}
				if (this.method_0(@class, -1L) < 0)
				{
					return 0;
				}
                this.float_0 += (float)(@class.int_1 << 3);
				if (this.bool_1 && this.int_22 != @class.method_5())
				{
                    this.method_5();
				}
                if (!this.bool_1)
				{
                    if (this.bool_0)
					{
                        this.int_22 = @class.method_5();
						int num3 = 0;
						while (num3 < this.int_20 && this.int_21[num3] != this.int_22)
						{
							num3++;
						}
						if (num3 == this.int_20)
						{
							break;
						}
						this.int_23 = num3;
						this.class56_0.method_1(this.int_22);
						this.class56_0.method_7();
                    }
					else
					{
                        int[] array = new int[1];
						int num4 = this.method_2(this.oggClass5[0], this.class47_0[0], array, @class);
						this.int_22 = array[0];
						if (num4 != 0)
						{
							return num4;
						}
						this.int_23++;
                    }
                    this.method_4();
                }
                this.class56_0.method_6(@class);
            }
			return -1;
			Block_11:
            int num5 = this.oggClass1.method_3();
			this.oggClass1.method_2(this.oggClass6);
			this.float_1 += (float)(this.oggClass1.method_3() - num5);
			this.float_0 += (float)(class2.int_1 * 8);
            if (num2 != -1L && class2.int_3 == 0)
			{
				int num6 = this.bool_0 ? this.int_23 : 0;
				int num7 = this.oggClass1.method_3();
				num2 -= (long)num7;
				for (int i = 0; i < num6; i++)
				{
					num2 += this.long_3[i];
				}
				this.long_4 = num2;
			}
			return 1;
		}

		private static int smethod_0(Stream stream_1, long long_6, int int_24)
		{
			if (stream_1.CanSeek)
			{
				try
				{
					if (int_24 == OGGStream.int_3)
					{
						stream_1.Seek(long_6, SeekOrigin.Begin);
					}
					else if (int_24 == OGGStream.int_5)
					{
						stream_1.Seek(stream_1.Length - long_6, SeekOrigin.Begin);
					}
					else
					{
						Console.Error.WriteLine("seek: " + int_24 + " is not supported");
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
				return 0;
			}
			int result;
			try
			{
				if (int_24 == 0)
				{
					stream_1.Seek(0L, SeekOrigin.Begin);
				}
				stream_1.Seek(long_6, SeekOrigin.Begin);
				return 0;
			}
			catch (Exception ex2)
			{
				Console.Error.WriteLine(ex2.Message);
				result = -1;
			}
			return result;
		}

		private static long smethod_1(Stream stream_1)
		{
			try
			{
				if (stream_1.CanSeek)
				{
					return stream_1.Position;
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return 0L;
		}

		private int method_7()
		{
			int offset = this.class52_0.method_1(OGGStream.int_2);
			byte[] byte_ = this.class52_0.byte_0;
			int num = 0;
			int result;
			try
			{
				num = this.fileStream.Read(byte_, offset, OGGStream.int_2);
				goto IL_51;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				result = OGGStream.int_9;
			}
			return result;
			IL_51:
			this.class52_0.method_2(num);
			if (num == -1)
			{
				num = 0;
			}
			return num;
		}

		private void method_8(long long_6)
		{
			OGGStream.smethod_0(this.fileStream, long_6, OGGStream.int_3);
			this.long_0 = long_6;
			this.class52_0.method_4();
		}

		private int method_9(Stream fileStream, byte[] nullArray, int zero)
		{
			return this.method_10(fileStream, nullArray, zero);
		}

		private int method_10(Stream fileStream, byte[] nullArray, int zero)
		{
            this.fileStream = fileStream;
            this.class52_0.method_5();
            if (nullArray != null)
			{
                int dstOffset = this.class52_0.method_1(zero);
                Buffer.BlockCopy(nullArray, 0, this.class52_0.byte_0, dstOffset, zero);
				this.class52_0.method_2(zero);
			}
            int num;
            if (fileStream.CanSeek)
            {
                num = this.method_11();
            }
            else
            {
                num = this.method_12();
            }
            //int num = stream_1.CanSeek ? this.method_11() : this.method_12();
            OGGClass5 @class = this.method_21(-1);
            this.waveFormat_0 = new WaveFormat(@class.int_9, @class.int_8);
			this.double_0 = (double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1) / ((double)this.method_20(-1) / 8.0);
            this.long_5 = this.method_15(-1) * (long)this.waveFormat_0.short_1;
            if (this.long_5 <= 0L)
			{
				this.long_5 = Convert.ToInt64((double)this.method_14(-1) * this.double_0);
			}
            if (num != 0)
			{
				this.fileStream = null;
				this.method_22();
			}
            return num;
		}

		private int method_11()
		{
			OGGClass5 oggClass5 = new OGGClass5();
			Class47 class47_ = new Class47();
			Class48 @class = new Class48();
			int[] array = new int[1];
            int num = this.method_2(oggClass5, class47_, array, null);
            int num2 = array[0];
			int int_ = (int)this.long_0;
			this.class56_0.method_2();
            if (num == -1)
			{
				return -1;
			}
			this.bool_0 = true;
            OGGStream.smethod_0(this.fileStream, 0L, OGGStream.int_5);
            this.long_0 = OGGStream.smethod_1(this.fileStream);
			long num3 = this.long_0;
            num3 = (long)this.method_1(@class);
            if (@class.method_5() != num2)
			{
				if (this.method_13(0L, 0L, num3 + 1L, num2, 0) < 0)
				{
					this.method_22();
					return OGGStream.int_9;
				}
			}
			else if (this.method_13(0L, num3, num3 + 1L, num2, 0) < 0)
			{
				this.method_22();
				return OGGStream.int_9;
			}
            this.method_3(oggClass5, class47_, int_);
            return this.method_17(0);
		}

		private int method_12()
		{
			this.int_20 = 1;
			this.oggClass5 = new OGGClass5[this.int_20];
			this.oggClass5[0] = new OGGClass5();
			this.class47_0 = new Class47[this.int_20];
			this.class47_0[0] = new Class47();
			int[] array = new int[1];
			if (this.method_2(this.oggClass5[0], this.class47_0[0], array, null) == -1)
			{
				return -1;
			}
			this.int_22 = array[0];
			this.method_4();
			return 0;
		}

		private int method_13(long long_6, long long_7, long long_8, int int_24, int int_25)
		{
			long num = long_8;
			long long_9 = long_8;
			Class48 @class = new Class48();
			int num3;
			while (long_7 < num)
			{
				long num2;
				if (num - long_7 < (long)OGGStream.int_2)
				{
					num2 = long_7;
				}
				else
				{
					num2 = (long_7 + num) / 2L;
				}
				this.method_8(num2);
				num3 = this.method_0(@class, -1L);
				if (num3 == OGGStream.int_9)
				{
					return OGGStream.int_9;
				}
				if (num3 >= 0)
				{
					if (@class.method_5() == int_24)
					{
						long_7 = (long)(num3 + @class.int_1 + @class.int_3);
						continue;
					}
				}
				num = num2;
				if (num3 >= 0)
				{
					long_9 = (long)num3;
				}
			}
			this.method_8(long_9);
			num3 = this.method_0(@class, -1L);
			if (num3 == OGGStream.int_9)
			{
				return OGGStream.int_9;
			}
			if (long_7 < long_8)
			{
				if (num3 != -1)
				{
					num3 = this.method_13(long_9, this.long_0, long_8, @class.method_5(), int_25 + 1);
					if (num3 == OGGStream.int_9)
					{
						return OGGStream.int_9;
					}
					goto IL_FF;
				}
			}
			this.int_20 = int_25 + 1;
			this.long_1 = new long[int_25 + 2];
			this.long_1[int_25 + 1] = long_7;
			IL_FF:
			this.long_1[int_25] = long_6;
			return 0;
		}

		public long method_14(int int_24)
		{
			if (!this.bool_0 || int_24 >= this.int_20)
			{
				return -1L;
			}
			if (int_24 < 0)
			{
				long num = 0L;
				for (int i = 0; i < this.int_20; i++)
				{
					num += this.method_14(i);
				}
				return num;
			}
			return this.long_1[int_24 + 1] - this.long_1[int_24];
		}

		public long method_15(int int_24)
		{
			if (!this.bool_0 || int_24 >= this.int_20)
			{
				return -1L;
			}
			if (int_24 < 0)
			{
				long num = 0L;
				for (int i = 0; i < this.int_20; i++)
				{
					num += this.method_15(i);
				}
				return num;
			}
			return this.long_3[int_24];
		}

		public float method_16(int int_24)
		{
			if (!this.bool_0 || int_24 >= this.int_20)
			{
				return -1f;
			}
			if (int_24 < 0)
			{
				float num = 0f;
				for (int i = 0; i < this.int_20; i++)
				{
					num += this.method_16(i);
				}
				return num;
			}
			return (float)this.long_3[int_24] / (float)this.oggClass5[int_24].int_9;
		}

		public int method_17(int int_24)
		{
            if (!this.bool_0)
			{
				return -1;
			}
			if (int_24 < 0 || (long)int_24 > this.long_1[this.int_20])
			{
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
			this.long_4 = -1L;
			this.method_5();
			this.method_8((long)int_24);
            switch (this.method_6(1))
			{
			case -1:
				this.long_4 = -1L;
				this.method_5();
				return -1;
			case 0:
				this.long_4 = this.method_15(-1);
				return 0;
			default:
				while (true)
				{
					switch (this.method_6(0))
					{
					case -1:
						goto IL_77;
					case 0:
						return 0;
					}
				}

				IL_77:
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
		}

		public int method_18(long long_6)
		{
			long num = this.method_15(-1);
			if (!this.bool_0)
			{
				return -1;
			}
			if (long_6 < 0L || long_6 > num)
			{
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
			int i;
			for (i = this.int_20 - 1; i >= 0; i--)
			{
				num -= this.long_3[i];
				if (long_6 >= num)
				{
					break;
				}
			}
			long num2 = long_6 - num;
			long num3 = this.long_1[i + 1];
			long num4 = this.long_1[i];
			int int_ = (int)num4;
			Class48 @class = new Class48();
			while (num4 < num3)
			{
				long num5;
				if (num3 - num4 < (long)OGGStream.int_2)
				{
					num5 = num4;
				}
				else
				{
					num5 = (num3 + num4) / 2L;
				}
				this.method_8(num5);
				int num6 = this.method_0(@class, num3 - num5);
				if (num6 == -1)
				{
					num3 = num5;
				}
				else
				{
					long num7 = @class.method_4();
					if (num7 < num2)
					{
						int_ = num6;
						num4 = this.long_0;
					}
					else
					{
						num3 = num5;
					}
				}
			}
			if (this.method_17(int_) != 0)
			{
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
			if (this.long_4 >= long_6)
			{
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
			if (long_6 > this.method_15(-1))
			{
				this.long_4 = -1L;
				this.method_5();
				return -1;
			}
			while (this.long_4 < long_6)
			{
				int num8 = (int)(long_6 - this.long_4);
				int num9 = this.oggClass1.method_3();
				if (num9 > num8)
				{
					num9 = num8;
				}
				this.oggClass1.method_6(num9);
				this.long_4 += (long)num9;
				if (num9 < num8 && this.method_6(1) == 0)
				{
					this.long_4 = this.method_15(-1);
				}
			}
			return 0;
		}

		public long method_19()
		{
			if (this.long_4 >= 0L)
			{
				return this.long_4;
			}
			return 0L;
		}

		public int method_20(int int_24)
		{
			if (int_24 >= this.int_20)
			{
				return -1;
			}
			if (!this.bool_0 && int_24 != 0)
			{
				return this.method_20(0);
			}
			if (int_24 < 0)
			{
				long num = 0L;
				for (int i = 0; i < this.int_20; i++)
				{
					num += (this.long_1[i + 1] - this.long_2[i]) * 8L;
				}
				return (int)Math.Round((double)((float)num / this.method_16(-1)));
			}
			if (this.bool_0)
			{
				return (int)Math.Round((double)((float)((this.long_1[int_24 + 1] - this.long_2[int_24]) * 8L) / this.method_16(int_24)));
			}
			if (this.oggClass5[int_24].int_11 > 0)
			{
				return this.oggClass5[int_24].int_11;
			}
			if (this.oggClass5[int_24].int_10 <= 0)
			{
				return -1;
			}
			if (this.oggClass5[int_24].int_12 > 0)
			{
				return (this.oggClass5[int_24].int_10 + this.oggClass5[int_24].int_12) / 2;
			}
			return this.oggClass5[int_24].int_10;
		}

		public OGGClass5 method_21(int int_24)
		{
			if (this.bool_0)
			{
				if (int_24 < 0)
				{
					if (!this.bool_1)
					{
						return null;
					}
					return this.oggClass5[this.int_23];
				}
				else
				{
					if (int_24 >= this.int_20)
					{
						return null;
					}
					return this.oggClass5[int_24];
				}
			}
			else
			{
				if (!this.bool_1)
				{
					return null;
				}
				return this.oggClass5[0];
			}
		}

		private int method_22()
		{
			this.oggClass6.method_1();
			this.oggClass1.method_7();
			this.class56_0.method_2();
			if (this.oggClass5 != null && this.int_20 != 0)
			{
				for (int i = 0; i < this.int_20; i++)
				{
					this.oggClass5[i].method_1();
					this.class47_0[i].method_2();
				}
				this.oggClass5 = null;
				this.class47_0 = null;
			}
			if (this.long_2 != null)
			{
				this.long_2 = null;
			}
			if (this.long_3 != null)
			{
				this.long_3 = null;
			}
			if (this.int_21 != null)
			{
				this.int_21 = null;
			}
			if (this.long_1 != null)
			{
				this.long_1 = null;
			}
			this.class52_0.method_0();
			return 0;
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
			this.method_22();
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

		public override int vmethod_3(IntPtr intptr_0, int int_24)
		{
			int_24 >>= 2;
			float[] source = new float[int_24];
			int num = this.vmethod_4(source, 0, int_24);
			if (num == 0)
			{
				return 0;
			}
			Marshal.Copy(source, 0, intptr_0, num);
			return num << 2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			float[] array = new float[count >> 2];
			int num = this.vmethod_4(array, 0, array.Length) << 2;
			Buffer.BlockCopy(array, 0, buffer, offset, num);
			return num;
		}

		public override int vmethod_4(float[] float_2, int int_24, int int_25)
		{
			int num = int_24;
			int num2 = int_24 + int_25;
			int short_ = (int)this.waveFormat_0.short_0;
			do
			{
				if (this.bool_1)
				{
					int num3 = this.oggClass1.method_4(float_2, num, num2);
					if (num3 != 0)
					{
						this.oggClass1.method_6(num3);
						this.long_4 += (long)num3;
						num += num3 * short_;
						if (num >= num2)
						{
							break;
						}
					}
				}
			}
			while (this.method_6(1) >= 1);
			return num - int_24;
		}

		public override float[][] vmethod_5(int int_24)
		{
			float[][] array = new float[(int)this.waveFormat_0.short_0][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new float[int_24];
			}
			int num = 0;
			do
			{
				if (this.bool_1)
				{
					int num2 = this.oggClass1.method_5(array, num, int_24);
					if (num2 != 0)
					{
						num += num2;
						this.long_4 += (long)num2;
						this.oggClass1.method_6(num2);
						if (num >= int_24)
						{
							break;
						}
					}
				}
			}
			while (this.method_6(1) >= 1);
			if (num == 0)
			{
				return null;
			}
			if (num < int_24)
			{
				for (int j = 0; j < array.Length; j++)
				{
					Array.Resize<float>(ref array[j], num);
				}
			}
			return array;
		}
	}
}
