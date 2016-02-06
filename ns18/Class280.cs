using ns21;
using System;
using System.Collections.Generic;

namespace ns18
{
	public class Class280 : Class278<Class314>
	{
		public int this[int int_0]
		{
			get
			{
				return ((Class314)base.Nodes[int_0]).int_0;
			}
			set
			{
				((Class314)base.Nodes[int_0]).int_0 = value;
			}
		}

		public Class280()
		{
			this.vmethod_0();
		}

		public Class280(IEnumerable<int> ienumerable_0)
		{
			this.method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 12;
		}

		public void method_11(IEnumerable<int> ienumerable_0)
		{
			foreach (int current in ienumerable_0)
			{
				base.Nodes.Add(new Class314(current));
			}
			this.vmethod_0();
		}

		public void method_12(IEnumerable<int> ienumerable_0)
		{
			base.Nodes.Clear();
			this.method_11(ienumerable_0);
		}

		public override byte vmethod_15()
		{
			return 1;
		}

		public override string vmethod_5()
		{
			return "Integer Array";
		}
	}
}
