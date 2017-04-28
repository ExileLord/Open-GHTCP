using System;
using System.IO;
using System.Security.Cryptography;

namespace ns0
{
	public class Class2
	{
		public class Class3
		{
			private static int[] int_0 = {
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

			private static int[] int_1 = {
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

			private static int[] int_2 = {
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

			private static int[] int_3 = {
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

			private bool bool_0;

			private Class4 class4_0;

			private Class5 class5_0;

			private Class7 class7_0;

			private Class6 class6_0;

			private Class6 class6_1;

			public Class3(byte[] byte_0)
			{
				class4_0 = new Class4();
				class5_0 = new Class5();
				int_4 = 2;
				class4_0.method_7(byte_0, 0, byte_0.Length);
			}

			private bool method_0()
			{
				var i = class5_0.method_4();
				while (i >= 258)
				{
					int num;
					switch (int_4)
					{
					case 7:
						while (((num = class6_0.method_1(class4_0)) & -256) == 0)
						{
							class5_0.method_0(num);
							if (--i < 258)
							{
								return true;
							}
						}
						if (num >= 257)
						{
							int_6 = int_0[num - 257];
							int_5 = int_1[num - 257];
							goto IL_9E;
						}
						if (num < 0)
						{
							return false;
						}
						class6_1 = null;
						class6_0 = null;
						int_4 = 2;
						return true;
					case 8:
						goto IL_9E;
					case 9:
						goto IL_EE;
					case 10:
						break;
					default:
						continue;
					}
					IL_121:
					if (int_5 > 0)
					{
						int_4 = 10;
						var num2 = class4_0.method_0(int_5);
						if (num2 < 0)
						{
							return false;
						}
						class4_0.method_1(int_5);
						int_7 += num2;
					}
					class5_0.method_2(int_6, int_7);
					i -= int_6;
					int_4 = 7;
					continue;
					IL_EE:
					num = class6_1.method_1(class4_0);
					if (num >= 0)
					{
						int_7 = int_2[num];
						int_5 = int_3[num];
						goto IL_121;
					}
					return false;
					IL_9E:
					if (int_5 > 0)
					{
						int_4 = 8;
						var num3 = class4_0.method_0(int_5);
						if (num3 < 0)
						{
							return false;
						}
						class4_0.method_1(int_5);
						int_6 += num3;
					}
					int_4 = 9;
					goto IL_EE;
				}
				return true;
			}

			private bool method_1()
			{
				switch (int_4)
				{
				case 2:
				{
					if (bool_0)
					{
						int_4 = 12;
						return false;
					}
					var num = class4_0.method_0(3);
					if (num < 0)
					{
						return false;
					}
					class4_0.method_1(3);
					if ((num & 1) != 0)
					{
						bool_0 = true;
					}
					switch (num >> 1)
					{
					case 0:
						class4_0.method_4();
						int_4 = 3;
						break;
					case 1:
						class6_0 = Class6.class6_0;
						class6_1 = Class6.class6_1;
						int_4 = 7;
						break;
					case 2:
						class7_0 = new Class7();
						int_4 = 6;
						break;
					}
					return true;
				}
				case 3:
					if ((int_8 = class4_0.method_0(16)) < 0)
					{
						return false;
					}
					class4_0.method_1(16);
					int_4 = 4;
					break;
				case 4:
					break;
				case 5:
					goto IL_137;
				case 6:
					if (!class7_0.method_0(class4_0))
					{
						return false;
					}
					class6_0 = class7_0.method_1();
					class6_1 = class7_0.method_2();
					int_4 = 7;
					goto IL_1BB;
				case 7:
				case 8:
				case 9:
				case 10:
					goto IL_1BB;
				case 11:
					return false;
				case 12:
					return false;
				default:
					return false;
				}
				var num2 = class4_0.method_0(16);
				if (num2 < 0)
				{
					return false;
				}
				class4_0.method_1(16);
				int_4 = 5;
				IL_137:
				var num3 = class5_0.method_3(class4_0, int_8);
				int_8 -= num3;
				if (int_8 == 0)
				{
					int_4 = 2;
					return true;
				}
				return !class4_0.method_5();
				IL_1BB:
				return method_0();
			}

			public int method_2(byte[] byte_0, int int_9, int int_10)
			{
				var num = 0;
				while (true)
				{
					if (int_4 != 11)
					{
						var num2 = class5_0.method_6(byte_0, int_9, int_10);
						int_9 += num2;
						num += num2;
						int_10 -= num2;
						if (int_10 == 0)
						{
							return num;
						}
					}
					if (!method_1())
					{
						if (class5_0.method_5() <= 0)
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
		}

		public class Class4
		{
			private byte[] byte_0;

			private int int_0;

			private int int_1;

			private uint uint_0;

			private int int_2;

			public int method_0(int int_3)
			{
				if (int_2 < int_3)
				{
					if (int_0 == int_1)
					{
						return -1;
					}
					uint_0 |= (uint)(byte_0[int_0++] & 255 | (byte_0[int_0++] & 255) << 8) << int_2;
					int_2 += 16;
				}
				return (int)(uint_0 & (ulong)((1 << int_3) - 1));
			}

			public void method_1(int int_3)
			{
				uint_0 >>= int_3;
				int_2 -= int_3;
			}

			public int method_2()
			{
				return int_2;
			}

			public int method_3()
			{
				return int_1 - int_0 + (int_2 >> 3);
			}

			public void method_4()
			{
				uint_0 >>= (int_2 & 7);
				int_2 &= -8;
			}

			public bool method_5()
			{
				return int_0 == int_1;
			}

			public int method_6(byte[] byte_1, int int_3, int int_4)
			{
				var num = 0;
				while (int_2 > 0 && int_4 > 0)
				{
					byte_1[int_3++] = (byte)uint_0;
					uint_0 >>= 8;
					int_2 -= 8;
					int_4--;
					num++;
				}
				if (int_4 == 0)
				{
					return num;
				}
				var num2 = int_1 - int_0;
				if (int_4 > num2)
				{
					int_4 = num2;
				}
				Array.Copy(byte_0, int_0, byte_1, int_3, int_4);
				int_0 += int_4;
				if ((int_0 - int_1 & 1) != 0)
				{
					uint_0 = (uint)(byte_0[int_0++] & 255);
					int_2 = 8;
				}
				return num + int_4;
			}

			public void method_7(byte[] byte_1, int int_3, int int_4)
			{
				if (int_0 < int_1)
				{
					throw new InvalidOperationException();
				}
				var num = int_3 + int_4;
				if (0 <= int_3 && int_3 <= num && num <= byte_1.Length)
				{
					if ((int_4 & 1) != 0)
					{
						uint_0 |= (uint)(byte_1[int_3++] & 255) << int_2;
						int_2 += 8;
					}
					byte_0 = byte_1;
					int_0 = int_3;
					int_1 = num;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		public class Class5
		{
			private static int int_0 = 32768;

			private static int int_1 = int_0 - 1;

			private byte[] byte_0 = new byte[int_0];

			private int int_2;

			private int int_3;

			public void method_0(int int_4)
			{
				if (int_3++ == int_0)
				{
					throw new InvalidOperationException();
				}
				byte_0[int_2++] = (byte)int_4;
				int_2 &= int_1;
			}

			private void method_1(int int_4, int int_5, int int_6)
			{
				while (int_5-- > 0)
				{
					byte_0[int_2++] = byte_0[int_4++];
					int_2 &= int_1;
					int_4 &= int_1;
				}
			}

			public void method_2(int int_4, int int_5)
			{
				if ((int_3 += int_4) > int_0)
				{
					throw new InvalidOperationException();
				}
				var num = int_2 - int_5 & int_1;
				var num2 = int_0 - int_4;
				if (num > num2 || int_2 >= num2)
				{
					method_1(num, int_4, int_5);
					return;
				}
				if (int_4 <= int_5)
				{
					Array.Copy(byte_0, num, byte_0, int_2, int_4);
					int_2 += int_4;
					return;
				}
				while (int_4-- > 0)
				{
					byte_0[int_2++] = byte_0[num++];
				}
			}

			public int method_3(Class4 class4_0, int int_4)
			{
				int_4 = Math.Min(Math.Min(int_4, int_0 - int_3), class4_0.method_3());
				var num = int_0 - int_2;
				int num2;
				if (int_4 > num)
				{
					num2 = class4_0.method_6(byte_0, int_2, num);
					if (num2 == num)
					{
						num2 += class4_0.method_6(byte_0, 0, int_4 - num);
					}
				}
				else
				{
					num2 = class4_0.method_6(byte_0, int_2, int_4);
				}
				int_2 = (int_2 + num2 & int_1);
				int_3 += num2;
				return num2;
			}

			public int method_4()
			{
				return int_0 - int_3;
			}

			public int method_5()
			{
				return int_3;
			}

			public int method_6(byte[] byte_1, int int_4, int int_5)
			{
				var num = int_2;
				if (int_5 > int_3)
				{
					int_5 = int_3;
				}
				else
				{
					num = (int_2 - int_3 + int_5 & int_1);
				}
				var num2 = int_5;
				var num3 = int_5 - num;
				if (num3 > 0)
				{
					Array.Copy(byte_0, int_0 - num3, byte_1, int_4, num3);
					int_4 += num3;
					int_5 = num;
				}
				Array.Copy(byte_0, num - int_5, byte_1, int_4, int_5);
				int_3 -= num2;
				if (int_3 < 0)
				{
					throw new InvalidOperationException();
				}
				return num2;
			}
		}

		public class Class6
		{
			private static int int_0;

			private short[] short_0;

			public static Class6 class6_0;

			public static Class6 class6_1;

			static Class6()
			{
				int_0 = 15;
				var array = new byte[288];
				var i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				class6_0 = new Class6(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				class6_1 = new Class6(array);
			}

			public Class6(byte[] byte_0)
			{
				method_0(byte_0);
			}

			private void method_0(byte[] byte_0)
			{
				var array = new int[int_0 + 1];
				var array2 = new int[int_0 + 1];
				for (var i = 0; i < byte_0.Length; i++)
				{
					int num = byte_0[i];
					if (num > 0)
					{
						array[num]++;
					}
				}
				var num2 = 0;
				var num3 = 512;
				for (var j = 1; j <= int_0; j++)
				{
					array2[j] = num2;
					num2 += array[j] << 16 - j;
					if (j >= 10)
					{
						var num4 = array2[j] & 130944;
						var num5 = num2 & 130944;
						num3 += num5 - num4 >> 16 - j;
					}
				}
				short_0 = new short[num3];
				var num6 = 512;
				for (var k = int_0; k >= 10; k--)
				{
					var num7 = num2 & 130944;
					num2 -= array[k] << 16 - k;
					var num8 = num2 & 130944;
					for (var l = num8; l < num7; l += 128)
					{
						short_0[Class8.smethod_0(l)] = (short)(-num6 << 4 | k);
						num6 += 1 << k - 9;
					}
				}
				for (var m = 0; m < byte_0.Length; m++)
				{
					int num9 = byte_0[m];
					if (num9 != 0)
					{
						num2 = array2[num9];
						int num10 = Class8.smethod_0(num2);
						if (num9 <= 9)
						{
							do
							{
								short_0[num10] = (short)(m << 4 | num9);
								num10 += 1 << num9;
							}
							while (num10 < 512);
						}
						else
						{
							int num11 = short_0[num10 & 511];
							var num12 = 1 << (num11 & 15);
							num11 = -(num11 >> 4);
							do
							{
								short_0[num11 | num10 >> 9] = (short)(m << 4 | num9);
								num10 += 1 << num9;
							}
							while (num10 < num12);
						}
						array2[num9] = num2 + (1 << 16 - num9);
					}
				}
			}

			public int method_1(Class4 class4_0)
			{
				int num;
				if ((num = class4_0.method_0(9)) >= 0)
				{
					int num2;
					if ((num2 = short_0[num]) >= 0)
					{
						class4_0.method_1(num2 & 15);
						return num2 >> 4;
					}
					var num3 = -(num2 >> 4);
					var int_ = num2 & 15;
					if ((num = class4_0.method_0(int_)) >= 0)
					{
						num2 = short_0[num3 | num >> 9];
						class4_0.method_1(num2 & 15);
						return num2 >> 4;
					}
					var num4 = class4_0.method_2();
					num = class4_0.method_0(num4);
					num2 = short_0[num3 | num >> 9];
					if ((num2 & 15) <= num4)
					{
						class4_0.method_1(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
				else
				{
					var num5 = class4_0.method_2();
					num = class4_0.method_0(num5);
					int num2 = short_0[num];
					if (num2 >= 0 && (num2 & 15) <= num5)
					{
						class4_0.method_1(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
			}
		}

		public class Class7
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

			private byte[] byte_0;

			private byte[] byte_1;

			private Class6 class6_0;

			private int int_2;

			private int int_3;

			private int int_4;

			private int int_5;

			private int int_6;

			private int int_7;

			private byte byte_2;

			private int int_8;

			private static readonly int[] int_9 = {
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

			public bool method_0(Class4 class4_0)
			{
				while (true)
				{
					switch (int_2)
					{
					case 0:
						int_3 = class4_0.method_0(5);
						if (int_3 >= 0)
						{
							int_3 += 257;
							class4_0.method_1(5);
							int_2 = 1;
							goto IL_1DD;
						}
						return false;
					case 1:
						goto IL_1DD;
					case 2:
						goto IL_18F;
					case 3:
						goto IL_156;
					case 4:
						break;
					case 5:
						goto IL_2C;
					default:
						continue;
					}
					IL_E1:
					int num;
					while (((num = class6_0.method_1(class4_0)) & -16) == 0)
					{
						byte_1[int_8++] = (byte_2 = (byte)num);
						if (int_8 == int_6)
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
						int_7 = num - 16;
						int_2 = 5;
						goto IL_2C;
					}
					return false;
					IL_156:
					while (int_8 < int_5)
					{
						var num2 = class4_0.method_0(3);
						if (num2 < 0)
						{
							return false;
						}
						class4_0.method_1(3);
						byte_0[int_9[int_8]] = (byte)num2;
						int_8++;
					}
					class6_0 = new Class6(byte_0);
					byte_0 = null;
					int_8 = 0;
					int_2 = 4;
					goto IL_E1;
					IL_2C:
					var num3 = int_1[int_7];
					var num4 = class4_0.method_0(num3);
					if (num4 < 0)
					{
						return false;
					}
					class4_0.method_1(num3);
					num4 += int_0[int_7];
					while (num4-- > 0)
					{
						byte_1[int_8++] = byte_2;
					}
					if (int_8 == int_6)
					{
						break;
					}
					int_2 = 4;
					continue;
					IL_18F:
					int_5 = class4_0.method_0(4);
					if (int_5 >= 0)
					{
						int_5 += 4;
						class4_0.method_1(4);
						byte_0 = new byte[19];
						int_8 = 0;
						int_2 = 3;
						goto IL_156;
					}
					return false;
					IL_1DD:
					int_4 = class4_0.method_0(5);
					if (int_4 >= 0)
					{
						int_4++;
						class4_0.method_1(5);
						int_6 = int_3 + int_4;
						byte_1 = new byte[int_6];
						int_2 = 2;
						goto IL_18F;
					}
					return false;
				}
				return true;
			}

			public Class6 method_1()
			{
				var destinationArray = new byte[int_3];
				Array.Copy(byte_1, 0, destinationArray, 0, int_3);
				return new Class6(destinationArray);
			}

			public Class6 method_2()
			{
				var destinationArray = new byte[int_4];
				Array.Copy(byte_1, int_3, destinationArray, 0, int_4);
				return new Class6(destinationArray);
			}
		}

		public class Class8
		{
			private static int int_0;

			private static int int_1;

			private static int int_2;

			private static int int_3;

			private static int int_4;

			private static int int_5;

			private static int int_6;

			private static int int_7;

			private static int[] int_8;

			private static byte[] byte_0;

			private static short[] short_0;

			private static byte[] byte_1;

			private static short[] short_1;

			private static byte[] byte_2;

			public static short smethod_0(int int_9)
			{
				return (short)(byte_0[int_9 & 15] << 12 | byte_0[int_9 >> 4 & 15] << 8 | byte_0[int_9 >> 8 & 15] << 4 | byte_0[int_9 >> 12]);
			}

			static Class8()
			{
				int_0 = 16384;
				int_1 = 286;
				int_2 = 30;
				int_3 = 19;
				int_4 = 16;
				int_5 = 17;
				int_6 = 18;
				int_7 = 256;
				int_8 = new[]
				{
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
				byte_0 = new byte[]
				{
					0,
					8,
					4,
					12,
					2,
					10,
					6,
					14,
					1,
					9,
					5,
					13,
					3,
					11,
					7,
					15
				};
				short_0 = new short[int_1];
				byte_1 = new byte[int_1];
				var i = 0;
				while (i < 144)
				{
					short_0[i] = smethod_0(48 + i << 8);
					byte_1[i++] = 8;
				}
				while (i < 256)
				{
					short_0[i] = smethod_0(256 + i << 7);
					byte_1[i++] = 9;
				}
				while (i < 280)
				{
					short_0[i] = smethod_0(-256 + i << 9);
					byte_1[i++] = 7;
				}
				while (i < int_1)
				{
					short_0[i] = smethod_0(-88 + i << 8);
					byte_1[i++] = 8;
				}
				short_1 = new short[int_2];
				byte_2 = new byte[int_2];
				for (i = 0; i < int_2; i++)
				{
					short_1[i] = smethod_0(i << 11);
					byte_2[i] = 5;
				}
			}
		}

		public class Stream0 : MemoryStream
		{
			public int method_0()
			{
				return ReadByte() | ReadByte() << 8;
			}

			public int method_1()
			{
				return method_0() | method_0() << 16;
			}

			public Stream0(byte[] byte_0) : base(byte_0, false)
			{
			}
		}

		public static byte[] smethod_0(byte[] byte_0)
		{
			var stream = new Stream0(byte_0);
			var array = new byte[0];
			var num = stream.method_1();
			if (num == 67324752)
			{
				var num2 = (short)stream.method_0();
				var num3 = stream.method_0();
				var num4 = stream.method_0();
				if (num == 67324752 && num2 == 20 && num3 == 0)
				{
					if (num4 == 8)
					{
						stream.method_1();
						stream.method_1();
						stream.method_1();
						var num5 = stream.method_1();
						var num6 = stream.method_0();
						var num7 = stream.method_0();
						if (num6 > 0)
						{
							var buffer = new byte[num6];
							stream.Read(buffer, 0, num6);
						}
						if (num7 > 0)
						{
							var buffer2 = new byte[num7];
							stream.Read(buffer2, 0, num7);
						}
						var array2 = new byte[stream.Length - stream.Position];
						stream.Read(array2, 0, array2.Length);
						var @class = new Class3(array2);
						array = new byte[num5];
						@class.method_2(array, 0, array.Length);
						goto IL_1FF;
					}
				}
				throw new FormatException("Wrong Header Signature");
			}
			var num8 = num >> 24;
			num -= num8 << 24;
			if (num != 8223355)
			{
				throw new FormatException("Unknown Header");
			}
			if (num8 == 1)
			{
				var num9 = stream.method_1();
				array = new byte[num9];
				int num11;
				for (var i = 0; i < num9; i += num11)
				{
					var num10 = stream.method_1();
					num11 = stream.method_1();
					var array3 = new byte[num10];
					stream.Read(array3, 0, array3.Length);
					var class2 = new Class3(array3);
					class2.method_2(array, i, num11);
				}
			}
			if (num8 == 2)
			{
				var dESCryptoServiceProvider = new DESCryptoServiceProvider();
				dESCryptoServiceProvider.Key = new byte[]
				{
					162,
					181,
					141,
					204,
					197,
					202,
					205,
					58
				};
				dESCryptoServiceProvider.IV = new byte[]
				{
					83,
					253,
					177,
					222,
					83,
					112,
					167,
					112
				};
				var cryptoTransform = dESCryptoServiceProvider.CreateDecryptor();
				var byte_ = cryptoTransform.TransformFinalBlock(byte_0, 4, byte_0.Length - 4);
				dESCryptoServiceProvider.Clear();
				array = smethod_0(byte_);
			}
			IL_1FF:
			stream.Close();
			return array;
		}
	}
}
