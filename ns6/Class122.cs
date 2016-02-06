using ns7;
using System;

namespace ns6
{
	public class Class122 : Class121
	{
		private byte[] byte_0 = new byte[16];

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private long long_0;

		public virtual int vmethod_1()
		{
			return this.int_1;
		}

		public virtual int vmethod_2()
		{
			return this.int_0;
		}

		public virtual long vmethod_3()
		{
			return this.long_0;
		}

		public virtual int vmethod_4()
		{
			return this.int_3;
		}

		public virtual int vmethod_5()
		{
			return this.int_2;
		}

		public virtual int vmethod_6()
		{
			return this.int_4;
		}

		public virtual int vmethod_7()
		{
			return this.int_6;
		}

		public virtual int vmethod_8()
		{
			return this.int_5;
		}

		public Class122(Class144 class144_0, int int_7, bool bool_1) : base(bool_1)
		{
			this.int_0 = class144_0.vmethod_10(16);
			this.int_1 = class144_0.vmethod_10(16);
			this.int_2 = class144_0.vmethod_10(24);
			this.int_3 = class144_0.vmethod_10(24);
			this.int_4 = class144_0.vmethod_10(20);
			this.int_5 = class144_0.vmethod_10(3) + 1;
			this.int_6 = class144_0.vmethod_10(5) + 1;
			this.long_0 = class144_0.vmethod_13(36);
			class144_0.vmethod_15(this.byte_0, 16);
			int_7 -= 34;
			class144_0.vmethod_15(null, int_7);
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"StreamInfo: BlockSize=",
				this.int_0,
				"-",
				this.int_1,
				" FrameSize",
				this.int_2,
				"-",
				this.int_3,
				" SampleRate=",
				this.int_4,
				" Channels=",
				this.int_5,
				" BPS=",
				this.int_6,
				" TotalSamples=",
				this.long_0
			});
		}
	}
}
