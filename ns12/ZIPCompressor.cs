using System;
using System.IO;
using Compression.Zip;
using ns13;
using ns14;

namespace ns12
{
	public class ZIPCompressor : Stream19
	{
		private delegate int Delegate5(byte[] b, int offset, int length);

		private Delegate5 delegate5_0;

		private Class192 class192_0 = new Class192();

		private Class193 class193_0;

		private long long_1;

		private int int_0;

		private int int_1;

		private string password;

		public override long Length
		{
			get
			{
				if (class193_0 == null)
				{
					throw new InvalidOperationException("No current entry");
				}
				if (class193_0.method_21() < 0L)
				{
					throw new ZipException("Length not available for the current entry");
				}
				return class193_0.method_21();
			}
		}

		public ZIPCompressor(Stream stream_1) : base(stream_1, new Class196(true))
		{
			delegate5_0 = method_9;
		}

		public void method_3(string password)
		{
			this.password = password;
		}

		public bool method_4()
		{
			return class193_0 != null && class193_0.method_12();
		}

		public Class193 method_5()
		{
			if (class192_0 == null)
			{
				throw new InvalidOperationException("Closed.");
			}
			if (class193_0 != null)
			{
				method_8();
			}
			var num = class201_0.method_10();
			if (num != 33639248 && num != 101010256 && num != 84233040 && num != 117853008)
			{
				if (num != 101075792)
				{
					if (num == 808471376 || num == 134695760)
					{
						num = class201_0.method_10();
					}
					if (num != 67324752)
					{
						throw new ZipException("Wrong Local header signature: 0x" + string.Format("{0:X}", num));
					}
					var int_ = (short)class201_0.method_9();
					int_1 = class201_0.method_9();
					int_0 = class201_0.method_9();
					var num2 = (uint)class201_0.method_10();
					var num3 = class201_0.method_10();
					long_0 = class201_0.method_10();
					long_1 = class201_0.method_10();
					var num4 = class201_0.method_9();
					var num5 = class201_0.method_9();
					var flag = (int_1 & 1) == 1;
					var array = new byte[num4];
					class201_0.method_5(array);
					var string_ = Class186.smethod_2(int_1, array);
					class193_0 = new Class193(string_, int_);
					class193_0.method_5(int_1);
					class193_0.method_28((Enum31)int_0);
					if ((int_1 & 8) == 0)
					{
						class193_0.method_26(num3 & 4294967295L);
						class193_0.method_22(long_1 & 4294967295L);
						class193_0.method_24(long_0 & 4294967295L);
						class193_0.method_3((byte)(num3 >> 24 & 255));
					}
					else
					{
						if (num3 != 0)
						{
							class193_0.method_26(num3 & 4294967295L);
						}
						if (long_1 != 0L)
						{
							class193_0.method_22(long_1 & 4294967295L);
						}
						if (long_0 != 0L)
						{
							class193_0.method_24(long_0 & 4294967295L);
						}
						class193_0.method_3((byte)(num2 >> 8 & 255u));
					}
					class193_0.method_18(num2);
					if (num5 > 0)
					{
						var array2 = new byte[num5];
						class201_0.method_5(array2);
						class193_0.method_30(array2);
					}
					class193_0.method_31(true);
					if (class193_0.method_23() >= 0L)
					{
						long_0 = class193_0.method_23();
					}
					if (class193_0.method_21() >= 0L)
					{
						long_1 = class193_0.method_21();
					}
					if (int_0 == 0 && ((!flag && long_0 != long_1) || (flag && long_0 - 12L != long_1)))
					{
						throw new ZipException("Stored, but compressed != uncompressed");
					}
					if (class193_0.method_34())
					{
						delegate5_0 = method_11;
					}
					else
					{
						delegate5_0 = method_10;
					}
					return class193_0;
				}
			}
			Close();
			return null;
		}

		private void method_6()
		{
			if (class201_0.method_10() != 134695760)
			{
				throw new ZipException("Data descriptor signature not found");
			}
			class193_0.method_26(class201_0.method_10() & 4294967295L);
			if (class193_0.method_15())
			{
				long_0 = class201_0.method_11();
				long_1 = class201_0.method_11();
			}
			else
			{
				long_0 = class201_0.method_10();
				long_1 = class201_0.method_10();
			}
			class193_0.method_24(long_0);
			class193_0.method_22(long_1);
		}

		private void method_7(bool bool_2)
		{
			method_1();
			if ((int_1 & 8) != 0)
			{
				method_6();
			}
			long_1 = 0L;
			if (bool_2 && (class192_0.vmethod_0() & 4294967295L) != class193_0.method_25() && class193_0.method_25() != -1L)
			{
				throw new ZipException("CRC mismatch");
			}
			class192_0.vmethod_1();
			if (int_0 == 8)
			{
				class196_0.method_0();
			}
			class193_0 = null;
		}

		public void method_8()
		{
			if (class192_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (class193_0 == null)
			{
				return;
			}
			if (int_0 == 8)
			{
				if ((int_1 & 8) != 0)
				{
					var array = new byte[2048];
					while (Read(array, 0, array.Length) > 0)
					{
					}
					return;
				}
				long_0 -= class196_0.method_12();
				var expr_67 = class201_0;
				expr_67.method_2(expr_67.method_1() + class196_0.method_13());
			}
			if (class201_0.method_1() > long_0 && long_0 >= 0L)
			{
				class201_0.method_2((int)(class201_0.method_1() - long_0));
			}
			else
			{
				long_0 -= class201_0.method_1();
				class201_0.method_2(0);
				while (long_0 != 0L)
				{
					var num = (int)method_0(long_0 & 4294967295L);
					if (num <= 0)
					{
						throw new ZipException("Zip archive ends early.");
					}
					long_0 -= num;
				}
			}
			method_7(false);
		}

		public override int ReadByte()
		{
			var array = new byte[1];
			if (Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return array[0] & 255;
		}

		private int method_9(byte[] byte_0, int int_2, int int_3)
		{
			throw new InvalidOperationException("Unable to read from this stream");
		}

		private int method_10(byte[] byte_0, int int_2, int int_3)
		{
			throw new ZipException("The compression method for this entry is not supported");
		}

		private int method_11(byte[] byte_0, int int_2, int int_3)
		{
			if (!method_4())
			{
				throw new ZipException("Library cannot extract this entry. Version required is (" + class193_0.method_11() + ")");
			}
			if (class193_0.method_0())
			{
				if (password == null)
				{
					throw new ZipException("No password set.");
				}
				var @class = new Class208();
				var rgbKey = Class207.smethod_0(Class186.smethod_3(password));
				class201_0.method_12(@class.CreateDecryptor(rgbKey, null));
				var array = new byte[12];
				class201_0.method_7(array, 0, 12);
				if (array[11] != class193_0.method_2())
				{
					throw new ZipException("Invalid password");
				}
				if (long_0 >= 12L)
				{
					long_0 -= 12L;
				}
				else if ((class193_0.method_4() & 8) == 0)
				{
					throw new ZipException(string.Format("Entry compressed size {0} too small for encryption", long_0));
				}
			}
			else
			{
				class201_0.method_12(null);
			}
			if (int_0 == 8 && class201_0.method_1() > 0)
			{
				class201_0.method_3(class196_0);
			}
			delegate5_0 = method_12;
			return method_12(byte_0, int_2, int_3);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Invalid offset/count combination");
			}
			return delegate5_0(buffer, offset, count);
		}

		private int method_12(byte[] byte_0, int int_2, int int_3)
		{
			if (class192_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (class193_0 == null || int_3 <= 0)
			{
				return 0;
			}
			if (int_2 + int_3 > byte_0.Length)
			{
				throw new ArgumentException("Offset + count exceeds buffer size");
			}
			var flag = false;
			var num = int_0;
			if (num != 0)
			{
				if (num == 8)
				{
					int_3 = base.Read(byte_0, int_2, int_3);
					if (int_3 <= 0)
					{
						if (!class196_0.method_10())
						{
							throw new ZipException("Inflater not finished!");
						}
						class201_0.method_2(class196_0.method_13());
						if ((int_1 & 8) == 0 && (class196_0.method_12() != long_0 || class196_0.method_11() != long_1))
						{
							throw new ZipException(string.Concat("Size mismatch: ", long_0, ";", long_1, " <-> ", class196_0.method_12(), ";", class196_0.method_11()));
						}
						class196_0.method_0();
						flag = true;
					}
				}
			}
			else
			{
				if (int_3 > long_0 && long_0 >= 0L)
				{
					int_3 = (int)long_0;
				}
				if (int_3 > 0)
				{
					int_3 = class201_0.method_7(byte_0, int_2, int_3);
					if (int_3 > 0)
					{
						long_0 -= int_3;
						long_1 -= int_3;
					}
				}
				if (long_0 == 0L)
				{
					flag = true;
				}
				else if (int_3 < 0)
				{
					throw new ZipException("EOF in stored block");
				}
			}
			if (int_3 > 0)
			{
				class192_0.vmethod_3(byte_0, int_2, int_3);
			}
			if (flag)
			{
				method_7(true);
			}
			return int_3;
		}

		public override void Close()
		{
			delegate5_0 = method_9;
			class192_0 = null;
			class193_0 = null;
			base.Close();
		}
	}
}
