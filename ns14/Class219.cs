using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns14
{
	public class ImageRelatedClass
	{
		private byte[] byte_0;

		private BitmapData bitmapData_0;

		private IntPtr intptr_0;

		private bool bool_0;

		private readonly bool bool_1;

		private Bitmap bitmap_0;

		private readonly int int_0;

		private readonly int int_1;

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public bool method_2()
		{
			return bool_1;
		}

		public Bitmap method_3()
		{
			return bitmap_0;
		}

		public ImageRelatedClass(Bitmap bitmap_1)
		{
			if (bitmap_1.PixelFormat == (bitmap_1.PixelFormat | PixelFormat.Indexed))
			{
				throw new Exception("Cannot lock an Indexed image.");
			}
			bitmap_0 = bitmap_1;
			bool_1 = (method_3().PixelFormat == (method_3().PixelFormat | PixelFormat.Alpha));
			int_0 = bitmap_1.Width;
			int_1 = bitmap_1.Height;
		}

		public void method_4()
		{
			if (bool_0)
			{
				return;
			}
			Rectangle rect = new Rectangle(0, 0, method_0(), method_1());
			bitmapData_0 = method_3().LockBits(rect, ImageLockMode.ReadWrite, method_3().PixelFormat);
			intptr_0 = bitmapData_0.Scan0;
			byte_0 = new byte[method_0() * method_1() * (method_2() ? 4 : 3)];
			Marshal.Copy(intptr_0, byte_0, 0, byte_0.Length);
			bool_0 = true;
		}

		public void method_5(bool bool_2)
		{
			if (!bool_0)
			{
				return;
			}
			if (bitmap_0 == null)
			{
				bitmap_0 = new Bitmap(method_0(), method_1(), bool_1 ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
				bitmapData_0 = method_3().LockBits(new Rectangle(0, 0, method_0(), method_1()), ImageLockMode.ReadWrite, method_3().PixelFormat);
				intptr_0 = bitmapData_0.Scan0;
			}
			if (bool_2)
			{
				Marshal.Copy(byte_0, 0, intptr_0, byte_0.Length);
			}
			method_3().UnlockBits(bitmapData_0);
			bool_0 = false;
		}

		public void method_6(Point point_0, Color color_0)
		{
			method_7(point_0.X, point_0.Y, color_0);
		}

		public void method_7(int int_2, int int_3, Color color_0)
		{
			if (!bool_0)
			{
				throw new Exception("Bitmap not locked.");
			}
			if (method_2())
			{
				int num = (int_3 * method_0() + int_2) * 4;
				byte_0[num] = color_0.B;
				byte_0[num + 1] = color_0.G;
				byte_0[num + 2] = color_0.R;
				byte_0[num + 3] = color_0.A;
				return;
			}
			int num2 = (int_3 * method_0() + int_2) * 3;
			byte_0[num2] = color_0.B;
			byte_0[num2 + 1] = color_0.G;
			byte_0[num2 + 2] = color_0.R;
		}
	}
}
