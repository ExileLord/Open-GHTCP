using System;
using System.Collections.Generic;
using ns18;
using ns20;

namespace ns19
{
	public class TextValueNode : AbstractTreeNode2
	{
		public int int_0;

		private string string_0;

		public TextValueNode()
		{
			vmethod_0();
		}

		public TextValueNode(int int_1, Dictionary<int, string> dictionary_0)
		{
			int_0 = int_1;
			if (dictionary_0.ContainsKey(int_0))
			{
				string_0 = dictionary_0[int_0];
			}
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 35;
		}

		public override object vmethod_7()
		{
			if (string_0 != null)
			{
				return string_0;
			}
			return int_0;
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
			if (string_0 != null)
			{
				return '"' + string_0 + '"';
			}
			return "0x" + IntToHex32Bit(int_0);
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			if (string_1 == null)
			{
				string_0 = null;
				return;
			}
			string_0 = string_1;
			int_0 = QbSongClass1.smethod_6(string_1);
		}

		public override string GetNodeText()
		{
			return "Text Value";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 4;
		}
	}
}
