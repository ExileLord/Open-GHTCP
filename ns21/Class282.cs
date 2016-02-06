using ns18;
using System;

namespace ns21
{
	public class Class282 : Class278<Class316>
	{
		public int this[int int_0]
		{
			get
			{
				return ((Class316)base.Nodes[int_0]).int_0;
			}
			set
			{
				((Class316)base.Nodes[int_0]).int_0 = value;
			}
		}

		public Class282()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 14;
		}

		public override byte vmethod_15()
		{
			return 26;
		}

		public override string vmethod_5()
		{
			return "File Tag Array";
		}
	}
}
