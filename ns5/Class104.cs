using ns4;

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
			enum4_0 = enum4_1;
			class105_0 = class105_1;
		}

		public Enum4 method_0()
		{
			return enum4_0;
		}

		public Class105 method_1()
		{
			return class105_0;
		}
	}
}
