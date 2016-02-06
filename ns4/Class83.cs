using System;

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
			this.byte_0 = byte_1;
			this.int_2 = int_3;
			this.double_0 = 1.0 / (double)byte_1.Length;
		}

		public Class83(int[] int_3, short short_0)
		{
			this.int_0 = int_3;
			this.int_1 = (int)short_0;
			this.double_0 = 1.0 / (double)int_3.Length;
		}

		public int method_0(double double_1)
		{
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			if (this.byte_0 == null)
			{
				while (num3 <= double_1)
				{
					num2 += this.int_0[num++];
					num3 += this.double_0;
				}
				return num2 - (int)((double)this.int_0[num - 1] * ((num3 - double_1) / this.double_0 + 0.5 / (double)this.int_1));
			}
			if (double_1 == 0.0)
			{
				return 0;
			}
			if (double_1 == 1.0)
			{
				return this.int_2;
			}
			num3 = double_1 * 100.0;
			num = (int)num3;
			if (num >= this.byte_0.Length - 1)
			{
				return (int)((double)this.byte_0[this.byte_0.Length - 1] / 256.0 * (double)this.int_2);
			}
			if ((double)num == num3)
			{
				return (int)((double)this.byte_0[num] / 256.0 * (double)this.int_2);
			}
			return (int)(((double)this.byte_0[num] + (num3 - (double)num) * (double)(this.byte_0[num + 1] - this.byte_0[num])) / 256.0 * (double)this.int_2);
		}
	}
}
