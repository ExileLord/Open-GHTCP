using ns7;

namespace ns6
{
	public class Class122 : Class121
	{
		private readonly byte[] _byte0 = new byte[16];

		private readonly int _int0;

		private readonly int _int1;

		private readonly int _int2;

		private readonly int _int3;

		private readonly int _int4;

		private readonly int _int5;

		private readonly int _int6;

		private readonly long _long0;

		public virtual int vmethod_1()
		{
			return _int1;
		}

		public virtual int vmethod_2()
		{
			return _int0;
		}

		public virtual long vmethod_3()
		{
			return _long0;
		}

		public virtual int vmethod_4()
		{
			return _int3;
		}

		public virtual int vmethod_5()
		{
			return _int2;
		}

		public virtual int vmethod_6()
		{
			return _int4;
		}

		public virtual int vmethod_7()
		{
			return _int6;
		}

		public virtual int vmethod_8()
		{
			return _int5;
		}

		public Class122(Class144 class1440, int int7, bool bool1) : base(bool1)
		{
			_int0 = class1440.vmethod_10(16);
			_int1 = class1440.vmethod_10(16);
			_int2 = class1440.vmethod_10(24);
			_int3 = class1440.vmethod_10(24);
			_int4 = class1440.vmethod_10(20);
			_int5 = class1440.vmethod_10(3) + 1;
			_int6 = class1440.vmethod_10(5) + 1;
			_long0 = class1440.vmethod_13(36);
			class1440.vmethod_15(_byte0, 16);
			int7 -= 34;
			class1440.vmethod_15(null, int7);
		}

		public override string ToString()
		{
			return string.Concat("StreamInfo: BlockSize=", _int0, "-", _int1, " FrameSize", _int2, "-", _int3, " SampleRate=", _int4, " Channels=", _int5, " BPS=", _int6, " TotalSamples=", _long0);
		}
	}
}
