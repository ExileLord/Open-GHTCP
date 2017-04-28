using System;

namespace ns13
{
	public class Class204 : ICloneable
	{
		private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		private string string_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private long long_0;

		private DateTime dateTime_1;

		private int int_3;

		private byte byte_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private string string_4;

		private string string_5;

		private int int_4;

		private int int_5;

		public static string string_6 = "None";

		public static int int_6;

		public static int int_7;

		public static string string_7 = "None";

		public static string string_8;

		public Class204()
		{
			method_14("ustar ");
			method_16(" ");
			method_1("");
			method_12("");
			method_3(int_6);
			method_5(int_7);
			method_18(string_8);
			method_20(string_7);
			method_7(0L);
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_0 = string_9;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_8)
		{
			int_1 = int_8;
		}

		public int method_4()
		{
			return int_2;
		}

		public void method_5(int int_8)
		{
			int_2 = int_8;
		}

		public long method_6()
		{
			return long_0;
		}

		public void method_7(long long_1)
		{
			if (long_1 < 0L)
			{
				throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
			}
			long_0 = long_1;
		}

		public DateTime method_8()
		{
			return dateTime_1;
		}

		public int method_9()
		{
			return int_3;
		}

		public byte method_10()
		{
			return byte_0;
		}

		public string method_11()
		{
			return string_1;
		}

		public void method_12(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_1 = string_9;
		}

		public string method_13()
		{
			return string_2;
		}

		public void method_14(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_2 = string_9;
		}

		public string method_15()
		{
			return string_3;
		}

		public void method_16(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			string_3 = string_9;
		}

		public string method_17()
		{
			return string_4;
		}

		public void method_18(string string_9)
		{
			if (string_9 != null)
			{
				string_4 = string_9.Substring(0, Math.Min(32, string_9.Length));
				return;
			}
			var text = Environment.UserName;
			if (text.Length > 32)
			{
				text = text.Substring(0, 32);
			}
			string_4 = text;
		}

		public string method_19()
		{
			return string_5;
		}

		public void method_20(string string_9)
		{
			if (string_9 == null)
			{
				string_5 = "None";
				return;
			}
			string_5 = string_9;
		}

		public int method_21()
		{
			return int_4;
		}

		public int method_22()
		{
			return int_5;
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
			return @class != null && (string_0 == @class.string_0 && int_0 == @class.int_0 && method_2() == @class.method_2() && method_4() == @class.method_4() && method_6() == @class.method_6() && method_8() == @class.method_8() && method_9() == @class.method_9() && method_10() == @class.method_10() && method_11() == @class.method_11() && method_13() == @class.method_13() && method_15() == @class.method_15() && method_17() == @class.method_17() && method_19() == @class.method_19() && method_21() == @class.method_21()) && method_22() == @class.method_22();
		}
	}
}
