using ns20;
using System;
using System.Collections.Generic;

namespace ns18
{
	public class Class279 : Class278<Class313>
	{
		public float this[int int_0]
		{
			get
			{
				return ((Class313)base.Nodes[int_0]).float_0;
			}
			set
			{
				((Class313)base.Nodes[int_0]).float_0 = value;
			}
		}

		public Class279()
		{
			this.vmethod_0();
		}

		public Class279(IEnumerable<float> ienumerable_0)
		{
			this.method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 13;
		}

		public void method_11(IEnumerable<float> ienumerable_0)
		{
			foreach (float float_ in ienumerable_0)
			{
				base.Nodes.Add(new Class313(float_));
			}
			this.vmethod_0();
		}

		public override byte vmethod_15()
		{
			return 2;
		}

		public override string vmethod_5()
		{
			return "Float Array";
		}
	}
}
