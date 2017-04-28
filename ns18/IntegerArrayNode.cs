using System.Collections.Generic;
using ns21;

namespace ns18
{
	public class IntegerArrayNode : zzUnkNode278<IntegerValueNode>
	{
		public int this[int int_0]
		{
			get
			{
				return ((IntegerValueNode)Nodes[int_0]).int_0;
			}
			set
			{
				((IntegerValueNode)Nodes[int_0]).int_0 = value;
			}
		}

		public IntegerArrayNode()
		{
			vmethod_0();
		}

		public IntegerArrayNode(IEnumerable<int> ienumerable_0)
		{
			method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 12;
		}

		public void method_11(IEnumerable<int> ienumerable_0)
		{
			foreach (int current in ienumerable_0)
			{
				Nodes.Add(new IntegerValueNode(current));
			}
			vmethod_0();
		}

		public void method_12(IEnumerable<int> ienumerable_0)
		{
			Nodes.Clear();
			method_11(ienumerable_0);
		}

		public override byte vmethod_15()
		{
			return 1;
		}

		public override string GetNodeText()
		{
			return "Integer Array";
		}
	}
}
