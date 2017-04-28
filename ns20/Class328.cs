using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ns16;
using ns19;

namespace ns20
{
	public class Class328 : TreeNode, IDisposable, Interface12
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private Enum35 enum35_0;

		public Dictionary<int, string> dictionary_0;

		private Encoding encoding_0;

		public Class328() : this("newfile.qs")
		{
		}

		public Class328(string string_0)
		{
			encoding_0 = Encoding.Unicode;
			//base..ctor();
			Text = KeyGenerator.GetFileName(string_0);
			int_2 = QbSongClass1.AddKeyToDictionary(string_0.Substring(string_0.LastIndexOf('.')));
			int_3 = QbSongClass1.AddKeyToDictionary(string_0);
			int_4 = QbSongClass1.AddKeyToDictionary(KeyGenerator.GetFileNameNoExt(string_0));
			ImageIndex = 39;
			SelectedImageIndex = 39;
			dictionary_0 = null;
		}

		public Class328(string string_0, Dictionary<int, string> dictionary_1) : this(string_0)
		{
			dictionary_0 = dictionary_1;
		}

		public Class328(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Enum35 enum35_1)
		{
			encoding_0 = Encoding.Unicode;
			//base..ctor();
			Text = (QbSongClass1.ContainsKey(int_9) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(int_9)) : ("0x" + KeyGenerator.ValToHex32bit(int_9)));
			int_2 = int_6;
			int_0 = int_7;
			int_1 = int_8;
			int_3 = int_9;
			int_4 = int_10;
			int_5 = int_11;
			enum35_0 = enum35_1;
			ImageIndex = 39;
			SelectedImageIndex = 39;
			dictionary_0 = null;
		}

		public int imethod_0()
		{
			return int_0;
		}

		public void imethod_1(int int_6)
		{
			int_0 = int_6;
		}

		public int imethod_2()
		{
			if (dictionary_0 == null)
			{
				return int_1;
			}
			int num = 2;
			if (dictionary_0.Count != 0)
			{
				num = dictionary_0.Keys.Count * 12 + 1;
				foreach (int current in dictionary_0.Keys)
				{
					num += dictionary_0[current].Length;
				}
			}
			return encoding_0.GetMaxByteCount(num);
		}

		public void imethod_3(int int_6)
		{
			if (dictionary_0 == null)
			{
				int_1 = int_6;
			}
		}

		public int imethod_4()
		{
			return int_2;
		}

		public void imethod_5(int int_6)
		{
			int_2 = int_6;
		}

		public string imethod_6()
		{
			if (!QbSongClass1.ContainsKey(imethod_4()))
			{
				return "0x" + KeyGenerator.ValToHex32bit(imethod_4());
			}
			return QbSongClass1.GetDictString(imethod_4());
		}

		public int imethod_7()
		{
			if (Parent != null && Parent is zzPakNode1 && !(Parent as zzPakNode1).bool_0)
			{
				return QbSongClass1.AddKeyToDictionary((Parent as zzPakNode1).vmethod_0() + Text);
			}
			return int_3;
		}

		public void imethod_8(int int_6)
		{
			int_3 = int_6;
		}

		public string imethod_9()
		{
			if (!QbSongClass1.ContainsKey(imethod_7()))
			{
				return "0x" + KeyGenerator.ValToHex32bit(imethod_7());
			}
			return QbSongClass1.GetDictString(imethod_7());
		}

		public int imethod_10()
		{
			return int_4;
		}

		public void imethod_11(int int_6)
		{
			int_4 = int_6;
		}

		public int imethod_12()
		{
			return int_5;
		}

		public void imethod_13(int int_6)
		{
			int_5 = int_6;
		}

		public Enum35 imethod_14()
		{
			return enum35_0;
		}

		public void imethod_15(Enum35 enum35_1)
		{
			enum35_0 = enum35_1;
		}

		public byte[] imethod_16()
		{
			MemoryStream memoryStream = new MemoryStream();
			using (StreamWriter streamWriter = new StreamWriter(memoryStream, encoding_0))
			{
				if (dictionary_0 != null && dictionary_0.Count != 0)
				{
					foreach (int current in dictionary_0.Keys)
					{
						streamWriter.Write("{0} \"{1}\"\n", KeyGenerator.ValToHex32bit(current), dictionary_0[current]);
					}
					streamWriter.Write("\n");
				}
				else
				{
					streamWriter.Write("\n\n");
				}
			}
			return memoryStream.ToArray();
		}

		public void imethod_17(byte[] byte_0)
		{
			dictionary_0 = new Dictionary<int, string>();
			StreamReader streamReader = new StreamReader(new MemoryStream(byte_0), encoding_0);
			encoding_0 = streamReader.CurrentEncoding;
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (!(text == ""))
				{
					string[] array = text.Split(new[]
					{
						' '
					}, 2, StringSplitOptions.RemoveEmptyEntries);
					int key;
					try
					{
						key = KeyGenerator.HexStringToInt(array[0]);
					}
					catch (Exception)
					{
						continue;
					}
					if (!dictionary_0.ContainsKey(key))
					{
						dictionary_0.Add(key, array[1].Trim('"'));
					}
				}
			}
			streamReader.Close();
			streamReader.Dispose();
		}

		public bool imethod_18()
		{
			return dictionary_0 == null;
		}

		public void imethod_19()
		{
			dictionary_0 = null;
		}

		public T imethod_20<T>(T gparam_0) where T : Interface12
		{
			gparam_0.imethod_1(int_0);
			gparam_0.imethod_3(int_1);
			gparam_0.imethod_5(int_2);
			gparam_0.imethod_8(int_3);
			gparam_0.imethod_11(int_4);
			gparam_0.imethod_13(int_5);
			gparam_0.imethod_15(enum35_0);
			if (!imethod_18())
			{
				gparam_0.imethod_17(imethod_16());
			}
			else
			{
				gparam_0.imethod_19();
			}
			return gparam_0;
		}

		public void Dispose()
		{
			imethod_19();
		}

		public override object Clone()
		{
			Class328 @class = (Class328)base.Clone();
			@class.imethod_1(int_0);
			@class.imethod_3(int_1);
			@class.imethod_5(int_2);
			@class.imethod_8(int_3);
			@class.imethod_11(int_4);
			@class.imethod_13(int_5);
			@class.imethod_15(enum35_0);
			if (imethod_18())
			{
				@class.imethod_19();
			}
			return @class;
		}
	}
}
