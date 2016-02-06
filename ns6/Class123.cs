using ns7;
using System;
using System.IO;
using System.Text;

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
			this.int_0 = class144_0.vmethod_10(32);
			num = 32;
			this.int_1 = class144_0.vmethod_10(32);
			num = 64;
			byte[] array = new byte[this.int_1];
			class144_0.vmethod_15(array, this.int_1);
			num = 64 + this.int_1 * 8;
			this.string_0 = Encoding.UTF8.GetString(array);
			this.int_2 = class144_0.vmethod_10(32);
			num += 32;
			if (this.int_2 != 0)
			{
				array = new byte[this.int_2];
				class144_0.vmethod_15(array, this.int_2);
				try
				{
					this.string_1 = Encoding.GetEncoding("UTF-8").GetString(array);
				}
				catch (IOException)
				{
				}
				num += 32;
			}
			else
			{
				this.string_1 = new StringBuilder("").ToString();
			}
			this.int_3 = class144_0.vmethod_10(32);
			num += 32;
			this.int_4 = class144_0.vmethod_10(32);
			num += 32;
			this.int_5 = class144_0.vmethod_10(32);
			num += 32;
			this.int_6 = class144_0.vmethod_10(32);
			num += 32;
			this.int_7 = class144_0.vmethod_10(32);
			num += 32;
			this.byte_0 = new byte[this.int_7];
			class144_0.vmethod_15(this.byte_0, this.int_7);
			num += this.int_7 * 8;
			int_8 -= num / 8;
			class144_0.vmethod_15(null, int_8);
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Picture:  Type=",
				this.int_0,
				" MIME type=",
				this.string_0,
				" Description=\"",
				this.string_1,
				"\" Pixels (WxH)=",
				this.int_3,
				"x",
				this.int_4,
				" Color Depth=",
				this.int_5,
				" Color Count=",
				this.int_6,
				" Picture Size (bytes)=",
				this.int_7
			});
		}
	}
}
