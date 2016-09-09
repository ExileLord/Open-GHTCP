using ns2;
using System;

namespace ns3
{
	public class Class47
	{
		private static string string_0 = "vorbis";

		private static int int_0 = -130;

		public byte[][] byte_0;

		public int[] int_1;

		public int int_2;

		public byte[] byte_1;

		public void method_0()
		{
			this.byte_0 = null;
			this.int_2 = 0;
			this.byte_1 = null;
		}

		public int method_1(OGGClass3 class38_0)
		{
			int num = class38_0.method_6(32);
			if (num < 0)
			{
				this.method_2();
				return -1;
			}
			this.byte_1 = new byte[num + 1];
			class38_0.method_5(this.byte_1, num);
			this.int_2 = class38_0.method_6(32);
			if (this.int_2 < 0)
			{
				this.method_2();
				return -1;
			}
			this.byte_0 = new byte[this.int_2 + 1][];
			this.int_1 = new int[this.int_2 + 1];
			for (int i = 0; i < this.int_2; i++)
			{
				int num2 = class38_0.method_6(32);
				if (num2 < 0)
				{
					this.method_2();
					return -1;
				}
				this.int_1[i] = num2;
				this.byte_0[i] = new byte[num2 + 1];
				class38_0.method_5(this.byte_0[i], num2);
			}
			if (class38_0.method_6(1) != 1)
			{
				this.method_2();
				return -1;
			}
			return 0;
		}

		public void method_2()
		{
			for (int i = 0; i < this.int_2; i++)
			{
				this.byte_0[i] = null;
			}
			this.byte_0 = null;
			this.byte_1 = null;
		}
	}
}
