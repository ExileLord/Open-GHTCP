using System;
using ns22;

namespace ns9
{
	public class zzNote338 : AbstractNoteClass
	{
		private readonly int int_1;

		private readonly int int_2;

		private readonly int int_3;

		private readonly int int_4;

		public zzNote338(int int_5, int int_6, int int_7, int int_8, int int_9)
		{
			int_0 = int_5;
			int_1 = int_6;
			int_2 = int_7;
			int_3 = int_8;
			int_4 = int_9;
		}

		public int method_1()
		{
			return int_1;
		}

		public override string ToString()
		{
			return string.Concat(method_0(), ": ", int_1, "/", Math.Pow(2.0, int_2), ", ", int_3, ", ", int_4);
		}
	}
}
