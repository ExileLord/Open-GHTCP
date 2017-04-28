using System.Text;
using ns6;

namespace ns7
{
	public class Class129 : Class121
	{
		public byte[] byte_0 = new byte[0];

		public int int_0;

		public Class146[] class146_0;

		public Class129(Class144 class144_0, int int_1, bool bool_1) : base(bool_1)
		{
			var num = class144_0.vmethod_14();
			byte_0 = new byte[num];
			class144_0.vmethod_15(byte_0, byte_0.Length);
			int_0 = class144_0.vmethod_14();
			if (int_0 > 0)
			{
				class146_0 = new Class146[int_0];
			}
			for (var i = 0; i < int_0; i++)
			{
				class146_0[i] = new Class146(class144_0);
			}
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder("VendorString '" + byte_0 + "'\n");
			stringBuilder.Append("VorbisComment (count=" + int_0 + ")");
			for (var i = 0; i < int_0; i++)
			{
				stringBuilder.Append("\n\t" + class146_0[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
