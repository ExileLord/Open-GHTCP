using ns19;
using ns21;

namespace ns22
{
	public class PairArrayNode : zzUnkNode289<FloatListNode>
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

		public PairArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 17;
		}

		public override byte vmethod_15()
		{
			return 5;
		}

		public override string GetNodeText()
		{
			return "Pair Array";
		}
	}
}
