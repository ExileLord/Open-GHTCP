using System.Collections.Generic;
using ns18;
using ns21;

namespace ns20
{
	public class TagArray : zzUnkNode278<TagValueNode>
	{
		public int this[int int_0]
		{
			get
			{
				return ((TagValueNode)Nodes[int_0]).int_0;
			}
			set
			{
				((TagValueNode)Nodes[int_0]).int_0 = value;
			}
		}

		public TagArray()
		{
			vmethod_0();
		}

		public TagArray(IEnumerable<int> ienumerable_0)
		{
			method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 14;
		}

		public void method_11(IEnumerable<int> ienumerable_0)
		{
			foreach (var current in ienumerable_0)
			{
				Nodes.Add(new TagValueNode(current));
			}
			vmethod_0();
		}

		public void method_12(IEnumerable<int> ienumerable_0)
		{
			Nodes.Clear();
			method_11(ienumerable_0);
		}

		public override byte vmethod_15()
		{
			return 13;
		}

		public override string GetNodeText()
		{
			return "Tag Array";
		}
	}
}
