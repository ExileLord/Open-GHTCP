using ns18;
using ns19;

namespace ns21
{
	public class ListArrayNode : ZzUnkNode289<AbsTreeNode11>
	{
		public AbsTreeNode11 this[int int0]
		{
			get => (AbsTreeNode11)Nodes[int0];
		    set => Nodes[int0] = value;
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
