using ns16;
using ns20;
using System;
using System.Drawing;

namespace ns18
{
	public abstract class Class294 : Class259
	{
		public int int_0;

		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()) || (((Class294)target).Nodes.Count != 0 && !((Class294)target).Nodes[0].Equals(base.Nodes[0])))
			{
				return -1;
			}
			if (((Class294)target).int_0 == this.int_0)
			{
				return 0;
			}
			return 1;
		}

		public override string vmethod_3()
		{
			string str = (base.Nodes.Count > 0) ? base.method_2(0).vmethod_3() : "NULL";
			if (QbSongClass1.smethod_3(this.int_0))
			{
				return QbSongClass1.smethod_5(this.int_0) + " = " + str;
			}
			return KeyGenerator.smethod_34(this.int_0) + " (Tag) = " + str;
		}

		public override Color vmethod_6()
		{
			if (base.Parent != null && this.method_7() != null && this.method_7().vmethod_6().Equals(Color.Gold))
			{
				return Color.Yellow;
			}
			return Color.Gold;
		}

		public override object Clone()
		{
			Class294 @class = (Class294)base.Clone();
			@class.int_0 = this.int_0;
			return @class;
		}

		public Class259 method_7()
		{
			return (Class259)base.PrevNode;
		}
	}
}
