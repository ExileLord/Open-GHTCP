using ns16;
using ns19;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

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

		public Class328(string string_0) : base()
		{
			this.encoding_0 = Encoding.Unicode;
			//base..ctor();
			base.Text = KeyGenerator.GetFileName(string_0);
			this.int_2 = QbSongClass1.AddKeyToDictionary(string_0.Substring(string_0.LastIndexOf('.')));
			this.int_3 = QbSongClass1.AddKeyToDictionary(string_0);
			this.int_4 = QbSongClass1.AddKeyToDictionary(KeyGenerator.GetFileNameNoExt(string_0));
			base.ImageIndex = 39;
			base.SelectedImageIndex = 39;
			this.dictionary_0 = null;
		}

		public Class328(string string_0, Dictionary<int, string> dictionary_1) : this(string_0)
		{
			this.dictionary_0 = dictionary_1;
		}

		public Class328(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Enum35 enum35_1) : base()
		{
			this.encoding_0 = Encoding.Unicode;
			//base..ctor();
			base.Text = (QbSongClass1.ContainsKey(int_9) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(int_9)) : ("0x" + KeyGenerator.ValToHex32bit(int_9)));
			this.int_2 = int_6;
			this.int_0 = int_7;
			this.int_1 = int_8;
			this.int_3 = int_9;
			this.int_4 = int_10;
			this.int_5 = int_11;
			this.enum35_0 = enum35_1;
			base.ImageIndex = 39;
			base.SelectedImageIndex = 39;
			this.dictionary_0 = null;
		}

		public int imethod_0()
		{
			return this.int_0;
		}

		public void imethod_1(int int_6)
		{
			this.int_0 = int_6;
		}

		public int imethod_2()
		{
			if (this.dictionary_0 == null)
			{
				return this.int_1;
			}
			int num = 2;
			if (this.dictionary_0.Count != 0)
			{
				num = this.dictionary_0.Keys.Count * 12 + 1;
				foreach (int current in this.dictionary_0.Keys)
				{
					num += this.dictionary_0[current].Length;
				}
			}
			return this.encoding_0.GetMaxByteCount(num);
		}

		public void imethod_3(int int_6)
		{
			if (this.dictionary_0 == null)
			{
				this.int_1 = int_6;
			}
		}

		public int imethod_4()
		{
			return this.int_2;
		}

		public void imethod_5(int int_6)
		{
			this.int_2 = int_6;
		}

		public string imethod_6()
		{
			if (!QbSongClass1.ContainsKey(this.imethod_4()))
			{
				return "0x" + KeyGenerator.ValToHex32bit(this.imethod_4());
			}
			return QbSongClass1.GetDictString(this.imethod_4());
		}

		public int imethod_7()
		{
			if (base.Parent != null && base.Parent is zzPakNode1 && !(base.Parent as zzPakNode1).bool_0)
			{
				return QbSongClass1.AddKeyToDictionary((base.Parent as zzPakNode1).vmethod_0() + base.Text);
			}
			return this.int_3;
		}

		public void imethod_8(int int_6)
		{
			this.int_3 = int_6;
		}

		public string imethod_9()
		{
			if (!QbSongClass1.ContainsKey(this.imethod_7()))
			{
				return "0x" + KeyGenerator.ValToHex32bit(this.imethod_7());
			}
			return QbSongClass1.GetDictString(this.imethod_7());
		}

		public int imethod_10()
		{
			return this.int_4;
		}

		public void imethod_11(int int_6)
		{
			this.int_4 = int_6;
		}

		public int imethod_12()
		{
			return this.int_5;
		}

		public void imethod_13(int int_6)
		{
			this.int_5 = int_6;
		}

		public Enum35 imethod_14()
		{
			return this.enum35_0;
		}

		public void imethod_15(Enum35 enum35_1)
		{
			this.enum35_0 = enum35_1;
		}

		public byte[] imethod_16()
		{
			MemoryStream memoryStream = new MemoryStream();
			using (StreamWriter streamWriter = new StreamWriter(memoryStream, this.encoding_0))
			{
				if (this.dictionary_0 != null && this.dictionary_0.Count != 0)
				{
					foreach (int current in this.dictionary_0.Keys)
					{
						streamWriter.Write("{0} \"{1}\"\n", KeyGenerator.ValToHex32bit(current), this.dictionary_0[current]);
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
			this.dictionary_0 = new Dictionary<int, string>();
			StreamReader streamReader = new StreamReader(new MemoryStream(byte_0), this.encoding_0);
			this.encoding_0 = streamReader.CurrentEncoding;
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (!(text == ""))
				{
					string[] array = text.Split(new char[]
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
					if (!this.dictionary_0.ContainsKey(key))
					{
						this.dictionary_0.Add(key, array[1].Trim(new char[]
						{
							'"'
						}));
					}
				}
			}
			streamReader.Close();
			streamReader.Dispose();
		}

		public bool imethod_18()
		{
			return this.dictionary_0 == null;
		}

		public void imethod_19()
		{
			this.dictionary_0 = null;
		}

		public T imethod_20<T>(T gparam_0) where T : Interface12
		{
			gparam_0.imethod_1(this.int_0);
			gparam_0.imethod_3(this.int_1);
			gparam_0.imethod_5(this.int_2);
			gparam_0.imethod_8(this.int_3);
			gparam_0.imethod_11(this.int_4);
			gparam_0.imethod_13(this.int_5);
			gparam_0.imethod_15(this.enum35_0);
			if (!this.imethod_18())
			{
				gparam_0.imethod_17(this.imethod_16());
			}
			else
			{
				gparam_0.imethod_19();
			}
			return gparam_0;
		}

		public void Dispose()
		{
			this.imethod_19();
		}

		public override object Clone()
		{
			Class328 @class = (Class328)base.Clone();
			@class.imethod_1(this.int_0);
			@class.imethod_3(this.int_1);
			@class.imethod_5(this.int_2);
			@class.imethod_8(this.int_3);
			@class.imethod_11(this.int_4);
			@class.imethod_13(this.int_5);
			@class.imethod_15(this.enum35_0);
			if (this.imethod_18())
			{
				@class.imethod_19();
			}
			return @class;
		}
	}
}
