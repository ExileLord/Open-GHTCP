using System;

namespace ns3
{
	public class Class44
	{
		private static readonly uint[] uint_0 = new uint[256];

		private static uint smethod_0(uint uint_1)
		{
			uint num = uint_1 << 24;
			for (int i = 0; i < 8; i++)
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

		public Class44()
		{
			uint num = 0u;
			while ((ulong)num < (ulong)((long)Class44.uint_0.Length))
			{
				Class44.uint_0[(int)((UIntPtr)num)] = Class44.smethod_0(num);
				num += 1u;
			}
		}
	}
}
