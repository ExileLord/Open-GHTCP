using System;
using System.Collections.Generic;

namespace ns18
{

    //Probably an array tree node

	public abstract class AbsTreeNode1_1_<T> : AbsTreeNode1_1 where T : AbstractBaseTreeNode1
	{
		public void method_9(IEnumerable<T> ienumerable_0)
		{
			base.Nodes.Clear();
			this.method_10(ienumerable_0);
		}

		public void method_10(IEnumerable<T> ienumerable_0)
		{
			foreach (T current in ienumerable_0)
			{
				base.Nodes.Add(current);
			}
			this.vmethod_0();
		}
	}
}
