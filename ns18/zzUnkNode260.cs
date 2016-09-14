using ns16;
using ns20;
using System;
using System.Drawing;

namespace ns18
{
	public abstract class zzUnkNode260 : AbstractTreeNode1
	{
		public int int_0;

		public int int_1;

		public override string GetText()
		{
			string text = (base.Nodes.Count > 0) ? base.method_2(0).GetText() : "NULL";
			if (QbSongClass1.smethod_3(this.int_0))
			{
				return QbSongClass1.smethod_5(this.int_0) + " = " + text;
			}
			return "0x" + KeyGenerator.ValToHex32bit(this.int_0) + " (Tag) = " + text;
		}

		public virtual Color vmethod_15()
		{
			return base.GetColor2IfPrevNodeIsColor1(Color.Beige, Color.Lavender);
		}

		public override Color GetColor()
		{
			return this.vmethod_15();
		}

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()) || (((zzUnkNode260)target).Nodes.Count != 0 && !((zzUnkNode260)target).Nodes[0].Equals(base.Nodes[0])))
			{
				return -1;
			}
			if (((zzUnkNode260)target).int_0 == this.int_0)
			{
				return 0;
			}
			return 1;
		}

		public override object Clone()
		{
			zzUnkNode260 @class = (zzUnkNode260)base.Clone();
			@class.int_0 = this.int_0;
			@class.int_1 = this.int_1;
			return @class;
		}
	}
}
