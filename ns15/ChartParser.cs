using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GuitarHero.Songlist;
using ns14;
using ns9;

namespace ns15
{
	public class ChartParser
	{
		public Dictionary<string, NoteEventInterpreter> difficultyWithNotes = new Dictionary<string, NoteEventInterpreter>();

		public Dictionary<string, InstrumentType> instrumentList = new Dictionary<string, InstrumentType>();

		public BPMInterpreter bpmInterpreter;

		public SectionInterpreter sectionInterpreter;

		public int constant480 = 480;

		public GH3Song gh3SongInfo = new GH3Song();

		private static double resolution;

		private Track<int, decimal> bpmMSTracker;

		public ChartParser()
		{
			bpmInterpreter = new BPMInterpreter();
			sectionInterpreter = new SectionInterpreter();
		}

		public ChartParser(GH3Song gh3Song_1) : this()
		{
			gh3SongInfo = gh3Song_1;
		}

        public ChartParser(string string_0, bool nothing)
        {
            List<string> list = new List<string>();
            StringReader stringReader = new StringReader(string_0);
            string bracketItems = null;
            string bracketItemsWithBrackets;
            while ((bracketItemsWithBrackets = stringReader.ReadLine()) != null)
            {
                if (bracketItemsWithBrackets.StartsWith("["))
                {
                    bracketItems = bracketItemsWithBrackets.Split(new[]
                    {
                        '[',
                        ']'
                    }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                else if (!bracketItemsWithBrackets.Equals("{"))
                {
                    if (bracketItemsWithBrackets.Equals("}"))
                    {
                        string a;
                        if ((a = bracketItems) == null)
                        {
                            goto IL_477;
                        }
                        if (a == "Song")
                        {
                            gh3SongInfo.editable = true;
                            using (List<string>.Enumerator enumerator = list.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    string current = enumerator.Current;
                                    string[] array = current.Split(new[]
                                    {
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    if (array.Length > 1)
                                    {
                                        string text3 = array[0].Trim().ToLower();
                                        string text4 = array[1].Trim().Replace("\"", "");
                                        string key;
                                        switch (key = text3)
                                        {
                                            case "name":
                                                gh3SongInfo.title = text4;
                                                break;
                                            case "artist":
                                                gh3SongInfo.artist = text4;
                                                break;
                                            case "year":
                                                gh3SongInfo.year = text4;
                                                break;
                                            case "player2":
                                                gh3SongInfo.not_bass = !text4.ToLower().Equals("bass");
                                                break;
                                            case "artisttext":
                                                if (text4.Equals("by"))
                                                {
                                                    gh3SongInfo.artist_text = true;
                                                }
                                                else if (text4.Equals("as made famous by"))
                                                {
                                                    gh3SongInfo.artist_text = false;
                                                }
                                                else
                                                {
                                                    gh3SongInfo.artist_text = text4;
                                                }
                                                break;
                                            case "offset":
                                                gh3SongInfo.input_offset = (gh3SongInfo.gem_offset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
                                                break;
                                            case "singer":
                                                gh3SongInfo.singer = text4;
                                                break;
                                            case "bassist":
                                                gh3SongInfo.bassist = text4;
                                                break;
                                            case "boss":
                                                gh3SongInfo.boss = text4;
                                                break;
                                            case "countoff":
                                                gh3SongInfo.countoff = text4;
                                                break;
                                            case "guitarvol":
                                                gh3SongInfo.guitar_vol = Convert.ToSingle(text4);
                                                break;
                                            case "bandvol":
                                                gh3SongInfo.band_vol = Convert.ToSingle(text4);
                                                break;
                                            case "hopo":
                                                gh3SongInfo.hammer_on = Convert.ToSingle(text4);
                                                break;
                                            case "originalartist":
                                                gh3SongInfo.original_artist = text4.Equals("true");
                                                break;
                                            case "resolution":
                                                resolution = 480.0 / Convert.ToDouble(text4);
                                                break;
                                        }
                                    }
                                }
                                goto IL_4D5;
                            }
                            goto IL_477;
                        }
                        if (!(a == "SyncTrack"))
                        {
                            if (!(a == "Events"))
                            {
                                goto IL_477;
                            }
                            if (sectionInterpreter == null)
                            {
                                sectionInterpreter = new SectionInterpreter(list.ToArray());
                            }
                        }
                        else if (bpmInterpreter == null)
                        {
                            bpmInterpreter = new BPMInterpreter(list.ToArray());
                        }
                    IL_4D5:
                        list.Clear();
                        continue;
                    IL_477:
                        Console.WriteLine(bracketItems + ", " + bracketItemsWithBrackets);
                        if (difficultyWithNotes.ContainsKey(bracketItems))
                        {
                            goto IL_4D5;
                        }
                        if (!bracketItems.Contains("Single") && !bracketItems.Contains("Double"))
                        {
                            instrumentList.Add(bracketItems, new InstrumentType(list.ToArray()));
                            goto IL_4D5;
                        }
                        difficultyWithNotes.Add(bracketItems, new NoteEventInterpreter(list.ToArray(), constant480));
                        goto IL_4D5;
                    }
                    if (!bracketItemsWithBrackets.Equals(""))
                    {
                        list.Add(bracketItemsWithBrackets);
                    }
                }
            }
            stringReader.Close();
            removeEmptyParts();
        }

        public ChartParser(string string_0)
		{
            List<string> list = new List<string>();
			StreamReader streamReader = File.OpenText(string_0);
			string bracketItems = null;
			string bracketItemsWithBrackets;
			while ((bracketItemsWithBrackets = streamReader.ReadLine()) != null)
			{
				if (bracketItemsWithBrackets.StartsWith("["))
				{
					bracketItems = bracketItemsWithBrackets.Split(new[]
					{
						'[',
						']'
					}, StringSplitOptions.RemoveEmptyEntries)[0];
                }
				else if (!bracketItemsWithBrackets.Equals("{"))
				{
				    if (bracketItemsWithBrackets.Equals("}"))
					{
                        string a;
						if ((a = bracketItems) == null)
						{
							goto IL_477;
						}
						if (a == "Song")
						{
							gh3SongInfo.editable = true;
							using (List<string>.Enumerator enumerator = list.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									string current = enumerator.Current;
									string[] array = current.Split(new[]
									{
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									if (array.Length > 1)
									{
										string text3 = array[0].Trim().ToLower();
										string text4 = array[1].Trim().Replace("\"", "");
										string key;
										switch (key = text3)
										{
										case "name":
											gh3SongInfo.title = text4;
											break;
										case "artist":
											gh3SongInfo.artist = text4;
											break;
										case "year":
											gh3SongInfo.year = text4;
											break;
										case "player2":
											gh3SongInfo.not_bass = !text4.ToLower().Equals("bass");
											break;
										case "artisttext":
											if (text4.Equals("by"))
											{
												gh3SongInfo.artist_text = true;
											}
											else if (text4.Equals("as made famous by"))
											{
												gh3SongInfo.artist_text = false;
											}
											else
											{
												gh3SongInfo.artist_text = text4;
											}
											break;
										case "offset":
											gh3SongInfo.input_offset = (gh3SongInfo.gem_offset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
											break;
										case "singer":
											gh3SongInfo.singer = text4;
											break;
										case "bassist":
											gh3SongInfo.bassist = text4;
											break;
										case "boss":
											gh3SongInfo.boss = text4;
											break;
										case "countoff":
											gh3SongInfo.countoff = text4;
											break;
										case "guitarvol":
											gh3SongInfo.guitar_vol = Convert.ToSingle(text4);
											break;
										case "bandvol":
											gh3SongInfo.band_vol = Convert.ToSingle(text4);
											break;
										case "hopo":
											gh3SongInfo.hammer_on = Convert.ToSingle(text4);
											break;
										case "originalartist":
											gh3SongInfo.original_artist = text4.Equals("true");
											break;
										case "resolution":
											resolution = 480.0 / Convert.ToDouble(text4);
											break;
										}
									}
								}
								goto IL_4D5;
							}
							goto IL_477;
						}
						if (!(a == "SyncTrack"))
						{
							if (!(a == "Events"))
							{
								goto IL_477;
							}
							if (sectionInterpreter == null)
							{
								sectionInterpreter = new SectionInterpreter(list.ToArray());
							}
						}
						else if (bpmInterpreter == null)
						{
							bpmInterpreter = new BPMInterpreter(list.ToArray());
						}
						IL_4D5:
						list.Clear();
						continue;
                    IL_477:
                        Console.WriteLine(bracketItems + ", " + bracketItemsWithBrackets);
                        if (difficultyWithNotes.ContainsKey(bracketItems))
						{
                            goto IL_4D5;
						}
                        if (!bracketItems.Contains("Single") && !bracketItems.Contains("Double"))
						{
							instrumentList.Add(bracketItems, new InstrumentType(list.ToArray()));
							goto IL_4D5;
						}
						difficultyWithNotes.Add(bracketItems, new NoteEventInterpreter(list.ToArray(), constant480));
                        goto IL_4D5;
					}
				    if (!bracketItemsWithBrackets.Equals(""))
				    {
				        list.Add(bracketItemsWithBrackets);
				    }
				}
			}
			streamReader.Close();
            removeEmptyParts();
        }

		public static int getNoteFromResolution(string offset)
		{
			return Convert.ToInt32(Convert.ToInt32(offset) * resolution);
		}

		public void removeEmptyParts()
		{
            string[] array = {
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				if (difficultyWithNotes.ContainsKey(str + "Single"))
				{
					difficultyWithNotes.Add(str + "SingleGuitar", difficultyWithNotes[str + "Single"]);
					difficultyWithNotes.Remove(str + "Single");
				}
				if (difficultyWithNotes.ContainsKey(str + "DoubleBass"))
				{
					if (difficultyWithNotes.ContainsKey(str + "DoubleGuitar") && !difficultyWithNotes[str + "DoubleGuitar"].alwaysTrue)
					{
						difficultyWithNotes.Add(str + "DoubleRhythm", difficultyWithNotes[str + "DoubleBass"]);
					}
					else
					{
						difficultyWithNotes.Add(str + "SingleRhythm", difficultyWithNotes[str + "DoubleBass"]);
					}
					difficultyWithNotes.Remove(str + "DoubleBass");
				}
			}
            List<string> list = new List<string>(difficultyWithNotes.Keys);
			foreach (string current in list)
			{
				if (difficultyWithNotes[current].noteList.Count == 0)
				{
					difficultyWithNotes.Remove(current);
				}
			}
            if (sectionInterpreter == null)
			{
				sectionInterpreter = new SectionInterpreter();
			}
			if (bpmInterpreter.TSList.Count == 0)
			{
                bpmInterpreter.TSList.Add(0, 4);
            }
        }

        public void chartCreator(string fileLocation, GH3Song song)
        {
            gh3SongInfo = song;
            StreamWriter streamWriter = new StreamWriter(fileLocation);
            streamWriter.WriteLine("[Song]");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("\tName = \"" + gh3SongInfo.title + "\"");
            streamWriter.WriteLine("\tArtist = \"" + gh3SongInfo.artist + "\"");
            streamWriter.WriteLine("\tYear = \"" + gh3SongInfo.year + "\"");
            streamWriter.WriteLine("\tPlayer2 = " + (gh3SongInfo.not_bass ? "Rhythm" : "Bass"));
            streamWriter.WriteLine("\tArtistText = \"" + ((gh3SongInfo.artist_text is bool) ? (((bool)gh3SongInfo.artist_text) ? "by" : "as made famous by") : ((string)gh3SongInfo.artist_text)) + "\"");
            streamWriter.WriteLine("\tOffset = " + gh3SongInfo.input_offset / -1000.0);
            if (!gh3SongInfo.singer.Equals(""))
            {
                streamWriter.WriteLine("\tSinger = \"" + gh3SongInfo.singer + "\"");
            }
            if (!gh3SongInfo.bassist.Equals("Generic Bassist"))
            {
                streamWriter.WriteLine("\tBassist = \"" + gh3SongInfo.bassist + "\"");
            }
            if (!gh3SongInfo.boss.Equals(""))
            {
                streamWriter.WriteLine("\tBoss = \"" + gh3SongInfo.boss + "\"");
            }
            streamWriter.WriteLine("\tCountOff = \"" + gh3SongInfo.countoff + "\"");
            streamWriter.WriteLine("\tGuitarVol = " + gh3SongInfo.guitar_vol);
            streamWriter.WriteLine("\tBandVol = " + gh3SongInfo.band_vol);
            streamWriter.WriteLine("\tHoPo = " + gh3SongInfo.hammer_on);
            streamWriter.WriteLine("\tOriginalArtist = " + (gh3SongInfo.original_artist ? "true" : "false"));
            streamWriter.WriteLine("\tResolution = " + constant480);
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[SyncTrack]");
            streamWriter.WriteLine("{");
            List<int> list = new List<int>(bpmInterpreter.TSList.Keys);
            foreach (int current in bpmInterpreter.bpmList.Keys)
            {
                if (!list.Contains(current))
                {
                    list.Add(current);
                }
            }
            list.Sort();
            foreach (int current2 in list)
            {
                if (bpmInterpreter.bpmList.ContainsKey(current2))
                {
                    streamWriter.WriteLine(string.Concat("\t", current2, " = B ", bpmInterpreter.bpmList[current2]));
                }
                if (bpmInterpreter.TSList.ContainsKey(current2))
                {
                    streamWriter.WriteLine(string.Concat("\t", current2, " = TS ", bpmInterpreter.TSList[current2]));
                }
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[Events]");
            streamWriter.WriteLine("{");
            list = new List<int>(sectionInterpreter.sectionList.Keys);
            foreach (int current3 in sectionInterpreter.otherList.Keys)
            {
                if (!list.Contains(current3))
                {
                    list.Add(current3);
                }
            }
            list.Sort();
            foreach (int current4 in list)
            {
                if (sectionInterpreter.sectionList.ContainsKey(current4))
                {
                    streamWriter.WriteLine(string.Concat("\t", current4, " = E \"section ", sectionInterpreter.sectionList[current4].Replace(" ", "_").ToLower(), "\""));
                }
                if (sectionInterpreter.otherList.ContainsKey(current4))
                {
                    List<string> list2 = sectionInterpreter.otherList[current4];
                    foreach (string current5 in list2)
                    {
                        streamWriter.WriteLine(string.Concat("\t", current4, " = E \"", current5, "\""));
                    }
                }
            }
            streamWriter.WriteLine("}");
            new ArrayList(difficultyWithNotes.Keys);
            string[] difficulties = {
                "Easy",
                "Medium",
                "Hard",
                "Expert"
            };
            for (int i = 0; i < difficulties.Length; i++)
            {
                string str = difficulties[i];
                string[] array2 = {
                    "Single",
                    "Double"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string str2 = array2[j];
                    string[] array3 = {
                        "Guitar",
                        "Rhythm"
                    };
                    for (int k = 0; k < array3.Length; k++)
                    {
                        string str3 = array3[k];
                        if (difficultyWithNotes.ContainsKey(str + str2 + str3))
                        {
                            string text = str + str2 + str3;
                            string printText = convertDBCName("[" + text + "]");
                            NoteEventInterpreter @class = difficultyWithNotes[text];
                            streamWriter.WriteLine(printText);
                            streamWriter.WriteLine("{");
                            list = new List<int>(@class.noteList.Keys);
                            foreach (int current6 in @class.class228_2.Keys)
                            {
                                if (!list.Contains(current6))
                                {
                                    list.Add(current6);
                                }
                            }
                            foreach (int current7 in @class.class228_3.Keys)
                            {
                                if (!list.Contains(current7))
                                {
                                    list.Add(current7);
                                }
                            }
                            foreach (int current8 in @class.class228_1.Keys)
                            {
                                if (!list.Contains(current8))
                                {
                                    list.Add(current8);
                                }
                            }
                            foreach (int current9 in @class.class228_4.Keys)
                            {
                                if (!list.Contains(current9))
                                {
                                    list.Add(current9);
                                }
                            }
                            foreach (int current10 in @class.class228_5.Keys)
                            {
                                if (!list.Contains(current10))
                                {
                                    list.Add(current10);
                                }
                            }
                            foreach (int current11 in @class.class228_6.Keys)
                            {
                                if (!list.Contains(current11))
                                {
                                    list.Add(current11);
                                }
                            }
                            foreach (int current12 in @class.eventList.Keys)
                            {
                                if (!list.Contains(current12))
                                {
                                    list.Add(current12);
                                }
                            }
                            list.Sort();
                            foreach (int current13 in list)
                            {
                                if (@class.eventList.ContainsKey(current13))
                                {
                                    List<string> list2 = @class.eventList[current13];
                                    foreach (string current14 in list2)
                                    {
                                        streamWriter.WriteLine(string.Concat("\t", current13, " = E ", current14));
                                    }
                                }
                                if (@class.noteList.ContainsKey(current13))
                                {
                                    NotesAtOffset class2 = @class.noteList[current13];
                                    for (int l = 0; l < class2.noteValues.Length; l++)
                                    {
                                        if (class2.noteValues[l])
                                        {
                                            streamWriter.WriteLine(string.Concat("\t", current13, " = N ", l, " ", class2.sustainLength));
                                        }
                                    }
                                }
                                if (@class.class228_2.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 0 ", @class.class228_2[current13]));
                                }
                                if (@class.class228_3.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 1 ", @class.class228_3[current13]));
                                }
                                if (@class.class228_1.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 2 ", @class.class228_1[current13]));
                                }
                                if (@class.class228_4.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 3 ", @class.class228_4[current13]));
                                }
                                if (@class.class228_5.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 4 ", @class.class228_5[current13]));
                                }
                                if (@class.class228_6.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 5 ", @class.class228_6[current13]));
                                }
                            }
                            streamWriter.WriteLine("}");
                        }
                    }
                }
                array2 = new[]
                {
                    "Drums",
                    "Keyboard"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string str4 = array2[j];
                    if (instrumentList.ContainsKey(str + str4))
                    {
                        string text2 = str + str4;
                        InstrumentType class3 = instrumentList[text2];
                        streamWriter.WriteLine("[" + text2 + "]");
                        streamWriter.WriteLine("{");
                        list = new List<int>(class3.Keys);
                        list.Sort();
                        foreach (int current15 in list)
                        {
                            foreach (string current16 in class3[current15])
                            {
                                streamWriter.WriteLine(string.Concat("\t", current15, " = E ", current16));
                            }
                        }
                        streamWriter.WriteLine("}");
                    }
                }
            }
            streamWriter.Close();
        }

        private String convertDBCName(String name)
        {
            String[] dbcTypes = {"[EasySingleGuitar]", "[MediumSingleGuitar]", "[HardSingleGuitar]", "[ExpertSingleGuitar]",
                "[EasyDoubleGuitar]", "[MediumDoubleGuitar]", "[HardDoubleGuitar]", "[ExpertDoubleGuitar]",
                 "[EasySingleRhythm]", "[MediumSingleRhythm]", "[HardSingleRhythm]", "[ExpertSingleRhythm]",
                 "[EasyDoubleRhythm]", "[MediumDoubleRhythm]", "[HardDoubleRhythm]", "[ExpertDoubleRhythm]"};
            String[] chartTypes = {"[EasySingle]", "[MediumSingle]", "[HardSingle]", "[ExpertSingle]",
                "[EasyDoubleGuitar]", "[MediumDoubleGuitar]", "[HardDoubleGuitar]", "[ExpertDoubleGuitar]",
                "[EasySingleBass]", "[MediumSingleBass]", "[HardSingleBass]", "[ExpertSingleBass]",
                "[EasyDoubleBass]", "[MediumDoubleBass]", "[HardDoubleBass]", "[ExpertDoubleBass]"};
            for (int i = 0; i < dbcTypes.Length; i++)
            {
                if (name.Equals(dbcTypes[i]))
                {
                    return chartTypes[i];
                }
            }
            return name;
        }

        public void dbcCreator(string fileLocation, GH3Song gh3Song)
		{
            gh3SongInfo = gh3Song;
			StreamWriter streamWriter = new StreamWriter(fileLocation);
			streamWriter.WriteLine("[Song]");
			streamWriter.WriteLine("{");
			streamWriter.WriteLine("\tName = \"" + gh3SongInfo.title + "\"");
			streamWriter.WriteLine("\tArtist = \"" + gh3SongInfo.artist + "\"");
			streamWriter.WriteLine("\tYear = \"" + gh3SongInfo.year + "\"");
			streamWriter.WriteLine("\tPlayer2 = " + (gh3SongInfo.not_bass ? "Rhythm" : "Bass"));
			streamWriter.WriteLine("\tArtistText = \"" + ((gh3SongInfo.artist_text is bool) ? (((bool)gh3SongInfo.artist_text) ? "by" : "as made famous by") : ((string)gh3SongInfo.artist_text)) + "\"");
			streamWriter.WriteLine("\tOffset = " + gh3SongInfo.input_offset / -1000.0);
			if (!gh3SongInfo.singer.Equals(""))
			{
				streamWriter.WriteLine("\tSinger = \"" + gh3SongInfo.singer + "\"");
			}
			if (!gh3SongInfo.bassist.Equals("Generic Bassist"))
			{
				streamWriter.WriteLine("\tBassist = \"" + gh3SongInfo.bassist + "\"");
			}
			if (!gh3SongInfo.boss.Equals(""))
			{
				streamWriter.WriteLine("\tBoss = \"" + gh3SongInfo.boss + "\"");
			}
			streamWriter.WriteLine("\tCountOff = \"" + gh3SongInfo.countoff + "\"");
			streamWriter.WriteLine("\tGuitarVol = " + gh3SongInfo.guitar_vol);
			streamWriter.WriteLine("\tBandVol = " + gh3SongInfo.band_vol);
			streamWriter.WriteLine("\tHoPo = " + gh3SongInfo.hammer_on);
			streamWriter.WriteLine("\tOriginalArtist = " + (gh3SongInfo.original_artist ? "true" : "false"));
			streamWriter.WriteLine("\tResolution = " + constant480);
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[SyncTrack]");
			streamWriter.WriteLine("{");
			List<int> list = new List<int>(bpmInterpreter.TSList.Keys);
			foreach (int current in bpmInterpreter.bpmList.Keys)
			{
				if (!list.Contains(current))
				{
					list.Add(current);
				}
			}
			list.Sort();
			foreach (int current2 in list)
			{
				if (bpmInterpreter.bpmList.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat("\t", current2, " = B ", bpmInterpreter.bpmList[current2]));
				}
				if (bpmInterpreter.TSList.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat("\t", current2, " = TS ", bpmInterpreter.TSList[current2]));
				}
			}
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[Events]");
			streamWriter.WriteLine("{");
			list = new List<int>(sectionInterpreter.sectionList.Keys);
			foreach (int current3 in sectionInterpreter.otherList.Keys)
			{
				if (!list.Contains(current3))
				{
					list.Add(current3);
				}
			}
			list.Sort();
			foreach (int current4 in list)
			{
				if (sectionInterpreter.sectionList.ContainsKey(current4))
				{
					streamWriter.WriteLine(string.Concat("\t", current4, " = E \"section ", sectionInterpreter.sectionList[current4].Replace(" ", "_").ToLower(), "\""));
				}
				if (sectionInterpreter.otherList.ContainsKey(current4))
				{
					List<string> list2 = sectionInterpreter.otherList[current4];
					foreach (string current5 in list2)
					{
						streamWriter.WriteLine(string.Concat("\t", current4, " = E \"", current5, "\""));
					}
				}
			}
			streamWriter.WriteLine("}");
			new ArrayList(difficultyWithNotes.Keys);
			string[] array = {
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				string[] array2 = {
					"Single",
					"Double"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string str2 = array2[j];
					string[] array3 = {
						"Guitar",
						"Rhythm"
					};
					for (int k = 0; k < array3.Length; k++)
					{
						string str3 = array3[k];
						if (difficultyWithNotes.ContainsKey(str + str2 + str3))
						{
							string text = str + str2 + str3;
							NoteEventInterpreter @class = difficultyWithNotes[text];
							streamWriter.WriteLine("[" + text + "]");
							streamWriter.WriteLine("{");
							list = new List<int>(@class.noteList.Keys);
							foreach (int current6 in @class.class228_2.Keys)
							{
								if (!list.Contains(current6))
								{
									list.Add(current6);
								}
							}
							foreach (int current7 in @class.class228_3.Keys)
							{
								if (!list.Contains(current7))
								{
									list.Add(current7);
								}
							}
							foreach (int current8 in @class.class228_1.Keys)
							{
								if (!list.Contains(current8))
								{
									list.Add(current8);
								}
							}
							foreach (int current9 in @class.class228_4.Keys)
							{
								if (!list.Contains(current9))
								{
									list.Add(current9);
								}
							}
							foreach (int current10 in @class.class228_5.Keys)
							{
								if (!list.Contains(current10))
								{
									list.Add(current10);
								}
							}
							foreach (int current11 in @class.class228_6.Keys)
							{
								if (!list.Contains(current11))
								{
									list.Add(current11);
								}
							}
							foreach (int current12 in @class.eventList.Keys)
							{
								if (!list.Contains(current12))
								{
									list.Add(current12);
								}
							}
							list.Sort();
							foreach (int current13 in list)
							{
								if (@class.eventList.ContainsKey(current13))
								{
									List<string> list2 = @class.eventList[current13];
									foreach (string current14 in list2)
									{
										streamWriter.WriteLine(string.Concat("\t", current13, " = E ", current14));
									}
								}
								if (@class.noteList.ContainsKey(current13))
								{
									NotesAtOffset class2 = @class.noteList[current13];
									for (int l = 0; l < class2.noteValues.Length; l++)
									{
										if (class2.noteValues[l])
										{
											streamWriter.WriteLine(string.Concat("\t", current13, " = N ", l, " ", class2.sustainLength));
										}
									}
								}
								if (@class.class228_2.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 0 ", @class.class228_2[current13]));
								}
								if (@class.class228_3.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 1 ", @class.class228_3[current13]));
								}
								if (@class.class228_1.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 2 ", @class.class228_1[current13]));
								}
								if (@class.class228_4.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 3 ", @class.class228_4[current13]));
								}
								if (@class.class228_5.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 4 ", @class.class228_5[current13]));
								}
								if (@class.class228_6.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 5 ", @class.class228_6[current13]));
								}
							}
							streamWriter.WriteLine("}");
						}
					}
				}
				array2 = new[]
				{
					"Drums",
					"Keyboard"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string str4 = array2[j];
					if (instrumentList.ContainsKey(str + str4))
					{
						string text2 = str + str4;
						InstrumentType class3 = instrumentList[text2];
						streamWriter.WriteLine("[" + text2 + "]");
						streamWriter.WriteLine("{");
						list = new List<int>(class3.Keys);
						list.Sort();
						foreach (int current15 in list)
						{
							foreach (string current16 in class3[current15])
							{
								streamWriter.WriteLine(string.Concat("\t", current15, " = E ", current16));
							}
						}
						streamWriter.WriteLine("}");
					}
				}
			}
			streamWriter.Close();
		}

		private int calculateOffset(int offsetInMS)
		{
			int bpmIndex = bpmInterpreter.bpmList.method_1(offsetInMS);
            int test = Convert.ToInt32(125000m * (bpmMSTracker[bpmIndex] + (offsetInMS - (decimal)bpmInterpreter.bpmList.Keys[bpmIndex]) / bpmInterpreter.bpmList.Values[bpmIndex]));
            return test;
        }

		public QBCParser ConvertToQBC()
        { 
            QBCParser @class = new QBCParser(gh3SongInfo);
			Track<int, int> track = null;
			Track<int, int> class3 = null;
			int largestOffset = 0;
            //Checks if there are any difficulties
            if (difficultyWithNotes.Count == 0)
			{
				throw new Exception("Chart file is empty and cannot be parsed to QB.");
			}
            //Finds the largest offset
            foreach (NoteEventInterpreter notes in difficultyWithNotes.Values)
			{                
				largestOffset = Math.Max(largestOffset, notes.noteList.Keys[notes.noteList.Count - 1] + notes.noteList.Values[notes.noteList.Count - 1].sustainLength);
			}
			largestOffset = ((sectionInterpreter.otherList.Count == 0) ? largestOffset : Math.Max(largestOffset, sectionInterpreter.otherList.Keys[sectionInterpreter.otherList.Count - 1]));
			bpmMSTracker = new Track<int, decimal>();
			bpmMSTracker.Add(0, 0m);
            //Adds BPMS to local list
			for (int i = 1; i < bpmInterpreter.bpmList.Count; i++)
			{
                 bpmMSTracker.Add(i, bpmMSTracker[i - 1] + (bpmInterpreter.bpmList.Keys[i] - bpmInterpreter.bpmList.Keys[i - 1]) / (decimal)bpmInterpreter.bpmList.Values[i - 1]);
            }
			string[] array = {
				"Single",
				"Double"
			};
            for (int j = 0; j < array.Length; j++)
			{
				string text = array[j];
				string[] array2 = {
					"Guitar",
					"Rhythm"
				};
				for (int k = 0; k < array2.Length; k++)
				{
					string text2 = array2[k];
					string[] array3 = {
						"Easy",
						"Medium",
						"Hard",
						"Expert"
					};
                    for (int l = 0; l < array3.Length; l++)
					{
						string text3 = array3[l];
						string difficulty = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower()).Replace("guitar_", "");
						if (difficultyWithNotes.ContainsKey(text3 + text + text2))
						{
							NoteEventInterpreter noteEventInterpreter = difficultyWithNotes[text3 + text + text2];
                            if (noteEventInterpreter.noteList.Count != 0)
							{
                                @class.noteList.Add(difficulty, new Track<int, NotesAtOffset>());
                                method_4(@class.noteList[difficulty], noteEventInterpreter.noteList);
                            }
                            if (noteEventInterpreter.class228_1.Count != 0)
							{
                                @class.spList.Add(difficulty, new Track<int, int[]>());
                                method_5(@class.spList[difficulty], noteEventInterpreter.class228_1, noteEventInterpreter.noteList);
                            }
                            if (noteEventInterpreter.class228_4.Count != 0)
							{
								@class.battleNoteList.Add(difficulty, new Track<int, int[]>());
								method_5(@class.battleNoteList[difficulty], noteEventInterpreter.class228_4, noteEventInterpreter.noteList);
							}
                            if (track == null || track.Count < noteEventInterpreter.class228_2.Count)
							{
								track = noteEventInterpreter.class228_2;
							}
                            if (class3 == null || class3.Count < noteEventInterpreter.class228_3.Count)
							{
								class3 = noteEventInterpreter.class228_3;
							}
                        }
                    }
				}
			}
            method_6(@class.class228_2, track);
			method_6(@class.class228_3, class3);
            foreach (int current2 in bpmInterpreter.TSList.Keys)
			{
				@class.tsList.Add(calculateOffset(current2), new[]
				{
					bpmInterpreter.TSList[current2],
					4
				});
			}
            int num2 = (int)Math.Ceiling(largestOffset / (double)constant480);
            for (int m = 0; m <= num2; m++)
			{
				@class.FretbarList.method_1(calculateOffset(m * constant480));
			}
            @class.FretbarList[0] = @class.FretbarList[1] - 4;
			@class.int_0 = 1;
            foreach (int current3 in sectionInterpreter.sectionList.Keys)
			{
				@class.class228_1.Add(calculateOffset(current3), sectionInterpreter.sectionList[current3]);
			}
            bpmMSTracker.Clear();
			bpmMSTracker = null;
			GC.Collect();
            return @class;
		}

		private void method_4(Track<int, NotesAtOffset> class228_1, Track<int, NotesAtOffset> class228_2)
		{
			foreach (int current in class228_2.Keys)
			{
				int num = calculateOffset(current);
				int int_ = (class228_2[current].sustainLength == 0) ? 1 : (calculateOffset(current + class228_2[current].sustainLength) - num);
				if (class228_1.ContainsKey(num))
				{
					for (int i = 0; i < 32; i++)
					{
						if (class228_2[current].noteValues[i])
						{
							class228_1[num].noteValues[i] = true;
						}
					}
				}
				else
				{
					class228_1.Add(num, new NotesAtOffset(class228_2[current].noteValues, int_));
				}
			}
		}

		private void method_5(Track<int, int[]> difficulty, Track<int, int> sp, Track<int, NotesAtOffset> notes)
		{
			foreach (int current in sp.Keys)
			{
                int num = calculateOffset(current);
                int num2 = 0;
                if (sp[current] == 0)
                {
                    num2 = 1;
                }         
                else
                {
                    int num4 = 0;
                    if ((sp.Keys[sp.method_1(current + sp[current])] > current))
                    {
                        num4 = notes.Keys[notes.method_1(sp.Keys[sp.method_1(current + sp[current])] - 1)];
                    }
                    else
                    {
                        num4 = (current + sp[current]);
                    }
                    int num3 = calculateOffset(num4);
                    //int num3 = this.method_2((sp.Keys[sp.method_1(current + sp[current])] > current) ? notes.Keys[notes.method_1(sp.Keys[sp.method_1(current + sp[current])] - 1)] : (current + sp[current]));
                    num2 = (num3 - num);
                }
                //int num2 = (sp[current] == 0) ? 1 : (this.method_2((sp.Keys[sp.method_1(current + sp[current])] > current) ? notes.Keys[notes.method_1(sp.Keys[sp.method_1(current + sp[current])] - 1)] : (current + sp[current])) - num);
                difficulty.Add(num, new[]
				{
					num2,
					notes.method_3(current, current + sp[current])
				});
            }
		}

		private void method_6(Track<int, int> class228_1, Track<int, int> class228_2)
		{
			if (class228_2 == null)
			{
				return;
			}
			foreach (int current in class228_2.Keys)
			{
				int num = calculateOffset(current);
				int value = (class228_2[current] == 0) ? 1 : (calculateOffset(current + class228_2[current]) - num);
				class228_1.Add(num, value);
			}
		}
	}
}
