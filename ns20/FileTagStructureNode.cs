using ns18;
using ns21;

namespace ns20
{
	public class FileTagStructureNode : zzUnkNode295
	{
		public FileTagStructureNode()
		{
			vmethod_0();
		}

		public FileTagStructureNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public FileTagStructureNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public FileTagStructureNode(string string_0, string string_1)
		{
			int_0 = QbSongClass1.AddKeyToDictionary(string_0);
			Nodes.Add(new TagValueNode(string_1));
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
				return ((TagValueNode)FirstNode).int_0;
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
