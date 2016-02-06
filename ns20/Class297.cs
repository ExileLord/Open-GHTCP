using ns18;
using System;

namespace ns20
{
	public class Class297 : Class295
	{
		public Class297()
		{
			this.vmethod_0();
		}

		public Class297(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class297(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class297(string string_0, float float_0) : this(Class327.smethod_9(string_0), float_0)
		{
		}

		public Class297(int int_1, float float_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new Class313(float_0));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 24;
		}

		public float method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class313)base.FirstNode).float_0;
			}
			return 0f;
		}

		public override string vmethod_5()
		{
			return "Float Structure";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 5;
			}
			return 130;
		}
	}
}
