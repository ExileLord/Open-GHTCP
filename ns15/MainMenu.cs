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
using GuitarHero;
using GuitarHero.Setlist;
using GuitarHero.Songlist;
using GuitarHero.Tier;
using Microsoft.Win32;
using MidiConverter;
using ns1;
using ns13;
using ns14;
using ns16;
using ns17;
using ns18;
using ns19;
using ns20;
using ns9;

namespace ns15
{
	public class MainMenu : Form
	{
		private readonly string AppDirectory;

		private readonly string GameRegistry;

		private readonly string GhtcpRegistry;

		private readonly string BackupName;

		private string DataFolder;

		private string Priority;

		private string[] LanguageList;

		private GH3Songlist gh3Songlist;

		private int SelectedSetlist;

		private bool IsAerosmith;

		public zzPabNode class319_0;

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

		private ToolStripContainer MainContainer;

		private StatusStrip StatusStrip;

		private ToolStripStatusLabel ToolStripStatusLbl;

		private ToolStripMenuItem RebuildSong_MenuItem;

		private ToolStripSeparator RemoveSong_ToolStripMenuItem;

		private ToolStripMenuItem HideUsed_MenuItem;

		private ToolStripMenuItem ByTitle_MenuItem;

		private ToolStripMenuItem ClearGameSettings_MenuItem;

		private ToolStripMenuItem DeleteSong_MenuItem;

		private ToolStripMenuItem SaveChart_MenuItem;

		private ToolStripMenuItem HideUnEdit_MenuItem;

		private ToolStripMenuItem GameSettingsSwitch_MenuItem;

		private ToolStripMenuItem RestoreLast_MenuItem;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripMenuItem RestoreOriginal_MenuItem;

		private ToolStripMenuItem SaveFileControl_MenuItem;

		private ToolStripMenuItem SysKorean_MenuItem;

		private ToolStripMenuItem RecoverGameSettings_MenuItem;

		private ToolStripMenuItem GH3Folder_MenuItem;

		private zzListBox238 SongListBox;

		private ToolStripMenuItem SilentGuitar_MenuItem;

		private ToolStripMenuItem RecoverSonglist_MenuItem;

		private ToolStripMenuItem MinToTray_MenuItem;

		private ToolStripMenuItem FxSpeedBoost_MenuItem;

		private ToolStripMenuItem ForceMp3Conversion_MenuItem;

        private ToolStripMenuItem exportSetlistAsChartsToolStripMenuItem;

        private ToolStripMenuItem forceRB3MidConversionToolStripMenuItem;


        private List<string> list_0 = new List<string>(new[]
		{
			"",
			"_f",
			"_i",
			"_s",
			"_g",
			"_k"
		});

		private int[][] int_1 = {
			new[]
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
			new[]
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
			new[]
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
			new[]
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
			new[]
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
			new[]
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
        private TabControl TabControl;
        private TabPage SetlistTab;
        private ToolStripContainer SetlistConfig_Container;
        private TableLayoutPanel SetlistConf_TLPanel;
        private TableLayoutPanel Setlist_TLPanel;
        private TextBox textBox3;
        private Label label5;
        private Label label4;
        private ComboBox TierBox;
        private TextBox SetlistInitMovie_TxtBox;
        private TextBox SetlistPrefix_TxtBox;
        private Label label2;
        private Label label13;
        private TextBox SetlistTitle_TxtBox;
        private TableLayoutPanel Tier_TLPanel;
        private Panel TierProps_Panel;
        private Button TierUnlockedSet_Btn;
        private CheckBox UnlockAll_CheckBox;
        private CheckBox NoCash_CheckBox;
        private Button TierApply_Btn;
        private Label label12;
        private Button SetlistApply_Btn;
        private TextBox TierCompMovie_TxtBox;
        private NumericUpDown TierUnlocked_NumBox;
        private TextBox TierTitle_TxtBox;
        private ComboBox TierIcon_DropBox;
        private ComboBox TierStage_DropBox;
        private CheckBox TierBoss_CheckBox;
        private CheckBox TierEncorep2_CheckBox;
        private CheckBox TierEncorep1_CheckBox;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label7;
        private TableLayoutPanel TierSongs_Panel;
        private zzListBox238 TierSongs_ListBox;
        private Label label11;
        private ToolStrip SetlistStrip;
        private ToolStripLabel Setlist_Lbl;
        private ToolStripComboBox Setlist_DropBox;
        private ToolStripButton CreateSetlist_Btn;
        private ToolStripButton DeleteSetlist_Btn;
        private TabPage SongEditorTab;
        private ToolStripContainer SongEditor_Container;
        private ToolStrip SongEditor_BottomToolStrip;
        private ToolStripSplitButton ToggleElements_EditorSplitBtn;
        private ToolStripMenuItem StarView_EditorBtn;
        private ToolStripMenuItem HopoView_EditorBtn;
        private ToolStripMenuItem AudioView_EditorBtn;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox BeatSize_EditorTxtBox;
        private GhtcpToolStripControlHost HyperSpeed_EditorBar;
        private GhtcpToolStripControlHost FretAngle_EditorBar;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox Offset_EditorTxtBox;
        private SongEditor SongEditor_Control;
        private ToolStrip SongEditor_TopToolStrip;
        private ToolStripButton GameMode_EditorBtn;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton LoadChart_EditorBtn;
        private ToolStripComboBox SelectedTrack_EditorBox;
        private ToolStripLabel SongName_EditorLbl;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton LoadAudio_EditorBtn;
        private ToolStripButton PlayPause_EditorBtn;
        private ToolStripButton Stop_EditorBtn;
        private ToolStripLabel PlayTime_EditorLbl;
        private int[][] int_2 = {
			new[]
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
			new[]
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
			new[]
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
			new[]
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
			new[]
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
			new[]
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
			int num = SongListBox.IndexFromPoint(e.X, e.Y);
			if (num >= 0 && num < SongListBox.Items.Count)
			{
				if (e.Clicks == 2 && e.Button == MouseButtons.Left)
				{
					SongProperties songProperties;
					if ((songProperties = new SongProperties((GH3Song)SongListBox.Items[num])).ShowDialog() == DialogResult.OK)
					{
						songProperties.GetSongWithChanges();
						method_4(new Class247(class319_0, gh3Songlist));
					}
				}
				else if (e.Clicks == 2 && e.Button == MouseButtons.Right)
				{
					GH3Song gH3Song = (GH3Song)SongListBox.Items[num];
					if (gH3Song.editable && DialogResult.Yes == MessageBox.Show(gH3Song.name.ToUpper() + " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
					{
						SongListBox.Items.Remove(gH3Song);
						foreach (int current in gh3Songlist.method_1(gH3Song))
						{
							method_4(new zzSetListUpdater(current, class319_0, gh3Songlist));
						}
						method_4(new Class247(class319_0, gh3Songlist));
					}
				}
			}
		}

		private void HideUnEdit_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Songlist arg_1D_0 = gh3Songlist;
			ToolStripMenuItem expr_0C = HideUnEdit_MenuItem;
			arg_1D_0.HideUnEditable = (expr_0C.Checked = !expr_0C.Checked);
			method_0();
		}

		private void HideUsed_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Songlist arg_1D_0 = gh3Songlist;
			ToolStripMenuItem expr_0C = HideUsed_MenuItem;
			arg_1D_0.HideUsed = (expr_0C.Checked = !expr_0C.Checked);
			method_0();
		}

		private void ByTitle_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = ByTitle_MenuItem;
			GH3Song.bool_0 = (expr_06.Checked = !expr_06.Checked);
			method_0();
		}

		private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SongListBox.SelectedItems.Count != 0)
			{
				bool enabled = false;
				foreach (GH3Song song in SongListBox.SelectedItems)
				{
					if (song.editable)
					{
						enabled = true;
					}
				}
                SaveChart_MenuItem.Enabled = (RebuildSong_MenuItem.Enabled = true);
                DeleteSong_MenuItem.Enabled = enabled;
			}
		}

        public static DialogResult MsgBoxEditDefaultSongs()
        {
            return MessageBox.Show("Do you really wish to edit a default song? Editing default songs is dangerous and should only be done if you understand the consequences of doing so.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

		private void SongProps_MenuItem_Click(object sender, EventArgs e)
		{
			SongProperties songProperties;
            if (!((GH3Song)SongListBox.Items[SongListBox.SelectedIndex]).isEditable())
            {
                if (MsgBoxEditDefaultSongs() != DialogResult.Yes)
                    return;
            }
            if (SongListBox.SelectedIndex >= 0 && (songProperties = new SongProperties((GH3Song)SongListBox.Items[SongListBox.SelectedIndex])).ShowDialog() == DialogResult.OK)
			{
				songProperties.GetSongWithChanges();
				method_4(new Class247(class319_0, gh3Songlist));
			}
		}

		private void RebuildSong_MenuItem_Click(object sender, EventArgs e)
		{
			GH3Song song = (GH3Song)SongListBox.Items[SongListBox.SelectedIndex];
            SongData songData;
            if (!song.isEditable())
            {
                if (MsgBoxEditDefaultSongs() != DialogResult.Yes)
                    return;
            }
            if (SongListBox.SelectedIndex >= 0 && (songData = new SongData(song.name, false, false)).ShowDialog() == DialogResult.OK)
			{
				if (songData.bool_1)
				{
					Class250 @class = songData.method_1(class319_0, DataFolder);
					method_4(@class);
					if (DialogResult.Yes == MessageBox.Show("Do you wish to get the song properties from the game track? (Current properties will be overwritten | Mid files have no properties!)", "Tier Exporting", MessageBoxButtons.YesNo))
					{
						bool no_rhythm_track = song.no_rhythm_track;
						bool use_coop_notetracks = song.use_coop_notetracks;
						song.vmethod_0(@class.class362_0.gh3Song_0);
						song.no_rhythm_track = no_rhythm_track;
						song.use_coop_notetracks = use_coop_notetracks;
						method_4(new Class247(class319_0, gh3Songlist));
					}
				}
				if (songData.bool_0)
				{
					Class248 class2 = songData.method_0(DataFolder);
					method_4(class2);
					song.no_rhythm_track = !class2.bool_0;
					song.use_coop_notetracks = class2.bool_1;
					method_4(new Class247(class319_0, gh3Songlist));
				}
			}
		}

		private void SongListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift && e.KeyCode == Keys.Delete && SongListBox.SelectedItems.Count != 0 && DialogResult.Yes == MessageBox.Show("The selected songs will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
			{
				object[] array = SongListBox.imethod_3();
				for (int i = 0; i < array.Length; i++)
				{
					GH3Song gh3Song = (GH3Song)array[i];
					if (gh3Song.editable)
					{
						SongListBox.Items.Remove(gh3Song);
						foreach (int current in gh3Songlist.method_1(gh3Song))
						{
							method_4(new zzSetListUpdater(current, class319_0, gh3Songlist));
						}
						method_4(new Class247(class319_0, gh3Songlist));
					}
				}
			}
		}

		private void DeleteSong_MenuItem_Click(object sender, EventArgs e)
		{
			object[] array = SongListBox.imethod_3();
			for (int i = 0; i < array.Length; i++)
			{
				GH3Song gH3Song = (GH3Song)array[i];
				if (gH3Song.editable && DialogResult.Yes == MessageBox.Show(gH3Song.name.ToUpper() + " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
				{
					SongListBox.Items.Remove(gH3Song);
					foreach (int current in gh3Songlist.method_1(gH3Song))
					{
						method_4(new zzSetListUpdater(current, class319_0, gh3Songlist));
					}
					method_4(new Class247(class319_0, gh3Songlist));
				}
			}
		}

		private void NewSong_MenuItem_Click(object sender, EventArgs e)
		{
			SongData songData = new SongData(gh3Songlist, forceRB3MidConversionToolStripMenuItem.Checked);
			if (songData.ShowDialog() == DialogResult.OK)
			{
				GH3Song gH3Song = IsAerosmith ? new GHASong() : new GH3Song();
				if (songData.bool_1)
				{
					Class250 @class = songData.method_1(class319_0, DataFolder);
					method_4(@class);
					gH3Song.vmethod_0(@class.class362_0.gh3Song_0);
				}
				if (songData.bool_0)
				{
					Class248 class2 = songData.method_0(DataFolder);
					method_4(class2);
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
					songProperties.GetSongWithChanges();
				}
				gh3Songlist.Add(gH3Song.name, gH3Song);
				method_4(new Class247(class319_0, gh3Songlist));
				method_0();
			}
		}

		private void RecoverSonglist_MenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			string[] files = Directory.GetFiles(DataFolder + "music\\", "*.dat.xen", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string text = files[i];
				string text2 = KeyGenerator.GetFileNameNoExt(text);
				if (File.Exists(DataFolder + "music\\" + text2 + ".fsb.xen") && File.Exists(DataFolder + "songs\\" + text2 + "_song.pak.xen") && !gh3Songlist.method_3(text2) && !QbSongClass1.smethod_4(text2) && !GH3Songlist.IgnoreSongs.Contains(QbSongClass1.AddKeyToDictionary(text2)))
				{
					try
					{
						GH3Song gH3Song = IsAerosmith ? new GHASong(text2) : new GH3Song(text2);
						List<string> list = new List<string>(new zzQbSongObject(text).string_1);
						gH3Song.no_rhythm_track = !list.Contains(text2 + "_rhythm");
						gH3Song.use_coop_notetracks = list.Contains(text2 + "_coop_song");
						gh3Songlist.Add(text2, gH3Song);
						flag = true;
					}
					catch
					{
					}
				}
			}
			if (flag)
			{
				method_4(new Class247(class319_0, gh3Songlist));
				method_0();
			}
		}

		private void method_0()
		{
			SongListBox.Items.Clear();
			SongListBox.Items.AddRange(gh3Songlist.getSongs());
		}

		private void LoadChart_EditorBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the game track file.", "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart", true)).Equals(""))
			{
				QBCParser qbcParser;
				try
				{
					if (fileName.EndsWith("_song.pak.xen"))
					{
						string str = KeyGenerator.GetFileName(fileName).Replace("_song.pak.xen", "");
						using (zzPakNode2 @class = new zzPakNode2(fileName, false))
						{
							if (!@class.method_6("songs\\" + str + ".mid.qb"))
							{
								throw new Exception("MID.QB song file not found.");
							}
							qbcParser = new QBCParser(str, @class.zzGetNode1("songs\\" + str + ".mid.qb"));
							goto IL_DA;
						}
					}
					if (fileName.EndsWith(".qbc"))
					{
						qbcParser = new QBCParser(fileName);
					}
					else if (fileName.EndsWith(".mid"))
					{
                        qbcParser = Midi2Chart.LoadMidiSong(fileName, forceRB3MidConversionToolStripMenuItem.Checked);
					}
					else
					{
						qbcParser = new ChartParser(fileName).ConvertToQBC();
                    }
					IL_DA:;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error loading game track file!\n" + ex.Message);
					return;
				}
				SongName_EditorLbl.Text = qbcParser.gh3Song_0.title;
				SelectedTrack_EditorBox.Items.Clear();
				foreach (string current in qbcParser.noteList.Keys)
				{
					SelectedTrack_EditorBox.Items.Add(current);
				}
                SongEditor_Control.LoadChart(qbcParser);
                SelectedTrack_EditorBox.SelectedIndex = 0;
				Offset_EditorTxtBox.Text = string.Concat(qbcParser.gh3Song_0.gem_offset);
			}
		}

		private void BeatSize_EditorTxtBox_TextChanged(object sender, EventArgs e)
		{
			int num;
			try
			{
				num = Convert.ToInt32(BeatSize_EditorTxtBox.Text);
			}
			catch
			{
				return;
			}
			if (num != 0)
			{
				SongEditor_Control.SetBeatSize(num);
			}
		}

		private void Offset_EditorTxtBox_TextChanged(object sender, EventArgs e)
		{
			int int_;
			try
			{
				int_ = Convert.ToInt32(Offset_EditorTxtBox.Text);
			}
			catch
			{
				return;
			}
			SongEditor_Control.SetOffset(int_);
		}

		private void PlayPause_EditorBtn_Click(object sender, EventArgs e)
		{
			if (SongEditor_Control.AudioLoaded())
			{
				if (SongEditor_Control.GetAudioStatus() != AudioStatus.ShouldStartAudio)
				{
					SongEditor_Control.DifferentStartPlaying();
					return;
				}
				SongEditor_Control.StartPlaying();
			}
		}

		private void Stop_EditorBtn_Click(object sender, EventArgs e)
		{
			if (SongEditor_Control.AudioLoaded())
			{
				SongEditor_Control.StopAudio();
			}
		}

		private void LoadAudio_EditorBtn_Click(object sender, EventArgs e)
		{
			string fileName;
			if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Audio track file.", "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio File|*.mp3|Waveform Audio File|*.wav|Ogg Vorbis Audio File|*.ogg|FLAC Audio File|*.flac", true)).Equals(""))
			{
				SongEditor_Control.LoadAudio(fileName);
            }
		}

		private void SelectedTrack_EditorBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SongEditor_Control.Difficulty = (string)SelectedTrack_EditorBox.SelectedItem;
		}

		private void method_1(object sender, EventArgs e)
		{
			PlayTime_EditorLbl.Text = string.Concat((int)sender / 1000f);
		}

		private void GameMode_EditorBtn_Click(object sender, EventArgs e)
		{
			SongEditor_Control.SetGamemodeView(GameMode_EditorBtn.Checked);
		}

		private void ToggleElements_EditorSplitBtn_ButtonClick(object sender, EventArgs e)
		{
			SongEditor arg_1D_0 = SongEditor_Control;
			ToolStripMenuItem expr_0C = StarView_EditorBtn;
			arg_1D_0.LoadStarpowerTextures = (expr_0C.Checked = !expr_0C.Checked);
			SongEditor arg_3F_0 = SongEditor_Control;
			ToolStripMenuItem expr_2E = HopoView_EditorBtn;
			arg_3F_0.LoadHopoTextures = (expr_2E.Checked = !expr_2E.Checked);
			SongEditor arg_61_0 = SongEditor_Control;
			ToolStripMenuItem expr_50 = AudioView_EditorBtn;
			arg_61_0.ShowAudioOnFretboard = (expr_50.Checked = !expr_50.Checked);
		}

		private void StarView_EditorBtn_Click(object sender, EventArgs e)
		{
			SongEditor_Control.LoadStarpowerTextures = StarView_EditorBtn.Checked;
		}

		private void HopoView_EditorBtn_Click(object sender, EventArgs e)
		{
			SongEditor_Control.LoadHopoTextures = HopoView_EditorBtn.Checked;
		}

		private void AudioView_EditorBtn_Click(object sender, EventArgs e)
		{
			SongEditor_Control.ShowAudioOnFretboard = AudioView_EditorBtn.Checked;
		}

		private void method_2(object sender, EventArgs e)
		{
			SongEditor_Control.SetFretboardAngle(FretAngle_EditorBar.method_4());
		}

		private void method_3(object sender, EventArgs e)
		{
			if (HyperSpeed_EditorBar.method_4() == 0)
			{
				SongEditor_Control.SetHyperspeed(1.0);
				return;
			}
			if (HyperSpeed_EditorBar.method_4() < 0)
			{
				SongEditor_Control.SetHyperspeed(1.0 - HyperSpeed_EditorBar.method_4() / (double)(HyperSpeed_EditorBar.method_1() * 2));
				return;
			}
			if (HyperSpeed_EditorBar.method_4() > 0)
			{
				SongEditor_Control.SetHyperspeed(1.0 + HyperSpeed_EditorBar.method_4() * HyperSpeed_EditorBar.method_4() / 10.0);
			}
		}

		private void SaveChart_MenuItem_Click(object sender, EventArgs e)
		{
			if (SongListBox.SelectedIndex >= 0)
			{
				GH3Song gh3Song = (GH3Song)SongListBox.SelectedItem;
                string fileLocation = KeyGenerator.OpenOrSaveFile("Select where to save the song chart.", "GH3 Chart File|*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc", false);
				if (!fileLocation.Equals("") && File.Exists(DataFolder + "songs\\" + gh3Song.name + "_song.pak.xen"))
				{
					using (zzPakNode2 @class = new zzPakNode2(DataFolder + "songs\\" + gh3Song.name + "_song.pak.xen", false))
					{
						if (fileLocation.EndsWith(".qbc"))
						{
							new QBCParser(gh3Song.name, @class.zzGetNode1("songs\\" + gh3Song.name + ".mid.qb")).qbcCreator(fileLocation, gh3Song);
						}
                        else if (fileLocation.EndsWith(".chart"))
                        {
                            new QBCParser(gh3Song.name, @class.zzGetNode1("songs\\" + gh3Song.name + ".mid.qb")).method_1().chartCreator(fileLocation, gh3Song);
                        }
                        else
						{
							new QBCParser(gh3Song.name, @class.zzGetNode1("songs\\" + gh3Song.name + ".mid.qb")).method_1().dbcCreator(fileLocation, gh3Song);
						}
					}
				}
			}
		}

		private void SaveTGH_MenuItem_Click(object sender, EventArgs e)
		{
			if (TierBox.SelectedIndex >= 0)
			{
				string text = KeyGenerator.OpenOrSaveFile("Select where to save the tier.", "GH3CP Tier File|*.tgh", false, TierTitle_TxtBox.Text);
				if (text.Equals(""))
				{
					return;
				}
				TGHManager @class;
				if (DialogResult.Yes == MessageBox.Show("Do you wish to include all used song data (Music & Game Tracks)?", "Tier Exporting", MessageBoxButtons.YesNo))
				{
					@class = new TGHManager(gh3Songlist, (GH3Tier)TierBox.SelectedItem, text, DataFolder);
				}
				else
				{
					@class = new TGHManager(gh3Songlist, (GH3Tier)TierBox.SelectedItem, text);
				}
				@class.method_1();
			}
		}

        private void exportSetlistAsChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TGHSwitch_MenuItem_Click(object sender, EventArgs e)
		{
			if (TierBox.SelectedIndex >= 0)
			{
				string text = KeyGenerator.OpenFile("Select the tier to switch too.", "GH3CP Tier File|*.tgh");
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
						tghManager = new TGHManager(gh3Songlist, gH3Tier, text, DataFolder);
					}
					else
					{
						tghManager = new TGHManager(gh3Songlist, gH3Tier, text);
					}
					tghManager.method_0();
					TierBox.Items[TierBox.SelectedIndex] = gH3Tier;
					TierBox.SelectedIndex = TierBox.SelectedIndex;
					SetlistApply_Btn.Enabled = true;
					method_4(new Class247(class319_0, gh3Songlist));
					method_0();
				}
				catch
				{
					MessageBox.Show("File not compatible! Tier Switch failed.", "Tier Switching");
				}
			}
		}

		private void TGHImport_MenuItem_Click(object sender, EventArgs e)
		{
			if (gh3Songlist.gh3SetlistList.ContainsKey(SelectedSetlist))
			{
				string text = KeyGenerator.OpenFile("Select the tier to import.", "GH3CP Tier File|*.tgh");
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
						@class = new TGHManager(gh3Songlist, gH3Tier, text, DataFolder);
					}
					else
					{
						@class = new TGHManager(gh3Songlist, gH3Tier, text);
					}
					@class.method_0();
					TierBox.Items.Add(gH3Tier);
					TierBox.SelectedIndex = TierBox.Items.Count - 1;
					SetlistApply_Btn.Enabled = true;
					method_4(new Class247(class319_0, gh3Songlist));
					method_0();
				}
				catch
				{
					MessageBox.Show("File not compatible! Tier Import failed.", "Tier Importing");
				}
			}
		}

		private void SaveSGH_MenuItem_Click(object sender, EventArgs e)
		{
			if (gh3Songlist.gh3SetlistList.ContainsKey(SelectedSetlist))
			{
				string saveLocation = KeyGenerator.OpenOrSaveFile("Select where to save the setlist.", "GH3CP Setlist File|*.sgh", false, SetlistTitle_TxtBox.Text);
				if (saveLocation.Equals(""))
				{
					return;
				}
				SGHManager sghManager;
				if (DialogResult.Yes == MessageBox.Show("Do you wish to include all used song data (Music & Game Tracks)?", "Setlist Exporting", MessageBoxButtons.YesNo))
				{
					sghManager = new SGHManager(gh3Songlist, gh3Songlist.gh3SetlistList[SelectedSetlist], saveLocation, DataFolder);
				}
				else
				{
					sghManager = new SGHManager(gh3Songlist, gh3Songlist.gh3SetlistList[SelectedSetlist], saveLocation);
				}
				sghManager.method_1();
			}
		}

        private void exportSetlistAsChartsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (gh3Songlist.gh3SetlistList.ContainsKey(SelectedSetlist))
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
                foreach(GH3Tier tier in gh3Songlist.gh3SetlistList[SelectedSetlist].tiers)
                {
                    foreach (GH3Song gh3Song in tier.songs)
                    {
                        string fileLocation = saveLocation + "\\" + gh3Song.name + ".chart";
                        using (zzPakNode2 @class = new zzPakNode2(DataFolder + "songs\\" + gh3Song.name + "_song.pak.xen", false))
                        {
                            new QBCParser(gh3Song.name, @class.zzGetNode1("songs\\" + gh3Song.name + ".mid.qb")).method_1().chartCreator(fileLocation, gh3Song);
                        }
                    }
                }
            }
        }

        private void SGHSwitch_MenuItem_Click(object sender, EventArgs e)
		{
			if (gh3Songlist.gh3SetlistList.ContainsKey(SelectedSetlist))
			{
				string text = KeyGenerator.OpenFile("Select the setlist to switch too.", "GH3CP Setlist File|*.sgh");
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
						sghManager = new SGHManager(gh3Songlist, gH3Setlist, text, DataFolder);
					}
					else
					{
						sghManager = new SGHManager(gh3Songlist, gH3Setlist, text);
					}
					sghManager.method_0();
					TierBox.Items.Clear();
					TierBox.Items.AddRange(gH3Setlist.tiers.ToArray());
					if (TierBox.Items.Count != 0)
					{
						TierBox.SelectedIndex = 0;
					}
					else
					{
						method_23();
					}
					SetlistTitle_TxtBox.Text = KeyGenerator.GetFileName(text, 1);
					SetlistApply_Btn.Enabled = true;
					method_4(new Class247(class319_0, gh3Songlist));
					method_0();
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
					List<string> list2 = KeyGenerator.checkFile(file, "*.mid;*.chart;*.qbc;*.dbc", true);
					List<string> list3 = KeyGenerator.checkFile(file, "*.wav;*.mp3;*.ogg", true);
					string[] files = Directory.GetFiles(file, "*.dat", SearchOption.TopDirectoryOnly);
					if (list2.Count != 0 && (list3.Count != 0 || files.Length != 0))
					{
						GH3Song gH3Song = IsAerosmith ? new GHASong() : new GH3Song();
						gH3Song.name = KeyGenerator.GetFileName(file).ToLower().Replace(" ", "").Replace('.', '_');
						if (gH3Song.name.Length > 30)
						{
							gH3Song.name = gH3Song.name.Remove(30);
						}
						if (QbSongClass1.smethod_4(gH3Song.name) || gh3Songlist.method_3(gH3Song.name))
						{
							int num = 2;
							while (QbSongClass1.smethod_4(gH3Song.name + num) || gh3Songlist.method_3(gH3Song.name + num))
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
                                    qbcParser = Midi2Chart.LoadMidiSong(current, forceRB3MidConversionToolStripMenuItem.Checked);
								}
								else
								{
									qbcParser = new ChartParser(current).ConvertToQBC();
								}
								break;
							}
							catch
							{
							}
						}
						if (qbcParser != null)
						{
							zzQbSongObject class2 = null;
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
											class2 = new zzQbSongObject(text2);
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
								Class250 class3 = songData.method_1(class319_0, DataFolder);
								Class248 class4 = songData.method_0(DataFolder);
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
								method_4(class3);
								method_4(class4);
								gh3Songlist.Add(gH3Song.name, gH3Song);
								list.Remove(file);
							}
						}
					}
				}
				catch
				{
				}
			}
			method_4(new Class247(class319_0, gh3Songlist));
			method_0();
			if (list.Count != 0)
			{
				string text4 = "The follwing songs (by folder name) failed:";
				foreach (string current2 in list)
				{
					text4 = text4 + "\n" + KeyGenerator.GetFileName(current2);
				}
				MessageBox.Show(text4, "Error!");
			}
		}

		public MainMenu()
		{
            //Creates GUI
			InitializeComponent();
            LoadMore();
			AbstractBaseTreeNode1.bool_0 = false;
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
				GameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero III\\";
				if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null && MessageBox.Show("Do you wish to load GH3 Aerosmith?", "GH3 Aerosmith found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					GameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
					IsAerosmith = true;
				}
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero III\\") != null)
			{
				GameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero III\\";
				if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null && MessageBox.Show("Do you wish to load GH3 Aerosmith?", "GH3 Aerosmith found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					GameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
					IsAerosmith = true;
				}
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null)
			{
				GameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
				IsAerosmith = true;
			}
			else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null)
			{
				GameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
				IsAerosmith = true;
			}
			else
			{
				MessageBox.Show("Guitar Hero III is not installed properly! Please re/install and run again.");
				formClosing();
			}
			GhtcpRegistry = (IsAerosmith ? "SOFTWARE\\SigmaInc\\GHTCPAero\\" : "SOFTWARE\\SigmaInc\\GHTCP\\");
			BackupName = (IsAerosmith ? "backupAero\\" : "backup\\");
			zzQbScriptZipperClass.GameName = (IsAerosmith ? "GHA" : "GH3");
			if (IsAerosmith)
			{
				Text += " - Aerosmith";
				TierIcon_DropBox.Items.AddRange(new[]
				{
					"setlist_icon_01",
					"setlist_icon_02",
					"setlist_icon_03",
					"setlist_icon_04",
					"setlist_icon_05",
					"setlist_icon_06"
				});
				TierStage_DropBox.Items.AddRange(new[]
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
				TierEncorep2_CheckBox.Text = "P1 Aerosmith Encore";
			}
			else
			{
				Text += " - Legends of Rock";
				TierIcon_DropBox.Items.AddRange(new[]
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
				TierStage_DropBox.Items.AddRange(new[]
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
			if (method_9() == null)
			{
				throw new Exception("GH3 Language setting missing from registry!");
			}
			QbSongClass1.smethod_0();
			AppDirectory = Directory.GetCurrentDirectory() + "\\";
			method_12(false);
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GhtcpRegistry);
			method_10((string)registryKey.GetValue("Priority"));
			if (!new List<string>(new[]
			{
				"high",
				"above",
				"normal",
				"below"
			}).Contains(Priority))
			{
				method_10("normal");
			}
			List<string> list = new List<string>(new[]
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
				LanguageList = new[]
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
				LanguageList = list.ToArray();
			}
			InitializeLanguageList();
			SilentGuitar_MenuItem.Checked = (Class248.bool_2 = ((((int?)registryKey.GetValue("SilentGuitar")) ?? 0) != 0));
			MinToTray_MenuItem.Checked = ((((int?)registryKey.GetValue("MinimizeToTray")) ?? 0) != 0);
			SilentGuitar_MenuItem.Checked = (Class248.bool_3 = ((((int?)registryKey.GetValue("ForceConversion")) ?? 0) != 0));
			if (!Directory.Exists(AppDirectory + BackupName))
			{
				Directory.CreateDirectory(AppDirectory + BackupName);
			}
			if (!Directory.Exists(AppDirectory + BackupName + "originals"))
			{
				Directory.CreateDirectory(AppDirectory + BackupName + "originals");
			}
			if (!Directory.Exists(AppDirectory + BackupName + "lastedited"))
			{
				Directory.CreateDirectory(AppDirectory + BackupName + "lastedited");
			}
			if (!File.Exists(AppDirectory + "lame_enc.dll"))
			{
				try
				{
					ZIPManager.smethod_8(new WebClient().OpenRead("http://spaghetticode.org/lame/libmp3lame-win-3.97.zip"), AppDirectory + "lame_enc.dll", "libmp3lame-3.97/lame_enc.dll");
				}
				catch
				{
					Process.Start("http://lame.buanzo.com.ar/");
					MessageBox.Show("Please download the file under \"ZIP OPTION:\" and select it: libmp3lame-win-#.#.zip", "MP3 Encoding Library Missing!");
					try
					{
						string text4 = KeyGenerator.OpenOrSaveFile("Locate MP3 Encoding Library (file will be deleted after!)", "MP3 Lame Zip|*.zip", true);
						string text5 = KeyGenerator.GetFileNameNoExt(text4);
						ZIPManager.smethod_4(text4, AppDirectory + "lame_enc.dll", "libmp3lame" + text5.Substring(text5.LastIndexOf('-')) + "/lame_enc.dll");
						try
						{
							KeyGenerator.smethod_20(text4);
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
			new TexExplorer(DataFolder).ShowDialog();
		}

		private void SaveFileControl_MenuItem_Click(object sender, EventArgs e)
		{
			string a = KeyGenerator.OpenOrSaveFile("Select Save File to Import. Current Save File will be Overwritten!", "GH3 Save File|s000.d", true);
			if (a != "")
			{
				Class324 @class = new Class324(a);
				@class.method_0(new Class324(872398018)).list_0[0].int_0[1] = -1;
				string text = "Progress" + (new[]
				{
					"A",
					"B",
					"C",
					"D",
					"E"
				})[list_0.IndexOf(KeyGenerator.GetFileNameNoExt(class319_0.string_0).Remove(0, 2))];
				text = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "\\Aspyr\\Guitar Hero III\\Save\\", text, "}{", text);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				@class.method_1(text);
			}
		}

		private void method_4(QbEditor class245_0)
		{
			foreach (QbEditor @class in ActionRequests_ListBox.Items)
			{
				if (@class.Equals(class245_0))
				{
					ActionRequests_ListBox.Items.Remove(@class);
					break;
				}
			}
			ActionRequests_ListBox.Items.Add(class245_0);
		}

		private void ClearActions_MenuItem_Click(object sender, EventArgs e)
		{
			if (ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes == MessageBox.Show("Are You sure you want to delete all Actions?", "Warning!", MessageBoxButtons.YesNo))
			{
				ActionRequests_ListBox.Items.Clear();
				GC.Collect();
			}
		}

		private void ExecuteActions_MenuItem_Click(object sender, EventArgs e)
		{
			if (ActionRequests_ListBox.Items.Count != 0)
			{
				if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Execute Actions?", "Warning!", MessageBoxButtons.YesNo))
				{
					List<QbEditor> list = new List<QbEditor>();
					foreach (QbEditor item in ActionRequests_ListBox.Items)
					{
						list.Add(item);
					}
					actionsWindow_0 = new ActionsWindow(list);
					actionsWindow_0.method_0(method_5);
					actionsWindow_0.Show();
					actionsWindow_0.method_1();
				}
			}
		}

		private void method_5(object sender, EventArgs e)
		{
			if ((!actionsWindow_0.bool_0 || DialogResult.Yes == MessageBox.Show("Some of the action requests failed!\nDo you still wish to rebuild the game settings?", "Warning!", MessageBoxButtons.YesNo)) && method_18())
			{
				actionsWindow_0 = null;
				ActionRequests_ListBox.Items.Clear();
				GC.Collect();
			}
		}

		private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes != MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?", "Warning!", MessageBoxButtons.YesNo))
			{
				e.Cancel = true;
				return;
			}
			formClosing();
		}

		public void MainMenu_SizeChanged(object sender, EventArgs e)
		{
			Console.WriteLine(WindowState);
			if (WindowState == FormWindowState.Minimized && MinToTray_MenuItem.Checked)
			{
				Hide();
				return;
			}
			if (!Visible)
			{
				BringToFront();
				base.Show();
				Focus();
				WindowState = FormWindowState.Normal;
			}
		}

		[DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool SetForegroundWindow(HandleRef handleRef_0);

		private void notifyIcon_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 2)
			{
				leftClickMenu.Hide();
				rightClickMenu.Hide();
				if (e.Button == MouseButtons.Left)
				{
					BringToFront();
					base.Show();
					Focus();
					WindowState = FormWindowState.Normal;
					return;
				}
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				try
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(GameRegistry);
					Process process = new Process();
					process.StartInfo = new ProcessStartInfo((string)registryKey.GetValue("Path") + (IsAerosmith ? "Guitar Hero Aerosmith.exe" : "GH3.exe"));
					process.Start();
					if (Priority != "normal")
					{
						process.PriorityClass = ((Priority == "high") ? ProcessPriorityClass.High : ((Priority == "above") ? ProcessPriorityClass.AboveNormal : ((Priority == "below") ? ProcessPriorityClass.BelowNormal : ProcessPriorityClass.Normal)));
					}
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			SetForegroundWindow(new HandleRef(this, Handle));
			if (e.Button == MouseButtons.Left)
			{
				leftClickMenu.Show(this, PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveLeft);
				return;
			}
			if (e.Button == MouseButtons.Right)
			{
				rightClickMenu.Show(this, PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveRight);
			}
		}

		private void formClosing()
		{
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GhtcpRegistry);
			registryKey.SetValue("Priority", Priority);
			registryKey.SetValue("SilentGuitar", Class248.bool_2 ? 1 : 0);
			registryKey.SetValue("MinimizeToTray", MinToTray_MenuItem.Checked ? 1 : 0);
			registryKey.SetValue("ForceConversion", Class248.bool_3 ? 1 : 0);
			method_15();
			SongEditor_Control.Dispose();
            notifyIcon_0.Visible = false;
            Dispose(true);
        }

		private void Exit_MenuItem_Click(object sender, EventArgs e)
		{
			if (ActionRequests_ListBox.Items.Count != 0 && DialogResult.Yes != MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?", "Warning!", MessageBoxButtons.YesNo))
			{
				return;
			}
			formClosing();
		}

		private void method_7(string string_7)
		{
			SysEnglish_MenuItem.Checked = (string_7 == "en");
			SysFrench_MenuItem.Checked = (string_7 == "fr");
			SysItalian_MenuItem.Checked = (string_7 == "it");
			SysSpanish_MenuItem.Checked = (string_7 == "es");
			SysGerman_MenuItem.Checked = (string_7 == "de");
			SysKorean_MenuItem.Checked = (string_7 == "ko");
		}

		private void method_8(string string_7)
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GameRegistry);
			registryKey.SetValue("Language", string_7);
			method_7(string_7);
		}

		private string method_9()
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GameRegistry);
			string text = (string)registryKey.GetValue("Language");
			method_7(text);
			return text;
		}

		private void SysKorean_MenuItem_Click(object sender, EventArgs e)
		{
			method_8((string)((ToolStripMenuItem)sender).Tag);
		}

		private void method_10(string string_7)
		{
			Priority = string_7;
			SysHigh_MenuItem.Checked = (Priority == "high");
			SysAbove_MenuItem.Checked = (Priority == "above");
			SysNormal_MenuItem.Checked = (Priority == "normal");
			SysBelow_MenuItem.Checked = (Priority == "below");
		}

		private void SysBelow_MenuItem_Click(object sender, EventArgs e)
		{
			method_10((string)((ToolStripMenuItem)sender).Tag);
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
			Process.Start(DataFolder);
		}

		private void Disclaimer_MenuItem_Click(object sender, EventArgs e)
		{
			if (new Disclaimer().ShowDialog() != DialogResult.OK)
			{
				formClosing();
			}
		}

		private void About_MenuItem_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void SilentGuitar_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = SilentGuitar_MenuItem;
			Class248.bool_2 = (expr_06.Checked = !expr_06.Checked);
		}

		private void FxSpeedBoost_MenuItem_Click(object sender, EventArgs e)
		{
			method_4(new zzFxBoost(class319_0));
		}

		private void ForceMp3Conversion_MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem expr_06 = ForceMp3Conversion_MenuItem;
			Class248.bool_3 = (expr_06.Checked = !expr_06.Checked);
		}

        //Disables Buttons
		private void method_11(GH3Setlist gh3Setlist_0)
		{
			SetlistTitle_TxtBox.Text = (string)Setlist_DropBox.SelectedItem;
			SetlistTitle_TxtBox.Enabled = (DeleteSetlist_Btn.Enabled = gh3Setlist_0.method_4());
			//this.CreateSetlist_Btn.Enabled = (this.gh3Songlist_0.CustomBitMask != -1);
			SetlistPrefix_TxtBox.Text = gh3Setlist_0.prefix;
			SetlistInitMovie_TxtBox.Text = gh3Setlist_0.initial_movie;
			TierBox.Items.Clear();
			TierBox.Items.AddRange(gh3Setlist_0.tiers.ToArray());
			if (TierBox.Items.Count != 0)
			{
				TierBox.SelectedIndex = 0;
			}
			else
			{
				method_23();
			}
			SetlistApply_Btn.Enabled = false;
		}

		private void Setlist_DropBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			method_11(gh3Songlist.gh3SetlistList[SelectedSetlist = gh3Songlist.method_9((string)Setlist_DropBox.SelectedItem)]);
		}

		private void CreateSetlist_Btn_Click(object sender, EventArgs e)
		{
			if (gh3Songlist.CustomBitMask == -1)
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
                if (!((gh3Songlist.CustomBitMask & num) == 0)) {
                    goto SKIPIT;
                }
                //2^numOfSetlists - 1

                    gh3Songlist.CustomBitMask |= (gH3Setlist.CustomBit = num);

                    IL_7E:
                    gH3Setlist.prefix = "custom" + (i + 1);
					int num2;
					gh3Songlist.gh3SetlistList.Add(num2 = QbSongClass1.AddKeyToDictionary("gh3_custom" + (i + 1) + "_songs"), gH3Setlist);
					int value;
					gh3Songlist.dictionary_1.Add(value = QbSongClass1.AddKeyToDictionary("custom" + (i + 1) + "_progression"), new GHLink(num2));
					string text;
					gh3Songlist.class214_0.Add(text = "Custom Setlist " + (i + 1), value);
					Setlist_DropBox.Items.Add(text);
					Setlist_DropBox.SelectedItem = text;
					method_4(new Class246(value, class319_0, gh3Songlist, true));
					method_4(new UpdateSetlistSwitcher(class319_0, gh3Songlist, IsAerosmith));
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
			if (!gh3Songlist.gh3SetlistList[SelectedSetlist].method_4())
			{
				return;
			}
			string text = (string)Setlist_DropBox.SelectedItem;
			Setlist_DropBox.SelectedIndex--;
			Setlist_DropBox.Items.Remove(text);
			method_4(new Class246(gh3Songlist.class214_0[text], class319_0, gh3Songlist, false));
			method_4(new UpdateSetlistSwitcher(class319_0, gh3Songlist, IsAerosmith));
		}

		private void SetlistTitle_TxtBox_TextChanged(object sender, EventArgs e)
		{
			SetlistApply_Btn.Enabled = true;
		}

		private void SetlistApply_Btn_Click(object sender, EventArgs e)
		{
			GH3Setlist gH3Setlist = gh3Songlist.gh3SetlistList[SelectedSetlist];
			gH3Setlist.initial_movie = SetlistInitMovie_TxtBox.Text;
			gH3Setlist.tiers.Clear();
			foreach (GH3Tier item in TierBox.Items)
			{
				gH3Setlist.tiers.Add(item);
			}
			if (SetlistTitle_TxtBox.Text != (string)Setlist_DropBox.SelectedItem)
			{
				gh3Songlist.class214_0.Add(SetlistTitle_TxtBox.Text, gh3Songlist.class214_0[(string)Setlist_DropBox.SelectedItem]);
				gh3Songlist.class214_0.Remove((string)Setlist_DropBox.SelectedItem);
				method_4(new UpdateSetlistSwitcher(class319_0, gh3Songlist, IsAerosmith));
				Setlist_DropBox.Items[Setlist_DropBox.SelectedIndex] = SetlistTitle_TxtBox.Text;
			}
			SetlistApply_Btn.Enabled = false;
			method_4(new zzSetListUpdater(SelectedSetlist, class319_0, gh3Songlist));
		}

		private void NewTier_MenuItem_Click(object sender, EventArgs e)
		{
			if (gh3Songlist.gh3SetlistList.ContainsKey(SelectedSetlist))
			{
				TierBox.Items.Add(new GH3Tier());
				TierBox.SelectedIndex = TierBox.Items.Count - 1;
				SetlistApply_Btn.Enabled = true;
			}
		}

		private void ManageTiers_MenuItem_Click(object sender, EventArgs e)
		{
			if (TierBox.SelectedIndex >= 0)
			{
				List<GH3Tier> list = new List<GH3Tier>();
				foreach (GH3Tier item in TierBox.Items)
				{
					list.Add(item);
				}
				TierManagement tierManagement = new TierManagement((string)Setlist_DropBox.SelectedItem, list.ToArray());
				if (tierManagement.ShowDialog() == DialogResult.OK)
				{
					TierBox.Items.Clear();
					TierBox.Items.AddRange(tierManagement.method_0());
					if (TierBox.Items.Count != 0)
					{
						TierBox.SelectedIndex = 0;
					}
					else
					{
						method_23();
					}
					SetlistApply_Btn.Enabled = true;
				}
			}
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainMenu));
            rightClickMenu = new ContextMenuStrip(components);
            SysHigh_MenuItem = new ToolStripMenuItem();
            SysAbove_MenuItem = new ToolStripMenuItem();
            SysNormal_MenuItem = new ToolStripMenuItem();
            SysBelow_MenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            MinToTray_MenuItem = new ToolStripMenuItem();
            SysExit_MenuItem = new ToolStripMenuItem();
            TopMenuStrip = new MenuStrip();
            File_MenuItem = new ToolStripMenuItem();
            OpenGameSettings_MenuItem = new ToolStripMenuItem();
            RecoverGameSettings_MenuItem = new ToolStripMenuItem();
            ClearGameSettings_MenuItem = new ToolStripMenuItem();
            ExecuteActions_MenuItem = new ToolStripMenuItem();
            ClearActions_MenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            SaveTGH_MenuItem = new ToolStripMenuItem();
            SaveSGH_MenuItem = new ToolStripMenuItem();
            SaveChart_MenuItem = new ToolStripMenuItem();
            exportSetlistAsChartsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            Exit_MenuItem = new ToolStripMenuItem();
            Add_MenuItem = new ToolStripMenuItem();
            NewSong_MenuItem = new ToolStripMenuItem();
            Tier_MenuItem = new ToolStripMenuItem();
            NewTier_MenuItem = new ToolStripMenuItem();
            TGHImport_MenuItem = new ToolStripMenuItem();
            MassImporter_MenuItem = new ToolStripMenuItem();
            LegacyImporter_MenuItem = new ToolStripMenuItem();
            RecoverSonglist_MenuItem = new ToolStripMenuItem();
            ManageGame_MenuItem = new ToolStripMenuItem();
            ManageTiers_MenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            TGHSwitch_MenuItem = new ToolStripMenuItem();
            SGHSwitch_MenuItem = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            GameSettingsSwitch_MenuItem = new ToolStripMenuItem();
            RestoreLast_MenuItem = new ToolStripMenuItem();
            RestoreOriginal_MenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            SaveFileControl_MenuItem = new ToolStripMenuItem();
            TexExplorer_MenuItem = new ToolStripMenuItem();
            FxSpeedBoost_MenuItem = new ToolStripMenuItem();
            ManageSongs_MenuItem = new ToolStripMenuItem();
            SongProps_MenuItem = new ToolStripMenuItem();
            RebuildSong_MenuItem = new ToolStripMenuItem();
            SilentGuitar_MenuItem = new ToolStripMenuItem();
            ForceMp3Conversion_MenuItem = new ToolStripMenuItem();
            forceRB3MidConversionToolStripMenuItem = new ToolStripMenuItem();
            DeleteSong_MenuItem = new ToolStripMenuItem();
            RemoveSong_ToolStripMenuItem = new ToolStripSeparator();
            HideUnEdit_MenuItem = new ToolStripMenuItem();
            HideUsed_MenuItem = new ToolStripMenuItem();
            ByTitle_MenuItem = new ToolStripMenuItem();
            Help_MenuItem = new ToolStripMenuItem();
            Guide_MenuItem = new ToolStripMenuItem();
            ScoreHero_MenuItem = new ToolStripMenuItem();
            GH3Folder_MenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            Disclaimer_MenuItem = new ToolStripMenuItem();
            About_MenuItem = new ToolStripMenuItem();
            ActionRequests_ListBox = new ListBox();
            label1 = new Label();
            label3 = new Label();
            SidePanel = new TableLayoutPanel();
            notifyIcon_0 = new NotifyIcon(components);
            fontDialog_0 = new FontDialog();
            leftClickMenu = new ContextMenuStrip(components);
            SysEnglish_MenuItem = new ToolStripMenuItem();
            SysFrench_MenuItem = new ToolStripMenuItem();
            SysItalian_MenuItem = new ToolStripMenuItem();
            SysSpanish_MenuItem = new ToolStripMenuItem();
            SysGerman_MenuItem = new ToolStripMenuItem();
            SysKorean_MenuItem = new ToolStripMenuItem();
            MainContainer = new ToolStripContainer();
            StatusStrip = new StatusStrip();
            ToolStripStatusLbl = new ToolStripStatusLabel();
            TabControl = new TabControl();
            SetlistTab = new TabPage();
            SetlistConfig_Container = new ToolStripContainer();
            SetlistConf_TLPanel = new TableLayoutPanel();
            Setlist_TLPanel = new TableLayoutPanel();
            textBox3 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TierBox = new ComboBox();
            SetlistInitMovie_TxtBox = new TextBox();
            SetlistPrefix_TxtBox = new TextBox();
            label2 = new Label();
            label13 = new Label();
            SetlistTitle_TxtBox = new TextBox();
            Tier_TLPanel = new TableLayoutPanel();
            TierProps_Panel = new Panel();
            TierUnlockedSet_Btn = new Button();
            UnlockAll_CheckBox = new CheckBox();
            NoCash_CheckBox = new CheckBox();
            TierApply_Btn = new Button();
            label12 = new Label();
            SetlistApply_Btn = new Button();
            TierCompMovie_TxtBox = new TextBox();
            TierUnlocked_NumBox = new NumericUpDown();
            TierTitle_TxtBox = new TextBox();
            TierIcon_DropBox = new ComboBox();
            TierStage_DropBox = new ComboBox();
            TierBoss_CheckBox = new CheckBox();
            TierEncorep2_CheckBox = new CheckBox();
            TierEncorep1_CheckBox = new CheckBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            TierSongs_Panel = new TableLayoutPanel();
            label11 = new Label();
            SetlistStrip = new ToolStrip();
            Setlist_Lbl = new ToolStripLabel();
            Setlist_DropBox = new ToolStripComboBox();
            CreateSetlist_Btn = new ToolStripButton();
            DeleteSetlist_Btn = new ToolStripButton();
            SongEditorTab = new TabPage();
            SongEditor_Container = new ToolStripContainer();
            SongEditor_BottomToolStrip = new ToolStrip();
            ToggleElements_EditorSplitBtn = new ToolStripSplitButton();
            StarView_EditorBtn = new ToolStripMenuItem();
            HopoView_EditorBtn = new ToolStripMenuItem();
            AudioView_EditorBtn = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            BeatSize_EditorTxtBox = new ToolStripTextBox();
            toolStripSeparator12 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            Offset_EditorTxtBox = new ToolStripTextBox();
            SongEditor_TopToolStrip = new ToolStrip();
            GameMode_EditorBtn = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            LoadChart_EditorBtn = new ToolStripButton();
            SelectedTrack_EditorBox = new ToolStripComboBox();
            SongName_EditorLbl = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            LoadAudio_EditorBtn = new ToolStripButton();
            PlayPause_EditorBtn = new ToolStripButton();
            Stop_EditorBtn = new ToolStripButton();
            PlayTime_EditorLbl = new ToolStripLabel();
            TierSongs_ListBox = new zzListBox238();
            HyperSpeed_EditorBar = new GhtcpToolStripControlHost();
            FretAngle_EditorBar = new GhtcpToolStripControlHost();
            SongEditor_Control = new SongEditor();
            SongListBox = new zzListBox238();
            rightClickMenu.SuspendLayout();
            TopMenuStrip.SuspendLayout();
            SidePanel.SuspendLayout();
            leftClickMenu.SuspendLayout();
            MainContainer.BottomToolStripPanel.SuspendLayout();
            MainContainer.ContentPanel.SuspendLayout();
            MainContainer.TopToolStripPanel.SuspendLayout();
            MainContainer.SuspendLayout();
            StatusStrip.SuspendLayout();
            TabControl.SuspendLayout();
            SetlistTab.SuspendLayout();
            SetlistConfig_Container.ContentPanel.SuspendLayout();
            SetlistConfig_Container.TopToolStripPanel.SuspendLayout();
            SetlistConfig_Container.SuspendLayout();
            SetlistConf_TLPanel.SuspendLayout();
            Setlist_TLPanel.SuspendLayout();
            Tier_TLPanel.SuspendLayout();
            TierProps_Panel.SuspendLayout();
            ((ISupportInitialize)(TierUnlocked_NumBox)).BeginInit();
            TierSongs_Panel.SuspendLayout();
            SetlistStrip.SuspendLayout();
            SongEditorTab.SuspendLayout();
            SongEditor_Container.BottomToolStripPanel.SuspendLayout();
            SongEditor_Container.ContentPanel.SuspendLayout();
            SongEditor_Container.TopToolStripPanel.SuspendLayout();
            SongEditor_Container.SuspendLayout();
            SongEditor_BottomToolStrip.SuspendLayout();
            SongEditor_TopToolStrip.SuspendLayout();
            SuspendLayout();
            //
            // rightClickMenu
            //
            rightClickMenu.Items.AddRange(new ToolStripItem[] {
            SysHigh_MenuItem,
            SysAbove_MenuItem,
            SysNormal_MenuItem,
            SysBelow_MenuItem,
            toolStripSeparator8,
            MinToTray_MenuItem,
            SysExit_MenuItem});
            rightClickMenu.Name = "rightClickMenu";
            rightClickMenu.Size = new Size(167, 142);
            //
            // SysHigh_MenuItem
            //
            SysHigh_MenuItem.Name = "SysHigh_MenuItem";
            SysHigh_MenuItem.ShowShortcutKeys = false;
            SysHigh_MenuItem.Size = new Size(166, 22);
            SysHigh_MenuItem.Tag = "high";
            SysHigh_MenuItem.Text = "High";
            SysHigh_MenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysAbove_MenuItem
            //
            SysAbove_MenuItem.Name = "SysAbove_MenuItem";
            SysAbove_MenuItem.ShowShortcutKeys = false;
            SysAbove_MenuItem.Size = new Size(166, 22);
            SysAbove_MenuItem.Tag = "above";
            SysAbove_MenuItem.Text = "Above Normal";
            SysAbove_MenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysNormal_MenuItem
            //
            SysNormal_MenuItem.Name = "SysNormal_MenuItem";
            SysNormal_MenuItem.ShowShortcutKeys = false;
            SysNormal_MenuItem.Size = new Size(166, 22);
            SysNormal_MenuItem.Tag = "normal";
            SysNormal_MenuItem.Text = "Normal";
            SysNormal_MenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysBelow_MenuItem
            //
            SysBelow_MenuItem.Name = "SysBelow_MenuItem";
            SysBelow_MenuItem.ShowShortcutKeys = false;
            SysBelow_MenuItem.Size = new Size(166, 22);
            SysBelow_MenuItem.Tag = "below";
            SysBelow_MenuItem.Text = "Below Normal";
            SysBelow_MenuItem.Click += SysBelow_MenuItem_Click;
            //
            // toolStripSeparator8
            //
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(163, 6);
            //
            // MinToTray_MenuItem
            //
            MinToTray_MenuItem.CheckOnClick = true;
            MinToTray_MenuItem.Name = "MinToTray_MenuItem";
            MinToTray_MenuItem.Size = new Size(166, 22);
            MinToTray_MenuItem.Text = "Minimize To Tray";
            //
            // SysExit_MenuItem
            //
            SysExit_MenuItem.Name = "SysExit_MenuItem";
            SysExit_MenuItem.ShowShortcutKeys = false;
            SysExit_MenuItem.Size = new Size(166, 22);
            SysExit_MenuItem.Text = "Exit";
            SysExit_MenuItem.Click += Exit_MenuItem_Click;
            //
            // TopMenuStrip
            //
            TopMenuStrip.Dock = DockStyle.None;
            TopMenuStrip.Items.AddRange(new ToolStripItem[] {
            File_MenuItem,
            Add_MenuItem,
            ManageGame_MenuItem,
            ManageSongs_MenuItem,
            Help_MenuItem});
            TopMenuStrip.Location = new Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.Size = new Size(784, 24);
            TopMenuStrip.TabIndex = 2;
            TopMenuStrip.Text = "menuStrip1";
            //
            // File_MenuItem
            //
            File_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            OpenGameSettings_MenuItem,
            RecoverGameSettings_MenuItem,
            ClearGameSettings_MenuItem,
            ExecuteActions_MenuItem,
            ClearActions_MenuItem,
            toolStripSeparator1,
            SaveTGH_MenuItem,
            SaveSGH_MenuItem,
            SaveChart_MenuItem,
            exportSetlistAsChartsToolStripMenuItem,
            toolStripSeparator6,
            Exit_MenuItem});
            File_MenuItem.Name = "File_MenuItem";
            File_MenuItem.Size = new Size(37, 20);
            File_MenuItem.Text = "File";
            //
            // OpenGameSettings_MenuItem
            //
            OpenGameSettings_MenuItem.Name = "OpenGameSettings_MenuItem";
            OpenGameSettings_MenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenGameSettings_MenuItem.Size = new Size(264, 22);
            OpenGameSettings_MenuItem.Text = "&Open Game Settings";
            OpenGameSettings_MenuItem.Click += OpenGameSettings_MenuItem_Click;
            //
            // RecoverGameSettings_MenuItem
            //
            RecoverGameSettings_MenuItem.Name = "RecoverGameSettings_MenuItem";
            RecoverGameSettings_MenuItem.ShortcutKeys = Keys.Control | Keys.R;
            RecoverGameSettings_MenuItem.Size = new Size(264, 22);
            RecoverGameSettings_MenuItem.Text = "&Recover Game Settings";
            RecoverGameSettings_MenuItem.Click += RecoverGameSettings_MenuItem_Click;
            //
            // ClearGameSettings_MenuItem
            //
            ClearGameSettings_MenuItem.Name = "ClearGameSettings_MenuItem";
            ClearGameSettings_MenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            ClearGameSettings_MenuItem.Size = new Size(264, 22);
            ClearGameSettings_MenuItem.Text = "Clear Game Settings";
            ClearGameSettings_MenuItem.Click += ClearGameSettings_MenuItem_Click;
            //
            // ExecuteActions_MenuItem
            //
            ExecuteActions_MenuItem.Name = "ExecuteActions_MenuItem";
            ExecuteActions_MenuItem.ShortcutKeys = (Keys.Control | Keys.Alt)
                                                   | Keys.S;
            ExecuteActions_MenuItem.Size = new Size(264, 22);
            ExecuteActions_MenuItem.Text = "Execute &Actions";
            ExecuteActions_MenuItem.Click += ExecuteActions_MenuItem_Click;
            //
            // ClearActions_MenuItem
            //
            ClearActions_MenuItem.Name = "ClearActions_MenuItem";
            ClearActions_MenuItem.ShortcutKeys = (Keys.Control | Keys.Alt)
                                                 | Keys.Q;
            ClearActions_MenuItem.Size = new Size(264, 22);
            ClearActions_MenuItem.Text = "&Clear Actions";
            ClearActions_MenuItem.Click += ClearActions_MenuItem_Click;
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(261, 6);
            //
            // SaveTGH_MenuItem
            //
            SaveTGH_MenuItem.Name = "SaveTGH_MenuItem";
            SaveTGH_MenuItem.ShortcutKeys = (Keys.Alt | Keys.Shift)
                                            | Keys.S;
            SaveTGH_MenuItem.Size = new Size(264, 22);
            SaveTGH_MenuItem.Text = "Export &TGH (Tier)";
            SaveTGH_MenuItem.Click += SaveTGH_MenuItem_Click;
            //
            // SaveSGH_MenuItem
            //
            SaveSGH_MenuItem.Name = "SaveSGH_MenuItem";
            SaveSGH_MenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            SaveSGH_MenuItem.Size = new Size(264, 22);
            SaveSGH_MenuItem.Text = "Export &SGH (Setlist)";
            SaveSGH_MenuItem.Click += SaveSGH_MenuItem_Click;
            //
            // SaveChart_MenuItem
            //
            SaveChart_MenuItem.Name = "SaveChart_MenuItem";
            SaveChart_MenuItem.Size = new Size(264, 22);
            SaveChart_MenuItem.Text = "Export Song Chart";
            SaveChart_MenuItem.Click += SaveChart_MenuItem_Click;
            //
            // exportSetlistAsChartsToolStripMenuItem
            //
            exportSetlistAsChartsToolStripMenuItem.Name = "exportSetlistAsChartsToolStripMenuItem";
            exportSetlistAsChartsToolStripMenuItem.ShortcutKeys = (Keys.Control | Keys.Shift)
                                                                  | Keys.S;
            exportSetlistAsChartsToolStripMenuItem.Size = new Size(264, 22);
            exportSetlistAsChartsToolStripMenuItem.Text = "Export Setlist as Charts";
            exportSetlistAsChartsToolStripMenuItem.Click += exportSetlistAsChartsToolStripMenuItem_Click_1;
            //
            // toolStripSeparator6
            //
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(261, 6);
            //
            // Exit_MenuItem
            //
            Exit_MenuItem.Name = "Exit_MenuItem";
            Exit_MenuItem.Size = new Size(264, 22);
            Exit_MenuItem.Text = "&Exit";
            Exit_MenuItem.Click += Exit_MenuItem_Click;
            //
            // Add_MenuItem
            //
            Add_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            NewSong_MenuItem,
            Tier_MenuItem,
            MassImporter_MenuItem,
            LegacyImporter_MenuItem,
            RecoverSonglist_MenuItem});
            Add_MenuItem.Name = "Add_MenuItem";
            Add_MenuItem.Size = new Size(41, 20);
            Add_MenuItem.Text = "Add";
            //
            // NewSong_MenuItem
            //
            NewSong_MenuItem.Name = "NewSong_MenuItem";
            NewSong_MenuItem.ShortcutKeys = Keys.Alt | Keys.N;
            NewSong_MenuItem.Size = new Size(167, 22);
            NewSong_MenuItem.Text = "New Song";
            NewSong_MenuItem.Click += NewSong_MenuItem_Click;
            //
            // Tier_MenuItem
            //
            Tier_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            NewTier_MenuItem,
            TGHImport_MenuItem});
            Tier_MenuItem.Name = "Tier_MenuItem";
            Tier_MenuItem.Size = new Size(167, 22);
            Tier_MenuItem.Text = "Tier";
            //
            // NewTier_MenuItem
            //
            NewTier_MenuItem.Name = "NewTier_MenuItem";
            NewTier_MenuItem.ShortcutKeys = Keys.Alt | Keys.T;
            NewTier_MenuItem.Size = new Size(137, 22);
            NewTier_MenuItem.Text = "New";
            NewTier_MenuItem.Click += NewTier_MenuItem_Click;
            //
            // TGHImport_MenuItem
            //
            TGHImport_MenuItem.Name = "TGHImport_MenuItem";
            TGHImport_MenuItem.Size = new Size(137, 22);
            TGHImport_MenuItem.Text = "TGH Import";
            TGHImport_MenuItem.Click += TGHImport_MenuItem_Click;
            //
            // MassImporter_MenuItem
            //
            MassImporter_MenuItem.Name = "MassImporter_MenuItem";
            MassImporter_MenuItem.Size = new Size(167, 22);
            MassImporter_MenuItem.Text = "Mass Importer";
            MassImporter_MenuItem.Click += MassImporter_MenuItem_Click;
            //
            // LegacyImporter_MenuItem
            //
            LegacyImporter_MenuItem.Enabled = false;
            LegacyImporter_MenuItem.Name = "LegacyImporter_MenuItem";
            LegacyImporter_MenuItem.Size = new Size(167, 22);
            LegacyImporter_MenuItem.Text = "Legacy Importer";
            LegacyImporter_MenuItem.Click += LegacyImporter_MenuItem_Click;
            //
            // RecoverSonglist_MenuItem
            //
            RecoverSonglist_MenuItem.Name = "RecoverSonglist_MenuItem";
            RecoverSonglist_MenuItem.Size = new Size(167, 22);
            RecoverSonglist_MenuItem.Text = "Recover Songlist";
            RecoverSonglist_MenuItem.Click += RecoverSonglist_MenuItem_Click;
            //
            // ManageGame_MenuItem
            //
            ManageGame_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            ManageTiers_MenuItem,
            toolStripSeparator4,
            TGHSwitch_MenuItem,
            SGHSwitch_MenuItem,
            toolStripSeparator11,
            GameSettingsSwitch_MenuItem,
            RestoreLast_MenuItem,
            RestoreOriginal_MenuItem,
            toolStripSeparator7,
            SaveFileControl_MenuItem,
            TexExplorer_MenuItem,
            FxSpeedBoost_MenuItem});
            ManageGame_MenuItem.Name = "ManageGame_MenuItem";
            ManageGame_MenuItem.Size = new Size(124, 20);
            ManageGame_MenuItem.Text = "Game Management";
            //
            // ManageTiers_MenuItem
            //
            ManageTiers_MenuItem.Name = "ManageTiers_MenuItem";
            ManageTiers_MenuItem.ShortcutKeys = Keys.Control | Keys.T;
            ManageTiers_MenuItem.Size = new Size(237, 22);
            ManageTiers_MenuItem.Text = "Manage Tiers";
            ManageTiers_MenuItem.Click += ManageTiers_MenuItem_Click;
            //
            // toolStripSeparator4
            //
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(234, 6);
            //
            // TGHSwitch_MenuItem
            //
            TGHSwitch_MenuItem.Name = "TGHSwitch_MenuItem";
            TGHSwitch_MenuItem.Size = new Size(237, 22);
            TGHSwitch_MenuItem.Text = "TGH Tier Switch";
            TGHSwitch_MenuItem.Click += TGHSwitch_MenuItem_Click;
            //
            // SGHSwitch_MenuItem
            //
            SGHSwitch_MenuItem.Name = "SGHSwitch_MenuItem";
            SGHSwitch_MenuItem.Size = new Size(237, 22);
            SGHSwitch_MenuItem.Text = "SGH Setlist Switch";
            SGHSwitch_MenuItem.Click += SGHSwitch_MenuItem_Click;
            //
            // toolStripSeparator11
            //
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(234, 6);
            //
            // GameSettingsSwitch_MenuItem
            //
            GameSettingsSwitch_MenuItem.Name = "GameSettingsSwitch_MenuItem";
            GameSettingsSwitch_MenuItem.Size = new Size(237, 22);
            GameSettingsSwitch_MenuItem.Text = "Game Settings Switch";
            GameSettingsSwitch_MenuItem.Click += GameSettingsSwitch_MenuItem_Click;
            //
            // RestoreLast_MenuItem
            //
            RestoreLast_MenuItem.Name = "RestoreLast_MenuItem";
            RestoreLast_MenuItem.Size = new Size(237, 22);
            RestoreLast_MenuItem.Text = "Restore Last Game Settings";
            RestoreLast_MenuItem.Click += RestoreLast_MenuItem_Click;
            //
            // RestoreOriginal_MenuItem
            //
            RestoreOriginal_MenuItem.Name = "RestoreOriginal_MenuItem";
            RestoreOriginal_MenuItem.Size = new Size(237, 22);
            RestoreOriginal_MenuItem.Text = "Restore Original Game Settings";
            RestoreOriginal_MenuItem.Click += RestoreOriginal_MenuItem_Click;
            //
            // toolStripSeparator7
            //
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(234, 6);
            //
            // SaveFileControl_MenuItem
            //
            SaveFileControl_MenuItem.Name = "SaveFileControl_MenuItem";
            SaveFileControl_MenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveFileControl_MenuItem.Size = new Size(237, 22);
            SaveFileControl_MenuItem.Text = "Save File Patcher";
            SaveFileControl_MenuItem.Click += SaveFileControl_MenuItem_Click;
            //
            // TexExplorer_MenuItem
            //
            TexExplorer_MenuItem.Name = "TexExplorer_MenuItem";
            TexExplorer_MenuItem.ShortcutKeys = Keys.Control | Keys.I;
            TexExplorer_MenuItem.Size = new Size(237, 22);
            TexExplorer_MenuItem.Text = "Texture Explorer";
            TexExplorer_MenuItem.Click += TexExplorer_MenuItem_Click;
            //
            // FxSpeedBoost_MenuItem
            //
            FxSpeedBoost_MenuItem.Name = "FxSpeedBoost_MenuItem";
            FxSpeedBoost_MenuItem.Size = new Size(237, 22);
            FxSpeedBoost_MenuItem.Text = "FX Speed Boost";
            FxSpeedBoost_MenuItem.Click += FxSpeedBoost_MenuItem_Click;
            //
            // ManageSongs_MenuItem
            //
            ManageSongs_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            SongProps_MenuItem,
            RebuildSong_MenuItem,
            SilentGuitar_MenuItem,
            ForceMp3Conversion_MenuItem,
            forceRB3MidConversionToolStripMenuItem,
            DeleteSong_MenuItem,
            RemoveSong_ToolStripMenuItem,
            HideUnEdit_MenuItem,
            HideUsed_MenuItem,
            ByTitle_MenuItem});
            ManageSongs_MenuItem.Name = "ManageSongs_MenuItem";
            ManageSongs_MenuItem.Size = new Size(135, 20);
            ManageSongs_MenuItem.Text = "Songlist Management";
            //
            // SongProps_MenuItem
            //
            SongProps_MenuItem.Name = "SongProps_MenuItem";
            SongProps_MenuItem.ShortcutKeys = Keys.Control | Keys.P;
            SongProps_MenuItem.Size = new Size(221, 22);
            SongProps_MenuItem.Text = "Edit Song Properties";
            SongProps_MenuItem.Click += SongProps_MenuItem_Click;
            //
            // RebuildSong_MenuItem
            //
            RebuildSong_MenuItem.Name = "RebuildSong_MenuItem";
            RebuildSong_MenuItem.ShortcutKeys = Keys.Control | Keys.D;
            RebuildSong_MenuItem.Size = new Size(221, 22);
            RebuildSong_MenuItem.Text = "Rebuild Song Data";
            RebuildSong_MenuItem.Click += RebuildSong_MenuItem_Click;
            //
            // SilentGuitar_MenuItem
            //
            SilentGuitar_MenuItem.Name = "SilentGuitar_MenuItem";
            SilentGuitar_MenuItem.Size = new Size(221, 22);
            SilentGuitar_MenuItem.Text = "Silent Guitar Track";
            SilentGuitar_MenuItem.Click += SilentGuitar_MenuItem_Click;
            //
            // ForceMp3Conversion_MenuItem
            //
            ForceMp3Conversion_MenuItem.Name = "ForceMp3Conversion_MenuItem";
            ForceMp3Conversion_MenuItem.Size = new Size(221, 22);
            ForceMp3Conversion_MenuItem.Text = "Force Mp3 Conversion";
            ForceMp3Conversion_MenuItem.Click += ForceMp3Conversion_MenuItem_Click;
            //
            // forceRB3MidConversionToolStripMenuItem
            //
            forceRB3MidConversionToolStripMenuItem.CheckOnClick = true;
            forceRB3MidConversionToolStripMenuItem.Name = "forceRB3MidConversionToolStripMenuItem";
            forceRB3MidConversionToolStripMenuItem.Size = new Size(221, 22);
            forceRB3MidConversionToolStripMenuItem.Text = "Force RB3 Mid Conversion";
            forceRB3MidConversionToolStripMenuItem.Click += forceRB3MidConversionToolStripMenuItem_Click;
            //
            // DeleteSong_MenuItem
            //
            DeleteSong_MenuItem.Name = "DeleteSong_MenuItem";
            DeleteSong_MenuItem.Size = new Size(221, 22);
            DeleteSong_MenuItem.Text = "Delete Song";
            DeleteSong_MenuItem.Click += DeleteSong_MenuItem_Click;
            //
            // RemoveSong_ToolStripMenuItem
            //
            RemoveSong_ToolStripMenuItem.Name = "RemoveSong_ToolStripMenuItem";
            RemoveSong_ToolStripMenuItem.Size = new Size(218, 6);
            //
            // HideUnEdit_MenuItem
            //
            HideUnEdit_MenuItem.Name = "HideUnEdit_MenuItem";
            HideUnEdit_MenuItem.ShortcutKeys = Keys.Alt | Keys.O;
            HideUnEdit_MenuItem.Size = new Size(221, 22);
            HideUnEdit_MenuItem.Text = "Hide Original Songs";
            HideUnEdit_MenuItem.Click += HideUnEdit_MenuItem_Click;
            //
            // HideUsed_MenuItem
            //
            HideUsed_MenuItem.Name = "HideUsed_MenuItem";
            HideUsed_MenuItem.ShortcutKeys = Keys.Alt | Keys.H;
            HideUsed_MenuItem.Size = new Size(221, 22);
            HideUsed_MenuItem.Text = "Hide Used Songs";
            HideUsed_MenuItem.Click += HideUsed_MenuItem_Click;
            //
            // ByTitle_MenuItem
            //
            ByTitle_MenuItem.Name = "ByTitle_MenuItem";
            ByTitle_MenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            ByTitle_MenuItem.Size = new Size(221, 22);
            ByTitle_MenuItem.Text = "Display By Title";
            ByTitle_MenuItem.Click += ByTitle_MenuItem_Click;
            //
            // Help_MenuItem
            //
            Help_MenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            Guide_MenuItem,
            ScoreHero_MenuItem,
            GH3Folder_MenuItem,
            toolStripSeparator3,
            Disclaimer_MenuItem,
            About_MenuItem});
            Help_MenuItem.Name = "Help_MenuItem";
            Help_MenuItem.Size = new Size(44, 20);
            Help_MenuItem.Text = "Help";
            //
            // Guide_MenuItem
            //
            Guide_MenuItem.Name = "Guide_MenuItem";
            Guide_MenuItem.ShortcutKeys = Keys.F1;
            Guide_MenuItem.Size = new Size(154, 22);
            Guide_MenuItem.Text = "Guide";
            Guide_MenuItem.Click += Guide_MenuItem_Click;
            //
            // ScoreHero_MenuItem
            //
            ScoreHero_MenuItem.Name = "ScoreHero_MenuItem";
            ScoreHero_MenuItem.ShortcutKeys = Keys.F2;
            ScoreHero_MenuItem.Size = new Size(154, 22);
            ScoreHero_MenuItem.Text = "Score Hero";
            ScoreHero_MenuItem.Click += ScoreHero_MenuItem_Click;
            //
            // GH3Folder_MenuItem
            //
            GH3Folder_MenuItem.Name = "GH3Folder_MenuItem";
            GH3Folder_MenuItem.ShortcutKeys = Keys.F3;
            GH3Folder_MenuItem.Size = new Size(154, 22);
            GH3Folder_MenuItem.Text = "GH3 Folder";
            GH3Folder_MenuItem.Click += GH3Folder_MenuItem_Click;
            //
            // toolStripSeparator3
            //
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(151, 6);
            //
            // Disclaimer_MenuItem
            //
            Disclaimer_MenuItem.Name = "Disclaimer_MenuItem";
            Disclaimer_MenuItem.ShortcutKeys = Keys.F11;
            Disclaimer_MenuItem.Size = new Size(154, 22);
            Disclaimer_MenuItem.Text = "Disclaimer";
            Disclaimer_MenuItem.Click += Disclaimer_MenuItem_Click;
            //
            // About_MenuItem
            //
            About_MenuItem.Name = "About_MenuItem";
            About_MenuItem.ShortcutKeys = Keys.F12;
            About_MenuItem.Size = new Size(154, 22);
            About_MenuItem.Text = "About";
            About_MenuItem.Click += About_MenuItem_Click;
            //
            // ActionRequests_ListBox
            //
            ActionRequests_ListBox.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                             | AnchorStyles.Left)
                                            | AnchorStyles.Right;
            ActionRequests_ListBox.FormattingEnabled = true;
            ActionRequests_ListBox.IntegralHeight = false;
            ActionRequests_ListBox.Location = new Point(0, 400);
            ActionRequests_ListBox.Margin = new Padding(0);
            ActionRequests_ListBox.Name = "ActionRequests_ListBox";
            ActionRequests_ListBox.ScrollAlwaysVisible = true;
            ActionRequests_ListBox.Size = new Size(180, 119);
            ActionRequests_ListBox.TabIndex = 3;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 4;
            label1.Text = "Song List";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 375);
            label3.Name = "label3";
            label3.Size = new Size(174, 25);
            label3.TabIndex = 6;
            label3.Text = "Action Request";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SidePanel
            //
            SidePanel.ColumnCount = 1;
            SidePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            SidePanel.Controls.Add(ActionRequests_ListBox, 0, 3);
            SidePanel.Controls.Add(label1, 0, 0);
            SidePanel.Controls.Add(label3, 0, 2);
            SidePanel.Controls.Add(SongListBox, 0, 1);
            SidePanel.Dock = DockStyle.Left;
            SidePanel.Location = new Point(0, 0);
            SidePanel.Margin = new Padding(0);
            SidePanel.MinimumSize = new Size(180, 500);
            SidePanel.Name = "SidePanel";
            SidePanel.RowCount = 4;
            SidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            SidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            SidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            SidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            SidePanel.Size = new Size(180, 519);
            SidePanel.TabIndex = 7;
            //
            // notifyIcon_0
            //
            notifyIcon_0.Icon = ((Icon)(resources.GetObject("notifyIcon_0.Icon")));
            notifyIcon_0.Text = "Guitar Hero Three Control Panel+";
            notifyIcon_0.Visible = true;
            notifyIcon_0.MouseDown += notifyIcon_0_MouseDown;
            //
            // fontDialog_0
            //
            fontDialog_0.Color = Color.Red;
            fontDialog_0.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fontDialog_0.ShowColor = true;
            //
            // leftClickMenu
            //
            leftClickMenu.Items.AddRange(new ToolStripItem[] {
            SysEnglish_MenuItem,
            SysFrench_MenuItem,
            SysItalian_MenuItem,
            SysSpanish_MenuItem,
            SysGerman_MenuItem,
            SysKorean_MenuItem});
            leftClickMenu.Name = "leftClickMenu";
            leftClickMenu.Size = new Size(118, 136);
            //
            // SysEnglish_MenuItem
            //
            SysEnglish_MenuItem.Name = "SysEnglish_MenuItem";
            SysEnglish_MenuItem.ShowShortcutKeys = false;
            SysEnglish_MenuItem.Size = new Size(117, 22);
            SysEnglish_MenuItem.Tag = "en";
            SysEnglish_MenuItem.Text = "(English)";
            SysEnglish_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysFrench_MenuItem
            //
            SysFrench_MenuItem.Name = "SysFrench_MenuItem";
            SysFrench_MenuItem.ShowShortcutKeys = false;
            SysFrench_MenuItem.Size = new Size(117, 22);
            SysFrench_MenuItem.Tag = "fr";
            SysFrench_MenuItem.Text = "(French)";
            SysFrench_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysItalian_MenuItem
            //
            SysItalian_MenuItem.Name = "SysItalian_MenuItem";
            SysItalian_MenuItem.ShowShortcutKeys = false;
            SysItalian_MenuItem.Size = new Size(117, 22);
            SysItalian_MenuItem.Tag = "it";
            SysItalian_MenuItem.Text = "(Italian)";
            SysItalian_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysSpanish_MenuItem
            //
            SysSpanish_MenuItem.Name = "SysSpanish_MenuItem";
            SysSpanish_MenuItem.ShowShortcutKeys = false;
            SysSpanish_MenuItem.Size = new Size(117, 22);
            SysSpanish_MenuItem.Tag = "es";
            SysSpanish_MenuItem.Text = "(Spanish)";
            SysSpanish_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysGerman_MenuItem
            //
            SysGerman_MenuItem.Name = "SysGerman_MenuItem";
            SysGerman_MenuItem.ShowShortcutKeys = false;
            SysGerman_MenuItem.Size = new Size(117, 22);
            SysGerman_MenuItem.Tag = "de";
            SysGerman_MenuItem.Text = "(German)";
            SysGerman_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysKorean_MenuItem
            //
            SysKorean_MenuItem.Name = "SysKorean_MenuItem";
            SysKorean_MenuItem.ShowShortcutKeys = false;
            SysKorean_MenuItem.Size = new Size(117, 22);
            SysKorean_MenuItem.Tag = "ko";
            SysKorean_MenuItem.Text = "(Korean)";
            SysKorean_MenuItem.Click += SysKorean_MenuItem_Click;
            //
            // MainContainer
            //
            //
            // MainContainer.BottomToolStripPanel
            //
            MainContainer.BottomToolStripPanel.Controls.Add(StatusStrip);
            //
            // MainContainer.ContentPanel
            //
            MainContainer.ContentPanel.Controls.Add(TabControl);
            MainContainer.ContentPanel.Controls.Add(SidePanel);
            MainContainer.ContentPanel.Size = new Size(784, 519);
            MainContainer.Dock = DockStyle.Fill;
            MainContainer.LeftToolStripPanelVisible = false;
            MainContainer.Location = new Point(0, 0);
            MainContainer.Name = "MainContainer";
            MainContainer.RightToolStripPanelVisible = false;
            MainContainer.Size = new Size(784, 565);
            MainContainer.TabIndex = 13;
            MainContainer.Text = "toolStripContainer1";
            //
            // MainContainer.TopToolStripPanel
            //
            MainContainer.TopToolStripPanel.Controls.Add(TopMenuStrip);
            //
            // StatusStrip
            //
            StatusStrip.Dock = DockStyle.None;
            StatusStrip.Items.AddRange(new ToolStripItem[] {
            ToolStripStatusLbl});
            StatusStrip.Location = new Point(0, 0);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(784, 22);
            StatusStrip.TabIndex = 0;
            //
            // ToolStripStatusLbl
            //
            ToolStripStatusLbl.Name = "ToolStripStatusLbl";
            ToolStripStatusLbl.Size = new Size(0, 17);
            ToolStripStatusLbl.Tag = "Function Description";
            //
            // TabControl
            //
            TabControl.Controls.Add(SetlistTab);
            TabControl.Controls.Add(SongEditorTab);
            TabControl.Dock = DockStyle.Fill;
            TabControl.HotTrack = true;
            TabControl.Location = new Point(180, 0);
            TabControl.Margin = new Padding(0);
            TabControl.MinimumSize = new Size(600, 500);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(604, 519);
            TabControl.TabIndex = 8;
            //
            // SetlistTab
            //
            SetlistTab.Controls.Add(SetlistConfig_Container);
            SetlistTab.Location = new Point(4, 22);
            SetlistTab.Name = "SetlistTab";
            SetlistTab.Padding = new Padding(3);
            SetlistTab.Size = new Size(596, 493);
            SetlistTab.TabIndex = 0;
            SetlistTab.Text = "Setlist Configuration";
            SetlistTab.UseVisualStyleBackColor = true;
            //
            // SetlistConfig_Container
            //
            //
            // SetlistConfig_Container.ContentPanel
            //
            SetlistConfig_Container.ContentPanel.Controls.Add(SetlistConf_TLPanel);
            SetlistConfig_Container.ContentPanel.Size = new Size(590, 462);
            SetlistConfig_Container.Dock = DockStyle.Fill;
            SetlistConfig_Container.Location = new Point(3, 3);
            SetlistConfig_Container.Name = "SetlistConfig_Container";
            SetlistConfig_Container.Size = new Size(590, 487);
            SetlistConfig_Container.TabIndex = 3;
            SetlistConfig_Container.Text = "Setlist Config Container";
            //
            // SetlistConfig_Container.TopToolStripPanel
            //
            SetlistConfig_Container.TopToolStripPanel.Controls.Add(SetlistStrip);
            //
            // SetlistConf_TLPanel
            //
            SetlistConf_TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            SetlistConf_TLPanel.ColumnCount = 1;
            SetlistConf_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            SetlistConf_TLPanel.Controls.Add(Setlist_TLPanel, 0, 0);
            SetlistConf_TLPanel.Controls.Add(Tier_TLPanel, 0, 1);
            SetlistConf_TLPanel.Dock = DockStyle.Fill;
            SetlistConf_TLPanel.Location = new Point(0, 0);
            SetlistConf_TLPanel.Name = "SetlistConf_TLPanel";
            SetlistConf_TLPanel.RowCount = 2;
            SetlistConf_TLPanel.RowStyles.Add(new RowStyle());
            SetlistConf_TLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            SetlistConf_TLPanel.Size = new Size(590, 462);
            SetlistConf_TLPanel.TabIndex = 2;
            //
            // Setlist_TLPanel
            //
            Setlist_TLPanel.ColumnCount = 4;
            Setlist_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            Setlist_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            Setlist_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            Setlist_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            Setlist_TLPanel.Controls.Add(textBox3, 1, 2);
            Setlist_TLPanel.Controls.Add(label5, 3, 0);
            Setlist_TLPanel.Controls.Add(label4, 2, 0);
            Setlist_TLPanel.Controls.Add(TierBox, 3, 1);
            Setlist_TLPanel.Controls.Add(SetlistInitMovie_TxtBox, 2, 1);
            Setlist_TLPanel.Controls.Add(SetlistPrefix_TxtBox, 1, 1);
            Setlist_TLPanel.Controls.Add(label2, 0, 0);
            Setlist_TLPanel.Controls.Add(label13, 1, 0);
            Setlist_TLPanel.Controls.Add(SetlistTitle_TxtBox, 0, 1);
            Setlist_TLPanel.Dock = DockStyle.Fill;
            Setlist_TLPanel.Location = new Point(4, 4);
            Setlist_TLPanel.Name = "Setlist_TLPanel";
            Setlist_TLPanel.RowCount = 3;
            Setlist_TLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            Setlist_TLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            Setlist_TLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            Setlist_TLPanel.Size = new Size(582, 44);
            Setlist_TLPanel.TabIndex = 0;
            //
            // textBox3
            //
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(148, 49);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(139, 20);
            textBox3.TabIndex = 7;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(438, 0);
            label5.Name = "label5";
            label5.Size = new Size(141, 20);
            label5.TabIndex = 5;
            label5.Text = "Tiers";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(293, 0);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 4;
            label4.Text = "Initial Movie";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            //
            // TierBox
            //
            TierBox.Dock = DockStyle.Fill;
            TierBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TierBox.FormattingEnabled = true;
            TierBox.Location = new Point(438, 23);
            TierBox.Name = "TierBox";
            TierBox.Size = new Size(141, 21);
            TierBox.TabIndex = 7;
            TierBox.SelectedIndexChanged += TierBox_SelectedIndexChanged;
            //
            // SetlistInitMovie_TxtBox
            //
            SetlistInitMovie_TxtBox.Dock = DockStyle.Fill;
            SetlistInitMovie_TxtBox.Location = new Point(293, 23);
            SetlistInitMovie_TxtBox.Name = "SetlistInitMovie_TxtBox";
            SetlistInitMovie_TxtBox.Size = new Size(139, 20);
            SetlistInitMovie_TxtBox.TabIndex = 6;
            SetlistInitMovie_TxtBox.TextChanged += SetlistTitle_TxtBox_TextChanged;
            //
            // SetlistPrefix_TxtBox
            //
            SetlistPrefix_TxtBox.Dock = DockStyle.Fill;
            SetlistPrefix_TxtBox.Enabled = false;
            SetlistPrefix_TxtBox.Location = new Point(148, 23);
            SetlistPrefix_TxtBox.Name = "SetlistPrefix_TxtBox";
            SetlistPrefix_TxtBox.Size = new Size(139, 20);
            SetlistPrefix_TxtBox.TabIndex = 1;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 3;
            label2.Text = "Title";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label13
            //
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(148, 0);
            label13.Name = "label13";
            label13.Size = new Size(139, 20);
            label13.TabIndex = 8;
            label13.Text = "Prefix";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistTitle_TxtBox
            //
            SetlistTitle_TxtBox.Dock = DockStyle.Fill;
            SetlistTitle_TxtBox.Enabled = false;
            SetlistTitle_TxtBox.Location = new Point(3, 23);
            SetlistTitle_TxtBox.Name = "SetlistTitle_TxtBox";
            SetlistTitle_TxtBox.Size = new Size(139, 20);
            SetlistTitle_TxtBox.TabIndex = 9;
            SetlistTitle_TxtBox.TextChanged += SetlistTitle_TxtBox_TextChanged;
            //
            // Tier_TLPanel
            //
            Tier_TLPanel.ColumnCount = 2;
            Tier_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Tier_TLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            Tier_TLPanel.Controls.Add(TierProps_Panel, 0, 0);
            Tier_TLPanel.Controls.Add(TierSongs_Panel, 1, 0);
            Tier_TLPanel.Dock = DockStyle.Fill;
            Tier_TLPanel.Location = new Point(4, 55);
            Tier_TLPanel.Name = "Tier_TLPanel";
            Tier_TLPanel.RowCount = 1;
            Tier_TLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Tier_TLPanel.Size = new Size(582, 403);
            Tier_TLPanel.TabIndex = 1;
            //
            // TierProps_Panel
            //
            TierProps_Panel.Controls.Add(TierUnlockedSet_Btn);
            TierProps_Panel.Controls.Add(UnlockAll_CheckBox);
            TierProps_Panel.Controls.Add(NoCash_CheckBox);
            TierProps_Panel.Controls.Add(TierApply_Btn);
            TierProps_Panel.Controls.Add(label12);
            TierProps_Panel.Controls.Add(SetlistApply_Btn);
            TierProps_Panel.Controls.Add(TierCompMovie_TxtBox);
            TierProps_Panel.Controls.Add(TierUnlocked_NumBox);
            TierProps_Panel.Controls.Add(TierTitle_TxtBox);
            TierProps_Panel.Controls.Add(TierIcon_DropBox);
            TierProps_Panel.Controls.Add(TierStage_DropBox);
            TierProps_Panel.Controls.Add(TierBoss_CheckBox);
            TierProps_Panel.Controls.Add(TierEncorep2_CheckBox);
            TierProps_Panel.Controls.Add(TierEncorep1_CheckBox);
            TierProps_Panel.Controls.Add(label10);
            TierProps_Panel.Controls.Add(label9);
            TierProps_Panel.Controls.Add(label8);
            TierProps_Panel.Controls.Add(label6);
            TierProps_Panel.Controls.Add(label7);
            TierProps_Panel.Dock = DockStyle.Fill;
            TierProps_Panel.Location = new Point(3, 3);
            TierProps_Panel.Name = "TierProps_Panel";
            TierProps_Panel.Size = new Size(396, 397);
            TierProps_Panel.TabIndex = 0;
            //
            // TierUnlockedSet_Btn
            //
            TierUnlockedSet_Btn.Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TierUnlockedSet_Btn.Location = new Point(242, 55);
            TierUnlockedSet_Btn.Name = "TierUnlockedSet_Btn";
            TierUnlockedSet_Btn.Size = new Size(33, 20);
            TierUnlockedSet_Btn.TabIndex = 23;
            TierUnlockedSet_Btn.Text = "=";
            TierUnlockedSet_Btn.UseVisualStyleBackColor = true;
            TierUnlockedSet_Btn.Click += TierUnlockedSet_Btn_Click;
            //
            // UnlockAll_CheckBox
            //
            UnlockAll_CheckBox.AutoSize = true;
            UnlockAll_CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UnlockAll_CheckBox.Location = new Point(226, 168);
            UnlockAll_CheckBox.Name = "UnlockAll_CheckBox";
            UnlockAll_CheckBox.Size = new Size(97, 23);
            UnlockAll_CheckBox.TabIndex = 22;
            UnlockAll_CheckBox.Text = "Unlock All";
            UnlockAll_CheckBox.UseVisualStyleBackColor = true;
            UnlockAll_CheckBox.Visible = false;
            UnlockAll_CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // NoCash_CheckBox
            //
            NoCash_CheckBox.AutoSize = true;
            NoCash_CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoCash_CheckBox.Location = new Point(128, 168);
            NoCash_CheckBox.Name = "NoCash_CheckBox";
            NoCash_CheckBox.Size = new Size(86, 23);
            NoCash_CheckBox.TabIndex = 15;
            NoCash_CheckBox.Text = "No Cash";
            NoCash_CheckBox.UseVisualStyleBackColor = true;
            NoCash_CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierApply_Btn
            //
            TierApply_Btn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TierApply_Btn.Location = new Point(16, 255);
            TierApply_Btn.Name = "TierApply_Btn";
            TierApply_Btn.Size = new Size(153, 27);
            TierApply_Btn.TabIndex = 17;
            TierApply_Btn.Text = "Apply Tier Changes";
            TierApply_Btn.UseVisualStyleBackColor = true;
            TierApply_Btn.Click += TierApply_Btn_Click;
            //
            // label12
            //
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(89, 5);
            label12.Name = "label12";
            label12.Size = new Size(110, 19);
            label12.TabIndex = 21;
            label12.Text = "Tier Properties";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistApply_Btn
            //
            SetlistApply_Btn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SetlistApply_Btn.Location = new Point(175, 255);
            SetlistApply_Btn.Name = "SetlistApply_Btn";
            SetlistApply_Btn.Size = new Size(169, 27);
            SetlistApply_Btn.TabIndex = 18;
            SetlistApply_Btn.Text = "Apply Setlist Changes";
            SetlistApply_Btn.UseVisualStyleBackColor = true;
            SetlistApply_Btn.Click += SetlistApply_Btn_Click;
            //
            // TierCompMovie_TxtBox
            //
            TierCompMovie_TxtBox.Location = new Point(156, 84);
            TierCompMovie_TxtBox.Name = "TierCompMovie_TxtBox";
            TierCompMovie_TxtBox.Size = new Size(119, 20);
            TierCompMovie_TxtBox.TabIndex = 10;
            TierCompMovie_TxtBox.TextChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierUnlocked_NumBox
            //
            TierUnlocked_NumBox.Location = new Point(193, 55);
            TierUnlocked_NumBox.Maximum = new decimal(new[] {
            65536,
            0,
            0,
            0});
            TierUnlocked_NumBox.Name = "TierUnlocked_NumBox";
            TierUnlocked_NumBox.Size = new Size(43, 20);
            TierUnlocked_NumBox.TabIndex = 9;
            TierUnlocked_NumBox.ValueChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierTitle_TxtBox
            //
            TierTitle_TxtBox.Location = new Point(63, 26);
            TierTitle_TxtBox.Name = "TierTitle_TxtBox";
            TierTitle_TxtBox.Size = new Size(212, 20);
            TierTitle_TxtBox.TabIndex = 8;
            TierTitle_TxtBox.TextChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierIcon_DropBox
            //
            TierIcon_DropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TierIcon_DropBox.FormattingEnabled = true;
            TierIcon_DropBox.Items.AddRange(new object[] {
            "No Icon"});
            TierIcon_DropBox.Location = new Point(93, 112);
            TierIcon_DropBox.Name = "TierIcon_DropBox";
            TierIcon_DropBox.Size = new Size(182, 21);
            TierIcon_DropBox.TabIndex = 11;
            TierIcon_DropBox.SelectedIndexChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierStage_DropBox
            //
            TierStage_DropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TierStage_DropBox.FormattingEnabled = true;
            TierStage_DropBox.Items.AddRange(new object[] {
            "No Preset Stage"});
            TierStage_DropBox.Location = new Point(70, 141);
            TierStage_DropBox.Name = "TierStage_DropBox";
            TierStage_DropBox.Size = new Size(205, 21);
            TierStage_DropBox.TabIndex = 12;
            TierStage_DropBox.SelectedIndexChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierBoss_CheckBox
            //
            TierBoss_CheckBox.AutoSize = true;
            TierBoss_CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TierBoss_CheckBox.Location = new Point(16, 168);
            TierBoss_CheckBox.Name = "TierBoss_CheckBox";
            TierBoss_CheckBox.Size = new Size(106, 23);
            TierBoss_CheckBox.TabIndex = 13;
            TierBoss_CheckBox.Text = "Boss Battle";
            TierBoss_CheckBox.UseVisualStyleBackColor = true;
            TierBoss_CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierEncorep2_CheckBox
            //
            TierEncorep2_CheckBox.AutoSize = true;
            TierEncorep2_CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TierEncorep2_CheckBox.Location = new Point(128, 197);
            TierEncorep2_CheckBox.Name = "TierEncorep2_CheckBox";
            TierEncorep2_CheckBox.Size = new Size(96, 23);
            TierEncorep2_CheckBox.TabIndex = 16;
            TierEncorep2_CheckBox.Text = "P2 Encore";
            TierEncorep2_CheckBox.UseVisualStyleBackColor = true;
            TierEncorep2_CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierEncorep1_CheckBox
            //
            TierEncorep1_CheckBox.AutoSize = true;
            TierEncorep1_CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TierEncorep1_CheckBox.Location = new Point(16, 197);
            TierEncorep1_CheckBox.Name = "TierEncorep1_CheckBox";
            TierEncorep1_CheckBox.Size = new Size(96, 23);
            TierEncorep1_CheckBox.TabIndex = 14;
            TierEncorep1_CheckBox.Text = "P1 Encore";
            TierEncorep1_CheckBox.UseVisualStyleBackColor = true;
            TierEncorep1_CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // label10
            //
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 140);
            label10.Name = "label10";
            label10.Size = new Size(52, 19);
            label10.TabIndex = 10;
            label10.Text = "Stage:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label9
            //
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 111);
            label9.Name = "label9";
            label9.Size = new Size(75, 19);
            label9.TabIndex = 9;
            label9.Text = "Tier Icon:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(12, 83);
            label8.Name = "label8";
            label8.Size = new Size(138, 19);
            label8.TabIndex = 8;
            label8.Text = "Completion Movie:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 25);
            label6.Name = "label6";
            label6.Size = new Size(45, 19);
            label6.TabIndex = 7;
            label6.Text = "Title:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 55);
            label7.Name = "label7";
            label7.Size = new Size(175, 19);
            label7.TabIndex = 6;
            label7.Text = "Default Unlocked Songs:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            //
            // TierSongs_Panel
            //
            TierSongs_Panel.ColumnCount = 1;
            TierSongs_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TierSongs_Panel.Controls.Add(TierSongs_ListBox, 0, 1);
            TierSongs_Panel.Controls.Add(label11, 0, 0);
            TierSongs_Panel.Dock = DockStyle.Fill;
            TierSongs_Panel.Location = new Point(405, 3);
            TierSongs_Panel.Name = "TierSongs_Panel";
            TierSongs_Panel.RowCount = 2;
            TierSongs_Panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TierSongs_Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TierSongs_Panel.Size = new Size(174, 397);
            TierSongs_Panel.TabIndex = 1;
            //
            // label11
            //
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(168, 20);
            label11.TabIndex = 5;
            label11.Text = "Tier Songs";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistStrip
            //
            SetlistStrip.Dock = DockStyle.None;
            SetlistStrip.GripStyle = ToolStripGripStyle.Hidden;
            SetlistStrip.Items.AddRange(new ToolStripItem[] {
            Setlist_Lbl,
            Setlist_DropBox,
            CreateSetlist_Btn,
            DeleteSetlist_Btn});
            SetlistStrip.Location = new Point(0, 0);
            SetlistStrip.Name = "SetlistStrip";
            SetlistStrip.Size = new Size(590, 25);
            SetlistStrip.Stretch = true;
            SetlistStrip.TabIndex = 0;
            SetlistStrip.Text = "toolStrip1";
            //
            // Setlist_Lbl
            //
            Setlist_Lbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            Setlist_Lbl.Name = "Setlist_Lbl";
            Setlist_Lbl.Size = new Size(56, 22);
            Setlist_Lbl.Text = "Setlist:";
            //
            // Setlist_DropBox
            //
            Setlist_DropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Setlist_DropBox.Name = "Setlist_DropBox";
            Setlist_DropBox.Size = new Size(121, 25);
            Setlist_DropBox.SelectedIndexChanged += Setlist_DropBox_SelectedIndexChanged;
            //
            // CreateSetlist_Btn
            //
            CreateSetlist_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CreateSetlist_Btn.ImageTransparentColor = Color.Magenta;
            CreateSetlist_Btn.Name = "CreateSetlist_Btn";
            CreateSetlist_Btn.Size = new Size(79, 22);
            CreateSetlist_Btn.Text = "Create Setlist";
            CreateSetlist_Btn.Click += CreateSetlist_Btn_Click;
            //
            // DeleteSetlist_Btn
            //
            DeleteSetlist_Btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteSetlist_Btn.ImageTransparentColor = Color.Magenta;
            DeleteSetlist_Btn.Name = "DeleteSetlist_Btn";
            DeleteSetlist_Btn.Size = new Size(78, 22);
            DeleteSetlist_Btn.Text = "Delete Setlist";
            DeleteSetlist_Btn.Click += DeleteSetlist_Btn_Click;
            //
            // SongEditorTab
            //
            SongEditorTab.AccessibleRole = AccessibleRole.None;
            SongEditorTab.Controls.Add(SongEditor_Container);
            SongEditorTab.Location = new Point(4, 22);
            SongEditorTab.Name = "SongEditorTab";
            SongEditorTab.Padding = new Padding(3);
            SongEditorTab.Size = new Size(596, 493);
            SongEditorTab.TabIndex = 1;
            SongEditorTab.Text = "Song Editor";
            SongEditorTab.UseVisualStyleBackColor = true;
            //
            // SongEditor_Container
            //
            //
            // SongEditor_Container.BottomToolStripPanel
            //
            SongEditor_Container.BottomToolStripPanel.Controls.Add(SongEditor_BottomToolStrip);
            //
            // SongEditor_Container.ContentPanel
            //
            SongEditor_Container.ContentPanel.Controls.Add(SongEditor_Control);
            SongEditor_Container.ContentPanel.Size = new Size(590, 437);
            SongEditor_Container.Dock = DockStyle.Fill;
            SongEditor_Container.Location = new Point(3, 3);
            SongEditor_Container.Name = "SongEditor_Container";
            SongEditor_Container.Size = new Size(590, 487);
            SongEditor_Container.TabIndex = 1;
            SongEditor_Container.Text = "SongEditor Container";
            //
            // SongEditor_Container.TopToolStripPanel
            //
            SongEditor_Container.TopToolStripPanel.Controls.Add(SongEditor_TopToolStrip);
            //
            // SongEditor_BottomToolStrip
            //
            SongEditor_BottomToolStrip.Dock = DockStyle.None;
            SongEditor_BottomToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            SongEditor_BottomToolStrip.Items.AddRange(new ToolStripItem[] {
            ToggleElements_EditorSplitBtn,
            toolStripSeparator10,
            toolStripLabel1,
            BeatSize_EditorTxtBox,
            HyperSpeed_EditorBar,
            FretAngle_EditorBar,
            toolStripSeparator12,
            toolStripLabel2,
            Offset_EditorTxtBox});
            SongEditor_BottomToolStrip.Location = new Point(0, 0);
            SongEditor_BottomToolStrip.Name = "SongEditor_BottomToolStrip";
            SongEditor_BottomToolStrip.Size = new Size(590, 25);
            SongEditor_BottomToolStrip.Stretch = true;
            SongEditor_BottomToolStrip.TabIndex = 0;
            //
            // ToggleElements_EditorSplitBtn
            //
            ToggleElements_EditorSplitBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToggleElements_EditorSplitBtn.DropDownItems.AddRange(new ToolStripItem[] {
            StarView_EditorBtn,
            HopoView_EditorBtn,
            AudioView_EditorBtn});
            ToggleElements_EditorSplitBtn.ImageTransparentColor = Color.Magenta;
            ToggleElements_EditorSplitBtn.Name = "ToggleElements_EditorSplitBtn";
            ToggleElements_EditorSplitBtn.Size = new Size(111, 22);
            ToggleElements_EditorSplitBtn.Text = "Toggle Elements";
            ToggleElements_EditorSplitBtn.ButtonClick += ToggleElements_EditorSplitBtn_ButtonClick;
            //
            // StarView_EditorBtn
            //
            StarView_EditorBtn.Checked = true;
            StarView_EditorBtn.CheckOnClick = true;
            StarView_EditorBtn.CheckState = CheckState.Checked;
            StarView_EditorBtn.Name = "StarView_EditorBtn";
            StarView_EditorBtn.Size = new Size(130, 22);
            StarView_EditorBtn.Text = "Star Power";
            StarView_EditorBtn.Click += StarView_EditorBtn_Click;
            //
            // HopoView_EditorBtn
            //
            HopoView_EditorBtn.Checked = true;
            HopoView_EditorBtn.CheckOnClick = true;
            HopoView_EditorBtn.CheckState = CheckState.Checked;
            HopoView_EditorBtn.Name = "HopoView_EditorBtn";
            HopoView_EditorBtn.Size = new Size(130, 22);
            HopoView_EditorBtn.Text = "HoPo";
            HopoView_EditorBtn.Click += HopoView_EditorBtn_Click;
            //
            // AudioView_EditorBtn
            //
            AudioView_EditorBtn.Checked = true;
            AudioView_EditorBtn.CheckOnClick = true;
            AudioView_EditorBtn.CheckState = CheckState.Checked;
            AudioView_EditorBtn.Name = "AudioView_EditorBtn";
            AudioView_EditorBtn.Size = new Size(130, 22);
            AudioView_EditorBtn.Text = "Audio";
            AudioView_EditorBtn.Click += AudioView_EditorBtn_Click;
            //
            // toolStripSeparator10
            //
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 25);
            //
            // toolStripLabel1
            //
            toolStripLabel1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(77, 22);
            toolStripLabel1.Text = "Beat Size:";
            //
            // BeatSize_EditorTxtBox
            //
            BeatSize_EditorTxtBox.Name = "BeatSize_EditorTxtBox";
            BeatSize_EditorTxtBox.Size = new Size(30, 25);
            BeatSize_EditorTxtBox.Text = "20";
            BeatSize_EditorTxtBox.TextChanged += BeatSize_EditorTxtBox_TextChanged;
            //
            // toolStripSeparator12
            //
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(6, 25);
            //
            // toolStripLabel2
            //
            toolStripLabel2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(56, 22);
            toolStripLabel2.Text = "Offset:";
            //
            // Offset_EditorTxtBox
            //
            Offset_EditorTxtBox.Name = "Offset_EditorTxtBox";
            Offset_EditorTxtBox.Size = new Size(50, 25);
            Offset_EditorTxtBox.Text = "20";
            Offset_EditorTxtBox.TextChanged += Offset_EditorTxtBox_TextChanged;
            //
            // SongEditor_TopToolStrip
            //
            SongEditor_TopToolStrip.Dock = DockStyle.None;
            SongEditor_TopToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            SongEditor_TopToolStrip.Items.AddRange(new ToolStripItem[] {
            GameMode_EditorBtn,
            toolStripSeparator5,
            LoadChart_EditorBtn,
            SelectedTrack_EditorBox,
            SongName_EditorLbl,
            toolStripSeparator2,
            LoadAudio_EditorBtn,
            PlayPause_EditorBtn,
            Stop_EditorBtn,
            PlayTime_EditorLbl});
            SongEditor_TopToolStrip.Location = new Point(0, 0);
            SongEditor_TopToolStrip.Name = "SongEditor_TopToolStrip";
            SongEditor_TopToolStrip.Size = new Size(590, 25);
            SongEditor_TopToolStrip.Stretch = true;
            SongEditor_TopToolStrip.TabIndex = 0;
            //
            // GameMode_EditorBtn
            //
            GameMode_EditorBtn.Checked = true;
            GameMode_EditorBtn.CheckOnClick = true;
            GameMode_EditorBtn.CheckState = CheckState.Checked;
            GameMode_EditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GameMode_EditorBtn.ImageTransparentColor = Color.Magenta;
            GameMode_EditorBtn.Name = "GameMode_EditorBtn";
            GameMode_EditorBtn.Size = new Size(76, 22);
            GameMode_EditorBtn.Text = "Game Mode";
            GameMode_EditorBtn.Click += GameMode_EditorBtn_Click;
            //
            // toolStripSeparator5
            //
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            //
            // LoadChart_EditorBtn
            //
            LoadChart_EditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            LoadChart_EditorBtn.ImageTransparentColor = Color.Magenta;
            LoadChart_EditorBtn.Name = "LoadChart_EditorBtn";
            LoadChart_EditorBtn.Size = new Size(69, 22);
            LoadChart_EditorBtn.Text = "Load Chart";
            LoadChart_EditorBtn.Click += LoadChart_EditorBtn_Click;
            //
            // SelectedTrack_EditorBox
            //
            SelectedTrack_EditorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectedTrack_EditorBox.Name = "SelectedTrack_EditorBox";
            SelectedTrack_EditorBox.Size = new Size(100, 25);
            SelectedTrack_EditorBox.SelectedIndexChanged += SelectedTrack_EditorBox_SelectedIndexChanged;
            //
            // SongName_EditorLbl
            //
            SongName_EditorLbl.Name = "SongName_EditorLbl";
            SongName_EditorLbl.Size = new Size(69, 22);
            SongName_EditorLbl.Text = "Song Name";
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            //
            // LoadAudio_EditorBtn
            //
            LoadAudio_EditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            LoadAudio_EditorBtn.ImageTransparentColor = Color.Magenta;
            LoadAudio_EditorBtn.Name = "LoadAudio_EditorBtn";
            LoadAudio_EditorBtn.Size = new Size(72, 22);
            LoadAudio_EditorBtn.Text = "Load Audio";
            LoadAudio_EditorBtn.Click += LoadAudio_EditorBtn_Click;
            //
            // PlayPause_EditorBtn
            //
            PlayPause_EditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            PlayPause_EditorBtn.ImageTransparentColor = Color.Magenta;
            PlayPause_EditorBtn.Name = "PlayPause_EditorBtn";
            PlayPause_EditorBtn.Size = new Size(69, 22);
            PlayPause_EditorBtn.Text = "Play/Pause";
            PlayPause_EditorBtn.Click += PlayPause_EditorBtn_Click;
            //
            // Stop_EditorBtn
            //
            Stop_EditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Stop_EditorBtn.ImageTransparentColor = Color.Magenta;
            Stop_EditorBtn.Name = "Stop_EditorBtn";
            Stop_EditorBtn.Size = new Size(35, 22);
            Stop_EditorBtn.Text = "Stop";
            Stop_EditorBtn.Click += Stop_EditorBtn_Click;
            //
            // PlayTime_EditorLbl
            //
            PlayTime_EditorLbl.Name = "PlayTime_EditorLbl";
            PlayTime_EditorLbl.Size = new Size(59, 22);
            PlayTime_EditorLbl.Text = "Play Time";
            //
            // TierSongs_ListBox
            //
            TierSongs_ListBox.AllowDrop = true;
            TierSongs_ListBox.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                        | AnchorStyles.Left)
                                       | AnchorStyles.Right;
            TierSongs_ListBox.FormattingEnabled = true;
            TierSongs_ListBox.IntegralHeight = false;
            TierSongs_ListBox.Location = new Point(0, 20);
            TierSongs_ListBox.Margin = new Padding(0);
            TierSongs_ListBox.Name = "TierSongs_ListBox";
            TierSongs_ListBox.ScrollAlwaysVisible = true;
            TierSongs_ListBox.SelectionMode = SelectionMode.MultiExtended;
            TierSongs_ListBox.Size = new Size(174, 377);
            TierSongs_ListBox.TabIndex = 19;
            TierSongs_ListBox.KeyDown += TierSongs_ListBox_KeyDown;
            TierSongs_ListBox.MouseDown += TierSongs_ListBox_MouseDown;
            //
            // HyperSpeed_EditorBar
            //
            HyperSpeed_EditorBar.Name = "HyperSpeed_EditorBar";
            HyperSpeed_EditorBar.Size = new Size(104, 22);
            HyperSpeed_EditorBar.ToolTipText = "HyperSpeed";
            //
            // FretAngle_EditorBar
            //
            FretAngle_EditorBar.Name = "FretAngle_EditorBar";
            FretAngle_EditorBar.Size = new Size(104, 22);
            FretAngle_EditorBar.ToolTipText = "FretBar Angle";
            //
            // SongEditor_Control
            //
            SongEditor_Control.BackColor = Color.White;
            SongEditor_Control.Dock = DockStyle.Fill;
            SongEditor_Control.Location = new Point(0, 0);
            SongEditor_Control.Name = "SongEditor_Control";
            SongEditor_Control.Size = new Size(590, 437);
            SongEditor_Control.TabIndex = 0;
            //
            // SongListBox
            //
            SongListBox.AllowDrop = true;
            SongListBox.Dock = DockStyle.Fill;
            SongListBox.FormattingEnabled = true;
            SongListBox.IntegralHeight = false;
            SongListBox.Location = new Point(0, 20);
            SongListBox.Margin = new Padding(0);
            SongListBox.Name = "SongListBox";
            SongListBox.ScrollAlwaysVisible = true;
            SongListBox.SelectionMode = SelectionMode.MultiExtended;
            SongListBox.Size = new Size(180, 355);
            SongListBox.Sorted = true;
            SongListBox.TabIndex = 1;
            SongListBox.SelectedIndexChanged += SongListBox_SelectedIndexChanged;
            SongListBox.KeyDown += SongListBox_KeyDown;
            SongListBox.MouseDown += SongListBox_MouseDown;
            //
            // MainMenu
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 565);
            Controls.Add(MainContainer);
            DoubleBuffered = true;
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            MainMenuStrip = TopMenuStrip;
            MinimumSize = new Size(800, 600);
            Name = "MainMenu";
            Text = "Guitar Hero Three Control Panel+";
            FormClosing += MainMenu_FormClosing;
            SizeChanged += MainMenu_SizeChanged;
            rightClickMenu.ResumeLayout(false);
            TopMenuStrip.ResumeLayout(false);
            TopMenuStrip.PerformLayout();
            SidePanel.ResumeLayout(false);
            SidePanel.PerformLayout();
            leftClickMenu.ResumeLayout(false);
            MainContainer.BottomToolStripPanel.ResumeLayout(false);
            MainContainer.BottomToolStripPanel.PerformLayout();
            MainContainer.ContentPanel.ResumeLayout(false);
            MainContainer.TopToolStripPanel.ResumeLayout(false);
            MainContainer.TopToolStripPanel.PerformLayout();
            MainContainer.ResumeLayout(false);
            MainContainer.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            TabControl.ResumeLayout(false);
            SetlistTab.ResumeLayout(false);
            SetlistConfig_Container.ContentPanel.ResumeLayout(false);
            SetlistConfig_Container.TopToolStripPanel.ResumeLayout(false);
            SetlistConfig_Container.TopToolStripPanel.PerformLayout();
            SetlistConfig_Container.ResumeLayout(false);
            SetlistConfig_Container.PerformLayout();
            SetlistConf_TLPanel.ResumeLayout(false);
            Setlist_TLPanel.ResumeLayout(false);
            Setlist_TLPanel.PerformLayout();
            Tier_TLPanel.ResumeLayout(false);
            TierProps_Panel.ResumeLayout(false);
            TierProps_Panel.PerformLayout();
            ((ISupportInitialize)(TierUnlocked_NumBox)).EndInit();
            TierSongs_Panel.ResumeLayout(false);
            TierSongs_Panel.PerformLayout();
            SetlistStrip.ResumeLayout(false);
            SetlistStrip.PerformLayout();
            SongEditorTab.ResumeLayout(false);
            SongEditor_Container.BottomToolStripPanel.ResumeLayout(false);
            SongEditor_Container.BottomToolStripPanel.PerformLayout();
            SongEditor_Container.ContentPanel.ResumeLayout(false);
            SongEditor_Container.TopToolStripPanel.ResumeLayout(false);
            SongEditor_Container.TopToolStripPanel.PerformLayout();
            SongEditor_Container.ResumeLayout(false);
            SongEditor_Container.PerformLayout();
            SongEditor_BottomToolStrip.ResumeLayout(false);
            SongEditor_BottomToolStrip.PerformLayout();
            SongEditor_TopToolStrip.ResumeLayout(false);
            SongEditor_TopToolStrip.PerformLayout();
            ResumeLayout(false);

		}

        private void LoadMore()
        {
            TierSongs_ListBox.method_0("Songs");
            TierSongs_ListBox.method_1(false);
            TierSongs_ListBox.method_6(method_21);
            SongListBox.method_0("Songs");
            SongListBox.method_4(false);
            SongListBox.method_2(false);
            SongListBox.method_5(false);
            SongEditor_Control.Set5NoteLines(false);
            SongEditor_Control.SetFretboardAngle(0);
            SongEditor_Control.SetGamemodeView(true);
            SongEditor_Control.SetHyperspeed(1);
            SongEditor_Control.SetDoubleFretbarWidth(false);
            SongEditor_Control.method_29(method_1);
        }

		private void method_12(bool bool_1)
		{
			ToolStripItem arg_1F_0 = SaveChart_MenuItem;
			ToolStripItem arg_19_0 = RebuildSong_MenuItem;
			DeleteSong_MenuItem.Enabled = false;
			arg_19_0.Enabled = false;
			arg_1F_0.Enabled = false;
			ToolStripItem arg_B3_0 = Add_MenuItem;
			ToolStripItem arg_AC_0 = ManageGame_MenuItem;
			ToolStripItem arg_A2_0 = ManageSongs_MenuItem;
			ToolStripItem arg_98_0 = ExecuteActions_MenuItem;
			ToolStripItem arg_8E_0 = ClearActions_MenuItem;
			ToolStripItem arg_84_0 = SaveSGH_MenuItem;
            ToolStripItem export = exportSetlistAsChartsToolStripMenuItem;
            ToolStripItem arg_7B_0 = SaveTGH_MenuItem;
			Control arg_73_0 = SetlistStrip;
			Control arg_6B_0 = SetlistConf_TLPanel;
			GH3Folder_MenuItem.Enabled = bool_1;
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

		public void InitializeLanguageList()
		{
			RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GhtcpRegistry);
			string[] array = {
				"English",
				"French",
				"Italian",
				"Spanish",
				"German",
				"Korean"
			};
			for (int i = 0; i < array.Length; i++)
			{
				registryKey.SetValue(array[i], LanguageList[i]);
			}
			SysEnglish_MenuItem.Text = LanguageList[0];
			SysFrench_MenuItem.Text = LanguageList[1];
			SysItalian_MenuItem.Text = LanguageList[2];
			SysSpanish_MenuItem.Text = LanguageList[3];
			SysGerman_MenuItem.Text = LanguageList[4];
			SysKorean_MenuItem.Text = LanguageList[5];
		}

		private void OpenGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			LoadCurrentGameSettings(false);
		}

		private void RecoverGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			LoadCurrentGameSettings(true);
		}

		private void LoadCurrentGameSettings(bool bool_1)
		{
			LoadGameSettings loadGameSettings = new LoadGameSettings(LanguageList);
			if (loadGameSettings.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			method_15();
			LanguageList = loadGameSettings.method_2();
			InitializeLanguageList();
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(GameRegistry);
				DataFolder = (string)registryKey.GetValue("Path") + "\\DATA\\";
				if (!Directory.Exists(DataFolder))
				{
					throw new Exception();
				}
			}
			catch
			{
				string text = KeyGenerator.OpenOrSaveFile("Find Guitar Hero " + (IsAerosmith ? "Aerosmith" : "3"), IsAerosmith ? "Guitar Hero Aerosmith Executable|Guitar Hero Aerosmith.exe" : "Guitar Hero 3 Executable|GH3.exe", true);
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				try
				{
					DataFolder = new FileInfo(text).Directory.FullName;
					RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(GameRegistry);
					registryKey.SetValue("Path", DataFolder);
					DataFolder += "\\DATA\\";
				}
				catch
				{
					MessageBox.Show("Guitar Hero " + (IsAerosmith ? "Aerosmith" : "3") + " is not installed properly on this computer.", "Error!");
					return;
				}
			}
			string text2 = list_0[loadGameSettings.method_3()];
			int int_ = loadGameSettings.method_3();
			using (new Class217("QB Parse Operations"))
			{
				try
				{
					if (!method_16(int_) && DialogResult.Yes == MessageBox.Show("A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && !method_17(int_))
					{
						return;
					}
					zzPabNode class2 = new zzPabNode(string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pak.xen"), string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pab.xen"), false);
					GH3Songlist gH3Songlist = null;
					using (class319_0 = new zzPabNode(DataFolder + "PAK\\qb" + text2 + ".pak.xen", DataFolder + "PAK\\qb" + text2 + ".pab.xen", false))
					{
						if (method_19(int_).GameSettingsAreValid())
						{
							if (!bool_1)
							{
								goto IL_478;
							}
						}
						try
						{
							gH3Songlist = new GH3Songlist(class319_0.zzGetNode1("scripts\\guitar\\songlist.qb"), new GH3Songlist(class2.zzGetNode1("scripts\\guitar\\songlist.qb"), null));
							new zzSetListParser(class319_0, gH3Songlist, IsAerosmith).method_0();
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
						class319_0.Dispose();
						class319_0 = null;
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
						if (!method_16(int_))
						{
							return;
						}
						KeyGenerator.smethod_19(DataFolder + "PAK\\qb" + text2 + ".pab.xen", string.Concat(AppDirectory, BackupName, "lastedited\\qb", text2, ".pab.xen"), true);
						KeyGenerator.smethod_19(DataFolder + "PAK\\qb" + text2 + ".pak.xen", string.Concat(AppDirectory, BackupName, "lastedited\\qb", text2, ".pak.xen"), true);
						KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pab.xen"), DataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
						KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pak.xen"), DataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
						IL_478:;
					}
					class319_0 = new zzPabNode(DataFolder + "PAK\\qb" + text2 + ".pak.xen", DataFolder + "PAK\\qb" + text2 + ".pab.xen", false);
					method_20(int_);
					gh3Songlist = new GH3Songlist(class319_0.zzGetNode1("scripts\\guitar\\songlist.qb"), new GH3Songlist(class2.zzGetNode1("scripts\\guitar\\songlist.qb"), null));
					class2.Dispose();
					bool flag = false;
					if (gH3Songlist != null)
					{
						foreach (string current in gH3Songlist.Keys)
						{
							if (!gh3Songlist.method_3(current))
							{
								gh3Songlist.Add(gH3Songlist[current]);
								flag = true;
							}
						}
					}
					if (flag)
					{
						method_4(new Class247(class319_0, gh3Songlist));
					}
					new CustomMenuCreator(class319_0, IsAerosmith).method_0();
					new zzSetListParser(class319_0, gh3Songlist, IsAerosmith).method_0();
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
                                            if (!((gh3Songlist.CustomBitMask & num) == 0))
                                                goto SKIPIT;

												gh3Songlist.CustomBitMask |= (gH3Setlist.CustomBit = num);
												IL_666:
												gH3Setlist.prefix = "custom" + (i + 1);
												int num2;
												gh3Songlist.gh3SetlistList.Add(num2 = QbSongClass1.AddKeyToDictionary("gh3_custom" + (i + 1) + "_songs"), gH3Setlist);
												int value;
												gh3Songlist.dictionary_1.Add(value = QbSongClass1.AddKeyToDictionary("custom" + (i + 1) + "_progression"), new GHLink(num2));
												gh3Songlist.class214_0.Add("Custom Setlist " + (i + 1), value);
												method_4(new Class246(value, class319_0, gh3Songlist, true));
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
									gh3Songlist.gh3SetlistList[current2].method_0().AddRange(gH3Setlist.method_0());
									method_4(new zzSetListUpdater(current2, class319_0, gh3Songlist));
								}
							}
						}
						if (flag2)
						{
							method_4(new UpdateSetlistSwitcher(class319_0, gh3Songlist, IsAerosmith));
						}
					}
					new Class249(class319_0).method_0();
					new QbDatabaseInitialModifier(class319_0, IsAerosmith).method_0();
					method_0();
				}
				catch (Exception ex3)
				{
					if (class319_0 != null)
					{
						class319_0.Dispose();
						class319_0 = null;
					}
					Console.WriteLine(ex3.Message);
					if (DialogResult.Yes == MessageBox.Show("Game Settings files are corrupt. Do you wish to start from backup? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && method_16(int_))
					{
						KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pab.xen"), DataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
						KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\qb", text2, ".pak.xen"), DataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
					}
					return;
				}
			}
			foreach (string current3 in gh3Songlist.class214_0.Keys)
			{
				Setlist_DropBox.Items.Add(current3);
			}
			method_12(true);
			if (Setlist_DropBox.Items.Count != 0)
			{
				Setlist_DropBox.SelectedIndex = 0;
			}
			TabControl.SelectedIndex = 1;
		}

		private void ClearGameSettings_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Clear All Game Settings?", "Warning!", MessageBoxButtons.YesNo))
			{
				method_15();
			}
		}

		private void method_15()
		{
			method_12(false);
			if (gh3Songlist != null)
			{
				gh3Songlist.Clear();
				gh3Songlist.gh3SetlistList.Clear();
			}
			gh3Songlist = null;
			SongListBox.Items.Clear();
			Setlist_DropBox.Items.Clear();
			ActionRequests_ListBox.Items.Clear();
            //this.notifyIcon_0.Visible = false;
			method_23();
			if (!Directory.Exists(AppDirectory + "log"))
			{
				Directory.CreateDirectory(AppDirectory + "log");
			}
			Class216.smethod_0(AppDirectory + "log\\");
			Class216.smethod_2();
			if (class319_0 != null)
			{
				class319_0.Dispose();
			}
			class319_0 = null;
			GC.Collect();
		}

		private bool method_16(int int_3)
		{
			string text = string.Concat(AppDirectory, BackupName, "originals\\qb", list_0[int_3], ".pab.xen");
			int[] icollection_ = IsAerosmith ? int_2[int_3] : int_1[int_3];
			return File.Exists(text) && File.Exists(text.Replace(".pab.xen", ".pak.xen")) && KeyGenerator.smethod_53(KeyGenerator.smethod_21(KeyGenerator.HashStream(text)), icollection_);
		}

		private bool method_17(int int_3)
		{
			string text = DataFolder + "PAK\\qb" + list_0[int_3] + ".pab.xen";
			int[] icollection_ = IsAerosmith ? int_2[int_3] : int_1[int_3];
			while (!File.Exists(text) || !File.Exists(text.Replace(".pab.xen", ".pak.xen")) || !KeyGenerator.smethod_53(KeyGenerator.smethod_21(KeyGenerator.HashStream(text)), icollection_))
			{
				if ((text = KeyGenerator.OpenOrSaveFile("Find The Original V1.3 Game Settings.", "Original V1.3 Game Settings|qb" + list_0[int_3] + ".pab.xen", true)).Equals(""))
				{
					return false;
				}
			}
			KeyGenerator.smethod_19(text, string.Concat(AppDirectory, BackupName, "originals\\qb", list_0[int_3], ".pab.xen"), true);
			KeyGenerator.smethod_19(text.Replace(".pab.xen", ".pak.xen"), string.Concat(AppDirectory, BackupName, "originals\\qb", list_0[int_3], ".pak.xen"), true);
			return true;
		}

		private bool method_18()
		{
			bool result;
			try
			{
				GameSettingsChecker.SignHash(class319_0);
				class319_0.vmethod_1();
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

		private GameSettingsChecker method_19(int int_3)
		{
			if (File.Exists(class319_0.string_0) && File.Exists(class319_0.string_2) && KeyGenerator.smethod_53(KeyGenerator.smethod_21(KeyGenerator.HashStream(class319_0.string_2)), IsAerosmith ? int_2[int_3] : int_1[int_3]))
			{
				return new GameSettingsChecker(true);
			}
			GameSettingsChecker result;
			try
			{
				result = new GameSettingsChecker(class319_0);
			}
			catch
			{
				result = new GameSettingsChecker(false);
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
			string text = KeyGenerator.GetFileNameNoExt(class319_0.string_0);
			int int_ = new List<string>(list_0).IndexOf(text.Replace("qb", ""));
			if (method_16(int_))
			{
				method_15();
				KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\", text, ".pak.xen"), DataFolder + "PAK\\" + text + ".pak.xen", true);
				KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "originals\\", text, ".pab.xen"), DataFolder + "PAK\\" + text + ".pab.xen", true);
				return;
			}
			method_17(int_);
		}

		private void RestoreLast_MenuItem_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes != MessageBox.Show("Do you wish to continue with Last Game Settings Restoration? Current Game Settings will be overwritten!", "Last Game Settings Restoration", MessageBoxButtons.YesNo))
			{
				return;
			}
			string text = KeyGenerator.GetFileNameNoExt(class319_0.string_0);
			if (File.Exists(string.Concat(AppDirectory, BackupName, "lastedited\\", text, ".pak.xen")) && File.Exists(string.Concat(AppDirectory, BackupName, "lastedited\\", text, ".pab.xen")))
			{
				method_15();
				KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "lastedited\\", text, ".pak.xen"), DataFolder + "PAK\\" + text + ".pak.xen", true);
				KeyGenerator.smethod_19(string.Concat(AppDirectory, BackupName, "lastedited\\", text, ".pab.xen"), DataFolder + "PAK\\" + text + ".pab.xen", true);
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
			LoadGameSettings loadGameSettings = new LoadGameSettings(new[]
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
			string text = KeyGenerator.GetFileNameNoExt(class319_0.string_0);
			if (!method_16(num) && DialogResult.Yes == MessageBox.Show("A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)", "Loading Game Settings", MessageBoxButtons.YesNo) && !method_17(num))
			{
				return;
			}
			new List<string>(list_0).IndexOf(text.Replace("qb", ""));
			method_15();
			using (zzPabNode @class = new zzPabNode(string.Concat(AppDirectory, BackupName, "originals\\qb", list_0[num], ".pak.xen"), string.Concat(AppDirectory, BackupName, "originals\\qb", list_0[num], ".pab.xen"), false))
			{
				GameSettingsChecker.SignHash(@class);
				@class.method_20(DataFolder + "PAK\\" + text + ".pak.xen", DataFolder + "PAK\\" + text + ".pab.xen");
			}
			GC.Collect();
		}

		private void method_21(object sender, EventArgs2 e)
		{
			TierApply_Btn.Enabled = true;
		}

        private void TierSongs_ListBox_DragDrop(object sender, DragEventArgs e) {
            TierApply_Btn.Enabled = true;
        }

        private void TierSongs_ListBox_MouseDown(object sender, MouseEventArgs e)
		{
            int num = TierSongs_ListBox.IndexFromPoint(e.Location);
			if (num >= 0 && num < TierSongs_ListBox.Items.Count && e.Clicks == 2 && e.Button == MouseButtons.Right)
			{
				TierSongs_ListBox.Items.RemoveAt(num);
				TierApply_Btn.Enabled = true;
			}
		}

		private void TierSongs_ListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && SongListBox.SelectedItems.Count != 0 && DialogResult.Yes == MessageBox.Show("The selected songs will be deleted from the Tier!\nAre you sure you wish to continue?", "Warning!", MessageBoxButtons.YesNo))
			{
				TierSongs_ListBox.method_3();
				TierApply_Btn.Enabled = true;
			}
		}

		private void method_22(GH3Tier gh3Tier_0)
		{
			Tier_TLPanel.Enabled = true;
			TierTitle_TxtBox.Text = gh3Tier_0.title;
			TierUnlocked_NumBox.Value = gh3Tier_0.defaultunlocked;
			TierCompMovie_TxtBox.Text = gh3Tier_0.completion_movie;
			TierIcon_DropBox.SelectedItem = gh3Tier_0.setlist_icon;
			TierStage_DropBox.SelectedItem = gh3Tier_0.level;
			TierEncorep1_CheckBox.Checked = gh3Tier_0.encorep1;
			TierEncorep2_CheckBox.Checked = (gh3Tier_0.encorep2 || gh3Tier_0.aerosmith_encore_p1);
			TierBoss_CheckBox.Checked = gh3Tier_0.boss;
			NoCash_CheckBox.Checked = gh3Tier_0.nocash;
			UnlockAll_CheckBox.Checked = gh3Tier_0.unlockall;
			TierSongs_ListBox.Items.Clear();
			TierSongs_ListBox.Items.AddRange(gh3Tier_0.songs.ToArray());
			TierApply_Btn.Enabled = false;
		}

		private void method_23()
		{
			TierBox.SelectedIndex = -1;
			Tier_TLPanel.Enabled = false;
			TierTitle_TxtBox.Text = "";
			TierUnlocked_NumBox.Value = 0m;
			TierCompMovie_TxtBox.Text = "";
			TierIcon_DropBox.SelectedIndex = -1;
			TierStage_DropBox.SelectedIndex = -1;
			TierEncorep1_CheckBox.Checked = false;
			TierEncorep2_CheckBox.Checked = false;
			TierBoss_CheckBox.Checked = false;
			NoCash_CheckBox.Checked = false;
			UnlockAll_CheckBox.Checked = false;
			TierSongs_ListBox.Items.Clear();
			TierApply_Btn.Enabled = false;
		}

		private void TierBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TierBox.SelectedIndex >= 0)
			{
				method_22((GH3Tier)TierBox.Items[TierBox.SelectedIndex]);
			}
		}

		private void TierEncorep1_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TierApply_Btn.Enabled = true;
		}

		private void TierUnlockedSet_Btn_Click(object sender, EventArgs e)
		{
			TierUnlocked_NumBox.Value = TierSongs_ListBox.Items.Count;
		}

		private void TierApply_Btn_Click(object sender, EventArgs e)
		{
			GH3Tier gH3Tier = (GH3Tier)TierBox.Items[TierBox.SelectedIndex];
			gH3Tier.title = TierTitle_TxtBox.Text;
			gH3Tier.defaultunlocked = Convert.ToInt32(TierUnlocked_NumBox.Value);
			gH3Tier.completion_movie = TierCompMovie_TxtBox.Text;
			gH3Tier.setlist_icon = (string)TierIcon_DropBox.SelectedItem;
			gH3Tier.level = (string)TierStage_DropBox.SelectedItem;
			gH3Tier.boss = TierBoss_CheckBox.Checked;
			gH3Tier.nocash = NoCash_CheckBox.Checked;
			gH3Tier.unlockall = UnlockAll_CheckBox.Checked;
			gH3Tier.encorep1 = TierEncorep1_CheckBox.Checked;
			if (IsAerosmith)
			{
				gH3Tier.aerosmith_encore_p1 = TierEncorep2_CheckBox.Checked;
			}
			else
			{
				gH3Tier.encorep2 = TierEncorep2_CheckBox.Checked;
			}
			gH3Tier.songs.Clear();
			foreach (GH3Song item in TierSongs_ListBox.Items)
			{
				gH3Tier.songs.Add(item);
			}
			TierApply_Btn.Enabled = false;
			method_4(new zzSetListUpdater(SelectedSetlist, class319_0, gh3Songlist));
			if (HideUsed_MenuItem.Checked)
			{
				gh3Songlist.HideUsed = true;
				method_0();
			}
		}

        private void forceRB3MidConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
