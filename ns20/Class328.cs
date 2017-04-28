using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ns16;
using ns19;

namespace ns20
{
	public class Class328 : TreeNode, IDisposable, INterface12
	{
		private int _int0;

		private int _int1;

		private int _int2;

		private int _int3;

		private int _int4;

		private int _int5;

		private Enum35 _enum350;

		public Dictionary<int, string> Dictionary0;

		private Encoding _encoding0;

		public Class328() : this("newfile.qs")
		{
		}

		public Class328(string string0)
		{
			_encoding0 = Encoding.Unicode;
			//base..ctor();
			Text = KeyGenerator.GetFileName(string0);
			_int2 = QbSongClass1.AddKeyToDictionary(string0.Substring(string0.LastIndexOf('.')));
			_int3 = QbSongClass1.AddKeyToDictionary(string0);
			_int4 = QbSongClass1.AddKeyToDictionary(KeyGenerator.GetFileNameNoExt(string0));
			ImageIndex = 39;
			SelectedImageIndex = 39;
			Dictionary0 = null;
		}

		public Class328(string string0, Dictionary<int, string> dictionary1) : this(string0)
		{
			Dictionary0 = dictionary1;
		}

		public Class328(int int6, int int7, int int8, int int9, int int10, int int11, Enum35 enum351)
		{
			_encoding0 = Encoding.Unicode;
			//base..ctor();
			Text = (QbSongClass1.ContainsKey(int9) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(int9)) : ("0x" + KeyGenerator.ValToHex32Bit(int9)));
			_int2 = int6;
			_int0 = int7;
			_int1 = int8;
			_int3 = int9;
			_int4 = int10;
			_int5 = int11;
			_enum350 = enum351;
			ImageIndex = 39;
			SelectedImageIndex = 39;
			Dictionary0 = null;
		}

		public int imethod_0()
		{
			return _int0;
		}

		public void imethod_1(int int6)
		{
			_int0 = int6;
		}

		public int imethod_2()
		{
			if (Dictionary0 == null)
			{
				return _int1;
			}
			var num = 2;
			if (Dictionary0.Count != 0)
			{
				num = Dictionary0.Keys.Count * 12 + 1;
				foreach (var current in Dictionary0.Keys)
				{
					num += Dictionary0[current].Length;
				}
			}
			return _encoding0.GetMaxByteCount(num);
		}

		public void imethod_3(int int6)
		{
			if (Dictionary0 == null)
			{
				_int1 = int6;
			}
		}

		public int imethod_4()
		{
			return _int2;
		}

		public void imethod_5(int int6)
		{
			_int2 = int6;
		}

		public string imethod_6()
		{
			if (!QbSongClass1.ContainsKey(imethod_4()))
			{
				return "0x" + KeyGenerator.ValToHex32Bit(imethod_4());
			}
			return QbSongClass1.GetDictString(imethod_4());
		}

		public int imethod_7()
		{
			if (Parent != null && Parent is ZzPakNode1 && !(Parent as ZzPakNode1).Bool0)
			{
				return QbSongClass1.AddKeyToDictionary((Parent as ZzPakNode1).vmethod_0() + Text);
			}
			return _int3;
		}

		public void imethod_8(int int6)
		{
			_int3 = int6;
		}

		public string imethod_9()
		{
			if (!QbSongClass1.ContainsKey(imethod_7()))
			{
				return "0x" + KeyGenerator.ValToHex32Bit(imethod_7());
			}
			return QbSongClass1.GetDictString(imethod_7());
		}

		public int imethod_10()
		{
			return _int4;
		}

		public void imethod_11(int int6)
		{
			_int4 = int6;
		}

		public int imethod_12()
		{
			return _int5;
		}

		public void imethod_13(int int6)
		{
			_int5 = int6;
		}

		public Enum35 imethod_14()
		{
			return _enum350;
		}

		public void imethod_15(Enum35 enum351)
		{
			_enum350 = enum351;
		}

		public byte[] imethod_16()
		{
			var memoryStream = new MemoryStream();
			using (var streamWriter = new StreamWriter(memoryStream, _encoding0))
			{
				if (Dictionary0 != null && Dictionary0.Count != 0)
				{
					foreach (var current in Dictionary0.Keys)
					{
						streamWriter.Write("{0} \"{1}\"\n", KeyGenerator.ValToHex32Bit(current), Dictionary0[current]);
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

		public void imethod_17(byte[] byte0)
		{
			Dictionary0 = new Dictionary<int, string>();
			var streamReader = new StreamReader(new MemoryStream(byte0), _encoding0);
			_encoding0 = streamReader.CurrentEncoding;
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (!(text == ""))
				{
					var array = text.Split(new[]
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
					if (!Dictionary0.ContainsKey(key))
					{
						Dictionary0.Add(key, array[1].Trim('"'));
					}
				}
			}
			streamReader.Close();
			streamReader.Dispose();
		}

		public bool imethod_18()
		{
			return Dictionary0 == null;
		}

		public void imethod_19()
		{
			Dictionary0 = null;
		}

		public T imethod_20<T>(T gparam0) where T : INterface12
		{
			gparam0.imethod_1(_int0);
			gparam0.imethod_3(_int1);
			gparam0.imethod_5(_int2);
			gparam0.imethod_8(_int3);
			gparam0.imethod_11(_int4);
			gparam0.imethod_13(_int5);
			gparam0.imethod_15(_enum350);
			if (!imethod_18())
			{
				gparam0.imethod_17(imethod_16());
			}
			else
			{
				gparam0.imethod_19();
			}
			return gparam0;
		}

		public void Dispose()
		{
			imethod_19();
		}

		public override object Clone()
		{
			var @class = (Class328)base.Clone();
			@class.imethod_1(_int0);
			@class.imethod_3(_int1);
			@class.imethod_5(_int2);
			@class.imethod_8(_int3);
			@class.imethod_11(_int4);
			@class.imethod_13(_int5);
			@class.imethod_15(_enum350);
			if (imethod_18())
			{
				@class.imethod_19();
			}
			return @class;
		}
	}
}
