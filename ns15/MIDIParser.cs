using ns22;
using ns9;
using System;
using System.Collections.Generic;
using System.IO;

namespace ns15
{
	public class MIDIParser
	{
		private string fileLocation;

		private NoteEventInterpreter expertSingle = new NoteEventInterpreter();

		private NoteEventInterpreter hardSingle = new NoteEventInterpreter();

		private NoteEventInterpreter mediumSingle = new NoteEventInterpreter();

		private NoteEventInterpreter easySingle = new NoteEventInterpreter();

		private NoteEventInterpreter expertDoubleGuitar = new NoteEventInterpreter();

		private NoteEventInterpreter hardDoubleGuitar = new NoteEventInterpreter();

		private NoteEventInterpreter mediumDoubleGuitar = new NoteEventInterpreter();

		private NoteEventInterpreter easyDoubleGuitar = new NoteEventInterpreter();

		private NoteEventInterpreter expertDoubleBass = new NoteEventInterpreter();

		private NoteEventInterpreter hardDoubleBass = new NoteEventInterpreter();

		private NoteEventInterpreter mediumDoubleBass = new NoteEventInterpreter();

		private NoteEventInterpreter easyDoubleBass = new NoteEventInterpreter();

		private InstrumentType expertDrums = new InstrumentType();

		private InstrumentType hardDrums = new InstrumentType();

		private InstrumentType mediumDrums = new InstrumentType();

		private InstrumentType easyDrums = new InstrumentType();

		private InstrumentType expertKeyboard = new InstrumentType();

		private InstrumentType hardKeyboard = new InstrumentType();

		private InstrumentType mediumKeyboard = new InstrumentType();

		private InstrumentType easyKeyboard = new InstrumentType();

		private BPMInterpreter bpmInterpreter;

		private SectionInterpreter sectionInterpreter;

		private string songTitle = "";

		private double resolution;

		private bool isPartGuitar;

		private bool isEvents;

		private bool notBass;

		private bool bool_3;

		private MIDIReader midiReader;

		private List<string> uselessEvents = new List<string>();

		public MIDIParser(string fileLocation)
		{
			this.fileLocation = fileLocation;
		}

		public ChartParser LoadMidi()
		{
			string name = "";
			name = name + new FileInfo(this.fileLocation).Name + ":\n";
			try
			{
				this.midiReader = MIDIReader.smethod_0(this.fileLocation);
			}
			catch (Exception)
			{
				throw new IOException(name + "Unknown Error: Could not parse MIDI sequence.");
			}
			foreach (MIDILine current in this.midiReader.getMidiLineList())
			{
				if (current.method_2().Equals("PART GUITAR"))
				{
					this.isPartGuitar = true;
				}
				else if (current.method_2().Equals("EVENTS"))
				{
					this.isEvents = true;
				}
			}
			if (this.midiReader.getMidiLineList().Count == 1 && !this.isPartGuitar)
			{
				this.midiReader.getMidiLineList()[0].method_3("PART GUITAR");
				this.isPartGuitar = true;
			}
			if (!this.isPartGuitar)
			{
				throw new IOException(name + "PART GUITAR not found. No chart created.");
			}
			ChartParser chartParser = new ChartParser();
			this.bpmInterpreter = chartParser.bpmInterpreter;
			this.sectionInterpreter = chartParser.sectionInterpreter;
			chartParser.difficultyWithNotes.Add("EasySingle", this.easySingle);
			chartParser.difficultyWithNotes.Add("MediumSingle", this.mediumSingle);
			chartParser.difficultyWithNotes.Add("HardSingle", this.hardSingle);
			chartParser.difficultyWithNotes.Add("ExpertSingle", this.expertSingle);
			chartParser.difficultyWithNotes.Add("EasyDoubleGuitar", this.easyDoubleGuitar);
			chartParser.difficultyWithNotes.Add("MediumDoubleGuitar", this.mediumDoubleGuitar);
			chartParser.difficultyWithNotes.Add("HardDoubleGuitar", this.hardDoubleGuitar);
			chartParser.difficultyWithNotes.Add("ExpertDoubleGuitar", this.expertDoubleGuitar);
			chartParser.difficultyWithNotes.Add("EasyDoubleBass", this.easyDoubleBass);
			chartParser.difficultyWithNotes.Add("MediumDoubleBass", this.mediumDoubleBass);
			chartParser.difficultyWithNotes.Add("HardDoubleBass", this.hardDoubleBass);
			chartParser.difficultyWithNotes.Add("ExpertDoubleBass", this.expertDoubleBass);
			chartParser.instrumentList.Add("EasyDrums", this.easyDrums);
			chartParser.instrumentList.Add("MediumDrums", this.mediumDrums);
			chartParser.instrumentList.Add("HardDrums", this.hardDrums);
			chartParser.instrumentList.Add("ExpertDrums", this.expertDrums);
			chartParser.instrumentList.Add("EasyKeyboard", this.easyKeyboard);
			chartParser.instrumentList.Add("MediumKeyboard", this.mediumKeyboard);
			chartParser.instrumentList.Add("HardKeyboard", this.hardKeyboard);
			chartParser.instrumentList.Add("ExpertKeyboard", this.expertKeyboard);
			chartParser.constant480 = 480;
			this.resolution = 480.0 / (double)this.midiReader.method_0();
			object obj = name;
			name = string.Concat(new object[]
			{
				obj,
				"NumTracks = ",
				this.midiReader.getMidiLineList().Count,
				"\n"
			});
			this.method_1(this.midiReader.getMidiLineList()[0]);
			foreach (MIDILine midiLine in this.midiReader.getMidiLineList())
			{
				if (midiLine.method_2().Equals("PART GUITAR"))
				{
					this.getNotes(midiLine, 0);
				}
				else if (midiLine.method_2().Equals("T1 GEMS"))
				{
					this.getNotes(midiLine, 0);
				}
				else if (midiLine.method_2().Equals("PART GUITAR COOP"))
				{
					this.getNotes(midiLine, 1);
				}
				else if (midiLine.method_2().Equals("PART RHYTHM"))
				{
					this.notBass = true;
					this.getNotes(midiLine, 3);
				}
				else if (midiLine.method_2().Equals("PART BASS"))
				{
					this.getNotes(midiLine, 3);
				}
				else if (midiLine.method_2().Equals("EVENTS"))
				{
					this.getNotes(midiLine, 4);
				}
				else if (midiLine.method_2().Equals("BAND DRUMS"))
				{
					this.getNotes(midiLine, 5);
				}
				else if (midiLine.method_2().Equals("BAND KEYS"))
				{
					this.getNotes(midiLine, 7);
				}
				else
				{
					name = name + "Track (" + midiLine.method_2() + ") ignored.\n";
				}
			}
			chartParser.gh3SongInfo.title = this.songTitle;
			chartParser.gh3SongInfo.not_bass = this.notBass;
			name += "Conversion Complete!";
			Console.WriteLine(name);
			chartParser.removeEmptyParts();
			return chartParser;
		}

		private void method_1(MIDILine class353_0)
		{
			this.songTitle = class353_0.method_2();
			foreach (AbstractNoteClass current in class353_0.method_0())
			{
				int num = Convert.ToInt32((double)current.method_0() * this.resolution);
				if (current is zzNote1)
				{
					zzNote1 @class = (zzNote1)current;
					if (!this.isEvents && @class.method_2() == zzNote1.Enum37.const_0)
					{
						this.method_4(4, num, "section " + @class.method_1());
					}
				}
				else if (current is BpmNote1)
				{
					int num2 = ((BpmNote1)current).method_1();
					this.bpmInterpreter.bpmList.Add(num, Convert.ToInt32(Math.Floor(60000000.0 / (double)num2 * 1000.0)));
				}
				else if (current is zzNote338)
				{
					this.bpmInterpreter.TSList.Add(num, ((zzNote338)current).method_1());
				}
			}
		}

		private void getNotes(MIDILine midiLine, int difficulty)
		{
			bool[] array = new bool[midiLine.method_0().Count];
			List<AbstractNoteClass> list = midiLine.method_0();
			for (int i = 0; i < list.Count; i++)
			{
				if (!array[i])
				{
					int num = Convert.ToInt32((double)list[i].method_0() * this.resolution);
					if (list[i] is MIDINote)
					{
						MIDINote midiNote = (MIDINote)list[i];
						if (midiNote.method_5())
						{
							int j = -1;
							int num2 = i + 1;
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
										j = Convert.ToInt32((double)list[num2].method_0() * this.resolution);
										array[num2] = true;
									}
									else
									{
										j = Convert.ToInt32((double)list[num2].method_0() * this.resolution);
									}
								}
								num2++;
							}
							int num3 = Convert.ToInt32(j - num);
							if (num3 <= 160)
							{
								num3 = 0;
							}
							this.method_3(difficulty, num, midiNote, num3);
						}
					}
					else if (list[i] is zzNote1)
					{
						zzNote1 class2 = (zzNote1)list[i];
						List<string> list2 = this.method_5(difficulty - 4);
						string text = class2.method_1();
						if (text.StartsWith("["))
						{
							text = text.Substring(1, text.Length - 2);
						}
						if (list2.Contains(text) || text.Contains("section "))
						{
							this.method_4(difficulty, num, text);
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
					noteEvenInterpreter = this.easySingle;
					break;
				case 1:
					noteEvenInterpreter = this.easyDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = this.easyDoubleBass;
					break;
				}
				break;
			case Difficulty.Medium:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = this.mediumSingle;
					break;
				case 1:
					noteEvenInterpreter = this.mediumDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = this.mediumDoubleBass;
					break;
				}
				break;
			case Difficulty.Hard:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = this.hardSingle;
					break;
				case 1:
					noteEvenInterpreter = this.hardDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = this.hardDoubleBass;
					break;
				}
				break;
			case Difficulty.Expert:
				switch (instrumentType)
				{
				case 0:
					noteEvenInterpreter = this.expertSingle;
					break;
				case 1:
					noteEvenInterpreter = this.expertDoubleGuitar;
					break;
				case 3:
					noteEvenInterpreter = this.expertDoubleBass;
					break;
				}
				break;
			default:
				if (!this.bool_3 && midiNote.method_2() == MIDINoteMask.StarPower)
				{
					this.bool_3 = true;
					this.expertSingle.class228_1.Clear();
					this.hardSingle.class228_1.Clear();
					this.mediumSingle.class228_1.Clear();
					this.easySingle.class228_1.Clear();
				}
				else if (!this.bool_3)
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
				bool[] array = new bool[32];
				array[(int)midiNote.method_3()] = true;
				noteEvenInterpreter.noteList.Add(int_1, new NotesAtOffset(array, int_2));
				return;
			}
			else
			{
				if (midiNote.method_2() == MIDINoteMask.StarPower && !this.expertSingle.class228_1.ContainsKey(int_1))
				{
					this.expertSingle.class228_1.Add(int_1, int_2);
					this.hardSingle.class228_1.Add(int_1, int_2);
					this.mediumSingle.class228_1.Add(int_1, int_2);
					this.easySingle.class228_1.Add(int_1, int_2);
					return;
				}
				if (midiNote.method_2() == MIDINoteMask.Unk7 && !noteEvenInterpreter.class228_1.ContainsKey(int_1) && !this.bool_3)
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
				return;
			}
		}

		private void method_4(int int_0, int int_1, string string_2)
		{
			if (int_0 == 4)
			{
				if (string_2.Contains("section "))
				{
					this.sectionInterpreter.sectionList.Add(int_1, string_2);
					return;
				}
				if (this.sectionInterpreter.otherList.method_4(int_1))
				{
					this.sectionInterpreter.otherList[int_1].Add(string_2);
					return;
				}
				this.sectionInterpreter.otherList.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				return;
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
					@class = this.expertSingle;
					class2 = this.hardSingle;
					class3 = this.mediumSingle;
					class4 = this.easySingle;
					break;
				case 1:
					@class = this.expertDoubleGuitar;
					class2 = this.hardDoubleGuitar;
					class3 = this.mediumDoubleGuitar;
					class4 = this.easyDoubleGuitar;
					break;
				case 3:
					@class = this.expertDoubleBass;
					class2 = this.hardDoubleBass;
					class3 = this.mediumDoubleBass;
					class4 = this.easyDoubleBass;
					break;
				case 5:
					this.expertDrums.method_5(int_1, string_2);
					this.hardDrums.method_5(int_1, string_2);
					this.mediumDrums.method_5(int_1, string_2);
					this.easyDrums.method_5(int_1, string_2);
					return;
				case 7:
					this.expertKeyboard.method_5(int_1, string_2);
					this.hardKeyboard.method_5(int_1, string_2);
					this.mediumKeyboard.method_5(int_1, string_2);
					this.easyKeyboard.method_5(int_1, string_2);
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
				@class.eventList.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class2.eventList.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class3.eventList.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class4.eventList.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				return;
			}
		}

		private List<string> method_5(int int_0)
		{
			if (this.uselessEvents.Count == 0)
			{
				this.uselessEvents.Add("lighting (chase)");
				this.uselessEvents.Add("lighting (strobe)");
				this.uselessEvents.Add("lighting (color1)");
				this.uselessEvents.Add("lighting (color2)");
				this.uselessEvents.Add("lighting (sweep)");
				this.uselessEvents.Add("crowd_lighters_fast");
				this.uselessEvents.Add("crowd_lighters_off");
				this.uselessEvents.Add("crowd_lighters_slow");
				this.uselessEvents.Add("crowd_half_tempo");
				this.uselessEvents.Add("crowd_normal_tempo");
				this.uselessEvents.Add("crowd_double_tempo");
				this.uselessEvents.Add("band_jump");
				this.uselessEvents.Add("sync_head_bang");
				this.uselessEvents.Add("sync_wag");
				this.uselessEvents.Add("lighting ()");
				this.uselessEvents.Add("lighting (flare)");
				this.uselessEvents.Add("lighting (blackout)");
				this.uselessEvents.Add("music_start");
				this.uselessEvents.Add("verse");
				this.uselessEvents.Add("chorus");
				this.uselessEvents.Add("solo");
				this.uselessEvents.Add("end");
				this.uselessEvents.Add("idle");
				this.uselessEvents.Add("play");
				this.uselessEvents.Add("solo_on");
				this.uselessEvents.Add("solo_off");
				this.uselessEvents.Add("wail_on");
				this.uselessEvents.Add("wail_off");
				this.uselessEvents.Add("drum_on");
				this.uselessEvents.Add("drum_off");
				this.uselessEvents.Add("sing_on");
				this.uselessEvents.Add("sing_off");
				this.uselessEvents.Add("bass_on");
				this.uselessEvents.Add("bass_off");
				this.uselessEvents.Add("gtr_on");
				this.uselessEvents.Add("gtr_off");
				this.uselessEvents.Add("ow_face_on");
				this.uselessEvents.Add("ow_face_off");
				this.uselessEvents.Add("half_tempo");
				this.uselessEvents.Add("normal_tempo");
				this.uselessEvents.Add("half_time");
				this.uselessEvents.Add("double_time");
				this.uselessEvents.Add("allbeat");
				this.uselessEvents.Add("nobeat");
			}
			return this.uselessEvents;
		}
	}
}
