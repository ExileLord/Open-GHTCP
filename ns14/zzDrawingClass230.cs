using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ns14
{
	public class zzDrawingClass230
	{
		public static class GDI
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

		public zzDrawingClass230(ListBox listBox_1)
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
			IntPtr dC = zzDrawingClass230.GDI.GetDC(IntPtr.Zero);
			zzDrawingClass230.GDI.SetROP2(dC, 6);
			zzDrawingClass230.GDI.MoveToEx(dC, point.X, point.Y, IntPtr.Zero);
			zzDrawingClass230.GDI.LineTo(dC, point2.X, point2.Y);
			zzDrawingClass230.GDI.MoveToEx(dC, point3.X, point3.Y, IntPtr.Zero);
			zzDrawingClass230.GDI.LineTo(dC, point4.X, point4.Y);
			zzDrawingClass230.GDI.ReleaseDC(IntPtr.Zero, dC);
			this.int_0 = int_1;
		}
	}
}
