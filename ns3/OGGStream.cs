using System;
using System.IO;
using System.Runtime.InteropServices;
using ns0;
using ns10;
using ns2;
using SharpAudio.ASC;

namespace ns3
{
	public class OGGStream : GenericAudioStream
	{
		private static readonly int int_2 = 8500;

		private static int int_3;

		private static int int_4 = 1;

		private static readonly int int_5 = 2;

		private static readonly int int_6 = -1;

		private static readonly int int_7 = -2;

		private static int int_8 = -3;

		private static readonly int int_9 = -128;

		private static readonly int int_10 = -129;

		private static int int_11 = -130;

		private static int int_12 = -131;

		private static readonly int int_13 = -132;

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
				return long_5;
			}
		}

		public override long Position
		{
			get
			{
				return method_19() * waveFormat_0.short_1;
			}
			set
			{
				try
				{
					if (method_18(value / waveFormat_0.short_1) < 0)
					{
						method_17(Convert.ToInt32(value / double_0));
					}
				}
				catch
				{
				}
			}
		}

		private OGGStream()
		{
			class56_0 = new Class56();
			oggClass1 = new OGGClass1();
			oggClass6 = new OGGClass6(oggClass1);
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
            var num = method_9(fileData, null, 0);
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
			var num = method_9(stream_1, byte_0, int_24);
			if (num == -1)
			{
				throw new Exception0("OggStream: open return -1");
			}
		}

		private int method_0(Class48 class48_0, long long_6)
		{
			if (long_6 > 0L)
			{
				long_6 += long_0;
			}
			while (long_6 <= 0L || long_0 < long_6)
			{
				var num = class52_0.method_3(class48_0);
				if (num < 0)
				{
					long_0 -= num;
				}
				else
				{
					if (num != 0)
					{
						var result = (int)long_0;
						long_0 += num;
						return result;
					}
					if (long_6 == 0L)
					{
						return int_6;
					}
					var num2 = method_7();
					if (num2 == 0)
					{
						return int_7;
					}
					if (num2 < 0)
					{
						return int_9;
					}
				}
			}
			return int_6;
		}

		private int method_1(Class48 class48_0)
		{
			var num = long_0;
			var num2 = -1;
			int num3;
			while (num2 == -1)
			{
				num -= int_2;
				if (num < 0L)
				{
					num = 0L;
				}
				method_8(num);
				while (long_0 < num + int_2)
				{
					num3 = method_0(class48_0, num + int_2 - long_0);
					if (num3 == int_9)
					{
						return int_9;
					}
					if (num3 < 0)
					{
						break;
					}
					num2 = num3;
				}
			}
			method_8(num2);
			num3 = method_0(class48_0, int_2);
			if (num3 < 0)
			{
				return int_10;
			}
			return num2;
		}

		private int method_2(OGGClass5 oggClass5, Class47 class47_1, int[] int_24, Class48 class48_0)
		{
			var @class = new Class48();
			var class67_ = new Class67();
			if (class48_0 == null)
			{
				var num = method_0(@class, int_2);
				if (num == int_9)
				{
					return int_9;
				}
				if (num < 0)
				{
					return int_13;
				}
				class48_0 = @class;
			}
			if (int_24 != null)
			{
				int_24[0] = class48_0.method_5();
			}
			class56_0.method_1(class48_0.method_5());
			oggClass5.method_0();
			class47_1.method_0();
			var i = 0;
			while (i < 3)
			{
				class56_0.method_6(class48_0);
				while (i < 3)
				{
					var num2 = class56_0.method_5(class67_);
					if (num2 == 0)
					{
						break;
					}
					if (num2 == -1)
					{
						Console.Error.WriteLine("Corrupt header in logical bitstream.");
						oggClass5.method_1();
						class47_1.method_2();
						class56_0.method_2();
						return -1;
					}
					if (oggClass5.method_4(class47_1, class67_) != 0)
					{
						Console.Error.WriteLine("Illegal header in logical bitstream.");
						oggClass5.method_1();
						class47_1.method_2();
						class56_0.method_2();
						return -1;
					}
					i++;
				}
				if (i < 3 && method_0(class48_0, 1L) < 0)
				{
					Console.Error.WriteLine("Missing header in logical bitstream.");
					oggClass5.method_1();
					class47_1.method_2();
					class56_0.method_2();
					return -1;
				}
			}
			return 0;
		}

		private void method_3(OGGClass5 class49_1, Class47 class47_1, int int_24)
		{
			var @class = new Class48();
            oggClass5 = new OGGClass5[int_20];
			class47_0 = new Class47[int_20];
			long_2 = new long[int_20];
			long_3 = new long[int_20];
			int_21 = new int[int_20];
			var i = 0;
			while (i < int_20)
			{
                if (class49_1 != null && class47_1 != null && i == 0)
				{
					oggClass5[i] = class49_1;
					class47_0[i] = class47_1;
					long_2[i] = int_24;
				}
				else
				{
					method_8(long_1[i]);
					if (method_2(oggClass5[i], class47_0[i], null, null) == -1)
					{
						Console.Error.WriteLine("Error opening logical bitstream #" + (i + 1) + "\n");
						long_2[i] = -1L;
					}
					else
					{
						long_2[i] = long_0;
						class56_0.method_2();
					}
				}
                var long_ = long_1[i + 1];
				method_8(long_);
				long num2;
                while (true)
				{
                    var num = method_1(@class);
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
                int_21[i] = @class.method_5();
                long_3[i] = num2;
				goto IL_189;
				Block_6:
				Console.Error.WriteLine("Could not find last page of logical bitstream #" + i + "\n");
                oggClass5[i].method_1();
				class47_0[i].method_2();
				goto IL_189;
			}
		}

		private int method_4()
		{
			if (bool_1)
			{
				return 1;
			}
            oggClass1.method_1(oggClass5[0]);
            oggClass6.method_0(oggClass1);
            bool_1 = true;
			return 0;
		}

		private void method_5()
		{
			class56_0.method_2();
			oggClass1.method_7();
			oggClass6.method_1();
			bool_1 = false;
			float_0 = 0f;
			float_1 = 0f;
		}

		private int method_6(int int_24)
		{
            var @class = new Class48();
			Class67 class2;
			long num2;
			while (true)
			{
                if (bool_1)
				{
                    class2 = new Class67();
					var num = class56_0.method_5(class2);
					if (num > 0)
					{
						num2 = class2.long_0;
						if (oggClass6.method_2(class2) == 0)
						{
							goto Block_11;
						}
					}
				}
                if (int_24 == 0)
				{
					return 0;
				}
				if (method_0(@class, -1L) < 0)
				{
					return 0;
				}
                float_0 += @class.int_1 << 3;
				if (bool_1 && int_22 != @class.method_5())
				{
                    method_5();
				}
                if (!bool_1)
				{
                    if (bool_0)
					{
                        int_22 = @class.method_5();
						var num3 = 0;
						while (num3 < int_20 && int_21[num3] != int_22)
						{
							num3++;
						}
						if (num3 == int_20)
						{
							break;
						}
						int_23 = num3;
						class56_0.method_1(int_22);
						class56_0.method_7();
                    }
					else
					{
                        var array = new int[1];
						var num4 = method_2(oggClass5[0], class47_0[0], array, @class);
						int_22 = array[0];
						if (num4 != 0)
						{
							return num4;
						}
						int_23++;
                    }
                    method_4();
                }
                class56_0.method_6(@class);
            }
			return -1;
			Block_11:
            var num5 = oggClass1.method_3();
			oggClass1.method_2(oggClass6);
			float_1 += oggClass1.method_3() - num5;
			float_0 += class2.int_1 * 8;
            if (num2 != -1L && class2.int_3 == 0)
			{
				var num6 = bool_0 ? int_23 : 0;
				var num7 = oggClass1.method_3();
				num2 -= num7;
				for (var i = 0; i < num6; i++)
				{
					num2 += long_3[i];
				}
				long_4 = num2;
			}
			return 1;
		}

		private static int smethod_0(Stream stream_1, long long_6, int int_24)
		{
			if (stream_1.CanSeek)
			{
				try
				{
					if (int_24 == int_3)
					{
						stream_1.Seek(long_6, SeekOrigin.Begin);
					}
					else if (int_24 == int_5)
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
			var offset = class52_0.method_1(int_2);
			var byte_ = class52_0.byte_0;
			var num = 0;
			int result;
			try
			{
				num = fileStream.Read(byte_, offset, int_2);
				goto IL_51;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				result = int_9;
			}
			return result;
			IL_51:
			class52_0.method_2(num);
			if (num == -1)
			{
				num = 0;
			}
			return num;
		}

		private void method_8(long long_6)
		{
			smethod_0(fileStream, long_6, int_3);
			long_0 = long_6;
			class52_0.method_4();
		}

		private int method_9(Stream fileStream, byte[] nullArray, int zero)
		{
			return method_10(fileStream, nullArray, zero);
		}

		private int method_10(Stream fileStream, byte[] nullArray, int zero)
		{
            this.fileStream = fileStream;
            class52_0.method_5();
            if (nullArray != null)
			{
                var dstOffset = class52_0.method_1(zero);
                Buffer.BlockCopy(nullArray, 0, class52_0.byte_0, dstOffset, zero);
				class52_0.method_2(zero);
			}
            int num;
            if (fileStream.CanSeek)
            {
                num = method_11();
            }
            else
            {
                num = method_12();
            }
            //int num = stream_1.CanSeek ? this.method_11() : this.method_12();
            var @class = method_21(-1);
            waveFormat_0 = new WaveFormat(@class.int_9, @class.int_8);
			double_0 = waveFormat_0.int_0 * waveFormat_0.short_1 / (method_20(-1) / 8.0);
            long_5 = method_15(-1) * waveFormat_0.short_1;
            if (long_5 <= 0L)
			{
				long_5 = Convert.ToInt64(method_14(-1) * double_0);
			}
            if (num != 0)
			{
				this.fileStream = null;
				method_22();
			}
            return num;
		}

		private int method_11()
		{
			var oggClass5 = new OGGClass5();
			var class47_ = new Class47();
			var @class = new Class48();
			var array = new int[1];
            var num = method_2(oggClass5, class47_, array, null);
            var num2 = array[0];
			var int_ = (int)long_0;
			class56_0.method_2();
            if (num == -1)
			{
				return -1;
			}
			bool_0 = true;
            smethod_0(fileStream, 0L, int_5);
            long_0 = smethod_1(fileStream);
			var num3 = long_0;
            num3 = method_1(@class);
            if (@class.method_5() != num2)
			{
				if (method_13(0L, 0L, num3 + 1L, num2, 0) < 0)
				{
					method_22();
					return int_9;
				}
			}
			else if (method_13(0L, num3, num3 + 1L, num2, 0) < 0)
			{
				method_22();
				return int_9;
			}
            method_3(oggClass5, class47_, int_);
            return method_17(0);
		}

		private int method_12()
		{
			int_20 = 1;
			oggClass5 = new OGGClass5[int_20];
			oggClass5[0] = new OGGClass5();
			class47_0 = new Class47[int_20];
			class47_0[0] = new Class47();
			var array = new int[1];
			if (method_2(oggClass5[0], class47_0[0], array, null) == -1)
			{
				return -1;
			}
			int_22 = array[0];
			method_4();
			return 0;
		}

		private int method_13(long long_6, long long_7, long long_8, int int_24, int int_25)
		{
			var num = long_8;
			var long_9 = long_8;
			var @class = new Class48();
			int num3;
			while (long_7 < num)
			{
				long num2;
				if (num - long_7 < int_2)
				{
					num2 = long_7;
				}
				else
				{
					num2 = (long_7 + num) / 2L;
				}
				method_8(num2);
				num3 = method_0(@class, -1L);
				if (num3 == int_9)
				{
					return int_9;
				}
				if (num3 >= 0)
				{
					if (@class.method_5() == int_24)
					{
						long_7 = num3 + @class.int_1 + @class.int_3;
						continue;
					}
				}
				num = num2;
				if (num3 >= 0)
				{
					long_9 = num3;
				}
			}
			method_8(long_9);
			num3 = method_0(@class, -1L);
			if (num3 == int_9)
			{
				return int_9;
			}
			if (long_7 < long_8)
			{
				if (num3 != -1)
				{
					num3 = method_13(long_9, long_0, long_8, @class.method_5(), int_25 + 1);
					if (num3 == int_9)
					{
						return int_9;
					}
					goto IL_FF;
				}
			}
			int_20 = int_25 + 1;
			long_1 = new long[int_25 + 2];
			long_1[int_25 + 1] = long_7;
			IL_FF:
			long_1[int_25] = long_6;
			return 0;
		}

		public long method_14(int int_24)
		{
			if (!bool_0 || int_24 >= int_20)
			{
				return -1L;
			}
			if (int_24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < int_20; i++)
				{
					num += method_14(i);
				}
				return num;
			}
			return long_1[int_24 + 1] - long_1[int_24];
		}

		public long method_15(int int_24)
		{
			if (!bool_0 || int_24 >= int_20)
			{
				return -1L;
			}
			if (int_24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < int_20; i++)
				{
					num += method_15(i);
				}
				return num;
			}
			return long_3[int_24];
		}

		public float method_16(int int_24)
		{
			if (!bool_0 || int_24 >= int_20)
			{
				return -1f;
			}
			if (int_24 < 0)
			{
				var num = 0f;
				for (var i = 0; i < int_20; i++)
				{
					num += method_16(i);
				}
				return num;
			}
			return long_3[int_24] / (float)oggClass5[int_24].int_9;
		}

		public int method_17(int int_24)
		{
            if (!bool_0)
			{
				return -1;
			}
			if (int_24 < 0 || int_24 > long_1[int_20])
			{
				long_4 = -1L;
				method_5();
				return -1;
			}
			long_4 = -1L;
			method_5();
			method_8(int_24);
            switch (method_6(1))
			{
			case -1:
				long_4 = -1L;
				method_5();
				return -1;
			case 0:
				long_4 = method_15(-1);
				return 0;
			default:
				while (true)
				{
					switch (method_6(0))
					{
					case -1:
						goto IL_77;
					case 0:
						return 0;
					}
				}

				IL_77:
				long_4 = -1L;
				method_5();
				return -1;
			}
		}

		public int method_18(long long_6)
		{
			var num = method_15(-1);
			if (!bool_0)
			{
				return -1;
			}
			if (long_6 < 0L || long_6 > num)
			{
				long_4 = -1L;
				method_5();
				return -1;
			}
			int i;
			for (i = int_20 - 1; i >= 0; i--)
			{
				num -= long_3[i];
				if (long_6 >= num)
				{
					break;
				}
			}
			var num2 = long_6 - num;
			var num3 = long_1[i + 1];
			var num4 = long_1[i];
			var int_ = (int)num4;
			var @class = new Class48();
			while (num4 < num3)
			{
				long num5;
				if (num3 - num4 < int_2)
				{
					num5 = num4;
				}
				else
				{
					num5 = (num3 + num4) / 2L;
				}
				method_8(num5);
				var num6 = method_0(@class, num3 - num5);
				if (num6 == -1)
				{
					num3 = num5;
				}
				else
				{
					var num7 = @class.method_4();
					if (num7 < num2)
					{
						int_ = num6;
						num4 = long_0;
					}
					else
					{
						num3 = num5;
					}
				}
			}
			if (method_17(int_) != 0)
			{
				long_4 = -1L;
				method_5();
				return -1;
			}
			if (long_4 >= long_6)
			{
				long_4 = -1L;
				method_5();
				return -1;
			}
			if (long_6 > method_15(-1))
			{
				long_4 = -1L;
				method_5();
				return -1;
			}
			while (long_4 < long_6)
			{
				var num8 = (int)(long_6 - long_4);
				var num9 = oggClass1.method_3();
				if (num9 > num8)
				{
					num9 = num8;
				}
				oggClass1.method_6(num9);
				long_4 += num9;
				if (num9 < num8 && method_6(1) == 0)
				{
					long_4 = method_15(-1);
				}
			}
			return 0;
		}

		public long method_19()
		{
			if (long_4 >= 0L)
			{
				return long_4;
			}
			return 0L;
		}

		public int method_20(int int_24)
		{
			if (int_24 >= int_20)
			{
				return -1;
			}
			if (!bool_0 && int_24 != 0)
			{
				return method_20(0);
			}
			if (int_24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < int_20; i++)
				{
					num += (long_1[i + 1] - long_2[i]) * 8L;
				}
				return (int)Math.Round(num / method_16(-1));
			}
			if (bool_0)
			{
				return (int)Math.Round((long_1[int_24 + 1] - long_2[int_24]) * 8L / method_16(int_24));
			}
			if (oggClass5[int_24].int_11 > 0)
			{
				return oggClass5[int_24].int_11;
			}
			if (oggClass5[int_24].int_10 <= 0)
			{
				return -1;
			}
			if (oggClass5[int_24].int_12 > 0)
			{
				return (oggClass5[int_24].int_10 + oggClass5[int_24].int_12) / 2;
			}
			return oggClass5[int_24].int_10;
		}

		public OGGClass5 method_21(int int_24)
		{
			if (bool_0)
			{
				if (int_24 < 0)
				{
					if (!bool_1)
					{
						return null;
					}
					return oggClass5[int_23];
				}
			    if (int_24 >= int_20)
			    {
			        return null;
			    }
			    return oggClass5[int_24];
			}
		    if (!bool_1)
		    {
		        return null;
		    }
		    return oggClass5[0];
		}

		private int method_22()
		{
			oggClass6.method_1();
			oggClass1.method_7();
			class56_0.method_2();
			if (oggClass5 != null && int_20 != 0)
			{
				for (var i = 0; i < int_20; i++)
				{
					oggClass5[i].method_1();
					class47_0[i].method_2();
				}
				oggClass5 = null;
				class47_0 = null;
			}
			if (long_2 != null)
			{
				long_2 = null;
			}
			if (long_3 != null)
			{
				long_3 = null;
			}
			if (int_21 != null)
			{
				int_21 = null;
			}
			if (long_1 != null)
			{
				long_1 = null;
			}
			class52_0.method_0();
			return 0;
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
			method_22();
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

		public override int vmethod_3(IntPtr intptr_0, int int_24)
		{
			int_24 >>= 2;
			var source = new float[int_24];
			var num = vmethod_4(source, 0, int_24);
			if (num == 0)
			{
				return 0;
			}
			Marshal.Copy(source, 0, intptr_0, num);
			return num << 2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			var array = new float[count >> 2];
			var num = vmethod_4(array, 0, array.Length) << 2;
			Buffer.BlockCopy(array, 0, buffer, offset, num);
			return num;
		}

		public override int vmethod_4(float[] float_2, int int_24, int int_25)
		{
			var num = int_24;
			var num2 = int_24 + int_25;
			int short_ = waveFormat_0.short_0;
			do
			{
				if (bool_1)
				{
					var num3 = oggClass1.method_4(float_2, num, num2);
					if (num3 != 0)
					{
						oggClass1.method_6(num3);
						long_4 += num3;
						num += num3 * short_;
						if (num >= num2)
						{
							break;
						}
					}
				}
			}
			while (method_6(1) >= 1);
			return num - int_24;
		}

		public override float[][] vmethod_5(int int_24)
		{
			var array = new float[waveFormat_0.short_0][];
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = new float[int_24];
			}
			var num = 0;
			do
			{
				if (bool_1)
				{
					var num2 = oggClass1.method_5(array, num, int_24);
					if (num2 != 0)
					{
						num += num2;
						long_4 += num2;
						oggClass1.method_6(num2);
						if (num >= int_24)
						{
							break;
						}
					}
				}
			}
			while (method_6(1) >= 1);
			if (num == 0)
			{
				return null;
			}
			if (num < int_24)
			{
				for (var j = 0; j < array.Length; j++)
				{
					Array.Resize(ref array[j], num);
				}
			}
			return array;
		}
	}
}
