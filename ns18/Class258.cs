using System;
using System.Drawing;
using System.Windows.Forms;

namespace ns18
{
	public abstract class Class258 : TreeNode
	{
		public static bool bool_0 = true;

		public virtual void vmethod_0()
		{
			if (!Class258.bool_0)
			{
				return;
			}
			base.Text = this.vmethod_3();
			base.ToolTipText = this.vmethod_4();
			base.BackColor = this.vmethod_6();
			base.SelectedImageIndex = (base.ImageIndex = this.vmethod_1());
		}

		public abstract int vmethod_1();

		public abstract void vmethod_2(ref int int_0);

		public virtual string vmethod_3()
		{
			return this.vmethod_5();
		}

		public virtual string vmethod_4()
		{
			return this.vmethod_5();
		}

		public abstract string vmethod_5();

		public Color method_0(Color color_0, Color color_1)
		{
			if (base.Parent != null && base.PrevNode != null && base.PrevNode.BackColor.Equals(color_0))
			{
				return color_1;
			}
			return color_0;
		}

		public virtual Color vmethod_6()
		{
			return Color.Aqua;
		}
	}
}
