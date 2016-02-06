using ns20;
using ns21;
using System;

namespace ns18
{
	public class Class296 : Class295
	{
		public Class296()
		{
			this.vmethod_0();
		}

		public Class296(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class296(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class296(int int_1, string string_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new Class316(string_0));
			this.vmethod_0();
		}

		public Class296(string string_0, string string_1)
		{
			this.int_0 = Class327.smethod_9(string_0);
			base.Nodes.Add(new Class316(string_1));
			this.vmethod_0();
		}

		public Class296(string string_0, int int_1)
		{
			this.int_0 = Class327.smethod_9(string_0);
			base.Nodes.Add(new Class316(int_1));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 25;
		}

		public string method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class316)base.FirstNode).method_2();
			}
			return null;
		}

		public void method_9(string string_0)
		{
			if (base.Nodes.Count != 0)
			{
				((Class316)base.FirstNode).method_3(string_0);
				return;
			}
			base.Nodes.Add(new Class316(string_0));
		}

		public int method_10()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class316)base.FirstNode).int_0;
			}
			return 0;
		}

		public override string vmethod_5()
		{
			return "Tag Structure";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 27;
			}
			return 141;
		}
	}
}
