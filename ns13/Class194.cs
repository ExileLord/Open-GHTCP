using ns12;
using System;

namespace ns13
{
	public class Class194
	{
		private int int_0;

		private bool bool_0;

		private int int_1;

		private long long_0;

		private Class189 class189_0;

		private Class184 class184_0;

		public Class194() : this(-1, false)
		{
		}

		public Class194(int int_2, bool bool_1)
		{
			if (int_2 == -1)
			{
				int_2 = 6;
			}
			else if (int_2 < 0 || int_2 > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			this.class189_0 = new Class189();
			this.class184_0 = new Class184(this.class189_0);
			this.bool_0 = bool_1;
			this.method_8(Enum29.const_0);
			this.method_7(int_2);
			this.method_0();
		}

		public void method_0()
		{
			this.int_1 = (this.bool_0 ? 16 : 0);
			this.long_0 = 0L;
			this.class189_0.method_0();
			this.class184_0.method_3();
		}

		public long method_1()
		{
			return this.long_0;
		}

		public void method_2()
		{
			this.int_1 |= 4;
		}

		public void method_3()
		{
			this.int_1 |= 12;
		}

		public bool method_4()
		{
			return this.int_1 == 30 && this.class189_0.method_7();
		}

		public bool method_5()
		{
			return this.class184_0.method_2();
		}

		public void method_6(byte[] byte_0, int int_2, int int_3)
		{
			if ((this.int_1 & 8) != 0)
			{
				throw new InvalidOperationException("Finish() already called");
			}
			this.class184_0.method_1(byte_0, int_2, int_3);
		}

		public void method_7(int int_2)
		{
			if (int_2 == -1)
			{
				int_2 = 6;
			}
			else if (int_2 < 0 || int_2 > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			if (this.int_0 != int_2)
			{
				this.int_0 = int_2;
				this.class184_0.method_6(int_2);
			}
		}

		public void method_8(Enum29 enum29_0)
		{
			this.class184_0.method_5(enum29_0);
		}

		public int method_9(byte[] byte_0, int int_2, int int_3)
		{
			int num = int_3;
			if (this.int_1 == 127)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.int_1 < 16)
			{
				int num2 = 30720;
				int num3 = this.int_0 - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((this.int_1 & 1) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				this.class189_0.method_6(num2);
				if ((this.int_1 & 1) != 0)
				{
					int num4 = this.class184_0.method_4();
					this.class184_0.ResetAdler();
					this.class189_0.method_6(num4 >> 16);
					this.class189_0.method_6(num4 & 65535);
				}
				this.int_1 = (16 | (this.int_1 & 12));
			}
			while (true)
			{
				int num5 = this.class189_0.method_8(byte_0, int_2, int_3);
				int_2 += num5;
				this.long_0 += (long)num5;
				int_3 -= num5;
				if (int_3 == 0 || this.int_1 == 30)
				{
					goto IL_1E2;
				}
				if (!this.class184_0.method_0((this.int_1 & 4) != 0, (this.int_1 & 8) != 0))
				{
					if (this.int_1 == 16)
					{
						break;
					}
					if (this.int_1 == 20)
					{
						if (this.int_0 != 0)
						{
							for (int i = 8 + (-this.class189_0.method_3() & 7); i > 0; i -= 10)
							{
								this.class189_0.method_5(2, 10);
							}
						}
						this.int_1 = 16;
					}
					else if (this.int_1 == 28)
					{
						this.class189_0.method_4();
						if (!this.bool_0)
						{
							int num6 = this.class184_0.method_4();
							this.class189_0.method_6(num6 >> 16);
							this.class189_0.method_6(num6 & 65535);
						}
						this.int_1 = 30;
					}
				}
			}
			return num - int_3;
			IL_1E2:
			return num - int_3;
		}
	}
}
