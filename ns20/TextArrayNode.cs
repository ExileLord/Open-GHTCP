using ns16;
using ns18;
using ns19;

namespace ns20
{
	public class TextArrayNode : AbsTreeNode1_1_<TextValueNode>
	{
		public string this[int int_0]
		{
			get
			{
				return ((TextValueNode)Nodes[int_0]).method_2();
			}
			set
			{
				((TextValueNode)Nodes[int_0]).method_3(value);
			}
		}

		public TextArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 11;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.ReadInt();
			if (num == 0)
			{
				return;
			}
			if (num > 1)
			{
				stream26_0.Position = stream26_0.ReadInt();
			}
			for (int i = 0; i < num; i++)
			{
				Nodes.Add(new TextValueNode(stream26_0.ReadInt(), vmethod_10()));
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			vmethod_9(true);
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = 28;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(Nodes.Count);
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 4);
			}
			foreach (TextValueNode @class in Nodes)
			{
				stream26_0.WriteByteArray(@class.vmethod_8());
				if (@class.method_2() != null)
				{
					vmethod_10()[@class.int_0] = @class.method_2();
				}
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * Nodes.Count;
		}

		public override string GetNodeText()
		{
			return "Text Array";
		}
	}
}
