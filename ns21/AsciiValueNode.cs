using System.Text;
using ns18;

namespace ns21
{
	public class AsciiValueNode : AbstractTreeNode2
	{
		public string string_0 = "";

		public AsciiValueNode()
		{
			vmethod_0();
		}

		public AsciiValueNode(string string_1)
		{
			string_0 = string_1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 31;
		}

		public override object vmethod_7()
		{
			return string_0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.ASCII.GetBytes(string_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			string_0 = Encoding.ASCII.GetString(byte_0);
		}

		public override string GetText()
		{
			return "\"" + string_0 + "\"";
		}

		public override string GetNodeText()
		{
			return "Ascii Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += Encoding.ASCII.GetByteCount(string_0);
		}
	}
}
