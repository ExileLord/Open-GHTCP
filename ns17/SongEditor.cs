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
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ns17
{
	public class SongEditor : UserControl, IDisposable
	{
		public delegate void Delegate10(object sender, EventArgs e);

		[CompilerGenerated]
		private class SongData
		{
			public SongEditor songEditor_0;

			public string fileName;

			public void LoadAudioData(object object_0)
			{
				using (GenericAudioStream stream = AudioManager.getAudioStream(this.fileName))
				{
                    this.songEditor_0.AudioData = new sbyte[(ulong)stream.vmethod_1().uint_0 * (ulong)((long)stream.vmethod_1().method_0())];
					float[] array = new float[4096];
					int num;
					for (int i = 0; i < this.songEditor_0.AudioData.Length; i += num)
					{
						if (i + array.Length < this.songEditor_0.AudioData.Length)
						{
							num = stream.vmethod_4(array, 0, array.Length);
						}
						else
						{
							num = stream.vmethod_4(array, 0, this.songEditor_0.AudioData.Length - i);
						}
						for (int j = 0; j < num; j++)
						{
							this.songEditor_0.AudioData[i + j] = Class11.smethod_19(array[j]);
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

		private System.Windows.Forms.Timer timer;

		private VScrollBar VerticalScrollBar = new VScrollBar();

		private int Width;

		private int Height;

		private int int_2;

		private int UsedForCalculatingLastFretbar;

		private int SomeFretbarValue;

		private int LastFretbarValue;

		private float float_0;

		private float FretboardAngleFloat;

		private float float_2;

		private int LastFretbar;

		private QBCParser Chart;

		private PlayableAudio Audio;

		private sbyte[] AudioData;

		private Pen Pen_Black = Pens.Black;

		private Pen Pen_Gray = Pens.Gray;

		private Pen Pen_LightGray = Pens.LightGray;

		private bool DoubleFretbarWidth;

		private int NumberOfNoteLines = 4;

		public decimal FretbarWidth;

		private Brush Brush_GrayText = SystemBrushes.GrayText;

		private Font Font_Verdana = new Font("Verdana", 24f);

		private Brush[] NoteBrush = new Brush[]
		{
			Brushes.Green,
			Brushes.Red,
			Brushes.Yellow,
			Brushes.Blue,
			Brushes.Orange,
			Brushes.LightGray
		};

		private Pen[] NotePen = new Pen[]
		{
			Pens.Green,
			Pens.Red,
			Pens.Yellow,
			Pens.Blue,
			Pens.Orange,
			Pens.LightGray
		};

		private Pen[] pen_4 = new Pen[6];

		private Brush Brush_Black = Brushes.Black;

		private Brush Brush_White = Brushes.White;

		private Pen Pen_Black2 = Pens.Black;

		private Pen Pen_TransparentBlue = new Pen(Color.FromArgb(30, Color.Blue));

		private double double_0 = 2.5132741228718345;

		private bool GamemodeView = true;

		private Size Editor_Size = new Size(200, 600);

		private float float_3;

		private double double_1;

		private float FretboardAngle;

		public string Difficulty;

		public float float_5 = 10f;

		public Size size_1 = new Size(20, 60);

		public bool LoadStarpowerTextures = true;

		public bool LoadHopoTextures = true;

		public bool ShowAudioOnFretboard = true;

		private double Hyperspeed = 1.0;

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

		public AudioStatus GetAudioStatus()
		{
			if (this.Audio == null)
			{
				return AudioStatus.ShouldStopAudio;
			}
			return this.Audio.GetStatus();
		}

        public void SetBeatSize(int BeatSize)
        {
            if (this.Chart == null)
            {
                return;
            }
            this.size_1.Width = BeatSize;
            this.FretbarWidth = (decimal)this.size_1.Width / (decimal)this.Chart.FretbarList[1];
			this.RedrawFretboard();
		}

		public void SetOffset(int offset)
		{
            if (this.Chart == null)
            {
                return;
            }
            GH3Song ghSong = this.Chart.gh3Song_0;
			this.Chart.gh3Song_0.gem_offset = offset;
			ghSong.fretbar_offset = offset;
			this.RedrawFretboard();
		}

		public bool ShouldDoubleFretbarWidth()
		{
			return this.DoubleFretbarWidth;
		}

		public void SetDoubleFretbarWidth(bool bool_5)
		{
			ScrollBar arg_22_0 = this.VerticalScrollBar;
			this.DoubleFretbarWidth = bool_5;
			arg_22_0.Maximum = (bool_5 ? this.SomeFretbarValue : this.LastFretbarValue) - 1;
			this.RedrawFretboard();
		}

		public bool Has5NoteLines()
		{
			return this.NumberOfNoteLines == 5;
		}

		public void Set5NoteLines(bool bool_5)
		{
			this.NumberOfNoteLines = (bool_5 ? 5 : 4);
		}

		public bool IsGamemodeView()
		{
			return this.GamemodeView;
		}

		public void SetGamemodeView(bool isGamemode)
		{
			this.GamemodeView = isGamemode;
			this.RedrawFretboard();
		}

		public void SetHyperspeed(double hyperspeed)
		{
			this.Hyperspeed = hyperspeed;
			this.RedrawFretboard();
		}

		public void SetFretboardAngle(double double_3)
		{
			this.FretboardAngle = Convert.ToSingle(Math.Pow(Math.Cos(this.double_1 = 3.1415926535897932 * double_3 / 180.0), 7.3890560989306495));
			this.RedrawFretboard();
		}

		public SongEditor()
		{
			this.InitializeComponent();
			this.BackColor = Color.White;
			base.MouseMove += new MouseEventHandler(this.SongEditor_MouseMove);
			base.MouseDown += new MouseEventHandler(this.SongEditor_MouseDown);
			base.MouseWheel += new MouseEventHandler(this.SongEditor_MouseWheel);
			base.Resize += new EventHandler(this.SongEditor_Resize);
			base.Controls.Add(this.VerticalScrollBar);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.timer = new System.Windows.Forms.Timer();
			this.timer.Interval = 20;
			this.timer.Tick += new EventHandler(this.timer_0_Tick);
			this.timer.Start();
		}

		public void LoadChart(QBCParser chartFile)
		{
			this.Chart = chartFile;
			chartFile.FretbarList[0] = 0;
			this.LastFretbar = this.Chart.FretbarList[this.Chart.FretbarList.Count - 1];
            this.FretbarWidth = (decimal)this.size_1.Width / (decimal)this.Chart.FretbarList[1];
            this.SetFretboardAngle(15.0);
			this.Difficulty = "expert";
			for (int i = 0; i < this.NoteBrush.Length; i++)
			{
				this.pen_4[i] = new Pen(this.NoteBrush[i], (float)this.size_1.Height / 24f);
			}
            this.RedrawFretboard();
		}

        public void LoadAudio(string fileName)
        {
            SongEditor.SongData songData = new SongEditor.SongData();
            songData.fileName = fileName;
            songData.songEditor_0 = this;
            if (this.Audio != null)
            {
                this.Audio.Dispose();
            }
            GenericAudioStream audioStream = AudioManager.getAudioStream(songData.fileName);
            if (audioStream == null)
            {
                return;
            }
            this.Audio = AudioManager.LoadPlayableAudio(Enum25.const_2, audioStream);
            ThreadPool.QueueUserWorkItem(new WaitCallback(songData.LoadAudioData));
        }

		private void RedrawFretboard()
		{
			if (this.Chart == null)
			{
				return;
			}
			this.VerticalScrollBar.Height = (this.Height = base.Height);
			this.Width = (this.VerticalScrollBar.Left = base.Width - this.VerticalScrollBar.Width);
			this.VerticalScrollBar.Top = 0;
			this.Editor_Size.Height = this.Width / 2;
			this.Editor_Size.Width = this.Editor_Size.Height / 3;
			this.float_0 = (float)this.size_1.Height + this.float_5 * (float)(this.Has5NoteLines() ? 4 : 5);
			this.float_3 = (float)this.Editor_Size.Width / (1f - this.FretboardAngle);
			if (this.float_3 > (float)this.Height * 3f / 4f)
			{
				this.float_3 = (float)this.Height * 3f / 4f;
			}
			this.FretboardAngleFloat = (this.IsGamemodeView() ? Convert.ToSingle(Math.Log(Math.Abs(1.0 - (double)(this.float_3 * (1f - this.FretboardAngle)) / (double)this.Editor_Size.Width), (double)this.FretboardAngle)) : (((float)this.Width - this.float_5 * 2f) / (float)this.size_1.Width));
			this.SomeFretbarValue = (int)Math.Ceiling((double)this.Chart.FretbarList.Count / (double)this.FretboardAngleFloat);
            this.UsedForCalculatingLastFretbar = (this.IsGamemodeView() ? Convert.ToInt32((double)this.Chart.FretbarList[1] / this.Hyperspeed * Math.Log(Math.Abs(1.0 - (double)(this.float_3 * (1f - this.FretboardAngle)) / (double)this.Editor_Size.Width), (double)this.FretboardAngle)) : this.method_15((float)this.Width - this.float_5 * 2f));
            this.LastFretbarValue = (int)Math.Ceiling((double)this.LastFretbar / (double)this.UsedForCalculatingLastFretbar);
			this.int_2 = this.Height / (int)this.float_0;
			this.VerticalScrollBar.Minimum = 0;
			this.VerticalScrollBar.SmallChange = 1;
            this.VerticalScrollBar.LargeChange = (this.IsGamemodeView() ? ((int)this.FretboardAngleFloat) : this.int_2);
            this.VerticalScrollBar.Maximum = (this.IsGamemodeView() ? (this.Chart.FretbarList.Count * 2 + this.VerticalScrollBar.LargeChange) : ((this.ShouldDoubleFretbarWidth() ? this.SomeFretbarValue : this.LastFretbarValue) - 1));
            this.VerticalScrollBar.Value = (this.IsGamemodeView() ? (this.VerticalScrollBar.Maximum - this.VerticalScrollBar.LargeChange) : 0);
        }

		private void timer_0_Tick(object sender, EventArgs e)
		{
			base.Invalidate();
		}

		private void SongEditor_Resize(object sender, EventArgs e)
		{
			this.RedrawFretboard();
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
				this.Set5NoteLines(!this.Has5NoteLines());
				return;
			}
			if (e.Clicks == 2 && e.Button == MouseButtons.Left)
			{
				this.SetDoubleFretbarWidth(!this.ShouldDoubleFretbarWidth());
			}
		}

		private void SongEditor_MouseWheel(object sender, MouseEventArgs e)
		{
			int num = this.VerticalScrollBar.Value - e.Delta / SystemInformation.MouseWheelScrollDelta;
			if (this.VerticalScrollBar.Maximum - (this.VerticalScrollBar.LargeChange - this.VerticalScrollBar.SmallChange) >= num && this.VerticalScrollBar.Minimum <= num)
			{
				this.VerticalScrollBar.Value = num;
			}
		}

		private float method_14(int int_8)
		{
			return Convert.ToSingle(int_8 * this.FretbarWidth);
		}

		private int method_15(float float_6)
		{
			return Convert.ToInt32((decimal)float_6 / this.FretbarWidth);
		}

		private int method_16(float float_6)
		{
			int num = (int)Math.Floor((double)float_6);
			if (num + 1 >= this.Chart.FretbarList.Count)
			{
				return this.LastFretbar;
			}
			if (num < 0)
			{
				return 0;
			}
			int num2 = this.Chart.FretbarList[num];
			return num2 + Convert.ToInt32((float_6 - (float)num) * (float)(this.Chart.FretbarList[num + 1] - num2));
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
			int_8 += this.Chart.gh3Song_0.fretbar_offset;
			int_9 += this.Chart.gh3Song_0.fretbar_offset;
			graphics_0.SetClip(new RectangleF(float_6, 0f, (float)this.Width - float_6 * 2f, (float)this.Height));
			int count = this.Chart.FretbarList.Count;
			int num = this.Chart.FretbarList.method_7(int_8);
			int num2 = this.Chart.FretbarList.method_7(int_9);
			int num3 = this.Chart.FretbarList[num];
			float num4 = (num + 1 < count) ? ((float)(int_8 - num3) / (float)(this.Chart.FretbarList[num + 1] - num3)) : 0f;
			int count2 = this.Chart.tsList.Count;
			int num5 = this.Chart.tsList.method_1(num3);
			int num6 = this.Chart.tsList.Values[num5][0];
			int num7 = this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5]);
			int num8 = (count2 > num5 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5 + 1]) : -1;
			float num9 = 0f;
			float y = float_7 + (float)this.size_1.Height;
			for (int i = num; i <= num2; i++)
			{
				int num10 = this.Chart.FretbarList[i];
				if (this.ShouldDoubleFretbarWidth())
				{
					num9 = float_6 + ((float)(i - num) - num4) * (float)this.size_1.Width;
				}
				else
				{
					num9 = float_6 + this.method_14(num10 - int_8);
				}
				if (i - num7 == 0)
				{
					graphics_0.DrawString(string.Concat(num6), this.Font_Verdana, this.Brush_GrayText, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), this.Font_Verdana, this.Brush_GrayText, num9 - 4f, float_7 + (float)this.size_1.Height / 2f - 3f);
				}
				if (i == num8)
				{
					num5++;
					num6 = this.Chart.tsList.Values[num5][0];
					num7 = this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5 + 1]) : -1);
					graphics_0.DrawString(string.Concat(num6), this.Font_Verdana, this.Brush_GrayText, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), this.Font_Verdana, this.Brush_GrayText, num9 - 4f, float_7 + (float)this.size_1.Height / 2f - 3f);
				}
				if (num9 >= float_6)
				{
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? this.Pen_Black : this.Pen_Gray, num9, float_7, num9, y);
				}
				if (i + 1 < count)
				{
					if (this.ShouldDoubleFretbarWidth())
					{
						num9 += 0.5f * (float)this.size_1.Width;
					}
					else
					{
						num9 += this.method_14(this.Chart.FretbarList[i + 1] - num10) / 2f;
					}
					if (num9 >= float_6 && num9 <= (float)this.Width - float_6)
					{
						graphics_0.DrawLine(this.Pen_LightGray, num9, float_7, num9, y);
					}
				}
			}
			float x = (int_9 >= this.LastFretbar) ? num9 : ((float)this.Width - float_6);
			for (int j = 1; j < this.NumberOfNoteLines; j++)
			{
				graphics_0.DrawLine(this.Pen_Gray, float_6, y = float_7 + (float)(j * this.size_1.Height) / (float)this.NumberOfNoteLines, x, y);
			}
			graphics_0.DrawLine(this.Pen_Black, float_6, float_7, x, float_7);
			graphics_0.DrawLine(this.Pen_Black, float_6, y = float_7 + (float)this.size_1.Height, x, y);
			graphics_0.ResetClip();
		}

		private void DrawFlatViewNotes(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.Chart.gh3Song_0.gem_offset;
			int_9 += this.Chart.gh3Song_0.gem_offset;
			Track<int, NotesAtOffset> @class = this.Chart.noteList.ContainsKey(this.Difficulty) ? this.Chart.noteList[this.Difficulty] : new Track<int, NotesAtOffset>();
			Track<int, int[]> class2 = this.Chart.spList.ContainsKey(this.Difficulty) ? this.Chart.spList[this.Difficulty] : new Track<int, int[]>();
			int arg_9A_0 = @class.Count;
			int num = @class.method_1(int_8);
			int num2 = @class.method_1(int_9);
			int num3 = @class.Keys[num];
			if (int_8 < this.LastFretbar && num3 <= int_9)
			{
				int count = this.Chart.FretbarList.Count;
				int num4 = this.Chart.FretbarList.method_7(num3);
				int num5 = this.Chart.FretbarList[num4];
				int num6 = this.Chart.FretbarList[num4 + 1] - num5;
				int num7 = (count > num4 + 1) ? @class.method_2(this.Chart.FretbarList[num4 + 1]) : -1;
				int num8 = this.Chart.FretbarList.method_7(int_8);
				float num9 = (float)(int_8 - this.Chart.FretbarList[num8]) / (float)(this.Chart.FretbarList[num8 + 1] - this.Chart.FretbarList[num8]);
				int count2 = this.Chart.tsList.Count;
				int num10 = this.Chart.tsList.method_1(num3);
				int num11 = this.Chart.tsList.Values[num10][0];
				int num12 = (count2 > num10 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num10 + 1]) : -1;
				int count3 = class2.Count;
				int num13 = class2.method_1(num3);
				int num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				int num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				float num16 = (float)this.size_1.Height / (float)this.NumberOfNoteLines;
				float num17 = (float)this.size_1.Height / 15f;
				float num18 = num17 / 1.6f;
				float num19 = num17 * 2f;
				float num20 = num18 * 2f;
				float val = (float)this.Width - float_6;
				if (this.Has5NoteLines())
				{
					float_7 += num16 / 2f;
				}
				for (int i = num; i <= num2; i++)
				{
					int num21 = @class.Keys[i];
					NotesAtOffset class3 = @class[num21];
					if (i == num7)
					{
						num4 = this.Chart.FretbarList.method_7(num21);
						num5 = this.Chart.FretbarList[num4];
						num6 = this.Chart.FretbarList[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(this.Chart.FretbarList[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = this.Chart.tsList.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					bool ShowDrawSP = this.LoadStarpowerTextures && num14 >= num21;
					float num22;
					float num23;
					if (this.ShouldDoubleFretbarWidth())
					{
						num22 = Math.Max(float_6 + ((float)(num4 - num8) - num9 + (float)(num21 - num5) / (float)num6) * (float)this.size_1.Width, float_6);
						if (class3.sustainLength - this.Chart.int_0 > this.Chart.int_0)
						{
							num23 = (float)(num21 + class3.sustainLength - this.Chart.int_0);
							int num24 = this.Chart.FretbarList.method_7((int)num23);
							num23 = Math.Min(float_6 + ((float)(num24 - num8) - num9 + (num23 - (float)this.Chart.FretbarList[num24]) / (float)(this.Chart.FretbarList[num24 + 1] - this.Chart.FretbarList[num24])) * (float)this.size_1.Width, val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_6 + this.method_14(num21 - int_8);
						num23 = ((class3.sustainLength - this.Chart.int_0 > this.Chart.int_0) ? Math.Min(num22 + this.method_14(class3.sustainLength - this.Chart.int_0), val) : -1f);
						num22 = Math.Max(num22, float_6);
					}
					if (num23 == -1f || num23 >= float_6)
					{
						bool ShouldDrawHopo = this.LoadHopoTextures && ((i != 0 && SongEditor.smethod_0(@class[@class.Keys[i - 1]].noteValues, class3.noteValues) && (float)(num21 - @class.Keys[i - 1]) <= (float)num11 / 4f * (float)num6 / ((this.Chart.gh3Song_0.hammer_on == 0f) ? QBCParser.float_0 : this.Chart.gh3Song_0.hammer_on)) ^ class3.noteValues[5]);
						for (int j = 0; j < 6; j++)
						{
							if (class3.noteValues[j])
							{
								float num25 = float_7 + num16 * (float)j;
								if (num23 != -1f)
								{
									graphics_0.DrawLine(this.pen_4[j], num22, num25, num23, num25);
									graphics_0.DrawRectangle(this.Pen_Black2, num22, num25 - 1f, num23 - num22, this.pen_4[j].Width);
								}
								if (num != i || num == 0)
								{
									if (ShowDrawSP)
									{
										PointF[] array = new PointF[5];
										for (int k = 0; k < 5; k++)
										{
											array[k] = new PointF(num22 + num19 * (float)Math.Sin((double)k * this.double_0), num25 - num19 * (float)Math.Cos((double)k * this.double_0));
										}
										graphics_0.FillPolygon(this.Brush_Black, array, FillMode.Winding);
									}
									RectangleF rect = new RectangleF(num22 - num17, num25 - num17, num19, num19);
									graphics_0.FillEllipse(this.NoteBrush[j], rect);
									graphics_0.DrawEllipse(this.Pen_Black2, rect);
									if (ShouldDrawHopo)
									{
										rect = new RectangleF(num22 - num18, num25 - num18, num20, num20);
										graphics_0.FillEllipse(this.Brush_White, rect);
										graphics_0.DrawEllipse(this.Pen_Black2, rect);
									}
								}
							}
						}
					}
				}
				return;
			}
		}

		private void DrawAudio(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (this.AudioData == null)
			{
				return;
			}
			float num = float_6;
			float x = num;
			float num2 = 0f;
			int num3 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 * (int_8 / 1000m));
			int num4 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 * (int_9 / 1000m));
			num4 = Math.Min(num4, this.AudioData.Length);
			int num5 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 / (this.FretbarWidth * 1000m));
			int i = num3;
			for (int j = 0; j < (int)this.Audio.GetWaveFormat().short_0; j++)
			{
				while (i < num4)
				{
					float num6 = -128f;
					float num7 = 127f;
					if (this.ShouldDoubleFretbarWidth())
					{
						num5 = this.size_1.Width;
					}
					int num8 = j;
					while (num8 < num5 && num8 + i < num4)
					{
						num6 = Math.Max(num6, (float)this.AudioData[num8 + i]);
						num7 = Math.Min(num7, (float)this.AudioData[num8 + i]);
						num8 += (int)this.Audio.GetWaveFormat().short_0;
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
								graphics_0.DrawLine(this.Pen_TransparentBlue, x, float_7 + num2, num, float_7 + num10);
							}
						}
						else
						{
							graphics_0.DrawLine(this.Pen_TransparentBlue, num, float_7 + num9, num, float_7 + num10);
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

		private void DrawFlatView(Graphics graphics_0)
		{
			int num = 0;
			int num2 = 0;
			if (this.ShouldDoubleFretbarWidth())
			{
				int num3 = Math.Min(this.int_2, this.SomeFretbarValue);
				for (int i = 0; i < num3; i++)
				{
					num = this.method_16(this.FretboardAngleFloat * (float)(this.VerticalScrollBar.Value + i));
					num2 = this.method_16(this.FretboardAngleFloat * (float)(this.VerticalScrollBar.Value + i + 1));
					float num4 = this.float_5 * 2f + this.float_0 * (float)i;
					this.method_17(graphics_0, num, num2, this.float_5, num4);
					this.DrawFlatViewNotes(graphics_0, num, num2, this.float_5, num4);
				}
			}
			else
			{
				int num5 = Math.Min(this.int_2, this.LastFretbarValue);
				int j = 0;
				if (this.Audio != null)
				{
					j = (int)this.Audio.AudioLength().TotalMilliseconds;
				}
				if (this.GetAudioStatus() == AudioStatus.ShouldStartAudio)
				{
					while (j < this.UsedForCalculatingLastFretbar * this.VerticalScrollBar.Value)
					{
						this.VerticalScrollBar.Value--;
					}
				}
				for (int k = 0; k < num5; k++)
				{
					num = this.UsedForCalculatingLastFretbar * (this.VerticalScrollBar.Value + k);
					num2 = this.UsedForCalculatingLastFretbar * (this.VerticalScrollBar.Value + k + 1);
					float num4 = this.float_5 * 2f + this.float_0 * (float)k;
					if (this.ShowAudioOnFretboard)
					{
						this.DrawAudio(graphics_0, num, num2, this.float_5, num4);
					}
					this.method_17(graphics_0, num, num2, this.float_5, num4);
					this.DrawFlatViewNotes(graphics_0, num, num2, this.float_5, num4);
					if (this.Audio != null && num <= j && j <= num2)
					{
						SmoothingMode smoothingMode = graphics_0.SmoothingMode;
						graphics_0.SmoothingMode = SmoothingMode.None;
						graphics_0.DrawLine(this.Pen_Black2, this.float_5 + this.method_14(j - num), num4 - 5f, this.float_5 + this.method_14(j - num), num4 + (float)this.size_1.Height + 5f);
						graphics_0.SmoothingMode = smoothingMode;
					}
				}
				if (this.GetAudioStatus() == AudioStatus.ShouldStartAudio && j > num2 && this.VerticalScrollBar.Value + num5 <= this.VerticalScrollBar.Maximum)
				{
					this.VerticalScrollBar.Value += num5;
				}
			}
			this.delegate10_0(num, null);
		}

		public void DifferentStartPlaying()
		{
			if (this.Audio != null)
			{
				this.Audio.DifferentStartPlaying();
			}
		}

		public void StartPlaying()
		{
			if (this.Audio != null)
			{
				this.Audio.StartPlaying();
			}
		}

		public void StopAudio()
		{
			if (this.Audio != null)
			{
				this.Audio.StopPlaying();
				this.Audio.SetStartingTimeBasedOnSomeValue(0);
			}
		}

		public bool AudioLoaded()
		{
			return this.Audio != null;
		}

		private void method_25(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.Chart.gh3Song_0.fretbar_offset;
			int_9 += this.Chart.gh3Song_0.fretbar_offset;
			int count = this.Chart.FretbarList.Count;
			int num = this.Chart.FretbarList.method_7(int_8);
			int num2 = this.Chart.FretbarList.method_7(int_9);
			int num3 = this.Chart.FretbarList[num];
			float num4 = (num + 1 < count) ? ((float)(int_8 - num3) / (float)(this.Chart.FretbarList[num + 1] - num3)) : 0f;
			int count2 = this.Chart.tsList.Count;
			int num5 = this.Chart.tsList.method_1(num3);
			int num6 = this.Chart.tsList.Values[num5][0];
			int num7 = this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5]);
			int num8 = (count2 > num5 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5 + 1]) : -1;
			float num10;
			for (int i = num; i <= num2; i++)
			{
				int num9 = this.Chart.FretbarList[i];
				if (this.ShouldDoubleFretbarWidth())
				{
					num10 = float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, (double)((float)(i - num) - num4))) / (double)(1f - this.FretboardAngle));
				}
				else
				{
					num10 = float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, this.Hyperspeed * (double)(num9 - int_8) / (double)this.Chart.FretbarList[1])) / (double)(1f - this.FretboardAngle));
				}
				if (i - num7 == 0)
				{
					float num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
					Font font = new Font("Verdana", Math.Max(0f, ((float)this.Editor_Size.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + this.Chart.tsList.Values[num5][1], font, this.Brush_GrayText, float_6 + (float)this.Editor_Size.Height + 5f - num11, num10 - font.Size);
				}
				if (i == num8)
				{
					num5++;
					num6 = this.Chart.tsList.Values[num5][0];
					num7 = this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num5 + 1]) : -1);
					float num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
					Font font2 = new Font("Verdana", Math.Max(0f, ((float)this.Editor_Size.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + this.Chart.tsList.Values[num5][1], font2, this.Brush_GrayText, float_6 + (float)this.Editor_Size.Height + 5f - num11, num10 - font2.Size);
				}
				if (num10 <= float_7)
				{
					float num11;
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? this.Pen_Black : this.Pen_Gray, float_6 + (num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1))), num10, float_6 + (float)this.Editor_Size.Height - num11, num10);
				}
				if (i + 1 < count && i + 1 <= num2)
				{
					if (this.ShouldDoubleFretbarWidth())
					{
						num10 = float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, (double)((float)(i - num) - num4 + 0.5f))) / (double)(1f - this.FretboardAngle));
					}
					else
					{
						num10 = float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, this.Hyperspeed * (double)((this.Chart.FretbarList[i + 1] - num9) / 2 + num9 - int_8) / (double)this.Chart.FretbarList[1])) / (double)(1f - this.FretboardAngle));
					}
					if (num10 <= float_7 && num10 >= (float)this.Height - float_7)
					{
						float num11;
						graphics_0.DrawLine(this.Pen_LightGray, float_6 + (num11 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1))), num10, float_6 + (float)this.Editor_Size.Height - num11, num10);
					}
				}
			}
			num10 = float_7 - this.float_3;
			float num12 = Convert.ToSingle((double)(float_7 - num10) * Math.Tan(this.double_1));
			float num13 = (float)this.Editor_Size.Height - 2f * num12;
			for (int j = 0; j <= this.NumberOfNoteLines; j++)
			{
				graphics_0.DrawLine(this.Pen_Gray, float_6 + (float)(j * this.Editor_Size.Height) / (float)this.NumberOfNoteLines, float_7, float_6 + num12 + (float)j * num13 / (float)this.NumberOfNoteLines, num10);
			}
		}

		private void DrawGameViewNotes(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += this.Chart.gh3Song_0.gem_offset;
			int_9 += this.Chart.gh3Song_0.gem_offset;
			Track<int, NotesAtOffset> @class = this.Chart.noteList.ContainsKey(this.Difficulty) ? this.Chart.noteList[this.Difficulty] : new Track<int, NotesAtOffset>();
			Track<int, int[]> class2 = this.Chart.spList.ContainsKey(this.Difficulty) ? this.Chart.spList[this.Difficulty] : new Track<int, int[]>();
			if (@class.Count == 0)
			{
				return;
			}
			int arg_A3_0 = @class.Count;
			int num = @class.method_1(int_8);
			int num2 = @class.method_1(int_9);
			int num3 = @class.Keys[num];
			if (int_8 < this.LastFretbar && num3 <= int_9)
			{
				int count = this.Chart.FretbarList.Count;
				int num4 = this.Chart.FretbarList.method_7(num3);
				int num5 = this.Chart.FretbarList[num4];
				int num6 = this.Chart.FretbarList[num4 + 1] - num5;
				int num7 = (count > num4 + 1) ? @class.method_2(this.Chart.FretbarList[num4 + 1]) : -1;
				int num8 = this.Chart.FretbarList.method_7(int_8);
				this.Chart.FretbarList.method_7(int_9);
				float num9 = (float)(int_8 - this.Chart.FretbarList[num8]) / (float)(this.Chart.FretbarList[num8 + 1] - this.Chart.FretbarList[num8]);
				int count2 = this.Chart.tsList.Count;
				int num10 = this.Chart.tsList.method_1(num3);
				int num11 = this.Chart.tsList.Values[num10][0];
				int num12 = (count2 > num10 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num10 + 1]) : -1;
				int count3 = class2.Count;
				int num13 = class2.method_1(num3);
				int num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				int num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				float num16 = (float)this.Editor_Size.Height / (float)this.NumberOfNoteLines;
				float num17 = (float)this.Editor_Size.Height / 15f;
				float num18 = num17 / 1.6f;
				float num19 = num17 * 2f;
				float num20 = num18 * 2f;
				float val = float_7 - this.float_3;
				for (int i = num; i <= num2; i++)
				{
					int num21 = @class.Keys[i];
					NotesAtOffset class3 = @class[num21];
					if (i == num7)
					{
						num4 = this.Chart.FretbarList.method_7(num21);
						num5 = this.Chart.FretbarList[num4];
						num6 = this.Chart.FretbarList[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(this.Chart.FretbarList[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = this.Chart.tsList.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? this.Chart.FretbarList.method_7(this.Chart.tsList.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					bool ShouldDrawSP = this.LoadStarpowerTextures && num14 >= num21;
					float num22;
					float num23;
					if (this.ShouldDoubleFretbarWidth())
					{
						num22 = Math.Min(float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, (double)((float)(num4 - num8) - num9 + (float)(num21 - num5) / (float)num6))) / (double)(1f - this.FretboardAngle)), float_7);
						if (class3.sustainLength - this.Chart.int_0 > this.Chart.int_0)
						{
							num23 = (float)(num21 + class3.sustainLength - this.Chart.int_0);
							int num24 = this.Chart.FretbarList.method_7((int)num23);
							num23 = Math.Max(float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, (double)((float)(num24 - num8) - num9 + (num23 - (float)this.Chart.FretbarList[num24]) / (float)(this.Chart.FretbarList[num24 + 1] - this.Chart.FretbarList[num24])))) / (double)(1f - this.FretboardAngle)), val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, this.Hyperspeed * (double)(num21 - int_8) / (double)this.Chart.FretbarList[1])) / (double)(1f - this.FretboardAngle));
						num23 = ((class3.sustainLength - this.Chart.int_0 > this.Chart.int_0) ? Math.Max(float_7 - Convert.ToSingle((double)this.Editor_Size.Width * (1.0 - Math.Pow((double)this.FretboardAngle, this.Hyperspeed * (double)(num21 - int_8 + class3.sustainLength - this.Chart.int_0) / (double)this.Chart.FretbarList[1])) / (double)(1f - this.FretboardAngle)), val) : -1f);
						num22 = Math.Min(num22, float_7);
					}
					if (num23 == -1f || num23 <= float_7)
					{
						bool ShouldDrawHopo = this.LoadHopoTextures && ((i != 0 && SongEditor.smethod_0(@class[@class.Keys[i - 1]].noteValues, class3.noteValues) && (float)(num21 - @class.Keys[i - 1]) <= (float)num11 / 4f * (float)num6 / ((this.Chart.gh3Song_0.hammer_on == 0f) ? QBCParser.float_0 : this.Chart.gh3Song_0.hammer_on)) ^ class3.noteValues[5]);
						float num25 = float_6 + Convert.ToSingle((double)(float_7 - num22) * Math.Tan(this.double_1));
						num16 = ((float)this.Editor_Size.Height - 2f * (num25 - float_6)) / (float)this.NumberOfNoteLines;
						float num26 = float_6 + Convert.ToSingle((double)(float_7 - num23) * Math.Tan(this.double_1));
						float num27 = ((float)this.Editor_Size.Height - 2f * (num26 - float_6)) / (float)this.NumberOfNoteLines;
						num17 = ((float)this.Editor_Size.Height - 2f * (num25 - float_6)) / 15f;
						num18 = num17 / 1.6f;
						num19 = num17 * 2f;
						num20 = num18 * 2f;
						float num28 = ((float)this.Editor_Size.Height - 2f * (num25 - float_6)) / 32f;
						float num29 = ((float)this.Editor_Size.Height - 2f * (num26 - float_6)) / 32f;
						if (this.Has5NoteLines())
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
							if (class3.noteValues[j])
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
									graphics_0.FillPolygon(this.NoteBrush[j], points);
								}
								if (num != i || num == 0)
								{
									if (ShouldDrawSP)
									{
										PointF[] TrianlePositions = new PointF[5];
										for (int k = 0; k < 5; k++)
										{
											TrianlePositions[k] = new PointF(num25 - num19 * (float)Math.Sin((double)k * this.double_0), num22 + num19 * this.FretboardAngle * (float)Math.Cos((double)k * this.double_0));
										}
										graphics_0.FillPolygon(this.Brush_Black, TrianlePositions, FillMode.Winding);
									}
									RectangleF rect = new RectangleF(num25 - num17, num22 - num17 * this.FretboardAngle, num19, num19 * this.FretboardAngle);
									graphics_0.FillEllipse(this.NoteBrush[j], rect);
									graphics_0.DrawEllipse(this.Pen_Black2, rect);
									if (ShouldDrawHopo)
									{
										rect = new RectangleF(num25 - num18, num22 - num18 * this.FretboardAngle, num20, num20 * this.FretboardAngle);
										graphics_0.FillEllipse(this.Brush_White, rect);
										graphics_0.DrawEllipse(this.Pen_Black2, rect);
									}
								}
							}
						}
					}
				}
				return;
			}
		}

		private void DrawGameviewFretbars(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (this.AudioData == null)
			{
				return;
			}
			float num = 0f;
			float num2 = float_7;
			float num3 = num2;
			int num4 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 * (int_8 / 1000m));
			int num5 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 * (int_9 / 1000m));
			num5 = Math.Min(num5, this.AudioData.Length);
			decimal d = 0m;
			int i = num4;
			for (int j = 0; j < (int)this.Audio.GetWaveFormat().short_0; j++)
			{
				while (i < num5)
				{
					float num6 = -128f;
					float num7 = 127f;
					decimal num8 = (decimal)((double)this.Chart.FretbarList[1] / this.Hyperspeed * Math.Log(Math.Abs(1.0 - (double)((float_7 - num2 + 1f) * (1f - this.FretboardAngle)) / (double)this.Editor_Size.Width), (double)this.FretboardAngle));
					int num9 = Convert.ToInt32(this.Audio.GetWaveFormat().int_0 * (int)this.Audio.GetWaveFormat().short_0 * ((num8 - d) / 1000m));
					d = num8;
					int num10 = j;
					while (num10 < num9 && num10 + i < num5)
					{
						num6 = Math.Max(num6, (float)this.AudioData[num10 + i]);
						num7 = Math.Min(num7, (float)this.AudioData[num10 + i]);
						num10 += (int)this.Audio.GetWaveFormat().short_0;
					}
					float num11 = Convert.ToSingle((double)(float_7 - num2) * Math.Tan(this.double_1));
					float num12 = (float)this.Editor_Size.Height - 2f * num11;
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
								graphics_0.DrawLine(this.Pen_TransparentBlue, float_6 + num11 + num, num3, float_6 + num11 + num14, num2);
							}
						}
						else
						{
							graphics_0.DrawLine(this.Pen_TransparentBlue, float_6 + num11 + num13, num2, float_6 + num11 + num14, num2);
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

		private void DrawGameView(Graphics graphics_0)
		{
			float num = this.float_5 * 2f;
			int num2 = this.method_16((float)(this.VerticalScrollBar.Maximum - this.VerticalScrollBar.LargeChange - this.VerticalScrollBar.Value) / 2f);
            if (this.ShouldDoubleFretbarWidth())
			{
                int int_ = this.method_16((float)(this.VerticalScrollBar.Maximum - this.VerticalScrollBar.LargeChange - this.VerticalScrollBar.Value) / 2f + this.FretboardAngleFloat);
				this.method_25(graphics_0, num2, int_, (float)this.Width / 4f, (float)this.Height - num);
                this.DrawGameViewNotes(graphics_0, num2, int_, (float)this.Width / 4f, (float)this.Height - num);
            }
			else
			{
                if (this.Audio != null && this.GetAudioStatus() == AudioStatus.ShouldStartAudio)
				{
					num2 = (int)this.Audio.AudioLength().TotalMilliseconds;
				}
                int int_ = num2 + this.UsedForCalculatingLastFretbar;
				if (this.ShowAudioOnFretboard)
				{
					this.DrawGameviewFretbars(graphics_0, num2, int_, (float)this.Width / 4f, (float)this.Height - num);
				}
                this.method_25(graphics_0, num2, int_, (float)this.Width / 4f, (float)this.Height - num);
				this.DrawGameViewNotes(graphics_0, num2, int_, (float)this.Width / 4f, (float)this.Height - num);
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
			if (this.Chart == null)
			{
				return;
			}
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this.GamemodeView)
			{
				this.DrawGameView(graphics);
				return;
			}
			this.DrawFlatView(graphics);
		}

		public new void Dispose()
		{
			if (this.Audio != null)
			{
				this.Audio.Dispose();
			}
			base.Dispose();
		}
	}
}
