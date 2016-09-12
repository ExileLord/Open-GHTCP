using ns16;
using ns20;
using System;
using System.Drawing;

namespace ns18
{
	public abstract class Class260 : Class259
	{
		public int int_0;

		public int int_1;

		public override string vmethod_3()
		{
			string text = (base.Nodes.Count > 0) ? base.method_2(0).vmethod_3() : "NULL";
			if (QbSongClass1.smethod_3(this.int_0))
			{
				return QbSongClass1.smethod_5(this.int_0) + " = " + text;
			}
			return "0x" + KeyGenerator.smethod_34(this.int_0) + " (Tag) = " + text;
		}

		public virtual Color vmethod_15()
		{
			return base.method_0(Color.Beige, Color.Lavender);
		}

		public override Color vmethod_6()
		{
			return this.vmethod_15();
		}

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()) || (((Class260)target).Nodes.Count != 0 && !((Class260)target).Nodes[0].Equals(base.Nodes[0])))
			{
				return -1;
			}
			if (((Class260)target).int_0 == this.int_0)
			{
				return 0;
			}
			return 1;
		}

		public override object Clone()
		{
			Class260 @class = (Class260)base.Clone();
			@class.int_0 = this.int_0;
			@class.int_1 = this.int_1;
			return @class;
		}
	}
}
