using System.Collections.Generic;

namespace ns18
{

    //Probably an array tree node

	public abstract class AbsTreeNode1_1_<T> : AbsTreeNode1_1 where T : AbstractBaseTreeNode1
	{
		public void method_9(IEnumerable<T> ienumerable_0)
		{
			Nodes.Clear();
			method_10(ienumerable_0);
		}

		public void method_10(IEnumerable<T> ienumerable_0)
		{
			foreach (var current in ienumerable_0)
			{
				Nodes.Add(current);
			}
			vmethod_0();
		}
	}
}
