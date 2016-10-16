using ns14;
using System;
using System.Collections.Generic;

namespace ns15
{
	public class NoteEventInterpreter
	{
		public Track<int, NotesAtOffset> noteList = new Track<int, NotesAtOffset>();

        //SP
		public Track<int, int> class228_1 = new Track<int, int>();

        //SP
        public Track<int, int> class228_2 = new Track<int, int>();

        //SP
        public Track<int, int> class228_3 = new Track<int, int>();

        //SP
        public Track<int, int> class228_4 = new Track<int, int>();

        //SP
        public Track<int, int> class228_5 = new Track<int, int>();

        //SP
        public Track<int, int> class228_6 = new Track<int, int>();

        //Events
        public Track<int, List<string>> eventList = new Track<int, List<string>>();

		public bool alwaysTrue = true;

		private string currentEventLine;

		public NoteEventInterpreter()
		{
		}

		public NoteEventInterpreter(string[] stringImported, int constant480, bool ConvertEvents)
		{
			if (!(this.alwaysTrue = (stringImported.Length == 0)))//If string is empty
			{
                //Cycles through the string array imported (All notes/SP)
				for (int i = 0; i < stringImported.Length; i++)
				{
					string currentString = stringImported[i];
                    /*
                    Indexes:
                    0=Offset
                    1=Event Type
                    2=Note Value
                    3=Sustain Length
                    */
					string[] NotesEventsArray = currentString.Split(new char[]
					{
						' ',
						'\t',
						'='
					}, StringSplitOptions.RemoveEmptyEntries);
					int offset = ChartParser.getNoteFromResolution(NotesEventsArray[0]);
					string eventType;
					if ((eventType = NotesEventsArray[1]) != null)
					{
						if (!(eventType == "N"))
						{
							if (!(eventType == "S"))
							{
								if (eventType == "E")
								{
                                    //Interprets Events
									if (this.eventList.ContainsKey(offset))
									{
										this.currentEventLine = NotesEventsArray[2];
                                        for (int j = 3; j < NotesEventsArray.Length; j++)
										{
											this.currentEventLine = this.currentEventLine + " " + NotesEventsArray[j];
										}
                                        this.eventList[offset].Add(this.currentEventLine);
									}
									else
									{
										this.currentEventLine = NotesEventsArray[2];
										for (int k = 3; k < NotesEventsArray.Length; k++)
										{
											this.currentEventLine = this.currentEventLine + " " + NotesEventsArray[k];
										}
                                        if (ConvertEvents)
                                        {
                                            if (!this.noteList.ContainsKey(offset))
                                            {
                                                this.noteList.Add(offset, new NotesAtOffset());
                                            }
                                            if (this.currentEventLine.Equals("*") || this.currentEventLine.ToLower().Equals("f"))
                                            {
                                                this.noteList[offset].noteValues[5] = true;
                                            }
                                            else if (this.currentEventLine.Equals("t"))
                                            {
                                                this.noteList[offset].noteValues[6] = true;
                                            }
                                            else if (this.currentEventLine.Equals("o"))
                                            {
                                                this.noteList[offset].noteValues[7] = true;
                                            }
                                        }
										this.eventList.Add(offset, new List<string>());
										this.eventList[offset].Add(this.currentEventLine);
									}
								}
							}
                            //Interprets Starpower
                            else
                            {
								switch (Convert.ToInt32(NotesEventsArray[2]))
								{
								case 0:
									if (!this.class228_2.ContainsKey(offset))
									{
										this.class228_2.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 1:
									if (!this.class228_3.ContainsKey(offset))
									{
										this.class228_3.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 2:
									if (!this.class228_1.ContainsKey(offset))
									{
										this.class228_1.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 3:
									if (!this.class228_4.ContainsKey(offset))
									{
										this.class228_4.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 4:
									if (!this.class228_5.ContainsKey(offset))
									{
										this.class228_5.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 5:
									if (!this.class228_6.ContainsKey(offset))
									{
										this.class228_6.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								}
							}
						}
                        //Interprets Notes
                        /*
                        Indexes:
                        0=Offset
                        1=Event Type
                        2=Note Value
                        3=Sustain Length
                        */
                         else
                        {
                            bool[] notes = new bool[32];
							int sustainLength = ChartParser.getNoteFromResolution(NotesEventsArray[3]);
                            if (sustainLength <= constant480 / 4)
							{
								sustainLength = 0;
							}
							if (!this.noteList.ContainsKey(offset))
							{
								this.noteList.Add(offset, new NotesAtOffset(notes, sustainLength));
							}
							else
							{
								int currentSustainLength = this.noteList[offset].sustainLength;
                                //Updates sustain length
								if (currentSustainLength < sustainLength)
								{
									this.noteList[offset].sustainLength = sustainLength;
								}
							}
                            int note = Convert.ToInt32(NotesEventsArray[2]);
							this.noteList[offset].noteValues[note] = true;
                        }
					}
				}
			}
		}
	}
}
