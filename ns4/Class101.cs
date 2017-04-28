namespace ns4
{
	public class Class101
	{
		private short short_0;

		public Class101()
		{
			short_0 = -1;
		}

		public void method_0(int int_0, int int_1)
		{
			int num = 1 << int_1 - 1;
			do
			{
				if ((short_0 & 32768) == 0 ^ (int_0 & num) == 0)
				{
					short_0 = (short)(short_0 << 1);
					short_0 ^= -32763;
				}
				else
				{
					short_0 = (short)(short_0 << 1);
				}
			}
			while ((num >>= 1) != 0);
		}

		public short method_1()
		{
			short result = short_0;
			short_0 = -1;
			return result;
		}
	}
}
