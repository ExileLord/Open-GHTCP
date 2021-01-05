using System;
using System.Collections.Generic;
using System.IO;
using GHNamespaceG;
using GHNamespaceN;

namespace GHNamespace8
{
    public class MidiParser
    {
        private readonly string _fileLocation;

        private readonly NoteEventInterpreter _expertSingle = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _hardSingle = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _mediumSingle = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _easySingle = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _expertDoubleGuitar = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _hardDoubleGuitar = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _mediumDoubleGuitar = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _easyDoubleGuitar = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _expertDoubleBass = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _hardDoubleBass = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _mediumDoubleBass = new NoteEventInterpreter();

        private readonly NoteEventInterpreter _easyDoubleBass = new NoteEventInterpreter();

        private readonly InstrumentType _expertDrums = new InstrumentType();

        private readonly InstrumentType _hardDrums = new InstrumentType();

        private readonly InstrumentType _mediumDrums = new InstrumentType();

        private readonly InstrumentType _easyDrums = new InstrumentType();

        private readonly InstrumentType _expertKeyboard = new InstrumentType();

        private readonly InstrumentType _hardKeyboard = new InstrumentType();

        private readonly InstrumentType _mediumKeyboard = new InstrumentType();

        private readonly InstrumentType _easyKeyboard = new InstrumentType();

        private BpmInterpreter _bpmInterpreter;

        private SectionInterpreter _sectionInterpreter;

        private string _songTitle = "";

        private double _resolution;

        private bool _isPartGuitar;

        private bool _isEvents;

        private bool _notBass;

        private bool _bool3;

        private MidiReader _midiReader;

        private readonly List<string> _uselessEvents = new List<string>();

        public MidiParser(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public ChartParser LoadMidi()
        {
            var name = "";
            name = name + new FileInfo(_fileLocation).Name + ":\n";
            try
            {
                _midiReader = MidiReader.smethod_0(_fileLocation);
            }
            catch (Exception)
            {
                throw new IOException(name + "Unknown Error: Could not parse MIDI sequence.");
            }
            foreach (var current in _midiReader.GetMidiLineList())
            {
                if (current.method_2().Equals("PART GUITAR"))
                {
                    _isPartGuitar = true;
                }
                else if (current.method_2().Equals("EVENTS"))
                {
                    _isEvents = true;
                }
            }
            if (_midiReader.GetMidiLineList().Count == 1 && !_isPartGuitar)
            {
                _midiReader.GetMidiLineList()[0].method_3("PART GUITAR");
                _isPartGuitar = true;
            }
            if (!_isPartGuitar)
            {
                throw new IOException(name + "PART GUITAR not found. No chart created.");
            }
            var chartParser = new ChartParser();
            _bpmInterpreter = chartParser.BpmInterpreter;
            _sectionInterpreter = chartParser.SectionInterpreter;
            chartParser.DifficultyWithNotes.Add("EasySingle", _easySingle);
            chartParser.DifficultyWithNotes.Add("MediumSingle", _mediumSingle);
            chartParser.DifficultyWithNotes.Add("HardSingle", _hardSingle);
            chartParser.DifficultyWithNotes.Add("ExpertSingle", _expertSingle);
            chartParser.DifficultyWithNotes.Add("EasyDoubleGuitar", _easyDoubleGuitar);
            chartParser.DifficultyWithNotes.Add("MediumDoubleGuitar", _mediumDoubleGuitar);
            chartParser.DifficultyWithNotes.Add("HardDoubleGuitar", _hardDoubleGuitar);
            chartParser.DifficultyWithNotes.Add("ExpertDoubleGuitar", _expertDoubleGuitar);
            chartParser.DifficultyWithNotes.Add("EasyDoubleBass", _easyDoubleBass);
            chartParser.DifficultyWithNotes.Add("MediumDoubleBass", _mediumDoubleBass);
            chartParser.DifficultyWithNotes.Add("HardDoubleBass", _hardDoubleBass);
            chartParser.DifficultyWithNotes.Add("ExpertDoubleBass", _expertDoubleBass);
            chartParser.InstrumentList.Add("EasyDrums", _easyDrums);
            chartParser.InstrumentList.Add("MediumDrums", _mediumDrums);
            chartParser.InstrumentList.Add("HardDrums", _hardDrums);
            chartParser.InstrumentList.Add("ExpertDrums", _expertDrums);
            chartParser.InstrumentList.Add("EasyKeyboard", _easyKeyboard);
            chartParser.InstrumentList.Add("MediumKeyboard", _mediumKeyboard);
            chartParser.InstrumentList.Add("HardKeyboard", _hardKeyboard);
            chartParser.InstrumentList.Add("ExpertKeyboard", _expertKeyboard);
            chartParser.Constant480 = 480;
            _resolution = 480.0 / _midiReader.method_0();
            object obj = name;
            name = string.Concat(obj, "NumTracks = ", _midiReader.GetMidiLineList().Count, "\n");
            method_1(_midiReader.GetMidiLineList()[0]);
            foreach (var midiLine in _midiReader.GetMidiLineList())
            {
                if (midiLine.method_2().Equals("PART GUITAR"))
                {
                    GetNotes(midiLine, 0);
                }
                else if (midiLine.method_2().Equals("T1 GEMS"))
                {
                    GetNotes(midiLine, 0);
                }
                else if (midiLine.method_2().Equals("PART GUITAR COOP"))
                {
                    GetNotes(midiLine, 1);
                }
                else if (midiLine.method_2().Equals("PART RHYTHM"))
                {
                    _notBass = true;
                    GetNotes(midiLine, 3);
                }
                else if (midiLine.method_2().Equals("PART BASS"))
                {
                    GetNotes(midiLine, 3);
                }
                else if (midiLine.method_2().Equals("EVENTS"))
                {
                    GetNotes(midiLine, 4);
                }
                else if (midiLine.method_2().Equals("BAND DRUMS"))
                {
                    GetNotes(midiLine, 5);
                }
                else if (midiLine.method_2().Equals("BAND KEYS"))
                {
                    GetNotes(midiLine, 7);
                }
                else
                {
                    name = name + "Track (" + midiLine.method_2() + ") ignored.\n";
                }
            }
            chartParser.Gh3SongInfo.Title = _songTitle;
            chartParser.Gh3SongInfo.NotBass = _notBass;
            name += "Conversion Complete!";
            Console.WriteLine(name);
            chartParser.RemoveEmptyParts();
            return chartParser;
        }

        private void method_1(MidiLine class3530)
        {
            _songTitle = class3530.method_2();
            foreach (var current in class3530.method_0())
            {
                var num = Convert.ToInt32(current.method_0() * _resolution);
                if (current is ZzNote1)
                {
                    var @class = (ZzNote1) current;
                    if (!_isEvents && @class.method_2() == ZzNote1.Enum37.Const0)
                    {
                        method_4(4, num, "section " + @class.method_1());
                    }
                }
                else if (current is BpmNote1)
                {
                    var num2 = ((BpmNote1) current).method_1();
                    _bpmInterpreter.BpmList.Add(num, Convert.ToInt32(Math.Floor(60000000.0 / num2 * 1000.0)));
                }
                else if (current is ZzNote338)
                {
                    _bpmInterpreter.TsList.Add(num, ((ZzNote338) current).method_1());
                }
            }
        }

        private void GetNotes(MidiLine midiLine, int difficulty)
        {
            var array = new bool[midiLine.method_0().Count];
            var list = midiLine.method_0();
            for (var i = 0; i < list.Count; i++)
            {
                if (!array[i])
                {
                    var num = Convert.ToInt32(list[i].method_0() * _resolution);
                    if (list[i] is MidiNote)
                    {
                        var midiNote = (MidiNote) list[i];
                        if (midiNote.method_5())
                        {
                            var j = -1;
                            var num2 = i + 1;
                            while (j < 0)
                            {
                                if (num2 == midiLine.method_0().Count)
                                {
                                    break;
                                }
                                if (list[num2] is MidiNote && ((MidiNote) list[num2]).method_4() == midiNote.method_4())
                                {
                                    if (((MidiNote) list[num2]).method_5())
                                    {
                                        j = Convert.ToInt32(list[num2].method_0() * _resolution);
                                        array[num2] = true;
                                    }
                                    else
                                    {
                                        j = Convert.ToInt32(list[num2].method_0() * _resolution);
                                    }
                                }
                                num2++;
                            }
                            var num3 = Convert.ToInt32(j - num);
                            if (num3 <= 160)
                            {
                                num3 = 0;
                            }
                            method_3(difficulty, num, midiNote, num3);
                        }
                    }
                    else if (list[i] is ZzNote1)
                    {
                        var class2 = (ZzNote1) list[i];
                        var list2 = method_5(difficulty - 4);
                        var text = class2.method_1();
                        if (text.StartsWith("["))
                        {
                            text = text.Substring(1, text.Length - 2);
                        }
                        if (list2.Contains(text) || text.Contains("section "))
                        {
                            method_4(difficulty, num, text);
                        }
                    }
                }
            }
        }

        private void method_3(int instrumentType, int int1, MidiNote midiNote, int int2)
        {
            NoteEventInterpreter noteEvenInterpreter = null;
            switch (midiNote.GetDifficulty())
            {
                case Difficulty.Easy:
                    switch (instrumentType)
                    {
                        case 0:
                            noteEvenInterpreter = _easySingle;
                            break;
                        case 1:
                            noteEvenInterpreter = _easyDoubleGuitar;
                            break;
                        case 3:
                            noteEvenInterpreter = _easyDoubleBass;
                            break;
                    }
                    break;
                case Difficulty.Medium:
                    switch (instrumentType)
                    {
                        case 0:
                            noteEvenInterpreter = _mediumSingle;
                            break;
                        case 1:
                            noteEvenInterpreter = _mediumDoubleGuitar;
                            break;
                        case 3:
                            noteEvenInterpreter = _mediumDoubleBass;
                            break;
                    }
                    break;
                case Difficulty.Hard:
                    switch (instrumentType)
                    {
                        case 0:
                            noteEvenInterpreter = _hardSingle;
                            break;
                        case 1:
                            noteEvenInterpreter = _hardDoubleGuitar;
                            break;
                        case 3:
                            noteEvenInterpreter = _hardDoubleBass;
                            break;
                    }
                    break;
                case Difficulty.Expert:
                    switch (instrumentType)
                    {
                        case 0:
                            noteEvenInterpreter = _expertSingle;
                            break;
                        case 1:
                            noteEvenInterpreter = _expertDoubleGuitar;
                            break;
                        case 3:
                            noteEvenInterpreter = _expertDoubleBass;
                            break;
                    }
                    break;
                default:
                    if (!_bool3 && midiNote.method_2() == MidiNoteMask.StarPower)
                    {
                        _bool3 = true;
                        _expertSingle.Class2281.Clear();
                        _hardSingle.Class2281.Clear();
                        _mediumSingle.Class2281.Clear();
                        _easySingle.Class2281.Clear();
                    }
                    else if (!_bool3)
                    {
                        return;
                    }
                    break;
            }
            if (midiNote.method_3() != Fret.Invalid)
            {
                if (noteEvenInterpreter.NoteList.method_4(int1))
                {
                    noteEvenInterpreter.NoteList[int1].NoteValues[(int) midiNote.method_3()] = true;
                    return;
                }
                var array = new bool[32];
                array[(int) midiNote.method_3()] = true;
                noteEvenInterpreter.NoteList.Add(int1, new NotesAtOffset(array, int2));
            }
            else
            {
                if (midiNote.method_2() == MidiNoteMask.StarPower && !_expertSingle.Class2281.ContainsKey(int1))
                {
                    _expertSingle.Class2281.Add(int1, int2);
                    _hardSingle.Class2281.Add(int1, int2);
                    _mediumSingle.Class2281.Add(int1, int2);
                    _easySingle.Class2281.Add(int1, int2);
                    return;
                }
                if (midiNote.method_2() == MidiNoteMask.Unk7 && !noteEvenInterpreter.Class2281.ContainsKey(int1) &&
                    !_bool3)
                {
                    noteEvenInterpreter.Class2281.Add(int1, int2);
                    return;
                }
                if (midiNote.method_2() == MidiNoteMask.Unk9 && !noteEvenInterpreter.Class2282.ContainsKey(int1))
                {
                    noteEvenInterpreter.Class2282.Add(int1, int2);
                    return;
                }
                if (midiNote.method_2() == MidiNoteMask.Unk10 && !noteEvenInterpreter.Class2283.ContainsKey(int1))
                {
                    noteEvenInterpreter.Class2283.Add(int1, int2);
                }
            }
        }

        private void method_4(int int0, int int1, string string2)
        {
            if (int0 == 4)
            {
                if (string2.Contains("section "))
                {
                    _sectionInterpreter.SectionList.Add(int1, string2);
                    return;
                }
                if (_sectionInterpreter.OtherList.method_4(int1))
                {
                    _sectionInterpreter.OtherList[int1].Add(string2);
                    return;
                }
                _sectionInterpreter.OtherList.Add(int1, new List<string>(new[]
                {
                    string2
                }));
            }
            else
            {
                NoteEventInterpreter @class = null;
                NoteEventInterpreter class2 = null;
                NoteEventInterpreter class3 = null;
                NoteEventInterpreter class4 = null;
                switch (int0)
                {
                    case 0:
                        @class = _expertSingle;
                        class2 = _hardSingle;
                        class3 = _mediumSingle;
                        class4 = _easySingle;
                        break;
                    case 1:
                        @class = _expertDoubleGuitar;
                        class2 = _hardDoubleGuitar;
                        class3 = _mediumDoubleGuitar;
                        class4 = _easyDoubleGuitar;
                        break;
                    case 3:
                        @class = _expertDoubleBass;
                        class2 = _hardDoubleBass;
                        class3 = _mediumDoubleBass;
                        class4 = _easyDoubleBass;
                        break;
                    case 5:
                        _expertDrums.method_5(int1, string2);
                        _hardDrums.method_5(int1, string2);
                        _mediumDrums.method_5(int1, string2);
                        _easyDrums.method_5(int1, string2);
                        return;
                    case 7:
                        _expertKeyboard.method_5(int1, string2);
                        _hardKeyboard.method_5(int1, string2);
                        _mediumKeyboard.method_5(int1, string2);
                        _easyKeyboard.method_5(int1, string2);
                        return;
                }
                if (@class != null && @class.EventList.method_4(int1))
                {
                    @class.EventList[int1].Add(string2);
                    class2.EventList[int1].Add(string2);
                    class3.EventList[int1].Add(string2);
                    class4.EventList[int1].Add(string2);
                    return;
                }
                @class.EventList.Add(int1, new List<string>(new[]
                {
                    string2
                }));
                class2.EventList.Add(int1, new List<string>(new[]
                {
                    string2
                }));
                class3.EventList.Add(int1, new List<string>(new[]
                {
                    string2
                }));
                class4.EventList.Add(int1, new List<string>(new[]
                {
                    string2
                }));
            }
        }

        private List<string> method_5(int int0)
        {
            if (_uselessEvents.Count == 0)
            {
                _uselessEvents.Add("lighting (chase)");
                _uselessEvents.Add("lighting (strobe)");
                _uselessEvents.Add("lighting (color1)");
                _uselessEvents.Add("lighting (color2)");
                _uselessEvents.Add("lighting (sweep)");
                _uselessEvents.Add("crowd_lighters_fast");
                _uselessEvents.Add("crowd_lighters_off");
                _uselessEvents.Add("crowd_lighters_slow");
                _uselessEvents.Add("crowd_half_tempo");
                _uselessEvents.Add("crowd_normal_tempo");
                _uselessEvents.Add("crowd_double_tempo");
                _uselessEvents.Add("band_jump");
                _uselessEvents.Add("sync_head_bang");
                _uselessEvents.Add("sync_wag");
                _uselessEvents.Add("lighting ()");
                _uselessEvents.Add("lighting (flare)");
                _uselessEvents.Add("lighting (blackout)");
                _uselessEvents.Add("music_start");
                _uselessEvents.Add("verse");
                _uselessEvents.Add("chorus");
                _uselessEvents.Add("solo");
                _uselessEvents.Add("end");
                _uselessEvents.Add("idle");
                _uselessEvents.Add("play");
                _uselessEvents.Add("solo_on");
                _uselessEvents.Add("solo_off");
                _uselessEvents.Add("wail_on");
                _uselessEvents.Add("wail_off");
                _uselessEvents.Add("drum_on");
                _uselessEvents.Add("drum_off");
                _uselessEvents.Add("sing_on");
                _uselessEvents.Add("sing_off");
                _uselessEvents.Add("bass_on");
                _uselessEvents.Add("bass_off");
                _uselessEvents.Add("gtr_on");
                _uselessEvents.Add("gtr_off");
                _uselessEvents.Add("ow_face_on");
                _uselessEvents.Add("ow_face_off");
                _uselessEvents.Add("half_tempo");
                _uselessEvents.Add("normal_tempo");
                _uselessEvents.Add("half_time");
                _uselessEvents.Add("double_time");
                _uselessEvents.Add("allbeat");
                _uselessEvents.Add("nobeat");
            }
            return _uselessEvents;
        }
    }
}