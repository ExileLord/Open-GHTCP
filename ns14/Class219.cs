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
			return this.int_0;
		}

		public int method_1()
		{
			return this.int_1;
		}

		public bool method_2()
		{
			return this.bool_1;
		}

		public Bitmap method_3()
		{
			return this.bitmap_0;
		}

		public ImageRelatedClass(Bitmap bitmap_1)
		{
			if (bitmap_1.PixelFormat == (bitmap_1.PixelFormat | PixelFormat.Indexed))
			{
				throw new Exception("Cannot lock an Indexed image.");
			}
			this.bitmap_0 = bitmap_1;
			this.bool_1 = (this.method_3().PixelFormat == (this.method_3().PixelFormat | PixelFormat.Alpha));
			this.int_0 = bitmap_1.Width;
			this.int_1 = bitmap_1.Height;
		}

		public void method_4()
		{
			if (this.bool_0)
			{
				return;
			}
			Rectangle rect = new Rectangle(0, 0, this.method_0(), this.method_1());
			this.bitmapData_0 = this.method_3().LockBits(rect, ImageLockMode.ReadWrite, this.method_3().PixelFormat);
			this.intptr_0 = this.bitmapData_0.Scan0;
			this.byte_0 = new byte[this.method_0() * this.method_1() * (this.method_2() ? 4 : 3)];
			Marshal.Copy(this.intptr_0, this.byte_0, 0, this.byte_0.Length);
			this.bool_0 = true;
		}

		public void method_5(bool bool_2)
		{
			if (!this.bool_0)
			{
				return;
			}
			if (this.bitmap_0 == null)
			{
				this.bitmap_0 = new Bitmap(this.method_0(), this.method_1(), this.bool_1 ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
				this.bitmapData_0 = this.method_3().LockBits(new Rectangle(0, 0, this.method_0(), this.method_1()), ImageLockMode.ReadWrite, this.method_3().PixelFormat);
				this.intptr_0 = this.bitmapData_0.Scan0;
			}
			if (bool_2)
			{
				Marshal.Copy(this.byte_0, 0, this.intptr_0, this.byte_0.Length);
			}
			this.method_3().UnlockBits(this.bitmapData_0);
			this.bool_0 = false;
		}

		public void method_6(Point point_0, Color color_0)
		{
			this.method_7(point_0.X, point_0.Y, color_0);
		}

		public void method_7(int int_2, int int_3, Color color_0)
		{
			if (!this.bool_0)
			{
				throw new Exception("Bitmap not locked.");
			}
			if (this.method_2())
			{
				int num = (int_3 * this.method_0() + int_2) * 4;
				this.byte_0[num] = color_0.B;
				this.byte_0[num + 1] = color_0.G;
				this.byte_0[num + 2] = color_0.R;
				this.byte_0[num + 3] = color_0.A;
				return;
			}
			int num2 = (int_3 * this.method_0() + int_2) * 3;
			this.byte_0[num2] = color_0.B;
			this.byte_0[num2 + 1] = color_0.G;
			this.byte_0[num2 + 2] = color_0.R;
		}
	}
}
