using System.Text;
using ns18;

namespace ns19
{
	public class UnicodeValueNode : AbstractTreeNode2
	{
		public string string_0 = "";

		public UnicodeValueNode()
		{
			vmethod_0();
		}

		public UnicodeValueNode(string string_1)
		{
			string_0 = string_1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 32;
		}

		public override object vmethod_7()
		{
			return string_0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.Unicode.GetBytes(string_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			string_0 = Encoding.Unicode.GetString(byte_0);
		}

		public override string GetText()
		{
			return "\"" + string_0 + "\"";
		}

		public override string GetNodeText()
		{
			return "Unicode Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += Encoding.Unicode.GetByteCount(string_0);
		}
	}
}
