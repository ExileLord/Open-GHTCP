using System;
using ns11;

namespace ns8
{
	public class Exception4 : Exception
	{
		private readonly Enum18 _enum180;

		private string _string0;

		public Exception4(Enum18 enum181, string string1) : base(smethod_0(enum181, string1))
		{
			_enum180 = enum181;
			_string0 = string1;
		}

		private static string smethod_0(Enum18 enum181, string string1)
		{
			return string.Format("{0} calling {1}", enum181, string1);
		}

		public static void smethod_1(Enum18 enum181, string string1)
		{
			if (enum181 != Enum18.Const0)
			{
				throw new Exception4(enum181, string1);
			}
		}

		public Enum18 method_0()
		{
			return _enum180;
		}
	}
}
