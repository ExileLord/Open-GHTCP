using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GuitarHero.Songlist;
using ns0;
using ns1;
using ns14;
using ns15;
using ns8;
using ns9;
using Timer = System.Windows.Forms.Timer;

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
				using (var stream = AudioManager.getAudioStream(fileName))
				{
                    songEditor_0.AudioData = new sbyte[stream.vmethod_1().uint_0 * (ulong)stream.vmethod_1().method_0()];
					var array = new float[4096];
					int num;
					for (var i = 0; i < songEditor_0.AudioData.Length; i += num)
					{
						if (i + array.Length < songEditor_0.AudioData.Length)
						{
							num = stream.vmethod_4(array, 0, array.Length);
						}
						else
						{
							num = stream.vmethod_4(array, 0, songEditor_0.AudioData.Length - i);
						}
						for (var j = 0; j < num; j++)
						{
							songEditor_0.AudioData[i + j] = Class11.smethod_19(array[j]);
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

		private Timer timer;

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

		private Brush[] NoteBrush = {
			Brushes.Green,
			Brushes.Red,
			Brushes.Yellow,
			Brushes.Blue,
			Brushes.Orange,
			Brushes.LightGray
		};

		private Pen[] NotePen = {
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

        private Delegate10 delegate10_0;

        protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			Name = "SongEditor";
			ResumeLayout(false);
		}

		public AudioStatus GetAudioStatus()
		{
			if (Audio == null)
			{
				return AudioStatus.ShouldStopAudio;
			}
			return Audio.GetStatus();
		}

        public void SetBeatSize(int BeatSize)
        {
            if (Chart == null)
            {
                return;
            }
            size_1.Width = BeatSize;
            FretbarWidth = size_1.Width / (decimal)Chart.FretbarList[1];
			RedrawFretboard();
		}

		public void SetOffset(int offset)
		{
            if (Chart == null)
            {
                return;
            }
            var ghSong = Chart.gh3Song_0;
			Chart.gh3Song_0.gem_offset = offset;
			ghSong.fretbar_offset = offset;
			RedrawFretboard();
		}

		public bool ShouldDoubleFretbarWidth()
		{
			return DoubleFretbarWidth;
		}

		public void SetDoubleFretbarWidth(bool bool_5)
		{
			ScrollBar arg_22_0 = VerticalScrollBar;
			DoubleFretbarWidth = bool_5;
			arg_22_0.Maximum = (bool_5 ? SomeFretbarValue : LastFretbarValue) - 1;
			RedrawFretboard();
		}

		public bool Has5NoteLines()
		{
			return NumberOfNoteLines == 5;
		}

		public void Set5NoteLines(bool bool_5)
		{
			NumberOfNoteLines = (bool_5 ? 5 : 4);
		}

		public bool IsGamemodeView()
		{
			return GamemodeView;
		}

		public void SetGamemodeView(bool isGamemode)
		{
			GamemodeView = isGamemode;
			RedrawFretboard();
		}

		public void SetHyperspeed(double hyperspeed)
		{
			Hyperspeed = hyperspeed;
			RedrawFretboard();
		}

		public void SetFretboardAngle(double double_3)
		{
			FretboardAngle = Convert.ToSingle(Math.Pow(Math.Cos(double_1 = 3.1415926535897932 * double_3 / 180.0), 7.3890560989306495));
			RedrawFretboard();
		}

		public SongEditor()
		{
			InitializeComponent();
			BackColor = Color.White;
			MouseMove += SongEditor_MouseMove;
			MouseDown += SongEditor_MouseDown;
			MouseWheel += SongEditor_MouseWheel;
			Resize += SongEditor_Resize;
			Controls.Add(VerticalScrollBar);
			SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			timer = new Timer();
			timer.Interval = 20;
			timer.Tick += timer_0_Tick;
			timer.Start();
		}

		public void LoadChart(QBCParser chartFile)
		{
			Chart = chartFile;
			chartFile.FretbarList[0] = 0;
			LastFretbar = Chart.FretbarList[Chart.FretbarList.Count - 1];
            FretbarWidth = size_1.Width / (decimal)Chart.FretbarList[1];
            SetFretboardAngle(15.0);
			Difficulty = "expert";
			for (var i = 0; i < NoteBrush.Length; i++)
			{
				pen_4[i] = new Pen(NoteBrush[i], size_1.Height / 24f);
			}
            RedrawFretboard();
		}

        public void LoadAudio(string fileName)
        {
            var songData = new SongData();
            songData.fileName = fileName;
            songData.songEditor_0 = this;
            if (Audio != null)
            {
                Audio.Dispose();
            }
            var audioStream = AudioManager.getAudioStream(songData.fileName);
            if (audioStream == null)
            {
                return;
            }
            Audio = AudioManager.LoadPlayableAudio(Enum25.const_2, audioStream);
            ThreadPool.QueueUserWorkItem(songData.LoadAudioData);
        }

		private void RedrawFretboard()
		{
			if (Chart == null)
			{
				return;
			}
			VerticalScrollBar.Height = (Height = base.Height);
			Width = (VerticalScrollBar.Left = base.Width - VerticalScrollBar.Width);
			VerticalScrollBar.Top = 0;
			Editor_Size.Height = Width / 2;
			Editor_Size.Width = Editor_Size.Height / 3;
			float_0 = size_1.Height + float_5 * (Has5NoteLines() ? 4 : 5);
			float_3 = Editor_Size.Width / (1f - FretboardAngle);
			if (float_3 > Height * 3f / 4f)
			{
				float_3 = Height * 3f / 4f;
			}
			FretboardAngleFloat = (IsGamemodeView() ? Convert.ToSingle(Math.Log(Math.Abs(1.0 - float_3 * (1f - FretboardAngle) / (double)Editor_Size.Width), FretboardAngle)) : ((Width - float_5 * 2f) / size_1.Width));
			SomeFretbarValue = (int)Math.Ceiling(Chart.FretbarList.Count / (double)FretboardAngleFloat);
            UsedForCalculatingLastFretbar = (IsGamemodeView() ? Convert.ToInt32(Chart.FretbarList[1] / Hyperspeed * Math.Log(Math.Abs(1.0 - float_3 * (1f - FretboardAngle) / (double)Editor_Size.Width), FretboardAngle)) : method_15(Width - float_5 * 2f));
            LastFretbarValue = (int)Math.Ceiling(LastFretbar / (double)UsedForCalculatingLastFretbar);
			int_2 = Height / (int)float_0;
			VerticalScrollBar.Minimum = 0;
			VerticalScrollBar.SmallChange = 1;
            VerticalScrollBar.LargeChange = (IsGamemodeView() ? ((int)FretboardAngleFloat) : int_2);
            VerticalScrollBar.Maximum = (IsGamemodeView() ? (Chart.FretbarList.Count * 2 + VerticalScrollBar.LargeChange) : ((ShouldDoubleFretbarWidth() ? SomeFretbarValue : LastFretbarValue) - 1));
            VerticalScrollBar.Value = (IsGamemodeView() ? (VerticalScrollBar.Maximum - VerticalScrollBar.LargeChange) : 0);
        }

		private void timer_0_Tick(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void SongEditor_Resize(object sender, EventArgs e)
		{
			RedrawFretboard();
		}

		private void SongEditor_MouseMove(object sender, MouseEventArgs e)
		{
			float_2 = e.X - float_5;
			if (float_2 < 0f)
			{
				float_2 = 0f;
				return;
			}
			if (float_2 > base.Width - float_5 * 2f)
			{
				float_2 = base.Width - float_5 * 2f;
			}
		}

		private void SongEditor_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2 && e.Button == MouseButtons.Right)
			{
				Set5NoteLines(!Has5NoteLines());
				return;
			}
			if (e.Clicks == 2 && e.Button == MouseButtons.Left)
			{
				SetDoubleFretbarWidth(!ShouldDoubleFretbarWidth());
			}
		}

		private void SongEditor_MouseWheel(object sender, MouseEventArgs e)
		{
			var num = VerticalScrollBar.Value - e.Delta / SystemInformation.MouseWheelScrollDelta;
			if (VerticalScrollBar.Maximum - (VerticalScrollBar.LargeChange - VerticalScrollBar.SmallChange) >= num && VerticalScrollBar.Minimum <= num)
			{
				VerticalScrollBar.Value = num;
			}
		}

		private float method_14(int int_8)
		{
			return Convert.ToSingle(int_8 * FretbarWidth);
		}

		private int method_15(float float_6)
		{
			return Convert.ToInt32((decimal)float_6 / FretbarWidth);
		}

		private int method_16(float float_6)
		{
			var num = (int)Math.Floor(float_6);
			if (num + 1 >= Chart.FretbarList.Count)
			{
				return LastFretbar;
			}
			if (num < 0)
			{
				return 0;
			}
			var num2 = Chart.FretbarList[num];
			return num2 + Convert.ToInt32((float_6 - num) * (Chart.FretbarList[num + 1] - num2));
		}

		private static bool smethod_0(bool[] bool_5, bool[] bool_6)
		{
			for (var i = 0; i < 5; i++)
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
			int_8 += Chart.gh3Song_0.fretbar_offset;
			int_9 += Chart.gh3Song_0.fretbar_offset;
			graphics_0.SetClip(new RectangleF(float_6, 0f, Width - float_6 * 2f, Height));
			var count = Chart.FretbarList.Count;
			var num = Chart.FretbarList.method_7(int_8);
			var num2 = Chart.FretbarList.method_7(int_9);
			var num3 = Chart.FretbarList[num];
			var num4 = (num + 1 < count) ? ((int_8 - num3) / (float)(Chart.FretbarList[num + 1] - num3)) : 0f;
			var count2 = Chart.tsList.Count;
			var num5 = Chart.tsList.method_1(num3);
			var num6 = Chart.tsList.Values[num5][0];
			var num7 = Chart.FretbarList.method_7(Chart.tsList.Keys[num5]);
			var num8 = (count2 > num5 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num5 + 1]) : -1;
			var num9 = 0f;
			var y = float_7 + size_1.Height;
			for (var i = num; i <= num2; i++)
			{
				var num10 = Chart.FretbarList[i];
				if (ShouldDoubleFretbarWidth())
				{
					num9 = float_6 + (i - num - num4) * size_1.Width;
				}
				else
				{
					num9 = float_6 + method_14(num10 - int_8);
				}
				if (i - num7 == 0)
				{
					graphics_0.DrawString(string.Concat(num6), Font_Verdana, Brush_GrayText, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), Font_Verdana, Brush_GrayText, num9 - 4f, float_7 + size_1.Height / 2f - 3f);
				}
				if (i == num8)
				{
					num5++;
					num6 = Chart.tsList.Values[num5][0];
					num7 = Chart.FretbarList.method_7(Chart.tsList.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num5 + 1]) : -1);
					graphics_0.DrawString(string.Concat(num6), Font_Verdana, Brush_GrayText, num9 - 4f, float_7 - 3f);
					graphics_0.DrawString(string.Concat(4), Font_Verdana, Brush_GrayText, num9 - 4f, float_7 + size_1.Height / 2f - 3f);
				}
				if (num9 >= float_6)
				{
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? Pen_Black : Pen_Gray, num9, float_7, num9, y);
				}
				if (i + 1 < count)
				{
					if (ShouldDoubleFretbarWidth())
					{
						num9 += 0.5f * size_1.Width;
					}
					else
					{
						num9 += method_14(Chart.FretbarList[i + 1] - num10) / 2f;
					}
					if (num9 >= float_6 && num9 <= Width - float_6)
					{
						graphics_0.DrawLine(Pen_LightGray, num9, float_7, num9, y);
					}
				}
			}
			var x = (int_9 >= LastFretbar) ? num9 : (Width - float_6);
			for (var j = 1; j < NumberOfNoteLines; j++)
			{
				graphics_0.DrawLine(Pen_Gray, float_6, y = float_7 + j * size_1.Height / (float)NumberOfNoteLines, x, y);
			}
			graphics_0.DrawLine(Pen_Black, float_6, float_7, x, float_7);
			graphics_0.DrawLine(Pen_Black, float_6, y = float_7 + size_1.Height, x, y);
			graphics_0.ResetClip();
		}

		private void DrawFlatViewNotes(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += Chart.gh3Song_0.gem_offset;
			int_9 += Chart.gh3Song_0.gem_offset;
			var @class = Chart.noteList.ContainsKey(Difficulty) ? Chart.noteList[Difficulty] : new Track<int, NotesAtOffset>();
			var class2 = Chart.spList.ContainsKey(Difficulty) ? Chart.spList[Difficulty] : new Track<int, int[]>();
			var arg_9A_0 = @class.Count;
			var num = @class.method_1(int_8);
			var num2 = @class.method_1(int_9);
			var num3 = @class.Keys[num];
			if (int_8 < LastFretbar && num3 <= int_9)
			{
				var count = Chart.FretbarList.Count;
				var num4 = Chart.FretbarList.method_7(num3);
				var num5 = Chart.FretbarList[num4];
				var num6 = Chart.FretbarList[num4 + 1] - num5;
				var num7 = (count > num4 + 1) ? @class.method_2(Chart.FretbarList[num4 + 1]) : -1;
				var num8 = Chart.FretbarList.method_7(int_8);
				var num9 = (int_8 - Chart.FretbarList[num8]) / (float)(Chart.FretbarList[num8 + 1] - Chart.FretbarList[num8]);
				var count2 = Chart.tsList.Count;
				var num10 = Chart.tsList.method_1(num3);
				var num11 = Chart.tsList.Values[num10][0];
				var num12 = (count2 > num10 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num10 + 1]) : -1;
				var count3 = class2.Count;
				var num13 = class2.method_1(num3);
				var num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				var num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				var num16 = size_1.Height / (float)NumberOfNoteLines;
				var num17 = size_1.Height / 15f;
				var num18 = num17 / 1.6f;
				var num19 = num17 * 2f;
				var num20 = num18 * 2f;
				var val = Width - float_6;
				if (Has5NoteLines())
				{
					float_7 += num16 / 2f;
				}
				for (var i = num; i <= num2; i++)
				{
					var num21 = @class.Keys[i];
					var class3 = @class[num21];
					if (i == num7)
					{
						num4 = Chart.FretbarList.method_7(num21);
						num5 = Chart.FretbarList[num4];
						num6 = Chart.FretbarList[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(Chart.FretbarList[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = Chart.tsList.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					var ShowDrawSP = LoadStarpowerTextures && num14 >= num21;
					float num22;
					float num23;
					if (ShouldDoubleFretbarWidth())
					{
						num22 = Math.Max(float_6 + (num4 - num8 - num9 + (num21 - num5) / (float)num6) * size_1.Width, float_6);
						if (class3.sustainLength - Chart.int_0 > Chart.int_0)
						{
							num23 = num21 + class3.sustainLength - Chart.int_0;
							var num24 = Chart.FretbarList.method_7((int)num23);
							num23 = Math.Min(float_6 + (num24 - num8 - num9 + (num23 - Chart.FretbarList[num24]) / (Chart.FretbarList[num24 + 1] - Chart.FretbarList[num24])) * size_1.Width, val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_6 + method_14(num21 - int_8);
						num23 = ((class3.sustainLength - Chart.int_0 > Chart.int_0) ? Math.Min(num22 + method_14(class3.sustainLength - Chart.int_0), val) : -1f);
						num22 = Math.Max(num22, float_6);
					}
					if (num23 == -1f || num23 >= float_6)
					{
						var ShouldDrawHopo = LoadHopoTextures && ((i != 0 && smethod_0(@class[@class.Keys[i - 1]].noteValues, class3.noteValues) && num21 - @class.Keys[i - 1] <= num11 / 4f * num6 / ((Chart.gh3Song_0.hammer_on == 0f) ? QBCParser.float_0 : Chart.gh3Song_0.hammer_on)) ^ class3.noteValues[5]);
						for (var j = 0; j < 6; j++)
						{
							if (class3.noteValues[j])
							{
								var num25 = float_7 + num16 * j;
								if (num23 != -1f)
								{
									graphics_0.DrawLine(pen_4[j], num22, num25, num23, num25);
									graphics_0.DrawRectangle(Pen_Black2, num22, num25 - 1f, num23 - num22, pen_4[j].Width);
								}
								if (num != i || num == 0)
								{
									if (ShowDrawSP)
									{
										var array = new PointF[5];
										for (var k = 0; k < 5; k++)
										{
											array[k] = new PointF(num22 + num19 * (float)Math.Sin(k * double_0), num25 - num19 * (float)Math.Cos(k * double_0));
										}
										graphics_0.FillPolygon(Brush_Black, array, FillMode.Winding);
									}
									var rect = new RectangleF(num22 - num17, num25 - num17, num19, num19);
									graphics_0.FillEllipse(NoteBrush[j], rect);
									graphics_0.DrawEllipse(Pen_Black2, rect);
									if (ShouldDrawHopo)
									{
										rect = new RectangleF(num22 - num18, num25 - num18, num20, num20);
										graphics_0.FillEllipse(Brush_White, rect);
										graphics_0.DrawEllipse(Pen_Black2, rect);
									}
								}
							}
						}
					}
				}
			}
		}

		private void DrawAudio(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (AudioData == null)
			{
				return;
			}
			var num = float_6;
			var x = num;
			var num2 = 0f;
			var num3 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 * (int_8 / 1000m));
			var num4 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 * (int_9 / 1000m));
			num4 = Math.Min(num4, AudioData.Length);
			var num5 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 / (FretbarWidth * 1000m));
			var i = num3;
			for (var j = 0; j < (int)Audio.GetWaveFormat().short_0; j++)
			{
				while (i < num4)
				{
					var num6 = -128f;
					var num7 = 127f;
					if (ShouldDoubleFretbarWidth())
					{
						num5 = size_1.Width;
					}
					var num8 = j;
					while (num8 < num5 && num8 + i < num4)
					{
						num6 = Math.Max(num6, AudioData[num8 + i]);
						num7 = Math.Min(num7, AudioData[num8 + i]);
						num8 += Audio.GetWaveFormat().short_0;
					}
					var num9 = (num7 + 128f) * size_1.Height / 256f;
					var num10 = (num6 + 128f) * size_1.Height / 256f;
					if (num6 != num7)
					{
						if (num5 <= 1E-10)
						{
							return;
						}
						if (num9 == num10)
						{
							if (num2 != 0f)
							{
								graphics_0.DrawLine(Pen_TransparentBlue, x, float_7 + num2, num, float_7 + num10);
							}
						}
						else
						{
							graphics_0.DrawLine(Pen_TransparentBlue, num, float_7 + num9, num, float_7 + num10);
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
			var num = 0;
			var num2 = 0;
			if (ShouldDoubleFretbarWidth())
			{
				var num3 = Math.Min(int_2, SomeFretbarValue);
				for (var i = 0; i < num3; i++)
				{
					num = method_16(FretboardAngleFloat * (VerticalScrollBar.Value + i));
					num2 = method_16(FretboardAngleFloat * (VerticalScrollBar.Value + i + 1));
					var num4 = float_5 * 2f + float_0 * i;
					method_17(graphics_0, num, num2, float_5, num4);
					DrawFlatViewNotes(graphics_0, num, num2, float_5, num4);
				}
			}
			else
			{
				var num5 = Math.Min(int_2, LastFretbarValue);
				var j = 0;
				if (Audio != null)
				{
					j = (int)Audio.AudioLength().TotalMilliseconds;
				}
				if (GetAudioStatus() == AudioStatus.ShouldStartAudio)
				{
					while (j < UsedForCalculatingLastFretbar * VerticalScrollBar.Value)
					{
						VerticalScrollBar.Value--;
					}
				}
				for (var k = 0; k < num5; k++)
				{
					num = UsedForCalculatingLastFretbar * (VerticalScrollBar.Value + k);
					num2 = UsedForCalculatingLastFretbar * (VerticalScrollBar.Value + k + 1);
					var num4 = float_5 * 2f + float_0 * k;
					if (ShowAudioOnFretboard)
					{
						DrawAudio(graphics_0, num, num2, float_5, num4);
					}
					method_17(graphics_0, num, num2, float_5, num4);
					DrawFlatViewNotes(graphics_0, num, num2, float_5, num4);
					if (Audio != null && num <= j && j <= num2)
					{
						var smoothingMode = graphics_0.SmoothingMode;
						graphics_0.SmoothingMode = SmoothingMode.None;
						graphics_0.DrawLine(Pen_Black2, float_5 + method_14(j - num), num4 - 5f, float_5 + method_14(j - num), num4 + size_1.Height + 5f);
						graphics_0.SmoothingMode = smoothingMode;
					}
				}
				if (GetAudioStatus() == AudioStatus.ShouldStartAudio && j > num2 && VerticalScrollBar.Value + num5 <= VerticalScrollBar.Maximum)
				{
					VerticalScrollBar.Value += num5;
				}
			}
			delegate10_0(num, null);
		}

		public void DifferentStartPlaying()
		{
			if (Audio != null)
			{
				Audio.DifferentStartPlaying();
			}
		}

		public void StartPlaying()
		{
			if (Audio != null)
			{
				Audio.StartPlaying();
			}
		}

		public void StopAudio()
		{
			if (Audio != null)
			{
				Audio.StopPlaying();
				Audio.SetStartingTimeBasedOnSomeValue(0);
			}
		}

		public bool AudioLoaded()
		{
			return Audio != null;
		}

		private void method_25(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += Chart.gh3Song_0.fretbar_offset;
			int_9 += Chart.gh3Song_0.fretbar_offset;
			var count = Chart.FretbarList.Count;
			var num = Chart.FretbarList.method_7(int_8);
			var num2 = Chart.FretbarList.method_7(int_9);
			var num3 = Chart.FretbarList[num];
			var num4 = (num + 1 < count) ? ((int_8 - num3) / (float)(Chart.FretbarList[num + 1] - num3)) : 0f;
			var count2 = Chart.tsList.Count;
			var num5 = Chart.tsList.method_1(num3);
			var num6 = Chart.tsList.Values[num5][0];
			var num7 = Chart.FretbarList.method_7(Chart.tsList.Keys[num5]);
			var num8 = (count2 > num5 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num5 + 1]) : -1;
			float num10;
			for (var i = num; i <= num2; i++)
			{
				var num9 = Chart.FretbarList[i];
				if (ShouldDoubleFretbarWidth())
				{
					num10 = float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, i - num - num4)) / (1f - FretboardAngle));
				}
				else
				{
					num10 = float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, Hyperspeed * (num9 - int_8) / Chart.FretbarList[1])) / (1f - FretboardAngle));
				}
				if (i - num7 == 0)
				{
					var num11 = Convert.ToSingle((float_7 - num10) * Math.Tan(double_1));
					var font = new Font("Verdana", Math.Max(0f, (Editor_Size.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + Chart.tsList.Values[num5][1], font, Brush_GrayText, float_6 + Editor_Size.Height + 5f - num11, num10 - font.Size);
				}
				if (i == num8)
				{
					num5++;
					num6 = Chart.tsList.Values[num5][0];
					num7 = Chart.FretbarList.method_7(Chart.tsList.Keys[num5]);
					num8 = ((count2 > num5 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num5 + 1]) : -1);
					var num11 = Convert.ToSingle((float_7 - num10) * Math.Tan(double_1));
					var font2 = new Font("Verdana", Math.Max(0f, (Editor_Size.Height - 2f * num11) / 15f));
					graphics_0.DrawString(num6 + "/" + Chart.tsList.Values[num5][1], font2, Brush_GrayText, float_6 + Editor_Size.Height + 5f - num11, num10 - font2.Size);
				}
				if (num10 <= float_7)
				{
					float num11;
					graphics_0.DrawLine(((i - num7) % num6 == 0) ? Pen_Black : Pen_Gray, float_6 + (num11 = Convert.ToSingle((float_7 - num10) * Math.Tan(double_1))), num10, float_6 + Editor_Size.Height - num11, num10);
				}
				if (i + 1 < count && i + 1 <= num2)
				{
					if (ShouldDoubleFretbarWidth())
					{
						num10 = float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, i - num - num4 + 0.5f)) / (1f - FretboardAngle));
					}
					else
					{
						num10 = float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, Hyperspeed * ((Chart.FretbarList[i + 1] - num9) / 2 + num9 - int_8) / Chart.FretbarList[1])) / (1f - FretboardAngle));
					}
					if (num10 <= float_7 && num10 >= Height - float_7)
					{
						float num11;
						graphics_0.DrawLine(Pen_LightGray, float_6 + (num11 = Convert.ToSingle((float_7 - num10) * Math.Tan(double_1))), num10, float_6 + Editor_Size.Height - num11, num10);
					}
				}
			}
			num10 = float_7 - float_3;
			var num12 = Convert.ToSingle((float_7 - num10) * Math.Tan(double_1));
			var num13 = Editor_Size.Height - 2f * num12;
			for (var j = 0; j <= NumberOfNoteLines; j++)
			{
				graphics_0.DrawLine(Pen_Gray, float_6 + j * Editor_Size.Height / (float)NumberOfNoteLines, float_7, float_6 + num12 + j * num13 / NumberOfNoteLines, num10);
			}
		}

		private void DrawGameViewNotes(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			int_8 += Chart.gh3Song_0.gem_offset;
			int_9 += Chart.gh3Song_0.gem_offset;
			var @class = Chart.noteList.ContainsKey(Difficulty) ? Chart.noteList[Difficulty] : new Track<int, NotesAtOffset>();
			var class2 = Chart.spList.ContainsKey(Difficulty) ? Chart.spList[Difficulty] : new Track<int, int[]>();
			if (@class.Count == 0)
			{
				return;
			}
			var arg_A3_0 = @class.Count;
			var num = @class.method_1(int_8);
			var num2 = @class.method_1(int_9);
			var num3 = @class.Keys[num];
			if (int_8 < LastFretbar && num3 <= int_9)
			{
				var count = Chart.FretbarList.Count;
				var num4 = Chart.FretbarList.method_7(num3);
				var num5 = Chart.FretbarList[num4];
				var num6 = Chart.FretbarList[num4 + 1] - num5;
				var num7 = (count > num4 + 1) ? @class.method_2(Chart.FretbarList[num4 + 1]) : -1;
				var num8 = Chart.FretbarList.method_7(int_8);
				Chart.FretbarList.method_7(int_9);
				var num9 = (int_8 - Chart.FretbarList[num8]) / (float)(Chart.FretbarList[num8 + 1] - Chart.FretbarList[num8]);
				var count2 = Chart.tsList.Count;
				var num10 = Chart.tsList.method_1(num3);
				var num11 = Chart.tsList.Values[num10][0];
				var num12 = (count2 > num10 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num10 + 1]) : -1;
				var count3 = class2.Count;
				var num13 = class2.method_1(num3);
				var num14 = (class2.Count == 0 || class2.Keys[num13] > num3) ? -1 : (class2.Keys[num13] + class2.Values[num13][0]);
				var num15 = (count3 > num13 + 1) ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13]) : -1;
				if (num14 == -1)
				{
					num13--;
				}
				var num16 = Editor_Size.Height / (float)NumberOfNoteLines;
				var num17 = Editor_Size.Height / 15f;
				var num18 = num17 / 1.6f;
				var num19 = num17 * 2f;
				var num20 = num18 * 2f;
				var val = float_7 - float_3;
				for (var i = num; i <= num2; i++)
				{
					var num21 = @class.Keys[i];
					var class3 = @class[num21];
					if (i == num7)
					{
						num4 = Chart.FretbarList.method_7(num21);
						num5 = Chart.FretbarList[num4];
						num6 = Chart.FretbarList[num4 + 1] - num5;
						num7 = ((count > num4 + 1) ? @class.method_2(Chart.FretbarList[num4 + 1]) : -1);
					}
					if (i == num12)
					{
						num10++;
						num11 = Chart.tsList.Values[num10][0];
						num12 = ((count2 > num10 + 1) ? Chart.FretbarList.method_7(Chart.tsList.Keys[num10 + 1]) : -1);
					}
					if (i == num15)
					{
						num13++;
						num14 = class2.Keys[num13] + class2.Values[num13][0];
						num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
					}
					var ShouldDrawSP = LoadStarpowerTextures && num14 >= num21;
					float num22;
					float num23;
					if (ShouldDoubleFretbarWidth())
					{
						num22 = Math.Min(float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, num4 - num8 - num9 + (num21 - num5) / (float)num6)) / (1f - FretboardAngle)), float_7);
						if (class3.sustainLength - Chart.int_0 > Chart.int_0)
						{
							num23 = num21 + class3.sustainLength - Chart.int_0;
							var num24 = Chart.FretbarList.method_7((int)num23);
							num23 = Math.Max(float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, num24 - num8 - num9 + (num23 - Chart.FretbarList[num24]) / (Chart.FretbarList[num24 + 1] - Chart.FretbarList[num24]))) / (1f - FretboardAngle)), val);
						}
						else
						{
							num23 = -1f;
						}
					}
					else
					{
						num22 = float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, Hyperspeed * (num21 - int_8) / Chart.FretbarList[1])) / (1f - FretboardAngle));
						num23 = ((class3.sustainLength - Chart.int_0 > Chart.int_0) ? Math.Max(float_7 - Convert.ToSingle(Editor_Size.Width * (1.0 - Math.Pow(FretboardAngle, Hyperspeed * (num21 - int_8 + class3.sustainLength - Chart.int_0) / Chart.FretbarList[1])) / (1f - FretboardAngle)), val) : -1f);
						num22 = Math.Min(num22, float_7);
					}
					if (num23 == -1f || num23 <= float_7)
					{
						var ShouldDrawHopo = LoadHopoTextures && ((i != 0 && smethod_0(@class[@class.Keys[i - 1]].noteValues, class3.noteValues) && num21 - @class.Keys[i - 1] <= num11 / 4f * num6 / ((Chart.gh3Song_0.hammer_on == 0f) ? QBCParser.float_0 : Chart.gh3Song_0.hammer_on)) ^ class3.noteValues[5]);
						var num25 = float_6 + Convert.ToSingle((float_7 - num22) * Math.Tan(double_1));
						num16 = (Editor_Size.Height - 2f * (num25 - float_6)) / NumberOfNoteLines;
						var num26 = float_6 + Convert.ToSingle((float_7 - num23) * Math.Tan(double_1));
						var num27 = (Editor_Size.Height - 2f * (num26 - float_6)) / NumberOfNoteLines;
						num17 = (Editor_Size.Height - 2f * (num25 - float_6)) / 15f;
						num18 = num17 / 1.6f;
						num19 = num17 * 2f;
						num20 = num18 * 2f;
						var num28 = (Editor_Size.Height - 2f * (num25 - float_6)) / 32f;
						var num29 = (Editor_Size.Height - 2f * (num26 - float_6)) / 32f;
						if (Has5NoteLines())
						{
							num25 += num16 / 2f;
							num26 += num27 / 2f;
						}
						num25 -= num16;
						num26 -= num27;
						for (var j = 0; j < 6; j++)
						{
							num25 += num16;
							num26 += num27;
							if (class3.noteValues[j])
							{
								if (num23 != -1f)
								{
									PointF[] points = {
										new PointF(num25 - num28, num22),
										new PointF(num26 - num29, num23),
										new PointF(num26 + num29, num23),
										new PointF(num25 + num28, num22)
									};
									graphics_0.FillPolygon(NoteBrush[j], points);
								}
								if (num != i || num == 0)
								{
									if (ShouldDrawSP)
									{
										var TrianlePositions = new PointF[5];
										for (var k = 0; k < 5; k++)
										{
											TrianlePositions[k] = new PointF(num25 - num19 * (float)Math.Sin(k * double_0), num22 + num19 * FretboardAngle * (float)Math.Cos(k * double_0));
										}
										graphics_0.FillPolygon(Brush_Black, TrianlePositions, FillMode.Winding);
									}
									var rect = new RectangleF(num25 - num17, num22 - num17 * FretboardAngle, num19, num19 * FretboardAngle);
									graphics_0.FillEllipse(NoteBrush[j], rect);
									graphics_0.DrawEllipse(Pen_Black2, rect);
									if (ShouldDrawHopo)
									{
										rect = new RectangleF(num25 - num18, num22 - num18 * FretboardAngle, num20, num20 * FretboardAngle);
										graphics_0.FillEllipse(Brush_White, rect);
										graphics_0.DrawEllipse(Pen_Black2, rect);
									}
								}
							}
						}
					}
				}
			}
		}

		private void DrawGameviewFretbars(Graphics graphics_0, int int_8, int int_9, float float_6, float float_7)
		{
			if (AudioData == null)
			{
				return;
			}
			var num = 0f;
			var num2 = float_7;
			var num3 = num2;
			var num4 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 * (int_8 / 1000m));
			var num5 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 * (int_9 / 1000m));
			num5 = Math.Min(num5, AudioData.Length);
			var d = 0m;
			var i = num4;
			for (var j = 0; j < (int)Audio.GetWaveFormat().short_0; j++)
			{
				while (i < num5)
				{
					var num6 = -128f;
					var num7 = 127f;
					var num8 = (decimal)(Chart.FretbarList[1] / Hyperspeed * Math.Log(Math.Abs(1.0 - (float_7 - num2 + 1f) * (1f - FretboardAngle) / (double)Editor_Size.Width), FretboardAngle));
					var num9 = Convert.ToInt32(Audio.GetWaveFormat().int_0 * Audio.GetWaveFormat().short_0 * ((num8 - d) / 1000m));
					d = num8;
					var num10 = j;
					while (num10 < num9 && num10 + i < num5)
					{
						num6 = Math.Max(num6, AudioData[num10 + i]);
						num7 = Math.Min(num7, AudioData[num10 + i]);
						num10 += Audio.GetWaveFormat().short_0;
					}
					var num11 = Convert.ToSingle((float_7 - num2) * Math.Tan(double_1));
					var num12 = Editor_Size.Height - 2f * num11;
					if (num7 != num6)
					{
						var num13 = (num7 + 128f) * num12 / 256f;
						var num14 = (num6 + 128f) * num12 / 256f;
						if (num9 <= 1E-10)
						{
							return;
						}
						if (num13 == num14)
						{
							if (num3 != 0f)
							{
								graphics_0.DrawLine(Pen_TransparentBlue, float_6 + num11 + num, num3, float_6 + num11 + num14, num2);
							}
						}
						else
						{
							graphics_0.DrawLine(Pen_TransparentBlue, float_6 + num11 + num13, num2, float_6 + num11 + num14, num2);
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
			var num = float_5 * 2f;
			var num2 = method_16((VerticalScrollBar.Maximum - VerticalScrollBar.LargeChange - VerticalScrollBar.Value) / 2f);
            if (ShouldDoubleFretbarWidth())
			{
                var int_ = method_16((VerticalScrollBar.Maximum - VerticalScrollBar.LargeChange - VerticalScrollBar.Value) / 2f + FretboardAngleFloat);
				method_25(graphics_0, num2, int_, Width / 4f, Height - num);
                DrawGameViewNotes(graphics_0, num2, int_, Width / 4f, Height - num);
            }
			else
			{
                if (Audio != null && GetAudioStatus() == AudioStatus.ShouldStartAudio)
				{
					num2 = (int)Audio.AudioLength().TotalMilliseconds;
				}
                var int_ = num2 + UsedForCalculatingLastFretbar;
				if (ShowAudioOnFretboard)
				{
					DrawGameviewFretbars(graphics_0, num2, int_, Width / 4f, Height - num);
				}
                method_25(graphics_0, num2, int_, Width / 4f, Height - num);
				DrawGameViewNotes(graphics_0, num2, int_, Width / 4f, Height - num);
            }
            delegate10_0(num2, null);
        }

		public void method_29(Delegate10 delegate10_1)
		{
			var @delegate = delegate10_0;
			Delegate10 delegate2;
			do
			{
				delegate2 = @delegate;
				var value = (Delegate10)Delegate.Combine(delegate2, delegate10_1);
				@delegate = Interlocked.CompareExchange(ref delegate10_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

        protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (Chart == null)
			{
				return;
			}
			var graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (GamemodeView)
			{
				DrawGameView(graphics);
				return;
			}
			DrawFlatView(graphics);
		}

		public new void Dispose()
		{
			if (Audio != null)
			{
				Audio.Dispose();
			}
			base.Dispose();
		}
	}
}
