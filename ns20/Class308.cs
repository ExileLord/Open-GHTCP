using ns16;
using ns18;
using ns19;
using ns21;
using ns22;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ns20
{
	public class Class308 : Class259
	{
		public bool bool_1 = true;

		private bool bool_2;

		private Dictionary<int, string> dictionary_0;

		public byte[] byte_0 = new byte[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			28,
			8,
			2,
			4,
			16,
			4,
			8,
			12,
			12,
			8,
			2,
			4,
			20,
			2,
			4,
			12,
			16,
			16,
			12,
			0
		};

		public override bool vmethod_7()
		{
			return this.bool_1;
		}

		public override bool vmethod_8()
		{
			return this.bool_2;
		}

		public override void vmethod_9(bool bool_3)
		{
			this.bool_2 = bool_3;
		}

		public override Dictionary<int, string> vmethod_10()
		{
			Dictionary<int, string> arg_18_0;
			if ((arg_18_0 = this.dictionary_0) == null)
			{
				arg_18_0 = (this.dictionary_0 = new Dictionary<int, string>());
			}
			return arg_18_0;
		}

		public override void vmethod_11(Dictionary<int, string> dictionary_1)
		{
			this.bool_2 = true;
			this.dictionary_0 = dictionary_1;
		}

		public Class308()
		{
		}

		public Class308(string string_0, Class259 class259_0)
		{
			base.Text = KeyGenerator.smethod_13(string_0);
			base.Nodes.Add(class259_0);
		}

		public Class308(string string_0, IEnumerable<Class259> ienumerable_0)
		{
			base.Text = KeyGenerator.smethod_13(string_0);
			base.Nodes.AddRange(new List<Class259>(ienumerable_0).ToArray());
		}

		public Class308(string string_0, byte[] byte_1) : this(string_0, new Stream26(byte_1))
		{
		}

		public Class308(string string_0, Stream26 stream26_0)
		{
			base.Text = KeyGenerator.smethod_13(string_0);
			stream26_0.Position = 28L;
			base.method_4(stream26_0);
		}

		public Class308(string string_0, Stream26 stream26_0, Dictionary<int, string> dictionary_1)
		{
			base.Text = KeyGenerator.smethod_13(string_0);
			if (dictionary_1 != null)
			{
				this.dictionary_0 = dictionary_1;
				this.bool_2 = true;
			}
			stream26_0.Position = 28L;
			base.method_4(stream26_0);
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			while (stream26_0.Length > stream26_0.Position)
			{
				int num = stream26_0.method_20(true);
				if (num != 0)
				{
					Class259 @class = this.vmethod_12(num);
					stream26_0.bool_0 = this.vmethod_7();
					base.Nodes.Add(@class);
					@class.method_4(stream26_0);
				}
				else
				{
					stream26_0.Position += 4L;
				}
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			stream26_0.bool_0 = this.vmethod_7();
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override Class259 vmethod_12(int int_0)
		{
			if (int_0 == 256)
			{
				return new Class286();
			}
			int num = int_0 >> 16 & 255;
			int num2 = int_0 >> 8 & 255;
			if (num == 32)
			{
				this.bool_1 = true;
			}
			else if (num == 4)
			{
				this.bool_1 = false;
			}
			Exception ex = new Exception("No QB Node class found for : " + KeyGenerator.smethod_34(int_0));
			if (num != 32)
			{
				if (num != 4)
				{
					if (num == 1)
					{
						if (num2 == 0)
						{
							return new Class287();
						}
						if (num2 == 1)
						{
							return new Class280();
						}
						if (num2 == 2)
						{
							return new Class279();
						}
						if (num2 == 3)
						{
							return new Class285();
						}
						if (num2 == 4)
						{
							return new Class283();
						}
						if (num2 == 5)
						{
							return new Class293();
						}
						if (num2 == 6)
						{
							return new Class290();
						}
						if (num2 == 10)
						{
							return new Class292();
						}
						if (num2 == 12)
						{
							return new Class291();
						}
						if (num2 == 13)
						{
							return new Class281();
						}
						if (num2 == 26)
						{
							this.bool_2 = true;
							return new Class282();
						}
						if (num2 == 28)
						{
							this.bool_2 = true;
							return new Class284();
						}
						throw ex;
					}
					else if (!this.bool_1)
					{
						if (num == 3)
						{
							return new Class299();
						}
						if (num == 5)
						{
							return new Class297();
						}
						if (num == 7)
						{
							return new Class305();
						}
						if (num == 9)
						{
							return new Class307();
						}
						if (num == 11)
						{
							return new Class303();
						}
						if (num == 13)
						{
							return new Class304();
						}
						if (num == 21)
						{
							return new Class302();
						}
						if (num == 25)
						{
							return new Class301();
						}
						if (num == 27)
						{
							return new Class296();
						}
						if (num == 53)
						{
							return new Class298();
						}
						throw ex;
					}
					else
					{
						if (num == 154)
						{
							return new Class298();
						}
						if ((num & 240) != 128 || (num2 = (num & 15)) == 0)
						{
							return null;
						}
						if (num2 == 1)
						{
							return new Class299();
						}
						if (num2 == 2)
						{
							return new Class297();
						}
						if (num2 == 3)
						{
							return new Class305();
						}
						if (num2 == 4)
						{
							return new Class307();
						}
						if (num2 == 5)
						{
							return new Class303();
						}
						if (num2 == 6)
						{
							return new Class304();
						}
						if (num2 == 10)
						{
							return new Class302();
						}
						if (num2 == 12)
						{
							return new Class301();
						}
						if (num2 == 13)
						{
							return new Class296();
						}
						throw ex;
					}
				}
			}
			if (num2 == 1)
			{
				return new Class269();
			}
			if (num2 == 2)
			{
				return new Class271();
			}
			if (num2 == 3)
			{
				return new Class261();
			}
			if (num2 == 4)
			{
				return new Class273();
			}
			if (num2 == 5)
			{
				return new Class264();
			}
			if (num2 == 6)
			{
				return new Class265();
			}
			if (num2 == 7)
			{
				return new Class274();
			}
			if (num2 == 10)
			{
				return new Class266();
			}
			if (num2 == 12)
			{
				return new Class267();
			}
			if (num2 == 13)
			{
				return new Class272();
			}
			if (num2 == 26)
			{
				this.bool_2 = true;
				return new Class270();
			}
			if (num2 == 28)
			{
				this.bool_2 = true;
				return new Class262();
			}
			throw ex;
		}

		public byte[] method_7()
		{
			return this.method_8().ToArray();
		}

		public MemoryStream method_8()
		{
			MemoryStream memoryStream = new MemoryStream();
			this.method_9(memoryStream);
			memoryStream.Position = 0L;
			return memoryStream;
		}

		public void method_9(Stream stream_0)
		{
			this.method_10(new Stream26(stream_0, this.bool_1));
		}

		public void method_10(Stream26 stream26_0)
		{
			stream26_0.method_16(this.byte_0, false);
			this.vmethod_14(stream26_0);
			stream26_0.method_33(4, (int)stream26_0.Length);
			stream26_0.Position = stream26_0.Length;
		}

		public int method_11()
		{
			int result = 28;
			this.vmethod_2(ref result);
			return result;
		}

		public override void vmethod_2(ref int int_0)
		{
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_0);
			}
		}

		public override int vmethod_1()
		{
			return 40;
		}

		public override void vmethod_0()
		{
			if (!Class258.bool_0)
			{
				return;
			}
			base.ToolTipText = this.vmethod_4();
			base.BackColor = this.vmethod_6();
			base.ImageIndex = 40;
			base.SelectedImageIndex = 40;
		}

		public override string vmethod_5()
		{
			return "QB File";
		}

		public override Color vmethod_6()
		{
			return Color.LightCyan;
		}

		public override int CompareTo(object target)
		{
			if (!(target is Class308))
			{
				return -1;
			}
			if (((Class308)target).Text == base.Text)
			{
				return 0;
			}
			return 1;
		}
	}
}
