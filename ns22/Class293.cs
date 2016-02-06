using ns19;
using ns21;
using System;

namespace ns22
{
	public class Class293 : Class289<Class287>
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

		public Class293()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 17;
		}

		public override byte vmethod_15()
		{
			return 5;
		}

		public override string vmethod_5()
		{
			return "Pair Array";
		}
	}
}
