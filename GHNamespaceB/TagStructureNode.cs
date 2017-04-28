using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceB
{
	public class TagStructureNode : ZzUnkNode295
	{
		public TagStructureNode()
		{
			vmethod_0();
		}

		public TagStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public TagStructureNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public TagStructureNode(int int1, string string0)
		{
			Int0 = int1;
			Nodes.Add(new TagValueNode(string0));
			vmethod_0();
		}

		public TagStructureNode(string string0, string string1)
		{
			Int0 = QbSongClass1.AddKeyToDictionary(string0);
			Nodes.Add(new TagValueNode(string1));
			vmethod_0();
		}

		public TagStructureNode(string string0, int int1)
		{
			Int0 = QbSongClass1.AddKeyToDictionary(string0);
			Nodes.Add(new TagValueNode(int1));
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

		public void method_9(string string0)
		{
			if (Nodes.Count != 0)
			{
				((TagValueNode)FirstNode).method_3(string0);
				return;
			}
			Nodes.Add(new TagValueNode(string0));
		}

		public int method_10()
		{
			if (Nodes.Count != 0)
			{
				return ((TagValueNode)FirstNode).Int0;
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
