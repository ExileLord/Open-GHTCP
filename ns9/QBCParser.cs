using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GuitarHero.Songlist;
using ns14;
using ns15;
using ns16;
using ns18;
using ns20;
using ns21;
using ns22;

namespace ns9
{
	public class QBCParser
	{
		public Dictionary<string, Track<int, NotesAtOffset>> noteList = new Dictionary<string, Track<int, NotesAtOffset>>();

		public Dictionary<string, Track<int, int[]>> spList = new Dictionary<string, Track<int, int[]>>();

		public Dictionary<string, Track<int, int[]>> battleNoteList = new Dictionary<string, Track<int, int[]>>();

		public Fretbar<int> FretbarList;

		public Track<int, int[]> tsList = new Track<int, int[]>();

		public Track<int, string> class228_1 = new Track<int, string>();

		public Track<int, int> class228_2 = new Track<int, int>();

		public Track<int, int> class228_3 = new Track<int, int>();

		public Track<int, int> bpmList = new Track<int, int>();

		public Track<int, int> class228_5 = new Track<int, int>();

		public int int_0;

		public int int_1 = 480;

		public static float float_0 = 2.82352948f;

		public GH3Song gh3Song_0 = new GH3Song();

		private Track<int, int> class228_6;

		private FloatListNode class287_0 = new FloatListNode(true);

		public QBCParser()
		{
			FretbarList = new Fretbar<int>();
		}

		public QBCParser(GH3Song gh3Song_1) : this()
		{
			gh3Song_0 = gh3Song_1;
		}

		public QBCParser(string fileName)
		{
			var list = new List<string>();
			var streamReader = File.OpenText(fileName);
			string text = null;
			string currentLine;
			while ((currentLine = streamReader.ReadLine()) != null)
			{
				if (currentLine.StartsWith("["))
				{
					text = currentLine.Split(new[]
					{
						'[',
						']'
					}, StringSplitOptions.RemoveEmptyEntries)[0];
				}
				else if (!currentLine.Equals("{"))
				{
				    if (currentLine.Equals("}"))
					{
						string key;
						if ((key = text) == null)
						{
							goto IL_8AA;
						}
						if (Class369.dictionary_0 == null)
						{
							Class369.dictionary_0 = new Dictionary<string, int>(8)
							{
								{
									"Song",
									0
								},
								{
									"SyncTrack",
									1
								},
								{
									"FretBars",
									2
								},
								{
									"Events",
									3
								},
								{
									"FaceOffP1",
									4
								},
								{
									"FaceOffP2",
									5
								},
								{
									"BossBattleP1",
									6
								},
								{
									"BossBattleP2",
									7
								}
							};
						}
						int num;
						if (Class369.dictionary_0.TryGetValue(key, out num))
						{
							switch (num)
							{
							case 0:
								gh3Song_0.editable = true;
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
											string key2;
											switch (key2 = text3)
											{
											case "name":
												gh3Song_0.title = text4;
												break;
											case "artist":
												gh3Song_0.artist = text4;
												break;
											case "year":
												gh3Song_0.year = text4;
												break;
											case "player2":
												gh3Song_0.not_bass = !text4.ToLower().Equals("bass");
												break;
											case "artisttext":
												if (text4.Equals("by"))
												{
													gh3Song_0.artist_text = true;
												}
												else if (text4.Equals("as made famous by"))
												{
													gh3Song_0.artist_text = false;
												}
												else
												{
													gh3Song_0.artist_text = text4;
												}
												break;
											case "offset":
												gh3Song_0.input_offset = (gh3Song_0.gem_offset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
												break;
											case "singer":
												gh3Song_0.singer = text4;
												break;
											case "bassist":
												gh3Song_0.bassist = text4;
												break;
											case "boss":
												gh3Song_0.boss = text4;
												break;
											case "countoff":
												gh3Song_0.countoff = text4;
												break;
											case "guitarvol":
												gh3Song_0.guitar_vol = Convert.ToSingle(text4);
												break;
											case "bandvol":
												gh3Song_0.band_vol = Convert.ToSingle(text4);
												break;
											case "hopo":
												gh3Song_0.hammer_on = Convert.ToSingle(text4);
												break;
											case "originalartist":
												gh3Song_0.original_artist = text4.Equals("true");
												break;
											case "resolution":
												int_1 = Convert.ToInt32(text4);
												break;
											}
										}
									}
									goto IL_A3C;
								}
								goto IL_514;
							case 1:
								goto IL_514;
							case 2:
								goto IL_5AE;
							case 3:
								using (var enumerator2 = list.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										var current2 = enumerator2.Current;
										var array2 = current2.Split(new[]
										{
											' ',
											'\t',
											'='
										}, StringSplitOptions.RemoveEmptyEntries);
										string a;
										if ((a = array2[1]) != null && a == "S")
										{
											class228_1.Add(Convert.ToInt32(array2[0]), array2[2]);
										}
									}
									goto IL_A3C;
								}
								break;
							case 4:
								break;
							case 5:
								goto IL_72D;
							case 6:
								goto IL_7AC;
							case 7:
								goto IL_82B;
							default:
								goto IL_8AA;
							}
							using (var enumerator3 = list.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									var current3 = enumerator3.Current;
									var array3 = current3.Split(new[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a2;
									if ((a2 = array3[1]) != null && a2 == "F")
									{
										class228_2.Add(Convert.ToInt32(array3[0]), Convert.ToInt32(array3[2]));
									}
								}
								goto IL_A3C;
							}
							goto IL_72D;
							IL_5AE:
							FretbarList = new Fretbar<int>();
							foreach (var current4 in list)
							{
								FretbarList.method_1(Convert.ToInt32(current4.Trim(' ', '\t', '=')));
							}
							int_0 = (FretbarList[1] - FretbarList[0]) / 4;
							goto IL_A3C;
							IL_514:
							using (var enumerator5 = list.GetEnumerator())
							{
								while (enumerator5.MoveNext())
								{
									var current5 = enumerator5.Current;
									var array4 = current5.Split(new[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a3;
									if ((a3 = array4[1]) != null && a3 == "TS")
									{
										tsList.Add(Convert.ToInt32(array4[0]), new[]
										{
											Convert.ToInt32(array4[2]),
											Convert.ToInt32(array4[3])
										});
									}
								}
								goto IL_A3C;
							}
							goto IL_5AE;
							IL_72D:
							using (var enumerator6 = list.GetEnumerator())
							{
								while (enumerator6.MoveNext())
								{
									var current6 = enumerator6.Current;
									var array5 = current6.Split(new[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a4;
									if ((a4 = array5[1]) != null && a4 == "F")
									{
										class228_3.Add(Convert.ToInt32(array5[0]), Convert.ToInt32(array5[2]));
									}
								}
								goto IL_A3C;
							}
							IL_7AC:
							using (var enumerator7 = list.GetEnumerator())
							{
								while (enumerator7.MoveNext())
								{
									var current7 = enumerator7.Current;
									var array6 = current7.Split(new[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a5;
									if ((a5 = array6[1]) != null && a5 == "B")
									{
										bpmList.Add(Convert.ToInt32(array6[0]), Convert.ToInt32(array6[2]));
									}
								}
								goto IL_A3C;
							}
							IL_82B:
							using (var enumerator8 = list.GetEnumerator())
							{
								while (enumerator8.MoveNext())
								{
									var current8 = enumerator8.Current;
									var array7 = current8.Split(new[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a6;
									if ((a6 = array7[1]) != null && a6 == "B")
									{
										class228_5.Add(Convert.ToInt32(array7[0]), Convert.ToInt32(array7[2]));
									}
								}
								goto IL_A3C;
							}
							goto IL_8AA;
						}
						goto IL_8AA;
						IL_A3C:
						list.Clear();
						continue;
						IL_8AA:
						text = text.ToLower();
						if (!this.noteList.ContainsKey(text))
						{
							var noteList = new Track<int, NotesAtOffset>();
							var spList = new Track<int, int[]>();
							var battleNote = new Track<int, int[]>();
							foreach (var current9 in list)
							{
								var array8 = current9.Split(new[]
								{
									' ',
									'\t',
									'='
								}, StringSplitOptions.RemoveEmptyEntries);
								string a7;
								if ((a7 = array8[1]) != null)
								{
									if (!(a7 == "N"))
									{
										if (!(a7 == "S"))
										{
											if (a7 == "B")
											{
												battleNote.Add(Convert.ToInt32(array8[0]), new[]
												{
													Convert.ToInt32(array8[3]),
													Convert.ToInt32(array8[2])
												});
											}
										}
										else
										{
											spList.Add(Convert.ToInt32(array8[0]), new[]
											{
												Convert.ToInt32(array8[3]),
												Convert.ToInt32(array8[2])
											});
										}
									}
									else
									{
										noteList.Add(Convert.ToInt32(array8[0]), new NotesAtOffset(Convert.ToInt32(array8[2]), Convert.ToInt32(array8[3])));
									}
								}
							}
							this.noteList.Add(text, noteList);
							this.spList.Add(text, spList);
							battleNoteList.Add(text, battleNote);
						}
						goto IL_A3C;
					}
				    if (!currentLine.Equals(""))
				    {
				        list.Add(currentLine);
				    }
				}
			}
			streamReader.Close();
		}

		public QBCParser(string string_0, zzGenericNode1 class308_0) : this(string_0, class308_0, null)
		{
		}

		public QBCParser(string gh3SongName, zzGenericNode1 class308_0, zzGenericNode1 class308_1) : this(gh3SongName, class308_0, class308_1, null)
		{
		}

		public QBCParser(string string_0, zzGenericNode1 class308_0, zzGenericNode1 class308_1, zzGenericNode1 class308_2)
		{
			string[] array = {
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			string[] array2 = {
				"Single",
				"Double"
			};
			ArrayPointerRootNode @class;
			for (var i = 0; i < array2.Length; i++)
			{
				var a = array2[i];
				string[] array3 = {
					"Guitar",
					"Rhythm"
				};
				for (var j = 0; j < array3.Length; j++)
				{
					var text = array3[j];
					var array4 = array;
					for (var k = 0; k < array4.Length; k++)
					{
						var text2 = array4[k];
						var text3 = (text.ToLower() + ((a == "Double") ? "coop" : "") + "_" + text2.ToLower()).Replace("guitar_", "");
						@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_song_" + text3));
						if (@class != null && @class.method_7() is IntegerArrayNode)
						{
							var class2 = new Track<int, NotesAtOffset>();
							var array5 = @class.method_7().method_7<int>();
							for (var l = 0; l < array5.Length; l += 3)
							{
								class2.Add(array5[l], new NotesAtOffset(array5[l + 2], array5[l + 1]));
							}
							noteList.Add(text3, class2);
						}
						@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_" + text3 + "_star"));
						if (@class != null && @class.method_7() is ListArrayNode)
						{
							var class3 = new Track<int, int[]>();
							foreach (var current in @class.method_7().method_8<IntegerArrayNode>())
							{
								class3.Add(current[0], new[]
								{
									current[1],
									current[2]
								});
							}
							spList.Add(text3, class3);
						}
						@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_" + text3 + "_starbattlemode"));
						if (@class != null && @class.method_7() is ListArrayNode)
						{
							var class4 = new Track<int, int[]>();
							foreach (var current2 in @class.method_7().method_8<IntegerArrayNode>())
							{
								class4.Add(current2[0], new[]
								{
									current2[1],
									current2[2]
								});
							}
							battleNoteList.Add(text3, class4);
						}
					}
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_faceoffp1"));
			if (@class != null && @class.method_7() is ListArrayNode)
			{
				foreach (var current3 in @class.method_7().method_8<IntegerArrayNode>())
				{
					class228_2.Add(current3[0], current3[1]);
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_faceoffp2"));
			if (@class != null && @class.method_7() is ListArrayNode)
			{
				foreach (var current4 in @class.method_7().method_8<IntegerArrayNode>())
				{
					class228_3.Add(current4[0], current4[1]);
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_bossbattlep1"));
			if (@class != null && @class.method_7() is ListArrayNode)
			{
				foreach (var current5 in @class.method_7().method_8<IntegerArrayNode>())
				{
					bpmList.Add(current5[0], current5[1]);
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_bossbattlep2"));
			if (@class != null && @class.method_7() is ListArrayNode)
			{
				foreach (var current6 in @class.method_7().method_8<IntegerArrayNode>())
				{
					class228_5.Add(current6[0], current6[1]);
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_timesig"));
			if (@class != null && @class.method_7() is ListArrayNode)
			{
				foreach (var current7 in @class.method_7().method_8<IntegerArrayNode>())
				{
					tsList.Add(current7[0], new[]
					{
						current7[1],
						current7[2]
					});
				}
			}
			@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_fretbars"));
			if (@class != null && @class.method_7() is IntegerArrayNode)
			{
				FretbarList = new Fretbar<int>(@class.method_7().method_8<int>());
				int_0 = (FretbarList[1] - FretbarList[0]) / 4;
				try
				{
					var dictionary = new Dictionary<int, string>();
					@class = class308_0.method_5(new ArrayPointerRootNode(string_0 + "_markers"));
					if (class308_1 != null && @class != null && @class.method_7() is StructureArrayNode)
					{
						foreach (UnicodeRootNode class5 in class308_1.Nodes)
						{
							dictionary.Add(class5.int_0, class5.method_7());
						}
						using (var enumerator9 = @class.method_7().method_8<StructureHeaderNode>().GetEnumerator())
						{
							while (enumerator9.MoveNext())
							{
								var current8 = enumerator9.Current;
								class228_1.Add(((IntegerStructureNode)current8[0]).method_8(), dictionary[((FileTagStructureNode)current8[1]).method_9()]);
							}
							goto IL_7C2;
						}
					}
					if (@class != null && @class.method_7() is StructureArrayNode)
					{
						foreach (var current9 in @class.method_7().method_8<StructureHeaderNode>())
						{
							class228_1.Add(((IntegerStructureNode)current9[0]).method_8(), ((UnicodeStructureNode)current9[1]).method_8());
						}
					}
					IL_7C2:;
				}
				catch
				{
				}
				try
				{
					if (class308_2 != null)
					{
						gh3Song_0 = new GH3Song(class308_2.method_5(new StructurePointerNode(string_0)));
					}
					return;
				}
				catch
				{
					return;
				}
			}
			throw new Exception("Not a MID.QB!");
		}

		private int method_0(int int_2)
		{
			var num = class228_6.method_1(int_2);
			return Convert.ToInt32((num + (int_2 - class228_6.Keys[num]) / (double)class228_6.Values[num]) * int_1);
		}

		public ChartParser method_1()
		{
			return method_2(null);
		}

		public ChartParser method_2(GH3Song gh3Song_1)
		{
			var @class = new ChartParser(gh3Song_0);
			@class.constant480 = int_1;
			if (gh3Song_1 != null)
			{
				@class.gh3SongInfo.vmethod_0(gh3Song_1);
			}
			class228_6 = new Track<int, int>();
			if (FretbarList != null)
			{
				var value = FretbarList[0];
				FretbarList[0] = 0;
				var num = 0;
				for (var i = 1; i < FretbarList.Count; i++)
				{
					var num2 = FretbarList[i] - FretbarList[i - 1];
					var num3 = Convert.ToInt32(60000000.0 / num2);
					if (num3 != num)
					{
						@class.bpmInterpreter.bpmList.Add((i - 1) * int_1, num3);
						num = num3;
					}
					class228_6.Add(FretbarList[i - 1], num2);
				}
				FretbarList[0] = value;
				@class.sectionInterpreter.otherList.Add(method_0(FretbarList[FretbarList.Count - 1]), new List<string>(new[]
				{
					"end"
				}));
				foreach (var current in class228_1.Keys)
				{
					@class.sectionInterpreter.sectionList.Add(method_0(current), class228_1[current]);
				}
				foreach (var current2 in tsList.Keys)
				{
					@class.bpmInterpreter.TSList.Add(method_0(current2), tsList[current2][0]);
				}
				var class2 = new Track<int, int>();
				var class3 = new Track<int, int>();
				foreach (var current3 in class228_2.Keys)
				{
					var num4 = method_0(current3);
					var num5 = method_0(current3 + class228_2[current3] - int_0) - num4;
					class2.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
				}
				foreach (var current4 in class228_3.Keys)
				{
					var num4 = method_0(current4);
					var num5 = method_0(current4 + class228_3[current4] - int_0) - num4;
					class3.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
				}
				var class4 = new Track<int, int>();
				var class5 = new Track<int, int>();
				foreach (var current5 in bpmList.Keys)
				{
					var num4 = method_0(current5);
					var num5 = method_0(current5 + bpmList[current5] - int_0) - num4;
					class4.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
				}
				foreach (var current6 in class228_5.Keys)
				{
					var num4 = method_0(current6);
					var num5 = method_0(current6 + class228_5[current6] - int_0) - num4;
					class5.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
				}
				string[] array = {
					"Easy",
					"Medium",
					"Hard",
					"Expert"
				};
				string[] array2 = {
					"Single",
					"Double"
				};
				for (var j = 0; j < array2.Length; j++)
				{
					var text = array2[j];
					string[] array3 = {
						"Guitar",
						"Rhythm"
					};
					for (var k = 0; k < array3.Length; k++)
					{
						var text2 = array3[k];
						var array4 = array;
						for (var l = 0; l < array4.Length; l++)
						{
							var text3 = array4[l];
							var key = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower()).Replace("guitar_", "");
							if (noteList.ContainsKey(key))
							{
								var class6 = new NoteEventInterpreter();
								var class7 = noteList[key];
								foreach (var current7 in class7.Keys)
								{
									var num4 = method_0(current7);
									var num5 = method_0(current7 + class7[current7].sustainLength - int_0) - num4;
									class6.noteList.Add(num4, new NotesAtOffset(class7[current7].noteValues, (num5 <= int_1 / 4) ? 0 : num5));
								}
								class6.alwaysTrue = false;
								if (spList.ContainsKey(key))
								{
									var class8 = spList[key];
									foreach (var current8 in class8.Keys)
									{
										var num4 = method_0(current8);
										var num5 = method_0(current8 + class8[current8][0] - int_0) - num4;
										class6.class228_1.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
									}
								}
								if (battleNoteList.ContainsKey(key))
								{
									var class9 = spList[key];
									foreach (var current9 in class9.Keys)
									{
										var num4 = method_0(current9);
										var num5 = method_0(current9 + class9[current9][0] - int_0) - num4;
										class6.class228_4.Add(num4, (num5 <= int_1 / 4) ? 0 : num5);
									}
								}
								class6.class228_2 = class2;
								class6.class228_3 = class3;
								class6.class228_5 = class4;
								class6.class228_6 = class5;
								@class.difficultyWithNotes.Add(text3 + text + text2, class6);
							}
						}
					}
				}
				class228_6.Clear();
				class228_6 = null;
				return @class;
			}
			return null;
		}

        public void qbcCreator(string fileLocation, GH3Song song)
        {
            gh3Song_0 = song;
            var streamWriter = new StreamWriter(fileLocation);
            streamWriter.WriteLine("[Song]");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("\tName = \"" + gh3Song_0.title + "\"");
            streamWriter.WriteLine("\tArtist = \"" + gh3Song_0.artist + "\"");
            streamWriter.WriteLine("\tYear = \"" + gh3Song_0.year + "\"");
            streamWriter.WriteLine("\tPlayer2 = " + (gh3Song_0.not_bass ? "Rhythm" : "Bass"));
            streamWriter.WriteLine("\tArtistText = \"" + ((gh3Song_0.artist_text is bool) ? (((bool)gh3Song_0.artist_text) ? "by" : "as made famous by") : ((string)gh3Song_0.artist_text)) + "\"");
            streamWriter.WriteLine("\tOffset = " + gh3Song_0.input_offset / -1000.0);
            if (!gh3Song_0.singer.Equals(""))
            {
                streamWriter.WriteLine("\tSinger = \"" + gh3Song_0.singer + "\"");
            }
            if (!gh3Song_0.bassist.Equals("Generic Bassist"))
            {
                streamWriter.WriteLine("\tBassist = \"" + gh3Song_0.bassist + "\"");
            }
            if (!gh3Song_0.boss.Equals(""))
            {
                streamWriter.WriteLine("\tBoss = \"" + gh3Song_0.boss + "\"");
            }
            streamWriter.WriteLine("\tCountOff = \"" + gh3Song_0.countoff + "\"");
            streamWriter.WriteLine("\tGuitarVol = " + gh3Song_0.guitar_vol);
            streamWriter.WriteLine("\tBandVol = " + gh3Song_0.band_vol);
            streamWriter.WriteLine("\tHoPo = " + gh3Song_0.hammer_on);
            streamWriter.WriteLine("\tOriginalArtist = " + (gh3Song_0.original_artist ? "true" : "false"));
            streamWriter.WriteLine("\tResolution = " + int_1);
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[SyncTrack]");
            streamWriter.WriteLine("{");
            foreach (var current in tsList.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current, " = TS ", tsList[current][0], " ", tsList[current][1]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FretBars]");
            streamWriter.WriteLine("{");
            foreach (var current2 in FretbarList)
            {
                streamWriter.WriteLine("\t" + current2);
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[Events]");
            streamWriter.WriteLine("{");
            foreach (var current3 in class228_1.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current3, " = S \"", class228_1[current3], "\""));
            }
            streamWriter.WriteLine("}");
            string[] array = {
                "",
                "rhythm_",
                "guitarcoop_",
                "rhythmcoop_"
            };
            for (var i = 0; i < array.Length; i++)
            {
                var str = array[i];
                string[] array2 = {
                    "easy",
                    "medium",
                    "hard",
                    "expert"
                };
                for (var j = 0; j < array2.Length; j++)
                {
                    var str2 = array2[j];
                    var text = str + str2;
                    var @class = noteList.ContainsKey(text) ? noteList[text] : new Track<int, NotesAtOffset>();
                    var class2 = spList.ContainsKey(text) ? spList[text] : new Track<int, int[]>();
                    var class3 = battleNoteList.ContainsKey(text) ? battleNoteList[text] : new Track<int, int[]>();
                    var class4 = new Class221<int>(@class.Keys);
                    class4.vmethod_1(class2.Keys);
                    class4.vmethod_1(class3.Keys);
                    class4.Sort();
                    var stringBuilder = new StringBuilder(text);
                    stringBuilder[0] = char.ToUpper(stringBuilder[0]);
                    if (text.Contains("_"))
                    {
                        stringBuilder[text.IndexOf('_') + 1] = char.ToUpper(stringBuilder[text.IndexOf('_') + 1]);
                    }
                    streamWriter.WriteLine("[" + stringBuilder + "]");
                    streamWriter.WriteLine("{");
                    foreach (var current4 in class4)
                    {
                        if (@class.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = N ", @class[current4].method_0(), " ", @class[current4].sustainLength));
                        }
                        if (class2.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = S ", class2[current4][1], " ", class2[current4][0]));
                        }
                        if (class3.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat("\t", current4, " = B ", class3[current4][1], " ", class3[current4][0]));
                        }
                    }
                    streamWriter.WriteLine("}");
                }
            }
            streamWriter.WriteLine("[FaceOffP1]");
            streamWriter.WriteLine("{");
            foreach (var current5 in class228_2.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current5, " = F ", class228_2[current5]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FaceOffP2]");
            streamWriter.WriteLine("{");
            foreach (var current6 in class228_3.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current6, " = F ", class228_3[current6]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP1]");
            streamWriter.WriteLine("{");
            foreach (var current7 in bpmList.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current7, " = B ", bpmList[current7]));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP2]");
            streamWriter.WriteLine("{");
            foreach (var current8 in class228_5.Keys)
            {
                streamWriter.WriteLine(string.Concat("\t", current8, " = B ", class228_5[current8]));
            }
            streamWriter.WriteLine("}");
            streamWriter.Close();
        }

        public zzGenericNode1 method_4(string string_0)
		{
			var @class = new zzGenericNode1();
			var int_ = QbSongClass1.AddKeyToDictionary("songs\\" + string_0 + ".mid.qb");
			string[] array = {
				"",
				"rhythm_",
				"guitarcoop_",
				"rhythmcoop_",
				"aux_"
			};
			for (var i = 0; i < array.Length; i++)
			{
				var str = array[i];
				string[] array2 = {
					"easy",
					"medium",
					"hard",
					"expert"
				};
				for (var j = 0; j < array2.Length; j++)
				{
					var str2 = array2[j];
					var text = str + str2;
					if (noteList.ContainsKey(text))
					{
						method_5(int_, string_0 + "_song_" + text, @class, noteList[text]);
					}
					else
					{
						method_11(int_, string_0 + "_song_" + text, @class);
					}
					if (spList.ContainsKey(text))
					{
						method_6(int_, string_0 + "_" + text + "_star", @class, spList[text]);
					}
					else
					{
						method_11(int_, string_0 + "_" + text + "_star", @class);
					}
					if (battleNoteList.ContainsKey(text))
					{
						method_6(int_, string_0 + "_" + text + "_starbattlemode", @class, battleNoteList[text]);
					}
					else
					{
						method_11(int_, string_0 + "_" + text + "_starbattlemode", @class);
					}
				}
			}
			method_7(int_, string_0 + "_faceoffp1", @class, class228_2);
			method_7(int_, string_0 + "_faceoffp2", @class, class228_3);
			method_7(int_, string_0 + "_bossbattlep1", @class, bpmList);
			method_7(int_, string_0 + "_bossbattlep2", @class, class228_5);
			method_8(int_, string_0 + "_timesig", @class);
			method_9(int_, string_0 + "_fretbars", @class);
			method_10(int_, string_0 + "_markers", @class);
			method_11(int_, string_0 + "_scripts_notes", @class);
			method_11(int_, string_0 + "_anim_notes", @class);
			method_11(int_, string_0 + "_triggers_notes", @class);
			method_11(int_, string_0 + "_cameras_notes", @class);
			method_11(int_, string_0 + "_lightshow_notes", @class);
			method_11(int_, string_0 + "_crowd_notes", @class);
			method_11(int_, string_0 + "_drums_notes", @class);
			method_11(int_, string_0 + "_performance_notes", @class);
			method_11(int_, string_0 + "_scripts", @class);
			method_11(int_, string_0 + "_anim", @class);
			method_11(int_, string_0 + "_triggers", @class);
			method_11(int_, string_0 + "_cameras", @class);
			method_11(int_, string_0 + "_lightshow", @class);
			method_11(int_, string_0 + "_crowd", @class);
			method_11(int_, string_0 + "_drums", @class);
			method_11(int_, string_0 + "_performance", @class);
			return @class;
		}

		private void method_5(int int_2, string string_0, zzGenericNode1 class308_0, Track<int, NotesAtOffset> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				method_11(int_2, string_0, class308_0);
				return;
			}
			var list = new List<int>();
			foreach (var current in class228_7.Keys)
			{
				list.Add(current);
				list.Add(class228_7[current].sustainLength);
				list.Add(class228_7[current].method_0());
			}
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, new IntegerArrayNode(list)));
		}

		private void method_6(int int_2, string string_0, zzGenericNode1 class308_0, Track<int, int[]> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				method_11(int_2, string_0, class308_0);
				return;
			}
			var @class = new ListArrayNode();
			foreach (var current in class228_7.Keys)
			{
				@class.method_3(new IntegerArrayNode(new[]
				{
					current,
					class228_7[current][0],
					class228_7[current][1]
				}));
			}
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, @class));
		}

		private void method_7(int int_2, string string_0, zzGenericNode1 class308_0, Track<int, int> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				method_11(int_2, string_0, class308_0);
				return;
			}
			var @class = new ListArrayNode();
			foreach (var current in class228_7.Keys)
			{
				@class.method_3(new IntegerArrayNode(new[]
				{
					current,
					class228_7[current]
				}));
			}
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, @class));
		}

		private void method_8(int int_2, string string_0, zzGenericNode1 class308_0)
		{
			var @class = new ListArrayNode();
			foreach (var current in tsList.Keys)
			{
				@class.method_3(new IntegerArrayNode(new[]
				{
					current,
					tsList[current][0],
					tsList[current][1]
				}));
			}
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, @class));
		}

		private void method_9(int int_2, string string_0, zzGenericNode1 class308_0)
		{
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, new IntegerArrayNode(FretbarList)));
		}

		private void method_10(int int_2, string string_0, zzGenericNode1 class308_0)
		{
			if (class228_1.Keys.Count == 0)
			{
				method_11(int_2, string_0, class308_0);
				return;
			}
			var @class = new StructureArrayNode();
			foreach (var current in class228_1.Keys)
			{
				@class.method_3(new StructureHeaderNode(new zzUnkNode294[]
				{
					new IntegerStructureNode("time", current),
					new UnicodeStructureNode("marker", class228_1[current])
				}));
			}
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, @class));
		}

		private void method_11(int int_2, string string_0, zzGenericNode1 class308_0)
		{
			class308_0.method_3(new ArrayPointerRootNode(string_0, int_2, class287_0));
		}
	}
}
