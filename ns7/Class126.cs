using ns6;

namespace ns7
{
	public class Class126 : Class121
	{
		public byte[] byte_0;

		public Class126(Class144 class144_0, int int_0, bool bool_1) : base(bool_1)
		{
			if (int_0 > 0)
			{
				byte_0 = new byte[int_0];
				class144_0.vmethod_15(byte_0, int_0);
			}
		}
	}
}
