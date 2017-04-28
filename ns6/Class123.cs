using System.IO;
using System.Text;
using ns7;

namespace ns6
{
	public class Class123 : Class121
	{
		private readonly int int_0;

		private readonly int int_1;

		private readonly string string_0;

		private readonly int int_2;

		private readonly string string_1;

		private readonly int int_3;

		private readonly int int_4;

		private readonly int int_5;

		private readonly int int_6;

		private readonly int int_7;

		public byte[] byte_0;

		public Class123(Class144 class144_0, int int_8, bool bool_1) : base(bool_1)
		{
			int num = 0;
			int_0 = class144_0.vmethod_10(32);
			num = 32;
			int_1 = class144_0.vmethod_10(32);
			num = 64;
			byte[] array = new byte[int_1];
			class144_0.vmethod_15(array, int_1);
			num = 64 + int_1 * 8;
			string_0 = Encoding.UTF8.GetString(array);
			int_2 = class144_0.vmethod_10(32);
			num += 32;
			if (int_2 != 0)
			{
				array = new byte[int_2];
				class144_0.vmethod_15(array, int_2);
				try
				{
					string_1 = Encoding.GetEncoding("UTF-8").GetString(array);
				}
				catch (IOException)
				{
				}
				num += 32;
			}
			else
			{
				string_1 = new StringBuilder("").ToString();
			}
			int_3 = class144_0.vmethod_10(32);
			num += 32;
			int_4 = class144_0.vmethod_10(32);
			num += 32;
			int_5 = class144_0.vmethod_10(32);
			num += 32;
			int_6 = class144_0.vmethod_10(32);
			num += 32;
			int_7 = class144_0.vmethod_10(32);
			num += 32;
			byte_0 = new byte[int_7];
			class144_0.vmethod_15(byte_0, int_7);
			num += int_7 * 8;
			int_8 -= num / 8;
			class144_0.vmethod_15(null, int_8);
		}

		public override string ToString()
		{
			return string.Concat("Picture:  Type=", int_0, " MIME type=", string_0, " Description=\"", string_1, "\" Pixels (WxH)=", int_3, "x", int_4, " Color Depth=", int_5, " Color Count=", int_6, " Picture Size (bytes)=", int_7);
		}
	}
}
