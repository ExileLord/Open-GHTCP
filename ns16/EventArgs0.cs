using System;

namespace ns16
{
	public class EventArgs0 : EventArgs
	{
		private readonly string string_0;

		private readonly int int_0;

		public EventArgs0(string string_1, int int_1)
		{
			string_0 = string_1;
			int_0 = int_1;
		}

		public string method_0()
		{
			return string_0;
		}

		public int method_1()
		{
			return int_0;
		}
	}
}
