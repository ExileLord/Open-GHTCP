using GHNamespaceF;

namespace GHNamespaceC
{
	public class VectorArrayNode : ZzUnkNode289<FloatListNode>
	{
		public FloatListNode this[int int0]
		{
			get => (FloatListNode)Nodes[int0];
		    set => Nodes[int0] = value;
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
