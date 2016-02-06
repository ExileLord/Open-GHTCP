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

		private Control1.Enum40 enum40_0;

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
			EventHandler eventHandler = this.eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

		public void method_1(string string_1)
		{
			this.string_0 = string_1;
			base.Invalidate();
		}

		public void method_2(bool bool_8)
		{
			this.bool_3 = bool_8;
			base.Invalidate();
		}

		public string method_3()
		{
			if (!this.bool_3)
			{
				return string.Format(this.string_0, this.method_13());
			}
			return Control1.smethod_4(TimeSpan.FromSeconds((double)this.method_13()), this.string_0);
		}

		public void method_4(int int_8)
		{
			if (int_8 <= 0)
			{
				throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greater than zero");
			}
			this.int_0 = int_8;
		}

		public void method_5(int int_8)
		{
			if (!(int_8 > 0 & int_8 < ((this.orientation_0 == Orientation.Horizontal) ? base.ClientRectangle.Width : base.ClientRectangle.Height)))
			{
				throw new ArgumentOutOfRangeException("TrackSize has to be greater than zero and lower than half of Slider width");
			}
			this.int_1 = int_8;
			base.Invalidate();
		}

		public void method_6(SizeF sizeF_1)
		{
			this.sizeF_0.Width = ((sizeF_1.Width < 1f) ? 1f : ((sizeF_1.Width > 100f) ? 100f : sizeF_1.Width));
			this.sizeF_0.Height = ((sizeF_1.Height < 1f) ? 1f : ((sizeF_1.Height > 100f) ? 100f : sizeF_1.Height));
			base.Invalidate();
		}

		public void method_7(float float_3)
		{
			this.float_0 = ((float_3 < 1f) ? 1f : ((float_3 > 100f) ? 100f : float_3));
			base.Invalidate();
		}

		public void method_8(float float_3)
		{
			this.float_1 = ((float_3 < 0f) ? 0f : ((float_3 > 100f) ? 100f : float_3));
			base.Invalidate();
		}

		public void method_9(Color color_9)
		{
			this.color_3 = color_9;
			base.Invalidate();
		}

		public void method_10(Color color_9)
		{
			this.color_4 = color_9;
			base.Invalidate();
		}

		public void method_11(Color color_9)
		{
			this.color_6 = color_9;
			base.Invalidate();
		}

		public void method_12(Color color_9)
		{
			this.color_7 = color_9;
			base.Invalidate();
		}

		public int method_13()
		{
			if (!this.bool_0)
			{
				return this.int_2;
			}
			return this.method_17() - this.int_2 + this.method_15();
		}

		public void method_14(int int_8)
		{
			if (int_8 < this.int_3)
			{
				this.int_2 = this.int_3;
			}
			else if (int_8 > this.int_4)
			{
				this.int_2 = this.int_4;
			}
			else
			{
				this.int_2 = (this.bool_0 ? (this.method_17() - int_8 + this.method_15()) : int_8);
			}
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, new EventArgs());
			}
			base.Invalidate();
		}

		public int method_15()
		{
			return this.int_3;
		}

		public void method_16(int int_8)
		{
			if (int_8 >= this.int_4)
			{
				throw new ArgumentOutOfRangeException("Minimal value is greater than maximal one");
			}
			this.int_3 = int_8;
			if (this.int_2 < this.int_3)
			{
				this.int_2 = this.int_3;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, new EventArgs());
				}
			}
			base.Invalidate();
		}

		public int method_17()
		{
			return this.int_4;
		}

		public void method_18(int int_8)
		{
			if (int_8 <= this.int_3)
			{
				this.int_4 = this.int_3;
			}
			this.int_4 = int_8;
			if (this.int_2 > this.int_4)
			{
				this.int_2 = this.int_4;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, new EventArgs());
				}
			}
			base.Invalidate();
		}

		public void method_19(uint uint_2)
		{
			this.uint_0 = uint_2;
		}

		public void method_20(uint uint_2)
		{
			this.uint_1 = uint_2;
		}

		public void method_21(Control1.Enum40 enum40_1)
		{
			this.enum40_0 = enum40_1;
			byte b = (byte)enum40_1;
			this.color_0 = this.color_8[(int)b, 0];
			this.color_1 = this.color_8[(int)b, 1];
			this.color_2 = this.color_8[(int)b, 2];
			this.color_3 = this.color_8[(int)b, 3];
			this.color_4 = this.color_8[(int)b, 4];
			this.color_5 = this.color_8[(int)b, 5];
			this.color_6 = this.color_8[(int)b, 6];
			this.color_7 = this.color_8[(int)b, 7];
			base.Invalidate();
		}

		public Control1(int int_8, int int_9, int int_10) : base()
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
			this.color_8 = array;

			this.method_24();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserMouse | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.method_16(int_8);
			this.method_18(int_9);
			this.method_14(int_10);
		}

		public Control1() : this(0, 100, 50)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!base.Enabled)
			{
				Color[] array = Control1.smethod_1(new Color[]
				{
					this.color_0,
					this.color_1,
					this.color_2,
					this.bool_0 ? this.color_6 : this.color_3,
					this.bool_0 ? this.color_7 : this.color_4,
					this.color_5,
					this.bool_0 ? this.color_3 : this.color_6,
					this.bool_0 ? this.color_4 : this.color_7
				});
				this.method_22(e, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
				return;
			}
			if (this.bool_4 && this.bool_6)
			{
				Color[] array2 = Control1.smethod_2(new Color[]
				{
					this.color_0,
					this.color_1,
					this.color_2,
					this.bool_0 ? this.color_6 : this.color_3,
					this.bool_0 ? this.color_7 : this.color_4,
					this.color_5,
					this.bool_0 ? this.color_3 : this.color_6,
					this.bool_0 ? this.color_4 : this.color_7
				});
				this.method_22(e, array2[0], array2[1], array2[2], array2[3], array2[4], array2[5], array2[6], array2[7]);
				return;
			}
			this.method_22(e, this.color_0, this.color_1, this.color_2, this.bool_0 ? this.color_6 : this.color_3, this.bool_0 ? this.color_7 : this.color_4, this.color_5, this.bool_0 ? this.color_3 : this.color_6, this.bool_0 ? this.color_4 : this.color_7);
		}

		private void method_22(PaintEventArgs paintEventArgs_0, Color color_9, Color color_10, Color color_11, Color color_12, Color color_13, Color color_14, Color color_15, Color color_16)
		{
			try
			{
				if (this.orientation_0 == Orientation.Horizontal)
				{
					float x = (float)((this.int_2 - this.int_3) * (base.ClientRectangle.Width - this.int_1)) / (float)(this.int_4 - this.int_3);
					this.rectangleF_0 = new RectangleF(x, 1f, (float)(this.int_1 - 1), (float)(base.ClientRectangle.Height - 2));
				}
				else
				{
					float y = (float)((this.int_2 - this.int_3) * (base.ClientRectangle.Height - this.int_1)) / (float)(this.int_4 - this.int_3);
					this.rectangleF_0 = new RectangleF(1f, y, (float)(base.ClientRectangle.Width - 2), (float)(this.int_1 - 1));
				}
				this.rectangleF_1 = base.ClientRectangle;
				this.rectangleF_3 = this.rectangleF_0;
				LinearGradientMode linearGradientMode;
				SizeF sizeF_;
				if (this.orientation_0 == Orientation.Horizontal)
				{
					this.rectangleF_1.Inflate(-1f, -this.rectangleF_1.Height * (100f - this.float_1) / 200f - 1f);
					this.rectangleF_2 = this.rectangleF_1;
					this.rectangleF_2.Height = this.rectangleF_2.Height / 2f;
					linearGradientMode = LinearGradientMode.Vertical;
					this.rectangleF_3.Height = this.rectangleF_3.Height / 2f;
					this.rectangleF_4 = this.rectangleF_1;
					this.rectangleF_4.Width = this.rectangleF_0.Left + (float)this.int_1 / 2f;
					sizeF_ = new SizeF(this.rectangleF_1.Height * this.float_0 / 50f, this.rectangleF_1.Height * this.float_0 / 50f);
				}
				else
				{
					this.rectangleF_1.Inflate(-this.rectangleF_1.Width * (100f - this.float_1) / 200f - 1f, -1f);
					this.rectangleF_2 = this.rectangleF_1;
					this.rectangleF_2.Width = this.rectangleF_2.Width / 2f;
					linearGradientMode = LinearGradientMode.Horizontal;
					this.rectangleF_3.Width = this.rectangleF_3.Width / 2f;
					this.rectangleF_4 = this.rectangleF_1;
					this.rectangleF_4.Height = this.rectangleF_0.Top + (float)this.int_1 / 2f;
					sizeF_ = new SizeF(this.rectangleF_1.Width * this.float_0 / 50f, this.rectangleF_1.Width * this.float_0 / 50f);
				}
				if (this.string_0.Length > 0 && (base.Capture || this.bool_7))
				{
					if (this.orientation_0 == Orientation.Horizontal)
					{
						if (this.rectangleF_0.X != this.float_2)
						{
							this.toolTip_0.Show(this.method_3(), this, (int)((this.float_2 = this.rectangleF_0.X) + this.rectangleF_0.Width * 5f / 4f), (int)this.rectangleF_0.Y);
						}
					}
					else if (this.rectangleF_0.Y != this.float_2)
					{
						this.toolTip_0.Show(this.method_3(), this, (int)(this.rectangleF_0.X + this.rectangleF_0.Width * 5f / 4f), (int)(this.float_2 = this.rectangleF_0.Y));
					}
				}
				else if (this.string_0.Length > 0 && this.bool_6)
				{
					string text = this.bool_3 ? Control1.smethod_4(TimeSpan.FromSeconds((double)this.int_7), this.string_0) : string.Format(this.string_0, this.int_7);
					if (this.orientation_0 == Orientation.Horizontal)
					{
						if ((float)this.int_5 != this.float_2)
						{
							this.toolTip_0.Show(text, this, (int)((this.float_2 = (float)this.int_5) + 25f), this.int_6);
						}
					}
					else if ((float)this.int_5 != this.float_2)
					{
						this.toolTip_0.Show(text, this, this.int_5 + 25, (int)(this.float_2 = (float)this.int_6));
					}
				}
				else
				{
					this.toolTip_0.Hide(this);
					this.float_2 = -1f;
				}
				GraphicsPath graphicsPath;
				if (this.graphicsPath_0 == null)
				{
					graphicsPath = Control1.smethod_0(this.rectangleF_0, new SizeF(this.rectangleF_0.Width * this.sizeF_0.Width / 50f, this.rectangleF_0.Height * this.sizeF_0.Height / 50f));
				}
				else
				{
					graphicsPath = this.graphicsPath_0;
					Matrix matrix = new Matrix();
					matrix.Translate(this.rectangleF_0.Left - graphicsPath.GetBounds().Left, this.rectangleF_0.Top - graphicsPath.GetBounds().Top);
					graphicsPath.Transform(matrix);
				}
				paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				using (GraphicsPath graphicsPath2 = Control1.smethod_0(this.rectangleF_1, sizeF_))
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.rectangleF_2, color_12, color_13, linearGradientMode))
					{
						linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
						paintEventArgs_0.Graphics.FillPath(linearGradientBrush, graphicsPath2);
						using (GraphicsPath graphicsPath3 = Control1.smethod_0(this.rectangleF_4, sizeF_))
						{
							using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(this.rectangleF_2, color_15, color_16, linearGradientMode))
							{
								linearGradientBrush2.WrapMode = WrapMode.TileFlipXY;
								if (base.Capture && this.bool_5)
								{
									Region region = new Region(graphicsPath3);
									region.Exclude(graphicsPath);
									paintEventArgs_0.Graphics.FillRegion(linearGradientBrush2, region);
								}
								else
								{
									paintEventArgs_0.Graphics.FillPath(linearGradientBrush2, graphicsPath3);
								}
							}
						}
						using (Pen pen = new Pen(color_14, 0.5f))
						{
							paintEventArgs_0.Graphics.DrawPath(pen, graphicsPath2);
						}
					}
				}
				Color color = color_9;
				Color color2 = color_10;
				if (base.Capture && this.bool_5)
				{
					color = Color.FromArgb(175, color_9);
					color2 = Color.FromArgb(175, color_10);
				}
				using (LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(this.rectangleF_3, color, color2, linearGradientMode))
				{
					linearGradientBrush3.WrapMode = WrapMode.TileFlipXY;
					paintEventArgs_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					Color color3 = color_11;
					if (this.bool_4 && (base.Capture || this.bool_7))
					{
						color3 = ControlPaint.Dark(color3);
					}
					using (Pen pen2 = new Pen(color3))
					{
						if (this.image_0 != null)
						{
							paintEventArgs_0.Graphics.DrawImage(this.image_0, this.rectangleF_0);
						}
						else
						{
							paintEventArgs_0.Graphics.FillPath(linearGradientBrush3, graphicsPath);
							paintEventArgs_0.Graphics.DrawPath(pen2, graphicsPath);
						}
					}
				}
				if (this.Focused & this.bool_1)
				{
					using (Pen pen3 = new Pen(Color.FromArgb(200, color_14)))
					{
						pen3.DashStyle = DashStyle.Dot;
						RectangleF rectangleF_ = base.ClientRectangle;
						rectangleF_.Width -= 2f;
						rectangleF_.Height -= 1f;
						rectangleF_.X += 1f;
						using (GraphicsPath graphicsPath4 = Control1.smethod_0(rectangleF_, sizeF_))
						{
							paintEventArgs_0.Graphics.DrawPath(pen3, graphicsPath4);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("DrawBackGround Error in " + base.Name + ":" + ex.Message);
			}
		}

        protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			base.Invalidate();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.bool_6 = true;
			base.Invalidate();
		}

        protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.bool_6 = false;
			this.bool_7 = false;
			base.Invalidate();
		}

        protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				base.Capture = true;
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, this.int_2));
				}
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, new EventArgs());
				}
				this.OnMouseMove(e);
			}
		}

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.int_5 = e.X;
			this.int_6 = e.Y;
			this.bool_7 = Control1.smethod_3(e.Location, this.rectangleF_0);
			Point location = e.Location;
			int num = (this.orientation_0 == Orientation.Horizontal) ? location.X : location.Y;
			int num2 = this.int_1 >> 1;
			num -= num2;
			float num3 = (float)(this.int_4 - this.int_3) / (float)(((this.orientation_0 == Orientation.Horizontal) ? base.ClientSize.Width : base.ClientSize.Height) - 2 * num2);
			this.int_7 = (int)((float)num * num3 + (float)this.int_3);
			if (base.Capture & e.Button == MouseButtons.Left)
			{
				ScrollEventType type = ScrollEventType.ThumbPosition;
				this.int_2 = this.int_7;
				if (this.int_2 <= this.int_3)
				{
					this.int_2 = this.int_3;
					type = ScrollEventType.First;
				}
				else if (this.int_2 >= this.int_4)
				{
					this.int_2 = this.int_4;
					type = ScrollEventType.Last;
				}
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(type, this.int_2));
				}
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, new EventArgs());
				}
			}
			if (this.int_7 < this.int_3)
			{
				this.int_7 = this.int_3;
			}
			else if (this.int_7 > this.int_4)
			{
				this.int_7 = this.int_4;
			}
			if (this.bool_0)
			{
				this.int_7 = this.int_4 - this.int_7 + this.int_3;
			}
			base.Invalidate();
		}

        protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			base.Capture = false;
			this.bool_7 = Control1.smethod_3(e.Location, this.rectangleF_0);
			if (this.scrollEventHandler_0 != null)
			{
				this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.EndScroll, this.int_2));
			}
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, new EventArgs());
			}
			base.Invalidate();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (this.bool_2)
			{
				base.OnMouseWheel(e);
				int num = e.Delta / SystemInformation.MouseWheelScrollDelta * (this.int_4 - this.int_3) / this.int_0;
				this.method_23(this.method_13() + num);
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.EndScroll, this.int_2));
				}
			}
		}

        protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			base.Invalidate();
		}

        protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			base.Invalidate();
		}

        protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			switch (e.KeyCode)
			{
			case Keys.Prior:
				this.method_23(this.method_13() + (int)this.uint_1);
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, this.method_13()));
				}
				break;
			case Keys.Next:
				this.method_23(this.method_13() - (int)this.uint_1);
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, this.method_13()));
				}
				break;
			case Keys.End:
				this.method_14(this.int_4);
				break;
			case Keys.Home:
				this.method_14(this.int_3);
				break;
			case Keys.Left:
			case Keys.Down:
				this.method_23(this.method_13() - (int)this.uint_0);
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, this.method_13()));
				}
				break;
			case Keys.Up:
			case Keys.Right:
				this.method_23(this.method_13() + (int)this.uint_0);
				if (this.scrollEventHandler_0 != null)
				{
					this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, this.method_13()));
				}
				break;
			}
			if (this.scrollEventHandler_0 != null && this.method_13() == this.int_3)
			{
				this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.First, this.method_13()));
			}
			if (this.scrollEventHandler_0 != null && this.method_13() == this.int_4)
			{
				this.scrollEventHandler_0(this, new ScrollEventArgs(ScrollEventType.Last, this.method_13()));
			}
			Point point = base.PointToClient(Cursor.Position);
			this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Tab | Control.ModifierKeys == Keys.Shift)
			{
				return base.ProcessDialogKey(keyData);
			}
			this.OnKeyDown(new KeyEventArgs(keyData));
			return true;
		}

		public static GraphicsPath smethod_0(RectangleF rectangleF_5, SizeF sizeF_1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
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
			Color[] array = new Color[color_9.Length];
			for (int i = 0; i < color_9.Length; i++)
			{
				int num = (int)((double)color_9[i].R * 0.3 + (double)color_9[i].G * 0.6 + (double)color_9[i].B * 0.1);
				array[i] = Color.FromArgb(-65793 * (255 - num) - 1);
			}
			return array;
		}

		public static Color[] smethod_2(Color[] color_9)
		{
			Color[] array = new Color[color_9.Length];
			for (int i = 0; i < color_9.Length; i++)
			{
				array[i] = ((color_9[i] == Color.FromKnownColor(KnownColor.Transparent)) ? color_9[i] : ControlPaint.Light(color_9[i]));
			}
			return array;
		}

		private void method_23(int int_8)
		{
			this.method_14((int_8 < this.int_3) ? this.int_3 : ((int_8 > this.int_4) ? this.int_4 : int_8));
		}

		private static bool smethod_3(Point point_0, RectangleF rectangleF_5)
		{
			return (float)point_0.X > rectangleF_5.Left && (float)point_0.X < rectangleF_5.Right && (float)point_0.Y > rectangleF_5.Top && (float)point_0.Y < rectangleF_5.Bottom;
		}

		private static string smethod_4(TimeSpan timeSpan_0, string string_1)
		{
			if (string_1.Length == 0)
			{
				return string.Empty;
			}
			if (!(string_1 == "{0}"))
			{
				return string.Format(Control1.class361_0, string_1, new object[]
				{
					timeSpan_0
				});
			}
			return timeSpan_0.ToString();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_24()
		{
			base.SuspendLayout();
			base.Size = new Size(200, 30);
			base.ResumeLayout(false);
		}
	}
}
