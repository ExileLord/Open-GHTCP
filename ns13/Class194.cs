using System;
using ns12;

namespace ns13
{
	public class Class194
	{
		private int int_0;

		private readonly bool bool_0;

		private int int_1;

		private long long_0;

		private readonly Class189 class189_0;

		private readonly Class184 class184_0;

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
			class189_0 = new Class189();
			class184_0 = new Class184(class189_0);
			bool_0 = bool_1;
			method_8(Enum29.const_0);
			method_7(int_2);
			method_0();
		}

		public void method_0()
		{
			int_1 = (bool_0 ? 16 : 0);
			long_0 = 0L;
			class189_0.method_0();
			class184_0.method_3();
		}

		public long method_1()
		{
			return long_0;
		}

		public void method_2()
		{
			int_1 |= 4;
		}

		public void method_3()
		{
			int_1 |= 12;
		}

		public bool method_4()
		{
			return int_1 == 30 && class189_0.method_7();
		}

		public bool method_5()
		{
			return class184_0.method_2();
		}

		public void method_6(byte[] byte_0, int int_2, int int_3)
		{
			if ((int_1 & 8) != 0)
			{
				throw new InvalidOperationException("Finish() already called");
			}
			class184_0.method_1(byte_0, int_2, int_3);
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
			if (int_0 != int_2)
			{
				int_0 = int_2;
				class184_0.method_6(int_2);
			}
		}

		public void method_8(Enum29 enum29_0)
		{
			class184_0.method_5(enum29_0);
		}

		public int method_9(byte[] byte_0, int int_2, int int_3)
		{
			var num = int_3;
			if (int_1 == 127)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (int_1 < 16)
			{
				var num2 = 30720;
				var num3 = int_0 - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((int_1 & 1) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				class189_0.method_6(num2);
				if ((int_1 & 1) != 0)
				{
					var num4 = class184_0.method_4();
					class184_0.ResetAdler();
					class189_0.method_6(num4 >> 16);
					class189_0.method_6(num4 & 65535);
				}
				int_1 = (16 | (int_1 & 12));
			}
			while (true)
			{
				var num5 = class189_0.method_8(byte_0, int_2, int_3);
				int_2 += num5;
				long_0 += num5;
				int_3 -= num5;
				if (int_3 == 0 || int_1 == 30)
				{
					goto IL_1E2;
				}
				if (!class184_0.method_0((int_1 & 4) != 0, (int_1 & 8) != 0))
				{
					if (int_1 == 16)
					{
						break;
					}
					if (int_1 == 20)
					{
						if (int_0 != 0)
						{
							for (var i = 8 + (-class189_0.method_3() & 7); i > 0; i -= 10)
							{
								class189_0.method_5(2, 10);
							}
						}
						int_1 = 16;
					}
					else if (int_1 == 28)
					{
						class189_0.method_4();
						if (!bool_0)
						{
							var num6 = class184_0.method_4();
							class189_0.method_6(num6 >> 16);
							class189_0.method_6(num6 & 65535);
						}
						int_1 = 30;
					}
				}
			}
			return num - int_3;
			IL_1E2:
			return num - int_3;
		}
	}
}
