using System;

namespace ns22
{
	public class zzNote1 : AbstractNoteClass
	{
		public enum Enum37
		{
			const_0 = 1,
			const_1,
			const_2
		}

		private readonly zzNote1.Enum37 enum37_0;

		private readonly string string_0;

		public zzNote1(int int_1, zzNote1.Enum37 enum37_1, string string_1)
		{
			this.int_0 = int_1;
			this.enum37_0 = enum37_1;
			this.string_0 = string_1;
		}

		public string method_1()
		{
			return this.string_0;
		}

		public zzNote1.Enum37 method_2()
		{
			return this.enum37_0;
		}

		public override string ToString()
		{
			return string.Format("{0}: \"{1}\"", base.method_0(), this.string_0);
		}
	}
}
