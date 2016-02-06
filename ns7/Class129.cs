using ns6;
using System;
using System.Text;

namespace ns7
{
	public class Class129 : Class121
	{
		public byte[] byte_0 = new byte[0];

		public int int_0;

		public Class146[] class146_0;

		public Class129(Class144 class144_0, int int_1, bool bool_1) : base(bool_1)
		{
			int num = class144_0.vmethod_14();
			this.byte_0 = new byte[num];
			class144_0.vmethod_15(this.byte_0, this.byte_0.Length);
			this.int_0 = class144_0.vmethod_14();
			if (this.int_0 > 0)
			{
				this.class146_0 = new Class146[this.int_0];
			}
			for (int i = 0; i < this.int_0; i++)
			{
				this.class146_0[i] = new Class146(class144_0);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("VendorString '" + this.byte_0 + "'\n");
			stringBuilder.Append("VorbisComment (count=" + this.int_0 + ")");
			for (int i = 0; i < this.int_0; i++)
			{
				stringBuilder.Append("\n\t" + this.class146_0[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
