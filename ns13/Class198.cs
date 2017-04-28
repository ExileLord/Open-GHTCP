using System;
using Compression;
using ns12;

namespace ns13
{
	public class Class198
	{
		private static readonly int[] int_0 = {
			3,
			3,
			11
		};

		private static readonly int[] int_1 = {
			2,
			3,
			7
		};

		private static readonly int[] int_2 = {
			16,
			17,
			18,
			0,
			8,
			7,
			9,
			6,
			10,
			5,
			11,
			4,
			12,
			3,
			13,
			2,
			14,
			1,
			15
		};

		private byte[] byte_0;

		private byte[] byte_1;

		private Class197 class197_0;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private byte byte_2;

		private int int_9;

		public bool method_0(Class187 class187_0)
		{
			while (true)
			{
				switch (int_3)
				{
				case 0:
					int_4 = class187_0.method_0(5);
					if (int_4 >= 0)
					{
						int_4 += 257;
						class187_0.method_1(5);
						int_3 = 1;
						goto IL_1FD;
					}
					return false;
				case 1:
					goto IL_1FD;
				case 2:
					goto IL_1AF;
				case 3:
					goto IL_176;
				case 4:
					break;
				case 5:
					goto IL_2C;
				default:
					continue;
				}
				IL_F4:
				int num;
				while (((num = class197_0.method_1(class187_0)) & -16) == 0)
				{
					byte_1[int_9++] = (byte_2 = (byte)num);
					if (int_9 == int_7)
					{
						return true;
					}
				}
				if (num >= 0)
				{
					if (num >= 17)
					{
						byte_2 = 0;
					}
					else if (int_9 == 0)
					{
						goto IL_2A6;
					}
					int_8 = num - 16;
					int_3 = 5;
					goto IL_2C;
				}
				return false;
				IL_176:
				while (int_9 < int_6)
				{
					int num2 = class187_0.method_0(3);
					if (num2 < 0)
					{
						return false;
					}
					class187_0.method_1(3);
					byte_0[int_2[int_9]] = (byte)num2;
					int_9++;
				}
				class197_0 = new Class197(byte_0);
				byte_0 = null;
				int_9 = 0;
				int_3 = 4;
				goto IL_F4;
				IL_2C:
				int num3 = int_1[int_8];
				int num4 = class187_0.method_0(num3);
				if (num4 < 0)
				{
					return false;
				}
				class187_0.method_1(num3);
				num4 += int_0[int_8];
				if (int_9 + num4 > int_7)
				{
					break;
				}
				while (num4-- > 0)
				{
					byte_1[int_9++] = byte_2;
				}
				if (int_9 == int_7)
				{
					return true;
				}
				int_3 = 4;
				continue;
				IL_1AF:
				int_6 = class187_0.method_0(4);
				if (int_6 >= 0)
				{
					int_6 += 4;
					class187_0.method_1(4);
					byte_0 = new byte[19];
					int_9 = 0;
					int_3 = 3;
					goto IL_176;
				}
				return false;
				IL_1FD:
				int_5 = class187_0.method_0(5);
				if (int_5 >= 0)
				{
					int_5++;
					class187_0.method_1(5);
					int_7 = int_4 + int_5;
					byte_1 = new byte[int_7];
					int_3 = 2;
					goto IL_1AF;
				}
				return false;
			}
			throw new SharpZipBaseException();
			IL_2A6:
			throw new SharpZipBaseException();
		}

		public Class197 method_1()
		{
			byte[] destinationArray = new byte[int_4];
			Array.Copy(byte_1, 0, destinationArray, 0, int_4);
			return new Class197(destinationArray);
		}

		public Class197 method_2()
		{
			byte[] destinationArray = new byte[int_5];
			Array.Copy(byte_1, int_4, destinationArray, 0, int_5);
			return new Class197(destinationArray);
		}
	}
}
