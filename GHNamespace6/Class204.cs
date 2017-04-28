using System;

namespace GHNamespace6
{
	public class Class204 : ICloneable
	{
		private static readonly DateTime DateTime0 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		private string _string0;

		private int _int0;

		private int _int1;

		private int _int2;

		private long _long0;

		private DateTime _dateTime1;

		private int _int3;

		private byte _byte0;

		private string _string1;

		private string _string2;

		private string _string3;

		private string _string4;

		private string _string5;

		private int _int4;

		private int _int5;

		public static string String6 = "None";

		public static int Int6;

		public static int Int7;

		public static string String7 = "None";

		public static string String8;

		public Class204()
		{
			method_14("ustar ");
			method_16(" ");
			method_1("");
			method_12("");
			method_3(Int6);
			method_5(Int7);
			method_18(String8);
			method_20(String7);
			method_7(0L);
		}

		public string method_0()
		{
			return _string0;
		}

		public void method_1(string string9)
		{
			if (string9 == null)
			{
				throw new ArgumentNullException("value");
			}
			_string0 = string9;
		}

		public int method_2()
		{
			return _int1;
		}

		public void method_3(int int8)
		{
			_int1 = int8;
		}

		public int method_4()
		{
			return _int2;
		}

		public void method_5(int int8)
		{
			_int2 = int8;
		}

		public long method_6()
		{
			return _long0;
		}

		public void method_7(long long1)
		{
			if (long1 < 0L)
			{
				throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
			}
			_long0 = long1;
		}

		public DateTime method_8()
		{
			return _dateTime1;
		}

		public int method_9()
		{
			return _int3;
		}

		public byte method_10()
		{
			return _byte0;
		}

		public string method_11()
		{
			return _string1;
		}

		public void method_12(string string9)
		{
			if (string9 == null)
			{
				throw new ArgumentNullException("value");
			}
			_string1 = string9;
		}

		public string method_13()
		{
			return _string2;
		}

		public void method_14(string string9)
		{
			if (string9 == null)
			{
				throw new ArgumentNullException("value");
			}
			_string2 = string9;
		}

		public string method_15()
		{
			return _string3;
		}

		public void method_16(string string9)
		{
			if (string9 == null)
			{
				throw new ArgumentNullException("value");
			}
			_string3 = string9;
		}

		public string method_17()
		{
			return _string4;
		}

		public void method_18(string string9)
		{
			if (string9 != null)
			{
				_string4 = string9.Substring(0, Math.Min(32, string9.Length));
				return;
			}
			var text = Environment.UserName;
			if (text.Length > 32)
			{
				text = text.Substring(0, 32);
			}
			_string4 = text;
		}

		public string method_19()
		{
			return _string5;
		}

		public void method_20(string string9)
		{
			if (string9 == null)
			{
				_string5 = "None";
				return;
			}
			_string5 = string9;
		}

		public int method_21()
		{
			return _int4;
		}

		public int method_22()
		{
			return _int5;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public override int GetHashCode()
		{
			return method_0().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var @class = obj as Class204;
			return @class != null && (_string0 == @class._string0 && _int0 == @class._int0 && method_2() == @class.method_2() && method_4() == @class.method_4() && method_6() == @class.method_6() && method_8() == @class.method_8() && method_9() == @class.method_9() && method_10() == @class.method_10() && method_11() == @class.method_11() && method_13() == @class.method_13() && method_15() == @class.method_15() && method_17() == @class.method_17() && method_19() == @class.method_19() && method_21() == @class.method_21()) && method_22() == @class.method_22();
		}
	}
}
