using System.Drawing;
using ns16;
using ns20;

namespace ns18
{
	public abstract class zzUnkNode294 : AbstractTreeNode1
	{
		public int int_0;

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(GetType()) || (((zzUnkNode294)target).Nodes.Count != 0 && !((zzUnkNode294)target).Nodes[0].Equals(Nodes[0])))
			{
				return -1;
			}
			if (((zzUnkNode294)target).int_0 == int_0)
			{
				return 0;
			}
			return 1;
		}

		public override string GetText()
		{
			var str = (Nodes.Count > 0) ? method_2(0).GetText() : "NULL";
			if (QbSongClass1.ContainsKey(int_0))
			{
				return QbSongClass1.GetDictString(int_0) + " = " + str;
			}
			return KeyGenerator.ValToHex32bit(int_0) + " (Tag) = " + str;
		}

		public override Color GetColor()
		{
			if (Parent != null && method_7() != null && method_7().GetColor().Equals(Color.Gold))
			{
				return Color.Yellow;
			}
			return Color.Gold;
		}

		public override object Clone()
		{
			var @class = (zzUnkNode294)base.Clone();
			@class.int_0 = int_0;
			return @class;
		}

		public AbstractTreeNode1 method_7()
		{
			return (AbstractTreeNode1)PrevNode;
		}
	}
}
