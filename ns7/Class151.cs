using System.Text;
using ns6;

namespace ns7
{
	public class Class151
	{
		public Class140 class140_0;

		public Class131[] class131_0;

		private short short_0;

		public Class151()
		{
			method_0();
		}

		private void method_0()
		{
			class131_0 = new Class131[8];
		}

		public virtual short vmethod_0()
		{
			return short_0;
		}

		public virtual void vmethod_1(short short_1)
		{
			short_0 = short_1;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Frame Header: " + class140_0 + "\n");
			for (int i = 0; i < class140_0.int_2; i++)
			{
				stringBuilder.Append("\tFrame Data " + class131_0[i] + "\n");
			}
			stringBuilder.Append("\tFrame Footer: " + short_0);
			return stringBuilder.ToString();
		}
	}
}
