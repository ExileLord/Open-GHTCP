using ns20;
using ns21;
using System;

namespace ns18
{
	public class TagStructureNode : zzUnkNode295
	{
		public TagStructureNode()
		{
			this.vmethod_0();
		}

		public TagStructureNode(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public TagStructureNode(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public TagStructureNode(int int_1, string string_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new TagValueNode(string_0));
			this.vmethod_0();
		}

		public TagStructureNode(string string_0, string string_1)
		{
			this.int_0 = QbSongClass1.smethod_9(string_0);
			base.Nodes.Add(new TagValueNode(string_1));
			this.vmethod_0();
		}

		public TagStructureNode(string string_0, int int_1)
		{
			this.int_0 = QbSongClass1.smethod_9(string_0);
			base.Nodes.Add(new TagValueNode(int_1));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 25;
		}

		public string method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((TagValueNode)base.FirstNode).method_2();
			}
			return null;
		}

		public void method_9(string string_0)
		{
			if (base.Nodes.Count != 0)
			{
				((TagValueNode)base.FirstNode).method_3(string_0);
				return;
			}
			base.Nodes.Add(new TagValueNode(string_0));
		}

		public int method_10()
		{
			if (base.Nodes.Count != 0)
			{
				return ((TagValueNode)base.FirstNode).int_0;
			}
			return 0;
		}

		public override string GetNodeText()
		{
			return "Tag Structure";
		}

		public override byte vmethod_15()
		{
			if (!this.vmethod_7())
			{
				return 27;
			}
			return 141;
		}
	}
}
