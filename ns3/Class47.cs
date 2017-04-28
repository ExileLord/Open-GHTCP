using ns2;

namespace ns3
{
	public class Class47
	{
		private static string string_0 = "vorbis";

		private static int int_0 = -130;

		public byte[][] byte_0;

		public int[] int_1;

		public int int_2;

		public byte[] byte_1;

		public void method_0()
		{
			byte_0 = null;
			int_2 = 0;
			byte_1 = null;
		}

		public int method_1(OGGClass3 class38_0)
		{
			int num = class38_0.method_6(32);
			if (num < 0)
			{
				method_2();
				return -1;
			}
			byte_1 = new byte[num + 1];
			class38_0.method_5(byte_1, num);
			int_2 = class38_0.method_6(32);
			if (int_2 < 0)
			{
				method_2();
				return -1;
			}
			byte_0 = new byte[int_2 + 1][];
			int_1 = new int[int_2 + 1];
			for (int i = 0; i < int_2; i++)
			{
				int num2 = class38_0.method_6(32);
				if (num2 < 0)
				{
					method_2();
					return -1;
				}
				int_1[i] = num2;
				byte_0[i] = new byte[num2 + 1];
				class38_0.method_5(byte_0[i], num2);
			}
			if (class38_0.method_6(1) != 1)
			{
				method_2();
				return -1;
			}
			return 0;
		}

		public void method_2()
		{
			for (int i = 0; i < int_2; i++)
			{
				byte_0[i] = null;
			}
			byte_0 = null;
			byte_1 = null;
		}
	}
}
