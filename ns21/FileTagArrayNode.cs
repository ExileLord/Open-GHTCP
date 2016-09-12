using ns18;
using System;

namespace ns21
{
	public class FileTagArrayNode : Class278<TagValueNode>
	{
		public int this[int int_0]
		{
			get
			{
				return ((TagValueNode)base.Nodes[int_0]).int_0;
			}
			set
			{
				((TagValueNode)base.Nodes[int_0]).int_0 = value;
			}
		}

		public FileTagArrayNode()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 14;
		}

		public override byte vmethod_15()
		{
			return 26;
		}

		public override string GetNodeText()
		{
			return "File Tag Array";
		}
	}
}
