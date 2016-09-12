using ns18;
using System;
using System.Text;

namespace ns19
{
	public class Class312 : AbstractTreeNode2
	{
		public string string_0 = "";

		public Class312()
		{
			this.vmethod_0();
		}

		public Class312(string string_1)
		{
			this.string_0 = string_1;
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 32;
		}

		public override object vmethod_7()
		{
			return this.string_0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.Unicode.GetBytes(this.string_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.string_0 = Encoding.Unicode.GetString(byte_0);
		}

		public override string GetText()
		{
			return "\"" + this.string_0 + "\"";
		}

		public override string GetNodeText()
		{
			return "Unicode Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += Encoding.Unicode.GetByteCount(this.string_0);
		}
	}
}
