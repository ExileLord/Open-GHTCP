using ns18;
using ns21;
using System;
using System.Collections.Generic;

namespace ns20
{
	public class TagArray : zzUnkNode278<TagValueNode>
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

		public TagArray()
		{
			this.vmethod_0();
		}

		public TagArray(IEnumerable<int> ienumerable_0)
		{
			this.method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 14;
		}

		public void method_11(IEnumerable<int> ienumerable_0)
		{
			foreach (int current in ienumerable_0)
			{
				base.Nodes.Add(new TagValueNode(current));
			}
			this.vmethod_0();
		}

		public void method_12(IEnumerable<int> ienumerable_0)
		{
			base.Nodes.Clear();
			this.method_11(ienumerable_0);
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
