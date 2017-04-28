using ns19;
using ns21;

namespace ns22
{
	public class StructureArrayNode : zzUnkNode289<StructureHeaderNode>
	{
		public StructureHeaderNode this[int int_0]
		{
			get
			{
				return (StructureHeaderNode)Nodes[int_0];
			}
			set
			{
				Nodes[int_0] = value;
			}
		}

		public StructureArrayNode()
		{
			vmethod_0();
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
