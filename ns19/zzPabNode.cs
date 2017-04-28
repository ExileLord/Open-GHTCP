using System;
using System.IO;
using System.Windows.Forms;
using ns16;
using ns20;
using ns21;

namespace ns19
{
	public class ZzPabNode : ZzPakNode2
	{
		public string String2;

		public ZzPabNode() : this(true)
		{
		}

		public ZzPabNode(bool bool5) : this(bool5, true, 0)
		{
		}

		public ZzPabNode(bool bool5, bool bool6, int int1)
		{
			Text = "PabFile";
			Bool2 = bool5;
			Bool1 = bool6;
			Int0 = int1;
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		public ZzPabNode(string string3, string string4, bool bool5) : this(string3, string4, null, bool5)
		{
		}

		public ZzPabNode(string string3, string string4, string string5, bool bool5)
		{
			Text = KeyGenerator.GetFileName(string3);
			String0 = string3;
			String2 = string4;
			String1 = string5;
			Bool4 = bool5;
			if (File.Exists(string3) && File.Exists(string4))
			{
				method_19();
			}
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		private void method_19()
		{
			if (String1 != null)
			{
				Class3180 = new ZzPakNode2(String1, false);
			}
			using (var stream = new Stream26(File.Open(String0, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				var num = 0;
				var num2 = (int)stream.Length;
				if (num2 == 0)
				{
					throw new Exception("Pak File is empty!");
				}
				var int_ = stream.ReadInt();
				stream.ReverseEndianness = (Bool2 = (!QbSongClass1.ContainsKey(int_) || !QbSongClass1.GetDictString(int_).StartsWith(".")));
				Bool3 = (stream.ReadInt() < stream.Length);
				var @enum = (Enum35)stream.ReadIntAt(28);
				Bool1 = ((@enum & Enum35.Flag3) == Enum35.Flag0);
				Int0 = stream.ReadIntAt(Bool1 ? 12 : 16, Bool2 && (@enum & Enum35.Flag4) == Enum35.Flag0 && (@enum & Enum35.Flag5) == Enum35.Flag0);
				while (true)
				{
					var enum2 = (Enum35)stream.ReadIntAt(num + 28, false);
					var bool_ = Bool2 && (enum2 & Enum35.Flag4) == Enum35.Flag0 && (enum2 & Enum35.Flag5) == Enum35.Flag0;
					var num3 = stream.ReadIntAt(num, bool_);
					if (QbSongClass1.ContainsKey(num3) && (QbSongClass1.GetDictString(num3).Equals(".last") || QbSongClass1.GetDictString(num3).Equals("last")))
					{
						break;
					}
					var num4 = stream.ReadInt(bool_);
					if (!Bool3)
					{
						num4 = num4 - num2 + num;
					}
					if (num4 < 0)
					{
						num4 = 0;
					}
					var int2 = stream.ReadInt(bool_);
					var num5 = stream.ReadIntAt(num + (Bool1 ? 16 : 12), bool_);
					var num6 = stream.ReadIntAt(num + 20, bool_);
					var int3 = stream.ReadInt(bool_);
					stream.Position += 4L;
					if ((enum2 & Enum35.Flag3) != Enum35.Flag0)
					{
						Bool1 = false;
						var text = Stream260.ReadString(160);
						var num7 = text.IndexOf('\0');
						if (num7 >= 0)
						{
							text = text.Substring(0, num7);
						}
						if (QbSongClass1.ContainsKey(num3) && !QbSongClass1.GetDictString(num3).EndsWith(".qb.ngc") && !QbSongClass1.GetDictString(num3).EndsWith(".qb.ps2"))
						{
							if (!Bool2)
							{
								if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".ps2", ""), true))
								{
									QbSongClass1.AddKeyToDictionary(text);
								}
								else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".qb", ""), true))
								{
									QbSongClass1.AddKeyToDictionary(text);
								}
							}
							else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".ngc", ""), true))
							{
								QbSongClass1.AddKeyToDictionary(text);
							}
							else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".qb", ""), true))
							{
								QbSongClass1.AddKeyToDictionary(text);
							}
						}
						else
						{
							var text2 = "abcdefghijklmnopqrstuvwxyz";
							for (var i = 0; i < text2.Length; i++)
							{
								var c = text2[i];
								if (num5 == KeyGenerator.GetQbKey(c + text, true))
								{
									QbSongClass1.AddKeyToDictionary(c + text);
								}
							}
						}
						if (num6 == KeyGenerator.GetQbKey(text = KeyGenerator.GetFileNameNoExt(text), true))
						{
							QbSongClass1.AddKeyToDictionary(text);
						}
					}
					TreeNode treeNode;
					if (QbSongClass1.ContainsKey(num3) && QbSongClass1.GetDictString(num3).EndsWith("qb"))
					{
						treeNode = new Class309(num3, num4, int2, num5, num6, int3, enum2);
					}
					else if (QbSongClass1.ContainsKey(num3) && QbSongClass1.GetDictString(num3).Contains("qs"))
					{
						treeNode = new Class328(num3, num4, int2, num5, num6, int3, enum2);
					}
					else
					{
						treeNode = new ZzCocoaNode12(num3, num4, int2, num5, num6, int3, enum2);
					}
					if (QbSongClass1.ContainsKey(num5))
					{
						method_1(QbSongClass1.GetDictString(num5), treeNode);
					}
					else
					{
						method_5(num5, (INterface12)treeNode);
					}
					num += (((enum2 & Enum35.Flag3) != Enum35.Flag0) ? 192 : 32);
				}
			}
			Stream260 = new Stream26(File.Open(String2, FileMode.Open, FileAccess.Read, FileShare.Read));
			if (Stream260.Length == 0L)
			{
				throw new Exception("Pab File is empty!");
			}
		}

		public override void vmethod_1()
		{
			if (Stream260 == null)
			{
				throw new IOException("Pab File was never parsed");
			}
			method_20(String0, String2);
		}

		public void method_20(string string3, string string4)
		{
			var stream = new Stream26(Bool2);
			var stream2 = new Stream26();
			method_18(stream, stream2);
			if (Stream260 != null && String0 == string3 && String2 == string4)
			{
				Stream260.Close();
			}
			KeyGenerator.WriteAllBytes(string4, stream2.ReadEverything());
			KeyGenerator.WriteAllBytes(string3, stream.ReadEverything());
			stream.Dispose();
			stream2.Dispose();
			if (Stream260 != null && String0 == string3 && String2 == string4)
			{
				if (Class3180 != null && Class3180 != this)
				{
					Class3180.vmethod_1();
				}
				Dispose();
				method_19();
				GC.Collect();
			}
		}
	}
}
