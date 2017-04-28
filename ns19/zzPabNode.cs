using System;
using System.IO;
using System.Windows.Forms;
using ns16;
using ns20;
using ns21;

namespace ns19
{
	public class zzPabNode : zzPakNode2
	{
		public string string_2;

		public zzPabNode() : this(true)
		{
		}

		public zzPabNode(bool bool_5) : this(bool_5, true, 0)
		{
		}

		public zzPabNode(bool bool_5, bool bool_6, int int_1)
		{
			Text = "PabFile";
			bool_2 = bool_5;
			bool_1 = bool_6;
			int_0 = int_1;
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		public zzPabNode(string string_3, string string_4, bool bool_5) : this(string_3, string_4, null, bool_5)
		{
		}

		public zzPabNode(string string_3, string string_4, string string_5, bool bool_5)
		{
			Text = KeyGenerator.GetFileName(string_3);
			string_0 = string_3;
			string_2 = string_4;
			string_1 = string_5;
			bool_4 = bool_5;
			if (File.Exists(string_3) && File.Exists(string_4))
			{
				method_19();
			}
			ImageIndex = 37;
			SelectedImageIndex = 37;
		}

		private void method_19()
		{
			if (string_1 != null)
			{
				class318_0 = new zzPakNode2(string_1, false);
			}
			using (var stream = new Stream26(File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				var num = 0;
				var num2 = (int)stream.Length;
				if (num2 == 0)
				{
					throw new Exception("Pak File is empty!");
				}
				var int_ = stream.ReadInt();
				stream._reverseEndianness = (bool_2 = (!QbSongClass1.ContainsKey(int_) || !QbSongClass1.GetDictString(int_).StartsWith(".")));
				bool_3 = (stream.ReadInt() < stream.Length);
				var @enum = (Enum35)stream.ReadIntAt(28);
				bool_1 = ((@enum & Enum35.flag_3) == Enum35.flag_0);
				int_0 = stream.ReadIntAt(bool_1 ? 12 : 16, bool_2 && (@enum & Enum35.flag_4) == Enum35.flag_0 && (@enum & Enum35.flag_5) == Enum35.flag_0);
				while (true)
				{
					var enum2 = (Enum35)stream.ReadIntAt(num + 28, false);
					var bool_ = bool_2 && (enum2 & Enum35.flag_4) == Enum35.flag_0 && (enum2 & Enum35.flag_5) == Enum35.flag_0;
					var num3 = stream.ReadIntAt(num, bool_);
					if (QbSongClass1.ContainsKey(num3) && (QbSongClass1.GetDictString(num3).Equals(".last") || QbSongClass1.GetDictString(num3).Equals("last")))
					{
						break;
					}
					var num4 = stream.ReadInt(bool_);
					if (!bool_3)
					{
						num4 = num4 - num2 + num;
					}
					if (num4 < 0)
					{
						num4 = 0;
					}
					var int_2 = stream.ReadInt(bool_);
					var num5 = stream.ReadIntAt(num + (bool_1 ? 16 : 12), bool_);
					var num6 = stream.ReadIntAt(num + 20, bool_);
					var int_3 = stream.ReadInt(bool_);
					stream.Position += 4L;
					if ((enum2 & Enum35.flag_3) != Enum35.flag_0)
					{
						bool_1 = false;
						var text = stream26_0.ReadString(160);
						var num7 = text.IndexOf('\0');
						if (num7 >= 0)
						{
							text = text.Substring(0, num7);
						}
						if (QbSongClass1.ContainsKey(num3) && !QbSongClass1.GetDictString(num3).EndsWith(".qb.ngc") && !QbSongClass1.GetDictString(num3).EndsWith(".qb.ps2"))
						{
							if (!bool_2)
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
						treeNode = new Class309(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					else if (QbSongClass1.ContainsKey(num3) && QbSongClass1.GetDictString(num3).Contains("qs"))
					{
						treeNode = new Class328(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					else
					{
						treeNode = new zzCocoaNode12(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					if (QbSongClass1.ContainsKey(num5))
					{
						method_1(QbSongClass1.GetDictString(num5), treeNode);
					}
					else
					{
						method_5(num5, (Interface12)treeNode);
					}
					num += (((enum2 & Enum35.flag_3) != Enum35.flag_0) ? 192 : 32);
				}
			}
			stream26_0 = new Stream26(File.Open(string_2, FileMode.Open, FileAccess.Read, FileShare.Read));
			if (stream26_0.Length == 0L)
			{
				throw new Exception("Pab File is empty!");
			}
		}

		public override void vmethod_1()
		{
			if (stream26_0 == null)
			{
				throw new IOException("Pab File was never parsed");
			}
			method_20(string_0, string_2);
		}

		public void method_20(string string_3, string string_4)
		{
			var stream = new Stream26(bool_2);
			var stream2 = new Stream26();
			method_18(stream, stream2);
			if (stream26_0 != null && string_0 == string_3 && string_2 == string_4)
			{
				stream26_0.Close();
			}
			KeyGenerator.WriteAllBytes(string_4, stream2.ReadEverything());
			KeyGenerator.WriteAllBytes(string_3, stream.ReadEverything());
			stream.Dispose();
			stream2.Dispose();
			if (stream26_0 != null && string_0 == string_3 && string_2 == string_4)
			{
				if (class318_0 != null && class318_0 != this)
				{
					class318_0.vmethod_1();
				}
				Dispose();
				method_19();
				GC.Collect();
			}
		}
	}
}
