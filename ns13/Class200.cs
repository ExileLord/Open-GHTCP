using System;

namespace ns13
{
	public class Class200
	{
		private uint _uint0;

		public long vmethod_0()
		{
			return _uint0;
		}

		public Class200()
		{
			vmethod_1();
		}

		public void vmethod_1()
		{
			_uint0 = 1u;
		}

		public void vmethod_2(byte[] byte0, int int0, int int1)
		{
			if (byte0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int0 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be negative");
			}
			if (int1 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be negative");
			}
			if (int0 >= byte0.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (int0 + int1 > byte0.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			var num = _uint0 & 65535u;
			var num2 = _uint0 >> 16;
			while (int1 > 0)
			{
				var num3 = 3800;
				if (3800 > int1)
				{
					num3 = int1;
				}
				int1 -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(byte0[int0++] & 255);
					num2 += num;
				}
				num %= 65521u;
				num2 %= 65521u;
			}
			_uint0 = (num2 << 16 | num);
		}
	}
}
