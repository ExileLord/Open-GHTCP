using System;
using System.Collections.Generic;

namespace ns18
{
	public abstract class Class277<T> : Class276 where T : Class258
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
