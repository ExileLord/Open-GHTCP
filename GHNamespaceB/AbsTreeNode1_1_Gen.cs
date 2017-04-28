using System.Collections.Generic;

namespace GHNamespaceB
{

    //Probably an array tree node

	public abstract class AbsTreeNode11<T> : AbsTreeNode11 where T : AbstractBaseTreeNode1
	{
		public void method_9(IEnumerable<T> ienumerable0)
		{
			Nodes.Clear();
			method_10(ienumerable0);
		}

		public void method_10(IEnumerable<T> ienumerable0)
		{
			foreach (var current in ienumerable0)
			{
				Nodes.Add(current);
			}
			vmethod_0();
		}
	}
}
