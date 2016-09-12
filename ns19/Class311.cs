using ns18;
using ns20;
using System;
using System.Collections.Generic;

namespace ns19
{
	public class Class311 : Class310
	{
		public int int_0;

		private string string_0;

		public Class311()
		{
			this.vmethod_0();
		}

		public Class311(int int_1, Dictionary<int, string> dictionary_0)
		{
			this.int_0 = int_1;
			if (dictionary_0.ContainsKey(this.int_0))
			{
				this.string_0 = dictionary_0[this.int_0];
			}
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 35;
		}

		public override object vmethod_7()
		{
			if (this.string_0 != null)
			{
				return this.string_0;
			}
			return this.int_0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(this.int_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.int_0 = BitConverter.ToInt32(byte_0, 0);
		}

		public override string vmethod_3()
		{
			if (this.string_0 != null)
			{
				return '"' + this.string_0 + '"';
			}
			return "0x" + base.method_1(this.int_0);
		}

		public string method_2()
		{
			return this.string_0;
		}

		public void method_3(string string_1)
		{
			if (string_1 == null)
			{
				this.string_0 = null;
				return;
			}
			this.string_0 = string_1;
			this.int_0 = QbSongClass1.smethod_6(string_1);
		}

		public override string vmethod_5()
		{
			return "Text Value";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 4;
		}
	}
}
