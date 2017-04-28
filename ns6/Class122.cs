using ns7;

namespace ns6
{
	public class Class122 : Class121
	{
		private readonly byte[] byte_0 = new byte[16];

		private readonly int int_0;

		private readonly int int_1;

		private readonly int int_2;

		private readonly int int_3;

		private readonly int int_4;

		private readonly int int_5;

		private readonly int int_6;

		private readonly long long_0;

		public virtual int vmethod_1()
		{
			return int_1;
		}

		public virtual int vmethod_2()
		{
			return int_0;
		}

		public virtual long vmethod_3()
		{
			return long_0;
		}

		public virtual int vmethod_4()
		{
			return int_3;
		}

		public virtual int vmethod_5()
		{
			return int_2;
		}

		public virtual int vmethod_6()
		{
			return int_4;
		}

		public virtual int vmethod_7()
		{
			return int_6;
		}

		public virtual int vmethod_8()
		{
			return int_5;
		}

		public Class122(Class144 class144_0, int int_7, bool bool_1) : base(bool_1)
		{
			int_0 = class144_0.vmethod_10(16);
			int_1 = class144_0.vmethod_10(16);
			int_2 = class144_0.vmethod_10(24);
			int_3 = class144_0.vmethod_10(24);
			int_4 = class144_0.vmethod_10(20);
			int_5 = class144_0.vmethod_10(3) + 1;
			int_6 = class144_0.vmethod_10(5) + 1;
			long_0 = class144_0.vmethod_13(36);
			class144_0.vmethod_15(byte_0, 16);
			int_7 -= 34;
			class144_0.vmethod_15(null, int_7);
		}

		public override string ToString()
		{
			return string.Concat("StreamInfo: BlockSize=", int_0, "-", int_1, " FrameSize", int_2, "-", int_3, " SampleRate=", int_4, " Channels=", int_5, " BPS=", int_6, " TotalSamples=", long_0);
		}
	}
}
