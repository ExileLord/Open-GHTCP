using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuitarHero.Songlist;

namespace ns15
{
	public class SongProperties : Form
	{
		private readonly GH3Song Song;

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

		private CheckBox chkOriginal;

		private CheckBox chkRhythm;

		private CheckBox chkCoop;

		private Button btnApply;

		private Button btnCancel;

		private CheckBox chkKeyboard;

		private RadioButton rBtnBass;

		private RadioButton rBtnRhythm;

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

		public SongProperties(string songName)
		{
			InitializeComponent();
			Song = new GH3Song();
			Text = Text + " (" + songName + ")";
			SingerBox.SelectedIndex = 0;
			CountOffBox.SelectedIndex = 0;
			BassistBox.SelectedIndex = 0;
			BossBox.SelectedIndex = 0;
		}

		public SongProperties(GH3Song song) : this(song.name)
		{
			Song = song;
			if (Song is GHASong)
			{
				BassistBox.Enabled = false;
				BossBox.Items.Add("Joe Perry Props");
				BossBox.Items.Add("Tom Morello Props");
			}
			else
			{
				AeroGroupBox.Enabled = false;
				SingerBox.Items.Add("Bret Michaels");
				BossBox.Items.Add("Tom Morello Props");
				BossBox.Items.Add("Slash Props");
				BossBox.Items.Add("Lou Props");
			}
            btnApply.Enabled = true; // this.gh3Song_0.editable;
			TitleTxt.Text = Song.title;
			ArtistTxt.Text = Song.artist;
			YearTxt.Text = Song.year;
			chkOriginal.Checked = Song.original_artist;
			chkRhythm.Checked = !Song.no_rhythm_track;
			chkKeyboard.Checked = Song.keyboard;
			chkCoop.Checked = Song.use_coop_notetracks;
			rBtnBass.Checked = !(rBtnRhythm.Checked = Song.not_bass);
			if (Song.artist_text is bool)
			{
				FamousByBtn.Checked = !(ByBtn.Checked = (bool)Song.artist_text);
			}
			else
			{
				ArtistTextBox.Text = (string)Song.artist_text;
				CustomTxtBtn.Checked = true;
			}
			GuitarVolBox.Value = (decimal)Song.guitar_vol;
			BandVolBox.Value = (decimal)Song.band_vol;
			HammerOnBox.Value = (decimal)Song.hammer_on;
			OffsetBox.Value = Song.gem_offset;
			if (Song.singer.Equals(""))
			{
				SingerBox.SelectedIndex = 0;
			}
			else if (Song.singer.Equals("male"))
			{
				SingerBox.SelectedIndex = 1;
			}
			else if (Song.singer.Equals("female"))
			{
				SingerBox.SelectedIndex = 2;
			}
			else if (Song.singer.Equals("bret"))
			{
				SingerBox.SelectedItem = "Bret Michaels";
			}
			CountOffBox.SelectedItem = Song.countoff.ToLower();
			BassistBox.SelectedItem = Song.bassist;
			if (Song.boss.Equals(""))
			{
				BossBox.SelectedIndex = 0;
			}
			else if (Song.boss.Equals("boss_tommorello_props"))
			{
				BossBox.SelectedItem = "Tom Morello Props";
			}
			else if (Song.boss.Equals("boss_slash_props"))
			{
				BossBox.SelectedItem = "Slash Props";
			}
			else if (Song.boss.Equals("boss_devil_props"))
			{
				BossBox.SelectedItem = "Lou Props";
			}
			else if (Song.boss.Equals("boss_joe_props"))
			{
				BossBox.SelectedItem = "Joe Perry Props";
			}
			if (AeroGroupBox.Enabled)
			{
				var gHASong = (GHASong)Song;
				CoveredTxt.Text = gHASong.covered_by;
				SingAnimPakTxt.Text = gHASong.singer_anim_pak;
				BandBox.SelectedItem = gHASong.band;
				BPM8NoteBox.Value = gHASong.thin_fretbar_8note_params_high_bpm;
				AeroGuitaristBox.Checked = gHASong.guitarist_checksum;
				PerryMicBox.Checked = gHASong.perry_mic_stand;
			}
		}

        void btnApply_Click(Object sender, EventArgs e)
        {
            if ( !Song.isEditable() && (MainMenu.MsgBoxEditDefaultSongs() != DialogResult.Yes) )
            {
                DialogResult = DialogResult.None;
            }
        }

		public GH3Song GetSongWithChanges()
		{
			Song.title = TitleTxt.Text;
			Song.artist = ArtistTxt.Text;
			Song.year = YearTxt.Text;
			Song.original_artist = chkOriginal.Checked;
			Song.no_rhythm_track = !chkRhythm.Checked;
			Song.keyboard = chkKeyboard.Checked;
			Song.use_coop_notetracks = chkCoop.Checked;
			Song.not_bass = rBtnRhythm.Checked;
			if (CustomTxtBtn.Checked)
			{
				Song.artist_text = ArtistTextBox.Text;
			}
			else
			{
				Song.artist_text = ByBtn.Checked;
			}
			Song.guitar_vol = (float)GuitarVolBox.Value;
			Song.band_vol = (float)BandVolBox.Value;
			Song.hammer_on = (float)HammerOnBox.Value;
			Song.input_offset = (Song.gem_offset = (int)OffsetBox.Value);
			Song.singer = (new[]
			{
				"",
				"male",
				"female",
				"bret"
			})[SingerBox.SelectedIndex];
			Song.countoff = (string)CountOffBox.SelectedItem;
			Song.bassist = (string)BassistBox.SelectedItem;
			string a;
			if ((a = (string)BossBox.SelectedItem) != null)
			{
				if (!(a == "Tom Morello Props"))
				{
					if (!(a == "Slash Props"))
					{
						if (!(a == "Lou Props"))
						{
							if (a == "Joe Perry Props")
							{
								Song.boss = "boss_joe_props";
							}
						}
						else
						{
							Song.boss = "boss_devil_props";
						}
					}
					else
					{
						Song.boss = "boss_slash_props";
					}
				}
				else
				{
					Song.boss = "boss_tommorello_props";
				}
			}
			if (Song is GHASong)
			{
				var song = (GHASong)Song;
				song.covered_by = CoveredTxt.Text;
				song.singer_anim_pak = SingAnimPakTxt.Text;
				song.band = (string)BandBox.SelectedItem;
				BPM8NoteBox.Value = song.thin_fretbar_8note_params_high_bpm;
				AeroGuitaristBox.Checked = song.guitarist_checksum;
				PerryMicBox.Checked = song.perry_mic_stand;
			}
			return Song;
		}

		private void ByBtn_CheckedChanged(object sender, EventArgs e)
		{
			ArtistTextBox.Enabled = false;
		}

		private void FamousByBtn_CheckedChanged(object sender, EventArgs e)
		{
			ArtistTextBox.Enabled = false;
		}

		private void CustomTxtBtn_CheckedChanged(object sender, EventArgs e)
		{
			ArtistTextBox.Enabled = true;
		}

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
			YearTxt = new TextBox();
			OffsetBox = new NumericUpDown();
			TitleTxt = new TextBox();
			SingerBox = new ComboBox();
			CountOffBox = new ComboBox();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label6 = new Label();
			label7 = new Label();
			ArtistTxt = new TextBox();
			label1 = new Label();
			BassistBox = new ComboBox();
			label2 = new Label();
			BandVolBox = new NumericUpDown();
			label3 = new Label();
			GuitarVolBox = new NumericUpDown();
			label4 = new Label();
			HammerOnBox = new NumericUpDown();
			label5 = new Label();
			ByBtn = new RadioButton();
			FamousByBtn = new RadioButton();
			CustomTxtBtn = new RadioButton();
			ArtistTextBox = new TextBox();
			label11 = new Label();
			chkOriginal = new CheckBox();
			chkRhythm = new CheckBox();
			chkCoop = new CheckBox();
			btnApply = new Button();
			btnCancel = new Button();
			chkKeyboard = new CheckBox();
			rBtnBass = new RadioButton();
			rBtnRhythm = new RadioButton();
			BossBox = new ComboBox();
			label12 = new Label();
			panel1 = new Panel();
			panel2 = new Panel();
			AeroGroupBox = new GroupBox();
			SingAnimPakTxt = new TextBox();
			label14 = new Label();
			PerryMicBox = new CheckBox();
			AeroGuitaristBox = new CheckBox();
			BandBox = new ComboBox();
			label16 = new Label();
			CoveredTxt = new TextBox();
			label15 = new Label();
			BPM8NoteBox = new NumericUpDown();
			label13 = new Label();
			((ISupportInitialize)OffsetBox).BeginInit();
			((ISupportInitialize)BandVolBox).BeginInit();
			((ISupportInitialize)GuitarVolBox).BeginInit();
			((ISupportInitialize)HammerOnBox).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			AeroGroupBox.SuspendLayout();
			((ISupportInitialize)BPM8NoteBox).BeginInit();
			SuspendLayout();
			YearTxt.Location = new Point(64, 66);
			YearTxt.Name = "YearTxt";
			YearTxt.Size = new Size(156, 20);
			YearTxt.TabIndex = 2;
			OffsetBox.Location = new Point(130, 175);
			var arg_2EA_0 = OffsetBox;
			var array = new int[4];
			array[0] = 30000;
			arg_2EA_0.Maximum = new decimal(array);
			OffsetBox.Minimum = new decimal(new[]
			{
				30000,
				0,
				0,
				-2147483648
			});
			OffsetBox.Name = "OffsetBox";
			OffsetBox.Size = new Size(50, 20);
			OffsetBox.TabIndex = 9;
			TitleTxt.Location = new Point(63, 10);
			TitleTxt.Name = "TitleTxt";
			TitleTxt.Size = new Size(157, 20);
			TitleTxt.TabIndex = 0;
			SingerBox.DropDownStyle = ComboBoxStyle.DropDownList;
			SingerBox.FormattingEnabled = true;
			SingerBox.Items.AddRange(new object[]
			{
				"No Singer",
				"Male",
				"Female"
			});
			SingerBox.Location = new Point(309, 10);
			SingerBox.Name = "SingerBox";
			SingerBox.Size = new Size(143, 21);
			SingerBox.TabIndex = 3;
			CountOffBox.DropDownStyle = ComboBoxStyle.DropDownList;
			CountOffBox.FormattingEnabled = true;
			CountOffBox.Items.AddRange(new object[]
			{
				"sticks_tiny",
				"sticks_normal",
				"sticks_huge",
				"hihat01",
				"hihat02",
				"hihat03",
				"shaker"
			});
			CountOffBox.Location = new Point(332, 38);
			CountOffBox.Name = "CountOffBox";
			CountOffBox.Size = new Size(120, 21);
			CountOffBox.TabIndex = 4;
			label10.AutoSize = true;
			label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.Location = new Point(246, 37);
			label10.Name = "label10";
			label10.Size = new Size(80, 19);
			label10.TabIndex = 27;
			label10.Text = "Count Off:";
			label10.TextAlign = ContentAlignment.MiddleCenter;
			label9.AutoSize = true;
			label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.Location = new Point(246, 9);
			label9.Name = "label9";
			label9.Size = new Size(57, 19);
			label9.TabIndex = 26;
			label9.Text = "Singer:";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(12, 65);
			label8.Name = "label8";
			label8.Size = new Size(46, 19);
			label8.TabIndex = 25;
			label8.Text = "Year:";
			label8.TextAlign = ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(12, 9);
			label6.Name = "label6";
			label6.Size = new Size(45, 19);
			label6.TabIndex = 23;
			label6.Text = "Title:";
			label6.TextAlign = ContentAlignment.MiddleCenter;
			label7.AutoSize = true;
			label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(68, 176);
			label7.Name = "label7";
			label7.Size = new Size(56, 19);
			label7.TabIndex = 32;
			label7.Text = "Offset:";
			label7.TextAlign = ContentAlignment.MiddleCenter;
			ArtistTxt.Location = new Point(70, 38);
			ArtistTxt.Name = "ArtistTxt";
			ArtistTxt.Size = new Size(150, 20);
			ArtistTxt.TabIndex = 1;
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 37);
			label1.Name = "label1";
			label1.Size = new Size(52, 19);
			label1.TabIndex = 24;
			label1.Text = "Artist:";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			BassistBox.DropDownStyle = ComboBoxStyle.DropDownList;
			BassistBox.FormattingEnabled = true;
			BassistBox.Items.AddRange(new object[]
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
			BassistBox.Location = new Point(315, 66);
			BassistBox.Name = "BassistBox";
			BassistBox.Size = new Size(137, 21);
			BassistBox.TabIndex = 5;
			label2.AutoSize = true;
			label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(246, 65);
			label2.Name = "label2";
			label2.Size = new Size(63, 19);
			label2.TabIndex = 28;
			label2.Text = "Bassist:";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			BandVolBox.DecimalPlaces = 2;
			BandVolBox.Increment = new decimal(new[]
			{
				25,
				0,
				0,
				131072
			});
			BandVolBox.Location = new Point(130, 124);
			var arg_A56_0 = BandVolBox;
			var array2 = new int[4];
			array2[0] = 5;
			arg_A56_0.Maximum = new decimal(array2);
			BandVolBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			BandVolBox.Name = "BandVolBox";
			BandVolBox.ReadOnly = true;
			BandVolBox.Size = new Size(49, 20);
			BandVolBox.TabIndex = 7;
			label3.AutoSize = true;
			label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(20, 125);
			label3.Name = "label3";
			label3.Size = new Size(104, 19);
			label3.TabIndex = 30;
			label3.Text = "Band Volume:";
			label3.TextAlign = ContentAlignment.MiddleCenter;
			GuitarVolBox.DecimalPlaces = 2;
			GuitarVolBox.Increment = new decimal(new[]
			{
				25,
				0,
				0,
				131072
			});
			GuitarVolBox.Location = new Point(130, 99);
			var arg_BB0_0 = GuitarVolBox;
			var array3 = new int[4];
			array3[0] = 5;
			arg_BB0_0.Maximum = new decimal(array3);
			GuitarVolBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			GuitarVolBox.Name = "GuitarVolBox";
			GuitarVolBox.ReadOnly = true;
			GuitarVolBox.Size = new Size(49, 20);
			GuitarVolBox.TabIndex = 6;
			label4.AutoSize = true;
			label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(12, 100);
			label4.Name = "label4";
			label4.Size = new Size(112, 19);
			label4.TabIndex = 29;
			label4.Text = "Guitar Volume:";
			label4.TextAlign = ContentAlignment.MiddleCenter;
			HammerOnBox.DecimalPlaces = 2;
			HammerOnBox.Increment = new decimal(new[]
			{
				5,
				0,
				0,
				131072
			});
			HammerOnBox.Location = new Point(130, 150);
			var arg_D0C_0 = HammerOnBox;
			var array4 = new int[4];
			array4[0] = 5;
			arg_D0C_0.Maximum = new decimal(array4);
			HammerOnBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			HammerOnBox.Name = "HammerOnBox";
			HammerOnBox.ReadOnly = true;
			HammerOnBox.Size = new Size(49, 20);
			HammerOnBox.TabIndex = 8;
			label5.AutoSize = true;
			label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(28, 151);
			label5.Name = "label5";
			label5.Size = new Size(96, 19);
			label5.TabIndex = 31;
			label5.Text = "Hammer On:";
			label5.TextAlign = ContentAlignment.MiddleCenter;
			ByBtn.AutoSize = true;
			ByBtn.Checked = true;
			ByBtn.Location = new Point(89, 14);
			ByBtn.Name = "ByBtn";
			ByBtn.Size = new Size(46, 17);
			ByBtn.TabIndex = 11;
			ByBtn.TabStop = true;
			ByBtn.Text = "\"by\"";
			ByBtn.UseVisualStyleBackColor = true;
			ByBtn.CheckedChanged += ByBtn_CheckedChanged;
			FamousByBtn.AutoSize = true;
			FamousByBtn.Location = new Point(141, 14);
			FamousByBtn.Name = "FamousByBtn";
			FamousByBtn.Size = new Size(126, 17);
			FamousByBtn.TabIndex = 12;
			FamousByBtn.TabStop = true;
			FamousByBtn.Text = "\"as made famous by\"";
			FamousByBtn.UseVisualStyleBackColor = true;
			FamousByBtn.CheckedChanged += FamousByBtn_CheckedChanged;
			CustomTxtBtn.AutoSize = true;
			CustomTxtBtn.Location = new Point(89, 43);
			CustomTxtBtn.Name = "CustomTxtBtn";
			CustomTxtBtn.Size = new Size(60, 17);
			CustomTxtBtn.TabIndex = 13;
			CustomTxtBtn.TabStop = true;
			CustomTxtBtn.Text = "Custom";
			CustomTxtBtn.UseVisualStyleBackColor = true;
			CustomTxtBtn.CheckedChanged += CustomTxtBtn_CheckedChanged;
			ArtistTextBox.Enabled = false;
			ArtistTextBox.Location = new Point(155, 41);
			ArtistTextBox.Name = "ArtistTextBox";
			ArtistTextBox.Size = new Size(104, 20);
			ArtistTextBox.TabIndex = 14;
			label11.AutoSize = true;
			label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(-4, 24);
			label11.Name = "label11";
			label11.Size = new Size(87, 19);
			label11.TabIndex = 34;
			label11.Text = "Artist Text:";
			label11.TextAlign = ContentAlignment.MiddleCenter;
			chkOriginal.AutoSize = true;
			chkOriginal.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			chkOriginal.Location = new Point(16, 302);
			chkOriginal.Name = "Original_CheckBox";
			chkOriginal.Size = new Size(124, 23);
			chkOriginal.TabIndex = 15;
			chkOriginal.Text = "Original Artist";
			chkOriginal.UseVisualStyleBackColor = true;

			chkRhythm.AutoSize = true;
			chkRhythm.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			chkRhythm.Location = new Point(16, 331);
			chkRhythm.Name = "Rhythm_CheckBox";
			chkRhythm.Size = new Size(125, 23);
			chkRhythm.TabIndex = 18;
			chkRhythm.Text = "Rhythm Track";
			chkRhythm.UseVisualStyleBackColor = true;

			chkCoop.AutoSize = true;
			chkCoop.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			chkCoop.Location = new Point(246, 302);
			chkCoop.Name = "Coop_CheckBox";
			chkCoop.Size = new Size(63, 23);
			chkCoop.TabIndex = 17;
			chkCoop.Text = "Coop";
			chkCoop.UseVisualStyleBackColor = true;

            btnApply.Click += btnApply_Click;
			btnApply.DialogResult = DialogResult.OK;
			btnApply.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnApply.Location = new Point(318, 327);
			btnApply.Name = "ApplyBtn";
			btnApply.Size = new Size(65, 27);
			btnApply.TabIndex = 21;
			btnApply.Text = "Apply";
			btnApply.UseVisualStyleBackColor = true;

			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCancel.Location = new Point(389, 327);
			btnCancel.Name = "CancelBtn";
			btnCancel.Size = new Size(65, 27);
			btnCancel.TabIndex = 22;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;

			chkKeyboard.AutoSize = true;
			chkKeyboard.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			chkKeyboard.Location = new Point(146, 302);
			chkKeyboard.Name = "Keyboard_CheckBox";
			chkKeyboard.Size = new Size(94, 23);
			chkKeyboard.TabIndex = 16;
			chkKeyboard.Text = "Keyboard";
			chkKeyboard.UseVisualStyleBackColor = true;

			rBtnBass.AutoSize = true;
			rBtnBass.Checked = true;
			rBtnBass.Location = new Point(67, 3);
			rBtnBass.Name = "BassBtn";
			rBtnBass.Size = new Size(48, 17);
			rBtnBass.TabIndex = 20;
			rBtnBass.TabStop = true;
			rBtnBass.Text = "Bass";
			rBtnBass.UseVisualStyleBackColor = true;

			rBtnRhythm.AutoSize = true;
			rBtnRhythm.Location = new Point(0, 3);
			rBtnRhythm.Name = "RhythmBtn";
			rBtnRhythm.Size = new Size(61, 17);
			rBtnRhythm.TabIndex = 19;
			rBtnRhythm.TabStop = true;
			rBtnRhythm.Text = "Rhythm";
			rBtnRhythm.UseVisualStyleBackColor = true;

			BossBox.DropDownStyle = ComboBoxStyle.DropDownList;
			BossBox.FormattingEnabled = true;
			BossBox.Items.AddRange(new object[]
			{
				"Not a boss battle"
			});
			BossBox.Location = new Point(315, 101);
			BossBox.Name = "BossBox";
			BossBox.Size = new Size(137, 21);
			BossBox.TabIndex = 10;

			label12.AutoSize = true;
			label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.Location = new Point(189, 100);
			label12.Name = "label12";
			label12.Size = new Size(120, 19);
			label12.TabIndex = 54;
			label12.Text = "Boss Properties:";
			label12.TextAlign = ContentAlignment.MiddleCenter;

			panel1.Controls.Add(label11);
			panel1.Controls.Add(ByBtn);
			panel1.Controls.Add(FamousByBtn);
			panel1.Controls.Add(CustomTxtBtn);
			panel1.Controls.Add(ArtistTextBox);
			panel1.Location = new Point(193, 127);
			panel1.Name = "panel1";
			panel1.Size = new Size(267, 68);
			panel1.TabIndex = 33;

			panel2.Controls.Add(rBtnRhythm);
			panel2.Controls.Add(rBtnBass);
			panel2.Location = new Point(146, 331);
			panel2.Name = "panel2";
			panel2.Size = new Size(117, 23);
			panel2.TabIndex = 35;

			AeroGroupBox.Controls.Add(SingAnimPakTxt);
			AeroGroupBox.Controls.Add(label14);
			AeroGroupBox.Controls.Add(PerryMicBox);
			AeroGroupBox.Controls.Add(AeroGuitaristBox);
			AeroGroupBox.Controls.Add(BandBox);
			AeroGroupBox.Controls.Add(label16);
			AeroGroupBox.Controls.Add(CoveredTxt);
			AeroGroupBox.Controls.Add(label15);
			AeroGroupBox.Controls.Add(BPM8NoteBox);
			AeroGroupBox.Controls.Add(label13);
			AeroGroupBox.Location = new Point(3, 198);
			AeroGroupBox.Name = "AeroGroupBox";
			AeroGroupBox.Size = new Size(457, 98);
			AeroGroupBox.TabIndex = 55;
			AeroGroupBox.TabStop = false;
			AeroGroupBox.Text = "Aerosmith";

			SingAnimPakTxt.Location = new Point(174, 45);
			SingAnimPakTxt.Name = "SingAnimPakTxt";
			SingAnimPakTxt.Size = new Size(275, 20);
			SingAnimPakTxt.TabIndex = 41;
			label14.AutoSize = true;
			label14.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(9, 46);
			label14.Name = "label14";
			label14.Size = new Size(159, 19);
			label14.TabIndex = 42;
			label14.Text = "Singer Animation Pak:";
			label14.TextAlign = ContentAlignment.MiddleCenter;
			PerryMicBox.AutoSize = true;
			PerryMicBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			PerryMicBox.Location = new Point(311, 71);
			PerryMicBox.Name = "PerryMicBox";
			PerryMicBox.Size = new Size(138, 23);
			PerryMicBox.TabIndex = 40;
			PerryMicBox.Text = "Perry Mic Stand";
			PerryMicBox.UseVisualStyleBackColor = true;
			AeroGuitaristBox.AutoSize = true;
			AeroGuitaristBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			AeroGuitaristBox.Location = new Point(218, 71);
			AeroGuitaristBox.Name = "AeroGuitaristBox";
			AeroGuitaristBox.Size = new Size(87, 23);
			AeroGuitaristBox.TabIndex = 39;
			AeroGuitaristBox.Text = "Guitarist";
			AeroGuitaristBox.UseVisualStyleBackColor = true;
			BandBox.DropDownStyle = ComboBoxStyle.DropDownList;
			BandBox.FormattingEnabled = true;
			BandBox.Items.AddRange(new object[]
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
			BandBox.Location = new Point(298, 18);
			BandBox.Name = "BandBox";
			BandBox.Size = new Size(151, 21);
			BandBox.TabIndex = 37;
			label16.AutoSize = true;
			label16.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label16.Location = new Point(243, 20);
			label16.Name = "label16";
			label16.Size = new Size(49, 19);
			label16.TabIndex = 38;
			label16.Text = "Band:";
			label16.TextAlign = ContentAlignment.MiddleCenter;
			CoveredTxt.Location = new Point(109, 19);
			CoveredTxt.Name = "CoveredTxt";
			CoveredTxt.Size = new Size(108, 20);
			CoveredTxt.TabIndex = 35;
			label15.AutoSize = true;
			label15.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label15.Location = new Point(9, 20);
			label15.Name = "label15";
			label15.Size = new Size(94, 19);
			label15.TabIndex = 36;
			label15.Text = "Covered By:";
			label15.TextAlign = ContentAlignment.MiddleCenter;
			var arg_1D9F_0 = BPM8NoteBox;
			var array5 = new int[4];
			array5[0] = 5;
			arg_1D9F_0.Increment = new decimal(array5);
			BPM8NoteBox.Location = new Point(127, 71);
			var arg_1DD6_0 = BPM8NoteBox;
			var array6 = new int[4];
			array6[0] = 500;
			arg_1DD6_0.Maximum = new decimal(array6);
			BPM8NoteBox.Minimum = new decimal(new[]
			{
				500,
				0,
				0,
				-2147483648
			});
			BPM8NoteBox.Name = "BPM8NoteBox";
			BPM8NoteBox.Size = new Size(49, 20);
			BPM8NoteBox.TabIndex = 32;
			label13.AutoSize = true;
			label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.Location = new Point(22, 72);
			label13.Name = "label13";
			label13.Size = new Size(99, 19);
			label13.TabIndex = 33;
			label13.Text = "8 Note BPM:";
			label13.TextAlign = ContentAlignment.MiddleCenter;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(466, 358);
			Controls.Add(chkRhythm);
			Controls.Add(AeroGroupBox);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(BossBox);
			Controls.Add(label12);
			Controls.Add(HammerOnBox);
			Controls.Add(label5);
			Controls.Add(GuitarVolBox);
			Controls.Add(label4);
			Controls.Add(BandVolBox);
			Controls.Add(label3);
			Controls.Add(BassistBox);
			Controls.Add(label2);
			Controls.Add(chkKeyboard);
			Controls.Add(ArtistTxt);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnApply);
			Controls.Add(YearTxt);
			Controls.Add(OffsetBox);
			Controls.Add(TitleTxt);
			Controls.Add(SingerBox);
			Controls.Add(CountOffBox);
			Controls.Add(chkCoop);
			Controls.Add(chkOriginal);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label6);
			Controls.Add(label7);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SongProperties";
			Text = "Song Properties";
			((ISupportInitialize)OffsetBox).EndInit();
			((ISupportInitialize)BandVolBox).EndInit();
			((ISupportInitialize)GuitarVolBox).EndInit();
			((ISupportInitialize)HammerOnBox).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			AeroGroupBox.ResumeLayout(false);
			AeroGroupBox.PerformLayout();
			((ISupportInitialize)BPM8NoteBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
    }
}
