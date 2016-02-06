using ns4;
using System;

namespace ns5
{
	public class Class104
	{
		private Enum4 enum4_0;

		private readonly Class105 class105_0;

		public Class104() : this(Enum4.const_0, Class105.class105_0)
		{
		}

		public Class104(Enum4 enum4_1) : this(enum4_1, Class105.class105_0)
		{
		}

		public Class104(Enum4 enum4_1, Class105 class105_1)
		{
			this.enum4_0 = enum4_1;
			this.class105_0 = class105_1;
		}

		public Enum4 method_0()
		{
			return this.enum4_0;
		}

		public Class105 method_1()
		{
			return this.class105_0;
		}
	}
}
