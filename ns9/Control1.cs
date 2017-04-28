using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace ns9
{
	public class Control1 : Control
	{
		public enum Enum40
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private EventHandler eventHandler_0;

		private ScrollEventHandler scrollEventHandler_0;

		private bool bool_0;

		private Orientation orientation_0;

		private bool bool_1;

		private bool bool_2;

		private readonly ToolTip toolTip_0 = new ToolTip();

		private string string_0 = "{0}";

		private bool bool_3;

		private bool bool_4 = true;

		private int int_0 = 10;

		private RectangleF rectangleF_0;

		private RectangleF rectangleF_1;

		private RectangleF rectangleF_2;

		private RectangleF rectangleF_3;

		private RectangleF rectangleF_4;

		private int int_1 = 15;

		private GraphicsPath graphicsPath_0;

		private SizeF sizeF_0 = new SizeF(50f, 50f);

		private bool bool_5 = true;

		private Image image_0;

		private Color color_0 = Color.White;

		private Color color_1 = Color.Gainsboro;

		private Color color_2 = Color.Silver;

		private float float_0 = 100f;

		private float float_1 = 33f;

		private Color color_3 = Color.SkyBlue;

		private Color color_4 = Color.DarkSlateBlue;

		private Color color_5 = Color.Gainsboro;

		private Color color_6 = Color.DarkGreen;

		private Color color_7 = Color.Chartreuse;

		private int int_2 = 50;

		private int int_3;

		private int int_4 = 100;

		private uint uint_0 = 1u;

		private uint uint_1 = 5u;

		private readonly Color[,] color_8;

		private Enum40 enum40_0;

		private float float_2;

		private bool bool_6;

		private bool bool_7;

		private int int_5;

		private int int_6;

		private int int_7;

		private static readonly Class361 class361_0 = new Class361();

		private IContainer icontainer_0;

		public void method_0(EventHandler eventHandler_1)
		{
			var eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				var value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
			Invalidate();
		}

		public void method_2(bool bool_8)
		{
			bool_3 = bool_8;
			Invalidate();
		}

		public string method_3()
		{
			if (!bool_3)
			{
				return string.Format(string_0, method_13());
			}
			return smethod_4(TimeSpan.FromSeconds(method_13()), string_0);
		}

		public void method_4(int int_8)
		{
			if (int_8 <= 0)
			{
				throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greater than zero");
			}
			int_0 = int_8;
		}

		public void method_5(int int_8)
		{
			if (!(int_8 > 0 & int_8 < ((orientation_0 == Orientation.Horizontal) ? ClientRectangle.Width : ClientRectangle.Height)))
			{
				throw new ArgumentOutOfRangeException("TrackSize has to be greater than zero and lower than half of Slider width");
			}
			int_1 = int_8;
			Invalidate();
		}

		public void method_6(SizeF sizeF_1)
		{
			sizeF_0.Width = ((sizeF_1.Width < 1f) ? 1f : ((sizeF_1.Width > 100f) ? 100f : sizeF_1.Width));
			sizeF_0.Height = ((sizeF_1.Height < 1f) ? 1f : ((sizeF_1.Height > 100f) ? 100f : sizeF_1.Height));
			Invalidate();
		}

		public void method_7(float float_3)
		{
			float_0 = ((float_3 < 1f) ? 1f : ((float_3 > 100f) ? 100f : float_3));
			Invalidate();
		}

		public void method_8(float float_3)
		{
			float_1 = ((float_3 < 0f) ? 0f : ((float_3 > 100f) ? 100f : float_3));
			Invalidate();
		}

		public void method_9(Color color_9)
		{
			color_3 = color_9;
			Invalidate();
		}

		public void method_10(Color color_9)
		{
			color_4 = color_9;
			Invalidate();
		}

		public void method_11(Color color_9)
		{
			color_6 = color_9;
			Invalidate();
		}

		public void method_12(Color color_9)
		{
			color_7 = color_9;
			Invalidate();
		}

		public int method_13()
		{
			if (!bool_0)
			{
				return int_2;
			}
			return method_17() - int_2 + method_15();
		}

		public void method_14(int int_8)
		{
			if (int_8 < int_3)
			{
				int_2 = int_3;
			}
			else if (int_8 > int_4)
			{
				int_2 = int_4;
			}
			else
			{
				int_2 = (bool_0 ? (method_17() - int_8 + method_15()) : int_8);
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
			Invalidate();
		}

		public int method_15()
		{
			return int_3;
		}

		public void method_16(int int_8)
		{
			if (int_8 >= int_4)
			{
				throw new ArgumentOutOfRangeException("Minimal value is greater than maximal one");
			}
			int_3 = int_8;
			if (int_2 < int_3)
			{
				int_2 = int_3;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
			Invalidate();
		}

		public int method_17()
		{
			return int_4;
		}

		public void method_18(int int_8)
		{
			if (int_8 <= int_3)
			{
				int_4 = int_3;
			}
			int_4 = int_8;
			if (int_2 > int_4)
			{
				int_2 = int_4;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
			Invalidate();
		}

		public void method_19(uint uint_2)
		{
			uint_0 = uint_2;
		}

		public void method_20(uint uint_2)
		{
			uint_1 = uint_2;
		}

		public void method_21(Enum40 enum40_1)
		{
			enum40_0 = enum40_1;
			var b = (byte)enum40_1;
			color_0 = color_8[b, 0];
			color_1 = color_8[b, 1];
			color_2 = color_8[b, 2];
			color_3 = color_8[b, 3];
			color_4 = color_8[b, 4];
			color_5 = color_8[b, 5];
			color_6 = color_8[b, 6];
			color_7 = color_8[b, 7];
			Invalidate();
		}

		public Control1(int int_8, int int_9, int int_10)
		{
			var array = new Color[4, 8];
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
			color_8 = array;

			method_24();
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			BackColor = Color.Transparent;
			method_16(int_8);
			method_18(int_9);
			method_14(int_10);
		}

		public Control1() : this(0, 100, 50)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!Enabled)
			{
				var array = smethod_1(new[]
				{
					color_0,
					color_1,
					color_2,
					bool_0 ? color_6 : color_3,
					bool_0 ? color_7 : color_4,
					color_5,
					bool_0 ? color_3 : color_6,
					bool_0 ? color_4 : color_7
				});
				method_22(e, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
				return;
			}
			if (bool_4 && bool_6)
			{
				var array2 = smethod_2(new[]
				{
					color_0,
					color_1,
					color_2,
					bool_0 ? color_6 : color_3,
					bool_0 ? color_7 : color_4,
					color_5,
					bool_0 ? color_3 : color_6,
					bool_0 ? color_4 : color_7
				});
				method_22(e, array2[0], array2[1], array2[2], array2[3], array2[4], array2[5], array2[6], array2[7]);
				return;
			}
			method_22(e, color_0, color_1, color_2, bool_0 ? color_6 : color_3, bool_0 ? color_7 : color_4, color_5, bool_0 ? color_3 : color_6, bool_0 ? color_4 : color_7);
		}

		private void method_22(PaintEventArgs paintEventArgs_0, Color color_9, Color color_10, Color color_11, Color color_12, Color color_13, Color color_14, Color color_15, Color color_16)
		{
			try
			{
				if (orientation_0 == Orientation.Horizontal)
				{
					var x = (int_2 - int_3) * (ClientRectangle.Width - int_1) / (float)(int_4 - int_3);
					rectangleF_0 = new RectangleF(x, 1f, int_1 - 1, ClientRectangle.Height - 2);
				}
				else
				{
					var y = (int_2 - int_3) * (ClientRectangle.Height - int_1) / (float)(int_4 - int_3);
					rectangleF_0 = new RectangleF(1f, y, ClientRectangle.Width - 2, int_1 - 1);
				}
				rectangleF_1 = ClientRectangle;
				rectangleF_3 = rectangleF_0;
				LinearGradientMode linearGradientMode;
				SizeF sizeF_;
				if (orientation_0 == Orientation.Horizontal)
				{
					rectangleF_1.Inflate(-1f, -rectangleF_1.Height * (100f - float_1) / 200f - 1f);
					rectangleF_2 = rectangleF_1;
					rectangleF_2.Height = rectangleF_2.Height / 2f;
					linearGradientMode = LinearGradientMode.Vertical;
					rectangleF_3.Height = rectangleF_3.Height / 2f;
					rectangleF_4 = rectangleF_1;
					rectangleF_4.Width = rectangleF_0.Left + int_1 / 2f;
					sizeF_ = new SizeF(rectangleF_1.Height * float_0 / 50f, rectangleF_1.Height * float_0 / 50f);
				}
				else
				{
					rectangleF_1.Inflate(-rectangleF_1.Width * (100f - float_1) / 200f - 1f, -1f);
					rectangleF_2 = rectangleF_1;
					rectangleF_2.Width = rectangleF_2.Width / 2f;
					linearGradientMode = LinearGradientMode.Horizontal;
					rectangleF_3.Width = rectangleF_3.Width / 2f;
					rectangleF_4 = rectangleF_1;
					rectangleF_4.Height = rectangleF_0.Top + int_1 / 2f;
					sizeF_ = new SizeF(rectangleF_1.Width * float_0 / 50f, rectangleF_1.Width * float_0 / 50f);
				}
				if (string_0.Length > 0 && (Capture || bool_7))
				{
					if (orientation_0 == Orientation.Horizontal)
					{
						if (rectangleF_0.X != float_2)
						{
							toolTip_0.Show(method_3(), this, (int)((float_2 = rectangleF_0.X) + rectangleF_0.Width * 5f / 4f), (int)rectangleF_0.Y);
						}
					}
					else if (rectangleF_0.Y != float_2)
					{
						toolTip_0.Show(method_3(), this, (int)(rectangleF_0.X + rectangleF_0.Width * 5f / 4f), (int)(float_2 = rectangleF_0.Y));
					}
				}
				else if (string_0.Length > 0 && bool_6)
				{
					var text = bool_3 ? smethod_4(TimeSpan.FromSeconds(int_7), string_0) : string.Format(string_0, int_7);
					if (orientation_0 == Orientation.Horizontal)
					{
						if (int_5 != float_2)
						{
							toolTip_0.Show(text, this, (int)((float_2 = int_5) + 25f), int_6);
						}
					}
					else if (int_5 != float_2)
					{
						toolTip_0.Show(text, this, int_5 + 25, (int)(float_2 = int_6));
					}
				}
				else
				{
					toolTip_0.Hide(this);
					float_2 = -1f;
				}
				GraphicsPath graphicsPath;
				if (graphicsPath_0 == null)
				{
					graphicsPath = smethod_0(rectangleF_0, new SizeF(rectangleF_0.Width * sizeF_0.Width / 50f, rectangleF_0.Height * sizeF_0.Height / 50f));
				}
				else
				{
					graphicsPath = graphicsPath_0;
					var matrix = new Matrix();
					matrix.Translate(rectangleF_0.Left - graphicsPath.GetBounds().Left, rectangleF_0.Top - graphicsPath.GetBounds().Top);
					graphicsPath.Transform(matrix);
				}
				paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				using (var graphicsPath2 = smethod_0(rectangleF_1, sizeF_))
				{
					using (var linearGradientBrush = new LinearGradientBrush(rectangleF_2, color_12, color_13, linearGradientMode))
					{
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						paintEventArgs_0.Graphics.FillPath(linearGradientBrush, graphicsPath2);
						using (var graphicsPath3 = smethod_0(rectangleF_4, sizeF_))
						{
							using (var linearGradientBrush2 = new LinearGradientBrush(rectangleF_2, color_15, color_16, linearGradientMode))
							{
								linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
								if (Capture && bool_5)
								{
									var region = new Region(graphicsPath3);
									region.Exclude(graphicsPath);
									paintEventArgs_0.Graphics.FillRegion(linearGradientBrush2, region);
								}
								else
								{
									paintEventArgs_0.Graphics.FillPath(linearGradientBrush2, graphicsPath3);
								}
							}
						}
						using (var pen = new Pen(color_14, 0.5f))
						{
							paintEventArgs_0.Graphics.DrawPath(pen, graphicsPath2);
						}
					}
				}
				var color = color_9;
				var color2 = color_10;
				if (Capture && bool_5)
				{
					color = Color.FromArgb(175, color_9);
					color2 = Color.FromArgb(175, color_10);
				}
				using (var linearGradientBrush3 = new LinearGradientBrush(rectangleF_3, color, color2, linearGradientMode))
				{
					linearGradientBrush3.WrapMode = WrapMode.TileFlipXY;
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					var color3 = color_11;
					if (bool_4 && (Capture || bool_7))
					{
						color3 = ControlPaint.Dark(color3);
					}
					using (var pen2 = new Pen(color3))
					{
						if (image_0 != null)
						{
							paintEventArgs_0.Graphics.DrawImage(image_0, rectangleF_0);
						}
						else
						{
							paintEventArgs_0.Graphics.FillPath(linearGradientBrush3, graphicsPath);
							paintEventArgs_0.Graphics.DrawPath(pen2, graphicsPath);
						}
					}
				}
				if (Focused & bool_1)
				{
					using (var pen3 = new Pen(Color.FromArgb(200, color_14)))
					{
						pen3.DashStyle = DashStyle.Dot;
						RectangleF rectangleF_ = ClientRectangle;
						rectangleF_.Width -= 2f;
						rectangleF_.Height -= 1f;
						rectangleF_.X += 1f;
						using (var graphicsPath4 = smethod_0(rectangleF_, sizeF_))
						{
							paintEventArgs_0.Graphics.DrawPath(pen3, graphicsPath4);
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
			bool_6 = true;
			Invalidate();
		}

        protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			bool_6 = false;
			bool_7 = false;
			Invalidate();
		}

        protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				Capture = true;
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, int_2));
				}
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
				OnMouseMove(e);
			}
		}

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			int_5 = e.X;
			int_6 = e.Y;
			bool_7 = smethod_3(e.Location, rectangleF_0);
			var location = e.Location;
			var num = (orientation_0 == Orientation.Horizontal) ? location.X : location.Y;
			var num2 = int_1 >> 1;
			num -= num2;
			var num3 = (int_4 - int_3) / (float)(((orientation_0 == Orientation.Horizontal) ? ClientSize.Width : ClientSize.Height) - 2 * num2);
			int_7 = (int)(num * num3 + int_3);
			if (Capture & e.Button == MouseButtons.Left)
			{
				var type = ScrollEventType.ThumbPosition;
				int_2 = int_7;
				if (int_2 <= int_3)
				{
					int_2 = int_3;
					type = ScrollEventType.First;
				}
				else if (int_2 >= int_4)
				{
					int_2 = int_4;
					type = ScrollEventType.Last;
				}
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(type, int_2));
				}
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
			if (int_7 < int_3)
			{
				int_7 = int_3;
			}
			else if (int_7 > int_4)
			{
				int_7 = int_4;
			}
			if (bool_0)
			{
				int_7 = int_4 - int_7 + int_3;
			}
			Invalidate();
		}

        protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			Capture = false;
			bool_7 = smethod_3(e.Location, rectangleF_0);
			if (scrollEventHandler_0 != null)
			{
				scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.EndScroll, int_2));
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
			Invalidate();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (bool_2)
			{
				base.OnMouseWheel(e);
				var num = e.Delta / SystemInformation.MouseWheelScrollDelta * (int_4 - int_3) / int_0;
				method_23(method_13() + num);
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.EndScroll, int_2));
				}
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
				method_23(method_13() + (int)uint_1);
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, method_13()));
				}
				break;
			case Keys.Next:
				method_23(method_13() - (int)uint_1);
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, method_13()));
				}
				break;
			case Keys.End:
				method_14(int_4);
				break;
			case Keys.Home:
				method_14(int_3);
				break;
			case Keys.Left:
			case Keys.Down:
				method_23(method_13() - (int)uint_0);
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, method_13()));
				}
				break;
			case Keys.Up:
			case Keys.Right:
				method_23(method_13() + (int)uint_0);
				if (scrollEventHandler_0 != null)
				{
					scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, method_13()));
				}
				break;
			}
			if (scrollEventHandler_0 != null && method_13() == int_3)
			{
				scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.First, method_13()));
			}
			if (scrollEventHandler_0 != null && method_13() == int_4)
			{
				scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.Last, method_13()));
			}
			var point = PointToClient(Cursor.Position);
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

		public static GraphicsPath smethod_0(RectangleF rectangleF_5, SizeF sizeF_1)
		{
			var graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(rectangleF_5.Left + sizeF_1.Width / 2f, rectangleF_5.Top, rectangleF_5.Right - sizeF_1.Width / 2f, rectangleF_5.Top);
			graphicsPath.AddArc(rectangleF_5.Right - sizeF_1.Width, rectangleF_5.Top, sizeF_1.Width, sizeF_1.Height, 270f, 90f);
			graphicsPath.AddLine(rectangleF_5.Right, rectangleF_5.Top + sizeF_1.Height / 2f, rectangleF_5.Right, rectangleF_5.Bottom - sizeF_1.Height / 2f);
			graphicsPath.AddArc(rectangleF_5.Right - sizeF_1.Width, rectangleF_5.Bottom - sizeF_1.Height, sizeF_1.Width, sizeF_1.Height, 0f, 90f);
			graphicsPath.AddLine(rectangleF_5.Right - sizeF_1.Width / 2f, rectangleF_5.Bottom, rectangleF_5.Left + sizeF_1.Width / 2f, rectangleF_5.Bottom);
			graphicsPath.AddArc(rectangleF_5.Left, rectangleF_5.Bottom - sizeF_1.Height, sizeF_1.Width, sizeF_1.Height, 90f, 90f);
			graphicsPath.AddLine(rectangleF_5.Left, rectangleF_5.Bottom - sizeF_1.Height / 2f, rectangleF_5.Left, rectangleF_5.Top + sizeF_1.Height / 2f);
			graphicsPath.AddArc(rectangleF_5.Left, rectangleF_5.Top, sizeF_1.Width, sizeF_1.Height, 180f, 90f);
			return graphicsPath;
		}

		public static Color[] smethod_1(Color[] color_9)
		{
			var array = new Color[color_9.Length];
			for (var i = 0; i < color_9.Length; i++)
			{
				var num = (int)(color_9[i].R * 0.3 + color_9[i].G * 0.6 + color_9[i].B * 0.1);
				array[i] = Color.FromArgb(-65793 * (255 - num) - 1);
			}
			return array;
		}

		public static Color[] smethod_2(Color[] color_9)
		{
			var array = new Color[color_9.Length];
			for (var i = 0; i < color_9.Length; i++)
			{
				array[i] = ((color_9[i] == Color.FromKnownColor(KnownColor.Transparent)) ? color_9[i] : ControlPaint.Light(color_9[i]));
			}
			return array;
		}

		private void method_23(int int_8)
		{
			method_14((int_8 < int_3) ? int_3 : ((int_8 > int_4) ? int_4 : int_8));
		}

		private static bool smethod_3(Point point_0, RectangleF rectangleF_5)
		{
			return point_0.X > rectangleF_5.Left && point_0.X < rectangleF_5.Right && point_0.Y > rectangleF_5.Top && point_0.Y < rectangleF_5.Bottom;
		}

		private static string smethod_4(TimeSpan timeSpan_0, string string_1)
		{
			if (string_1.Length == 0)
			{
				return string.Empty;
			}
			if (!(string_1 == "{0}"))
			{
				return string.Format(class361_0, string_1, timeSpan_0);
			}
			return timeSpan_0.ToString();
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
