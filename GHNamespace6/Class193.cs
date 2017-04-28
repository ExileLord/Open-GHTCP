using System;
using Compression.Zip;
using GHNamespace5;

namespace GHNamespace6
{
	public class Class193 : ICloneable
	{
		[Flags]
		private enum Enum32 : byte
		{
			Flag0 = 0,
			Flag1 = 1,
			Flag2 = 2,
			Flag3 = 4,
			Flag4 = 8,
			Flag5 = 16
		}

		private Enum32 _enum320;

		private readonly int _int0 = -1;

		private readonly ushort _ushort0;

		private readonly string _string0;

		private ulong _ulong0;

		private ulong _ulong1;

		private readonly ushort _ushort1;

		private uint _uint0;

		private uint _uint1;

		private Enum31 _enum310 = Enum31.Const1;

		private byte[] _byte0;

		private string _string1;

		private int _int1;

		private long _long0 = -1L;

		private long _long1;

		private bool _bool0;

		private byte _byte1;

		public Class193(string string2) : this(string2, 0, 45, Enum31.Const1)
		{
		}

		public Class193(string string2, int int2) : this(string2, int2, 45, Enum31.Const1)
		{
		}

		public Class193(string string2, int int2, int int3, Enum31 enum311)
		{
			if (string2 == null)
			{
				throw new ArgumentNullException("ZipEntry name");
			}
			if (string2.Length > 65535)
			{
				throw new ArgumentException("Name is too long", "name");
			}
			if (int2 != 0 && int2 < 10)
			{
				throw new ArgumentOutOfRangeException("versionRequiredToExtract");
			}
			method_19(DateTime.Now);
			_string0 = string2;
			_ushort0 = (ushort)int3;
			_ushort1 = (ushort)int2;
			_enum310 = enum311;
		}

		public bool method_0()
		{
			return (_int1 & 1) != 0;
		}

		public void method_1(bool bool1)
		{
			if (bool1)
			{
				_int1 |= 1;
				return;
			}
			_int1 &= -2;
		}

		public byte method_2()
		{
			return _byte1;
		}

		public void method_3(byte byte2)
		{
			_byte1 = byte2;
		}

		public int method_4()
		{
			return _int1;
		}

		public void method_5(int int2)
		{
			_int1 = int2;
		}

		public long method_6()
		{
			return _long1;
		}

		public void method_7(long long2)
		{
			_long1 = long2;
		}

		public int method_8()
		{
			if ((byte)(_enum320 & Enum32.Flag5) == 0)
			{
				return -1;
			}
			return _int0;
		}

		private bool method_9(int int2)
		{
			var result = false;
			if ((byte)(_enum320 & Enum32.Flag5) != 0 && (method_10() == 0 || method_10() == 10) && (method_8() & int2) == int2)
			{
				result = true;
			}
			return result;
		}

		public int method_10()
		{
			return _ushort0 >> 8 & 255;
		}

		public int method_11()
		{
			if (_ushort1 != 0)
			{
				return _ushort1;
			}
			var result = 10;
			if (method_16())
			{
				result = 45;
			}
			else if (Enum31.Const1 == _enum310)
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
			_bool0 = true;
		}

		public bool method_14()
		{
			return _bool0;
		}

		public bool method_15()
		{
			bool result;
			if (!(result = _bool0))
			{
				var num = _ulong1;
				if (_ushort1 == 0 && method_0())
				{
					num += 12uL;
				}
				result = ((_ulong0 >= 4294967295uL || num >= 4294967295uL) && (_ushort1 == 0 || _ushort1 >= 45));
			}
			return result;
		}

		public bool method_16()
		{
			return method_15() || _long1 >= 4294967295L;
		}

		public long method_17()
		{
			if ((byte)(_enum320 & Enum32.Flag4) == 0)
			{
				return 0L;
			}
			return _uint1;
		}

		public void method_18(long long2)
		{
			_uint1 = (uint)long2;
			_enum320 |= Enum32.Flag4;
		}

		public void method_19(DateTime dateTime0)
		{
			var num = (uint)dateTime0.Year;
			var num2 = (uint)dateTime0.Month;
			var num3 = (uint)dateTime0.Day;
			var num4 = (uint)dateTime0.Hour;
			var num5 = (uint)dateTime0.Minute;
			var num6 = (uint)dateTime0.Second;
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
			return _string0;
		}

		public long method_21()
		{
			if ((byte)(_enum320 & Enum32.Flag1) == 0)
			{
				return -1L;
			}
			return (long)_ulong0;
		}

		public void method_22(long long2)
		{
			_ulong0 = (ulong)long2;
			_enum320 |= Enum32.Flag1;
		}

		public long method_23()
		{
			if ((byte)(_enum320 & Enum32.Flag2) == 0)
			{
				return -1L;
			}
			return (long)_ulong1;
		}

		public void method_24(long long2)
		{
			_ulong1 = (ulong)long2;
			_enum320 |= Enum32.Flag2;
		}

		public long method_25()
		{
			if ((byte)(_enum320 & Enum32.Flag3) == 0)
			{
				return -1L;
			}
			return (long)(_uint0 & 4294967295uL);
		}

		public void method_26(long long2)
		{
			_uint0 = (uint)long2;
			_enum320 |= Enum32.Flag3;
		}

		public Enum31 method_27()
		{
			return _enum310;
		}

		public void method_28(Enum31 enum311)
		{
			if (!smethod_0(enum311))
			{
				throw new NotSupportedException("Compression method not supported");
			}
			_enum310 = enum311;
		}

		public byte[] method_29()
		{
			return _byte0;
		}

		public void method_30(byte[] byte2)
		{
			if (byte2 == null)
			{
				_byte0 = null;
				return;
			}
			if (byte2.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_byte0 = new byte[byte2.Length];
			Array.Copy(byte2, 0, _byte0, 0, byte2.Length);
		}

		public void method_31(bool bool1)
		{
			var @class = new Class202(_byte0);
			if (@class.method_6(1))
			{
				if ((_ushort1 & 255) < 45)
				{
					throw new ZipException("Zip64 Extended information found but version is not valid");
				}
				_bool0 = true;
				if (@class.method_3() < 4)
				{
					throw new ZipException("Extra data extended Zip64 information length is invalid");
				}
				if (bool1 || _ulong0 == 4294967295uL)
				{
					_ulong0 = (ulong)@class.method_14();
				}
				if (bool1 || _ulong1 == 4294967295uL)
				{
					_ulong1 = (ulong)@class.method_14();
				}
				if (!bool1 && _long1 == 4294967295L)
				{
					_long1 = @class.method_14();
				}
			}
			else if ((_ushort1 & 255) >= 45 && (_ulong0 == 4294967295uL || _ulong1 == 4294967295uL))
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
			return _string1;
		}

		public bool method_33()
		{
			var length = _string0.Length;
			int arg410;
			if (length > 0)
			{
				if (_string0[length - 1] == '/' || _string0[length - 1] == '\\')
				{
					arg410 = 1;
					return arg410 != 0;
				}
			}
			arg410 = (method_9(16) ? 1 : 0);
			return arg410 != 0;
		}

		public bool method_34()
		{
			return smethod_0(method_27());
		}

		public object Clone()
		{
			var @class = (Class193)MemberwiseClone();
			if (_byte0 != null)
			{
				@class._byte0 = new byte[_byte0.Length];
				Array.Copy(_byte0, 0, @class._byte0, 0, _byte0.Length);
			}
			return @class;
		}

		public override string ToString()
		{
			return _string0;
		}

		public static bool smethod_0(Enum31 enum311)
		{
			return enum311 == Enum31.Const1 || enum311 == Enum31.Const0;
		}
	}
}
