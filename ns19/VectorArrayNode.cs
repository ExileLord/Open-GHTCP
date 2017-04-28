using ns21;

namespace ns19
{
	public class VectorArrayNode : zzUnkNode289<FloatListNode>
	{
		public FloatListNode this[int int_0]
		{
			get
			{
				return (FloatListNode)Nodes[int_0];
			}
			set
			{
				Nodes[int_0] = value;
			}
		}

		public VectorArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 18;
		}

		public override byte vmethod_15()
		{
			return 6;
		}

		public override string GetNodeText()
		{
			return "Vector Array";
		}
	}
}
