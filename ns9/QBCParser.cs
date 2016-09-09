using GuitarHero.Songlist;
using ns14;
using ns15;
using ns16;
using ns18;
using ns20;
using ns21;
using ns22;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns9
{
	public class QBCParser
	{
		public Dictionary<string, Track<int, NotesAtOffset>> noteList = new Dictionary<string, Track<int, NotesAtOffset>>();

		public Dictionary<string, Track<int, int[]>> spList = new Dictionary<string, Track<int, int[]>>();

		public Dictionary<string, Track<int, int[]>> battleNoteList = new Dictionary<string, Track<int, int[]>>();

		public Class239<int> class239_0;

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

		private Class287 class287_0 = new Class287(true);

		public QBCParser()
		{
			this.class239_0 = new Class239<int>();
		}

		public QBCParser(GH3Song gh3Song_1) : this()
		{
			this.gh3Song_0 = gh3Song_1;
		}

		public QBCParser(string fileName)
		{
			List<string> list = new List<string>();
			StreamReader streamReader = File.OpenText(fileName);
			string text = null;
			string currentLine;
			while ((currentLine = streamReader.ReadLine()) != null)
			{
				if (currentLine.StartsWith("["))
				{
					text = currentLine.Split(new char[]
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
								this.gh3Song_0.editable = true;
								using (List<string>.Enumerator enumerator = list.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										string current = enumerator.Current;
										string[] array = current.Split(new char[]
										{
											'\t',
											'='
										}, StringSplitOptions.RemoveEmptyEntries);
										if (array.Length > 1)
										{
											string text3 = array[0].Trim().ToLower();
											string text4 = array[1].Trim().Replace("\"", "");
											string key2;
											switch (key2 = text3)
											{
											case "name":
												this.gh3Song_0.title = text4;
												break;
											case "artist":
												this.gh3Song_0.artist = text4;
												break;
											case "year":
												this.gh3Song_0.year = text4;
												break;
											case "player2":
												this.gh3Song_0.not_bass = !text4.ToLower().Equals("bass");
												break;
											case "artisttext":
												if (text4.Equals("by"))
												{
													this.gh3Song_0.artist_text = true;
												}
												else if (text4.Equals("as made famous by"))
												{
													this.gh3Song_0.artist_text = false;
												}
												else
												{
													this.gh3Song_0.artist_text = text4;
												}
												break;
											case "offset":
												this.gh3Song_0.input_offset = (this.gh3Song_0.gem_offset = Convert.ToInt32(Convert.ToDouble(text4) * -1000.0));
												break;
											case "singer":
												this.gh3Song_0.singer = text4;
												break;
											case "bassist":
												this.gh3Song_0.bassist = text4;
												break;
											case "boss":
												this.gh3Song_0.boss = text4;
												break;
											case "countoff":
												this.gh3Song_0.countoff = text4;
												break;
											case "guitarvol":
												this.gh3Song_0.guitar_vol = Convert.ToSingle(text4);
												break;
											case "bandvol":
												this.gh3Song_0.band_vol = Convert.ToSingle(text4);
												break;
											case "hopo":
												this.gh3Song_0.hammer_on = Convert.ToSingle(text4);
												break;
											case "originalartist":
												this.gh3Song_0.original_artist = text4.Equals("true");
												break;
											case "resolution":
												this.int_1 = Convert.ToInt32(text4);
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
								using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										string current2 = enumerator2.Current;
										string[] array2 = current2.Split(new char[]
										{
											' ',
											'\t',
											'='
										}, StringSplitOptions.RemoveEmptyEntries);
										string a;
										if ((a = array2[1]) != null && a == "S")
										{
											this.class228_1.Add(Convert.ToInt32(array2[0]), array2[2]);
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
							using (List<string>.Enumerator enumerator3 = list.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									string current3 = enumerator3.Current;
									string[] array3 = current3.Split(new char[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a2;
									if ((a2 = array3[1]) != null && a2 == "F")
									{
										this.class228_2.Add(Convert.ToInt32(array3[0]), Convert.ToInt32(array3[2]));
									}
								}
								goto IL_A3C;
							}
							goto IL_72D;
							IL_5AE:
							this.class239_0 = new Class239<int>();
							foreach (string current4 in list)
							{
								this.class239_0.method_1(Convert.ToInt32(current4.Trim(new char[]
								{
									' ',
									'\t',
									'='
								})));
							}
							this.int_0 = (this.class239_0[1] - this.class239_0[0]) / 4;
							goto IL_A3C;
							IL_514:
							using (List<string>.Enumerator enumerator5 = list.GetEnumerator())
							{
								while (enumerator5.MoveNext())
								{
									string current5 = enumerator5.Current;
									string[] array4 = current5.Split(new char[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a3;
									if ((a3 = array4[1]) != null && a3 == "TS")
									{
										this.tsList.Add(Convert.ToInt32(array4[0]), new int[]
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
							using (List<string>.Enumerator enumerator6 = list.GetEnumerator())
							{
								while (enumerator6.MoveNext())
								{
									string current6 = enumerator6.Current;
									string[] array5 = current6.Split(new char[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a4;
									if ((a4 = array5[1]) != null && a4 == "F")
									{
										this.class228_3.Add(Convert.ToInt32(array5[0]), Convert.ToInt32(array5[2]));
									}
								}
								goto IL_A3C;
							}
							IL_7AC:
							using (List<string>.Enumerator enumerator7 = list.GetEnumerator())
							{
								while (enumerator7.MoveNext())
								{
									string current7 = enumerator7.Current;
									string[] array6 = current7.Split(new char[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a5;
									if ((a5 = array6[1]) != null && a5 == "B")
									{
										this.bpmList.Add(Convert.ToInt32(array6[0]), Convert.ToInt32(array6[2]));
									}
								}
								goto IL_A3C;
							}
							IL_82B:
							using (List<string>.Enumerator enumerator8 = list.GetEnumerator())
							{
								while (enumerator8.MoveNext())
								{
									string current8 = enumerator8.Current;
									string[] array7 = current8.Split(new char[]
									{
										' ',
										'\t',
										'='
									}, StringSplitOptions.RemoveEmptyEntries);
									string a6;
									if ((a6 = array7[1]) != null && a6 == "B")
									{
										this.class228_5.Add(Convert.ToInt32(array7[0]), Convert.ToInt32(array7[2]));
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
							Track<int, NotesAtOffset> noteList = new Track<int, NotesAtOffset>();
							Track<int, int[]> spList = new Track<int, int[]>();
							Track<int, int[]> battleNote = new Track<int, int[]>();
							foreach (string current9 in list)
							{
								string[] array8 = current9.Split(new char[]
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
												battleNote.Add(Convert.ToInt32(array8[0]), new int[]
												{
													Convert.ToInt32(array8[3]),
													Convert.ToInt32(array8[2])
												});
											}
										}
										else
										{
											spList.Add(Convert.ToInt32(array8[0]), new int[]
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
							this.battleNoteList.Add(text, battleNote);
							goto IL_A3C;
						}
						goto IL_A3C;
					}
					else if (!currentLine.Equals(""))
					{
						list.Add(currentLine);
					}
				}
			}
			streamReader.Close();
		}

		public QBCParser(string string_0, Class308 class308_0) : this(string_0, class308_0, null)
		{
		}

		public QBCParser(string gh3SongName, Class308 class308_0, Class308 class308_1) : this(gh3SongName, class308_0, class308_1, null)
		{
		}

		public QBCParser(string string_0, Class308 class308_0, Class308 class308_1, Class308 class308_2)
		{
			string[] array = new string[]
			{
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			string[] array2 = new string[]
			{
				"Single",
				"Double"
			};
			Class267 @class;
			for (int i = 0; i < array2.Length; i++)
			{
				string a = array2[i];
				string[] array3 = new string[]
				{
					"Guitar",
					"Rhythm"
				};
				for (int j = 0; j < array3.Length; j++)
				{
					string text = array3[j];
					string[] array4 = array;
					for (int k = 0; k < array4.Length; k++)
					{
						string text2 = array4[k];
						string text3 = (text.ToLower() + ((a == "Double") ? "coop" : "") + "_" + text2.ToLower()).Replace("guitar_", "");
						@class = class308_0.method_5<Class267>(new Class267(string_0 + "_song_" + text3));
						if (@class != null && @class.method_7() is Class280)
						{
							Track<int, NotesAtOffset> class2 = new Track<int, NotesAtOffset>();
							int[] array5 = @class.method_7().method_7<int>();
							for (int l = 0; l < array5.Length; l += 3)
							{
								class2.Add(array5[l], new NotesAtOffset(array5[l + 2], array5[l + 1]));
							}
							this.noteList.Add(text3, class2);
						}
						@class = class308_0.method_5<Class267>(new Class267(string_0 + "_" + text3 + "_star"));
						if (@class != null && @class.method_7() is Class291)
						{
							Track<int, int[]> class3 = new Track<int, int[]>();
							foreach (Class280 current in @class.method_7().method_8<Class280>())
							{
								class3.Add(current[0], new int[]
								{
									current[1],
									current[2]
								});
							}
							this.spList.Add(text3, class3);
						}
						@class = class308_0.method_5<Class267>(new Class267(string_0 + "_" + text3 + "_starbattlemode"));
						if (@class != null && @class.method_7() is Class291)
						{
							Track<int, int[]> class4 = new Track<int, int[]>();
							foreach (Class280 current2 in @class.method_7().method_8<Class280>())
							{
								class4.Add(current2[0], new int[]
								{
									current2[1],
									current2[2]
								});
							}
							this.battleNoteList.Add(text3, class4);
						}
					}
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_faceoffp1"));
			if (@class != null && @class.method_7() is Class291)
			{
				foreach (Class280 current3 in @class.method_7().method_8<Class280>())
				{
					this.class228_2.Add(current3[0], current3[1]);
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_faceoffp2"));
			if (@class != null && @class.method_7() is Class291)
			{
				foreach (Class280 current4 in @class.method_7().method_8<Class280>())
				{
					this.class228_3.Add(current4[0], current4[1]);
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_bossbattlep1"));
			if (@class != null && @class.method_7() is Class291)
			{
				foreach (Class280 current5 in @class.method_7().method_8<Class280>())
				{
					this.bpmList.Add(current5[0], current5[1]);
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_bossbattlep2"));
			if (@class != null && @class.method_7() is Class291)
			{
				foreach (Class280 current6 in @class.method_7().method_8<Class280>())
				{
					this.class228_5.Add(current6[0], current6[1]);
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_timesig"));
			if (@class != null && @class.method_7() is Class291)
			{
				foreach (Class280 current7 in @class.method_7().method_8<Class280>())
				{
					this.tsList.Add(current7[0], new int[]
					{
						current7[1],
						current7[2]
					});
				}
			}
			@class = class308_0.method_5<Class267>(new Class267(string_0 + "_fretbars"));
			if (@class != null && @class.method_7() is Class280)
			{
				this.class239_0 = new Class239<int>(@class.method_7().method_8<int>());
				this.int_0 = (this.class239_0[1] - this.class239_0[0]) / 4;
				try
				{
					Dictionary<int, string> dictionary = new Dictionary<int, string>();
					@class = class308_0.method_5<Class267>(new Class267(string_0 + "_markers"));
					if (class308_1 != null && @class != null && @class.method_7() is Class292)
					{
						foreach (Class273 class5 in class308_1.Nodes)
						{
							dictionary.Add(class5.int_0, class5.method_7());
						}
						using (List<Class286>.Enumerator enumerator9 = @class.method_7().method_8<Class286>().GetEnumerator())
						{
							while (enumerator9.MoveNext())
							{
								Class286 current8 = enumerator9.Current;
								this.class228_1.Add(((Class299)current8[0]).method_8(), dictionary[((Class298)current8[1]).method_9()]);
							}
							goto IL_7C2;
						}
					}
					if (@class != null && @class.method_7() is Class292)
					{
						foreach (Class286 current9 in @class.method_7().method_8<Class286>())
						{
							this.class228_1.Add(((Class299)current9[0]).method_8(), ((Class307)current9[1]).method_8());
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
						this.gh3Song_0 = new GH3Song(class308_2.method_5<Class302>(new Class302(string_0)));
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
			int num = this.class228_6.method_1(int_2);
			return Convert.ToInt32((num + (double)((double) (int_2 - this.class228_6.Keys[num]) / (double)this.class228_6.Values[num])) * (double)this.int_1);
		}

		public ChartParser method_1()
		{
			return this.method_2(null);
		}

		public ChartParser method_2(GH3Song gh3Song_1)
		{
			ChartParser @class = new ChartParser(this.gh3Song_0);
			@class.constant480 = this.int_1;
			if (gh3Song_1 != null)
			{
				@class.gh3SongInfo.vmethod_0(gh3Song_1);
			}
			this.class228_6 = new Track<int, int>();
			if (this.class239_0 != null)
			{
				int value = this.class239_0[0];
				this.class239_0[0] = 0;
				int num = 0;
				for (int i = 1; i < this.class239_0.Count; i++)
				{
					int num2 = this.class239_0[i] - this.class239_0[i - 1];
					int num3 = Convert.ToInt32(60000000.0 / (double)num2);
					if (num3 != num)
					{
						@class.bpmInterpreter.bpmList.Add((i - 1) * this.int_1, num3);
						num = num3;
					}
					this.class228_6.Add(this.class239_0[i - 1], num2);
				}
				this.class239_0[0] = value;
				@class.sectionInterpreter.otherList.Add(this.method_0(this.class239_0[this.class239_0.Count - 1]), new List<string>(new string[]
				{
					"end"
				}));
				foreach (int current in this.class228_1.Keys)
				{
					@class.sectionInterpreter.sectionList.Add(this.method_0(current), this.class228_1[current]);
				}
				foreach (int current2 in this.tsList.Keys)
				{
					@class.bpmInterpreter.TSList.Add(this.method_0(current2), this.tsList[current2][0]);
				}
				Track<int, int> class2 = new Track<int, int>();
				Track<int, int> class3 = new Track<int, int>();
				foreach (int current3 in this.class228_2.Keys)
				{
					int num4 = this.method_0(current3);
					int num5 = this.method_0(current3 + this.class228_2[current3] - this.int_0) - num4;
					class2.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
				}
				foreach (int current4 in this.class228_3.Keys)
				{
					int num4 = this.method_0(current4);
					int num5 = this.method_0(current4 + this.class228_3[current4] - this.int_0) - num4;
					class3.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
				}
				Track<int, int> class4 = new Track<int, int>();
				Track<int, int> class5 = new Track<int, int>();
				foreach (int current5 in this.bpmList.Keys)
				{
					int num4 = this.method_0(current5);
					int num5 = this.method_0(current5 + this.bpmList[current5] - this.int_0) - num4;
					class4.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
				}
				foreach (int current6 in this.class228_5.Keys)
				{
					int num4 = this.method_0(current6);
					int num5 = this.method_0(current6 + this.class228_5[current6] - this.int_0) - num4;
					class5.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
				}
				string[] array = new string[]
				{
					"Easy",
					"Medium",
					"Hard",
					"Expert"
				};
				string[] array2 = new string[]
				{
					"Single",
					"Double"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string text = array2[j];
					string[] array3 = new string[]
					{
						"Guitar",
						"Rhythm"
					};
					for (int k = 0; k < array3.Length; k++)
					{
						string text2 = array3[k];
						string[] array4 = array;
						for (int l = 0; l < array4.Length; l++)
						{
							string text3 = array4[l];
							string key = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower()).Replace("guitar_", "");
							if (this.noteList.ContainsKey(key))
							{
								NoteEventInterpreter class6 = new NoteEventInterpreter();
								Track<int, NotesAtOffset> class7 = this.noteList[key];
								foreach (int current7 in class7.Keys)
								{
									int num4 = this.method_0(current7);
									int num5 = this.method_0(current7 + class7[current7].sustainLength - this.int_0) - num4;
									class6.noteList.Add(num4, new NotesAtOffset(class7[current7].noteValues, (num5 <= this.int_1 / 4) ? 0 : num5));
								}
								class6.alwaysTrue = false;
								if (this.spList.ContainsKey(key))
								{
									Track<int, int[]> class8 = this.spList[key];
									foreach (int current8 in class8.Keys)
									{
										int num4 = this.method_0(current8);
										int num5 = this.method_0(current8 + class8[current8][0] - this.int_0) - num4;
										class6.class228_1.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
									}
								}
								if (this.battleNoteList.ContainsKey(key))
								{
									Track<int, int[]> class9 = this.spList[key];
									foreach (int current9 in class9.Keys)
									{
										int num4 = this.method_0(current9);
										int num5 = this.method_0(current9 + class9[current9][0] - this.int_0) - num4;
										class6.class228_4.Add(num4, (num5 <= this.int_1 / 4) ? 0 : num5);
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
				this.class228_6.Clear();
				this.class228_6 = null;
				return @class;
			}
			return null;
		}

        public void qbcCreator(string fileLocation, GH3Song song)
        {
            this.gh3Song_0 = song;
            StreamWriter streamWriter = new StreamWriter(fileLocation);
            streamWriter.WriteLine("[Song]");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("\tName = \"" + this.gh3Song_0.title + "\"");
            streamWriter.WriteLine("\tArtist = \"" + this.gh3Song_0.artist + "\"");
            streamWriter.WriteLine("\tYear = \"" + this.gh3Song_0.year + "\"");
            streamWriter.WriteLine("\tPlayer2 = " + (this.gh3Song_0.not_bass ? "Rhythm" : "Bass"));
            streamWriter.WriteLine("\tArtistText = \"" + ((this.gh3Song_0.artist_text is bool) ? (((bool)this.gh3Song_0.artist_text) ? "by" : "as made famous by") : ((string)this.gh3Song_0.artist_text)) + "\"");
            streamWriter.WriteLine("\tOffset = " + (double)this.gh3Song_0.input_offset / -1000.0);
            if (!this.gh3Song_0.singer.Equals(""))
            {
                streamWriter.WriteLine("\tSinger = \"" + this.gh3Song_0.singer + "\"");
            }
            if (!this.gh3Song_0.bassist.Equals("Generic Bassist"))
            {
                streamWriter.WriteLine("\tBassist = \"" + this.gh3Song_0.bassist + "\"");
            }
            if (!this.gh3Song_0.boss.Equals(""))
            {
                streamWriter.WriteLine("\tBoss = \"" + this.gh3Song_0.boss + "\"");
            }
            streamWriter.WriteLine("\tCountOff = \"" + this.gh3Song_0.countoff + "\"");
            streamWriter.WriteLine("\tGuitarVol = " + this.gh3Song_0.guitar_vol);
            streamWriter.WriteLine("\tBandVol = " + this.gh3Song_0.band_vol);
            streamWriter.WriteLine("\tHoPo = " + this.gh3Song_0.hammer_on);
            streamWriter.WriteLine("\tOriginalArtist = " + (this.gh3Song_0.original_artist ? "true" : "false"));
            streamWriter.WriteLine("\tResolution = " + this.int_1);
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[SyncTrack]");
            streamWriter.WriteLine("{");
            foreach (int current in this.tsList.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current,
                    " = TS ",
                    this.tsList[current][0],
                    " ",
                    this.tsList[current][1]
                }));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FretBars]");
            streamWriter.WriteLine("{");
            foreach (int current2 in this.class239_0)
            {
                streamWriter.WriteLine("\t" + current2);
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[Events]");
            streamWriter.WriteLine("{");
            foreach (int current3 in this.class228_1.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current3,
                    " = S \"",
                    this.class228_1[current3],
                    "\""
                }));
            }
            streamWriter.WriteLine("}");
            string[] array = new string[]
            {
                "",
                "rhythm_",
                "guitarcoop_",
                "rhythmcoop_"
            };
            for (int i = 0; i < array.Length; i++)
            {
                string str = array[i];
                string[] array2 = new string[]
                {
                    "easy",
                    "medium",
                    "hard",
                    "expert"
                };
                for (int j = 0; j < array2.Length; j++)
                {
                    string str2 = array2[j];
                    string text = str + str2;
                    Track<int, NotesAtOffset> @class = this.noteList.ContainsKey(text) ? this.noteList[text] : new Track<int, NotesAtOffset>();
                    Track<int, int[]> class2 = this.spList.ContainsKey(text) ? this.spList[text] : new Track<int, int[]>();
                    Track<int, int[]> class3 = this.battleNoteList.ContainsKey(text) ? this.battleNoteList[text] : new Track<int, int[]>();
                    Class221<int> class4 = new Class221<int>(@class.Keys);
                    class4.vmethod_1(class2.Keys);
                    class4.vmethod_1(class3.Keys);
                    class4.Sort();
                    StringBuilder stringBuilder = new StringBuilder(text);
                    stringBuilder[0] = char.ToUpper(stringBuilder[0]);
                    if (text.Contains("_"))
                    {
                        stringBuilder[text.IndexOf('_') + 1] = char.ToUpper(stringBuilder[text.IndexOf('_') + 1]);
                    }
                    streamWriter.WriteLine("[" + stringBuilder.ToString() + "]");
                    streamWriter.WriteLine("{");
                    foreach (int current4 in class4)
                    {
                        if (@class.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat(new object[]
                            {
                                "\t",
                                current4,
                                " = N ",
                                @class[current4].method_0(),
                                " ",
                                @class[current4].sustainLength
                            }));
                        }
                        if (class2.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat(new object[]
                            {
                                "\t",
                                current4,
                                " = S ",
                                class2[current4][1],
                                " ",
                                class2[current4][0]
                            }));
                        }
                        if (class3.ContainsKey(current4))
                        {
                            streamWriter.WriteLine(string.Concat(new object[]
                            {
                                "\t",
                                current4,
                                " = B ",
                                class3[current4][1],
                                " ",
                                class3[current4][0]
                            }));
                        }
                    }
                    streamWriter.WriteLine("}");
                }
            }
            streamWriter.WriteLine("[FaceOffP1]");
            streamWriter.WriteLine("{");
            foreach (int current5 in this.class228_2.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current5,
                    " = F ",
                    this.class228_2[current5]
                }));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[FaceOffP2]");
            streamWriter.WriteLine("{");
            foreach (int current6 in this.class228_3.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current6,
                    " = F ",
                    this.class228_3[current6]
                }));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP1]");
            streamWriter.WriteLine("{");
            foreach (int current7 in this.bpmList.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current7,
                    " = B ",
                    this.bpmList[current7]
                }));
            }
            streamWriter.WriteLine("}");
            streamWriter.WriteLine("[BossBattleP2]");
            streamWriter.WriteLine("{");
            foreach (int current8 in this.class228_5.Keys)
            {
                streamWriter.WriteLine(string.Concat(new object[]
                {
                    "\t",
                    current8,
                    " = B ",
                    this.class228_5[current8]
                }));
            }
            streamWriter.WriteLine("}");
            streamWriter.Close();
        }

        public Class308 method_4(string string_0)
		{
			Class308 @class = new Class308();
			int int_ = Class327.smethod_9("songs\\" + string_0 + ".mid.qb");
			string[] array = new string[]
			{
				"",
				"rhythm_",
				"guitarcoop_",
				"rhythmcoop_",
				"aux_"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				string[] array2 = new string[]
				{
					"easy",
					"medium",
					"hard",
					"expert"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string str2 = array2[j];
					string text = str + str2;
					if (this.noteList.ContainsKey(text))
					{
						this.method_5(int_, string_0 + "_song_" + text, @class, this.noteList[text]);
					}
					else
					{
						this.method_11(int_, string_0 + "_song_" + text, @class);
					}
					if (this.spList.ContainsKey(text))
					{
						this.method_6(int_, string_0 + "_" + text + "_star", @class, this.spList[text]);
					}
					else
					{
						this.method_11(int_, string_0 + "_" + text + "_star", @class);
					}
					if (this.battleNoteList.ContainsKey(text))
					{
						this.method_6(int_, string_0 + "_" + text + "_starbattlemode", @class, this.battleNoteList[text]);
					}
					else
					{
						this.method_11(int_, string_0 + "_" + text + "_starbattlemode", @class);
					}
				}
			}
			this.method_7(int_, string_0 + "_faceoffp1", @class, this.class228_2);
			this.method_7(int_, string_0 + "_faceoffp2", @class, this.class228_3);
			this.method_7(int_, string_0 + "_bossbattlep1", @class, this.bpmList);
			this.method_7(int_, string_0 + "_bossbattlep2", @class, this.class228_5);
			this.method_8(int_, string_0 + "_timesig", @class);
			this.method_9(int_, string_0 + "_fretbars", @class);
			this.method_10(int_, string_0 + "_markers", @class);
			this.method_11(int_, string_0 + "_scripts_notes", @class);
			this.method_11(int_, string_0 + "_anim_notes", @class);
			this.method_11(int_, string_0 + "_triggers_notes", @class);
			this.method_11(int_, string_0 + "_cameras_notes", @class);
			this.method_11(int_, string_0 + "_lightshow_notes", @class);
			this.method_11(int_, string_0 + "_crowd_notes", @class);
			this.method_11(int_, string_0 + "_drums_notes", @class);
			this.method_11(int_, string_0 + "_performance_notes", @class);
			this.method_11(int_, string_0 + "_scripts", @class);
			this.method_11(int_, string_0 + "_anim", @class);
			this.method_11(int_, string_0 + "_triggers", @class);
			this.method_11(int_, string_0 + "_cameras", @class);
			this.method_11(int_, string_0 + "_lightshow", @class);
			this.method_11(int_, string_0 + "_crowd", @class);
			this.method_11(int_, string_0 + "_drums", @class);
			this.method_11(int_, string_0 + "_performance", @class);
			return @class;
		}

		private void method_5(int int_2, string string_0, Class308 class308_0, Track<int, NotesAtOffset> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				this.method_11(int_2, string_0, class308_0);
				return;
			}
			List<int> list = new List<int>();
			foreach (int current in class228_7.Keys)
			{
				list.Add(current);
				list.Add(class228_7[current].sustainLength);
				list.Add(class228_7[current].method_0());
			}
			class308_0.method_3(new Class267(string_0, int_2, new Class280(list)));
		}

		private void method_6(int int_2, string string_0, Class308 class308_0, Track<int, int[]> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				this.method_11(int_2, string_0, class308_0);
				return;
			}
			Class291 @class = new Class291();
			foreach (int current in class228_7.Keys)
			{
				@class.method_3(new Class280(new int[]
				{
					current,
					class228_7[current][0],
					class228_7[current][1]
				}));
			}
			class308_0.method_3(new Class267(string_0, int_2, @class));
		}

		private void method_7(int int_2, string string_0, Class308 class308_0, Track<int, int> class228_7)
		{
			if (class228_7.Keys.Count == 0)
			{
				this.method_11(int_2, string_0, class308_0);
				return;
			}
			Class291 @class = new Class291();
			foreach (int current in class228_7.Keys)
			{
				@class.method_3(new Class280(new int[]
				{
					current,
					class228_7[current]
				}));
			}
			class308_0.method_3(new Class267(string_0, int_2, @class));
		}

		private void method_8(int int_2, string string_0, Class308 class308_0)
		{
			Class291 @class = new Class291();
			foreach (int current in this.tsList.Keys)
			{
				@class.method_3(new Class280(new int[]
				{
					current,
					this.tsList[current][0],
					this.tsList[current][1]
				}));
			}
			class308_0.method_3(new Class267(string_0, int_2, @class));
		}

		private void method_9(int int_2, string string_0, Class308 class308_0)
		{
			class308_0.method_3(new Class267(string_0, int_2, new Class280(this.class239_0)));
		}

		private void method_10(int int_2, string string_0, Class308 class308_0)
		{
			if (this.class228_1.Keys.Count == 0)
			{
				this.method_11(int_2, string_0, class308_0);
				return;
			}
			Class292 @class = new Class292();
			foreach (int current in this.class228_1.Keys)
			{
				@class.method_3(new Class286(new Class294[]
				{
					new Class299("time", current),
					new Class307("marker", this.class228_1[current])
				}));
			}
			class308_0.method_3(new Class267(string_0, int_2, @class));
		}

		private void method_11(int int_2, string string_0, Class308 class308_0)
		{
			class308_0.method_3(new Class267(string_0, int_2, this.class287_0));
		}
	}
}
