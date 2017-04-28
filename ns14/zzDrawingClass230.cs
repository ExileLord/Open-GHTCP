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
			listBox_0 = listBox_1;
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1()
		{
			if (int_0 != -1)
			{
				method_2(int_0);
				int_0 = -1;
			}
		}

		public void method_2(int int_1)
		{
			Point point;
			Point point2;
			Point point3;
			Point point4;
			if (listBox_0.Sorted)
			{
				Rectangle r = listBox_0.ClientRectangle;
				r = listBox_0.RectangleToScreen(r);
				point = new Point(r.Left, r.Top);
				point2 = new Point(r.Left, r.Bottom);
				point3 = new Point(r.Left + 1, r.Top);
				point4 = new Point(r.Left + 1, r.Bottom);
			}
			else
			{
				Rectangle r;
				if (listBox_0.Items.Count == 0)
				{
					r = listBox_0.ClientRectangle;
				}
				else if (int_1 < listBox_0.Items.Count)
				{
					r = listBox_0.GetItemRectangle(int_1);
				}
				else
				{
					r = listBox_0.GetItemRectangle(listBox_0.Items.Count - 1);
					r.Y += r.Height;
				}
				r.Y--;
				if (r.Y < listBox_0.ClientRectangle.Y)
				{
					r.Y = listBox_0.ClientRectangle.Y;
				}
				r = listBox_0.RectangleToScreen(r);
				point = new Point(r.Left, r.Top);
				point2 = new Point(r.Right, r.Top);
				point3 = new Point(r.Left, r.Top + 1);
				point4 = new Point(r.Right, r.Top + 1);
			}
			IntPtr dC = GDI.GetDC(IntPtr.Zero);
			GDI.SetROP2(dC, 6);
			GDI.MoveToEx(dC, point.X, point.Y, IntPtr.Zero);
			GDI.LineTo(dC, point2.X, point2.Y);
			GDI.MoveToEx(dC, point3.X, point3.Y, IntPtr.Zero);
			GDI.LineTo(dC, point4.X, point4.Y);
			GDI.ReleaseDC(IntPtr.Zero, dC);
			int_0 = int_1;
		}
	}
}
