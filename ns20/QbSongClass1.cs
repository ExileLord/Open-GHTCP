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
		private static Dictionary<int, string> _keyDict1 = new Dictionary<int, string>();

		private static Dictionary<int, string> _keyDict2 = new Dictionary<int, string>();

		public static bool Dirty = false; //This hasn't been saved yet?..

		public static void smethod_0()
		{
			if (QbSongClass1.Dirty)
			{
				return;
			}
			QbSongClass1.AddAllLinesToDictionary(new MemoryStream(ZIPManager.smethod_5(KeyGenerator.cryptoMethod(Assembly.GetExecutingAssembly().GetManifestResourceStream("NeversoftTools.NSTreeView.nstags.aes"), "MinimizedNSTags1245"), "nstags.ids")));
			QbSongClass1.Dirty = true;
		}

		public static void AddAllLinesToDictionary(Stream stream, bool useSecondDictionary = false)
		{
			using (StreamReader streamReader = new StreamReader(stream))
			{
				string text;
				while ((text = streamReader.ReadLine()) != null)
				{
					if (!text.Equals(""))
					{
						int key = KeyGenerator.GetQbKey(text, true);
						if (!QbSongClass1._keyDict1.ContainsKey(key) && !QbSongClass1._keyDict2.ContainsKey(key))
						{
							if (useSecondDictionary)
							{
								QbSongClass1._keyDict2.Add(key, text);
							}
							else
							{
								QbSongClass1._keyDict1.Add(key, text);
							}
						}
					}
				}
			}
		}

		public static bool ContainsKey(int key)
		{
			return QbSongClass1._keyDict1.ContainsKey(key) || QbSongClass1._keyDict2.ContainsKey(key);
		}

		public static bool smethod_4(string string_0)
		{
			return QbSongClass1._keyDict1.ContainsValue(string_0.ToLower());
		}

		public static string GetDictString(int key)
		{
			if (QbSongClass1._keyDict1.ContainsKey(key))
			{
				return QbSongClass1._keyDict1[key];
			}
			if (QbSongClass1._keyDict2.ContainsKey(key))
			{
				return QbSongClass1._keyDict2[key];
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

		public static void AddStringToDictionary(string str, bool addToTheOtherDictionaryToo = true)
		{
			if (QbSongClass1._keyDict1.ContainsValue(str) || QbSongClass1._keyDict2.ContainsValue(str))
			{
				return;
			}
			int key = KeyGenerator.GetQbKey(str, true);
			if (addToTheOtherDictionaryToo && !QbSongClass1._keyDict2.ContainsKey(key))
			{
				QbSongClass1._keyDict2.Add(key, str);
				return;
			}
			if (!QbSongClass1._keyDict1.ContainsKey(key))
			{
				QbSongClass1._keyDict1.Add(key, str);
			}
		}

		public static int AddKeyToDictionary(string qbName)
		{
			qbName = qbName.ToLower();
			int key = KeyGenerator.GetQbKey(qbName, true);
			if (!QbSongClass1.ContainsKey(key))
			{
				QbSongClass1._keyDict2.Add(key, qbName);
			}
			return key;
		}

		public static void GenerateSongTrackStuff(string songName)
		{
			QbSongClass1.AddStringToDictionary(songName);
			string[] singerTypes = new string[]
			{
				"_male_",
				"_female_"
			};
			for (int i = 0; i < singerTypes.Length; i++)
			{
				string singerGender = singerTypes[i];
				for (int j = 1; j < 10; j++)
				{
					QbSongClass1.AddStringToDictionary(string.Concat(new object[]
					{
						"gh3_singer",
						singerGender,
						songName,
						"_",
						j
					}));
					QbSongClass1.AddStringToDictionary(string.Concat(new object[]
					{
						"gh3_singer",
						singerGender,
						songName,
						"_",
						j,
						"b"
					}));
				}
			}
			QbSongClass1.AddStringToDictionary("animload_singer_male_" + songName);
			QbSongClass1.AddStringToDictionary("animload_singer_female_" + songName);
			QbSongClass1.AddStringToDictionary("menu_music_" + songName);
			QbSongClass1.AddStringToDictionary("songs\\" + songName + ".mid.qb");
			QbSongClass1.AddStringToDictionary("songs\\" + songName + ".mid.qs");
			QbSongClass1.AddStringToDictionary("songs\\" + songName + ".mid_text.qb");
			QbSongClass1.AddStringToDictionary("songs\\" + songName + "_song_scripts.qb");
			QbSongClass1.AddStringToDictionary("data\\songs\\" + songName + ".mid");
			QbSongClass1.AddStringToDictionary("data\\songs\\" + songName + ".mid_text");
			QbSongClass1.AddStringToDictionary("data\\songs\\" + songName + "_song_scripts.qb");
			QbSongClass1.AddStringToDictionary("dlc\\output\\" + songName + ".mid.qb");
			QbSongClass1.AddStringToDictionary("dlc\\output\\" + songName + ".mid_text.qb");
			QbSongClass1.AddStringToDictionary("dlc\\output\\" + songName + ".mid");
			QbSongClass1.AddStringToDictionary("dlc\\output\\" + songName + ".mid_text");
			QbSongClass1.AddStringToDictionary("dlc\\output\\" + songName + "_song_scripts.qb");
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
					QbSongClass1.AddStringToDictionary(songName + "_song_" + text2 + text3);
					QbSongClass1.AddStringToDictionary(string.Concat(new string[]
					{
						songName,
						"_",
						text2,
						text3,
						"_star"
					}));
					QbSongClass1.AddStringToDictionary(string.Concat(new string[]
					{
						songName,
						"_",
						text2,
						text3,
						"_starbattlemode"
					}));
					QbSongClass1.AddStringToDictionary(string.Concat(new string[]
					{
						songName,
						"_",
						text2,
						text3,
						"_tapping"
					}));
					QbSongClass1.AddStringToDictionary(string.Concat(new string[]
					{
						songName,
						"_",
						text2,
						text3,
						"_whammycontroller"
					}));
				}
				QbSongClass1.AddStringToDictionary(songName + "_" + text2 + "faceoffstar");
				QbSongClass1.AddStringToDictionary(songName + "_" + text2 + "faceoffp1");
				QbSongClass1.AddStringToDictionary(songName + "_" + text2 + "faceoffp2");
			}
			QbSongClass1.AddStringToDictionary(songName + "_bossbattlep1");
			QbSongClass1.AddStringToDictionary(songName + "_bossbattlep2");
			QbSongClass1.AddStringToDictionary(songName + "_timesig");
			QbSongClass1.AddStringToDictionary(songName + "_fretbars");
			QbSongClass1.AddStringToDictionary(songName + "_guitar_markers");
			QbSongClass1.AddStringToDictionary(songName + "_rhythm_markers");
			QbSongClass1.AddStringToDictionary(songName + "_drum_markers");
			QbSongClass1.AddStringToDictionary(songName + "_vocals_markers");
			QbSongClass1.AddStringToDictionary(songName + "_easy_drumfill");
			QbSongClass1.AddStringToDictionary(songName + "_medium_drumfill");
			QbSongClass1.AddStringToDictionary(songName + "_hard_drumfill");
			QbSongClass1.AddStringToDictionary(songName + "_expert_drumfill");
			QbSongClass1.AddStringToDictionary(songName + "_easy_drumunmute");
			QbSongClass1.AddStringToDictionary(songName + "_medium_drumunmute");
			QbSongClass1.AddStringToDictionary(songName + "_hard_drumunmute");
			QbSongClass1.AddStringToDictionary(songName + "_expert_drumunmute");
			QbSongClass1.AddStringToDictionary(songName + "_song_vocals");
			QbSongClass1.AddStringToDictionary(songName + "_vocals_freeform");
			QbSongClass1.AddStringToDictionary(songName + "_vocals_phrases");
			QbSongClass1.AddStringToDictionary(songName + "_vocals_note_range");
			QbSongClass1.AddStringToDictionary(songName + "_lyrics");
			QbSongClass1.AddStringToDictionary(songName + "_scripts_notes");
			QbSongClass1.AddStringToDictionary(songName + "_anim_notes");
			QbSongClass1.AddStringToDictionary(songName + "_triggers_notes");
			QbSongClass1.AddStringToDictionary(songName + "_cameras_notes");
			QbSongClass1.AddStringToDictionary(songName + "_lightshow_notes");
			QbSongClass1.AddStringToDictionary(songName + "_crowd_notes");
			QbSongClass1.AddStringToDictionary(songName + "_drums_notes");
			QbSongClass1.AddStringToDictionary(songName + "_performance_notes");
			QbSongClass1.AddStringToDictionary(songName + "_scripts");
			QbSongClass1.AddStringToDictionary(songName + "_anim");
			QbSongClass1.AddStringToDictionary(songName + "_triggers");
			QbSongClass1.AddStringToDictionary(songName + "_cameras");
			QbSongClass1.AddStringToDictionary(songName + "_lightshow");
			QbSongClass1.AddStringToDictionary(songName + "_crowd");
			QbSongClass1.AddStringToDictionary(songName + "_drums");
			QbSongClass1.AddStringToDictionary(songName + "_performance");
		}
	}
}
