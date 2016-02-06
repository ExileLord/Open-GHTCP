using GuitarHero.Songlist;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ns15
{
	public class SongProperties : Form
	{
		private GH3Song gh3Song_0;

		private IContainer icontainer_0;

		private TextBox YearTxt;

		private NumericUpDown OffsetBox;

		private TextBox TitleTxt;

		private ComboBox SingerBox;

		private ComboBox CountOffBox;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label6;

		private Label label7;

		private TextBox ArtistTxt;

		private Label label1;

		private ComboBox BassistBox;

		private Label label2;

		private NumericUpDown BandVolBox;

		private Label label3;

		private Label label4;

		private NumericUpDown HammerOnBox;

		private Label label5;

		private RadioButton ByBtn;

		private RadioButton FamousByBtn;

		private RadioButton CustomTxtBtn;

		private TextBox ArtistTextBox;

		private Label label11;

		private CheckBox Original_CheckBox;

		private CheckBox Rhythm_CheckBox;

		private CheckBox Coop_CheckBox;

		private Button ApplyBtn;

		private Button CancelBtn;

		private CheckBox Keyboard_CheckBox;

		private RadioButton BassBtn;

		private RadioButton RhythmBtn;

		private ComboBox BossBox;

		private Label label12;

		private Panel panel1;

		private Panel panel2;

		private NumericUpDown GuitarVolBox;

		private GroupBox AeroGroupBox;

		private NumericUpDown BPM8NoteBox;

		private Label label13;

		private TextBox CoveredTxt;

		private Label label15;

		private ComboBox BandBox;

		private Label label16;

		private CheckBox AeroGuitaristBox;

		private CheckBox PerryMicBox;

		private TextBox SingAnimPakTxt;

		private Label label14;

		public SongProperties(string string_0)
		{
			this.InitializeComponent();
			this.gh3Song_0 = new GH3Song();
			this.Text = this.Text + " (" + string_0 + ")";
			this.SingerBox.SelectedIndex = 0;
			this.CountOffBox.SelectedIndex = 0;
			this.BassistBox.SelectedIndex = 0;
			this.BossBox.SelectedIndex = 0;
		}

		public SongProperties(GH3Song gh3Song_1) : this(gh3Song_1.name)
		{
			this.gh3Song_0 = gh3Song_1;
			if (this.gh3Song_0 is GHASong)
			{
				this.BassistBox.Enabled = false;
				this.BossBox.Items.Add("Joe Perry Props");
				this.BossBox.Items.Add("Tom Morello Props");
			}
			else
			{
				this.AeroGroupBox.Enabled = false;
				this.SingerBox.Items.Add("Bret Michaels");
				this.BossBox.Items.Add("Tom Morello Props");
				this.BossBox.Items.Add("Slash Props");
				this.BossBox.Items.Add("Lou Props");
			}
			this.ApplyBtn.Enabled = this.gh3Song_0.editable;
			this.TitleTxt.Text = this.gh3Song_0.title;
			this.ArtistTxt.Text = this.gh3Song_0.artist;
			this.YearTxt.Text = this.gh3Song_0.year;
			this.Original_CheckBox.Checked = this.gh3Song_0.original_artist;
			this.Rhythm_CheckBox.Checked = !this.gh3Song_0.no_rhythm_track;
			this.Keyboard_CheckBox.Checked = this.gh3Song_0.keyboard;
			this.Coop_CheckBox.Checked = this.gh3Song_0.use_coop_notetracks;
			this.BassBtn.Checked = !(this.RhythmBtn.Checked = this.gh3Song_0.not_bass);
			if (this.gh3Song_0.artist_text is bool)
			{
				this.FamousByBtn.Checked = !(this.ByBtn.Checked = (bool)this.gh3Song_0.artist_text);
			}
			else
			{
				this.ArtistTextBox.Text = (string)this.gh3Song_0.artist_text;
				this.CustomTxtBtn.Checked = true;
			}
			this.GuitarVolBox.Value = (decimal)this.gh3Song_0.guitar_vol;
			this.BandVolBox.Value = (decimal)this.gh3Song_0.band_vol;
			this.HammerOnBox.Value = (decimal)this.gh3Song_0.hammer_on;
			this.OffsetBox.Value = this.gh3Song_0.gem_offset;
			if (this.gh3Song_0.singer.Equals(""))
			{
				this.SingerBox.SelectedIndex = 0;
			}
			else if (this.gh3Song_0.singer.Equals("male"))
			{
				this.SingerBox.SelectedIndex = 1;
			}
			else if (this.gh3Song_0.singer.Equals("female"))
			{
				this.SingerBox.SelectedIndex = 2;
			}
			else if (this.gh3Song_0.singer.Equals("bret"))
			{
				this.SingerBox.SelectedItem = "Bret Michaels";
			}
			this.CountOffBox.SelectedItem = this.gh3Song_0.countoff.ToLower();
			this.BassistBox.SelectedItem = this.gh3Song_0.bassist;
			if (this.gh3Song_0.boss.Equals(""))
			{
				this.BossBox.SelectedIndex = 0;
			}
			else if (this.gh3Song_0.boss.Equals("boss_tommorello_props"))
			{
				this.BossBox.SelectedItem = "Tom Morello Props";
			}
			else if (this.gh3Song_0.boss.Equals("boss_slash_props"))
			{
				this.BossBox.SelectedItem = "Slash Props";
			}
			else if (this.gh3Song_0.boss.Equals("boss_devil_props"))
			{
				this.BossBox.SelectedItem = "Lou Props";
			}
			else if (this.gh3Song_0.boss.Equals("boss_joe_props"))
			{
				this.BossBox.SelectedItem = "Joe Perry Props";
			}
			if (this.AeroGroupBox.Enabled)
			{
				GHASong gHASong = (GHASong)this.gh3Song_0;
				this.CoveredTxt.Text = gHASong.covered_by;
				this.SingAnimPakTxt.Text = gHASong.singer_anim_pak;
				this.BandBox.SelectedItem = gHASong.band;
				this.BPM8NoteBox.Value = gHASong.thin_fretbar_8note_params_high_bpm;
				this.AeroGuitaristBox.Checked = gHASong.guitarist_checksum;
				this.PerryMicBox.Checked = gHASong.perry_mic_stand;
			}
		}

		public GH3Song method_0()
		{
			this.gh3Song_0.title = this.TitleTxt.Text;
			this.gh3Song_0.artist = this.ArtistTxt.Text;
			this.gh3Song_0.year = this.YearTxt.Text;
			this.gh3Song_0.original_artist = this.Original_CheckBox.Checked;
			this.gh3Song_0.no_rhythm_track = !this.Rhythm_CheckBox.Checked;
			this.gh3Song_0.keyboard = this.Keyboard_CheckBox.Checked;
			this.gh3Song_0.use_coop_notetracks = this.Coop_CheckBox.Checked;
			this.gh3Song_0.not_bass = this.RhythmBtn.Checked;
			if (this.CustomTxtBtn.Checked)
			{
				this.gh3Song_0.artist_text = this.ArtistTextBox.Text;
			}
			else
			{
				this.gh3Song_0.artist_text = this.ByBtn.Checked;
			}
			this.gh3Song_0.guitar_vol = (float)this.GuitarVolBox.Value;
			this.gh3Song_0.band_vol = (float)this.BandVolBox.Value;
			this.gh3Song_0.hammer_on = (float)this.HammerOnBox.Value;
			this.gh3Song_0.input_offset = (this.gh3Song_0.gem_offset = (int)this.OffsetBox.Value);
			this.gh3Song_0.singer = (new string[]
			{
				"",
				"male",
				"female",
				"bret"
			})[this.SingerBox.SelectedIndex];
			this.gh3Song_0.countoff = (string)this.CountOffBox.SelectedItem;
			this.gh3Song_0.bassist = (string)this.BassistBox.SelectedItem;
			string a;
			if ((a = (string)this.BossBox.SelectedItem) != null)
			{
				if (!(a == "Tom Morello Props"))
				{
					if (!(a == "Slash Props"))
					{
						if (!(a == "Lou Props"))
						{
							if (a == "Joe Perry Props")
							{
								this.gh3Song_0.boss = "boss_joe_props";
							}
						}
						else
						{
							this.gh3Song_0.boss = "boss_devil_props";
						}
					}
					else
					{
						this.gh3Song_0.boss = "boss_slash_props";
					}
				}
				else
				{
					this.gh3Song_0.boss = "boss_tommorello_props";
				}
			}
			if (this.gh3Song_0 is GHASong)
			{
				GHASong gHASong = (GHASong)this.gh3Song_0;
				gHASong.covered_by = this.CoveredTxt.Text;
				gHASong.singer_anim_pak = this.SingAnimPakTxt.Text;
				gHASong.band = (string)this.BandBox.SelectedItem;
				this.BPM8NoteBox.Value = gHASong.thin_fretbar_8note_params_high_bpm;
				this.AeroGuitaristBox.Checked = gHASong.guitarist_checksum;
				this.PerryMicBox.Checked = gHASong.perry_mic_stand;
			}
			return this.gh3Song_0;
		}

		private void ByBtn_CheckedChanged(object sender, EventArgs e)
		{
			this.ArtistTextBox.Enabled = false;
		}

		private void FamousByBtn_CheckedChanged(object sender, EventArgs e)
		{
			this.ArtistTextBox.Enabled = false;
		}

		private void CustomTxtBtn_CheckedChanged(object sender, EventArgs e)
		{
			this.ArtistTextBox.Enabled = true;
		}

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
			this.YearTxt = new TextBox();
			this.OffsetBox = new NumericUpDown();
			this.TitleTxt = new TextBox();
			this.SingerBox = new ComboBox();
			this.CountOffBox = new ComboBox();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.ArtistTxt = new TextBox();
			this.label1 = new Label();
			this.BassistBox = new ComboBox();
			this.label2 = new Label();
			this.BandVolBox = new NumericUpDown();
			this.label3 = new Label();
			this.GuitarVolBox = new NumericUpDown();
			this.label4 = new Label();
			this.HammerOnBox = new NumericUpDown();
			this.label5 = new Label();
			this.ByBtn = new RadioButton();
			this.FamousByBtn = new RadioButton();
			this.CustomTxtBtn = new RadioButton();
			this.ArtistTextBox = new TextBox();
			this.label11 = new Label();
			this.Original_CheckBox = new CheckBox();
			this.Rhythm_CheckBox = new CheckBox();
			this.Coop_CheckBox = new CheckBox();
			this.ApplyBtn = new Button();
			this.CancelBtn = new Button();
			this.Keyboard_CheckBox = new CheckBox();
			this.BassBtn = new RadioButton();
			this.RhythmBtn = new RadioButton();
			this.BossBox = new ComboBox();
			this.label12 = new Label();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.AeroGroupBox = new GroupBox();
			this.SingAnimPakTxt = new TextBox();
			this.label14 = new Label();
			this.PerryMicBox = new CheckBox();
			this.AeroGuitaristBox = new CheckBox();
			this.BandBox = new ComboBox();
			this.label16 = new Label();
			this.CoveredTxt = new TextBox();
			this.label15 = new Label();
			this.BPM8NoteBox = new NumericUpDown();
			this.label13 = new Label();
			((ISupportInitialize)this.OffsetBox).BeginInit();
			((ISupportInitialize)this.BandVolBox).BeginInit();
			((ISupportInitialize)this.GuitarVolBox).BeginInit();
			((ISupportInitialize)this.HammerOnBox).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.AeroGroupBox.SuspendLayout();
			((ISupportInitialize)this.BPM8NoteBox).BeginInit();
			base.SuspendLayout();
			this.YearTxt.Location = new Point(64, 66);
			this.YearTxt.Name = "YearTxt";
			this.YearTxt.Size = new Size(156, 20);
			this.YearTxt.TabIndex = 2;
			this.OffsetBox.Location = new Point(130, 175);
			NumericUpDown arg_2EA_0 = this.OffsetBox;
			int[] array = new int[4];
			array[0] = 30000;
			arg_2EA_0.Maximum = new decimal(array);
			this.OffsetBox.Minimum = new decimal(new int[]
			{
				30000,
				0,
				0,
				-2147483648
			});
			this.OffsetBox.Name = "OffsetBox";
			this.OffsetBox.Size = new Size(50, 20);
			this.OffsetBox.TabIndex = 9;
			this.TitleTxt.Location = new Point(63, 10);
			this.TitleTxt.Name = "TitleTxt";
			this.TitleTxt.Size = new Size(157, 20);
			this.TitleTxt.TabIndex = 0;
			this.SingerBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SingerBox.FormattingEnabled = true;
			this.SingerBox.Items.AddRange(new object[]
			{
				"No Singer",
				"Male",
				"Female"
			});
			this.SingerBox.Location = new Point(309, 10);
			this.SingerBox.Name = "SingerBox";
			this.SingerBox.Size = new Size(143, 21);
			this.SingerBox.TabIndex = 3;
			this.CountOffBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.CountOffBox.FormattingEnabled = true;
			this.CountOffBox.Items.AddRange(new object[]
			{
				"sticks_tiny",
				"sticks_normal",
				"sticks_huge",
				"hihat01",
				"hihat02",
				"hihat03",
				"shaker"
			});
			this.CountOffBox.Location = new Point(332, 38);
			this.CountOffBox.Name = "CountOffBox";
			this.CountOffBox.Size = new Size(120, 21);
			this.CountOffBox.TabIndex = 4;
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.Location = new Point(246, 37);
			this.label10.Name = "label10";
			this.label10.Size = new Size(80, 19);
			this.label10.TabIndex = 27;
			this.label10.Text = "Count Off:";
			this.label10.TextAlign = ContentAlignment.MiddleCenter;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.Location = new Point(246, 9);
			this.label9.Name = "label9";
			this.label9.Size = new Size(57, 19);
			this.label9.TabIndex = 26;
			this.label9.Text = "Singer:";
			this.label9.TextAlign = ContentAlignment.MiddleCenter;
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.Location = new Point(12, 65);
			this.label8.Name = "label8";
			this.label8.Size = new Size(46, 19);
			this.label8.TabIndex = 25;
			this.label8.Text = "Year:";
			this.label8.TextAlign = ContentAlignment.MiddleCenter;
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(12, 9);
			this.label6.Name = "label6";
			this.label6.Size = new Size(45, 19);
			this.label6.TabIndex = 23;
			this.label6.Text = "Title:";
			this.label6.TextAlign = ContentAlignment.MiddleCenter;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label7.Location = new Point(68, 176);
			this.label7.Name = "label7";
			this.label7.Size = new Size(56, 19);
			this.label7.TabIndex = 32;
			this.label7.Text = "Offset:";
			this.label7.TextAlign = ContentAlignment.MiddleCenter;
			this.ArtistTxt.Location = new Point(70, 38);
			this.ArtistTxt.Name = "ArtistTxt";
			this.ArtistTxt.Size = new Size(150, 20);
			this.ArtistTxt.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new Size(52, 19);
			this.label1.TabIndex = 24;
			this.label1.Text = "Artist:";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.BassistBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BassistBox.FormattingEnabled = true;
			this.BassistBox.Items.AddRange(new object[]
			{
				"Generic Bassist",
				"Axel",
				"Casey",
				"Izzy",
				"Judy",
				"Johnny",
				"Lars",
				"Midori",
				"Xavier",
				"Slash",
				"Morello",
				"Satan",
				"RockGod",
				"Ripper"
			});
			this.BassistBox.Location = new Point(315, 66);
			this.BassistBox.Name = "BassistBox";
			this.BassistBox.Size = new Size(137, 21);
			this.BassistBox.TabIndex = 5;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(246, 65);
			this.label2.Name = "label2";
			this.label2.Size = new Size(63, 19);
			this.label2.TabIndex = 28;
			this.label2.Text = "Bassist:";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			this.BandVolBox.DecimalPlaces = 2;
			this.BandVolBox.Increment = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			this.BandVolBox.Location = new Point(130, 124);
			NumericUpDown arg_A56_0 = this.BandVolBox;
			int[] array2 = new int[4];
			array2[0] = 5;
			arg_A56_0.Maximum = new decimal(array2);
			this.BandVolBox.Minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147483648
			});
			this.BandVolBox.Name = "BandVolBox";
			this.BandVolBox.ReadOnly = true;
			this.BandVolBox.Size = new Size(49, 20);
			this.BandVolBox.TabIndex = 7;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(20, 125);
			this.label3.Name = "label3";
			this.label3.Size = new Size(104, 19);
			this.label3.TabIndex = 30;
			this.label3.Text = "Band Volume:";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.GuitarVolBox.DecimalPlaces = 2;
			this.GuitarVolBox.Increment = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			this.GuitarVolBox.Location = new Point(130, 99);
			NumericUpDown arg_BB0_0 = this.GuitarVolBox;
			int[] array3 = new int[4];
			array3[0] = 5;
			arg_BB0_0.Maximum = new decimal(array3);
			this.GuitarVolBox.Minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147483648
			});
			this.GuitarVolBox.Name = "GuitarVolBox";
			this.GuitarVolBox.ReadOnly = true;
			this.GuitarVolBox.Size = new Size(49, 20);
			this.GuitarVolBox.TabIndex = 6;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(12, 100);
			this.label4.Name = "label4";
			this.label4.Size = new Size(112, 19);
			this.label4.TabIndex = 29;
			this.label4.Text = "Guitar Volume:";
			this.label4.TextAlign = ContentAlignment.MiddleCenter;
			this.HammerOnBox.DecimalPlaces = 2;
			this.HammerOnBox.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				131072
			});
			this.HammerOnBox.Location = new Point(130, 150);
			NumericUpDown arg_D0C_0 = this.HammerOnBox;
			int[] array4 = new int[4];
			array4[0] = 5;
			arg_D0C_0.Maximum = new decimal(array4);
			this.HammerOnBox.Minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147483648
			});
			this.HammerOnBox.Name = "HammerOnBox";
			this.HammerOnBox.ReadOnly = true;
			this.HammerOnBox.Size = new Size(49, 20);
			this.HammerOnBox.TabIndex = 8;
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(28, 151);
			this.label5.Name = "label5";
			this.label5.Size = new Size(96, 19);
			this.label5.TabIndex = 31;
			this.label5.Text = "Hammer On:";
			this.label5.TextAlign = ContentAlignment.MiddleCenter;
			this.ByBtn.AutoSize = true;
			this.ByBtn.Checked = true;
			this.ByBtn.Location = new Point(89, 14);
			this.ByBtn.Name = "ByBtn";
			this.ByBtn.Size = new Size(46, 17);
			this.ByBtn.TabIndex = 11;
			this.ByBtn.TabStop = true;
			this.ByBtn.Text = "\"by\"";
			this.ByBtn.UseVisualStyleBackColor = true;
			this.ByBtn.CheckedChanged += new EventHandler(this.ByBtn_CheckedChanged);
			this.FamousByBtn.AutoSize = true;
			this.FamousByBtn.Location = new Point(141, 14);
			this.FamousByBtn.Name = "FamousByBtn";
			this.FamousByBtn.Size = new Size(126, 17);
			this.FamousByBtn.TabIndex = 12;
			this.FamousByBtn.TabStop = true;
			this.FamousByBtn.Text = "\"as made famous by\"";
			this.FamousByBtn.UseVisualStyleBackColor = true;
			this.FamousByBtn.CheckedChanged += new EventHandler(this.FamousByBtn_CheckedChanged);
			this.CustomTxtBtn.AutoSize = true;
			this.CustomTxtBtn.Location = new Point(89, 43);
			this.CustomTxtBtn.Name = "CustomTxtBtn";
			this.CustomTxtBtn.Size = new Size(60, 17);
			this.CustomTxtBtn.TabIndex = 13;
			this.CustomTxtBtn.TabStop = true;
			this.CustomTxtBtn.Text = "Custom";
			this.CustomTxtBtn.UseVisualStyleBackColor = true;
			this.CustomTxtBtn.CheckedChanged += new EventHandler(this.CustomTxtBtn_CheckedChanged);
			this.ArtistTextBox.Enabled = false;
			this.ArtistTextBox.Location = new Point(155, 41);
			this.ArtistTextBox.Name = "ArtistTextBox";
			this.ArtistTextBox.Size = new Size(104, 20);
			this.ArtistTextBox.TabIndex = 14;
			this.label11.AutoSize = true;
			this.label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label11.Location = new Point(-4, 24);
			this.label11.Name = "label11";
			this.label11.Size = new Size(87, 19);
			this.label11.TabIndex = 34;
			this.label11.Text = "Artist Text:";
			this.label11.TextAlign = ContentAlignment.MiddleCenter;
			this.Original_CheckBox.AutoSize = true;
			this.Original_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Original_CheckBox.Location = new Point(16, 302);
			this.Original_CheckBox.Name = "Original_CheckBox";
			this.Original_CheckBox.Size = new Size(124, 23);
			this.Original_CheckBox.TabIndex = 15;
			this.Original_CheckBox.Text = "Original Artist";
			this.Original_CheckBox.UseVisualStyleBackColor = true;
			this.Rhythm_CheckBox.AutoSize = true;
			this.Rhythm_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Rhythm_CheckBox.Location = new Point(16, 331);
			this.Rhythm_CheckBox.Name = "Rhythm_CheckBox";
			this.Rhythm_CheckBox.Size = new Size(125, 23);
			this.Rhythm_CheckBox.TabIndex = 18;
			this.Rhythm_CheckBox.Text = "Rhythm Track";
			this.Rhythm_CheckBox.UseVisualStyleBackColor = true;
			this.Coop_CheckBox.AutoSize = true;
			this.Coop_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Coop_CheckBox.Location = new Point(246, 302);
			this.Coop_CheckBox.Name = "Coop_CheckBox";
			this.Coop_CheckBox.Size = new Size(63, 23);
			this.Coop_CheckBox.TabIndex = 17;
			this.Coop_CheckBox.Text = "Coop";
			this.Coop_CheckBox.UseVisualStyleBackColor = true;
			this.ApplyBtn.DialogResult = DialogResult.OK;
			this.ApplyBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.ApplyBtn.Location = new Point(318, 327);
			this.ApplyBtn.Name = "ApplyBtn";
			this.ApplyBtn.Size = new Size(65, 27);
			this.ApplyBtn.TabIndex = 21;
			this.ApplyBtn.Text = "Apply";
			this.ApplyBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			this.CancelBtn.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.CancelBtn.Location = new Point(389, 327);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new Size(65, 27);
			this.CancelBtn.TabIndex = 22;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.Keyboard_CheckBox.AutoSize = true;
			this.Keyboard_CheckBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Keyboard_CheckBox.Location = new Point(146, 302);
			this.Keyboard_CheckBox.Name = "Keyboard_CheckBox";
			this.Keyboard_CheckBox.Size = new Size(94, 23);
			this.Keyboard_CheckBox.TabIndex = 16;
			this.Keyboard_CheckBox.Text = "Keyboard";
			this.Keyboard_CheckBox.UseVisualStyleBackColor = true;
			this.BassBtn.AutoSize = true;
			this.BassBtn.Checked = true;
			this.BassBtn.Location = new Point(67, 3);
			this.BassBtn.Name = "BassBtn";
			this.BassBtn.Size = new Size(48, 17);
			this.BassBtn.TabIndex = 20;
			this.BassBtn.TabStop = true;
			this.BassBtn.Text = "Bass";
			this.BassBtn.UseVisualStyleBackColor = true;
			this.RhythmBtn.AutoSize = true;
			this.RhythmBtn.Location = new Point(0, 3);
			this.RhythmBtn.Name = "RhythmBtn";
			this.RhythmBtn.Size = new Size(61, 17);
			this.RhythmBtn.TabIndex = 19;
			this.RhythmBtn.TabStop = true;
			this.RhythmBtn.Text = "Rhythm";
			this.RhythmBtn.UseVisualStyleBackColor = true;
			this.BossBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BossBox.FormattingEnabled = true;
			this.BossBox.Items.AddRange(new object[]
			{
				"Not a boss battle"
			});
			this.BossBox.Location = new Point(315, 101);
			this.BossBox.Name = "BossBox";
			this.BossBox.Size = new Size(137, 21);
			this.BossBox.TabIndex = 10;
			this.label12.AutoSize = true;
			this.label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label12.Location = new Point(189, 100);
			this.label12.Name = "label12";
			this.label12.Size = new Size(120, 19);
			this.label12.TabIndex = 54;
			this.label12.Text = "Boss Properties:";
			this.label12.TextAlign = ContentAlignment.MiddleCenter;
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.ByBtn);
			this.panel1.Controls.Add(this.FamousByBtn);
			this.panel1.Controls.Add(this.CustomTxtBtn);
			this.panel1.Controls.Add(this.ArtistTextBox);
			this.panel1.Location = new Point(193, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(267, 68);
			this.panel1.TabIndex = 33;
			this.panel2.Controls.Add(this.RhythmBtn);
			this.panel2.Controls.Add(this.BassBtn);
			this.panel2.Location = new Point(146, 331);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(117, 23);
			this.panel2.TabIndex = 35;
			this.AeroGroupBox.Controls.Add(this.SingAnimPakTxt);
			this.AeroGroupBox.Controls.Add(this.label14);
			this.AeroGroupBox.Controls.Add(this.PerryMicBox);
			this.AeroGroupBox.Controls.Add(this.AeroGuitaristBox);
			this.AeroGroupBox.Controls.Add(this.BandBox);
			this.AeroGroupBox.Controls.Add(this.label16);
			this.AeroGroupBox.Controls.Add(this.CoveredTxt);
			this.AeroGroupBox.Controls.Add(this.label15);
			this.AeroGroupBox.Controls.Add(this.BPM8NoteBox);
			this.AeroGroupBox.Controls.Add(this.label13);
			this.AeroGroupBox.Location = new Point(3, 198);
			this.AeroGroupBox.Name = "AeroGroupBox";
			this.AeroGroupBox.Size = new Size(457, 98);
			this.AeroGroupBox.TabIndex = 55;
			this.AeroGroupBox.TabStop = false;
			this.AeroGroupBox.Text = "Aerosmith";
			this.SingAnimPakTxt.Location = new Point(174, 45);
			this.SingAnimPakTxt.Name = "SingAnimPakTxt";
			this.SingAnimPakTxt.Size = new Size(275, 20);
			this.SingAnimPakTxt.TabIndex = 41;
			this.label14.AutoSize = true;
			this.label14.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label14.Location = new Point(9, 46);
			this.label14.Name = "label14";
			this.label14.Size = new Size(159, 19);
			this.label14.TabIndex = 42;
			this.label14.Text = "Singer Animation Pak:";
			this.label14.TextAlign = ContentAlignment.MiddleCenter;
			this.PerryMicBox.AutoSize = true;
			this.PerryMicBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.PerryMicBox.Location = new Point(311, 71);
			this.PerryMicBox.Name = "PerryMicBox";
			this.PerryMicBox.Size = new Size(138, 23);
			this.PerryMicBox.TabIndex = 40;
			this.PerryMicBox.Text = "Perry Mic Stand";
			this.PerryMicBox.UseVisualStyleBackColor = true;
			this.AeroGuitaristBox.AutoSize = true;
			this.AeroGuitaristBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.AeroGuitaristBox.Location = new Point(218, 71);
			this.AeroGuitaristBox.Name = "AeroGuitaristBox";
			this.AeroGuitaristBox.Size = new Size(87, 23);
			this.AeroGuitaristBox.TabIndex = 39;
			this.AeroGuitaristBox.Text = "Guitarist";
			this.AeroGuitaristBox.UseVisualStyleBackColor = true;
			this.BandBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BandBox.FormattingEnabled = true;
			this.BandBox.Items.AddRange(new object[]
			{
				"default_band",
				"aerosmith_band_backinthesaddle",
				"aerosmith_band_beyondbeautiful",
				"aerosmith_band_brightlightfright",
				"aerosmith_band_combination",
				"aerosmith_band_drawtheline",
				"aerosmith_band_dreamon",
				"aerosmith_band_joeperrybossbattle",
				"dmc_band",
				"aerosmith_band_kingsandqueens",
				"aerosmith_band_letthemusicdothetalkin",
				"aerosmith_band_livinontheedge",
				"aerosmith_band_loveinanelevator",
				"aerosmith_band_makeit",
				"aerosmith_band_mamakin",
				"aerosmith_band_mercy",
				"aerosmith_band_movinout",
				"aerosmith_band_nobodysfault",
				"aerosmith_band_nosurprize",
				"aerosmith_band_pandorasbox",
				"aerosmith_band_pink",
				"aerosmith_band_ragdoll",
				"aerosmith_band_ratsinthecellar",
				"joeperryproject_band_shakinmycage",
				"aerosmith_band_miracas",
				"aerosmith_band_talktalkin",
				"aerosmith_band",
				"aerosmith_band_toysintheattic",
				"aerosmith_band_trainkeptarollin",
				"aerosmith_band_unclesalty",
				"aerosmith_band_walkthisway",
				"aerosmith_band_walkthiswaydmc"
			});
			this.BandBox.Location = new Point(298, 18);
			this.BandBox.Name = "BandBox";
			this.BandBox.Size = new Size(151, 21);
			this.BandBox.TabIndex = 37;
			this.label16.AutoSize = true;
			this.label16.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label16.Location = new Point(243, 20);
			this.label16.Name = "label16";
			this.label16.Size = new Size(49, 19);
			this.label16.TabIndex = 38;
			this.label16.Text = "Band:";
			this.label16.TextAlign = ContentAlignment.MiddleCenter;
			this.CoveredTxt.Location = new Point(109, 19);
			this.CoveredTxt.Name = "CoveredTxt";
			this.CoveredTxt.Size = new Size(108, 20);
			this.CoveredTxt.TabIndex = 35;
			this.label15.AutoSize = true;
			this.label15.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label15.Location = new Point(9, 20);
			this.label15.Name = "label15";
			this.label15.Size = new Size(94, 19);
			this.label15.TabIndex = 36;
			this.label15.Text = "Covered By:";
			this.label15.TextAlign = ContentAlignment.MiddleCenter;
			NumericUpDown arg_1D9F_0 = this.BPM8NoteBox;
			int[] array5 = new int[4];
			array5[0] = 5;
			arg_1D9F_0.Increment = new decimal(array5);
			this.BPM8NoteBox.Location = new Point(127, 71);
			NumericUpDown arg_1DD6_0 = this.BPM8NoteBox;
			int[] array6 = new int[4];
			array6[0] = 500;
			arg_1DD6_0.Maximum = new decimal(array6);
			this.BPM8NoteBox.Minimum = new decimal(new int[]
			{
				500,
				0,
				0,
				-2147483648
			});
			this.BPM8NoteBox.Name = "BPM8NoteBox";
			this.BPM8NoteBox.Size = new Size(49, 20);
			this.BPM8NoteBox.TabIndex = 32;
			this.label13.AutoSize = true;
			this.label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label13.Location = new Point(22, 72);
			this.label13.Name = "label13";
			this.label13.Size = new Size(99, 19);
			this.label13.TabIndex = 33;
			this.label13.Text = "8 Note BPM:";
			this.label13.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(466, 358);
			base.Controls.Add(this.Rhythm_CheckBox);
			base.Controls.Add(this.AeroGroupBox);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.BossBox);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.HammerOnBox);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.GuitarVolBox);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.BandVolBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.BassistBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.Keyboard_CheckBox);
			base.Controls.Add(this.ArtistTxt);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.ApplyBtn);
			base.Controls.Add(this.YearTxt);
			base.Controls.Add(this.OffsetBox);
			base.Controls.Add(this.TitleTxt);
			base.Controls.Add(this.SingerBox);
			base.Controls.Add(this.CountOffBox);
			base.Controls.Add(this.Coop_CheckBox);
			base.Controls.Add(this.Original_CheckBox);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label7);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SongProperties";
			this.Text = "Song Properties";
			((ISupportInitialize)this.OffsetBox).EndInit();
			((ISupportInitialize)this.BandVolBox).EndInit();
			((ISupportInitialize)this.GuitarVolBox).EndInit();
			((ISupportInitialize)this.HammerOnBox).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.AeroGroupBox.ResumeLayout(false);
			this.AeroGroupBox.PerformLayout();
			((ISupportInitialize)this.BPM8NoteBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
