using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;

namespace GHNamespaceE
{
	public class TextArrayNode : AbsTreeNode11<TextValueNode>
	{
		public string this[int int0]
		{
			get => ((TextValueNode)Nodes[int0]).method_2();
		    set => ((TextValueNode)Nodes[int0]).method_3(value);
		}

		public TextArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 11;
		}

		public override void vmethod_13(Stream26 stream260)
		{
			var num = stream260.ReadInt();
			if (num == 0)
			{
				return;
			}
			if (num > 1)
			{
				stream260.Position = stream260.ReadInt();
			}
			for (var i = 0; i < num; i++)
			{
				Nodes.Add(new TextValueNode(stream260.ReadInt(), vmethod_10()));
			}
		}

		public override void vmethod_14(Stream26 stream260)
		{
			vmethod_9(true);
			var array = new byte[4];
			array[1] = 1;
			array[2] = 28;
			stream260.WriteByteArray(array, false);
			stream260.WriteInt(Nodes.Count);
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				stream260.WriteInt((int)stream260.Position + 4);
			}
			foreach (TextValueNode @class in Nodes)
			{
				stream260.WriteByteArray(@class.vmethod_8());
				if (@class.method_2() != null)
				{
					vmethod_10()[@class.Int0] = @class.method_2();
				}
			}
		}

		public override void vmethod_2(ref int int0)
		{
			int0 += 8;
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				int0 += 4;
			}
			int0 += 4 * Nodes.Count;
		}

		public override string GetNodeText()
		{
			return "Text Array";
		}
	}
}
