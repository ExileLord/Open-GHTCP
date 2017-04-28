using System.Text;
using ns18;

namespace ns21
{
	public class AsciiValueNode : AbstractTreeNode2
	{
		public string String0 = "";

		public AsciiValueNode()
		{
			vmethod_0();
		}

		public AsciiValueNode(string string1)
		{
			String0 = string1;
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 31;
		}

		public override object vmethod_7()
		{
			return String0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.ASCII.GetBytes(String0);
		}

		public override void vmethod_9(byte[] byte0)
		{
			String0 = Encoding.ASCII.GetString(byte0);
		}

		public override string GetText()
		{
			return "\"" + String0 + "\"";
		}

		public override string GetNodeText()
		{
			return "Ascii Value";
		}

		public override void vmethod_2(ref int int0)
		{
			int0 += Encoding.ASCII.GetByteCount(String0);
		}
	}
}
