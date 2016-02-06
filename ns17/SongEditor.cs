using GuitarHero.Songlist;
using ns0;
using ns1;
using ns14;
using ns15;
using ns8;
using ns9;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns17
{
	public class SongEditor : UserControl, IDisposable
	{
		public delegate void Delegate10(object sender, EventArgs e);

		[CompilerGenerated]
		private class Class373
		{
			public SongEditor songEditor_0;

			public string string_0;

			public void method_0(object object_0)
			{
				using (Stream1 stream = Class170.smethod_4(this.string_0))
				{
					this.songEditor_0.sbyte_0 = new sbyte[(ulong)stream.vmethod_1().uint_0 * (ulong)((long)stream.vmethod_1().method_0())];
					float[] array = new float[4096];
					int num;
					for (int i = 0; i < this.songEditor_0.sbyte_0.Length; i += num)
					{
						if (i + array.Length < this.songEditor_0.sbyte_0.Length)
						{
							num = stream.vmethod_4(array, 0, array.Length);
						}
						else
						{
							num = stream.vmethod_4(array, 0, this.songEditor_0.sbyte_0.Length - i);
						}
						for (int j = 0; j < num; j++)
						{
							this.songEditor_0.sbyte_0[i + j] = Class11.smethod_19(array[j]);
						}
						if (num <= 0)
						{
							break;
						}
					}
				}
				GC.Collect();
			}
		}

		private IContainer icontainer_0;

		private System.Windows.Forms.Timer timer_0;

		private VScrollBar vscrollBar_0 = new VScrollBar();

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private float float_0;

		private float float_1;

		private float float_2;

		private int int_6;

		private Class362 class362_0;

		private Interface6 interface6_0;

		private sbyte[] sbyte_0;

		private Pen pen_0 = Pens.Black;

		private Pen pen_1 = Pens.Gray;

		private Pen pen_2 = Pens.LightGray;

		private bool bool_0;

		private int int_7 = 4;

		public decimal decimal_0;

		private Brush brush_0 = SystemBrushes.GrayText;

		private Font font_0 = new Font("Verdana", 24f);

		private Brush[] brush_1 = new Brush[]
		{
			Brushes.Green,
			Brushes.Red,
			Brushes.Yellow,
			Brushes.Blue,
			Brushes.Orange,
			Brushes.LightGray
		};

		private Pen[] pen_3 = new Pen[]
		{
			Pens.Green,
			Pens.Red,
			Pens.Yellow,
			Pens.Blue,
			Pens.Orange,
			Pens.LightGray
		};

		private Pen[] pen_4 = new Pen[6];

		private Brush brush_2 = Brushes.Black;

		private Brush brush_3 = Brushes.White;

		private Pen pen_5 = Pens.Black;

		private Pen pen_6 = new Pen(Color.FromArgb(30, Color.Blue));

		private double double_0 = 2.5132741228718345;

		private bool bool_1 = true;

		private Size size_0 = new Size(200, 600);

		private float float_3;

		private double double_1;

		private float float_4;

		public string string_0;

		public float float_5 = 10f;

		public Size size_1 = new Size(20, 60);

		public bool bool_2 = true;

		public bool bool_3 = true;

		public bool bool_4 = true;

		private double double_2 = 1.0;

		private SongEditor.Delegate10 delegate10_0;

        protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Name = "SongEditor";
			base.ResumeLayout(false);
		}

		public Enum1 method_0()
		{
			if (this.interface6_0 == null)
			{
				return Enum1.const_0;
			}
			return this.interface6_0.imethod_6();
		}

		public void method_1(int int_8)
		{
			this.size_1.Width = int_8;
			this.decimal_0 = this.size_1.Width / this.class362_0.class239_0[1];
			this.method_13();
		}

		public void method_2(int int_8)
		{
			GH3Song arg_1F_0 = this.class362_0.gh3Song_0;
			this.class362_0.gh3Song_0.gem_offset = int_8;
			arg_1F_0.fretbar_offset = int_8;
			this.method_13();
		}

		public bool method_3()
		{
			return this.bool_0;
		}

		public void method_4(bool bool_5)
		{
			ScrollBar arg_22_0 = this.vscrollBar_0;
			this.bool_0 = bool_5;
			arg_22_0.Maximum = (bool_5 ? this.int_4 : this.int_5) - 1;
			this.method_13();
		}

		public bool method_5()
		{
			return this.int_7 == 5;
		}

		public void method_6(bool bool_5)
		{
			this.int_7 = (bool_5 ? 5 : 4);
		}

		public bool method_7()
		{
			return this.bool_1;
		}

		public void method_8(bool bool_5)
		{
			this.bool_1 = bool_5;
			this.method_13();
		}

		public void method_9(double double_3)
		{
			this.double_2 = double_3;
			this.method_13();
		}

		public void method_10(double double_3)
		{
			this.float_4 = Convert.ToSingle(Math.Pow(Math.Cos(this.double_1 = 3.1415926535897931 * double_3 / 180.0), 7.3890560989306495));
			this.method_13();
		}

		public SongEditor()
		{
			this.InitializeComponent();
			this.BackColor = Color.White;
			base.MouseMove += new MouseEventHandler(this.SongEditor_MouseMove);
			base.MouseDown += new MouseEventHandler(this.SongEditor_MouseDown);
			base.MouseWheel += new MouseEventHandler(this.SongEditor_MouseWheel);
			base.Resize += new EventHandler(this.SongEditor_Resize);
			base.Controls.Add(this.vscrollBar_0);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Interval = 20;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			this.timer_0.Start();
		}

		public void method_11(Class362 class362_1)
		{
			this.class362_0 = class362_1;
			class362_1.class239_0[0] = 0;
			this.int_6 = this.class362_0.class239_0[this.class362_0.class239_0.Count - 1];
			this.decimal_0 = this.size_1.Width / this.class362_0.class239_0[1];
			this.method_10(15.0);
			this.string_0 = "expert";
			for (int i = 0; i < this.brush_1.Length; i++)
			{
				this.pen_4[i] = new Pen(this.brush_1[i], (float)this.size_1.Height / 24f);
			}
			this.method_13();
		}

		public void method_12(string string_1)
		{
			SongEditor.Class373 @class = new SongEditor.Class373();
			@class.string_0 = string_1;
			@class.songEditor_0 = this;
			if (this.interface6_0 != null)
			{
				this.interface6_0.Dispose();
			}
			this.interface6_0 = Class170.smethod_0(Enum25.const_2, Class170.smethod_4(@class.string_0));
			ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
		}

		private void method_13()
		{
			if (this.class362_0 == null)
			{
				return;
			}
			this.vscrollBar_0.Height = (this.int_1 = base.Height);
			this.int_0 = (this.vscrollBar_0.Left = base.Width - this.vscrollBar_0.Width);
			this.vscrollBar_0.Top = 0;
			this.size_0.Height = this.int_0 / 2;
			this.size_0.Width = this.size_0.Height / 3;
			this.float_0 = (float)this.size_1.Height + this.float_5 * (float)(this.method_5() ? 4 : 5);
			this.float_3 = (float)this.size_0.Width / (1f - this.float_4);
			if (this.float_3 > (float)this.int_1 * 3f / 4f)
			{
				this.float_3 = (float)this.int_1 * 3f / 4f;
			}
			this.float_1 = (this.method_7() ? Convert.ToSingle(Math.Log(Math.Abs(1.0 - (double)(this.float_3 * (1f - this.float_4)) / (double)this.size_0.Width), (double)this.float_4)) : (((float)this.int_0 - this.float_5 * 2f) / (float)this.size_1.Width));
			this.int_4 = (int)Math.Ceiling((double)this.class362_0.class239_0.Count / (double)this.float_1);
			this.int_3 = (this.method_7() ? Convert.ToInt32((double)this.class362_0.class239_0[1] / this.double_2 * Math.Log(Math.Abs(1.0 - (double)(this.float_3 * (1f - this.float_4)) / (double)this.size_0.Width), (double)this.float_4)) : this.method_15((float)this.int_0 - this.float_5 * 2f));
			this.int_5 = (int)Math.Ceiling((double)this.int_6 / (double)this.int_3);
			this.int_2 = this.int_1 / (int)this.float_0;
			this.vscrollBar_0.Minimum = 0;
			this.vscrollBar_0.SmallChange = 1;
			this.vscrollBar_0.LargeChange = (this.method_7() ? ((int)this.float_1) : this.int_2);
			this.vscrollBar_0.Maximum = (this.method_7() ? (this.class362_0.class239_0.Count * 2 + this.vscrollBar_0.LargeChange) : ((this.method_3() ? this.int_4 : this.int_5) - 1));
			this.vscrollBar_0.Value = (this.method_7() ? (this.vscrollBar_0.Maximum - this.vscrollBar_0.LargeChange) : 0);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			base.Invalidate();
		}

		private void SongEditor_Resize(object sender, EventArgs e)
		{
			this.method_13();
		}

		private void SongEditor_MouseMove(object sender, MouseEventArgs e)
		{
			this.float_2 = (float)e.X - this.float_5;
			if (this.float_2 < 0f)
			{
				this.float_2 = 0f;
				return;
			}
			if (this.float_2 > (float)base.Width - this.float_5 * 2f)
			{
				this.float_2 = (float)base.Width - this.float_5 * 2f;
			}
		}

		private void SongEditor_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2 && e.Button == MouseButtons.Right)
			{
				this.method_6(!this.method_5());
				return;
			}
			if (e.Clicks == 2 && e.Button == MouseButtons.Left)
			{
				this.method_4(!this.method_3());
			}
		}

		private void SongEditor_MouseWheel(object sender, MouseEventArgs e)
		{
			int num = this.vscrollBar_0.Value - e.Delta / SystemInformation.MouseWheelScrollDelta;
			if (this.vscrollBar_0.Maximum - (this.vscrollBar_0.LargeChange - this.vscrollBar_0.SmallChange) >= num && this.vscrollBar_0.Minimum <= num)
			{
				this.vscrollBar_0.Value = num;
			}
		}

		private float method_14(int int_8)
		{
			return Convert.ToSingle(int_8 * this.decimal_0);
		}

		private int method_15(float float_6)
		{
			return Convert.ToInt32((decimal)float_6 / this.decimal_0);
		}

		private int method_16(float float_6)
		{
			int num = (int)Math.Floor((double)float_6);
			if (num + 1 >= this.class362_0.class239_0.Count)
			{
				return this.int_6;
			}
			if (num < 0)
			{
				return 0;
			}
			int num2 = this.class362_0.class239_0[num];
			return num2 + Convert.ToInt32((float_6 - (float)num) * (float)(this.class362_0.class239_0[num + 1] - num2));
		}

		private static bool smethod_0(bool[] bool_5, bool[] bool_6)
		{
			for (int i = 0; i < 5; i++)
			{
				if (bool_5[i] && bool_6[i])
				{
					return false;
				}
			}
			return true;
		}

		private void method_17(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.class362_0.gh3Song_0.fretbar_offset;
			int_9 += this.class362_0.gh3Song_0.fretbar_offset;
			graphics_0.SetClip(new RectangleF(float_6, 0f, (float)this.int_0 - float_6 * 2f, (float)this.int_1));
			int count = this.class362_0.class239_0.Count;
			int num = this.class362_0.class239_0.method_7(int_8);
			int num2 = this.class362_0.class239_0.method_7(int_9);
			int num3 = this.class362_0.class239_0[num];
			float num4 = (num + 1 < count) ? ((float)(int_8 - num3) / (float)(this.class362_0.class239_0[num + 1] - num3)) : 0f;
			int count2 = this.class362_0.class228_0.Count;
			int num5 = this.class362_0.class228_0.method_1(num3);
			int num6 = this.class362_0.class228_0.Values[num5][0];
			int num7 = this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5]);
			int num8 = (count2 > num5 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5 + 1]) : -1;
			float num9 = 0f;
			float y = float_7 + (float)this.size_1.Height;
			for (int i = num; i <= num2; i++)
			{
				int num10 = this.class362_0.class239_0[i];
				if (this.method_3())
				{
					num9 = float_6 + ((float)(i - num) - num4) * (float)this.size_1.Width;
				}
				else
				{
					num9 = float_6 + this.method_14(num10 - int_8);
				}
				if (i - num7 == 0)
				{
					graphics_0.DrawString(string.Concat(num6), this.font_0, this.brush_0, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), this.font_0, this.brush_0, num9 - 4f, float_7 + (float)this.size_1.Height / 2f - 3f);
				}
				if (i == num8)
				{
					num5++;
					num6 = this.class362_0.class228_0.Values[num5][0];
					num7 = this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5 + 1]) : -1);
					graphics_0.DrawString(string.Concat(num6), this.font_0, this.brush_0, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), this.font_0, this.brush_0, num9 - 4f, float_7 + (float)this.size_1.Height / 2f - 3f);
				}
				if (num9 >= float_6)
				{
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? this.pen_0 : this.pen_1, num9, float_7, num9, y);
				}
				if (i + 1 < count)
				{
					if (this.method_3())
					{
						num9 += 0.5f * (float)this.size_1.Width;
					}
					else
					{
						num9 += this.method_14(this.class362_0.class239_0[i + 1] - num10) / 2f;
					}
					if (num9 >= float_6 && num9 <= (float)this.int_0 - float_6)
					{
						graphics_0.DrawLine(this.pen_2, num9, float_7, num9, y);
					}
				}
			}
			float x = (int_9 >= this.int_6) ? num9 : ((float)this.int_0 - float_6);
			for (int j = 1; j < this.int_7; j++)
			{
				graphics_0.DrawLine(this.pen_1, float_6, y = float_7 + (float)(j * this.size_1.Height) / (float)this.int_7, x, y);
			}
			graphics_0.DrawLine(this.pen_0, float_6, float_7, x, float_7);
			graphics_0.DrawLine(this.pen_0, float_6, y = float_7 + (float)this.size_1.Height, x, y);
			graphics_0.ResetClip();
		}

		private void method_18(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.class362_0.gh3Song_0.gem_offset;
			int_9 += this.class362_0.gh3Song_0.gem_offset;
			Track<int, Class364> @class = this.class362_0.dictionary_0.ContainsKey(this.string_0) ? this.class362_0.dictionary_0[this.string_0] : new Track<int, Class364>();
			Track<int, int[]> class2 = this.class362_0.dictionary_1.ContainsKey(this.string_0) ? this.class362_0.dictionary_1[this.string_0] : new Track<int, int[]>();
			int arg_9A_0 = @class.Count;
			int num = @class.method_1(int_8);
			int num2 = @class.method_1(int_9);
			int num3 = @class.Keys[num];
			if (int_8 < this.int_6 && num3 <= int_9)
			{
				int count = this.class362_0.class239_0.Count;
				int num4 = this.class362_0.class239_0.method_7(num3);
				int num5 = this.class362_0.class239_0[num4];
				int num6 = this.class362_0.class239_0[num4 + 1] - num5;
				int num7 = (count > num4 + 1) ? @class.method_2(this.class362_0.class239_0[num4 + 1]) : -1;
				int num8 = this.class362_0.class239_0.method_7(int_8);
				float num9 = (float)(int_8 - this.class362_0.class239_0[num8]) / (float)(this.class362_0.class239_0[num8 + 1] - this.class362_0.class239_0[num8]);
				int count2 = this.class362_0.class228_0.Count;
				int num10 = this.class362_0.class228_0.method_1(num3);
				int num11 = this.class362_0.class228_0.Values[num10][0];
				int num12 = (count2 > num10 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num10 + 1]) : -1;
				int count3 = class2.Count;
				int num13 = class2.method_1(num3);
				int num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				int num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				float num16 = (float)this.size_1.Height / (float)this.int_7;
				float num17 = (float)this.size_1.Height / 15f;
				float num18 = num17 / 1.6f;
				float num19 = num17 * 2f;
				float num20 = num18 * 2f;
				float val = (float)this.int_0 - float_6;
				if (this.method_5())
				{
					float_7 += num16 / 2f;
				}
				for (int i = num; i <= num2; i++)
				{
					int num21 = @class.Keys[i];
					Class364 class3 = @class[num21];
					if (i == num7)
					{
						num4 = this.class362_0.class239_0.method_7(num21);
						num5 = this.class362_0.class239_0[num4];
						num6 = this.class362_0.class239_0[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(this.class362_0.class239_0[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = this.class362_0.class228_0.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					bool flag = this.bool_2 && num14 >= num21;
					float num22;
					float num23;
					if (this.method_3())
					{
						num22 = Math.Max(float_6 + ((float)(num4 - num8) - num9 + (float)(num21 - num5) / (float)num6) * (float)this.size_1.Width, float_6);
						if (class3.int_0 - this.class362_0.int_0 > this.class362_0.int_0)
						{
							num23 = (float)(num21 + class3.int_0 - this.class362_0.int_0);
							int num24 = this.class362_0.class239_0.method_7((int)num23);
							num23 = Math.Min(float_6 + ((float)(num24 - num8) - num9 + (num23 - (float)this.class362_0.class239_0[num24]) / (float)(this.class362_0.class239_0[num24 + 1] - this.class362_0.class239_0[num24])) * (float)this.size_1.Width, val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_6 + this.method_14(num21 - int_8);
						num23 = ((class3.int_0 - this.class362_0.int_0 > this.class362_0.int_0) ? Math.Min(num22 + this.method_14(class3.int_0 - this.class362_0.int_0), val) : -1f);
						num22 = Math.Max(num22, float_6);
					}
					if (num23 == -1f || num23 >= float_6)
					{
						bool flag2 = this.bool_3 && ((i != 0 && SongEditor.smethod_0(@class[@class.Keys[i - 1]].bool_0, class3.bool_0) && (float)(num21 - @class.Keys[i - 1]) <= (float)num11 / 4f * (float)num6 / ((this.class362_0.gh3Song_0.hammer_on == 0f) ? Class362.float_0 : this.class362_0.gh3Song_0.hammer_on)) ^ class3.bool_0[5]);
						for (int j = 0; j < 6; j++)
						{
							if (class3.bool_0[j])
							{
								float num25 = float_7 + num16 * (float)j;
								if (num23 != -1f)
								{
									graphics_0.DrawLine(this.pen_4[j], num22, num25, num23, num25);
									graphics_0.DrawRectangle(this.pen_5, num22, num25 - 1f, num23 - num22, this.pen_4[j].Width);
								}
								if (num != i || num == 0)
								{
									if (flag)
									{
										PointF[] array = new PointF[5];
										for (int k = 0; k < 5; k++)
										{
											array[k] = new PointF(num22 + num19 * (float)Math.Sin((double)k * this.double_0), num25 - num19 * (float)Math.Cos((double)k * this.double_0));
										}
										graphics_0.FillPolygon(this.brush_2, array, FillMode.Winding);
									}
									RectangleF rect = new RectangleF(num22 - num17, num25 - num17, num19, num19);
									graphics_0.FillEllipse(this.brush_1[j], rect);
									graphics_0.DrawEllipse(this.pen_5, rect);
									if (flag2)
									{
										rect = new RectangleF(num22 - num18, num25 - num18, num20, num20);
										graphics_0.FillEllipse(this.brush_3, rect);
										graphics_0.DrawEllipse(this.pen_5, rect);
									}
								}
							}
						}
					}
				}
				return;
			}
		}

		private void method_19(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (this.sbyte_0 == null)
			{
				return;
			}
			float num = float_6;
			float x = num;
			float num2 = 0f;
			int num3 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 * (int_8 / 1000m));
			int num4 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 * (int_9 / 1000m));
			num4 = Math.Min(num4, this.sbyte_0.Length);
			int num5 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 / (this.decimal_0 * 1000m));
			int i = num3;
			for (int j = 0; j < (int)this.interface6_0.imethod_7().short_0; j++)
			{
				while (i < num4)
				{
					float num6 = -128f;
					float num7 = 127f;
					if (this.method_3())
					{
						num5 = this.size_1.Width;
					}
					int num8 = j;
					while (num8 < num5 && num8 + i < num4)
					{
						num6 = Math.Max(num6, (float)this.sbyte_0[num8 + i]);
						num7 = Math.Min(num7, (float)this.sbyte_0[num8 + i]);
						num8 += (int)this.interface6_0.imethod_7().short_0;
					}
					float num9 = (num7 + 128f) * (float)this.size_1.Height / 256f;
					float num10 = (num6 + 128f) * (float)this.size_1.Height / 256f;
					if (num6 != num7)
					{
						if ((double)num5 <= 1E-10)
						{
							return;
						}
						if (num9 == num10)
						{
							if (num2 != 0f)
							{
								graphics_0.DrawLine(this.pen_6, x, float_7 + num2, num, float_7 + num10);
							}
						}
						else
						{
							graphics_0.DrawLine(this.pen_6, num, float_7 + num9, num, float_7 + num10);
						}
					}
					x = num;
					num2 = num10;
					num += 1f;
					i += num5;
				}
				num = float_6;
				x = num;
				num2 = 0f;
				i = num3;
			}
		}

		private void method_20(Graphics graphics_0)
		{
			int num = 0;
			int num2 = 0;
			if (this.method_3())
			{
				int num3 = Math.Min(this.int_2, this.int_4);
				for (int i = 0; i < num3; i++)
				{
					num = this.method_16(this.float_1 * (float)(this.vscrollBar_0.Value + i));
					num2 = this.method_16(this.float_1 * (float)(this.vscrollBar_0.Value + i + 1));
					float num4 = this.float_5 * 2f + this.float_0 * (float)i;
					this.method_17(graphics_0, num, num2, this.float_5, num4);
					this.method_18(graphics_0, num, num2, this.float_5, num4);
				}
			}
			else
			{
				int num5 = Math.Min(this.int_2, this.int_5);
				int j = 0;
				if (this.interface6_0 != null)
				{
					j = (int)this.interface6_0.imethod_0().TotalMilliseconds;
				}
				if (this.method_0() == Enum1.const_1)
				{
					while (j < this.int_3 * this.vscrollBar_0.Value)
					{
						this.vscrollBar_0.Value--;
					}
				}
				for (int k = 0; k < num5; k++)
				{
					num = this.int_3 * (this.vscrollBar_0.Value + k);
					num2 = this.int_3 * (this.vscrollBar_0.Value + k + 1);
					float num4 = this.float_5 * 2f + this.float_0 * (float)k;
					if (this.bool_4)
					{
						this.method_19(graphics_0, num, num2, this.float_5, num4);
					}
					this.method_17(graphics_0, num, num2, this.float_5, num4);
					this.method_18(graphics_0, num, num2, this.float_5, num4);
					if (this.interface6_0 != null && num <= j && j <= num2)
					{
						SmoothingMode smoothingMode = graphics_0.SmoothingMode;
						graphics_0.SmoothingMode = SmoothingMode.None;
						graphics_0.DrawLine(this.pen_5, this.float_5 + this.method_14(j - num), num4 - 5f, this.float_5 + this.method_14(j - num), num4 + (float)this.size_1.Height + 5f);
						graphics_0.SmoothingMode = smoothingMode;
					}
				}
				if (this.method_0() == Enum1.const_1 && j > num2 && this.vscrollBar_0.Value + num5 <= this.vscrollBar_0.Maximum)
				{
					this.vscrollBar_0.Value += num5;
				}
			}
			this.delegate10_0(num, null);
		}

		public void method_21()
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.imethod_3();
			}
		}

		public void method_22()
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.imethod_4();
			}
		}

		public void method_23()
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.imethod_5();
				this.interface6_0.imethod_2(0);
			}
		}

		public bool method_24()
		{
			return this.interface6_0 != null;
		}

		private void method_25(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.class362_0.gh3Song_0.fretbar_offset;
			int_9 += this.class362_0.gh3Song_0.fretbar_offset;
			int count = this.class362_0.class239_0.Count;
			int num = this.class362_0.class239_0.method_7(int_8);
			int num2 = this.class362_0.class239_0.method_7(int_9);
			int num3 = this.class362_0.class239_0[num];
			float num4 = (num + 1 < count) ? ((float)(int_8 - num3) / (float)(this.class362_0.class239_0[num + 1] - num3)) : 0f;
			int count2 = this.class362_0.class228_0.Count;
			int num5 = this.class362_0.class228_0.method_1(num3);
			int num6 = this.class362_0.class228_0.Values[num5][0];
			int num7 = this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5]);
			int num8 = (count2 > num5 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5 + 1]) : -1;
			float num10;
			for (int i = num; i <= num2; i++)
			{
				int num9 = this.class362_0.class239_0[i];
				if (this.method_3())
				{
					num10 = float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, (double)((float)(i - num) - num4))) / (double)(1f - this.float_4));
				}
				else
				{
					num10 = float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, this.double_2 * (double)(num9 - int_8) / (double)this.class362_0.class239_0[1])) / (double)(1f - this.float_4));
				}
				if (i - num7 == 0)
				{
					float num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
					Font font = new Font("Verdana", Math.Max(0f, ((float)this.size_0.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + this.class362_0.class228_0.Values[num5][1], font, this.brush_0, float_6 + (float)this.size_0.Height + 5f - num11, num10 - font.Size);
				}
				if (i == num8)
				{
					num5++;
					num6 = this.class362_0.class228_0.Values[num5][0];
					num7 = this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num5 + 1]) : -1);
					float num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
					Font font2 = new Font("Verdana", Math.Max(0f, ((float)this.size_0.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + this.class362_0.class228_0.Values[num5][1], font2, this.brush_0, float_6 + (float)this.size_0.Height + 5f - num11, num10 - font2.Size);
				}
				if (num10 <= float_7)
				{
					float num11;
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? this.pen_0 : this.pen_1, float_6 + (num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1))), num10, float_6 + (float)this.size_0.Height - num11, num10);
				}
				if (i + 1 < count && i + 1 <= num2)
				{
					if (this.method_3())
					{
						num10 = float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, (double)((float)(i - num) - num4 + 0.5f))) / (double)(1f - this.float_4));
					}
					else
					{
						num10 = float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, this.double_2 * (double)((this.class362_0.class239_0[i + 1] - num9) / 2 + num9 - int_8) / (double)this.class362_0.class239_0[1])) / (double)(1f - this.float_4));
					}
					if (num10 <= float_7 && num10 >= (float)this.int_1 - float_7)
					{
						float num11;
						graphics_0.DrawLine(this.pen_2, float_6 + (num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1))), num10, float_6 + (float)this.size_0.Height - num11, num10);
					}
				}
			}
			num10 = float_7 - this.float_3;
			float num12 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
			float num13 = (float)this.size_0.Height - 2f * num12;
			for (int j = 0; j <= this.int_7; j++)
			{
				graphics_0.DrawLine(this.pen_1, float_6 + (float)(j * this.size_0.Height) / (float)this.int_7, float_7, float_6 + num12 + (float)j * num13 / (float)this.int_7, num10);
			}
		}

		private void method_26(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.class362_0.gh3Song_0.gem_offset;
			int_9 += this.class362_0.gh3Song_0.gem_offset;
			Track<int, Class364> @class = this.class362_0.dictionary_0.ContainsKey(this.string_0) ? this.class362_0.dictionary_0[this.string_0] : new Track<int, Class364>();
			Track<int, int[]> class2 = this.class362_0.dictionary_1.ContainsKey(this.string_0) ? this.class362_0.dictionary_1[this.string_0] : new Track<int, int[]>();
			if (@class.Count == 0)
			{
				return;
			}
			int arg_A3_0 = @class.Count;
			int num = @class.method_1(int_8);
			int num2 = @class.method_1(int_9);
			int num3 = @class.Keys[num];
			if (int_8 < this.int_6 && num3 <= int_9)
			{
				int count = this.class362_0.class239_0.Count;
				int num4 = this.class362_0.class239_0.method_7(num3);
				int num5 = this.class362_0.class239_0[num4];
				int num6 = this.class362_0.class239_0[num4 + 1] - num5;
				int num7 = (count > num4 + 1) ? @class.method_2(this.class362_0.class239_0[num4 + 1]) : -1;
				int num8 = this.class362_0.class239_0.method_7(int_8);
				this.class362_0.class239_0.method_7(int_9);
				float num9 = (float)(int_8 - this.class362_0.class239_0[num8]) / (float)(this.class362_0.class239_0[num8 + 1] - this.class362_0.class239_0[num8]);
				int count2 = this.class362_0.class228_0.Count;
				int num10 = this.class362_0.class228_0.method_1(num3);
				int num11 = this.class362_0.class228_0.Values[num10][0];
				int num12 = (count2 > num10 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num10 + 1]) : -1;
				int count3 = class2.Count;
				int num13 = class2.method_1(num3);
				int num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				int num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				float num16 = (float)this.size_0.Height / (float)this.int_7;
				float num17 = (float)this.size_0.Height / 15f;
				float num18 = num17 / 1.6f;
				float num19 = num17 * 2f;
				float num20 = num18 * 2f;
				float val = float_7 - this.float_3;
				for (int i = num; i <= num2; i++)
				{
					int num21 = @class.Keys[i];
					Class364 class3 = @class[num21];
					if (i == num7)
					{
						num4 = this.class362_0.class239_0.method_7(num21);
						num5 = this.class362_0.class239_0[num4];
						num6 = this.class362_0.class239_0[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(this.class362_0.class239_0[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = this.class362_0.class228_0.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? this.class362_0.class239_0.method_7(this.class362_0.class228_0.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					bool flag = this.bool_2 && num14 >= num21;
					float num22;
					float num23;
					if (this.method_3())
					{
						num22 = Math.Min(float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, (double)((float)(num4 - num8) - num9 + (float)(num21 - num5) / (float)num6))) / (double)(1f - this.float_4)), float_7);
						if (class3.int_0 - this.class362_0.int_0 > this.class362_0.int_0)
						{
							num23 = (float)(num21 + class3.int_0 - this.class362_0.int_0);
							int num24 = this.class362_0.class239_0.method_7((int)num23);
							num23 = Math.Max(float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, (double)((float)(num24 - num8) - num9 + (num23 - (float)this.class362_0.class239_0[num24]) / (float)(this.class362_0.class239_0[num24 + 1] - this.class362_0.class239_0[num24])))) / (double)(1f - this.float_4)), val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, this.double_2 * (double)(num21 - int_8) / (double)this.class362_0.class239_0[1])) / (double)(1f - this.float_4));
						num23 = ((class3.int_0 - this.class362_0.int_0 > this.class362_0.int_0) ? Math.Max(float_7 - Convert.ToSingle((double)this.size_0.Width * (1.0 - Math.Pow((double)this.float_4, this.double_2 * (double)(num21 - int_8 + class3.int_0 - this.class362_0.int_0) / (double)this.class362_0.class239_0[1])) / (double)(1f - this.float_4)), val) : -1f);
						num22 = Math.Min(num22, float_7);
					}
					if (num23 == -1f || num23 <= float_7)
					{
						bool flag2 = this.bool_3 && ((i != 0 && SongEditor.smethod_0(@class[@class.Keys[i - 1]].bool_0, class3.bool_0) && (float)(num21 - @class.Keys[i - 1]) <= (float)num11 / 4f * (float)num6 / ((this.class362_0.gh3Song_0.hammer_on == 0f) ? Class362.float_0 : this.class362_0.gh3Song_0.hammer_on)) ^ class3.bool_0[5]);
						float num25 = float_6 + Convert.ToSingle((double)(float_7 - num22) * Math.Tan(this.double_1));
						num16 = ((float)this.size_0.Height - 2f * (num25 - float_6)) / (float)this.int_7;
						float num26 = float_6 + Convert.ToSingle((double)(float_7 - num23) * Math.Tan(this.double_1));
						float num27 = ((float)this.size_0.Height - 2f * (num26 - float_6)) / (float)this.int_7;
						num17 = ((float)this.size_0.Height - 2f * (num25 - float_6)) / 15f;
						num18 = num17 / 1.6f;
						num19 = num17 * 2f;
						num20 = num18 * 2f;
						float num28 = ((float)this.size_0.Height - 2f * (num25 - float_6)) / 32f;
						float num29 = ((float)this.size_0.Height - 2f * (num26 - float_6)) / 32f;
						if (this.method_5())
						{
							num25 += num16 / 2f;
							num26 += num27 / 2f;
						}
						num25 -= num16;
						num26 -= num27;
						for (int j = 0; j < 6; j++)
						{
							num25 += num16;
							num26 += num27;
							if (class3.bool_0[j])
							{
								if (num23 != -1f)
								{
									PointF[] points = new PointF[]
									{
										new PointF(num25 - num28, num22),
										new PointF(num26 - num29, num23),
										new PointF(num26 + num29, num23),
										new PointF(num25 + num28, num22)
									};
									graphics_0.FillPolygon(this.brush_1[j], points);
								}
								if (num != i || num == 0)
								{
									if (flag)
									{
										PointF[] array = new PointF[5];
										for (int k = 0; k < 5; k++)
										{
											array[k] = new PointF(num25 - num19 * (float)Math.Sin((double)k * this.double_0), num22 + num19 * this.float_4 * (float)Math.Cos((double)k * this.double_0));
										}
										graphics_0.FillPolygon(this.brush_2, array, FillMode.Winding);
									}
									RectangleF rect = new RectangleF(num25 - num17, num22 - num17 * this.float_4, num19, num19 * this.float_4);
									graphics_0.FillEllipse(this.brush_1[j], rect);
									graphics_0.DrawEllipse(this.pen_5, rect);
									if (flag2)
									{
										rect = new RectangleF(num25 - num18, num22 - num18 * this.float_4, num20, num20 * this.float_4);
										graphics_0.FillEllipse(this.brush_3, rect);
										graphics_0.DrawEllipse(this.pen_5, rect);
									}
								}
							}
						}
					}
				}
				return;
			}
		}

		private void method_27(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (this.sbyte_0 == null)
			{
				return;
			}
			float num = 0f;
			float num2 = float_7;
			float num3 = num2;
			int num4 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 * (int_8 / 1000m));
			int num5 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 * (int_9 / 1000m));
			num5 = Math.Min(num5, this.sbyte_0.Length);
			decimal d = 0m;
			int i = num4;
			for (int j = 0; j < (int)this.interface6_0.imethod_7().short_0; j++)
			{
				while (i < num5)
				{
					float num6 = -128f;
					float num7 = 127f;
					decimal num8 = (decimal)((double)this.class362_0.class239_0[1] / this.double_2 * Math.Log(Math.Abs(1.0 - (double)((float_7 - num2 + 1f) * (1f - this.float_4)) / (double)this.size_0.Width), (double)this.float_4));
					int num9 = Convert.ToInt32(this.interface6_0.imethod_7().int_0 * (int)this.interface6_0.imethod_7().short_0 * ((num8 - d) / 1000m));
					d = num8;
					int num10 = j;
					while (num10 < num9 && num10 + i < num5)
					{
						num6 = Math.Max(num6, (float)this.sbyte_0[num10 + i]);
						num7 = Math.Min(num7, (float)this.sbyte_0[num10 + i]);
						num10 += (int)this.interface6_0.imethod_7().short_0;
					}
					float num11 = Convert.ToSingle((double)(float_7 - num2) * Math.Tan(this.double_1));
					float num12 = (float)this.size_0.Height - 2f * num11;
					if (num7 != num6)
					{
						float num13 = (num7 + 128f) * num12 / 256f;
						float num14 = (num6 + 128f) * num12 / 256f;
						if ((double)num9 <= 1E-10)
						{
							return;
						}
						if (num13 == num14)
						{
							if (num3 != 0f)
							{
								graphics_0.DrawLine(this.pen_6, float_6 + num11 + num, num3, float_6 + num11 + num14, num2);
							}
						}
						else
						{
							graphics_0.DrawLine(this.pen_6, float_6 + num11 + num13, num2, float_6 + num11 + num14, num2);
						}
						num = num14;
					}
					else
					{
						num = num12 / 2f;
					}
					num3 = num2;
					num2 -= 1f;
					i += num9;
				}
				num = 0f;
				num2 = float_7;
				num3 = num2;
				i = num4;
				d = 0m;
			}
		}

		private void method_28(Graphics graphics_0)
		{
			float num = this.float_5 * 2f;
			int num2 = this.method_16((float)(this.vscrollBar_0.Maximum - this.vscrollBar_0.LargeChange - this.vscrollBar_0.Value) / 2f);
			if (this.method_3())
			{
				int int_ = this.method_16((float)(this.vscrollBar_0.Maximum - this.vscrollBar_0.LargeChange - this.vscrollBar_0.Value) / 2f + this.float_1);
				this.method_25(graphics_0, num2, int_, (float)this.int_0 / 4f, (float)this.int_1 - num);
				this.method_26(graphics_0, num2, int_, (float)this.int_0 / 4f, (float)this.int_1 - num);
			}
			else
			{
				if (this.interface6_0 != null && this.method_0() == Enum1.const_1)
				{
					num2 = (int)this.interface6_0.imethod_0().TotalMilliseconds;
				}
				int int_ = num2 + this.int_3;
				if (this.bool_4)
				{
					this.method_27(graphics_0, num2, int_, (float)this.int_0 / 4f, (float)this.int_1 - num);
				}
				this.method_25(graphics_0, num2, int_, (float)this.int_0 / 4f, (float)this.int_1 - num);
				this.method_26(graphics_0, num2, int_, (float)this.int_0 / 4f, (float)this.int_1 - num);
			}
			this.delegate10_0(num2, null);
		}

		public void method_29(SongEditor.Delegate10 delegate10_1)
		{
			SongEditor.Delegate10 @delegate = this.delegate10_0;
			SongEditor.Delegate10 delegate2;
			do
			{
				delegate2 = @delegate;
				SongEditor.Delegate10 value = (SongEditor.Delegate10)Delegate.Combine(delegate2, delegate10_1);
				@delegate = Interlocked.CompareExchange<SongEditor.Delegate10>(ref this.delegate10_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

        protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (this.class362_0 == null)
			{
				return;
			}
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this.bool_1)
			{
				this.method_28(graphics);
				return;
			}
			this.method_20(graphics);
		}

		public new void Dispose()
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.Dispose();
			}
			base.Dispose();
		}
	}
}
