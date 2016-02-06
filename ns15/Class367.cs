using ns22;
using ns9;
using System;
using System.Collections.Generic;
using System.IO;

namespace ns15
{
	public class Class367
	{
		private string string_0;

		private Class366 class366_0 = new Class366();

		private Class366 class366_1 = new Class366();

		private Class366 class366_2 = new Class366();

		private Class366 class366_3 = new Class366();

		private Class366 class366_4 = new Class366();

		private Class366 class366_5 = new Class366();

		private Class366 class366_6 = new Class366();

		private Class366 class366_7 = new Class366();

		private Class366 class366_8 = new Class366();

		private Class366 class366_9 = new Class366();

		private Class366 class366_10 = new Class366();

		private Class366 class366_11 = new Class366();

		private Class229 class229_0 = new Class229();

		private Class229 class229_1 = new Class229();

		private Class229 class229_2 = new Class229();

		private Class229 class229_3 = new Class229();

		private Class229 class229_4 = new Class229();

		private Class229 class229_5 = new Class229();

		private Class229 class229_6 = new Class229();

		private Class229 class229_7 = new Class229();

		private Class363 class363_0;

		private Class368 class368_0;

		private string string_1 = "";

		private double double_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private Class354 class354_0;

		private List<string> list_0 = new List<string>();

		public Class367(string string_2)
		{
			this.string_0 = string_2;
		}

		public ChartParser method_0()
		{
			string text = "";
			text = text + new FileInfo(this.string_0).Name + ":\n";
			try
			{
				this.class354_0 = Class354.smethod_0(this.string_0);
			}
			catch (Exception)
			{
				throw new IOException(text + "Unknown Error: Could not parse MIDI sequence.");
			}
			foreach (Class353 current in this.class354_0.method_2())
			{
				if (current.method_2().Equals("PART GUITAR"))
				{
					this.bool_0 = true;
				}
				else if (current.method_2().Equals("EVENTS"))
				{
					this.bool_1 = true;
				}
			}
			if (this.class354_0.method_2().Count == 1 && !this.bool_0)
			{
				this.class354_0.method_2()[0].method_3("PART GUITAR");
				this.bool_0 = true;
			}
			if (!this.bool_0)
			{
				throw new IOException(text + "PART GUITAR not found. No chart created.");
			}
			ChartParser @class = new ChartParser();
			this.class363_0 = @class.class363_0;
			this.class368_0 = @class.class368_0;
			@class.dictionary_0.Add("EasySingle", this.class366_3);
			@class.dictionary_0.Add("MediumSingle", this.class366_2);
			@class.dictionary_0.Add("HardSingle", this.class366_1);
			@class.dictionary_0.Add("ExpertSingle", this.class366_0);
			@class.dictionary_0.Add("EasyDoubleGuitar", this.class366_7);
			@class.dictionary_0.Add("MediumDoubleGuitar", this.class366_6);
			@class.dictionary_0.Add("HardDoubleGuitar", this.class366_5);
			@class.dictionary_0.Add("ExpertDoubleGuitar", this.class366_4);
			@class.dictionary_0.Add("EasyDoubleBass", this.class366_11);
			@class.dictionary_0.Add("MediumDoubleBass", this.class366_10);
			@class.dictionary_0.Add("HardDoubleBass", this.class366_9);
			@class.dictionary_0.Add("ExpertDoubleBass", this.class366_8);
			@class.dictionary_1.Add("EasyDrums", this.class229_3);
			@class.dictionary_1.Add("MediumDrums", this.class229_2);
			@class.dictionary_1.Add("HardDrums", this.class229_1);
			@class.dictionary_1.Add("ExpertDrums", this.class229_0);
			@class.dictionary_1.Add("EasyKeyboard", this.class229_7);
			@class.dictionary_1.Add("MediumKeyboard", this.class229_6);
			@class.dictionary_1.Add("HardKeyboard", this.class229_5);
			@class.dictionary_1.Add("ExpertKeyboard", this.class229_4);
			@class.int_0 = 480;
			this.double_0 = 480.0 / (double)this.class354_0.method_0();
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"NumTracks = ",
				this.class354_0.method_2().Count,
				"\n"
			});
			this.method_1(this.class354_0.method_2()[0]);
			foreach (Class353 current2 in this.class354_0.method_2())
			{
				if (current2.method_2().Equals("PART GUITAR"))
				{
					this.method_2(current2, 0);
				}
				else if (current2.method_2().Equals("T1 GEMS"))
				{
					this.method_2(current2, 0);
				}
				else if (current2.method_2().Equals("PART GUITAR COOP"))
				{
					this.method_2(current2, 1);
				}
				else if (current2.method_2().Equals("PART RHYTHM"))
				{
					this.bool_2 = true;
					this.method_2(current2, 3);
				}
				else if (current2.method_2().Equals("PART BASS"))
				{
					this.method_2(current2, 3);
				}
				else if (current2.method_2().Equals("EVENTS"))
				{
					this.method_2(current2, 4);
				}
				else if (current2.method_2().Equals("BAND DRUMS"))
				{
					this.method_2(current2, 5);
				}
				else if (current2.method_2().Equals("BAND KEYS"))
				{
					this.method_2(current2, 7);
				}
				else
				{
					text = text + "Track (" + current2.method_2() + ") ignored.\n";
				}
			}
			@class.gh3Song_0.title = this.string_1;
			@class.gh3Song_0.not_bass = this.bool_2;
			text += "Conversion Complete!";
			Console.WriteLine(text);
			@class.method_0();
			return @class;
		}

		private void method_1(Class353 class353_0)
		{
			this.string_1 = class353_0.method_2();
			foreach (Class335 current in class353_0.method_0())
			{
				int num = Convert.ToInt32((double)current.method_0() * this.double_0);
				if (current is Class337)
				{
					Class337 @class = (Class337)current;
					if (!this.bool_1 && @class.method_2() == Class337.Enum37.const_0)
					{
						this.method_4(4, num, "section " + @class.method_1());
					}
				}
				else if (current is Class339)
				{
					int num2 = ((Class339)current).method_1();
					this.class363_0.class228_1.Add(num, Convert.ToInt32(Math.Floor(60000000.0 / (double)num2 * 1000.0)));
				}
				else if (current is Class338)
				{
					this.class363_0.class228_0.Add(num, ((Class338)current).method_1());
				}
			}
		}

		private void method_2(Class353 class353_0, int int_0)
		{
			bool[] array = new bool[class353_0.method_0().Count];
			List<Class335> list = class353_0.method_0();
			for (int i = 0; i < list.Count; i++)
			{
				if (!array[i])
				{
					int num = Convert.ToInt32((double)list[i].method_0() * this.double_0);
					if (list[i] is Class336)
					{
						Class336 @class = (Class336)list[i];
						if (@class.method_5())
						{
							int j = -1;
							int num2 = i + 1;
							while (j < 0)
							{
								if (num2 == class353_0.method_0().Count)
								{
									break;
								}
								if (list[num2] is Class336 && ((Class336)list[num2]).method_4() == @class.method_4())
								{
									if (((Class336)list[num2]).method_5())
									{
										j = Convert.ToInt32((double)list[num2].method_0() * this.double_0);
										array[num2] = true;
									}
									else
									{
										j = Convert.ToInt32((double)list[num2].method_0() * this.double_0);
									}
								}
								num2++;
							}
							int num3 = Convert.ToInt32(j - num);
							if (num3 <= 160)
							{
								num3 = 0;
							}
							this.method_3(int_0, num, @class, num3);
						}
					}
					else if (list[i] is Class337)
					{
						Class337 class2 = (Class337)list[i];
						List<string> list2 = this.method_5(int_0 - 4);
						string text = class2.method_1();
						if (text.StartsWith("["))
						{
							text = text.Substring(1, text.Length - 2);
						}
						if (list2.Contains(text) || text.Contains("section "))
						{
							this.method_4(int_0, num, text);
						}
					}
				}
			}
		}

		private void method_3(int int_0, int int_1, Class336 class336_0, int int_2)
		{
			Class366 @class = null;
			switch (class336_0.method_1())
			{
			case Enum38.const_0:
				switch (int_0)
				{
				case 0:
					@class = this.class366_3;
					break;
				case 1:
					@class = this.class366_7;
					break;
				case 3:
					@class = this.class366_11;
					break;
				}
				break;
			case Enum38.const_1:
				switch (int_0)
				{
				case 0:
					@class = this.class366_2;
					break;
				case 1:
					@class = this.class366_6;
					break;
				case 3:
					@class = this.class366_10;
					break;
				}
				break;
			case Enum38.const_2:
				switch (int_0)
				{
				case 0:
					@class = this.class366_1;
					break;
				case 1:
					@class = this.class366_5;
					break;
				case 3:
					@class = this.class366_9;
					break;
				}
				break;
			case Enum38.const_3:
				switch (int_0)
				{
				case 0:
					@class = this.class366_0;
					break;
				case 1:
					@class = this.class366_4;
					break;
				case 3:
					@class = this.class366_8;
					break;
				}
				break;
			default:
				if (!this.bool_3 && class336_0.method_2() == Enum36.const_8)
				{
					this.bool_3 = true;
					this.class366_0.class228_1.Clear();
					this.class366_1.class228_1.Clear();
					this.class366_2.class228_1.Clear();
					this.class366_3.class228_1.Clear();
				}
				else if (!this.bool_3)
				{
					return;
				}
				break;
			}
			if (class336_0.method_3() != Enum39.const_5)
			{
				if (@class.class228_0.method_4(int_1))
				{
					@class.class228_0[int_1].bool_0[(int)class336_0.method_3()] = true;
					return;
				}
				bool[] array = new bool[6];
				array[(int)class336_0.method_3()] = true;
				@class.class228_0.Add(int_1, new Class364(array, int_2));
				return;
			}
			else
			{
				if (class336_0.method_2() == Enum36.const_8 && !this.class366_0.class228_1.ContainsKey(int_1))
				{
					this.class366_0.class228_1.Add(int_1, int_2);
					this.class366_1.class228_1.Add(int_1, int_2);
					this.class366_2.class228_1.Add(int_1, int_2);
					this.class366_3.class228_1.Add(int_1, int_2);
					return;
				}
				if (class336_0.method_2() == Enum36.const_5 && !@class.class228_1.ContainsKey(int_1) && !this.bool_3)
				{
					@class.class228_1.Add(int_1, int_2);
					return;
				}
				if (class336_0.method_2() == Enum36.const_6 && !@class.class228_2.ContainsKey(int_1))
				{
					@class.class228_2.Add(int_1, int_2);
					return;
				}
				if (class336_0.method_2() == Enum36.const_7 && !@class.class228_3.ContainsKey(int_1))
				{
					@class.class228_3.Add(int_1, int_2);
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
					this.class368_0.class228_1.Add(int_1, string_2);
					return;
				}
				if (this.class368_0.class228_0.method_4(int_1))
				{
					this.class368_0.class228_0[int_1].Add(string_2);
					return;
				}
				this.class368_0.class228_0.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				return;
			}
			else
			{
				Class366 @class = null;
				Class366 class2 = null;
				Class366 class3 = null;
				Class366 class4 = null;
				switch (int_0)
				{
				case 0:
					@class = this.class366_0;
					class2 = this.class366_1;
					class3 = this.class366_2;
					class4 = this.class366_3;
					break;
				case 1:
					@class = this.class366_4;
					class2 = this.class366_5;
					class3 = this.class366_6;
					class4 = this.class366_7;
					break;
				case 3:
					@class = this.class366_8;
					class2 = this.class366_9;
					class3 = this.class366_10;
					class4 = this.class366_11;
					break;
				case 5:
					this.class229_0.method_5(int_1, string_2);
					this.class229_1.method_5(int_1, string_2);
					this.class229_2.method_5(int_1, string_2);
					this.class229_3.method_5(int_1, string_2);
					return;
				case 7:
					this.class229_4.method_5(int_1, string_2);
					this.class229_5.method_5(int_1, string_2);
					this.class229_6.method_5(int_1, string_2);
					this.class229_7.method_5(int_1, string_2);
					return;
				}
				if (@class != null && @class.class228_7.method_4(int_1))
				{
					@class.class228_7[int_1].Add(string_2);
					class2.class228_7[int_1].Add(string_2);
					class3.class228_7[int_1].Add(string_2);
					class4.class228_7[int_1].Add(string_2);
					return;
				}
				@class.class228_7.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class2.class228_7.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class3.class228_7.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				class4.class228_7.Add(int_1, new List<string>(new string[]
				{
					string_2
				}));
				return;
			}
		}

		private List<string> method_5(int int_0)
		{
			if (this.list_0.Count == 0)
			{
				this.list_0.Add("lighting (chase)");
				this.list_0.Add("lighting (strobe)");
				this.list_0.Add("lighting (color1)");
				this.list_0.Add("lighting (color2)");
				this.list_0.Add("lighting (sweep)");
				this.list_0.Add("crowd_lighters_fast");
				this.list_0.Add("crowd_lighters_off");
				this.list_0.Add("crowd_lighters_slow");
				this.list_0.Add("crowd_half_tempo");
				this.list_0.Add("crowd_normal_tempo");
				this.list_0.Add("crowd_double_tempo");
				this.list_0.Add("band_jump");
				this.list_0.Add("sync_head_bang");
				this.list_0.Add("sync_wag");
				this.list_0.Add("lighting ()");
				this.list_0.Add("lighting (flare)");
				this.list_0.Add("lighting (blackout)");
				this.list_0.Add("music_start");
				this.list_0.Add("verse");
				this.list_0.Add("chorus");
				this.list_0.Add("solo");
				this.list_0.Add("end");
				this.list_0.Add("idle");
				this.list_0.Add("play");
				this.list_0.Add("solo_on");
				this.list_0.Add("solo_off");
				this.list_0.Add("wail_on");
				this.list_0.Add("wail_off");
				this.list_0.Add("drum_on");
				this.list_0.Add("drum_off");
				this.list_0.Add("sing_on");
				this.list_0.Add("sing_off");
				this.list_0.Add("bass_on");
				this.list_0.Add("bass_off");
				this.list_0.Add("gtr_on");
				this.list_0.Add("gtr_off");
				this.list_0.Add("ow_face_on");
				this.list_0.Add("ow_face_off");
				this.list_0.Add("half_tempo");
				this.list_0.Add("normal_tempo");
				this.list_0.Add("half_time");
				this.list_0.Add("double_time");
				this.list_0.Add("allbeat");
				this.list_0.Add("nobeat");
			}
			return this.list_0;
		}
	}
}
