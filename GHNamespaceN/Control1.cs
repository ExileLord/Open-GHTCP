using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace GHNamespaceN
{
    public class Control1 : Control
    {
        public enum Enum40
        {
            Const0,
            Const1,
            Const2,
            Const3
        }

        private EventHandler _eventHandler0;

        private readonly ScrollEventHandler _scrollEventHandler0;

        private bool _bool0;

        private readonly Orientation _orientation0;

        private readonly bool _bool1;

        private readonly bool _bool2;

        private readonly ToolTip _toolTip0 = new ToolTip();

        private string _string0 = "{0}";

        private bool _bool3;

        private readonly bool _bool4 = true;

        private int _int0 = 10;

        private RectangleF _rectangleF0;

        private RectangleF _rectangleF1;

        private RectangleF _rectangleF2;

        private RectangleF _rectangleF3;

        private RectangleF _rectangleF4;

        private int _int1 = 15;

        private readonly GraphicsPath _graphicsPath0;

        private SizeF _sizeF0 = new SizeF(50f, 50f);

        private readonly bool _bool5 = true;

        private readonly Image _image0;

        private Color _color0 = Color.White;

        private Color _color1 = Color.Gainsboro;

        private Color _color2 = Color.Silver;

        private float _float0 = 100f;

        private float _float1 = 33f;

        private Color _color3 = Color.SkyBlue;

        private Color _color4 = Color.DarkSlateBlue;

        private Color _color5 = Color.Gainsboro;

        private Color _color6 = Color.DarkGreen;

        private Color _color7 = Color.Chartreuse;

        private int _int2 = 50;

        private int _int3;

        private int _int4 = 100;

        private uint _uint0 = 1u;

        private uint _uint1 = 5u;

        private readonly Color[,] _color8;

        private Enum40 _enum400;

        private float _float2;

        private bool _bool6;

        private bool _bool7;

        private int _int5;

        private int _int6;

        private int _int7;

        private static readonly Class361 Class3610 = new Class361();

        private IContainer icontainer_0;

        public void method_0(EventHandler eventHandler1)
        {
            EventHandler eventHandler = _eventHandler0;
            EventHandler eventHandler2;
            do
            {
                eventHandler2 = eventHandler;
                EventHandler value = (EventHandler) Delegate.Combine(eventHandler2, eventHandler1);
                eventHandler = Interlocked.CompareExchange(ref _eventHandler0, value, eventHandler2);
            } while (eventHandler != eventHandler2);
        }

        public void method_1(string string1)
        {
            _string0 = string1;
            Invalidate();
        }

        public void method_2(bool bool8)
        {
            _bool3 = bool8;
            Invalidate();
        }

        public string method_3()
        {
            if (!_bool3)
            {
                return string.Format(_string0, method_13());
            }
            return smethod_4(TimeSpan.FromSeconds(method_13()), _string0);
        }

        public void method_4(int int8)
        {
            if (int8 <= 0)
            {
                throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greater than zero");
            }
            _int0 = int8;
        }

        public void method_5(int int8)
        {
            if (!(int8 > 0 & int8 < ((_orientation0 == Orientation.Horizontal)
                      ? ClientRectangle.Width
                      : ClientRectangle.Height)))
            {
                throw new ArgumentOutOfRangeException(
                    "TrackSize has to be greater than zero and lower than half of Slider width");
            }
            _int1 = int8;
            Invalidate();
        }

        public void method_6(SizeF sizeF1)
        {
            _sizeF0.Width = ((sizeF1.Width < 1f) ? 1f : ((sizeF1.Width > 100f) ? 100f : sizeF1.Width));
            _sizeF0.Height = ((sizeF1.Height < 1f) ? 1f : ((sizeF1.Height > 100f) ? 100f : sizeF1.Height));
            Invalidate();
        }

        public void method_7(float float3)
        {
            _float0 = ((float3 < 1f) ? 1f : ((float3 > 100f) ? 100f : float3));
            Invalidate();
        }

        public void method_8(float float3)
        {
            _float1 = ((float3 < 0f) ? 0f : ((float3 > 100f) ? 100f : float3));
            Invalidate();
        }

        public void method_9(Color color9)
        {
            _color3 = color9;
            Invalidate();
        }

        public void method_10(Color color9)
        {
            _color4 = color9;
            Invalidate();
        }

        public void method_11(Color color9)
        {
            _color6 = color9;
            Invalidate();
        }

        public void method_12(Color color9)
        {
            _color7 = color9;
            Invalidate();
        }

        public int method_13()
        {
            if (!_bool0)
            {
                return _int2;
            }
            return method_17() - _int2 + method_15();
        }

        public void method_14(int int8)
        {
            if (int8 < _int3)
            {
                _int2 = _int3;
            }
            else if (int8 > _int4)
            {
                _int2 = _int4;
            }
            else
            {
                _int2 = (_bool0 ? (method_17() - int8 + method_15()) : int8);
            }
            _eventHandler0?.Invoke(this, new EventArgs());
            Invalidate();
        }

        public int method_15()
        {
            return _int3;
        }

        public void method_16(int int8)
        {
            if (int8 >= _int4)
            {
                throw new ArgumentOutOfRangeException("Minimal value is greater than maximal one");
            }
            _int3 = int8;
            if (_int2 < _int3)
            {
                _int2 = _int3;
                _eventHandler0?.Invoke(this, new EventArgs());
            }
            Invalidate();
        }

        public int method_17()
        {
            return _int4;
        }

        public void method_18(int int8)
        {
            if (int8 <= _int3)
            {
                _int4 = _int3;
            }
            _int4 = int8;
            if (_int2 > _int4)
            {
                _int2 = _int4;
                _eventHandler0?.Invoke(this, new EventArgs());
            }
            Invalidate();
        }

        public void method_19(uint uint2)
        {
            _uint0 = uint2;
        }

        public void method_20(uint uint2)
        {
            _uint1 = uint2;
        }

        public void method_21(Enum40 enum401)
        {
            _enum400 = enum401;
            byte b = (byte) enum401;
            _color0 = _color8[b, 0];
            _color1 = _color8[b, 1];
            _color2 = _color8[b, 2];
            _color3 = _color8[b, 3];
            _color4 = _color8[b, 4];
            _color5 = _color8[b, 5];
            _color6 = _color8[b, 6];
            _color7 = _color8[b, 7];
            Invalidate();
        }

        public Control1(int int8, int int9, int int10)
        {
            Color[,] array = new Color[4, 8];
            array[0, 0] = Color.White;
            array[0, 1] = Color.Gainsboro;
            array[0, 2] = Color.Silver;
            array[0, 3] = Color.SkyBlue;
            array[0, 4] = Color.DarkSlateBlue;
            array[0, 5] = Color.Gainsboro;
            array[0, 6] = Color.DarkGreen;
            array[0, 7] = Color.Chartreuse;
            array[1, 0] = Color.White;
            array[1, 1] = Color.Gainsboro;
            array[1, 2] = Color.Silver;
            array[1, 3] = Color.Red;
            array[1, 4] = Color.DarkRed;
            array[1, 5] = Color.Gainsboro;
            array[1, 6] = Color.Coral;
            array[1, 7] = Color.LightCoral;
            array[2, 0] = Color.White;
            array[2, 1] = Color.Gainsboro;
            array[2, 2] = Color.Silver;
            array[2, 3] = Color.GreenYellow;
            array[2, 4] = Color.Yellow;
            array[2, 5] = Color.Gold;
            array[2, 6] = Color.Orange;
            array[2, 7] = Color.OrangeRed;
            array[3, 0] = Color.White;
            array[3, 1] = Color.Gainsboro;
            array[3, 2] = Color.Silver;
            array[3, 3] = Color.Red;
            array[3, 4] = Color.Crimson;
            array[3, 5] = Color.Gainsboro;
            array[3, 6] = Color.DarkViolet;
            array[3, 7] = Color.Violet;
            _color8 = array;

            method_24();
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable |
                ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            method_16(int8);
            method_18(int9);
            method_14(int10);
        }

        public Control1() : this(0, 100, 50)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Enabled)
            {
                Color[] array = smethod_1(new[]
                {
                    _color0,
                    _color1,
                    _color2,
                    _bool0 ? _color6 : _color3,
                    _bool0 ? _color7 : _color4,
                    _color5,
                    _bool0 ? _color3 : _color6,
                    _bool0 ? _color4 : _color7
                });
                method_22(e, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
                return;
            }
            if (_bool4 && _bool6)
            {
                Color[] array2 = smethod_2(new[]
                {
                    _color0,
                    _color1,
                    _color2,
                    _bool0 ? _color6 : _color3,
                    _bool0 ? _color7 : _color4,
                    _color5,
                    _bool0 ? _color3 : _color6,
                    _bool0 ? _color4 : _color7
                });
                method_22(e, array2[0], array2[1], array2[2], array2[3], array2[4], array2[5], array2[6], array2[7]);
                return;
            }
            method_22(e, _color0, _color1, _color2, _bool0 ? _color6 : _color3, _bool0 ? _color7 : _color4, _color5,
                _bool0 ? _color3 : _color6, _bool0 ? _color4 : _color7);
        }

        private void method_22(PaintEventArgs paintEventArgs0, Color color9, Color color10, Color color11,
            Color color12, Color color13, Color color14, Color color15, Color color16)
        {
            try
            {
                if (_orientation0 == Orientation.Horizontal)
                {
                    float x = (_int2 - _int3) * (ClientRectangle.Width - _int1) / (float) (_int4 - _int3);
                    _rectangleF0 = new RectangleF(x, 1f, _int1 - 1, ClientRectangle.Height - 2);
                }
                else
                {
                    float y = (_int2 - _int3) * (ClientRectangle.Height - _int1) / (float) (_int4 - _int3);
                    _rectangleF0 = new RectangleF(1f, y, ClientRectangle.Width - 2, _int1 - 1);
                }
                _rectangleF1 = ClientRectangle;
                _rectangleF3 = _rectangleF0;
                LinearGradientMode linearGradientMode;
                SizeF sizeF;
                if (_orientation0 == Orientation.Horizontal)
                {
                    _rectangleF1.Inflate(-1f, -_rectangleF1.Height * (100f - _float1) / 200f - 1f);
                    _rectangleF2 = _rectangleF1;
                    _rectangleF2.Height = _rectangleF2.Height / 2f;
                    linearGradientMode = LinearGradientMode.Vertical;
                    _rectangleF3.Height = _rectangleF3.Height / 2f;
                    _rectangleF4 = _rectangleF1;
                    _rectangleF4.Width = _rectangleF0.Left + _int1 / 2f;
                    sizeF = new SizeF(_rectangleF1.Height * _float0 / 50f, _rectangleF1.Height * _float0 / 50f);
                }
                else
                {
                    _rectangleF1.Inflate(-_rectangleF1.Width * (100f - _float1) / 200f - 1f, -1f);
                    _rectangleF2 = _rectangleF1;
                    _rectangleF2.Width = _rectangleF2.Width / 2f;
                    linearGradientMode = LinearGradientMode.Horizontal;
                    _rectangleF3.Width = _rectangleF3.Width / 2f;
                    _rectangleF4 = _rectangleF1;
                    _rectangleF4.Height = _rectangleF0.Top + _int1 / 2f;
                    sizeF = new SizeF(_rectangleF1.Width * _float0 / 50f, _rectangleF1.Width * _float0 / 50f);
                }
                if (_string0.Length > 0 && (Capture || _bool7))
                {
                    if (_orientation0 == Orientation.Horizontal)
                    {
                        if (_rectangleF0.X != _float2)
                        {
                            _toolTip0.Show(method_3(), this,
                                (int) ((_float2 = _rectangleF0.X) + _rectangleF0.Width * 5f / 4f),
                                (int) _rectangleF0.Y);
                        }
                    }
                    else if (_rectangleF0.Y != _float2)
                    {
                        _toolTip0.Show(method_3(), this, (int) (_rectangleF0.X + _rectangleF0.Width * 5f / 4f),
                            (int) (_float2 = _rectangleF0.Y));
                    }
                }
                else if (_string0.Length > 0 && _bool6)
                {
                    string text = _bool3
                        ? smethod_4(TimeSpan.FromSeconds(_int7), _string0)
                        : string.Format(_string0, _int7);
                    if (_orientation0 == Orientation.Horizontal)
                    {
                        if (_int5 != _float2)
                        {
                            _toolTip0.Show(text, this, (int) ((_float2 = _int5) + 25f), _int6);
                        }
                    }
                    else if (_int5 != _float2)
                    {
                        _toolTip0.Show(text, this, _int5 + 25, (int) (_float2 = _int6));
                    }
                }
                else
                {
                    _toolTip0.Hide(this);
                    _float2 = -1f;
                }
                GraphicsPath graphicsPath;
                if (_graphicsPath0 == null)
                {
                    graphicsPath = smethod_0(_rectangleF0,
                        new SizeF(_rectangleF0.Width * _sizeF0.Width / 50f,
                            _rectangleF0.Height * _sizeF0.Height / 50f));
                }
                else
                {
                    graphicsPath = _graphicsPath0;
                    Matrix matrix = new Matrix();
                    matrix.Translate(_rectangleF0.Left - graphicsPath.GetBounds().Left,
                        _rectangleF0.Top - graphicsPath.GetBounds().Top);
                    graphicsPath.Transform(matrix);
                }
                paintEventArgs0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath graphicsPath2 = smethod_0(_rectangleF1, sizeF))
                {
                    using (LinearGradientBrush linearGradientBrush =
                        new LinearGradientBrush(_rectangleF2, color12, color13, linearGradientMode))
                    {
                        linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
                        paintEventArgs0.Graphics.FillPath(linearGradientBrush, graphicsPath2);
                        using (GraphicsPath graphicsPath3 = smethod_0(_rectangleF4, sizeF))
                        {
                            using (LinearGradientBrush linearGradientBrush2 =
                                new LinearGradientBrush(_rectangleF2, color15, color16, linearGradientMode))
                            {
                                linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
                                if (Capture && _bool5)
                                {
                                    Region region = new Region(graphicsPath3);
                                    region.Exclude(graphicsPath);
                                    paintEventArgs0.Graphics.FillRegion(linearGradientBrush2, region);
                                }
                                else
                                {
                                    paintEventArgs0.Graphics.FillPath(linearGradientBrush2, graphicsPath3);
                                }
                            }
                        }
                        using (Pen pen = new Pen(color14, 0.5f))
                        {
                            paintEventArgs0.Graphics.DrawPath(pen, graphicsPath2);
                        }
                    }
                }
                Color color = color9;
                Color color2 = color10;
                if (Capture && _bool5)
                {
                    color = Color.FromArgb(175, color9);
                    color2 = Color.FromArgb(175, color10);
                }
                using (LinearGradientBrush linearGradientBrush3 =
                    new LinearGradientBrush(_rectangleF3, color, color2, linearGradientMode))
                {
                    linearGradientBrush3.WrapMode = WrapMode.TileFlipXY;
                    paintEventArgs0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Color color3 = color11;
                    if (_bool4 && (Capture || _bool7))
                    {
                        color3 = ControlPaint.Dark(color3);
                    }
                    using (Pen pen2 = new Pen(color3))
                    {
                        if (_image0 != null)
                        {
                            paintEventArgs0.Graphics.DrawImage(_image0, _rectangleF0);
                        }
                        else
                        {
                            paintEventArgs0.Graphics.FillPath(linearGradientBrush3, graphicsPath);
                            paintEventArgs0.Graphics.DrawPath(pen2, graphicsPath);
                        }
                    }
                }
                if (Focused & _bool1)
                {
                    using (Pen pen3 = new Pen(Color.FromArgb(200, color14)))
                    {
                        pen3.DashStyle = DashStyle.Dot;
                        RectangleF rectangleF = ClientRectangle;
                        rectangleF.Width -= 2f;
                        rectangleF.Height -= 1f;
                        rectangleF.X += 1f;
                        using (GraphicsPath graphicsPath4 = smethod_0(rectangleF, sizeF))
                        {
                            paintEventArgs0.Graphics.DrawPath(pen3, graphicsPath4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DrawBackGround Error in " + Name + ":" + ex.Message);
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _bool6 = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _bool6 = false;
            _bool7 = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = true;
                _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, _int2));
                _eventHandler0?.Invoke(this, new EventArgs());
                OnMouseMove(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _int5 = e.X;
            _int6 = e.Y;
            _bool7 = smethod_3(e.Location, _rectangleF0);
            Point location = e.Location;
            int num = (_orientation0 == Orientation.Horizontal) ? location.X : location.Y;
            int num2 = _int1 >> 1;
            num -= num2;
            float num3 = (_int4 - _int3) / (float) (((_orientation0 == Orientation.Horizontal)
                                                      ? ClientSize.Width
                                                      : ClientSize.Height) - 2 * num2);
            _int7 = (int) (num * num3 + _int3);
            if (Capture & e.Button == MouseButtons.Left)
            {
                ScrollEventType type = ScrollEventType.ThumbPosition;
                _int2 = _int7;
                if (_int2 <= _int3)
                {
                    _int2 = _int3;
                    type = ScrollEventType.First;
                }
                else if (_int2 >= _int4)
                {
                    _int2 = _int4;
                    type = ScrollEventType.Last;
                }
                _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(type, _int2));
                _eventHandler0?.Invoke(this, new EventArgs());
            }
            if (_int7 < _int3)
            {
                _int7 = _int3;
            }
            else if (_int7 > _int4)
            {
                _int7 = _int4;
            }
            if (_bool0)
            {
                _int7 = _int4 - _int7 + _int3;
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Capture = false;
            _bool7 = smethod_3(e.Location, _rectangleF0);
            _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.EndScroll, _int2));
            _eventHandler0?.Invoke(this, new EventArgs());
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (_bool2)
            {
                base.OnMouseWheel(e);
                int num = e.Delta / SystemInformation.MouseWheelScrollDelta * (_int4 - _int3) / _int0;
                method_23(method_13() + num);
                _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.EndScroll, _int2));
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Prior:
                    method_23(method_13() + (int) _uint1);
                    _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, method_13()));
                    break;
                case Keys.Next:
                    method_23(method_13() - (int) _uint1);
                    _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, method_13()));
                    break;
                case Keys.End:
                    method_14(_int4);
                    break;
                case Keys.Home:
                    method_14(_int3);
                    break;
                case Keys.Left:
                case Keys.Down:
                    method_23(method_13() - (int) _uint0);
                    _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, method_13()));
                    break;
                case Keys.Up:
                case Keys.Right:
                    method_23(method_13() + (int) _uint0);
                    _scrollEventHandler0?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, method_13()));
                    break;
            }
            if (_scrollEventHandler0 != null && method_13() == _int3)
            {
                _scrollEventHandler0(this, new ScrollEventArgs(ScrollEventType.First, method_13()));
            }
            if (_scrollEventHandler0 != null && method_13() == _int4)
            {
                _scrollEventHandler0(this, new ScrollEventArgs(ScrollEventType.Last, method_13()));
            }
            Point point = PointToClient(Cursor.Position);
            OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab | ModifierKeys == Keys.Shift)
            {
                return base.ProcessDialogKey(keyData);
            }
            OnKeyDown(new KeyEventArgs(keyData));
            return true;
        }

        public static GraphicsPath smethod_0(RectangleF rectangleF5, SizeF sizeF1)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(rectangleF5.Left + sizeF1.Width / 2f, rectangleF5.Top,
                rectangleF5.Right - sizeF1.Width / 2f, rectangleF5.Top);
            graphicsPath.AddArc(rectangleF5.Right - sizeF1.Width, rectangleF5.Top, sizeF1.Width, sizeF1.Height, 270f,
                90f);
            graphicsPath.AddLine(rectangleF5.Right, rectangleF5.Top + sizeF1.Height / 2f, rectangleF5.Right,
                rectangleF5.Bottom - sizeF1.Height / 2f);
            graphicsPath.AddArc(rectangleF5.Right - sizeF1.Width, rectangleF5.Bottom - sizeF1.Height, sizeF1.Width,
                sizeF1.Height, 0f, 90f);
            graphicsPath.AddLine(rectangleF5.Right - sizeF1.Width / 2f, rectangleF5.Bottom,
                rectangleF5.Left + sizeF1.Width / 2f, rectangleF5.Bottom);
            graphicsPath.AddArc(rectangleF5.Left, rectangleF5.Bottom - sizeF1.Height, sizeF1.Width, sizeF1.Height, 90f,
                90f);
            graphicsPath.AddLine(rectangleF5.Left, rectangleF5.Bottom - sizeF1.Height / 2f, rectangleF5.Left,
                rectangleF5.Top + sizeF1.Height / 2f);
            graphicsPath.AddArc(rectangleF5.Left, rectangleF5.Top, sizeF1.Width, sizeF1.Height, 180f, 90f);
            return graphicsPath;
        }

        public static Color[] smethod_1(Color[] color9)
        {
            Color[] array = new Color[color9.Length];
            for (int i = 0; i < color9.Length; i++)
            {
                int num = (int) (color9[i].R * 0.3 + color9[i].G * 0.6 + color9[i].B * 0.1);
                array[i] = Color.FromArgb(-65793 * (255 - num) - 1);
            }
            return array;
        }

        public static Color[] smethod_2(Color[] color9)
        {
            Color[] array = new Color[color9.Length];
            for (int i = 0; i < color9.Length; i++)
            {
                array[i] = ((color9[i] == Color.FromKnownColor(KnownColor.Transparent))
                    ? color9[i]
                    : ControlPaint.Light(color9[i]));
            }
            return array;
        }

        private void method_23(int int8)
        {
            method_14((int8 < _int3) ? _int3 : ((int8 > _int4) ? _int4 : int8));
        }

        private static bool smethod_3(Point point0, RectangleF rectangleF5)
        {
            return point0.X > rectangleF5.Left && point0.X < rectangleF5.Right && point0.Y > rectangleF5.Top &&
                   point0.Y < rectangleF5.Bottom;
        }

        private static string smethod_4(TimeSpan timeSpan0, string string1)
        {
            if (string1.Length == 0)
            {
                return string.Empty;
            }
            if (!(string1 == "{0}"))
            {
                return string.Format(Class3610, string1, timeSpan0);
            }
            return timeSpan0.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && icontainer_0 != null)
            {
                icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void method_24()
        {
            SuspendLayout();
            Size = new Size(200, 30);
            ResumeLayout(false);
        }
    }
}