using ns22;
using System;

namespace ns9
{
	public class Class338 : AbstractNoteClass
	{
		private readonly int int_1;

		private readonly int int_2;

		private readonly int int_3;

		private readonly int int_4;

		public Class338(int int_5, int int_6, int int_7, int int_8, int int_9)
		{
			this.int_0 = int_5;
			this.int_1 = int_6;
			this.int_2 = int_7;
			this.int_3 = int_8;
			this.int_4 = int_9;
		}

		public int method_1()
		{
			return this.int_1;
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				base.method_0(),
				": ",
				this.int_1,
				"/",
				Math.Pow(2.0, (double)this.int_2),
				", ",
				this.int_3,
				", ",
				this.int_4
			});
		}
	}
}
