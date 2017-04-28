using ns16;
using ns19;

namespace ns18
{
	public class TextRootNode : zzUnkNode260
	{
		public TextRootNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public string method_7()
		{
			if (Nodes.Count != 0)
			{
				return ((TextValueNode)FirstNode).method_2();
			}
			return null;
		}

		public int method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((TextValueNode)FirstNode).int_0;
			}
			return 0;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			int_1 = stream26_0.ReadInt();
			Nodes.Add(new TextValueNode(stream26_0.ReadInt(), vmethod_10()));
			stream26_0.ReadInt();
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			vmethod_9(true);
			byte[] array = new byte[4];
            array[1] = (vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 28;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt(int_1);
			if (Nodes.Count != 0)
			{
				stream26_0.WriteInt(method_8());
				if (method_7() != null)
				{
					vmethod_10()[method_8()] = method_7();
				}
			}
			else
			{
				stream26_0.WriteInt(0);
			}
			stream26_0.WriteInt(0);
		}

		public override string GetNodeText()
		{
			return "Text Root";
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
		}
	}
}
