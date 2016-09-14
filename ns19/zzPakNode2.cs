using ns16;
using ns20;
using ns21;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ns19
{
	public class zzPakNode2 : zzPakNode1, IEnumerable, IDisposable, IEnumerable<Interface12>
	{
		public string string_0;

		public string string_1;

		public zzPakNode1 class317_0;  //Parent?

		public List<Interface12> list_0;

		public zzPakNode2 class318_0; //Linked List?..

		public Dictionary<int, int[]> dictionary_0;

		public bool bool_1;

		public bool bool_2;

		public bool bool_3;

		public int int_0;

		public Stream26 stream26_0;

		public bool bool_4;

		public zzPakNode2() : this(true)
		{
		}

		public zzPakNode2(bool bool_5) : this(bool_5, true, 0)
		{
		}

		public zzPakNode2(bool bool_5, bool bool_6, int int_1) : base("PakFile")
		{
			this.class317_0 = new zzPakNode1(true);
			this.list_0 = new List<Interface12>();
			this.dictionary_0 = new Dictionary<int, int[]>();
			this.bool_1 = true;
			this.bool_2 = true;
			this.bool_4 = true;
			//base..ctor("PakFile");
			this.bool_2 = bool_5;
			this.bool_1 = bool_6;
			this.int_0 = int_1;
			base.ImageIndex = 37;
			base.SelectedImageIndex = 37;
		}

		public zzPakNode2(string string_2, bool bool_5) : this(string_2, null, bool_5)
		{
		}

		public zzPakNode2(string string_2, string string_3, bool bool_5) : base()
		{
			this.class317_0 = new zzPakNode1(true);
			this.list_0 = new List<Interface12>();
			this.dictionary_0 = new Dictionary<int, int[]>();
			this.bool_1 = true;
			this.bool_2 = true;
			this.bool_4 = true;
			//base..ctor();
			base.Text = KeyGenerator.GetFileName(string_2);
			this.string_0 = string_2;
			this.string_1 = string_3;
			this.bool_4 = bool_5;
			if (File.Exists(string_2))
			{
				this.method_4();
			}
			base.ImageIndex = 37;
			base.SelectedImageIndex = 37;
		}

		private void method_4()
		{
			if (this.stream26_0 == null)
			{
				this.stream26_0 = new Stream26(File.Open(this.string_0, FileMode.Open, FileAccess.Read, FileShare.Read));
			}
			this.class318_0 = ((this.string_1 != null) ? new zzPakNode2(this.string_1, false) : this);
			if (this.stream26_0.Length == 0L)
			{
				throw new Exception("Pak File is empty!");
			}
			int num = 0;
			int num2 = this.stream26_0.method_19();
			this.stream26_0.bool_0 = (this.bool_2 = (!QbSongClass1.smethod_3(num2) || !QbSongClass1.smethod_5(num2).StartsWith(".")));
			Enum35 @enum = (Enum35)this.stream26_0.method_41(28);
			this.bool_1 = ((@enum & Enum35.flag_3) == Enum35.flag_0);
			this.int_0 = this.stream26_0.method_42(this.bool_1 ? 12 : 16, this.bool_2 && (@enum & Enum35.flag_4) == Enum35.flag_0 && (@enum & Enum35.flag_5) == Enum35.flag_0);
			if (this.bool_4 && this.string_0 != null)
			{
				string text = KeyGenerator.GetFileName(this.string_0);
				if (text.Contains("_song"))
				{
					QbSongClass1.smethod_10(text.Substring(0, text.LastIndexOf("_song.pak")).ToLower());
				}
				else if (!this.bool_1)
				{
					QbSongClass1.smethod_10(text.Substring(0, text.LastIndexOf(".pak")).ToLower());
				}
			}
			while (true)
			{
				Enum35 enum2 = (Enum35)this.stream26_0.method_41(num + 28);
				bool flag = this.bool_2 && (enum2 & Enum35.flag_4) == Enum35.flag_0 && (enum2 & Enum35.flag_5) == Enum35.flag_0;
				int int_ = this.stream26_0.method_42(num, flag);
				if (QbSongClass1.smethod_3(int_))
				{
					if (QbSongClass1.smethod_5(int_).Equals(".last"))
					{
						return;
					}
					if (QbSongClass1.smethod_5(int_).Equals("last"))
					{
						break;
					}
				}
				int int_2 = this.stream26_0.method_20(flag) + num;
				int int_3 = this.stream26_0.method_20(flag);
				int num3 = this.stream26_0.method_42(num + (this.bool_1 ? 16 : 12), flag);
				int num4 = this.stream26_0.method_42(num + 20, flag);
				int int_4 = this.stream26_0.method_20(flag);
				this.stream26_0.Position += 4L;
				if ((enum2 & Enum35.flag_3) != Enum35.flag_0)
				{
					this.bool_1 = false;
					string text2 = this.stream26_0.method_28(160);
					int num5 = text2.IndexOf('\0');
					if (num5 >= 0)
					{
						text2 = text2.Substring(0, num5);
					}
					if (QbSongClass1.smethod_3(int_) && !QbSongClass1.smethod_5(int_).EndsWith(".qb.ngc") && !QbSongClass1.smethod_5(int_).EndsWith(".qb.ps2"))
					{
						if (!this.bool_2)
						{
							if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ps2", ""), true))
							{
								QbSongClass1.smethod_9(text2);
							}
							else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""), true))
							{
								QbSongClass1.smethod_9(text2);
							}
						}
						else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ngc", ""), true))
						{
							QbSongClass1.smethod_9(text2);
						}
						else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""), true))
						{
							QbSongClass1.smethod_9(text2);
						}
					}
					else
					{
						string text3 = "abcdefghijklmnopqrstuvwxyz";
						for (int i = 0; i < text3.Length; i++)
						{
							char c = text3[i];
							if (num3 == KeyGenerator.GetQbKey(c + text2, true))
							{
								QbSongClass1.smethod_9(c + text2);
							}
						}
					}
					if (num4 == KeyGenerator.GetQbKey(text2 = KeyGenerator.GetFileNameNoExt(text2), true))
					{
						QbSongClass1.smethod_9(text2);
					}
				}
				TreeNode treeNode;
				if (QbSongClass1.smethod_3(int_) && QbSongClass1.smethod_5(int_).Contains("qb"))
				{
					treeNode = new Class309(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				else if (QbSongClass1.smethod_3(int_) && QbSongClass1.smethod_5(int_).Contains("qs"))
				{
					treeNode = new Class328(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				else
				{
					treeNode = new zzCocoaNode12(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				if (this.bool_4)
				{
					if (QbSongClass1.smethod_3(num3))
					{
						base.method_1<TreeNode>(QbSongClass1.smethod_5(num3), treeNode);
					}
					else
					{
						this.method_5(num3, (Interface12)treeNode);
					}
				}
				else
				{
					this.list_0.Add((Interface12)treeNode);
				}
				num += (((enum2 & Enum35.flag_3) != Enum35.flag_0) ? 192 : 32);
			}
		}

		public void method_5(int int_1, Interface12 interface12_0)
		{
			this.class317_0.Nodes.Add((TreeNode)interface12_0);
			if (!base.Nodes.Contains(this.class317_0))
			{
				base.Nodes.Add(this.class317_0);
			}
			Interface12 @interface = this.method_11(int_1);
			if (@interface == null)
			{
				this.list_0.Add(interface12_0);
				return;
			}
			this.list_0[this.list_0.IndexOf(@interface)] = interface12_0;
		}

		public override string vmethod_0()
		{
			return "";
		}

		public bool method_6(string string_2)
		{
			return this.method_10(string_2) != null;
		}

		public bool method_7(string string_2)
		{
			Interface12 @interface = this.method_10(string_2);
			((TreeNode)@interface).Remove();
			return @interface != null && this.list_0.Remove(@interface);
		}

		public Class309 method_8(string string_2)
		{
			Interface12 @interface = this.method_10(string_2);
			if (@interface == null)
			{
				return null;
			}
			if (@interface is Class309)
			{
				return (Class309)this.method_15<Interface12>(@interface);
			}
			Class309 @class = @interface.imethod_20<Class309>(new Class309());
			if (this.bool_4)
			{
				((TreeNode)@interface).Remove();
				base.method_1<Class309>(string_2, @class);
			}
			else
			{
				this.list_0[this.list_0.IndexOf(@interface)] = @class;
			}
			return this.method_15<Class309>(@class);
		}

		public Class328 method_9(string string_2)
		{
			Interface12 @interface = this.method_10(string_2);
			if (@interface == null)
			{
				return null;
			}
			if (@interface is Class328)
			{
				return (Class328)this.method_15<Interface12>(@interface);
			}
			Class328 @class = @interface.imethod_20<Class328>(new Class328());
			if (this.bool_4)
			{
				((TreeNode)@interface).Remove();
				base.method_1<Class328>(string_2, @class);
			}
			else
			{
				this.list_0[this.list_0.IndexOf(@interface)] = @class;
			}
			return this.method_15<Class328>(@class);
		}

		public Interface12 method_10(string string_2)
		{
			return this.method_11(QbSongClass1.smethod_9(string_2));
		}

		public Interface12 method_11(int int_1)
		{
			foreach (Interface12 current in this.list_0)
			{
				if (current.imethod_7() == int_1)
				{
					return current;
				}
			}
			return null;
		}

		public byte[] method_12(string string_2)
		{
			return this.method_14(this.method_10(string_2));
		}

		public byte[] method_13(int int_1)
		{
			return this.method_14(this.method_11(int_1));
		}

		public byte[] method_14(Interface12 interface12_0)
		{
			if (interface12_0 == null)
			{
				return null;
			}
			if (interface12_0.imethod_18())
			{
				return this.stream26_0.method_47(interface12_0.imethod_0(), interface12_0.imethod_2(), false);
			}
			return interface12_0.imethod_16();
		}

		public T method_15<T>(T gparam_0) where T : class, Interface12
		{
			if (gparam_0 == null)
			{
				return default(T);
			}
			if (gparam_0.imethod_18())
			{
				gparam_0.imethod_17(this.stream26_0.method_47(gparam_0.imethod_0(), gparam_0.imethod_2(), false));
			}
			return gparam_0;
		}

		public virtual void vmethod_1()
		{
			if (this.stream26_0 == null)
			{
				throw new IOException("Pak File was never parsed");
			}
			this.method_16(this.string_0);
		}

		public void method_16(string string_2)
		{
			Stream26 stream = this.method_17();
			if (this.stream26_0 != null && this.string_0 == string_2)
			{
				this.stream26_0.Close();
			}
			KeyGenerator.smethod_9(string_2, stream.method_1());
			stream.Dispose();
			if (this.stream26_0 != null && this.string_0 == string_2)
			{
				if (this.class318_0 != null && this.class318_0 != this)
				{
					this.class318_0.vmethod_1();
				}
				this.Dispose();
				this.method_4();
				GC.Collect();
			}
		}

		public Stream26 method_17()
		{
			Stream26 stream = new Stream26(this.bool_2);
			Stream26 stream2 = new Stream26();
			this.method_18(stream, stream2);
			stream.method_16(stream2.method_1(), false);
			stream2.Dispose();
			return stream;
		}

		private static int smethod_0(long long_0, int int_1)
		{
			int num = 1 << int_1;
			int num2 = num - 1;
			return (int)((long)num - (long_0 & (long)num2) & (long)num2);
		}

		public void method_18(Stream26 stream26_1, Stream26 stream26_2)
		{
			int num = 0;
			foreach (Interface12 current in this.list_0)
			{
				num += (((current.imethod_14() & Enum35.flag_3) == Enum35.flag_0 || !QbSongClass1.smethod_3(current.imethod_7())) ? 32 : 192);
			}
			if (this.bool_1)
			{
				num = (num + 32 + 4095 & -4096);
			}
			else
			{
				num += (this.bool_2 ? 64 : 48);
			}
			int num2 = 0;
			List<Interface12> list = new List<Interface12>();
			foreach (Interface12 current2 in this.list_0)
			{
				if (current2 is Class309 && (current2 as Class309).vmethod_8())
				{
					string string_ = current2.imethod_9().Replace(".qb", ".qs");
					if (!this.class318_0.method_6(string_))
					{
						if (!current2.imethod_18())
						{
							list.Add(new Class328(string_, (current2 as Class309).vmethod_10()));
						}
						else
						{
							list.Add(new Class328(string_));
						}
					}
					else
					{
						Interface12 @interface = this.class318_0.method_10(string_);
						if (@interface.imethod_18() || ((Class328)@interface).dictionary_0 != (current2 as Class309).vmethod_10())
						{
							((Class328)@interface).dictionary_0 = (current2 as Class309).vmethod_10();
						}
					}
				}
			}
			if (list.Count != 0)
			{
				this.class318_0.list_0.AddRange(list);
			}
			int num4;
			foreach (Interface12 current3 in this.list_0)
			{
				bool flag = this.bool_2 && (current3.imethod_14() & Enum35.flag_4) == Enum35.flag_0 && (current3.imethod_14() & Enum35.flag_5) == Enum35.flag_0;
				int num3 = current3.imethod_7();
				if (current3.imethod_4() != 0)
				{
					stream26_1.method_6(current3.imethod_4(), flag);
				}
				else
				{
					string text = QbSongClass1.smethod_5(num3);
					if (!this.bool_1 && !text.EndsWith(".qb.ngc") && !text.EndsWith(".qb.ps2"))
					{
						stream26_1.method_6(1270999134, flag);
					}
					else if (text.Contains(".qb"))
					{
						stream26_1.method_8(2817852868u, flag);
					}
					else
					{
						stream26_1.method_6(1952304453, flag);
					}
				}
				if (this is zzPabNode && this.bool_3)
				{
					stream26_1.method_6((int)stream26_2.Length, flag);
				}
				else
				{
					stream26_1.method_6(num - num2 + (int)stream26_2.Length, flag);
				}
				stream26_1.method_6(current3.imethod_2(), flag);
				if (this.bool_1)
				{
					stream26_1.method_6(this.int_0, flag);
				}
				stream26_1.method_6(num3, flag);
				if (!this.bool_1)
				{
					stream26_1.method_6(this.int_0, flag);
				}
				stream26_1.method_6(current3.imethod_10(), flag);
				stream26_1.method_6(current3.imethod_12(), flag);
				stream26_1.method_6((int)current3.imethod_14(), false);
				bool flag2 = false;
				if ((current3.imethod_14() & Enum35.flag_3) != Enum35.flag_0 && QbSongClass1.smethod_3(num3))
				{
					flag2 = true;
					string text2 = QbSongClass1.smethod_5(num3);
					if (!current3.imethod_6().EndsWith(".qb.ngc") && !current3.imethod_6().EndsWith(".qb.ps2"))
					{
						if (this.bool_1)
						{
							text2 = text2.Replace("\\", "/");
						}
						else if (!this.bool_2)
						{
							text2 = text2.Replace("\\", "/") + (current3.imethod_6().EndsWith(".qb") ? "" : ".qb") + ".ps2";
						}
						else
						{
							text2 = text2.Replace("\\", "/") + (current3.imethod_6().EndsWith(".qb") ? "" : ".qb") + ".ngc";
						}
					}
					else
					{
						text2 = text2.Substring(1);
					}
					stream26_1.method_13(text2);
					stream26_1.method_4(0, 160 - text2.Length);
				}
				stream26_2.method_15(this.method_14(current3));
				num4 = ((this.bool_2 || this.bool_1) ? zzPakNode2.smethod_0(stream26_2.Length, 5) : zzPakNode2.smethod_0(stream26_2.Length, 4));
				stream26_2.method_4(0, num4);
				num2 += (flag2 ? 192 : 32);
			}
			stream26_1.method_7(this.bool_1 ? 749989691u : 3039057503u);
			if (this is zzPabNode && this.bool_3)
			{
				stream26_1.method_5((int)stream26_2.Length);
			}
			else
			{
				stream26_1.method_5(num - num2 + (int)stream26_2.Length);
			}
			stream26_1.method_5(4);
			if (this.bool_1)
			{
				stream26_1.method_5(this.int_0);
				stream26_1.method_7(2306521930u);
				stream26_1.method_5(1794739921);
				stream26_1.method_4(0, 8);
			}
			else
			{
				stream26_1.method_4(0, 4);
				stream26_1.method_5(this.int_0);
				stream26_1.method_4(0, 12);
			}
			num4 = (this.bool_1 ? zzPakNode2.smethod_0(stream26_1.Length, 12) : (this.bool_2 ? 32 : 16));
			stream26_1.method_4(0, num4);
			stream26_2.method_4(171, 4);
			stream26_2.method_4(0, 12);
			num4 = (this.bool_1 ? zzPakNode2.smethod_0(stream26_2.Length, 12) : ((int)stream26_2.Length % (this.bool_2 ? 32 : 16)));
			stream26_2.method_4(171, num4);
		}

		public IEnumerator<Interface12> GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}

		public void Dispose()
		{
			if (this.stream26_0 != null)
			{
				this.stream26_0.Close();
				this.stream26_0.Dispose();
				this.stream26_0 = null;
			}
			this.class317_0.Nodes.Clear();
			this.list_0.Clear();
			base.Nodes.Clear();
			this.dictionary_0.Clear();
			if (this.class318_0 != null && this.class318_0 != this)
			{
				this.class318_0.Dispose();
			}
		}
	}
}
