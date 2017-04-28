using System;
using System.IO;
using System.Text;
using ns6;
using ns7;

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
			int_6 = class136_0.vmethod_2();
			int_1 = int_9;
			for (var i = 0; i < int_9; i++)
			{
				int_5[i] = class144_0.vmethod_12(int_7);
			}
			var num = class144_0.vmethod_10(4);
			if (num == 15)
			{
				throw new IOException("STREAM_DECODER_ERROR_STATUS_LOST_SYNC");
			}
			int_2 = num + 1;
			int_3 = class144_0.vmethod_12(5);
			for (var j = 0; j < int_9; j++)
			{
				int_4[j] = class144_0.vmethod_12(int_2);
			}
			var num2 = class144_0.vmethod_10(2);
			var num3 = num2;
			if (num3 != 0)
			{
				throw new IOException("STREAM_DECODER_UNPARSEABLE_STREAM");
			}
			class137_0 = new Class138();
			((Class138)class137_0).int_0 = class144_0.vmethod_10(4);
			((Class138)class137_0).class143_0 = class136_0.vmethod_1();
			if (class137_0 is Class138)
			{
				((Class138)class137_0).vmethod_0(class144_0, int_9, ((Class138)class137_0).int_0, class140_1, class136_0.vmethod_2());
			}
			Buffer.BlockCopy(int_5, 0, class136_0.vmethod_0(), 0, int_9 << 2);
			if (int_7 + int_2 + Class141.smethod_0(int_9) > 32)
			{
				Class130.smethod_1(class136_0.vmethod_2(), class140_1.int_0 - int_9, int_4, int_9, int_3, class136_0.vmethod_0(), int_9);
				return;
			}
			if (int_7 <= 16 && int_2 <= 16)
			{
				Class130.smethod_0(class136_0.vmethod_2(), class140_1.int_0 - int_9, int_4, int_9, int_3, class136_0.vmethod_0(), int_9);
				return;
			}
			Class130.smethod_0(class136_0.vmethod_2(), class140_1.int_0 - int_9, int_4, int_9, int_3, class136_0.vmethod_0(), int_9);
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder(string.Concat("ChannelLPC: Order=", int_1, " WastedBits=", int_0));
			stringBuilder.Append(string.Concat(" qlpCoeffPrecision=", int_2, " quantizationLevel=", int_3));
			stringBuilder.Append("\n\t\tqlpCoeff: ");
			for (var i = 0; i < int_1; i++)
			{
				stringBuilder.Append(int_4[i] + " ");
			}
			stringBuilder.Append("\n\t\tWarmup: ");
			for (var j = 0; j < int_1; j++)
			{
				stringBuilder.Append(int_5[j] + " ");
			}
			stringBuilder.Append("\n\t\tParameter: ");
			for (var k = 0; k < 1 << ((Class138)class137_0).int_0; k++)
			{
				stringBuilder.Append(((Class138)class137_0).class143_0.int_0[k] + " ");
			}
			return stringBuilder.ToString();
		}
	}
}
