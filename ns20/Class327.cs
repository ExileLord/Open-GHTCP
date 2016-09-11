using ns13;
using ns16;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ns20
{
	public static class Class327
	{
		private static Dictionary<int, string> dictionary_0 = new Dictionary<int, string>();

		private static Dictionary<int, string> dictionary_1 = new Dictionary<int, string>();

		public static bool bool_0 = false;

		public static void smethod_0()
		{
			if (Class327.bool_0)
			{
				return;
			}
			Class327.smethod_1(new MemoryStream(ZIPManager.smethod_5(Class244.smethod_5(Assembly.GetExecutingAssembly().GetManifestResourceStream("NeversoftTools.NSTreeView.nstags.aes"), "MinimizedNSTags1245"), "nstags.ids")));
			Class327.bool_0 = true;
		}

		public static void smethod_1(Stream stream_0)
		{
			Class327.smethod_2(stream_0, false);
		}

		public static void smethod_2(Stream stream_0, bool bool_1)
		{
			using (StreamReader streamReader = new StreamReader(stream_0))
			{
				string text;
				while ((text = streamReader.ReadLine()) != null)
				{
					if (!text.Equals(""))
					{
						int key = Class244.smethod_36(text, true);
						if (!Class327.dictionary_0.ContainsKey(key) && !Class327.dictionary_1.ContainsKey(key))
						{
							if (bool_1)
							{
								Class327.dictionary_1.Add(key, text);
							}
							else
							{
								Class327.dictionary_0.Add(key, text);
							}
						}
					}
				}
			}
		}

		public static bool smethod_3(int int_0)
		{
			return Class327.dictionary_0.ContainsKey(int_0) || Class327.dictionary_1.ContainsKey(int_0);
		}

		public static bool smethod_4(string string_0)
		{
			return Class327.dictionary_0.ContainsValue(string_0.ToLower());
		}

		public static string smethod_5(int int_0)
		{
			if (Class327.dictionary_0.ContainsKey(int_0))
			{
				return Class327.dictionary_0[int_0];
			}
			if (Class327.dictionary_1.ContainsKey(int_0))
			{
				return Class327.dictionary_1[int_0];
			}
			return null;
		}

		public static int smethod_6(string string_0)
		{
			if (!(string_0 == ""))
			{
				return Class244.smethod_37(Encoding.Unicode.GetBytes(string_0), true);
			}
			return 0;
		}

		public static void smethod_7(string string_0)
		{
			Class327.smethod_8(string_0, true);
		}

		public static void smethod_8(string string_0, bool bool_1)
		{
			if (Class327.dictionary_0.ContainsValue(string_0) || Class327.dictionary_1.ContainsValue(string_0))
			{
				return;
			}
			int key = Class244.smethod_36(string_0, true);
			if (bool_1 && !Class327.dictionary_1.ContainsKey(key))
			{
				Class327.dictionary_1.Add(key, string_0);
				return;
			}
			if (!Class327.dictionary_0.ContainsKey(key))
			{
				Class327.dictionary_0.Add(key, string_0);
			}
		}

		public static int smethod_9(string qbName)
		{
			qbName = qbName.ToLower();
			int num = Class244.smethod_36(qbName, true);
			if (!Class327.smethod_3(num))
			{
				Class327.dictionary_1.Add(num, qbName);
			}
			return num;
		}

		public static void smethod_10(string string_0)
		{
			Class327.smethod_7(string_0);
			string[] array = new string[]
			{
				"_male_",
				"_female_"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				for (int j = 1; j < 10; j++)
				{
					Class327.smethod_7(string.Concat(new object[]
					{
						"gh3_singer",
						text,
						string_0,
						"_",
						j
					}));
					Class327.smethod_7(string.Concat(new object[]
					{
						"gh3_singer",
						text,
						string_0,
						"_",
						j,
						"b"
					}));
				}
			}
			Class327.smethod_7("animload_singer_male_" + string_0);
			Class327.smethod_7("animload_singer_female_" + string_0);
			Class327.smethod_7("menu_music_" + string_0);
			Class327.smethod_7("songs\\" + string_0 + ".mid.qb");
			Class327.smethod_7("songs\\" + string_0 + ".mid.qs");
			Class327.smethod_7("songs\\" + string_0 + ".mid_text.qb");
			Class327.smethod_7("songs\\" + string_0 + "_song_scripts.qb");
			Class327.smethod_7("data\\songs\\" + string_0 + ".mid");
			Class327.smethod_7("data\\songs\\" + string_0 + ".mid_text");
			Class327.smethod_7("data\\songs\\" + string_0 + "_song_scripts.qb");
			Class327.smethod_7("dlc\\output\\" + string_0 + ".mid.qb");
			Class327.smethod_7("dlc\\output\\" + string_0 + ".mid_text.qb");
			Class327.smethod_7("dlc\\output\\" + string_0 + ".mid");
			Class327.smethod_7("dlc\\output\\" + string_0 + ".mid_text");
			Class327.smethod_7("dlc\\output\\" + string_0 + "_song_scripts.qb");
			string[] array2 = new string[]
			{
				"",
				"rhythm_",
				"guitarcoop_",
				"rhythmcoop_",
				"drum_",
				"aux_"
			};
			for (int k = 0; k < array2.Length; k++)
			{
				string text2 = array2[k];
				string[] array3 = new string[]
				{
					"easy",
					"medium",
					"hard",
					"expert"
				};
				for (int l = 0; l < array3.Length; l++)
				{
					string text3 = array3[l];
					Class327.smethod_7(string_0 + "_song_" + text2 + text3);
					Class327.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_star"
					}));
					Class327.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_starbattlemode"
					}));
					Class327.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_tapping"
					}));
					Class327.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_whammycontroller"
					}));
				}
				Class327.smethod_7(string_0 + "_" + text2 + "faceoffstar");
				Class327.smethod_7(string_0 + "_" + text2 + "faceoffp1");
				Class327.smethod_7(string_0 + "_" + text2 + "faceoffp2");
			}
			Class327.smethod_7(string_0 + "_bossbattlep1");
			Class327.smethod_7(string_0 + "_bossbattlep2");
			Class327.smethod_7(string_0 + "_timesig");
			Class327.smethod_7(string_0 + "_fretbars");
			Class327.smethod_7(string_0 + "_guitar_markers");
			Class327.smethod_7(string_0 + "_rhythm_markers");
			Class327.smethod_7(string_0 + "_drum_markers");
			Class327.smethod_7(string_0 + "_vocals_markers");
			Class327.smethod_7(string_0 + "_easy_drumfill");
			Class327.smethod_7(string_0 + "_medium_drumfill");
			Class327.smethod_7(string_0 + "_hard_drumfill");
			Class327.smethod_7(string_0 + "_expert_drumfill");
			Class327.smethod_7(string_0 + "_easy_drumunmute");
			Class327.smethod_7(string_0 + "_medium_drumunmute");
			Class327.smethod_7(string_0 + "_hard_drumunmute");
			Class327.smethod_7(string_0 + "_expert_drumunmute");
			Class327.smethod_7(string_0 + "_song_vocals");
			Class327.smethod_7(string_0 + "_vocals_freeform");
			Class327.smethod_7(string_0 + "_vocals_phrases");
			Class327.smethod_7(string_0 + "_vocals_note_range");
			Class327.smethod_7(string_0 + "_lyrics");
			Class327.smethod_7(string_0 + "_scripts_notes");
			Class327.smethod_7(string_0 + "_anim_notes");
			Class327.smethod_7(string_0 + "_triggers_notes");
			Class327.smethod_7(string_0 + "_cameras_notes");
			Class327.smethod_7(string_0 + "_lightshow_notes");
			Class327.smethod_7(string_0 + "_crowd_notes");
			Class327.smethod_7(string_0 + "_drums_notes");
			Class327.smethod_7(string_0 + "_performance_notes");
			Class327.smethod_7(string_0 + "_scripts");
			Class327.smethod_7(string_0 + "_anim");
			Class327.smethod_7(string_0 + "_triggers");
			Class327.smethod_7(string_0 + "_cameras");
			Class327.smethod_7(string_0 + "_lightshow");
			Class327.smethod_7(string_0 + "_crowd");
			Class327.smethod_7(string_0 + "_drums");
			Class327.smethod_7(string_0 + "_performance");
		}
	}
}
