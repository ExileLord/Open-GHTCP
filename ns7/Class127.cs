using System.Text;
using ns6;

namespace ns7
{
	public class Class127 : Class121
	{
		public Class142[] class142_0;

		public Class127(Class144 class144_0, int int_0, bool bool_1) : base(bool_1)
		{
			var num = int_0 / 18;
			class142_0 = new Class142[num];
			for (var i = 0; i < class142_0.Length; i++)
			{
				class142_0[i] = new Class142(class144_0);
			}
			int_0 -= int_0 * 18;
			if (int_0 > 0)
			{
				class144_0.vmethod_15(null, int_0);
			}
		}

		public virtual int vmethod_1()
		{
			return class142_0.Length;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append("SeekTable: points=" + class142_0.Length + "\n");
			for (var i = 0; i < class142_0.Length; i++)
			{
				stringBuilder.Append("\tPoint " + class142_0[i] + "\n");
			}
			return stringBuilder.ToString();
		}
	}
}
