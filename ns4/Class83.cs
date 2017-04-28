namespace ns4
{
	public class Class83
	{
		private readonly byte[] byte_0;

		private readonly int[] int_0;

		private readonly int int_1;

		public int int_2;

		private readonly double double_0;

		public Class83(byte[] byte_1, int int_3)
		{
			byte_0 = byte_1;
			int_2 = int_3;
			double_0 = 1.0 / byte_1.Length;
		}

		public Class83(int[] int_3, short short_0)
		{
			int_0 = int_3;
			int_1 = short_0;
			double_0 = 1.0 / int_3.Length;
		}

		public int method_0(double double_1)
		{
			var num = 0;
			var num2 = 0;
			var num3 = 0.0;
			if (byte_0 == null)
			{
				while (num3 <= double_1)
				{
					num2 += int_0[num++];
					num3 += double_0;
				}
				return num2 - (int)(int_0[num - 1] * ((num3 - double_1) / double_0 + 0.5 / int_1));
			}
			if (double_1 == 0.0)
			{
				return 0;
			}
			if (double_1 == 1.0)
			{
				return int_2;
			}
			num3 = double_1 * 100.0;
			num = (int)num3;
			if (num >= byte_0.Length - 1)
			{
				return (int)(byte_0[byte_0.Length - 1] / 256.0 * int_2);
			}
			if (num == num3)
			{
				return (int)(byte_0[num] / 256.0 * int_2);
			}
			return (int)((byte_0[num] + (num3 - num) * (byte_0[num + 1] - byte_0[num])) / 256.0 * int_2);
		}
	}
}
