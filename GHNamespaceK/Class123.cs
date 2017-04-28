using System.IO;
using System.Text;
using GHNamespaceL;

namespace GHNamespaceK
{
	public class Class123 : Class121
	{
		private readonly int _int0;

		private readonly int _int1;

		private readonly string _string0;

		private readonly int _int2;

		private readonly string _string1;

		private readonly int _int3;

		private readonly int _int4;

		private readonly int _int5;

		private readonly int _int6;

		private readonly int _int7;

		public byte[] Byte0;

		public Class123(Class144 class1440, int int8, bool bool1) : base(bool1)
		{
			var num = 0;
			_int0 = class1440.vmethod_10(32);
			num = 32;
			_int1 = class1440.vmethod_10(32);
			num = 64;
			var array = new byte[_int1];
			class1440.vmethod_15(array, _int1);
			num = 64 + _int1 * 8;
			_string0 = Encoding.UTF8.GetString(array);
			_int2 = class1440.vmethod_10(32);
			num += 32;
			if (_int2 != 0)
			{
				array = new byte[_int2];
				class1440.vmethod_15(array, _int2);
				try
				{
					_string1 = Encoding.GetEncoding("UTF-8").GetString(array);
				}
				catch (IOException)
				{
				}
				num += 32;
			}
			else
			{
				_string1 = new StringBuilder("").ToString();
			}
			_int3 = class1440.vmethod_10(32);
			num += 32;
			_int4 = class1440.vmethod_10(32);
			num += 32;
			_int5 = class1440.vmethod_10(32);
			num += 32;
			_int6 = class1440.vmethod_10(32);
			num += 32;
			_int7 = class1440.vmethod_10(32);
			num += 32;
			Byte0 = new byte[_int7];
			class1440.vmethod_15(Byte0, _int7);
			num += _int7 * 8;
			int8 -= num / 8;
			class1440.vmethod_15(null, int8);
		}

		public override string ToString()
		{
			return string.Concat("Picture:  Type=", _int0, " MIME type=", _string0, " Description=\"", _string1, "\" Pixels (WxH)=", _int3, "x", _int4, " Color Depth=", _int5, " Color Count=", _int6, " Picture Size (bytes)=", _int7);
		}
	}
}
