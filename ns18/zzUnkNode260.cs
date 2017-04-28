using System.Drawing;
using ns16;
using ns20;

namespace ns18
{
	public abstract class zzUnkNode260 : AbstractTreeNode1
	{
		public int int_0;

		public int int_1;

		public override string GetText()
		{
			string text = (Nodes.Count > 0) ? method_2(0).GetText() : "NULL";
			if (QbSongClass1.ContainsKey(int_0))
			{
				return QbSongClass1.GetDictString(int_0) + " = " + text;
			}
			return "0x" + KeyGenerator.ValToHex32bit(int_0) + " (Tag) = " + text;
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
			if (!target.GetType().Equals(GetType()) || (((zzUnkNode260)target).Nodes.Count != 0 && !((zzUnkNode260)target).Nodes[0].Equals(Nodes[0])))
			{
				return -1;
			}
			if (((zzUnkNode260)target).int_0 == int_0)
			{
				return 0;
			}
			return 1;
		}

		public override object Clone()
		{
			zzUnkNode260 @class = (zzUnkNode260)base.Clone();
			@class.int_0 = int_0;
			@class.int_1 = int_1;
			return @class;
		}
	}
}
