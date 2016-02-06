using ns6;
using System;
using System.Text;

namespace ns7
{
	public class Class151
	{
		public Class140 class140_0;

		public Class131[] class131_0;

		private short short_0;

		public Class151()
		{
			this.method_0();
		}

		private void method_0()
		{
			this.class131_0 = new Class131[8];
		}

		public virtual short vmethod_0()
		{
			return this.short_0;
		}

		public virtual void vmethod_1(short short_1)
		{
			this.short_0 = short_1;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Frame Header: " + this.class140_0 + "\n");
			for (int i = 0; i < this.class140_0.int_2; i++)
			{
				stringBuilder.Append("\tFrame Data " + this.class131_0[i].ToString() + "\n");
			}
			stringBuilder.Append("\tFrame Footer: " + this.short_0);
			return stringBuilder.ToString();
		}
	}
}
