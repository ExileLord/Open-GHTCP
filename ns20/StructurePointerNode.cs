using ns19;
using ns21;
using System;

namespace ns20
{
	public class StructurePointerNode : zzUnkNode300
	{
		public StructurePointerNode()
		{
			this.vmethod_0();
		}

		public StructurePointerNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public StructurePointerNode(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public StructurePointerNode(string string_0, StructureHeaderNode class286_0) : this(QbSongClass1.AddKeyToDictionary(string_0), class286_0)
		{
		}

		public StructurePointerNode(int int_1, StructureHeaderNode class286_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(class286_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 27;
		}

		public StructureHeaderNode method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return (StructureHeaderNode)base.FirstNode;
			}
			return null;
		}

		public override string GetNodeText()
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
