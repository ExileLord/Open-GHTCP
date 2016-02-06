using ns18;
using ns20;
using System;

namespace ns19
{
	public class Class301 : Class300
	{
		public Class301()
		{
			this.vmethod_0();
		}

		public Class301(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class301(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class301(string string_0, Class276 class276_0) : this(Class327.smethod_9(string_0), class276_0)
		{
		}

		public Class301(int int_1, Class276 class276_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(class276_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 28;
		}

		public Class276 method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return (Class276)base.FirstNode;
			}
			return null;
		}

		public override string vmethod_5()
		{
			return "Array Pointer";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 25;
			}
			return 140;
		}
	}
}
