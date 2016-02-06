using ns19;
using ns21;
using System;

namespace ns22
{
	public class Class292 : Class289<Class286>
	{
		public Class286 this[int int_0]
		{
			get
			{
				return (Class286)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public Class292()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 15;
		}

		public override byte vmethod_15()
		{
			return 10;
		}

		public override string vmethod_5()
		{
			return "Structure Array";
		}
	}
}
