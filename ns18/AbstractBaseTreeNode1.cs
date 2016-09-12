using System;
using System.Drawing;
using System.Windows.Forms;

namespace ns18
{
	public abstract class AbstractBaseTreeNode1 : TreeNode
	{
		public static bool bool_0 = true;

		public virtual void vmethod_0()
		{
			if (!AbstractBaseTreeNode1.bool_0)
			{
				return;
			}
			base.Text = this.GetText();
			base.ToolTipText = this.GetToolTipText();
			base.BackColor = this.GetColor();
			base.SelectedImageIndex = (base.ImageIndex = this.vmethod_1());
		}

		public abstract int vmethod_1();

		public abstract void vmethod_2(ref int int_0);

		public virtual string GetText() 
		{
			return this.GetNodeText();
		}

		public virtual string GetToolTipText() 
        {
			return this.GetNodeText();
		}

		public abstract string GetNodeText();

		public Color GetColor2IfPrevNodeIsColor1(Color color1, Color color2)
		{
			if (base.Parent != null && base.PrevNode != null && base.PrevNode.BackColor.Equals(color1))
			{
				return color2;
			}
			return color1;
		}

		public virtual Color GetColor()
		{
			return Color.Aqua;
		}
	}
}
