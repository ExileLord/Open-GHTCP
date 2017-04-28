using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GHNamespace7
{
    public class ImageRelatedClass
    {
        private byte[] _byte0;

        private BitmapData _bitmapData0;

        private IntPtr _intptr0;

        private bool _bool0;

        private readonly bool _bool1;

        private Bitmap _bitmap0;

        private readonly int _int0;

        private readonly int _int1;

        public int method_0()
        {
            return _int0;
        }

        public int method_1()
        {
            return _int1;
        }

        public bool method_2()
        {
            return _bool1;
        }

        public Bitmap method_3()
        {
            return _bitmap0;
        }

        public ImageRelatedClass(Bitmap bitmap1)
        {
            if (bitmap1.PixelFormat == (bitmap1.PixelFormat | PixelFormat.Indexed))
            {
                throw new Exception("Cannot lock an Indexed image.");
            }
            _bitmap0 = bitmap1;
            _bool1 = (method_3().PixelFormat == (method_3().PixelFormat | PixelFormat.Alpha));
            _int0 = bitmap1.Width;
            _int1 = bitmap1.Height;
        }

        public void method_4()
        {
            if (_bool0)
            {
                return;
            }
            var rect = new Rectangle(0, 0, method_0(), method_1());
            _bitmapData0 = method_3().LockBits(rect, ImageLockMode.ReadWrite, method_3().PixelFormat);
            _intptr0 = _bitmapData0.Scan0;
            _byte0 = new byte[method_0() * method_1() * (method_2() ? 4 : 3)];
            Marshal.Copy(_intptr0, _byte0, 0, _byte0.Length);
            _bool0 = true;
        }

        public void method_5(bool bool2)
        {
            if (!_bool0)
            {
                return;
            }
            if (_bitmap0 == null)
            {
                _bitmap0 = new Bitmap(method_0(), method_1(),
                    _bool1 ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
                _bitmapData0 = method_3()
                    .LockBits(new Rectangle(0, 0, method_0(), method_1()), ImageLockMode.ReadWrite,
                        method_3().PixelFormat);
                _intptr0 = _bitmapData0.Scan0;
            }
            if (bool2)
            {
                Marshal.Copy(_byte0, 0, _intptr0, _byte0.Length);
            }
            method_3().UnlockBits(_bitmapData0);
            _bool0 = false;
        }

        public void method_6(Point point0, Color color0)
        {
            method_7(point0.X, point0.Y, color0);
        }

        public void method_7(int int2, int int3, Color color0)
        {
            if (!_bool0)
            {
                throw new Exception("Bitmap not locked.");
            }
            if (method_2())
            {
                var num = (int3 * method_0() + int2) * 4;
                _byte0[num] = color0.B;
                _byte0[num + 1] = color0.G;
                _byte0[num + 2] = color0.R;
                _byte0[num + 3] = color0.A;
                return;
            }
            var num2 = (int3 * method_0() + int2) * 3;
            _byte0[num2] = color0.B;
            _byte0[num2 + 1] = color0.G;
            _byte0[num2 + 2] = color0.R;
        }
    }
}