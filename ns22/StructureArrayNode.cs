using ns19;
using ns21;
using System;

namespace ns22
{
	public class StructureArrayNode : Class289<StructureHeaderNode>
	{
		public StructureHeaderNode this[int int_0]
		{
			get
			{
				return (StructureHeaderNode)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public StructureArrayNode()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 15;
		}

		public override byte vmethod_15()
		{
			return 10;
		}

		public override string GetNodeText()
		{
			return "Structure Array";
		}
	}
}
