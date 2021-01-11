using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GHNamespace7
{
    public class ZzDrawingClass230
    {
        public static class Gdi
        {
            [DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern int SetROP2(IntPtr intptr0, int int0);

            [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr GetDC(IntPtr intptr0);

            [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern IntPtr ReleaseDC(IntPtr intptr0, IntPtr intptr1);

            [DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern bool MoveToEx(IntPtr intptr0, int int0, int int1, IntPtr intptr1);

            [DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern bool LineTo(IntPtr intptr0, int int0, int int1);
        }

        private readonly ListBox _listBox0;

        private int _int0 = -1;

        public ZzDrawingClass230(ListBox listBox1)
        {
            _listBox0 = listBox1;
        }

        public int method_0()
        {
            return _int0;
        }

        public void method_1()
        {
            if (_int0 != -1)
            {
                method_2(_int0);
                _int0 = -1;
            }
        }

        public void method_2(int int1)
        {
            Point point;
            Point point2;
            Point point3;
            Point point4;
            if (_listBox0.Sorted)
            {
                Rectangle r = _listBox0.ClientRectangle;
                r = _listBox0.RectangleToScreen(r);
                point = new Point(r.Left, r.Top);
                point2 = new Point(r.Left, r.Bottom);
                point3 = new Point(r.Left + 1, r.Top);
                point4 = new Point(r.Left + 1, r.Bottom);
            }
            else
            {
                Rectangle r;
                if (_listBox0.Items.Count == 0)
                {
                    r = _listBox0.ClientRectangle;
                }
                else if (int1 < _listBox0.Items.Count)
                {
                    r = _listBox0.GetItemRectangle(int1);
                }
                else
                {
                    r = _listBox0.GetItemRectangle(_listBox0.Items.Count - 1);
                    r.Y += r.Height;
                }
                r.Y--;
                if (r.Y < _listBox0.ClientRectangle.Y)
                {
                    r.Y = _listBox0.ClientRectangle.Y;
                }
                r = _listBox0.RectangleToScreen(r);
                point = new Point(r.Left, r.Top);
                point2 = new Point(r.Right, r.Top);
                point3 = new Point(r.Left, r.Top + 1);
                point4 = new Point(r.Right, r.Top + 1);
            }
            IntPtr dC = Gdi.GetDC(IntPtr.Zero);
            Gdi.SetROP2(dC, 6);
            Gdi.MoveToEx(dC, point.X, point.Y, IntPtr.Zero);
            Gdi.LineTo(dC, point2.X, point2.Y);
            Gdi.MoveToEx(dC, point3.X, point3.Y, IntPtr.Zero);
            Gdi.LineTo(dC, point4.X, point4.Y);
            Gdi.ReleaseDC(IntPtr.Zero, dC);
            _int0 = int1;
        }
    }
}