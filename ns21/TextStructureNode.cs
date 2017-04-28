using ns16;
using ns18;
using ns19;

namespace ns21
{
	public class TextStructureNode : zzUnkNode294
	{
		public TextStructureNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 22;
		}

		public string method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((TextValueNode)FirstNode).method_2();
			}
			return null;
		}

		public int method_9()
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
			Nodes.Add(new TextValueNode(stream26_0.ReadInt(), vmethod_10()));
			var num = stream26_0.ReadInt();
			if (num != 0)
			{
				var @class = (Parent is StructureHeaderNode) ? (Parent as StructureHeaderNode).method_11(stream26_0.ReadIntAt(num)) : vmethod_12(stream26_0.ReadIntAt(num, true));
				method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			vmethod_9(true);
			var array = new byte[4];
			array[1] = 1;
			array[2] = 28;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(int_0);
			if (Nodes.Count != 0)
			{
				stream26_0.WriteInt(method_9());
				if (method_8() != null)
				{
					vmethod_10()[method_9()] = method_8();
				}
			}
			else
			{
				stream26_0.WriteInt(0);
			}
			if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 4);
				return;
			}
			stream26_0.WriteInt(0);
		}

		public override string GetNodeText()
		{
			return "Text Structure";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
		}
	}
}
