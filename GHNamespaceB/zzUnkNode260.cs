using System.Drawing;
using GHNamespace9;
using GHNamespaceE;

namespace GHNamespaceB
{
	public abstract class ZzUnkNode260 : AbstractTreeNode1
	{
		public int Int0;

		public int Int1;

		public override string GetText()
		{
			var text = (Nodes.Count > 0) ? method_2(0).GetText() : "NULL";
			if (QbSongClass1.ContainsKey(Int0))
			{
				return QbSongClass1.GetDictString(Int0) + " = " + text;
			}
			return "0x" + KeyGenerator.ValToHex32Bit(Int0) + " (Tag) = " + text;
		}

		public virtual Color vmethod_15()
		{
			return GetColor2IfPrevNodeIsColor1(Color.Beige, Color.Lavender);
		}

		public override Color GetColor()
		{
			return vmethod_15();
		}

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(GetType()) || (((ZzUnkNode260)target).Nodes.Count != 0 && !((ZzUnkNode260)target).Nodes[0].Equals(Nodes[0])))
			{
				return -1;
			}
			if (((ZzUnkNode260)target).Int0 == Int0)
			{
				return 0;
			}
			return 1;
		}

		public override object Clone()
		{
			var @class = (ZzUnkNode260)base.Clone();
			@class.Int0 = Int0;
			@class.Int1 = Int1;
			return @class;
		}
	}
}
