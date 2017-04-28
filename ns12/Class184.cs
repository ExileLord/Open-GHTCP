using System;
using ns13;

namespace ns12
{
	public class Class184 : Class183
	{
		private int int_6;

		private readonly short[] short_0;

		private readonly short[] short_1;

		private int int_7;

		private int int_8;

		private bool bool_0;

		private int int_9;

		private int int_10;

		private int int_11;

		private readonly byte[] byte_0;

		private Enum29 enum29_0;

		private int int_12;

		private int int_13;

		private int int_14;

		private int int_15;

		private int int_16;

		private byte[] byte_1;

		private int int_17;

		private int int_18;

		private int int_19;

		private readonly Class189 class189_0;

		private readonly Class190 class190_0;

		private readonly Class200 class200_0;

		public Class184(Class189 class189_1)
		{
			class189_0 = class189_1;
			class190_0 = new Class190(class189_1);
			class200_0 = new Class200();
			byte_0 = new byte[65536];
			short_0 = new short[32768];
			short_1 = new short[32768];
			int_10 = 1;
			int_9 = 1;
		}

		public bool method_0(bool bool_1, bool bool_2)
		{
			while (true)
			{
				method_7();
				var bool_3 = bool_1 && int_18 == int_19;
				bool flag;
				switch (int_16)
				{
				case 0:
					flag = method_12(bool_3, bool_2);
					goto IL_45;
				case 1:
					flag = method_13(bool_3, bool_2);
					goto IL_45;
				case 2:
					flag = method_14(bool_3, bool_2);
					goto IL_45;
				}
				break;
				IL_45:
				if (!class189_0.method_7())
				{
					return flag;
				}
				if (!flag)
				{
					return flag;
				}
			}
			throw new InvalidOperationException("unknown compressionFunction");
		}

		public void method_1(byte[] byte_2, int int_20, int int_21)
		{
			if (byte_2 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int_20 < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_21 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (int_18 < int_19)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			var num = int_20 + int_21;
			if (int_20 > num || num > byte_2.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			byte_1 = byte_2;
			int_18 = int_20;
			int_19 = num;
		}

		public bool method_2()
		{
			return int_19 == int_18;
		}

		public void method_3()
		{
			class190_0.method_0();
			class200_0.vmethod_1();
			int_10 = 1;
			int_9 = 1;
			int_11 = 0;
			int_17 = 0;
			bool_0 = false;
			int_8 = 2;
			for (var i = 0; i < 32768; i++)
			{
				short_0[i] = 0;
			}
			for (var j = 0; j < 32768; j++)
			{
				short_1[j] = 0;
			}
		}

		public void ResetAdler()
		{
			class200_0.vmethod_1();
		}

		public int method_4()
		{
			return (int)class200_0.vmethod_0();
		}

		public void method_5(Enum29 enum29_1)
		{
			enum29_0 = enum29_1;
		}

		public void method_6(int int_20)
		{
			if (int_20 >= 0 && int_20 <= 9)
			{
				int_15 = int_1[int_20];
				int_13 = int_2[int_20];
				int_14 = int_3[int_20];
				int_12 = int_4[int_20];
				if (int_5[int_20] != int_16)
				{
					switch (int_16)
					{
					case 0:
						if (int_10 > int_9)
						{
							class190_0.method_3(byte_0, int_9, int_10 - int_9, false);
							int_9 = int_10;
						}
						method_8();
						break;
					case 1:
						if (int_10 > int_9)
						{
							class190_0.method_4(byte_0, int_9, int_10 - int_9, false);
							int_9 = int_10;
						}
						break;
					case 2:
						if (bool_0)
						{
							class190_0.method_6(byte_0[int_10 - 1] & 255);
						}
						if (int_10 > int_9)
						{
							class190_0.method_4(byte_0, int_9, int_10 - int_9, false);
							int_9 = int_10;
						}
						bool_0 = false;
						int_8 = 2;
						break;
					}
					int_16 = int_5[int_20];
				}
				return;
			}
			throw new ArgumentOutOfRangeException("level");
		}

		public void method_7()
		{
			if (int_10 >= 65274)
			{
				method_10();
			}
			while (int_11 < 262 && int_18 < int_19)
			{
				var num = 65536 - int_11 - int_10;
				if (num > int_19 - int_18)
				{
					num = int_19 - int_18;
				}
				Array.Copy(byte_1, int_18, byte_0, int_10 + int_11, num);
				class200_0.vmethod_2(byte_1, int_18, num);
				int_18 += num;
				int_17 += num;
				int_11 += num;
			}
			if (int_11 >= 3)
			{
				method_8();
			}
		}

		private void method_8()
		{
			int_6 = (byte_0[int_10] << 5 ^ byte_0[int_10 + 1]);
		}

		private int method_9()
		{
			var num = (int_6 << 5 ^ byte_0[int_10 + 2]) & 32767;
			var num2 = short_1[int_10 & 32767] = short_0[num];
			short_0[num] = (short)int_10;
			int_6 = num;
			return num2 & 65535;
		}

		private void method_10()
		{
			Array.Copy(byte_0, 32768, byte_0, 0, 32768);
			int_7 -= 32768;
			int_10 -= 32768;
			int_9 -= 32768;
			for (var i = 0; i < 32768; i++)
			{
				var num = short_0[i] & 65535;
				short_0[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
			for (var j = 0; j < 32768; j++)
			{
				var num2 = short_1[j] & 65535;
				short_1[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
			}
		}

		private bool method_11(int int_20)
		{
			var num = int_12;
			var num2 = int_14;
			var array = short_1;
			var num3 = int_10;
			var num4 = int_10 + int_8;
			var num5 = Math.Max(int_8, 2);
			var num6 = Math.Max(int_10 - 32506, 0);
			var num7 = int_10 + 258 - 1;
			var b = byte_0[num4 - 1];
			var b2 = byte_0[num4];
			if (num5 >= int_15)
			{
				num >>= 2;
			}
			if (num2 > int_11)
			{
				num2 = int_11;
			}
			do
			{
				if (byte_0[int_20 + num5] == b2 && byte_0[int_20 + num5 - 1] == b && byte_0[int_20] == byte_0[num3] && byte_0[int_20 + 1] == byte_0[num3 + 1])
				{
					var num8 = int_20 + 2;
					num3 += 2;
					while (byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && byte_0[++num3] == byte_0[++num8] && num3 < num7)
					{
					}
					if (num3 > num4)
					{
						int_7 = int_20;
						num4 = num3;
						num5 = num3 - int_10;
						if (num5 >= num2)
						{
							break;
						}
						b = byte_0[num4 - 1];
						b2 = byte_0[num4];
					}
					num3 = int_10;
				}
				if ((int_20 = (array[int_20 & 32767] & 65535)) <= num6)
				{
					break;
				}
			}
			while (--num != 0);
			int_8 = Math.Min(num5, int_11);
			return int_8 >= 3;
		}

		private bool method_12(bool bool_1, bool bool_2)
		{
			if (!bool_1 && int_11 == 0)
			{
				return false;
			}
			int_10 += int_11;
			int_11 = 0;
			var num = int_10 - int_9;
			if (num < int_0 && (int_9 >= 32768 || num < 32506) && !bool_1)
			{
				return true;
			}
			var flag = bool_2;
			if (num > int_0)
			{
				num = int_0;
				flag = false;
			}
			class190_0.method_3(byte_0, int_9, num, flag);
			int_9 += num;
			return !flag;
		}

		private bool method_13(bool bool_1, bool bool_2)
		{
			if (int_11 < 262 && !bool_1)
			{
				return false;
			}
			while (int_11 >= 262 || bool_1)
			{
				if (int_11 == 0)
				{
					class190_0.method_4(byte_0, int_9, int_10 - int_9, bool_2);
					int_9 = int_10;
					return false;
				}
				if (int_10 > 65274)
				{
					method_10();
				}
				int num;
				if (int_11 >= 3 && (num = method_9()) != 0 && enum29_0 != Enum29.const_2 && int_10 - num <= 32506 && method_11(num))
				{
					var flag = class190_0.method_7(int_10 - int_7, int_8);
					int_11 -= int_8;
					if (int_8 <= int_13 && int_11 >= 3)
					{
						while (--int_8 > 0)
						{
							int_10++;
							method_9();
						}
						int_10++;
					}
					else
					{
						int_10 += int_8;
						if (int_11 >= 2)
						{
							method_8();
						}
					}
					int_8 = 2;
					if (!flag)
					{
						continue;
					}
				}
				else
				{
					class190_0.method_6(byte_0[int_10] & 255);
					int_10++;
					int_11--;
				}
				if (class190_0.method_5())
				{
					var flag2 = bool_2 && int_11 == 0;
					class190_0.method_4(byte_0, int_9, int_10 - int_9, flag2);
					int_9 = int_10;
					return !flag2;
				}
			}
			return true;
		}

		private bool method_14(bool bool_1, bool bool_2)
		{
			if (int_11 < 262 && !bool_1)
			{
				return false;
			}
			while (int_11 >= 262 || bool_1)
			{
				if (int_11 == 0)
				{
					if (bool_0)
					{
						class190_0.method_6(byte_0[int_10 - 1] & 255);
					}
					bool_0 = false;
					class190_0.method_4(byte_0, int_9, int_10 - int_9, bool_2);
					int_9 = int_10;
					return false;
				}
				if (int_10 >= 65274)
				{
					method_10();
				}
				var num = int_7;
				var num2 = int_8;
				if (int_11 >= 3)
				{
					var num3 = method_9();
					if (enum29_0 != Enum29.const_2 && num3 != 0 && int_10 - num3 <= 32506 && method_11(num3) && int_8 <= 5 && (enum29_0 == Enum29.const_1 || (int_8 == 3 && int_10 - int_7 > 4096)))
					{
						int_8 = 2;
					}
				}
				if (num2 >= 3 && int_8 <= num2)
				{
					class190_0.method_7(int_10 - 1 - num, num2);
					num2 -= 2;
					do
					{
						int_10++;
						int_11--;
						if (int_11 >= 3)
						{
							method_9();
						}
					}
					while (--num2 > 0);
					int_10++;
					int_11--;
					bool_0 = false;
					int_8 = 2;
				}
				else
				{
					if (bool_0)
					{
						class190_0.method_6(byte_0[int_10 - 1] & 255);
					}
					bool_0 = true;
					int_10++;
					int_11--;
				}
				if (class190_0.method_5())
				{
					var num4 = int_10 - int_9;
					if (bool_0)
					{
						num4--;
					}
					var flag = bool_2 && int_11 == 0 && !bool_0;
					class190_0.method_4(byte_0, int_9, num4, flag);
					int_9 += num4;
					return !flag;
				}
			}
			return true;
		}
	}
}
