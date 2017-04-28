using System;
using ns22;

namespace ns9
{
	public class ZzNote338 : AbstractNoteClass
	{
		private readonly int _int1;

		private readonly int _int2;

		private readonly int _int3;

		private readonly int _int4;

		public ZzNote338(int int5, int int6, int int7, int int8, int int9)
		{
			Int0 = int5;
			_int1 = int6;
			_int2 = int7;
			_int3 = int8;
			_int4 = int9;
		}

		public int method_1()
		{
			return _int1;
		}

		public override string ToString()
		{
			return string.Concat(method_0(), ": ", _int1, "/", Math.Pow(2.0, _int2), ", ", _int3, ", ", _int4);
		}
	}
}
