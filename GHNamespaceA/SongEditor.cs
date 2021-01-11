using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GHNamespace1;
using GHNamespace2;
using GHNamespace7;
using GHNamespace8;
using GHNamespaceM;
using GHNamespaceN;
using Timer = System.Windows.Forms.Timer;

namespace GHNamespaceA
{
    public class SongEditor : UserControl, IDisposable
    {
        public delegate void Delegate10(object sender, EventArgs e);

        [CompilerGenerated]
        private class SongData
        {
            public SongEditor SongEditor0;

            public string FileName;

            public void LoadAudioData(object object0)
            {
                using (GenericAudioStream stream = AudioManager.GetAudioStream(FileName))
                {
                    SongEditor0._audioData = new sbyte[stream.vmethod_1().Uint0 *
                                                       (ulong) stream.vmethod_1().method_0()];
                    float[] array = new float[4096];
                    int num;
                    for (int i = 0; i < SongEditor0._audioData.Length; i += num)
                    {
                        if (i + array.Length < SongEditor0._audioData.Length)
                        {
                            num = stream.vmethod_4(array, 0, array.Length);
                        }
                        else
                        {
                            num = stream.vmethod_4(array, 0, SongEditor0._audioData.Length - i);
                        }
                        for (int j = 0; j < num; j++)
                        {
                            SongEditor0._audioData[i + j] = Class11.smethod_19(array[j]);
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

        private readonly Timer _timer;

        private readonly VScrollBar _verticalScrollBar = new VScrollBar();

        private int _width;

        private int _height;

        private int _int2;

        private int _usedForCalculatingLastFretbar;

        private int _someFretbarValue;

        private int _lastFretbarValue;

        private float _float0;

        private float _fretboardAngleFloat;

        private float _float2;

        private int _lastFretbar;

        private QbcParser _chart;

        private IPlayableAudio _audio;

        private sbyte[] _audioData;

        private readonly Pen _penBlack = Pens.Black;

        private readonly Pen _penGray = Pens.Gray;

        private readonly Pen _penLightGray = Pens.LightGray;

        private bool _doubleFretbarWidth;

        private int _numberOfNoteLines = 4;

        public decimal FretbarWidth;

        private readonly Brush _brushGrayText = SystemBrushes.GrayText;

        private readonly Font _fontVerdana = new Font("Verdana", 24f);

        private readonly Brush[] _noteBrush =
        {
            Brushes.Green,
            Brushes.Red,
            Brushes.Yellow,
            Brushes.Blue,
            Brushes.Orange,
            Brushes.LightGray
        };

        private readonly Pen[] _notePen =
        {
            Pens.Green,
            Pens.Red,
            Pens.Yellow,
            Pens.Blue,
            Pens.Orange,
            Pens.LightGray
        };

        private readonly Pen[] _pen4 = new Pen[6];

        private readonly Brush _brushBlack = Brushes.Black;

        private readonly Brush _brushWhite = Brushes.White;

        private readonly Pen _penBlack2 = Pens.Black;

        private readonly Pen _penTransparentBlue = new Pen(Color.FromArgb(30, Color.Blue));

        private readonly double _double0 = 2.5132741228718345;

        private bool _gamemodeView = true;

        private Size _editorSize = new Size(200, 600);

        private float _float3;

        private double _double1;

        private float _fretboardAngle;

        public string Difficulty;

        public float Float5 = 10f;

        public Size Size1 = new Size(20, 60);

        public bool LoadStarpowerTextures = true;

        public bool LoadHopoTextures = true;

        public bool ShowAudioOnFretboard = true;

        private double _hyperspeed = 1.0;

        private Delegate10 _delegate100;

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
            if (_audio == null)
            {
                return AudioStatus.ShouldStopAudio;
            }
            return _audio.GetStatus();
        }

        public void SetBeatSize(int beatSize)
        {
            if (_chart == null)
            {
                return;
            }
            Size1.Width = beatSize;
            FretbarWidth = Size1.Width / (decimal) _chart.FretbarList[1];
            RedrawFretboard();
        }

        public void SetOffset(int offset)
        {
            if (_chart == null)
            {
                return;
            }
            GuitarHero.Songlist.Gh3Song ghSong = _chart.Gh3Song0;
            _chart.Gh3Song0.GemOffset = offset;
            ghSong.FretbarOffset = offset;
            RedrawFretboard();
        }

        public bool ShouldDoubleFretbarWidth()
        {
            return _doubleFretbarWidth;
        }

        public void SetDoubleFretbarWidth(bool bool5)
        {
            ScrollBar arg220 = _verticalScrollBar;
            _doubleFretbarWidth = bool5;
            arg220.Maximum = (bool5 ? _someFretbarValue : _lastFretbarValue) - 1;
            RedrawFretboard();
        }

        public bool Has5NoteLines()
        {
            return _numberOfNoteLines == 5;
        }

        public void Set5NoteLines(bool bool5)
        {
            _numberOfNoteLines = (bool5 ? 5 : 4);
        }

        public bool IsGamemodeView()
        {
            return _gamemodeView;
        }

        public void SetGamemodeView(bool isGamemode)
        {
            _gamemodeView = isGamemode;
            RedrawFretboard();
        }

        public void SetHyperspeed(double hyperspeed)
        {
            _hyperspeed = hyperspeed;
            RedrawFretboard();
        }

        public void SetFretboardAngle(double double3)
        {
            _fretboardAngle = Convert.ToSingle(Math.Pow(Math.Cos(_double1 = 3.1415926535897932 * double3 / 180.0),
                7.3890560989306495));
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
            Controls.Add(_verticalScrollBar);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true);
            _timer = new Timer
            {
                Interval = 20
            };
            _timer.Tick += timer_0_Tick;
            _timer.Start();
        }

        public void LoadChart(QbcParser chartFile)
        {
            _chart = chartFile;
            chartFile.FretbarList[0] = 0;
            _lastFretbar = _chart.FretbarList[_chart.FretbarList.Count - 1];
            FretbarWidth = Size1.Width / (decimal) _chart.FretbarList[1];
            SetFretboardAngle(15.0);
            Difficulty = "expert";
            for (int i = 0; i < _noteBrush.Length; i++)
            {
                _pen4[i] = new Pen(_noteBrush[i], Size1.Height / 24f);
            }
            RedrawFretboard();
        }

        public void LoadAudio(string fileName)
        {
            SongData songData = new SongData
            {
                FileName = fileName,
                SongEditor0 = this
            };
            if (_audio != null)
            {
                _audio.Dispose();
            }
            GenericAudioStream audioStream = AudioManager.GetAudioStream(songData.FileName);
            if (audioStream == null)
            {
                return;
            }
            _audio = AudioManager.LoadPlayableAudio(Enum25.Const2, audioStream);
            ThreadPool.QueueUserWorkItem(songData.LoadAudioData);
        }

        private void RedrawFretboard()
        {
            if (_chart == null)
            {
                return;
            }
            _verticalScrollBar.Height = (_height = Height);
            _width = (_verticalScrollBar.Left = Width - _verticalScrollBar.Width);
            _verticalScrollBar.Top = 0;
            _editorSize.Height = _width / 2;
            _editorSize.Width = _editorSize.Height / 3;
            _float0 = Size1.Height + Float5 * (Has5NoteLines() ? 4 : 5);
            _float3 = _editorSize.Width / (1f - _fretboardAngle);
            if (_float3 > _height * 3f / 4f)
            {
                _float3 = _height * 3f / 4f;
            }
            _fretboardAngleFloat = (IsGamemodeView()
                ? Convert.ToSingle(Math.Log(
                    Math.Abs(1.0 - _float3 * (1f - _fretboardAngle) / (double) _editorSize.Width), _fretboardAngle))
                : ((_width - Float5 * 2f) / Size1.Width));
            _someFretbarValue = (int) Math.Ceiling(_chart.FretbarList.Count / (double) _fretboardAngleFloat);
            _usedForCalculatingLastFretbar = (IsGamemodeView()
                ? Convert.ToInt32(_chart.FretbarList[1] / _hyperspeed *
                                  Math.Log(
                                      Math.Abs(1.0 - _float3 * (1f - _fretboardAngle) / (double) _editorSize.Width),
                                      _fretboardAngle))
                : method_15(_width - Float5 * 2f));
            _lastFretbarValue = (int) Math.Ceiling(_lastFretbar / (double) _usedForCalculatingLastFretbar);
            _int2 = _height / (int) _float0;
            _verticalScrollBar.Minimum = 0;
            _verticalScrollBar.SmallChange = 1;
            _verticalScrollBar.LargeChange = (IsGamemodeView() ? ((int) _fretboardAngleFloat) : _int2);
            _verticalScrollBar.Maximum = (IsGamemodeView()
                ? (_chart.FretbarList.Count * 2 + _verticalScrollBar.LargeChange)
                : ((ShouldDoubleFretbarWidth() ? _someFretbarValue : _lastFretbarValue) - 1));
            _verticalScrollBar.Value = (IsGamemodeView()
                ? (_verticalScrollBar.Maximum - _verticalScrollBar.LargeChange)
                : 0);
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
            _float2 = e.X - Float5;
            if (_float2 < 0f)
            {
                _float2 = 0f;
                return;
            }
            if (_float2 > Width - Float5 * 2f)
            {
                _float2 = Width - Float5 * 2f;
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
            int num = _verticalScrollBar.Value - e.Delta / SystemInformation.MouseWheelScrollDelta;
            if (_verticalScrollBar.Maximum - (_verticalScrollBar.LargeChange - _verticalScrollBar.SmallChange) >= num &&
                _verticalScrollBar.Minimum <= num)
            {
                _verticalScrollBar.Value = num;
            }
        }

        private float method_14(int int8)
        {
            return Convert.ToSingle(int8 * FretbarWidth);
        }

        private int method_15(float float6)
        {
            return Convert.ToInt32((decimal) float6 / FretbarWidth);
        }

        private int method_16(float float6)
        {
            int num = (int) Math.Floor(float6);
            if (num + 1 >= _chart.FretbarList.Count)
            {
                return _lastFretbar;
            }
            if (num < 0)
            {
                return 0;
            }
            int num2 = _chart.FretbarList[num];
            return num2 + Convert.ToInt32((float6 - num) * (_chart.FretbarList[num + 1] - num2));
        }

        private static bool smethod_0(bool[] bool5, bool[] bool6)
        {
            for (int i = 0; i < 5; i++)
            {
                if (bool5[i] && bool6[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void method_17(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            int8 += _chart.Gh3Song0.FretbarOffset;
            int9 += _chart.Gh3Song0.FretbarOffset;
            graphics0.SetClip(new RectangleF(float6, 0f, _width - float6 * 2f, _height));
            int count = _chart.FretbarList.Count;
            int num = _chart.FretbarList.method_7(int8);
            int num2 = _chart.FretbarList.method_7(int9);
            int num3 = _chart.FretbarList[num];
            float num4 = (num + 1 < count) ? ((int8 - num3) / (float) (_chart.FretbarList[num + 1] - num3)) : 0f;
            int count2 = _chart.TsList.Count;
            int num5 = _chart.TsList.method_1(num3);
            int num6 = _chart.TsList.Values[num5][0];
            int num7 = _chart.FretbarList.method_7(_chart.TsList.Keys[num5]);
            int num8 = (count2 > num5 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num5 + 1]) : -1;
            float num9 = 0f;
            float y = float7 + Size1.Height;
            for (int i = num; i <= num2; i++)
            {
                int num10 = _chart.FretbarList[i];
                if (ShouldDoubleFretbarWidth())
                {
                    num9 = float6 + (i - num - num4) * Size1.Width;
                }
                else
                {
                    num9 = float6 + method_14(num10 - int8);
                }
                if (i - num7 == 0)
                {
                    graphics0.DrawString(string.Concat(num6), _fontVerdana, _brushGrayText, num9 - 4f, float7 - 3f);
                    graphics0.DrawString(string.Concat(4), _fontVerdana, _brushGrayText, num9 - 4f,
                        float7 + Size1.Height / 2f - 3f);
                }
                if (i == num8)
                {
                    num5++;
                    num6 = _chart.TsList.Values[num5][0];
                    num7 = _chart.FretbarList.method_7(_chart.TsList.Keys[num5]);
                    num8 = ((count2 > num5 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num5 + 1]) : -1);
                    graphics0.DrawString(string.Concat(num6), _fontVerdana, _brushGrayText, num9 - 4f, float7 - 3f);
                    graphics0.DrawString(string.Concat(4), _fontVerdana, _brushGrayText, num9 - 4f,
                        float7 + Size1.Height / 2f - 3f);
                }
                if (num9 >= float6)
                {
                    graphics0.DrawLine(((i - num7) % num6 == 0) ? _penBlack : _penGray, num9, float7, num9, y);
                }
                if (i + 1 < count)
                {
                    if (ShouldDoubleFretbarWidth())
                    {
                        num9 += 0.5f * Size1.Width;
                    }
                    else
                    {
                        num9 += method_14(_chart.FretbarList[i + 1] - num10) / 2f;
                    }
                    if (num9 >= float6 && num9 <= _width - float6)
                    {
                        graphics0.DrawLine(_penLightGray, num9, float7, num9, y);
                    }
                }
            }
            float x = (int9 >= _lastFretbar) ? num9 : (_width - float6);
            for (int j = 1; j < _numberOfNoteLines; j++)
            {
                graphics0.DrawLine(_penGray, float6, y = float7 + j * Size1.Height / (float) _numberOfNoteLines, x, y);
            }
            graphics0.DrawLine(_penBlack, float6, float7, x, float7);
            graphics0.DrawLine(_penBlack, float6, y = float7 + Size1.Height, x, y);
            graphics0.ResetClip();
        }

        private void DrawFlatViewNotes(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            int8 += _chart.Gh3Song0.GemOffset;
            int9 += _chart.Gh3Song0.GemOffset;
            Track<int, NotesAtOffset> @class = _chart.NoteList.ContainsKey(Difficulty)
                ? _chart.NoteList[Difficulty]
                : new Track<int, NotesAtOffset>();
            Track<int, int[]> class2 = _chart.SpList.ContainsKey(Difficulty) ? _chart.SpList[Difficulty] : new Track<int, int[]>();
            int arg_9A0 = @class.Count;
            int num = @class.method_1(int8);
            int num2 = @class.method_1(int9);
            int num3 = @class.Keys[num];
            if (int8 < _lastFretbar && num3 <= int9)
            {
                int count = _chart.FretbarList.Count;
                int num4 = _chart.FretbarList.method_7(num3);
                int num5 = _chart.FretbarList[num4];
                int num6 = _chart.FretbarList[num4 + 1] - num5;
                int num7 = (count > num4 + 1) ? @class.method_2(_chart.FretbarList[num4 + 1]) : -1;
                int num8 = _chart.FretbarList.method_7(int8);
                float num9 = (int8 - _chart.FretbarList[num8]) /
                           (float) (_chart.FretbarList[num8 + 1] - _chart.FretbarList[num8]);
                int count2 = _chart.TsList.Count;
                int num10 = _chart.TsList.method_1(num3);
                int num11 = _chart.TsList.Values[num10][0];
                int num12 = (count2 > num10 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num10 + 1]) : -1;
                int count3 = class2.Count;
                int num13 = class2.method_1(num3);
                int num14 = (class2.Count == 0 || class2.Keys[num13] > num3)
                    ? -1
                    : (class2.Keys[num13] + class2.Values[num13][0]);
                int num15 = (count3 > num13 + 1)
                    ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13])
                    : -1;
                if (num14 == -1)
                {
                    num13--;
                }
                float num16 = Size1.Height / (float) _numberOfNoteLines;
                float num17 = Size1.Height / 15f;
                float num18 = num17 / 1.6f;
                float num19 = num17 * 2f;
                float num20 = num18 * 2f;
                float val = _width - float6;
                if (Has5NoteLines())
                {
                    float7 += num16 / 2f;
                }
                for (int i = num; i <= num2; i++)
                {
                    int num21 = @class.Keys[i];
                    NotesAtOffset class3 = @class[num21];
                    if (i == num7)
                    {
                        num4 = _chart.FretbarList.method_7(num21);
                        num5 = _chart.FretbarList[num4];
                        num6 = _chart.FretbarList[num4 + 1] - num5;
                        num7 = ((count > num4 + 1) ? @class.method_2(_chart.FretbarList[num4 + 1]) : -1);
                    }
                    if (i == num12)
                    {
                        num10++;
                        num11 = _chart.TsList.Values[num10][0];
                        num12 = ((count2 > num10 + 1)
                            ? _chart.FretbarList.method_7(_chart.TsList.Keys[num10 + 1])
                            : -1);
                    }
                    if (i == num15)
                    {
                        num13++;
                        num14 = class2.Keys[num13] + class2.Values[num13][0];
                        num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
                    }
                    bool showDrawSp = LoadStarpowerTextures && num14 >= num21;
                    float num22;
                    float num23;
                    if (ShouldDoubleFretbarWidth())
                    {
                        num22 = Math.Max(float6 + (num4 - num8 - num9 + (num21 - num5) / (float) num6) * Size1.Width,
                            float6);
                        if (class3.SustainLength - _chart.Int0 > _chart.Int0)
                        {
                            num23 = num21 + class3.SustainLength - _chart.Int0;
                            int num24 = _chart.FretbarList.method_7((int) num23);
                            num23 =
                                Math.Min(
                                    float6 +
                                    (num24 - num8 - num9 + (num23 - _chart.FretbarList[num24]) /
                                     (_chart.FretbarList[num24 + 1] - _chart.FretbarList[num24])) * Size1.Width, val);
                        }
                        else
                        {
                            num23 = -1f;
                        }
                    }
                    else
                    {
                        num22 = float6 + method_14(num21 - int8);
                        num23 = ((class3.SustainLength - _chart.Int0 > _chart.Int0)
                            ? Math.Min(num22 + method_14(class3.SustainLength - _chart.Int0), val)
                            : -1f);
                        num22 = Math.Max(num22, float6);
                    }
                    if (num23 == -1f || num23 >= float6)
                    {
                        bool shouldDrawHopo = LoadHopoTextures &&
                                             ((i != 0 &&
                                               smethod_0(@class[@class.Keys[i - 1]].NoteValues, class3.NoteValues) &&
                                               num21 - @class.Keys[i - 1] <=
                                               num11 / 4f * num6 /
                                               ((_chart.Gh3Song0.HammerOn == 0f)
                                                   ? QbcParser.Float0
                                                   : _chart.Gh3Song0.HammerOn)) ^ class3.NoteValues[5]);
                        for (int j = 0; j < 6; j++)
                        {
                            if (class3.NoteValues[j])
                            {
                                float num25 = float7 + num16 * j;
                                if (num23 != -1f)
                                {
                                    graphics0.DrawLine(_pen4[j], num22, num25, num23, num25);
                                    graphics0.DrawRectangle(_penBlack2, num22, num25 - 1f, num23 - num22,
                                        _pen4[j].Width);
                                }
                                if (num != i || num == 0)
                                {
                                    if (showDrawSp)
                                    {
                                        PointF[] array = new PointF[5];
                                        for (int k = 0; k < 5; k++)
                                        {
                                            array[k] =
                                                new PointF(num22 + num19 * (float) Math.Sin(k * _double0),
                                                    num25 - num19 * (float) Math.Cos(k * _double0));
                                        }
                                        graphics0.FillPolygon(_brushBlack, array, FillMode.Winding);
                                    }
                                    RectangleF rect = new RectangleF(num22 - num17, num25 - num17, num19, num19);
                                    graphics0.FillEllipse(_noteBrush[j], rect);
                                    graphics0.DrawEllipse(_penBlack2, rect);
                                    if (shouldDrawHopo)
                                    {
                                        rect = new RectangleF(num22 - num18, num25 - num18, num20, num20);
                                        graphics0.FillEllipse(_brushWhite, rect);
                                        graphics0.DrawEllipse(_penBlack2, rect);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DrawAudio(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            if (_audioData == null)
            {
                return;
            }
            float num = float6;
            float x = num;
            float num2 = 0f;
            int num3 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 * (int8 / 1000m));
            int num4 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 * (int9 / 1000m));
            num4 = Math.Min(num4, _audioData.Length);
            int num5 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 /
                                       (FretbarWidth * 1000m));
            int i = num3;
            for (int j = 0; j < (int) _audio.GetWaveFormat().short_0; j++)
            {
                while (i < num4)
                {
                    float num6 = -128f;
                    float num7 = 127f;
                    if (ShouldDoubleFretbarWidth())
                    {
                        num5 = Size1.Width;
                    }
                    int num8 = j;
                    while (num8 < num5 && num8 + i < num4)
                    {
                        num6 = Math.Max(num6, _audioData[num8 + i]);
                        num7 = Math.Min(num7, _audioData[num8 + i]);
                        num8 += _audio.GetWaveFormat().short_0;
                    }
                    float num9 = (num7 + 128f) * Size1.Height / 256f;
                    float num10 = (num6 + 128f) * Size1.Height / 256f;
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
                                graphics0.DrawLine(_penTransparentBlue, x, float7 + num2, num, float7 + num10);
                            }
                        }
                        else
                        {
                            graphics0.DrawLine(_penTransparentBlue, num, float7 + num9, num, float7 + num10);
                        }
                    }
                    x = num;
                    num2 = num10;
                    num += 1f;
                    i += num5;
                }
                num = float6;
                x = num;
                num2 = 0f;
                i = num3;
            }
        }

        private void DrawFlatView(Graphics graphics0)
        {
            int num = 0;
            int num2 = 0;
            if (ShouldDoubleFretbarWidth())
            {
                int num3 = Math.Min(_int2, _someFretbarValue);
                for (int i = 0; i < num3; i++)
                {
                    num = method_16(_fretboardAngleFloat * (_verticalScrollBar.Value + i));
                    num2 = method_16(_fretboardAngleFloat * (_verticalScrollBar.Value + i + 1));
                    float num4 = Float5 * 2f + _float0 * i;
                    method_17(graphics0, num, num2, Float5, num4);
                    DrawFlatViewNotes(graphics0, num, num2, Float5, num4);
                }
            }
            else
            {
                int num5 = Math.Min(_int2, _lastFretbarValue);
                int j = 0;
                if (_audio != null)
                {
                    j = (int) _audio.AudioLength().TotalMilliseconds;
                }
                if (GetAudioStatus() == AudioStatus.ShouldStartAudio)
                {
                    while (j < _usedForCalculatingLastFretbar * _verticalScrollBar.Value)
                    {
                        _verticalScrollBar.Value--;
                    }
                }
                for (int k = 0; k < num5; k++)
                {
                    num = _usedForCalculatingLastFretbar * (_verticalScrollBar.Value + k);
                    num2 = _usedForCalculatingLastFretbar * (_verticalScrollBar.Value + k + 1);
                    float num4 = Float5 * 2f + _float0 * k;
                    if (ShowAudioOnFretboard)
                    {
                        DrawAudio(graphics0, num, num2, Float5, num4);
                    }
                    method_17(graphics0, num, num2, Float5, num4);
                    DrawFlatViewNotes(graphics0, num, num2, Float5, num4);
                    if (_audio != null && num <= j && j <= num2)
                    {
                        SmoothingMode smoothingMode = graphics0.SmoothingMode;
                        graphics0.SmoothingMode = SmoothingMode.None;
                        graphics0.DrawLine(_penBlack2, Float5 + method_14(j - num), num4 - 5f,
                            Float5 + method_14(j - num), num4 + Size1.Height + 5f);
                        graphics0.SmoothingMode = smoothingMode;
                    }
                }
                if (GetAudioStatus() == AudioStatus.ShouldStartAudio && j > num2 &&
                    _verticalScrollBar.Value + num5 <= _verticalScrollBar.Maximum)
                {
                    _verticalScrollBar.Value += num5;
                }
            }
            _delegate100(num, null);
        }

        public void DifferentStartPlaying()
        {
            if (_audio != null)
            {
                _audio.DifferentStartPlaying();
            }
        }

        public void StartPlaying()
        {
            if (_audio != null)
            {
                _audio.StartPlaying();
            }
        }

        public void StopAudio()
        {
            if (_audio != null)
            {
                _audio.StopPlaying();
                _audio.SetStartingTimeBasedOnSomeValue(0);
            }
        }

        public bool AudioLoaded()
        {
            return _audio != null;
        }

        private void method_25(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            int8 += _chart.Gh3Song0.FretbarOffset;
            int9 += _chart.Gh3Song0.FretbarOffset;
            int count = _chart.FretbarList.Count;
            int num = _chart.FretbarList.method_7(int8);
            int num2 = _chart.FretbarList.method_7(int9);
            int num3 = _chart.FretbarList[num];
            float num4 = (num + 1 < count) ? ((int8 - num3) / (float) (_chart.FretbarList[num + 1] - num3)) : 0f;
            int count2 = _chart.TsList.Count;
            int num5 = _chart.TsList.method_1(num3);
            int num6 = _chart.TsList.Values[num5][0];
            int num7 = _chart.FretbarList.method_7(_chart.TsList.Keys[num5]);
            int num8 = (count2 > num5 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num5 + 1]) : -1;
            float num10;
            for (int i = num; i <= num2; i++)
            {
                int num9 = _chart.FretbarList[i];
                if (ShouldDoubleFretbarWidth())
                {
                    num10 = float7 - Convert.ToSingle(_editorSize.Width *
                                                      (1.0 - Math.Pow(_fretboardAngle, i - num - num4)) /
                                                      (1f - _fretboardAngle));
                }
                else
                {
                    num10 = float7 - Convert.ToSingle(_editorSize.Width *
                                                      (1.0 - Math.Pow(_fretboardAngle,
                                                           _hyperspeed * (num9 - int8) / _chart.FretbarList[1])) /
                                                      (1f - _fretboardAngle));
                }
                if (i - num7 == 0)
                {
                    float num11 = Convert.ToSingle((float7 - num10) * Math.Tan(_double1));
                    Font font = new Font("Verdana", Math.Max(0f, (_editorSize.Height - 2f * num11) / 15f));
                    graphics0.DrawString(num6 + "/" + _chart.TsList.Values[num5][1], font, _brushGrayText,
                        float6 + _editorSize.Height + 5f - num11, num10 - font.Size);
                }
                if (i == num8)
                {
                    num5++;
                    num6 = _chart.TsList.Values[num5][0];
                    num7 = _chart.FretbarList.method_7(_chart.TsList.Keys[num5]);
                    num8 = ((count2 > num5 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num5 + 1]) : -1);
                    float num11 = Convert.ToSingle((float7 - num10) * Math.Tan(_double1));
                    Font font2 = new Font("Verdana", Math.Max(0f, (_editorSize.Height - 2f * num11) / 15f));
                    graphics0.DrawString(num6 + "/" + _chart.TsList.Values[num5][1], font2, _brushGrayText,
                        float6 + _editorSize.Height + 5f - num11, num10 - font2.Size);
                }
                if (num10 <= float7)
                {
                    float num11;
                    graphics0.DrawLine(((i - num7) % num6 == 0) ? _penBlack : _penGray,
                        float6 + (num11 = Convert.ToSingle((float7 - num10) * Math.Tan(_double1))), num10,
                        float6 + _editorSize.Height - num11, num10);
                }
                if (i + 1 < count && i + 1 <= num2)
                {
                    if (ShouldDoubleFretbarWidth())
                    {
                        num10 = float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle, i - num - num4 + 0.5f)) /
                                                          (1f - _fretboardAngle));
                    }
                    else
                    {
                        num10 = float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle,
                                                               _hyperspeed *
                                                               ((_chart.FretbarList[i + 1] - num9) / 2 + num9 - int8) /
                                                               _chart.FretbarList[1])) / (1f - _fretboardAngle));
                    }
                    if (num10 <= float7 && num10 >= _height - float7)
                    {
                        float num11;
                        graphics0.DrawLine(_penLightGray,
                            float6 + (num11 = Convert.ToSingle((float7 - num10) * Math.Tan(_double1))), num10,
                            float6 + _editorSize.Height - num11, num10);
                    }
                }
            }
            num10 = float7 - _float3;
            float num12 = Convert.ToSingle((float7 - num10) * Math.Tan(_double1));
            float num13 = _editorSize.Height - 2f * num12;
            for (int j = 0; j <= _numberOfNoteLines; j++)
            {
                graphics0.DrawLine(_penGray, float6 + j * _editorSize.Height / (float) _numberOfNoteLines, float7,
                    float6 + num12 + j * num13 / _numberOfNoteLines, num10);
            }
        }

        private void DrawGameViewNotes(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            int8 += _chart.Gh3Song0.GemOffset;
            int9 += _chart.Gh3Song0.GemOffset;
            Track<int, NotesAtOffset> @class = _chart.NoteList.ContainsKey(Difficulty)
                ? _chart.NoteList[Difficulty]
                : new Track<int, NotesAtOffset>();
            Track<int, int[]> class2 = _chart.SpList.ContainsKey(Difficulty) ? _chart.SpList[Difficulty] : new Track<int, int[]>();
            if (@class.Count == 0)
            {
                return;
            }
            int argA30 = @class.Count;
            int num = @class.method_1(int8);
            int num2 = @class.method_1(int9);
            int num3 = @class.Keys[num];
            if (int8 < _lastFretbar && num3 <= int9)
            {
                int count = _chart.FretbarList.Count;
                int num4 = _chart.FretbarList.method_7(num3);
                int num5 = _chart.FretbarList[num4];
                int num6 = _chart.FretbarList[num4 + 1] - num5;
                int num7 = (count > num4 + 1) ? @class.method_2(_chart.FretbarList[num4 + 1]) : -1;
                int num8 = _chart.FretbarList.method_7(int8);
                _chart.FretbarList.method_7(int9);
                float num9 = (int8 - _chart.FretbarList[num8]) /
                           (float) (_chart.FretbarList[num8 + 1] - _chart.FretbarList[num8]);
                int count2 = _chart.TsList.Count;
                int num10 = _chart.TsList.method_1(num3);
                int num11 = _chart.TsList.Values[num10][0];
                int num12 = (count2 > num10 + 1) ? _chart.FretbarList.method_7(_chart.TsList.Keys[num10 + 1]) : -1;
                int count3 = class2.Count;
                int num13 = class2.method_1(num3);
                int num14 = (class2.Count == 0 || class2.Keys[num13] > num3)
                    ? -1
                    : (class2.Keys[num13] + class2.Values[num13][0]);
                int num15 = (count3 > num13 + 1)
                    ? @class.method_1(class2.Keys[(num14 != -1) ? (num13 + 1) : num13])
                    : -1;
                if (num14 == -1)
                {
                    num13--;
                }
                float num16 = _editorSize.Height / (float) _numberOfNoteLines;
                float num17 = _editorSize.Height / 15f;
                float num18 = num17 / 1.6f;
                float num19 = num17 * 2f;
                float num20 = num18 * 2f;
                float val = float7 - _float3;
                for (int i = num; i <= num2; i++)
                {
                    int num21 = @class.Keys[i];
                    NotesAtOffset class3 = @class[num21];
                    if (i == num7)
                    {
                        num4 = _chart.FretbarList.method_7(num21);
                        num5 = _chart.FretbarList[num4];
                        num6 = _chart.FretbarList[num4 + 1] - num5;
                        num7 = ((count > num4 + 1) ? @class.method_2(_chart.FretbarList[num4 + 1]) : -1);
                    }
                    if (i == num12)
                    {
                        num10++;
                        num11 = _chart.TsList.Values[num10][0];
                        num12 = ((count2 > num10 + 1)
                            ? _chart.FretbarList.method_7(_chart.TsList.Keys[num10 + 1])
                            : -1);
                    }
                    if (i == num15)
                    {
                        num13++;
                        num14 = class2.Keys[num13] + class2.Values[num13][0];
                        num15 = ((count3 > num13 + 1) ? @class.method_1(class2.Keys[num13 + 1]) : -1);
                    }
                    bool shouldDrawSp = LoadStarpowerTextures && num14 >= num21;
                    float num22;
                    float num23;
                    if (ShouldDoubleFretbarWidth())
                    {
                        num22 =
                            Math.Min(
                                float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle,
                                                               num4 - num8 - num9 + (num21 - num5) / (float) num6)) /
                                                          (1f - _fretboardAngle)), float7);
                        if (class3.SustainLength - _chart.Int0 > _chart.Int0)
                        {
                            num23 = num21 + class3.SustainLength - _chart.Int0;
                            int num24 = _chart.FretbarList.method_7((int) num23);
                            num23 = Math.Max(
                                float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle,
                                                               num24 - num8 - num9 +
                                                               (num23 - _chart.FretbarList[num24]) /
                                                               (_chart.FretbarList[num24 + 1] -
                                                                _chart.FretbarList[num24]))) / (1f - _fretboardAngle)),
                                val);
                        }
                        else
                        {
                            num23 = -1f;
                        }
                    }
                    else
                    {
                        num22 = float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle,
                                                               _hyperspeed * (num21 - int8) / _chart.FretbarList[1])) /
                                                          (1f - _fretboardAngle));
                        num23 = ((class3.SustainLength - _chart.Int0 > _chart.Int0)
                            ? Math.Max(
                                float7 - Convert.ToSingle(_editorSize.Width *
                                                          (1.0 - Math.Pow(_fretboardAngle,
                                                               _hyperspeed *
                                                               (num21 - int8 + class3.SustainLength - _chart.Int0) /
                                                               _chart.FretbarList[1])) / (1f - _fretboardAngle)), val)
                            : -1f);
                        num22 = Math.Min(num22, float7);
                    }
                    if (num23 == -1f || num23 <= float7)
                    {
                        bool shouldDrawHopo = LoadHopoTextures &&
                                             ((i != 0 &&
                                               smethod_0(@class[@class.Keys[i - 1]].NoteValues, class3.NoteValues) &&
                                               num21 - @class.Keys[i - 1] <=
                                               num11 / 4f * num6 /
                                               ((_chart.Gh3Song0.HammerOn == 0f)
                                                   ? QbcParser.Float0
                                                   : _chart.Gh3Song0.HammerOn)) ^ class3.NoteValues[5]);
                        float num25 = float6 + Convert.ToSingle((float7 - num22) * Math.Tan(_double1));
                        num16 = (_editorSize.Height - 2f * (num25 - float6)) / _numberOfNoteLines;
                        float num26 = float6 + Convert.ToSingle((float7 - num23) * Math.Tan(_double1));
                        float num27 = (_editorSize.Height - 2f * (num26 - float6)) / _numberOfNoteLines;
                        num17 = (_editorSize.Height - 2f * (num25 - float6)) / 15f;
                        num18 = num17 / 1.6f;
                        num19 = num17 * 2f;
                        num20 = num18 * 2f;
                        float num28 = (_editorSize.Height - 2f * (num25 - float6)) / 32f;
                        float num29 = (_editorSize.Height - 2f * (num26 - float6)) / 32f;
                        if (Has5NoteLines())
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
                            if (class3.NoteValues[j])
                            {
                                if (num23 != -1f)
                                {
                                    PointF[] points =
                                    {
                                        new PointF(num25 - num28, num22),
                                        new PointF(num26 - num29, num23),
                                        new PointF(num26 + num29, num23),
                                        new PointF(num25 + num28, num22)
                                    };
                                    graphics0.FillPolygon(_noteBrush[j], points);
                                }
                                if (num != i || num == 0)
                                {
                                    if (shouldDrawSp)
                                    {
                                        PointF[] trianlePositions = new PointF[5];
                                        for (int k = 0; k < 5; k++)
                                        {
                                            trianlePositions[k] =
                                                new PointF(num25 - num19 * (float) Math.Sin(k * _double0),
                                                    num22 + num19 * _fretboardAngle * (float) Math.Cos(k * _double0));
                                        }
                                        graphics0.FillPolygon(_brushBlack, trianlePositions, FillMode.Winding);
                                    }
                                    RectangleF rect = new RectangleF(num25 - num17, num22 - num17 * _fretboardAngle, num19,
                                        num19 * _fretboardAngle);
                                    graphics0.FillEllipse(_noteBrush[j], rect);
                                    graphics0.DrawEllipse(_penBlack2, rect);
                                    if (shouldDrawHopo)
                                    {
                                        rect =
                                            new RectangleF(num25 - num18, num22 - num18 * _fretboardAngle, num20,
                                                num20 * _fretboardAngle);
                                        graphics0.FillEllipse(_brushWhite, rect);
                                        graphics0.DrawEllipse(_penBlack2, rect);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DrawGameviewFretbars(Graphics graphics0, int int8, int int9, float float6, float float7)
        {
            if (_audioData == null)
            {
                return;
            }
            float num = 0f;
            float num2 = float7;
            float num3 = num2;
            int num4 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 * (int8 / 1000m));
            int num5 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 * (int9 / 1000m));
            num5 = Math.Min(num5, _audioData.Length);
            decimal d = 0m;
            int i = num4;
            for (int j = 0; j < (int) _audio.GetWaveFormat().short_0; j++)
            {
                while (i < num5)
                {
                    float num6 = -128f;
                    float num7 = 127f;
                    decimal num8 = (decimal) (_chart.FretbarList[1] / _hyperspeed *
                                          Math.Log(
                                              Math.Abs(
                                                  1.0 - (float7 - num2 + 1f) * (1f - _fretboardAngle) /
                                                  (double) _editorSize.Width), _fretboardAngle));
                    int num9 = Convert.ToInt32(_audio.GetWaveFormat().int_0 * _audio.GetWaveFormat().short_0 *
                                               ((num8 - d) / 1000m));
                    d = num8;
                    int num10 = j;
                    while (num10 < num9 && num10 + i < num5)
                    {
                        num6 = Math.Max(num6, _audioData[num10 + i]);
                        num7 = Math.Min(num7, _audioData[num10 + i]);
                        num10 += _audio.GetWaveFormat().short_0;
                    }
                    float num11 = Convert.ToSingle((float7 - num2) * Math.Tan(_double1));
                    float num12 = _editorSize.Height - 2f * num11;
                    if (num7 != num6)
                    {
                        float num13 = (num7 + 128f) * num12 / 256f;
                        float num14 = (num6 + 128f) * num12 / 256f;
                        if (num9 <= 1E-10)
                        {
                            return;
                        }
                        if (num13 == num14)
                        {
                            if (num3 != 0f)
                            {
                                graphics0.DrawLine(_penTransparentBlue, float6 + num11 + num, num3,
                                    float6 + num11 + num14, num2);
                            }
                        }
                        else
                        {
                            graphics0.DrawLine(_penTransparentBlue, float6 + num11 + num13, num2,
                                float6 + num11 + num14, num2);
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
                num2 = float7;
                num3 = num2;
                i = num4;
                d = 0m;
            }
        }

        private void DrawGameView(Graphics graphics0)
        {
            float num = Float5 * 2f;
            int num2 = method_16(
                (_verticalScrollBar.Maximum - _verticalScrollBar.LargeChange - _verticalScrollBar.Value) / 2f);
            if (ShouldDoubleFretbarWidth())
            {
                int int_ = method_16(
                    (_verticalScrollBar.Maximum - _verticalScrollBar.LargeChange - _verticalScrollBar.Value) / 2f +
                    _fretboardAngleFloat);
                method_25(graphics0, num2, int_, _width / 4f, _height - num);
                DrawGameViewNotes(graphics0, num2, int_, _width / 4f, _height - num);
            }
            else
            {
                if (_audio != null && GetAudioStatus() == AudioStatus.ShouldStartAudio)
                {
                    num2 = (int) _audio.AudioLength().TotalMilliseconds;
                }
                int int_ = num2 + _usedForCalculatingLastFretbar;
                if (ShowAudioOnFretboard)
                {
                    DrawGameviewFretbars(graphics0, num2, int_, _width / 4f, _height - num);
                }
                method_25(graphics0, num2, int_, _width / 4f, _height - num);
                DrawGameViewNotes(graphics0, num2, int_, _width / 4f, _height - num);
            }
            _delegate100(num2, null);
        }

        public void method_29(Delegate10 delegate101)
        {
            Delegate10 @delegate = _delegate100;
            Delegate10 delegate2;
            do
            {
                delegate2 = @delegate;
                Delegate10 value = (Delegate10) Delegate.Combine(delegate2, delegate101);
                @delegate = Interlocked.CompareExchange(ref _delegate100, value, delegate2);
            } while (@delegate != delegate2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_chart == null)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (_gamemodeView)
            {
                DrawGameView(graphics);
                return;
            }
            DrawFlatView(graphics);
        }

        public new void Dispose()
        {
            if (_audio != null)
            {
                _audio.Dispose();
            }
            base.Dispose();
        }
    }
}