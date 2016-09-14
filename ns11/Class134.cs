using ns6;
using ns7;
using System;
using System.IO;
using System.Text;

namespace ns11
{
	public class Class134 : Class131
	{
		private Class137 class137_0;

		private int int_1;

		private int[] int_2 = new int[4];

		private int[] int_3;

		public Class134(Class144 class144_0, Class140 class140_1, Class136 class136_0, int int_4, int int_5, int int_6) : base(class140_1, int_5)
		{
			this.int_3 = class136_0.vmethod_2();
			this.int_1 = int_6;
			for (int i = 0; i < int_6; i++)
			{
				this.int_2[i] = class144_0.vmethod_12(int_4);
			}
			int num = class144_0.vmethod_10(2);
			int num2 = num;
			if (num2 == 0)
			{
				int int_7 = class144_0.vmethod_10(4);
				Class138 @class = new Class138();
				this.class137_0 = @class;
				@class.int_0 = int_7;
				@class.class143_0 = class136_0.vmethod_1();
				@class.vmethod_0(class144_0, int_6, @class.int_0, class140_1, class136_0.vmethod_2());
				Buffer.BlockCopy(this.int_2, 0, class136_0.vmethod_0(), 0, int_6 << 2);
				BlackMagic.CopyArrayOffset(this.int_3, class140_1.int_0 - int_6, int_6, class136_0.vmethod_0(), int_6);
				return;
			}
			throw new IOException("STREAM_DECODER_UNPARSEABLE_STREAM");
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(string.Concat(new object[]
			{
				"FLACSubframe_Fixed: Order=",
				this.int_1,
				" PartitionOrder=",
				((Class138)this.class137_0).int_0,
				" WastedBits=",
				this.int_0
			}));
			for (int i = 0; i < this.int_1; i++)
			{
				stringBuilder.Append(string.Concat(new object[]
				{
					" warmup[",
					i,
					"]=",
					this.int_2[i]
				}));
			}
			return stringBuilder.ToString();
		}
	}
}
