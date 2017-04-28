using ns6;

namespace ns7
{
	public class Class132 : Class131
	{
		private readonly int int_1;

		public Class132(Class144 class144_0, Class140 class140_1, Class136 class136_0, int int_2, int int_3) : base(class140_1, int_3)
		{
			int_1 = class144_0.vmethod_12(int_2);
			for (int i = 0; i < class140_1.int_0; i++)
			{
				class136_0.vmethod_0()[i] = int_1;
			}
		}

		public override string ToString()
		{
			return string.Concat("ChannelConstant: Value=", int_1, " WastedBits=", int_0);
		}
	}
}
