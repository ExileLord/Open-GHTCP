using ns16;
using ns19;
using ns20;
using System;
using System.Windows.Forms;

namespace ns21
{
	public class Class332 : TreeNode, IDisposable, Interface12
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private Enum35 enum35_0;

		private byte[] byte_0;

		public Class332() : this("newfile.data")
		{
		}

		public Class332(string string_0)
		{
			base.Text = Class244.smethod_13(string_0);
			this.int_2 = Class327.smethod_9(string_0.Substring(string_0.LastIndexOf('.')));
			this.int_3 = Class327.smethod_9(string_0);
			this.int_4 = Class327.smethod_9(Class244.smethod_12(string_0));
			base.ImageIndex = 39;
			base.SelectedImageIndex = 39;
			this.byte_0 = null;
		}

		public Class332(string string_0, byte[] byte_1) : this(string_0)
		{
			this.byte_0 = byte_1;
		}

		public Class332(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, Enum35 enum35_1)
		{
			base.Text = (Class327.smethod_3(int_9) ? Class244.smethod_13(Class327.smethod_5(int_9)) : ("0x" + Class244.smethod_34(int_9)));
			this.int_2 = int_6;
			this.int_0 = int_7;
			this.int_1 = int_8;
			this.int_3 = int_9;
			this.int_4 = int_10;
			this.int_5 = int_11;
			this.enum35_0 = enum35_1;
			base.ImageIndex = 39;
			base.SelectedImageIndex = 39;
			this.byte_0 = null;
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
			if (this.byte_0 == null)
			{
				return this.int_1;
			}
			return this.byte_0.Length;
		}

		public void imethod_3(int int_6)
		{
			if (this.byte_0 == null)
			{
				this.int_1 = int_6;
				return;
			}
			Array.Resize<byte>(ref this.byte_0, int_6);
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
			if (!Class327.smethod_3(this.imethod_4()))
			{
				return "0x" + Class244.smethod_34(this.imethod_4());
			}
			return Class327.smethod_5(this.imethod_4());
		}

		public int imethod_7()
		{
			if (base.Parent != null && base.Parent is Class317 && !(base.Parent as Class317).bool_0)
			{
				return Class327.smethod_9((base.Parent as Class317).vmethod_0() + base.Text);
			}
			return this.int_3;
		}

		public void imethod_8(int int_6)
		{
			this.int_3 = int_6;
		}

		public string imethod_9()
		{
			if (!Class327.smethod_3(this.imethod_7()))
			{
				return "0x" + Class244.smethod_34(this.imethod_7());
			}
			return Class327.smethod_5(this.imethod_7());
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
			return this.byte_0;
		}

		public void imethod_17(byte[] byte_1)
		{
			this.byte_0 = byte_1;
		}

		public bool imethod_18()
		{
			return this.byte_0 == null;
		}

		public void imethod_19()
		{
			this.byte_0 = null;
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
				gparam_0.imethod_17(this.byte_0);
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
			Interface12 @interface = (Interface12)base.Clone();
			@interface.imethod_1(this.int_0);
			@interface.imethod_3(this.int_1);
			@interface.imethod_5(this.int_2);
			@interface.imethod_8(this.int_3);
			@interface.imethod_11(this.int_4);
			@interface.imethod_13(this.int_5);
			@interface.imethod_15(this.enum35_0);
			if (this.imethod_18())
			{
				@interface.imethod_19();
			}
			return @interface;
		}
	}
}
