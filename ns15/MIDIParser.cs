using System;
using System.Collections.Generic;
using System.IO;
using ns22;
using ns9;

namespace ns15
{
	public class MIDIParser
	{
		private readonly string fileLocation;

		private readonly NoteEventInterpreter expertSingle = new NoteEventInterpreter();

		private readonly NoteEventInterpreter hardSingle = new NoteEventInterpreter();

		private readonly NoteEventInterpreter mediumSingle = new NoteEventInterpreter();

		private readonly NoteEventInterpreter easySingle = new NoteEventInterpreter();

		private readonly NoteEventInterpreter expertDoubleGuitar = new NoteEventInterpreter();

		private readonly NoteEventInterpreter hardDoubleGuitar = new NoteEventInterpreter();

		private readonly NoteEventInterpreter mediumDoubleGuitar = new NoteEventInterpreter();

		private readonly NoteEventInterpreter easyDoubleGuitar = new NoteEventInterpreter();

		private readonly NoteEventInterpreter expertDoubleBass = new NoteEventInterpreter();

		private readonly NoteEventInterpreter hardDoubleBass = new NoteEventInterpreter();

		private readonly NoteEventInterpreter mediumDoubleBass = new NoteEventInterpreter();

		private readonly NoteEventInterpreter easyDoubleBass = new NoteEventInterpreter();

		private readonly InstrumentType expertDrums = new InstrumentType();

		private readonly InstrumentType hardDrums = new InstrumentType();

		private readonly InstrumentType mediumDrums = new InstrumentType();

		private readonly InstrumentType easyDrums = new InstrumentType();

		private readonly InstrumentType expertKeyboard = new InstrumentType();

		private readonly InstrumentType hardKeyboard = new InstrumentType();

		private readonly InstrumentType mediumKeyboard = new InstrumentType();

		private readonly InstrumentType easyKeyboard = new InstrumentType();

		private BPMInterpreter bpmInterpreter;

		private SectionInterpreter sectionInterpreter;

		private string songTitle = "";

		private double resolution;

		private bool isPartGuitar;

		private bool isEvents;

		private bool notBass;

		private bool bool_3;

		private MIDIReader midiReader;

		private readonly List<string> uselessEvents = new List<string>();

		public MIDIParser(string fileLocation)
		{
			this.fileLocation = fileLocation;
		}

		public ChartParser LoadMidi()
		{
			var name = "";
			name = name + new FileInfo(fileLocation).Name + ":\n";
			try
			{
				midiReader = MIDIReader.smethod_0(fileLocation);
			}
			catch (Exception)
			{
				throw new IOException(name + "Unknown Error: Could not parse MIDI sequence.");
			}
			foreach (var current in midiReader.getMidiLineList())
			{
				if (current.method_2().Equals("PART GUITAR"))
				{
					isPartGuitar = true;
				}
				else if (current.method_2().Equals("EVENTS"))
				{
					isEvents = true;
				}
			}
			if (midiReader.getMidiLineList().Count == 1 && !isPartGuitar)
			{
				midiReader.getMidiLineList()[0].method_3("PART GUITAR");
				isPartGuitar = true;
			}
			if (!isPartGuitar)
			{
				throw new IOException(name + "PART GUITAR not found. No chart created.");
			}
			var chartParser = new ChartParser();
			bpmInterpreter = chartParser.bpmInterpreter;
			sectionInterpreter = chartParser.sectionInterpreter;
			chartParser.difficultyWithNotes.Add("EasySingle", easySingle);
			chartParser.difficultyWithNotes.Add("MediumSingle", mediumSingle);
			chartParser.difficultyWithNotes.Add("HardSingle", hardSingle);
			chartParser.difficultyWithNotes.Add("ExpertSingle", expertSingle);
			chartParser.difficultyWithNotes.Add("EasyDoubleGuitar", easyDoubleGuitar);
			chartParser.difficultyWithNotes.Add("MediumDoubleGuitar", mediumDoubleGuitar);
			chartParser.difficultyWithNotes.Add("HardDoubleGuitar", hardDoubleGuitar);
			chartParser.difficultyWithNotes.Add("ExpertDoubleGuitar", expertDoubleGuitar);
			chartParser.difficultyWithNotes.Add("EasyDoubleBass", easyDoubleBass);
			chartParser.difficultyWithNotes.Add("MediumDoubleBass", mediumDoubleBass);
			chartParser.difficultyWithNotes.Add("HardDoubleBass", hardDoubleBass);
			chartParser.difficultyWithNotes.Add("ExpertDoubleBass", expertDoubleBass);
			chartParser.instrumentList.Add("EasyDrums", easyDrums);
			chartParser.instrumentList.Add("MediumDrums", mediumDrums);
			chartParser.instrumentList.Add("HardDrums", hardDrums);
			chartParser.instrumentList.Add("ExpertDrums", expertDrums);
			chartParser.instrumentList.Add("EasyKeyboard", easyKeyboard);
			chartParser.instrumentList.Add("MediumKeyboard", mediumKeyboard);
			chartParser.instrumentList.Add("HardKeyboard", hardKeyboard);
			chartParser.instrumentList.Add("ExpertKeyboard", expertKeyboard);
			chartParser.constant480 = 480;
			resolution = 480.0 / midiReader.method_0();
			object obj = name;
			name = string.Concat(obj, "NumTracks = ", midiReader.getMidiLineList().Count, "\n");
			method_1(midiReader.getMidiLineList()[0]);
			foreach (var midiLine in midiReader.getMidiLineList())
			{
				if (midiLine.method_2().Equals("PART GUITAR"))
				{
					getNotes(midiLine, 0);
				}
				else if (midiLine.method_2().Equals("T1 GEMS"))
				{
					getNotes(midiLine, 0);
				}
				else if (midiLine.method_2().Equals("PART GUITAR COOP"))
				{
					getNotes(midiLine, 1);
				}
				else if (midiLine.method_2().Equals("PART RHYTHM"))
				{
					notBass = true;
					getNotes(midiLine, 3);
				}
				else if (midiLine.method_2().Equals("PART BASS"))
				{
					getNotes(midiLine, 3);
				}
				else if (midiLine.method_2().Equals("EVENTS"))
				{
					getNotes(midiLine, 4);
				}
				else if (midiLine.method_2().Equals("BAND DRUMS"))
				{
					getNotes(midiLine, 5);
				}
				else if (midiLine.method_2().Equals("BAND KEYS"))
				{
					getNotes(midiLine, 7);
				}
				else
				{
					name = name + "Track (" + midiLine.method_2() + ") ignored.\n";
				}
			}
			chartParser.gh3SongInfo.title = songTitle;
			chartParser.gh3SongInfo.not_bass = notBass;
			name += "Conversion Complete!";
			Console.WriteLine(name);
			chartParser.removeEmptyParts();
			return chartParser;
		}

		private void method_1(MIDILine class353_0)
		{
			songTitle = class353_0.method_2();
			foreach (var current in class353_0.method_0())
			{
				var num = Convert.ToInt32(current.method_0() * resolution);
				if (current is zzNote1)
				{
					var @class = (zzNote1)current;
					if (!isEvents && @class.method_2() == zzNote1.Enum37.const_0)
					{
						method_4(4, num, "section " + @class.method_1());
					}
				}
				else if (current is BpmNote1)
				{
					var num2 = ((BpmNote1)current).method_1();
					bpmInterpreter.bpmList.Add(num, Convert.ToInt32(Math.Floor(60000000.0 / num2 * 1000.0)));
				}
				else if (current is zzNote338)
				{
					bpmInterpreter.TSList.Add(num, ((zzNote338)current).method_1());
				}
			}
		}

		private void getNotes(MIDILine midiLine, int difficulty)
		{
			var array = new bool[midiLine.method_0().Count];
			var list = midiLine.method_0();
			for (var i = 0; i < list.Count; i++)
			{
				if (!array[i])
				{
					var num = Convert.ToInt32(list[i].method_0() * resolution);
					if (list[i] is MIDINote)
					{
						var midiNote = (MIDINote)list[i];
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
								if (list[num2] is MIDINote && ((MIDINote)list[num2]).method_4() == midiNote.method_4())
								{
									if (((MIDINote)list[num2]).method_5())
									{
										j = Convert.ToInt32(list[num2].method_0() * resolution);
										array[num2] = true;
									}
									else
									{
										j = Convert.ToInt32(list[num2].method_0() * resolution);
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
					else if (list[i] is zzNote1)
					{
						var class2 = (zzNote1)list[i];
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

		private void method_3(int instrumentType, int int_1, MIDINote midiNote, int int_2)
		{
			NoteEventInterpreter noteEvenInterpreter = null;
			switch (midiNote.getDifficulty())
			{
			case Difficulty.Easy:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = easySingle;
					break;
				case 1:
					noteEvenInterpreter = easyDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = easyDoubleBass;
					break;
				}
				break;
			case Difficulty.Medium:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = mediumSingle;
					break;
				case 1:
					noteEvenInterpreter = mediumDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = mediumDoubleBass;
					break;
				}
				break;
			case Difficulty.Hard:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = hardSingle;
					break;
				case 1:
					noteEvenInterpreter = hardDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = hardDoubleBass;
					break;
				}
				break;
			case Difficulty.Expert:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = expertSingle;
					break;
				case 1:
					noteEvenInterpreter = expertDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = expertDoubleBass;
					break;
				}
				break;
			default:
				if (!bool_3 && midiNote.method_2() == MIDINoteMask.StarPower)
				{
					bool_3 = true;
					expertSingle.class228_1.Clear();
					hardSingle.class228_1.Clear();
					mediumSingle.class228_1.Clear();
					easySingle.class228_1.Clear();
				}
				else if (!bool_3)
				{
					return;
				}
				break;
			}
			if (midiNote.method_3() != Fret.Invalid)
			{
				if (noteEvenInterpreter.noteList.method_4(int_1))
				{
					noteEvenInterpreter.noteList[int_1].noteValues[(int)midiNote.method_3()] = true;
					return;
				}
				var array = new bool[32];
				array[(int)midiNote.method_3()] = true;
				noteEvenInterpreter.noteList.Add(int_1, new NotesAtOffset(array, int_2));
			}
			else
			{
				if (midiNote.method_2() == MIDINoteMask.StarPower && !expertSingle.class228_1.ContainsKey(int_1))
				{
					expertSingle.class228_1.Add(int_1, int_2);
					hardSingle.class228_1.Add(int_1, int_2);
					mediumSingle.class228_1.Add(int_1, int_2);
					easySingle.class228_1.Add(int_1, int_2);
					return;
				}
				if (midiNote.method_2() == MIDINoteMask.Unk7 && !noteEvenInterpreter.class228_1.ContainsKey(int_1) && !bool_3)
				{
					noteEvenInterpreter.class228_1.Add(int_1, int_2);
					return;
				}
				if (midiNote.method_2() == MIDINoteMask.Unk9 && !noteEvenInterpreter.class228_2.ContainsKey(int_1))
				{
					noteEvenInterpreter.class228_2.Add(int_1, int_2);
					return;
				}
				if (midiNote.method_2() == MIDINoteMask.Unk10 && !noteEvenInterpreter.class228_3.ContainsKey(int_1))
				{
					noteEvenInterpreter.class228_3.Add(int_1, int_2);
				}
			}
		}

		private void method_4(int int_0, int int_1, string string_2)
		{
			if (int_0 == 4)
			{
				if (string_2.Contains("section "))
				{
					sectionInterpreter.sectionList.Add(int_1, string_2);
					return;
				}
				if (sectionInterpreter.otherList.method_4(int_1))
				{
					sectionInterpreter.otherList[int_1].Add(string_2);
					return;
				}
				sectionInterpreter.otherList.Add(int_1, new List<string>(new[]
				{
					string_2
				}));
			}
			else
			{
				NoteEventInterpreter @class = null;
				NoteEventInterpreter class2 = null;
				NoteEventInterpreter class3 = null;
				NoteEventInterpreter class4 = null;
				switch (int_0)
				{
				case 0:
					@class = expertSingle;
					class2 = hardSingle;
					class3 = mediumSingle;
					class4 = easySingle;
					break;
				case 1:
					@class = expertDoubleGuitar;
					class2 = hardDoubleGuitar;
					class3 = mediumDoubleGuitar;
					class4 = easyDoubleGuitar;
					break;
				case 3:
					@class = expertDoubleBass;
					class2 = hardDoubleBass;
					class3 = mediumDoubleBass;
					class4 = easyDoubleBass;
					break;
				case 5:
					expertDrums.method_5(int_1, string_2);
					hardDrums.method_5(int_1, string_2);
					mediumDrums.method_5(int_1, string_2);
					easyDrums.method_5(int_1, string_2);
					return;
				case 7:
					expertKeyboard.method_5(int_1, string_2);
					hardKeyboard.method_5(int_1, string_2);
					mediumKeyboard.method_5(int_1, string_2);
					easyKeyboard.method_5(int_1, string_2);
					return;
				}
				if (@class != null && @class.eventList.method_4(int_1))
				{
					@class.eventList[int_1].Add(string_2);
					class2.eventList[int_1].Add(string_2);
					class3.eventList[int_1].Add(string_2);
					class4.eventList[int_1].Add(string_2);
					return;
				}
				@class.eventList.Add(int_1, new List<string>(new[]
				{
					string_2
				}));
				class2.eventList.Add(int_1, new List<string>(new[]
				{
					string_2
				}));
				class3.eventList.Add(int_1, new List<string>(new[]
				{
					string_2
				}));
				class4.eventList.Add(int_1, new List<string>(new[]
				{
					string_2
				}));
			}
		}

		private List<string> method_5(int int_0)
		{
			if (uselessEvents.Count == 0)
			{
				uselessEvents.Add("lighting (chase)");
				uselessEvents.Add("lighting (strobe)");
				uselessEvents.Add("lighting (color1)");
				uselessEvents.Add("lighting (color2)");
				uselessEvents.Add("lighting (sweep)");
				uselessEvents.Add("crowd_lighters_fast");
				uselessEvents.Add("crowd_lighters_off");
				uselessEvents.Add("crowd_lighters_slow");
				uselessEvents.Add("crowd_half_tempo");
				uselessEvents.Add("crowd_normal_tempo");
				uselessEvents.Add("crowd_double_tempo");
				uselessEvents.Add("band_jump");
				uselessEvents.Add("sync_head_bang");
				uselessEvents.Add("sync_wag");
				uselessEvents.Add("lighting ()");
				uselessEvents.Add("lighting (flare)");
				uselessEvents.Add("lighting (blackout)");
				uselessEvents.Add("music_start");
				uselessEvents.Add("verse");
				uselessEvents.Add("chorus");
				uselessEvents.Add("solo");
				uselessEvents.Add("end");
				uselessEvents.Add("idle");
				uselessEvents.Add("play");
				uselessEvents.Add("solo_on");
				uselessEvents.Add("solo_off");
				uselessEvents.Add("wail_on");
				uselessEvents.Add("wail_off");
				uselessEvents.Add("drum_on");
				uselessEvents.Add("drum_off");
				uselessEvents.Add("sing_on");
				uselessEvents.Add("sing_off");
				uselessEvents.Add("bass_on");
				uselessEvents.Add("bass_off");
				uselessEvents.Add("gtr_on");
				uselessEvents.Add("gtr_off");
				uselessEvents.Add("ow_face_on");
				uselessEvents.Add("ow_face_off");
				uselessEvents.Add("half_tempo");
				uselessEvents.Add("normal_tempo");
				uselessEvents.Add("half_time");
				uselessEvents.Add("double_time");
				uselessEvents.Add("allbeat");
				uselessEvents.Add("nobeat");
			}
			return uselessEvents;
		}
	}
}
