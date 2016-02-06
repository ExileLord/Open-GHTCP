using ns11;
using System;

namespace ns8
{
	public class Exception4 : Exception
	{
		private readonly Enum18 enum18_0;

		private string string_0;

		public Exception4(Enum18 enum18_1, string string_1) : base(Exception4.smethod_0(enum18_1, string_1))
		{
			this.enum18_0 = enum18_1;
			this.string_0 = string_1;
		}

		private static string smethod_0(Enum18 enum18_1, string string_1)
		{
			return string.Format("{0} calling {1}", enum18_1, string_1);
		}

		public static void smethod_1(Enum18 enum18_1, string string_1)
		{
			if (enum18_1 != Enum18.const_0)
			{
				throw new Exception4(enum18_1, string_1);
			}
		}

		public Enum18 method_0()
		{
			return this.enum18_0;
		}
	}
}
