using ns21;
using System;

namespace ns19
{
	public class Class290 : Class289<Class287>
	{
		public Class287 this[int int_0]
		{
			get
			{
				return (Class287)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public Class290()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 18;
		}

		public override byte vmethod_15()
		{
			return 6;
		}

		public override string vmethod_5()
		{
			return "Vector Array";
		}
	}
}
