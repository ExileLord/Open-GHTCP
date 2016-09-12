using ns19;
using ns21;
using System;

namespace ns20
{
	public class Class302 : Class300
	{
		public Class302()
		{
			this.vmethod_0();
		}

		public Class302(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public Class302(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class302(string string_0, Class286 class286_0) : this(QbSongClass1.smethod_9(string_0), class286_0)
		{
		}

		public Class302(int int_1, Class286 class286_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(class286_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 27;
		}

		public Class286 method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return (Class286)base.FirstNode;
			}
			return null;
		}

		public override string vmethod_5()
		{
			return "Structure Pointer";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 21;
			}
			return 138;
		}
	}
}
