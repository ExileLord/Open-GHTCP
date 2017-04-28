using System;
using Compression;
using ns12;

namespace ns13
{
	public class Class196
	{
		private static readonly int[] int_0 = {
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			13,
			15,
			17,
			19,
			23,
			27,
			31,
			35,
			43,
			51,
			59,
			67,
			83,
			99,
			115,
			131,
			163,
			195,
			227,
			258
		};

		private static readonly int[] int_1 = {
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
			5,
			0
		};

		private static readonly int[] int_2 = {
			1,
			2,
			3,
			4,
			5,
			7,
			9,
			13,
			17,
			25,
			33,
			49,
			65,
			97,
			129,
			193,
			257,
			385,
			513,
			769,
			1025,
			1537,
			2049,
			3073,
			4097,
			6145,
			8193,
			12289,
			16385,
			24577
		};

		private static readonly int[] int_3 = {
			0,
			0,
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13
		};

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private int int_9;

		private bool bool_0;

		private long long_0;

		private long long_1;

		private bool bool_1;

		private Class187 class187_0;

		private Class203 class203_0;

		private Class198 class198_0;

		private Class197 class197_0;

		private Class197 class197_1;

		private Class200 class200_0;

		public Class196() : this(false)
		{
		}

		public Class196(bool bool_2)
		{
			bool_1 = bool_2;
			class200_0 = new Class200();
			class187_0 = new Class187();
			class203_0 = new Class203();
			int_4 = (bool_2 ? 2 : 0);
		}

		public void method_0()
		{
			int_4 = (bool_1 ? 2 : 0);
			long_1 = 0L;
			long_0 = 0L;
			class187_0.method_7();
			class203_0.method_7();
			class198_0 = null;
			class197_0 = null;
			class197_1 = null;
			bool_0 = false;
			class200_0.vmethod_1();
		}

		private bool method_1()
		{
			var num = class187_0.method_0(16);
			if (num < 0)
			{
				return false;
			}
			class187_0.method_1(16);
			num = ((num << 8 | num >> 8) & 65535);
			if (num % 31 != 0)
			{
				throw new SharpZipBaseException("Header checksum illegal");
			}
			if ((num & 3840) != 2048)
			{
				throw new SharpZipBaseException("Compression Method unknown");
			}
			if ((num & 32) == 0)
			{
				int_4 = 2;
			}
			else
			{
				int_4 = 1;
				int_6 = 32;
			}
			return true;
		}

		private bool method_2()
		{
			while (int_6 > 0)
			{
				var num = class187_0.method_0(8);
				if (num < 0)
				{
					return false;
				}
				class187_0.method_1(8);
				int_5 = (int_5 << 8 | num);
				int_6 -= 8;
			}
			return false;
		}

		private bool method_3()
		{
			var i = class203_0.method_4();
			while (i >= 258)
			{
				int num;
				switch (int_4)
				{
				case 7:
					while (((num = class197_0.method_1(class187_0)) & -256) == 0)
					{
						class203_0.method_0(num);
						if (--i < 258)
						{
							return true;
						}
					}
					if (num >= 257)
					{
						try
						{
							int_7 = int_0[num - 257];
							int_6 = int_1[num - 257];
						}
						catch (Exception)
						{
							throw new SharpZipBaseException("Illegal rep length code");
						}
						goto IL_AC;
					}
					if (num < 0)
					{
						return false;
					}
					class197_1 = null;
					class197_0 = null;
					int_4 = 2;
					return true;
				case 8:
					goto IL_AC;
				case 9:
					goto IL_FC;
				case 10:
					break;
				default:
					throw new SharpZipBaseException("Inflater unknown mode");
				}
				IL_13D:
				if (int_6 > 0)
				{
					int_4 = 10;
					var num2 = class187_0.method_0(int_6);
					if (num2 < 0)
					{
						return false;
					}
					class187_0.method_1(int_6);
					int_8 += num2;
				}
				class203_0.method_2(int_7, int_8);
				i -= int_7;
				int_4 = 7;
				continue;
				IL_FC:
				num = class197_1.method_1(class187_0);
				if (num >= 0)
				{
					try
					{
						int_8 = int_2[num];
						int_6 = int_3[num];
					}
					catch (Exception)
					{
						throw new SharpZipBaseException("Illegal rep dist code");
					}
					goto IL_13D;
				}
				return false;
				IL_AC:
				if (int_6 > 0)
				{
					int_4 = 8;
					var num3 = class187_0.method_0(int_6);
					if (num3 < 0)
					{
						return false;
					}
					class187_0.method_1(int_6);
					int_7 += num3;
				}
				int_4 = 9;
				goto IL_FC;
			}
			return true;
		}

		private bool method_4()
		{
			while (int_6 > 0)
			{
				var num = class187_0.method_0(8);
				if (num < 0)
				{
					return false;
				}
				class187_0.method_1(8);
				int_5 = (int_5 << 8 | num);
				int_6 -= 8;
			}
			if ((int)class200_0.vmethod_0() != int_5)
			{
				throw new SharpZipBaseException(string.Concat("Adler chksum doesn't match: ", (int)class200_0.vmethod_0(), " vs. ", int_5));
			}
			int_4 = 12;
			return false;
		}

		private bool method_5()
		{
			switch (int_4)
			{
			case 0:
				return method_1();
			case 1:
				return method_2();
			case 2:
				if (bool_0)
				{
					if (bool_1)
					{
						int_4 = 12;
						return false;
					}
					class187_0.method_4();
					int_6 = 32;
					int_4 = 11;
					return true;
				}
				else
				{
					var num = class187_0.method_0(3);
					if (num < 0)
					{
						return false;
					}
					class187_0.method_1(3);
					if ((num & 1) != 0)
					{
						bool_0 = true;
					}
					switch (num >> 1)
					{
					case 0:
						class187_0.method_4();
						int_4 = 3;
						break;
					case 1:
						class197_0 = Class197.class197_0;
						class197_1 = Class197.class197_1;
						int_4 = 7;
						break;
					case 2:
						class198_0 = new Class198();
						int_4 = 6;
						break;
					default:
						throw new SharpZipBaseException("Unknown block type " + num);
					}
					return true;
				}
				break;
			case 3:
				if ((int_9 = class187_0.method_0(16)) < 0)
				{
					return false;
				}
				class187_0.method_1(16);
				int_4 = 4;
				break;
			case 4:
				break;
			case 5:
				goto IL_1A4;
			case 6:
				if (!class198_0.method_0(class187_0))
				{
					return false;
				}
				class197_0 = class198_0.method_1();
				class197_1 = class198_0.method_2();
				int_4 = 7;
				goto IL_228;
			case 7:
			case 8:
			case 9:
			case 10:
				goto IL_228;
			case 11:
				return method_4();
			case 12:
				return false;
			default:
				throw new SharpZipBaseException("Inflater.Decode unknown mode");
			}
			var num2 = class187_0.method_0(16);
			if (num2 < 0)
			{
				return false;
			}
			class187_0.method_1(16);
			if (num2 != (int_9 ^ 65535))
			{
				throw new SharpZipBaseException("broken uncompressed block");
			}
			int_4 = 5;
			IL_1A4:
			var num3 = class203_0.method_3(class187_0, int_9);
			int_9 -= num3;
			if (int_9 == 0)
			{
				int_4 = 2;
				return true;
			}
			return !class187_0.method_5();
			IL_228:
			return method_3();
		}

		public void method_6(byte[] byte_0, int int_10, int int_11)
		{
			class187_0.method_8(byte_0, int_10, int_11);
			long_1 += int_11;
		}

		public int method_7(byte[] byte_0, int int_10, int int_11)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_11 < 0)
			{
				throw new ArgumentOutOfRangeException("count", "count cannot be negative");
			}
			if (int_10 < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
			}
			if (int_10 + int_11 > byte_0.Length)
			{
				throw new ArgumentException("count exceeds buffer bounds");
			}
			if (int_11 == 0)
			{
				if (!method_10())
				{
					method_5();
				}
				return 0;
			}
			var num = 0;
			while (true)
			{
				if (int_4 != 11)
				{
					var num2 = class203_0.method_6(byte_0, int_10, int_11);
					if (num2 > 0)
					{
						class200_0.vmethod_2(byte_0, int_10, num2);
						int_10 += num2;
						num += num2;
						long_0 += num2;
						int_11 -= num2;
						if (int_11 == 0)
						{
							return num;
						}
					}
				}
				if (!method_5())
				{
					if (class203_0.method_5() <= 0)
					{
						break;
					}
					if (int_4 == 11)
					{
						break;
					}
				}
			}
			return num;
		}

		public bool method_8()
		{
			return class187_0.method_5();
		}

		public bool method_9()
		{
			return int_4 == 1 && int_6 == 0;
		}

		public bool method_10()
		{
			return int_4 == 12 && class203_0.method_5() == 0;
		}

		public long method_11()
		{
			return long_0;
		}

		public long method_12()
		{
			return long_1 - method_13();
		}

		public int method_13()
		{
			return class187_0.method_3();
		}
	}
}
