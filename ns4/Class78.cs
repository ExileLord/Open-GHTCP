using System;

namespace ns4
{
	public class Class78
	{
		private byte[] byte_0;

		private int int_0;

		private int[] int_1;

		private long[] long_0;

		private int int_2;

		private readonly byte[] byte_1 = new byte[282];

		public Class78()
		{
			this.method_0();
		}

		private void method_0()
		{
			this.int_0 = 16384;
			this.byte_0 = new byte[this.int_0];
			this.int_2 = 1024;
			this.int_1 = new int[this.int_2];
			this.long_0 = new long[this.int_2];
		}

		public void method_1()
		{
			this.byte_0 = null;
			this.int_1 = null;
			this.long_0 = null;
		}
	}
}
