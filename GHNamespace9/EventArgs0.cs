using System;

namespace GHNamespace9
{
	public class EventArgs0 : EventArgs
	{
		private readonly string _string0;

		private readonly int _int0;

		public EventArgs0(string string1, int int1)
		{
			_string0 = string1;
			_int0 = int1;
		}

		public string method_0()
		{
			return _string0;
		}

		public int method_1()
		{
			return _int0;
		}
	}
}
