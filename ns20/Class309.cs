using System;
using System.Windows.Forms;
using ns16;
using ns18;
using ns19;

namespace ns20
{
	public class Class309 : zzGenericNode1, IDisposable, Interface12
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private Enum35 enum35_0;

		private bool bool_3;

		public Class309() : this("newfile.qb")
		{
		}

		public Class309(string string_0)
		{
			Text = KeyGenerator.GetFileName(string_0);
			int_2 = QbSongClass1.AddKeyToDictionary(string_0.Substring(string_0.LastIndexOf('.')));
			int_3 = QbSongClass1.AddKeyToDictionary(string_0);
			int_4 = QbSongClass1.AddKeyToDictionary(KeyGenerator.GetFileNameNoExt(string_0));
			ImageIndex = 40;
			SelectedImageIndex = 40;
			bool_3 = true;
		}

		public Class309(string string_0, zzGenericNode1 class308_0) : this(string_0)
		{
			foreach (AbstractTreeNode1 node in class308_0.Nodes)
			{
				Nodes.Add(node);
			}
		}

		public Class309(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Enum35 enum35_1)
		{
			Text = (QbSongClass1.ContainsKey(int_9) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(int_9)) : ("0x" + KeyGenerator.ValToHex32bit(int_9)));
			int_2 = int_6;
			int_0 = int_7;
			int_1 = int_8;
			int_3 = int_9;
			int_4 = int_10;
			int_5 = int_11;
			enum35_0 = enum35_1;
			ImageIndex = 40;
			SelectedImageIndex = 40;
			bool_3 = false;
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
			if (!imethod_18())
			{
				return method_11();
			}
			return int_1;
		}

		public void imethod_3(int int_6)
		{
			int_1 = int_6;
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
			return method_7();
		}

		public void imethod_17(byte[] byte_1)
		{
			Stream26 stream26_ = new Stream26(byte_1);
			zzGenericNode1 @class;
			if (Parent != null && Parent is zzPakNode1 && !(Parent as zzPakNode1).bool_0)
			{
				TreeNode treeNode = this;
				int level = treeNode.Level;
				while (level-- != 0)
				{
					treeNode = treeNode.Parent;
				}
				if (treeNode is zzPakNode2 && (treeNode as zzPakNode2).class318_0 != null)
				{
					string string_ = imethod_9().Contains(".qb") ? imethod_9().Replace(".qb", ".qs") : (imethod_9() + ".qs");
					if ((treeNode as zzPakNode2).class318_0.method_6(string_))
					{
						@class = new zzGenericNode1("TempFile", stream26_, (treeNode as zzPakNode2).class318_0.method_9(string_).dictionary_0);
					}
					else
					{
						@class = new zzGenericNode1("TempFile", stream26_);
					}
				}
				else
				{
					@class = new zzGenericNode1("TempFile", stream26_);
				}
			}
			else
			{
				@class = new zzGenericNode1("TempFile", stream26_);
			}
			Nodes.Clear();
			foreach (AbstractTreeNode1 node in @class.Nodes)
			{
				Nodes.Add(node);
			}
			bool flag;
			vmethod_9(flag = @class.vmethod_8());
			if (flag)
			{
				vmethod_11(@class.vmethod_10());
			}
			bool_1 = @class.vmethod_7();
			bool_3 = true;
		}

		public bool imethod_18()
		{
			return !bool_3 && Nodes.Count == 0;
		}

		public void imethod_19()
		{
			Nodes.Clear();
			bool_3 = false;
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
			Interface12 @interface = (Interface12)base.Clone();
			@interface.imethod_1(int_0);
			@interface.imethod_3(int_1);
			@interface.imethod_5(int_2);
			@interface.imethod_8(int_3);
			@interface.imethod_11(int_4);
			@interface.imethod_13(int_5);
			@interface.imethod_15(enum35_0);
			if (imethod_18())
			{
				@interface.imethod_19();
			}
			return @interface;
		}
	}
}
