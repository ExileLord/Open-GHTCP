using System.Text;
using GHNamespaceB;

namespace GHNamespaceC
{
	public class UnicodeValueNode : AbstractTreeNode2
	{
		public string String0 = "";

		public UnicodeValueNode()
		{
			vmethod_0();
		}

		public UnicodeValueNode(string string1)
		{
			String0 = string1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 32;
		}

		public override object vmethod_7()
		{
			return String0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.Unicode.GetBytes(String0);
		}

		public override void vmethod_9(byte[] byte0)
		{
			String0 = Encoding.Unicode.GetString(byte0);
		}

		public override string GetText()
		{
			return "\"" + String0 + "\"";
		}

		public override string GetNodeText()
		{
			return "Unicode Value";
		}

		public override void vmethod_2(ref int int0)
		{
			int0 += Encoding.Unicode.GetByteCount(String0);
		}
	}
}
