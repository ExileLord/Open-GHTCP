using ns5;
using SharpAudio.ASC.Mp3.Decoding;

namespace ns4
{
	public class ZzSoundClass81
	{
		private static readonly Class104 Class1040 = new Class104();

		private Class84 _class840;

		private Class80 _class800;

		private Class80 _class801;

		private Class85 _class850;

		private Class93 _class930;

		private Class92 _class920;

		private int _int0;

		private int _int1;

		private readonly Class105 _class1050 = new Class105();

		private readonly Class104 _class1041;

		private bool _bool0;

		public Class84 method_0()
		{
			return _class840;
		}

		public int method_1()
		{
			return _int0;
		}

		public int method_2()
		{
			return _int1;
		}

		public ZzSoundClass81() : this(null)
		{
		}

		public ZzSoundClass81(Class104 class1042)
		{
			if (class1042 == null)
			{
				class1042 = Class1040;
			}
			_class1041 = class1042;
			var @class = _class1041.method_1();
			if (@class != null)
			{
				_class1050.method_2(@class);
			}
		}

		private void method_3(ZzSoundClass class1070)
		{
			var @enum = class1070.method_8();
			class1070.method_4();
			var num = (@enum == Enum5.Const3 || _class1041.method_0() != Enum4.Const0) ? 1 : 2;
			if (_class840 == null)
			{
				_class840 = new Class84(num);
			}
			var float_ = _class1050.method_0();
			_class800 = new Class80(0, float_);
			if (num == 2)
			{
				_class801 = new Class80(1, float_);
			}
			_int1 = num;
			_int0 = class1070.method_7();
			_bool0 = true;
		}

		private INterface7 method_4(ZzSoundClass class1070, Class82 class820, int int2)
		{
			INterface7 @interface = null;
			switch (int2)
			{
			case 1:
				if (_class920 == null)
				{
					_class920 = new Class92();
					_class920.vmethod_0(class820, class1070, _class800, _class801, _class840, _class1041.method_0());
				}
				@interface = _class920;
				break;
			case 2:
				if (_class930 == null)
				{
					_class930 = new Class93();
					_class930.vmethod_0(class820, class1070, _class800, _class801, _class840, _class1041.method_0());
				}
				@interface = _class930;
				break;
			case 3:
				if (_class850 == null)
				{
					_class850 = new Class85(class820, class1070, _class800, _class801, _class840, _class1041.method_0());
				}
				@interface = _class850;
				break;
			}
			if (@interface == null)
			{
				throw new DecoderException(DecoderError.UnsupportedLayer, null);
			}
			return @interface;
		}

		public Class84 method_5(ZzSoundClass class1070, Class82 class820)
		{
			if (!_bool0)
			{
				method_3(class1070);
			}
			var int_ = class1070.method_4();
			_class840.method_6();
			var @interface = method_4(class1070, class820, int_);
			@interface.imethod_0();
			_class840.method_5();
			return _class840;
		}
	}
}
