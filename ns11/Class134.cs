using System;
using System.IO;
using System.Text;
using ns6;
using ns7;

namespace ns11
{
	public class Class134 : Class131
	{
		private readonly Class137 class137_0;

		private readonly int int_1;

		private readonly int[] int_2 = new int[4];

		private readonly int[] int_3;

		public Class134(Class144 class144_0, Class140 class140_1, Class136 class136_0, int int_4, int int_5, int int_6) : base(class140_1, int_5)
		{
			int_3 = class136_0.vmethod_2();
			int_1 = int_6;
			for (var i = 0; i < int_6; i++)
			{
				int_2[i] = class144_0.vmethod_12(int_4);
			}
			var num = class144_0.vmethod_10(2);
			var num2 = num;
			if (num2 == 0)
			{
				var int_7 = class144_0.vmethod_10(4);
				var @class = new Class138();
				class137_0 = @class;
				@class.int_0 = int_7;
				@class.class143_0 = class136_0.vmethod_1();
				@class.vmethod_0(class144_0, int_6, @class.int_0, class140_1, class136_0.vmethod_2());
				Buffer.BlockCopy(int_2, 0, class136_0.vmethod_0(), 0, int_6 << 2);
				BlackMagic.CopyArrayOffset(int_3, class140_1.int_0 - int_6, int_6, class136_0.vmethod_0(), int_6);
				return;
			}
			throw new IOException("STREAM_DECODER_UNPARSEABLE_STREAM");
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder(string.Concat("FLACSubframe_Fixed: Order=", int_1, " PartitionOrder=", ((Class138)class137_0).int_0, " WastedBits=", int_0));
			for (var i = 0; i < int_1; i++)
			{
				stringBuilder.Append(string.Concat(" warmup[", i, "]=", int_2[i]));
			}
			return stringBuilder.ToString();
		}
	}
}
