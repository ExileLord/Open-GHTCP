using Compression;
using ns12;
using System;

namespace ns13
{
	public class Class196
	{
		private static readonly int[] int_0 = new int[]
		{
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

		private static readonly int[] int_1 = new int[]
		{
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

		private static readonly int[] int_2 = new int[]
		{
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

		private static readonly int[] int_3 = new int[]
		{
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
			this.bool_1 = bool_2;
			this.class200_0 = new Class200();
			this.class187_0 = new Class187();
			this.class203_0 = new Class203();
			this.int_4 = (bool_2 ? 2 : 0);
		}

		public void method_0()
		{
			this.int_4 = (this.bool_1 ? 2 : 0);
			this.long_1 = 0L;
			this.long_0 = 0L;
			this.class187_0.method_7();
			this.class203_0.method_7();
			this.class198_0 = null;
			this.class197_0 = null;
			this.class197_1 = null;
			this.bool_0 = false;
			this.class200_0.vmethod_1();
		}

		private bool method_1()
		{
			int num = this.class187_0.method_0(16);
			if (num < 0)
			{
				return false;
			}
			this.class187_0.method_1(16);
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
				this.int_4 = 2;
			}
			else
			{
				this.int_4 = 1;
				this.int_6 = 32;
			}
			return true;
		}

		private bool method_2()
		{
			while (this.int_6 > 0)
			{
				int num = this.class187_0.method_0(8);
				if (num < 0)
				{
					return false;
				}
				this.class187_0.method_1(8);
				this.int_5 = (this.int_5 << 8 | num);
				this.int_6 -= 8;
			}
			return false;
		}

		private bool method_3()
		{
			int i = this.class203_0.method_4();
			while (i >= 258)
			{
				int num;
				switch (this.int_4)
				{
				case 7:
					while (((num = this.class197_0.method_1(this.class187_0)) & -256) == 0)
					{
						this.class203_0.method_0(num);
						if (--i < 258)
						{
							return true;
						}
					}
					if (num >= 257)
					{
						try
						{
							this.int_7 = Class196.int_0[num - 257];
							this.int_6 = Class196.int_1[num - 257];
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
					this.class197_1 = null;
					this.class197_0 = null;
					this.int_4 = 2;
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
				if (this.int_6 > 0)
				{
					this.int_4 = 10;
					int num2 = this.class187_0.method_0(this.int_6);
					if (num2 < 0)
					{
						return false;
					}
					this.class187_0.method_1(this.int_6);
					this.int_8 += num2;
				}
				this.class203_0.method_2(this.int_7, this.int_8);
				i -= this.int_7;
				this.int_4 = 7;
				continue;
				IL_FC:
				num = this.class197_1.method_1(this.class187_0);
				if (num >= 0)
				{
					try
					{
						this.int_8 = Class196.int_2[num];
						this.int_6 = Class196.int_3[num];
					}
					catch (Exception)
					{
						throw new SharpZipBaseException("Illegal rep dist code");
					}
					goto IL_13D;
				}
				return false;
				IL_AC:
				if (this.int_6 > 0)
				{
					this.int_4 = 8;
					int num3 = this.class187_0.method_0(this.int_6);
					if (num3 < 0)
					{
						return false;
					}
					this.class187_0.method_1(this.int_6);
					this.int_7 += num3;
				}
				this.int_4 = 9;
				goto IL_FC;
			}
			return true;
		}

		private bool method_4()
		{
			while (this.int_6 > 0)
			{
				int num = this.class187_0.method_0(8);
				if (num < 0)
				{
					return false;
				}
				this.class187_0.method_1(8);
				this.int_5 = (this.int_5 << 8 | num);
				this.int_6 -= 8;
			}
			if ((int)this.class200_0.vmethod_0() != this.int_5)
			{
				throw new SharpZipBaseException(string.Concat(new object[]
				{
					"Adler chksum doesn't match: ",
					(int)this.class200_0.vmethod_0(),
					" vs. ",
					this.int_5
				}));
			}
			this.int_4 = 12;
			return false;
		}

		private bool method_5()
		{
			switch (this.int_4)
			{
			case 0:
				return this.method_1();
			case 1:
				return this.method_2();
			case 2:
				if (this.bool_0)
				{
					if (this.bool_1)
					{
						this.int_4 = 12;
						return false;
					}
					this.class187_0.method_4();
					this.int_6 = 32;
					this.int_4 = 11;
					return true;
				}
				else
				{
					int num = this.class187_0.method_0(3);
					if (num < 0)
					{
						return false;
					}
					this.class187_0.method_1(3);
					if ((num & 1) != 0)
					{
						this.bool_0 = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.class187_0.method_4();
						this.int_4 = 3;
						break;
					case 1:
						this.class197_0 = Class197.class197_0;
						this.class197_1 = Class197.class197_1;
						this.int_4 = 7;
						break;
					case 2:
						this.class198_0 = new Class198();
						this.int_4 = 6;
						break;
					default:
						throw new SharpZipBaseException("Unknown block type " + num);
					}
					return true;
				}
				break;
			case 3:
				if ((this.int_9 = this.class187_0.method_0(16)) < 0)
				{
					return false;
				}
				this.class187_0.method_1(16);
				this.int_4 = 4;
				break;
			case 4:
				break;
			case 5:
				goto IL_1A4;
			case 6:
				if (!this.class198_0.method_0(this.class187_0))
				{
					return false;
				}
				this.class197_0 = this.class198_0.method_1();
				this.class197_1 = this.class198_0.method_2();
				this.int_4 = 7;
				goto IL_228;
			case 7:
			case 8:
			case 9:
			case 10:
				goto IL_228;
			case 11:
				return this.method_4();
			case 12:
				return false;
			default:
				throw new SharpZipBaseException("Inflater.Decode unknown mode");
			}
			int num2 = this.class187_0.method_0(16);
			if (num2 < 0)
			{
				return false;
			}
			this.class187_0.method_1(16);
			if (num2 != (this.int_9 ^ 65535))
			{
				throw new SharpZipBaseException("broken uncompressed block");
			}
			this.int_4 = 5;
			IL_1A4:
			int num3 = this.class203_0.method_3(this.class187_0, this.int_9);
			this.int_9 -= num3;
			if (this.int_9 == 0)
			{
				this.int_4 = 2;
				return true;
			}
			return !this.class187_0.method_5();
			IL_228:
			return this.method_3();
		}

		public void method_6(byte[] byte_0, int int_10, int int_11)
		{
			this.class187_0.method_8(byte_0, int_10, int_11);
			this.long_1 += (long)int_11;
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
				if (!this.method_10())
				{
					this.method_5();
				}
				return 0;
			}
			int num = 0;
			while (true)
			{
				if (this.int_4 != 11)
				{
					int num2 = this.class203_0.method_6(byte_0, int_10, int_11);
					if (num2 > 0)
					{
						this.class200_0.vmethod_2(byte_0, int_10, num2);
						int_10 += num2;
						num += num2;
						this.long_0 += (long)num2;
						int_11 -= num2;
						if (int_11 == 0)
						{
							return num;
						}
					}
				}
				if (!this.method_5())
				{
					if (this.class203_0.method_5() <= 0)
					{
						break;
					}
					if (this.int_4 == 11)
					{
						break;
					}
				}
			}
			return num;
		}

		public bool method_8()
		{
			return this.class187_0.method_5();
		}

		public bool method_9()
		{
			return this.int_4 == 1 && this.int_6 == 0;
		}

		public bool method_10()
		{
			return this.int_4 == 12 && this.class203_0.method_5() == 0;
		}

		public long method_11()
		{
			return this.long_0;
		}

		public long method_12()
		{
			return this.long_1 - (long)this.method_13();
		}

		public int method_13()
		{
			return this.class187_0.method_3();
		}
	}
}
