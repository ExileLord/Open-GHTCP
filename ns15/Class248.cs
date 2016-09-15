using ns0;
using ns1;
using ns12;
using ns16;
using ns19;
using ns20;
using ns8;
using ns9;
using SharpAudio.ASC;
using System;
using System.Collections.Generic;
using System.IO;

namespace ns15
{
	public class Class248 : QbEditor
	{
		private readonly zzQbSongObject class323_0;

		public bool bool_0;

		public bool bool_1;

		private string[] string_0;

		private TimeSpan timeSpan_0;

		private TimeSpan timeSpan_1;

		public string string_1;

		private readonly string string_2;

		private readonly string string_3;

		public static bool bool_2;

		public static bool bool_3;

		public Class248(zzQbSongObject class323_1, string string_4, string string_5)
		{
			this.class323_0 = class323_1;
			this.string_1 = this.class323_0.fileName;
			this.string_3 = string_4;
			this.string_2 = string_5;
			string[] array = this.class323_0.string_1;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (text.Equals(this.class323_0.fileName + "_rhythm"))
				{
					this.bool_0 = true;
				}
				else if (text.Contains(this.class323_0.fileName + "_coop_"))
				{
					this.bool_1 = true;
				}
			}
		}

		public Class248(string string_4, string[] string_5, TimeSpan timeSpan_2, TimeSpan timeSpan_3, string string_6)
		{
			this.string_1 = string_4;
			this.string_0 = string_5;
			this.timeSpan_0 = timeSpan_2;
			this.timeSpan_1 = timeSpan_3;
			this.string_2 = string_6;
			this.bool_0 = (this.string_0.Length > 2 && !this.string_0[2].Equals(""));
			this.bool_1 = (this.string_0.Length == 6);
		}

		public override void vmethod_0()
		{
			if (this.class323_0 != null)
			{
				KeyGenerator.smethod_9(this.string_2 + "music\\" + this.string_1 + ".dat.xen", this.class323_0.data);
				KeyGenerator.smethod_19(this.string_3, this.string_2 + "music\\" + this.string_1 + ".fsb.xen", true);
			}
			else
			{
				List<string> list = new List<string>();
				List<Stream> list2 = new List<Stream>();
				GenericAudioStream stream3;
				if (this.string_0.Length == 1)
				{
					Stream stream;
					if (!Class248.bool_3 && AudioManager.smethod_1(this.string_0[0]) == AudioTypeEnum.const_1)
					{
						stream = File.OpenRead(this.string_0[0]);
					}
					else
					{
						stream = new Stream27();
						Stream16.smethod_0(AudioManager.getAudioStream(this.string_0[0]), stream, 44100, 128);
					}
					stream.Position = 0L;
					list.Add(this.string_1 + "_song");
					list2.Add(stream);
					list.Add(this.string_1 + "_guitar");
					if (Class248.bool_2)
					{
						Stream stream2 = new Stream27();
						Stream16.smethod_1(stream2, AudioManager.smethod_2(this.string_0[0]), 128);
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
					List<GenericAudioStream> list3 = new List<GenericAudioStream>();
					string[] array = new string[]
					{
						"_song",
						"_guitar",
						"_rhythm",
						"_coop_song",
						"_coop_guitar",
						"_coop_rhythm"
					};
					for (int i = 0; i < this.string_0.Length; i++)
					{
						if (this.string_0[i] != null && !this.string_0[i].Equals("") && File.Exists(this.string_0[i]))
						{
							Stream stream4;
							if (!Class248.bool_3 && AudioManager.smethod_1(this.string_0[i]) == AudioTypeEnum.const_1)
							{
								stream4 = File.OpenRead(this.string_0[i]);
							}
							else
							{
								stream4 = new Stream27();
								Stream16.smethod_0(AudioManager.getAudioStream(this.string_0[i]), stream4, 44100, 128);
							}
							stream4.Position = 0L;
							list.Add(this.string_1 + array[i]);
							list2.Add(stream4);
							if ((this.string_0.Length == 6) ? (i >= 3) : (i < 3))
							{
								list3.Add(AudioManager.smethod_5(stream4));
							}
						}
					}
					stream3 = new Stream2(list3.ToArray());
					float num = 0f;
					Stream3 stream5 = new Stream3(stream3, this.timeSpan_0, this.timeSpan_1);
					float[][] array2 = stream5.vmethod_5(100);
					while (array2 != null && array2.Length > 0)
					{
						float[][] array3 = array2;
						for (int j = 0; j < array3.Length; j++)
						{
							float[] array4 = array3[j];
							float[] array5 = array4;
							for (int k = 0; k < array5.Length; k++)
							{
								float value = array5[k];
								float num2 = Math.Abs(value);
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
				WaveFormat waveFormat = stream3.vmethod_0();
				TimeSpan t = new TimeSpan(0, 0, 1);
				Stream stream6 = new Stream27();
				Stream16.smethod_0(new Stream2(new Stream3(stream3, this.timeSpan_0, this.timeSpan_1), new Interface5[]
				{
					new Class173(Class173.Enum26.const_0, new Struct11[]
					{
						new Struct11(0, waveFormat.method_1(t))
					}),
					new Class173(Class173.Enum26.const_1, new Struct11[]
					{
						new Struct11(waveFormat.method_1(this.timeSpan_1 - this.timeSpan_0 - t), waveFormat.method_1(this.timeSpan_1 - this.timeSpan_0))
					})
				}), stream6, 44100, 128);
				list.Add(this.string_1 + "_preview");
				list2.Add(stream6);
				new zzQbSongObject((int)ns20.FSBClass2.smethod_0(this.string_2 + "music\\" + this.string_1 + ".fsb.xen", list2.ToArray()), list.ToArray()).method_2(this.string_2 + "music\\" + this.string_1 + ".dat.xen");
			}
			GC.Collect();
		}

		public override string ToString()
		{
			return "Create Music Track: " + this.string_1;
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class248 && (other as Class248).string_1 == this.string_1;
		}
	}
}
