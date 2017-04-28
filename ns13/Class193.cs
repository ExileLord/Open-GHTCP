using System;
using Compression.Zip;
using ns12;

namespace ns13
{
	public class Class193 : ICloneable
	{
		[Flags]
		private enum Enum32 : byte
		{
			flag_0 = 0,
			flag_1 = 1,
			flag_2 = 2,
			flag_3 = 4,
			flag_4 = 8,
			flag_5 = 16
		}

		private Enum32 enum32_0;

		private int int_0 = -1;

		private ushort ushort_0;

		private string string_0;

		private ulong ulong_0;

		private ulong ulong_1;

		private ushort ushort_1;

		private uint uint_0;

		private uint uint_1;

		private Enum31 enum31_0 = Enum31.const_1;

		private byte[] byte_0;

		private string string_1;

		private int int_1;

		private long long_0 = -1L;

		private long long_1;

		private bool bool_0;

		private byte byte_1;

		public Class193(string string_2) : this(string_2, 0, 45, Enum31.const_1)
		{
		}

		public Class193(string string_2, int int_2) : this(string_2, int_2, 45, Enum31.const_1)
		{
		}

		public Class193(string string_2, int int_2, int int_3, Enum31 enum31_1)
		{
			if (string_2 == null)
			{
				throw new ArgumentNullException("ZipEntry name");
			}
			if (string_2.Length > 65535)
			{
				throw new ArgumentException("Name is too long", "name");
			}
			if (int_2 != 0 && int_2 < 10)
			{
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			method_19(DateTime.Now);
			string_0 = string_2;
			ushort_0 = (ushort)int_3;
			ushort_1 = (ushort)int_2;
			enum31_0 = enum31_1;
		}

		public bool method_0()
		{
			return (int_1 & 1) != 0;
		}

		public void method_1(bool bool_1)
		{
			if (bool_1)
			{
				int_1 |= 1;
				return;
			}
			int_1 &= -2;
		}

		public byte method_2()
		{
			return byte_1;
		}

		public void method_3(byte byte_2)
		{
			byte_1 = byte_2;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_2)
		{
			int_1 = int_2;
		}

		public long method_6()
		{
			return long_1;
		}

		public void method_7(long long_2)
		{
			long_1 = long_2;
		}

		public int method_8()
		{
			if ((byte)(enum32_0 & Enum32.flag_5) == 0)
			{
				return -1;
			}
			return int_0;
		}

		private bool method_9(int int_2)
		{
			var result = false;
			if ((byte)(enum32_0 & Enum32.flag_5) != 0 && (method_10() == 0 || method_10() == 10) && (method_8() & int_2) == int_2)
			{
				result = true;
			}
			return result;
		}

		public int method_10()
		{
			return ushort_0 >> 8 & 255;
		}

		public int method_11()
		{
			if (ushort_1 != 0)
			{
				return ushort_1;
			}
			var result = 10;
			if (method_16())
			{
				result = 45;
			}
			else if (Enum31.const_1 == enum31_0)
			{
				result = 20;
			}
			else if (method_33())
			{
				result = 20;
			}
			else if (method_0())
			{
				result = 20;
			}
			else if (method_9(8))
			{
				result = 11;
			}
			return result;
		}

		public bool method_12()
		{
			return method_11() <= 45 && (method_11() == 10 || method_11() == 11 || method_11() == 20 || method_11() == 45) && method_34();
		}

		public void method_13()
		{
			bool_0 = true;
		}

		public bool method_14()
		{
			return bool_0;
		}

		public bool method_15()
		{
			bool result;
			if (!(result = bool_0))
			{
				var num = ulong_1;
				if (ushort_1 == 0 && method_0())
				{
					num += 12uL;
				}
				result = ((ulong_0 >= 4294967295uL || num >= 4294967295uL) && (ushort_1 == 0 || ushort_1 >= 45));
			}
			return result;
		}

		public bool method_16()
		{
			return method_15() || long_1 >= 4294967295L;
		}

		public long method_17()
		{
			if ((byte)(enum32_0 & Enum32.flag_4) == 0)
			{
				return 0L;
			}
			return uint_1;
		}

		public void method_18(long long_2)
		{
			uint_1 = (uint)long_2;
			enum32_0 |= Enum32.flag_4;
		}

		public void method_19(DateTime dateTime_0)
		{
			var num = (uint)dateTime_0.Year;
			var num2 = (uint)dateTime_0.Month;
			var num3 = (uint)dateTime_0.Day;
			var num4 = (uint)dateTime_0.Hour;
			var num5 = (uint)dateTime_0.Minute;
			var num6 = (uint)dateTime_0.Second;
			if (num < 1980u)
			{
				num = 1980u;
				num2 = 1u;
				num3 = 1u;
				num4 = 0u;
				num5 = 0u;
				num6 = 0u;
			}
			else if (num > 2107u)
			{
				num = 2107u;
				num2 = 12u;
				num3 = 31u;
				num4 = 23u;
				num5 = 59u;
				num6 = 59u;
			}
			method_18((num - 1980u & 127u) << 25 | num2 << 21 | num3 << 16 | num4 << 11 | num5 << 5 | num6 >> 1);
		}

		public string method_20()
		{
			return string_0;
		}

		public long method_21()
		{
			if ((byte)(enum32_0 & Enum32.flag_1) == 0)
			{
				return -1L;
			}
			return (long)ulong_0;
		}

		public void method_22(long long_2)
		{
			ulong_0 = (ulong)long_2;
			enum32_0 |= Enum32.flag_1;
		}

		public long method_23()
		{
			if ((byte)(enum32_0 & Enum32.flag_2) == 0)
			{
				return -1L;
			}
			return (long)ulong_1;
		}

		public void method_24(long long_2)
		{
			ulong_1 = (ulong)long_2;
			enum32_0 |= Enum32.flag_2;
		}

		public long method_25()
		{
			if ((byte)(enum32_0 & Enum32.flag_3) == 0)
			{
				return -1L;
			}
			return (long)(uint_0 & 4294967295uL);
		}

		public void method_26(long long_2)
		{
			uint_0 = (uint)long_2;
			enum32_0 |= Enum32.flag_3;
		}

		public Enum31 method_27()
		{
			return enum31_0;
		}

		public void method_28(Enum31 enum31_1)
		{
			if (!smethod_0(enum31_1))
			{
				throw new NotSupportedException("Compression method not supported");
			}
			enum31_0 = enum31_1;
		}

		public byte[] method_29()
		{
			return byte_0;
		}

		public void method_30(byte[] byte_2)
		{
			if (byte_2 == null)
			{
				byte_0 = null;
				return;
			}
			if (byte_2.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			byte_0 = new byte[byte_2.Length];
			Array.Copy(byte_2, 0, byte_0, 0, byte_2.Length);
		}

		public void method_31(bool bool_1)
		{
			var @class = new Class202(byte_0);
			if (@class.method_6(1))
			{
				if ((ushort_1 & 255) < 45)
				{
					throw new ZipException("Zip64 Extended information found but version is not valid");
				}
				bool_0 = true;
				if (@class.method_3() < 4)
				{
					throw new ZipException("Extra data extended Zip64 information length is invalid");
				}
				if (bool_1 || ulong_0 == 4294967295uL)
				{
					ulong_0 = (ulong)@class.method_14();
				}
				if (bool_1 || ulong_1 == 4294967295uL)
				{
					ulong_1 = (ulong)@class.method_14();
				}
				if (!bool_1 && long_1 == 4294967295L)
				{
					long_1 = @class.method_14();
				}
			}
			else if ((ushort_1 & 255) >= 45 && (ulong_0 == 4294967295uL || ulong_1 == 4294967295uL))
			{
				throw new ZipException("Zip64 Extended information required but is missing.");
			}
			if (@class.method_6(10))
			{
				if (@class.method_3() < 8)
				{
					throw new ZipException("NTFS Extra data invalid");
				}
				@class.method_15();
				while (@class.method_5() >= 4)
				{
					var num = @class.method_16();
					var num2 = @class.method_16();
					if (num == 1)
					{
						if (num2 >= 24)
						{
							var fileTime = @class.method_14();
							@class.method_14();
							@class.method_14();
							method_19(DateTime.FromFileTime(fileTime));
							return;
						}
						return;
					}
				    @class.method_18(num2);
				}
			}
			else if (@class.method_6(21589))
			{
				var num3 = @class.method_3();
				var num4 = @class.method_17();
				if ((num4 & 1) != 0 && num3 >= 5)
				{
					var seconds = @class.method_15();
					method_19((new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, seconds, 0)).ToLocalTime());
				}
			}
		}

		public string method_32()
		{
			return string_1;
		}

		public bool method_33()
		{
			var length = string_0.Length;
			int arg_41_0;
			if (length > 0)
			{
				if (string_0[length - 1] == '/' || string_0[length - 1] == '\\')
				{
					arg_41_0 = 1;
					return arg_41_0 != 0;
				}
			}
			arg_41_0 = (method_9(16) ? 1 : 0);
			return arg_41_0 != 0;
		}

		public bool method_34()
		{
			return smethod_0(method_27());
		}

		public object Clone()
		{
			var @class = (Class193)MemberwiseClone();
			if (byte_0 != null)
			{
				@class.byte_0 = new byte[byte_0.Length];
				Array.Copy(byte_0, 0, @class.byte_0, 0, byte_0.Length);
			}
			return @class;
		}

		public override string ToString()
		{
			return string_0;
		}

		public static bool smethod_0(Enum31 enum31_1)
		{
			return enum31_1 == Enum31.const_1 || enum31_1 == Enum31.const_0;
		}
	}
}
