using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GuitarHero.Songlist;

namespace ns15
{
	public class SongProperties : Form
	{
		private readonly Gh3Song _song;

		private IContainer icontainer_0;

		private TextBox _yearTxt;

		private NumericUpDown _offsetBox;

		private TextBox _titleTxt;

		private ComboBox _singerBox;

		private ComboBox _countOffBox;

		private Label _label10;

		private Label _label9;

		private Label _label8;

		private Label _label6;

		private Label _label7;

		private TextBox _artistTxt;

		private Label _label1;

		private ComboBox _bassistBox;

		private Label _label2;

		private NumericUpDown _bandVolBox;

		private Label _label3;

		private Label _label4;

		private NumericUpDown _hammerOnBox;

		private Label _label5;

		private RadioButton _byBtn;

		private RadioButton _famousByBtn;

		private RadioButton _customTxtBtn;

		private TextBox _artistTextBox;

		private Label _label11;

		private CheckBox _chkOriginal;

		private CheckBox _chkRhythm;

		private CheckBox _chkCoop;

		private Button _btnApply;

		private Button _btnCancel;

		private CheckBox _chkKeyboard;

		private RadioButton _rBtnBass;

		private RadioButton _rBtnRhythm;

		private ComboBox _bossBox;

		private Label _label12;

		private Panel _panel1;

		private Panel _panel2;

		private NumericUpDown _guitarVolBox;

		private GroupBox _aeroGroupBox;

		private NumericUpDown _bpm8NoteBox;

		private Label _label13;

		private TextBox _coveredTxt;

		private Label _label15;

		private ComboBox _bandBox;

		private Label _label16;

		private CheckBox _aeroGuitaristBox;

		private CheckBox _perryMicBox;

		private TextBox _singAnimPakTxt;

		private Label _label14;

		public SongProperties(string songName)
		{
			InitializeComponent();
			_song = new Gh3Song();
			Text = Text + " (" + songName + ")";
			_singerBox.SelectedIndex = 0;
			_countOffBox.SelectedIndex = 0;
			_bassistBox.SelectedIndex = 0;
			_bossBox.SelectedIndex = 0;
		}

		public SongProperties(Gh3Song song) : this(song.Name)
		{
			_song = song;
			if (_song is GhaSong)
			{
				_bassistBox.Enabled = false;
				_bossBox.Items.Add("Joe Perry Props");
				_bossBox.Items.Add("Tom Morello Props");
			}
			else
			{
				_aeroGroupBox.Enabled = false;
				_singerBox.Items.Add("Bret Michaels");
				_bossBox.Items.Add("Tom Morello Props");
				_bossBox.Items.Add("Slash Props");
				_bossBox.Items.Add("Lou Props");
			}
            _btnApply.Enabled = true; // this.gh3Song_0.editable;
			_titleTxt.Text = _song.Title;
			_artistTxt.Text = _song.Artist;
			_yearTxt.Text = _song.Year;
			_chkOriginal.Checked = _song.OriginalArtist;
			_chkRhythm.Checked = !_song.NoRhythmTrack;
			_chkKeyboard.Checked = _song.Keyboard;
			_chkCoop.Checked = _song.UseCoopNotetracks;
			_rBtnBass.Checked = !(_rBtnRhythm.Checked = _song.NotBass);
			if (_song.ArtistText is bool)
			{
				_famousByBtn.Checked = !(_byBtn.Checked = (bool)_song.ArtistText);
			}
			else
			{
				_artistTextBox.Text = (string)_song.ArtistText;
				_customTxtBtn.Checked = true;
			}
			_guitarVolBox.Value = (decimal)_song.GuitarVol;
			_bandVolBox.Value = (decimal)_song.BandVol;
			_hammerOnBox.Value = (decimal)_song.HammerOn;
			_offsetBox.Value = _song.GemOffset;
			if (_song.Singer.Equals(""))
			{
				_singerBox.SelectedIndex = 0;
			}
			else if (_song.Singer.Equals("male"))
			{
				_singerBox.SelectedIndex = 1;
			}
			else if (_song.Singer.Equals("female"))
			{
				_singerBox.SelectedIndex = 2;
			}
			else if (_song.Singer.Equals("bret"))
			{
				_singerBox.SelectedItem = "Bret Michaels";
			}
			_countOffBox.SelectedItem = _song.Countoff.ToLower();
			_bassistBox.SelectedItem = _song.Bassist;
			if (_song.Boss.Equals(""))
			{
				_bossBox.SelectedIndex = 0;
			}
			else if (_song.Boss.Equals("boss_tommorello_props"))
			{
				_bossBox.SelectedItem = "Tom Morello Props";
			}
			else if (_song.Boss.Equals("boss_slash_props"))
			{
				_bossBox.SelectedItem = "Slash Props";
			}
			else if (_song.Boss.Equals("boss_devil_props"))
			{
				_bossBox.SelectedItem = "Lou Props";
			}
			else if (_song.Boss.Equals("boss_joe_props"))
			{
				_bossBox.SelectedItem = "Joe Perry Props";
			}
			if (_aeroGroupBox.Enabled)
			{
				var gHaSong = (GhaSong)_song;
				_coveredTxt.Text = gHaSong.CoveredBy;
				_singAnimPakTxt.Text = gHaSong.SingerAnimPak;
				_bandBox.SelectedItem = gHaSong.Band;
				_bpm8NoteBox.Value = gHaSong.ThinFretbar_8NoteParamsHighBpm;
				_aeroGuitaristBox.Checked = gHaSong.GuitaristChecksum;
				_perryMicBox.Checked = gHaSong.PerryMicStand;
			}
		}

        void btnApply_Click(Object sender, EventArgs e)
        {
            if ( !_song.IsEditable() && (MainMenu.MsgBoxEditDefaultSongs() != DialogResult.Yes) )
            {
                DialogResult = DialogResult.None;
            }
        }

		public Gh3Song GetSongWithChanges()
		{
			_song.Title = _titleTxt.Text;
			_song.Artist = _artistTxt.Text;
			_song.Year = _yearTxt.Text;
			_song.OriginalArtist = _chkOriginal.Checked;
			_song.NoRhythmTrack = !_chkRhythm.Checked;
			_song.Keyboard = _chkKeyboard.Checked;
			_song.UseCoopNotetracks = _chkCoop.Checked;
			_song.NotBass = _rBtnRhythm.Checked;
			if (_customTxtBtn.Checked)
			{
				_song.ArtistText = _artistTextBox.Text;
			}
			else
			{
				_song.ArtistText = _byBtn.Checked;
			}
			_song.GuitarVol = (float)_guitarVolBox.Value;
			_song.BandVol = (float)_bandVolBox.Value;
			_song.HammerOn = (float)_hammerOnBox.Value;
			_song.InputOffset = (_song.GemOffset = (int)_offsetBox.Value);
			_song.Singer = (new[]
			{
				"",
				"male",
				"female",
				"bret"
			})[_singerBox.SelectedIndex];
			_song.Countoff = (string)_countOffBox.SelectedItem;
			_song.Bassist = (string)_bassistBox.SelectedItem;
			string a;
			if ((a = (string)_bossBox.SelectedItem) != null)
			{
				if (!(a == "Tom Morello Props"))
				{
					if (!(a == "Slash Props"))
					{
						if (!(a == "Lou Props"))
						{
							if (a == "Joe Perry Props")
							{
								_song.Boss = "boss_joe_props";
							}
						}
						else
						{
							_song.Boss = "boss_devil_props";
						}
					}
					else
					{
						_song.Boss = "boss_slash_props";
					}
				}
				else
				{
					_song.Boss = "boss_tommorello_props";
				}
			}
			if (_song is GhaSong)
			{
				var song = (GhaSong)_song;
				song.CoveredBy = _coveredTxt.Text;
				song.SingerAnimPak = _singAnimPakTxt.Text;
				song.Band = (string)_bandBox.SelectedItem;
				_bpm8NoteBox.Value = song.ThinFretbar_8NoteParamsHighBpm;
				_aeroGuitaristBox.Checked = song.GuitaristChecksum;
				_perryMicBox.Checked = song.PerryMicStand;
			}
			return _song;
		}

		private void ByBtn_CheckedChanged(object sender, EventArgs e)
		{
			_artistTextBox.Enabled = false;
		}

		private void FamousByBtn_CheckedChanged(object sender, EventArgs e)
		{
			_artistTextBox.Enabled = false;
		}

		private void CustomTxtBtn_CheckedChanged(object sender, EventArgs e)
		{
			_artistTextBox.Enabled = true;
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
			_yearTxt = new TextBox();
			_offsetBox = new NumericUpDown();
			_titleTxt = new TextBox();
			_singerBox = new ComboBox();
			_countOffBox = new ComboBox();
			_label10 = new Label();
			_label9 = new Label();
			_label8 = new Label();
			_label6 = new Label();
			_label7 = new Label();
			_artistTxt = new TextBox();
			_label1 = new Label();
			_bassistBox = new ComboBox();
			_label2 = new Label();
			_bandVolBox = new NumericUpDown();
			_label3 = new Label();
			_guitarVolBox = new NumericUpDown();
			_label4 = new Label();
			_hammerOnBox = new NumericUpDown();
			_label5 = new Label();
			_byBtn = new RadioButton();
			_famousByBtn = new RadioButton();
			_customTxtBtn = new RadioButton();
			_artistTextBox = new TextBox();
			_label11 = new Label();
			_chkOriginal = new CheckBox();
			_chkRhythm = new CheckBox();
			_chkCoop = new CheckBox();
			_btnApply = new Button();
			_btnCancel = new Button();
			_chkKeyboard = new CheckBox();
			_rBtnBass = new RadioButton();
			_rBtnRhythm = new RadioButton();
			_bossBox = new ComboBox();
			_label12 = new Label();
			_panel1 = new Panel();
			_panel2 = new Panel();
			_aeroGroupBox = new GroupBox();
			_singAnimPakTxt = new TextBox();
			_label14 = new Label();
			_perryMicBox = new CheckBox();
			_aeroGuitaristBox = new CheckBox();
			_bandBox = new ComboBox();
			_label16 = new Label();
			_coveredTxt = new TextBox();
			_label15 = new Label();
			_bpm8NoteBox = new NumericUpDown();
			_label13 = new Label();
			((ISupportInitialize)_offsetBox).BeginInit();
			((ISupportInitialize)_bandVolBox).BeginInit();
			((ISupportInitialize)_guitarVolBox).BeginInit();
			((ISupportInitialize)_hammerOnBox).BeginInit();
			_panel1.SuspendLayout();
			_panel2.SuspendLayout();
			_aeroGroupBox.SuspendLayout();
			((ISupportInitialize)_bpm8NoteBox).BeginInit();
			SuspendLayout();
			_yearTxt.Location = new Point(64, 66);
			_yearTxt.Name = "_yearTxt";
			_yearTxt.Size = new Size(156, 20);
			_yearTxt.TabIndex = 2;
			_offsetBox.Location = new Point(130, 175);
			var arg_2Ea0 = _offsetBox;
			var array = new int[4];
			array[0] = 30000;
			arg_2Ea0.Maximum = new decimal(array);
			_offsetBox.Minimum = new decimal(new[]
			{
				30000,
				0,
				0,
				-2147483648
			});
			_offsetBox.Name = "_offsetBox";
			_offsetBox.Size = new Size(50, 20);
			_offsetBox.TabIndex = 9;
			_titleTxt.Location = new Point(63, 10);
			_titleTxt.Name = "_titleTxt";
			_titleTxt.Size = new Size(157, 20);
			_titleTxt.TabIndex = 0;
			_singerBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_singerBox.FormattingEnabled = true;
			_singerBox.Items.AddRange(new object[]
			{
				"No Singer",
				"Male",
				"Female"
			});
			_singerBox.Location = new Point(309, 10);
			_singerBox.Name = "_singerBox";
			_singerBox.Size = new Size(143, 21);
			_singerBox.TabIndex = 3;
			_countOffBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_countOffBox.FormattingEnabled = true;
			_countOffBox.Items.AddRange(new object[]
			{
				"sticks_tiny",
				"sticks_normal",
				"sticks_huge",
				"hihat01",
				"hihat02",
				"hihat03",
				"shaker"
			});
			_countOffBox.Location = new Point(332, 38);
			_countOffBox.Name = "_countOffBox";
			_countOffBox.Size = new Size(120, 21);
			_countOffBox.TabIndex = 4;
			_label10.AutoSize = true;
			_label10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label10.Location = new Point(246, 37);
			_label10.Name = "_label10";
			_label10.Size = new Size(80, 19);
			_label10.TabIndex = 27;
			_label10.Text = "Count Off:";
			_label10.TextAlign = ContentAlignment.MiddleCenter;
			_label9.AutoSize = true;
			_label9.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label9.Location = new Point(246, 9);
			_label9.Name = "_label9";
			_label9.Size = new Size(57, 19);
			_label9.TabIndex = 26;
			_label9.Text = "Singer:";
			_label9.TextAlign = ContentAlignment.MiddleCenter;
			_label8.AutoSize = true;
			_label8.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label8.Location = new Point(12, 65);
			_label8.Name = "_label8";
			_label8.Size = new Size(46, 19);
			_label8.TabIndex = 25;
			_label8.Text = "Year:";
			_label8.TextAlign = ContentAlignment.MiddleCenter;
			_label6.AutoSize = true;
			_label6.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label6.Location = new Point(12, 9);
			_label6.Name = "_label6";
			_label6.Size = new Size(45, 19);
			_label6.TabIndex = 23;
			_label6.Text = "Title:";
			_label6.TextAlign = ContentAlignment.MiddleCenter;
			_label7.AutoSize = true;
			_label7.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label7.Location = new Point(68, 176);
			_label7.Name = "_label7";
			_label7.Size = new Size(56, 19);
			_label7.TabIndex = 32;
			_label7.Text = "Offset:";
			_label7.TextAlign = ContentAlignment.MiddleCenter;
			_artistTxt.Location = new Point(70, 38);
			_artistTxt.Name = "_artistTxt";
			_artistTxt.Size = new Size(150, 20);
			_artistTxt.TabIndex = 1;
			_label1.AutoSize = true;
			_label1.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label1.Location = new Point(12, 37);
			_label1.Name = "_label1";
			_label1.Size = new Size(52, 19);
			_label1.TabIndex = 24;
			_label1.Text = "Artist:";
			_label1.TextAlign = ContentAlignment.MiddleCenter;
			_bassistBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_bassistBox.FormattingEnabled = true;
			_bassistBox.Items.AddRange(new object[]
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
			_bassistBox.Location = new Point(315, 66);
			_bassistBox.Name = "_bassistBox";
			_bassistBox.Size = new Size(137, 21);
			_bassistBox.TabIndex = 5;
			_label2.AutoSize = true;
			_label2.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label2.Location = new Point(246, 65);
			_label2.Name = "_label2";
			_label2.Size = new Size(63, 19);
			_label2.TabIndex = 28;
			_label2.Text = "Bassist:";
			_label2.TextAlign = ContentAlignment.MiddleCenter;
			_bandVolBox.DecimalPlaces = 2;
			_bandVolBox.Increment = new decimal(new[]
			{
				25,
				0,
				0,
				131072
			});
			_bandVolBox.Location = new Point(130, 124);
			var argA560 = _bandVolBox;
			var array2 = new int[4];
			array2[0] = 5;
			argA560.Maximum = new decimal(array2);
			_bandVolBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			_bandVolBox.Name = "_bandVolBox";
			_bandVolBox.ReadOnly = true;
			_bandVolBox.Size = new Size(49, 20);
			_bandVolBox.TabIndex = 7;
			_label3.AutoSize = true;
			_label3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label3.Location = new Point(20, 125);
			_label3.Name = "_label3";
			_label3.Size = new Size(104, 19);
			_label3.TabIndex = 30;
			_label3.Text = "Band Volume:";
			_label3.TextAlign = ContentAlignment.MiddleCenter;
			_guitarVolBox.DecimalPlaces = 2;
			_guitarVolBox.Increment = new decimal(new[]
			{
				25,
				0,
				0,
				131072
			});
			_guitarVolBox.Location = new Point(130, 99);
			var argBb00 = _guitarVolBox;
			var array3 = new int[4];
			array3[0] = 5;
			argBb00.Maximum = new decimal(array3);
			_guitarVolBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			_guitarVolBox.Name = "_guitarVolBox";
			_guitarVolBox.ReadOnly = true;
			_guitarVolBox.Size = new Size(49, 20);
			_guitarVolBox.TabIndex = 6;
			_label4.AutoSize = true;
			_label4.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label4.Location = new Point(12, 100);
			_label4.Name = "_label4";
			_label4.Size = new Size(112, 19);
			_label4.TabIndex = 29;
			_label4.Text = "Guitar Volume:";
			_label4.TextAlign = ContentAlignment.MiddleCenter;
			_hammerOnBox.DecimalPlaces = 2;
			_hammerOnBox.Increment = new decimal(new[]
			{
				5,
				0,
				0,
				131072
			});
			_hammerOnBox.Location = new Point(130, 150);
			var argD0C0 = _hammerOnBox;
			var array4 = new int[4];
			array4[0] = 5;
			argD0C0.Maximum = new decimal(array4);
			_hammerOnBox.Minimum = new decimal(new[]
			{
				5,
				0,
				0,
				-2147483648
			});
			_hammerOnBox.Name = "_hammerOnBox";
			_hammerOnBox.ReadOnly = true;
			_hammerOnBox.Size = new Size(49, 20);
			_hammerOnBox.TabIndex = 8;
			_label5.AutoSize = true;
			_label5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label5.Location = new Point(28, 151);
			_label5.Name = "_label5";
			_label5.Size = new Size(96, 19);
			_label5.TabIndex = 31;
			_label5.Text = "Hammer On:";
			_label5.TextAlign = ContentAlignment.MiddleCenter;
			_byBtn.AutoSize = true;
			_byBtn.Checked = true;
			_byBtn.Location = new Point(89, 14);
			_byBtn.Name = "_byBtn";
			_byBtn.Size = new Size(46, 17);
			_byBtn.TabIndex = 11;
			_byBtn.TabStop = true;
			_byBtn.Text = "\"by\"";
			_byBtn.UseVisualStyleBackColor = true;
			_byBtn.CheckedChanged += ByBtn_CheckedChanged;
			_famousByBtn.AutoSize = true;
			_famousByBtn.Location = new Point(141, 14);
			_famousByBtn.Name = "_famousByBtn";
			_famousByBtn.Size = new Size(126, 17);
			_famousByBtn.TabIndex = 12;
			_famousByBtn.TabStop = true;
			_famousByBtn.Text = "\"as made famous by\"";
			_famousByBtn.UseVisualStyleBackColor = true;
			_famousByBtn.CheckedChanged += FamousByBtn_CheckedChanged;
			_customTxtBtn.AutoSize = true;
			_customTxtBtn.Location = new Point(89, 43);
			_customTxtBtn.Name = "_customTxtBtn";
			_customTxtBtn.Size = new Size(60, 17);
			_customTxtBtn.TabIndex = 13;
			_customTxtBtn.TabStop = true;
			_customTxtBtn.Text = "Custom";
			_customTxtBtn.UseVisualStyleBackColor = true;
			_customTxtBtn.CheckedChanged += CustomTxtBtn_CheckedChanged;
			_artistTextBox.Enabled = false;
			_artistTextBox.Location = new Point(155, 41);
			_artistTextBox.Name = "_artistTextBox";
			_artistTextBox.Size = new Size(104, 20);
			_artistTextBox.TabIndex = 14;
			_label11.AutoSize = true;
			_label11.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label11.Location = new Point(-4, 24);
			_label11.Name = "_label11";
			_label11.Size = new Size(87, 19);
			_label11.TabIndex = 34;
			_label11.Text = "Artist Text:";
			_label11.TextAlign = ContentAlignment.MiddleCenter;
			_chkOriginal.AutoSize = true;
			_chkOriginal.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_chkOriginal.Location = new Point(16, 302);
			_chkOriginal.Name = "Original_CheckBox";
			_chkOriginal.Size = new Size(124, 23);
			_chkOriginal.TabIndex = 15;
			_chkOriginal.Text = "Original Artist";
			_chkOriginal.UseVisualStyleBackColor = true;

			_chkRhythm.AutoSize = true;
			_chkRhythm.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_chkRhythm.Location = new Point(16, 331);
			_chkRhythm.Name = "Rhythm_CheckBox";
			_chkRhythm.Size = new Size(125, 23);
			_chkRhythm.TabIndex = 18;
			_chkRhythm.Text = "Rhythm Track";
			_chkRhythm.UseVisualStyleBackColor = true;

			_chkCoop.AutoSize = true;
			_chkCoop.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_chkCoop.Location = new Point(246, 302);
			_chkCoop.Name = "Coop_CheckBox";
			_chkCoop.Size = new Size(63, 23);
			_chkCoop.TabIndex = 17;
			_chkCoop.Text = "Coop";
			_chkCoop.UseVisualStyleBackColor = true;

            _btnApply.Click += btnApply_Click;
			_btnApply.DialogResult = DialogResult.OK;
			_btnApply.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_btnApply.Location = new Point(318, 327);
			_btnApply.Name = "ApplyBtn";
			_btnApply.Size = new Size(65, 27);
			_btnApply.TabIndex = 21;
			_btnApply.Text = "Apply";
			_btnApply.UseVisualStyleBackColor = true;

			_btnCancel.DialogResult = DialogResult.Cancel;
			_btnCancel.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_btnCancel.Location = new Point(389, 327);
			_btnCancel.Name = "CancelBtn";
			_btnCancel.Size = new Size(65, 27);
			_btnCancel.TabIndex = 22;
			_btnCancel.Text = "Cancel";
			_btnCancel.UseVisualStyleBackColor = true;

			_chkKeyboard.AutoSize = true;
			_chkKeyboard.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_chkKeyboard.Location = new Point(146, 302);
			_chkKeyboard.Name = "Keyboard_CheckBox";
			_chkKeyboard.Size = new Size(94, 23);
			_chkKeyboard.TabIndex = 16;
			_chkKeyboard.Text = "Keyboard";
			_chkKeyboard.UseVisualStyleBackColor = true;

			_rBtnBass.AutoSize = true;
			_rBtnBass.Checked = true;
			_rBtnBass.Location = new Point(67, 3);
			_rBtnBass.Name = "BassBtn";
			_rBtnBass.Size = new Size(48, 17);
			_rBtnBass.TabIndex = 20;
			_rBtnBass.TabStop = true;
			_rBtnBass.Text = "Bass";
			_rBtnBass.UseVisualStyleBackColor = true;

			_rBtnRhythm.AutoSize = true;
			_rBtnRhythm.Location = new Point(0, 3);
			_rBtnRhythm.Name = "RhythmBtn";
			_rBtnRhythm.Size = new Size(61, 17);
			_rBtnRhythm.TabIndex = 19;
			_rBtnRhythm.TabStop = true;
			_rBtnRhythm.Text = "Rhythm";
			_rBtnRhythm.UseVisualStyleBackColor = true;

			_bossBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_bossBox.FormattingEnabled = true;
			_bossBox.Items.AddRange(new object[]
			{
				"Not a boss battle"
			});
			_bossBox.Location = new Point(315, 101);
			_bossBox.Name = "_bossBox";
			_bossBox.Size = new Size(137, 21);
			_bossBox.TabIndex = 10;

			_label12.AutoSize = true;
			_label12.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label12.Location = new Point(189, 100);
			_label12.Name = "_label12";
			_label12.Size = new Size(120, 19);
			_label12.TabIndex = 54;
			_label12.Text = "Boss Properties:";
			_label12.TextAlign = ContentAlignment.MiddleCenter;

			_panel1.Controls.Add(_label11);
			_panel1.Controls.Add(_byBtn);
			_panel1.Controls.Add(_famousByBtn);
			_panel1.Controls.Add(_customTxtBtn);
			_panel1.Controls.Add(_artistTextBox);
			_panel1.Location = new Point(193, 127);
			_panel1.Name = "_panel1";
			_panel1.Size = new Size(267, 68);
			_panel1.TabIndex = 33;

			_panel2.Controls.Add(_rBtnRhythm);
			_panel2.Controls.Add(_rBtnBass);
			_panel2.Location = new Point(146, 331);
			_panel2.Name = "_panel2";
			_panel2.Size = new Size(117, 23);
			_panel2.TabIndex = 35;

			_aeroGroupBox.Controls.Add(_singAnimPakTxt);
			_aeroGroupBox.Controls.Add(_label14);
			_aeroGroupBox.Controls.Add(_perryMicBox);
			_aeroGroupBox.Controls.Add(_aeroGuitaristBox);
			_aeroGroupBox.Controls.Add(_bandBox);
			_aeroGroupBox.Controls.Add(_label16);
			_aeroGroupBox.Controls.Add(_coveredTxt);
			_aeroGroupBox.Controls.Add(_label15);
			_aeroGroupBox.Controls.Add(_bpm8NoteBox);
			_aeroGroupBox.Controls.Add(_label13);
			_aeroGroupBox.Location = new Point(3, 198);
			_aeroGroupBox.Name = "_aeroGroupBox";
			_aeroGroupBox.Size = new Size(457, 98);
			_aeroGroupBox.TabIndex = 55;
			_aeroGroupBox.TabStop = false;
			_aeroGroupBox.Text = "Aerosmith";

			_singAnimPakTxt.Location = new Point(174, 45);
			_singAnimPakTxt.Name = "_singAnimPakTxt";
			_singAnimPakTxt.Size = new Size(275, 20);
			_singAnimPakTxt.TabIndex = 41;
			_label14.AutoSize = true;
			_label14.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label14.Location = new Point(9, 46);
			_label14.Name = "_label14";
			_label14.Size = new Size(159, 19);
			_label14.TabIndex = 42;
			_label14.Text = "Singer Animation Pak:";
			_label14.TextAlign = ContentAlignment.MiddleCenter;
			_perryMicBox.AutoSize = true;
			_perryMicBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_perryMicBox.Location = new Point(311, 71);
			_perryMicBox.Name = "_perryMicBox";
			_perryMicBox.Size = new Size(138, 23);
			_perryMicBox.TabIndex = 40;
			_perryMicBox.Text = "Perry Mic Stand";
			_perryMicBox.UseVisualStyleBackColor = true;
			_aeroGuitaristBox.AutoSize = true;
			_aeroGuitaristBox.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_aeroGuitaristBox.Location = new Point(218, 71);
			_aeroGuitaristBox.Name = "_aeroGuitaristBox";
			_aeroGuitaristBox.Size = new Size(87, 23);
			_aeroGuitaristBox.TabIndex = 39;
			_aeroGuitaristBox.Text = "Guitarist";
			_aeroGuitaristBox.UseVisualStyleBackColor = true;
			_bandBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_bandBox.FormattingEnabled = true;
			_bandBox.Items.AddRange(new object[]
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
			_bandBox.Location = new Point(298, 18);
			_bandBox.Name = "_bandBox";
			_bandBox.Size = new Size(151, 21);
			_bandBox.TabIndex = 37;
			_label16.AutoSize = true;
			_label16.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label16.Location = new Point(243, 20);
			_label16.Name = "_label16";
			_label16.Size = new Size(49, 19);
			_label16.TabIndex = 38;
			_label16.Text = "Band:";
			_label16.TextAlign = ContentAlignment.MiddleCenter;
			_coveredTxt.Location = new Point(109, 19);
			_coveredTxt.Name = "_coveredTxt";
			_coveredTxt.Size = new Size(108, 20);
			_coveredTxt.TabIndex = 35;
			_label15.AutoSize = true;
			_label15.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label15.Location = new Point(9, 20);
			_label15.Name = "_label15";
			_label15.Size = new Size(94, 19);
			_label15.TabIndex = 36;
			_label15.Text = "Covered By:";
			_label15.TextAlign = ContentAlignment.MiddleCenter;
			var arg_1D9F0 = _bpm8NoteBox;
			var array5 = new int[4];
			array5[0] = 5;
			arg_1D9F0.Increment = new decimal(array5);
			_bpm8NoteBox.Location = new Point(127, 71);
			var arg_1Dd60 = _bpm8NoteBox;
			var array6 = new int[4];
			array6[0] = 500;
			arg_1Dd60.Maximum = new decimal(array6);
			_bpm8NoteBox.Minimum = new decimal(new[]
			{
				500,
				0,
				0,
				-2147483648
			});
			_bpm8NoteBox.Name = "_bpm8NoteBox";
			_bpm8NoteBox.Size = new Size(49, 20);
			_bpm8NoteBox.TabIndex = 32;
			_label13.AutoSize = true;
			_label13.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			_label13.Location = new Point(22, 72);
			_label13.Name = "_label13";
			_label13.Size = new Size(99, 19);
			_label13.TabIndex = 33;
			_label13.Text = "8 Note BPM:";
			_label13.TextAlign = ContentAlignment.MiddleCenter;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(466, 358);
			Controls.Add(_chkRhythm);
			Controls.Add(_aeroGroupBox);
			Controls.Add(_panel2);
			Controls.Add(_panel1);
			Controls.Add(_bossBox);
			Controls.Add(_label12);
			Controls.Add(_hammerOnBox);
			Controls.Add(_label5);
			Controls.Add(_guitarVolBox);
			Controls.Add(_label4);
			Controls.Add(_bandVolBox);
			Controls.Add(_label3);
			Controls.Add(_bassistBox);
			Controls.Add(_label2);
			Controls.Add(_chkKeyboard);
			Controls.Add(_artistTxt);
			Controls.Add(_label1);
			Controls.Add(_btnCancel);
			Controls.Add(_btnApply);
			Controls.Add(_yearTxt);
			Controls.Add(_offsetBox);
			Controls.Add(_titleTxt);
			Controls.Add(_singerBox);
			Controls.Add(_countOffBox);
			Controls.Add(_chkCoop);
			Controls.Add(_chkOriginal);
			Controls.Add(_label10);
			Controls.Add(_label9);
			Controls.Add(_label8);
			Controls.Add(_label6);
			Controls.Add(_label7);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SongProperties";
			Text = "Song Properties";
			((ISupportInitialize)_offsetBox).EndInit();
			((ISupportInitialize)_bandVolBox).EndInit();
			((ISupportInitialize)_guitarVolBox).EndInit();
			((ISupportInitialize)_hammerOnBox).EndInit();
			_panel1.ResumeLayout(false);
			_panel1.PerformLayout();
			_panel2.ResumeLayout(false);
			_panel2.PerformLayout();
			_aeroGroupBox.ResumeLayout(false);
			_aeroGroupBox.PerformLayout();
			((ISupportInitialize)_bpm8NoteBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
    }
}
