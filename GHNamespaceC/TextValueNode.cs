using System;
using System.Collections.Generic;
using GHNamespaceB;
using GHNamespaceE;

namespace GHNamespaceC
{
	public class TextValueNode : AbstractTreeNode2
	{
		public int Int0;

		private string _string0;

		public TextValueNode()
		{
			vmethod_0();
		}

		public TextValueNode(int int1, Dictionary<int, string> dictionary0)
		{
			Int0 = int1;
			if (dictionary0.ContainsKey(Int0))
			{
				_string0 = dictionary0[Int0];
			}
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 35;
		}

		public override object vmethod_7()
		{
			if (_string0 != null)
			{
				return _string0;
			}
			return Int0;
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(Int0);
		}

		public override void vmethod_9(byte[] byte0)
		{
			Int0 = BitConverter.ToInt32(byte0, 0);
		}

		public override string GetText()
		{
			if (_string0 != null)
			{
				return '"' + _string0 + '"';
			}
			return "0x" + IntToHex32Bit(Int0);
		}

		public string method_2()
		{
			return _string0;
		}

		public void method_3(string string1)
		{
			if (string1 == null)
			{
				_string0 = null;
				return;
			}
			_string0 = string1;
			Int0 = QbSongClass1.smethod_6(string1);
		}

		public override string GetNodeText()
		{
			return "Text Value";
		}

		public override void vmethod_2(ref int int1)
		{
			int1 += 4;
		}
	}
}
