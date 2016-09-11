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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

		private Class323 class323_0;

		private QBCParser qbcParser;

		private readonly GH3Songlist gh3Songlist_0;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private Interface6 interface6_0;

		private readonly Timer timer_0;

		private bool bool_5 = true;

        private bool forceRB3 = false;

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
			this.GuitarAudioTxt = new TextBox();
			this.label6 = new Label();
			this.AudioGroupBox = new GroupBox();
			this.Stop_Btn = new Button();
			this.Pause_Btn = new Button();
			this.Play_Btn = new Button();
			this.DualAudioBtn = new RadioButton();
			this.CoopAudioBtn = new RadioButton();
			this.BandCoopBtn = new Button();
			this.RhythmCoopBtn = new Button();
			this.GuitarCoopBtn = new Button();
			this.BandCoopTxt = new TextBox();
			this.RhythmCoopTxt = new TextBox();
			this.GuitarCoopTxt = new TextBox();
			this.label11 = new Label();
			this.BandAudioBtn = new Button();
			this.RhythmAudioBtn = new Button();
			this.GuitarAudioBtn = new Button();
			this.label1 = new Label();
			this.MultiAudioBtn = new RadioButton();
			this.SingleAudioBtn = new RadioButton();
			this.label3 = new Label();
			this.BandAudioTxt = new TextBox();
			this.label2 = new Label();
			this.RhythmAudioTxt = new TextBox();
			this.ChartGroupBox = new GroupBox();
			this.groupBox7 = new GroupBox();
			this.BossBattleP2Box = new ComboBox();
			this.groupBox2 = new GroupBox();
			this.FaceOffP2Box = new ComboBox();
			this.groupBox8 = new GroupBox();
			this.BossBattleP1Box = new ComboBox();
			this.groupBox1 = new GroupBox();
			this.FaceOffP1Box = new ComboBox();
			this.label13 = new Label();
			this.ResetBtn = new Button();
			this.AutoConfigBtn = new Button();
			this.groupBox5 = new GroupBox();
			this.ExpertCoop2Box = new ComboBox();
			this.HardCoop2Box = new ComboBox();
			this.MediumCoop2Box = new ComboBox();
			this.EasyCoop2Box = new ComboBox();
			this.groupBox4 = new GroupBox();
			this.ExpertRhythmBox = new ComboBox();
			this.HardRhythmBox = new ComboBox();
			this.MediumRhythmBox = new ComboBox();
			this.EasyRhythmBox = new ComboBox();
			this.groupBox6 = new GroupBox();
			this.ExpertCoopBox = new ComboBox();
			this.HardCoopBox = new ComboBox();
			this.MediumCoopBox = new ComboBox();
			this.EasyCoopBox = new ComboBox();
			this.groupBox3 = new GroupBox();
			this.ExpertGuitarBox = new ComboBox();
			this.HardGuitarBox = new ComboBox();
			this.MediumGuitarBox = new ComboBox();
			this.EasyGuitarBox = new ComboBox();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label5 = new Label();
			this.ChartFileBtn = new Button();
			this.label4 = new Label();
			this.ChartFileTxt = new TextBox();
			this.label10 = new Label();
			this.SongNameTxt = new TextBox();
			this.MainGroupBox = new GroupBox();
			this.label12 = new Label();
			this.CancelBtn = new Button();
			this.ApplyBtn = new Button();
			this.Chart_CheckBox = new CheckBox();
			this.Audio_CheckBox = new CheckBox();
			this.VolumeSlider = new Control1();
			this.PreviewSlider = new Control1();
			this.AudioGroupBox.SuspendLayout();
			this.ChartGroupBox.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.MainGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.GuitarAudioTxt.Location = new Point(113, 39);
			this.GuitarAudioTxt.Name = "GuitarAudioTxt";
			this.GuitarAudioTxt.ReadOnly = true;
			this.GuitarAudioTxt.Size = new Size(180, 20);
			this.GuitarAudioTxt.TabIndex = 39;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(6, 38);
			this.label6.Name = "label6";
			this.label6.Size = new Size(101, 19);
			this.label6.TabIndex = 39;
			this.label6.Text = "Guitar Track:";
			this.label6.TextAlign = ContentAlignment.MiddleCenter;
			this.AudioGroupBox.Controls.Add(this.VolumeSlider);
			this.AudioGroupBox.Controls.Add(this.Stop_Btn);
			this.AudioGroupBox.Controls.Add(this.Pause_Btn);
			this.AudioGroupBox.Controls.Add(this.Play_Btn);
			this.AudioGroupBox.Controls.Add(this.DualAudioBtn);
			this.AudioGroupBox.Controls.Add(this.CoopAudioBtn);
			this.AudioGroupBox.Controls.Add(this.BandCoopBtn);
			this.AudioGroupBox.Controls.Add(this.RhythmCoopBtn);
			this.AudioGroupBox.Controls.Add(this.GuitarCoopBtn);
			this.AudioGroupBox.Controls.Add(this.BandCoopTxt);
			this.AudioGroupBox.Controls.Add(this.RhythmCoopTxt);
			this.AudioGroupBox.Controls.Add(this.GuitarCoopTxt);
			this.AudioGroupBox.Controls.Add(this.PreviewSlider);
			this.AudioGroupBox.Controls.Add(this.label11);
			this.AudioGroupBox.Controls.Add(this.BandAudioBtn);
			this.AudioGroupBox.Controls.Add(this.RhythmAudioBtn);
			this.AudioGroupBox.Controls.Add(this.GuitarAudioBtn);
			this.AudioGroupBox.Controls.Add(this.label1);
			this.AudioGroupBox.Controls.Add(this.MultiAudioBtn);
			this.AudioGroupBox.Controls.Add(this.SingleAudioBtn);
			this.AudioGroupBox.Controls.Add(this.label3);
			this.AudioGroupBox.Controls.Add(this.BandAudioTxt);
			this.AudioGroupBox.Controls.Add(this.label2);
			this.AudioGroupBox.Controls.Add(this.RhythmAudioTxt);
			this.AudioGroupBox.Controls.Add(this.label6);
			this.AudioGroupBox.Controls.Add(this.GuitarAudioTxt);
			this.AudioGroupBox.Location = new Point(12, 96);
			this.AudioGroupBox.Name = "AudioGroupBox";
			this.AudioGroupBox.Size = new Size(566, 168);
			this.AudioGroupBox.TabIndex = 36;
			this.AudioGroupBox.TabStop = false;
			this.AudioGroupBox.Text = "Audio Track";
			this.Stop_Btn.FlatStyle = FlatStyle.Popup;
			this.Stop_Btn.Location = new Point(205, 137);
			this.Stop_Btn.Name = "Stop_Btn";
			this.Stop_Btn.Size = new Size(37, 20);
			this.Stop_Btn.TabIndex = 50;
			this.Stop_Btn.Text = "Stop";
			this.Stop_Btn.UseVisualStyleBackColor = true;
			this.Stop_Btn.Click += new EventHandler(this.Stop_Btn_Click);
			this.Pause_Btn.FlatStyle = FlatStyle.Popup;
			this.Pause_Btn.Location = new Point(160, 137);
			this.Pause_Btn.Name = "Pause_Btn";
			this.Pause_Btn.Size = new Size(45, 20);
			this.Pause_Btn.TabIndex = 49;
			this.Pause_Btn.Text = "Pause";
			this.Pause_Btn.UseVisualStyleBackColor = true;
			this.Pause_Btn.Click += new EventHandler(this.Pause_Btn_Click);
			this.Play_Btn.FlatStyle = FlatStyle.Popup;
			this.Play_Btn.Location = new Point(123, 137);
			this.Play_Btn.Name = "Play_Btn";
			this.Play_Btn.Size = new Size(37, 20);
			this.Play_Btn.TabIndex = 48;
			this.Play_Btn.Text = "Play";
			this.Play_Btn.UseVisualStyleBackColor = true;
			this.Play_Btn.Click += new EventHandler(this.Play_Btn_Click);
			this.DualAudioBtn.AutoSize = true;
			this.DualAudioBtn.Location = new Point(194, 18);
			this.DualAudioBtn.Name = "DualAudioBtn";
			this.DualAudioBtn.Size = new Size(84, 17);
			this.DualAudioBtn.TabIndex = 5;
			this.DualAudioBtn.Text = "Guitar Track";
			this.DualAudioBtn.UseVisualStyleBackColor = true;
			this.DualAudioBtn.CheckedChanged += new EventHandler(this.DualAudioBtn_CheckedChanged);
			this.CoopAudioBtn.AutoSize = true;
			this.CoopAudioBtn.Location = new Point(382, 18);
			this.CoopAudioBtn.Name = "CoopAudioBtn";
			this.CoopAudioBtn.Size = new Size(86, 17);
			this.CoopAudioBtn.TabIndex = 7;
			this.CoopAudioBtn.Text = "Coop Tracks";
			this.CoopAudioBtn.UseVisualStyleBackColor = true;
			this.CoopAudioBtn.CheckedChanged += new EventHandler(this.CoopAudioBtn_CheckedChanged);
			this.BandCoopBtn.Enabled = false;
			this.BandCoopBtn.Location = new Point(539, 91);
			this.BandCoopBtn.Name = "BandCoopBtn";
			this.BandCoopBtn.Size = new Size(24, 21);
			this.BandCoopBtn.TabIndex = 13;
			this.BandCoopBtn.Text = "...";
			this.BandCoopBtn.UseVisualStyleBackColor = true;
			this.BandCoopBtn.Click += new EventHandler(this.BandCoopBtn_Click);
			this.RhythmCoopBtn.Enabled = false;
			this.RhythmCoopBtn.Location = new Point(539, 65);
			this.RhythmCoopBtn.Name = "RhythmCoopBtn";
			this.RhythmCoopBtn.Size = new Size(24, 21);
			this.RhythmCoopBtn.TabIndex = 12;
			this.RhythmCoopBtn.Text = "...";
			this.RhythmCoopBtn.UseVisualStyleBackColor = true;
			this.RhythmCoopBtn.Click += new EventHandler(this.RhythmCoopBtn_Click);
			this.GuitarCoopBtn.Enabled = false;
			this.GuitarCoopBtn.Location = new Point(539, 38);
			this.GuitarCoopBtn.Name = "GuitarCoopBtn";
			this.GuitarCoopBtn.Size = new Size(24, 21);
			this.GuitarCoopBtn.TabIndex = 11;
			this.GuitarCoopBtn.Text = "...";
			this.GuitarCoopBtn.UseVisualStyleBackColor = true;
			this.GuitarCoopBtn.Click += new EventHandler(this.GuitarCoopBtn_Click);
			this.BandCoopTxt.Enabled = false;
			this.BandCoopTxt.Location = new Point(329, 92);
			this.BandCoopTxt.Name = "BandCoopTxt";
			this.BandCoopTxt.ReadOnly = true;
			this.BandCoopTxt.Size = new Size(204, 20);
			this.BandCoopTxt.TabIndex = 46;
			this.RhythmCoopTxt.Enabled = false;
			this.RhythmCoopTxt.Location = new Point(329, 66);
			this.RhythmCoopTxt.Name = "RhythmCoopTxt";
			this.RhythmCoopTxt.ReadOnly = true;
			this.RhythmCoopTxt.Size = new Size(204, 20);
			this.RhythmCoopTxt.TabIndex = 45;
			this.GuitarCoopTxt.Enabled = false;
			this.GuitarCoopTxt.Location = new Point(329, 39);
			this.GuitarCoopTxt.Name = "GuitarCoopTxt";
			this.GuitarCoopTxt.ReadOnly = true;
			this.GuitarCoopTxt.Size = new Size(204, 20);
			this.GuitarCoopTxt.TabIndex = 44;
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label11.Location = new Point(6, 129);
			this.label11.Name = "label11";
			this.label11.Size = new Size(111, 19);
			this.label11.TabIndex = 47;
			this.label11.Text = "Preview Track:";
			this.label11.TextAlign = ContentAlignment.MiddleCenter;
			this.BandAudioBtn.Enabled = false;
			this.BandAudioBtn.Location = new Point(299, 91);
			this.BandAudioBtn.Name = "BandAudioBtn";
			this.BandAudioBtn.Size = new Size(24, 21);
			this.BandAudioBtn.TabIndex = 10;
			this.BandAudioBtn.Text = "...";
			this.BandAudioBtn.UseVisualStyleBackColor = true;
			this.BandAudioBtn.Click += new EventHandler(this.BandAudioBtn_Click);
			this.RhythmAudioBtn.Enabled = false;
			this.RhythmAudioBtn.Location = new Point(299, 65);
			this.RhythmAudioBtn.Name = "RhythmAudioBtn";
			this.RhythmAudioBtn.Size = new Size(24, 21);
			this.RhythmAudioBtn.TabIndex = 9;
			this.RhythmAudioBtn.Text = "...";
			this.RhythmAudioBtn.UseVisualStyleBackColor = true;
			this.RhythmAudioBtn.Click += new EventHandler(this.RhythmAudioBtn_Click);
			this.GuitarAudioBtn.Location = new Point(299, 38);
			this.GuitarAudioBtn.Name = "GuitarAudioBtn";
			this.GuitarAudioBtn.Size = new Size(24, 21);
			this.GuitarAudioBtn.TabIndex = 8;
			this.GuitarAudioBtn.Text = "...";
			this.GuitarAudioBtn.UseVisualStyleBackColor = true;
			this.GuitarAudioBtn.Click += new EventHandler(this.GuitarAudioBtn_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(91, 19);
			this.label1.TabIndex = 38;
			this.label1.Text = "Audio Type:";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.MultiAudioBtn.AutoSize = true;
			this.MultiAudioBtn.Location = new Point(284, 18);
			this.MultiAudioBtn.Name = "MultiAudioBtn";
			this.MultiAudioBtn.Size = new Size(92, 17);
			this.MultiAudioBtn.TabIndex = 6;
			this.MultiAudioBtn.Text = "Rhythm Track";
			this.MultiAudioBtn.UseVisualStyleBackColor = true;
			this.MultiAudioBtn.CheckedChanged += new EventHandler(this.MultiAudioBtn_CheckedChanged);
			this.SingleAudioBtn.AutoSize = true;
			this.SingleAudioBtn.Checked = true;
			this.SingleAudioBtn.Location = new Point(103, 18);
			this.SingleAudioBtn.Name = "SingleAudioBtn";
			this.SingleAudioBtn.Size = new Size(85, 17);
			this.SingleAudioBtn.TabIndex = 4;
			this.SingleAudioBtn.TabStop = true;
			this.SingleAudioBtn.Text = "Single Track";
			this.SingleAudioBtn.UseVisualStyleBackColor = true;
			this.SingleAudioBtn.CheckedChanged += new EventHandler(this.SingleAudioBtn_CheckedChanged);
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(6, 91);
			this.label3.Name = "label3";
			this.label3.Size = new Size(93, 19);
			this.label3.TabIndex = 42;
			this.label3.Text = "Band Track:";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.BandAudioTxt.Enabled = false;
			this.BandAudioTxt.Location = new Point(105, 92);
			this.BandAudioTxt.Name = "BandAudioTxt";
			this.BandAudioTxt.ReadOnly = true;
			this.BandAudioTxt.Size = new Size(188, 20);
			this.BandAudioTxt.TabIndex = 43;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(6, 65);
			this.label2.Name = "label2";
			this.label2.Size = new Size(111, 19);
			this.label2.TabIndex = 40;
			this.label2.Text = "Rhythm Track:";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			this.RhythmAudioTxt.Enabled = false;
			this.RhythmAudioTxt.Location = new Point(123, 66);
			this.RhythmAudioTxt.Name = "RhythmAudioTxt";
			this.RhythmAudioTxt.ReadOnly = true;
			this.RhythmAudioTxt.Size = new Size(170, 20);
			this.RhythmAudioTxt.TabIndex = 41;
			this.ChartGroupBox.Controls.Add(this.groupBox7);
			this.ChartGroupBox.Controls.Add(this.groupBox2);
			this.ChartGroupBox.Controls.Add(this.groupBox8);
			this.ChartGroupBox.Controls.Add(this.groupBox1);
			this.ChartGroupBox.Controls.Add(this.label13);
			this.ChartGroupBox.Controls.Add(this.ResetBtn);
			this.ChartGroupBox.Controls.Add(this.AutoConfigBtn);
			this.ChartGroupBox.Controls.Add(this.groupBox5);
			this.ChartGroupBox.Controls.Add(this.groupBox4);
			this.ChartGroupBox.Controls.Add(this.groupBox6);
			this.ChartGroupBox.Controls.Add(this.groupBox3);
			this.ChartGroupBox.Controls.Add(this.label9);
			this.ChartGroupBox.Controls.Add(this.label8);
			this.ChartGroupBox.Controls.Add(this.label7);
			this.ChartGroupBox.Controls.Add(this.label5);
			this.ChartGroupBox.Controls.Add(this.ChartFileBtn);
			this.ChartGroupBox.Controls.Add(this.label4);
			this.ChartGroupBox.Controls.Add(this.ChartFileTxt);
			this.ChartGroupBox.Location = new Point(12, 270);
			this.ChartGroupBox.Name = "ChartGroupBox";
			this.ChartGroupBox.Size = new Size(566, 239);
			this.ChartGroupBox.TabIndex = 37;
			this.ChartGroupBox.TabStop = false;
			this.ChartGroupBox.Text = "Game Track";
			this.groupBox7.Controls.Add(this.BossBattleP2Box);
			this.groupBox7.Location = new Point(445, 180);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(110, 48);
			this.groupBox7.TabIndex = 58;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Boss Battle P2";
			this.BossBattleP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BossBattleP2Box.FormattingEnabled = true;
			this.BossBattleP2Box.Location = new Point(6, 19);
			this.BossBattleP2Box.Name = "BossBattleP2Box";
			this.BossBattleP2Box.Size = new Size(98, 21);
			this.BossBattleP2Box.TabIndex = 18;
			this.groupBox2.Controls.Add(this.FaceOffP2Box);
			this.groupBox2.Location = new Point(213, 180);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(110, 48);
			this.groupBox2.TabIndex = 56;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Face Off P2";
			this.FaceOffP2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FaceOffP2Box.FormattingEnabled = true;
			this.FaceOffP2Box.Location = new Point(6, 19);
			this.FaceOffP2Box.Name = "FaceOffP2Box";
			this.FaceOffP2Box.Size = new Size(98, 21);
			this.FaceOffP2Box.TabIndex = 18;
			this.groupBox8.Controls.Add(this.BossBattleP1Box);
			this.groupBox8.Location = new Point(329, 180);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new Size(110, 48);
			this.groupBox8.TabIndex = 57;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Boss Battle P1";
			this.BossBattleP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BossBattleP1Box.FormattingEnabled = true;
			this.BossBattleP1Box.Location = new Point(6, 19);
			this.BossBattleP1Box.Name = "BossBattleP1Box";
			this.BossBattleP1Box.Size = new Size(98, 21);
			this.BossBattleP1Box.TabIndex = 18;
			this.groupBox1.Controls.Add(this.FaceOffP1Box);
			this.groupBox1.Location = new Point(97, 180);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(110, 48);
			this.groupBox1.TabIndex = 55;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Face Off P1";
			this.FaceOffP1Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FaceOffP1Box.FormattingEnabled = true;
			this.FaceOffP1Box.Location = new Point(6, 19);
			this.FaceOffP1Box.Name = "FaceOffP1Box";
			this.FaceOffP1Box.Size = new Size(98, 21);
			this.FaceOffP1Box.TabIndex = 18;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(-2, 201);
			this.label13.Name = "label13";
			this.label13.Size = new Size(93, 19);
			this.label13.TabIndex = 58;
			this.label13.Text = "SECTIONS:";
			this.label13.TextAlign = ContentAlignment.MiddleCenter;
			this.ResetBtn.Enabled = false;
			this.ResetBtn.Location = new Point(512, 15);
			this.ResetBtn.Name = "ResetBtn";
			this.ResetBtn.Size = new Size(43, 23);
			this.ResetBtn.TabIndex = 17;
			this.ResetBtn.Text = "Reset";
			this.ResetBtn.UseVisualStyleBackColor = true;
			this.ResetBtn.Click += new EventHandler(this.ResetBtn_Click);
			this.AutoConfigBtn.Enabled = false;
			this.AutoConfigBtn.Location = new Point(404, 15);
			this.AutoConfigBtn.Name = "AutoConfigBtn";
			this.AutoConfigBtn.Size = new Size(102, 23);
			this.AutoConfigBtn.TabIndex = 16;
			this.AutoConfigBtn.Text = "Auto Configuration";
			this.AutoConfigBtn.UseVisualStyleBackColor = true;
			this.AutoConfigBtn.Click += new EventHandler(this.AutoConfigBtn_Click);
			this.groupBox5.Controls.Add(this.ExpertCoop2Box);
			this.groupBox5.Controls.Add(this.HardCoop2Box);
			this.groupBox5.Controls.Add(this.MediumCoop2Box);
			this.groupBox5.Controls.Add(this.EasyCoop2Box);
			this.groupBox5.Location = new Point(445, 43);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(110, 131);
			this.groupBox5.TabIndex = 57;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Coop Rhythm";
			this.ExpertCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ExpertCoop2Box.FormattingEnabled = true;
			this.ExpertCoop2Box.Location = new Point(6, 100);
			this.ExpertCoop2Box.Name = "ExpertCoop2Box";
			this.ExpertCoop2Box.Size = new Size(98, 21);
			this.ExpertCoop2Box.TabIndex = 33;
			this.HardCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HardCoop2Box.FormattingEnabled = true;
			this.HardCoop2Box.Location = new Point(6, 73);
			this.HardCoop2Box.Name = "HardCoop2Box";
			this.HardCoop2Box.Size = new Size(98, 21);
			this.HardCoop2Box.TabIndex = 32;
			this.MediumCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MediumCoop2Box.FormattingEnabled = true;
			this.MediumCoop2Box.Location = new Point(6, 46);
			this.MediumCoop2Box.Name = "MediumCoop2Box";
			this.MediumCoop2Box.Size = new Size(98, 21);
			this.MediumCoop2Box.TabIndex = 31;
			this.EasyCoop2Box.DropDownStyle = ComboBoxStyle.DropDownList;
			this.EasyCoop2Box.FormattingEnabled = true;
			this.EasyCoop2Box.Location = new Point(6, 19);
			this.EasyCoop2Box.Name = "EasyCoop2Box";
			this.EasyCoop2Box.Size = new Size(98, 21);
			this.EasyCoop2Box.TabIndex = 30;
			this.groupBox4.Controls.Add(this.ExpertRhythmBox);
			this.groupBox4.Controls.Add(this.HardRhythmBox);
			this.groupBox4.Controls.Add(this.MediumRhythmBox);
			this.groupBox4.Controls.Add(this.EasyRhythmBox);
			this.groupBox4.Location = new Point(213, 43);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(110, 131);
			this.groupBox4.TabIndex = 55;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Single Rhythm";
			this.ExpertRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ExpertRhythmBox.FormattingEnabled = true;
			this.ExpertRhythmBox.Location = new Point(6, 100);
			this.ExpertRhythmBox.Name = "ExpertRhythmBox";
			this.ExpertRhythmBox.Size = new Size(98, 21);
			this.ExpertRhythmBox.TabIndex = 25;
			this.HardRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HardRhythmBox.FormattingEnabled = true;
			this.HardRhythmBox.Location = new Point(6, 73);
			this.HardRhythmBox.Name = "HardRhythmBox";
			this.HardRhythmBox.Size = new Size(98, 21);
			this.HardRhythmBox.TabIndex = 24;
			this.MediumRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MediumRhythmBox.FormattingEnabled = true;
			this.MediumRhythmBox.Location = new Point(6, 46);
			this.MediumRhythmBox.Name = "MediumRhythmBox";
			this.MediumRhythmBox.Size = new Size(98, 21);
			this.MediumRhythmBox.TabIndex = 23;
			this.EasyRhythmBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.EasyRhythmBox.FormattingEnabled = true;
			this.EasyRhythmBox.Location = new Point(6, 19);
			this.EasyRhythmBox.Name = "EasyRhythmBox";
			this.EasyRhythmBox.Size = new Size(98, 21);
			this.EasyRhythmBox.TabIndex = 22;
			this.groupBox6.Controls.Add(this.ExpertCoopBox);
			this.groupBox6.Controls.Add(this.HardCoopBox);
			this.groupBox6.Controls.Add(this.MediumCoopBox);
			this.groupBox6.Controls.Add(this.EasyCoopBox);
			this.groupBox6.Location = new Point(329, 43);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(110, 131);
			this.groupBox6.TabIndex = 56;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Coop Guitar";
			this.ExpertCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ExpertCoopBox.FormattingEnabled = true;
			this.ExpertCoopBox.Location = new Point(6, 100);
			this.ExpertCoopBox.Name = "ExpertCoopBox";
			this.ExpertCoopBox.Size = new Size(98, 21);
			this.ExpertCoopBox.TabIndex = 29;
			this.HardCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HardCoopBox.FormattingEnabled = true;
			this.HardCoopBox.Location = new Point(6, 73);
			this.HardCoopBox.Name = "HardCoopBox";
			this.HardCoopBox.Size = new Size(98, 21);
			this.HardCoopBox.TabIndex = 28;
			this.MediumCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MediumCoopBox.FormattingEnabled = true;
			this.MediumCoopBox.Location = new Point(6, 46);
			this.MediumCoopBox.Name = "MediumCoopBox";
			this.MediumCoopBox.Size = new Size(98, 21);
			this.MediumCoopBox.TabIndex = 27;
			this.EasyCoopBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.EasyCoopBox.FormattingEnabled = true;
			this.EasyCoopBox.Location = new Point(6, 19);
			this.EasyCoopBox.Name = "EasyCoopBox";
			this.EasyCoopBox.Size = new Size(98, 21);
			this.EasyCoopBox.TabIndex = 26;
			this.groupBox3.Controls.Add(this.ExpertGuitarBox);
			this.groupBox3.Controls.Add(this.HardGuitarBox);
			this.groupBox3.Controls.Add(this.MediumGuitarBox);
			this.groupBox3.Controls.Add(this.EasyGuitarBox);
			this.groupBox3.Location = new Point(97, 43);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(110, 131);
			this.groupBox3.TabIndex = 54;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Single Guitar";
			this.ExpertGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ExpertGuitarBox.FormattingEnabled = true;
			this.ExpertGuitarBox.Location = new Point(6, 100);
			this.ExpertGuitarBox.Name = "ExpertGuitarBox";
			this.ExpertGuitarBox.Size = new Size(98, 21);
			this.ExpertGuitarBox.TabIndex = 21;
			this.HardGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HardGuitarBox.FormattingEnabled = true;
			this.HardGuitarBox.Location = new Point(6, 73);
			this.HardGuitarBox.Name = "HardGuitarBox";
			this.HardGuitarBox.Size = new Size(98, 21);
			this.HardGuitarBox.TabIndex = 20;
			this.MediumGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.MediumGuitarBox.FormattingEnabled = true;
			this.MediumGuitarBox.Location = new Point(6, 46);
			this.MediumGuitarBox.Name = "MediumGuitarBox";
			this.MediumGuitarBox.Size = new Size(98, 21);
			this.MediumGuitarBox.TabIndex = 19;
			this.EasyGuitarBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.EasyGuitarBox.FormattingEnabled = true;
			this.EasyGuitarBox.Location = new Point(6, 19);
			this.EasyGuitarBox.Name = "EasyGuitarBox";
			this.EasyGuitarBox.Size = new Size(98, 21);
			this.EasyGuitarBox.TabIndex = 18;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(15, 145);
			this.label9.Name = "label9";
			this.label9.Size = new Size(76, 19);
			this.label9.TabIndex = 53;
			this.label9.Text = "EXPERT:";
			this.label9.TextAlign = ContentAlignment.MiddleCenter;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(30, 118);
			this.label8.Name = "label8";
			this.label8.Size = new Size(61, 19);
			this.label8.TabIndex = 52;
			this.label8.Text = "HARD:";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(6, 91);
			this.label7.Name = "label7";
			this.label7.Size = new Size(85, 19);
			this.label7.TabIndex = 51;
			this.label7.Text = "MEDIUM:";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(37, 64);
			this.label5.Name = "label5";
			this.label5.Size = new Size(54, 19);
			this.label5.TabIndex = 50;
			this.label5.Text = "EASY:";
			this.label5.TextAlign = ContentAlignment.MiddleCenter;
			this.ChartFileBtn.Location = new Point(374, 16);
			this.ChartFileBtn.Name = "ChartFileBtn";
			this.ChartFileBtn.Size = new Size(24, 21);
			this.ChartFileBtn.TabIndex = 15;
			this.ChartFileBtn.Text = "...";
			this.ChartFileBtn.UseVisualStyleBackColor = true;
			this.ChartFileBtn.Click += new EventHandler(this.ChartFileBtn_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(10, 16);
			this.label4.Name = "label4";
			this.label4.Size = new Size(81, 19);
			this.label4.TabIndex = 48;
			this.label4.Text = "Chart File:";
			this.label4.TextAlign = ContentAlignment.MiddleCenter;
			this.ChartFileTxt.Location = new Point(97, 17);
			this.ChartFileTxt.Name = "ChartFileTxt";
			this.ChartFileTxt.ReadOnly = true;
			this.ChartFileTxt.Size = new Size(271, 20);
			this.ChartFileTxt.TabIndex = 49;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(6, 28);
			this.label10.Name = "label10";
			this.label10.Size = new Size(91, 19);
			this.label10.TabIndex = 36;
			this.label10.Text = "Song Name:";
			this.label10.TextAlign = ContentAlignment.MiddleCenter;
			this.SongNameTxt.CharacterCasing = CharacterCasing.Lower;
			this.SongNameTxt.Location = new Point(103, 29);
			this.SongNameTxt.MaxLength = 30;
			this.SongNameTxt.Name = "SongNameTxt";
			this.SongNameTxt.Size = new Size(140, 20);
			this.SongNameTxt.TabIndex = 1;
			this.SongNameTxt.TextChanged += new EventHandler(this.SongNameTxt_TextChanged);
			this.SongNameTxt.KeyPress += new KeyPressEventHandler(this.SongNameTxt_KeyPress);
			this.MainGroupBox.Controls.Add(this.label12);
			this.MainGroupBox.Controls.Add(this.CancelBtn);
			this.MainGroupBox.Controls.Add(this.ApplyBtn);
			this.MainGroupBox.Controls.Add(this.Chart_CheckBox);
			this.MainGroupBox.Controls.Add(this.Audio_CheckBox);
			this.MainGroupBox.Controls.Add(this.label10);
			this.MainGroupBox.Controls.Add(this.SongNameTxt);
			this.MainGroupBox.Location = new Point(12, 12);
			this.MainGroupBox.Name = "MainGroupBox";
			this.MainGroupBox.Size = new Size(566, 78);
			this.MainGroupBox.TabIndex = 0;
			this.MainGroupBox.TabStop = false;
			this.MainGroupBox.Text = "Main Settings";
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label12.Location = new Point(249, 28);
			this.label12.Name = "label12";
			this.label12.Size = new Size(131, 19);
			this.label12.TabIndex = 43;
			this.label12.Text = "Data to Generate:";
			this.label12.TextAlign = ContentAlignment.MiddleCenter;
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			this.CancelBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CancelBtn.Location = new Point(495, 44);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new Size(65, 27);
			this.CancelBtn.TabIndex = 35;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.ApplyBtn.DialogResult = DialogResult.OK;
			this.ApplyBtn.Enabled = false;
			this.ApplyBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ApplyBtn.Location = new Point(495, 11);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new Size(65, 27);
			this.ApplyBtn.TabIndex = 34;
			this.ApplyBtn.Text = "Apply";
			this.ApplyBtn.UseVisualStyleBackColor = true;
			this.Chart_CheckBox.AutoSize = true;
			this.Chart_CheckBox.Checked = true;
			this.Chart_CheckBox.CheckState = CheckState.Checked;
			this.Chart_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Chart_CheckBox.Location = new Point(380, 44);
			this.Chart_CheckBox.Name = "Chart_CheckBox";
			this.Chart_CheckBox.Size = new Size(112, 23);
			this.Chart_CheckBox.TabIndex = 3;
			this.Chart_CheckBox.Text = "Game Track";
			this.Chart_CheckBox.UseVisualStyleBackColor = true;
			this.Chart_CheckBox.CheckedChanged += new EventHandler(this.Chart_CheckBox_CheckedChanged);
			this.Audio_CheckBox.AutoSize = true;
			this.Audio_CheckBox.Checked = true;
			this.Audio_CheckBox.CheckState = CheckState.Checked;
			this.Audio_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Audio_CheckBox.Location = new Point(380, 15);
			this.Audio_CheckBox.Name = "Audio_CheckBox";
			this.Audio_CheckBox.Size = new Size(111, 23);
			this.Audio_CheckBox.TabIndex = 2;
			this.Audio_CheckBox.Text = "Audio Track";
			this.Audio_CheckBox.UseVisualStyleBackColor = true;
			this.Audio_CheckBox.CheckedChanged += new EventHandler(this.Audio_CheckBox_CheckedChanged);
			this.VolumeSlider.BackColor = Color.Transparent;
			this.VolumeSlider.method_7(50f);
			this.VolumeSlider.method_8(70f);
			this.VolumeSlider.method_20(5u);
			this.VolumeSlider.Location = new Point(465, 137);
			this.VolumeSlider.method_4(20);
			this.VolumeSlider.Name = "VolumeSlider";
			this.VolumeSlider.Size = new Size(95, 10);
			this.VolumeSlider.method_19(1u);
			this.VolumeSlider.TabIndex = 51;
			this.VolumeSlider.Text = "TimeSlideBar";
			this.VolumeSlider.method_6(new SizeF(50f, 25f));
			this.VolumeSlider.method_5(20);
			this.VolumeSlider.method_1("{0}%");
			this.VolumeSlider.method_14(100);
			this.VolumeSlider.method_0(new EventHandler(this.method_10));
			this.PreviewSlider.BackColor = Color.Transparent;
			this.PreviewSlider.method_10(Color.Crimson);
			this.PreviewSlider.method_9(Color.Red);
			this.PreviewSlider.method_7(50f);
			this.PreviewSlider.method_8(60f);
			this.PreviewSlider.method_21(Control1.Enum40.const_3);
			this.PreviewSlider.method_12(Color.Violet);
			this.PreviewSlider.method_11(Color.DarkViolet);
			this.PreviewSlider.Enabled = false;
			this.PreviewSlider.method_20(5u);
			this.PreviewSlider.Location = new Point(123, 116);
			this.PreviewSlider.method_4(20);
			this.PreviewSlider.Name = "PreviewSlider";
			this.PreviewSlider.Size = new Size(437, 15);
			this.PreviewSlider.method_19(1u);
			this.PreviewSlider.TabIndex = 14;
			this.PreviewSlider.Text = "PreviewSlider";
			this.PreviewSlider.method_6(new SizeF(20f, 50f));
			this.PreviewSlider.method_5(35);
			this.PreviewSlider.method_1("{0:mm:ss}");
			this.PreviewSlider.method_2(true);
			this.PreviewSlider.MouseDown += new MouseEventHandler(this.PreviewSlider_MouseDown);
			this.PreviewSlider.MouseUp += new MouseEventHandler(this.PreviewSlider_MouseUp);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(590, 520);
			base.Controls.Add(this.MainGroupBox);
			base.Controls.Add(this.ChartGroupBox);
			base.Controls.Add(this.AudioGroupBox);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SongData";
			this.Text = "Generate Song Data";
			this.AudioGroupBox.ResumeLayout(false);
			this.AudioGroupBox.PerformLayout();
			this.ChartGroupBox.ResumeLayout(false);
			this.ChartGroupBox.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.MainGroupBox.ResumeLayout(false);
			this.MainGroupBox.PerformLayout();
			base.ResumeLayout(false);
			base.FormClosing += new FormClosingEventHandler(this.SongData_FormClosing);
		}

		public SongData(GH3Songlist gh3Songlist_1)
		{
			this.InitializeComponent();
			Control arg_26_0 = this.Audio_CheckBox;
			this.Chart_CheckBox.Enabled = false;
			arg_26_0.Enabled = false;
			this.bool_1 = true;
			this.bool_0 = true;
			this.method_3();
			this.gh3Songlist_0 = gh3Songlist_1;
			this.timer_0 = new Timer();
			this.timer_0.Interval = 30;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
		}

        public SongData(GH3Songlist gh3Songlist_1, bool forceRB3)
        {
            this.forceRB3 = forceRB3;
            this.InitializeComponent();
            Control arg_26_0 = this.Audio_CheckBox;
            this.Chart_CheckBox.Enabled = false;
            arg_26_0.Enabled = false;
            this.bool_1 = true;
            this.bool_0 = true;
            this.method_3();
            this.gh3Songlist_0 = gh3Songlist_1;
            this.timer_0 = new Timer();
            this.timer_0.Interval = 30;
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        }

        public SongData(string string_0, bool bool_6, bool bool_7)
		{
			this.InitializeComponent();
			this.SongNameTxt.Text = string_0;
			this.bool_2 = true;
			this.SongNameTxt.Enabled = false;
			this.timer_0 = new Timer();
			this.timer_0.Interval = 30;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			CheckBox arg_71_0 = this.Audio_CheckBox;
			this.bool_0 = bool_6;
			arg_71_0.Checked = bool_6;
			CheckBox arg_86_0 = this.Chart_CheckBox;
			this.bool_1 = bool_7;
			arg_86_0.Checked = bool_7;
			this.method_3();
		}

		public SongData(string string_0, QBCParser class362_1, Class323 class323_1, string[] string_1)
		{
			this.InitializeComponent();
			this.SongNameTxt.Text = string_0;
			this.bool_2 = true;
			this.qbcParser = class362_1;
			this.method_6();
			this.method_4("No Track");
			this.method_5("No Track");
			this.method_8(0);
			foreach (string current in this.qbcParser.noteList.Keys)
			{
				this.method_4(current);
			}
			if (this.qbcParser.class228_2.Count != 0)
			{
				this.method_5("faceoffp1");
			}
			if (this.qbcParser.class228_3.Count != 0)
			{
				this.method_5("faceoffp2");
			}
			if (this.qbcParser.bpmList.Count != 0)
			{
				this.method_5("bossbattlep1");
			}
			if (this.qbcParser.class228_5.Count != 0)
			{
				this.method_5("bossbattlep2");
			}
			this.method_7();
			if (class323_1 != null)
			{
				this.class323_0 = class323_1;
				return;
			}
			if (string_1.Length == 1)
			{
				this.SingleAudioBtn.Checked = true;
				this.GuitarAudioTxt.Text = string_1[0];
			}
			else
			{
				string text = null;
				string text2 = null;
				string text3 = null;
				string text4 = null;
				string text5 = null;
				string text6 = null;
				for (int i = 0; i < string_1.Length; i++)
				{
					string text7 = string_1[i];
					string text8 = Class244.smethod_13(text7).ToLower();
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
							this.CoopAudioBtn.Checked = true;
							this.GuitarCoopTxt.Text = text4;
							this.RhythmCoopTxt.Text = text5;
							this.BandCoopTxt.Text = text6;
						}
						else
						{
							this.MultiAudioBtn.Checked = true;
						}
						this.RhythmAudioTxt.Text = text2;
					}
					else
					{
						this.DualAudioBtn.Checked = true;
					}
					this.BandAudioTxt.Text = text3;
				}
				else
				{
					this.SingleAudioBtn.Checked = true;
				}
				this.GuitarAudioTxt.Text = text;
			}
			this.PreviewSlider.method_18(Convert.ToInt32(AudioManager.getAudioStream(this.GuitarAudioTxt.Text).vmethod_1().timeSpan_0.TotalSeconds));
			this.PreviewSlider.method_14(this.PreviewSlider.method_17() / 2);
			if (this.GuitarAudioTxt.Text == "" || (!this.SingleAudioBtn.Checked && (this.BandAudioTxt.Text == "" || !this.DualAudioBtn.Checked) && (this.RhythmAudioTxt.Text == "" || !this.MultiAudioBtn.Checked) && (this.GuitarCoopTxt.Text == "" || this.RhythmCoopTxt.Text == "" || this.BandCoopTxt.Text == "" || !this.CoopAudioBtn.Checked)))
			{
				throw new Exception("File names did not follow format!");
			}
		}

		public Class248 method_0(string string_0)
		{
			if (this.class323_0 != null)
			{
				this.class323_0.method_0(this.SongNameTxt.Text);
				return new Class248(this.class323_0, this.GuitarAudioTxt.Text.Replace(".dat.xen", ".fsb.xen"), string_0);
			}
			string[] string_;
			if (this.SingleAudioBtn.Checked)
			{
				string_ = new string[]
				{
					this.GuitarAudioTxt.Text
				};
			}
			else if (this.DualAudioBtn.Checked)
			{
				string_ = new string[]
				{
					this.BandAudioTxt.Text,
					this.GuitarAudioTxt.Text
				};
			}
			else if (this.MultiAudioBtn.Checked)
			{
				string_ = new string[]
				{
					this.BandAudioTxt.Text,
					this.GuitarAudioTxt.Text,
					this.RhythmAudioTxt.Text
				};
			}
			else
			{
				string_ = new string[]
				{
					this.BandAudioTxt.Text,
					this.GuitarAudioTxt.Text,
					this.RhythmAudioTxt.Text,
					this.BandCoopTxt.Text,
					this.GuitarCoopTxt.Text,
					this.RhythmCoopTxt.Text
				};
			}
			return new Class248(this.SongNameTxt.Text, string_, new TimeSpan(0, 0, this.PreviewSlider.method_13()), new TimeSpan(0, 0, this.PreviewSlider.method_13() + Math.Min(this.PreviewSlider.method_17() - this.PreviewSlider.method_13(), 20)), string_0);
		}

		public Class250 method_1(Class318 class318_0, string string_0)
		{
			Dictionary<string, Track<int, NotesAtOffset>> dictionary = new Dictionary<string, Track<int, NotesAtOffset>>();
			if (!this.EasyGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("easy", this.qbcParser.noteList[(string)this.EasyGuitarBox.SelectedItem]);
			}
			if (!this.EasyRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_easy", this.qbcParser.noteList[(string)this.EasyRhythmBox.SelectedItem]);
			}
			if (!this.EasyCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_easy", this.qbcParser.noteList[(string)this.EasyCoopBox.SelectedItem]);
			}
			if (!this.EasyCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_easy", this.qbcParser.noteList[(string)this.EasyCoop2Box.SelectedItem]);
			}
			if (!this.MediumGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("medium", this.qbcParser.noteList[(string)this.MediumGuitarBox.SelectedItem]);
			}
			if (!this.MediumRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_medium", this.qbcParser.noteList[(string)this.MediumRhythmBox.SelectedItem]);
			}
			if (!this.MediumCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_medium", this.qbcParser.noteList[(string)this.MediumCoopBox.SelectedItem]);
			}
			if (!this.MediumCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_medium", this.qbcParser.noteList[(string)this.MediumCoop2Box.SelectedItem]);
			}
			if (!this.HardGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("hard", this.qbcParser.noteList[(string)this.HardGuitarBox.SelectedItem]);
			}
			if (!this.HardRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_hard", this.qbcParser.noteList[(string)this.HardRhythmBox.SelectedItem]);
			}
			if (!this.HardCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_hard", this.qbcParser.noteList[(string)this.HardCoopBox.SelectedItem]);
			}
			if (!this.HardCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_hard", this.qbcParser.noteList[(string)this.HardCoop2Box.SelectedItem]);
			}
			if (!this.ExpertGuitarBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("expert", this.qbcParser.noteList[(string)this.ExpertGuitarBox.SelectedItem]);
			}
			if (!this.ExpertRhythmBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythm_expert", this.qbcParser.noteList[(string)this.ExpertRhythmBox.SelectedItem]);
			}
			if (!this.ExpertCoopBox.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("guitarcoop_expert", this.qbcParser.noteList[(string)this.ExpertCoopBox.SelectedItem]);
			}
			if (!this.ExpertCoop2Box.SelectedItem.Equals("No Track"))
			{
				dictionary.Add("rhythmcoop_expert", this.qbcParser.noteList[(string)this.ExpertCoop2Box.SelectedItem]);
			}
			Track<int, int> class228_ = this.method_2(this.FaceOffP1Box);
			Track<int, int> class228_2 = this.method_2(this.FaceOffP2Box);
			Track<int, int> class228_3 = this.method_2(this.BossBattleP1Box);
			Track<int, int> class228_4 = this.method_2(this.BossBattleP2Box);
			this.qbcParser.noteList = dictionary;
			this.qbcParser.class228_2 = class228_;
			this.qbcParser.class228_3 = class228_2;
			this.qbcParser.bpmList = class228_3;
			this.qbcParser.class228_5 = class228_4;
			return new Class250(this.SongNameTxt.Text, this.qbcParser, class318_0, string_0);
		}

		private Track<int, int> method_2(ComboBox comboBox_0)
		{
			if (comboBox_0.SelectedItem.Equals("faceoffp1"))
			{
				return this.qbcParser.class228_2;
			}
			if (comboBox_0.SelectedItem.Equals("faceoffp2"))
			{
				return this.qbcParser.class228_3;
			}
			if (comboBox_0.SelectedItem.Equals("bossbattlep1"))
			{
				return this.qbcParser.bpmList;
			}
			if (comboBox_0.SelectedItem.Equals("bossbattlep2"))
			{
				return this.qbcParser.class228_5;
			}
			return new Track<int, int>();
		}

		private void method_3()
		{
			if (this.bool_0)
			{
				this.bool_3 = (this.GuitarAudioTxt.Text != "" && (this.SingleAudioBtn.Checked || (this.BandAudioTxt.Text != "" && (this.DualAudioBtn.Checked || (this.RhythmAudioTxt.Text != "" && this.MultiAudioBtn.Checked) || (this.GuitarCoopTxt.Text != "" && this.RhythmCoopTxt.Text != "" && this.BandCoopTxt.Text != "" && this.CoopAudioBtn.Checked)))));
			}
			this.ApplyBtn.Enabled = (((this.SongNameTxt.Enabled && this.bool_2) || !this.SongNameTxt.Enabled) && ((this.bool_0 && this.bool_3) || !this.bool_0) && ((this.bool_1 && this.bool_4) || !this.bool_1));
			if (!this.SongNameTxt.Enabled && !this.bool_0 && !this.bool_1)
			{
				this.ApplyBtn.Enabled = false;
			}
		}

		private void Audio_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.AudioGroupBox.Enabled = (this.bool_0 = this.Audio_CheckBox.Checked);
		}

		private void Chart_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.ChartGroupBox.Enabled = (this.bool_1 = this.Chart_CheckBox.Checked);
		}

		private void method_4(string string_0)
		{
			this.EasyGuitarBox.Items.Add(string_0);
			this.EasyRhythmBox.Items.Add(string_0);
			this.EasyCoopBox.Items.Add(string_0);
			this.EasyCoop2Box.Items.Add(string_0);
			this.MediumGuitarBox.Items.Add(string_0);
			this.MediumRhythmBox.Items.Add(string_0);
			this.MediumCoopBox.Items.Add(string_0);
			this.MediumCoop2Box.Items.Add(string_0);
			this.HardGuitarBox.Items.Add(string_0);
			this.HardRhythmBox.Items.Add(string_0);
			this.HardCoopBox.Items.Add(string_0);
			this.HardCoop2Box.Items.Add(string_0);
			this.ExpertGuitarBox.Items.Add(string_0);
			this.ExpertRhythmBox.Items.Add(string_0);
			this.ExpertCoopBox.Items.Add(string_0);
			this.ExpertCoop2Box.Items.Add(string_0);
		}

		private void method_5(string string_0)
		{
			this.FaceOffP1Box.Items.Add(string_0);
			this.FaceOffP2Box.Items.Add(string_0);
			this.BossBattleP1Box.Items.Add(string_0);
			this.BossBattleP2Box.Items.Add(string_0);
		}

		private void method_6()
		{
			this.EasyGuitarBox.Items.Clear();
			this.EasyRhythmBox.Items.Clear();
			this.EasyCoopBox.Items.Clear();
			this.EasyCoop2Box.Items.Clear();
			this.MediumGuitarBox.Items.Clear();
			this.MediumRhythmBox.Items.Clear();
			this.MediumCoopBox.Items.Clear();
			this.MediumCoop2Box.Items.Clear();
			this.HardGuitarBox.Items.Clear();
			this.HardRhythmBox.Items.Clear();
			this.HardCoopBox.Items.Clear();
			this.HardCoop2Box.Items.Clear();
			this.ExpertGuitarBox.Items.Clear();
			this.ExpertRhythmBox.Items.Clear();
			this.ExpertCoopBox.Items.Clear();
			this.ExpertCoop2Box.Items.Clear();
			this.FaceOffP1Box.Items.Clear();
			this.FaceOffP2Box.Items.Clear();
			this.BossBattleP1Box.Items.Clear();
			this.BossBattleP2Box.Items.Clear();
		}

		private void AutoConfigBtn_Click(object sender, EventArgs e)
		{
			this.method_7();
		}

		private void method_7()
		{
			this.ExpertGuitarBox.SelectedItem = (this.HardGuitarBox.SelectedItem = (this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "easy")));
			this.ExpertGuitarBox.SelectedItem = (this.HardGuitarBox.SelectedItem = (this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "medium")));
			this.ExpertGuitarBox.SelectedItem = (this.HardGuitarBox.SelectedItem = (this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "hard")));
			this.ExpertGuitarBox.SelectedItem = (this.HardGuitarBox.SelectedItem = (this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "expert")));
			this.HardGuitarBox.SelectedItem = (this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "hard"));
			this.MediumGuitarBox.SelectedItem = (this.EasyGuitarBox.SelectedItem = "medium");
			this.EasyGuitarBox.SelectedItem = "easy";
			this.ExpertRhythmBox.SelectedItem = (this.HardRhythmBox.SelectedItem = (this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_easy")));
			this.ExpertRhythmBox.SelectedItem = (this.HardRhythmBox.SelectedItem = (this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_medium")));
			this.ExpertRhythmBox.SelectedItem = (this.HardRhythmBox.SelectedItem = (this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_hard")));
			this.ExpertRhythmBox.SelectedItem = (this.HardRhythmBox.SelectedItem = (this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_expert")));
			this.HardRhythmBox.SelectedItem = (this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_hard"));
			this.MediumRhythmBox.SelectedItem = (this.EasyRhythmBox.SelectedItem = "rhythm_medium");
			this.EasyRhythmBox.SelectedItem = "rhythm_easy";
			this.ExpertCoopBox.SelectedItem = (this.HardCoopBox.SelectedItem = (this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_easy")));
			this.ExpertCoopBox.SelectedItem = (this.HardCoopBox.SelectedItem = (this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_medium")));
			this.ExpertCoopBox.SelectedItem = (this.HardCoopBox.SelectedItem = (this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_hard")));
			this.ExpertCoopBox.SelectedItem = (this.HardCoopBox.SelectedItem = (this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_expert")));
			this.HardCoopBox.SelectedItem = (this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_hard"));
			this.MediumCoopBox.SelectedItem = (this.EasyCoopBox.SelectedItem = "guitarcoop_medium");
			this.EasyCoopBox.SelectedItem = "guitarcoop_easy";
			this.ExpertCoop2Box.SelectedItem = (this.HardCoop2Box.SelectedItem = (this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_easy")));
			this.ExpertCoop2Box.SelectedItem = (this.HardCoop2Box.SelectedItem = (this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_medium")));
			this.ExpertCoop2Box.SelectedItem = (this.HardCoop2Box.SelectedItem = (this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_hard")));
			this.ExpertCoop2Box.SelectedItem = (this.HardCoop2Box.SelectedItem = (this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_expert")));
			this.HardCoop2Box.SelectedItem = (this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_hard"));
			this.MediumCoop2Box.SelectedItem = (this.EasyCoop2Box.SelectedItem = "rhythmcoop_medium");
			this.EasyCoop2Box.SelectedItem = "rhythmcoop_easy";
			this.FaceOffP1Box.SelectedItem = "faceoffp1";
			this.FaceOffP2Box.SelectedItem = "faceoffp2";
			this.BossBattleP1Box.SelectedItem = "bossbattlep1";
			this.BossBattleP2Box.SelectedItem = "bossbattlep2";
		}

		private void method_8(int int_0)
		{
			ListControl arg_12F_0 = this.EasyGuitarBox;
			ListControl arg_128_0 = this.EasyRhythmBox;
			ListControl arg_11E_0 = this.EasyCoopBox;
			ListControl arg_114_0 = this.EasyCoop2Box;
			ListControl arg_10A_0 = this.MediumGuitarBox;
			ListControl arg_100_0 = this.MediumRhythmBox;
			ListControl arg_F6_0 = this.MediumCoopBox;
			ListControl arg_EC_0 = this.MediumCoop2Box;
			ListControl arg_E2_0 = this.HardGuitarBox;
			ListControl arg_D8_0 = this.HardRhythmBox;
			ListControl arg_CE_0 = this.HardCoopBox;
			ListControl arg_C4_0 = this.HardCoop2Box;
			ListControl arg_BA_0 = this.ExpertGuitarBox;
			ListControl arg_B0_0 = this.ExpertRhythmBox;
			ListControl arg_A6_0 = this.ExpertCoopBox;
			ListControl arg_9C_0 = this.ExpertCoop2Box;
			ListControl arg_93_0 = this.FaceOffP1Box;
			ListControl arg_8B_0 = this.FaceOffP2Box;
			ListControl arg_83_0 = this.BossBattleP1Box;
			this.BossBattleP2Box.SelectedIndex = int_0;
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
			this.method_8(0);
		}

		private void ChartFileBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the game track file.", "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart", true)).Equals(""))
			{
				this.bool_4 = false;
				try
				{
                    //Configures paks
                    if (fileName.EndsWith("_song.pak.xen"))
					{
						string text2 = Class244.smethod_13(fileName).Replace("_song.pak.xen", "");
						using (Class318 @class = new Class318(fileName, false))
						{
							if (!@class.method_6("songs\\" + text2 + ".mid.qb"))
							{
								throw new Exception("MID.QB song file not found.");
							}
							this.qbcParser = new QBCParser(text2, @class.method_8("songs\\" + text2 + ".mid.qb"));
							goto IL_F5;
						}
					}
                    //Configures qbc
					if (fileName.EndsWith(".qbc"))
					{
						this.qbcParser = new QBCParser(fileName);
					}
                    //Configures midi
                    else if (fileName.EndsWith(".mid"))
					{
                        ChartParser chartParser = Midi2Chart.getMidiSong(fileName, this.forceRB3);
                        this.qbcParser = chartParser.method_3();
					}
                    //Configures charts
                    else
                    {
                        //Crashes in this
                        this.qbcParser = new ChartParser(fileName).method_3();
					}
                    IL_F5:
					this.method_6();
					this.method_4("No Track");
					this.method_5("No Track");
					this.method_8(0);
					Control arg_12B_0 = this.AutoConfigBtn;
					this.ResetBtn.Enabled = true;
					arg_12B_0.Enabled = true;
					foreach (string current in this.qbcParser.noteList.Keys)
					{
						this.method_4(current);
					}
					if (this.qbcParser.class228_2.Count != 0)
					{
						this.method_5("faceoffp1");
					}
					if (this.qbcParser.class228_3.Count != 0)
					{
						this.method_5("faceoffp2");
					}
					if (this.qbcParser.bpmList.Count != 0)
					{
						this.method_5("bossbattlep1");
					}
					if (this.qbcParser.class228_5.Count != 0)
					{
						this.method_5("bossbattlep2");
					}
					this.ChartFileTxt.Text = fileName;
					this.ChartFileTxt.SelectionStart = this.ChartFileTxt.TextLength;
					this.bool_4 = true;
					this.method_7();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Game Track cannot be parsed.\n" + ex.Message);
				}
				this.method_3();
			}
		}

		private void method_9()
		{
			this.GuitarAudioTxt.Text = (this.RhythmAudioTxt.Text = (this.BandAudioTxt.Text = (this.GuitarCoopTxt.Text = (this.RhythmCoopTxt.Text = (this.BandCoopTxt.Text = "")))));
			this.PreviewSlider.method_18(1);
			this.PreviewSlider.method_14(0);
			this.PreviewSlider.Enabled = false;
			if (this.interface6_0 != null)
			{
				this.interface6_0.Dispose();
				this.interface6_0 = null;
			}
		}

		private void SingleAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_73_0 = this.RhythmAudioBtn;
			Control arg_6D_0 = this.RhythmAudioTxt;
			Control arg_67_0 = this.BandAudioBtn;
			Control arg_61_0 = this.BandAudioTxt;
			Control arg_5B_0 = this.GuitarCoopBtn;
			Control arg_55_0 = this.GuitarCoopTxt;
			Control arg_4F_0 = this.RhythmCoopBtn;
			Control arg_49_0 = this.RhythmCoopTxt;
			Control arg_43_0 = this.BandCoopBtn;
			this.BandCoopTxt.Enabled = false;
			arg_43_0.Enabled = false;
			arg_49_0.Enabled = false;
			arg_4F_0.Enabled = false;
			arg_55_0.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			this.method_9();
		}

		private void DualAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_13_0 = this.BandAudioBtn;
			this.BandAudioTxt.Enabled = true;
			arg_13_0.Enabled = true;
			Control arg_73_0 = this.RhythmAudioBtn;
			Control arg_6D_0 = this.RhythmAudioTxt;
			Control arg_67_0 = this.GuitarCoopBtn;
			Control arg_61_0 = this.GuitarCoopTxt;
			Control arg_5B_0 = this.RhythmCoopBtn;
			Control arg_55_0 = this.RhythmCoopTxt;
			Control arg_4F_0 = this.BandCoopBtn;
			this.BandCoopTxt.Enabled = false;
			arg_4F_0.Enabled = false;
			arg_55_0.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			this.method_9();
		}

		private void MultiAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_2B_0 = this.RhythmAudioBtn;
			Control arg_25_0 = this.RhythmAudioTxt;
			Control arg_1F_0 = this.BandAudioBtn;
			this.BandAudioTxt.Enabled = true;
			arg_1F_0.Enabled = true;
			arg_25_0.Enabled = true;
			arg_2B_0.Enabled = true;
			Control arg_73_0 = this.GuitarCoopBtn;
			Control arg_6D_0 = this.GuitarCoopTxt;
			Control arg_67_0 = this.RhythmCoopBtn;
			Control arg_61_0 = this.RhythmCoopTxt;
			Control arg_5B_0 = this.BandCoopBtn;
			this.BandCoopTxt.Enabled = false;
			arg_5B_0.Enabled = false;
			arg_61_0.Enabled = false;
			arg_67_0.Enabled = false;
			arg_6D_0.Enabled = false;
			arg_73_0.Enabled = false;
			this.method_9();
		}

		private void CoopAudioBtn_CheckedChanged(object sender, EventArgs e)
		{
			Control arg_73_0 = this.RhythmAudioBtn;
			Control arg_6D_0 = this.RhythmAudioTxt;
			Control arg_67_0 = this.BandAudioBtn;
			Control arg_61_0 = this.BandAudioTxt;
			Control arg_5B_0 = this.GuitarCoopBtn;
			Control arg_55_0 = this.GuitarCoopTxt;
			Control arg_4F_0 = this.RhythmCoopBtn;
			Control arg_49_0 = this.RhythmCoopTxt;
			Control arg_43_0 = this.BandCoopBtn;
			this.BandCoopTxt.Enabled = true;
			arg_43_0.Enabled = true;
			arg_49_0.Enabled = true;
			arg_4F_0.Enabled = true;
			arg_55_0.Enabled = true;
			arg_5B_0.Enabled = true;
			arg_61_0.Enabled = true;
			arg_67_0.Enabled = true;
			arg_6D_0.Enabled = true;
			arg_73_0.Enabled = true;
			this.method_9();
		}

		private void GuitarAudioBtn_Click(object sender, EventArgs e)
		{
			string fileName = Class244.smethod_16("Select the Guitar Audio track file.", "Any Supported Audio Formats|*.dat.xen;*.mp3;*.wav;*.ogg;*.flac|GH3 Audio Header file|*.dat.xen|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true).ToLower();
            if (this.SingleAudioBtn.Checked)
			{
                if (!(fileName.Equals("")))
				{
                    this.GuitarAudioTxt.Text = fileName;
					this.GuitarAudioTxt.SelectionStart = this.GuitarAudioTxt.TextLength;
					if (fileName.EndsWith(".dat.xen"))
					{
						if (!File.Exists(fileName.Replace(".dat.xen", ".fsb.xen")))
						{
							MessageBox.Show("Data file (FSB.XEN) is missing.", "Error!");
							this.class323_0 = null;
							this.GuitarAudioTxt.Text = "";
						}
						else
						{
							this.class323_0 = new Class323(fileName);
							if ((int)new FileInfo(fileName.Replace(".dat.xen", ".fsb.xen")).Length != this.class323_0.int_0)
							{
								MessageBox.Show("FSB file size does not match!", "Error!");
								this.class323_0 = null;
								this.GuitarAudioTxt.Text = "";
							}
							else
							{
								this.PreviewSlider.Enabled = false;
							}
						}
					}
					else
					{
						this.PreviewSlider.Enabled = true;
						this.method_11();
					}
					this.method_3();
                    return;
				}
			}
			else if (!(fileName.Equals("")))
			{
				this.GuitarAudioTxt.Text = fileName;
				this.GuitarAudioTxt.SelectionStart = this.GuitarAudioTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
            }
		}

		private void RhythmAudioBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Rhythm Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                this.RhythmAudioTxt.Text = fileName;
				this.RhythmAudioTxt.SelectionStart = this.RhythmAudioTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
			}
		}

		private void BandAudioBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Band Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                this.BandAudioTxt.Text = fileName;
				this.BandAudioTxt.SelectionStart = this.BandAudioTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
			}
		}

		private void GuitarCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Guitar Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                this.GuitarCoopTxt.Text = fileName;
				this.GuitarCoopTxt.SelectionStart = this.GuitarCoopTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
			}
		}

		private void RhythmCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Rhythm Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                this.RhythmCoopTxt.Text = fileName;
				this.RhythmCoopTxt.SelectionStart = this.RhythmCoopTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
			}
		}

		private void BandCoopBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Band Coop Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio file|*.mp3|Waveform Audio file|*.wav|Ogg Vorbis Audio file|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
                this.BandCoopTxt.Text = fileName;
				this.BandCoopTxt.SelectionStart = this.BandCoopTxt.TextLength;
				this.PreviewSlider.Enabled = true;
				this.method_11();
				this.method_3();
			}
		}

		private void SongNameTxt_TextChanged(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0 != null)
			{
				this.bool_2 = (this.SongNameTxt.Text != "" && !Class327.smethod_4(this.SongNameTxt.Text) && !this.gh3Songlist_0.method_3(this.SongNameTxt.Text));
			}
			this.method_3();
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
			if (this.interface6_0 != null)
			{
				this.interface6_0.Dispose();
			}
		}

		~SongData()
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.Dispose();
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (this.interface6_0 != null && this.bool_5)
			{
				this.PreviewSlider.method_14((int)this.interface6_0.imethod_0().TotalSeconds);
			}
		}

		private void Play_Btn_Click(object sender, EventArgs e)
		{
			if (this.interface6_0 == null)
			{
				return;
			}
			this.interface6_0.imethod_3();
			this.timer_0.Start();
		}

		private void Pause_Btn_Click(object sender, EventArgs e)
		{
			if (this.interface6_0 == null)
			{
				return;
			}
			this.interface6_0.imethod_4();
			this.timer_0.Stop();
		}

		private void Stop_Btn_Click(object sender, EventArgs e)
		{
			if (this.interface6_0 == null)
			{
				return;
			}
			this.interface6_0.imethod_5();
			this.timer_0.Stop();
			this.PreviewSlider.method_14(this.PreviewSlider.method_15());
			this.interface6_0.imethod_2(0);
		}

		private void PreviewSlider_MouseUp(object sender, MouseEventArgs e)
		{
			this.bool_5 = true;
			this.interface6_0.imethod_1(TimeSpan.FromSeconds((double)this.PreviewSlider.method_13()));
		}

		private void PreviewSlider_MouseDown(object sender, MouseEventArgs e)
		{
			this.bool_5 = false;
		}

		private void method_10(object sender, EventArgs e)
		{
			if (this.interface6_0 != null)
			{
				this.interface6_0.imethod_8((float)this.VolumeSlider.method_13() / 100f);
			}
		}

		private void method_11()
		{
			try
			{
				List<GenericAudioStream> list = new List<GenericAudioStream>();
				if (!this.BandCoopTxt.Text.Equals(""))
				{
					list.Add(AudioManager.getAudioStream(this.BandCoopTxt.Text));
				}
				else if (!this.BandAudioTxt.Text.Equals(""))
				{
					list.Add(AudioManager.getAudioStream(this.BandAudioTxt.Text));
				}
				if (!this.GuitarCoopTxt.Text.Equals("") && !this.RhythmCoopTxt.Text.Equals(""))
				{
					list.Insert(0, AudioManager.getAudioStream(this.RhythmCoopTxt.Text));
					list.Insert(0, AudioManager.getAudioStream(this.GuitarCoopTxt.Text));
				}
				else
				{
					if (!this.RhythmAudioTxt.Text.Equals(""))
					{
						list.Insert(0, AudioManager.getAudioStream(this.RhythmAudioTxt.Text));
					}
					if (!this.GuitarAudioTxt.Text.Equals(""))
					{
						list.Insert(0, AudioManager.getAudioStream(this.GuitarAudioTxt.Text));
					}
				}
				if (list.Count != 0)
				{
					GenericAudioStream stream = (list.Count == 1) ? list[0] : new Stream2(list.ToArray());
					if (this.interface6_0 != null)
					{
						this.interface6_0.Dispose();
					}
					this.interface6_0 = AudioManager.smethod_0(Enum25.const_5, stream);
					this.PreviewSlider.method_14((int)this.interface6_0.imethod_0().TotalSeconds);
					this.PreviewSlider.method_18((int)stream.vmethod_1().timeSpan_0.TotalSeconds);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Cannot load audio file/s.\n" + ex.Message);
			}
		}
	}
}
