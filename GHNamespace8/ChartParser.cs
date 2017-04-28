using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GHNamespace7;
using GHNamespaceN;
using GuitarHero.Songlist;

namespace GHNamespace8
{
	public class ChartParser
	{
		public Dictionary<string, NoteEventInterpreter> DifficultyWithNotes = new Dictionary<string, NoteEventInterpreter>();

		public Dictionary<string, InstrumentType> InstrumentList = new Dictionary<string, InstrumentType>();

		public BpmInterpreter BpmInterpreter;

		public SectionInterpreter SectionInterpreter;

		public int Constant480 = 480;

		public Gh3Song Gh3SongInfo = new Gh3Song();

		private static double _resolution;

		private Track<int, decimal> _bpmMsTracker;

		public ChartParser()
		{
			BpmInterpreter = new BpmInterpreter();
			SectionInterpreter = new SectionInterpreter();
		}

		public ChartParser(Gh3Song gh3Song1) : this()
		{
			Gh3SongInfo = gh3Song1;
		}

        public ChartParser(string string0, bool nothing)
        {
            var list = new List<string>();
            var stringReader = new StringReader(string0);
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
                            Gh3SongInfo.Editable = true;
                            using (var enumerator = list.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    var current = enumerator.Current;
                                    var array = current.Split(new[]
                                    {
                                        '\t',
                                        '='
                                    }, StringSplitOptions.RemoveEmptyEntries);
                                    if (array.Length > 1)
                                    {
                                        var text3 = array[0].Trim().ToLower();
                                        var text4 = array[1].Trim().Replace("\"", "");
                                        string key;
                                        switch (key = text3)
                                        {
                                            case "name":
                                                Gh3SongInfo.Title = text4;
                                                break;
                                            case "artist":
                                                Gh3SongInfo.Artist = text4;
                                                break;
                                            case "year":
                                                Gh3SongInfo.Year = text4;
                                                break;
                                            case "player2":
                                                Gh3SongInfo.NotBass = !text4.ToLower().Equals("bass");
                                                break;
                                            case "artisttext":
                                                if (text4.Equals("by"))
                                                {
                                                    Gh3SongInfo.ArtistText = true;
                                                }
                                                else if (text4.Equals("as made famous by"))
                                                {
                                                    Gh3SongInfo.ArtistText = false;
                                                }
                                                else
                                                {
                                                    Gh3SongInfo.ArtistText = text4;
                                                }
                                                break;
                                            case "offset":
                                                Gh3SongInfo.InputOffset = (Gh3SongInfo.GemOffset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
                                                break;
                                            case "singer":
                                                Gh3SongInfo.Singer = text4;
                                                break;
                                            case "bassist":
                                                Gh3SongInfo.Bassist = text4;
                                                break;
                                            case "boss":
                                                Gh3SongInfo.Boss = text4;
                                                break;
                                            case "countoff":
                                                Gh3SongInfo.Countoff = text4;
                                                break;
                                            case "guitarvol":
                                                Gh3SongInfo.GuitarVol = Convert.ToSingle(text4);
                                                break;
                                            case "bandvol":
                                                Gh3SongInfo.BandVol = Convert.ToSingle(text4);
                                                break;
                                            case "hopo":
                                                Gh3SongInfo.HammerOn = Convert.ToSingle(text4);
                                                break;
                                            case "originalartist":
                                                Gh3SongInfo.OriginalArtist = text4.Equals("true");
                                                break;
                                            case "resolution":
                                                _resolution = 480.0 / Convert.ToDouble(text4);
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
                            if (SectionInterpreter == null)
                            {
                                SectionInterpreter = new SectionInterpreter(list.ToArray());
                            }
                        }
                        else if (BpmInterpreter == null)
                        {
                            BpmInterpreter = new BpmInterpreter(list.ToArray());
                        }
                    IL_4D5:
                        list.Clear();
                        continue;
                    IL_477:
                        Console.WriteLine(bracketItems + ", " + bracketItemsWithBrackets);
                        if (DifficultyWithNotes.ContainsKey(bracketItems))
                        {
                            goto IL_4D5;
                        }
                        if (!bracketItems.Contains("Single") && !bracketItems.Contains("Double"))
                        {
                            InstrumentList.Add(bracketItems, new InstrumentType(list.ToArray()));
                            goto IL_4D5;
                        }
                        DifficultyWithNotes.Add(bracketItems, new NoteEventInterpreter(list.ToArray(), Constant480));
                        goto IL_4D5;
                    }
                    if (!bracketItemsWithBrackets.Equals(""))
                    {
                        list.Add(bracketItemsWithBrackets);
                    }
                }
            }
            stringReader.Close();
            RemoveEmptyParts();
        }

        public ChartParser(string string0)
		{
            var list = new List<string>();
			var streamReader = File.OpenText(string0);
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
							Gh3SongInfo.Editable = true;
							using (var enumerator = list.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									var current = enumerator.Current;
									var array = current.Split(new[]
									{
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									if (array.Length > 1)
									{
										var text3 = array[0].Trim().ToLower();
										var text4 = array[1].Trim().Replace("\"", "");
										string key;
										switch (key = text3)
										{
										case "name":
											Gh3SongInfo.Title = text4;
											break;
										case "artist":
											Gh3SongInfo.Artist = text4;
											break;
										case "year":
											Gh3SongInfo.Year = text4;
											break;
										case "player2":
											Gh3SongInfo.NotBass = !text4.ToLower().Equals("bass");
											break;
										case "artisttext":
											if (text4.Equals("by"))
											{
												Gh3SongInfo.ArtistText = true;
											}
											else if (text4.Equals("as made famous by"))
											{
												Gh3SongInfo.ArtistText = false;
											}
											else
											{
												Gh3SongInfo.ArtistText = text4;
											}
											break;
										case "offset":
											Gh3SongInfo.InputOffset = (Gh3SongInfo.GemOffset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
											break;
										case "singer":
											Gh3SongInfo.Singer = text4;
											break;
										case "bassist":
											Gh3SongInfo.Bassist = text4;
											break;
										case "boss":
											Gh3SongInfo.Boss = text4;
											break;
										case "countoff":
											Gh3SongInfo.Countoff = text4;
											break;
										case "guitarvol":
											Gh3SongInfo.GuitarVol = Convert.ToSingle(text4);
											break;
										case "bandvol":
											Gh3SongInfo.BandVol = Convert.ToSingle(text4);
											break;
										case "hopo":
											Gh3SongInfo.HammerOn = Convert.ToSingle(text4);
											break;
										case "originalartist":
											Gh3SongInfo.OriginalArtist = text4.Equals("true");
											break;
										case "resolution":
											_resolution = 480.0 / Convert.ToDouble(text4);
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
							if (SectionInterpreter == null)
							{
								SectionInterpreter = new SectionInterpreter(list.ToArray());
							}
						}
						else if (BpmInterpreter == null)
						{
							BpmInterpreter = new BpmInterpreter(list.ToArray());
						}
						IL_4D5:
						list.Clear();
						continue;
                    IL_477:
                        Console.WriteLine(bracketItems + ", " + bracketItemsWithBrackets);
                        if (DifficultyWithNotes.ContainsKey(bracketItems))
						{
                            goto IL_4D5;
						}
                        if (!bracketItems.Contains("Single") && !bracketItems.Contains("Double"))
						{
							InstrumentList.Add(bracketItems, new InstrumentType(list.ToArray()));
							goto IL_4D5;
						}
						DifficultyWithNotes.Add(bracketItems, new NoteEventInterpreter(list.ToArray(), Constant480));
                        goto IL_4D5;
					}
				    if (!bracketItemsWithBrackets.Equals(""))
				    {
				        list.Add(bracketItemsWithBrackets);
				    }
				}
			}
			streamReader.Close();
            RemoveEmptyParts();
        }

		public static int GetNoteFromResolution(string offset)
		{
			return Convert.ToInt32(Convert.ToInt32(offset) * _resolution);
		}

		public void RemoveEmptyParts()
		{
            string[] array = {
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (var i = 0; i < array.Length; i++)
			{
				var str = array[i];
				if (DifficultyWithNotes.ContainsKey(str + "Single"))
				{
					DifficultyWithNotes.Add(str + "SingleGuitar", DifficultyWithNotes[str + "Single"]);
					DifficultyWithNotes.Remove(str + "Single");
				}
				if (DifficultyWithNotes.ContainsKey(str + "DoubleBass"))
				{
					if (DifficultyWithNotes.ContainsKey(str + "DoubleGuitar") && !DifficultyWithNotes[str + "DoubleGuitar"].AlwaysTrue)
					{
						DifficultyWithNotes.Add(str + "DoubleRhythm", DifficultyWithNotes[str + "DoubleBass"]);
					}
					else
					{
						DifficultyWithNotes.Add(str + "SingleRhythm", DifficultyWithNotes[str + "DoubleBass"]);
					}
					DifficultyWithNotes.Remove(str + "DoubleBass");
				}
			}
            var list = new List<string>(DifficultyWithNotes.Keys);
			foreach (var current in list)
			{
				if (DifficultyWithNotes[current].NoteList.Count == 0)
				{
					DifficultyWithNotes.Remove(current);
				}
			}
            if (SectionInterpreter == null)
			{
				SectionInterpreter = new SectionInterpreter();
			}
			if (BpmInterpreter.TsList.Count == 0)
			{
                BpmInterpreter.TsList.Add(0, 4);
            }
        }

        public void ChartCreator(string fileLocation, Gh3Song song)
        {
            Gh3SongInfo = song;
            var streamWriter = new StreamWriter(fileLocation);
            streamWriter.WriteLine("[Song]");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("\tName = \"" + Gh3SongInfo.Title + "\"");
            streamWriter.WriteLine("\tArtist = \"" + Gh3SongInfo.Artist + "\"");
            streamWriter.WriteLine("\tYear = \"" + Gh3SongInfo.Year + "\"");
            streamWriter.WriteLine("\tPlayer2 = " + (Gh3SongInfo.NotBass ? "Rhythm" : "Bass"));
            streamWriter.WriteLine("\tArtistText = \"" + ((Gh3SongInfo.ArtistText is bool) ? (((bool)Gh3SongInfo.ArtistText) ? "by" : "as made famous by") : ((string)Gh3SongInfo.ArtistText)) + "\"");
            streamWriter.WriteLine("\tOffset = " + Gh3SongInfo.InputOffset / -1000.0);
            if (!Gh3SongInfo.Singer.Equals(""))
            {
                streamWriter.WriteLine("\tSinger = \"" + Gh3SongInfo.Singer + "\"");
            }
            if (!Gh3SongInfo.Bassist.Equals("Generic Bassist"))
            {
                streamWriter.WriteLine("\tBassist = \"" + Gh3SongInfo.Bassist + "\"");
            }
            if (!Gh3SongInfo.Boss.Equals(""))
            {
                streamWriter.WriteLine("\tBoss = \"" + Gh3SongInfo.Boss + "\"");
            }
            streamWriter.WriteLine("\tCountOff = \"" + Gh3SongInfo.Countoff + "\"");
            streamWriter.WriteLine("\tGuitarVol = " + Gh3SongInfo.GuitarVol);
            streamWriter.WriteLine("\tBandVol = " + Gh3SongInfo.BandVol);
            streamWriter.WriteLine("\tHoPo = " + Gh3SongInfo.HammerOn);
            streamWriter.WriteLine("\tOriginalArtist = " + (Gh3SongInfo.OriginalArtist ? "true" : "false"));
            streamWriter.WriteLine("\tResolution = " + Constant480);
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[SyncTrack]");
            streamWriter.WriteLine("{");
            var list = new List<int>(BpmInterpreter.TsList.Keys);
            foreach (var current in BpmInterpreter.BpmList.Keys)
            {
                if (!list.Contains(current))
                {
                    list.Add(current);
                }
            }
            list.Sort();
            foreach (var current2 in list)
            {
                if (BpmInterpreter.BpmList.ContainsKey(current2))
                {
                    streamWriter.WriteLine(string.Concat("\t", current2, " = B ", BpmInterpreter.BpmList[current2]));
                }
                if (BpmInterpreter.TsList.ContainsKey(current2))
                {
                    streamWriter.WriteLine(string.Concat("\t", current2, " = TS ", BpmInterpreter.TsList[current2]));
                }
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[Events]");
            streamWriter.WriteLine("{");
            list = new List<int>(SectionInterpreter.SectionList.Keys);
            foreach (var current3 in SectionInterpreter.OtherList.Keys)
            {
                if (!list.Contains(current3))
                {
                    list.Add(current3);
                }
            }
            list.Sort();
            foreach (var current4 in list)
            {
                if (SectionInterpreter.SectionList.ContainsKey(current4))
                {
                    streamWriter.WriteLine(string.Concat("\t", current4, " = E \"section ", SectionInterpreter.SectionList[current4].Replace(" ", "_").ToLower(), "\""));
                }
                if (SectionInterpreter.OtherList.ContainsKey(current4))
                {
                    var list2 = SectionInterpreter.OtherList[current4];
                    foreach (var current5 in list2)
                    {
                        streamWriter.WriteLine(string.Concat("\t", current4, " = E \"", current5, "\""));
                    }
                }
            }
            streamWriter.WriteLine("}");
            new ArrayList(DifficultyWithNotes.Keys);
            string[] difficulties = {
                "Easy",
                "Medium",
                "Hard",
                "Expert"
            };
            for (var i = 0; i < difficulties.Length; i++)
            {
                var str = difficulties[i];
                string[] array2 = {
                    "Single",
                    "Double"
                };
                for (var j = 0; j < array2.Length; j++)
                {
                    var str2 = array2[j];
                    string[] array3 = {
                        "Guitar",
                        "Rhythm"
                    };
                    for (var k = 0; k < array3.Length; k++)
                    {
                        var str3 = array3[k];
                        if (DifficultyWithNotes.ContainsKey(str + str2 + str3))
                        {
                            var text = str + str2 + str3;
                            var printText = ConvertDbcName("[" + text + "]");
                            var @class = DifficultyWithNotes[text];
                            streamWriter.WriteLine(printText);
                            streamWriter.WriteLine("{");
                            list = new List<int>(@class.NoteList.Keys);
                            foreach (var current6 in @class.Class2282.Keys)
                            {
                                if (!list.Contains(current6))
                                {
                                    list.Add(current6);
                                }
                            }
                            foreach (var current7 in @class.Class2283.Keys)
                            {
                                if (!list.Contains(current7))
                                {
                                    list.Add(current7);
                                }
                            }
                            foreach (var current8 in @class.Class2281.Keys)
                            {
                                if (!list.Contains(current8))
                                {
                                    list.Add(current8);
                                }
                            }
                            foreach (var current9 in @class.Class2284.Keys)
                            {
                                if (!list.Contains(current9))
                                {
                                    list.Add(current9);
                                }
                            }
                            foreach (var current10 in @class.Class2285.Keys)
                            {
                                if (!list.Contains(current10))
                                {
                                    list.Add(current10);
                                }
                            }
                            foreach (var current11 in @class.Class2286.Keys)
                            {
                                if (!list.Contains(current11))
                                {
                                    list.Add(current11);
                                }
                            }
                            foreach (var current12 in @class.EventList.Keys)
                            {
                                if (!list.Contains(current12))
                                {
                                    list.Add(current12);
                                }
                            }
                            list.Sort();
                            foreach (var current13 in list)
                            {
                                if (@class.EventList.ContainsKey(current13))
                                {
                                    var list2 = @class.EventList[current13];
                                    foreach (var current14 in list2)
                                    {
                                        streamWriter.WriteLine(string.Concat("\t", current13, " = E ", current14));
                                    }
                                }
                                if (@class.NoteList.ContainsKey(current13))
                                {
                                    var class2 = @class.NoteList[current13];
                                    for (var l = 0; l < class2.NoteValues.Length; l++)
                                    {
                                        if (class2.NoteValues[l])
                                        {
                                            streamWriter.WriteLine(string.Concat("\t", current13, " = N ", l, " ", class2.SustainLength));
                                        }
                                    }
                                }
                                if (@class.Class2282.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 0 ", @class.Class2282[current13]));
                                }
                                if (@class.Class2283.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 1 ", @class.Class2283[current13]));
                                }
                                if (@class.Class2281.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 2 ", @class.Class2281[current13]));
                                }
                                if (@class.Class2284.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 3 ", @class.Class2284[current13]));
                                }
                                if (@class.Class2285.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 4 ", @class.Class2285[current13]));
                                }
                                if (@class.Class2286.ContainsKey(current13))
                                {
                                    streamWriter.WriteLine(string.Concat("\t", current13, " = S 5 ", @class.Class2286[current13]));
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
                for (var j = 0; j < array2.Length; j++)
                {
                    var str4 = array2[j];
                    if (InstrumentList.ContainsKey(str + str4))
                    {
                        var text2 = str + str4;
                        var class3 = InstrumentList[text2];
                        streamWriter.WriteLine("[" + text2 + "]");
                        streamWriter.WriteLine("{");
                        list = new List<int>(class3.Keys);
                        list.Sort();
                        foreach (var current15 in list)
                        {
                            foreach (var current16 in class3[current15])
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

        private String ConvertDbcName(String name)
        {
            String[] dbcTypes = {"[EasySingleGuitar]", "[MediumSingleGuitar]", "[HardSingleGuitar]", "[ExpertSingleGuitar]",
                "[EasyDoubleGuitar]", "[MediumDoubleGuitar]", "[HardDoubleGuitar]", "[ExpertDoubleGuitar]",
                 "[EasySingleRhythm]", "[MediumSingleRhythm]", "[HardSingleRhythm]", "[ExpertSingleRhythm]",
                 "[EasyDoubleRhythm]", "[MediumDoubleRhythm]", "[HardDoubleRhythm]", "[ExpertDoubleRhythm]"};
            String[] chartTypes = {"[EasySingle]", "[MediumSingle]", "[HardSingle]", "[ExpertSingle]",
                "[EasyDoubleGuitar]", "[MediumDoubleGuitar]", "[HardDoubleGuitar]", "[ExpertDoubleGuitar]",
                "[EasySingleBass]", "[MediumSingleBass]", "[HardSingleBass]", "[ExpertSingleBass]",
                "[EasyDoubleBass]", "[MediumDoubleBass]", "[HardDoubleBass]", "[ExpertDoubleBass]"};
            for (var i = 0; i < dbcTypes.Length; i++)
            {
                if (name.Equals(dbcTypes[i]))
                {
                    return chartTypes[i];
                }
            }
            return name;
        }

        public void DbcCreator(string fileLocation, Gh3Song gh3Song)
		{
            Gh3SongInfo = gh3Song;
			var streamWriter = new StreamWriter(fileLocation);
			streamWriter.WriteLine("[Song]");
			streamWriter.WriteLine("{");
			streamWriter.WriteLine("\tName = \"" + Gh3SongInfo.Title + "\"");
			streamWriter.WriteLine("\tArtist = \"" + Gh3SongInfo.Artist + "\"");
			streamWriter.WriteLine("\tYear = \"" + Gh3SongInfo.Year + "\"");
			streamWriter.WriteLine("\tPlayer2 = " + (Gh3SongInfo.NotBass ? "Rhythm" : "Bass"));
			streamWriter.WriteLine("\tArtistText = \"" + ((Gh3SongInfo.ArtistText is bool) ? (((bool)Gh3SongInfo.ArtistText) ? "by" : "as made famous by") : ((string)Gh3SongInfo.ArtistText)) + "\"");
			streamWriter.WriteLine("\tOffset = " + Gh3SongInfo.InputOffset / -1000.0);
			if (!Gh3SongInfo.Singer.Equals(""))
			{
				streamWriter.WriteLine("\tSinger = \"" + Gh3SongInfo.Singer + "\"");
			}
			if (!Gh3SongInfo.Bassist.Equals("Generic Bassist"))
			{
				streamWriter.WriteLine("\tBassist = \"" + Gh3SongInfo.Bassist + "\"");
			}
			if (!Gh3SongInfo.Boss.Equals(""))
			{
				streamWriter.WriteLine("\tBoss = \"" + Gh3SongInfo.Boss + "\"");
			}
			streamWriter.WriteLine("\tCountOff = \"" + Gh3SongInfo.Countoff + "\"");
			streamWriter.WriteLine("\tGuitarVol = " + Gh3SongInfo.GuitarVol);
			streamWriter.WriteLine("\tBandVol = " + Gh3SongInfo.BandVol);
			streamWriter.WriteLine("\tHoPo = " + Gh3SongInfo.HammerOn);
			streamWriter.WriteLine("\tOriginalArtist = " + (Gh3SongInfo.OriginalArtist ? "true" : "false"));
			streamWriter.WriteLine("\tResolution = " + Constant480);
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[SyncTrack]");
			streamWriter.WriteLine("{");
			var list = new List<int>(BpmInterpreter.TsList.Keys);
			foreach (var current in BpmInterpreter.BpmList.Keys)
			{
				if (!list.Contains(current))
				{
					list.Add(current);
				}
			}
			list.Sort();
			foreach (var current2 in list)
			{
				if (BpmInterpreter.BpmList.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat("\t", current2, " = B ", BpmInterpreter.BpmList[current2]));
				}
				if (BpmInterpreter.TsList.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat("\t", current2, " = TS ", BpmInterpreter.TsList[current2]));
				}
			}
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[Events]");
			streamWriter.WriteLine("{");
			list = new List<int>(SectionInterpreter.SectionList.Keys);
			foreach (var current3 in SectionInterpreter.OtherList.Keys)
			{
				if (!list.Contains(current3))
				{
					list.Add(current3);
				}
			}
			list.Sort();
			foreach (var current4 in list)
			{
				if (SectionInterpreter.SectionList.ContainsKey(current4))
				{
					streamWriter.WriteLine(string.Concat("\t", current4, " = E \"section ", SectionInterpreter.SectionList[current4].Replace(" ", "_").ToLower(), "\""));
				}
				if (SectionInterpreter.OtherList.ContainsKey(current4))
				{
					var list2 = SectionInterpreter.OtherList[current4];
					foreach (var current5 in list2)
					{
						streamWriter.WriteLine(string.Concat("\t", current4, " = E \"", current5, "\""));
					}
				}
			}
			streamWriter.WriteLine("}");
			new ArrayList(DifficultyWithNotes.Keys);
			string[] array = {
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (var i = 0; i < array.Length; i++)
			{
				var str = array[i];
				string[] array2 = {
					"Single",
					"Double"
				};
				for (var j = 0; j < array2.Length; j++)
				{
					var str2 = array2[j];
					string[] array3 = {
						"Guitar",
						"Rhythm"
					};
					for (var k = 0; k < array3.Length; k++)
					{
						var str3 = array3[k];
						if (DifficultyWithNotes.ContainsKey(str + str2 + str3))
						{
							var text = str + str2 + str3;
							var @class = DifficultyWithNotes[text];
							streamWriter.WriteLine("[" + text + "]");
							streamWriter.WriteLine("{");
							list = new List<int>(@class.NoteList.Keys);
							foreach (var current6 in @class.Class2282.Keys)
							{
								if (!list.Contains(current6))
								{
									list.Add(current6);
								}
							}
							foreach (var current7 in @class.Class2283.Keys)
							{
								if (!list.Contains(current7))
								{
									list.Add(current7);
								}
							}
							foreach (var current8 in @class.Class2281.Keys)
							{
								if (!list.Contains(current8))
								{
									list.Add(current8);
								}
							}
							foreach (var current9 in @class.Class2284.Keys)
							{
								if (!list.Contains(current9))
								{
									list.Add(current9);
								}
							}
							foreach (var current10 in @class.Class2285.Keys)
							{
								if (!list.Contains(current10))
								{
									list.Add(current10);
								}
							}
							foreach (var current11 in @class.Class2286.Keys)
							{
								if (!list.Contains(current11))
								{
									list.Add(current11);
								}
							}
							foreach (var current12 in @class.EventList.Keys)
							{
								if (!list.Contains(current12))
								{
									list.Add(current12);
								}
							}
							list.Sort();
							foreach (var current13 in list)
							{
								if (@class.EventList.ContainsKey(current13))
								{
									var list2 = @class.EventList[current13];
									foreach (var current14 in list2)
									{
										streamWriter.WriteLine(string.Concat("\t", current13, " = E ", current14));
									}
								}
								if (@class.NoteList.ContainsKey(current13))
								{
									var class2 = @class.NoteList[current13];
									for (var l = 0; l < class2.NoteValues.Length; l++)
									{
										if (class2.NoteValues[l])
										{
											streamWriter.WriteLine(string.Concat("\t", current13, " = N ", l, " ", class2.SustainLength));
										}
									}
								}
								if (@class.Class2282.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 0 ", @class.Class2282[current13]));
								}
								if (@class.Class2283.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 1 ", @class.Class2283[current13]));
								}
								if (@class.Class2281.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 2 ", @class.Class2281[current13]));
								}
								if (@class.Class2284.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 3 ", @class.Class2284[current13]));
								}
								if (@class.Class2285.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 4 ", @class.Class2285[current13]));
								}
								if (@class.Class2286.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat("\t", current13, " = S 5 ", @class.Class2286[current13]));
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
				for (var j = 0; j < array2.Length; j++)
				{
					var str4 = array2[j];
					if (InstrumentList.ContainsKey(str + str4))
					{
						var text2 = str + str4;
						var class3 = InstrumentList[text2];
						streamWriter.WriteLine("[" + text2 + "]");
						streamWriter.WriteLine("{");
						list = new List<int>(class3.Keys);
						list.Sort();
						foreach (var current15 in list)
						{
							foreach (var current16 in class3[current15])
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

		private int CalculateOffset(int offsetInMs)
		{
			var bpmIndex = BpmInterpreter.BpmList.method_1(offsetInMs);
            var test = Convert.ToInt32(125000m * (_bpmMsTracker[bpmIndex] + (offsetInMs - (decimal)BpmInterpreter.BpmList.Keys[bpmIndex]) / BpmInterpreter.BpmList.Values[bpmIndex]));
            return test;
        }

		public QbcParser ConvertToQbc()
        { 
            var @class = new QbcParser(Gh3SongInfo);
			Track<int, int> track = null;
			Track<int, int> class3 = null;
			var largestOffset = 0;
            //Checks if there are any difficulties
            if (DifficultyWithNotes.Count == 0)
			{
				throw new Exception("Chart file is empty and cannot be parsed to QB.");
			}
            //Finds the largest offset
            foreach (var notes in DifficultyWithNotes.Values)
			{                
				largestOffset = Math.Max(largestOffset, notes.NoteList.Keys[notes.NoteList.Count - 1] + notes.NoteList.Values[notes.NoteList.Count - 1].SustainLength);
			}
			largestOffset = ((SectionInterpreter.OtherList.Count == 0) ? largestOffset : Math.Max(largestOffset, SectionInterpreter.OtherList.Keys[SectionInterpreter.OtherList.Count - 1]));
			_bpmMsTracker = new Track<int, decimal>();
			_bpmMsTracker.Add(0, 0m);
            //Adds BPMS to local list
			for (var i = 1; i < BpmInterpreter.BpmList.Count; i++)
			{
                 _bpmMsTracker.Add(i, _bpmMsTracker[i - 1] + (BpmInterpreter.BpmList.Keys[i] - BpmInterpreter.BpmList.Keys[i - 1]) / (decimal)BpmInterpreter.BpmList.Values[i - 1]);
            }
			string[] array = {
				"Single",
				"Double"
			};
            for (var j = 0; j < array.Length; j++)
			{
				var text = array[j];
				string[] array2 = {
					"Guitar",
					"Rhythm"
				};
				for (var k = 0; k < array2.Length; k++)
				{
					var text2 = array2[k];
					string[] array3 = {
						"Easy",
						"Medium",
						"Hard",
						"Expert"
					};
                    for (var l = 0; l < array3.Length; l++)
					{
						var text3 = array3[l];
						var difficulty = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower()).Replace("guitar_", "");
						if (DifficultyWithNotes.ContainsKey(text3 + text + text2))
						{
							var noteEventInterpreter = DifficultyWithNotes[text3 + text + text2];
                            if (noteEventInterpreter.NoteList.Count != 0)
							{
                                @class.NoteList.Add(difficulty, new Track<int, NotesAtOffset>());
                                method_4(@class.NoteList[difficulty], noteEventInterpreter.NoteList);
                            }
                            if (noteEventInterpreter.Class2281.Count != 0)
							{
                                @class.SpList.Add(difficulty, new Track<int, int[]>());
                                method_5(@class.SpList[difficulty], noteEventInterpreter.Class2281, noteEventInterpreter.NoteList);
                            }
                            if (noteEventInterpreter.Class2284.Count != 0)
							{
								@class.BattleNoteList.Add(difficulty, new Track<int, int[]>());
								method_5(@class.BattleNoteList[difficulty], noteEventInterpreter.Class2284, noteEventInterpreter.NoteList);
							}
                            if (track == null || track.Count < noteEventInterpreter.Class2282.Count)
							{
								track = noteEventInterpreter.Class2282;
							}
                            if (class3 == null || class3.Count < noteEventInterpreter.Class2283.Count)
							{
								class3 = noteEventInterpreter.Class2283;
							}
                        }
                    }
				}
			}
            method_6(@class.Class2282, track);
			method_6(@class.Class2283, class3);
            foreach (var current2 in BpmInterpreter.TsList.Keys)
			{
				@class.TsList.Add(CalculateOffset(current2), new[]
				{
					BpmInterpreter.TsList[current2],
					4
				});
			}
            var num2 = (int)Math.Ceiling(largestOffset / (double)Constant480);
            for (var m = 0; m <= num2; m++)
			{
				@class.FretbarList.method_1(CalculateOffset(m * Constant480));
			}
            @class.FretbarList[0] = @class.FretbarList[1] - 4;
			@class.Int0 = 1;
            foreach (var current3 in SectionInterpreter.SectionList.Keys)
			{
				@class.Class2281.Add(CalculateOffset(current3), SectionInterpreter.SectionList[current3]);
			}
            _bpmMsTracker.Clear();
			_bpmMsTracker = null;
			GC.Collect();
            return @class;
		}

		private void method_4(Track<int, NotesAtOffset> class2281, Track<int, NotesAtOffset> class2282)
		{
			foreach (var current in class2282.Keys)
			{
				var num = CalculateOffset(current);
				var int_ = (class2282[current].SustainLength == 0) ? 1 : (CalculateOffset(current + class2282[current].SustainLength) - num);
				if (class2281.ContainsKey(num))
				{
					for (var i = 0; i < 32; i++)
					{
						if (class2282[current].NoteValues[i])
						{
							class2281[num].NoteValues[i] = true;
						}
					}
				}
				else
				{
					class2281.Add(num, new NotesAtOffset(class2282[current].NoteValues, int_));
				}
			}
		}

		private void method_5(Track<int, int[]> difficulty, Track<int, int> sp, Track<int, NotesAtOffset> notes)
		{
			foreach (var current in sp.Keys)
			{
                var num = CalculateOffset(current);
                var num2 = 0;
                if (sp[current] == 0)
                {
                    num2 = 1;
                }         
                else
                {
                    var num4 = 0;
                    if ((sp.Keys[sp.method_1(current + sp[current])] > current))
                    {
                        num4 = notes.Keys[notes.method_1(sp.Keys[sp.method_1(current + sp[current])] - 1)];
                    }
                    else
                    {
                        num4 = (current + sp[current]);
                    }
                    var num3 = CalculateOffset(num4);
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

		private void method_6(Track<int, int> class2281, Track<int, int> class2282)
		{
			if (class2282 == null)
			{
				return;
			}
			foreach (var current in class2282.Keys)
			{
				var num = CalculateOffset(current);
				var value = (class2282[current] == 0) ? 1 : (CalculateOffset(current + class2282[current]) - num);
				class2281.Add(num, value);
			}
		}
	}
}
