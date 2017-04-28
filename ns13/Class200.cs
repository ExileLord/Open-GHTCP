using System;

namespace ns13
{
	public class Class200
	{
		private uint uint_0;

		public long vmethod_0()
		{
			return uint_0;
		}

		public Class200()
		{
			vmethod_1();
		}

		public void vmethod_1()
		{
			uint_0 = 1u;
		}

		public void vmethod_2(byte[] byte_0, int int_0, int int_1)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be negative");
			}
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be negative");
			}
			if (int_0 >= byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (int_0 + int_1 > byte_0.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			var num = uint_0 & 65535u;
			var num2 = uint_0 >> 16;
			while (int_1 > 0)
			{
				var num3 = 3800;
				if (3800 > int_1)
				{
					num3 = int_1;
				}
				int_1 -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(byte_0[int_0++] & 255);
					num2 += num;
				}
				num %= 65521u;
				num2 %= 65521u;
			}
			uint_0 = (num2 << 16 | num);
		}
	}
}
