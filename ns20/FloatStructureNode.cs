using ns18;

namespace ns20
{
	public class FloatStructureNode : zzUnkNode295
	{
		public FloatStructureNode()
		{
			vmethod_0();
		}

		public FloatStructureNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public FloatStructureNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public FloatStructureNode(string string_0, float float_0) : this(QbSongClass1.AddKeyToDictionary(string_0), float_0)
		{
		}

		public FloatStructureNode(int int_1, float float_0)
		{
			int_0 = int_1;
			Nodes.Add(new FloatValueNode(float_0));
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
				return ((FloatValueNode)FirstNode).float_0;
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
