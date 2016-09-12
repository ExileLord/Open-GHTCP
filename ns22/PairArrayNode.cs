using ns19;
using ns21;
using System;

namespace ns22
{
	public class PairArrayNode : Class289<FloatListNode>
	{
		public FloatListNode this[int int_0]
		{
			get
			{
				return (FloatListNode)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public PairArrayNode()
		{
			this.vmethod_0();
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
