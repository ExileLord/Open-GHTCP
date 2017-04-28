using System;

namespace ns3
{
	public class Class52
	{
		public byte[] byte_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private readonly Class48 class48_0 = new Class48();

		private readonly byte[] byte_1 = new byte[4];

		public int method_0()
		{
			byte_0 = null;
			return 0;
		}

		public int method_1(int int_6)
		{
			if (int_2 != 0)
			{
				int_1 -= int_2;
				if (int_1 > 0)
				{
					Buffer.BlockCopy(byte_0, int_2, byte_0, 0, int_1);
				}
				int_2 = 0;
			}
			if (int_6 > int_0 - int_1)
			{
				var num = int_6 + int_1 + 4096;
				if (byte_0 != null)
				{
					var dst = new byte[num];
					Buffer.BlockCopy(byte_0, 0, dst, 0, byte_0.Length);
					byte_0 = dst;
				}
				else
				{
					byte_0 = new byte[num];
				}
				int_0 = num;
			}
			return int_1;
		}

		public int method_2(int int_6)
		{
			if (int_1 + int_6 > int_0)
			{
				return -1;
			}
			int_1 += int_6;
			return 0;
		}

		public int method_3(Class48 class48_1)
		{
			var num = int_2;
			var num2 = int_1 - int_2;
			if (int_4 == 0)
			{
				if (num2 < 27)
				{
					return 0;
				}
				if (byte_0[num] == 79 && byte_0[num + 1] == 103 && byte_0[num + 2] == 103)
				{
					if (byte_0[num + 3] == 83)
					{
						var num3 = (byte_0[num + 26] & 255) + 27;
						if (num2 < num3)
						{
							return 0;
						}
						for (var i = 0; i < (byte_0[num + 26] & 255); i++)
						{
							int_5 += byte_0[num + 27 + i] & 255;
						}
						int_4 = num3;
						goto IL_11E;
					}
				}
				int_4 = 0;
				int_5 = 0;
				var num4 = 0;
				for (var j = 0; j < num2 - 1; j++)
				{
					if (byte_0[num + 1 + j] == 79)
					{
						num4 = num + 1 + j;
                        goto IL_108;
					}
				}
            IL_108:
                if (num4 == 0)
                {
                    num4 = int_1;
                }
                int_2 = num4;
                return -(num4 - num);
			}
			IL_11E:
			if (int_5 + int_4 > num2)
			{
				return 0;
			}
			lock (byte_1)
			{
				Buffer.BlockCopy(byte_0, num + 22, byte_1, 0, 4);
				byte_0[num + 22] = 0;
				byte_0[num + 23] = 0;
				byte_0[num + 24] = 0;
				byte_0[num + 25] = 0;
				var @class = class48_0;
				@class.byte_0 = byte_0;
				@class.int_0 = num;
				@class.int_1 = int_4;
				@class.byte_1 = byte_0;
				@class.int_2 = num + int_4;
				@class.int_3 = int_5;
				@class.method_7();
				if (byte_1[0] == byte_0[num + 22] && byte_1[1] == byte_0[num + 23] && byte_1[2] == byte_0[num + 24])
				{
					if (byte_1[3] == byte_0[num + 25])
					{
						goto IL_2B0;
					}
				}
				Buffer.BlockCopy(byte_1, 0, byte_0, num + 22, 4);
				int_4 = 0;
				int_5 = 0;
				var num4 = 0;
				for (var k = 0; k < num2 - 1; k++)
				{
					if (byte_0[num + 1 + k] == 79)
					{
						num4 = num + 1 + k;
                        goto IL_28C;
					}
				}
            IL_28C:
                if (num4 == 0)
                {
                    num4 = int_1;
                }
                int_2 = num4;
                return -(num4 - num);
			}
			IL_2B0:
			num = int_2;
			if (class48_1 != null)
			{
				class48_1.byte_0 = byte_0;
				class48_1.int_0 = num;
				class48_1.int_1 = int_4;
				class48_1.byte_1 = byte_0;
				class48_1.int_2 = num + int_4;
				class48_1.int_3 = int_5;
			}
			int_3 = 0;
			int_2 += (num2 = int_4 + int_5);
			int_4 = 0;
			int_5 = 0;
			return num2;
		}

		public int method_4()
		{
			int_1 = 0;
			int_2 = 0;
			int_3 = 0;
			int_4 = 0;
			int_5 = 0;
			return 0;
		}

		public void method_5()
		{
		}
	}
}
