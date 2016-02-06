using ns19;
using ns21;
using System;

namespace ns20
{
	public class Class266 : Class263
	{
		public Class266()
		{
			this.vmethod_0();
		}

		public Class266(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class266(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public Class266(int int_2, string string_0, Class286 class286_0) : this(int_2, Class327.smethod_9(string_0), class286_0)
		{
		}

		public Class266(int int_2, int int_3, Class286 class286_0)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(class286_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 6;
		}

		public Class286 method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return (Class286)base.FirstNode;
			}
			return null;
		}

		public void method_8(Class286 class286_0)
		{
			if (base.Nodes.Count != 0)
			{
				base.Nodes[0] = class286_0;
				return;
			}
			base.Nodes.Add(class286_0);
		}

		public override string vmethod_5()
		{
			return "Structure Pointer Root";
		}

		public override byte vmethod_16()
		{
			return 10;
		}
	}
}
