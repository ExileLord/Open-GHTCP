using System;

namespace ns0
{
	public static class Class11
	{
		public static short smethod_0(byte byte_0)
		{
			return (short)(byte_0 - 128 << 8);
		}

		public static Struct8 smethod_1(byte byte_0)
		{
			return Struct8.smethod_1(byte_0 - 128 << 16);
		}

		public static int smethod_2(byte byte_0)
		{
			return byte_0 - 128 << 24;
		}

		public static float smethod_3(byte byte_0)
		{
			return (byte_0 - 128) * 1f / 128f;
		}

		public static byte smethod_4(short short_0)
		{
			return (byte)((short_0 >> 8) + 128);
		}

		public static Struct8 smethod_5(short short_0)
		{
			return Struct8.smethod_1(short_0 << 8);
		}

		public static int smethod_6(short short_0)
		{
			return short_0 << 16;
		}

		public static float smethod_7(short short_0)
		{
			return short_0 * 1f / 32768f;
		}

		public static byte smethod_8(Struct8 struct8_0)
		{
			return (byte)(Struct8.smethod_0(Struct8.smethod_5(struct8_0, 16)) + 128);
		}

		public static short smethod_9(Struct8 struct8_0)
		{
			return (short)Struct8.smethod_0(Struct8.smethod_5(struct8_0, 8));
		}

		public static int smethod_10(Struct8 struct8_0)
		{
			return Struct8.smethod_0(Struct8.smethod_6(struct8_0, 8));
		}

		public static float smethod_11(Struct8 struct8_0)
		{
			return Struct8.smethod_0(struct8_0) * 1f / 8388608f;
		}

		public static byte smethod_12(int int_0)
		{
			return (byte)((int_0 >> 24) + 128);
		}

		public static short smethod_13(int int_0)
		{
			return (short)(int_0 >> 16);
		}

		public static Struct8 smethod_14(int int_0)
		{
			return Struct8.smethod_1(int_0 >> 8);
		}

		public static float smethod_15(int int_0)
		{
			return int_0 * 1f / 2.14748365E+09f;
		}

		public static byte smethod_16(double double_0)
		{
			double num = Math.Round(double_0 * 127.0) + 128.0;
			if (num > 255.0)
			{
				return 255;
			}
			if (num >= 0.0)
			{
				return (byte)num;
			}
			return 0;
		}

		public static byte smethod_17(float float_0)
		{
			return smethod_16(float_0);
		}

		public static sbyte smethod_18(double double_0)
		{
			double num = Math.Round(double_0 * 127.0);
			if (num > 127.0)
			{
				return 127;
			}
			if (num >= -128.0)
			{
				return (sbyte)num;
			}
			return -128;
		}

		public static sbyte smethod_19(float float_0)
		{
			return smethod_18(float_0);
		}

		public static short smethod_20(double double_0)
		{
			double num = Math.Round(double_0 * 32767.0);
			if (num > 32767.0)
			{
				return 32767;
			}
			if (num >= -32768.0)
			{
				return (short)num;
			}
			return -32768;
		}

		public static short smethod_21(float float_0)
		{
			return smethod_20(float_0);
		}

		public static Struct8 smethod_22(double double_0)
		{
			double num = Math.Round(double_0 * 8388607.0);
			return Struct8.smethod_1((num > 8388607.0) ? 8388607 : ((num < -8388608.0) ? -8388608 : ((int)num)));
		}

		public static Struct8 smethod_23(float float_0)
		{
			return smethod_22(float_0);
		}

		public static int smethod_24(double double_0)
		{
			double num = Math.Round(double_0 * 2147483647.0);
			if (num > 2147483647.0)
			{
				return 2147483647;
			}
			if (num >= -2147483648.0)
			{
				return (int)num;
			}
			return -2147483648;
		}

		public static int smethod_25(float float_0)
		{
			return smethod_24(float_0);
		}

		public static float smethod_26(double double_0)
		{
			return (float)double_0;
		}
	}
}
