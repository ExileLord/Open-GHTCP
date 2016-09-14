using ns18;
using ns20;
using System;

namespace ns19
{
	public class ArrayPointerNode : zzUnkNode300
	{
		public ArrayPointerNode()
		{
			this.vmethod_0();
		}

		public ArrayPointerNode(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public ArrayPointerNode(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public ArrayPointerNode(string string_0, AbsTreeNode1_1 class276_0) : this(QbSongClass1.smethod_9(string_0), class276_0)
		{
		}

		public ArrayPointerNode(int int_1, AbsTreeNode1_1 class276_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(class276_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 28;
		}

		public AbsTreeNode1_1 method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return (AbsTreeNode1_1)base.FirstNode;
			}
			return null;
		}

		public override string GetNodeText()
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
