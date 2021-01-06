using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GHNamespace2;
using GHNamespace6;
using GHNamespace7;
using GHNamespace9;
using GHNamespaceA;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceN;
using GuitarHero;
using GuitarHero.Setlist;
using GuitarHero.Songlist;
using GuitarHero.Tier;
using Microsoft.Win32;
using MidiConverter;

namespace GHNamespace8
{
    public class MainMenu : Form
    {
        private readonly string _appDirectory;

        private readonly string _gameRegistry;

        private readonly string _ghtcpRegistry;

        private readonly string _backupName;

        private string _dataFolder;

        private string _priority;

        private string[] _languageList;

        private Gh3Songlist _gh3Songlist;

        private int _selectedSetlist;

        private readonly bool _isAerosmith;

        public ZzPabNode Class3190;

        private ActionsWindow _actionsWindow0;

        private IContainer icontainer_0;

        private ContextMenuStrip _rightClickMenu;

        private MenuStrip _topMenuStrip;

        private ToolStripMenuItem _fileMenuItem;

        private ToolStripMenuItem _openGameSettingsMenuItem;

        private ToolStripMenuItem _executeActionsMenuItem;

        private ToolStripMenuItem _exitMenuItem;

        private ToolStripMenuItem _addMenuItem;

        private ToolStripMenuItem _manageGameMenuItem;

        private ListBox _actionRequestsListBox;

        private Label _label1;

        private ToolStripSeparator _toolStripSeparator1;

        private ToolStripMenuItem _newSongMenuItem;

        private ToolStripMenuItem _tierMenuItem;

        private ToolStripMenuItem _manageTiersMenuItem;

        private Label _label3;

        private ToolStripMenuItem _helpMenuItem;

        private ToolStripMenuItem _guideMenuItem;

        private ToolStripSeparator _toolStripSeparator3;

        private ToolStripMenuItem _aboutMenuItem;

        private ToolStripMenuItem _scoreHeroMenuItem;

        private TableLayoutPanel _sidePanel;

        private ToolStripMenuItem _newTierMenuItem;

        private ToolStripMenuItem _legacyImporterMenuItem;

        private ToolStripMenuItem _tghImportMenuItem;

        private ToolStripMenuItem _sghSwitchMenuItem;

        private ToolStripSeparator _toolStripSeparator4;

        private ToolStripMenuItem _tghSwitchMenuItem;

        private ToolStripMenuItem _texExplorerMenuItem;

        private ToolStripSeparator _toolStripSeparator6;

        private ToolStripMenuItem _manageSongsMenuItem;

        private ToolStripMenuItem _songPropsMenuItem;

        private ToolStripSeparator _toolStripSeparator7;

        private ToolStripMenuItem _saveTghMenuItem;

        private ToolStripMenuItem _saveSghMenuItem;

        private ToolStripMenuItem _massImporterMenuItem;

        private ToolStripMenuItem _clearActionsMenuItem;

        private ToolStripMenuItem _disclaimerMenuItem;

        private ToolStripMenuItem _sysExitMenuItem;

        private NotifyIcon _notifyIcon0;

        private FontDialog _fontDialog0;

        private ToolStripMenuItem _sysEnglishMenuItem;

        private ToolStripMenuItem _sysFrenchMenuItem;

        private ToolStripMenuItem _sysItalianMenuItem;

        private ToolStripMenuItem _sysSpanishMenuItem;

        private ToolStripMenuItem _sysGermanMenuItem;

        private ContextMenuStrip _leftClickMenu;

        private ToolStripMenuItem _sysHighMenuItem;

        private ToolStripMenuItem _sysAboveMenuItem;

        private ToolStripMenuItem _sysNormalMenuItem;

        private ToolStripMenuItem _sysBelowMenuItem;

        private ToolStripSeparator _toolStripSeparator8;

        private ToolStripContainer _mainContainer;

        private StatusStrip _statusStrip;

        private ToolStripStatusLabel _toolStripStatusLbl;

        private ToolStripMenuItem _rebuildSongMenuItem;

        private ToolStripSeparator _removeSongToolStripMenuItem;

        private ToolStripMenuItem _hideUsedMenuItem;

        private ToolStripMenuItem _byTitleMenuItem;

        private ToolStripMenuItem _clearGameSettingsMenuItem;

        private ToolStripMenuItem _deleteSongMenuItem;

        private ToolStripMenuItem _saveChartMenuItem;

        private ToolStripMenuItem _hideUnEditMenuItem;

        private ToolStripMenuItem _gameSettingsSwitchMenuItem;

        private ToolStripMenuItem _restoreLastMenuItem;

        private ToolStripSeparator _toolStripSeparator11;

        private ToolStripMenuItem _restoreOriginalMenuItem;

        private ToolStripMenuItem _saveFileControlMenuItem;

        private ToolStripMenuItem _sysKoreanMenuItem;

        private ToolStripMenuItem _recoverGameSettingsMenuItem;

        private ToolStripMenuItem _gh3FolderMenuItem;

        private ZzListBox238 _songListBox;

        private ToolStripMenuItem _silentGuitarMenuItem;

        private ToolStripMenuItem _recoverSonglistMenuItem;

        private ToolStripMenuItem _minToTrayMenuItem;

        private ToolStripMenuItem _fxSpeedBoostMenuItem;

        private ToolStripMenuItem _forceMp3ConversionMenuItem;

        private ToolStripMenuItem _exportSetlistAsChartsToolStripMenuItem;

        private ToolStripMenuItem _forceRb3MidConversionToolStripMenuItem;


        private readonly List<string> _list0 = new List<string>(new[]
        {
            "",
            "_f",
            "_i",
            "_s",
            "_g",
            "_k"
        });

        private readonly int[][] _int1 =
        {
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
        private ToolStripMenuItem _exportSongListToolStripMenuItem;
        private ToolStripMenuItem _exportSongListToolStripMenuItem1;
        private TabControl _tabControl;
        private TabPage _setlistTab;
        private ToolStripContainer _setlistConfigContainer;
        private TableLayoutPanel _setlistConfTLPanel;
        private TableLayoutPanel _setlistTLPanel;
        private TextBox _textBox3;
        private Label _label5;
        private Label _label4;
        private ComboBox _tierBox;
        private TextBox _setlistInitMovieTxtBox;
        private TextBox _setlistPrefixTxtBox;
        private Label _label2;
        private Label _label13;
        private TextBox _setlistTitleTxtBox;
        private TableLayoutPanel _tierTLPanel;
        private Panel _tierPropsPanel;
        private Button _tierUnlockedSetBtn;
        private CheckBox _unlockAllCheckBox;
        private CheckBox _noCashCheckBox;
        private Button _tierApplyBtn;
        private Label _label12;
        private Button _setlistApplyBtn;
        private TextBox _tierCompMovieTxtBox;
        private NumericUpDown _tierUnlockedNumBox;
        private TextBox _tierTitleTxtBox;
        private ComboBox _tierIconDropBox;
        private ComboBox _tierStageDropBox;
        private CheckBox _tierBossCheckBox;
        private CheckBox _tierEncorep2CheckBox;
        private CheckBox _tierEncorep1CheckBox;
        private Label _label10;
        private Label _label9;
        private Label _label8;
        private Label _label6;
        private Label _label7;
        private TableLayoutPanel _tierSongsPanel;
        private ZzListBox238 _tierSongsListBox;
        private Label _label11;
        private ToolStrip _setlistStrip;
        private ToolStripLabel _setlistLbl;
        private ToolStripComboBox _setlistDropBox;
        private ToolStripButton _createSetlistBtn;
        private ToolStripButton _deleteSetlistBtn;
        private TabPage _songEditorTab;
        private ToolStripContainer _songEditorContainer;
        private ToolStrip _songEditorBottomToolStrip;
        private ToolStripSplitButton _toggleElementsEditorSplitBtn;
        private ToolStripMenuItem _starViewEditorBtn;
        private ToolStripMenuItem _hopoViewEditorBtn;
        private ToolStripMenuItem _audioViewEditorBtn;
        private ToolStripSeparator _toolStripSeparator10;
        private ToolStripLabel _toolStripLabel1;
        private ToolStripTextBox _beatSizeEditorTxtBox;
        private GhtcpToolStripControlHost _hyperSpeedEditorBar;
        private GhtcpToolStripControlHost _fretAngleEditorBar;
        private ToolStripSeparator _toolStripSeparator12;
        private ToolStripLabel _toolStripLabel2;
        private ToolStripTextBox _offsetEditorTxtBox;
        private SongEditor _songEditorControl;
        private ToolStrip _songEditorTopToolStrip;
        private ToolStripButton _gameModeEditorBtn;
        private ToolStripSeparator _toolStripSeparator5;
        private ToolStripButton _loadChartEditorBtn;
        private ToolStripComboBox _selectedTrackEditorBox;
        private ToolStripLabel _songNameEditorLbl;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripButton _loadAudioEditorBtn;
        private ToolStripButton _playPauseEditorBtn;
        private ToolStripButton _stopEditorBtn;
        private ToolStripLabel _playTimeEditorLbl;

        private readonly int[][] _int2 =
        {
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
            var num = _songListBox.IndexFromPoint(e.X, e.Y);
            if (num >= 0 && num < _songListBox.Items.Count)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    SongProperties songProperties;
                    if ((songProperties = new SongProperties((Gh3Song) _songListBox.Items[num])).ShowDialog() ==
                        DialogResult.OK)
                    {
                        songProperties.GetSongWithChanges();
                        method_4(new Class247(Class3190, _gh3Songlist));
                    }
                }
                else if (e.Clicks == 2 && e.Button == MouseButtons.Right)
                {
                    var gH3Song = (Gh3Song) _songListBox.Items[num];
                    if (gH3Song.Editable && DialogResult.Yes ==
                        MessageBox.Show(
                            gH3Song.Name.ToUpper() +
                            " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!",
                            MessageBoxButtons.YesNo))
                    {
                        _songListBox.Items.Remove(gH3Song);
                        foreach (var current in _gh3Songlist.method_1(gH3Song))
                        {
                            method_4(new ZzSetListUpdater(current, Class3190, _gh3Songlist));
                        }
                        method_4(new Class247(Class3190, _gh3Songlist));
                    }
                }
            }
        }

        private void HideUnEdit_MenuItem_Click(object sender, EventArgs e)
        {
            var arg_1D0 = _gh3Songlist;
            var expr_0C = _hideUnEditMenuItem;
            arg_1D0.HideUnEditable = (expr_0C.Checked = !expr_0C.Checked);
            RefreshSongListBox();
        }

        private void HideUsed_MenuItem_Click(object sender, EventArgs e)
        {
            var arg_1D0 = _gh3Songlist;
            var expr_0C = _hideUsedMenuItem;
            arg_1D0.HideUsed = (expr_0C.Checked = !expr_0C.Checked);
            RefreshSongListBox();
        }

        private void ByTitle_MenuItem_Click(object sender, EventArgs e)
        {
            var expr06 = _byTitleMenuItem;
            Gh3Song.Bool0 = (expr06.Checked = !expr06.Checked);
            RefreshSongListBox();
        }

        private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_songListBox.SelectedItems.Count != 0)
            {
                var enabled = false;
                foreach (Gh3Song song in _songListBox.SelectedItems)
                {
                    if (song.Editable)
                    {
                        enabled = true;
                    }
                }
                _saveChartMenuItem.Enabled = (_rebuildSongMenuItem.Enabled = true);
                _deleteSongMenuItem.Enabled = enabled;
            }
        }

        public static DialogResult MsgBoxEditDefaultSongs()
        {
            return MessageBox.Show(
                "Do you really wish to edit a default song? Editing default songs is dangerous and should only be done if you understand the consequences of doing so.",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void SongProps_MenuItem_Click(object sender, EventArgs e)
        {
            SongProperties songProperties;
            if (!((Gh3Song) _songListBox.Items[_songListBox.SelectedIndex]).IsEditable())
            {
                if (MsgBoxEditDefaultSongs() != DialogResult.Yes)
                    return;
            }
            if (_songListBox.SelectedIndex >= 0 && (songProperties =
                    new SongProperties((Gh3Song) _songListBox.Items[_songListBox.SelectedIndex])).ShowDialog() ==
                DialogResult.OK)
            {
                songProperties.GetSongWithChanges();
                method_4(new Class247(Class3190, _gh3Songlist));
            }
        }

        private void RebuildSong_MenuItem_Click(object sender, EventArgs e)
        {
            var song = (Gh3Song) _songListBox.Items[_songListBox.SelectedIndex];
            SongData songData;
            if (!song.IsEditable())
            {
                if (MsgBoxEditDefaultSongs() != DialogResult.Yes)
                    return;
            }
            if (_songListBox.SelectedIndex >= 0 && (songData = new SongData(song.Name, false, false)).ShowDialog() ==
                DialogResult.OK)
            {
                if (songData.Bool1)
                {
                    var @class = songData.method_1(Class3190, _dataFolder);
                    method_4(@class);
                    if (DialogResult.Yes == MessageBox.Show(
                            "Do you wish to get the song properties from the game track? (Current properties will be overwritten | Mid files have no properties!)",
                            "Tier Exporting", MessageBoxButtons.YesNo))
                    {
                        var noRhythmTrack = song.NoRhythmTrack;
                        var useCoopNotetracks = song.UseCoopNotetracks;
                        song.vmethod_0(@class.Class3620.Gh3Song0);
                        song.NoRhythmTrack = noRhythmTrack;
                        song.UseCoopNotetracks = useCoopNotetracks;
                        method_4(new Class247(Class3190, _gh3Songlist));
                    }
                }
                if (songData.Bool0)
                {
                    var class2 = songData.method_0(_dataFolder);
                    method_4(class2);
                    song.NoRhythmTrack = !class2.Bool0;
                    song.UseCoopNotetracks = class2.Bool1;
                    method_4(new Class247(Class3190, _gh3Songlist));
                }
            }
        }

        private void SongListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Delete && _songListBox.SelectedItems.Count != 0 && DialogResult.Yes ==
                MessageBox.Show(
                    "The selected songs will be deleted from the Songlist!\nAre you sure you wish to continue?",
                    "Warning!", MessageBoxButtons.YesNo))
            {
                var array = _songListBox.imethod_3();
                for (var i = 0; i < array.Length; i++)
                {
                    var gh3Song = (Gh3Song) array[i];
                    if (gh3Song.Editable)
                    {
                        _songListBox.Items.Remove(gh3Song);
                        foreach (var current in _gh3Songlist.method_1(gh3Song))
                        {
                            method_4(new ZzSetListUpdater(current, Class3190, _gh3Songlist));
                        }
                        method_4(new Class247(Class3190, _gh3Songlist));
                    }
                }
            }
        }

        private void DeleteSong_MenuItem_Click(object sender, EventArgs e)
        {
            var array = _songListBox.imethod_3();
            for (var i = 0; i < array.Length; i++)
            {
                var gH3Song = (Gh3Song) array[i];
                if (gH3Song.Editable && DialogResult.Yes ==
                    MessageBox.Show(
                        gH3Song.Name.ToUpper() +
                        " will be deleted from the Songlist!\nAre you sure you wish to continue?", "Warning!",
                        MessageBoxButtons.YesNo))
                {
                    _songListBox.Items.Remove(gH3Song);
                    foreach (var current in _gh3Songlist.method_1(gH3Song))
                    {
                        method_4(new ZzSetListUpdater(current, Class3190, _gh3Songlist));
                    }
                    method_4(new Class247(Class3190, _gh3Songlist));
                }
            }
        }

        private void NewSong_MenuItem_Click(object sender, EventArgs e)
        {
            var songData = new SongData(_gh3Songlist, _forceRb3MidConversionToolStripMenuItem.Checked);
            if (songData.ShowDialog() == DialogResult.OK)
            {
                var gH3Song = _isAerosmith ? new GhaSong() : new Gh3Song();
                if (songData.Bool1)
                {
                    var @class = songData.method_1(Class3190, _dataFolder);
                    method_4(@class);
                    gH3Song.vmethod_0(@class.Class3620.Gh3Song0);
                }
                if (songData.Bool0)
                {
                    var class2 = songData.method_0(_dataFolder);
                    method_4(class2);
                    gH3Song.Name = class2.String1;
                    gH3Song.NoRhythmTrack = !class2.Bool0;
                    gH3Song.UseCoopNotetracks = class2.Bool1;
                    gH3Song.Version = 3;
                    gH3Song.Leaderboard = true;
                    gH3Song.Editable = true;
                }
                var songProperties = new SongProperties(gH3Song);
                if (songProperties.ShowDialog() == DialogResult.OK)
                {
                    songProperties.GetSongWithChanges();
                }
                _gh3Songlist.Add(gH3Song.Name, gH3Song);
                method_4(new Class247(Class3190, _gh3Songlist));
                RefreshSongListBox();
            }
        }

        private void RecoverSonglist_MenuItem_Click(object sender, EventArgs e)
        {
            var flag = false;
            var files = Directory.GetFiles(_dataFolder + "music\\", "*.dat.xen", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; i++)
            {
                var text = files[i];
                var text2 = KeyGenerator.GetFileNameNoExt(text);
                if (File.Exists(_dataFolder + "music\\" + text2 + ".fsb.xen") &&
                    File.Exists(_dataFolder + "songs\\" + text2 + "_song.pak.xen") && !_gh3Songlist.method_3(text2) &&
                    !QbSongClass1.smethod_4(text2) &&
                    !Gh3Songlist.IgnoreSongs.Contains(QbSongClass1.AddKeyToDictionary(text2)))
                {
                    try
                    {
                        var gH3Song = _isAerosmith ? new GhaSong(text2) : new Gh3Song(text2);
                        var list = new List<string>(new ZzQbSongObject(text).String1);
                        gH3Song.NoRhythmTrack = !list.Contains(text2 + "_rhythm");
                        gH3Song.UseCoopNotetracks = list.Contains(text2 + "_coop_song");
                        _gh3Songlist.Add(text2, gH3Song);
                        flag = true;
                    }
                    catch
                    {
                    }
                }
            }
            if (flag)
            {
                method_4(new Class247(Class3190, _gh3Songlist));
                RefreshSongListBox();
            }
        }

        private void RefreshSongListBox()
        {
            _songListBox.Items.Clear();
            _songListBox.Items.AddRange(_gh3Songlist.GetSongs());
        }

        private void LoadChart_EditorBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the game track file.",
                "Any Supported Game Track Formats|*.qbc;*.dbc;*_song.pak.xen;*.mid;*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc|GH3 Game Track file|*_song.pak.xen|GH standard Midi file|*.mid|dB standard or GH3CP Chart file|*.chart",
                true)).Equals(""))
            {
                QbcParser qbcParser;
                try
                {
                    if (fileName.EndsWith("_song.pak.xen"))
                    {
                        var str = KeyGenerator.GetFileName(fileName).Replace("_song.pak.xen", "");
                        using (var @class = new ZzPakNode2(fileName, false))
                        {
                            if (!@class.zzQbFileExists("songs\\" + str + ".mid.qb"))
                            {
                                throw new Exception("MID.QB song file not found.");
                            }
                            qbcParser = new QbcParser(str, @class.ZzGetNode1("songs\\" + str + ".mid.qb"));
                            goto IL_DA;
                        }
                    }
                    if (fileName.EndsWith(".qbc"))
                    {
                        qbcParser = new QbcParser(fileName);
                    }
                    else if (fileName.EndsWith(".mid"))
                    {
                        qbcParser = Midi2Chart.LoadMidiSong(fileName, _forceRb3MidConversionToolStripMenuItem.Checked);
                    }
                    else
                    {
                        qbcParser = new ChartParser(fileName).ConvertToQbc();
                    }
                    IL_DA:
                    ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading game track file!\n" + ex.Message);
                    return;
                }
                _songNameEditorLbl.Text = qbcParser.Gh3Song0.Title;
                _selectedTrackEditorBox.Items.Clear();
                foreach (var current in qbcParser.NoteList.Keys)
                {
                    _selectedTrackEditorBox.Items.Add(current);
                }
                _songEditorControl.LoadChart(qbcParser);
                _selectedTrackEditorBox.SelectedIndex = 0;
                _offsetEditorTxtBox.Text = string.Concat(qbcParser.Gh3Song0.GemOffset);
            }
        }

        private void BeatSize_EditorTxtBox_TextChanged(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = Convert.ToInt32(_beatSizeEditorTxtBox.Text);
            }
            catch
            {
                return;
            }
            if (num != 0)
            {
                _songEditorControl.SetBeatSize(num);
            }
        }

        private void Offset_EditorTxtBox_TextChanged(object sender, EventArgs e)
        {
            int int_;
            try
            {
                int_ = Convert.ToInt32(_offsetEditorTxtBox.Text);
            }
            catch
            {
                return;
            }
            _songEditorControl.SetOffset(int_);
        }

        private void PlayPause_EditorBtn_Click(object sender, EventArgs e)
        {
            if (_songEditorControl.AudioLoaded())
            {
                if (_songEditorControl.GetAudioStatus() != AudioStatus.ShouldStartAudio)
                {
                    _songEditorControl.DifferentStartPlaying();
                    return;
                }
                _songEditorControl.StartPlaying();
            }
        }

        private void Stop_EditorBtn_Click(object sender, EventArgs e)
        {
            if (_songEditorControl.AudioLoaded())
            {
                _songEditorControl.StopAudio();
            }
        }

        private void LoadAudio_EditorBtn_Click(object sender, EventArgs e)
        {
            string fileName;
            if (!(fileName = KeyGenerator.OpenOrSaveFile("Select the Guitar Audio track file.",
                "Any Supported Audio Formats|*.mp3;*.wav;*.ogg;*.flac|MPEG Layer-3 Audio File|*.mp3|Waveform Audio File|*.wav|Ogg Vorbis Audio File|*.ogg|FLAC Audio File|*.flac",
                true)).Equals(""))
            {
                _songEditorControl.LoadAudio(fileName);
            }
        }

        private void SelectedTrack_EditorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _songEditorControl.Difficulty = (string) _selectedTrackEditorBox.SelectedItem;
        }

        private void method_1(object sender, EventArgs e)
        {
            _playTimeEditorLbl.Text = string.Concat((int) sender / 1000f);
        }

        private void GameMode_EditorBtn_Click(object sender, EventArgs e)
        {
            _songEditorControl.SetGamemodeView(_gameModeEditorBtn.Checked);
        }

        private void ToggleElements_EditorSplitBtn_ButtonClick(object sender, EventArgs e)
        {
            var arg_1D0 = _songEditorControl;
            var expr_0C = _starViewEditorBtn;
            arg_1D0.LoadStarpowerTextures = (expr_0C.Checked = !expr_0C.Checked);
            var arg_3F0 = _songEditorControl;
            var expr_2E = _hopoViewEditorBtn;
            arg_3F0.LoadHopoTextures = (expr_2E.Checked = !expr_2E.Checked);
            var arg610 = _songEditorControl;
            var expr50 = _audioViewEditorBtn;
            arg610.ShowAudioOnFretboard = (expr50.Checked = !expr50.Checked);
        }

        private void StarView_EditorBtn_Click(object sender, EventArgs e)
        {
            _songEditorControl.LoadStarpowerTextures = _starViewEditorBtn.Checked;
        }

        private void HopoView_EditorBtn_Click(object sender, EventArgs e)
        {
            _songEditorControl.LoadHopoTextures = _hopoViewEditorBtn.Checked;
        }

        private void AudioView_EditorBtn_Click(object sender, EventArgs e)
        {
            _songEditorControl.ShowAudioOnFretboard = _audioViewEditorBtn.Checked;
        }

        private void method_2(object sender, EventArgs e)
        {
            _songEditorControl.SetFretboardAngle(_fretAngleEditorBar.method_4());
        }

        private void method_3(object sender, EventArgs e)
        {
            if (_hyperSpeedEditorBar.method_4() == 0)
            {
                _songEditorControl.SetHyperspeed(1.0);
                return;
            }
            if (_hyperSpeedEditorBar.method_4() < 0)
            {
                _songEditorControl.SetHyperspeed(1.0 - _hyperSpeedEditorBar.method_4() /
                                                 (double) (_hyperSpeedEditorBar.method_1() * 2));
                return;
            }
            if (_hyperSpeedEditorBar.method_4() > 0)
            {
                _songEditorControl.SetHyperspeed(1.0 + _hyperSpeedEditorBar.method_4() *
                                                 _hyperSpeedEditorBar.method_4() / 10.0);
            }
        }

        private void SaveChart_MenuItem_Click(object sender, EventArgs e)
        {
            if (_songListBox.SelectedIndex >= 0)
            {
                var gh3Song = (Gh3Song) _songListBox.SelectedItem;
                var fileLocation = KeyGenerator.OpenOrSaveFile("Select where to save the song chart.",
                    "GH3 Chart File|*.chart|GH3CP QB Based Chart File|*.qbc|GH3CP dB Based Chart File|*.dbc", false,
                    _songListBox.Text);
                if (!fileLocation.Equals("") && File.Exists(_dataFolder + "songs\\" + gh3Song.Name + "_song.pak.xen"))
                {
                    using (var @class = new ZzPakNode2(_dataFolder + "songs\\" + gh3Song.Name + "_song.pak.xen", false))
                    {
                        if (fileLocation.EndsWith(".qbc"))
                        {
                            new QbcParser(gh3Song.Name, @class.ZzGetNode1("songs\\" + gh3Song.Name + ".mid.qb"))
                                .QbcCreator(fileLocation, gh3Song);
                        }
                        else if (fileLocation.EndsWith(".chart"))
                        {
                            new QbcParser(gh3Song.Name, @class.ZzGetNode1("songs\\" + gh3Song.Name + ".mid.qb"))
                                .method_1()
                                .ChartCreator(fileLocation, gh3Song);
                        }
                        else
                        {
                            new QbcParser(gh3Song.Name, @class.ZzGetNode1("songs\\" + gh3Song.Name + ".mid.qb"))
                                .method_1()
                                .DbcCreator(fileLocation, gh3Song);
                        }
                    }
                }
            }
        }

        private void SaveTGH_MenuItem_Click(object sender, EventArgs e)
        {
            if (_tierBox.SelectedIndex >= 0)
            {
                var text = KeyGenerator.OpenOrSaveFile("Select where to save the tier.", "GH3CP Tier File|*.tgh", false,
                    _tierTitleTxtBox.Text);
                if (text.Equals(""))
                {
                    return;
                }
                TghManager @class;
                if (DialogResult.Yes == MessageBox.Show(
                        "Do you wish to include all used song data (Music & Game Tracks)?", "Tier Exporting",
                        MessageBoxButtons.YesNo))
                {
                    @class = new TghManager(_gh3Songlist, (Gh3Tier) _tierBox.SelectedItem, text, _dataFolder);
                }
                else
                {
                    @class = new TghManager(_gh3Songlist, (Gh3Tier) _tierBox.SelectedItem, text);
                }
                @class.method_1();
            }
        }

        private void exportSetlistAsChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void TGHSwitch_MenuItem_Click(object sender, EventArgs e)
        {
            if (_tierBox.SelectedIndex >= 0)
            {
                var text = KeyGenerator.OpenFile("Select the tier to switch too.", "GH3CP Tier File|*.tgh");
                if (text.Equals(""))
                {
                    return;
                }
                var gH3Tier = new Gh3Tier();
                try
                {
                    TghManager tghManager;
                    if (DialogResult.Yes == MessageBox.Show(
                            "Do you wish to import all contained song data (Music & Game Tracks)? Data and properties will be overwritten!",
                            "Tier Switching", MessageBoxButtons.YesNo))
                    {
                        tghManager = new TghManager(_gh3Songlist, gH3Tier, text, _dataFolder);
                    }
                    else
                    {
                        tghManager = new TghManager(_gh3Songlist, gH3Tier, text);
                    }
                    tghManager.method_0();
                    _tierBox.Items[_tierBox.SelectedIndex] = gH3Tier;
                    _tierBox.SelectedIndex = _tierBox.SelectedIndex;
                    _setlistApplyBtn.Enabled = true;
                    method_4(new Class247(Class3190, _gh3Songlist));
                    RefreshSongListBox();
                }
                catch
                {
                    MessageBox.Show("File not compatible! Tier Switch failed.", "Tier Switching");
                }
            }
        }

        private void TGHImport_MenuItem_Click(object sender, EventArgs e)
        {
            if (_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
            {
                var text = KeyGenerator.OpenFile("Select the tier to import.", "GH3CP Tier File|*.tgh");
                if (text.Equals(""))
                {
                    return;
                }
                var gH3Tier = new Gh3Tier();
                try
                {
                    TghManager @class;
                    if (DialogResult.Yes == MessageBox.Show(
                            "Do you wish to import all contained song data (Music & Game Tracks) and properties? Data will be overwritten!",
                            "Tier Importing", MessageBoxButtons.YesNo))
                    {
                        @class = new TghManager(_gh3Songlist, gH3Tier, text, _dataFolder);
                    }
                    else
                    {
                        @class = new TghManager(_gh3Songlist, gH3Tier, text);
                    }
                    @class.method_0();
                    _tierBox.Items.Add(gH3Tier);
                    _tierBox.SelectedIndex = _tierBox.Items.Count - 1;
                    _setlistApplyBtn.Enabled = true;
                    method_4(new Class247(Class3190, _gh3Songlist));
                    RefreshSongListBox();
                }
                catch
                {
                    MessageBox.Show("File not compatible! Tier Import failed.", "Tier Importing");
                }
            }
        }

        private void SaveSGH_MenuItem_Click(object sender, EventArgs e)
        {
            if (_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
            {
                var saveLocation = KeyGenerator.OpenOrSaveFile("Select where to save the setlist.",
                    "GH3CP Setlist File|*.sgh", false, _setlistTitleTxtBox.Text);
                if (saveLocation.Equals(""))
                {
                    return;
                }
                SghManager sghManager;
                if (DialogResult.Yes == MessageBox.Show(
                        "Do you wish to include all used song data (Music & Game Tracks)?", "Setlist Exporting",
                        MessageBoxButtons.YesNo))
                {
                    sghManager = new SghManager(_gh3Songlist, _gh3Songlist.Gh3SetlistList[_selectedSetlist],
                        saveLocation, _dataFolder);
                }
                else
                {
                    sghManager = new SghManager(_gh3Songlist, _gh3Songlist.Gh3SetlistList[_selectedSetlist],
                        saveLocation);
                }
                sghManager.method_1();
            }
        }

        private void exportSetlistAsChartsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.Description = "Please select where you would like to save the charts.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var saveLocation = folderBrowserDialog.SelectedPath;
                if (saveLocation.Equals(""))
                {
                    return;
                }
                foreach (var tier in _gh3Songlist.Gh3SetlistList[_selectedSetlist].Tiers)
                {
                    foreach (var gh3Song in tier.Songs)
                    {
                        var fileLocation = saveLocation + "\\" + gh3Song.Name + ".chart";
                        using (var @class = new ZzPakNode2(_dataFolder + "songs\\" + gh3Song.Name + "_song.pak.xen",
                            false))
                        {
                            new QbcParser(gh3Song.Name, @class.ZzGetNode1("songs\\" + gh3Song.Name + ".mid.qb"))
                                .method_1()
                                .ChartCreator(fileLocation, gh3Song);
                        }
                    }
                }
            }
        }

        private void SGHSwitch_MenuItem_Click(object sender, EventArgs e)
        {
            if (!_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist)) return;
            var text = KeyGenerator.OpenFile("Select the setlist to switch to.", "GH3CP Setlist File|*.sgh");
            if (text.Equals(""))
            {
                return;
            }
            MessageBox.Show("Found file: " + text);
            Trace.WriteLine("Found file: " + text);
            Debug.WriteLine("Found file: " + text);
            Console.WriteLine("Found file: " + text);
            var gH3Setlist = new Gh3Setlist();
            try
            {
                var sghManager = DialogResult.Yes ==
                                 MessageBox.Show(
                                     "Do you wish to import all contained song data (Music & Game Tracks)? Data and properties will be overwritten!",
                                     "Setlist Switching", MessageBoxButtons.YesNo)
                    ? new SghManager(_gh3Songlist, gH3Setlist, text, _dataFolder)
                    : new SghManager(_gh3Songlist, gH3Setlist, text);
                sghManager.ImportSGH();
                _tierBox.Items.Clear();
                _tierBox.Items.AddRange(gH3Setlist.Tiers.ToArray());
                if (_tierBox.Items.Count != 0)
                {
                    _tierBox.SelectedIndex = 0;
                }
                else
                {
                    method_23();
                }
                _setlistTitleTxtBox.Text = KeyGenerator.GetFileName(text, 1);
                _setlistApplyBtn.Enabled = true;
                method_4(new Class247(Class3190, _gh3Songlist));
                RefreshSongListBox();
            }
            catch (Exception exception)
            {
                MessageBox.Show("File not compatible! Setlist Switch failed.\n" + exception, "Setlist Switching");
            }
        }

        private static void LegacyImporter_MenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MassImporter_MenuItem_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Please select a folder that contains the folder structure for mass song importing.",
                RootFolder = Environment.SpecialFolder.DesktopDirectory
            };
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var directories = Directory.GetDirectories(folderBrowserDialog.SelectedPath, "*",
                SearchOption.TopDirectoryOnly);
            var list = new List<string>(directories);
            var array = directories;
            foreach (var file in array)
            {
                try
                {
                    var list2 = KeyGenerator.CheckFile(file, "*.mid;*.chart;*.qbc;*.dbc", true);
                    var list3 = KeyGenerator.CheckFile(file, "*.wav;*.mp3;*.ogg", true);
                    var files = Directory.GetFiles(file, "*.dat", SearchOption.TopDirectoryOnly);
                    if (list2.Count == 0 || (list3.Count == 0 && files.Length == 0)) continue;
                    var gH3Song = _isAerosmith ? new GhaSong() : new Gh3Song();
                    gH3Song.Name = KeyGenerator.GetFileName(file).ToLower().Replace(" ", "").Replace('.', '_');
                    if (gH3Song.Name.Length > 30)
                    {
                        gH3Song.Name = gH3Song.Name.Remove(30);
                    }
                    if (QbSongClass1.smethod_4(gH3Song.Name) || _gh3Songlist.method_3(gH3Song.Name))
                    {
                        var num = 2;
                        while (QbSongClass1.smethod_4(gH3Song.Name + num) || _gh3Songlist.method_3(gH3Song.Name + num))
                        {
                            num++;
                        }
                        var expr176 = gH3Song;
                        expr176.Name += num;
                    }
                    QbcParser qbcParser = null;
                    foreach (var current in list2)
                    {
                        try
                        {
                            if (current.EndsWith(".qbc"))
                            {
                                qbcParser = new QbcParser(current);
                            }
                            else if (current.EndsWith(".mid"))
                            {
                                qbcParser =
                                    Midi2Chart.LoadMidiSong(current, _forceRb3MidConversionToolStripMenuItem.Checked);
                            }
                            else
                            {
                                qbcParser = new ChartParser(current).ConvertToQbc();
                            }
                            break;
                        }
                        catch
                        {
                        }
                    }
                    if (qbcParser == null) continue;
                    ZzQbSongObject class2 = null;
                    if (files.Length != 0)
                    {
                        var array2 = files;
                        foreach (var text2 in array2)
                        {
                            try
                            {
                                if (!File.Exists(text2.Replace(".dat.xen", ".fsb.xen"))) continue;
                                class2 = new ZzQbSongObject(text2);
                                if ((int) new FileInfo(text2.Replace(".dat.xen", ".fsb.xen")).Length == class2.Int0)
                                {
                                    break;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    if (class2 == null && list3.Count == 0) continue;
                    var songData = new SongData(gH3Song.Name, qbcParser, class2, list3.ToArray());
                    var class3 = songData.method_1(Class3190, _dataFolder);
                    var class4 = songData.method_0(_dataFolder);
                    gH3Song.vmethod_0(class3.Class3620.Gh3Song0);
                    if (File.Exists(file + "\\song.ini"))
                    {
                        var array3 = File.ReadAllLines(file + "\\song.ini");
                        foreach (var text3 in array3)
                        {
                            if (text3.StartsWith("name"))
                            {
                                gH3Song.Title = text3.Remove(0, text3.IndexOf('=') + 1).Trim();
                            }
                            else if (text3.StartsWith("artist"))
                            {
                                gH3Song.Artist = text3.Remove(0, text3.IndexOf('=') + 1).Trim();
                            }
                        }
                    }
                    gH3Song.NoRhythmTrack = !class4.Bool0;
                    gH3Song.UseCoopNotetracks = class4.Bool1;
                    gH3Song.Version = 3;
                    gH3Song.Leaderboard = true;
                    gH3Song.Editable = true;
                    method_4(class3);
                    method_4(class4);
                    _gh3Songlist.Add(gH3Song.Name, gH3Song);
                    list.Remove(file);
                }
                catch
                {
                }
            }
            method_4(new Class247(Class3190, _gh3Songlist));
            RefreshSongListBox();
            if (list.Count == 0) return;
            var text4 = list.Aggregate("The follwing songs (by folder name) failed:",
                (current, current2) => current + "\n" + KeyGenerator.GetFileName(current2));
            MessageBox.Show(text4, "Error!");
        }

        public MainMenu()
        {
            //Creates GUI
            InitializeComponent();
            LoadMore();
            AbstractBaseTreeNode1.Bool0 = false;
            try
            {
                string text = null;
                string text2 = null;
                using (var streamReader = new StreamReader(
                    new WebClient().OpenRead("http://sites.google.com/site/sigmaincproduction/ghtcp_latest.txt")))
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
                if (text != null && text2 != null &&
                    Assembly.GetExecutingAssembly().GetName().Version.CompareTo(new Version(text)) < 0 &&
                    DialogResult.Yes == MessageBox.Show("Would you like to download the latest version?",
                        "GHTCP: Version " + text + " is available!", MessageBoxButtons.YesNo))
                {
                    Process.Start(text2);
                }
            }
            catch
            {
                // ignored
            }
            if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero III\\") != null)
            {
                _gameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero III\\";
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null &&
                    MessageBox.Show("Do you wish to load GH Aerosmith?", "GH Aerosmith found!",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _gameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
                    _isAerosmith = true;
                }
            }
            else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero III\\") != null)
            {
                _gameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero III\\";
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null &&
                    MessageBox.Show("Do you wish to load GH Aerosmith?", "GH Aerosmith found!",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _gameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
                    _isAerosmith = true;
                }
            }
            else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\") != null)
            {
                _gameRegistry = "SOFTWARE\\Wow6432Node\\Aspyr\\Guitar Hero Aerosmith\\";
                _isAerosmith = true;
            }
            else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\") != null)
            {
                _gameRegistry = "SOFTWARE\\Aspyr\\Guitar Hero Aerosmith\\";
                _isAerosmith = true;
            }
            else
            {
                MessageBox.Show("Guitar Hero III is not installed properly! Please re/install and run again.");
                formClosing();
            }
            _ghtcpRegistry = (_isAerosmith ? "SOFTWARE\\SigmaInc\\GHTCPAero\\" : "SOFTWARE\\SigmaInc\\GHTCP\\");
            _backupName = (_isAerosmith ? "backupAero\\" : "backup\\");
            zzEmbeddedResourceDB.GameName = (_isAerosmith ? "GHA" : "GH3");
            if (_isAerosmith)
            {
                Text += " - Aerosmith";
                _tierIconDropBox.Items.AddRange(new[]
                {
                    "setlist_icon_01",
                    "setlist_icon_02",
                    "setlist_icon_03",
                    "setlist_icon_04",
                    "setlist_icon_05",
                    "setlist_icon_06"
                });
                _tierStageDropBox.Items.AddRange(new[]
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
                _tierEncorep2CheckBox.Text = "P1 Aerosmith Encore";
            }
            else
            {
                Text += " - Legends of Rock";
                _tierIconDropBox.Items.AddRange(new[]
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
                _tierStageDropBox.Items.AddRange(new[]
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
            _appDirectory = Directory.GetCurrentDirectory() + "\\";
            method_12(false);
            var registryKey = Registry.LocalMachine.CreateSubKey(_ghtcpRegistry);
            method_10((string) registryKey.GetValue("Priority"));
            if (!new List<string>(new[]
            {
                "high",
                "above",
                "normal",
                "below"
            }).Contains(_priority))
            {
                method_10("normal");
            }
            var list = new List<string>(new[]
            {
                (string) registryKey.GetValue("English"),
                (string) registryKey.GetValue("French"),
                (string) registryKey.GetValue("Italian"),
                (string) registryKey.GetValue("Spanish"),
                (string) registryKey.GetValue("German"),
                (string) registryKey.GetValue("Korean")
            });
            if (list.Contains(null))
            {
                _languageList = new[]
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
                _languageList = list.ToArray();
            }
            InitializeLanguageList();
            _silentGuitarMenuItem.Checked = (Class248.Bool2 =
                ((((int?) registryKey.GetValue("SilentGuitar")) ?? 0) != 0));
            _minToTrayMenuItem.Checked = ((((int?) registryKey.GetValue("MinimizeToTray")) ?? 0) != 0);
            _silentGuitarMenuItem.Checked = (Class248.Bool3 =
                ((((int?) registryKey.GetValue("ForceConversion")) ?? 0) != 0));
            if (!Directory.Exists(_appDirectory + _backupName))
            {
                Directory.CreateDirectory(_appDirectory + _backupName);
            }
            if (!Directory.Exists(_appDirectory + _backupName + "originals"))
            {
                Directory.CreateDirectory(_appDirectory + _backupName + "originals");
            }
            if (!Directory.Exists(_appDirectory + _backupName + "lastedited"))
            {
                Directory.CreateDirectory(_appDirectory + _backupName + "lastedited");
            }
            if (!File.Exists(_appDirectory + "lame_enc.dll"))
            {
                try
                {
                    ZipManager.smethod_8(
                        new WebClient().OpenRead("http://spaghetticode.org/lame/libmp3lame-win-3.97.zip"),
                        _appDirectory + "lame_enc.dll", "libmp3lame-3.97/lame_enc.dll");
                }
                catch
                {
                    Process.Start("http://lame.buanzo.com.ar/");
                    MessageBox.Show(
                        "Please download the file under \"ZIP OPTION:\" and select it: libmp3lame-win-#.#.zip",
                        "MP3 Encoding Library Missing!");
                    try
                    {
                        var text4 =
                            KeyGenerator.OpenOrSaveFile("Locate MP3 Encoding Library (file will be deleted after!)",
                                "MP3 Lame Zip|*.zip", true);
                        var text5 = KeyGenerator.GetFileNameNoExt(text4);
                        ZipManager.smethod_4(text4, _appDirectory + "lame_enc.dll",
                            "libmp3lame" + text5.Substring(text5.LastIndexOf('-')) + "/lame_enc.dll");
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
                        MessageBox.Show(
                            "MP3 Encoding Library could not be extracted, Audio conversion will fail without it!",
                            "MP3 Encoding Library Missing!");
                    }
                }
            }
        }

        private void TexExplorer_MenuItem_Click(object sender, EventArgs e)
        {
            new TexExplorer(_dataFolder).ShowDialog();
        }

        private void SaveFileControl_MenuItem_Click(object sender, EventArgs e)
        {
            var a = KeyGenerator.OpenOrSaveFile("Select Save File to Import. Current Save File will be Overwritten!",
                "GH3 Save File|s000.d", true);
            if (a != "")
            {
                var @class = new Class324(a);
                @class.method_0(new Class324(872398018)).List0[0].Int0[1] = -1;
                var text = "Progress" + (new[]
                {
                    "A",
                    "B",
                    "C",
                    "D",
                    "E"
                })[_list0.IndexOf(KeyGenerator.GetFileNameNoExt(Class3190.String0).Remove(0, 2))];
                text = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "\\Aspyr\\Guitar Hero III\\Save\\", text, "}{", text);
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                @class.method_1(text);
            }
        }

        private void method_4(QbEditor class2450)
        {
            foreach (QbEditor @class in _actionRequestsListBox.Items)
            {
                if (@class.Equals(class2450))
                {
                    _actionRequestsListBox.Items.Remove(@class);
                    break;
                }
            }
            _actionRequestsListBox.Items.Add(class2450);
        }

        private void ClearActions_MenuItem_Click(object sender, EventArgs e)
        {
            if (_actionRequestsListBox.Items.Count != 0 && DialogResult.Yes ==
                MessageBox.Show("Are You sure you want to delete all Actions?", "Warning!", MessageBoxButtons.YesNo))
            {
                _actionRequestsListBox.Items.Clear();
                GC.Collect();
            }
        }

        private void ExecuteActions_MenuItem_Click(object sender, EventArgs e)
        {
            if (_actionRequestsListBox.Items.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Execute Actions?", "Warning!",
                        MessageBoxButtons.YesNo))
                {
                    var list = new List<QbEditor>();
                    foreach (QbEditor item in _actionRequestsListBox.Items)
                    {
                        list.Add(item);
                    }
                    _actionsWindow0 = new ActionsWindow(list);
                    _actionsWindow0.method_0(method_5);
                    _actionsWindow0.Show();
                    _actionsWindow0.method_1();
                }
            }
        }

        private void method_5(object sender, EventArgs e)
        {
            if ((!_actionsWindow0.Bool0 || DialogResult.Yes ==
                 MessageBox.Show("Some of the action requests failed!\nDo you still wish to rebuild the game settings?",
                     "Warning!", MessageBoxButtons.YesNo)) && method_18())
            {
                _actionsWindow0 = null;
                _actionRequestsListBox.Items.Clear();
                GC.Collect();
            }
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_actionRequestsListBox.Items.Count != 0 && DialogResult.Yes !=
                MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?",
                    "Warning!", MessageBoxButtons.YesNo))
            {
                e.Cancel = true;
                return;
            }
            formClosing();
        }

        public void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine(WindowState);
            if (WindowState == FormWindowState.Minimized && _minToTrayMenuItem.Checked)
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
        public static extern bool SetForegroundWindow(HandleRef handleRef0);

        private void notifyIcon_0_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                _leftClickMenu.Hide();
                _rightClickMenu.Hide();
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
                    var registryKey = Registry.LocalMachine.OpenSubKey(_gameRegistry);
                    var process = new Process();
                    process.StartInfo =
                        new ProcessStartInfo((string) registryKey.GetValue("Path") +
                                             (_isAerosmith ? "Guitar Hero Aerosmith.exe" : "GH3.exe"));
                    process.Start();
                    if (_priority != "normal")
                    {
                        process.PriorityClass = ((_priority == "high")
                            ? ProcessPriorityClass.High
                            : ((_priority == "above")
                                ? ProcessPriorityClass.AboveNormal
                                : ((_priority == "below")
                                    ? ProcessPriorityClass.BelowNormal
                                    : ProcessPriorityClass.Normal)));
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
                _leftClickMenu.Show(this, PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveLeft);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                _rightClickMenu.Show(this, PointToClient(Cursor.Position), ToolStripDropDownDirection.AboveRight);
            }
        }

        private void formClosing()
        {
            var registryKey = Registry.LocalMachine.CreateSubKey(_ghtcpRegistry);
            registryKey.SetValue("Priority", _priority);
            registryKey.SetValue("SilentGuitar", Class248.Bool2 ? 1 : 0);
            registryKey.SetValue("MinimizeToTray", _minToTrayMenuItem.Checked ? 1 : 0);
            registryKey.SetValue("ForceConversion", Class248.Bool3 ? 1 : 0);
            method_15();
            _songEditorControl.Dispose();
            _notifyIcon0.Visible = false;
            Dispose(true);
        }

        private void Exit_MenuItem_Click(object sender, EventArgs e)
        {
            if (_actionRequestsListBox.Items.Count != 0 && DialogResult.Yes !=
                MessageBox.Show("Any actions that are not executed will be erased! Are you sure you wish to quit?",
                    "Warning!", MessageBoxButtons.YesNo))
            {
                return;
            }
            formClosing();
        }

        private void method_7(string string7)
        {
            _sysEnglishMenuItem.Checked = (string7 == "en");
            _sysFrenchMenuItem.Checked = (string7 == "fr");
            _sysItalianMenuItem.Checked = (string7 == "it");
            _sysSpanishMenuItem.Checked = (string7 == "es");
            _sysGermanMenuItem.Checked = (string7 == "de");
            _sysKoreanMenuItem.Checked = (string7 == "ko");
        }

        private void method_8(string string7)
        {
            var registryKey = Registry.LocalMachine.CreateSubKey(_gameRegistry);
            registryKey.SetValue("Language", string7);
            method_7(string7);
        }

        private string method_9()
        {
            var registryKey = Registry.LocalMachine.CreateSubKey(_gameRegistry);
            var text = (string) registryKey.GetValue("Language");
            method_7(text);
            return text;
        }

        private void SysKorean_MenuItem_Click(object sender, EventArgs e)
        {
            method_8((string) ((ToolStripMenuItem) sender).Tag);
        }

        private void method_10(string string7)
        {
            _priority = string7;
            _sysHighMenuItem.Checked = (_priority == "high");
            _sysAboveMenuItem.Checked = (_priority == "above");
            _sysNormalMenuItem.Checked = (_priority == "normal");
            _sysBelowMenuItem.Checked = (_priority == "below");
        }

        private void SysBelow_MenuItem_Click(object sender, EventArgs e)
        {
            method_10((string) ((ToolStripMenuItem) sender).Tag);
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
            Process.Start(_dataFolder);
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
            var expr06 = _silentGuitarMenuItem;
            Class248.Bool2 = (expr06.Checked = !expr06.Checked);
        }

        private void FxSpeedBoost_MenuItem_Click(object sender, EventArgs e)
        {
            method_4(new ZzFxBoost(Class3190));
        }

        private void ForceMp3Conversion_MenuItem_Click(object sender, EventArgs e)
        {
            var expr06 = _forceMp3ConversionMenuItem;
            Class248.Bool3 = (expr06.Checked = !expr06.Checked);
        }

        //Disables Buttons
        private void method_11(Gh3Setlist gh3Setlist0)
        {
            _setlistTitleTxtBox.Text = (string) _setlistDropBox.SelectedItem;
            _setlistTitleTxtBox.Enabled = (_deleteSetlistBtn.Enabled = gh3Setlist0.method_4());
            //this.CreateSetlist_Btn.Enabled = (this.gh3Songlist_0.CustomBitMask != -1);
            _setlistPrefixTxtBox.Text = gh3Setlist0.Prefix;
            _setlistInitMovieTxtBox.Text = gh3Setlist0.InitialMovie;
            _tierBox.Items.Clear();
            _tierBox.Items.AddRange(gh3Setlist0.Tiers.ToArray());
            if (_tierBox.Items.Count != 0)
            {
                _tierBox.SelectedIndex = 0;
            }
            else
            {
                method_23();
            }
            _setlistApplyBtn.Enabled = false;
        }

        private void Setlist_DropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_11(_gh3Songlist.Gh3SetlistList[
                _selectedSetlist = _gh3Songlist.method_9((string) _setlistDropBox.SelectedItem)]);
        }

        private void CreateSetlist_Btn_Click(object sender, EventArgs e)
        {
            if (_gh3Songlist.CustomBitMask == -1)
            {
                return;
            }
            var gH3Setlist = new Gh3Setlist();
            gH3Setlist.method_3("scripts\\guitar\\custom_menu\\guitar_custom_progression.qb");
            gH3Setlist.InitialMovie = "";
            gH3Setlist.Tiers.Add(new Gh3Tier());
            for (var i = 0;;)
            {
                //num = 2^numOfSetlists
                var num = 1 << i;
                if ((_gh3Songlist.CustomBitMask & num) != 0)
                {
                    goto SKIPIT;
                }
                //2^numOfSetlists - 1

                _gh3Songlist.CustomBitMask |= (gH3Setlist.CustomBit = num);

                IL_7E:
                gH3Setlist.Prefix = "custom" + (i + 1);
                int num2;
                _gh3Songlist.Gh3SetlistList.Add(
                    num2 = QbSongClass1.AddKeyToDictionary("gh3_custom" + (i + 1) + "_songs"), gH3Setlist);
                int value;
                _gh3Songlist.Dictionary1.Add(
                    value = QbSongClass1.AddKeyToDictionary("custom" + (i + 1) + "_progression"), new GhLink(num2));
                string text;
                _gh3Songlist.Class2140.Add(text = "Custom Setlist " + (i + 1), value);
                _setlistDropBox.Items.Add(text);
                _setlistDropBox.SelectedItem = text;
                method_4(new Class246(value, Class3190, _gh3Songlist, true));
                method_4(new UpdateSetlistSwitcher(Class3190, _gh3Songlist, _isAerosmith));
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
            if (!_gh3Songlist.Gh3SetlistList[_selectedSetlist].method_4())
            {
                return;
            }
            var text = (string) _setlistDropBox.SelectedItem;
            _setlistDropBox.SelectedIndex--;
            _setlistDropBox.Items.Remove(text);
            method_4(new Class246(_gh3Songlist.Class2140[text], Class3190, _gh3Songlist, false));
            method_4(new UpdateSetlistSwitcher(Class3190, _gh3Songlist, _isAerosmith));
        }

        private void SetlistTitle_TxtBox_TextChanged(object sender, EventArgs e)
        {
            _setlistApplyBtn.Enabled = true;
        }

        private void SetlistApply_Btn_Click(object sender, EventArgs e)
        {
            var gH3Setlist = _gh3Songlist.Gh3SetlistList[_selectedSetlist];
            gH3Setlist.InitialMovie = _setlistInitMovieTxtBox.Text;
            gH3Setlist.Tiers.Clear();
            foreach (Gh3Tier item in _tierBox.Items)
            {
                gH3Setlist.Tiers.Add(item);
            }
            if (_setlistTitleTxtBox.Text != (string) _setlistDropBox.SelectedItem)
            {
                _gh3Songlist.Class2140.Add(_setlistTitleTxtBox.Text,
                    _gh3Songlist.Class2140[(string) _setlistDropBox.SelectedItem]);
                _gh3Songlist.Class2140.Remove((string) _setlistDropBox.SelectedItem);
                method_4(new UpdateSetlistSwitcher(Class3190, _gh3Songlist, _isAerosmith));
                _setlistDropBox.Items[_setlistDropBox.SelectedIndex] = _setlistTitleTxtBox.Text;
            }
            _setlistApplyBtn.Enabled = false;
            method_4(new ZzSetListUpdater(_selectedSetlist, Class3190, _gh3Songlist));
        }

        private void NewTier_MenuItem_Click(object sender, EventArgs e)
        {
            if (_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
            {
                _tierBox.Items.Add(new Gh3Tier());
                _tierBox.SelectedIndex = _tierBox.Items.Count - 1;
                _setlistApplyBtn.Enabled = true;
            }
        }

        private void ManageTiers_MenuItem_Click(object sender, EventArgs e)
        {
            if (_tierBox.SelectedIndex >= 0)
            {
                var list = new List<Gh3Tier>();
                foreach (Gh3Tier item in _tierBox.Items)
                {
                    list.Add(item);
                }
                var tierManagement = new TierManagement((string) _setlistDropBox.SelectedItem, list.ToArray());
                if (tierManagement.ShowDialog() == DialogResult.OK)
                {
                    _tierBox.Items.Clear();
                    _tierBox.Items.AddRange(tierManagement.method_0());
                    if (_tierBox.Items.Count != 0)
                    {
                        _tierBox.SelectedIndex = 0;
                    }
                    else
                    {
                        method_23();
                    }
                    _setlistApplyBtn.Enabled = true;
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
            var resources = new ComponentResourceManager(typeof(MainMenu));
            _rightClickMenu = new ContextMenuStrip(components);
            _sysHighMenuItem = new ToolStripMenuItem();
            _sysAboveMenuItem = new ToolStripMenuItem();
            _sysNormalMenuItem = new ToolStripMenuItem();
            _sysBelowMenuItem = new ToolStripMenuItem();
            _toolStripSeparator8 = new ToolStripSeparator();
            _minToTrayMenuItem = new ToolStripMenuItem();
            _sysExitMenuItem = new ToolStripMenuItem();
            _topMenuStrip = new MenuStrip();
            _fileMenuItem = new ToolStripMenuItem();
            _openGameSettingsMenuItem = new ToolStripMenuItem();
            _recoverGameSettingsMenuItem = new ToolStripMenuItem();
            _clearGameSettingsMenuItem = new ToolStripMenuItem();
            _executeActionsMenuItem = new ToolStripMenuItem();
            _clearActionsMenuItem = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _saveTghMenuItem = new ToolStripMenuItem();
            _saveSghMenuItem = new ToolStripMenuItem();
            _saveChartMenuItem = new ToolStripMenuItem();
            _exportSetlistAsChartsToolStripMenuItem = new ToolStripMenuItem();
            _exportSongListToolStripMenuItem = new ToolStripMenuItem();
            _exportSongListToolStripMenuItem1 = new ToolStripMenuItem();
            _toolStripSeparator6 = new ToolStripSeparator();
            _exitMenuItem = new ToolStripMenuItem();
            _addMenuItem = new ToolStripMenuItem();
            _newSongMenuItem = new ToolStripMenuItem();
            _tierMenuItem = new ToolStripMenuItem();
            _newTierMenuItem = new ToolStripMenuItem();
            _tghImportMenuItem = new ToolStripMenuItem();
            _massImporterMenuItem = new ToolStripMenuItem();
            _legacyImporterMenuItem = new ToolStripMenuItem();
            _recoverSonglistMenuItem = new ToolStripMenuItem();
            _manageGameMenuItem = new ToolStripMenuItem();
            _manageTiersMenuItem = new ToolStripMenuItem();
            _toolStripSeparator4 = new ToolStripSeparator();
            _tghSwitchMenuItem = new ToolStripMenuItem();
            _sghSwitchMenuItem = new ToolStripMenuItem();
            _toolStripSeparator11 = new ToolStripSeparator();
            _gameSettingsSwitchMenuItem = new ToolStripMenuItem();
            _restoreLastMenuItem = new ToolStripMenuItem();
            _restoreOriginalMenuItem = new ToolStripMenuItem();
            _toolStripSeparator7 = new ToolStripSeparator();
            _saveFileControlMenuItem = new ToolStripMenuItem();
            _texExplorerMenuItem = new ToolStripMenuItem();
            _fxSpeedBoostMenuItem = new ToolStripMenuItem();
            _manageSongsMenuItem = new ToolStripMenuItem();
            _songPropsMenuItem = new ToolStripMenuItem();
            _rebuildSongMenuItem = new ToolStripMenuItem();
            _silentGuitarMenuItem = new ToolStripMenuItem();
            _forceMp3ConversionMenuItem = new ToolStripMenuItem();
            _forceRb3MidConversionToolStripMenuItem = new ToolStripMenuItem();
            _deleteSongMenuItem = new ToolStripMenuItem();
            _removeSongToolStripMenuItem = new ToolStripSeparator();
            _hideUnEditMenuItem = new ToolStripMenuItem();
            _hideUsedMenuItem = new ToolStripMenuItem();
            _byTitleMenuItem = new ToolStripMenuItem();
            _helpMenuItem = new ToolStripMenuItem();
            _guideMenuItem = new ToolStripMenuItem();
            _scoreHeroMenuItem = new ToolStripMenuItem();
            _gh3FolderMenuItem = new ToolStripMenuItem();
            _toolStripSeparator3 = new ToolStripSeparator();
            _disclaimerMenuItem = new ToolStripMenuItem();
            _aboutMenuItem = new ToolStripMenuItem();
            _actionRequestsListBox = new ListBox();
            _label1 = new Label();
            _label3 = new Label();
            _sidePanel = new TableLayoutPanel();
            _notifyIcon0 = new NotifyIcon(components);
            _fontDialog0 = new FontDialog();
            _leftClickMenu = new ContextMenuStrip(components);
            _sysEnglishMenuItem = new ToolStripMenuItem();
            _sysFrenchMenuItem = new ToolStripMenuItem();
            _sysItalianMenuItem = new ToolStripMenuItem();
            _sysSpanishMenuItem = new ToolStripMenuItem();
            _sysGermanMenuItem = new ToolStripMenuItem();
            _sysKoreanMenuItem = new ToolStripMenuItem();
            _mainContainer = new ToolStripContainer();
            _statusStrip = new StatusStrip();
            _toolStripStatusLbl = new ToolStripStatusLabel();
            _tabControl = new TabControl();
            _setlistTab = new TabPage();
            _setlistConfigContainer = new ToolStripContainer();
            _setlistConfTLPanel = new TableLayoutPanel();
            _setlistTLPanel = new TableLayoutPanel();
            _textBox3 = new TextBox();
            _label5 = new Label();
            _label4 = new Label();
            _tierBox = new ComboBox();
            _setlistInitMovieTxtBox = new TextBox();
            _setlistPrefixTxtBox = new TextBox();
            _label2 = new Label();
            _label13 = new Label();
            _setlistTitleTxtBox = new TextBox();
            _tierTLPanel = new TableLayoutPanel();
            _tierPropsPanel = new Panel();
            _tierUnlockedSetBtn = new Button();
            _unlockAllCheckBox = new CheckBox();
            _noCashCheckBox = new CheckBox();
            _tierApplyBtn = new Button();
            _label12 = new Label();
            _setlistApplyBtn = new Button();
            _tierCompMovieTxtBox = new TextBox();
            _tierUnlockedNumBox = new NumericUpDown();
            _tierTitleTxtBox = new TextBox();
            _tierIconDropBox = new ComboBox();
            _tierStageDropBox = new ComboBox();
            _tierBossCheckBox = new CheckBox();
            _tierEncorep2CheckBox = new CheckBox();
            _tierEncorep1CheckBox = new CheckBox();
            _label10 = new Label();
            _label9 = new Label();
            _label8 = new Label();
            _label6 = new Label();
            _label7 = new Label();
            _tierSongsPanel = new TableLayoutPanel();
            _label11 = new Label();
            _setlistStrip = new ToolStrip();
            _setlistLbl = new ToolStripLabel();
            _setlistDropBox = new ToolStripComboBox();
            _createSetlistBtn = new ToolStripButton();
            _deleteSetlistBtn = new ToolStripButton();
            _songEditorTab = new TabPage();
            _songEditorContainer = new ToolStripContainer();
            _songEditorBottomToolStrip = new ToolStrip();
            _toggleElementsEditorSplitBtn = new ToolStripSplitButton();
            _starViewEditorBtn = new ToolStripMenuItem();
            _hopoViewEditorBtn = new ToolStripMenuItem();
            _audioViewEditorBtn = new ToolStripMenuItem();
            _toolStripSeparator10 = new ToolStripSeparator();
            _toolStripLabel1 = new ToolStripLabel();
            _beatSizeEditorTxtBox = new ToolStripTextBox();
            _toolStripSeparator12 = new ToolStripSeparator();
            _toolStripLabel2 = new ToolStripLabel();
            _offsetEditorTxtBox = new ToolStripTextBox();
            _songEditorTopToolStrip = new ToolStrip();
            _gameModeEditorBtn = new ToolStripButton();
            _toolStripSeparator5 = new ToolStripSeparator();
            _loadChartEditorBtn = new ToolStripButton();
            _selectedTrackEditorBox = new ToolStripComboBox();
            _songNameEditorLbl = new ToolStripLabel();
            _toolStripSeparator2 = new ToolStripSeparator();
            _loadAudioEditorBtn = new ToolStripButton();
            _playPauseEditorBtn = new ToolStripButton();
            _stopEditorBtn = new ToolStripButton();
            _playTimeEditorLbl = new ToolStripLabel();
            _tierSongsListBox = new ZzListBox238();
            _hyperSpeedEditorBar = new GhtcpToolStripControlHost();
            _fretAngleEditorBar = new GhtcpToolStripControlHost();
            _songEditorControl = new SongEditor();
            _songListBox = new ZzListBox238();
            _rightClickMenu.SuspendLayout();
            _topMenuStrip.SuspendLayout();
            _sidePanel.SuspendLayout();
            _leftClickMenu.SuspendLayout();
            _mainContainer.BottomToolStripPanel.SuspendLayout();
            _mainContainer.ContentPanel.SuspendLayout();
            _mainContainer.TopToolStripPanel.SuspendLayout();
            _mainContainer.SuspendLayout();
            _statusStrip.SuspendLayout();
            _tabControl.SuspendLayout();
            _setlistTab.SuspendLayout();
            _setlistConfigContainer.ContentPanel.SuspendLayout();
            _setlistConfigContainer.TopToolStripPanel.SuspendLayout();
            _setlistConfigContainer.SuspendLayout();
            _setlistConfTLPanel.SuspendLayout();
            _setlistTLPanel.SuspendLayout();
            _tierTLPanel.SuspendLayout();
            _tierPropsPanel.SuspendLayout();
            ((ISupportInitialize) (_tierUnlockedNumBox)).BeginInit();
            _tierSongsPanel.SuspendLayout();
            _setlistStrip.SuspendLayout();
            _songEditorTab.SuspendLayout();
            _songEditorContainer.BottomToolStripPanel.SuspendLayout();
            _songEditorContainer.ContentPanel.SuspendLayout();
            _songEditorContainer.TopToolStripPanel.SuspendLayout();
            _songEditorContainer.SuspendLayout();
            _songEditorBottomToolStrip.SuspendLayout();
            _songEditorTopToolStrip.SuspendLayout();
            SuspendLayout();
            //
            // rightClickMenu
            //
            _rightClickMenu.Items.AddRange(new ToolStripItem[]
            {
                _sysHighMenuItem,
                _sysAboveMenuItem,
                _sysNormalMenuItem,
                _sysBelowMenuItem,
                _toolStripSeparator8,
                _minToTrayMenuItem,
                _sysExitMenuItem
            });
            _rightClickMenu.Name = "_rightClickMenu";
            _rightClickMenu.Size = new Size(167, 142);
            //
            // SysHigh_MenuItem
            //
            _sysHighMenuItem.Name = "_sysHighMenuItem";
            _sysHighMenuItem.ShowShortcutKeys = false;
            _sysHighMenuItem.Size = new Size(166, 22);
            _sysHighMenuItem.Tag = "high";
            _sysHighMenuItem.Text = "High";
            _sysHighMenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysAbove_MenuItem
            //
            _sysAboveMenuItem.Name = "_sysAboveMenuItem";
            _sysAboveMenuItem.ShowShortcutKeys = false;
            _sysAboveMenuItem.Size = new Size(166, 22);
            _sysAboveMenuItem.Tag = "above";
            _sysAboveMenuItem.Text = "Above Normal";
            _sysAboveMenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysNormal_MenuItem
            //
            _sysNormalMenuItem.Name = "_sysNormalMenuItem";
            _sysNormalMenuItem.ShowShortcutKeys = false;
            _sysNormalMenuItem.Size = new Size(166, 22);
            _sysNormalMenuItem.Tag = "normal";
            _sysNormalMenuItem.Text = "Normal";
            _sysNormalMenuItem.Click += SysBelow_MenuItem_Click;
            //
            // SysBelow_MenuItem
            //
            _sysBelowMenuItem.Name = "_sysBelowMenuItem";
            _sysBelowMenuItem.ShowShortcutKeys = false;
            _sysBelowMenuItem.Size = new Size(166, 22);
            _sysBelowMenuItem.Tag = "below";
            _sysBelowMenuItem.Text = "Below Normal";
            _sysBelowMenuItem.Click += SysBelow_MenuItem_Click;
            //
            // toolStripSeparator8
            //
            _toolStripSeparator8.Name = "_toolStripSeparator8";
            _toolStripSeparator8.Size = new Size(163, 6);
            //
            // MinToTray_MenuItem
            //
            _minToTrayMenuItem.CheckOnClick = true;
            _minToTrayMenuItem.Name = "_minToTrayMenuItem";
            _minToTrayMenuItem.Size = new Size(166, 22);
            _minToTrayMenuItem.Text = "Minimize To Tray";
            //
            // SysExit_MenuItem
            //
            _sysExitMenuItem.Name = "_sysExitMenuItem";
            _sysExitMenuItem.ShowShortcutKeys = false;
            _sysExitMenuItem.Size = new Size(166, 22);
            _sysExitMenuItem.Text = "Exit";
            _sysExitMenuItem.Click += Exit_MenuItem_Click;
            //
            // TopMenuStrip
            //
            _topMenuStrip.Dock = DockStyle.None;
            _topMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                _fileMenuItem,
                _addMenuItem,
                _manageGameMenuItem,
                _manageSongsMenuItem,
                _helpMenuItem
            });
            _topMenuStrip.Location = new Point(0, 0);
            _topMenuStrip.Name = "_topMenuStrip";
            _topMenuStrip.Size = new Size(784, 24);
            _topMenuStrip.TabIndex = 2;
            _topMenuStrip.Text = "menuStrip1";
            //
            // File_MenuItem
            //
            _fileMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _openGameSettingsMenuItem,
                _recoverGameSettingsMenuItem,
                _clearGameSettingsMenuItem,
                _executeActionsMenuItem,
                _clearActionsMenuItem,
                _toolStripSeparator1,
                _saveTghMenuItem,
                _saveSghMenuItem,
                _saveChartMenuItem,
                _exportSetlistAsChartsToolStripMenuItem,
                _exportSongListToolStripMenuItem,
                _exportSongListToolStripMenuItem1,
                _toolStripSeparator6,
                _exitMenuItem
            });
            _fileMenuItem.Name = "_fileMenuItem";
            _fileMenuItem.Size = new Size(37, 20);
            _fileMenuItem.Text = "File";
            //
            // OpenGameSettings_MenuItem
            //
            _openGameSettingsMenuItem.Name = "_openGameSettingsMenuItem";
            _openGameSettingsMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            _openGameSettingsMenuItem.Size = new Size(264, 22);
            _openGameSettingsMenuItem.Text = "&Open Game Settings";
            _openGameSettingsMenuItem.Click += OpenGameSettings_MenuItem_Click;
            //
            // RecoverGameSettings_MenuItem
            //
            _recoverGameSettingsMenuItem.Name = "_recoverGameSettingsMenuItem";
            _recoverGameSettingsMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            _recoverGameSettingsMenuItem.Size = new Size(264, 22);
            _recoverGameSettingsMenuItem.Text = "&Recover Game Settings";
            _recoverGameSettingsMenuItem.Click += RecoverGameSettings_MenuItem_Click;
            //
            // ClearGameSettings_MenuItem
            //
            _clearGameSettingsMenuItem.Name = "_clearGameSettingsMenuItem";
            _clearGameSettingsMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            _clearGameSettingsMenuItem.Size = new Size(264, 22);
            _clearGameSettingsMenuItem.Text = "Clear Game Settings";
            _clearGameSettingsMenuItem.Click += ClearGameSettings_MenuItem_Click;
            //
            // ExecuteActions_MenuItem
            //
            _executeActionsMenuItem.Name = "_executeActionsMenuItem";
            _executeActionsMenuItem.ShortcutKeys = (Keys.Control | Keys.Alt)
                                                   | Keys.S;
            _executeActionsMenuItem.Size = new Size(264, 22);
            _executeActionsMenuItem.Text = "Execute &Actions";
            _executeActionsMenuItem.Click += ExecuteActions_MenuItem_Click;
            //
            // ClearActions_MenuItem
            //
            _clearActionsMenuItem.Name = "_clearActionsMenuItem";
            _clearActionsMenuItem.ShortcutKeys = (Keys.Control | Keys.Alt)
                                                 | Keys.Q;
            _clearActionsMenuItem.Size = new Size(264, 22);
            _clearActionsMenuItem.Text = "&Clear Actions";
            _clearActionsMenuItem.Click += ClearActions_MenuItem_Click;
            //
            // toolStripSeparator1
            //
            _toolStripSeparator1.Name = "_toolStripSeparator1";
            _toolStripSeparator1.Size = new Size(261, 6);
            //
            // SaveTGH_MenuItem
            //
            _saveTghMenuItem.Name = "_saveTghMenuItem";
            _saveTghMenuItem.ShortcutKeys = (Keys.Alt | Keys.Shift)
                                            | Keys.S;
            _saveTghMenuItem.Size = new Size(264, 22);
            _saveTghMenuItem.Text = "Export &TGH (Tier)";
            _saveTghMenuItem.Click += SaveTGH_MenuItem_Click;
            //
            // SaveSGH_MenuItem
            //
            _saveSghMenuItem.Name = "_saveSghMenuItem";
            _saveSghMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            _saveSghMenuItem.Size = new Size(264, 22);
            _saveSghMenuItem.Text = "Export &SGH (Setlist)";
            _saveSghMenuItem.Click += SaveSGH_MenuItem_Click;
            //
            // SaveChart_MenuItem
            //
            _saveChartMenuItem.Name = "_saveChartMenuItem";
            _saveChartMenuItem.Size = new Size(264, 22);
            _saveChartMenuItem.Text = "Export Song Chart";
            _saveChartMenuItem.Click += SaveChart_MenuItem_Click;
            //
            // exportSetlistAsChartsToolStripMenuItem
            //
            _exportSetlistAsChartsToolStripMenuItem.Name = "_exportSetlistAsChartsToolStripMenuItem";
            _exportSetlistAsChartsToolStripMenuItem.ShortcutKeys = (Keys.Control | Keys.Shift)
                                                                   | Keys.S;
            _exportSetlistAsChartsToolStripMenuItem.Size = new Size(264, 22);
            _exportSetlistAsChartsToolStripMenuItem.Text = "Export Setlist as Charts";
            _exportSetlistAsChartsToolStripMenuItem.Click += exportSetlistAsChartsToolStripMenuItem_Click_1;
            // 
            // exportSongListToolStripMenuItem
            // 
            _exportSongListToolStripMenuItem.Enabled = false;
            _exportSongListToolStripMenuItem.Name = "exportSongListToolStripMenuItem";
            _exportSongListToolStripMenuItem.Size = new Size(264, 22);
            _exportSongListToolStripMenuItem.Text = "Export Setlist as CSV";
            _exportSongListToolStripMenuItem.ToolTipText = "Export songs in the selected setlist as CSV";
            _exportSongListToolStripMenuItem.Click += new EventHandler(exportSongListToolStripMenuItem_Click);
            // 
            // exportSongListToolStripMenuItem1
            // 
            _exportSongListToolStripMenuItem1.Enabled = false;
            _exportSongListToolStripMenuItem1.Name = "exportSongListToolStripMenuItem1";
            _exportSongListToolStripMenuItem1.Size = new Size(264, 22);
            _exportSongListToolStripMenuItem1.Text = "Export Songlist as CSV";
            _exportSongListToolStripMenuItem1.ToolTipText = "Export the whole songlist as CSV";
            _exportSongListToolStripMenuItem1.Click += new EventHandler(exportSongListToolStripMenuItem1_Click);
            //
            // toolStripSeparator6
            //
            _toolStripSeparator6.Name = "_toolStripSeparator6";
            _toolStripSeparator6.Size = new Size(261, 6);
            //
            // Exit_MenuItem
            //
            _exitMenuItem.Name = "_exitMenuItem";
            _exitMenuItem.Size = new Size(264, 22);
            _exitMenuItem.Text = "&Exit";
            _exitMenuItem.Click += Exit_MenuItem_Click;
            //
            // Add_MenuItem
            //
            _addMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _newSongMenuItem,
                _tierMenuItem,
                _massImporterMenuItem,
                _legacyImporterMenuItem,
                _recoverSonglistMenuItem
            });
            _addMenuItem.Name = "_addMenuItem";
            _addMenuItem.Size = new Size(41, 20);
            _addMenuItem.Text = "Add";
            //
            // NewSong_MenuItem
            //
            _newSongMenuItem.Name = "_newSongMenuItem";
            _newSongMenuItem.ShortcutKeys = Keys.Alt | Keys.N;
            _newSongMenuItem.Size = new Size(167, 22);
            _newSongMenuItem.Text = "New Song";
            _newSongMenuItem.Click += NewSong_MenuItem_Click;
            //
            // Tier_MenuItem
            //
            _tierMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _newTierMenuItem,
                _tghImportMenuItem
            });
            _tierMenuItem.Name = "_tierMenuItem";
            _tierMenuItem.Size = new Size(167, 22);
            _tierMenuItem.Text = "Tier";
            //
            // NewTier_MenuItem
            //
            _newTierMenuItem.Name = "_newTierMenuItem";
            _newTierMenuItem.ShortcutKeys = Keys.Alt | Keys.T;
            _newTierMenuItem.Size = new Size(137, 22);
            _newTierMenuItem.Text = "New";
            _newTierMenuItem.Click += NewTier_MenuItem_Click;
            //
            // TGHImport_MenuItem
            //
            _tghImportMenuItem.Name = "_tghImportMenuItem";
            _tghImportMenuItem.Size = new Size(137, 22);
            _tghImportMenuItem.Text = "TGH Import";
            _tghImportMenuItem.Click += TGHImport_MenuItem_Click;
            //
            // MassImporter_MenuItem
            //
            _massImporterMenuItem.Name = "_massImporterMenuItem";
            _massImporterMenuItem.Size = new Size(167, 22);
            _massImporterMenuItem.Text = "Mass Importer";
            _massImporterMenuItem.Click += MassImporter_MenuItem_Click;
            //
            // LegacyImporter_MenuItem
            //
            _legacyImporterMenuItem.Enabled = false;
            _legacyImporterMenuItem.Name = "_legacyImporterMenuItem";
            _legacyImporterMenuItem.Size = new Size(167, 22);
            _legacyImporterMenuItem.Text = "Legacy Importer";
            _legacyImporterMenuItem.Click += LegacyImporter_MenuItem_Click;
            //
            // RecoverSonglist_MenuItem
            //
            _recoverSonglistMenuItem.Name = "_recoverSonglistMenuItem";
            _recoverSonglistMenuItem.Size = new Size(167, 22);
            _recoverSonglistMenuItem.Text = "Recover Songlist";
            _recoverSonglistMenuItem.Click += RecoverSonglist_MenuItem_Click;
            //
            // ManageGame_MenuItem
            //
            _manageGameMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _manageTiersMenuItem,
                _toolStripSeparator4,
                _tghSwitchMenuItem,
                _sghSwitchMenuItem,
                _toolStripSeparator11,
                _gameSettingsSwitchMenuItem,
                _restoreLastMenuItem,
                _restoreOriginalMenuItem,
                _toolStripSeparator7,
                _saveFileControlMenuItem,
                _texExplorerMenuItem,
                _fxSpeedBoostMenuItem
            });
            _manageGameMenuItem.Name = "_manageGameMenuItem";
            _manageGameMenuItem.Size = new Size(124, 20);
            _manageGameMenuItem.Text = "Game Management";
            //
            // ManageTiers_MenuItem
            //
            _manageTiersMenuItem.Name = "_manageTiersMenuItem";
            _manageTiersMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            _manageTiersMenuItem.Size = new Size(237, 22);
            _manageTiersMenuItem.Text = "Manage Tiers";
            _manageTiersMenuItem.Click += ManageTiers_MenuItem_Click;
            //
            // toolStripSeparator4
            //
            _toolStripSeparator4.Name = "_toolStripSeparator4";
            _toolStripSeparator4.Size = new Size(234, 6);
            //
            // TGHSwitch_MenuItem
            //
            _tghSwitchMenuItem.Name = "_tghSwitchMenuItem";
            _tghSwitchMenuItem.Size = new Size(237, 22);
            _tghSwitchMenuItem.Text = "TGH Tier Switch";
            _tghSwitchMenuItem.Click += TGHSwitch_MenuItem_Click;
            //
            // SGHSwitch_MenuItem
            //
            _sghSwitchMenuItem.Name = "_sghSwitchMenuItem";
            _sghSwitchMenuItem.Size = new Size(237, 22);
            _sghSwitchMenuItem.Text = "SGH Setlist Switch";
            _sghSwitchMenuItem.Click += SGHSwitch_MenuItem_Click;
            //
            // Bulk SGH switch
            //
            var bulkSghSwitchMenuItem = new ToolStripMenuItem
            {
                Name = "bulkSghSwitchMenuItem",
                Size = new Size(237, 22),
                Text = "Bulk add SGH setlists"
            };
            bulkSghSwitchMenuItem.Click += BulkSGHSwitch_MenuItem_Click;
            _manageGameMenuItem.DropDownItems.Add(bulkSghSwitchMenuItem);
            //
            // toolStripSeparator11
            //
            _toolStripSeparator11.Name = "_toolStripSeparator11";
            _toolStripSeparator11.Size = new Size(234, 6);
            //
            // GameSettingsSwitch_MenuItem
            //
            _gameSettingsSwitchMenuItem.Name = "_gameSettingsSwitchMenuItem";
            _gameSettingsSwitchMenuItem.Size = new Size(237, 22);
            _gameSettingsSwitchMenuItem.Text = "Game Settings Switch";
            _gameSettingsSwitchMenuItem.Click += GameSettingsSwitch_MenuItem_Click;
            //
            // RestoreLast_MenuItem
            //
            _restoreLastMenuItem.Name = "_restoreLastMenuItem";
            _restoreLastMenuItem.Size = new Size(237, 22);
            _restoreLastMenuItem.Text = "Restore Last Game Settings";
            _restoreLastMenuItem.Click += RestoreLast_MenuItem_Click;
            //
            // RestoreOriginal_MenuItem
            //
            _restoreOriginalMenuItem.Name = "_restoreOriginalMenuItem";
            _restoreOriginalMenuItem.Size = new Size(237, 22);
            _restoreOriginalMenuItem.Text = "Restore Original Game Settings";
            _restoreOriginalMenuItem.Click += RestoreOriginal_MenuItem_Click;
            //
            // toolStripSeparator7
            //
            _toolStripSeparator7.Name = "_toolStripSeparator7";
            _toolStripSeparator7.Size = new Size(234, 6);
            //
            // SaveFileControl_MenuItem
            //
            _saveFileControlMenuItem.Name = "_saveFileControlMenuItem";
            _saveFileControlMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            _saveFileControlMenuItem.Size = new Size(237, 22);
            _saveFileControlMenuItem.Text = "Save File Patcher";
            _saveFileControlMenuItem.Click += SaveFileControl_MenuItem_Click;
            //
            // TexExplorer_MenuItem
            //
            _texExplorerMenuItem.Name = "_texExplorerMenuItem";
            _texExplorerMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            _texExplorerMenuItem.Size = new Size(237, 22);
            _texExplorerMenuItem.Text = "Texture Explorer";
            _texExplorerMenuItem.Click += TexExplorer_MenuItem_Click;
            //
            // FxSpeedBoost_MenuItem
            //
            _fxSpeedBoostMenuItem.Name = "_fxSpeedBoostMenuItem";
            _fxSpeedBoostMenuItem.Size = new Size(237, 22);
            _fxSpeedBoostMenuItem.Text = "FX Speed Boost";
            _fxSpeedBoostMenuItem.Click += FxSpeedBoost_MenuItem_Click;
            //
            // ManageSongs_MenuItem
            //
            _manageSongsMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _songPropsMenuItem,
                _rebuildSongMenuItem,
                _silentGuitarMenuItem,
                _forceMp3ConversionMenuItem,
                _forceRb3MidConversionToolStripMenuItem,
                _deleteSongMenuItem,
                _removeSongToolStripMenuItem,
                _hideUnEditMenuItem,
                _hideUsedMenuItem,
                _byTitleMenuItem
            });
            _manageSongsMenuItem.Name = "_manageSongsMenuItem";
            _manageSongsMenuItem.Size = new Size(135, 20);
            _manageSongsMenuItem.Text = "Songlist Management";
            //
            // SongProps_MenuItem
            //
            _songPropsMenuItem.Name = "_songPropsMenuItem";
            _songPropsMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            _songPropsMenuItem.Size = new Size(221, 22);
            _songPropsMenuItem.Text = "Edit Song Properties";
            _songPropsMenuItem.Click += SongProps_MenuItem_Click;
            //
            // RebuildSong_MenuItem
            //
            _rebuildSongMenuItem.Name = "_rebuildSongMenuItem";
            _rebuildSongMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            _rebuildSongMenuItem.Size = new Size(221, 22);
            _rebuildSongMenuItem.Text = "Rebuild Song Data";
            _rebuildSongMenuItem.Click += RebuildSong_MenuItem_Click;
            //
            // SilentGuitar_MenuItem
            //
            _silentGuitarMenuItem.Name = "_silentGuitarMenuItem";
            _silentGuitarMenuItem.Size = new Size(221, 22);
            _silentGuitarMenuItem.Text = "Silent Guitar Track";
            _silentGuitarMenuItem.Click += SilentGuitar_MenuItem_Click;
            //
            // ForceMp3Conversion_MenuItem
            //
            _forceMp3ConversionMenuItem.Name = "_forceMp3ConversionMenuItem";
            _forceMp3ConversionMenuItem.Size = new Size(221, 22);
            _forceMp3ConversionMenuItem.Text = "Force Mp3 Conversion";
            _forceMp3ConversionMenuItem.Click += ForceMp3Conversion_MenuItem_Click;
            //
            // forceRB3MidConversionToolStripMenuItem
            //
            _forceRb3MidConversionToolStripMenuItem.CheckOnClick = true;
            _forceRb3MidConversionToolStripMenuItem.Name = "_forceRb3MidConversionToolStripMenuItem";
            _forceRb3MidConversionToolStripMenuItem.Size = new Size(221, 22);
            _forceRb3MidConversionToolStripMenuItem.Text = "Force RB3 Mid Conversion";
            _forceRb3MidConversionToolStripMenuItem.Click += forceRB3MidConversionToolStripMenuItem_Click;
            //
            // DeleteSong_MenuItem
            //
            _deleteSongMenuItem.Name = "_deleteSongMenuItem";
            _deleteSongMenuItem.Size = new Size(221, 22);
            _deleteSongMenuItem.Text = "Delete Song";
            _deleteSongMenuItem.Click += DeleteSong_MenuItem_Click;
            //
            // RemoveSong_ToolStripMenuItem
            //
            _removeSongToolStripMenuItem.Name = "_removeSongToolStripMenuItem";
            _removeSongToolStripMenuItem.Size = new Size(218, 6);
            //
            // HideUnEdit_MenuItem
            //
            _hideUnEditMenuItem.Name = "_hideUnEditMenuItem";
            _hideUnEditMenuItem.ShortcutKeys = Keys.Alt | Keys.O;
            _hideUnEditMenuItem.Size = new Size(221, 22);
            _hideUnEditMenuItem.Text = "Hide Original Songs";
            _hideUnEditMenuItem.Click += HideUnEdit_MenuItem_Click;
            //
            // HideUsed_MenuItem
            //
            _hideUsedMenuItem.Name = "_hideUsedMenuItem";
            _hideUsedMenuItem.ShortcutKeys = Keys.Alt | Keys.H;
            _hideUsedMenuItem.Size = new Size(221, 22);
            _hideUsedMenuItem.Text = "Hide Used Songs";
            _hideUsedMenuItem.Click += HideUsed_MenuItem_Click;
            //
            // ByTitle_MenuItem
            //
            _byTitleMenuItem.Name = "_byTitleMenuItem";
            _byTitleMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            _byTitleMenuItem.Size = new Size(221, 22);
            _byTitleMenuItem.Text = "Display By Title";
            _byTitleMenuItem.Click += ByTitle_MenuItem_Click;
            //
            // Help_MenuItem
            //
            _helpMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                _guideMenuItem,
                _scoreHeroMenuItem,
                _gh3FolderMenuItem,
                _toolStripSeparator3,
                _disclaimerMenuItem,
                _aboutMenuItem
            });
            _helpMenuItem.Name = "_helpMenuItem";
            _helpMenuItem.Size = new Size(44, 20);
            _helpMenuItem.Text = "Help";
            //
            // Guide_MenuItem
            //
            _guideMenuItem.Name = "_guideMenuItem";
            _guideMenuItem.ShortcutKeys = Keys.F1;
            _guideMenuItem.Size = new Size(154, 22);
            _guideMenuItem.Text = "Guide";
            _guideMenuItem.Click += Guide_MenuItem_Click;
            //
            // ScoreHero_MenuItem
            //
            _scoreHeroMenuItem.Name = "_scoreHeroMenuItem";
            _scoreHeroMenuItem.ShortcutKeys = Keys.F2;
            _scoreHeroMenuItem.Size = new Size(154, 22);
            _scoreHeroMenuItem.Text = "Score Hero";
            _scoreHeroMenuItem.Click += ScoreHero_MenuItem_Click;
            //
            // GH3Folder_MenuItem
            //
            _gh3FolderMenuItem.Name = "_gh3FolderMenuItem";
            _gh3FolderMenuItem.ShortcutKeys = Keys.F3;
            _gh3FolderMenuItem.Size = new Size(154, 22);
            _gh3FolderMenuItem.Text = "GH3 Folder";
            _gh3FolderMenuItem.Click += GH3Folder_MenuItem_Click;
            //
            // toolStripSeparator3
            //
            _toolStripSeparator3.Name = "_toolStripSeparator3";
            _toolStripSeparator3.Size = new Size(151, 6);
            //
            // Disclaimer_MenuItem
            //
            _disclaimerMenuItem.Name = "_disclaimerMenuItem";
            _disclaimerMenuItem.ShortcutKeys = Keys.F11;
            _disclaimerMenuItem.Size = new Size(154, 22);
            _disclaimerMenuItem.Text = "Disclaimer";
            _disclaimerMenuItem.Click += Disclaimer_MenuItem_Click;
            //
            // About_MenuItem
            //
            _aboutMenuItem.Name = "_aboutMenuItem";
            _aboutMenuItem.ShortcutKeys = Keys.F12;
            _aboutMenuItem.Size = new Size(154, 22);
            _aboutMenuItem.Text = "About";
            _aboutMenuItem.Click += About_MenuItem_Click;
            //
            // ActionRequests_ListBox
            //
            _actionRequestsListBox.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                             | AnchorStyles.Left)
                                            | AnchorStyles.Right;
            _actionRequestsListBox.FormattingEnabled = true;
            _actionRequestsListBox.IntegralHeight = false;
            _actionRequestsListBox.Location = new Point(0, 400);
            _actionRequestsListBox.Margin = new Padding(0);
            _actionRequestsListBox.Name = "_actionRequestsListBox";
            _actionRequestsListBox.ScrollAlwaysVisible = true;
            _actionRequestsListBox.Size = new Size(180, 119);
            _actionRequestsListBox.TabIndex = 3;
            //
            // label1
            //
            _label1.AutoSize = true;
            _label1.Dock = DockStyle.Fill;
            _label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label1.Location = new Point(3, 0);
            _label1.Name = "_label1";
            _label1.Size = new Size(174, 20);
            _label1.TabIndex = 4;
            _label1.Text = "Song List";
            _label1.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label3
            //
            _label3.AutoSize = true;
            _label3.Dock = DockStyle.Fill;
            _label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label3.Location = new Point(3, 375);
            _label3.Name = "_label3";
            _label3.Size = new Size(174, 25);
            _label3.TabIndex = 6;
            _label3.Text = "Action Request";
            _label3.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SidePanel
            //
            _sidePanel.ColumnCount = 1;
            _sidePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _sidePanel.Controls.Add(_actionRequestsListBox, 0, 3);
            _sidePanel.Controls.Add(_label1, 0, 0);
            _sidePanel.Controls.Add(_label3, 0, 2);
            _sidePanel.Controls.Add(_songListBox, 0, 1);
            _sidePanel.Dock = DockStyle.Left;
            _sidePanel.Location = new Point(0, 0);
            _sidePanel.Margin = new Padding(0);
            _sidePanel.MinimumSize = new Size(180, 500);
            _sidePanel.Name = "_sidePanel";
            _sidePanel.RowCount = 4;
            _sidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _sidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            _sidePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            _sidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            _sidePanel.Size = new Size(180, 519);
            _sidePanel.TabIndex = 7;
            //
            // _notifyIcon0
            //
            _notifyIcon0.Icon = ((Icon) (resources.GetObject("_notifyIcon0.Icon")));
            _notifyIcon0.Text = "Guitar Hero Three Control Panel+";
            _notifyIcon0.Visible = true;
            _notifyIcon0.MouseDown += notifyIcon_0_MouseDown;
            //
            // fontDialog_0
            //
            _fontDialog0.Color = Color.Red;
            _fontDialog0.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _fontDialog0.ShowColor = true;
            //
            // leftClickMenu
            //
            _leftClickMenu.Items.AddRange(new ToolStripItem[]
            {
                _sysEnglishMenuItem,
                _sysFrenchMenuItem,
                _sysItalianMenuItem,
                _sysSpanishMenuItem,
                _sysGermanMenuItem,
                _sysKoreanMenuItem
            });
            _leftClickMenu.Name = "_leftClickMenu";
            _leftClickMenu.Size = new Size(118, 136);
            //
            // SysEnglish_MenuItem
            //
            _sysEnglishMenuItem.Name = "_sysEnglishMenuItem";
            _sysEnglishMenuItem.ShowShortcutKeys = false;
            _sysEnglishMenuItem.Size = new Size(117, 22);
            _sysEnglishMenuItem.Tag = "en";
            _sysEnglishMenuItem.Text = "(English)";
            _sysEnglishMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysFrench_MenuItem
            //
            _sysFrenchMenuItem.Name = "_sysFrenchMenuItem";
            _sysFrenchMenuItem.ShowShortcutKeys = false;
            _sysFrenchMenuItem.Size = new Size(117, 22);
            _sysFrenchMenuItem.Tag = "fr";
            _sysFrenchMenuItem.Text = "(French)";
            _sysFrenchMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysItalian_MenuItem
            //
            _sysItalianMenuItem.Name = "_sysItalianMenuItem";
            _sysItalianMenuItem.ShowShortcutKeys = false;
            _sysItalianMenuItem.Size = new Size(117, 22);
            _sysItalianMenuItem.Tag = "it";
            _sysItalianMenuItem.Text = "(Italian)";
            _sysItalianMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysSpanish_MenuItem
            //
            _sysSpanishMenuItem.Name = "_sysSpanishMenuItem";
            _sysSpanishMenuItem.ShowShortcutKeys = false;
            _sysSpanishMenuItem.Size = new Size(117, 22);
            _sysSpanishMenuItem.Tag = "es";
            _sysSpanishMenuItem.Text = "(Spanish)";
            _sysSpanishMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysGerman_MenuItem
            //
            _sysGermanMenuItem.Name = "_sysGermanMenuItem";
            _sysGermanMenuItem.ShowShortcutKeys = false;
            _sysGermanMenuItem.Size = new Size(117, 22);
            _sysGermanMenuItem.Tag = "de";
            _sysGermanMenuItem.Text = "(German)";
            _sysGermanMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // SysKorean_MenuItem
            //
            _sysKoreanMenuItem.Name = "_sysKoreanMenuItem";
            _sysKoreanMenuItem.ShowShortcutKeys = false;
            _sysKoreanMenuItem.Size = new Size(117, 22);
            _sysKoreanMenuItem.Tag = "ko";
            _sysKoreanMenuItem.Text = "(Korean)";
            _sysKoreanMenuItem.Click += SysKorean_MenuItem_Click;
            //
            // MainContainer
            //
            //
            // MainContainer.BottomToolStripPanel
            //
            _mainContainer.BottomToolStripPanel.Controls.Add(_statusStrip);
            //
            // MainContainer.ContentPanel
            //
            _mainContainer.ContentPanel.Controls.Add(_tabControl);
            _mainContainer.ContentPanel.Controls.Add(_sidePanel);
            _mainContainer.ContentPanel.Size = new Size(784, 519);
            _mainContainer.Dock = DockStyle.Fill;
            _mainContainer.LeftToolStripPanelVisible = false;
            _mainContainer.Location = new Point(0, 0);
            _mainContainer.Name = "_mainContainer";
            _mainContainer.RightToolStripPanelVisible = false;
            _mainContainer.Size = new Size(784, 565);
            _mainContainer.TabIndex = 13;
            _mainContainer.Text = "toolStripContainer1";
            //
            // MainContainer.TopToolStripPanel
            //
            _mainContainer.TopToolStripPanel.Controls.Add(_topMenuStrip);
            //
            // StatusStrip
            //
            _statusStrip.Dock = DockStyle.None;
            _statusStrip.Items.AddRange(new ToolStripItem[]
            {
                _toolStripStatusLbl
            });
            _statusStrip.Location = new Point(0, 0);
            _statusStrip.Name = "StatusStrip";
            _statusStrip.Size = new Size(784, 22);
            _statusStrip.TabIndex = 0;
            //
            // ToolStripStatusLbl
            //
            _toolStripStatusLbl.Name = "_toolStripStatusLbl";
            _toolStripStatusLbl.Size = new Size(0, 17);
            _toolStripStatusLbl.Tag = "Function Description";
            //
            // TabControl
            //
            _tabControl.Controls.Add(_setlistTab);
            _tabControl.Controls.Add(_songEditorTab);
            _tabControl.Dock = DockStyle.Fill;
            _tabControl.HotTrack = true;
            _tabControl.Location = new Point(180, 0);
            _tabControl.Margin = new Padding(0);
            _tabControl.MinimumSize = new Size(600, 500);
            _tabControl.Name = "TabControl";
            _tabControl.SelectedIndex = 0;
            _tabControl.Size = new Size(604, 519);
            _tabControl.TabIndex = 8;
            //
            // SetlistTab
            //
            _setlistTab.Controls.Add(_setlistConfigContainer);
            _setlistTab.Location = new Point(4, 22);
            _setlistTab.Name = "_setlistTab";
            _setlistTab.Padding = new Padding(3);
            _setlistTab.Size = new Size(596, 493);
            _setlistTab.TabIndex = 0;
            _setlistTab.Text = "Setlist Configuration";
            _setlistTab.UseVisualStyleBackColor = true;
            //
            // SetlistConfig_Container
            //
            //
            // SetlistConfig_Container.ContentPanel
            //
            _setlistConfigContainer.ContentPanel.Controls.Add(_setlistConfTLPanel);
            _setlistConfigContainer.ContentPanel.Size = new Size(590, 462);
            _setlistConfigContainer.Dock = DockStyle.Fill;
            _setlistConfigContainer.Location = new Point(3, 3);
            _setlistConfigContainer.Name = "_setlistConfigContainer";
            _setlistConfigContainer.Size = new Size(590, 487);
            _setlistConfigContainer.TabIndex = 3;
            _setlistConfigContainer.Text = "Setlist Config Container";
            //
            // SetlistConfig_Container.TopToolStripPanel
            //
            _setlistConfigContainer.TopToolStripPanel.Controls.Add(_setlistStrip);
            //
            // SetlistConf_TLPanel
            //
            _setlistConfTLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            _setlistConfTLPanel.ColumnCount = 1;
            _setlistConfTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _setlistConfTLPanel.Controls.Add(_setlistTLPanel, 0, 0);
            _setlistConfTLPanel.Controls.Add(_tierTLPanel, 0, 1);
            _setlistConfTLPanel.Dock = DockStyle.Fill;
            _setlistConfTLPanel.Location = new Point(0, 0);
            _setlistConfTLPanel.Name = "_setlistConfTLPanel";
            _setlistConfTLPanel.RowCount = 2;
            _setlistConfTLPanel.RowStyles.Add(new RowStyle());
            _setlistConfTLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _setlistConfTLPanel.Size = new Size(590, 462);
            _setlistConfTLPanel.TabIndex = 2;
            //
            // Setlist_TLPanel
            //
            _setlistTLPanel.ColumnCount = 4;
            _setlistTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _setlistTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _setlistTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _setlistTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _setlistTLPanel.Controls.Add(_textBox3, 1, 2);
            _setlistTLPanel.Controls.Add(_label5, 3, 0);
            _setlistTLPanel.Controls.Add(_label4, 2, 0);
            _setlistTLPanel.Controls.Add(_tierBox, 3, 1);
            _setlistTLPanel.Controls.Add(_setlistInitMovieTxtBox, 2, 1);
            _setlistTLPanel.Controls.Add(_setlistPrefixTxtBox, 1, 1);
            _setlistTLPanel.Controls.Add(_label2, 0, 0);
            _setlistTLPanel.Controls.Add(_label13, 1, 0);
            _setlistTLPanel.Controls.Add(_setlistTitleTxtBox, 0, 1);
            _setlistTLPanel.Dock = DockStyle.Fill;
            _setlistTLPanel.Location = new Point(4, 4);
            _setlistTLPanel.Name = "_setlistTLPanel";
            _setlistTLPanel.RowCount = 3;
            _setlistTLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _setlistTLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            _setlistTLPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _setlistTLPanel.Size = new Size(582, 44);
            _setlistTLPanel.TabIndex = 0;
            //
            // textBox3
            //
            _textBox3.Dock = DockStyle.Fill;
            _textBox3.Location = new Point(148, 49);
            _textBox3.Name = "_textBox3";
            _textBox3.Size = new Size(139, 20);
            _textBox3.TabIndex = 7;
            //
            // label5
            //
            _label5.AutoSize = true;
            _label5.Dock = DockStyle.Fill;
            _label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label5.Location = new Point(438, 0);
            _label5.Name = "_label5";
            _label5.Size = new Size(141, 20);
            _label5.TabIndex = 5;
            _label5.Text = "Tiers";
            _label5.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label4
            //
            _label4.AutoSize = true;
            _label4.Dock = DockStyle.Fill;
            _label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label4.Location = new Point(293, 0);
            _label4.Name = "_label4";
            _label4.Size = new Size(139, 20);
            _label4.TabIndex = 4;
            _label4.Text = "Initial Movie";
            _label4.TextAlign = ContentAlignment.MiddleCenter;
            //
            // TierBox
            //
            _tierBox.Dock = DockStyle.Fill;
            _tierBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _tierBox.FormattingEnabled = true;
            _tierBox.Location = new Point(438, 23);
            _tierBox.Name = "_tierBox";
            _tierBox.Size = new Size(141, 21);
            _tierBox.TabIndex = 7;
            _tierBox.SelectedIndexChanged += TierBox_SelectedIndexChanged;
            //
            // SetlistInitMovie_TxtBox
            //
            _setlistInitMovieTxtBox.Dock = DockStyle.Fill;
            _setlistInitMovieTxtBox.Location = new Point(293, 23);
            _setlistInitMovieTxtBox.Name = "_setlistInitMovieTxtBox";
            _setlistInitMovieTxtBox.Size = new Size(139, 20);
            _setlistInitMovieTxtBox.TabIndex = 6;
            _setlistInitMovieTxtBox.TextChanged += SetlistTitle_TxtBox_TextChanged;
            //
            // SetlistPrefix_TxtBox
            //
            _setlistPrefixTxtBox.Dock = DockStyle.Fill;
            _setlistPrefixTxtBox.Enabled = false;
            _setlistPrefixTxtBox.Location = new Point(148, 23);
            _setlistPrefixTxtBox.Name = "_setlistPrefixTxtBox";
            _setlistPrefixTxtBox.Size = new Size(139, 20);
            _setlistPrefixTxtBox.TabIndex = 1;
            //
            // label2
            //
            _label2.AutoSize = true;
            _label2.Dock = DockStyle.Fill;
            _label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label2.Location = new Point(3, 0);
            _label2.Name = "_label2";
            _label2.Size = new Size(139, 20);
            _label2.TabIndex = 3;
            _label2.Text = "Title";
            _label2.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label13
            //
            _label13.AutoSize = true;
            _label13.Dock = DockStyle.Fill;
            _label13.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label13.Location = new Point(148, 0);
            _label13.Name = "_label13";
            _label13.Size = new Size(139, 20);
            _label13.TabIndex = 8;
            _label13.Text = "Prefix";
            _label13.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistTitle_TxtBox
            //
            _setlistTitleTxtBox.Dock = DockStyle.Fill;
            _setlistTitleTxtBox.Enabled = false;
            _setlistTitleTxtBox.Location = new Point(3, 23);
            _setlistTitleTxtBox.Name = "_setlistTitleTxtBox";
            _setlistTitleTxtBox.Size = new Size(139, 20);
            _setlistTitleTxtBox.TabIndex = 9;
            _setlistTitleTxtBox.TextChanged += SetlistTitle_TxtBox_TextChanged;
            //
            // Tier_TLPanel
            //
            _tierTLPanel.ColumnCount = 2;
            _tierTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tierTLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            _tierTLPanel.Controls.Add(_tierPropsPanel, 0, 0);
            _tierTLPanel.Controls.Add(_tierSongsPanel, 1, 0);
            _tierTLPanel.Dock = DockStyle.Fill;
            _tierTLPanel.Location = new Point(4, 55);
            _tierTLPanel.Name = "_tierTLPanel";
            _tierTLPanel.RowCount = 1;
            _tierTLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tierTLPanel.Size = new Size(582, 403);
            _tierTLPanel.TabIndex = 1;
            //
            // TierProps_Panel
            //
            _tierPropsPanel.Controls.Add(_tierUnlockedSetBtn);
            _tierPropsPanel.Controls.Add(_unlockAllCheckBox);
            _tierPropsPanel.Controls.Add(_noCashCheckBox);
            _tierPropsPanel.Controls.Add(_tierApplyBtn);
            _tierPropsPanel.Controls.Add(_label12);
            _tierPropsPanel.Controls.Add(_setlistApplyBtn);
            _tierPropsPanel.Controls.Add(_tierCompMovieTxtBox);
            _tierPropsPanel.Controls.Add(_tierUnlockedNumBox);
            _tierPropsPanel.Controls.Add(_tierTitleTxtBox);
            _tierPropsPanel.Controls.Add(_tierIconDropBox);
            _tierPropsPanel.Controls.Add(_tierStageDropBox);
            _tierPropsPanel.Controls.Add(_tierBossCheckBox);
            _tierPropsPanel.Controls.Add(_tierEncorep2CheckBox);
            _tierPropsPanel.Controls.Add(_tierEncorep1CheckBox);
            _tierPropsPanel.Controls.Add(_label10);
            _tierPropsPanel.Controls.Add(_label9);
            _tierPropsPanel.Controls.Add(_label8);
            _tierPropsPanel.Controls.Add(_label6);
            _tierPropsPanel.Controls.Add(_label7);
            _tierPropsPanel.Dock = DockStyle.Fill;
            _tierPropsPanel.Location = new Point(3, 3);
            _tierPropsPanel.Name = "_tierPropsPanel";
            _tierPropsPanel.Size = new Size(396, 397);
            _tierPropsPanel.TabIndex = 0;
            //
            // TierUnlockedSet_Btn
            //
            _tierUnlockedSetBtn.Font = new Font("Times New Roman", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _tierUnlockedSetBtn.Location = new Point(242, 55);
            _tierUnlockedSetBtn.Name = "_tierUnlockedSetBtn";
            _tierUnlockedSetBtn.Size = new Size(33, 20);
            _tierUnlockedSetBtn.TabIndex = 23;
            _tierUnlockedSetBtn.Text = "=";
            _tierUnlockedSetBtn.UseVisualStyleBackColor = true;
            _tierUnlockedSetBtn.Click += TierUnlockedSet_Btn_Click;
            //
            // UnlockAll_CheckBox
            //
            _unlockAllCheckBox.AutoSize = true;
            _unlockAllCheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _unlockAllCheckBox.Location = new Point(226, 168);
            _unlockAllCheckBox.Name = "_unlockAllCheckBox";
            _unlockAllCheckBox.Size = new Size(97, 23);
            _unlockAllCheckBox.TabIndex = 22;
            _unlockAllCheckBox.Text = "Unlock All";
            _unlockAllCheckBox.UseVisualStyleBackColor = true;
            _unlockAllCheckBox.Visible = false;
            _unlockAllCheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // NoCash_CheckBox
            //
            _noCashCheckBox.AutoSize = true;
            _noCashCheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _noCashCheckBox.Location = new Point(128, 168);
            _noCashCheckBox.Name = "_noCashCheckBox";
            _noCashCheckBox.Size = new Size(86, 23);
            _noCashCheckBox.TabIndex = 15;
            _noCashCheckBox.Text = "No Cash";
            _noCashCheckBox.UseVisualStyleBackColor = true;
            _noCashCheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierApply_Btn
            //
            _tierApplyBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _tierApplyBtn.Location = new Point(16, 255);
            _tierApplyBtn.Name = "_tierApplyBtn";
            _tierApplyBtn.Size = new Size(153, 27);
            _tierApplyBtn.TabIndex = 17;
            _tierApplyBtn.Text = "Apply Tier Changes";
            _tierApplyBtn.UseVisualStyleBackColor = true;
            _tierApplyBtn.Click += TierApply_Btn_Click;
            //
            // label12
            //
            _label12.AutoSize = true;
            _label12.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label12.Location = new Point(89, 5);
            _label12.Name = "_label12";
            _label12.Size = new Size(110, 19);
            _label12.TabIndex = 21;
            _label12.Text = "Tier Properties";
            _label12.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistApply_Btn
            //
            _setlistApplyBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _setlistApplyBtn.Location = new Point(175, 255);
            _setlistApplyBtn.Name = "_setlistApplyBtn";
            _setlistApplyBtn.Size = new Size(169, 27);
            _setlistApplyBtn.TabIndex = 18;
            _setlistApplyBtn.Text = "Apply Setlist Changes";
            _setlistApplyBtn.UseVisualStyleBackColor = true;
            _setlistApplyBtn.Click += SetlistApply_Btn_Click;
            //
            // TierCompMovie_TxtBox
            //
            _tierCompMovieTxtBox.Location = new Point(156, 84);
            _tierCompMovieTxtBox.Name = "_tierCompMovieTxtBox";
            _tierCompMovieTxtBox.Size = new Size(119, 20);
            _tierCompMovieTxtBox.TabIndex = 10;
            _tierCompMovieTxtBox.TextChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierUnlocked_NumBox
            //
            _tierUnlockedNumBox.Location = new Point(193, 55);
            _tierUnlockedNumBox.Maximum = new decimal(new[]
            {
                65536,
                0,
                0,
                0
            });
            _tierUnlockedNumBox.Name = "_tierUnlockedNumBox";
            _tierUnlockedNumBox.Size = new Size(43, 20);
            _tierUnlockedNumBox.TabIndex = 9;
            _tierUnlockedNumBox.ValueChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierTitle_TxtBox
            //
            _tierTitleTxtBox.Location = new Point(63, 26);
            _tierTitleTxtBox.Name = "_tierTitleTxtBox";
            _tierTitleTxtBox.Size = new Size(212, 20);
            _tierTitleTxtBox.TabIndex = 8;
            _tierTitleTxtBox.TextChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierIcon_DropBox
            //
            _tierIconDropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _tierIconDropBox.FormattingEnabled = true;
            _tierIconDropBox.Items.AddRange(new object[]
            {
                "No Icon"
            });
            _tierIconDropBox.Location = new Point(93, 112);
            _tierIconDropBox.Name = "_tierIconDropBox";
            _tierIconDropBox.Size = new Size(182, 21);
            _tierIconDropBox.TabIndex = 11;
            _tierIconDropBox.SelectedIndexChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierStage_DropBox
            //
            _tierStageDropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _tierStageDropBox.FormattingEnabled = true;
            _tierStageDropBox.Items.AddRange(new object[]
            {
                "No Preset Stage"
            });
            _tierStageDropBox.Location = new Point(70, 141);
            _tierStageDropBox.Name = "_tierStageDropBox";
            _tierStageDropBox.Size = new Size(205, 21);
            _tierStageDropBox.TabIndex = 12;
            _tierStageDropBox.SelectedIndexChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierBoss_CheckBox
            //
            _tierBossCheckBox.AutoSize = true;
            _tierBossCheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _tierBossCheckBox.Location = new Point(16, 168);
            _tierBossCheckBox.Name = "_tierBossCheckBox";
            _tierBossCheckBox.Size = new Size(106, 23);
            _tierBossCheckBox.TabIndex = 13;
            _tierBossCheckBox.Text = "Boss Battle";
            _tierBossCheckBox.UseVisualStyleBackColor = true;
            _tierBossCheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierEncorep2_CheckBox
            //
            _tierEncorep2CheckBox.AutoSize = true;
            _tierEncorep2CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _tierEncorep2CheckBox.Location = new Point(128, 197);
            _tierEncorep2CheckBox.Name = "_tierEncorep2CheckBox";
            _tierEncorep2CheckBox.Size = new Size(96, 23);
            _tierEncorep2CheckBox.TabIndex = 16;
            _tierEncorep2CheckBox.Text = "P2 Encore";
            _tierEncorep2CheckBox.UseVisualStyleBackColor = true;
            _tierEncorep2CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // TierEncorep1_CheckBox
            //
            _tierEncorep1CheckBox.AutoSize = true;
            _tierEncorep1CheckBox.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _tierEncorep1CheckBox.Location = new Point(16, 197);
            _tierEncorep1CheckBox.Name = "_tierEncorep1CheckBox";
            _tierEncorep1CheckBox.Size = new Size(96, 23);
            _tierEncorep1CheckBox.TabIndex = 14;
            _tierEncorep1CheckBox.Text = "P1 Encore";
            _tierEncorep1CheckBox.UseVisualStyleBackColor = true;
            _tierEncorep1CheckBox.CheckedChanged += TierEncorep1_CheckBox_CheckedChanged;
            //
            // label10
            //
            _label10.AutoSize = true;
            _label10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label10.Location = new Point(12, 140);
            _label10.Name = "_label10";
            _label10.Size = new Size(52, 19);
            _label10.TabIndex = 10;
            _label10.Text = "Stage:";
            _label10.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label9
            //
            _label9.AutoSize = true;
            _label9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label9.Location = new Point(12, 111);
            _label9.Name = "_label9";
            _label9.Size = new Size(75, 19);
            _label9.TabIndex = 9;
            _label9.Text = "Tier Icon:";
            _label9.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label8
            //
            _label8.AutoSize = true;
            _label8.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label8.Location = new Point(12, 83);
            _label8.Name = "_label8";
            _label8.Size = new Size(138, 19);
            _label8.TabIndex = 8;
            _label8.Text = "Completion Movie:";
            _label8.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label6
            //
            _label6.AutoSize = true;
            _label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label6.Location = new Point(12, 25);
            _label6.Name = "_label6";
            _label6.Size = new Size(45, 19);
            _label6.TabIndex = 7;
            _label6.Text = "Title:";
            _label6.TextAlign = ContentAlignment.MiddleCenter;
            //
            // label7
            //
            _label7.AutoSize = true;
            _label7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label7.Location = new Point(12, 55);
            _label7.Name = "_label7";
            _label7.Size = new Size(175, 19);
            _label7.TabIndex = 6;
            _label7.Text = "Default Unlocked Songs:";
            _label7.TextAlign = ContentAlignment.MiddleCenter;
            //
            // TierSongs_Panel
            //
            _tierSongsPanel.ColumnCount = 1;
            _tierSongsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tierSongsPanel.Controls.Add(_tierSongsListBox, 0, 1);
            _tierSongsPanel.Controls.Add(_label11, 0, 0);
            _tierSongsPanel.Dock = DockStyle.Fill;
            _tierSongsPanel.Location = new Point(405, 3);
            _tierSongsPanel.Name = "_tierSongsPanel";
            _tierSongsPanel.RowCount = 2;
            _tierSongsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _tierSongsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tierSongsPanel.Size = new Size(174, 397);
            _tierSongsPanel.TabIndex = 1;
            //
            // label11
            //
            _label11.AutoSize = true;
            _label11.Dock = DockStyle.Fill;
            _label11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _label11.Location = new Point(3, 0);
            _label11.Name = "_label11";
            _label11.Size = new Size(168, 20);
            _label11.TabIndex = 5;
            _label11.Text = "Tier Songs";
            _label11.TextAlign = ContentAlignment.MiddleCenter;
            //
            // SetlistStrip
            //
            _setlistStrip.Dock = DockStyle.None;
            _setlistStrip.GripStyle = ToolStripGripStyle.Hidden;
            _setlistStrip.Items.AddRange(new ToolStripItem[]
            {
                _setlistLbl,
                _setlistDropBox,
                _createSetlistBtn,
                _deleteSetlistBtn
            });
            _setlistStrip.Location = new Point(0, 0);
            _setlistStrip.Name = "_setlistStrip";
            _setlistStrip.Size = new Size(590, 25);
            _setlistStrip.Stretch = true;
            _setlistStrip.TabIndex = 0;
            _setlistStrip.Text = "toolStrip1";
            //
            // Setlist_Lbl
            //
            _setlistLbl.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            _setlistLbl.Name = "_setlistLbl";
            _setlistLbl.Size = new Size(56, 22);
            _setlistLbl.Text = "Setlist:";
            //
            // Setlist_DropBox
            //
            _setlistDropBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _setlistDropBox.Name = "_setlistDropBox";
            _setlistDropBox.Size = new Size(121, 25);
            _setlistDropBox.SelectedIndexChanged += Setlist_DropBox_SelectedIndexChanged;
            //
            // CreateSetlist_Btn
            //
            _createSetlistBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _createSetlistBtn.ImageTransparentColor = Color.Magenta;
            _createSetlistBtn.Name = "_createSetlistBtn";
            _createSetlistBtn.Size = new Size(79, 22);
            _createSetlistBtn.Text = "Create Setlist";
            _createSetlistBtn.Click += CreateSetlist_Btn_Click;
            //
            // DeleteSetlist_Btn
            //
            _deleteSetlistBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _deleteSetlistBtn.ImageTransparentColor = Color.Magenta;
            _deleteSetlistBtn.Name = "_deleteSetlistBtn";
            _deleteSetlistBtn.Size = new Size(78, 22);
            _deleteSetlistBtn.Text = "Delete Setlist";
            _deleteSetlistBtn.Click += DeleteSetlist_Btn_Click;
            //
            // SongEditorTab
            //
            _songEditorTab.AccessibleRole = AccessibleRole.None;
            _songEditorTab.Controls.Add(_songEditorContainer);
            _songEditorTab.Location = new Point(4, 22);
            _songEditorTab.Name = "_songEditorTab";
            _songEditorTab.Padding = new Padding(3);
            _songEditorTab.Size = new Size(596, 493);
            _songEditorTab.TabIndex = 1;
            _songEditorTab.Text = "Song Editor";
            _songEditorTab.UseVisualStyleBackColor = true;
            //
            // SongEditor_Container
            //
            //
            // SongEditor_Container.BottomToolStripPanel
            //
            _songEditorContainer.BottomToolStripPanel.Controls.Add(_songEditorBottomToolStrip);
            //
            // SongEditor_Container.ContentPanel
            //
            _songEditorContainer.ContentPanel.Controls.Add(_songEditorControl);
            _songEditorContainer.ContentPanel.Size = new Size(590, 437);
            _songEditorContainer.Dock = DockStyle.Fill;
            _songEditorContainer.Location = new Point(3, 3);
            _songEditorContainer.Name = "_songEditorContainer";
            _songEditorContainer.Size = new Size(590, 487);
            _songEditorContainer.TabIndex = 1;
            _songEditorContainer.Text = "SongEditor Container";
            //
            // SongEditor_Container.TopToolStripPanel
            //
            _songEditorContainer.TopToolStripPanel.Controls.Add(_songEditorTopToolStrip);
            //
            // SongEditor_BottomToolStrip
            //
            _songEditorBottomToolStrip.Dock = DockStyle.None;
            _songEditorBottomToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            _songEditorBottomToolStrip.Items.AddRange(new ToolStripItem[]
            {
                _toggleElementsEditorSplitBtn,
                _toolStripSeparator10,
                _toolStripLabel1,
                _beatSizeEditorTxtBox,
                _hyperSpeedEditorBar,
                _fretAngleEditorBar,
                _toolStripSeparator12,
                _toolStripLabel2,
                _offsetEditorTxtBox
            });
            _songEditorBottomToolStrip.Location = new Point(0, 0);
            _songEditorBottomToolStrip.Name = "_songEditorBottomToolStrip";
            _songEditorBottomToolStrip.Size = new Size(590, 25);
            _songEditorBottomToolStrip.Stretch = true;
            _songEditorBottomToolStrip.TabIndex = 0;
            //
            // ToggleElements_EditorSplitBtn
            //
            _toggleElementsEditorSplitBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _toggleElementsEditorSplitBtn.DropDownItems.AddRange(new ToolStripItem[]
            {
                _starViewEditorBtn,
                _hopoViewEditorBtn,
                _audioViewEditorBtn
            });
            _toggleElementsEditorSplitBtn.ImageTransparentColor = Color.Magenta;
            _toggleElementsEditorSplitBtn.Name = "_toggleElementsEditorSplitBtn";
            _toggleElementsEditorSplitBtn.Size = new Size(111, 22);
            _toggleElementsEditorSplitBtn.Text = "Toggle Elements";
            _toggleElementsEditorSplitBtn.ButtonClick += ToggleElements_EditorSplitBtn_ButtonClick;
            //
            // StarView_EditorBtn
            //
            _starViewEditorBtn.Checked = true;
            _starViewEditorBtn.CheckOnClick = true;
            _starViewEditorBtn.CheckState = CheckState.Checked;
            _starViewEditorBtn.Name = "_starViewEditorBtn";
            _starViewEditorBtn.Size = new Size(130, 22);
            _starViewEditorBtn.Text = "Star Power";
            _starViewEditorBtn.Click += StarView_EditorBtn_Click;
            //
            // HopoView_EditorBtn
            //
            _hopoViewEditorBtn.Checked = true;
            _hopoViewEditorBtn.CheckOnClick = true;
            _hopoViewEditorBtn.CheckState = CheckState.Checked;
            _hopoViewEditorBtn.Name = "_hopoViewEditorBtn";
            _hopoViewEditorBtn.Size = new Size(130, 22);
            _hopoViewEditorBtn.Text = "HoPo";
            _hopoViewEditorBtn.Click += HopoView_EditorBtn_Click;
            //
            // AudioView_EditorBtn
            //
            _audioViewEditorBtn.Checked = true;
            _audioViewEditorBtn.CheckOnClick = true;
            _audioViewEditorBtn.CheckState = CheckState.Checked;
            _audioViewEditorBtn.Name = "_audioViewEditorBtn";
            _audioViewEditorBtn.Size = new Size(130, 22);
            _audioViewEditorBtn.Text = "Audio";
            _audioViewEditorBtn.Click += AudioView_EditorBtn_Click;
            //
            // toolStripSeparator10
            //
            _toolStripSeparator10.Name = "_toolStripSeparator10";
            _toolStripSeparator10.Size = new Size(6, 25);
            //
            // toolStripLabel1
            //
            _toolStripLabel1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            _toolStripLabel1.Name = "_toolStripLabel1";
            _toolStripLabel1.Size = new Size(77, 22);
            _toolStripLabel1.Text = "Beat Size:";
            //
            // BeatSize_EditorTxtBox
            //
            _beatSizeEditorTxtBox.Name = "_beatSizeEditorTxtBox";
            _beatSizeEditorTxtBox.Size = new Size(30, 25);
            _beatSizeEditorTxtBox.Text = "20";
            _beatSizeEditorTxtBox.TextChanged += BeatSize_EditorTxtBox_TextChanged;
            //
            // toolStripSeparator12
            //
            _toolStripSeparator12.Name = "_toolStripSeparator12";
            _toolStripSeparator12.Size = new Size(6, 25);
            //
            // toolStripLabel2
            //
            _toolStripLabel2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            _toolStripLabel2.Name = "_toolStripLabel2";
            _toolStripLabel2.Size = new Size(56, 22);
            _toolStripLabel2.Text = "Offset:";
            //
            // Offset_EditorTxtBox
            //
            _offsetEditorTxtBox.Name = "_offsetEditorTxtBox";
            _offsetEditorTxtBox.Size = new Size(50, 25);
            _offsetEditorTxtBox.Text = "20";
            _offsetEditorTxtBox.TextChanged += Offset_EditorTxtBox_TextChanged;
            //
            // SongEditor_TopToolStrip
            //
            _songEditorTopToolStrip.Dock = DockStyle.None;
            _songEditorTopToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            _songEditorTopToolStrip.Items.AddRange(new ToolStripItem[]
            {
                _gameModeEditorBtn,
                _toolStripSeparator5,
                _loadChartEditorBtn,
                _selectedTrackEditorBox,
                _songNameEditorLbl,
                _toolStripSeparator2,
                _loadAudioEditorBtn,
                _playPauseEditorBtn,
                _stopEditorBtn,
                _playTimeEditorLbl
            });
            _songEditorTopToolStrip.Location = new Point(0, 0);
            _songEditorTopToolStrip.Name = "_songEditorTopToolStrip";
            _songEditorTopToolStrip.Size = new Size(590, 25);
            _songEditorTopToolStrip.Stretch = true;
            _songEditorTopToolStrip.TabIndex = 0;
            //
            // GameMode_EditorBtn
            //
            _gameModeEditorBtn.Checked = true;
            _gameModeEditorBtn.CheckOnClick = true;
            _gameModeEditorBtn.CheckState = CheckState.Checked;
            _gameModeEditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _gameModeEditorBtn.ImageTransparentColor = Color.Magenta;
            _gameModeEditorBtn.Name = "_gameModeEditorBtn";
            _gameModeEditorBtn.Size = new Size(76, 22);
            _gameModeEditorBtn.Text = "Game Mode";
            _gameModeEditorBtn.Click += GameMode_EditorBtn_Click;
            //
            // toolStripSeparator5
            //
            _toolStripSeparator5.Name = "_toolStripSeparator5";
            _toolStripSeparator5.Size = new Size(6, 25);
            //
            // LoadChart_EditorBtn
            //
            _loadChartEditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _loadChartEditorBtn.ImageTransparentColor = Color.Magenta;
            _loadChartEditorBtn.Name = "_loadChartEditorBtn";
            _loadChartEditorBtn.Size = new Size(69, 22);
            _loadChartEditorBtn.Text = "Load Chart";
            _loadChartEditorBtn.Click += LoadChart_EditorBtn_Click;
            //
            // SelectedTrack_EditorBox
            //
            _selectedTrackEditorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _selectedTrackEditorBox.Name = "_selectedTrackEditorBox";
            _selectedTrackEditorBox.Size = new Size(100, 25);
            _selectedTrackEditorBox.SelectedIndexChanged += SelectedTrack_EditorBox_SelectedIndexChanged;
            //
            // SongName_EditorLbl
            //
            _songNameEditorLbl.Name = "_songNameEditorLbl";
            _songNameEditorLbl.Size = new Size(69, 22);
            _songNameEditorLbl.Text = "Song Name";
            //
            // toolStripSeparator2
            //
            _toolStripSeparator2.Name = "_toolStripSeparator2";
            _toolStripSeparator2.Size = new Size(6, 25);
            //
            // LoadAudio_EditorBtn
            //
            _loadAudioEditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _loadAudioEditorBtn.ImageTransparentColor = Color.Magenta;
            _loadAudioEditorBtn.Name = "_loadAudioEditorBtn";
            _loadAudioEditorBtn.Size = new Size(72, 22);
            _loadAudioEditorBtn.Text = "Load Audio";
            _loadAudioEditorBtn.Click += LoadAudio_EditorBtn_Click;
            //
            // PlayPause_EditorBtn
            //
            _playPauseEditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _playPauseEditorBtn.ImageTransparentColor = Color.Magenta;
            _playPauseEditorBtn.Name = "_playPauseEditorBtn";
            _playPauseEditorBtn.Size = new Size(69, 22);
            _playPauseEditorBtn.Text = "Play/Pause";
            _playPauseEditorBtn.Click += PlayPause_EditorBtn_Click;
            //
            // Stop_EditorBtn
            //
            _stopEditorBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _stopEditorBtn.ImageTransparentColor = Color.Magenta;
            _stopEditorBtn.Name = "_stopEditorBtn";
            _stopEditorBtn.Size = new Size(35, 22);
            _stopEditorBtn.Text = "Stop";
            _stopEditorBtn.Click += Stop_EditorBtn_Click;
            //
            // PlayTime_EditorLbl
            //
            _playTimeEditorLbl.Name = "_playTimeEditorLbl";
            _playTimeEditorLbl.Size = new Size(59, 22);
            _playTimeEditorLbl.Text = "Play Time";
            //
            // TierSongs_ListBox
            //
            _tierSongsListBox.AllowDrop = true;
            _tierSongsListBox.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                                        | AnchorStyles.Left)
                                       | AnchorStyles.Right;
            _tierSongsListBox.FormattingEnabled = true;
            _tierSongsListBox.IntegralHeight = false;
            _tierSongsListBox.Location = new Point(0, 20);
            _tierSongsListBox.Margin = new Padding(0);
            _tierSongsListBox.Name = "_tierSongsListBox";
            _tierSongsListBox.ScrollAlwaysVisible = true;
            _tierSongsListBox.SelectionMode = SelectionMode.MultiExtended;
            _tierSongsListBox.Size = new Size(174, 377);
            _tierSongsListBox.TabIndex = 19;
            _tierSongsListBox.KeyDown += TierSongs_ListBox_KeyDown;
            _tierSongsListBox.MouseDown += TierSongs_ListBox_MouseDown;
            //
            // HyperSpeed_EditorBar
            //
            _hyperSpeedEditorBar.Name = "_hyperSpeedEditorBar";
            _hyperSpeedEditorBar.Size = new Size(104, 22);
            _hyperSpeedEditorBar.ToolTipText = "HyperSpeed";
            //
            // FretAngle_EditorBar
            //
            _fretAngleEditorBar.Name = "_fretAngleEditorBar";
            _fretAngleEditorBar.Size = new Size(104, 22);
            _fretAngleEditorBar.ToolTipText = "FretBar Angle";
            //
            // SongEditor_Control
            //
            _songEditorControl.BackColor = Color.White;
            _songEditorControl.Dock = DockStyle.Fill;
            _songEditorControl.Location = new Point(0, 0);
            _songEditorControl.Name = "_songEditorControl";
            _songEditorControl.Size = new Size(590, 437);
            _songEditorControl.TabIndex = 0;
            //
            // SongListBox
            //
            _songListBox.AllowDrop = true;
            _songListBox.Dock = DockStyle.Fill;
            _songListBox.FormattingEnabled = true;
            _songListBox.IntegralHeight = false;
            _songListBox.Location = new Point(0, 20);
            _songListBox.Margin = new Padding(0);
            _songListBox.Name = "_songListBox";
            _songListBox.ScrollAlwaysVisible = true;
            _songListBox.SelectionMode = SelectionMode.MultiExtended;
            _songListBox.Size = new Size(180, 355);
            _songListBox.Sorted = true;
            _songListBox.TabIndex = 1;
            _songListBox.SelectedIndexChanged += SongListBox_SelectedIndexChanged;
            _songListBox.KeyDown += SongListBox_KeyDown;
            _songListBox.MouseDown += SongListBox_MouseDown;
            //
            // MainMenu
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 565);
            Controls.Add(_mainContainer);
            DoubleBuffered = true;
            Icon = ((Icon) (resources.GetObject("$this.Icon")));
            MainMenuStrip = _topMenuStrip;
            MinimumSize = new Size(800, 600);
            Name = "MainMenu";
            Text = "Guitar Hero Three Control Panel+";
            FormClosing += MainMenu_FormClosing;
            SizeChanged += MainMenu_SizeChanged;
            _rightClickMenu.ResumeLayout(false);
            _topMenuStrip.ResumeLayout(false);
            _topMenuStrip.PerformLayout();
            _sidePanel.ResumeLayout(false);
            _sidePanel.PerformLayout();
            _leftClickMenu.ResumeLayout(false);
            _mainContainer.BottomToolStripPanel.ResumeLayout(false);
            _mainContainer.BottomToolStripPanel.PerformLayout();
            _mainContainer.ContentPanel.ResumeLayout(false);
            _mainContainer.TopToolStripPanel.ResumeLayout(false);
            _mainContainer.TopToolStripPanel.PerformLayout();
            _mainContainer.ResumeLayout(false);
            _mainContainer.PerformLayout();
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            _tabControl.ResumeLayout(false);
            _setlistTab.ResumeLayout(false);
            _setlistConfigContainer.ContentPanel.ResumeLayout(false);
            _setlistConfigContainer.TopToolStripPanel.ResumeLayout(false);
            _setlistConfigContainer.TopToolStripPanel.PerformLayout();
            _setlistConfigContainer.ResumeLayout(false);
            _setlistConfigContainer.PerformLayout();
            _setlistConfTLPanel.ResumeLayout(false);
            _setlistTLPanel.ResumeLayout(false);
            _setlistTLPanel.PerformLayout();
            _tierTLPanel.ResumeLayout(false);
            _tierPropsPanel.ResumeLayout(false);
            _tierPropsPanel.PerformLayout();
            ((ISupportInitialize) (_tierUnlockedNumBox)).EndInit();
            _tierSongsPanel.ResumeLayout(false);
            _tierSongsPanel.PerformLayout();
            _setlistStrip.ResumeLayout(false);
            _setlistStrip.PerformLayout();
            _songEditorTab.ResumeLayout(false);
            _songEditorContainer.BottomToolStripPanel.ResumeLayout(false);
            _songEditorContainer.BottomToolStripPanel.PerformLayout();
            _songEditorContainer.ContentPanel.ResumeLayout(false);
            _songEditorContainer.TopToolStripPanel.ResumeLayout(false);
            _songEditorContainer.TopToolStripPanel.PerformLayout();
            _songEditorContainer.ResumeLayout(false);
            _songEditorContainer.PerformLayout();
            _songEditorBottomToolStrip.ResumeLayout(false);
            _songEditorBottomToolStrip.PerformLayout();
            _songEditorTopToolStrip.ResumeLayout(false);
            _songEditorTopToolStrip.PerformLayout();
            ResumeLayout(false);
        }

        private void BulkSGHSwitch_MenuItem_Click(object sender, EventArgs e)
        {

            var dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select the setlists to import",
                Filter = "GH3CP Setlist Files|*.sgh"
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.Cancel || result == DialogResult.No)
            {
                return;
            }
            //var text = @"C:\Users\Rafael\Downloads\guitar hero 3 setlists\more\impossibleshit.sgh";

            var files = dialog.FileNames;

            foreach (var text in files)
            {
                CreateSetlist_Btn_Click(sender,e);
                _setlistDropBox.SelectedIndex = _setlistDropBox.Items.Count-1;
                //Setlist_DropBox_SelectedIndexChanged(sender, e);
                //SGHSwitch_MenuItem_Click
                if (!_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
                {
                    MessageBox.Show("Something weird happened: setlistlist does not contain selected setlist.");
                    return;
                }

                var gH3Setlist = new Gh3Setlist();
                try
                {
                    var sghManager = /*DialogResult.Yes ==
                                     MessageBox.Show(
                                         "Do you wish to import all contained song data (Music & Game Tracks)? Data and properties will be overwritten!",
                                         "Setlist Switching", MessageBoxButtons.YesNo)
                        ? */new SghManager(_gh3Songlist, gH3Setlist, text, _dataFolder)
    /*                    : new SghManager(_gh3Songlist, gH3Setlist, text)*/;

                    sghManager.ImportSGH();
                    _tierBox.Items.Clear();
                    _tierBox.Items.AddRange(gH3Setlist.Tiers.ToArray());
                    if (_tierBox.Items.Count != 0)
                    {
                        _tierBox.SelectedIndex = 0;
                    }
                    else
                    {
                        method_23();
                    }
                    _setlistTitleTxtBox.Text = KeyGenerator.GetFileName(text, 1);
                    _setlistApplyBtn.Enabled = true;
                    method_4(new Class247(Class3190, _gh3Songlist));
                    RefreshSongListBox();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("File not compatible! Setlist Switch failed.\n" + exception, "Setlist Switching");
                }

                SetlistApply_Btn_Click(sender, e);
                // SetlistApply_Btn_Click
            }
        }

        private void LoadMore()
        {
            _tierSongsListBox.method_0("Songs");
            _tierSongsListBox.method_1(false);
            _tierSongsListBox.method_6(method_21);
            _songListBox.method_0("Songs");
            _songListBox.method_4(false);
            _songListBox.method_2(false);
            _songListBox.method_5(false);
            _songEditorControl.Set5NoteLines(false);
            _songEditorControl.SetFretboardAngle(0);
            _songEditorControl.SetGamemodeView(true);
            _songEditorControl.SetHyperspeed(1);
            _songEditorControl.SetDoubleFretbarWidth(false);
            _songEditorControl.method_29(method_1);
        }

        // Disables majority of interface before opening game settings
        private void method_12(bool bool1)
        {
            ToolStripItem arg_1F0 = _saveChartMenuItem;
            ToolStripItem arg190 = _rebuildSongMenuItem;
            _deleteSongMenuItem.Enabled = false;
            arg190.Enabled = false;
            arg_1F0.Enabled = false;
            ToolStripItem argB30 = _addMenuItem;
            ToolStripItem argAc0 = _manageGameMenuItem;
            ToolStripItem argA20 = _manageSongsMenuItem;
            ToolStripItem arg980 = _executeActionsMenuItem;
            ToolStripItem arg_8E0 = _clearActionsMenuItem;
            ToolStripItem arg840 = _saveSghMenuItem;
            ToolStripItem export = _exportSetlistAsChartsToolStripMenuItem;
            ToolStripItem arg_7B0 = _saveTghMenuItem;
            Control arg730 = _setlistStrip;
            Control arg_6B0 = _setlistConfTLPanel;
            _gh3FolderMenuItem.Enabled = bool1;
            arg_6B0.Enabled = bool1;
            arg730.Enabled = bool1;
            arg_7B0.Enabled = bool1;
            arg840.Enabled = bool1;
            arg_8E0.Enabled = bool1;
            arg980.Enabled = bool1;
            argA20.Enabled = bool1;
            argAc0.Enabled = bool1;
            argB30.Enabled = bool1;
            export.Enabled = bool1;
            _exportSongListToolStripMenuItem.Enabled = bool1;
            _exportSongListToolStripMenuItem1.Enabled = bool1;
        }

        public void InitializeLanguageList()
        {
            var registryKey = Registry.LocalMachine.CreateSubKey(_ghtcpRegistry);
            string[] array =
            {
                "English",
                "French",
                "Italian",
                "Spanish",
                "German",
                "Korean"
            };
            for (var i = 0; i < array.Length; i++)
            {
                registryKey.SetValue(array[i], _languageList[i]);
            }
            _sysEnglishMenuItem.Text = _languageList[0];
            _sysFrenchMenuItem.Text = _languageList[1];
            _sysItalianMenuItem.Text = _languageList[2];
            _sysSpanishMenuItem.Text = _languageList[3];
            _sysGermanMenuItem.Text = _languageList[4];
            _sysKoreanMenuItem.Text = _languageList[5];
        }

        private void OpenGameSettings_MenuItem_Click(object sender, EventArgs e)
        {
            LoadCurrentGameSettings(false);
        }

        private void RecoverGameSettings_MenuItem_Click(object sender, EventArgs e)
        {
            LoadCurrentGameSettings(true);
        }

        private void LoadCurrentGameSettings(bool bool1)
        {
            var loadGameSettings = new LoadGameSettings(_languageList);
            if (loadGameSettings.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            method_15();
            _languageList = loadGameSettings.method_2();
            InitializeLanguageList();
            try
            {
                var registryKey = Registry.LocalMachine.OpenSubKey(_gameRegistry);
                _dataFolder = (string) registryKey.GetValue("Path") + "\\DATA\\";
                if (!Directory.Exists(_dataFolder))
                {
                    throw new Exception();
                }
            }
            catch
            {
                var text = KeyGenerator.OpenOrSaveFile("Find Guitar Hero " + (_isAerosmith ? "Aerosmith" : "3"),
                    _isAerosmith
                        ? "Guitar Hero Aerosmith Executable|Guitar Hero Aerosmith.exe"
                        : "Guitar Hero 3 Executable|GH3.exe", true);
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                try
                {
                    _dataFolder = new FileInfo(text).Directory.FullName;
                    var registryKey = Registry.LocalMachine.CreateSubKey(_gameRegistry);
                    registryKey.SetValue("Path", _dataFolder);
                    _dataFolder += "\\DATA\\";
                }
                catch
                {
                    MessageBox.Show(
                        "Guitar Hero " + (_isAerosmith ? "Aerosmith" : "3") +
                        " is not installed properly on this computer.", "Error!");
                    return;
                }
            }
            var text2 = _list0[loadGameSettings.method_3()];
            var int_ = loadGameSettings.method_3();
            using (new Class217("QB Parse Operations"))
            {
                try
                {
                    if (!method_16(int_) && DialogResult.Yes ==
                        MessageBox.Show(
                            "A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)",
                            "Loading Game Settings", MessageBoxButtons.YesNo) && !method_17(int_))
                    {
                        return;
                    }
                    var class2 = new ZzPabNode(
                        string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pak.xen"),
                        string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pab.xen"), false);
                    Gh3Songlist gH3Songlist = null;
                    using (Class3190 = new ZzPabNode(_dataFolder + "PAK\\qb" + text2 + ".pak.xen",
                        _dataFolder + "PAK\\qb" + text2 + ".pab.xen", false))
                    {
                        if (method_19(int_).GameSettingsAreValid())
                        {
                            if (!bool1)
                            {
                                goto IL_478;
                            }
                        }
                        try
                        {
                            gH3Songlist = new Gh3Songlist(Class3190.ZzGetNode1("scripts\\guitar\\songlist.qb"),
                                new Gh3Songlist(class2.ZzGetNode1("scripts\\guitar\\songlist.qb"), null));
                            new ZzSetListParser(Class3190, gH3Songlist, _isAerosmith).method_0();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        Class3190.Dispose();
                        Class3190 = null;
                        if (gH3Songlist != null)
                        {
                            var dialogResult =
                                MessageBox.Show(
                                    "Game Settings files are not compatible, but something can be recovered. Do you wish to recover when starting from backup? (Overwriting!)",
                                    "Loading Game Settings", MessageBoxButtons.YesNoCancel);
                            if (dialogResult == DialogResult.Cancel)
                            {
                                return;
                            }
                            if (dialogResult == DialogResult.No)
                            {
                                gH3Songlist = null;
                            }
                        }
                        else if (DialogResult.No ==
                                 MessageBox.Show(
                                     "Game Settings files are not compatible, and nothing can be recovered. Do you wish to start from backup? (Overwriting!)",
                                     "Loading Game Settings", MessageBoxButtons.YesNo))
                        {
                            return;
                        }
                        if (!method_16(int_))
                        {
                            return;
                        }
                        KeyGenerator.smethod_19(_dataFolder + "PAK\\qb" + text2 + ".pab.xen",
                            string.Concat(_appDirectory, _backupName, "lastedited\\qb", text2, ".pab.xen"), true);
                        KeyGenerator.smethod_19(_dataFolder + "PAK\\qb" + text2 + ".pak.xen",
                            string.Concat(_appDirectory, _backupName, "lastedited\\qb", text2, ".pak.xen"), true);
                        KeyGenerator.smethod_19(
                            string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pab.xen"),
                            _dataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
                        KeyGenerator.smethod_19(
                            string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pak.xen"),
                            _dataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
                        IL_478:
                        ;
                    }
                    Class3190 = new ZzPabNode(_dataFolder + "PAK\\qb" + text2 + ".pak.xen",
                        _dataFolder + "PAK\\qb" + text2 + ".pab.xen", false);
                    method_20(int_);
                    _gh3Songlist = new Gh3Songlist(Class3190.ZzGetNode1("scripts\\guitar\\songlist.qb"),
                        new Gh3Songlist(class2.ZzGetNode1("scripts\\guitar\\songlist.qb"), null));
                    class2.Dispose();
                    var flag = false;
                    if (gH3Songlist != null)
                    {
                        foreach (var current in gH3Songlist.Keys)
                        {
                            if (!_gh3Songlist.method_3(current))
                            {
                                _gh3Songlist.Add(gH3Songlist[current]);
                                flag = true;
                            }
                        }
                    }
                    if (flag)
                    {
                        method_4(new Class247(Class3190, _gh3Songlist));
                    }
                    new CustomMenuCreator(Class3190, _isAerosmith).method_0();
                    new ZzSetListParser(Class3190, _gh3Songlist, _isAerosmith).method_0();
                    if (flag && gH3Songlist.Gh3SetlistList.Count != 0)
                    {
                        var flag2 = false;
                        using (var enumerator2 = gH3Songlist.Gh3SetlistList.Keys.GetEnumerator())
                        {
                            IL_78C:
                            while (enumerator2.MoveNext())
                            {
                                var current2 = enumerator2.Current;
                                var gH3Setlist = gH3Songlist.Gh3SetlistList[current2];
                                if (gH3Setlist.method_4())
                                {
                                    try
                                    {
                                        /*if (this.gh3Songlist_0.CustomBitMask == -1)
                                        {
                                            break;
                                        }*/
                                        for (var i = 0;;)
                                        {
                                            var num = 1 << i;
                                            if (!((_gh3Songlist.CustomBitMask & num) == 0))
                                                goto SKIPIT;

                                            _gh3Songlist.CustomBitMask |= (gH3Setlist.CustomBit = num);
                                            IL_666:
                                            gH3Setlist.Prefix = "custom" + (i + 1);
                                            int num2;
                                            _gh3Songlist.Gh3SetlistList.Add(
                                                num2 =
                                                    QbSongClass1.AddKeyToDictionary("gh3_custom" + (i + 1) + "_songs"),
                                                gH3Setlist);
                                            int value;
                                            _gh3Songlist.Dictionary1.Add(
                                                value =
                                                    QbSongClass1.AddKeyToDictionary(
                                                        "custom" + (i + 1) + "_progression"), new GhLink(num2));
                                            _gh3Songlist.Class2140.Add("Custom Setlist " + (i + 1), value);
                                            method_4(new Class246(value, Class3190, _gh3Songlist, true));
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
                                    _gh3Songlist.Gh3SetlistList[current2].method_0().AddRange(gH3Setlist.method_0());
                                    method_4(new ZzSetListUpdater(current2, Class3190, _gh3Songlist));
                                }
                            }
                        }
                        if (flag2)
                        {
                            method_4(new UpdateSetlistSwitcher(Class3190, _gh3Songlist, _isAerosmith));
                        }
                    }
                    new Class249(Class3190).method_0();
                    new QbDatabaseInitialModifier(Class3190, _isAerosmith).method_0();
                    RefreshSongListBox();
                }
                catch (Exception ex3)
                {
                    if (Class3190 != null)
                    {
                        Class3190.Dispose();
                        Class3190 = null;
                    }
                    Console.WriteLine(ex3.Message);
                    if (DialogResult.Yes == MessageBox.Show(
                            "Game Settings files are corrupt. Do you wish to start from backup? (Overwriting!)",
                            "Loading Game Settings", MessageBoxButtons.YesNo) && method_16(int_))
                    {
                        KeyGenerator.smethod_19(
                            string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pab.xen"),
                            _dataFolder + "PAK\\qb" + text2 + ".pab.xen", true);
                        KeyGenerator.smethod_19(
                            string.Concat(_appDirectory, _backupName, "originals\\qb", text2, ".pak.xen"),
                            _dataFolder + "PAK\\qb" + text2 + ".pak.xen", true);
                    }
                    return;
                }
            }
            foreach (var current3 in _gh3Songlist.Class2140.Keys)
            {
                _setlistDropBox.Items.Add(current3);
            }
            method_12(true);
            if (_setlistDropBox.Items.Count != 0)
            {
                _setlistDropBox.SelectedIndex = 0;
            }
            _tabControl.SelectedIndex = 0;
        }

        private void ClearGameSettings_MenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are You sure you want to Clear All Game Settings?", "Warning!",
                    MessageBoxButtons.YesNo))
            {
                method_15();
            }
        }

        private void method_15()
        {
            method_12(false);
            if (_gh3Songlist != null)
            {
                _gh3Songlist.Clear();
                _gh3Songlist.Gh3SetlistList.Clear();
            }
            _gh3Songlist = null;
            _songListBox.Items.Clear();
            _setlistDropBox.Items.Clear();
            _actionRequestsListBox.Items.Clear();
            //this.notifyIcon_0.Visible = false;
            method_23();
            if (!Directory.Exists(_appDirectory + "log"))
            {
                Directory.CreateDirectory(_appDirectory + "log");
            }
            Class216.smethod_0(_appDirectory + "log\\");
            Class216.smethod_2();
            if (Class3190 != null)
            {
                Class3190.Dispose();
            }
            Class3190 = null;
            GC.Collect();
        }

        private bool method_16(int int3)
        {
            var text = string.Concat(_appDirectory, _backupName, "originals\\qb", _list0[int3], ".pab.xen");
            var icollection = _isAerosmith ? _int2[int3] : _int1[int3];
            return File.Exists(text) && File.Exists(text.Replace(".pab.xen", ".pak.xen")) && KeyGenerator.smethod_53(
                       KeyGenerator.smethod_21(KeyGenerator.HashStream(text)), icollection);
        }

        private bool method_17(int int3)
        {
            var text = _dataFolder + "PAK\\qb" + _list0[int3] + ".pab.xen";
            var icollection = _isAerosmith ? _int2[int3] : _int1[int3];
            while (!File.Exists(text) || !File.Exists(text.Replace(".pab.xen", ".pak.xen")) || !KeyGenerator.smethod_53(
                       KeyGenerator.smethod_21(KeyGenerator.HashStream(text)), icollection))
            {
                if ((text = KeyGenerator.OpenOrSaveFile("Find The Original V1.3 Game Settings.",
                    "Original V1.3 Game Settings|qb" + _list0[int3] + ".pab.xen", true)).Equals(""))
                {
                    return false;
                }
            }
            KeyGenerator.smethod_19(text,
                string.Concat(_appDirectory, _backupName, "originals\\qb", _list0[int3], ".pab.xen"), true);
            KeyGenerator.smethod_19(text.Replace(".pab.xen", ".pak.xen"),
                string.Concat(_appDirectory, _backupName, "originals\\qb", _list0[int3], ".pak.xen"), true);
            return true;
        }

        private bool method_18()
        {
            bool result;
            try
            {
                GameSettingsChecker.SignHash(Class3190);
                Class3190.vmethod_1();
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

        private GameSettingsChecker method_19(int int3)
        {
            if (File.Exists(Class3190.String0) && File.Exists(Class3190.String2) && KeyGenerator.smethod_53(
                    KeyGenerator.smethod_21(KeyGenerator.HashStream(Class3190.String2)),
                    _isAerosmith ? _int2[int3] : _int1[int3]))
            {
                return new GameSettingsChecker(true);
            }
            GameSettingsChecker result;
            try
            {
                result = new GameSettingsChecker(Class3190);
            }
            catch
            {
                result = new GameSettingsChecker(false);
            }
            return result;
        }

        private void method_20(int int3)
        {
        }

        private void RestoreOriginal_MenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(
                    "Do you wish to continue with Original Game Settings Restoration? Current Game Settings will be overwritten!",
                    "Original Game Settings Restoration", MessageBoxButtons.YesNo))
            {
                return;
            }
            var text = KeyGenerator.GetFileNameNoExt(Class3190.String0);
            var int_ = new List<string>(_list0).IndexOf(text.Replace("qb", ""));
            if (method_16(int_))
            {
                method_15();
                KeyGenerator.smethod_19(string.Concat(_appDirectory, _backupName, "originals\\", text, ".pak.xen"),
                    _dataFolder + "PAK\\" + text + ".pak.xen", true);
                KeyGenerator.smethod_19(string.Concat(_appDirectory, _backupName, "originals\\", text, ".pab.xen"),
                    _dataFolder + "PAK\\" + text + ".pab.xen", true);
                return;
            }
            method_17(int_);
        }

        private void RestoreLast_MenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(
                    "Do you wish to continue with Last Game Settings Restoration? Current Game Settings will be overwritten!",
                    "Last Game Settings Restoration", MessageBoxButtons.YesNo))
            {
                return;
            }
            var text = KeyGenerator.GetFileNameNoExt(Class3190.String0);
            if (File.Exists(string.Concat(_appDirectory, _backupName, "lastedited\\", text, ".pak.xen")) && File.Exists(
                    string.Concat(_appDirectory, _backupName, "lastedited\\", text, ".pab.xen")))
            {
                method_15();
                KeyGenerator.smethod_19(string.Concat(_appDirectory, _backupName, "lastedited\\", text, ".pak.xen"),
                    _dataFolder + "PAK\\" + text + ".pak.xen", true);
                KeyGenerator.smethod_19(string.Concat(_appDirectory, _backupName, "lastedited\\", text, ".pab.xen"),
                    _dataFolder + "PAK\\" + text + ".pab.xen", true);
                return;
            }
            MessageBox.Show("Last Game Settings were never backuped.", "Error!");
        }

        private void GameSettingsSwitch_MenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(
                    "Do you wish to switch Game Settings to a different language? Current Game Settings will be overwritten and you will start from a backup!",
                    "Game Settings Switch", MessageBoxButtons.YesNo))
            {
                return;
            }
            var loadGameSettings = new LoadGameSettings(new[]
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
            var num = loadGameSettings.method_3();
            var text = KeyGenerator.GetFileNameNoExt(Class3190.String0);
            if (!method_16(num) && DialogResult.Yes ==
                MessageBox.Show("A proper backup doesn't exist. Do you wish to start backup creation? (Overwriting!)",
                    "Loading Game Settings", MessageBoxButtons.YesNo) && !method_17(num))
            {
                return;
            }
            new List<string>(_list0).IndexOf(text.Replace("qb", ""));
            method_15();
            using (var @class = new ZzPabNode(
                string.Concat(_appDirectory, _backupName, "originals\\qb", _list0[num], ".pak.xen"),
                string.Concat(_appDirectory, _backupName, "originals\\qb", _list0[num], ".pab.xen"), false))
            {
                GameSettingsChecker.SignHash(@class);
                @class.method_20(_dataFolder + "PAK\\" + text + ".pak.xen", _dataFolder + "PAK\\" + text + ".pab.xen");
            }
            GC.Collect();
        }

        private void method_21(object sender, EventArgs2 e)
        {
            _tierApplyBtn.Enabled = true;
        }

        private void TierSongs_ListBox_DragDrop(object sender, DragEventArgs e)
        {
            _tierApplyBtn.Enabled = true;
        }

        private void TierSongs_ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            var num = _tierSongsListBox.IndexFromPoint(e.Location);
            if (num >= 0 && num < _tierSongsListBox.Items.Count && e.Clicks == 2 && e.Button == MouseButtons.Right)
            {
                _tierSongsListBox.Items.RemoveAt(num);
                _tierApplyBtn.Enabled = true;
            }
        }

        private void TierSongs_ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _songListBox.SelectedItems.Count != 0 && DialogResult.Yes ==
                MessageBox.Show("The selected songs will be deleted from the Tier!\nAre you sure you wish to continue?",
                    "Warning!", MessageBoxButtons.YesNo))
            {
                _tierSongsListBox.method_3();
                _tierApplyBtn.Enabled = true;
            }
        }

        private void method_22(Gh3Tier gh3Tier0)
        {
            _tierTLPanel.Enabled = true;
            _tierTitleTxtBox.Text = gh3Tier0.Title;
            _tierUnlockedNumBox.Value = gh3Tier0.Defaultunlocked;
            _tierCompMovieTxtBox.Text = gh3Tier0.CompletionMovie;
            _tierIconDropBox.SelectedItem = gh3Tier0.SetlistIcon;
            _tierStageDropBox.SelectedItem = gh3Tier0.Level;
            _tierEncorep1CheckBox.Checked = gh3Tier0.Encorep1;
            _tierEncorep2CheckBox.Checked = (gh3Tier0.Encorep2 || gh3Tier0.AerosmithEncoreP1);
            _tierBossCheckBox.Checked = gh3Tier0.Boss;
            _noCashCheckBox.Checked = gh3Tier0.Nocash;
            _unlockAllCheckBox.Checked = gh3Tier0.Unlockall;
            _tierSongsListBox.Items.Clear();
            _tierSongsListBox.Items.AddRange(gh3Tier0.Songs.ToArray());
            _tierApplyBtn.Enabled = false;
        }

        private void method_23()
        {
            _tierBox.SelectedIndex = -1;
            _tierTLPanel.Enabled = false;
            _tierTitleTxtBox.Text = "";
            _tierUnlockedNumBox.Value = 0m;
            _tierCompMovieTxtBox.Text = "";
            _tierIconDropBox.SelectedIndex = -1;
            _tierStageDropBox.SelectedIndex = -1;
            _tierEncorep1CheckBox.Checked = false;
            _tierEncorep2CheckBox.Checked = false;
            _tierBossCheckBox.Checked = false;
            _noCashCheckBox.Checked = false;
            _unlockAllCheckBox.Checked = false;
            _tierSongsListBox.Items.Clear();
            _tierApplyBtn.Enabled = false;
        }

        private void TierBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tierBox.SelectedIndex >= 0)
            {
                method_22((Gh3Tier) _tierBox.Items[_tierBox.SelectedIndex]);
            }
        }

        private void TierEncorep1_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _tierApplyBtn.Enabled = true;
        }

        private void TierUnlockedSet_Btn_Click(object sender, EventArgs e)
        {
            _tierUnlockedNumBox.Value = _tierSongsListBox.Items.Count;
        }

        private void TierApply_Btn_Click(object sender, EventArgs e)
        {
            var gH3Tier = (Gh3Tier) _tierBox.Items[_tierBox.SelectedIndex];
            gH3Tier.Title = _tierTitleTxtBox.Text;
            gH3Tier.Defaultunlocked = Convert.ToInt32(_tierUnlockedNumBox.Value);
            gH3Tier.CompletionMovie = _tierCompMovieTxtBox.Text;
            gH3Tier.SetlistIcon = (string) _tierIconDropBox.SelectedItem;
            gH3Tier.Level = (string) _tierStageDropBox.SelectedItem;
            gH3Tier.Boss = _tierBossCheckBox.Checked;
            gH3Tier.Nocash = _noCashCheckBox.Checked;
            gH3Tier.Unlockall = _unlockAllCheckBox.Checked;
            gH3Tier.Encorep1 = _tierEncorep1CheckBox.Checked;
            if (_isAerosmith)
            {
                gH3Tier.AerosmithEncoreP1 = _tierEncorep2CheckBox.Checked;
            }
            else
            {
                gH3Tier.Encorep2 = _tierEncorep2CheckBox.Checked;
            }
            gH3Tier.Songs.Clear();
            foreach (Gh3Song item in _tierSongsListBox.Items)
            {
                gH3Tier.Songs.Add(item);
            }
            _tierApplyBtn.Enabled = false;
            method_4(new ZzSetListUpdater(_selectedSetlist, Class3190, _gh3Songlist));
            if (_hideUsedMenuItem.Checked)
            {
                _gh3Songlist.HideUsed = true;
                RefreshSongListBox();
            }
        }

        private void forceRB3MidConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exportSongListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gh3Songlist.Gh3SetlistList.ContainsKey(_selectedSetlist))
            {
                SaveFileDialog saveFileDlg = new SaveFileDialog();
                saveFileDlg.Filter = "CSV files (*.csv)|*.csv";
                saveFileDlg.Title = "Please select where you would like to save the songlist";
                saveFileDlg.FileName = String.Format("{0}.csv", _setlistDropBox.Text);
                if (saveFileDlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Open selected file for writing
                using (Stream myStream = saveFileDlg.OpenFile())
                {
                    if (myStream == null)
                    {
                        MessageBox.Show("Couldn't open file for writing");
                        return;
                    }

                    // Get songs for this setlist
                    List<Gh3Song> songs = new List<Gh3Song>();
                    foreach (Gh3Tier tier in _gh3Songlist.Gh3SetlistList[_selectedSetlist].Tiers)
                    {
                        foreach (Gh3Song song in tier.Songs)
                        {
                            songs.Add(song);
                        }
                    }

                    // Sort songs by artist and title
                    songs = songs.OrderBy(song => song.Artist).ThenBy(song => song.Title).ToList();

                    // Write to file
                    using (StreamWriter outFile = new StreamWriter(myStream))
                    {
                        // Write CSV header
                        outFile.WriteLine("\"artist\",\"song\"");
                        foreach (Gh3Song song in songs)
                        {
                            outFile.WriteLine(String.Format("\"{0}\",\"{1}\"", song.Artist.Replace("\"", "\"\""),
                                                                               song.Title.Replace("\"", "\"\"")));
                        }
                    }
                }

                MessageBox.Show("Done.");
            }
        }

        private void exportSongListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortSongListForm form = new SortSongListForm();
            form.ShowDialog();

            bool sortBySetlist = form.sortBy == SortSongListForm.SortBy.Setlist;

            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "CSV files (*.csv)|*.csv";
            saveFileDlg.Title = "Please select where you would like to save the songlist";
            saveFileDlg.FileName = "songlist.csv";
            if (saveFileDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Open selected file for writing
            using (Stream myStream = saveFileDlg.OpenFile())
            {
                if (myStream == null)
                {
                    MessageBox.Show("Couldn't open file for writing");
                    return;
                }

                // Retrieve songs and associated setlist name
                List<KeyValuePair<string, Gh3Song>> songs = new List<KeyValuePair<string, Gh3Song>>();
                // Setlist contains a pair of setlist name => setlist id
                foreach (KeyValuePair<string, int> setlist in _gh3Songlist.Class2140)
                {
                    foreach (Gh3Tier tier in _gh3Songlist.Gh3SetlistList[_selectedSetlist = _gh3Songlist.method_9(setlist.Key)].Tiers)
                    {
                        foreach (Gh3Song song in tier.Songs)
                        {
                            songs.Add(new KeyValuePair<string, Gh3Song>(setlist.Key, song));
                        }
                    }
                }

                // Sort by setlist or artist
                if (sortBySetlist)
                {
                    songs = songs.OrderBy(pair => pair.Key).ThenBy(pair => pair.Value.Artist).ThenBy(pair => pair.Value.Title).ToList();
                }
                else
                {
                    songs = songs.OrderBy(pair => pair.Value.Artist).ThenBy(pair => pair.Value.Title).ThenBy(pair => pair.Key).ToList();
                }

                // Write results to file
                using (StreamWriter outFile = new StreamWriter(myStream))
                {
                    // Write CSV header
                    outFile.WriteLine("\"artist\",\"song\",\"setlist\"");
                    foreach (KeyValuePair<string, Gh3Song> song in songs)
                    {
                        outFile.WriteLine(String.Format("\"{1}\",\"{2}\",\"{0}\"", song.Key.Replace("\"", "\"\""),
                                                                                   song.Value.Artist.Replace("\"", "\"\""),
                                                                                   song.Value.Title.Replace("\"", "\"\"")));
                    }
                }
            }

            MessageBox.Show("Done.");
        }
    }
}