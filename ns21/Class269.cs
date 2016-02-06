using ns20;
using System;

namespace ns21
{
	public class Class269 : Class268
	{
		public Class269()
		{
			this.vmethod_0();
		}

		public Class269(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class269(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public Class269(string string_0, string string_1, int int_2) : this(Class327.smethod_9(string_0), Class327.smethod_9(string_1), int_2)
		{
		}

		public Class269(int int_2, int int_3, int int_4)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(new Class314(int_4));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 2;
		}

		public int method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class314)base.FirstNode).int_0;
			}
			return 0;
		}

		public void method_8(int int_2)
		{
			if (base.Nodes.Count != 0)
			{
				((Class314)base.FirstNode).int_0 = int_2;
				return;
			}
			base.Nodes.Add(new Class314(int_2));
		}

		public override string vmethod_5()
		{
			return "Integer Root";
		}

		public override byte vmethod_16()
		{
			return 1;
		}
	}
}
