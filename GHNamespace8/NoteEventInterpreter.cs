using System;
using System.Collections.Generic;
using GHNamespace7;

namespace GHNamespace8
{
    public class NoteEventInterpreter
    {
        public Track<int, NotesAtOffset> NoteList = new Track<int, NotesAtOffset>();

        //SP
        public Track<int, int> Class2281 = new Track<int, int>();

        //SP
        public Track<int, int> Class2282 = new Track<int, int>();

        //SP
        public Track<int, int> Class2283 = new Track<int, int>();

        //SP
        public Track<int, int> Class2284 = new Track<int, int>();

        //SP
        public Track<int, int> Class2285 = new Track<int, int>();

        //SP
        public Track<int, int> Class2286 = new Track<int, int>();

        //Events
        public Track<int, List<string>> EventList = new Track<int, List<string>>();

        public bool AlwaysTrue = true;

        private readonly string _currentEventLine;

        public NoteEventInterpreter()
        {
        }

        public NoteEventInterpreter(string[] stringImported, int constant480)
        {
            if (!(AlwaysTrue = (stringImported.Length == 0))) //If string is empty
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
                    string[] notesEventsArray = currentString.Split(new[]
                    {
                        ' ',
                        '\t',
                        '='
                    }, StringSplitOptions.RemoveEmptyEntries);
                    int offset = ChartParser.GetNoteFromResolution(notesEventsArray[0]);
                    string eventType;
                    if ((eventType = notesEventsArray[1]) != null)
                    {
                        if (!(eventType == "N"))
                        {
                            if (!(eventType == "S"))
                            {
                                if (eventType == "E")
                                {
                                    //Interprets Events
                                    if (EventList.ContainsKey(offset))
                                    {
                                        _currentEventLine = notesEventsArray[2];
                                        for (int j = 3; j < notesEventsArray.Length; j++)
                                        {
                                            _currentEventLine = _currentEventLine + " " + notesEventsArray[j];
                                        }
                                        EventList[offset].Add(_currentEventLine);
                                    }
                                    else
                                    {
                                        _currentEventLine = notesEventsArray[2];
                                        for (int k = 3; k < notesEventsArray.Length; k++)
                                        {
                                            _currentEventLine = _currentEventLine + " " + notesEventsArray[k];
                                        }
                                        EventList.Add(offset, new List<string>());
                                        EventList[offset].Add(_currentEventLine);
                                    }
                                }
                            }
                            //Interprets Starpower
                            else
                            {
                                switch (Convert.ToInt32(notesEventsArray[2]))
                                {
                                    case 0:
                                        if (!Class2282.ContainsKey(offset))
                                        {
                                            Class2282.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
                                        }
                                        break;
                                    case 1:
                                        if (!Class2283.ContainsKey(offset))
                                        {
                                            Class2283.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
                                        }
                                        break;
                                    case 2:
                                        if (!Class2281.ContainsKey(offset))
                                        {
                                            Class2281.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
                                        }
                                        break;
                                    case 3:
                                        if (!Class2284.ContainsKey(offset))
                                        {
                                            Class2284.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
                                        }
                                        break;
                                    case 4:
                                        if (!Class2285.ContainsKey(offset))
                                        {
                                            Class2285.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
                                        }
                                        break;
                                    case 5:
                                        if (!Class2286.ContainsKey(offset))
                                        {
                                            Class2286.Add(offset,
                                                ChartParser.GetNoteFromResolution(notesEventsArray[3]));
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
                            int sustainLength = ChartParser.GetNoteFromResolution(notesEventsArray[3]);
                            if (sustainLength <= constant480 / 4)
                            {
                                sustainLength = 0;
                            }
                            if (!NoteList.ContainsKey(offset))
                            {
                                NoteList.Add(offset, new NotesAtOffset(notes, sustainLength));
                            }
                            else
                            {
                                int currentSustainLength = NoteList[offset].SustainLength;
                                //Updates sustain length
                                if (currentSustainLength < sustainLength)
                                {
                                    NoteList[offset].SustainLength = sustainLength;
                                }
                            }
                            int note = Convert.ToInt32(notesEventsArray[2]);
                            NoteList[offset].NoteValues[note] = true;
                        }
                    }
                }
            }
        }
    }
}