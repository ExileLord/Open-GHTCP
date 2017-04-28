using ns19;
using ns21;

namespace ns20
{
	public class StructurePointerNode : zzUnkNode300
	{
		public StructurePointerNode()
		{
			vmethod_0();
		}

		public StructurePointerNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public StructurePointerNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public StructurePointerNode(string string_0, StructureHeaderNode class286_0) : this(QbSongClass1.AddKeyToDictionary(string_0), class286_0)
		{
		}

		public StructurePointerNode(int int_1, StructureHeaderNode class286_0)
		{
			int_0 = int_1;
			Nodes.Add(class286_0);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 27;
		}

		public StructureHeaderNode method_8()
		{
			if (Nodes.Count != 0)
			{
				return (StructureHeaderNode)FirstNode;
			}
			return null;
		}

		public override string GetNodeText()
		{
			return "Structure Pointer";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 21;
			}
			return 138;
		}
	}
}
