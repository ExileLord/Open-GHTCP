using ns18;
using ns21;

namespace ns20
{
	public class FileTagStructureNode : ZzUnkNode295
	{
		public FileTagStructureNode()
		{
			vmethod_0();
		}

		public FileTagStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public FileTagStructureNode(int int1)
		{
			Int0 = int1;
			vmethod_0();
		}

		public FileTagStructureNode(string string0, string string1)
		{
			Int0 = QbSongClass1.AddKeyToDictionary(string0);
			Nodes.Add(new TagValueNode(string1));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 26;
		}

		public string method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((TagValueNode)FirstNode).method_2();
			}
			return null;
		}

		public int method_9()
		{
			if (Nodes.Count != 0)
			{
				return ((TagValueNode)FirstNode).Int0;
			}
			return 0;
		}

		public override string GetNodeText()
		{
			return "File Tag Structure";
		}

		public override byte vmethod_15()
		{
			if (!vmethod_7())
			{
				return 53;
			}
			return 154;
		}
	}
}
