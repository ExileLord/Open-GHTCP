using ns18;
using ns19;
using System;

namespace ns20
{
	public class Class267 : Class263
	{
		public Class267()
		{
			this.vmethod_0();
		}

		public Class267(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class267(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public Class267(string string_0, string string_1, Class276 class276_0) : this(Class327.smethod_9(string_0), Class327.smethod_9(string_1), class276_0)
		{
		}

		public Class267(string string_0, int int_2, Class276 class276_0) : this(Class327.smethod_9(string_0), int_2, class276_0)
		{
		}

		public Class267(int int_2, int int_3, Class276 class276_0)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(class276_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 7;
		}

		public Class276 method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return (Class276)base.FirstNode;
			}
			return null;
		}

		public void method_8(Class276 class276_0)
		{
			if (base.Nodes.Count != 0)
			{
				base.Nodes[0] = class276_0;
				return;
			}
			base.Nodes.Add(class276_0);
		}

		public override string vmethod_5()
		{
			return "Array Pointer Root";
		}

		public override byte vmethod_16()
		{
			return 12;
		}
	}
}
