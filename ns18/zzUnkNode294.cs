using ns16;
using ns20;
using System;
using System.Drawing;

namespace ns18
{
	public abstract class zzUnkNode294 : AbstractTreeNode1
	{
		public int int_0;

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()) || (((zzUnkNode294)target).Nodes.Count != 0 && !((zzUnkNode294)target).Nodes[0].Equals(base.Nodes[0])))
			{
				return -1;
			}
			if (((zzUnkNode294)target).int_0 == this.int_0)
			{
				return 0;
			}
			return 1;
		}

		public override string GetText()
		{
			string str = (base.Nodes.Count > 0) ? base.method_2(0).GetText() : "NULL";
			if (QbSongClass1.ContainsKey(this.int_0))
			{
				return QbSongClass1.GetDictString(this.int_0) + " = " + str;
			}
			return KeyGenerator.ValToHex32bit(this.int_0) + " (Tag) = " + str;
		}

		public override Color GetColor()
		{
			if (base.Parent != null && this.method_7() != null && this.method_7().GetColor().Equals(Color.Gold))
			{
				return Color.Yellow;
			}
			return Color.Gold;
		}

		public override object Clone()
		{
			zzUnkNode294 @class = (zzUnkNode294)base.Clone();
			@class.int_0 = this.int_0;
			return @class;
		}

		public AbstractTreeNode1 method_7()
		{
			return (AbstractTreeNode1)base.PrevNode;
		}
	}
}
