using GuitarHero.Songlist;
using ns14;
using ns9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ns15
{
	public class ChartParser
	{
		public Dictionary<string, Class366> dictionary_0 = new Dictionary<string, Class366>();

		public Dictionary<string, Class229> dictionary_1 = new Dictionary<string, Class229>();

		public Class363 class363_0;

		public Class368 class368_0;

		public int int_0 = 480;

		public GH3Song gh3Song_0 = new GH3Song();

		private static double double_0;

		private Track<int, decimal> class228_0;

		public ChartParser()
		{
			this.class363_0 = new Class363();
			this.class368_0 = new Class368();
		}

		public ChartParser(GH3Song gh3Song_1) : this()
		{
			this.gh3Song_0 = gh3Song_1;
		}

		public ChartParser(string string_0)
		{
			List<string> list = new List<string>();
			StreamReader streamReader = File.OpenText(string_0);
			string text = null;
			string text2;
			while ((text2 = streamReader.ReadLine()) != null)
			{
				if (text2.StartsWith("["))
				{
					text = text2.Split(new char[]
					{
						'[',
						']'
					}, StringSplitOptions.RemoveEmptyEntries)[0];
				}
				else if (!text2.Equals("{"))
				{
					if (text2.Equals("}"))
					{
						string a;
						if ((a = text) == null)
						{
							goto IL_477;
						}
						if (a == "Song")
						{
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
										string key;
										switch (key = text3)
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
											ChartParser.double_0 = 480.0 / Convert.ToDouble(text4);
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
							if (this.class368_0 == null)
							{
								this.class368_0 = new Class368(list.ToArray());
							}
						}
						else if (this.class363_0 == null)
						{
							this.class363_0 = new Class363(list.ToArray());
						}
						IL_4D5:
						list.Clear();
						continue;
						IL_477:
						if (this.dictionary_0.ContainsKey(text))
						{
							goto IL_4D5;
						}
						if (!text.Contains("Single") && !text.Contains("Double"))
						{
							this.dictionary_1.Add(text, new Class229(list.ToArray()));
							goto IL_4D5;
						}
						this.dictionary_0.Add(text, new Class366(list.ToArray(), this.int_0));
						goto IL_4D5;
					}
					else if (!text2.Equals(""))
					{
						list.Add(text2);
					}
				}
			}
			streamReader.Close();
			this.method_0();
		}

		public static int smethod_0(string string_0)
		{
			return Convert.ToInt32((double)Convert.ToInt32(string_0) * ChartParser.double_0);
		}

		public void method_0()
		{
			string[] array = new string[]
			{
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				if (this.dictionary_0.ContainsKey(str + "Single"))
				{
					this.dictionary_0.Add(str + "SingleGuitar", this.dictionary_0[str + "Single"]);
					this.dictionary_0.Remove(str + "Single");
				}
				if (this.dictionary_0.ContainsKey(str + "DoubleBass"))
				{
					if (this.dictionary_0.ContainsKey(str + "DoubleGuitar") && !this.dictionary_0[str + "DoubleGuitar"].bool_0)
					{
						this.dictionary_0.Add(str + "DoubleRhythm", this.dictionary_0[str + "DoubleBass"]);
					}
					else
					{
						this.dictionary_0.Add(str + "SingleRhythm", this.dictionary_0[str + "DoubleBass"]);
					}
					this.dictionary_0.Remove(str + "DoubleBass");
				}
			}
			List<string> list = new List<string>(this.dictionary_0.Keys);
			foreach (string current in list)
			{
				if (this.dictionary_0[current].class228_0.Count == 0)
				{
					this.dictionary_0.Remove(current);
				}
			}
			if (this.class368_0 == null)
			{
				this.class368_0 = new Class368();
			}
			if (this.class363_0.class228_0.Count == 0)
			{
				this.class363_0.class228_0.Add(0, 4);
			}
		}

		public void WriteMethod1(string string_0)
		{
			StreamWriter streamWriter = new StreamWriter(string_0);
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
			streamWriter.WriteLine("\tResolution = " + this.int_0);
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[SyncTrack]");
			streamWriter.WriteLine("{");
			List<int> list = new List<int>(this.class363_0.class228_0.Keys);
			foreach (int current in this.class363_0.class228_1.Keys)
			{
				if (!list.Contains(current))
				{
					list.Add(current);
				}
			}
			list.Sort();
			foreach (int current2 in list)
			{
				if (this.class363_0.class228_1.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat(new object[]
					{
						"\t",
						current2,
						" = B ",
						this.class363_0.class228_1[current2]
					}));
				}
				if (this.class363_0.class228_0.ContainsKey(current2))
				{
					streamWriter.WriteLine(string.Concat(new object[]
					{
						"\t",
						current2,
						" = TS ",
						this.class363_0.class228_0[current2]
					}));
				}
			}
			streamWriter.WriteLine("}");
			streamWriter.WriteLine("[Events]");
			streamWriter.WriteLine("{");
			list = new List<int>(this.class368_0.class228_1.Keys);
			foreach (int current3 in this.class368_0.class228_0.Keys)
			{
				if (!list.Contains(current3))
				{
					list.Add(current3);
				}
			}
			list.Sort();
			foreach (int current4 in list)
			{
				if (this.class368_0.class228_1.ContainsKey(current4))
				{
					streamWriter.WriteLine(string.Concat(new object[]
					{
						"\t",
						current4,
						" = E \"section ",
						this.class368_0.class228_1[current4].Replace(" ", "_").ToLower(),
						"\""
					}));
				}
				if (this.class368_0.class228_0.ContainsKey(current4))
				{
					List<string> list2 = this.class368_0.class228_0[current4];
					foreach (string current5 in list2)
					{
						streamWriter.WriteLine(string.Concat(new object[]
						{
							"\t",
							current4,
							" = E \"",
							current5,
							"\""
						}));
					}
				}
			}
			streamWriter.WriteLine("}");
			new ArrayList(this.dictionary_0.Keys);
			string[] array = new string[]
			{
				"Easy",
				"Medium",
				"Hard",
				"Expert"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string str = array[i];
				string[] array2 = new string[]
				{
					"Single",
					"Double"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string str2 = array2[j];
					string[] array3 = new string[]
					{
						"Guitar",
						"Rhythm"
					};
					for (int k = 0; k < array3.Length; k++)
					{
						string str3 = array3[k];
						if (this.dictionary_0.ContainsKey(str + str2 + str3))
						{
							string text = str + str2 + str3;
							Class366 @class = this.dictionary_0[text];
							streamWriter.WriteLine("[" + text + "]");
							streamWriter.WriteLine("{");
							list = new List<int>(@class.class228_0.Keys);
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
							foreach (int current12 in @class.class228_7.Keys)
							{
								if (!list.Contains(current12))
								{
									list.Add(current12);
								}
							}
							list.Sort();
							foreach (int current13 in list)
							{
								if (@class.class228_7.ContainsKey(current13))
								{
									List<string> list2 = @class.class228_7[current13];
									foreach (string current14 in list2)
									{
										streamWriter.WriteLine(string.Concat(new object[]
										{
											"\t",
											current13,
											" = E ",
											current14
										}));
									}
								}
								if (@class.class228_0.ContainsKey(current13))
								{
									Class364 class2 = @class.class228_0[current13];
									for (int l = 0; l < class2.bool_0.Length; l++)
									{
										if (class2.bool_0[l])
										{
											streamWriter.WriteLine(string.Concat(new object[]
											{
												"\t",
												current13,
												" = N ",
												l,
												" ",
												class2.int_0
											}));
										}
									}
								}
								if (@class.class228_2.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 0 ",
										@class.class228_2[current13]
									}));
								}
								if (@class.class228_3.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 1 ",
										@class.class228_3[current13]
									}));
								}
								if (@class.class228_1.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 2 ",
										@class.class228_1[current13]
									}));
								}
								if (@class.class228_4.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 3 ",
										@class.class228_4[current13]
									}));
								}
								if (@class.class228_5.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 4 ",
										@class.class228_5[current13]
									}));
								}
								if (@class.class228_6.ContainsKey(current13))
								{
									streamWriter.WriteLine(string.Concat(new object[]
									{
										"\t",
										current13,
										" = S 5 ",
										@class.class228_6[current13]
									}));
								}
							}
							streamWriter.WriteLine("}");
						}
					}
				}
				array2 = new string[]
				{
					"Drums",
					"Keyboard"
				};
				for (int j = 0; j < array2.Length; j++)
				{
					string str4 = array2[j];
					if (this.dictionary_1.ContainsKey(str + str4))
					{
						string text2 = str + str4;
						Class229 class3 = this.dictionary_1[text2];
						streamWriter.WriteLine("[" + text2 + "]");
						streamWriter.WriteLine("{");
						list = new List<int>(class3.Keys);
						list.Sort();
						foreach (int current15 in list)
						{
							foreach (string current16 in class3[current15])
							{
								streamWriter.WriteLine(string.Concat(new object[]
								{
									"\t",
									current15,
									" = E ",
									current16
								}));
							}
						}
						streamWriter.WriteLine("}");
					}
				}
			}
			streamWriter.Close();
		}

		private int method_2(int int_1)
		{
			int num = this.class363_0.class228_1.method_1(int_1);
			return Convert.ToInt32(60000000m / this.int_0 * (this.class228_0[num] + (int_1 - this.class363_0.class228_1.Keys[num]) / this.class363_0.class228_1.Values[num]));
		}

		public Class362 method_3()
		{
			Class362 @class = new Class362(this.gh3Song_0);
			Track<int, int> class2 = null;
			Track<int, int> class3 = null;
			int num = 0;
			if (this.dictionary_0.Count == 0)
			{
				throw new Exception("Chart file is empty and cannot be parsed to QB.");
			}
			foreach (Class366 current in this.dictionary_0.Values)
			{
				num = Math.Max(num, current.class228_0.Keys[current.class228_0.Count - 1] + current.class228_0.Values[current.class228_0.Count - 1].int_0);
			}
			num = ((this.class368_0.class228_0.Count == 0) ? num : Math.Max(num, this.class368_0.class228_0.Keys[this.class368_0.class228_0.Count - 1]));
			this.class228_0 = new Track<int, decimal>();
			this.class228_0.Add(0, 0m);
			for (int i = 1; i < this.class363_0.class228_1.Count; i++)
			{
				this.class228_0.Add(i, this.class228_0[i - 1] + (this.class363_0.class228_1.Keys[i] - this.class363_0.class228_1.Keys[i - 1]) / this.class363_0.class228_1.Values[i - 1]);
			}
			string[] array = new string[]
			{
				"Single",
				"Double"
			};
			for (int j = 0; j < array.Length; j++)
			{
				string text = array[j];
				string[] array2 = new string[]
				{
					"Guitar",
					"Rhythm"
				};
				for (int k = 0; k < array2.Length; k++)
				{
					string text2 = array2[k];
					string[] array3 = new string[]
					{
						"Easy",
						"Medium",
						"Hard",
						"Expert"
					};
					for (int l = 0; l < array3.Length; l++)
					{
						string text3 = array3[l];
						string key = (text2.ToLower() + ((text == "Double") ? "coop" : "") + "_" + text3.ToLower()).Replace("guitar_", "");
						if (this.dictionary_0.ContainsKey(text3 + text + text2))
						{
							Class366 class4 = this.dictionary_0[text3 + text + text2];
							if (class4.class228_0.Count != 0)
							{
								@class.dictionary_0.Add(key, new Track<int, Class364>());
								this.method_4(@class.dictionary_0[key], class4.class228_0);
							}
							if (class4.class228_1.Count != 0)
							{
								@class.dictionary_1.Add(key, new Track<int, int[]>());
								this.method_5(@class.dictionary_1[key], class4.class228_1, class4.class228_0);
							}
							if (class4.class228_4.Count != 0)
							{
								@class.dictionary_2.Add(key, new Track<int, int[]>());
								this.method_5(@class.dictionary_2[key], class4.class228_4, class4.class228_0);
							}
							if (class2 == null || class2.Count < class4.class228_2.Count)
							{
								class2 = class4.class228_2;
							}
							if (class3 == null || class3.Count < class4.class228_3.Count)
							{
								class3 = class4.class228_3;
							}
						}
					}
				}
			}
			this.method_6(@class.class228_2, class2);
			this.method_6(@class.class228_3, class3);
			foreach (int current2 in this.class363_0.class228_0.Keys)
			{
				@class.class228_0.Add(this.method_2(current2), new int[]
				{
					this.class363_0.class228_0[current2],
					4
				});
			}
			int num2 = (int)Math.Ceiling((double)num / (double)this.int_0);
			for (int m = 0; m <= num2; m++)
			{
				@class.class239_0.method_1(this.method_2(m * this.int_0));
			}
			@class.class239_0[0] = @class.class239_0[1] - 4;
			@class.int_0 = 1;
			foreach (int current3 in this.class368_0.class228_1.Keys)
			{
				@class.class228_1.Add(this.method_2(current3), this.class368_0.class228_1[current3]);
			}
			this.class228_0.Clear();
			this.class228_0 = null;
			GC.Collect();
			return @class;
		}

		private void method_4(Track<int, Class364> class228_1, Track<int, Class364> class228_2)
		{
			foreach (int current in class228_2.Keys)
			{
				int num = this.method_2(current);
				int int_ = (class228_2[current].int_0 == 0) ? 1 : (this.method_2(current + class228_2[current].int_0) - num);
				if (class228_1.ContainsKey(num))
				{
					for (int i = 0; i < 32; i++)
					{
						if (class228_2[current].bool_0[i])
						{
							class228_1[num].bool_0[i] = true;
						}
					}
				}
				else
				{
					class228_1.Add(num, new Class364(class228_2[current].bool_0, int_));
				}
			}
		}

		private void method_5(Track<int, int[]> class228_1, Track<int, int> class228_2, Track<int, Class364> class228_3)
		{
			foreach (int current in class228_2.Keys)
			{
				int num = this.method_2(current);
				int num2 = (class228_2[current] == 0) ? 1 : (this.method_2((class228_2.Keys[class228_2.method_1(current + class228_2[current])] > current) ? class228_3.Keys[class228_3.method_1(class228_2.Keys[class228_2.method_1(current + class228_2[current])] - 1)] : (current + class228_2[current])) - num);
				class228_1.Add(num, new int[]
				{
					num2,
					class228_3.method_3(current, current + class228_2[current])
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
				int num = this.method_2(current);
				int value = (class228_2[current] == 0) ? 1 : (this.method_2(current + class228_2[current]) - num);
				class228_1.Add(num, value);
			}
		}
	}
}
