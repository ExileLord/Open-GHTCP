using System;
using System.Collections.Generic;
using ns14;

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

		private readonly string currentEventLine;

		public NoteEventInterpreter()
		{
		}

		public NoteEventInterpreter(string[] stringImported, int constant480)
		{
			if (!(alwaysTrue = (stringImported.Length == 0)))//If string is empty
			{
                //Cycles through the string array imported (All notes/SP)
				for (var i = 0; i < stringImported.Length; i++)
				{
					var currentString = stringImported[i];
                    /*
                    Indexes:
                    0=Offset
                    1=Event Type
                    2=Note Value
                    3=Sustain Length
                    */
					var NotesEventsArray = currentString.Split(new[]
					{
						' ',
						'\t',
						'='
					}, StringSplitOptions.RemoveEmptyEntries);
					var offset = ChartParser.getNoteFromResolution(NotesEventsArray[0]);
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
									if (eventList.ContainsKey(offset))
									{
										currentEventLine = NotesEventsArray[2];
                                        for (var j = 3; j < NotesEventsArray.Length; j++)
										{
											currentEventLine = currentEventLine + " " + NotesEventsArray[j];
										}
                                        eventList[offset].Add(currentEventLine);
									}
									else
									{
										currentEventLine = NotesEventsArray[2];
										for (var k = 3; k < NotesEventsArray.Length; k++)
										{
											currentEventLine = currentEventLine + " " + NotesEventsArray[k];
										}
										eventList.Add(offset, new List<string>());
										eventList[offset].Add(currentEventLine);
									}
								}
							}
                            //Interprets Starpower
                            else
                            {
								switch (Convert.ToInt32(NotesEventsArray[2]))
								{
								case 0:
									if (!class228_2.ContainsKey(offset))
									{
										class228_2.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 1:
									if (!class228_3.ContainsKey(offset))
									{
										class228_3.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 2:
									if (!class228_1.ContainsKey(offset))
									{
										class228_1.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 3:
									if (!class228_4.ContainsKey(offset))
									{
										class228_4.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 4:
									if (!class228_5.ContainsKey(offset))
									{
										class228_5.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
									}
									break;
								case 5:
									if (!class228_6.ContainsKey(offset))
									{
										class228_6.Add(offset, ChartParser.getNoteFromResolution(NotesEventsArray[3]));
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
                            var notes = new bool[32];
							var sustainLength = ChartParser.getNoteFromResolution(NotesEventsArray[3]);
                            if (sustainLength <= constant480 / 4)
							{
								sustainLength = 0;
							}
							if (!noteList.ContainsKey(offset))
							{
								noteList.Add(offset, new NotesAtOffset(notes, sustainLength));
							}
							else
							{
								var currentSustainLength = noteList[offset].sustainLength;
                                //Updates sustain length
								if (currentSustainLength < sustainLength)
								{
									noteList[offset].sustainLength = sustainLength;
								}
							}
                            var note = Convert.ToInt32(NotesEventsArray[2]);
							noteList[offset].noteValues[note] = true;
                        }
					}
				}
			}
		}
	}
}
