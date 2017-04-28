using System;
using System.Collections.Generic;
using System.IO;
using ns0;
using ns1;
using ns12;
using ns16;
using ns19;
using ns8;
using ns9;
using SharpAudio.ASC;
using FSBClass2 = ns20.FSBClass2;

namespace ns15
{
	public class Class248 : QbEditor
	{
		private readonly zzQbSongObject class323_0;

		public bool bool_0;

		public bool bool_1;

		private readonly string[] string_0;

		private readonly TimeSpan timeSpan_0;

		private readonly TimeSpan timeSpan_1;

		public string string_1;

		private readonly string string_2;

		private readonly string string_3;

		public static bool bool_2;

		public static bool bool_3;

		public Class248(zzQbSongObject class323_1, string string_4, string string_5)
		{
			class323_0 = class323_1;
			string_1 = class323_0.fileName;
			string_3 = string_4;
			string_2 = string_5;
			var array = class323_0.string_1;
			for (var i = 0; i < array.Length; i++)
			{
				var text = array[i];
				if (text.Equals(class323_0.fileName + "_rhythm"))
				{
					bool_0 = true;
				}
				else if (text.Contains(class323_0.fileName + "_coop_"))
				{
					bool_1 = true;
				}
			}
		}

		public Class248(string string_4, string[] string_5, TimeSpan timeSpan_2, TimeSpan timeSpan_3, string string_6)
		{
			string_1 = string_4;
			string_0 = string_5;
			timeSpan_0 = timeSpan_2;
			timeSpan_1 = timeSpan_3;
			string_2 = string_6;
			bool_0 = (string_0.Length > 2 && !string_0[2].Equals(""));
			bool_1 = (string_0.Length == 6);
		}

		public override void vmethod_0()
		{
			if (class323_0 != null)
			{
				KeyGenerator.WriteAllBytes(string_2 + "music\\" + string_1 + ".dat.xen", class323_0.data);
				KeyGenerator.smethod_19(string_3, string_2 + "music\\" + string_1 + ".fsb.xen", true);
			}
			else
			{
				var list = new List<string>();
				var list2 = new List<Stream>();
				GenericAudioStream stream3;
				if (string_0.Length == 1)
				{
					Stream stream;
					if (!bool_3 && AudioManager.smethod_1(string_0[0]) == AudioTypeEnum.const_1)
					{
						stream = File.OpenRead(string_0[0]);
					}
					else
					{
						stream = new Stream27();
						Stream16.smethod_0(AudioManager.getAudioStream(string_0[0]), stream, 44100, 128);
					}
					stream.Position = 0L;
					list.Add(string_1 + "_song");
					list2.Add(stream);
					list.Add(string_1 + "_guitar");
					if (bool_2)
					{
						Stream stream2 = new Stream27();
						Stream16.smethod_1(stream2, AudioManager.smethod_2(string_0[0]), 128);
						list2.Add(stream2);
					}
					else
					{
						list2.Add(stream);
					}
					stream3 = AudioManager.smethod_5(stream);
				}
				else
				{
					var list3 = new List<GenericAudioStream>();
					string[] array = {
						"_song",
						"_guitar",
						"_rhythm",
						"_coop_song",
						"_coop_guitar",
						"_coop_rhythm"
					};
					for (var i = 0; i < string_0.Length; i++)
					{
						if (string_0[i] != null && !string_0[i].Equals("") && File.Exists(string_0[i]))
						{
							Stream stream4;
							if (!bool_3 && AudioManager.smethod_1(string_0[i]) == AudioTypeEnum.const_1)
							{
								stream4 = File.OpenRead(string_0[i]);
							}
							else
							{
								stream4 = new Stream27();
								Stream16.smethod_0(AudioManager.getAudioStream(string_0[i]), stream4, 44100, 128);
							}
							stream4.Position = 0L;
							list.Add(string_1 + array[i]);
							list2.Add(stream4);
							if ((string_0.Length == 6) ? (i >= 3) : (i < 3))
							{
								list3.Add(AudioManager.smethod_5(stream4));
							}
						}
					}
					stream3 = new Stream2(list3.ToArray());
					var num = 0f;
					var stream5 = new Stream3(stream3, timeSpan_0, timeSpan_1);
					var array2 = stream5.vmethod_5(100);
					while (array2 != null && array2.Length > 0)
					{
						var array3 = array2;
						for (var j = 0; j < array3.Length; j++)
						{
							var array4 = array3[j];
							var array5 = array4;
							for (var k = 0; k < array5.Length; k++)
							{
								var value = array5[k];
								var num2 = Math.Abs(value);
								if (num2 > num)
								{
									num = num2;
								}
							}
						}
						array2 = stream5.vmethod_5(100);
					}
					(stream3 as Stream2).method_0(new Interface5[]
					{
						new Class174(3, 1f / num)
					});
				}
				var waveFormat = stream3.vmethod_0();
				var t = new TimeSpan(0, 0, 1);
				Stream stream6 = new Stream27();
				Stream16.smethod_0(new Stream2(new Stream3(stream3, timeSpan_0, timeSpan_1), new Interface5[]
				{
					new Class173(Class173.Enum26.const_0, new[]
					{
						new Struct11(0, waveFormat.method_1(t))
					}),
					new Class173(Class173.Enum26.const_1, new[]
					{
						new Struct11(waveFormat.method_1(timeSpan_1 - timeSpan_0 - t), waveFormat.method_1(timeSpan_1 - timeSpan_0))
					})
				}), stream6, 44100, 128);
				list.Add(string_1 + "_preview");
				list2.Add(stream6);
				new zzQbSongObject((int)FSBClass2.smethod_0(string_2 + "music\\" + string_1 + ".fsb.xen", list2.ToArray()), list.ToArray()).method_2(string_2 + "music\\" + string_1 + ".dat.xen");
			}
			GC.Collect();
		}

		public override string ToString()
		{
			return "Create Music Track: " + string_1;
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class248 && (other as Class248).string_1 == string_1;
		}
	}
}
