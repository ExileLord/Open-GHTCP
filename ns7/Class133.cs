using System;
using ns6;

namespace ns7
{
	public class Class133 : Class131
	{
		private readonly int[] int_1;

		public Class133(Class144 class144_0, Class140 class140_1, Class136 class136_0, int int_2, int int_3) : base(class140_1, int_3)
		{
			int_1 = class136_0.vmethod_2();
			for (var i = 0; i < class140_1.int_0; i++)
			{
				int_1[i] = class144_0.vmethod_12(int_2);
			}
			Buffer.BlockCopy(int_1, 0, class136_0.vmethod_0(), 0, class140_1.int_0 << 2);
		}

		public override string ToString()
		{
			return "ChannelVerbatim: WastedBits=" + int_0;
		}
	}
}
