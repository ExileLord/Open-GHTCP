using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GuitarHero.Songlist;
using MidiConverter;
using ns0;
using ns1;
using ns14;
using ns15;
using ns16;
using ns19;
using ns20;
using ns8;
using ns9;

namespace ns17
{
	public class SongData : Form
	{
		private IContainer icontainer_0;

		private TextBox GuitarAudioTxt;

		private Label label6;

		private GroupBox AudioGroupBox;

		private Label label3;

		private TextBox BandAudioTxt;

		private Label label2;

		private TextBox RhythmAudioTxt;

		private Button GuitarAudioBtn;

		private Label label1;

		private RadioButton MultiAudioBtn;

		private RadioButton SingleAudioBtn;

		private Button BandAudioBtn;

		private Button RhythmAudioBtn;

		private GroupBox ChartGroupBox;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label5;

		private Button ChartFileBtn;

		private Label label4;

		private TextBox ChartFileTxt;

		private GroupBox groupBox3;

		private ComboBox ExpertGuitarBox;

		private ComboBox HardGuitarBox;

		private ComboBox MediumGuitarBox;

		private ComboBox EasyGuitarBox;

		private GroupBox groupBox5;

		private ComboBox ExpertCoop2Box;

		private ComboBox HardCoop2Box;

		private ComboBox MediumCoop2Box;

		private ComboBox EasyCoop2Box;

		private GroupBox groupBox4;

		private ComboBox ExpertRhythmBox;

		private ComboBox HardRhythmBox;

		private ComboBox MediumRhythmBox;

		private ComboBox EasyRhythmBox;

		private GroupBox groupBox6;

		private ComboBox ExpertCoopBox;

		private ComboBox HardCoopBox;

		private ComboBox MediumCoopBox;

		private ComboBox EasyCoopBox;

		private Button AutoConfigBtn;

		private Button ResetBtn;

		private Label label10;

		private TextBox SongNameTxt;

		private GroupBox MainGroupBox;

		private CheckBox Chart_CheckBox;

		private CheckBox Audio_CheckBox;

		private Button CancelBtn;

		private Button ApplyBtn;

		private Label label11;

		private Control1 PreviewSlider;

		private Label label12;

		private Button BandCoopBtn;

		private Button RhythmCoopBtn;

		private Button GuitarCoopBtn;

		private TextBox BandCoopTxt;

		private TextBox RhythmCoopTxt;

		private TextBox GuitarCoopTxt;

		private RadioButton CoopAudioBtn;

		private RadioButton DualAudioBtn;

		private GroupBox groupBox1;

		private ComboBox FaceOffP1Box;

		private Label label13;

		private GroupBox groupBox7;

		private ComboBox BossBattleP2Box;

		private GroupBox groupBox2;

		private ComboBox FaceOffP2Box;

		private GroupBox groupBox8;

		private ComboBox BossBattleP1Box;

		private Button Stop_Btn;

		private Button Pause_Btn;

		private Button Play_Btn;

		private Control1 VolumeSlider;

		public bool bool_0;

		public bool bool_1;

		private zzQbSongObject class323_0;

		private QBCParser qbcParser;

		private readonly GH3Songlist gh3Songlist_0;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private PlayableAudio Audio;

		private readonly Timer timer_0;

		private bool bool_5 = true;

        private bool forceRB3;

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
			GuitarAudioTxt = new TextBox();
			label6 = new Label();
			AudioGroupBox = new GroupBox();
			Stop_Btn = new Button();
			Pause_Btn = new Button();
			Play_Btn = new Button();
			DualAudioBtn = new RadioButton();
			CoopAudioBtn = new RadioButton();
			BandCoopBtn = new Button();
			RhythmCoopBtn = new Button();
			GuitarCoopBtn = new Button();
			BandCoopTxt = new TextBox();
			RhythmCoopTxt = new TextBox();
			GuitarCoopTxt = new TextBox();
			label11 = new Label();
			BandAudioBtn = new Button();
			RhythmAudioBtn = new Button();
			GuitarAudioBtn = new Button();
			label1 = new Label();
			MultiAudioBtn = new RadioButton();
			SingleAudioBtn = new RadioButton();
			label3 = new Label();
			BandAudioTxt = new TextBox();
			label2 = new Label();
			RhythmAudioTxt = new TextBox();
			ChartGroupBox = new GroupBox();
			groupBox7 = new GroupBox();
			BossBattleP2Box = new ComboBox();
			groupBox2 = new GroupBox();
			FaceOffP2Box = new ComboBox();
			groupBox8 = new GroupBox();
			BossBattleP1Box = new ComboBox();
			groupBox1 = new GroupBox();
			FaceOffP1Box = new ComboBox();
			label13 = new Label();
			ResetBtn = new Button();
			AutoConfigBtn = new Button();
			groupBox5 = new GroupBox();
			ExpertCoop2Box = new ComboBox();
			HardCoop2Box = new ComboBox();
			MediumCoop2Box = new ComboBox();
			EasyCoop2Box = new ComboBox();
			groupBox4 = new GroupBox();
			ExpertRhythmBox = new ComboBox();
			HardRhythmBox = new ComboBox();
			MediumRhythmBox = new ComboBox();
			EasyRhythmBox = new ComboBox();
			groupBox6 = new GroupBox();
			ExpertCoopBox = new ComboBox();
			HardCoopBox = new ComboBox();
			MediumCoopBox = new ComboBox();
			EasyCoopBox = new ComboBox();
			groupBox3 = new GroupBox();
			ExpertGuitarBox = new ComboBox();
			HardGuitarBox = new ComboBox();
			MediumGuitarBox = new ComboBox();
			EasyGuitarBox = new ComboBox();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label5 = new Label();
			ChartFileBtn = new Button();
			label4 = new Label();
			ChartFileTxt = new TextBox();
			label10 = new Label();
			SongNameTxt = new TextBox();
			MainGroupBox = new GroupBox();
			label12 = new Label();
			CancelBtn = new Button();
			ApplyBtn = new Button();
			Chart_CheckBox = new CheckBox();
			Audio_CheckBox = new CheckBox();
			VolumeSlider = new Control1();
			PreviewSlider = new Control1();
			AudioGroupBox.SuspendLayout();
			ChartGroupBox.SuspendLayout();
			groupBox7.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox8.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox3.SuspendLayout();
			MainGroupBox.SuspendLayout();
			SuspendLayout();
			GuitarAudioTxt.Location = new Point(113, 39);
			GuitarAudioTxt.Name = "GuitarAudioTxt";
			GuitarAudioTxt.ReadOnly = true;
			GuitarAudioTxt.Size = new Size(180, 20);
			GuitarAudioTxt.TabIndex = 39;
			label6.AutoSize = true;
			label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(6, 38);
			label6.Name = "label6";
			label6.Size = new Size(101, 19);
			label6.TabIndex = 39;
			label6.Text = "Guitar Track:";
			label6.TextAlign = ContentAlignment.MiddleCenter;
			AudioGroupBox.Controls.Add(VolumeSlider);
			AudioGroupBox.Controls.Add(Stop_Btn);
			AudioGroupBox.Controls.Add(Pause_Btn);
			AudioGroupBox.Controls.Add(Play_Btn);
			AudioGroupBox.Controls.Add(DualAudioBtn);
			AudioGroupBox.Controls.Add(CoopAudioBtn);
			AudioGroupBox.Controls.Add(BandCoopBtn);
			AudioGroupBox.Controls.Add(RhythmCoopBtn);
			AudioGroupBox.Controls.Add(GuitarCoopBtn);
			AudioGroupBox.Controls.Add(BandCoopTxt);
			AudioGroupBox.Controls.Add(RhythmCoopTxt);
			AudioGroupBox.Controls.Add(GuitarCoopTxt);
			AudioGroupBox.Controls.Add(PreviewSlider);
			AudioGroupBox.Controls.Add(label11);
			AudioGroupBox.Controls.Add(BandAudioBtn);
			AudioGroupBox.Controls.Add(RhythmAudioBtn);
			AudioGroupBox.Controls.Add(GuitarAudioBtn);
			AudioGroupBox.Controls.Add(label1);
			AudioGroupBox.Controls.Add(MultiAudioBtn);
			AudioGroupBox.Controls.Add(SingleAudioBtn);
			AudioGroupBox.Controls.Add(label3);
			AudioGroupBox.Controls.Add(BandAudioTxt);
			AudioGroupBox.Controls.Add(label2);
			AudioGroupBox.Controls.Add(RhythmAudioTxt);
			AudioGroupBox.Controls.Add(label6);
			AudioGroupBox.Controls.Add(GuitarAudioTxt);
			AudioGroupBox.Location = new Point(12, 96);
			AudioGroupBox.Name = "AudioGroupBox";
			AudioGroupBox.Size = new Size(566, 168);
			AudioGroupBox.TabIndex = 36;
			AudioGroupBox.TabStop = false;
			AudioGroupBox.Text = "Audio Track";
			Stop_Btn.FlatStyle = FlatStyle.Popup;
			Stop_Btn.Location = new Point(205, 137);
			Stop_Btn.Name = "Stop_Btn";
			Stop_Btn.Size = new Size(37, 20);
			Stop_Btn.TabIndex = 50;
			Stop_Btn.Text = "Stop";
			Stop_Btn.UseVisualStyleBackColor = true;
			Stop_Btn.Click += Stop_Btn_Click;
			Pause_Btn.FlatStyle = FlatStyle.Popup;
			Pause_Btn.Location = new Point(160, 137);
			Pause_Btn.Name = "Pause_Btn";
			Pause_Btn.Size = new Size(45, 20);
			Pause_Btn.TabIndex = 49;
			Pause_Btn.Text = "Pause";
			Pause_Btn.UseVisualStyleBackColor = true;
			Pause_Btn.Click += Pause_Btn_Click;
			Play_Btn.FlatStyle = FlatStyle.Popup;
			Play_Btn.Location = new Point(123, 137);
			Play_Btn.Name = "Play_Btn";
			Play_Btn.Size = new Size(37, 20);
			Play_Btn.TabIndex = 48;
			Play_Btn.Text = "Play";
			Play_Btn.UseVisualStyleBackColor = true;
			Play_Btn.Click += Play_Btn_Click;
			DualAudioBtn.AutoSize = true;
			DualAudioBtn.Location = new Point(194, 18);
			DualAudioBtn.Name = "DualAudioBtn";
			DualAudioBtn.Size = new Size(84, 17);
			DualAudioBtn.TabIndex = 5;
			DualAudioBtn.Text = "Guitar Track";
			DualAudioBtn.UseVisualStyleBackColor = true;
			DualAudioBtn.CheckedChanged += DualAudioBtn_CheckedChanged;
			CoopAudioBtn.AutoSize = true;
			CoopAudioBtn.Location = new Point(382, 18);
			CoopAudioBtn.Name = "CoopAudioBtn";
			CoopAudioBtn.Size = new Size(86, 17);
			CoopAudioBtn.TabIndex = 7;
			CoopAudioBtn.Text = "Coop Tracks";
			CoopAudioBtn.UseVisualStyleBackColor = true;
			CoopAudioBtn.CheckedChanged += CoopAudioBtn_CheckedChanged;
			BandCoopBtn.Enabled = false;
			BandCoopBtn.Location = new Point(539, 91);
			BandCoopBtn.Name = "BandCoopBtn";
			BandCoopBtn.Size = new Size(24, 21);
			BandCoopBtn.TabIndex = 13;
			BandCoopBtn.Text = "...";
			BandCoopBtn.UseVisualStyleBackColor = true;
			BandCoopBtn.Click += BandCoopBtn_Click;
			RhythmCoopBtn.Enabled = false;
			RhythmCoopBtn.Location = new Point(539, 65);
			RhythmCoopBtn.Name = "RhythmCoopBtn";
			RhythmCoopBtn.Size = new Size(24, 21);
			RhythmCoopBtn.TabIndex = 12;
			RhythmCoopBtn.Text = "...";
			RhythmCoopBtn.UseVisualStyleBackColor = true;
			RhythmCoopBtn.Click += RhythmCoopBtn_Click;
			GuitarCoopBtn.Enabled = false;
			GuitarCoopBtn.Location = new Point(539, 38);
			GuitarCoopBtn.Name = "GuitarCoopBtn";
			GuitarCoopBtn.Size = new Size(24, 21);
			GuitarCoopBtn.TabIndex = 11;
			GuitarCoopBtn.Text = "...";
			GuitarCoopBtn.UseVisualStyleBackColor = true;
			GuitarCoopBtn.Click += GuitarCoopBtn_Click;
			BandCoopTxt.Enabled = false;
			BandCoopTxt.Location = new Point(329, 92);
			BandCoopTxt.Name = "BandCoopTxt";
			BandCoopTxt.ReadOnly = true;
			BandCoopTxt.Size = new Size(204, 20);
			BandCoopTxt.TabIndex = 46;
			RhythmCoopTxt.Enabled = false;
			RhythmCoopTxt.Location = new Point(329, 66);
			RhythmCoopTxt.Name = "RhythmCoopTxt";
			RhythmCoopTxt.ReadOnly = true;
			RhythmCoopTxt.Size = new Size(204, 20);
			RhythmCoopTxt.TabIndex = 45;
			GuitarCoopTxt.Enabled = false;
			GuitarCoopTxt.Location = new Point(329, 39);
			GuitarCoopTxt.Name = "GuitarCoopTxt";
			GuitarCoopTxt.ReadOnly = true;
			GuitarCoopTxt.Size = new Size(204, 20);
			GuitarCoopTxt.TabIndex = 44;
			label11.AutoSize = true;
			label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(6, 129);
			label11.Name = "label11";
			label11.Size = new Size(111, 19);
			label11.TabIndex = 47;
			label11.Text = "Preview Track:";
			label11.TextAlign = ContentAlignment.MiddleCenter;
			BandAudioBtn.Enabled = false;
			BandAudioBtn.Location = new Point(299, 91);
			BandAudioBtn.Name = "BandAudioBtn";
			BandAudioBtn.Size = new Size(24, 21);
			BandAudioBtn.TabIndex = 10;
			BandAudioBtn.Text = "...";
			BandAudioBtn.UseVisualStyleBackColor = true;
			BandAudioBtn.Click += BandAudioBtn_Click;
			RhythmAudioBtn.Enabled = false;
			RhythmAudioBtn.Location = new Point(299, 65);
			RhythmAudioBtn.Name = "RhythmAudioBtn";
			RhythmAudioBtn.Size = new Size(24, 21);
			RhythmAudioBtn.TabIndex = 9;
			RhythmAudioBtn.Text = "...";
			RhythmAudioBtn.UseVisualStyleBackColor = true;
			RhythmAudioBtn.Click += RhythmAudioBtn_Click;
			GuitarAudioBtn.Location = new Point(299, 38);
			GuitarAudioBtn.Name = "GuitarAudioBtn";
			GuitarAudioBtn.Size = new Size(24, 21);
			GuitarAudioBtn.TabIndex = 8;
			GuitarAudioBtn.Text = "...";
			GuitarAudioBtn.UseVisualStyleBackColor = true;
			GuitarAudioBtn.Click += GuitarAudioBtn_Click;
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(6, 16);
			label1.Name = "label1";
			label1.Size = new Size(91, 19);
			label1.TabIndex = 38;
			label1.Text = "Audio Type:";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			MultiAudioBtn.AutoSize = true;
			MultiAudioBtn.Location = new Point(284, 18);
			MultiAudioBtn.Name = "MultiAudioBtn";
			MultiAudioBtn.Size = new Size(92, 17);
			MultiAudioBtn.TabIndex = 6;
			MultiAudioBtn.Text = "Rhythm Track";
			MultiAudioBtn.UseVisualStyleBackColor = true;
			MultiAudioBtn.CheckedChanged += MultiAudioBtn_CheckedChanged;
			SingleAudioBtn.AutoSize = true;
			SingleAudioBtn.Checked = true;
			SingleAudioBtn.Location = new Point(103, 18);
			SingleAudioBtn.Name = "SingleAudioBtn";
			SingleAudioBtn.Size = new Size(85, 17);
			SingleAudioBtn.TabIndex = 4;
			SingleAudioBtn.TabStop = true;
			SingleAudioBtn.Text = "Single Track";
			SingleAudioBtn.UseVisualStyleBackColor = true;
			SingleAudioBtn.CheckedChanged += SingleAudioBtn_CheckedChanged;
			label3.AutoSize = true;
			label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(6, 91);
			label3.Name = "label3";
			label3.Size = new Size(93, 19);
			label3.TabIndex = 42;
			label3.Text = "Band Track:";
			label3.TextAlign = ContentAlignment.MiddleCenter;
			BandAudioTxt.Enabled = false;
			BandAudioTxt.Location = new Point(105, 92);
			BandAudioTxt.Name = "BandAudioTxt";
			BandAudioTxt.ReadOnly = true;
			BandAudioTxt.Size = new Size(188, 20);
			BandAudioTxt.TabIndex = 43;
			label2.AutoSize = true;
			label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(6, 65);
			label2.Name = "label2";
			label2.Size = new Size(111, 19);
			label2.TabIndex = 40;
			label2.Text = "Rhythm Track:";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			RhythmAudioTxt.Enabled = false;
			RhythmAudioTxt.Location = new Point(123, 66);
			RhythmAudioTxt.Name = "RhythmAudioTxt";
			RhythmAudioTxt.ReadOnly = true;
			RhythmAudioTxt.Size = new Size(170, 20);
			RhythmAudioTxt.TabIndex = 41;
			ChartGroupBox.Controls.Add(groupBox7);
			ChartGroupBox.Controls.Add(groupBox2);
			ChartGroupBox.Controls.Add(groupBox8);
			ChartGroupBox.Controls.Add(groupBox1);
			ChartGroupBox.Controls.Add(label13);
			ChartGroupBox.Controls.Add(ResetBtn);
			ChartGroupBox.Controls.Add(AutoConfigBtn);
			ChartGroupBox.Controls.Add(groupBox5);
			ChartGroupBox.Controls.Add(groupBox4);
			ChartGroupBox.Controls.Add(groupBox6);
			ChartGroupBox.Controls.Add(groupBox3);
			ChartGroupBox.Controls.Add(label9);
			ChartGroupBox.Controls.Add(label8);
			ChartGroupBox.Controls.Add(label7);
			ChartGroupBox.Controls.Add(label5);
			ChartGroupBox.Controls.Add(ChartFileBtn);
			ChartGroupBox.Controls.Add(label4);
			ChartGroupBox.Controls.Add(ChartFileTxt);
			ChartGroupBox.Location = new Point(12, 270);
			ChartGroupBox.Name = "ChartGroupBox";
			ChartGroupBox.Size = new Size(566, 239);
			ChartGroupBox.TabIndex = 37;
			ChartGroupBox.TabStop = false;
			ChartGroupBox.Text = "Game Track";
			groupBox7.Controls.Add(BossBattleP2Box);
			groupBox7.Location = new Point(445, 180);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new Size(110, 48);
			groupBox7.TabIndex = 58;
			groupBox7.TabStop = false;
			groupBox7.Text = "Boss Battle P2";
			BossBattleP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			BossBattleP2Box.FormattingEnabled = true;
			BossBattleP2Box.Location = new Point(6, 19);
			BossBattleP2Box.Name = "BossBattleP2Box";
			BossBattleP2Box.Size = new Size(98, 21);
			BossBattleP2Box.TabIndex = 18;
			groupBox2.Controls.Add(FaceOffP2Box);
			groupBox2.Location = new Point(213, 180);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(110, 48);
			groupBox2.TabIndex = 56;
			groupBox2.TabStop = false;
			groupBox2.Text = "Face Off P2";
			FaceOffP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			FaceOffP2Box.FormattingEnabled = true;
			FaceOffP2Box.Location = new Point(6, 19);
			FaceOffP2Box.Name = "FaceOffP2Box";
			FaceOffP2Box.Size = new Size(98, 21);
			FaceOffP2Box.TabIndex = 18;
			groupBox8.Controls.Add(BossBattleP1Box);
			groupBox8.Location = new Point(329, 180);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new Size(110, 48);
			groupBox8.TabIndex = 57;
			groupBox8.TabStop = false;
			groupBox8.Text = "Boss Battle P1";
			BossBattleP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
			BossBattleP1Box.FormattingEnabled = true;
			BossBattleP1Box.Location = new Point(6, 19);
			BossBattleP1Box.Name = "BossBattleP1Box";
			BossBattleP1Box.Size = new Size(98, 21);
			BossBattleP1Box.TabIndex = 18;
			groupBox1.Controls.Add(FaceOffP1Box);
			groupBox1.Location = new Point(97, 180);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(110, 48);
			groupBox1.TabIndex = 55;
			groupBox1.TabStop = false;
			groupBox1.Text = "Face Off P1";
			FaceOffP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
			FaceOffP1Box.FormattingEnabled = true;
			FaceOffP1Box.Location = new Point(6, 19);
			FaceOffP1Box.Name = "FaceOffP1Box";
			FaceOffP1Box.Size = new Size(98, 21);
			FaceOffP1Box.TabIndex = 18;
			label13.AutoSize = true;
			label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.Location = new Point(-2, 201);
			label13.Name = "label13";
			label13.Size = new Size(93, 19);
			label13.TabIndex = 58;
			label13.Text = "SECTIONS:";
			label13.TextAlign = ContentAlignment.MiddleCenter;
			ResetBtn.Enabled = false;
			ResetBtn.Location = new Point(512, 15);
			ResetBtn.Name = "ResetBtn";
			ResetBtn.Size = new Size(43, 23);
			ResetBtn.TabIndex = 17;
			ResetBtn.Text = "Reset";
			ResetBtn.UseVisualStyleBackColor = true;
			ResetBtn.Click += ResetBtn_Click;
			AutoConfigBtn.Enabled = false;
			AutoConfigBtn.Location = new Point(404, 15);
			AutoConfigBtn.Name = "AutoConfigBtn";
			AutoConfigBtn.Size = new Size(102, 23);
			AutoConfigBtn.TabIndex = 16;
			AutoConfigBtn.Text = "Auto Configuration";
			AutoConfigBtn.UseVisualStyleBackColor = true;
			AutoConfigBtn.Click += AutoConfigBtn_Click;
			groupBox5.Controls.Add(ExpertCoop2Box);
			groupBox5.Controls.Add(HardCoop2Box);
			groupBox5.Controls.Add(MediumCoop2Box);
			groupBox5.Controls.Add(EasyCoop2Box);
			groupBox5.Location = new Point(445, 43);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(110, 131);
			groupBox5.TabIndex = 57;
			groupBox5.TabStop = false;
			groupBox5.Text = "Coop Rhythm";
			ExpertCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpertCoop2Box.FormattingEnabled = true;
			ExpertCoop2Box.Location = new Point(6, 100);
			ExpertCoop2Box.Name = "ExpertCoop2Box";
			ExpertCoop2Box.Size = new Size(98, 21);
			ExpertCoop2Box.TabIndex = 33;
			HardCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			HardCoop2Box.FormattingEnabled = true;
			HardCoop2Box.Location = new Point(6, 73);
			HardCoop2Box.Name = "HardCoop2Box";
			HardCoop2Box.Size = new Size(98, 21);
			HardCoop2Box.TabIndex = 32;
			MediumCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			MediumCoop2Box.FormattingEnabled = true;
			MediumCoop2Box.Location = new Point(6, 46);
			MediumCoop2Box.Name = "MediumCoop2Box";
			MediumCoop2Box.Size = new Size(98, 21);
			MediumCoop2Box.TabIndex = 31;
			EasyCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			EasyCoop2Box.FormattingEnabled = true;
			EasyCoop2Box.Location = new Point(6, 19);
			EasyCoop2Box.Name = "EasyCoop2Box";
			EasyCoop2Box.Size = new Size(98, 21);
			EasyCoop2Box.TabIndex = 30;
			groupBox4.Controls.Add(ExpertRhythmBox);
			groupBox4.Controls.Add(HardRhythmBox);
			groupBox4.Controls.Add(MediumRhythmBox);
			groupBox4.Controls.Add(EasyRhythmBox);
			groupBox4.Location = new Point(213, 43);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(110, 131);
			groupBox4.TabIndex = 55;
			groupBox4.TabStop = false;
			groupBox4.Text = "Single Rhythm";
			ExpertRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpertRhythmBox.FormattingEnabled = true;
			ExpertRhythmBox.Location = new Point(6, 100);
			ExpertRhythmBox.Name = "ExpertRhythmBox";
			ExpertRhythmBox.Size = new Size(98, 21);
			ExpertRhythmBox.TabIndex = 25;
			HardRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			HardRhythmBox.FormattingEnabled = true;
			HardRhythmBox.Location = new Point(6, 73);
			HardRhythmBox.Name = "HardRhythmBox";
			HardRhythmBox.Size = new Size(98, 21);
			HardRhythmBox.TabIndex = 24;
			MediumRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			MediumRhythmBox.FormattingEnabled = true;
			MediumRhythmBox.Location = new Point(6, 46);
			MediumRhythmBox.Name = "MediumRhythmBox";
			MediumRhythmBox.Size = new Size(98, 21);
			MediumRhythmBox.TabIndex = 23;
			EasyRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			EasyRhythmBox.FormattingEnabled = true;
			EasyRhythmBox.Location = new Point(6, 19);
			EasyRhythmBox.Name = "EasyRhythmBox";
			EasyRhythmBox.Size = new Size(98, 21);
			EasyRhythmBox.TabIndex = 22;
			groupBox6.Controls.Add(ExpertCoopBox);
			groupBox6.Controls.Add(HardCoopBox);
			groupBox6.Controls.Add(MediumCoopBox);
			groupBox6.Controls.Add(EasyCoopBox);
			groupBox6.Location = new Point(329, 43);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new Size(110, 131);
			groupBox6.TabIndex = 56;
			groupBox6.TabStop = false;
			groupBox6.Text = "Coop Guitar";
			ExpertCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpertCoopBox.FormattingEnabled = true;
			ExpertCoopBox.Location = new Point(6, 100);
			ExpertCoopBox.Name = "ExpertCoopBox";
			ExpertCoopBox.Size = new Size(98, 21);
			ExpertCoopBox.TabIndex = 29;
			HardCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			HardCoopBox.FormattingEnabled = true;
			HardCoopBox.Location = new Point(6, 73);
			HardCoopBox.Name = "HardCoopBox";
			HardCoopBox.Size = new Size(98, 21);
			HardCoopBox.TabIndex = 28;
			MediumCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			MediumCoopBox.FormattingEnabled = true;
			MediumCoopBox.Location = new Point(6, 46);
			MediumCoopBox.Name = "MediumCoopBox";
			MediumCoopBox.Size = new Size(98, 21);
			MediumCoopBox.TabIndex = 27;
			EasyCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			EasyCoopBox.FormattingEnabled = true;
			EasyCoopBox.Location = new Point(6, 19);
			EasyCoopBox.Name = "EasyCoopBox";
			EasyCoopBox.Size = new Size(98, 21);
			EasyCoopBox.TabIndex = 26;
			groupBox3.Controls.Add(ExpertGuitarBox);
			groupBox3.Controls.Add(HardGuitarBox);
			groupBox3.Controls.Add(MediumGuitarBox);
			groupBox3.Controls.Add(EasyGuitarBox);
			groupBox3.Location = new Point(97, 43);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(110, 131);
			groupBox3.TabIndex = 54;
			groupBox3.TabStop = false;
			groupBox3.Text = "Single Guitar";
			ExpertGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpertGuitarBox.FormattingEnabled = true;
			ExpertGuitarBox.Location = new Point(6, 100);
			ExpertGuitarBox.Name = "ExpertGuitarBox";
			ExpertGuitarBox.Size = new Size(98, 21);
			ExpertGuitarBox.TabIndex = 21;
			HardGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			HardGuitarBox.FormattingEnabled = true;
			HardGuitarBox.Location = new Point(6, 73);
			HardGuitarBox.Name = "HardGuitarBox";
			HardGuitarBox.Size = new Size(98, 21);
			HardGuitarBox.TabIndex = 20;
			MediumGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			MediumGuitarBox.FormattingEnabled = true;
			MediumGuitarBox.Location = new Point(6, 46);
			MediumGuitarBox.Name = "MediumGuitarBox";
			MediumGuitarBox.Size = new Size(98, 21);
			MediumGuitarBox.TabIndex = 19;
			EasyGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			EasyGuitarBox.FormattingEnabled = true;
			EasyGuitarBox.Location = new Point(6, 19);
			EasyGuitarBox.Name = "EasyGuitarBox";
			EasyGuitarBox.Size = new Size(98, 21);
			EasyGuitarBox.TabIndex = 18;
			label9.AutoSize = true;
			label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.Location = new Point(15, 145);
			label9.Name = "label9";
			label9.Size = new Size(76, 19);
			label9.TabIndex = 53;
			label9.Text = "EXPERT:";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(30, 118);
			label8.Name = "label8";
			label8.Size = new Size(61, 19);
			label8.TabIndex = 52;
			label8.Text = "HARD:";
			label8.TextAlign = ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(6, 91);
			label7.Name = "label7";
			label7.Size = new Size(85, 19);
			label7.TabIndex = 51;
			label7.Text = "MEDIUM:";
			label7.TextAlign = ContentAlignment.MiddleCenter;
			label5.AutoSize = true;
			label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(37, 64);
			label5.Name = "label5";
			label5.Size = new Size(54, 19);
			label5.TabIndex = 50;
			label5.Text = "EASY:";
			label5.TextAlign = ContentAlignment.MiddleCenter;
			ChartFileBtn.Location = new Point(374, 16);
			ChartFileBtn.Name = "ChartFileBtn";
			ChartFileBtn.Size = new Size(24, 21);
			ChartFileBtn.TabIndex = 15;
			ChartFileBtn.Text = "...";
			ChartFileBtn.UseVisualStyleBackColor = true;
			ChartFileBtn.Click += ChartFileBtn_Click;
			label4.AutoSize = true;
			label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(10, 16);
			label4.Name = "label4";
			label4.Size = new Size(81, 19);
			label4.TabIndex = 48;
			label4.Text = "Chart File:";
			label4.TextAlign = ContentAlignment.MiddleCenter;
			ChartFileTxt.Location = new Point(97, 17);
			ChartFileTxt.Name = "ChartFileTxt";
			ChartFileTxt.ReadOnly = true;
			ChartFileTxt.Size = new Size(271, 20);
			ChartFileTxt.TabIndex = 49;
			label10.AutoSize = true;
			label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.Location = new Point(6, 28);
			label10.Name = "label10";
			label10.Size = new Size(91, 19);
			label10.TabIndex = 36;
			label10.Text = "Song Name:";
			label10.TextAlign = ContentAlignment.MiddleCenter;
			SongNameTxt.CharacterCasing = CharacterCasing.Lower;
			SongNameTxt.Location = new Point(103, 29);
			SongNameTxt.MaxLength = 30;
			SongNameTxt.Name = "SongNameTxt";
			SongNameTxt.Size = new Size(140, 20);
			SongNameTxt.TabIndex = 1;
			SongNameTxt.TextChanged += SongNameTxt_TextChanged;
			SongNameTxt.KeyPress += SongNameTxt_KeyPress;
			MainGroupBox.Controls.Add(label12);
			MainGroupBox.Controls.Add(CancelBtn);
			MainGroupBox.Controls.Add(ApplyBtn);
			MainGroupBox.Controls.Add(Chart_CheckBox);
			MainGroupBox.Controls.Add(Audio_CheckBox);
			MainGroupBox.Controls.Add(label10);
			MainGroupBox.Controls.Add(SongNameTxt);
			MainGroupBox.Location = new Point(12, 12);
			MainGroupBox.Name = "MainGroupBox";
			MainGroupBox.Size = new Size(566, 78);
			MainGroupBox.TabIndex = 0;
			MainGroupBox.TabStop = false;
			MainGroupBox.Text = "Main Settings";
			label12.AutoSize = true;
			label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.Location = new Point(249, 28);
			label12.Name = "label12";
			label12.Size = new Size(131, 19);
			label12.TabIndex = 43;
			label12.Text = "Data to Generate:";
			label12.TextAlign = ContentAlignment.MiddleCenter;
			CancelBtn.DialogResult = DialogResult.Cancel;
			CancelBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			CancelBtn.Location = new Point(495, 44);
			CancelBtn.Name = "CancelBtn";
			CancelBtn.Size = new Size(65, 27);
			CancelBtn.TabIndex = 35;
			CancelBtn.Text = "Cancel";
			CancelBtn.UseVisualStyleBackColor = true;
			ApplyBtn.DialogResult = DialogResult.OK;
			ApplyBtn.Enabled = false;
			ApplyBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			ApplyBtn.Location = new Point(495, 11);
			ApplyBtn.Name = "ApplyBtn";
			ApplyBtn.Size = new Size(65, 27);
			ApplyBtn.TabIndex = 34;
			ApplyBtn.Text = "Apply";
			ApplyBtn.UseVisualStyleBackColor = true;
			Chart_CheckBox.AutoSize = true;
			Chart_CheckBox.Checked = true;
			Chart_CheckBox.CheckState = CheckState.Checked;
			Chart_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Chart_CheckBox.Location = new Point(380, 44);
			Chart_CheckBox.Name = "Chart_CheckBox";
			Chart_CheckBox.Size = new Size(112, 23);
			Chart_CheckBox.TabIndex = 3;
			Chart_CheckBox.Text = "Game Track";
			Chart_CheckBox.UseVisualStyleBackColor = true;
			Chart_CheckBox.CheckedChanged += Chart_CheckBox_CheckedChanged;
			Audio_CheckBox.AutoSize = true;
			Audio_CheckBox.Checked = true;
			Audio_CheckBox.CheckState = CheckState.Checked;
			Audio_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Audio_CheckBox.Location = new Point(380, 15);
			Audio_CheckBox.Name = "Audio_CheckBox";
			Audio_CheckBox.Size = new Size(111, 23);
			Audio_CheckBox.TabIndex = 2;
			Audio_CheckBox.Text = "Audio Track";
			Audio_CheckBox.UseVisualStyleBackColor = true;
			Audio_CheckBox.CheckedChanged += Audio_CheckBox_CheckedChanged;
			VolumeSlider.BackColor = Color.Transparent;
			VolumeSlider.method_7(50f);
			VolumeSlider.method_8(70f);
			VolumeSlider.method_20(5u);
			VolumeSlider.Location = new Point(465, 137);
			VolumeSlider.method_4(20);
			VolumeSlider.Name = "VolumeSlider";
			VolumeSlider.Size = new Size(95, 10);
			VolumeSlider.method_19(1u);
			VolumeSlider.TabIndex = 51;
			VolumeSlider.Text = "TimeSlideBar";
			VolumeSlider.method_6(new SizeF(50f, 25f));
			VolumeSlider.method_5(20);
			VolumeSlider.method_1("{0}%");
			VolumeSlider.method_14(100);
			VolumeSlider.method_0(method_10);
			PreviewSlider.BackColor = Color.Transparent;
			PreviewSlider.method_10(Color.Crimson);
			PreviewSlider.method_9(Color.Red);
			PreviewSlider.method_7(50f);
			PreviewSlider.method_8(60f);
			PreviewSlider.method_21(Control1.Enum40.const_3);
			PreviewSlider.method_12(Color.Violet);
			PreviewSlider.method_11(Color.DarkViolet);
			PreviewSlider.Enabled = false;
			PreviewSlider.method_20(5u);
			PreviewSlider.Location = new Point(123, 116);
			PreviewSlider.method_4(20);
			PreviewSlider.Name = "PreviewSlider";
			PreviewSlider.Size = new Size(437, 15);
			PreviewSlider.method_19(1u);
			PreviewSlider.TabIndex = 14;
			PreviewSlider.Text = "PreviewSlider";
			PreviewSlider.method_6(new SizeF(20f, 50f));
			PreviewSlider.method_5(35);
			PreviewSlider.method_1("{0:mm:ss}");
			PreviewSlider.method_2(true);
			PreviewSlider.MouseDown += PreviewSlider_MouseDown;
			PreviewSlider.MouseUp += PreviewSlider_MouseUp;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(590, 520);
			Controls.Add(MainGroupBox);
			Controls.Add(ChartGroupBox);
			Controls.Add(AudioGroupBox);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SongData";
			Text = "Generate Song Data";
			AudioGroupBox.ResumeLayout(false);
			AudioGroupBox.PerformLayout();
			ChartGroupBox.ResumeLayout(false);
			ChartGroupBox.PerformLayout();
			groupBox7.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox8.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			MainGroupBox.ResumeLayout(false);
			MainGroupBox.PerformLayout();
			ResumeLayout(false);
			FormClosing += SongData_FormClosing;
		}

		public SongData(GH3Songlist gh3Songlist_1)
		{
			InitializeComponent();
			Control arg_26_0 = Audio_CheckBox;
			Chart_CheckBox.Enabled = false;
			arg_26_0.Enabled = false;
			bool_1 = true;
			bool_0 = true;
			EnableAudioButtons();
			gh3Songlist_0 = gh3Songlist_1;
			timer_0 = new Timer();
			timer_0.Interval = 30;
			timer_0.Tick += timer_0_Tick;
		}

        public SongData(GH3Songlist gh3Songlist_1, bool forceRB3)
        {
            this.forceRB3 = forceRB3;
            InitializeComponent();
            Control arg_26_0 = Audio_CheckBox;
            Chart_CheckBox.Enabled = false;
            arg_26_0.Enabled = false;
            bool_1 = true;
            bool_0 = true;
            EnableAudioButtons();
            gh3Songlist_0 = gh3Songlist_1;
            timer_0 = new Timer();
            timer_0.Interval = 30;
            timer_0.Tick += timer_0_Tick;
        }

        public SongData(string string_0, bool bool_6, bool bool_7)
		{
			InitializeComponent();
			SongNameTxt.Text = string_0;
			bool_2 = true;
			SongNameTxt.Enabled = false;
			timer_0 = new Timer();
			timer_0.Interval = 30;
			timer_0.Tick += timer_0_Tick;
			var arg_71_0 = Audio_CheckBox;
			bool_0 = bool_6;
			arg_71_0.Checked = bool_6;
			var arg_86_0 = Chart_CheckBox;
			bool_1 = bool_7;
			arg_86_0.Checked = bool_7;
			EnableAudioButtons();
		}

		public SongData(string string_0, QBCParser class362_1, zzQbSongObject class323_1, string[] string_1)
		{
			InitializeComponent();
			SongNameTxt.Text = string_0;
			bool_2 = true;
			qbcParser = class362_1;
			method_6();
			method_4("No Track");
			method_5("No Track");
			method_8(0);
			foreach (var current in qbcParser.noteList.Keys)
			{
				method_4(current);
			}
			if (qbcParser.class228_2.Count != 0)
			{
				method_5("faceoffp1");
			}
			if (qbcParser.class228_3.Count != 0)
			{
				method_5("faceoffp2");
			}
			if (qbcParser.bpmList.Count != 0)
			{
				method_5("bossbattlep1");
			}
			if (qbcParser.class228_5.Count != 0)
			{
				method_5("bossbattlep2");
			}
			method_7();
			if (class323_1 != null)
			{
				class323_0 = class323_1;
				return;
			}
			if (string_1.Length == 1)
			{
				SingleAudioBtn.Checked = true;
				GuitarAudioTxt.Text = string_1[0];
			}
			else
			{
				string text = null;
				string text2 = null;
				string text3 = null;
				string text4 = null;
				string text5 = null;
				string text6 = null;
				for (var i = 0; i < string_1.Length; i++)
				{
					var text7 = string_1[i];
					var text8 = KeyGenerator.GetFileName(text7).ToLower();
					if (string_1.Length > 4 && text8.Contains("coop"))
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
							CoopAudioBtn.Checked = true;
							GuitarCoopTxt.Text = text4;
							RhythmCoopTxt.Text = text5;
							BandCoopTxt.Text = text6;
						}
						else
						{
							MultiAudioBtn.Checked = true;
						}
						RhythmAudioTxt.Text = text2;
					}
					else
					{
						DualAudioBtn.Checked = true;
					}
					BandAudioTxt.Text = text3;
				}
				else
				{
					SingleAudioBtn.Checked = true;
				}
				GuitarAudioTxt.Text = text;
			}
			PreviewSlider.method_18(Convert.ToInt32(AudioManager.getAudioStream(GuitarAudioTxt.Text).vmethod_1().timeSpan_0.TotalSeconds));
			PreviewSlider.method_14(PreviewSlider.method_17() / 2);
			if (GuitarAudioTxt.Text == "" || (!SingleAudioBtn.Checked && (BandAudioTxt.Text == "" || !DualAudioBtn.Checked) && (RhythmAudioTxt.Text == "" || !MultiAudioBtn.Checked) && (GuitarCoopTxt.Text == "" || RhythmCoopTxt.Text == "" || BandCoopTxt.Text == "" || !CoopAudioBtn.Checked)))
			{
				throw new Exception("File names did not follow format!");
			}
		}

		public Class248 method_0(string string_0)
		{
			if (class323_0 != null)
			{
				class323_0.method_0(SongNameTxt.Text);
				return new Class248(class323_0, GuitarAudioTxt.Text.Replace(".dat.xen", ".fsb.xen"), string_0);
			}
			string[] string_;
			if (SingleAudioBtn.Checked)
			{
				string_ = new[]
				{
					GuitarAudioTxt.Text
				};
			}
			else if (DualAudioBtn.Checked)
			{
				string_ = new[]
				{
					BandAudioTxt.Text,
					GuitarAudioTxt.Text
				};
			}
			else if (MultiAudioBtn.Checked)
			{
				string_ = new[]
				{
					BandAudioTxt.Text,
					GuitarAudioTxt.Text,
					RhythmAudioTxt.Text
				};
			}
			else
			{
				string_ = new[]
				{
					BandAudioTxt.Text,
					GuitarAudioTxt.Text,
					RhythmAudioTxt.Text,
					BandCoopTxt.Text,
					GuitarCoopTxt.Text,
					RhythmCoopTxt.Text
				};
			}
			return new Class248(SongNameTxt.Text, string_, new TimeSpan(0, 0, PreviewSlider.method_13()), new TimeSpan(0, 0, PreviewSlider.method_13() + Math.Min(PreviewSlider.method_17() - PreviewSlider.method_13(), 20)), string_0);
		}

		public Class250 method_1(zzPakNode2 class318_0, string string_0)
		{
			var dictionary = new Dictionary<string, Track<int, NotesAtOffset>>();
			if (!EasyGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("easy", qbcParser.noteList[(string)EasyGuitarBox.SelectedItem]);
			}
			if (!EasyRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_easy", qbcParser.noteList[(string)EasyRhythmBox.SelectedItem]);
			}
			if (!EasyCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_easy", qbcParser.noteList[(string)EasyCoopBox.SelectedItem]);
			}
			if (!EasyCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_easy", qbcParser.noteList[(string)EasyCoop2Box.SelectedItem]);
			}
			if (!MediumGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("medium", qbcParser.noteList[(string)MediumGuitarBox.SelectedItem]);
			}
			if (!MediumRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_medium", qbcParser.noteList[(string)MediumRhythmBox.SelectedItem]);
			}
			if (!MediumCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_medium", qbcParser.noteList[(string)MediumCoopBox.SelectedItem]);
			}
			if (!MediumCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_medium", qbcParser.noteList[(string)MediumCoop2Box.SelectedItem]);
			}
			if (!HardGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("hard", qbcParser.noteList[(string)HardGuitarBox.SelectedItem]);
			}
			if (!HardRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_hard", qbcParser.noteList[(string)HardRhythmBox.SelectedItem]);
			}
			if (!HardCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_hard", qbcParser.noteList[(string)HardCoopBox.SelectedItem]);
			}
			if (!HardCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_hard", qbcParser.noteList[(string)HardCoop2Box.SelectedItem]);
			}
			if (!ExpertGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("expert", qbcParser.noteList[(string)ExpertGuitarBox.SelectedItem]);
			}
			if (!ExpertRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_expert", qbcParser.noteList[(string)ExpertRhythmBox.SelectedItem]);
			}
			if (!ExpertCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_expert", qbcParser.noteList[(string)ExpertCoopBox.SelectedItem]);
			}
			if (!ExpertCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_expert", qbcParser.noteList[(string)ExpertCoop2Box.SelectedItem]);
			}
			var class228_ = method_2(FaceOffP1Box);
			var class228_2 = method_2(FaceOffP2Box);
			var class228_3 = method_2(BossBattleP1Box);
			var class228_4 = method_2(BossBattleP2Box);
			qbcParser.noteList = dictionary;
			qbcParser.class228_2 = class228_;
			qbcParser.class228_3 = class228_2;
			qbcParser.bpmList = class228_3;
			qbcParser.class228_5 = class228_4;
			return new Class250(SongNameTxt.Text, qbcParser, class318_0, string_0);
		}

		private Track<int, int> method_2(ComboBox comboBox_0)
		{
			if (comboBox_0.SelectedItem.Equals("faceoffp1"))
			{
				return qbcParser.class228_2;
			}
			if (comboBox_0.SelectedItem.Equals("faceoffp2"))
			{
				return qbcParser.class228_3;
			}
			if (comboBox_0.SelectedItem.Equals("bossbattlep1"))
			{
				return qbcParser.bpmList;
			}
			if (comboBox_0.SelectedItem.Equals("bossbattlep2"))
			{
				return qbcParser.class228_5;
			}
			return new Track<int, int>();
		}

		private void EnableAudioButtons()
		{
			if (bool_0)
			{
				bool_3 = (GuitarAudioTxt.Text != "" && (SingleAudioBtn.Checked || (BandAudioTxt.Text != "" && (DualAudioBtn.Checked || (RhythmAudioTxt.Text != "" && MultiAudioBtn.Checked) || (GuitarCoopTxt.Text != "" && RhythmCoopTxt.Text != "" && BandCoopTxt.Text != "" && CoopAudioBtn.Checked)))));
			}
			ApplyBtn.Enabled = (((SongNameTxt.Enabled && bool_2) || !SongNameTxt.Enabled) && ((bool_0 && bool_3) || !bool_0) && ((bool_1 && bool_4) || !bool_1));
			if (!SongNameTxt.Enabled && !bool_0 && !bool_1)
			{
				ApplyBtn.Enabled = false;
			}
		}

		private void Audio_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			AudioGroupBox.Enabled = (bool_0 = Audio_CheckBox.Checked);
		}

		private void Chart_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ChartGroupBox.Enabled = (bool_1 = Chart_CheckBox.Checked);
		}

		private void method_4(string string_0)
		{
			EasyGuitarBox.Items.Add(string_0);
			EasyRhythmBox.Items.Add(string_0);
			EasyCoopBox.Items.Add(string_0);
			EasyCoop2Box.Items.Add(string_0);
			MediumGuitarBox.Items.Add(string_0);
			MediumRhythmBox.Items.Add(string_0);
			MediumCoopBox.Items.Add(string_0);
			MediumCoop2Box.Items.Add(string_0);
			HardGuitarBox.Items.Add(string_0);
			HardRhythmBox.Items.Add(string_0);
			HardCoopBox.Items.Add(string_0);
			HardCoop2Box.Items.Add(string_0);
			ExpertGuitarBox.Items.Add(string_0);
			ExpertRhythmBox.Items.Add(string_0);
			ExpertCoopBox.Items.Add(string_0);
			ExpertCoop2Box.Items.Add(string_0);
		}

		private void method_5(string string_0)
		{
			FaceOffP1Box.Items.Add(string_0);
			FaceOffP2Box.Items.Add(string_0);
			BossBattleP1Box.Items.Add(string_0);
			BossBattleP2Box.Items.Add(string_0);
		}

		private void method_6()
		{
			EasyGuitarBox.Items.Clear();
			EasyRhythmBox.Items.Clear();
			EasyCoopBox.Items.Clear();
			EasyCoop2Box.Items.Clear();
			MediumGuitarBox.Items.Clear();
			MediumRhythmBox.Items.Clear();
			MediumCoopBox.Items.Clear();
			MediumCoop2Box.Items.Clear();
			HardGuitarBox.Items.Clear();
			HardRhythmBox.Items.Clear();
			HardCoopBox.Items.Clear();
			HardCoop2Box.Items.Clear();
			ExpertGuitarBox.Items.Clear();
			ExpertRhythmBox.Items.Clear();
			ExpertCoopBox.Items.Clear();
			ExpertCoop2Box.Items.Clear();
			FaceOffP1Box.Items.Clear();
			FaceOffP2Box.Items.Clear();
			BossBattleP1Box.Items.Clear();
			BossBattleP2Box.Items.Clear();
		}

		private void AutoConfigBtn_Click(object sender, EventArgs e)
		{
			method_7();
		}

		private void method_7()
		{
			ExpertGuitarBox.SelectedItem = (HardGuitarBox.SelectedItem = (MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "easy")));
			ExpertGuitarBox.SelectedItem = (HardGuitarBox.SelectedItem = (MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "medium")));
			ExpertGuitarBox.SelectedItem = (HardGuitarBox.SelectedItem = (MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "hard")));
			ExpertGuitarBox.SelectedItem = (HardGuitarBox.SelectedItem = (MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "expert")));
			HardGuitarBox.SelectedItem = (MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "hard"));
			MediumGuitarBox.SelectedItem = (EasyGuitarBox.SelectedItem = "medium");
			EasyGuitarBox.SelectedItem = "easy";
			ExpertRhythmBox.SelectedItem = (HardRhythmBox.SelectedItem = (MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_easy")));
			ExpertRhythmBox.SelectedItem = (HardRhythmBox.SelectedItem = (MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_medium")));
			ExpertRhythmBox.SelectedItem = (HardRhythmBox.SelectedItem = (MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_hard")));
			ExpertRhythmBox.SelectedItem = (HardRhythmBox.SelectedItem = (MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_expert")));
			HardRhythmBox.SelectedItem = (MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_hard"));
			MediumRhythmBox.SelectedItem = (EasyRhythmBox.SelectedItem = "rhythm_medium");
			EasyRhythmBox.SelectedItem = "rhythm_easy";
			ExpertCoopBox.SelectedItem = (HardCoopBox.SelectedItem = (MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_easy")));
			ExpertCoopBox.SelectedItem = (HardCoopBox.SelectedItem = (MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_medium")));
			ExpertCoopBox.SelectedItem = (HardCoopBox.SelectedItem = (MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_hard")));
			ExpertCoopBox.SelectedItem = (HardCoopBox.SelectedItem = (MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_expert")));
			HardCoopBox.SelectedItem = (MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_hard"));
			MediumCoopBox.SelectedItem = (EasyCoopBox.SelectedItem = "guitarcoop_medium");
			EasyCoopBox.SelectedItem = "guitarcoop_easy";
			ExpertCoop2Box.SelectedItem = (HardCoop2Box.SelectedItem = (MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_easy")));
			ExpertCoop2Box.SelectedItem = (HardCoop2Box.SelectedItem = (MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_medium")));
			ExpertCoop2Box.SelectedItem = (HardCoop2Box.SelectedItem = (MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_hard")));
			ExpertCoop2Box.SelectedItem = (HardCoop2Box.SelectedItem = (MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_expert")));
			HardCoop2Box.SelectedItem = (MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_hard"));
			MediumCoop2Box.SelectedItem = (EasyCoop2Box.SelectedItem = "rhythmcoop_medium");
			EasyCoop2Box.SelectedItem = "rhythmcoop_easy";
			FaceOffP1Box.SelectedItem = "faceoffp1";
			FaceOffP2Box.SelectedItem = "faceoffp2";
			BossBattleP1Box.SelectedItem = "bossbattlep1";
			BossBattleP2Box.SelectedItem = "bossbattlep2";
		}

		private void method_8(int int_0)
		{
			ListControl arg_12F_0 = EasyGuitarBox;
			ListControl arg_128_0 = EasyRhythmBox;
			ListControl arg_11E_0 = EasyCoopBox;
			ListControl arg_114_0 = EasyCoop2Box;
			ListControl arg_10A_0 = MediumGuitarBox;
			ListControl arg_100_0 = MediumRhythmBox;
			ListControl arg_F6_0 = MediumCoopBox;
			ListControl arg_EC_0 = MediumCoop2Box;
			ListControl arg_E2_0 = HardGuitarBox;
			ListControl arg_D8_0 = HardRhythmBox;
			ListControl arg_CE_0 = HardCoopBox;
			ListControl arg_C4_0 = HardCoop2Box;
			ListControl arg_BA_0 = ExpertGuitarBox;
			ListControl arg_B0_0 = ExpertRhythmBox;
			ListControl arg_A6_0 = ExpertCoopBox;
			ListControl arg_9C_0 = ExpertCoop2Box;
			ListControl arg_93_0 = FaceOffP1Box;
			ListControl arg_8B_0 = FaceOffP2Box;
			ListControl arg_83_0 = BossBattleP1Box;
			BossBattleP2Box.SelectedIndex = int_0;
			arg_83_0.SelectedIndex = int_0;
			arg_8B_0.SelectedIndex = int_0;
			arg_93_0.SelectedIndex = int_0;
			arg_9C_0.SelectedIndex = int_0;
			arg_A6_0.SelectedIndex = int_0;
			arg_B0_0.SelectedIndex = int_0;
			arg_BA_0.SelectedIndex = int_0;
			arg_C4_0.SelectedIndex = int_0;
			arg_CE_0.SelectedIndex = int_0;
			arg_D8_0.SelectedIndex = int_0;
			arg_E2_0.SelectedIndex = int_0;
			arg_EC_0.SelectedIndex = int_0;
			arg_F6_0.SelectedIndex = int_0;
			arg_100_0.SelectedIndex = int_0;
			arg_10A_0.SelectedIndex = int_0;
			arg_114_0.SelectedIndex = int_0;
			arg_11E_0.SelectedIndex = int_0;
			arg_128_0.SelectedIndex = int_0;
			arg_12F_0.SelectedIndex = int_0;
		}

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			method_8(0);
		}

		private void ChartFileBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the game track file.", "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart", true)).Equals(""))
			{
				bool_4 = false;
				try
				{
                    //Configures paks
                    if (fileName.EndsWith("_song.pak.xen"))
					{
						var text2 = KeyGenerator.GetFileName(fileName).Replace("_song.pak.xen", "");
						using (var @class = new zzPakNode2(fileName, false))
						{
							if (!@class.method_6("songs\\" + text2 + ".mid.qb"))
							{
								throw new Exception("MID.QB song file not found.");
							}
							qbcParser = new QBCParser(text2, @class.zzGetNode1("songs\\" + text2 + ".mid.qb"));
							goto IL_F5;
						}
					}
                    //Configures qbc
					if (fileName.EndsWith(".qbc"))
					{
						qbcParser = new QBCParser(fileName);
					}
                    //Configures midi
                    else if (fileName.EndsWith(".mid"))
					{
                        qbcParser = Midi2Chart.LoadMidiSong(fileName, forceRB3);
					}
                    //Configures charts
                    else
                    {
                        //Crashes in this
                        qbcParser = new ChartParser(fileName).ConvertToQBC();
					}
                    IL_F5:
					method_6();
					method_4("No Track");
					method_5("No Track");
					method_8(0);
					Control arg_12B_0 = AutoConfigBtn;
					ResetBtn.Enabled = true;
					arg_12B_0.Enabled = true;
					foreach (var current in qbcParser.noteList.Keys)
					{
						method_4(current);
					}
					if (qbcParser.class228_2.Count != 0)
					{
						method_5("faceoffp1");
					}
					if (qbcParser.class228_3.Count != 0)
					{
						method_5("faceoffp2");
					}
					if (qbcParser.bpmList.Count != 0)
					{
						method_5("bossbattlep1");
					}
					if (qbcParser.class228_5.Count != 0)
					{
						method_5("bossbattlep2");
					}
					ChartFileTxt.Text = fileName;
					ChartFileTxt.SelectionStart = ChartFileTxt.TextLength;
					bool_4 = true;
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
			GuitarAudioTxt.Text = (RhythmAudioTxt.Text = (BandAudioTxt.Text = (GuitarCoopTxt.Text = (RhythmCoopTxt.Text = (BandCoopTxt.Text = "")))));
			PreviewSlider.method_18(1);
			PreviewSlider.method_14(0);
			PreviewSlider.Enabled = false;
			if (Audio != null)
			{
				Audio.Dispose();
				Audio = null;
			}
		}

		private void SingleAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_73_0 = RhythmAudioBtn;
			Control arg_6D_0 = RhythmAudioTxt;
			Control arg_67_0 = BandAudioBtn;
			Control arg_61_0 = BandAudioTxt;
			Control arg_5B_0 = GuitarCoopBtn;
			Control arg_55_0 = GuitarCoopTxt;
			Control arg_4F_0 = RhythmCoopBtn;
			Control arg_49_0 = RhythmCoopTxt;
			Control arg_43_0 = BandCoopBtn;
			BandCoopTxt.Enabled = false;
			arg_43_0.Enabled = false;
			arg_49_0.Enabled = false;
			arg_4F_0.Enabled = false;
			arg_55_0.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			method_9();
		}

		private void DualAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_13_0 = BandAudioBtn;
			BandAudioTxt.Enabled = true;
			arg_13_0.Enabled = true;
			Control arg_73_0 = RhythmAudioBtn;
			Control arg_6D_0 = RhythmAudioTxt;
			Control arg_67_0 = GuitarCoopBtn;
			Control arg_61_0 = GuitarCoopTxt;
			Control arg_5B_0 = RhythmCoopBtn;
			Control arg_55_0 = RhythmCoopTxt;
			Control arg_4F_0 = BandCoopBtn;
			BandCoopTxt.Enabled = false;
			arg_4F_0.Enabled = false;
			arg_55_0.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			method_9();
		}

		private void MultiAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_2B_0 = RhythmAudioBtn;
			Control arg_25_0 = RhythmAudioTxt;
			Control arg_1F_0 = BandAudioBtn;
			BandAudioTxt.Enabled = true;
			arg_1F_0.Enabled = true;
			arg_25_0.Enabled = true;
			arg_2B_0.Enabled = true;
			Control arg_73_0 = GuitarCoopBtn;
			Control arg_6D_0 = GuitarCoopTxt;
			Control arg_67_0 = RhythmCoopBtn;
			Control arg_61_0 = RhythmCoopTxt;
			Control arg_5B_0 = BandCoopBtn;
			BandCoopTxt.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			method_9();
		}

		private void CoopAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_73_0 = RhythmAudioBtn;
			Control arg_6D_0 = RhythmAudioTxt;
			Control arg_67_0 = BandAudioBtn;
			Control arg_61_0 = BandAudioTxt;
			Control arg_5B_0 = GuitarCoopBtn;
			Control arg_55_0 = GuitarCoopTxt;
			Control arg_4F_0 = RhythmCoopBtn;
			Control arg_49_0 = RhythmCoopTxt;
			Control arg_43_0 = BandCoopBtn;
			BandCoopTxt.Enabled = true;
			arg_43_0.Enabled = true;
			arg_49_0.Enabled = true;
			arg_4F_0.Enabled = true;
			arg_55_0.Enabled = true;
			arg_5B_0.Enabled = true;
			arg_61_0.Enabled = true;
			arg_67_0.Enabled = true;
			arg_6D_0.Enabled = true;
			arg_73_0.Enabled = true;
			method_9();
		}

		private void GuitarAudioBtn_Click(object sender, EventArgs e)
		{
			var fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Audio track file.", "Any Supported Audio Formats|*.dat.xen;*.mp3;*.wav;*.ogg;*.flac|GH3 Audio Header file|*.dat.xen|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true).ToLower();
            if (SingleAudioBtn.Checked)
			{
                if (!(fileName.Equals("")))
				{
                    GuitarAudioTxt.Text = fileName;
					GuitarAudioTxt.SelectionStart = GuitarAudioTxt.TextLength;
					if (fileName.EndsWith(".dat.xen"))
					{
						if (!File.Exists(fileName.Replace(".dat.xen", ".fsb.xen")))
						{
							MessageBox.Show("Data file (FSB.XEN) is missing.", "Error!");
							class323_0 = null;
							GuitarAudioTxt.Text = "";
						}
						else
						{
							class323_0 = new zzQbSongObject(fileName);
							if ((int)new FileInfo(fileName.Replace(".dat.xen", ".fsb.xen")).Length != class323_0.int_0)
							{
								MessageBox.Show("FSB file size does not match!", "Error!");
								class323_0 = null;
								GuitarAudioTxt.Text = "";
							}
							else
							{
								PreviewSlider.Enabled = false;
							}
						}
					}
					else
					{
						PreviewSlider.Enabled = true;
						LoadAudio();
					}
					EnableAudioButtons();
				}
			}
			else if (!(fileName.Equals("")))
			{
				GuitarAudioTxt.Text = fileName;
				GuitarAudioTxt.SelectionStart = GuitarAudioTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
            }
		}

		private void RhythmAudioBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Rhythm Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                RhythmAudioTxt.Text = fileName;
				RhythmAudioTxt.SelectionStart = RhythmAudioTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
			}
		}

		private void BandAudioBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Band Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                BandAudioTxt.Text = fileName;
				BandAudioTxt.SelectionStart = BandAudioTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
			}
		}

		private void GuitarCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                GuitarCoopTxt.Text = fileName;
				GuitarCoopTxt.SelectionStart = GuitarCoopTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
			}
		}

		private void RhythmCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Rhythm Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                RhythmCoopTxt.Text = fileName;
				RhythmCoopTxt.SelectionStart = RhythmCoopTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
			}
		}

		private void BandCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Band Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                BandCoopTxt.Text = fileName;
				BandCoopTxt.SelectionStart = BandCoopTxt.TextLength;
				PreviewSlider.Enabled = true;
				LoadAudio();
				EnableAudioButtons();
			}
		}

		private void SongNameTxt_TextChanged(object sender, EventArgs e)
		{
			if (gh3Songlist_0 != null)
			{
				bool_2 = (SongNameTxt.Text != "" && !QbSongClass1.smethod_4(SongNameTxt.Text) && !gh3Songlist_0.method_3(SongNameTxt.Text));
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
			if (Audio != null)
			{
				Audio.Dispose();
			}
		}

		~SongData()
		{
			if (Audio != null)
			{
				Audio.Dispose();
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (Audio != null && bool_5)
			{
				PreviewSlider.method_14((int)Audio.AudioLength().TotalSeconds);
			}
		}

		private void Play_Btn_Click(object sender, EventArgs e)
		{
			if (Audio == null)
			{
				return;
			}
			Audio.DifferentStartPlaying();
			timer_0.Start();
		}

		private void Pause_Btn_Click(object sender, EventArgs e)
		{
			if (Audio == null)
			{
				return;
			}
			Audio.StartPlaying();
			timer_0.Stop();
		}

		private void Stop_Btn_Click(object sender, EventArgs e)
		{
			if (Audio == null)
			{
				return;
			}
			Audio.StopPlaying();
			timer_0.Stop();
			PreviewSlider.method_14(PreviewSlider.method_15());
			Audio.SetStartingTimeBasedOnSomeValue(0);
		}

		private void PreviewSlider_MouseUp(object sender, MouseEventArgs e)
		{
			bool_5 = true;
			Audio.SetStartingTime(TimeSpan.FromSeconds(PreviewSlider.method_13()));
		}

		private void PreviewSlider_MouseDown(object sender, MouseEventArgs e)
		{
			bool_5 = false;
		}

		private void method_10(object sender, EventArgs e)
		{
			if (Audio != null)
			{
				Audio.SetVolume(VolumeSlider.method_13() / 100f);
			}
		}

		private void LoadAudio()
		{
			try
			{
				var list = new List<GenericAudioStream>();
				if (!BandCoopTxt.Text.Equals(""))
				{
					list.Add(AudioManager.getAudioStream(BandCoopTxt.Text));
				}
				else if (!BandAudioTxt.Text.Equals(""))
				{
					list.Add(AudioManager.getAudioStream(BandAudioTxt.Text));
				}
				if (!GuitarCoopTxt.Text.Equals("") && !RhythmCoopTxt.Text.Equals(""))
				{
					list.Insert(0, AudioManager.getAudioStream(RhythmCoopTxt.Text));
					list.Insert(0, AudioManager.getAudioStream(GuitarCoopTxt.Text));
				}
				else
				{
					if (!RhythmAudioTxt.Text.Equals(""))
					{
						list.Insert(0, AudioManager.getAudioStream(RhythmAudioTxt.Text));
					}
					if (!GuitarAudioTxt.Text.Equals(""))
					{
						list.Insert(0, AudioManager.getAudioStream(GuitarAudioTxt.Text));
					}
				}
				if (list.Count != 0)
				{
					var stream = (list.Count == 1) ? list[0] : new Stream2(list.ToArray());
					if (Audio != null)
					{
						Audio.Dispose();
					}
					Audio = AudioManager.LoadPlayableAudio(Enum25.const_5, stream);
					PreviewSlider.method_14((int)Audio.AudioLength().TotalSeconds);
					PreviewSlider.method_18((int)stream.vmethod_1().timeSpan_0.TotalSeconds);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Cannot load audio file/s.\n" + ex.Message);
			}
		}
	}
}
