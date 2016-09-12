using ns13;
using ns16;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ns20
{
	public static class QbSongClass1
	{
		private static Dictionary<int, string> dictionary_0 = new Dictionary<int, string>();

		private static Dictionary<int, string> dictionary_1 = new Dictionary<int, string>();

		public static bool bool_0 = false;

		public static void smethod_0()
		{
			if (QbSongClass1.bool_0)
			{
				return;
			}
			QbSongClass1.smethod_1(new MemoryStream(ZIPManager.smethod_5(KeyGenerator.smethod_5(Assembly.GetExecutingAssembly().GetManifestResourceStream("NeversoftTools.NSTreeView.nstags.aes"), "MinimizedNSTags1245"), "nstags.ids")));
			QbSongClass1.bool_0 = true;
		}

		public static void smethod_1(Stream stream_0)
		{
			QbSongClass1.smethod_2(stream_0, false);
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
						int key = KeyGenerator.GetQbKey(text, true);
						if (!QbSongClass1.dictionary_0.ContainsKey(key) && !QbSongClass1.dictionary_1.ContainsKey(key))
						{
							if (bool_1)
							{
								QbSongClass1.dictionary_1.Add(key, text);
							}
							else
							{
								QbSongClass1.dictionary_0.Add(key, text);
							}
						}
					}
				}
			}
		}

		public static bool smethod_3(int int_0)
		{
			return QbSongClass1.dictionary_0.ContainsKey(int_0) || QbSongClass1.dictionary_1.ContainsKey(int_0);
		}

		public static bool smethod_4(string string_0)
		{
			return QbSongClass1.dictionary_0.ContainsValue(string_0.ToLower());
		}

		public static string smethod_5(int int_0)
		{
			if (QbSongClass1.dictionary_0.ContainsKey(int_0))
			{
				return QbSongClass1.dictionary_0[int_0];
			}
			if (QbSongClass1.dictionary_1.ContainsKey(int_0))
			{
				return QbSongClass1.dictionary_1[int_0];
			}
			return null;
		}

		public static int smethod_6(string string_0)
		{
			if (!(string_0 == ""))
			{
				return KeyGenerator.GetQbKey(Encoding.Unicode.GetBytes(string_0), true);
			}
			return 0;
		}

		public static void smethod_7(string string_0)
		{
			QbSongClass1.smethod_8(string_0, true);
		}

		public static void smethod_8(string string_0, bool bool_1)
		{
			if (QbSongClass1.dictionary_0.ContainsValue(string_0) || QbSongClass1.dictionary_1.ContainsValue(string_0))
			{
				return;
			}
			int key = KeyGenerator.GetQbKey(string_0, true);
			if (bool_1 && !QbSongClass1.dictionary_1.ContainsKey(key))
			{
				QbSongClass1.dictionary_1.Add(key, string_0);
				return;
			}
			if (!QbSongClass1.dictionary_0.ContainsKey(key))
			{
				QbSongClass1.dictionary_0.Add(key, string_0);
			}
		}

		public static int smethod_9(string qbName)
		{
			qbName = qbName.ToLower();
			int num = KeyGenerator.GetQbKey(qbName, true);
			if (!QbSongClass1.smethod_3(num))
			{
				QbSongClass1.dictionary_1.Add(num, qbName);
			}
			return num;
		}

		public static void smethod_10(string string_0)
		{
			QbSongClass1.smethod_7(string_0);
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
					QbSongClass1.smethod_7(string.Concat(new object[]
					{
						"gh3_singer",
						text,
						string_0,
						"_",
						j
					}));
					QbSongClass1.smethod_7(string.Concat(new object[]
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
			QbSongClass1.smethod_7("animload_singer_male_" + string_0);
			QbSongClass1.smethod_7("animload_singer_female_" + string_0);
			QbSongClass1.smethod_7("menu_music_" + string_0);
			QbSongClass1.smethod_7("songs\\" + string_0 + ".mid.qb");
			QbSongClass1.smethod_7("songs\\" + string_0 + ".mid.qs");
			QbSongClass1.smethod_7("songs\\" + string_0 + ".mid_text.qb");
			QbSongClass1.smethod_7("songs\\" + string_0 + "_song_scripts.qb");
			QbSongClass1.smethod_7("data\\songs\\" + string_0 + ".mid");
			QbSongClass1.smethod_7("data\\songs\\" + string_0 + ".mid_text");
			QbSongClass1.smethod_7("data\\songs\\" + string_0 + "_song_scripts.qb");
			QbSongClass1.smethod_7("dlc\\output\\" + string_0 + ".mid.qb");
			QbSongClass1.smethod_7("dlc\\output\\" + string_0 + ".mid_text.qb");
			QbSongClass1.smethod_7("dlc\\output\\" + string_0 + ".mid");
			QbSongClass1.smethod_7("dlc\\output\\" + string_0 + ".mid_text");
			QbSongClass1.smethod_7("dlc\\output\\" + string_0 + "_song_scripts.qb");
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
					QbSongClass1.smethod_7(string_0 + "_song_" + text2 + text3);
					QbSongClass1.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_star"
					}));
					QbSongClass1.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_starbattlemode"
					}));
					QbSongClass1.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_tapping"
					}));
					QbSongClass1.smethod_7(string.Concat(new string[]
					{
						string_0,
						"_",
						text2,
						text3,
						"_whammycontroller"
					}));
				}
				QbSongClass1.smethod_7(string_0 + "_" + text2 + "faceoffstar");
				QbSongClass1.smethod_7(string_0 + "_" + text2 + "faceoffp1");
				QbSongClass1.smethod_7(string_0 + "_" + text2 + "faceoffp2");
			}
			QbSongClass1.smethod_7(string_0 + "_bossbattlep1");
			QbSongClass1.smethod_7(string_0 + "_bossbattlep2");
			QbSongClass1.smethod_7(string_0 + "_timesig");
			QbSongClass1.smethod_7(string_0 + "_fretbars");
			QbSongClass1.smethod_7(string_0 + "_guitar_markers");
			QbSongClass1.smethod_7(string_0 + "_rhythm_markers");
			QbSongClass1.smethod_7(string_0 + "_drum_markers");
			QbSongClass1.smethod_7(string_0 + "_vocals_markers");
			QbSongClass1.smethod_7(string_0 + "_easy_drumfill");
			QbSongClass1.smethod_7(string_0 + "_medium_drumfill");
			QbSongClass1.smethod_7(string_0 + "_hard_drumfill");
			QbSongClass1.smethod_7(string_0 + "_expert_drumfill");
			QbSongClass1.smethod_7(string_0 + "_easy_drumunmute");
			QbSongClass1.smethod_7(string_0 + "_medium_drumunmute");
			QbSongClass1.smethod_7(string_0 + "_hard_drumunmute");
			QbSongClass1.smethod_7(string_0 + "_expert_drumunmute");
			QbSongClass1.smethod_7(string_0 + "_song_vocals");
			QbSongClass1.smethod_7(string_0 + "_vocals_freeform");
			QbSongClass1.smethod_7(string_0 + "_vocals_phrases");
			QbSongClass1.smethod_7(string_0 + "_vocals_note_range");
			QbSongClass1.smethod_7(string_0 + "_lyrics");
			QbSongClass1.smethod_7(string_0 + "_scripts_notes");
			QbSongClass1.smethod_7(string_0 + "_anim_notes");
			QbSongClass1.smethod_7(string_0 + "_triggers_notes");
			QbSongClass1.smethod_7(string_0 + "_cameras_notes");
			QbSongClass1.smethod_7(string_0 + "_lightshow_notes");
			QbSongClass1.smethod_7(string_0 + "_crowd_notes");
			QbSongClass1.smethod_7(string_0 + "_drums_notes");
			QbSongClass1.smethod_7(string_0 + "_performance_notes");
			QbSongClass1.smethod_7(string_0 + "_scripts");
			QbSongClass1.smethod_7(string_0 + "_anim");
			QbSongClass1.smethod_7(string_0 + "_triggers");
			QbSongClass1.smethod_7(string_0 + "_cameras");
			QbSongClass1.smethod_7(string_0 + "_lightshow");
			QbSongClass1.smethod_7(string_0 + "_crowd");
			QbSongClass1.smethod_7(string_0 + "_drums");
			QbSongClass1.smethod_7(string_0 + "_performance");
		}
	}
}
