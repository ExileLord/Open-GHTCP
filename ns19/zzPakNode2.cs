using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ns16;
using ns20;
using ns21;

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
			class317_0 = new zzPakNode1(true);
			list_0 = new List<Interface12>();
			dictionary_0 = new Dictionary<int, int[]>();
			bool_1 = true;
			bool_2 = true;
			bool_4 = true;
			//base..ctor("PakFile");
			bool_2 = bool_5;
			bool_1 = bool_6;
			int_0 = int_1;
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		public zzPakNode2(string string_2, bool bool_5) : this(string_2, null, bool_5)
		{
		}

		public zzPakNode2(string string_2, string string_3, bool bool_5)
		{
			class317_0 = new zzPakNode1(true);
			list_0 = new List<Interface12>();
			dictionary_0 = new Dictionary<int, int[]>();
			bool_1 = true;
			bool_2 = true;
			bool_4 = true;
			//base..ctor();
			Text = KeyGenerator.GetFileName(string_2);
			string_0 = string_2;
			string_1 = string_3;
			bool_4 = bool_5;
			if (File.Exists(string_2))
			{
				method_4();
			}
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		private void method_4()
		{
			if (stream26_0 == null)
			{
				stream26_0 = new Stream26(File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read));
			}
			class318_0 = ((string_1 != null) ? new zzPakNode2(string_1, false) : this);
			if (stream26_0.Length == 0L)
			{
				throw new Exception("Pak File is empty!");
			}
			var num = 0;
			var num2 = stream26_0.ReadInt();
			stream26_0._reverseEndianness = (bool_2 = (!QbSongClass1.ContainsKey(num2) || !QbSongClass1.GetDictString(num2).StartsWith(".")));
			var @enum = (Enum35)stream26_0.ReadIntAt(28);
			bool_1 = ((@enum & Enum35.flag_3) == Enum35.flag_0);
			int_0 = stream26_0.ReadIntAt(bool_1 ? 12 : 16, bool_2 && (@enum & Enum35.flag_4) == Enum35.flag_0 && (@enum & Enum35.flag_5) == Enum35.flag_0);
			if (bool_4 && string_0 != null)
			{
				var text = KeyGenerator.GetFileName(string_0);
				if (text.Contains("_song"))
				{
					QbSongClass1.GenerateSongTrackStuff(text.Substring(0, text.LastIndexOf("_song.pak")).ToLower());
				}
				else if (!bool_1)
				{
					QbSongClass1.GenerateSongTrackStuff(text.Substring(0, text.LastIndexOf(".pak")).ToLower());
				}
			}
			while (true)
			{
				var enum2 = (Enum35)stream26_0.ReadIntAt(num + 28);
				var flag = bool_2 && (enum2 & Enum35.flag_4) == Enum35.flag_0 && (enum2 & Enum35.flag_5) == Enum35.flag_0;
				var int_ = stream26_0.ReadIntAt(num, flag);
				if (QbSongClass1.ContainsKey(int_))
				{
					if (QbSongClass1.GetDictString(int_).Equals(".last"))
					{
						return;
					}
					if (QbSongClass1.GetDictString(int_).Equals("last"))
					{
						break;
					}
				}
				var int_2 = stream26_0.ReadInt(flag) + num;
				var int_3 = stream26_0.ReadInt(flag);
				var num3 = stream26_0.ReadIntAt(num + (bool_1 ? 16 : 12), flag);
				var num4 = stream26_0.ReadIntAt(num + 20, flag);
				var int_4 = stream26_0.ReadInt(flag);
				stream26_0.Position += 4L;
				if ((enum2 & Enum35.flag_3) != Enum35.flag_0)
				{
					bool_1 = false;
					var text2 = stream26_0.ReadString(160);
					var num5 = text2.IndexOf('\0');
					if (num5 >= 0)
					{
						text2 = text2.Substring(0, num5);
					}
					if (QbSongClass1.ContainsKey(int_) && !QbSongClass1.GetDictString(int_).EndsWith(".qb.ngc") && !QbSongClass1.GetDictString(int_).EndsWith(".qb.ps2"))
					{
						if (!bool_2)
						{
							if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ps2", ""), true))
							{
								QbSongClass1.AddKeyToDictionary(text2);
							}
							else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""), true))
							{
								QbSongClass1.AddKeyToDictionary(text2);
							}
						}
						else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ngc", ""), true))
						{
							QbSongClass1.AddKeyToDictionary(text2);
						}
						else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""), true))
						{
							QbSongClass1.AddKeyToDictionary(text2);
						}
					}
					else
					{
						var text3 = "abcdefghijklmnopqrstuvwxyz";
						for (var i = 0; i < text3.Length; i++)
						{
							var c = text3[i];
							if (num3 == KeyGenerator.GetQbKey(c + text2, true))
							{
								QbSongClass1.AddKeyToDictionary(c + text2);
							}
						}
					}
					if (num4 == KeyGenerator.GetQbKey(text2 = KeyGenerator.GetFileNameNoExt(text2), true))
					{
						QbSongClass1.AddKeyToDictionary(text2);
					}
				}
				TreeNode treeNode;
				if (QbSongClass1.ContainsKey(int_) && QbSongClass1.GetDictString(int_).Contains("qb"))
				{
					treeNode = new Class309(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				else if (QbSongClass1.ContainsKey(int_) && QbSongClass1.GetDictString(int_).Contains("qs"))
				{
					treeNode = new Class328(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				else
				{
					treeNode = new zzCocoaNode12(int_, int_2, int_3, num3, num4, int_4, enum2);
				}
				if (bool_4)
				{
					if (QbSongClass1.ContainsKey(num3))
					{
						method_1(QbSongClass1.GetDictString(num3), treeNode);
					}
					else
					{
						method_5(num3, (Interface12)treeNode);
					}
				}
				else
				{
					list_0.Add((Interface12)treeNode);
				}
				num += (((enum2 & Enum35.flag_3) != Enum35.flag_0) ? 192 : 32);
			}
		}

		public void method_5(int int_1, Interface12 interface12_0)
		{
			class317_0.Nodes.Add((TreeNode)interface12_0);
			if (!Nodes.Contains(class317_0))
			{
				Nodes.Add(class317_0);
			}
			var @interface = method_11(int_1);
			if (@interface == null)
			{
				list_0.Add(interface12_0);
				return;
			}
			list_0[list_0.IndexOf(@interface)] = interface12_0;
		}

		public override string vmethod_0()
		{
			return "";
		}

		public bool method_6(string string_2)
		{
			return method_10(string_2) != null;
		}

		public bool method_7(string string_2)
		{
			var @interface = method_10(string_2);
			((TreeNode)@interface).Remove();
			return @interface != null && list_0.Remove(@interface);
		}

		public Class309 zzGetNode1(string string_2)
		{
			var @interface = method_10(string_2);
			if (@interface == null)
			{
				return null;
			}
			if (@interface is Class309)
			{
				return (Class309)method_15(@interface);
			}
			var @class = @interface.imethod_20(new Class309());
			if (bool_4)
			{
				((TreeNode)@interface).Remove();
				method_1(string_2, @class);
			}
			else
			{
				list_0[list_0.IndexOf(@interface)] = @class;
			}
			return method_15(@class);
		}

		public Class328 method_9(string string_2)
		{
			var @interface = method_10(string_2);
			if (@interface == null)
			{
				return null;
			}
			if (@interface is Class328)
			{
				return (Class328)method_15(@interface);
			}
			var @class = @interface.imethod_20(new Class328());
			if (bool_4)
			{
				((TreeNode)@interface).Remove();
				method_1(string_2, @class);
			}
			else
			{
				list_0[list_0.IndexOf(@interface)] = @class;
			}
			return method_15(@class);
		}

		public Interface12 method_10(string string_2)
		{
			return method_11(QbSongClass1.AddKeyToDictionary(string_2));
		}

		public Interface12 method_11(int int_1)
		{
			foreach (var current in list_0)
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
			return method_14(method_10(string_2));
		}

		public byte[] method_13(int int_1)
		{
			return method_14(method_11(int_1));
		}

		public byte[] method_14(Interface12 interface12_0)
		{
			if (interface12_0 == null)
			{
				return null;
			}
			if (interface12_0.imethod_18())
			{
				return stream26_0.ReadBytesAt(interface12_0.imethod_0(), interface12_0.imethod_2(), false);
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
				gparam_0.imethod_17(stream26_0.ReadBytesAt(gparam_0.imethod_0(), gparam_0.imethod_2(), false));
			}
			return gparam_0;
		}

		public virtual void vmethod_1()
		{
			if (stream26_0 == null)
			{
				throw new IOException("Pak File was never parsed");
			}
			method_16(string_0);
		}

		public void method_16(string string_2)
		{
			var stream = method_17();
			if (stream26_0 != null && string_0 == string_2)
			{
				stream26_0.Close();
			}
			KeyGenerator.WriteAllBytes(string_2, stream.ReadEverything());
			stream.Dispose();
			if (stream26_0 != null && string_0 == string_2)
			{
				if (class318_0 != null && class318_0 != this)
				{
					class318_0.vmethod_1();
				}
				Dispose();
				method_4();
				GC.Collect();
			}
		}

		public Stream26 method_17()
		{
			var stream = new Stream26(bool_2);
			var stream2 = new Stream26();
			method_18(stream, stream2);
			stream.WriteByteArray(stream2.ReadEverything(), false);
			stream2.Dispose();
			return stream;
		}

		private static int smethod_0(long long_0, int int_1)
		{
			var num = 1 << int_1;
			var num2 = num - 1;
			return (int)(num - (long_0 & num2) & num2);
		}

		public void method_18(Stream26 stream26_1, Stream26 stream26_2)
		{
			var num = 0;
			foreach (var current in list_0)
			{
				num += (((current.imethod_14() & Enum35.flag_3) == Enum35.flag_0 || !QbSongClass1.ContainsKey(current.imethod_7())) ? 32 : 192);
			}
			if (bool_1)
			{
				num = (num + 32 + 4095 & -4096);
			}
			else
			{
				num += (bool_2 ? 64 : 48);
			}
			var num2 = 0;
			var list = new List<Interface12>();
			foreach (var current2 in list_0)
			{
				if (current2 is Class309 && (current2 as Class309).vmethod_8())
				{
					var string_ = current2.imethod_9().Replace(".qb", ".qs");
					if (!class318_0.method_6(string_))
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
						var @interface = class318_0.method_10(string_);
						if (@interface.imethod_18() || ((Class328)@interface).dictionary_0 != (current2 as Class309).vmethod_10())
						{
							((Class328)@interface).dictionary_0 = (current2 as Class309).vmethod_10();
						}
					}
				}
			}
			if (list.Count != 0)
			{
				class318_0.list_0.AddRange(list);
			}
			int num4;
			foreach (var current3 in list_0)
			{
				var flag = bool_2 && (current3.imethod_14() & Enum35.flag_4) == Enum35.flag_0 && (current3.imethod_14() & Enum35.flag_5) == Enum35.flag_0;
				var num3 = current3.imethod_7();
				if (current3.imethod_4() != 0)
				{
					stream26_1.WriteInt(current3.imethod_4(), flag);
				}
				else
				{
					var text = QbSongClass1.GetDictString(num3);
					if (!bool_1 && !text.EndsWith(".qb.ngc") && !text.EndsWith(".qb.ps2"))
					{
						stream26_1.WriteInt(1270999134, flag);
					}
					else if (text.Contains(".qb"))
					{
						stream26_1.WriteUInt(2817852868u, flag);
					}
					else
					{
						stream26_1.WriteInt(1952304453, flag);
					}
				}
				if (this is zzPabNode && bool_3)
				{
					stream26_1.WriteInt((int)stream26_2.Length, flag);
				}
				else
				{
					stream26_1.WriteInt(num - num2 + (int)stream26_2.Length, flag);
				}
				stream26_1.WriteInt(current3.imethod_2(), flag);
				if (bool_1)
				{
					stream26_1.WriteInt(int_0, flag);
				}
				stream26_1.WriteInt(num3, flag);
				if (!bool_1)
				{
					stream26_1.WriteInt(int_0, flag);
				}
				stream26_1.WriteInt(current3.imethod_10(), flag);
				stream26_1.WriteInt(current3.imethod_12(), flag);
				stream26_1.WriteInt((int)current3.imethod_14(), false);
				var flag2 = false;
				if ((current3.imethod_14() & Enum35.flag_3) != Enum35.flag_0 && QbSongClass1.ContainsKey(num3))
				{
					flag2 = true;
					var text2 = QbSongClass1.GetDictString(num3);
					if (!current3.imethod_6().EndsWith(".qb.ngc") && !current3.imethod_6().EndsWith(".qb.ps2"))
					{
						if (bool_1)
						{
							text2 = text2.Replace("\\", "/");
						}
						else if (!bool_2)
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
					stream26_1.WriteString(text2);
					stream26_1.WriteNBytes(0, 160 - text2.Length);
				}
				stream26_2.WriteByteArray(method_14(current3));
				num4 = ((bool_2 || bool_1) ? smethod_0(stream26_2.Length, 5) : smethod_0(stream26_2.Length, 4));
				stream26_2.WriteNBytes(0, num4);
				num2 += (flag2 ? 192 : 32);
			}
			stream26_1.WriteUInt(bool_1 ? 749989691u : 3039057503u);
			if (this is zzPabNode && bool_3)
			{
				stream26_1.WriteInt((int)stream26_2.Length);
			}
			else
			{
				stream26_1.WriteInt(num - num2 + (int)stream26_2.Length);
			}
			stream26_1.WriteInt(4);
			if (bool_1)
			{
				stream26_1.WriteInt(int_0);
				stream26_1.WriteUInt(2306521930u);
				stream26_1.WriteInt(1794739921);
				stream26_1.WriteNBytes(0, 8);
			}
			else
			{
				stream26_1.WriteNBytes(0, 4);
				stream26_1.WriteInt(int_0);
				stream26_1.WriteNBytes(0, 12);
			}
			num4 = (bool_1 ? smethod_0(stream26_1.Length, 12) : (bool_2 ? 32 : 16));
			stream26_1.WriteNBytes(0, num4);
			stream26_2.WriteNBytes(171, 4);
			stream26_2.WriteNBytes(0, 12);
			num4 = (bool_1 ? smethod_0(stream26_2.Length, 12) : ((int)stream26_2.Length % (bool_2 ? 32 : 16)));
			stream26_2.WriteNBytes(171, num4);
		}

		public IEnumerator<Interface12> GetEnumerator()
		{
			return list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list_0.GetEnumerator();
		}

		public void Dispose()
		{
			if (stream26_0 != null)
			{
				stream26_0.Close();
				stream26_0.Dispose();
				stream26_0 = null;
			}
			class317_0.Nodes.Clear();
			list_0.Clear();
			Nodes.Clear();
			dictionary_0.Clear();
			if (class318_0 != null && class318_0 != this)
			{
				class318_0.Dispose();
			}
		}
	}
}
