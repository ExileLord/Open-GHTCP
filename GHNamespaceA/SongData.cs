using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GHNamespace1;
using GHNamespace2;
using GHNamespace7;
using GHNamespace8;
using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceM;
using GHNamespaceN;
using GuitarHero.Songlist;
using MidiConverter;

namespace GHNamespaceA
{
    public class SongData : Form
    {
        private IContainer icontainer_0;

        private TextBox _guitarAudioTxt;

        private Label _label6;

        private GroupBox _audioGroupBox;

        private Label _label3;

        private TextBox _bandAudioTxt;

        private Label _label2;

        private TextBox _rhythmAudioTxt;

        private Button _guitarAudioBtn;

        private Label _label1;

        private RadioButton _multiAudioBtn;

        private RadioButton _singleAudioBtn;

        private Button _bandAudioBtn;

        private Button _rhythmAudioBtn;

        private GroupBox _chartGroupBox;

        private Label _label9;

        private Label _label8;

        private Label _label7;

        private Label _label5;

        private Button _chartFileBtn;

        private Label _label4;

        private TextBox _chartFileTxt;

        private GroupBox _groupBox3;

        private ComboBox _expertGuitarBox;

        private ComboBox _hardGuitarBox;

        private ComboBox _mediumGuitarBox;

        private ComboBox _easyGuitarBox;

        private GroupBox _groupBox5;

        private ComboBox _expertCoop2Box;

        private ComboBox _hardCoop2Box;

        private ComboBox _mediumCoop2Box;

        private ComboBox _easyCoop2Box;

        private GroupBox _groupBox4;

        private ComboBox _expertRhythmBox;

        private ComboBox _hardRhythmBox;

        private ComboBox _mediumRhythmBox;

        private ComboBox _easyRhythmBox;

        private GroupBox _groupBox6;

        private ComboBox _expertCoopBox;

        private ComboBox _hardCoopBox;

        private ComboBox _mediumCoopBox;

        private ComboBox _easyCoopBox;

        private Button _autoConfigBtn;

        private Button _resetBtn;

        private Label _label10;

        private TextBox _songNameTxt;

        private GroupBox _mainGroupBox;

        private CheckBox _chartCheckBox;

        private CheckBox _audioCheckBox;

        private Button _cancelBtn;

        private Button _applyBtn;

        private Label _label11;

        private Control1 _previewSlider;

        private Label _label12;

        private Button _bandCoopBtn;

        private Button _rhythmCoopBtn;

        private Button _guitarCoopBtn;

        private TextBox _bandCoopTxt;

        private TextBox _rhythmCoopTxt;

        private TextBox _guitarCoopTxt;

        private RadioButton _coopAudioBtn;

        private RadioButton _dualAudioBtn;

        private GroupBox _groupBox1;

        private ComboBox _faceOffP1Box;

        private Label _label13;

        private GroupBox _groupBox7;

        private ComboBox _bossBattleP2Box;

        private GroupBox _groupBox2;

        private ComboBox _faceOffP2Box;

        private GroupBox _groupBox8;

        private ComboBox _bossBattleP1Box;

        private Button _stopBtn;

        private Button _pauseBtn;

        private Button _playBtn;

        private Control1 _volumeSlider;

        public bool Bool0;

        public bool Bool1;

        private ZzQbSongObject _class3230;

        private QbcParser _qbcParser;

        private readonly Gh3Songlist _gh3Songlist0;

        private bool _bool2;

        private bool _bool3;

        private bool _bool4;

        private IPlayableAudio _audio;

        private readonly Timer _timer0;

        private bool _bool5 = true;

        private readonly bool _forceRb3;

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
            _guitarAudioTxt = new TextBox();
            _label6 = new Label();
            _audioGroupBox = new GroupBox();
            _stopBtn = new Button();
            _pauseBtn = new Button();
            _playBtn = new Button();
            _dualAudioBtn = new RadioButton();
            _coopAudioBtn = new RadioButton();
            _bandCoopBtn = new Button();
            _rhythmCoopBtn = new Button();
            _guitarCoopBtn = new Button();
            _bandCoopTxt = new TextBox();
            _rhythmCoopTxt = new TextBox();
            _guitarCoopTxt = new TextBox();
            _label11 = new Label();
            _bandAudioBtn = new Button();
            _rhythmAudioBtn = new Button();
            _guitarAudioBtn = new Button();
            _label1 = new Label();
            _multiAudioBtn = new RadioButton();
            _singleAudioBtn = new RadioButton();
            _label3 = new Label();
            _bandAudioTxt = new TextBox();
            _label2 = new Label();
            _rhythmAudioTxt = new TextBox();
            _chartGroupBox = new GroupBox();
            _groupBox7 = new GroupBox();
            _bossBattleP2Box = new ComboBox();
            _groupBox2 = new GroupBox();
            _faceOffP2Box = new ComboBox();
            _groupBox8 = new GroupBox();
            _bossBattleP1Box = new ComboBox();
            _groupBox1 = new GroupBox();
            _faceOffP1Box = new ComboBox();
            _label13 = new Label();
            _resetBtn = new Button();
            _autoConfigBtn = new Button();
            _groupBox5 = new GroupBox();
            _expertCoop2Box = new ComboBox();
            _hardCoop2Box = new ComboBox();
            _mediumCoop2Box = new ComboBox();
            _easyCoop2Box = new ComboBox();
            _groupBox4 = new GroupBox();
            _expertRhythmBox = new ComboBox();
            _hardRhythmBox = new ComboBox();
            _mediumRhythmBox = new ComboBox();
            _easyRhythmBox = new ComboBox();
            _groupBox6 = new GroupBox();
            _expertCoopBox = new ComboBox();
            _hardCoopBox = new ComboBox();
            _mediumCoopBox = new ComboBox();
            _easyCoopBox = new ComboBox();
            _groupBox3 = new GroupBox();
            _expertGuitarBox = new ComboBox();
            _hardGuitarBox = new ComboBox();
            _mediumGuitarBox = new ComboBox();
            _easyGuitarBox = new ComboBox();
            _label9 = new Label();
            _label8 = new Label();
            _label7 = new Label();
            _label5 = new Label();
            _chartFileBtn = new Button();
            _label4 = new Label();
            _chartFileTxt = new TextBox();
            _label10 = new Label();
            _songNameTxt = new TextBox();
            _mainGroupBox = new GroupBox();
            _label12 = new Label();
            _cancelBtn = new Button();
            _applyBtn = new Button();
            _chartCheckBox = new CheckBox();
            _audioCheckBox = new CheckBox();
            _volumeSlider = new Control1();
            _previewSlider = new Control1();
            _audioGroupBox.SuspendLayout();
            _chartGroupBox.SuspendLayout();
            _groupBox7.SuspendLayout();
            _groupBox2.SuspendLayout();
            _groupBox8.SuspendLayout();
            _groupBox1.SuspendLayout();
            _groupBox5.SuspendLayout();
            _groupBox4.SuspendLayout();
            _groupBox6.SuspendLayout();
            _groupBox3.SuspendLayout();
            _mainGroupBox.SuspendLayout();
            SuspendLayout();
            _guitarAudioTxt.Location = new Point(113, 39);
            _guitarAudioTxt.Name = "_guitarAudioTxt";
            _guitarAudioTxt.ReadOnly = true;
            _guitarAudioTxt.Size = new Size(180, 20);
            _guitarAudioTxt.TabIndex = 39;
            _label6.AutoSize = true;
            _label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label6.Location = new Point(6, 38);
            _label6.Name = "_label6";
            _label6.Size = new Size(101, 19);
            _label6.TabIndex = 39;
            _label6.Text = "Guitar Track:";
            _label6.TextAlign = ContentAlignment.MiddleCenter;
            _audioGroupBox.Controls.Add(_volumeSlider);
            _audioGroupBox.Controls.Add(_stopBtn);
            _audioGroupBox.Controls.Add(_pauseBtn);
            _audioGroupBox.Controls.Add(_playBtn);
            _audioGroupBox.Controls.Add(_dualAudioBtn);
            _audioGroupBox.Controls.Add(_coopAudioBtn);
            _audioGroupBox.Controls.Add(_bandCoopBtn);
            _audioGroupBox.Controls.Add(_rhythmCoopBtn);
            _audioGroupBox.Controls.Add(_guitarCoopBtn);
            _audioGroupBox.Controls.Add(_bandCoopTxt);
            _audioGroupBox.Controls.Add(_rhythmCoopTxt);
            _audioGroupBox.Controls.Add(_guitarCoopTxt);
            _audioGroupBox.Controls.Add(_previewSlider);
            _audioGroupBox.Controls.Add(_label11);
            _audioGroupBox.Controls.Add(_bandAudioBtn);
            _audioGroupBox.Controls.Add(_rhythmAudioBtn);
            _audioGroupBox.Controls.Add(_guitarAudioBtn);
            _audioGroupBox.Controls.Add(_label1);
            _audioGroupBox.Controls.Add(_multiAudioBtn);
            _audioGroupBox.Controls.Add(_singleAudioBtn);
            _audioGroupBox.Controls.Add(_label3);
            _audioGroupBox.Controls.Add(_bandAudioTxt);
            _audioGroupBox.Controls.Add(_label2);
            _audioGroupBox.Controls.Add(_rhythmAudioTxt);
            _audioGroupBox.Controls.Add(_label6);
            _audioGroupBox.Controls.Add(_guitarAudioTxt);
            _audioGroupBox.Location = new Point(12, 96);
            _audioGroupBox.Name = "_audioGroupBox";
            _audioGroupBox.Size = new Size(566, 168);
            _audioGroupBox.TabIndex = 36;
            _audioGroupBox.TabStop = false;
            _audioGroupBox.Text = "Audio Track";
            _stopBtn.FlatStyle = FlatStyle.Popup;
            _stopBtn.Location = new Point(205, 137);
            _stopBtn.Name = "_stopBtn";
            _stopBtn.Size = new Size(37, 20);
            _stopBtn.TabIndex = 50;
            _stopBtn.Text = "Stop";
            _stopBtn.UseVisualStyleBackColor = true;
            _stopBtn.Click += Stop_Btn_Click;
            _pauseBtn.FlatStyle = FlatStyle.Popup;
            _pauseBtn.Location = new Point(160, 137);
            _pauseBtn.Name = "_pauseBtn";
            _pauseBtn.Size = new Size(45, 20);
            _pauseBtn.TabIndex = 49;
            _pauseBtn.Text = "Pause";
            _pauseBtn.UseVisualStyleBackColor = true;
            _pauseBtn.Click += Pause_Btn_Click;
            _playBtn.FlatStyle = FlatStyle.Popup;
            _playBtn.Location = new Point(123, 137);
            _playBtn.Name = "_playBtn";
            _playBtn.Size = new Size(37, 20);
            _playBtn.TabIndex = 48;
            _playBtn.Text = "Play";
            _playBtn.UseVisualStyleBackColor = true;
            _playBtn.Click += Play_Btn_Click;
            _dualAudioBtn.AutoSize = true;
            _dualAudioBtn.Location = new Point(194, 18);
            _dualAudioBtn.Name = "_dualAudioBtn";
            _dualAudioBtn.Size = new Size(84, 17);
            _dualAudioBtn.TabIndex = 5;
            _dualAudioBtn.Text = "Guitar Track";
            _dualAudioBtn.UseVisualStyleBackColor = true;
            _dualAudioBtn.CheckedChanged += DualAudioBtn_CheckedChanged;
            _coopAudioBtn.AutoSize = true;
            _coopAudioBtn.Location = new Point(382, 18);
            _coopAudioBtn.Name = "_coopAudioBtn";
            _coopAudioBtn.Size = new Size(86, 17);
            _coopAudioBtn.TabIndex = 7;
            _coopAudioBtn.Text = "Coop Tracks";
            _coopAudioBtn.UseVisualStyleBackColor = true;
            _coopAudioBtn.CheckedChanged += CoopAudioBtn_CheckedChanged;
            _bandCoopBtn.Enabled = false;
            _bandCoopBtn.Location = new Point(539, 91);
            _bandCoopBtn.Name = "_bandCoopBtn";
            _bandCoopBtn.Size = new Size(24, 21);
            _bandCoopBtn.TabIndex = 13;
            _bandCoopBtn.Text = "...";
            _bandCoopBtn.UseVisualStyleBackColor = true;
            _bandCoopBtn.Click += BandCoopBtn_Click;
            _rhythmCoopBtn.Enabled = false;
            _rhythmCoopBtn.Location = new Point(539, 65);
            _rhythmCoopBtn.Name = "_rhythmCoopBtn";
            _rhythmCoopBtn.Size = new Size(24, 21);
            _rhythmCoopBtn.TabIndex = 12;
            _rhythmCoopBtn.Text = "...";
            _rhythmCoopBtn.UseVisualStyleBackColor = true;
            _rhythmCoopBtn.Click += RhythmCoopBtn_Click;
            _guitarCoopBtn.Enabled = false;
            _guitarCoopBtn.Location = new Point(539, 38);
            _guitarCoopBtn.Name = "_guitarCoopBtn";
            _guitarCoopBtn.Size = new Size(24, 21);
            _guitarCoopBtn.TabIndex = 11;
            _guitarCoopBtn.Text = "...";
            _guitarCoopBtn.UseVisualStyleBackColor = true;
            _guitarCoopBtn.Click += GuitarCoopBtn_Click;
            _bandCoopTxt.Enabled = false;
            _bandCoopTxt.Location = new Point(329, 92);
            _bandCoopTxt.Name = "_bandCoopTxt";
            _bandCoopTxt.ReadOnly = true;
            _bandCoopTxt.Size = new Size(204, 20);
            _bandCoopTxt.TabIndex = 46;
            _rhythmCoopTxt.Enabled = false;
            _rhythmCoopTxt.Location = new Point(329, 66);
            _rhythmCoopTxt.Name = "_rhythmCoopTxt";
            _rhythmCoopTxt.ReadOnly = true;
            _rhythmCoopTxt.Size = new Size(204, 20);
            _rhythmCoopTxt.TabIndex = 45;
            _guitarCoopTxt.Enabled = false;
            _guitarCoopTxt.Location = new Point(329, 39);
            _guitarCoopTxt.Name = "_guitarCoopTxt";
            _guitarCoopTxt.ReadOnly = true;
            _guitarCoopTxt.Size = new Size(204, 20);
            _guitarCoopTxt.TabIndex = 44;
            _label11.AutoSize = true;
            _label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label11.Location = new Point(6, 129);
            _label11.Name = "_label11";
            _label11.Size = new Size(111, 19);
            _label11.TabIndex = 47;
            _label11.Text = "Preview Track:";
            _label11.TextAlign = ContentAlignment.MiddleCenter;
            _bandAudioBtn.Enabled = false;
            _bandAudioBtn.Location = new Point(299, 91);
            _bandAudioBtn.Name = "_bandAudioBtn";
            _bandAudioBtn.Size = new Size(24, 21);
            _bandAudioBtn.TabIndex = 10;
            _bandAudioBtn.Text = "...";
            _bandAudioBtn.UseVisualStyleBackColor = true;
            _bandAudioBtn.Click += BandAudioBtn_Click;
            _rhythmAudioBtn.Enabled = false;
            _rhythmAudioBtn.Location = new Point(299, 65);
            _rhythmAudioBtn.Name = "_rhythmAudioBtn";
            _rhythmAudioBtn.Size = new Size(24, 21);
            _rhythmAudioBtn.TabIndex = 9;
            _rhythmAudioBtn.Text = "...";
            _rhythmAudioBtn.UseVisualStyleBackColor = true;
            _rhythmAudioBtn.Click += RhythmAudioBtn_Click;
            _guitarAudioBtn.Location = new Point(299, 38);
            _guitarAudioBtn.Name = "_guitarAudioBtn";
            _guitarAudioBtn.Size = new Size(24, 21);
            _guitarAudioBtn.TabIndex = 8;
            _guitarAudioBtn.Text = "...";
            _guitarAudioBtn.UseVisualStyleBackColor = true;
            _guitarAudioBtn.Click += GuitarAudioBtn_Click;
            _label1.AutoSize = true;
            _label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label1.Location = new Point(6, 16);
            _label1.Name = "_label1";
            _label1.Size = new Size(91, 19);
            _label1.TabIndex = 38;
            _label1.Text = "Audio Type:";
            _label1.TextAlign = ContentAlignment.MiddleCenter;
            _multiAudioBtn.AutoSize = true;
            _multiAudioBtn.Location = new Point(284, 18);
            _multiAudioBtn.Name = "_multiAudioBtn";
            _multiAudioBtn.Size = new Size(92, 17);
            _multiAudioBtn.TabIndex = 6;
            _multiAudioBtn.Text = "Rhythm Track";
            _multiAudioBtn.UseVisualStyleBackColor = true;
            _multiAudioBtn.CheckedChanged += MultiAudioBtn_CheckedChanged;
            _singleAudioBtn.AutoSize = true;
            _singleAudioBtn.Checked = true;
            _singleAudioBtn.Location = new Point(103, 18);
            _singleAudioBtn.Name = "_singleAudioBtn";
            _singleAudioBtn.Size = new Size(85, 17);
            _singleAudioBtn.TabIndex = 4;
            _singleAudioBtn.TabStop = true;
            _singleAudioBtn.Text = "Single Track";
            _singleAudioBtn.UseVisualStyleBackColor = true;
            _singleAudioBtn.CheckedChanged += SingleAudioBtn_CheckedChanged;
            _label3.AutoSize = true;
            _label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label3.Location = new Point(6, 91);
            _label3.Name = "_label3";
            _label3.Size = new Size(93, 19);
            _label3.TabIndex = 42;
            _label3.Text = "Band Track:";
            _label3.TextAlign = ContentAlignment.MiddleCenter;
            _bandAudioTxt.Enabled = false;
            _bandAudioTxt.Location = new Point(105, 92);
            _bandAudioTxt.Name = "_bandAudioTxt";
            _bandAudioTxt.ReadOnly = true;
            _bandAudioTxt.Size = new Size(188, 20);
            _bandAudioTxt.TabIndex = 43;
            _label2.AutoSize = true;
            _label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label2.Location = new Point(6, 65);
            _label2.Name = "_label2";
            _label2.Size = new Size(111, 19);
            _label2.TabIndex = 40;
            _label2.Text = "Rhythm Track:";
            _label2.TextAlign = ContentAlignment.MiddleCenter;
            _rhythmAudioTxt.Enabled = false;
            _rhythmAudioTxt.Location = new Point(123, 66);
            _rhythmAudioTxt.Name = "_rhythmAudioTxt";
            _rhythmAudioTxt.ReadOnly = true;
            _rhythmAudioTxt.Size = new Size(170, 20);
            _rhythmAudioTxt.TabIndex = 41;
            _chartGroupBox.Controls.Add(_groupBox7);
            _chartGroupBox.Controls.Add(_groupBox2);
            _chartGroupBox.Controls.Add(_groupBox8);
            _chartGroupBox.Controls.Add(_groupBox1);
            _chartGroupBox.Controls.Add(_label13);
            _chartGroupBox.Controls.Add(_resetBtn);
            _chartGroupBox.Controls.Add(_autoConfigBtn);
            _chartGroupBox.Controls.Add(_groupBox5);
            _chartGroupBox.Controls.Add(_groupBox4);
            _chartGroupBox.Controls.Add(_groupBox6);
            _chartGroupBox.Controls.Add(_groupBox3);
            _chartGroupBox.Controls.Add(_label9);
            _chartGroupBox.Controls.Add(_label8);
            _chartGroupBox.Controls.Add(_label7);
            _chartGroupBox.Controls.Add(_label5);
            _chartGroupBox.Controls.Add(_chartFileBtn);
            _chartGroupBox.Controls.Add(_label4);
            _chartGroupBox.Controls.Add(_chartFileTxt);
            _chartGroupBox.Location = new Point(12, 270);
            _chartGroupBox.Name = "_chartGroupBox";
            _chartGroupBox.Size = new Size(566, 239);
            _chartGroupBox.TabIndex = 37;
            _chartGroupBox.TabStop = false;
            _chartGroupBox.Text = "Game Track";
            _groupBox7.Controls.Add(_bossBattleP2Box);
            _groupBox7.Location = new Point(445, 180);
            _groupBox7.Name = "_groupBox7";
            _groupBox7.Size = new Size(110, 48);
            _groupBox7.TabIndex = 58;
            _groupBox7.TabStop = false;
            _groupBox7.Text = "Boss Battle P2";
            _bossBattleP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _bossBattleP2Box.FormattingEnabled = true;
            _bossBattleP2Box.Location = new Point(6, 19);
            _bossBattleP2Box.Name = "_bossBattleP2Box";
            _bossBattleP2Box.Size = new Size(98, 21);
            _bossBattleP2Box.TabIndex = 18;
            _groupBox2.Controls.Add(_faceOffP2Box);
            _groupBox2.Location = new Point(213, 180);
            _groupBox2.Name = "_groupBox2";
            _groupBox2.Size = new Size(110, 48);
            _groupBox2.TabIndex = 56;
            _groupBox2.TabStop = false;
            _groupBox2.Text = "Face Off P2";
            _faceOffP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _faceOffP2Box.FormattingEnabled = true;
            _faceOffP2Box.Location = new Point(6, 19);
            _faceOffP2Box.Name = "_faceOffP2Box";
            _faceOffP2Box.Size = new Size(98, 21);
            _faceOffP2Box.TabIndex = 18;
            _groupBox8.Controls.Add(_bossBattleP1Box);
            _groupBox8.Location = new Point(329, 180);
            _groupBox8.Name = "_groupBox8";
            _groupBox8.Size = new Size(110, 48);
            _groupBox8.TabIndex = 57;
            _groupBox8.TabStop = false;
            _groupBox8.Text = "Boss Battle P1";
            _bossBattleP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _bossBattleP1Box.FormattingEnabled = true;
            _bossBattleP1Box.Location = new Point(6, 19);
            _bossBattleP1Box.Name = "_bossBattleP1Box";
            _bossBattleP1Box.Size = new Size(98, 21);
            _bossBattleP1Box.TabIndex = 18;
            _groupBox1.Controls.Add(_faceOffP1Box);
            _groupBox1.Location = new Point(97, 180);
            _groupBox1.Name = "_groupBox1";
            _groupBox1.Size = new Size(110, 48);
            _groupBox1.TabIndex = 55;
            _groupBox1.TabStop = false;
            _groupBox1.Text = "Face Off P1";
            _faceOffP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _faceOffP1Box.FormattingEnabled = true;
            _faceOffP1Box.Location = new Point(6, 19);
            _faceOffP1Box.Name = "_faceOffP1Box";
            _faceOffP1Box.Size = new Size(98, 21);
            _faceOffP1Box.TabIndex = 18;
            _label13.AutoSize = true;
            _label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label13.Location = new Point(-2, 201);
            _label13.Name = "_label13";
            _label13.Size = new Size(93, 19);
            _label13.TabIndex = 58;
            _label13.Text = "SECTIONS:";
            _label13.TextAlign = ContentAlignment.MiddleCenter;
            _resetBtn.Enabled = false;
            _resetBtn.Location = new Point(512, 15);
            _resetBtn.Name = "_resetBtn";
            _resetBtn.Size = new Size(43, 23);
            _resetBtn.TabIndex = 17;
            _resetBtn.Text = "Reset";
            _resetBtn.UseVisualStyleBackColor = true;
            _resetBtn.Click += ResetBtn_Click;
            _autoConfigBtn.Enabled = false;
            _autoConfigBtn.Location = new Point(404, 15);
            _autoConfigBtn.Name = "_autoConfigBtn";
            _autoConfigBtn.Size = new Size(102, 23);
            _autoConfigBtn.TabIndex = 16;
            _autoConfigBtn.Text = "Auto Configuration";
            _autoConfigBtn.UseVisualStyleBackColor = true;
            _autoConfigBtn.Click += AutoConfigBtn_Click;
            _groupBox5.Controls.Add(_expertCoop2Box);
            _groupBox5.Controls.Add(_hardCoop2Box);
            _groupBox5.Controls.Add(_mediumCoop2Box);
            _groupBox5.Controls.Add(_easyCoop2Box);
            _groupBox5.Location = new Point(445, 43);
            _groupBox5.Name = "_groupBox5";
            _groupBox5.Size = new Size(110, 131);
            _groupBox5.TabIndex = 57;
            _groupBox5.TabStop = false;
            _groupBox5.Text = "Coop Rhythm";
            _expertCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _expertCoop2Box.FormattingEnabled = true;
            _expertCoop2Box.Location = new Point(6, 100);
            _expertCoop2Box.Name = "_expertCoop2Box";
            _expertCoop2Box.Size = new Size(98, 21);
            _expertCoop2Box.TabIndex = 33;
            _hardCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _hardCoop2Box.FormattingEnabled = true;
            _hardCoop2Box.Location = new Point(6, 73);
            _hardCoop2Box.Name = "_hardCoop2Box";
            _hardCoop2Box.Size = new Size(98, 21);
            _hardCoop2Box.TabIndex = 32;
            _mediumCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _mediumCoop2Box.FormattingEnabled = true;
            _mediumCoop2Box.Location = new Point(6, 46);
            _mediumCoop2Box.Name = "_mediumCoop2Box";
            _mediumCoop2Box.Size = new Size(98, 21);
            _mediumCoop2Box.TabIndex = 31;
            _easyCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
            _easyCoop2Box.FormattingEnabled = true;
            _easyCoop2Box.Location = new Point(6, 19);
            _easyCoop2Box.Name = "_easyCoop2Box";
            _easyCoop2Box.Size = new Size(98, 21);
            _easyCoop2Box.TabIndex = 30;
            _groupBox4.Controls.Add(_expertRhythmBox);
            _groupBox4.Controls.Add(_hardRhythmBox);
            _groupBox4.Controls.Add(_mediumRhythmBox);
            _groupBox4.Controls.Add(_easyRhythmBox);
            _groupBox4.Location = new Point(213, 43);
            _groupBox4.Name = "_groupBox4";
            _groupBox4.Size = new Size(110, 131);
            _groupBox4.TabIndex = 55;
            _groupBox4.TabStop = false;
            _groupBox4.Text = "Single Rhythm";
            _expertRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _expertRhythmBox.FormattingEnabled = true;
            _expertRhythmBox.Location = new Point(6, 100);
            _expertRhythmBox.Name = "_expertRhythmBox";
            _expertRhythmBox.Size = new Size(98, 21);
            _expertRhythmBox.TabIndex = 25;
            _hardRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _hardRhythmBox.FormattingEnabled = true;
            _hardRhythmBox.Location = new Point(6, 73);
            _hardRhythmBox.Name = "_hardRhythmBox";
            _hardRhythmBox.Size = new Size(98, 21);
            _hardRhythmBox.TabIndex = 24;
            _mediumRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _mediumRhythmBox.FormattingEnabled = true;
            _mediumRhythmBox.Location = new Point(6, 46);
            _mediumRhythmBox.Name = "_mediumRhythmBox";
            _mediumRhythmBox.Size = new Size(98, 21);
            _mediumRhythmBox.TabIndex = 23;
            _easyRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _easyRhythmBox.FormattingEnabled = true;
            _easyRhythmBox.Location = new Point(6, 19);
            _easyRhythmBox.Name = "_easyRhythmBox";
            _easyRhythmBox.Size = new Size(98, 21);
            _easyRhythmBox.TabIndex = 22;
            _groupBox6.Controls.Add(_expertCoopBox);
            _groupBox6.Controls.Add(_hardCoopBox);
            _groupBox6.Controls.Add(_mediumCoopBox);
            _groupBox6.Controls.Add(_easyCoopBox);
            _groupBox6.Location = new Point(329, 43);
            _groupBox6.Name = "_groupBox6";
            _groupBox6.Size = new Size(110, 131);
            _groupBox6.TabIndex = 56;
            _groupBox6.TabStop = false;
            _groupBox6.Text = "Coop Guitar";
            _expertCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _expertCoopBox.FormattingEnabled = true;
            _expertCoopBox.Location = new Point(6, 100);
            _expertCoopBox.Name = "_expertCoopBox";
            _expertCoopBox.Size = new Size(98, 21);
            _expertCoopBox.TabIndex = 29;
            _hardCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _hardCoopBox.FormattingEnabled = true;
            _hardCoopBox.Location = new Point(6, 73);
            _hardCoopBox.Name = "_hardCoopBox";
            _hardCoopBox.Size = new Size(98, 21);
            _hardCoopBox.TabIndex = 28;
            _mediumCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _mediumCoopBox.FormattingEnabled = true;
            _mediumCoopBox.Location = new Point(6, 46);
            _mediumCoopBox.Name = "_mediumCoopBox";
            _mediumCoopBox.Size = new Size(98, 21);
            _mediumCoopBox.TabIndex = 27;
            _easyCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _easyCoopBox.FormattingEnabled = true;
            _easyCoopBox.Location = new Point(6, 19);
            _easyCoopBox.Name = "_easyCoopBox";
            _easyCoopBox.Size = new Size(98, 21);
            _easyCoopBox.TabIndex = 26;
            _groupBox3.Controls.Add(_expertGuitarBox);
            _groupBox3.Controls.Add(_hardGuitarBox);
            _groupBox3.Controls.Add(_mediumGuitarBox);
            _groupBox3.Controls.Add(_easyGuitarBox);
            _groupBox3.Location = new Point(97, 43);
            _groupBox3.Name = "_groupBox3";
            _groupBox3.Size = new Size(110, 131);
            _groupBox3.TabIndex = 54;
            _groupBox3.TabStop = false;
            _groupBox3.Text = "Single Guitar";
            _expertGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _expertGuitarBox.FormattingEnabled = true;
            _expertGuitarBox.Location = new Point(6, 100);
            _expertGuitarBox.Name = "_expertGuitarBox";
            _expertGuitarBox.Size = new Size(98, 21);
            _expertGuitarBox.TabIndex = 21;
            _hardGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _hardGuitarBox.FormattingEnabled = true;
            _hardGuitarBox.Location = new Point(6, 73);
            _hardGuitarBox.Name = "_hardGuitarBox";
            _hardGuitarBox.Size = new Size(98, 21);
            _hardGuitarBox.TabIndex = 20;
            _mediumGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _mediumGuitarBox.FormattingEnabled = true;
            _mediumGuitarBox.Location = new Point(6, 46);
            _mediumGuitarBox.Name = "_mediumGuitarBox";
            _mediumGuitarBox.Size = new Size(98, 21);
            _mediumGuitarBox.TabIndex = 19;
            _easyGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _easyGuitarBox.FormattingEnabled = true;
            _easyGuitarBox.Location = new Point(6, 19);
            _easyGuitarBox.Name = "_easyGuitarBox";
            _easyGuitarBox.Size = new Size(98, 21);
            _easyGuitarBox.TabIndex = 18;
            _label9.AutoSize = true;
            _label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label9.Location = new Point(15, 145);
            _label9.Name = "_label9";
            _label9.Size = new Size(76, 19);
            _label9.TabIndex = 53;
            _label9.Text = "EXPERT:";
            _label9.TextAlign = ContentAlignment.MiddleCenter;
            _label8.AutoSize = true;
            _label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label8.Location = new Point(30, 118);
            _label8.Name = "_label8";
            _label8.Size = new Size(61, 19);
            _label8.TabIndex = 52;
            _label8.Text = "HARD:";
            _label8.TextAlign = ContentAlignment.MiddleCenter;
            _label7.AutoSize = true;
            _label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label7.Location = new Point(6, 91);
            _label7.Name = "_label7";
            _label7.Size = new Size(85, 19);
            _label7.TabIndex = 51;
            _label7.Text = "MEDIUM:";
            _label7.TextAlign = ContentAlignment.MiddleCenter;
            _label5.AutoSize = true;
            _label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label5.Location = new Point(37, 64);
            _label5.Name = "_label5";
            _label5.Size = new Size(54, 19);
            _label5.TabIndex = 50;
            _label5.Text = "EASY:";
            _label5.TextAlign = ContentAlignment.MiddleCenter;
            _chartFileBtn.Location = new Point(374, 16);
            _chartFileBtn.Name = "_chartFileBtn";
            _chartFileBtn.Size = new Size(24, 21);
            _chartFileBtn.TabIndex = 15;
            _chartFileBtn.Text = "...";
            _chartFileBtn.UseVisualStyleBackColor = true;
            _chartFileBtn.Click += ChartFileBtn_Click;
            _label4.AutoSize = true;
            _label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label4.Location = new Point(10, 16);
            _label4.Name = "_label4";
            _label4.Size = new Size(81, 19);
            _label4.TabIndex = 48;
            _label4.Text = "Chart File:";
            _label4.TextAlign = ContentAlignment.MiddleCenter;
            _chartFileTxt.Location = new Point(97, 17);
            _chartFileTxt.Name = "_chartFileTxt";
            _chartFileTxt.ReadOnly = true;
            _chartFileTxt.Size = new Size(271, 20);
            _chartFileTxt.TabIndex = 49;
            _label10.AutoSize = true;
            _label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label10.Location = new Point(6, 28);
            _label10.Name = "_label10";
            _label10.Size = new Size(91, 19);
            _label10.TabIndex = 36;
            _label10.Text = "Song Name:";
            _label10.TextAlign = ContentAlignment.MiddleCenter;
            _songNameTxt.CharacterCasing = CharacterCasing.Lower;
            _songNameTxt.Location = new Point(103, 29);
            _songNameTxt.MaxLength = 30;
            _songNameTxt.Name = "_songNameTxt";
            _songNameTxt.Size = new Size(140, 20);
            _songNameTxt.TabIndex = 1;
            _songNameTxt.TextChanged += SongNameTxt_TextChanged;
            _songNameTxt.KeyPress += SongNameTxt_KeyPress;
            _mainGroupBox.Controls.Add(_label12);
            _mainGroupBox.Controls.Add(_cancelBtn);
            _mainGroupBox.Controls.Add(_applyBtn);
            _mainGroupBox.Controls.Add(_chartCheckBox);
            _mainGroupBox.Controls.Add(_audioCheckBox);
            _mainGroupBox.Controls.Add(_label10);
            _mainGroupBox.Controls.Add(_songNameTxt);
            _mainGroupBox.Location = new Point(12, 12);
            _mainGroupBox.Name = "_mainGroupBox";
            _mainGroupBox.Size = new Size(566, 78);
            _mainGroupBox.TabIndex = 0;
            _mainGroupBox.TabStop = false;
            _mainGroupBox.Text = "Main Settings";
            _label12.AutoSize = true;
            _label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label12.Location = new Point(249, 28);
            _label12.Name = "_label12";
            _label12.Size = new Size(131, 19);
            _label12.TabIndex = 43;
            _label12.Text = "Data to Generate:";
            _label12.TextAlign = ContentAlignment.MiddleCenter;
            _cancelBtn.DialogResult = DialogResult.Cancel;
            _cancelBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _cancelBtn.Location = new Point(495, 44);
            _cancelBtn.Name = "_cancelBtn";
            _cancelBtn.Size = new Size(65, 27);
            _cancelBtn.TabIndex = 35;
            _cancelBtn.Text = "Cancel";
            _cancelBtn.UseVisualStyleBackColor = true;
            _applyBtn.DialogResult = DialogResult.OK;
            _applyBtn.Enabled = false;
            _applyBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _applyBtn.Location = new Point(495, 11);
            _applyBtn.Name = "_applyBtn";
            _applyBtn.Size = new Size(65, 27);
            _applyBtn.TabIndex = 34;
            _applyBtn.Text = "Apply";
            _applyBtn.UseVisualStyleBackColor = true;
            _chartCheckBox.AutoSize = true;
            _chartCheckBox.Checked = true;
            _chartCheckBox.CheckState = CheckState.Checked;
            _chartCheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _chartCheckBox.Location = new Point(380, 44);
            _chartCheckBox.Name = "_chartCheckBox";
            _chartCheckBox.Size = new Size(112, 23);
            _chartCheckBox.TabIndex = 3;
            _chartCheckBox.Text = "Game Track";
            _chartCheckBox.UseVisualStyleBackColor = true;
            _chartCheckBox.CheckedChanged += Chart_CheckBox_CheckedChanged;
            _audioCheckBox.AutoSize = true;
            _audioCheckBox.Checked = true;
            _audioCheckBox.CheckState = CheckState.Checked;
            _audioCheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            _audioCheckBox.Location = new Point(380, 15);
            _audioCheckBox.Name = "_audioCheckBox";
            _audioCheckBox.Size = new Size(111, 23);
            _audioCheckBox.TabIndex = 2;
            _audioCheckBox.Text = "Audio Track";
            _audioCheckBox.UseVisualStyleBackColor = true;
            _audioCheckBox.CheckedChanged += Audio_CheckBox_CheckedChanged;
            _volumeSlider.BackColor = Color.Transparent;
            _volumeSlider.method_7(50f);
            _volumeSlider.method_8(70f);
            _volumeSlider.method_20(5u);
            _volumeSlider.Location = new Point(465, 137);
            _volumeSlider.method_4(20);
            _volumeSlider.Name = "_volumeSlider";
            _volumeSlider.Size = new Size(95, 10);
            _volumeSlider.method_19(1u);
            _volumeSlider.TabIndex = 51;
            _volumeSlider.Text = "TimeSlideBar";
            _volumeSlider.method_6(new SizeF(50f, 25f));
            _volumeSlider.method_5(20);
            _volumeSlider.method_1("{0}%");
            _volumeSlider.method_14(100);
            _volumeSlider.method_0(method_10);
            _previewSlider.BackColor = Color.Transparent;
            _previewSlider.method_10(Color.Crimson);
            _previewSlider.method_9(Color.Red);
            _previewSlider.method_7(50f);
            _previewSlider.method_8(60f);
            _previewSlider.method_21(Control1.Enum40.Const3);
            _previewSlider.method_12(Color.Violet);
            _previewSlider.method_11(Color.DarkViolet);
            _previewSlider.Enabled = false;
            _previewSlider.method_20(5u);
            _previewSlider.Location = new Point(123, 116);
            _previewSlider.method_4(20);
            _previewSlider.Name = "_previewSlider";
            _previewSlider.Size = new Size(437, 15);
            _previewSlider.method_19(1u);
            _previewSlider.TabIndex = 14;
            _previewSlider.Text = "PreviewSlider";
            _previewSlider.method_6(new SizeF(20f, 50f));
            _previewSlider.method_5(35);
            _previewSlider.method_1("{0:mm:ss}");
            _previewSlider.method_2(true);
            _previewSlider.MouseDown += PreviewSlider_MouseDown;
            _previewSlider.MouseUp += PreviewSlider_MouseUp;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 520);
            Controls.Add(_mainGroupBox);
            Controls.Add(_chartGroupBox);
            Controls.Add(_audioGroupBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SongData";
            Text = "Generate Song Data";
            _audioGroupBox.ResumeLayout(false);
            _audioGroupBox.PerformLayout();
            _chartGroupBox.ResumeLayout(false);
            _chartGroupBox.PerformLayout();
            _groupBox7.ResumeLayout(false);
            _groupBox2.ResumeLayout(false);
            _groupBox8.ResumeLayout(false);
            _groupBox1.ResumeLayout(false);
            _groupBox5.ResumeLayout(false);
            _groupBox4.ResumeLayout(false);
            _groupBox6.ResumeLayout(false);
            _groupBox3.ResumeLayout(false);
            _mainGroupBox.ResumeLayout(false);
            _mainGroupBox.PerformLayout();
            ResumeLayout(false);
            FormClosing += SongData_FormClosing;
        }

        public SongData(Gh3Songlist gh3Songlist1)
        {
            InitializeComponent();
            Control arg260 = _audioCheckBox;
            _chartCheckBox.Enabled = false;
            arg260.Enabled = false;
            Bool1 = true;
            Bool0 = true;
            EnableAudioButtons();
            _gh3Songlist0 = gh3Songlist1;
            _timer0 = new Timer();
            _timer0.Interval = 30;
            _timer0.Tick += timer_0_Tick;
        }

        public SongData(Gh3Songlist gh3Songlist1, bool forceRb3)
        {
            _forceRb3 = forceRb3;
            InitializeComponent();
            Control arg260 = _audioCheckBox;
            _chartCheckBox.Enabled = false;
            arg260.Enabled = false;
            Bool1 = true;
            Bool0 = true;
            EnableAudioButtons();
            _gh3Songlist0 = gh3Songlist1;
            _timer0 = new Timer();
            _timer0.Interval = 30;
            _timer0.Tick += timer_0_Tick;
        }

        public SongData(string string0, bool bool6, bool bool7)
        {
            InitializeComponent();
            _songNameTxt.Text = string0;
            _bool2 = true;
            _songNameTxt.Enabled = false;
            _timer0 = new Timer();
            _timer0.Interval = 30;
            _timer0.Tick += timer_0_Tick;
            var arg710 = _audioCheckBox;
            Bool0 = bool6;
            arg710.Checked = bool6;
            var arg860 = _chartCheckBox;
            Bool1 = bool7;
            arg860.Checked = bool7;
            EnableAudioButtons();
        }

        public SongData(string string0, QbcParser class3621, ZzQbSongObject class3231, string[] string1)
        {
            InitializeComponent();
            _songNameTxt.Text = string0;
            _bool2 = true;
            _qbcParser = class3621;
            method_6();
            method_4("No Track");
            method_5("No Track");
            method_8(0);
            foreach (var current in _qbcParser.NoteList.Keys)
            {
                method_4(current);
            }
            if (_qbcParser.Class2282.Count != 0)
            {
                method_5("faceoffp1");
            }
            if (_qbcParser.Class2283.Count != 0)
            {
                method_5("faceoffp2");
            }
            if (_qbcParser.BpmList.Count != 0)
            {
                method_5("bossbattlep1");
            }
            if (_qbcParser.Class2285.Count != 0)
            {
                method_5("bossbattlep2");
            }
            method_7();
            if (class3231 != null)
            {
                _class3230 = class3231;
                return;
            }
            if (string1.Length == 1)
            {
                _singleAudioBtn.Checked = true;
                _guitarAudioTxt.Text = string1[0];
            }
            else
            {
                string text = null;
                string text2 = null;
                string text3 = null;
                string text4 = null;
                string text5 = null;
                string text6 = null;
                for (var i = 0; i < string1.Length; i++)
                {
                    var text7 = string1[i];
                    var text8 = KeyGenerator.GetFileName(text7).ToLower();
                    if (string1.Length > 4 && text8.Contains("coop"))
                    {
                        if (text5 == null && (text8.Contains("rhythm") || text8.Contains("bass")))
                        {
                            text5 = text7;
                        }
                        else if (text4 == null && text8.Contains("guitar"))
                        {
                            text4 = text7;
                        }
                        else if (text6 == null)
                        {
                            text6 = text7;
                        }
                    }
                    else if (text2 == null && (text8.Contains("rhythm") || text8.Contains("bass")))
                    {
                        text2 = text7;
                    }
                    else if (text == null && text8.Contains("guitar"))
                    {
                        text = text7;
                    }
                    else if (text3 == null)
                    {
                        text3 = text7;
                    }
                }
                if (text == null)
                {
                    throw new Exception("File names did not follow format!");
                }
                if (text3 != null)
                {
                    if (text2 != null)
                    {
                        if (text4 != null && text5 != null && text6 != null)
                        {
                            _coopAudioBtn.Checked = true;
                            _guitarCoopTxt.Text = text4;
                            _rhythmCoopTxt.Text = text5;
                            _bandCoopTxt.Text = text6;
                        }
                        else
                        {
                            _multiAudioBtn.Checked = true;
                        }
                        _rhythmAudioTxt.Text = text2;
                    }
                    else
                    {
                        _dualAudioBtn.Checked = true;
                    }
                    _bandAudioTxt.Text = text3;
                }
                else
                {
                    _singleAudioBtn.Checked = true;
                }
                _guitarAudioTxt.Text = text;
            }
            _previewSlider.method_18(Convert.ToInt32(AudioManager.GetAudioStream(_guitarAudioTxt.Text)
                .vmethod_1()
                .TimeSpan0.TotalSeconds));
            _previewSlider.method_14(_previewSlider.method_17() / 2);
            if (_guitarAudioTxt.Text == "" || (!_singleAudioBtn.Checked &&
                                               (_bandAudioTxt.Text == "" || !_dualAudioBtn.Checked) &&
                                               (_rhythmAudioTxt.Text == "" || !_multiAudioBtn.Checked) &&
                                               (_guitarCoopTxt.Text == "" || _rhythmCoopTxt.Text == "" ||
                                                _bandCoopTxt.Text == "" || !_coopAudioBtn.Checked)))
            {
                throw new Exception("File names did not follow format!");
            }
        }

        public Class248 method_0(string string0)
        {
            if (_class3230 != null)
            {
                _class3230.method_0(_songNameTxt.Text);
                return new Class248(_class3230, _guitarAudioTxt.Text.Replace(".dat.xen", ".fsb.xen"), string0);
            }
            string[] string_;
            if (_singleAudioBtn.Checked)
            {
                string_ = new[]
                {
                    _guitarAudioTxt.Text
                };
            }
            else if (_dualAudioBtn.Checked)
            {
                string_ = new[]
                {
                    _bandAudioTxt.Text,
                    _guitarAudioTxt.Text
                };
            }
            else if (_multiAudioBtn.Checked)
            {
                string_ = new[]
                {
                    _bandAudioTxt.Text,
                    _guitarAudioTxt.Text,
                    _rhythmAudioTxt.Text
                };
            }
            else
            {
                string_ = new[]
                {
                    _bandAudioTxt.Text,
                    _guitarAudioTxt.Text,
                    _rhythmAudioTxt.Text,
                    _bandCoopTxt.Text,
                    _guitarCoopTxt.Text,
                    _rhythmCoopTxt.Text
                };
            }
            return new Class248(_songNameTxt.Text, string_, new TimeSpan(0, 0, _previewSlider.method_13()),
                new TimeSpan(0, 0,
                    _previewSlider.method_13() + Math.Min(_previewSlider.method_17() - _previewSlider.method_13(), 20)),
                string0);
        }

        public Class250 method_1(ZzPakNode2 class3180, string string0)
        {
            var dictionary = new Dictionary<string, Track<int, NotesAtOffset>>();
            if (!_easyGuitarBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("easy", _qbcParser.NoteList[(string) _easyGuitarBox.SelectedItem]);
            }
            if (!_easyRhythmBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythm_easy", _qbcParser.NoteList[(string) _easyRhythmBox.SelectedItem]);
            }
            if (!_easyCoopBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("guitarcoop_easy", _qbcParser.NoteList[(string) _easyCoopBox.SelectedItem]);
            }
            if (!_easyCoop2Box.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythmcoop_easy", _qbcParser.NoteList[(string) _easyCoop2Box.SelectedItem]);
            }
            if (!_mediumGuitarBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("medium", _qbcParser.NoteList[(string) _mediumGuitarBox.SelectedItem]);
            }
            if (!_mediumRhythmBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythm_medium", _qbcParser.NoteList[(string) _mediumRhythmBox.SelectedItem]);
            }
            if (!_mediumCoopBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("guitarcoop_medium", _qbcParser.NoteList[(string) _mediumCoopBox.SelectedItem]);
            }
            if (!_mediumCoop2Box.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythmcoop_medium", _qbcParser.NoteList[(string) _mediumCoop2Box.SelectedItem]);
            }
            if (!_hardGuitarBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("hard", _qbcParser.NoteList[(string) _hardGuitarBox.SelectedItem]);
            }
            if (!_hardRhythmBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythm_hard", _qbcParser.NoteList[(string) _hardRhythmBox.SelectedItem]);
            }
            if (!_hardCoopBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("guitarcoop_hard", _qbcParser.NoteList[(string) _hardCoopBox.SelectedItem]);
            }
            if (!_hardCoop2Box.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythmcoop_hard", _qbcParser.NoteList[(string) _hardCoop2Box.SelectedItem]);
            }
            if (!_expertGuitarBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("expert", _qbcParser.NoteList[(string) _expertGuitarBox.SelectedItem]);
            }
            if (!_expertRhythmBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythm_expert", _qbcParser.NoteList[(string) _expertRhythmBox.SelectedItem]);
            }
            if (!_expertCoopBox.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("guitarcoop_expert", _qbcParser.NoteList[(string) _expertCoopBox.SelectedItem]);
            }
            if (!_expertCoop2Box.SelectedItem.Equals("No Track"))
            {
                dictionary.Add("rhythmcoop_expert", _qbcParser.NoteList[(string) _expertCoop2Box.SelectedItem]);
            }
            var class228 = method_2(_faceOffP1Box);
            var class2282 = method_2(_faceOffP2Box);
            var class2283 = method_2(_bossBattleP1Box);
            var class2284 = method_2(_bossBattleP2Box);
            _qbcParser.NoteList = dictionary;
            _qbcParser.Class2282 = class228;
            _qbcParser.Class2283 = class2282;
            _qbcParser.BpmList = class2283;
            _qbcParser.Class2285 = class2284;
            return new Class250(_songNameTxt.Text, _qbcParser, class3180, string0);
        }

        private Track<int, int> method_2(ComboBox comboBox0)
        {
            if (comboBox0.SelectedItem.Equals("faceoffp1"))
            {
                return _qbcParser.Class2282;
            }
            if (comboBox0.SelectedItem.Equals("faceoffp2"))
            {
                return _qbcParser.Class2283;
            }
            if (comboBox0.SelectedItem.Equals("bossbattlep1"))
            {
                return _qbcParser.BpmList;
            }
            if (comboBox0.SelectedItem.Equals("bossbattlep2"))
            {
                return _qbcParser.Class2285;
            }
            return new Track<int, int>();
        }

        private void EnableAudioButtons()
        {
            if (Bool0)
            {
                _bool3 = (_guitarAudioTxt.Text != "" && (_singleAudioBtn.Checked ||
                                                         (_bandAudioTxt.Text != "" &&
                                                          (_dualAudioBtn.Checked ||
                                                           (_rhythmAudioTxt.Text != "" && _multiAudioBtn.Checked) ||
                                                           (_guitarCoopTxt.Text != "" && _rhythmCoopTxt.Text != "" &&
                                                            _bandCoopTxt.Text != "" && _coopAudioBtn.Checked)))));
            }
            _applyBtn.Enabled = (((_songNameTxt.Enabled && _bool2) || !_songNameTxt.Enabled) &&
                                 ((Bool0 && _bool3) || !Bool0) && ((Bool1 && _bool4) || !Bool1));
            if (!_songNameTxt.Enabled && !Bool0 && !Bool1)
            {
                _applyBtn.Enabled = false;
            }
        }

        private void Audio_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _audioGroupBox.Enabled = (Bool0 = _audioCheckBox.Checked);
        }

        private void Chart_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _chartGroupBox.Enabled = (Bool1 = _chartCheckBox.Checked);
        }

        private void method_4(string string0)
        {
            _easyGuitarBox.Items.Add(string0);
            _easyRhythmBox.Items.Add(string0);
            _easyCoopBox.Items.Add(string0);
            _easyCoop2Box.Items.Add(string0);
            _mediumGuitarBox.Items.Add(string0);
            _mediumRhythmBox.Items.Add(string0);
            _mediumCoopBox.Items.Add(string0);
            _mediumCoop2Box.Items.Add(string0);
            _hardGuitarBox.Items.Add(string0);
            _hardRhythmBox.Items.Add(string0);
            _hardCoopBox.Items.Add(string0);
            _hardCoop2Box.Items.Add(string0);
            _expertGuitarBox.Items.Add(string0);
            _expertRhythmBox.Items.Add(string0);
            _expertCoopBox.Items.Add(string0);
            _expertCoop2Box.Items.Add(string0);
        }

        private void method_5(string string0)
        {
            _faceOffP1Box.Items.Add(string0);
            _faceOffP2Box.Items.Add(string0);
            _bossBattleP1Box.Items.Add(string0);
            _bossBattleP2Box.Items.Add(string0);
        }

        private void method_6()
        {
            _easyGuitarBox.Items.Clear();
            _easyRhythmBox.Items.Clear();
            _easyCoopBox.Items.Clear();
            _easyCoop2Box.Items.Clear();
            _mediumGuitarBox.Items.Clear();
            _mediumRhythmBox.Items.Clear();
            _mediumCoopBox.Items.Clear();
            _mediumCoop2Box.Items.Clear();
            _hardGuitarBox.Items.Clear();
            _hardRhythmBox.Items.Clear();
            _hardCoopBox.Items.Clear();
            _hardCoop2Box.Items.Clear();
            _expertGuitarBox.Items.Clear();
            _expertRhythmBox.Items.Clear();
            _expertCoopBox.Items.Clear();
            _expertCoop2Box.Items.Clear();
            _faceOffP1Box.Items.Clear();
            _faceOffP2Box.Items.Clear();
            _bossBattleP1Box.Items.Clear();
            _bossBattleP2Box.Items.Clear();
        }

        private void AutoConfigBtn_Click(object sender, EventArgs e)
        {
            method_7();
        }

        private void method_7()
        {
            _expertGuitarBox.SelectedItem = (_hardGuitarBox.SelectedItem =
                (_mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "easy")));
            _expertGuitarBox.SelectedItem = (_hardGuitarBox.SelectedItem =
                (_mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "medium")));
            _expertGuitarBox.SelectedItem = (_hardGuitarBox.SelectedItem =
                (_mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "hard")));
            _expertGuitarBox.SelectedItem = (_hardGuitarBox.SelectedItem =
                (_mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "expert")));
            _hardGuitarBox.SelectedItem = (_mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "hard"));
            _mediumGuitarBox.SelectedItem = (_easyGuitarBox.SelectedItem = "medium");
            _easyGuitarBox.SelectedItem = "easy";
            _expertRhythmBox.SelectedItem = (_hardRhythmBox.SelectedItem =
                (_mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_easy")));
            _expertRhythmBox.SelectedItem = (_hardRhythmBox.SelectedItem =
                (_mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_medium")));
            _expertRhythmBox.SelectedItem = (_hardRhythmBox.SelectedItem =
                (_mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_hard")));
            _expertRhythmBox.SelectedItem = (_hardRhythmBox.SelectedItem =
                (_mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_expert")));
            _hardRhythmBox.SelectedItem =
                (_mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_hard"));
            _mediumRhythmBox.SelectedItem = (_easyRhythmBox.SelectedItem = "rhythm_medium");
            _easyRhythmBox.SelectedItem = "rhythm_easy";
            _expertCoopBox.SelectedItem = (_hardCoopBox.SelectedItem =
                (_mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_easy")));
            _expertCoopBox.SelectedItem = (_hardCoopBox.SelectedItem =
                (_mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_medium")));
            _expertCoopBox.SelectedItem = (_hardCoopBox.SelectedItem =
                (_mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_hard")));
            _expertCoopBox.SelectedItem = (_hardCoopBox.SelectedItem =
                (_mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_expert")));
            _hardCoopBox.SelectedItem = (_mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_hard"));
            _mediumCoopBox.SelectedItem = (_easyCoopBox.SelectedItem = "guitarcoop_medium");
            _easyCoopBox.SelectedItem = "guitarcoop_easy";
            _expertCoop2Box.SelectedItem = (_hardCoop2Box.SelectedItem =
                (_mediumCoop2Box.SelectedItem = (_easyCoop2Box.SelectedItem = "rhythmcoop_easy")));
            _expertCoop2Box.SelectedItem = (_hardCoop2Box.SelectedItem =
                (_mediumCoop2Box.SelectedItem = (_easyCoop2Box.SelectedItem = "rhythmcoop_medium")));
            _expertCoop2Box.SelectedItem = (_hardCoop2Box.SelectedItem =
                (_mediumCoop2Box.SelectedItem = (_easyCoop2Box.SelectedItem = "rhythmcoop_hard")));
            _expertCoop2Box.SelectedItem = (_hardCoop2Box.SelectedItem =
                (_mediumCoop2Box.SelectedItem = (_easyCoop2Box.SelectedItem = "rhythmcoop_expert")));
            _hardCoop2Box.SelectedItem = (_mediumCoop2Box.SelectedItem =
                (_easyCoop2Box.SelectedItem = "rhythmcoop_hard"));
            _mediumCoop2Box.SelectedItem = (_easyCoop2Box.SelectedItem = "rhythmcoop_medium");
            _easyCoop2Box.SelectedItem = "rhythmcoop_easy";
            _faceOffP1Box.SelectedItem = "faceoffp1";
            _faceOffP2Box.SelectedItem = "faceoffp2";
            _bossBattleP1Box.SelectedItem = "bossbattlep1";
            _bossBattleP2Box.SelectedItem = "bossbattlep2";
        }

        private void method_8(int int0)
        {
            ListControl arg12F0 = _easyGuitarBox;
            ListControl arg1280 = _easyRhythmBox;
            ListControl arg11E0 = _easyCoopBox;
            ListControl arg1140 = _easyCoop2Box;
            ListControl arg10A0 = _mediumGuitarBox;
            ListControl arg1000 = _mediumRhythmBox;
            ListControl argF60 = _mediumCoopBox;
            ListControl argEc0 = _mediumCoop2Box;
            ListControl argE20 = _hardGuitarBox;
            ListControl argD80 = _hardRhythmBox;
            ListControl argCe0 = _hardCoopBox;
            ListControl argC40 = _hardCoop2Box;
            ListControl argBa0 = _expertGuitarBox;
            ListControl argB00 = _expertRhythmBox;
            ListControl argA60 = _expertCoopBox;
            ListControl arg_9C0 = _expertCoop2Box;
            ListControl arg930 = _faceOffP1Box;
            ListControl arg_8B0 = _faceOffP2Box;
            ListControl arg830 = _bossBattleP1Box;
            _bossBattleP2Box.SelectedIndex = int0;
            arg830.SelectedIndex = int0;
            arg_8B0.SelectedIndex = int0;
            arg930.SelectedIndex = int0;
            arg_9C0.SelectedIndex = int0;
            argA60.SelectedIndex = int0;
            argB00.SelectedIndex = int0;
            argBa0.SelectedIndex = int0;
            argC40.SelectedIndex = int0;
            argCe0.SelectedIndex = int0;
            argD80.SelectedIndex = int0;
            argE20.SelectedIndex = int0;
            argEc0.SelectedIndex = int0;
            argF60.SelectedIndex = int0;
            arg1000.SelectedIndex = int0;
            arg10A0.SelectedIndex = int0;
            arg1140.SelectedIndex = int0;
            arg11E0.SelectedIndex = int0;
            arg1280.SelectedIndex = int0;
            arg12F0.SelectedIndex = int0;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            method_8(0);
        }

        private void ChartFileBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the game track file.",
                "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart",
                true)).Equals(""))
            {
                _bool4 = false;
                try
                {
                    //Configures paks
                    if (fileName.EndsWith("_song.pak.xen"))
                    {
                        var text2 = KeyGenerator.GetFileName(fileName).Replace("_song.pak.xen", "");
                        using (var @class = new ZzPakNode2(fileName, false))
                        {
                            if (!@class.method_6("songs\\" + text2 + ".mid.qb"))
                            {
                                throw new Exception("MID.QB song file not found.");
                            }
                            _qbcParser = new QbcParser(text2, @class.ZzGetNode1("songs\\" + text2 + ".mid.qb"));
                            goto IL_F5;
                        }
                    }
                    //Configures qbc
                    if (fileName.EndsWith(".qbc"))
                    {
                        _qbcParser = new QbcParser(fileName);
                    }
                    //Configures midi
                    else if (fileName.EndsWith(".mid"))
                    {
                        _qbcParser = Midi2Chart.LoadMidiSong(fileName, _forceRb3);
                    }
                    //Configures charts
                    else
                    {
                        //Crashes in this
                        _qbcParser = new ChartParser(fileName).ConvertToQbc();
                    }
                    IL_F5:
                    method_6();
                    method_4("No Track");
                    method_5("No Track");
                    method_8(0);
                    Control arg12B0 = _autoConfigBtn;
                    _resetBtn.Enabled = true;
                    arg12B0.Enabled = true;
                    foreach (var current in _qbcParser.NoteList.Keys)
                    {
                        method_4(current);
                    }
                    if (_qbcParser.Class2282.Count != 0)
                    {
                        method_5("faceoffp1");
                    }
                    if (_qbcParser.Class2283.Count != 0)
                    {
                        method_5("faceoffp2");
                    }
                    if (_qbcParser.BpmList.Count != 0)
                    {
                        method_5("bossbattlep1");
                    }
                    if (_qbcParser.Class2285.Count != 0)
                    {
                        method_5("bossbattlep2");
                    }
                    _chartFileTxt.Text = fileName;
                    _chartFileTxt.SelectionStart = _chartFileTxt.TextLength;
                    _bool4 = true;
                    method_7();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Game Track cannot be parsed.\n" + ex.Message);
                }
                EnableAudioButtons();
            }
        }

        private void method_9()
        {
            _guitarAudioTxt.Text = (_rhythmAudioTxt.Text =
                (_bandAudioTxt.Text = (_guitarCoopTxt.Text = (_rhythmCoopTxt.Text = (_bandCoopTxt.Text = "")))));
            _previewSlider.method_18(1);
            _previewSlider.method_14(0);
            _previewSlider.Enabled = false;
            if (_audio != null)
            {
                _audio.Dispose();
                _audio = null;
            }
        }

        private void SingleAudioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Control arg730 = _rhythmAudioBtn;
            Control arg_6D0 = _rhythmAudioTxt;
            Control arg670 = _bandAudioBtn;
            Control arg610 = _bandAudioTxt;
            Control arg_5B0 = _guitarCoopBtn;
            Control arg550 = _guitarCoopTxt;
            Control arg_4F0 = _rhythmCoopBtn;
            Control arg490 = _rhythmCoopTxt;
            Control arg430 = _bandCoopBtn;
            _bandCoopTxt.Enabled = false;
            arg430.Enabled = false;
            arg490.Enabled = false;
            arg_4F0.Enabled = false;
            arg550.Enabled = false;
            arg_5B0.Enabled = false;
            arg610.Enabled = false;
            arg670.Enabled = false;
            arg_6D0.Enabled = false;
            arg730.Enabled = false;
            method_9();
        }

        private void DualAudioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Control arg130 = _bandAudioBtn;
            _bandAudioTxt.Enabled = true;
            arg130.Enabled = true;
            Control arg730 = _rhythmAudioBtn;
            Control arg_6D0 = _rhythmAudioTxt;
            Control arg670 = _guitarCoopBtn;
            Control arg610 = _guitarCoopTxt;
            Control arg_5B0 = _rhythmCoopBtn;
            Control arg550 = _rhythmCoopTxt;
            Control arg_4F0 = _bandCoopBtn;
            _bandCoopTxt.Enabled = false;
            arg_4F0.Enabled = false;
            arg550.Enabled = false;
            arg_5B0.Enabled = false;
            arg610.Enabled = false;
            arg670.Enabled = false;
            arg_6D0.Enabled = false;
            arg730.Enabled = false;
            method_9();
        }

        private void MultiAudioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Control arg_2B0 = _rhythmAudioBtn;
            Control arg250 = _rhythmAudioTxt;
            Control arg_1F0 = _bandAudioBtn;
            _bandAudioTxt.Enabled = true;
            arg_1F0.Enabled = true;
            arg250.Enabled = true;
            arg_2B0.Enabled = true;
            Control arg730 = _guitarCoopBtn;
            Control arg_6D0 = _guitarCoopTxt;
            Control arg670 = _rhythmCoopBtn;
            Control arg610 = _rhythmCoopTxt;
            Control arg_5B0 = _bandCoopBtn;
            _bandCoopTxt.Enabled = false;
            arg_5B0.Enabled = false;
            arg610.Enabled = false;
            arg670.Enabled = false;
            arg_6D0.Enabled = false;
            arg730.Enabled = false;
            method_9();
        }

        private void CoopAudioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Control arg730 = _rhythmAudioBtn;
            Control arg_6D0 = _rhythmAudioTxt;
            Control arg670 = _bandAudioBtn;
            Control arg610 = _bandAudioTxt;
            Control arg_5B0 = _guitarCoopBtn;
            Control arg550 = _guitarCoopTxt;
            Control arg_4F0 = _rhythmCoopBtn;
            Control arg490 = _rhythmCoopTxt;
            Control arg430 = _bandCoopBtn;
            _bandCoopTxt.Enabled = true;
            arg430.Enabled = true;
            arg490.Enabled = true;
            arg_4F0.Enabled = true;
            arg550.Enabled = true;
            arg_5B0.Enabled = true;
            arg610.Enabled = true;
            arg670.Enabled = true;
            arg_6D0.Enabled = true;
            arg730.Enabled = true;
            method_9();
        }

        private void GuitarAudioBtn_Click(object sender, EventArgs e)
        {
            var fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Audio track file.",
                    "Any Supported Audio Formats|*.dat.xen;*.mp3;*.wav;*.ogg;*.flac|GH3 Audio Header file|*.dat.xen|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                    true)
                .ToLower();
            if (_singleAudioBtn.Checked)
            {
                if (!(fileName.Equals("")))
                {
                    _guitarAudioTxt.Text = fileName;
                    _guitarAudioTxt.SelectionStart = _guitarAudioTxt.TextLength;
                    if (fileName.EndsWith(".dat.xen"))
                    {
                        if (!File.Exists(fileName.Replace(".dat.xen", ".fsb.xen")))
                        {
                            MessageBox.Show("Data file (FSB.XEN) is missing.", "Error!");
                            _class3230 = null;
                            _guitarAudioTxt.Text = "";
                        }
                        else
                        {
                            _class3230 = new ZzQbSongObject(fileName);
                            if ((int) new FileInfo(fileName.Replace(".dat.xen", ".fsb.xen")).Length != _class3230.Int0)
                            {
                                MessageBox.Show("FSB file size does not match!", "Error!");
                                _class3230 = null;
                                _guitarAudioTxt.Text = "";
                            }
                            else
                            {
                                _previewSlider.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        _previewSlider.Enabled = true;
                        LoadAudio();
                    }
                    EnableAudioButtons();
                }
            }
            else if (!(fileName.Equals("")))
            {
                _guitarAudioTxt.Text = fileName;
                _guitarAudioTxt.SelectionStart = _guitarAudioTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void RhythmAudioBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Rhythm Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _rhythmAudioTxt.Text = fileName;
                _rhythmAudioTxt.SelectionStart = _rhythmAudioTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void BandAudioBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Band Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _bandAudioTxt.Text = fileName;
                _bandAudioTxt.SelectionStart = _bandAudioTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void GuitarCoopBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Coop Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _guitarCoopTxt.Text = fileName;
                _guitarCoopTxt.SelectionStart = _guitarCoopTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void RhythmCoopBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Rhythm Coop Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _rhythmCoopTxt.Text = fileName;
                _rhythmCoopTxt.SelectionStart = _rhythmCoopTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void BandCoopBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Band Coop Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _bandCoopTxt.Text = fileName;
                _bandCoopTxt.SelectionStart = _bandCoopTxt.TextLength;
                _previewSlider.Enabled = true;
                LoadAudio();
                EnableAudioButtons();
            }
        }

        private void SongNameTxt_TextChanged(object sender, EventArgs e)
        {
            if (_gh3Songlist0 != null)
            {
                _bool2 = (_songNameTxt.Text != "" && !QbSongClass1.smethod_4(_songNameTxt.Text) &&
                          !_gh3Songlist0.method_3(_songNameTxt.Text));
            }
            EnableAudioButtons();
        }

        private void SongNameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void SongData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_audio != null)
            {
                _audio.Dispose();
            }
        }

        ~SongData()
        {
            if (_audio != null)
            {
                _audio.Dispose();
            }
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (_audio != null && _bool5)
            {
                _previewSlider.method_14((int) _audio.AudioLength().TotalSeconds);
            }
        }

        private void Play_Btn_Click(object sender, EventArgs e)
        {
            if (_audio == null)
            {
                return;
            }
            _audio.DifferentStartPlaying();
            _timer0.Start();
        }

        private void Pause_Btn_Click(object sender, EventArgs e)
        {
            if (_audio == null)
            {
                return;
            }
            _audio.StartPlaying();
            _timer0.Stop();
        }

        private void Stop_Btn_Click(object sender, EventArgs e)
        {
            if (_audio == null)
            {
                return;
            }
            _audio.StopPlaying();
            _timer0.Stop();
            _previewSlider.method_14(_previewSlider.method_15());
            _audio.SetStartingTimeBasedOnSomeValue(0);
        }

        private void PreviewSlider_MouseUp(object sender, MouseEventArgs e)
        {
            _bool5 = true;
            _audio.SetStartingTime(TimeSpan.FromSeconds(_previewSlider.method_13()));
        }

        private void PreviewSlider_MouseDown(object sender, MouseEventArgs e)
        {
            _bool5 = false;
        }

        private void method_10(object sender, EventArgs e)
        {
            if (_audio != null)
            {
                _audio.SetVolume(_volumeSlider.method_13() / 100f);
            }
        }

        private void LoadAudio()
        {
            try
            {
                var list = new List<GenericAudioStream>();
                if (!_bandCoopTxt.Text.Equals(""))
                {
                    list.Add(AudioManager.GetAudioStream(_bandCoopTxt.Text));
                }
                else if (!_bandAudioTxt.Text.Equals(""))
                {
                    list.Add(AudioManager.GetAudioStream(_bandAudioTxt.Text));
                }
                if (!_guitarCoopTxt.Text.Equals("") && !_rhythmCoopTxt.Text.Equals(""))
                {
                    list.Insert(0, AudioManager.GetAudioStream(_rhythmCoopTxt.Text));
                    list.Insert(0, AudioManager.GetAudioStream(_guitarCoopTxt.Text));
                }
                else
                {
                    if (!_rhythmAudioTxt.Text.Equals(""))
                    {
                        list.Insert(0, AudioManager.GetAudioStream(_rhythmAudioTxt.Text));
                    }
                    if (!_guitarAudioTxt.Text.Equals(""))
                    {
                        list.Insert(0, AudioManager.GetAudioStream(_guitarAudioTxt.Text));
                    }
                }
                if (list.Count != 0)
                {
                    var stream = (list.Count == 1) ? list[0] : new Stream2(list.ToArray());
                    if (_audio != null)
                    {
                        _audio.Dispose();
                    }
                    _audio = AudioManager.LoadPlayableAudio(Enum25.Const5, stream);
                    _previewSlider.method_14((int) _audio.AudioLength().TotalSeconds);
                    _previewSlider.method_18((int) stream.vmethod_1().TimeSpan0.TotalSeconds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load audio file/s.\n" + ex.Message);
            }
        }
    }
}