using ns18;
using ns19;

namespace ns21
{
	public class ListArrayNode : zzUnkNode289<AbsTreeNode1_1>
	{
		public AbsTreeNode1_1 this[int int_0]
		{
			get
			{
				return (AbsTreeNode1_1)Nodes[int_0];
			}
			set
			{
				Nodes[int_0] = value;
			}
		}

		public ListArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 16;
		}

		public override byte vmethod_15()
		{
			return 12;
		}

		public override string GetNodeText()
		{
			return "List Array";
		}
	}
}
