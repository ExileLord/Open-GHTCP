using System.Text;
using ns6;

namespace ns7
{
	public class Class151
	{
		public Class140 Class1400;

		public Class131[] Class1310;

		private short _short0;

		public Class151()
		{
			method_0();
		}

		private void method_0()
		{
			Class1310 = new Class131[8];
		}

		public virtual short vmethod_0()
		{
			return _short0;
		}

		public virtual void vmethod_1(short short1)
		{
			_short0 = short1;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append("Frame Header: " + Class1400 + "\n");
			for (var i = 0; i < Class1400.Int2; i++)
			{
				stringBuilder.Append("\tFrame Data " + Class1310[i] + "\n");
			}
			stringBuilder.Append("\tFrame Footer: " + _short0);
			return stringBuilder.ToString();
		}
	}
}
