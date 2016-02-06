using ns18;
using ns21;
using System;

namespace ns20
{
	public class Class299 : Class295
	{
		public Class299()
		{
			this.vmethod_0();
		}

		public Class299(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class299(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class299(string string_0, int int_1) : this(Class327.smethod_9(string_0), int_1)
		{
		}

		public Class299(int int_1, int int_2)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new Class314(int_2));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 23;
		}

		public int method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class314)base.FirstNode).int_0;
			}
			return 0;
		}

		public void method_9(int int_1)
		{
			if (base.Nodes.Count != 0)
			{
				((Class314)base.FirstNode).int_0 = int_1;
				return;
			}
			base.Nodes.Add(new Class314(int_1));
		}

		public override string vmethod_5()
		{
			return "Integer Structure";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 3;
			}
			return 129;
		}
	}
}
