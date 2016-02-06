using ns18;
using ns21;
using System;

namespace ns20
{
	public class Class298 : Class295
	{
		public Class298()
		{
			this.vmethod_0();
		}

		public Class298(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class298(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class298(string string_0, string string_1)
		{
			this.int_0 = Class327.smethod_9(string_0);
			base.Nodes.Add(new Class316(string_1));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 26;
		}

		public string method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class316)base.FirstNode).method_2();
			}
			return null;
		}

		public int method_9()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class316)base.FirstNode).int_0;
			}
			return 0;
		}

		public override string vmethod_5()
		{
			return "File Tag Structure";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 53;
			}
			return 154;
		}
	}
}
