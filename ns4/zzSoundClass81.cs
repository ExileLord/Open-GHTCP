using ns5;
using SharpAudio.ASC.Mp3.Decoding;
using System;

namespace ns4
{
	public class zzSoundClass81
	{
		private static readonly Class104 class104_0 = new Class104();

		private Class84 class84_0;

		private Class80 class80_0;

		private Class80 class80_1;

		private Class85 class85_0;

		private Class93 class93_0;

		private Class92 class92_0;

		private int int_0;

		private int int_1;

		private readonly Class105 class105_0 = new Class105();

		private readonly Class104 class104_1;

		private bool bool_0;

		public Class84 method_0()
		{
			return this.class84_0;
		}

		public int method_1()
		{
			return this.int_0;
		}

		public int method_2()
		{
			return this.int_1;
		}

		public zzSoundClass81() : this(null)
		{
		}

		public zzSoundClass81(Class104 class104_2)
		{
			if (class104_2 == null)
			{
				class104_2 = zzSoundClass81.class104_0;
			}
			this.class104_1 = class104_2;
			Class105 @class = this.class104_1.method_1();
			if (@class != null)
			{
				this.class105_0.method_2(@class);
			}
		}

		private void method_3(zzSoundClass class107_0)
		{
			Enum5 @enum = class107_0.method_8();
			class107_0.method_4();
			int num = (@enum == Enum5.const_3 || this.class104_1.method_0() != Enum4.const_0) ? 1 : 2;
			if (this.class84_0 == null)
			{
				this.class84_0 = new Class84(num);
			}
			float[] float_ = this.class105_0.method_0();
			this.class80_0 = new Class80(0, float_);
			if (num == 2)
			{
				this.class80_1 = new Class80(1, float_);
			}
			this.int_1 = num;
			this.int_0 = class107_0.method_7();
			this.bool_0 = true;
		}

		private Interface7 method_4(zzSoundClass class107_0, Class82 class82_0, int int_2)
		{
			Interface7 @interface = null;
			switch (int_2)
			{
			case 1:
				if (this.class92_0 == null)
				{
					this.class92_0 = new Class92();
					this.class92_0.vmethod_0(class82_0, class107_0, this.class80_0, this.class80_1, this.class84_0, this.class104_1.method_0());
				}
				@interface = this.class92_0;
				break;
			case 2:
				if (this.class93_0 == null)
				{
					this.class93_0 = new Class93();
					this.class93_0.vmethod_0(class82_0, class107_0, this.class80_0, this.class80_1, this.class84_0, this.class104_1.method_0());
				}
				@interface = this.class93_0;
				break;
			case 3:
				if (this.class85_0 == null)
				{
					this.class85_0 = new Class85(class82_0, class107_0, this.class80_0, this.class80_1, this.class84_0, this.class104_1.method_0());
				}
				@interface = this.class85_0;
				break;
			}
			if (@interface == null)
			{
				throw new DecoderException(DecoderError.UnsupportedLayer, null);
			}
			return @interface;
		}

		public Class84 method_5(zzSoundClass class107_0, Class82 class82_0)
		{
			if (!this.bool_0)
			{
				this.method_3(class107_0);
			}
			int int_ = class107_0.method_4();
			this.class84_0.method_6();
			Interface7 @interface = this.method_4(class107_0, class82_0, int_);
			@interface.imethod_0();
			this.class84_0.method_5();
			return this.class84_0;
		}
	}
}
