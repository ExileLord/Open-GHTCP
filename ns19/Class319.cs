using ns16;
using ns20;
using ns21;
using System;
using System.IO;
using System.Windows.Forms;

namespace ns19
{
	public class Class319 : Class318
	{
		public string string_2;

		public Class319() : this(true)
		{
		}

		public Class319(bool bool_5) : this(bool_5, true, 0)
		{
		}

		public Class319(bool bool_5, bool bool_6, int int_1)
		{
			base.Text = "PabFile";
			this.bool_2 = bool_5;
			this.bool_1 = bool_6;
			this.int_0 = int_1;
			base.ImageIndex = 37;
			base.SelectedImageIndex = 37;
		}

		public Class319(string string_3, string string_4, bool bool_5) : this(string_3, string_4, null, bool_5)
		{
		}

		public Class319(string string_3, string string_4, string string_5, bool bool_5)
		{
			base.Text = KeyGenerator.smethod_13(string_3);
			this.string_0 = string_3;
			this.string_2 = string_4;
			this.string_1 = string_5;
			this.bool_4 = bool_5;
			if (File.Exists(string_3) && File.Exists(string_4))
			{
				this.method_19();
			}
			base.ImageIndex = 37;
			base.SelectedImageIndex = 37;
		}

		private void method_19()
		{
			if (this.string_1 != null)
			{
				this.class318_0 = new Class318(this.string_1, false);
			}
			using (Stream26 stream = new Stream26(File.Open(this.string_0, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				int num = 0;
				int num2 = (int)stream.Length;
				if (num2 == 0)
				{
					throw new Exception("Pak File is empty!");
				}
				int int_ = stream.method_19();
				stream.bool_0 = (this.bool_2 = (!QbSongClass1.smethod_3(int_) || !QbSongClass1.smethod_5(int_).StartsWith(".")));
				this.bool_3 = ((long)stream.method_19() < stream.Length);
				Enum35 @enum = (Enum35)stream.method_41(28);
				this.bool_1 = ((@enum & Enum35.flag_3) == Enum35.flag_0);
				this.int_0 = stream.method_42(this.bool_1 ? 12 : 16, this.bool_2 && (@enum & Enum35.flag_4) == Enum35.flag_0 && (@enum & Enum35.flag_5) == Enum35.flag_0);
				while (true)
				{
					Enum35 enum2 = (Enum35)stream.method_42(num + 28, false);
					bool bool_ = this.bool_2 && (enum2 & Enum35.flag_4) == Enum35.flag_0 && (enum2 & Enum35.flag_5) == Enum35.flag_0;
					int num3 = stream.method_42(num, bool_);
					if (QbSongClass1.smethod_3(num3) && (QbSongClass1.smethod_5(num3).Equals(".last") || QbSongClass1.smethod_5(num3).Equals("last")))
					{
						break;
					}
					int num4 = stream.method_20(bool_);
					if (!this.bool_3)
					{
						num4 = num4 - num2 + num;
					}
					if (num4 < 0)
					{
						num4 = 0;
					}
					int int_2 = stream.method_20(bool_);
					int num5 = stream.method_42(num + (this.bool_1 ? 16 : 12), bool_);
					int num6 = stream.method_42(num + 20, bool_);
					int int_3 = stream.method_20(bool_);
					stream.Position += 4L;
					if ((enum2 & Enum35.flag_3) != Enum35.flag_0)
					{
						this.bool_1 = false;
						string text = this.stream26_0.method_28(160);
						int num7 = text.IndexOf('\0');
						if (num7 >= 0)
						{
							text = text.Substring(0, num7);
						}
						if (QbSongClass1.smethod_3(num3) && !QbSongClass1.smethod_5(num3).EndsWith(".qb.ngc") && !QbSongClass1.smethod_5(num3).EndsWith(".qb.ps2"))
						{
							if (!this.bool_2)
							{
								if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".ps2", ""), true))
								{
									QbSongClass1.smethod_9(text);
								}
								else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".qb", ""), true))
								{
									QbSongClass1.smethod_9(text);
								}
							}
							else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".ngc", ""), true))
							{
								QbSongClass1.smethod_9(text);
							}
							else if (num5 == KeyGenerator.GetQbKey(text = text.Replace("/", "\\").Replace(".qb", ""), true))
							{
								QbSongClass1.smethod_9(text);
							}
						}
						else
						{
							string text2 = "abcdefghijklmnopqrstuvwxyz";
							for (int i = 0; i < text2.Length; i++)
							{
								char c = text2[i];
								if (num5 == KeyGenerator.GetQbKey(c + text, true))
								{
									QbSongClass1.smethod_9(c + text);
								}
							}
						}
						if (num6 == KeyGenerator.GetQbKey(text = KeyGenerator.smethod_12(text), true))
						{
							QbSongClass1.smethod_9(text);
						}
					}
					TreeNode treeNode;
					if (QbSongClass1.smethod_3(num3) && QbSongClass1.smethod_5(num3).EndsWith("qb"))
					{
						treeNode = new Class309(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					else if (QbSongClass1.smethod_3(num3) && QbSongClass1.smethod_5(num3).Contains("qs"))
					{
						treeNode = new Class328(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					else
					{
						treeNode = new zzCocoaNode12(num3, num4, int_2, num5, num6, int_3, enum2);
					}
					if (QbSongClass1.smethod_3(num5))
					{
						base.method_1<TreeNode>(QbSongClass1.smethod_5(num5), treeNode);
					}
					else
					{
						base.method_5(num5, (Interface12)treeNode);
					}
					num += (((enum2 & Enum35.flag_3) != Enum35.flag_0) ? 192 : 32);
				}
			}
			this.stream26_0 = new Stream26(File.Open(this.string_2, FileMode.Open, FileAccess.Read, FileShare.Read));
			if (this.stream26_0.Length == 0L)
			{
				throw new Exception("Pab File is empty!");
			}
		}

		public override void vmethod_1()
		{
			if (this.stream26_0 == null)
			{
				throw new IOException("Pab File was never parsed");
			}
			this.method_20(this.string_0, this.string_2);
		}

		public void method_20(string string_3, string string_4)
		{
			Stream26 stream = new Stream26(this.bool_2);
			Stream26 stream2 = new Stream26();
			base.method_18(stream, stream2);
			if (this.stream26_0 != null && this.string_0 == string_3 && this.string_2 == string_4)
			{
				this.stream26_0.Close();
			}
			KeyGenerator.smethod_9(string_4, stream2.method_1());
			KeyGenerator.smethod_9(string_3, stream.method_1());
			stream.Dispose();
			stream2.Dispose();
			if (this.stream26_0 != null && this.string_0 == string_3 && this.string_2 == string_4)
			{
				if (this.class318_0 != null && this.class318_0 != this)
				{
					this.class318_0.vmethod_1();
				}
				base.Dispose();
				this.method_19();
				GC.Collect();
			}
		}
	}
}
