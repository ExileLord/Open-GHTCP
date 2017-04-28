using ns20;
using ns21;

namespace ns18
{
	public class TagStructureNode : zzUnkNode295
	{
		public TagStructureNode()
		{
			vmethod_0();
		}

		public TagStructureNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public TagStructureNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public TagStructureNode(int int_1, string string_0)
		{
			int_0 = int_1;
			Nodes.Add(new TagValueNode(string_0));
			vmethod_0();
		}

		public TagStructureNode(string string_0, string string_1)
		{
			int_0 = QbSongClass1.AddKeyToDictionary(string_0);
			Nodes.Add(new TagValueNode(string_1));
			vmethod_0();
		}

		public TagStructureNode(string string_0, int int_1)
		{
			int_0 = QbSongClass1.AddKeyToDictionary(string_0);
			Nodes.Add(new TagValueNode(int_1));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 25;
		}

		public string method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((TagValueNode)FirstNode).method_2();
			}
			return null;
		}

		public void method_9(string string_0)
		{
			if (Nodes.Count != 0)
			{
				((TagValueNode)FirstNode).method_3(string_0);
				return;
			}
			Nodes.Add(new TagValueNode(string_0));
		}

		public int method_10()
		{
			if (Nodes.Count != 0)
			{
				return ((TagValueNode)FirstNode).int_0;
			}
			return 0;
		}

		public override string GetNodeText()
		{
			return "Tag Structure";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 27;
			}
			return 141;
		}
	}
}
