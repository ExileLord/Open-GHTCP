using GuitarHero;
using GuitarHero.Setlist;
using GuitarHero.Songlist;
using GuitarHero.Tier;
using Microsoft.Win32;
using ns1;
using ns13;
using ns14;
using ns16;
using ns17;
using ns18;
using ns19;
using ns20;
using ns9;
using mid2chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MidiConverter;

namespace ns15
{
	public class MainMenu : Form
	{
		private readonly string string_0;

		private readonly string string_1;

		private readonly string string_2;

		private readonly string string_3;

		private string dataFolder;

		private string string_5;

		private string[] string_6;

		private GH3Songlist gh3Songlist_0;

		private int int_0;

		private bool bool_0;

		public Class319 class319_0;

		private ActionsWindow actionsWindow_0;

		private IContainer icontainer_0;

		private ContextMenuStrip rightClickMenu;

		private MenuStrip TopMenuStrip;

		private ToolStripMenuItem File_MenuItem;

		private ToolStripMenuItem OpenGameSettings_MenuItem;

		private ToolStripMenuItem ExecuteActions_MenuItem;

		private ToolStripMenuItem Exit_MenuItem;

		private ToolStripMenuItem Add_MenuItem;

		private ToolStripMenuItem ManageGame_MenuItem;

		private ListBox ActionRequests_ListBox;

		private Label label1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem NewSong_MenuItem;

		private ToolStripMenuItem Tier_MenuItem;

		private ToolStripMenuItem ManageTiers_MenuItem;

		private Label label3;

		private ToolStripMenuItem Help_MenuItem;

		private ToolStripMenuItem Guide_MenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem About_MenuItem;

		private ToolStripMenuItem ScoreHero_MenuItem;

		private TableLayoutPanel SidePanel;

		private ToolStripMenuItem NewTier_MenuItem;

		private ToolStripMenuItem LegacyImporter_MenuItem;

		private ToolStripMenuItem TGHImport_MenuItem;

		private ToolStripMenuItem SGHSwitch_MenuItem;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem TGHSwitch_MenuItem;

		private ToolStripMenuItem TexExplorer_MenuItem;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripMenuItem ManageSongs_MenuItem;

		private ToolStripMenuItem SongProps_MenuItem;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripMenuItem SaveTGH_MenuItem;

		private ToolStripMenuItem SaveSGH_MenuItem;

		private ToolStripMenuItem MassImporter_MenuItem;

		private ToolStripMenuItem ClearActions_MenuItem;

		private ToolStripMenuItem Disclaimer_MenuItem;

		private ToolStripMenuItem SysExit_MenuItem;

		private NotifyIcon notifyIcon_0;

		private FontDialog fontDialog_0;

		private ToolStripMenuItem SysEnglish_MenuItem;

		private ToolStripMenuItem SysFrench_MenuItem;

		private ToolStripMenuItem SysItalian_MenuItem;

		private ToolStripMenuItem SysSpanish_MenuItem;

		private ToolStripMenuItem SysGerman_MenuItem;

		private ContextMenuStrip leftClickMenu;

		private ToolStripMenuItem SysHigh_MenuItem;

		private ToolStripMenuItem SysAbove_MenuItem;

		private ToolStripMenuItem SysNormal_MenuItem;

		private ToolStripMenuItem SysBelow_MenuItem;

		private ToolStripSeparator toolStripSeparator8;

		private TabPage SongEditorTab;

		private TabPage SetlistTab;

		private ToolStrip SetlistStrip;

		private TabPage SettingsTab;

		private TabControl TabControl;

		private ToolStripContainer MainContainer;

		private StatusStrip StatusStrip;

		private ToolStripStatusLabel ToolStripStatusLbl;

		private TableLayoutPanel SetlistConf_TLPanel;

		private TableLayoutPanel Setlist_TLPanel;

		private ComboBox TierBox;

		private TextBox SetlistPrefix_TxtBox;

		private Label label2;

		private Label label5;

		private Label label4;

		private TableLayoutPanel Tier_TLPanel;

		private Panel TierProps_Panel;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private Label label10;

		private CheckBox TierEncorep1_CheckBox;

		private CheckBox TierEncorep2_CheckBox;

		private CheckBox TierBoss_CheckBox;

		private ComboBox TierStage_DropBox;

		private TextBox TierCompMovie_TxtBox;

		private NumericUpDown TierUnlocked_NumBox;

		private TextBox TierTitle_TxtBox;

		private ComboBox TierIcon_DropBox;

		private TableLayoutPanel TierSongs_Panel;

		private Label label11;

		private Class238 TierSongs_ListBox;

		private Button SetlistApply_Btn;

		private Label label12;

		private TextBox textBox3;

		private TextBox SetlistInitMovie_TxtBox;

		private ToolStripMenuItem RebuildSong_MenuItem;

		private ToolStripSeparator RemoveSong_ToolStripMenuItem;

		private ToolStripMenuItem HideUsed_MenuItem;

		private Button TierApply_Btn;

		private CheckBox NoCash_CheckBox;

		private ToolStripMenuItem ByTitle_MenuItem;

		private ToolStripMenuItem ClearGameSettings_MenuItem;

		private ToolStripMenuItem DeleteSong_MenuItem;

		private ToolStripMenuItem SaveChart_MenuItem;

		private ToolStripMenuItem HideUnEdit_MenuItem;

		private ToolStrip SongEditor_BottomToolStrip;

		private ToolStrip SongEditor_TopToolStrip;

		private ToolStripLabel SongName_EditorLbl;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel PlayTime_EditorLbl;

		private ToolStripSeparator toolStripSeparator10;

		private SongEditor SongEditor_Control;

		private Control0 FretAngle_EditorBar;

		private ToolStripMenuItem GameSettingsSwitch_MenuItem;

		private ToolStripMenuItem RestoreLast_MenuItem;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripMenuItem RestoreOriginal_MenuItem;

		private ToolStripMenuItem SaveFileControl_MenuItem;

		private ToolStripTextBox BeatSize_EditorTxtBox;

		private ToolStripMenuItem SysKorean_MenuItem;

		private ToolStripComboBox Setlist_DropBox;

		private ToolStripLabel Setlist_Lbl;

		private ToolStripLabel toolStripLabel1;

		private CheckBox UnlockAll_CheckBox;

		private ToolStripButton PlayPause_EditorBtn;

		private ToolStripButton LoadAudio_EditorBtn;

		private Label label13;

		private ToolStripButton CreateSetlist_Btn;

		private ToolStripButton DeleteSetlist_Btn;

		private TextBox SetlistTitle_TxtBox;

		private Button TierUnlockedSet_Btn;

		private ToolStripComboBox SelectedTrack_EditorBox;

		private ToolStripButton GameMode_EditorBtn;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripTextBox Offset_EditorTxtBox;

		private ToolStripLabel toolStripLabel2;

		private ToolStripMenuItem RecoverGameSettings_MenuItem;

		private ToolStripMenuItem GH3Folder_MenuItem;

		private ToolStripSplitButton ToggleElements_EditorSplitBtn;

		private ToolStripMenuItem StarView_EditorBtn;

		private ToolStripMenuItem HopoView_EditorBtn;

		private ToolStripMenuItem AudioView_EditorBtn;

		private Control0 HyperSpeed_EditorBar;

		private ToolStripContainer SongEditor_Container;

		private ToolStripContainer SetlistConfig_Container;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripButton LoadChart_EditorBtn;

		private Class238 SongListBox;

		private ToolStripButton Stop_EditorBtn;

		private ToolStripMenuItem SilentGuitar_MenuItem;

		private ToolStripMenuItem RecoverSonglist_MenuItem;

		private ToolStripMenuItem MinToTray_MenuItem;

		private ToolStripMenuItem FxSpeedBoost_MenuItem;

		private ToolStripMenuItem ForceMp3Conversion_MenuItem;

        private ToolStripMenuItem exportSetlistAsChartsToolStripMenuItem;

        private ToolStripMenuItem forceRB3MidConversionToolStripMenuItem;

        private List<string> list_0 = new List<string>(new string[]
		{
			"",
			"_f",
			"_i",
			"_s",
			"_g",
			"_k"
		});

		private int[][] int_1 = new int[][]
		{
			new int[]
			{
				829593536,
				697043826,
				-1837107027,
				1318637149,
				-539680678,
				1171873709,
				1653292043,
				459358182,
				556340579,
				-1642812599,
				-742193873,
				175271819,
				1331363290,
				570416556,
				29153329,
				1819319387
			},
			new int[]
			{
				1836059490,
				1771483454,
				-673998631,
				641462861,
				1900654009,
				1709986031,
				33390903,
				304427717,
				1304990069,
				-1785474702,
				-1337258443,
				324473326,
				1965474355,
				916367820,
				1499003735,
				1352803218
			},
			new int[]
			{
				1269522022,
				-131210374,
				1629838035,
				202858366,
				1666554359,
				636669508,
				714264300,
				-404205300,
				1876358717,
				-1515833711,
				-209857640,
				-1024635964,
				1825789822,
				1897957965,
				-1290348488,
				1190923125
			},
			new int[]
			{
				-887973262,
				1466517696,
				1012345538,
				1334047578,
				1479192262,
				777644331,
				55893077,
				-645061064,
				1149500538,
				-893692966,
				1279451696,
				1784565148,
				-585817907,
				-796356986,
				-850594579,
				978230305
			},
			new int[]
			{
				2116291983,
				1856446224,
				1972458884,
				-348513475,
				-1540514032,
				-1152881742,
				-1084710889,
				-927384332,
				1257846839,
				-1329362414,
				1892002220,
				-1156746513,
				996577931,
				1529160761,
				470653622,
				-1505612085
			},
			new int[]
			{
				-1021830939,
				1913508896,
				125205333,
				379146835,
				1188636734,
				1617165582,
				-722858410,
				849002028,
				-1131773601,
				1209604138,
				-338256082,
				-1855979794,
				-221145881,
				-1691900572,
				1804265874,
				50178858
			}
		};
        private IContainer components;
        private int[][] int_2 = new int[][]
		{
			new int[]
			{
				1437566472,
				-1061079748,
				-1111592754,
				-1966717168,
				-1428950520,
				1212724879,
				740255143,
				715944313,
				2111189242,
				-1451656433,
				-15320960,
				-763814429,
				-1818972422,
				682353600,
				996166890,
				2016473740
			},
			new int[]
			{
				305200924,
				-1196737699,
				-1987906763,
				1679742203,
				1982146584,
				759844203,
				1351130681,
				757831823,
				-363786259,
				2087242606,
				-118476920,
				1285472074,
				1638750453,
				458284014,
				1046153972,
				2026010499
			},
			new int[]
			{
				934530828,
				-980895192,
				-362462945,
				-1205732614,
				1435566503,
				723105985,
				1914552563,
				703888743,
				-2112510328,
				130444503,
				-11435175,
				1470528751,
				1564837879,
				-271089057,
				-1789758487,
				-1075631989
			},
			new int[]
			{
				-1709924020,
				-643193285,
				-309917039,
				-289393289,
				444317537,
				480082408,
				1513307172,
				609246245,
				-160900291,
				750978047,
				-1163119017,
				-1840466690,
				446893618,
				-1892840172,
				-444827469,
				-713549917
			},
			new int[]
			{
				-352783955,
				980938386,
				1545708568,
				-1993984026,
				1402693583,
				-1214301264,
				-1414365273,
				-945991889,
				-274266520,
				1601334973,
				-1624586832,
				-227904233,
				-2024051484,
				-1955644985,
				-1038381726,
				1539206104
			},
			new int[]
			{
				-1888660237,
				1331936703,
				463303036,
				806620738,
				1028153509,
				774209744,
				-511465646,
				1872831595,
				-127158240,
				1527098556,
				-621058351,
				-2069209528,
				-2108293886,
				-45253186,
				1502196519,
				687435827
			}
		};

		private void SongListBox_MouseDown(object sender, MouseEventArgs e)
		{
			int num = this.SongListBox.IndexFromPoint(e.X, e.Y);
			if (num >= 0 && num < this.SongListBox.Items.Count)
			{
				if (e.Clicks == 2 && e.Button == MouseButtons.Left)
				{
					SongProperties songProperties;
					if ((songProperties = new SongProperties((GH3Song)this.SongListBox.Items[num])).ShowDialog() == DialogResult.OK)
					{
						songProperties.method_0();
						this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
						return;
					}
				}
				else if (e.Clicks == 2 && e.Button == MouseButtons.Right)
				{
					GH3Song gH3Song = (GH3Song)this.SongListBox.Items[num];
					if (gH3Song.editable && DialogResult.Yes == MessageBox.Show(gH3Song.name.ToUpper() + " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
					{
						this.SongListBox.Items.Remove(gH3Song);
						foreach (int current in this.gh3Songlist_0.method_1(gH3Song))
						{
							this.method_4(new Class255(current, this.class319_0, this.gh3Songlist_0));
						}
						this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					}
				}
			}
		}

		private void HideUnEdit_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Songlist arg_1D_0 = this.gh3Songlist_0;
			ToolStripMenuItem expr_0C = this.HideUnEdit_MenuItem;
			arg_1D_0.HideUnEditable = (expr_0C.Checked = !expr_0C.Checked);
			this.method_0();
		}

		private void HideUsed_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Songlist arg_1D_0 = this.gh3Songlist_0;
			ToolStripMenuItem expr_0C = this.HideUsed_MenuItem;
			arg_1D_0.HideUsed = (expr_0C.Checked = !expr_0C.Checked);
			this.method_0();
		}

		private void ByTitle_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = this.ByTitle_MenuItem;
			GH3Song.bool_0 = (expr_06.Checked = !expr_06.Checked);
			this.method_0();
		}

		private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.SongListBox.SelectedItems.Count != 0)
			{
				bool enabled = false;
				foreach (GH3Song gH3Song in this.SongListBox.SelectedItems)
				{
					if (gH3Song.editable)
					{
						enabled = true;
					}
				}
				this.SaveChart_MenuItem.Enabled = (this.RebuildSong_MenuItem.Enabled = (this.DeleteSong_MenuItem.Enabled = enabled));
			}
		}

		private void SongProps_MenuItem_Click(object sender, EventArgs e)
		{
			SongProperties songProperties;
			if (this.SongListBox.SelectedIndex >= 0 && (songProperties = new SongProperties((GH3Song)this.SongListBox.Items[this.SongListBox.SelectedIndex])).ShowDialog() == DialogResult.OK)
			{
				songProperties.method_0();
				this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
			}
		}

		private void RebuildSong_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Song gH3Song;
			SongData songData;
			if (this.SongListBox.SelectedIndex >= 0 && (gH3Song = (GH3Song)this.SongListBox.Items[this.SongListBox.SelectedIndex]).editable && (songData = new SongData(gH3Song.name, false, false)).ShowDialog() == DialogResult.OK)
			{
				if (songData.bool_1)
				{
					Class250 @class = songData.method_1(this.class319_0, this.dataFolder);
					this.method_4(@class);
					if (DialogResult.Yes == MessageBox.Show("Do you wish to get the song properties from the game track? (Current properties will be overwritten | Mid files have no properties!)", "Tier Exporting", MessageBoxButtons.YesNo))
					{
						bool no_rhythm_track = gH3Song.no_rhythm_track;
						bool use_coop_notetracks = gH3Song.use_coop_notetracks;
						gH3Song.vmethod_0(@class.class362_0.gh3Song_0);
						gH3Song.no_rhythm_track = no_rhythm_track;
						gH3Song.use_coop_notetracks = use_coop_notetracks;
						this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					}
				}
				if (songData.bool_0)
				{
					Class248 class2 = songData.method_0(this.dataFolder);
					this.method_4(class2);
					gH3Song.no_rhythm_track = !class2.bool_0;
					gH3Song.use_coop_notetracks = class2.bool_1;
					this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
				}
			}
		}

		private void SongListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift && e.KeyCode == Keys.Delete && this.SongListBox.SelectedItems.Count != 0 && DialogResult.Yes == MessageBox.Show("The selected songs will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
			{
				object[] array = this.SongListBox.imethod_3();
				for (int i = 0; i < array.Length; i++)
				{
					GH3Song gH3Song = (GH3Song)array[i];
					if (gH3Song.editable)
					{
						this.SongListBox.Items.Remove(gH3Song);
						foreach (int current in this.gh3Songlist_0.method_1(gH3Song))
						{
							this.method_4(new Class255(current, this.class319_0, this.gh3Songlist_0));
						}
						this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					}
				}
			}
		}

		private void DeleteSong_MenuItem_Click(object sender, EventArgs e)
		{
			object[] array = this.SongListBox.imethod_3();
			for (int i = 0; i < array.Length; i++)
			{
				GH3Song gH3Song = (GH3Song)array[i];
				if (gH3Song.editable && DialogResult.Yes == MessageBox.Show(gH3Song.name.ToUpper() + " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
				{
					this.SongListBox.Items.Remove(gH3Song);
					foreach (int current in this.gh3Songlist_0.method_1(gH3Song))
					{
						this.method_4(new Class255(current, this.class319_0, this.gh3Songlist_0));
					}
					this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
				}
			}
		}

		private void NewSong_MenuItem_Click(object sender, EventArgs e)
		{
			SongData songData = new SongData(this.gh3Songlist_0, this.forceRB3MidConversionToolStripMenuItem.Checked);
			if (songData.ShowDialog() == DialogResult.OK)
			{
				GH3Song gH3Song = this.bool_0 ? new GHASong() : new GH3Song();
				if (songData.bool_1)
				{
					Class250 @class = songData.method_1(this.class319_0, this.dataFolder);
					this.method_4(@class);
					gH3Song.vmethod_0(@class.class362_0.gh3Song_0);
				}
				if (songData.bool_0)
				{
					Class248 class2 = songData.method_0(this.dataFolder);
					this.method_4(class2);
					gH3Song.name = class2.string_1;
					gH3Song.no_rhythm_track = !class2.bool_0;
					gH3Song.use_coop_notetracks = class2.bool_1;
					gH3Song.version = 3;
					gH3Song.leaderboard = true;
					gH3Song.editable = true;
				}
				SongProperties songProperties = new SongProperties(gH3Song);
				if (songProperties.ShowDialog() == DialogResult.OK)
				{
					songProperties.method_0();
				}
				this.gh3Songlist_0.Add(gH3Song.name, gH3Song);
				this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
				this.method_0();
			}
		}

		private void RecoverSonglist_MenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			string[] files = Directory.GetFiles(this.dataFolder + "music\\", "*.dat.xen", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string text = files[i];
				string text2 = Class244.smethod_12(text);
				if (File.Exists(this.dataFolder + "music\\" + text2 + ".fsb.xen") && File.Exists(this.dataFolder + "songs\\" + text2 + "_song.pak.xen") && !this.gh3Songlist_0.method_3(text2) && !Class327.smethod_4(text2) && !GH3Songlist.IgnoreSongs.Contains(Class327.smethod_9(text2)))
				{
					try
					{
						GH3Song gH3Song = this.bool_0 ? new GHASong(text2) : new GH3Song(text2);
						List<string> list = new List<string>(new Class323(text).string_1);
						gH3Song.no_rhythm_track = !list.Contains(text2 + "_rhythm");
						gH3Song.use_coop_notetracks = list.Contains(text2 + "_coop_song");
						this.gh3Songlist_0.Add(text2, gH3Song);
						flag = true;
					}
					catch
					{
					}
				}
			}
			if (flag)
			{
				this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
				this.method_0();
			}
		}

		private void method_0()
		{
			this.SongListBox.Items.Clear();
			this.SongListBox.Items.AddRange(this.gh3Songlist_0.getSongs());
		}

		private void LoadChart_EditorBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the game track file.", "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart", true)).Equals(""))
			{
				QBCParser qbcParser;
				try
				{
					if (fileName.EndsWith("_song.pak.xen"))
					{
						string str = Class244.smethod_13(fileName).Replace("_song.pak.xen", "");
						using (Class318 @class = new Class318(fileName, false))
						{
							if (!@class.method_6("songs\\" + str + ".mid.qb"))
							{
								throw new Exception("MID.QB song file not found.");
							}
							qbcParser = new QBCParser(str, @class.method_8("songs\\" + str + ".mid.qb"));
							goto IL_DA;
						}
					}
					if (fileName.EndsWith(".qbc"))
					{
						qbcParser = new QBCParser(fileName);
					}
					else if (fileName.EndsWith(".mid"))
					{
                        ChartParser chartParser = Midi2Chart.getMidiSong(fileName, this.forceRB3MidConversionToolStripMenuItem.Checked);
                        qbcParser = chartParser.method_3();
					}
					else
					{
						qbcParser = new ChartParser(fileName).method_3();
                    }
					IL_DA:;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error loading game track file!\n" + ex.Message);
					return;
				}
				this.SongName_EditorLbl.Text = qbcParser.gh3Song_0.title;
				this.SelectedTrack_EditorBox.Items.Clear();
				foreach (string current in qbcParser.noteList.Keys)
				{
					this.SelectedTrack_EditorBox.Items.Add(current);
				}
				this.SongEditor_Control.method_11(qbcParser);
				this.SelectedTrack_EditorBox.SelectedIndex = 0;
				this.Offset_EditorTxtBox.Text = string.Concat(qbcParser.gh3Song_0.gem_offset);
			}
		}

		private void BeatSize_EditorTxtBox_TextChanged(object sender, EventArgs e)
		{
			int num;
			try
			{
				num = Convert.ToInt32(this.BeatSize_EditorTxtBox.Text);
			}
			catch
			{
				return;
			}
			if (num != 0)
			{
				this.SongEditor_Control.method_1(num);
			}
		}

		private void Offset_EditorTxtBox_TextChanged(object sender, EventArgs e)
		{
			int int_;
			try
			{
				int_ = Convert.ToInt32(this.Offset_EditorTxtBox.Text);
			}
			catch
			{
				return;
			}
			this.SongEditor_Control.method_2(int_);
		}

		private void PlayPause_EditorBtn_Click(object sender, EventArgs e)
		{
			if (this.SongEditor_Control.method_24())
			{
				if (this.SongEditor_Control.method_0() != Enum1.const_1)
				{
					this.SongEditor_Control.method_21();
					return;
				}
				this.SongEditor_Control.method_22();
			}
		}

		private void Stop_EditorBtn_Click(object sender, EventArgs e)
		{
			if (this.SongEditor_Control.method_24())
			{
				this.SongEditor_Control.method_23();
			}
		}

		private void LoadAudio_EditorBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = Class244.smethod_16("Select the Guitar Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio File|*.mp3|Waveform Audio File|*.wav|Ogg Vorbis Audio File|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
				this.SongEditor_Control.loadAudio(fileName);
            }
		}

		private void SelectedTrack_EditorBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SongEditor_Control.string_0 = (string)this.SelectedTrack_EditorBox.SelectedItem;
		}

		private void method_1(object sender, EventArgs e)
		{
			this.PlayTime_EditorLbl.Text = string.Concat((float)((int)sender) / 1000f);
		}

		private void GameMode_EditorBtn_Click(object sender, EventArgs e)
		{
			this.SongEditor_Control.method_8(this.GameMode_EditorBtn.Checked);
		}

		private void ToggleElements_EditorSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			SongEditor arg_1D_0 = this.SongEditor_Control;
			ToolStripMenuItem expr_0C = this.StarView_EditorBtn;
			arg_1D_0.bool_2 = (expr_0C.Checked = !expr_0C.Checked);
			SongEditor arg_3F_0 = this.SongEditor_Control;
			ToolStripMenuItem expr_2E = this.HopoView_EditorBtn;
			arg_3F_0.bool_3 = (expr_2E.Checked = !expr_2E.Checked);
			SongEditor arg_61_0 = this.SongEditor_Control;
			ToolStripMenuItem expr_50 = this.AudioView_EditorBtn;
			arg_61_0.bool_4 = (expr_50.Checked = !expr_50.Checked);
		}

		private void StarView_EditorBtn_Click(object sender, EventArgs e)
		{
			this.SongEditor_Control.bool_2 = this.StarView_EditorBtn.Checked;
		}

		private void HopoView_EditorBtn_Click(object sender, EventArgs e)
		{
			this.SongEditor_Control.bool_3 = this.HopoView_EditorBtn.Checked;
		}

		private void AudioView_EditorBtn_Click(object sender, EventArgs e)
		{
			this.SongEditor_Control.bool_4 = this.AudioView_EditorBtn.Checked;
		}

		private void method_2(object sender, EventArgs e)
		{
			this.SongEditor_Control.method_10((double)this.FretAngle_EditorBar.method_4());
		}

		private void method_3(object sender, EventArgs e)
		{
			if (this.HyperSpeed_EditorBar.method_4() == 0)
			{
				this.SongEditor_Control.method_9(1.0);
				return;
			}
			if (this.HyperSpeed_EditorBar.method_4() < 0)
			{
				this.SongEditor_Control.method_9(1.0 - (double)this.HyperSpeed_EditorBar.method_4() / (double)(this.HyperSpeed_EditorBar.method_1() * 2));
				return;
			}
			if (this.HyperSpeed_EditorBar.method_4() > 0)
			{
				this.SongEditor_Control.method_9(1.0 + (double)(this.HyperSpeed_EditorBar.method_4() * this.HyperSpeed_EditorBar.method_4()) / 10.0);
			}
		}

		private void SaveChart_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.SongListBox.SelectedIndex >= 0)
			{
				GH3Song gh3Song = (GH3Song)this.SongListBox.SelectedItem;
				if (!gh3Song.editable)
				{
					return;
				}
				string fileLocation = Class244.smethod_16("Select where to save the song chart.", "GH3 Chart File|*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc", false);
				if (!fileLocation.Equals("") && File.Exists(this.dataFolder + "songs\\" + gh3Song.name + "_song.pak.xen"))
				{
					using (Class318 @class = new Class318(this.dataFolder + "songs\\" + gh3Song.name + "_song.pak.xen", false))
					{
						if (fileLocation.EndsWith(".qbc"))
						{
							new QBCParser(gh3Song.name, @class.method_8("songs\\" + gh3Song.name + ".mid.qb")).qbcCreator(fileLocation, gh3Song);
						}
                        else if (fileLocation.EndsWith(".chart"))
                        {
                            new QBCParser(gh3Song.name, @class.method_8("songs\\" + gh3Song.name + ".mid.qb")).method_1().chartCreator(fileLocation, gh3Song);
                        }
                        else
						{
							new QBCParser(gh3Song.name, @class.method_8("songs\\" + gh3Song.name + ".mid.qb")).method_1().dbcCreator(fileLocation, gh3Song);
						}
                       /* string firstArg = this.dataFolder + "MUSIC\\" + gh3Song.name + ".fsb.xen";
                        MessageBox.Show(firstArg);
                        string secondArg = firstArg + ".fsb";
                        System.Diagnostics.Process.Start("D:\\Guitar Hero 3 Custom Songs\\Chart Maker\\FSB Extractor\\decfsb.exe", "for %%a IN (" + firstArg + ") DO decfsb %%a %%a.fsb -x ac 86 2e ae 6c ee 2c 5e 86 ee\nfor %% b IN(" + secondArg + ") Do ren %% b\nfor %% c IN(*.fsb) Do fsbext - R %% c");
                        */
                        return;
					}
				}
				return;
			}
		}

		private void SaveTGH_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.TierBox.SelectedIndex >= 0)
			{
				string text = Class244.smethod_15("Select where to save the tier.", "GH3CP Tier File|*.tgh", false, this.TierTitle_TxtBox.Text);
				if (text.Equals(""))
				{
					return;
				}
				TGHManager @class;
				if (DialogResult.Yes == MessageBox.Show("Do you wish to include all used song data (Music & Game Tracks)?", "Tier Exporting", MessageBoxButtons.YesNo))
				{
					@class = new TGHManager(this.gh3Songlist_0, (GH3Tier)this.TierBox.SelectedItem, text, this.dataFolder);
				}
				else
				{
					@class = new TGHManager(this.gh3Songlist_0, (GH3Tier)this.TierBox.SelectedItem, text);
				}
				@class.method_1();
			}
		}

        private void exportSetlistAsChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TGHSwitch_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.TierBox.SelectedIndex >= 0)
			{
				string text = Class244.smethod_17("Select the tier to switch too.", "GH3CP Tier File|*.tgh");
				if (text.Equals(""))
				{
					return;
				}
				GH3Tier gH3Tier = new GH3Tier();
				try
				{
					TGHManager tghManager;
					if (DialogResult.Yes == MessageBox.Show("Do you wish to import all contained song data (Music & Game Tracks)? Data and properties will be overwritten!", "Tier Switching", MessageBoxButtons.YesNo))
					{
						tghManager = new TGHManager(this.gh3Songlist_0, gH3Tier, text, this.dataFolder);
					}
					else
					{
						tghManager = new TGHManager(this.gh3Songlist_0, gH3Tier, text);
					}
					tghManager.method_0();
					this.TierBox.Items[this.TierBox.SelectedIndex] = gH3Tier;
					this.TierBox.SelectedIndex = this.TierBox.SelectedIndex;
					this.SetlistApply_Btn.Enabled = true;
					this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					this.method_0();
				}
				catch
				{
					MessageBox.Show("File not compatible! Tier Switch failed.", "Tier Switching");
				}
			}
		}

		private void TGHImport_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0.gh3SetlistList.ContainsKey(this.int_0))
			{
				string text = Class244.smethod_17("Select the tier to import.", "GH3CP Tier File|*.tgh");
				if (text.Equals(""))
				{
					return;
				}
				GH3Tier gH3Tier = new GH3Tier();
				try
				{
					TGHManager @class;
					if (DialogResult.Yes == MessageBox.Show("Do you wish to import all contained song data (Music & Game Tracks) and properties? Data will be overwritten!", "Tier Importing", MessageBoxButtons.YesNo))
					{
						@class = new TGHManager(this.gh3Songlist_0, gH3Tier, text, this.dataFolder);
					}
					else
					{
						@class = new TGHManager(this.gh3Songlist_0, gH3Tier, text);
					}
					@class.method_0();
					this.TierBox.Items.Add(gH3Tier);
					this.TierBox.SelectedIndex = this.TierBox.Items.Count - 1;
					this.SetlistApply_Btn.Enabled = true;
					this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					this.method_0();
				}
				catch
				{
					MessageBox.Show("File not compatible! Tier Import failed.", "Tier Importing");
				}
			}
		}

		private void SaveSGH_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0.gh3SetlistList.ContainsKey(this.int_0))
			{
				string saveLocation = Class244.smethod_15("Select where to save the setlist.", "GH3CP Setlist File|*.sgh", false, this.SetlistTitle_TxtBox.Text);
				if (saveLocation.Equals(""))
				{
					return;
				}
				SGHManager sghManager;
				if (DialogResult.Yes == MessageBox.Show("Do you wish to include all used song data (Music & Game Tracks)?", "Setlist Exporting", MessageBoxButtons.YesNo))
				{
					sghManager = new SGHManager(this.gh3Songlist_0, this.gh3Songlist_0.gh3SetlistList[this.int_0], saveLocation, this.dataFolder);
				}
				else
				{
					sghManager = new SGHManager(this.gh3Songlist_0, this.gh3Songlist_0.gh3SetlistList[this.int_0], saveLocation);
				}
				sghManager.method_1();
			}
		}

        private void exportSetlistAsChartsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.gh3Songlist_0.gh3SetlistList.ContainsKey(this.int_0))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.Description = "Please select where you would like to save the charts.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string saveLocation = folderBrowserDialog.SelectedPath;
                if (saveLocation.Equals(""))
                {
                    return;
                }
                foreach(GH3Tier tier in this.gh3Songlist_0.gh3SetlistList[this.int_0].tiers)
                {
                    foreach (GH3Song gh3Song in tier.songs)
                    {
                        string fileLocation = saveLocation + "\\" + gh3Song.name + ".chart";
                        using (Class318 @class = new Class318(this.dataFolder + "songs\\" + gh3Song.name + "_song.pak.xen", false))
                        {
                            new QBCParser(gh3Song.name, @class.method_8("songs\\" + gh3Song.name + ".mid.qb")).method_1().chartCreator(fileLocation, gh3Song);
                        }
                    }
                }
            }
        }

        private void SGHSwitch_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0.gh3SetlistList.ContainsKey(this.int_0))
			{
				string text = Class244.smethod_17("Select the setlist to switch too.", "GH3CP Setlist File|*.sgh");
				if (text.Equals(""))
				{
					return;
				}
				GH3Setlist gH3Setlist = new GH3Setlist();
				try
				{
					SGHManager sghManager;
					if (DialogResult.Yes == MessageBox.Show("Do you wish to import all contained song data (Music & Game Tracks)? Data and properties will be overwritten!", "Setlist Switching", MessageBoxButtons.YesNo))
					{
						sghManager = new SGHManager(this.gh3Songlist_0, gH3Setlist, text, this.dataFolder);
					}
					else
					{
						sghManager = new SGHManager(this.gh3Songlist_0, gH3Setlist, text);
					}
					sghManager.method_0();
					this.TierBox.Items.Clear();
					this.TierBox.Items.AddRange(gH3Setlist.tiers.ToArray());
					if (this.TierBox.Items.Count != 0)
					{
						this.TierBox.SelectedIndex = 0;
					}
					else
					{
						this.method_23();
					}
					this.SetlistTitle_TxtBox.Text = Class244.smethod_11(text, 1);
					this.SetlistApply_Btn.Enabled = true;
					this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					this.method_0();
				}
				catch (Exception exception)
				{
					MessageBox.Show("File not compatible! Setlist Switch failed.\n" + exception, "Setlist Switching");
				}
			}
		}

		private void LegacyImporter_MenuItem_Click(object sender, EventArgs e)
		{
		}

		private void MassImporter_MenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = false;
			folderBrowserDialog.Description = "Please select a folder that contains the folder structure for mass song importing.";
			folderBrowserDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] directories = Directory.GetDirectories(folderBrowserDialog.SelectedPath, "*", SearchOption.TopDirectoryOnly);
			List<string> list = new List<string>(directories);
			string[] array = directories;
			for (int i = 0; i < array.Length; i++)
			{
				string file = array[i];
				try
				{
					List<string> list2 = Class244.checkFile(file, "*.mid;*.chart;*.qbc;*.dbc", true);
					List<string> list3 = Class244.checkFile(file, "*.wav;*.mp3;*.ogg", true);
					string[] files = Directory.GetFiles(file, "*.dat", SearchOption.TopDirectoryOnly);
					if (list2.Count != 0 && (list3.Count != 0 || files.Length != 0))
					{
						GH3Song gH3Song = this.bool_0 ? new GHASong() : new GH3Song();
						gH3Song.name = Class244.smethod_13(file).ToLower().Replace(" ", "").Replace('.', '_');
						if (gH3Song.name.Length > 30)
						{
							gH3Song.name = gH3Song.name.Remove(30);
						}
						if (Class327.smethod_4(gH3Song.name) || this.gh3Songlist_0.method_3(gH3Song.name))
						{
							int num = 2;
							while (Class327.smethod_4(gH3Song.name + num) || this.gh3Songlist_0.method_3(gH3Song.name + num))
							{
								num++;
							}
							GH3Song expr_176 = gH3Song;
							expr_176.name += num;
						}
						QBCParser qbcParser = null;
						foreach (string current in list2)
						{
							try
							{
								if (current.EndsWith(".qbc"))
								{
									qbcParser = new QBCParser(current);
								}
								else if (current.EndsWith(".mid"))
								{
                                    ChartParser chartParser = Midi2Chart.getMidiSong(current, this.forceRB3MidConversionToolStripMenuItem.Checked);
                                    qbcParser = chartParser.method_3();
								}
								else
								{
									qbcParser = new ChartParser(current).method_3();
								}
								break;
							}
							catch
							{
							}
						}
						if (qbcParser != null)
						{
							Class323 class2 = null;
							if (files.Length != 0)
							{
								string[] array2 = files;
								for (int j = 0; j < array2.Length; j++)
								{
									string text2 = array2[j];
									try
									{
										if (File.Exists(text2.Replace(".dat.xen", ".fsb.xen")))
										{
											class2 = new Class323(text2);
											if ((int)new FileInfo(text2.Replace(".dat.xen", ".fsb.xen")).Length == class2.int_0)
											{
												break;
											}
										}
									}
									catch
									{
									}
								}
							}
							if (class2 != null || list3.Count != 0)
							{
								SongData songData = new SongData(gH3Song.name, qbcParser, class2, list3.ToArray());
								Class250 class3 = songData.method_1(this.class319_0, this.dataFolder);
								Class248 class4 = songData.method_0(this.dataFolder);
								gH3Song.vmethod_0(class3.class362_0.gh3Song_0);
								if (File.Exists(file + "\\song.ini"))
								{
									string[] array3 = File.ReadAllLines(file + "\\song.ini");
									for (int k = 0; k < array3.Length; k++)
									{
										string text3 = array3[k];
										if (text3.StartsWith("name"))
										{
											gH3Song.title = text3.Remove(0, text3.IndexOf('=') + 1).Trim();
										}
										else if (text3.StartsWith("artist"))
										{
											gH3Song.artist = text3.Remove(0, text3.IndexOf('=') + 1).Trim();
										}
									}
								}
								gH3Song.no_rhythm_track = !class4.bool_0;
								gH3Song.use_coop_notetracks = class4.bool_1;
								gH3Song.version = 3;
								gH3Song.leaderboard = true;
								gH3Song.editable = true;
								this.method_4(class3);
								this.method_4(class4);
								this.gh3Songlist_0.Add(gH3Song.name, gH3Song);
								list.Remove(file);
							}
						}
					}
				}
				catch
				{
				}
			}
			this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
			this.method_0();
			if (list.Count != 0)
			{
				string text4 = "The follwing songs (by folder name) failed:";
				foreach (string current2 in list)
				{
					text4 = text4 + "\n" + Class244.smethod_13(current2);
				}
				MessageBox.Show(text4, "Error!");
			}
		}

		public MainMenu()
		{
            //Creates GUI
			this.InitializeComponent();
			Class258.bool_0 = false;
			try
			{
				string text = null;
				string text2 = null;
				using (StreamReader streamReader = new StreamReader(new WebClient().OpenRead("http://sites.google.com/site/sigmaincproduction/ghtcp_latest.txt")))
				{
					string text3;
					while ((text3 = streamReader.ReadLine()) != null)
					{
						if (text3.StartsWith("version: "))
						{
							text = text3.Replace("version: ", "");
						}
						else if (text3.StartsWith("link: "))
						{
							text2 = text3.Replace("link: ", "");
						}
					}
				}
				if (text != null && text2 != null && Assembly.GetExecutingAssembly().GetName().Version.CompareTo(new Version(text)) < 0 && DialogResult.Yes == MessageBox.Show("Would you like to download the latest version?", "GHTCP: Version " + text + " is available!", MessageBoxButtons.YesNo))
				{
					Process.Start(text2);
				}
			}
			catch
			{
			}
			if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero III\\") != null)
			{
				this.string_1 = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero III\\";
				if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null && MessageBox.Show("Do you wish to load GH3 Aerosmith?", "GH3 Aerosmith found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.string_1 = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
					this.bool_0 = true;
				}
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero III\\") != null)
			{
				this.string_1 = "SOFTWARE\\Aspyr\\Guitar Hero III\\";
				if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null && MessageBox.Show("Do you wish to load GH3 Aerosmith?", "GH3 Aerosmith found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.string_1 = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
					this.bool_0 = true;
				}
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null)
			{
				this.string_1 = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
				this.bool_0 = true;
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null)
			{
				this.string_1 = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
				this.bool_0 = true;
			}
			else
			{
				MessageBox.Show("Guitar Hero III is not installed properly! Please re/install and run again.");
				this.formClosing();
			}
			this.string_2 = (this.bool_0 ? "SOFTWARE\\SigmaInc\\GHTCPAero\\" : "SOFTWARE\\SigmaInc\\GHTCP\\");
			this.string_3 = (this.bool_0 ? "backupAero\\" : "backup\\");
			Class372.string_0 = (this.bool_0 ? "GHA" : "GH3");
			if (this.bool_0)
			{
				this.Text += " - Aerosmith";
				this.TierIcon_DropBox.Items.AddRange(new string[]
				{
					"setlist_icon_01",
					"setlist_icon_02",
					"setlist_icon_03",
					"setlist_icon_04",
					"setlist_icon_05",
					"setlist_icon_06"
				});
				this.TierStage_DropBox.Items.AddRange(new string[]
				{
					"load_z_hof",
					"load_z_nine_lives",
					"load_z_jpplay",
					"load_z_nipmuc",
					"load_z_maxskc",
					"load_z_fenway",
					"viewer",
					"load_z_credits",
					"load_z_viewer"
				});
				this.TierEncorep2_CheckBox.Text = "P1 Aerosmith Encore";
			}
			else
			{
				this.Text += " - Legends of Rock";
				this.TierIcon_DropBox.Items.AddRange(new string[]
				{
					"setlist_icon_backyard",
					"setlist_icon_bar",
					"setlist_icon_videoshoot",
					"setlist_icon_odeon",
					"setlist_icon_prison",
					"setlist_icon_desert",
					"setlist_icon_megadome",
					"setlist_icon_hell"
				});
				this.TierStage_DropBox.Items.AddRange(new string[]
				{
					"load_z_artdeco",
					"load_z_budokan",
					"load_z_dive",
					"load_z_hell",
					"load_z_party",
					"load_z_prison",
					"load_z_video",
					"load_z_wikker",
					"load_z_soundcheck",
					"viewer",
					"load_z_credits",
					"load_z_viewer"
				});
			}
			if (this.method_9() == null)
			{
				throw new Exception("GH3 Language setting missing from registry!");
			}
			Class327.smethod_0();
			this.string_0 = Directory.GetCurrentDirectory() + "\\";
			this.method_12(false);
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_2);
			this.method_10((string)registryKey.GetValue("Priority"));
			if (!new List<string>(new string[]
			{
				"high",
				"above",
				"normal",
				"below"
			}).Contains(this.string_5))
			{
				this.method_10("normal");
			}
			List<string> list = new List<string>(new string[]
			{
				(string)registryKey.GetValue("English"),
				(string)registryKey.GetValue("French"),
				(string)registryKey.GetValue("Italian"),
				(string)registryKey.GetValue("Spanish"),
				(string)registryKey.GetValue("German"),
				(string)registryKey.GetValue("Korean")
			});
			if (list.Contains(null))
			{
				this.string_6 = new string[]
				{
					"Guitar Hero III (English)",
					"Guitar Hero III (French)",
					"Guitar Hero III (Italian)",
					"Guitar Hero III (Spanish)",
					"Guitar Hero III (German)",
					"Guitar Hero III (Korean)"
				};
			}
			else
			{
				this.string_6 = list.ToArray();
			}
			this.method_13();
			this.SilentGuitar_MenuItem.Checked = (Class248.bool_2 = ((((int?)registryKey.GetValue("SilentGuitar")) ?? 0) != 0));
			this.MinToTray_MenuItem.Checked = ((((int?)registryKey.GetValue("MinimizeToTray")) ?? 0) != 0);
			this.SilentGuitar_MenuItem.Checked = (Class248.bool_3 = ((((int?)registryKey.GetValue("ForceConversion")) ?? 0) != 0));
			if (!Directory.Exists(this.string_0 + this.string_3))
			{
				Directory.CreateDirectory(this.string_0 + this.string_3);
			}
			if (!Directory.Exists(this.string_0 + this.string_3 + "originals"))
			{
				Directory.CreateDirectory(this.string_0 + this.string_3 + "originals");
			}
			if (!Directory.Exists(this.string_0 + this.string_3 + "lastedited"))
			{
				Directory.CreateDirectory(this.string_0 + this.string_3 + "lastedited");
			}
			if (!File.Exists(this.string_0 + "lame_enc.dll"))
			{
				try
				{
					ZIPManager.smethod_8(new WebClient().OpenRead("http://spaghetticode.org/lame/libmp3lame-win-3.97.zip"), this.string_0 + "lame_enc.dll", "libmp3lame-3.97/lame_enc.dll");
				}
				catch
				{
					Process.Start("http://lame.buanzo.com.ar/");
					MessageBox.Show("Please download the file under \"ZIP OPTION:\" and select it: libmp3lame-win-#.#.zip", "MP3 Encoding Library Missing!");
					try
					{
						string text4 = Class244.smethod_16("Locate MP3 Encoding Library (file will be deleted after!)", "MP3 Lame Zip|*.zip", true);
						string text5 = Class244.smethod_12(text4);
						ZIPManager.smethod_4(text4, this.string_0 + "lame_enc.dll", "libmp3lame" + text5.Substring(text5.LastIndexOf('-')) + "/lame_enc.dll");
						try
						{
							Class244.smethod_20(text4);
						}
						catch
						{
						}
					}
					catch
					{
						MessageBox.Show("MP3 Encoding Library could not be extracted, Audio conversion will fail without it!", "MP3 Encoding Library Missing!");
					}
				}
			}
		}

		private void TexExplorer_MenuItem_Click(object sender, EventArgs e)
		{
			new TexExplorer(this.dataFolder).ShowDialog();
		}

		private void SaveFileControl_MenuItem_Click(object sender, EventArgs e)
		{
			string a = Class244.smethod_16("Select Save File to Import. Current Save File will be Overwritten!", "GH3 Save File|s000.d", true);
			if (a != "")
			{
				Class324 @class = new Class324(a);
				@class.method_0(new Class324(872398018)).list_0[0].int_0[1] = -1;
				string text = "Progress" + (new string[]
				{
					"A",
					"B",
					"C",
					"D",
					"E"
				})[this.list_0.IndexOf(Class244.smethod_12(this.class319_0.string_0).Remove(0, 2))];
				text = string.Concat(new string[]
				{
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"\\Aspyr\\Guitar Hero III\\Save\\",
					text,
					"}{",
					text
				});
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				@class.method_1(text);
			}
		}

		private void method_4(Class245 class245_0)
		{
			foreach (Class245 @class in this.ActionRequests_ListBox.Items)
			{
				if (@class.Equals(class245_0))
				{
					this.ActionRequests_ListBox.Items.Remove(@class);
					break;
				}
			}
			this.ActionRequests_ListBox.Items.Add(class245_0);
		}

		private void ClearActions_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes == MessageBox.Show("Are You sure you want to delete all Actions?", "Warning!", MessageBoxButtons.YesNo))
			{
				this.ActionRequests_ListBox.Items.Clear();
				GC.Collect();
			}
		}

		private void ExecuteActions_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActionRequests_ListBox.Items.Count != 0)
			{
				if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Execute Actions?", "Warning!", MessageBoxButtons.YesNo))
				{
					List<Class245> list = new List<Class245>();
					foreach (Class245 item in this.ActionRequests_ListBox.Items)
					{
						list.Add(item);
					}
					this.actionsWindow_0 = new ActionsWindow(list);
					this.actionsWindow_0.method_0(new EventHandler(this.method_5));
					this.actionsWindow_0.Show();
					this.actionsWindow_0.method_1();
					return;
				}
			}
		}

		private void method_5(object sender, EventArgs e)
		{
			if ((!this.actionsWindow_0.bool_0 || DialogResult.Yes == MessageBox.Show("Some of the action requests failed!\nDo you still wish to rebuild the game settings?", "Warning!", MessageBoxButtons.YesNo)) && this.method_18())
			{
				this.actionsWindow_0 = null;
				this.ActionRequests_ListBox.Items.Clear();
				GC.Collect();
			}
		}

		private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes != MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?", "Warning!", MessageBoxButtons.YesNo))
			{
				e.Cancel = true;
				return;
			}
			this.formClosing();
		}

		public void MainMenu_SizeChanged(object sender, EventArgs e)
		{
			Console.WriteLine(base.WindowState);
			if (base.WindowState == FormWindowState.Minimized && this.MinToTray_MenuItem.Checked)
			{
				base.Hide();
				return;
			}
			if (!base.Visible)
			{
				base.BringToFront();
				base.Show();
				base.Focus();
				base.WindowState = FormWindowState.Normal;
			}
		}

		[DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool SetForegroundWindow(HandleRef handleRef_0);

		private void notifyIcon_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2)
			{
				this.leftClickMenu.Hide();
				this.rightClickMenu.Hide();
				if (e.Button == MouseButtons.Left)
				{
					base.BringToFront();
					base.Show();
					base.Focus();
					base.WindowState = FormWindowState.Normal;
					return;
				}
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				try
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.string_1);
					Process process = new Process();
					process.StartInfo = new ProcessStartInfo((string)registryKey.GetValue("Path") + (this.bool_0 ? "Guitar Hero Aerosmith.exe" : "GH3.exe"));
					process.Start();
					if (this.string_5 != "normal")
					{
						process.PriorityClass = ((this.string_5 == "high") ? ProcessPriorityClass.High : ((this.string_5 == "above") ? ProcessPriorityClass.AboveNormal : ((this.string_5 == "below") ? ProcessPriorityClass.BelowNormal : ProcessPriorityClass.Normal)));
					}
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			MainMenu.SetForegroundWindow(new HandleRef(this, base.Handle));
			if (e.Button == MouseButtons.Left)
			{
				this.leftClickMenu.Show(this, base.PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveLeft);
				return;
			}
			if (e.Button == MouseButtons.Right)
			{
				this.rightClickMenu.Show(this, base.PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveRight);
			}
		}

		private void formClosing()
		{
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_2);
			registryKey.SetValue("Priority", this.string_5);
			registryKey.SetValue("SilentGuitar", Class248.bool_2 ? 1 : 0);
			registryKey.SetValue("MinimizeToTray", this.MinToTray_MenuItem.Checked ? 1 : 0);
			registryKey.SetValue("ForceConversion", Class248.bool_3 ? 1 : 0);
			this.method_15();
			this.SongEditor_Control.Dispose();
            this.Dispose(true);
        }

		private void Exit_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes != MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?", "Warning!", MessageBoxButtons.YesNo))
			{
				return;
			}
			this.formClosing();
		}

		private void method_7(string string_7)
		{
			this.SysEnglish_MenuItem.Checked = (string_7 == "en");
			this.SysFrench_MenuItem.Checked = (string_7 == "fr");
			this.SysItalian_MenuItem.Checked = (string_7 == "it");
			this.SysSpanish_MenuItem.Checked = (string_7 == "es");
			this.SysGerman_MenuItem.Checked = (string_7 == "de");
			this.SysKorean_MenuItem.Checked = (string_7 == "ko");
		}

		private void method_8(string string_7)
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_1);
			registryKey.SetValue("Language", string_7);
			this.method_7(string_7);
		}

		private string method_9()
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_1);
			string text = (string)registryKey.GetValue("Language");
			this.method_7(text);
			return text;
		}

		private void SysKorean_MenuItem_Click(object sender, EventArgs e)
		{
			this.method_8((string)((ToolStripMenuItem)sender).Tag);
		}

		private void method_10(string string_7)
		{
			this.string_5 = string_7;
			this.SysHigh_MenuItem.Checked = (this.string_5 == "high");
			this.SysAbove_MenuItem.Checked = (this.string_5 == "above");
			this.SysNormal_MenuItem.Checked = (this.string_5 == "normal");
			this.SysBelow_MenuItem.Checked = (this.string_5 == "below");
		}

		private void SysBelow_MenuItem_Click(object sender, EventArgs e)
		{
			this.method_10((string)((ToolStripMenuItem)sender).Tag);
		}

		private void Guide_MenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.scorehero.com/forum/viewtopic.php?t=72367");
		}

		private void ScoreHero_MenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.scorehero.com/forum/viewtopic.php?t=69818");
		}

		private void GH3Folder_MenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(this.dataFolder);
		}

		private void Disclaimer_MenuItem_Click(object sender, EventArgs e)
		{
			if (new Disclaimer().ShowDialog() != DialogResult.OK)
			{
				this.formClosing();
			}
		}

		private void About_MenuItem_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void SilentGuitar_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = this.SilentGuitar_MenuItem;
			Class248.bool_2 = (expr_06.Checked = !expr_06.Checked);
		}

		private void FxSpeedBoost_MenuItem_Click(object sender, EventArgs e)
		{
			this.method_4(new Class251(this.class319_0));
		}

		private void ForceMp3Conversion_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = this.ForceMp3Conversion_MenuItem;
			Class248.bool_3 = (expr_06.Checked = !expr_06.Checked);
		}

        //Disables Buttons
		private void method_11(GH3Setlist gh3Setlist_0)
		{
			this.SetlistTitle_TxtBox.Text = (string)this.Setlist_DropBox.SelectedItem;
			this.SetlistTitle_TxtBox.Enabled = (this.DeleteSetlist_Btn.Enabled = gh3Setlist_0.method_4());
			//this.CreateSetlist_Btn.Enabled = (this.gh3Songlist_0.CustomBitMask != -1);
			this.SetlistPrefix_TxtBox.Text = gh3Setlist_0.prefix;
			this.SetlistInitMovie_TxtBox.Text = gh3Setlist_0.initial_movie;
			this.TierBox.Items.Clear();
			this.TierBox.Items.AddRange(gh3Setlist_0.tiers.ToArray());
			if (this.TierBox.Items.Count != 0)
			{
				this.TierBox.SelectedIndex = 0;
			}
			else
			{
				this.method_23();
			}
			this.SetlistApply_Btn.Enabled = false;
		}

		private void Setlist_DropBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_11(this.gh3Songlist_0.gh3SetlistList[this.int_0 = this.gh3Songlist_0.method_9((string)this.Setlist_DropBox.SelectedItem)]);
		}

		private void CreateSetlist_Btn_Click(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0.CustomBitMask == -1)
			{
				return;
			}
			GH3Setlist gH3Setlist = new GH3Setlist();
			gH3Setlist.method_3("scripts\\guitar\\custom_menu\\guitar_custom_progression.qb");
			gH3Setlist.initial_movie = "";
			gH3Setlist.tiers.Add(new GH3Tier());
			for (int i = 0; ; )
			{
                //num = 2^numOfSetlists
				int num = 1 << i;
                if (!((this.gh3Songlist_0.CustomBitMask & num) == 0)) {
                    goto SKIPIT;
                }
                //2^numOfSetlists - 1

                    this.gh3Songlist_0.CustomBitMask |= (gH3Setlist.CustomBit = num);

                    IL_7E:
                    gH3Setlist.prefix = "custom" + (i + 1);
					int num2;
					this.gh3Songlist_0.gh3SetlistList.Add(num2 = Class327.smethod_9("gh3_custom" + (i + 1) + "_songs"), gH3Setlist);
					int value;
					this.gh3Songlist_0.dictionary_1.Add(value = Class327.smethod_9("custom" + (i + 1) + "_progression"), new GHLink(num2));
					string text;
					this.gh3Songlist_0.class214_0.Add(text = "Custom Setlist " + (i + 1), value);
					this.Setlist_DropBox.Items.Add(text);
					this.Setlist_DropBox.SelectedItem = text;
					this.method_4(new Class246(value, this.class319_0, this.gh3Songlist_0, true));
					this.method_4(new Class256(this.class319_0, this.gh3Songlist_0, this.bool_0));
					return;
            SKIPIT:
                i++;
                if (i >= 32)
                {
                    goto IL_7E;
                }
			}

		}

		private void DeleteSetlist_Btn_Click(object sender, EventArgs e)
		{
			if (!this.gh3Songlist_0.gh3SetlistList[this.int_0].method_4())
			{
				return;
			}
			string text = (string)this.Setlist_DropBox.SelectedItem;
			this.Setlist_DropBox.SelectedIndex--;
			this.Setlist_DropBox.Items.Remove(text);
			this.method_4(new Class246(this.gh3Songlist_0.class214_0[text], this.class319_0, this.gh3Songlist_0, false));
			this.method_4(new Class256(this.class319_0, this.gh3Songlist_0, this.bool_0));
		}

		private void SetlistTitle_TxtBox_TextChanged(object sender, EventArgs e)
		{
			this.SetlistApply_Btn.Enabled = true;
		}

		private void SetlistApply_Btn_Click(object sender, EventArgs e)
		{
			GH3Setlist gH3Setlist = this.gh3Songlist_0.gh3SetlistList[this.int_0];
			gH3Setlist.initial_movie = this.SetlistInitMovie_TxtBox.Text;
			gH3Setlist.tiers.Clear();
			foreach (GH3Tier item in this.TierBox.Items)
			{
				gH3Setlist.tiers.Add(item);
			}
			if (this.SetlistTitle_TxtBox.Text != (string)this.Setlist_DropBox.SelectedItem)
			{
				this.gh3Songlist_0.class214_0.Add(this.SetlistTitle_TxtBox.Text, this.gh3Songlist_0.class214_0[(string)this.Setlist_DropBox.SelectedItem]);
				this.gh3Songlist_0.class214_0.Remove((string)this.Setlist_DropBox.SelectedItem);
				this.method_4(new Class256(this.class319_0, this.gh3Songlist_0, this.bool_0));
				this.Setlist_DropBox.Items[this.Setlist_DropBox.SelectedIndex] = this.SetlistTitle_TxtBox.Text;
			}
			this.SetlistApply_Btn.Enabled = false;
			this.method_4(new Class255(this.int_0, this.class319_0, this.gh3Songlist_0));
		}

		private void NewTier_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.gh3Songlist_0.gh3SetlistList.ContainsKey(this.int_0))
			{
				this.TierBox.Items.Add(new GH3Tier());
				this.TierBox.SelectedIndex = this.TierBox.Items.Count - 1;
				this.SetlistApply_Btn.Enabled = true;
			}
		}

		private void ManageTiers_MenuItem_Click(object sender, EventArgs e)
		{
			if (this.TierBox.SelectedIndex >= 0)
			{
				List<GH3Tier> list = new List<GH3Tier>();
				foreach (GH3Tier item in this.TierBox.Items)
				{
					list.Add(item);
				}
				TierManagement tierManagement = new TierManagement((string)this.Setlist_DropBox.SelectedItem, list.ToArray());
				if (tierManagement.ShowDialog() == DialogResult.OK)
				{
					this.TierBox.Items.Clear();
					this.TierBox.Items.AddRange(tierManagement.method_0());
					if (this.TierBox.Items.Count != 0)
					{
						this.TierBox.SelectedIndex = 0;
					}
					else
					{
						this.method_23();
					}
					this.SetlistApply_Btn.Enabled = true;
				}
			}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SysHigh_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysAbove_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysNormal_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysBelow_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.MinToTray_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysExit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.File_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGameSettings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecoverGameSettings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearGameSettings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteActions_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearActions_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveTGH_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSGH_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveChart_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSetlistAsChartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Add_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSong_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tier_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTier_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TGHImport_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MassImporter_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LegacyImporter_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecoverSonglist_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageGame_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageTiers_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TGHSwitch_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SGHSwitch_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.GameSettingsSwitch_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreLast_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreOriginal_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileControl_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TexExplorer_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FxSpeedBoost_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageSongs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongProps_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebuildSong_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SilentGuitar_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForceMp3Conversion_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSong_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSong_ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.HideUnEdit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideUsed_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ByTitle_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Guide_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScoreHero_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GH3Folder_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Disclaimer_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionRequests_ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.SongListBox = new ns16.Class238();
            this.notifyIcon_0 = new System.Windows.Forms.NotifyIcon(this.components);
            this.fontDialog_0 = new System.Windows.Forms.FontDialog();
            this.leftClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SysEnglish_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysFrench_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysItalian_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysSpanish_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysGerman_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SysKorean_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongEditorTab = new System.Windows.Forms.TabPage();
            this.SongEditor_Container = new System.Windows.Forms.ToolStripContainer();
            this.SongEditor_BottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToggleElements_EditorSplitBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.StarView_EditorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.HopoView_EditorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioView_EditorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.BeatSize_EditorTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.HyperSpeed_EditorBar = new ns16.Control0();
            this.FretAngle_EditorBar = new ns16.Control0();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.Offset_EditorTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.SongEditor_Control = new ns17.SongEditor();
            this.SongEditor_TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.GameMode_EditorBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadChart_EditorBtn = new System.Windows.Forms.ToolStripButton();
            this.SelectedTrack_EditorBox = new System.Windows.Forms.ToolStripComboBox();
            this.SongName_EditorLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadAudio_EditorBtn = new System.Windows.Forms.ToolStripButton();
            this.PlayPause_EditorBtn = new System.Windows.Forms.ToolStripButton();
            this.Stop_EditorBtn = new System.Windows.Forms.ToolStripButton();
            this.PlayTime_EditorLbl = new System.Windows.Forms.ToolStripLabel();
            this.SetlistTab = new System.Windows.Forms.TabPage();
            this.SetlistConfig_Container = new System.Windows.Forms.ToolStripContainer();
            this.SetlistConf_TLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Setlist_TLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TierBox = new System.Windows.Forms.ComboBox();
            this.SetlistInitMovie_TxtBox = new System.Windows.Forms.TextBox();
            this.SetlistPrefix_TxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SetlistTitle_TxtBox = new System.Windows.Forms.TextBox();
            this.Tier_TLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TierProps_Panel = new System.Windows.Forms.Panel();
            this.TierUnlockedSet_Btn = new System.Windows.Forms.Button();
            this.UnlockAll_CheckBox = new System.Windows.Forms.CheckBox();
            this.NoCash_CheckBox = new System.Windows.Forms.CheckBox();
            this.TierApply_Btn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SetlistApply_Btn = new System.Windows.Forms.Button();
            this.TierCompMovie_TxtBox = new System.Windows.Forms.TextBox();
            this.TierUnlocked_NumBox = new System.Windows.Forms.NumericUpDown();
            this.TierTitle_TxtBox = new System.Windows.Forms.TextBox();
            this.TierIcon_DropBox = new System.Windows.Forms.ComboBox();
            this.TierStage_DropBox = new System.Windows.Forms.ComboBox();
            this.TierBoss_CheckBox = new System.Windows.Forms.CheckBox();
            this.TierEncorep2_CheckBox = new System.Windows.Forms.CheckBox();
            this.TierEncorep1_CheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TierSongs_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.TierSongs_ListBox = new ns16.Class238();
            this.label11 = new System.Windows.Forms.Label();
            this.SetlistStrip = new System.Windows.Forms.ToolStrip();
            this.Setlist_Lbl = new System.Windows.Forms.ToolStripLabel();
            this.Setlist_DropBox = new System.Windows.Forms.ToolStripComboBox();
            this.CreateSetlist_Btn = new System.Windows.Forms.ToolStripButton();
            this.DeleteSetlist_Btn = new System.Windows.Forms.ToolStripButton();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.forceRB3MidConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenu.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.SidePanel.SuspendLayout();
            this.leftClickMenu.SuspendLayout();
            this.SongEditorTab.SuspendLayout();
            this.SongEditor_Container.BottomToolStripPanel.SuspendLayout();
            this.SongEditor_Container.ContentPanel.SuspendLayout();
            this.SongEditor_Container.TopToolStripPanel.SuspendLayout();
            this.SongEditor_Container.SuspendLayout();
            this.SongEditor_BottomToolStrip.SuspendLayout();
            this.SongEditor_TopToolStrip.SuspendLayout();
            this.SetlistTab.SuspendLayout();
            this.SetlistConfig_Container.ContentPanel.SuspendLayout();
            this.SetlistConfig_Container.TopToolStripPanel.SuspendLayout();
            this.SetlistConfig_Container.SuspendLayout();
            this.SetlistConf_TLPanel.SuspendLayout();
            this.Setlist_TLPanel.SuspendLayout();
            this.Tier_TLPanel.SuspendLayout();
            this.TierProps_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TierUnlocked_NumBox)).BeginInit();
            this.TierSongs_Panel.SuspendLayout();
            this.SetlistStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.MainContainer.BottomToolStripPanel.SuspendLayout();
            this.MainContainer.ContentPanel.SuspendLayout();
            this.MainContainer.TopToolStripPanel.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SysHigh_MenuItem,
            this.SysAbove_MenuItem,
            this.SysNormal_MenuItem,
            this.SysBelow_MenuItem,
            this.toolStripSeparator8,
            this.MinToTray_MenuItem,
            this.SysExit_MenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(167, 142);
            // 
            // SysHigh_MenuItem
            // 
            this.SysHigh_MenuItem.Name = "SysHigh_MenuItem";
            this.SysHigh_MenuItem.ShowShortcutKeys = false;
            this.SysHigh_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.SysHigh_MenuItem.Tag = "high";
            this.SysHigh_MenuItem.Text = "High";
            this.SysHigh_MenuItem.Click += new System.EventHandler(this.SysBelow_MenuItem_Click);
            // 
            // SysAbove_MenuItem
            // 
            this.SysAbove_MenuItem.Name = "SysAbove_MenuItem";
            this.SysAbove_MenuItem.ShowShortcutKeys = false;
            this.SysAbove_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.SysAbove_MenuItem.Tag = "above";
            this.SysAbove_MenuItem.Text = "Above Normal";
            this.SysAbove_MenuItem.Click += new System.EventHandler(this.SysBelow_MenuItem_Click);
            // 
            // SysNormal_MenuItem
            // 
            this.SysNormal_MenuItem.Name = "SysNormal_MenuItem";
            this.SysNormal_MenuItem.ShowShortcutKeys = false;
            this.SysNormal_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.SysNormal_MenuItem.Tag = "normal";
            this.SysNormal_MenuItem.Text = "Normal";
            this.SysNormal_MenuItem.Click += new System.EventHandler(this.SysBelow_MenuItem_Click);
            // 
            // SysBelow_MenuItem
            // 
            this.SysBelow_MenuItem.Name = "SysBelow_MenuItem";
            this.SysBelow_MenuItem.ShowShortcutKeys = false;
            this.SysBelow_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.SysBelow_MenuItem.Tag = "below";
            this.SysBelow_MenuItem.Text = "Below Normal";
            this.SysBelow_MenuItem.Click += new System.EventHandler(this.SysBelow_MenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(163, 6);
            // 
            // MinToTray_MenuItem
            // 
            this.MinToTray_MenuItem.CheckOnClick = true;
            this.MinToTray_MenuItem.Name = "MinToTray_MenuItem";
            this.MinToTray_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.MinToTray_MenuItem.Text = "Minimize To Tray";
            // 
            // SysExit_MenuItem
            // 
            this.SysExit_MenuItem.Name = "SysExit_MenuItem";
            this.SysExit_MenuItem.ShowShortcutKeys = false;
            this.SysExit_MenuItem.Size = new System.Drawing.Size(166, 22);
            this.SysExit_MenuItem.Text = "Exit";
            this.SysExit_MenuItem.Click += new System.EventHandler(this.Exit_MenuItem_Click);
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_MenuItem,
            this.Add_MenuItem,
            this.ManageGame_MenuItem,
            this.ManageSongs_MenuItem,
            this.Help_MenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.TopMenuStrip.TabIndex = 2;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // File_MenuItem
            // 
            this.File_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenGameSettings_MenuItem,
            this.RecoverGameSettings_MenuItem,
            this.ClearGameSettings_MenuItem,
            this.ExecuteActions_MenuItem,
            this.ClearActions_MenuItem,
            this.toolStripSeparator1,
            this.SaveTGH_MenuItem,
            this.SaveSGH_MenuItem,
            this.SaveChart_MenuItem,
            this.exportSetlistAsChartsToolStripMenuItem,
            this.toolStripSeparator6,
            this.Exit_MenuItem});
            this.File_MenuItem.Name = "File_MenuItem";
            this.File_MenuItem.Size = new System.Drawing.Size(37, 20);
            this.File_MenuItem.Text = "File";
            // 
            // OpenGameSettings_MenuItem
            // 
            this.OpenGameSettings_MenuItem.Name = "OpenGameSettings_MenuItem";
            this.OpenGameSettings_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenGameSettings_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.OpenGameSettings_MenuItem.Text = "&Open Game Settings";
            this.OpenGameSettings_MenuItem.Click += new System.EventHandler(this.OpenGameSettings_MenuItem_Click);
            // 
            // RecoverGameSettings_MenuItem
            // 
            this.RecoverGameSettings_MenuItem.Name = "RecoverGameSettings_MenuItem";
            this.RecoverGameSettings_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RecoverGameSettings_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.RecoverGameSettings_MenuItem.Text = "&Recover Game Settings";
            this.RecoverGameSettings_MenuItem.Click += new System.EventHandler(this.RecoverGameSettings_MenuItem_Click);
            // 
            // ClearGameSettings_MenuItem
            // 
            this.ClearGameSettings_MenuItem.Name = "ClearGameSettings_MenuItem";
            this.ClearGameSettings_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.ClearGameSettings_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.ClearGameSettings_MenuItem.Text = "Clear Game Settings";
            this.ClearGameSettings_MenuItem.Click += new System.EventHandler(this.ClearGameSettings_MenuItem_Click);
            // 
            // ExecuteActions_MenuItem
            // 
            this.ExecuteActions_MenuItem.Name = "ExecuteActions_MenuItem";
            this.ExecuteActions_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.ExecuteActions_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.ExecuteActions_MenuItem.Text = "Execute &Actions";
            this.ExecuteActions_MenuItem.Click += new System.EventHandler(this.ExecuteActions_MenuItem_Click);
            // 
            // ClearActions_MenuItem
            // 
            this.ClearActions_MenuItem.Name = "ClearActions_MenuItem";
            this.ClearActions_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.ClearActions_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.ClearActions_MenuItem.Text = "&Clear Actions";
            this.ClearActions_MenuItem.Click += new System.EventHandler(this.ClearActions_MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // SaveTGH_MenuItem
            // 
            this.SaveTGH_MenuItem.Name = "SaveTGH_MenuItem";
            this.SaveTGH_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveTGH_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.SaveTGH_MenuItem.Text = "Export &TGH (Tier)";
            this.SaveTGH_MenuItem.Click += new System.EventHandler(this.SaveTGH_MenuItem_Click);
            // 
            // SaveSGH_MenuItem
            // 
            this.SaveSGH_MenuItem.Name = "SaveSGH_MenuItem";
            this.SaveSGH_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.SaveSGH_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.SaveSGH_MenuItem.Text = "Export &SGH (Setlist)";
            this.SaveSGH_MenuItem.Click += new System.EventHandler(this.SaveSGH_MenuItem_Click);
            // 
            // SaveChart_MenuItem
            // 
            this.SaveChart_MenuItem.Name = "SaveChart_MenuItem";
            this.SaveChart_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.SaveChart_MenuItem.Text = "Export Song Chart";
            this.SaveChart_MenuItem.Click += new System.EventHandler(this.SaveChart_MenuItem_Click);
            // 
            // exportSetlistAsChartsToolStripMenuItem
            // 
            this.exportSetlistAsChartsToolStripMenuItem.Name = "exportSetlistAsChartsToolStripMenuItem";
            this.exportSetlistAsChartsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.exportSetlistAsChartsToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.exportSetlistAsChartsToolStripMenuItem.Text = "Export Setlist as Charts";
            this.exportSetlistAsChartsToolStripMenuItem.Click += new System.EventHandler(this.exportSetlistAsChartsToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(261, 6);
            // 
            // Exit_MenuItem
            // 
            this.Exit_MenuItem.Name = "Exit_MenuItem";
            this.Exit_MenuItem.Size = new System.Drawing.Size(264, 22);
            this.Exit_MenuItem.Text = "&Exit";
            this.Exit_MenuItem.Click += new System.EventHandler(this.Exit_MenuItem_Click);
            // 
            // Add_MenuItem
            // 
            this.Add_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSong_MenuItem,
            this.Tier_MenuItem,
            this.MassImporter_MenuItem,
            this.LegacyImporter_MenuItem,
            this.RecoverSonglist_MenuItem});
            this.Add_MenuItem.Name = "Add_MenuItem";
            this.Add_MenuItem.Size = new System.Drawing.Size(41, 20);
            this.Add_MenuItem.Text = "Add";
            // 
            // NewSong_MenuItem
            // 
            this.NewSong_MenuItem.Name = "NewSong_MenuItem";
            this.NewSong_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.NewSong_MenuItem.Size = new System.Drawing.Size(167, 22);
            this.NewSong_MenuItem.Text = "New Song";
            this.NewSong_MenuItem.Click += new System.EventHandler(this.NewSong_MenuItem_Click);
            // 
            // Tier_MenuItem
            // 
            this.Tier_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTier_MenuItem,
            this.TGHImport_MenuItem});
            this.Tier_MenuItem.Name = "Tier_MenuItem";
            this.Tier_MenuItem.Size = new System.Drawing.Size(167, 22);
            this.Tier_MenuItem.Text = "Tier";
            // 
            // NewTier_MenuItem
            // 
            this.NewTier_MenuItem.Name = "NewTier_MenuItem";
            this.NewTier_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.NewTier_MenuItem.Size = new System.Drawing.Size(137, 22);
            this.NewTier_MenuItem.Text = "New";
            this.NewTier_MenuItem.Click += new System.EventHandler(this.NewTier_MenuItem_Click);
            // 
            // TGHImport_MenuItem
            // 
            this.TGHImport_MenuItem.Name = "TGHImport_MenuItem";
            this.TGHImport_MenuItem.Size = new System.Drawing.Size(137, 22);
            this.TGHImport_MenuItem.Text = "TGH Import";
            this.TGHImport_MenuItem.Click += new System.EventHandler(this.TGHImport_MenuItem_Click);
            // 
            // MassImporter_MenuItem
            // 
            this.MassImporter_MenuItem.Name = "MassImporter_MenuItem";
            this.MassImporter_MenuItem.Size = new System.Drawing.Size(167, 22);
            this.MassImporter_MenuItem.Text = "Mass Importer";
            this.MassImporter_MenuItem.Click += new System.EventHandler(this.MassImporter_MenuItem_Click);
            // 
            // LegacyImporter_MenuItem
            // 
            this.LegacyImporter_MenuItem.Enabled = false;
            this.LegacyImporter_MenuItem.Name = "LegacyImporter_MenuItem";
            this.LegacyImporter_MenuItem.Size = new System.Drawing.Size(167, 22);
            this.LegacyImporter_MenuItem.Text = "Legacy Importer";
            this.LegacyImporter_MenuItem.Click += new System.EventHandler(this.LegacyImporter_MenuItem_Click);
            // 
            // RecoverSonglist_MenuItem
            // 
            this.RecoverSonglist_MenuItem.Name = "RecoverSonglist_MenuItem";
            this.RecoverSonglist_MenuItem.Size = new System.Drawing.Size(167, 22);
            this.RecoverSonglist_MenuItem.Text = "Recover Songlist";
            this.RecoverSonglist_MenuItem.Click += new System.EventHandler(this.RecoverSonglist_MenuItem_Click);
            // 
            // ManageGame_MenuItem
            // 
            this.ManageGame_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageTiers_MenuItem,
            this.toolStripSeparator4,
            this.TGHSwitch_MenuItem,
            this.SGHSwitch_MenuItem,
            this.toolStripSeparator11,
            this.GameSettingsSwitch_MenuItem,
            this.RestoreLast_MenuItem,
            this.RestoreOriginal_MenuItem,
            this.toolStripSeparator7,
            this.SaveFileControl_MenuItem,
            this.TexExplorer_MenuItem,
            this.FxSpeedBoost_MenuItem});
            this.ManageGame_MenuItem.Name = "ManageGame_MenuItem";
            this.ManageGame_MenuItem.Size = new System.Drawing.Size(124, 20);
            this.ManageGame_MenuItem.Text = "Game Management";
            // 
            // ManageTiers_MenuItem
            // 
            this.ManageTiers_MenuItem.Name = "ManageTiers_MenuItem";
            this.ManageTiers_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.ManageTiers_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.ManageTiers_MenuItem.Text = "Manage Tiers";
            this.ManageTiers_MenuItem.Click += new System.EventHandler(this.ManageTiers_MenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // TGHSwitch_MenuItem
            // 
            this.TGHSwitch_MenuItem.Name = "TGHSwitch_MenuItem";
            this.TGHSwitch_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.TGHSwitch_MenuItem.Text = "TGH Tier Switch";
            this.TGHSwitch_MenuItem.Click += new System.EventHandler(this.TGHSwitch_MenuItem_Click);
            // 
            // SGHSwitch_MenuItem
            // 
            this.SGHSwitch_MenuItem.Name = "SGHSwitch_MenuItem";
            this.SGHSwitch_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.SGHSwitch_MenuItem.Text = "SGH Setlist Switch";
            this.SGHSwitch_MenuItem.Click += new System.EventHandler(this.SGHSwitch_MenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(234, 6);
            // 
            // GameSettingsSwitch_MenuItem
            // 
            this.GameSettingsSwitch_MenuItem.Name = "GameSettingsSwitch_MenuItem";
            this.GameSettingsSwitch_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.GameSettingsSwitch_MenuItem.Text = "Game Settings Switch";
            this.GameSettingsSwitch_MenuItem.Click += new System.EventHandler(this.GameSettingsSwitch_MenuItem_Click);
            // 
            // RestoreLast_MenuItem
            // 
            this.RestoreLast_MenuItem.Name = "RestoreLast_MenuItem";
            this.RestoreLast_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.RestoreLast_MenuItem.Text = "Restore Last Game Settings";
            this.RestoreLast_MenuItem.Click += new System.EventHandler(this.RestoreLast_MenuItem_Click);
            // 
            // RestoreOriginal_MenuItem
            // 
            this.RestoreOriginal_MenuItem.Name = "RestoreOriginal_MenuItem";
            this.RestoreOriginal_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.RestoreOriginal_MenuItem.Text = "Restore Original Game Settings";
            this.RestoreOriginal_MenuItem.Click += new System.EventHandler(this.RestoreOriginal_MenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(234, 6);
            // 
            // SaveFileControl_MenuItem
            // 
            this.SaveFileControl_MenuItem.Name = "SaveFileControl_MenuItem";
            this.SaveFileControl_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFileControl_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.SaveFileControl_MenuItem.Text = "Save File Patcher";
            this.SaveFileControl_MenuItem.Click += new System.EventHandler(this.SaveFileControl_MenuItem_Click);
            // 
            // TexExplorer_MenuItem
            // 
            this.TexExplorer_MenuItem.Name = "TexExplorer_MenuItem";
            this.TexExplorer_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.TexExplorer_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.TexExplorer_MenuItem.Text = "Texture Explorer";
            this.TexExplorer_MenuItem.Click += new System.EventHandler(this.TexExplorer_MenuItem_Click);
            // 
            // FxSpeedBoost_MenuItem
            // 
            this.FxSpeedBoost_MenuItem.Name = "FxSpeedBoost_MenuItem";
            this.FxSpeedBoost_MenuItem.Size = new System.Drawing.Size(237, 22);
            this.FxSpeedBoost_MenuItem.Text = "FX Speed Boost";
            this.FxSpeedBoost_MenuItem.Click += new System.EventHandler(this.FxSpeedBoost_MenuItem_Click);
            // 
            // ManageSongs_MenuItem
            // 
            this.ManageSongs_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SongProps_MenuItem,
            this.RebuildSong_MenuItem,
            this.SilentGuitar_MenuItem,
            this.ForceMp3Conversion_MenuItem,
            this.forceRB3MidConversionToolStripMenuItem,
            this.DeleteSong_MenuItem,
            this.RemoveSong_ToolStripMenuItem,
            this.HideUnEdit_MenuItem,
            this.HideUsed_MenuItem,
            this.ByTitle_MenuItem});
            this.ManageSongs_MenuItem.Name = "ManageSongs_MenuItem";
            this.ManageSongs_MenuItem.Size = new System.Drawing.Size(135, 20);
            this.ManageSongs_MenuItem.Text = "Songlist Management";
            // 
            // SongProps_MenuItem
            // 
            this.SongProps_MenuItem.Name = "SongProps_MenuItem";
            this.SongProps_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.SongProps_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.SongProps_MenuItem.Text = "Edit Song Properties";
            this.SongProps_MenuItem.Click += new System.EventHandler(this.SongProps_MenuItem_Click);
            // 
            // RebuildSong_MenuItem
            // 
            this.RebuildSong_MenuItem.Name = "RebuildSong_MenuItem";
            this.RebuildSong_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.RebuildSong_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.RebuildSong_MenuItem.Text = "Rebuild Song Data";
            this.RebuildSong_MenuItem.Click += new System.EventHandler(this.RebuildSong_MenuItem_Click);
            // 
            // SilentGuitar_MenuItem
            // 
            this.SilentGuitar_MenuItem.Name = "SilentGuitar_MenuItem";
            this.SilentGuitar_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.SilentGuitar_MenuItem.Text = "Silent Guitar Track";
            this.SilentGuitar_MenuItem.Click += new System.EventHandler(this.SilentGuitar_MenuItem_Click);
            // 
            // ForceMp3Conversion_MenuItem
            // 
            this.ForceMp3Conversion_MenuItem.Name = "ForceMp3Conversion_MenuItem";
            this.ForceMp3Conversion_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.ForceMp3Conversion_MenuItem.Text = "Force Mp3 Conversion";
            this.ForceMp3Conversion_MenuItem.Click += new System.EventHandler(this.ForceMp3Conversion_MenuItem_Click);
            // 
            // DeleteSong_MenuItem
            // 
            this.DeleteSong_MenuItem.Name = "DeleteSong_MenuItem";
            this.DeleteSong_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.DeleteSong_MenuItem.Text = "Delete Song";
            this.DeleteSong_MenuItem.Click += new System.EventHandler(this.DeleteSong_MenuItem_Click);
            // 
            // RemoveSong_ToolStripMenuItem
            // 
            this.RemoveSong_ToolStripMenuItem.Name = "RemoveSong_ToolStripMenuItem";
            this.RemoveSong_ToolStripMenuItem.Size = new System.Drawing.Size(218, 6);
            // 
            // HideUnEdit_MenuItem
            // 
            this.HideUnEdit_MenuItem.Name = "HideUnEdit_MenuItem";
            this.HideUnEdit_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.HideUnEdit_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.HideUnEdit_MenuItem.Text = "Hide Original Songs";
            this.HideUnEdit_MenuItem.Click += new System.EventHandler(this.HideUnEdit_MenuItem_Click);
            // 
            // HideUsed_MenuItem
            // 
            this.HideUsed_MenuItem.Name = "HideUsed_MenuItem";
            this.HideUsed_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.HideUsed_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.HideUsed_MenuItem.Text = "Hide Used Songs";
            this.HideUsed_MenuItem.Click += new System.EventHandler(this.HideUsed_MenuItem_Click);
            // 
            // ByTitle_MenuItem
            // 
            this.ByTitle_MenuItem.Name = "ByTitle_MenuItem";
            this.ByTitle_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.ByTitle_MenuItem.Size = new System.Drawing.Size(221, 22);
            this.ByTitle_MenuItem.Text = "Display By Title";
            this.ByTitle_MenuItem.Click += new System.EventHandler(this.ByTitle_MenuItem_Click);
            // 
            // Help_MenuItem
            // 
            this.Help_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Guide_MenuItem,
            this.ScoreHero_MenuItem,
            this.GH3Folder_MenuItem,
            this.toolStripSeparator3,
            this.Disclaimer_MenuItem,
            this.About_MenuItem});
            this.Help_MenuItem.Name = "Help_MenuItem";
            this.Help_MenuItem.Size = new System.Drawing.Size(44, 20);
            this.Help_MenuItem.Text = "Help";
            // 
            // Guide_MenuItem
            // 
            this.Guide_MenuItem.Name = "Guide_MenuItem";
            this.Guide_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Guide_MenuItem.Size = new System.Drawing.Size(154, 22);
            this.Guide_MenuItem.Text = "Guide";
            this.Guide_MenuItem.Click += new System.EventHandler(this.Guide_MenuItem_Click);
            // 
            // ScoreHero_MenuItem
            // 
            this.ScoreHero_MenuItem.Name = "ScoreHero_MenuItem";
            this.ScoreHero_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ScoreHero_MenuItem.Size = new System.Drawing.Size(154, 22);
            this.ScoreHero_MenuItem.Text = "Score Hero";
            this.ScoreHero_MenuItem.Click += new System.EventHandler(this.ScoreHero_MenuItem_Click);
            // 
            // GH3Folder_MenuItem
            // 
            this.GH3Folder_MenuItem.Name = "GH3Folder_MenuItem";
            this.GH3Folder_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.GH3Folder_MenuItem.Size = new System.Drawing.Size(154, 22);
            this.GH3Folder_MenuItem.Text = "GH3 Folder";
            this.GH3Folder_MenuItem.Click += new System.EventHandler(this.GH3Folder_MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // Disclaimer_MenuItem
            // 
            this.Disclaimer_MenuItem.Name = "Disclaimer_MenuItem";
            this.Disclaimer_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.Disclaimer_MenuItem.Size = new System.Drawing.Size(154, 22);
            this.Disclaimer_MenuItem.Text = "Disclaimer";
            this.Disclaimer_MenuItem.Click += new System.EventHandler(this.Disclaimer_MenuItem_Click);
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.About_MenuItem.Size = new System.Drawing.Size(154, 22);
            this.About_MenuItem.Text = "About";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // ActionRequests_ListBox
            // 
            this.ActionRequests_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionRequests_ListBox.FormattingEnabled = true;
            this.ActionRequests_ListBox.IntegralHeight = false;
            this.ActionRequests_ListBox.Location = new System.Drawing.Point(0, 400);
            this.ActionRequests_ListBox.Margin = new System.Windows.Forms.Padding(0);
            this.ActionRequests_ListBox.Name = "ActionRequests_ListBox";
            this.ActionRequests_ListBox.ScrollAlwaysVisible = true;
            this.ActionRequests_ListBox.Size = new System.Drawing.Size(180, 119);
            this.ActionRequests_ListBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Song List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Action Request";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SidePanel
            // 
            this.SidePanel.ColumnCount = 1;
            this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SidePanel.Controls.Add(this.ActionRequests_ListBox, 0, 3);
            this.SidePanel.Controls.Add(this.label1, 0, 0);
            this.SidePanel.Controls.Add(this.label3, 0, 2);
            this.SidePanel.Controls.Add(this.SongListBox, 0, 1);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.SidePanel.MinimumSize = new System.Drawing.Size(180, 500);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.RowCount = 4;
            this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.SidePanel.Size = new System.Drawing.Size(180, 519);
            this.SidePanel.TabIndex = 7;
            // 
            // SongListBox
            // 
            this.SongListBox.AllowDrop = true;
            this.SongListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SongListBox.FormattingEnabled = true;
            this.SongListBox.IntegralHeight = false;
            this.SongListBox.Location = new System.Drawing.Point(0, 20);
            this.SongListBox.Margin = new System.Windows.Forms.Padding(0);
            this.SongListBox.Name = "SongListBox";
            this.SongListBox.ScrollAlwaysVisible = true;
            this.SongListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SongListBox.Size = new System.Drawing.Size(180, 355);
            this.SongListBox.Sorted = true;
            this.SongListBox.TabIndex = 1;
            this.SongListBox.SelectedIndexChanged += new System.EventHandler(this.SongListBox_SelectedIndexChanged);
            this.SongListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SongListBox_KeyDown);
            this.SongListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SongListBox_MouseDown);
            // 
            // notifyIcon_0
            // 
            this.notifyIcon_0.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_0.Icon")));
            this.notifyIcon_0.Text = "Guitar Hero Three Control Panel+";
            this.notifyIcon_0.Visible = true;
            this.notifyIcon_0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_0_MouseDown);
            // 
            // fontDialog_0
            // 
            this.fontDialog_0.Color = System.Drawing.Color.Red;
            this.fontDialog_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog_0.ShowColor = true;
            // 
            // leftClickMenu
            // 
            this.leftClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SysEnglish_MenuItem,
            this.SysFrench_MenuItem,
            this.SysItalian_MenuItem,
            this.SysSpanish_MenuItem,
            this.SysGerman_MenuItem,
            this.SysKorean_MenuItem});
            this.leftClickMenu.Name = "leftClickMenu";
            this.leftClickMenu.Size = new System.Drawing.Size(118, 136);
            // 
            // SysEnglish_MenuItem
            // 
            this.SysEnglish_MenuItem.Name = "SysEnglish_MenuItem";
            this.SysEnglish_MenuItem.ShowShortcutKeys = false;
            this.SysEnglish_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysEnglish_MenuItem.Tag = "en";
            this.SysEnglish_MenuItem.Text = "(English)";
            this.SysEnglish_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SysFrench_MenuItem
            // 
            this.SysFrench_MenuItem.Name = "SysFrench_MenuItem";
            this.SysFrench_MenuItem.ShowShortcutKeys = false;
            this.SysFrench_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysFrench_MenuItem.Tag = "fr";
            this.SysFrench_MenuItem.Text = "(French)";
            this.SysFrench_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SysItalian_MenuItem
            // 
            this.SysItalian_MenuItem.Name = "SysItalian_MenuItem";
            this.SysItalian_MenuItem.ShowShortcutKeys = false;
            this.SysItalian_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysItalian_MenuItem.Tag = "it";
            this.SysItalian_MenuItem.Text = "(Italian)";
            this.SysItalian_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SysSpanish_MenuItem
            // 
            this.SysSpanish_MenuItem.Name = "SysSpanish_MenuItem";
            this.SysSpanish_MenuItem.ShowShortcutKeys = false;
            this.SysSpanish_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysSpanish_MenuItem.Tag = "es";
            this.SysSpanish_MenuItem.Text = "(Spanish)";
            this.SysSpanish_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SysGerman_MenuItem
            // 
            this.SysGerman_MenuItem.Name = "SysGerman_MenuItem";
            this.SysGerman_MenuItem.ShowShortcutKeys = false;
            this.SysGerman_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysGerman_MenuItem.Tag = "de";
            this.SysGerman_MenuItem.Text = "(German)";
            this.SysGerman_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SysKorean_MenuItem
            // 
            this.SysKorean_MenuItem.Name = "SysKorean_MenuItem";
            this.SysKorean_MenuItem.ShowShortcutKeys = false;
            this.SysKorean_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.SysKorean_MenuItem.Tag = "ko";
            this.SysKorean_MenuItem.Text = "(Korean)";
            this.SysKorean_MenuItem.Click += new System.EventHandler(this.SysKorean_MenuItem_Click);
            // 
            // SongEditorTab
            // 
            this.SongEditorTab.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SongEditorTab.Controls.Add(this.SongEditor_Container);
            this.SongEditorTab.Location = new System.Drawing.Point(4, 22);
            this.SongEditorTab.Name = "SongEditorTab";
            this.SongEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.SongEditorTab.Size = new System.Drawing.Size(596, 493);
            this.SongEditorTab.TabIndex = 1;
            this.SongEditorTab.Text = "Song Editor";
            this.SongEditorTab.UseVisualStyleBackColor = true;
            // 
            // SongEditor_Container
            // 
            // 
            // SongEditor_Container.BottomToolStripPanel
            // 
            this.SongEditor_Container.BottomToolStripPanel.Controls.Add(this.SongEditor_BottomToolStrip);
            // 
            // SongEditor_Container.ContentPanel
            // 
            this.SongEditor_Container.ContentPanel.Controls.Add(this.SongEditor_Control);
            this.SongEditor_Container.ContentPanel.Size = new System.Drawing.Size(590, 437);
            this.SongEditor_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SongEditor_Container.Location = new System.Drawing.Point(3, 3);
            this.SongEditor_Container.Name = "SongEditor_Container";
            this.SongEditor_Container.Size = new System.Drawing.Size(590, 487);
            this.SongEditor_Container.TabIndex = 1;
            this.SongEditor_Container.Text = "SongEditor Container";
            // 
            // SongEditor_Container.TopToolStripPanel
            // 
            this.SongEditor_Container.TopToolStripPanel.Controls.Add(this.SongEditor_TopToolStrip);
            // 
            // SongEditor_BottomToolStrip
            // 
            this.SongEditor_BottomToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SongEditor_BottomToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SongEditor_BottomToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleElements_EditorSplitBtn,
            this.toolStripSeparator10,
            this.toolStripLabel1,
            this.BeatSize_EditorTxtBox,
            this.HyperSpeed_EditorBar,
            this.FretAngle_EditorBar,
            this.toolStripSeparator12,
            this.toolStripLabel2,
            this.Offset_EditorTxtBox});
            this.SongEditor_BottomToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SongEditor_BottomToolStrip.Name = "SongEditor_BottomToolStrip";
            this.SongEditor_BottomToolStrip.Size = new System.Drawing.Size(590, 25);
            this.SongEditor_BottomToolStrip.Stretch = true;
            this.SongEditor_BottomToolStrip.TabIndex = 0;
            // 
            // ToggleElements_EditorSplitBtn
            // 
            this.ToggleElements_EditorSplitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToggleElements_EditorSplitBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StarView_EditorBtn,
            this.HopoView_EditorBtn,
            this.AudioView_EditorBtn});
            this.ToggleElements_EditorSplitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToggleElements_EditorSplitBtn.Name = "ToggleElements_EditorSplitBtn";
            this.ToggleElements_EditorSplitBtn.Size = new System.Drawing.Size(111, 22);
            this.ToggleElements_EditorSplitBtn.Text = "Toggle Elements";
            this.ToggleElements_EditorSplitBtn.ButtonClick += new System.EventHandler(this.ToggleElements_EditorSplitBtn_ButtonClick);
            // 
            // StarView_EditorBtn
            // 
            this.StarView_EditorBtn.Checked = true;
            this.StarView_EditorBtn.CheckOnClick = true;
            this.StarView_EditorBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StarView_EditorBtn.Name = "StarView_EditorBtn";
            this.StarView_EditorBtn.Size = new System.Drawing.Size(130, 22);
            this.StarView_EditorBtn.Text = "Star Power";
            this.StarView_EditorBtn.Click += new System.EventHandler(this.StarView_EditorBtn_Click);
            // 
            // HopoView_EditorBtn
            // 
            this.HopoView_EditorBtn.Checked = true;
            this.HopoView_EditorBtn.CheckOnClick = true;
            this.HopoView_EditorBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HopoView_EditorBtn.Name = "HopoView_EditorBtn";
            this.HopoView_EditorBtn.Size = new System.Drawing.Size(130, 22);
            this.HopoView_EditorBtn.Text = "HoPo";
            this.HopoView_EditorBtn.Click += new System.EventHandler(this.HopoView_EditorBtn_Click);
            // 
            // AudioView_EditorBtn
            // 
            this.AudioView_EditorBtn.Checked = true;
            this.AudioView_EditorBtn.CheckOnClick = true;
            this.AudioView_EditorBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AudioView_EditorBtn.Name = "AudioView_EditorBtn";
            this.AudioView_EditorBtn.Size = new System.Drawing.Size(130, 22);
            this.AudioView_EditorBtn.Text = "Audio";
            this.AudioView_EditorBtn.Click += new System.EventHandler(this.AudioView_EditorBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel1.Text = "Beat Size:";
            // 
            // BeatSize_EditorTxtBox
            // 
            this.BeatSize_EditorTxtBox.Name = "BeatSize_EditorTxtBox";
            this.BeatSize_EditorTxtBox.Size = new System.Drawing.Size(30, 25);
            this.BeatSize_EditorTxtBox.Text = "20";
            this.BeatSize_EditorTxtBox.TextChanged += new System.EventHandler(this.BeatSize_EditorTxtBox_TextChanged);
            // 
            // HyperSpeed_EditorBar
            // 
            this.HyperSpeed_EditorBar.Name = "HyperSpeed_EditorBar";
            this.HyperSpeed_EditorBar.Size = new System.Drawing.Size(104, 22);
            this.HyperSpeed_EditorBar.ToolTipText = "HyperSpeed";
            // 
            // FretAngle_EditorBar
            // 
            this.FretAngle_EditorBar.Name = "FretAngle_EditorBar";
            this.FretAngle_EditorBar.Size = new System.Drawing.Size(104, 22);
            this.FretAngle_EditorBar.ToolTipText = "FretBar Angle";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "Offset:";
            // 
            // Offset_EditorTxtBox
            // 
            this.Offset_EditorTxtBox.Name = "Offset_EditorTxtBox";
            this.Offset_EditorTxtBox.Size = new System.Drawing.Size(50, 25);
            this.Offset_EditorTxtBox.Text = "20";
            this.Offset_EditorTxtBox.TextChanged += new System.EventHandler(this.Offset_EditorTxtBox_TextChanged);
            // 
            // SongEditor_Control
            // 
            this.SongEditor_Control.BackColor = System.Drawing.Color.White;
            this.SongEditor_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SongEditor_Control.Location = new System.Drawing.Point(0, 0);
            this.SongEditor_Control.Name = "SongEditor_Control";
            this.SongEditor_Control.Size = new System.Drawing.Size(590, 437);
            this.SongEditor_Control.TabIndex = 0;
            // 
            // SongEditor_TopToolStrip
            // 
            this.SongEditor_TopToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SongEditor_TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SongEditor_TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMode_EditorBtn,
            this.toolStripSeparator5,
            this.LoadChart_EditorBtn,
            this.SelectedTrack_EditorBox,
            this.SongName_EditorLbl,
            this.toolStripSeparator2,
            this.LoadAudio_EditorBtn,
            this.PlayPause_EditorBtn,
            this.Stop_EditorBtn,
            this.PlayTime_EditorLbl});
            this.SongEditor_TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SongEditor_TopToolStrip.Name = "SongEditor_TopToolStrip";
            this.SongEditor_TopToolStrip.Size = new System.Drawing.Size(590, 25);
            this.SongEditor_TopToolStrip.Stretch = true;
            this.SongEditor_TopToolStrip.TabIndex = 0;
            // 
            // GameMode_EditorBtn
            // 
            this.GameMode_EditorBtn.Checked = true;
            this.GameMode_EditorBtn.CheckOnClick = true;
            this.GameMode_EditorBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GameMode_EditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GameMode_EditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GameMode_EditorBtn.Name = "GameMode_EditorBtn";
            this.GameMode_EditorBtn.Size = new System.Drawing.Size(76, 22);
            this.GameMode_EditorBtn.Text = "Game Mode";
            this.GameMode_EditorBtn.Click += new System.EventHandler(this.GameMode_EditorBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // LoadChart_EditorBtn
            // 
            this.LoadChart_EditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadChart_EditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadChart_EditorBtn.Name = "LoadChart_EditorBtn";
            this.LoadChart_EditorBtn.Size = new System.Drawing.Size(69, 22);
            this.LoadChart_EditorBtn.Text = "Load Chart";
            this.LoadChart_EditorBtn.Click += new System.EventHandler(this.LoadChart_EditorBtn_Click);
            // 
            // SelectedTrack_EditorBox
            // 
            this.SelectedTrack_EditorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedTrack_EditorBox.Name = "SelectedTrack_EditorBox";
            this.SelectedTrack_EditorBox.Size = new System.Drawing.Size(100, 25);
            this.SelectedTrack_EditorBox.SelectedIndexChanged += new System.EventHandler(this.SelectedTrack_EditorBox_SelectedIndexChanged);
            // 
            // SongName_EditorLbl
            // 
            this.SongName_EditorLbl.Name = "SongName_EditorLbl";
            this.SongName_EditorLbl.Size = new System.Drawing.Size(69, 22);
            this.SongName_EditorLbl.Text = "Song Name";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // LoadAudio_EditorBtn
            // 
            this.LoadAudio_EditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadAudio_EditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadAudio_EditorBtn.Name = "LoadAudio_EditorBtn";
            this.LoadAudio_EditorBtn.Size = new System.Drawing.Size(72, 22);
            this.LoadAudio_EditorBtn.Text = "Load Audio";
            this.LoadAudio_EditorBtn.Click += new System.EventHandler(this.LoadAudio_EditorBtn_Click);
            // 
            // PlayPause_EditorBtn
            // 
            this.PlayPause_EditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PlayPause_EditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayPause_EditorBtn.Name = "PlayPause_EditorBtn";
            this.PlayPause_EditorBtn.Size = new System.Drawing.Size(69, 22);
            this.PlayPause_EditorBtn.Text = "Play/Pause";
            this.PlayPause_EditorBtn.Click += new System.EventHandler(this.PlayPause_EditorBtn_Click);
            // 
            // Stop_EditorBtn
            // 
            this.Stop_EditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Stop_EditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stop_EditorBtn.Name = "Stop_EditorBtn";
            this.Stop_EditorBtn.Size = new System.Drawing.Size(35, 22);
            this.Stop_EditorBtn.Text = "Stop";
            this.Stop_EditorBtn.Click += new System.EventHandler(this.Stop_EditorBtn_Click);
            // 
            // PlayTime_EditorLbl
            // 
            this.PlayTime_EditorLbl.Name = "PlayTime_EditorLbl";
            this.PlayTime_EditorLbl.Size = new System.Drawing.Size(59, 22);
            this.PlayTime_EditorLbl.Text = "Play Time";
            // 
            // SetlistTab
            // 
            this.SetlistTab.Controls.Add(this.SetlistConfig_Container);
            this.SetlistTab.Location = new System.Drawing.Point(4, 22);
            this.SetlistTab.Name = "SetlistTab";
            this.SetlistTab.Padding = new System.Windows.Forms.Padding(3);
            this.SetlistTab.Size = new System.Drawing.Size(596, 493);
            this.SetlistTab.TabIndex = 0;
            this.SetlistTab.Text = "Setlist Configuration";
            this.SetlistTab.UseVisualStyleBackColor = true;
            // 
            // SetlistConfig_Container
            // 
            // 
            // SetlistConfig_Container.ContentPanel
            // 
            this.SetlistConfig_Container.ContentPanel.Controls.Add(this.SetlistConf_TLPanel);
            this.SetlistConfig_Container.ContentPanel.Size = new System.Drawing.Size(590, 462);
            this.SetlistConfig_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetlistConfig_Container.Location = new System.Drawing.Point(3, 3);
            this.SetlistConfig_Container.Name = "SetlistConfig_Container";
            this.SetlistConfig_Container.Size = new System.Drawing.Size(590, 487);
            this.SetlistConfig_Container.TabIndex = 3;
            this.SetlistConfig_Container.Text = "Setlist Config Container";
            // 
            // SetlistConfig_Container.TopToolStripPanel
            // 
            this.SetlistConfig_Container.TopToolStripPanel.Controls.Add(this.SetlistStrip);
            // 
            // SetlistConf_TLPanel
            // 
            this.SetlistConf_TLPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.SetlistConf_TLPanel.ColumnCount = 1;
            this.SetlistConf_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SetlistConf_TLPanel.Controls.Add(this.Setlist_TLPanel, 0, 0);
            this.SetlistConf_TLPanel.Controls.Add(this.Tier_TLPanel, 0, 1);
            this.SetlistConf_TLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetlistConf_TLPanel.Location = new System.Drawing.Point(0, 0);
            this.SetlistConf_TLPanel.Name = "SetlistConf_TLPanel";
            this.SetlistConf_TLPanel.RowCount = 2;
            this.SetlistConf_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SetlistConf_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SetlistConf_TLPanel.Size = new System.Drawing.Size(590, 462);
            this.SetlistConf_TLPanel.TabIndex = 2;
            // 
            // Setlist_TLPanel
            // 
            this.Setlist_TLPanel.ColumnCount = 4;
            this.Setlist_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Setlist_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Setlist_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Setlist_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Setlist_TLPanel.Controls.Add(this.textBox3, 1, 2);
            this.Setlist_TLPanel.Controls.Add(this.label5, 3, 0);
            this.Setlist_TLPanel.Controls.Add(this.label4, 2, 0);
            this.Setlist_TLPanel.Controls.Add(this.TierBox, 3, 1);
            this.Setlist_TLPanel.Controls.Add(this.SetlistInitMovie_TxtBox, 2, 1);
            this.Setlist_TLPanel.Controls.Add(this.SetlistPrefix_TxtBox, 1, 1);
            this.Setlist_TLPanel.Controls.Add(this.label2, 0, 0);
            this.Setlist_TLPanel.Controls.Add(this.label13, 1, 0);
            this.Setlist_TLPanel.Controls.Add(this.SetlistTitle_TxtBox, 0, 1);
            this.Setlist_TLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Setlist_TLPanel.Location = new System.Drawing.Point(4, 4);
            this.Setlist_TLPanel.Name = "Setlist_TLPanel";
            this.Setlist_TLPanel.RowCount = 3;
            this.Setlist_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Setlist_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.Setlist_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Setlist_TLPanel.Size = new System.Drawing.Size(582, 44);
            this.Setlist_TLPanel.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(148, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(139, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(438, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tiers";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(293, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Initial Movie";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TierBox
            // 
            this.TierBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TierBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TierBox.FormattingEnabled = true;
            this.TierBox.Location = new System.Drawing.Point(438, 23);
            this.TierBox.Name = "TierBox";
            this.TierBox.Size = new System.Drawing.Size(141, 21);
            this.TierBox.TabIndex = 7;
            this.TierBox.SelectedIndexChanged += new System.EventHandler(this.TierBox_SelectedIndexChanged);
            // 
            // SetlistInitMovie_TxtBox
            // 
            this.SetlistInitMovie_TxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetlistInitMovie_TxtBox.Location = new System.Drawing.Point(293, 23);
            this.SetlistInitMovie_TxtBox.Name = "SetlistInitMovie_TxtBox";
            this.SetlistInitMovie_TxtBox.Size = new System.Drawing.Size(139, 20);
            this.SetlistInitMovie_TxtBox.TabIndex = 6;
            this.SetlistInitMovie_TxtBox.TextChanged += new System.EventHandler(this.SetlistTitle_TxtBox_TextChanged);
            // 
            // SetlistPrefix_TxtBox
            // 
            this.SetlistPrefix_TxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetlistPrefix_TxtBox.Enabled = false;
            this.SetlistPrefix_TxtBox.Location = new System.Drawing.Point(148, 23);
            this.SetlistPrefix_TxtBox.Name = "SetlistPrefix_TxtBox";
            this.SetlistPrefix_TxtBox.Size = new System.Drawing.Size(139, 20);
            this.SetlistPrefix_TxtBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(148, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Prefix";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetlistTitle_TxtBox
            // 
            this.SetlistTitle_TxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetlistTitle_TxtBox.Enabled = false;
            this.SetlistTitle_TxtBox.Location = new System.Drawing.Point(3, 23);
            this.SetlistTitle_TxtBox.Name = "SetlistTitle_TxtBox";
            this.SetlistTitle_TxtBox.Size = new System.Drawing.Size(139, 20);
            this.SetlistTitle_TxtBox.TabIndex = 9;
            this.SetlistTitle_TxtBox.TextChanged += new System.EventHandler(this.SetlistTitle_TxtBox_TextChanged);
            // 
            // Tier_TLPanel
            // 
            this.Tier_TLPanel.ColumnCount = 2;
            this.Tier_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tier_TLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.Tier_TLPanel.Controls.Add(this.TierProps_Panel, 0, 0);
            this.Tier_TLPanel.Controls.Add(this.TierSongs_Panel, 1, 0);
            this.Tier_TLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tier_TLPanel.Location = new System.Drawing.Point(4, 55);
            this.Tier_TLPanel.Name = "Tier_TLPanel";
            this.Tier_TLPanel.RowCount = 1;
            this.Tier_TLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tier_TLPanel.Size = new System.Drawing.Size(582, 403);
            this.Tier_TLPanel.TabIndex = 1;
            // 
            // TierProps_Panel
            // 
            this.TierProps_Panel.Controls.Add(this.TierUnlockedSet_Btn);
            this.TierProps_Panel.Controls.Add(this.UnlockAll_CheckBox);
            this.TierProps_Panel.Controls.Add(this.NoCash_CheckBox);
            this.TierProps_Panel.Controls.Add(this.TierApply_Btn);
            this.TierProps_Panel.Controls.Add(this.label12);
            this.TierProps_Panel.Controls.Add(this.SetlistApply_Btn);
            this.TierProps_Panel.Controls.Add(this.TierCompMovie_TxtBox);
            this.TierProps_Panel.Controls.Add(this.TierUnlocked_NumBox);
            this.TierProps_Panel.Controls.Add(this.TierTitle_TxtBox);
            this.TierProps_Panel.Controls.Add(this.TierIcon_DropBox);
            this.TierProps_Panel.Controls.Add(this.TierStage_DropBox);
            this.TierProps_Panel.Controls.Add(this.TierBoss_CheckBox);
            this.TierProps_Panel.Controls.Add(this.TierEncorep2_CheckBox);
            this.TierProps_Panel.Controls.Add(this.TierEncorep1_CheckBox);
            this.TierProps_Panel.Controls.Add(this.label10);
            this.TierProps_Panel.Controls.Add(this.label9);
            this.TierProps_Panel.Controls.Add(this.label8);
            this.TierProps_Panel.Controls.Add(this.label6);
            this.TierProps_Panel.Controls.Add(this.label7);
            this.TierProps_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TierProps_Panel.Location = new System.Drawing.Point(3, 3);
            this.TierProps_Panel.Name = "TierProps_Panel";
            this.TierProps_Panel.Size = new System.Drawing.Size(396, 397);
            this.TierProps_Panel.TabIndex = 0;
            // 
            // TierUnlockedSet_Btn
            // 
            this.TierUnlockedSet_Btn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TierUnlockedSet_Btn.Location = new System.Drawing.Point(242, 55);
            this.TierUnlockedSet_Btn.Name = "TierUnlockedSet_Btn";
            this.TierUnlockedSet_Btn.Size = new System.Drawing.Size(33, 20);
            this.TierUnlockedSet_Btn.TabIndex = 23;
            this.TierUnlockedSet_Btn.Text = "=";
            this.TierUnlockedSet_Btn.UseVisualStyleBackColor = true;
            this.TierUnlockedSet_Btn.Click += new System.EventHandler(this.TierUnlockedSet_Btn_Click);
            // 
            // UnlockAll_CheckBox
            // 
            this.UnlockAll_CheckBox.AutoSize = true;
            this.UnlockAll_CheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnlockAll_CheckBox.Location = new System.Drawing.Point(226, 168);
            this.UnlockAll_CheckBox.Name = "UnlockAll_CheckBox";
            this.UnlockAll_CheckBox.Size = new System.Drawing.Size(97, 23);
            this.UnlockAll_CheckBox.TabIndex = 22;
            this.UnlockAll_CheckBox.Text = "Unlock All";
            this.UnlockAll_CheckBox.UseVisualStyleBackColor = true;
            this.UnlockAll_CheckBox.Visible = false;
            this.UnlockAll_CheckBox.CheckedChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // NoCash_CheckBox
            // 
            this.NoCash_CheckBox.AutoSize = true;
            this.NoCash_CheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoCash_CheckBox.Location = new System.Drawing.Point(128, 168);
            this.NoCash_CheckBox.Name = "NoCash_CheckBox";
            this.NoCash_CheckBox.Size = new System.Drawing.Size(86, 23);
            this.NoCash_CheckBox.TabIndex = 15;
            this.NoCash_CheckBox.Text = "No Cash";
            this.NoCash_CheckBox.UseVisualStyleBackColor = true;
            this.NoCash_CheckBox.CheckedChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierApply_Btn
            // 
            this.TierApply_Btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TierApply_Btn.Location = new System.Drawing.Point(16, 255);
            this.TierApply_Btn.Name = "TierApply_Btn";
            this.TierApply_Btn.Size = new System.Drawing.Size(153, 27);
            this.TierApply_Btn.TabIndex = 17;
            this.TierApply_Btn.Text = "Apply Tier Changes";
            this.TierApply_Btn.UseVisualStyleBackColor = true;
            this.TierApply_Btn.Click += new System.EventHandler(this.TierApply_Btn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(89, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 19);
            this.label12.TabIndex = 21;
            this.label12.Text = "Tier Properties";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetlistApply_Btn
            // 
            this.SetlistApply_Btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetlistApply_Btn.Location = new System.Drawing.Point(175, 255);
            this.SetlistApply_Btn.Name = "SetlistApply_Btn";
            this.SetlistApply_Btn.Size = new System.Drawing.Size(169, 27);
            this.SetlistApply_Btn.TabIndex = 18;
            this.SetlistApply_Btn.Text = "Apply Setlist Changes";
            this.SetlistApply_Btn.UseVisualStyleBackColor = true;
            this.SetlistApply_Btn.Click += new System.EventHandler(this.SetlistApply_Btn_Click);
            // 
            // TierCompMovie_TxtBox
            // 
            this.TierCompMovie_TxtBox.Location = new System.Drawing.Point(156, 84);
            this.TierCompMovie_TxtBox.Name = "TierCompMovie_TxtBox";
            this.TierCompMovie_TxtBox.Size = new System.Drawing.Size(119, 20);
            this.TierCompMovie_TxtBox.TabIndex = 10;
            this.TierCompMovie_TxtBox.TextChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierUnlocked_NumBox
            // 
            this.TierUnlocked_NumBox.Location = new System.Drawing.Point(193, 55);
            this.TierUnlocked_NumBox.Name = "TierUnlocked_NumBox";
            this.TierUnlocked_NumBox.Size = new System.Drawing.Size(43, 20);
            this.TierUnlocked_NumBox.TabIndex = 9;
            this.TierUnlocked_NumBox.ValueChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierTitle_TxtBox
            // 
            this.TierTitle_TxtBox.Location = new System.Drawing.Point(63, 26);
            this.TierTitle_TxtBox.Name = "TierTitle_TxtBox";
            this.TierTitle_TxtBox.Size = new System.Drawing.Size(212, 20);
            this.TierTitle_TxtBox.TabIndex = 8;
            this.TierTitle_TxtBox.TextChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierIcon_DropBox
            // 
            this.TierIcon_DropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TierIcon_DropBox.FormattingEnabled = true;
            this.TierIcon_DropBox.Items.AddRange(new object[] {
            "No Icon"});
            this.TierIcon_DropBox.Location = new System.Drawing.Point(93, 112);
            this.TierIcon_DropBox.Name = "TierIcon_DropBox";
            this.TierIcon_DropBox.Size = new System.Drawing.Size(182, 21);
            this.TierIcon_DropBox.TabIndex = 11;
            this.TierIcon_DropBox.SelectedIndexChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierStage_DropBox
            // 
            this.TierStage_DropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TierStage_DropBox.FormattingEnabled = true;
            this.TierStage_DropBox.Items.AddRange(new object[] {
            "No Preset Stage"});
            this.TierStage_DropBox.Location = new System.Drawing.Point(70, 141);
            this.TierStage_DropBox.Name = "TierStage_DropBox";
            this.TierStage_DropBox.Size = new System.Drawing.Size(205, 21);
            this.TierStage_DropBox.TabIndex = 12;
            this.TierStage_DropBox.SelectedIndexChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierBoss_CheckBox
            // 
            this.TierBoss_CheckBox.AutoSize = true;
            this.TierBoss_CheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TierBoss_CheckBox.Location = new System.Drawing.Point(16, 168);
            this.TierBoss_CheckBox.Name = "TierBoss_CheckBox";
            this.TierBoss_CheckBox.Size = new System.Drawing.Size(106, 23);
            this.TierBoss_CheckBox.TabIndex = 13;
            this.TierBoss_CheckBox.Text = "Boss Battle";
            this.TierBoss_CheckBox.UseVisualStyleBackColor = true;
            this.TierBoss_CheckBox.CheckedChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierEncorep2_CheckBox
            // 
            this.TierEncorep2_CheckBox.AutoSize = true;
            this.TierEncorep2_CheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TierEncorep2_CheckBox.Location = new System.Drawing.Point(128, 197);
            this.TierEncorep2_CheckBox.Name = "TierEncorep2_CheckBox";
            this.TierEncorep2_CheckBox.Size = new System.Drawing.Size(96, 23);
            this.TierEncorep2_CheckBox.TabIndex = 16;
            this.TierEncorep2_CheckBox.Text = "P2 Encore";
            this.TierEncorep2_CheckBox.UseVisualStyleBackColor = true;
            this.TierEncorep2_CheckBox.CheckedChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // TierEncorep1_CheckBox
            // 
            this.TierEncorep1_CheckBox.AutoSize = true;
            this.TierEncorep1_CheckBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TierEncorep1_CheckBox.Location = new System.Drawing.Point(16, 197);
            this.TierEncorep1_CheckBox.Name = "TierEncorep1_CheckBox";
            this.TierEncorep1_CheckBox.Size = new System.Drawing.Size(96, 23);
            this.TierEncorep1_CheckBox.TabIndex = 14;
            this.TierEncorep1_CheckBox.Text = "P1 Encore";
            this.TierEncorep1_CheckBox.UseVisualStyleBackColor = true;
            this.TierEncorep1_CheckBox.CheckedChanged += new System.EventHandler(this.TierEncorep1_CheckBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 19);
            this.label10.TabIndex = 10;
            this.label10.Text = "Stage:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tier Icon:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Completion Movie:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Title:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Default Unlocked Songs:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TierSongs_Panel
            // 
            this.TierSongs_Panel.ColumnCount = 1;
            this.TierSongs_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TierSongs_Panel.Controls.Add(this.TierSongs_ListBox, 0, 1);
            this.TierSongs_Panel.Controls.Add(this.label11, 0, 0);
            this.TierSongs_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TierSongs_Panel.Location = new System.Drawing.Point(405, 3);
            this.TierSongs_Panel.Name = "TierSongs_Panel";
            this.TierSongs_Panel.RowCount = 2;
            this.TierSongs_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TierSongs_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TierSongs_Panel.Size = new System.Drawing.Size(174, 397);
            this.TierSongs_Panel.TabIndex = 1;
            // 
            // TierSongs_ListBox
            // 
            this.TierSongs_ListBox.AllowDrop = true;
            this.TierSongs_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TierSongs_ListBox.FormattingEnabled = true;
            this.TierSongs_ListBox.IntegralHeight = false;
            this.TierSongs_ListBox.Location = new System.Drawing.Point(0, 20);
            this.TierSongs_ListBox.Margin = new System.Windows.Forms.Padding(0);
            this.TierSongs_ListBox.Name = "TierSongs_ListBox";
            this.TierSongs_ListBox.ScrollAlwaysVisible = true;
            this.TierSongs_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TierSongs_ListBox.Size = new System.Drawing.Size(174, 377);
            this.TierSongs_ListBox.TabIndex = 19;
            this.TierSongs_ListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TierSongs_ListBox_KeyDown);
            this.TierSongs_ListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TierSongs_ListBox_MouseDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Tier Songs";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetlistStrip
            // 
            this.SetlistStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SetlistStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SetlistStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Setlist_Lbl,
            this.Setlist_DropBox,
            this.CreateSetlist_Btn,
            this.DeleteSetlist_Btn});
            this.SetlistStrip.Location = new System.Drawing.Point(0, 0);
            this.SetlistStrip.Name = "SetlistStrip";
            this.SetlistStrip.Size = new System.Drawing.Size(590, 25);
            this.SetlistStrip.Stretch = true;
            this.SetlistStrip.TabIndex = 0;
            this.SetlistStrip.Text = "toolStrip1";
            // 
            // Setlist_Lbl
            // 
            this.Setlist_Lbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Setlist_Lbl.Name = "Setlist_Lbl";
            this.Setlist_Lbl.Size = new System.Drawing.Size(56, 22);
            this.Setlist_Lbl.Text = "Setlist:";
            // 
            // Setlist_DropBox
            // 
            this.Setlist_DropBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Setlist_DropBox.Name = "Setlist_DropBox";
            this.Setlist_DropBox.Size = new System.Drawing.Size(121, 25);
            this.Setlist_DropBox.SelectedIndexChanged += new System.EventHandler(this.Setlist_DropBox_SelectedIndexChanged);
            // 
            // CreateSetlist_Btn
            // 
            this.CreateSetlist_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateSetlist_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateSetlist_Btn.Name = "CreateSetlist_Btn";
            this.CreateSetlist_Btn.Size = new System.Drawing.Size(79, 22);
            this.CreateSetlist_Btn.Text = "Create Setlist";
            this.CreateSetlist_Btn.Click += new System.EventHandler(this.CreateSetlist_Btn_Click);
            // 
            // DeleteSetlist_Btn
            // 
            this.DeleteSetlist_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteSetlist_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSetlist_Btn.Name = "DeleteSetlist_Btn";
            this.DeleteSetlist_Btn.Size = new System.Drawing.Size(78, 22);
            this.DeleteSetlist_Btn.Text = "Delete Setlist";
            this.DeleteSetlist_Btn.Click += new System.EventHandler(this.DeleteSetlist_Btn_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(596, 493);
            this.SettingsTab.TabIndex = 5;
            this.SettingsTab.Text = "Progression Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.SettingsTab);
            this.TabControl.Controls.Add(this.SetlistTab);
            this.TabControl.Controls.Add(this.SongEditorTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HotTrack = true;
            this.TabControl.Location = new System.Drawing.Point(180, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.MinimumSize = new System.Drawing.Size(600, 500);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(604, 519);
            this.TabControl.TabIndex = 8;
            // 
            // MainContainer
            // 
            // 
            // MainContainer.BottomToolStripPanel
            // 
            this.MainContainer.BottomToolStripPanel.Controls.Add(this.StatusStrip);
            // 
            // MainContainer.ContentPanel
            // 
            this.MainContainer.ContentPanel.Controls.Add(this.TabControl);
            this.MainContainer.ContentPanel.Controls.Add(this.SidePanel);
            this.MainContainer.ContentPanel.Size = new System.Drawing.Size(784, 519);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.LeftToolStripPanelVisible = false;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.RightToolStripPanelVisible = false;
            this.MainContainer.Size = new System.Drawing.Size(784, 565);
            this.MainContainer.TabIndex = 13;
            this.MainContainer.Text = "toolStripContainer1";
            // 
            // MainContainer.TopToolStripPanel
            // 
            this.MainContainer.TopToolStripPanel.Controls.Add(this.TopMenuStrip);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLbl});
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(784, 22);
            this.StatusStrip.TabIndex = 0;
            // 
            // ToolStripStatusLbl
            // 
            this.ToolStripStatusLbl.Name = "ToolStripStatusLbl";
            this.ToolStripStatusLbl.Size = new System.Drawing.Size(0, 17);
            this.ToolStripStatusLbl.Tag = "Function Description";
            // 
            // forceRB3MidConversionToolStripMenuItem
            // 
            this.forceRB3MidConversionToolStripMenuItem.CheckOnClick = true;
            this.forceRB3MidConversionToolStripMenuItem.Name = "forceRB3MidConversionToolStripMenuItem";
            this.forceRB3MidConversionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.forceRB3MidConversionToolStripMenuItem.Text = "Force RB3 Mid Conversion";
            this.forceRB3MidConversionToolStripMenuItem.Click += new System.EventHandler(this.forceRB3MidConversionToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 565);
            this.Controls.Add(this.MainContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainMenu";
            this.Text = "Guitar Hero Three Control Panel+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainMenu_SizeChanged);
            this.rightClickMenu.ResumeLayout(false);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            this.leftClickMenu.ResumeLayout(false);
            this.SongEditorTab.ResumeLayout(false);
            this.SongEditor_Container.BottomToolStripPanel.ResumeLayout(false);
            this.SongEditor_Container.BottomToolStripPanel.PerformLayout();
            this.SongEditor_Container.ContentPanel.ResumeLayout(false);
            this.SongEditor_Container.TopToolStripPanel.ResumeLayout(false);
            this.SongEditor_Container.TopToolStripPanel.PerformLayout();
            this.SongEditor_Container.ResumeLayout(false);
            this.SongEditor_Container.PerformLayout();
            this.SongEditor_BottomToolStrip.ResumeLayout(false);
            this.SongEditor_BottomToolStrip.PerformLayout();
            this.SongEditor_TopToolStrip.ResumeLayout(false);
            this.SongEditor_TopToolStrip.PerformLayout();
            this.SetlistTab.ResumeLayout(false);
            this.SetlistConfig_Container.ContentPanel.ResumeLayout(false);
            this.SetlistConfig_Container.TopToolStripPanel.ResumeLayout(false);
            this.SetlistConfig_Container.TopToolStripPanel.PerformLayout();
            this.SetlistConfig_Container.ResumeLayout(false);
            this.SetlistConfig_Container.PerformLayout();
            this.SetlistConf_TLPanel.ResumeLayout(false);
            this.Setlist_TLPanel.ResumeLayout(false);
            this.Setlist_TLPanel.PerformLayout();
            this.Tier_TLPanel.ResumeLayout(false);
            this.TierProps_Panel.ResumeLayout(false);
            this.TierProps_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TierUnlocked_NumBox)).EndInit();
            this.TierSongs_Panel.ResumeLayout(false);
            this.TierSongs_Panel.PerformLayout();
            this.SetlistStrip.ResumeLayout(false);
            this.SetlistStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.MainContainer.BottomToolStripPanel.ResumeLayout(false);
            this.MainContainer.BottomToolStripPanel.PerformLayout();
            this.MainContainer.ContentPanel.ResumeLayout(false);
            this.MainContainer.TopToolStripPanel.ResumeLayout(false);
            this.MainContainer.TopToolStripPanel.PerformLayout();
            this.MainContainer.ResumeLayout(false);
            this.MainContainer.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		private void method_12(bool bool_1)
		{
			ToolStripItem arg_1F_0 = this.SaveChart_MenuItem;
			ToolStripItem arg_19_0 = this.RebuildSong_MenuItem;
			this.DeleteSong_MenuItem.Enabled = false;
			arg_19_0.Enabled = false;
			arg_1F_0.Enabled = false;
			ToolStripItem arg_B3_0 = this.Add_MenuItem;
			ToolStripItem arg_AC_0 = this.ManageGame_MenuItem;
			ToolStripItem arg_A2_0 = this.ManageSongs_MenuItem;
			ToolStripItem arg_98_0 = this.ExecuteActions_MenuItem;
			ToolStripItem arg_8E_0 = this.ClearActions_MenuItem;
			ToolStripItem arg_84_0 = this.SaveSGH_MenuItem;
            ToolStripItem export = this.exportSetlistAsChartsToolStripMenuItem;
            ToolStripItem arg_7B_0 = this.SaveTGH_MenuItem;
			Control arg_73_0 = this.SetlistStrip;
			Control arg_6B_0 = this.SetlistConf_TLPanel;
			this.GH3Folder_MenuItem.Enabled = bool_1;
			arg_6B_0.Enabled = bool_1;
			arg_73_0.Enabled = bool_1;
			arg_7B_0.Enabled = bool_1;
			arg_84_0.Enabled = bool_1;
			arg_8E_0.Enabled = bool_1;
			arg_98_0.Enabled = bool_1;
			arg_A2_0.Enabled = bool_1;
			arg_AC_0.Enabled = bool_1;
			arg_B3_0.Enabled = bool_1;
            export.Enabled = bool_1;
		}

		public void method_13()
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_2);
			string[] array = new string[]
			{
				"English",
				"French",
				"Italian",
				"Spanish",
				"German",
				"Korean"
			};
			for (int i = 0; i < array.Length; i++)
			{
				registryKey.SetValue(array[i], this.string_6[i]);
			}
			this.SysEnglish_MenuItem.Text = this.string_6[0];
			this.SysFrench_MenuItem.Text = this.string_6[1];
			this.SysItalian_MenuItem.Text = this.string_6[2];
			this.SysSpanish_MenuItem.Text = this.string_6[3];
			this.SysGerman_MenuItem.Text = this.string_6[4];
			this.SysKorean_MenuItem.Text = this.string_6[5];
		}

		private void OpenGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			this.method_14(false);
		}

		private void RecoverGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			this.method_14(true);
		}

		private void method_14(bool bool_1)
		{
			LoadGameSettings loadGameSettings = new LoadGameSettings(this.string_6);
			if (loadGameSettings.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			this.method_15();
			this.string_6 = loadGameSettings.method_2();
			this.method_13();
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.string_1);
				this.dataFolder = (string)registryKey.GetValue("Path") + "\\DATA\\";
				if (!Directory.Exists(this.dataFolder))
				{
					throw new Exception();
				}
			}
			catch
			{
				string text = Class244.smethod_16("Find Guitar Hero " + (this.bool_0 ? "Aerosmith" : "3"), this.bool_0 ? "Guitar Hero Aerosmith Executable|Guitar Hero Aerosmith.exe" : "Guitar Hero 3 Executable|GH3.exe", true);
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				try
				{
					this.dataFolder = new FileInfo(text).Directory.FullName;
					RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(this.string_1);
					registryKey.SetValue("Path", this.dataFolder);
					this.dataFolder += "\\DATA\\";
				}
				catch
				{
					MessageBox.Show("Guitar Hero " + (this.bool_0 ? "Aerosmith" : "3") + " is not installed properly on this computer.", "Error!");
					return;
				}
			}
			string text2 = this.list_0[loadGameSettings.method_3()];
			int int_ = loadGameSettings.method_3();
			using (new Class217("QB Parse Operations"))
			{
				try
				{
					if (!this.method_16(int_) && DialogResult.Yes == MessageBox.Show("A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && !this.method_17(int_))
					{
						return;
					}
					Class319 class2 = new Class319(string.Concat(new string[]
					{
						this.string_0,
						this.string_3,
						"originals\\qb",
						text2,
						".pak.xen"
					}), string.Concat(new string[]
					{
						this.string_0,
						this.string_3,
						"originals\\qb",
						text2,
						".pab.xen"
					}), false);
					GH3Songlist gH3Songlist = null;
					using (this.class319_0 = new Class319(this.dataFolder + "PAK\\qb" + text2 + ".pak.xen", this.dataFolder + "PAK\\qb" + text2 + ".pab.xen", false))
					{
						if (this.method_19(int_).method_0())
						{
							if (!bool_1)
							{
								goto IL_478;
							}
						}
						try
						{
							gH3Songlist = new GH3Songlist(this.class319_0.method_8("scripts\\guitar\\songlist.qb"), new GH3Songlist(class2.method_8("scripts\\guitar\\songlist.qb"), null));
							new Class252(this.class319_0, gH3Songlist, this.bool_0).method_0();
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
						this.class319_0.Dispose();
						this.class319_0 = null;
						if (gH3Songlist != null)
						{
							DialogResult dialogResult = MessageBox.Show("Game Settings files are not compatible, but something can be recovered. Do you wish to recover when starting from backup? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNoCancel);
							if (dialogResult == DialogResult.Cancel)
							{
								return;
							}
							if (dialogResult == DialogResult.No)
							{
								gH3Songlist = null;
							}
						}
						else if (DialogResult.No == MessageBox.Show("Game Settings files are not compatible, and nothing can be recovered. Do you wish to start from backup? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo))
						{
							return;
						}
						if (!this.method_16(int_))
						{
							return;
						}
						Class244.smethod_19(this.dataFolder + "PAK\\qb" + text2 + ".pab.xen", string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"lastedited\\qb",
							text2,
							".pab.xen"
						}), true);
						Class244.smethod_19(this.dataFolder + "PAK\\qb" + text2 + ".pak.xen", string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"lastedited\\qb",
							text2,
							".pak.xen"
						}), true);
						Class244.smethod_19(string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"originals\\qb",
							text2,
							".pab.xen"
						}), this.dataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
						Class244.smethod_19(string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"originals\\qb",
							text2,
							".pak.xen"
						}), this.dataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
						IL_478:;
					}
					this.class319_0 = new Class319(this.dataFolder + "PAK\\qb" + text2 + ".pak.xen", this.dataFolder + "PAK\\qb" + text2 + ".pab.xen", false);
					this.method_20(int_);
					this.gh3Songlist_0 = new GH3Songlist(this.class319_0.method_8("scripts\\guitar\\songlist.qb"), new GH3Songlist(class2.method_8("scripts\\guitar\\songlist.qb"), null));
					class2.Dispose();
					bool flag = false;
					if (gH3Songlist != null)
					{
						foreach (string current in gH3Songlist.Keys)
						{
							if (!this.gh3Songlist_0.method_3(current))
							{
								this.gh3Songlist_0.Add(gH3Songlist[current]);
								flag = true;
							}
						}
					}
					if (flag)
					{
						this.method_4(new Class247(this.class319_0, this.gh3Songlist_0));
					}
					new Class254(this.class319_0, this.bool_0).method_0();
					new Class252(this.class319_0, this.gh3Songlist_0, this.bool_0).method_0();
					if (flag && gH3Songlist.gh3SetlistList.Count != 0)
					{
						bool flag2 = false;
						using (Dictionary<int, GH3Setlist>.KeyCollection.Enumerator enumerator2 = gH3Songlist.gh3SetlistList.Keys.GetEnumerator())
						{
							IL_78C:
							while (enumerator2.MoveNext())
							{
								int current2 = enumerator2.Current;
								GH3Setlist gH3Setlist = gH3Songlist.gh3SetlistList[current2];
								if (gH3Setlist.method_4())
								{
									try
									{
										/*if (this.gh3Songlist_0.CustomBitMask == -1)
										{
											break;
										}*/
										for (int i = 0; ; )
										{
											int num = 1 << i;
                                            if (!((this.gh3Songlist_0.CustomBitMask & num) == 0))
                                                goto SKIPIT;
											
												this.gh3Songlist_0.CustomBitMask |= (gH3Setlist.CustomBit = num);
												IL_666:
												gH3Setlist.prefix = "custom" + (i + 1);
												int num2;
												this.gh3Songlist_0.gh3SetlistList.Add(num2 = Class327.smethod_9("gh3_custom" + (i + 1) + "_songs"), gH3Setlist);
												int value;
												this.gh3Songlist_0.dictionary_1.Add(value = Class327.smethod_9("custom" + (i + 1) + "_progression"), new GHLink(num2));
												this.gh3Songlist_0.class214_0.Add("Custom Setlist " + (i + 1), value);
												this.method_4(new Class246(value, this.class319_0, this.gh3Songlist_0, true));
												flag2 = true;
												goto IL_78C;
											

                                        SKIPIT:
                                            i++;
                                            if (i >= 32)
                                                goto IL_666;
										}
										
									}
									catch (Exception ex2)
									{
										Console.WriteLine(ex2.ToString());
										continue;
									}
								}
								if (gH3Setlist.method_2() == "scripts\\guitar\\guitar_download.qb")
								{
									this.gh3Songlist_0.gh3SetlistList[current2].method_0().AddRange(gH3Setlist.method_0());
									this.method_4(new Class255(current2, this.class319_0, this.gh3Songlist_0));
								}
							}
						}
						if (flag2)
						{
							this.method_4(new Class256(this.class319_0, this.gh3Songlist_0, this.bool_0));
						}
					}
					new Class249(this.class319_0).method_0();
					new Class253(this.class319_0, this.bool_0).method_0();
					this.method_0();
				}
				catch (Exception ex3)
				{
					if (this.class319_0 != null)
					{
						this.class319_0.Dispose();
						this.class319_0 = null;
					}
					Console.WriteLine(ex3.Message);
					if (DialogResult.Yes == MessageBox.Show("Game Settings files are corrupt. Do you wish to start from backup? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && this.method_16(int_))
					{
						Class244.smethod_19(string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"originals\\qb",
							text2,
							".pab.xen"
						}), this.dataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
						Class244.smethod_19(string.Concat(new string[]
						{
							this.string_0,
							this.string_3,
							"originals\\qb",
							text2,
							".pak.xen"
						}), this.dataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
					}
					return;
				}
			}
			foreach (string current3 in this.gh3Songlist_0.class214_0.Keys)
			{
				this.Setlist_DropBox.Items.Add(current3);
			}
			this.method_12(true);
			if (this.Setlist_DropBox.Items.Count != 0)
			{
				this.Setlist_DropBox.SelectedIndex = 0;
			}
			this.TabControl.SelectedIndex = 1;
		}

		private void ClearGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Clear All Game Settings?", "Warning!", MessageBoxButtons.YesNo))
			{
				this.method_15();
			}
		}

		private void method_15()
		{
			this.method_12(false);
			if (this.gh3Songlist_0 != null)
			{
				this.gh3Songlist_0.Clear();
				this.gh3Songlist_0.gh3SetlistList.Clear();
			}
			this.gh3Songlist_0 = null;
			this.SongListBox.Items.Clear();
			this.Setlist_DropBox.Items.Clear();
			this.ActionRequests_ListBox.Items.Clear();
            this.notifyIcon_0.Visible = false;
			this.method_23();
			if (!Directory.Exists(this.string_0 + "log"))
			{
				Directory.CreateDirectory(this.string_0 + "log");
			}
			Class216.smethod_0(this.string_0 + "log\\");
			Class216.smethod_2();
			if (this.class319_0 != null)
			{
				this.class319_0.Dispose();
			}
			this.class319_0 = null;
			GC.Collect();
		}

		private bool method_16(int int_3)
		{
			string text = string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"originals\\qb",
				this.list_0[int_3],
				".pab.xen"
			});
			int[] icollection_ = this.bool_0 ? this.int_2[int_3] : this.int_1[int_3];
			return File.Exists(text) && File.Exists(text.Replace(".pab.xen", ".pak.xen")) && Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_42(text)), icollection_);
		}

		private bool method_17(int int_3)
		{
			string text = this.dataFolder + "PAK\\qb" + this.list_0[int_3] + ".pab.xen";
			int[] icollection_ = this.bool_0 ? this.int_2[int_3] : this.int_1[int_3];
			while (!File.Exists(text) || !File.Exists(text.Replace(".pab.xen", ".pak.xen")) || !Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_42(text)), icollection_))
			{
				if ((text = Class244.smethod_16("Find The Original V1.3 Game Settings.", "Original V1.3 Game Settings|qb" + this.list_0[int_3] + ".pab.xen", true)).Equals(""))
				{
					return false;
				}
			}
			Class244.smethod_19(text, string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"originals\\qb",
				this.list_0[int_3],
				".pab.xen"
			}), true);
			Class244.smethod_19(text.Replace(".pab.xen", ".pak.xen"), string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"originals\\qb",
				this.list_0[int_3],
				".pak.xen"
			}), true);
			return true;
		}

		private bool method_18()
		{
			bool result;
			try
			{
				Class375.smethod_0(this.class319_0);
				this.class319_0.vmethod_1();
				GC.Collect();
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				result = false;
			}
			return result;
		}

		private Class375 method_19(int int_3)
		{
			if (File.Exists(this.class319_0.string_0) && File.Exists(this.class319_0.string_2) && Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_42(this.class319_0.string_2)), this.bool_0 ? this.int_2[int_3] : this.int_1[int_3]))
			{
				return new Class375(true);
			}
			Class375 result;
			try
			{
				result = new Class375(this.class319_0);
			}
			catch
			{
				result = new Class375(false);
			}
			return result;
		}

		private void method_20(int int_3)
		{
		}

		private void RestoreOriginal_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Do you wish to continue with Original Game Settings Restoration? Current Game Settings will be overwritten!", "Original Game Settings Restoration", MessageBoxButtons.YesNo))
			{
				return;
			}
			string text = Class244.smethod_12(this.class319_0.string_0);
			int int_ = new List<string>(this.list_0).IndexOf(text.Replace("qb", ""));
			if (this.method_16(int_))
			{
				this.method_15();
				Class244.smethod_19(string.Concat(new string[]
				{
					this.string_0,
					this.string_3,
					"originals\\",
					text,
					".pak.xen"
				}), this.dataFolder + "PAK\\" + text + ".pak.xen", true);
				Class244.smethod_19(string.Concat(new string[]
				{
					this.string_0,
					this.string_3,
					"originals\\",
					text,
					".pab.xen"
				}), this.dataFolder + "PAK\\" + text + ".pab.xen", true);
				return;
			}
			this.method_17(int_);
		}

		private void RestoreLast_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Do you wish to continue with Last Game Settings Restoration? Current Game Settings will be overwritten!", "Last Game Settings Restoration", MessageBoxButtons.YesNo))
			{
				return;
			}
			string text = Class244.smethod_12(this.class319_0.string_0);
			if (File.Exists(string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"lastedited\\",
				text,
				".pak.xen"
			})) && File.Exists(string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"lastedited\\",
				text,
				".pab.xen"
			})))
			{
				this.method_15();
				Class244.smethod_19(string.Concat(new string[]
				{
					this.string_0,
					this.string_3,
					"lastedited\\",
					text,
					".pak.xen"
				}), this.dataFolder + "PAK\\" + text + ".pak.xen", true);
				Class244.smethod_19(string.Concat(new string[]
				{
					this.string_0,
					this.string_3,
					"lastedited\\",
					text,
					".pab.xen"
				}), this.dataFolder + "PAK\\" + text + ".pab.xen", true);
				return;
			}
			MessageBox.Show("Last Game Settings were never backuped.", "Error!");
		}

		private void GameSettingsSwitch_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Do you wish to switch Game Settings to a different language? Current Game Settings will be overwritten and you will start from a backup!", "Game Settings Switch", MessageBoxButtons.YesNo))
			{
				return;
			}
			LoadGameSettings loadGameSettings = new LoadGameSettings(new string[]
			{
				"English",
				"French",
				"Italian",
				"Spanish",
				"German",
				"Korean"
			});
			if (loadGameSettings.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			int num = loadGameSettings.method_3();
			string text = Class244.smethod_12(this.class319_0.string_0);
			if (!this.method_16(num) && DialogResult.Yes == MessageBox.Show("A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && !this.method_17(num))
			{
				return;
			}
			new List<string>(this.list_0).IndexOf(text.Replace("qb", ""));
			this.method_15();
			using (Class319 @class = new Class319(string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"originals\\qb",
				this.list_0[num],
				".pak.xen"
			}), string.Concat(new string[]
			{
				this.string_0,
				this.string_3,
				"originals\\qb",
				this.list_0[num],
				".pab.xen"
			}), false))
			{
				Class375.smethod_0(@class);
				@class.method_20(this.dataFolder + "PAK\\" + text + ".pak.xen", this.dataFolder + "PAK\\" + text + ".pab.xen");
			}
			GC.Collect();
		}

		private void method_21(object sender, EventArgs2 e)
		{
			this.TierApply_Btn.Enabled = true;
		}

		private void TierSongs_ListBox_MouseDown(object sender, MouseEventArgs e)
		{
			int num = this.TierSongs_ListBox.IndexFromPoint(e.Location);
			if (num >= 0 && num < this.TierSongs_ListBox.Items.Count && e.Clicks == 2 && e.Button == MouseButtons.Right)
			{
				this.TierSongs_ListBox.Items.RemoveAt(num);
				this.TierApply_Btn.Enabled = true;
			}
		}

		private void TierSongs_ListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && this.SongListBox.SelectedItems.Count != 0 && DialogResult.Yes == MessageBox.Show("The selected songs will be deleted from the Tier!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
			{
				this.TierSongs_ListBox.method_3();
				this.TierApply_Btn.Enabled = true;
			}
		}

		private void method_22(GH3Tier gh3Tier_0)
		{
			this.Tier_TLPanel.Enabled = true;
			this.TierTitle_TxtBox.Text = gh3Tier_0.title;
			this.TierUnlocked_NumBox.Value = gh3Tier_0.defaultunlocked;
			this.TierCompMovie_TxtBox.Text = gh3Tier_0.completion_movie;
			this.TierIcon_DropBox.SelectedItem = gh3Tier_0.setlist_icon;
			this.TierStage_DropBox.SelectedItem = gh3Tier_0.level;
			this.TierEncorep1_CheckBox.Checked = gh3Tier_0.encorep1;
			this.TierEncorep2_CheckBox.Checked = (gh3Tier_0.encorep2 || gh3Tier_0.aerosmith_encore_p1);
			this.TierBoss_CheckBox.Checked = gh3Tier_0.boss;
			this.NoCash_CheckBox.Checked = gh3Tier_0.nocash;
			this.UnlockAll_CheckBox.Checked = gh3Tier_0.unlockall;
			this.TierSongs_ListBox.Items.Clear();
			this.TierSongs_ListBox.Items.AddRange(gh3Tier_0.songs.ToArray());
			this.TierApply_Btn.Enabled = false;
		}

		private void method_23()
		{
			this.TierBox.SelectedIndex = -1;
			this.Tier_TLPanel.Enabled = false;
			this.TierTitle_TxtBox.Text = "";
			this.TierUnlocked_NumBox.Value = 0m;
			this.TierCompMovie_TxtBox.Text = "";
			this.TierIcon_DropBox.SelectedIndex = -1;
			this.TierStage_DropBox.SelectedIndex = -1;
			this.TierEncorep1_CheckBox.Checked = false;
			this.TierEncorep2_CheckBox.Checked = false;
			this.TierBoss_CheckBox.Checked = false;
			this.NoCash_CheckBox.Checked = false;
			this.UnlockAll_CheckBox.Checked = false;
			this.TierSongs_ListBox.Items.Clear();
			this.TierApply_Btn.Enabled = false;
		}

		private void TierBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.TierBox.SelectedIndex >= 0)
			{
				this.method_22((GH3Tier)this.TierBox.Items[this.TierBox.SelectedIndex]);
			}
		}

		private void TierEncorep1_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.TierApply_Btn.Enabled = true;
		}

		private void TierUnlockedSet_Btn_Click(object sender, EventArgs e)
		{
			this.TierUnlocked_NumBox.Value = this.TierSongs_ListBox.Items.Count;
		}

		private void TierApply_Btn_Click(object sender, EventArgs e)
		{
			GH3Tier gH3Tier = (GH3Tier)this.TierBox.Items[this.TierBox.SelectedIndex];
			gH3Tier.title = this.TierTitle_TxtBox.Text;
			gH3Tier.defaultunlocked = Convert.ToInt32(this.TierUnlocked_NumBox.Value);
			gH3Tier.completion_movie = this.TierCompMovie_TxtBox.Text;
			gH3Tier.setlist_icon = (string)this.TierIcon_DropBox.SelectedItem;
			gH3Tier.level = (string)this.TierStage_DropBox.SelectedItem;
			gH3Tier.boss = this.TierBoss_CheckBox.Checked;
			gH3Tier.nocash = this.NoCash_CheckBox.Checked;
			gH3Tier.unlockall = this.UnlockAll_CheckBox.Checked;
			gH3Tier.encorep1 = this.TierEncorep1_CheckBox.Checked;
			if (this.bool_0)
			{
				gH3Tier.aerosmith_encore_p1 = this.TierEncorep2_CheckBox.Checked;
			}
			else
			{
				gH3Tier.encorep2 = this.TierEncorep2_CheckBox.Checked;
			}
			gH3Tier.songs.Clear();
			foreach (GH3Song item in this.TierSongs_ListBox.Items)
			{
				gH3Tier.songs.Add(item);
			}
			this.TierApply_Btn.Enabled = false;
			this.method_4(new Class255(this.int_0, this.class319_0, this.gh3Songlist_0));
			if (this.HideUsed_MenuItem.Checked)
			{
				this.gh3Songlist_0.HideUsed = true;
				this.method_0();
			}
		}

        private void forceRB3MidConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
