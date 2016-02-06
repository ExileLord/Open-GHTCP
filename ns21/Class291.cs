using ns18;
using ns19;
using System;

namespace ns21
{
	public class Class291 : Class289<Class276>
	{
		public Class276 this[int int_0]
		{
			get
			{
				return (Class276)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public Class291()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 16;
		}

		public override byte vmethod_15()
		{
			return 12;
		}

		public override string vmethod_5()
		{
			return "List Array";
		}
	}
}
