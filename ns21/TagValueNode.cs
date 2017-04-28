using System;
using ns18;
using ns20;

namespace ns21
{
	public class TagValueNode : AbstractTreeNode2
	{
		public int int_0;

		public TagValueNode()
		{
			vmethod_0();
		}

		public TagValueNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public TagValueNode(string string_0)
		{
			method_3(string_0);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 35;
		}

		public override object vmethod_7()
		{
			return method_2();
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(int_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			int_0 = BitConverter.ToInt32(byte_0, 0);
		}

		public override string GetText()
		{
			return method_2();
		}

		public string method_2()
		{
			if (QbSongClass1.ContainsKey(int_0))
			{
				return QbSongClass1.GetDictString(int_0);
			}
			return "0x" + IntToHex32Bit(int_0);
		}

		public void method_3(string string_0)
		{
			int_0 = QbSongClass1.AddKeyToDictionary(string_0);
		}

		public override string GetNodeText()
		{
			return "Tag Value";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 4;
		}
	}
}
