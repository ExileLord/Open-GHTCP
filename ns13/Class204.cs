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
			this.method_14("ustar ");
			this.method_16(" ");
			this.method_1("");
			this.method_12("");
			this.method_3(Class204.int_6);
			this.method_5(Class204.int_7);
			this.method_18(Class204.string_8);
			this.method_20(Class204.string_7);
			this.method_7(0L);
		}

		public string method_0()
		{
			return this.string_0;
		}

		public void method_1(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			this.string_0 = string_9;
		}

		public int method_2()
		{
			return this.int_1;
		}

		public void method_3(int int_8)
		{
			this.int_1 = int_8;
		}

		public int method_4()
		{
			return this.int_2;
		}

		public void method_5(int int_8)
		{
			this.int_2 = int_8;
		}

		public long method_6()
		{
			return this.long_0;
		}

		public void method_7(long long_1)
		{
			if (long_1 < 0L)
			{
				throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
			}
			this.long_0 = long_1;
		}

		public DateTime method_8()
		{
			return this.dateTime_1;
		}

		public int method_9()
		{
			return this.int_3;
		}

		public byte method_10()
		{
			return this.byte_0;
		}

		public string method_11()
		{
			return this.string_1;
		}

		public void method_12(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			this.string_1 = string_9;
		}

		public string method_13()
		{
			return this.string_2;
		}

		public void method_14(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			this.string_2 = string_9;
		}

		public string method_15()
		{
			return this.string_3;
		}

		public void method_16(string string_9)
		{
			if (string_9 == null)
			{
				throw new ArgumentNullException("value");
			}
			this.string_3 = string_9;
		}

		public string method_17()
		{
			return this.string_4;
		}

		public void method_18(string string_9)
		{
			if (string_9 != null)
			{
				this.string_4 = string_9.Substring(0, Math.Min(32, string_9.Length));
				return;
			}
			string text = Environment.UserName;
			if (text.Length > 32)
			{
				text = text.Substring(0, 32);
			}
			this.string_4 = text;
		}

		public string method_19()
		{
			return this.string_5;
		}

		public void method_20(string string_9)
		{
			if (string_9 == null)
			{
				this.string_5 = "None";
				return;
			}
			this.string_5 = string_9;
		}

		public int method_21()
		{
			return this.int_4;
		}

		public int method_22()
		{
			return this.int_5;
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}

		public override int GetHashCode()
		{
			return this.method_0().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Class204 @class = obj as Class204;
			return @class != null && (this.string_0 == @class.string_0 && this.int_0 == @class.int_0 && this.method_2() == @class.method_2() && this.method_4() == @class.method_4() && this.method_6() == @class.method_6() && this.method_8() == @class.method_8() && this.method_9() == @class.method_9() && this.method_10() == @class.method_10() && this.method_11() == @class.method_11() && this.method_13() == @class.method_13() && this.method_15() == @class.method_15() && this.method_17() == @class.method_17() && this.method_19() == @class.method_19() && this.method_21() == @class.method_21()) && this.method_22() == @class.method_22();
		}
	}
}
