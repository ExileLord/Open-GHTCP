using ns6;
using ns7;
using System;
using System.IO;
using System.Text;

namespace ns11
{
	public class Class135 : Class131
	{
		private Class137 class137_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int[] int_4 = new int[32];

		private int[] int_5 = new int[32];

		private int[] int_6;

		public Class135(Class144 class144_0, Class140 class140_1, Class136 class136_0, int int_7, int int_8, int int_9) : base(class140_1, int_8)
		{
			this.int_6 = class136_0.vmethod_2();
			this.int_1 = int_9;
			for (int i = 0; i < int_9; i++)
			{
				this.int_5[i] = class144_0.vmethod_12(int_7);
			}
			int num = class144_0.vmethod_10(4);
			if (num == 15)
			{
				throw new IOException("STREAM_DECODER_ERROR_STATUS_LOST_SYNC");
			}
			this.int_2 = num + 1;
			this.int_3 = class144_0.vmethod_12(5);
			for (int j = 0; j < int_9; j++)
			{
				this.int_4[j] = class144_0.vmethod_12(this.int_2);
			}
			int num2 = class144_0.vmethod_10(2);
			int num3 = num2;
			if (num3 != 0)
			{
				throw new IOException("STREAM_DECODER_UNPARSEABLE_STREAM");
			}
			this.class137_0 = new Class138();
			((Class138)this.class137_0).int_0 = class144_0.vmethod_10(4);
			((Class138)this.class137_0).class143_0 = class136_0.vmethod_1();
			if (this.class137_0 is Class138)
			{
				((Class138)this.class137_0).vmethod_0(class144_0, int_9, ((Class138)this.class137_0).int_0, class140_1, class136_0.vmethod_2());
			}
			Buffer.BlockCopy(this.int_5, 0, class136_0.vmethod_0(), 0, int_9 << 2);
			if (int_7 + this.int_2 + Class141.smethod_0(int_9) > 32)
			{
				Class130.smethod_1(class136_0.vmethod_2(), class140_1.int_0 - int_9, this.int_4, int_9, this.int_3, class136_0.vmethod_0(), int_9);
				return;
			}
			if (int_7 <= 16 && this.int_2 <= 16)
			{
				Class130.smethod_0(class136_0.vmethod_2(), class140_1.int_0 - int_9, this.int_4, int_9, this.int_3, class136_0.vmethod_0(), int_9);
				return;
			}
			Class130.smethod_0(class136_0.vmethod_2(), class140_1.int_0 - int_9, this.int_4, int_9, this.int_3, class136_0.vmethod_0(), int_9);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(string.Concat(new object[]
			{
				"ChannelLPC: Order=",
				this.int_1,
				" WastedBits=",
				this.int_0
			}));
			stringBuilder.Append(string.Concat(new object[]
			{
				" qlpCoeffPrecision=",
				this.int_2,
				" quantizationLevel=",
				this.int_3
			}));
			stringBuilder.Append("\n\t\tqlpCoeff: ");
			for (int i = 0; i < this.int_1; i++)
			{
				stringBuilder.Append(this.int_4[i] + " ");
			}
			stringBuilder.Append("\n\t\tWarmup: ");
			for (int j = 0; j < this.int_1; j++)
			{
				stringBuilder.Append(this.int_5[j] + " ");
			}
			stringBuilder.Append("\n\t\tParameter: ");
			for (int k = 0; k < 1 << ((Class138)this.class137_0).int_0; k++)
			{
				stringBuilder.Append(((Class138)this.class137_0).class143_0.int_0[k] + " ");
			}
			return stringBuilder.ToString();
		}
	}
}
