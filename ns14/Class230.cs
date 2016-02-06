using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns14
{
	public class Class230
	{
		public static class Class231
		{
			[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern int SetROP2(IntPtr intptr_0, int int_0);

			[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern IntPtr GetDC(IntPtr intptr_0);

			[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern IntPtr ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

			[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern bool MoveToEx(IntPtr intptr_0, int int_0, int int_1, IntPtr intptr_1);

			[DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern bool LineTo(IntPtr intptr_0, int int_0, int int_1);
		}

		private ListBox listBox_0;

		private int int_0 = -1;

		public Class230(ListBox listBox_1)
		{
			this.listBox_0 = listBox_1;
		}

		public int method_0()
		{
			return this.int_0;
		}

		public void method_1()
		{
			if (this.int_0 != -1)
			{
				this.method_2(this.int_0);
				this.int_0 = -1;
			}
		}

		public void method_2(int int_1)
		{
			Point point;
			Point point2;
			Point point3;
			Point point4;
			if (this.listBox_0.Sorted)
			{
				Rectangle r = this.listBox_0.ClientRectangle;
				r = this.listBox_0.RectangleToScreen(r);
				point = new Point(r.Left, r.Top);
				point2 = new Point(r.Left, r.Bottom);
				point3 = new Point(r.Left + 1, r.Top);
				point4 = new Point(r.Left + 1, r.Bottom);
			}
			else
			{
				Rectangle r;
				if (this.listBox_0.Items.Count == 0)
				{
					r = this.listBox_0.ClientRectangle;
				}
				else if (int_1 < this.listBox_0.Items.Count)
				{
					r = this.listBox_0.GetItemRectangle(int_1);
				}
				else
				{
					r = this.listBox_0.GetItemRectangle(this.listBox_0.Items.Count - 1);
					r.Y += r.Height;
				}
				r.Y--;
				if (r.Y < this.listBox_0.ClientRectangle.Y)
				{
					r.Y = this.listBox_0.ClientRectangle.Y;
				}
				r = this.listBox_0.RectangleToScreen(r);
				point = new Point(r.Left, r.Top);
				point2 = new Point(r.Right, r.Top);
				point3 = new Point(r.Left, r.Top + 1);
				point4 = new Point(r.Right, r.Top + 1);
			}
			IntPtr dC = Class230.Class231.GetDC(IntPtr.Zero);
			Class230.Class231.SetROP2(dC, 6);
			Class230.Class231.MoveToEx(dC, point.X, point.Y, IntPtr.Zero);
			Class230.Class231.LineTo(dC, point2.X, point2.Y);
			Class230.Class231.MoveToEx(dC, point3.X, point3.Y, IntPtr.Zero);
			Class230.Class231.LineTo(dC, point4.X, point4.Y);
			Class230.Class231.ReleaseDC(IntPtr.Zero, dC);
			this.int_0 = int_1;
		}
	}
}
