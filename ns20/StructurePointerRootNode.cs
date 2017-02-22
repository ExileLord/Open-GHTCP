using ns19;
using ns21;
using System;

namespace ns20
{
	public class StructurePointerRootNode : ProbablyRootNode
	{
		public StructurePointerRootNode()
		{
			this.vmethod_0();
		}

		public StructurePointerRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public StructurePointerRootNode(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public StructurePointerRootNode(int int_2, string string_0, StructureHeaderNode class286_0) : this(int_2, QbSongClass1.AddKeyToDictionary(string_0), class286_0)
		{
		}

		public StructurePointerRootNode(int int_2, int int_3, StructureHeaderNode class286_0)
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

		public StructureHeaderNode method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return (StructureHeaderNode)base.FirstNode;
			}
			return null;
		}

		public void method_8(StructureHeaderNode class286_0)
		{
			if (base.Nodes.Count != 0)
			{
				base.Nodes[0] = class286_0;
				return;
			}
			base.Nodes.Add(class286_0);
		}

		public override string GetNodeText()
		{
			return "Structure Pointer Root";
		}

		public override byte vmethod_16()
		{
			return 10;
		}
	}
}
