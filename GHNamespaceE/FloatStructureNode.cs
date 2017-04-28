using GHNamespaceB;

namespace GHNamespaceE
{
	public class FloatStructureNode : ZzUnkNode295
	{
		public FloatStructureNode()
		{
			vmethod_0();
		}

		public FloatStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public FloatStructureNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public FloatStructureNode(string string0, float float0) : this(QbSongClass1.AddKeyToDictionary(string0), float0)
		{
		}

		public FloatStructureNode(int int1, float float0)
		{
			Int0 = int1;
			Nodes.Add(new FloatValueNode(float0));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 24;
		}

		public float method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((FloatValueNode)FirstNode).Float0;
			}
			return 0f;
		}

		public override string GetNodeText()
		{
			return "Float Structure";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 5;
			}
			return 130;
		}
	}
}
