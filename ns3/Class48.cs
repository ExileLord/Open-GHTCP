using System;

namespace ns3
{
	public class Class48
	{
		public byte[] Byte0;

		public int Int0;

		public int Int1;

		public byte[] Byte1;

		public int Int2;

		public int Int3;

		private static readonly uint[] Uint0 = new uint[256];

		public Class48()
		{
			var num = 0u;
			while (num < (ulong)Uint0.Length)
			{
				Uint0[(int)((UIntPtr)num)] = smethod_0(num);
				num += 1u;
			}
		}

		private static uint smethod_0(uint uint1)
		{
			var num = uint1 << 24;
			for (var i = 0; i < 8; i++)
			{
				if ((num & 2147483648u) != 0u)
				{
					num = (num << 1 ^ 79764919u);
				}
				else
				{
					num <<= 1;
				}
			}
			return num & 4294967295u;
		}

		public int method_0()
		{
			return Byte0[Int0 + 4] & 255;
		}

		public int method_1()
		{
			return Byte0[Int0 + 5] & 1;
		}

		public int method_2()
		{
			return Byte0[Int0 + 5] & 2;
		}

		public int method_3()
		{
			return Byte0[Int0 + 5] & 4;
		}

		public long method_4()
		{
			long num = Byte0[Int0 + 13] & 255;
			num = (num << 8 | Byte0[Int0 + 12] & 255);
			num = (num << 8 | Byte0[Int0 + 11] & 255);
			num = (num << 8 | Byte0[Int0 + 10] & 255);
			num = (num << 8 | Byte0[Int0 + 9] & 255);
			num = (num << 8 | Byte0[Int0 + 8] & 255);
			num = (num << 8 | Byte0[Int0 + 7] & 255);
			return num << 8 | Byte0[Int0 + 6] & 255;
		}

		public int method_5()
		{
			return Byte0[Int0 + 14] & 255 | (Byte0[Int0 + 15] & 255) << 8 | (Byte0[Int0 + 16] & 255) << 16 | (Byte0[Int0 + 17] & 255) << 24;
		}

		public int method_6()
		{
			return Byte0[Int0 + 18] & 255 | (Byte0[Int0 + 19] & 255) << 8 | (Byte0[Int0 + 20] & 255) << 16 | (Byte0[Int0 + 21] & 255) << 24;
		}

		public void method_7()
		{
			var num = 0u;
			for (var i = 0; i < Int1; i++)
			{
				var num2 = (uint)(Byte0[Int0 + i] & 255);
				var num3 = num >> 24 & 255u;
				num = (num << 8 ^ Uint0[(int)((UIntPtr)(num2 ^ num3))]);
			}
			for (var j = 0; j < Int3; j++)
			{
				var num2 = (uint)(Byte1[Int2 + j] & 255);
				var num3 = num >> 24 & 255u;
				num = (num << 8 ^ Uint0[(int)((UIntPtr)(num2 ^ num3))]);
			}
			Byte0[Int0 + 22] = (byte)num;
			Byte0[Int0 + 23] = (byte)(num >> 8);
			Byte0[Int0 + 24] = (byte)(num >> 16);
			Byte0[Int0 + 25] = (byte)(num >> 24);
		}
	}
}
