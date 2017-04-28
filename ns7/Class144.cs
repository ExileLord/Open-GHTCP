using System;
using System.IO;
using ns11;

namespace ns7
{
	public class Class144
	{
		private static byte byte_0 = 128;

		private byte[] byte_1 = new byte[1024];

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private short short_0;

		private Stream stream_0;

		public virtual short vmethod_0()
		{
			return short_0;
		}

		public virtual bool vmethod_1()
		{
			return (int_2 & 7) == 0;
		}

		public Class144(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		private int method_0()
		{
			if (int_1 > 0 && int_0 > int_1)
			{
				Buffer.BlockCopy(byte_1, int_1, byte_1, 0, int_0 - int_1);
			}
			int_0 -= int_1;
			int_1 = 0;
			int num = byte_1.Length - int_0;
			num = stream_0.Read(byte_1, int_0, num);
			if (num <= 0)
			{
				throw new EndOfStreamException();
			}
			int_0 += num;
			int_3 += num << 3;
			return num;
		}

		public virtual void vmethod_2()
		{
			int_1 = 0;
			int_2 = 0;
			int_0 = 0;
			int_3 = 0;
		}

		public virtual void vmethod_3(short short_1)
		{
			short_0 = short_1;
		}

		public virtual int vmethod_4()
		{
			return 8 - (int_2 & 7);
		}

		public virtual void vmethod_5(int int_5)
		{
			if (int_5 == 0)
			{
				return;
			}
			int num = int_2 & 7;
			if (num != 0)
			{
				int num2 = Math.Min(8 - num, int_5);
				vmethod_10(num2);
				int_5 -= num2;
			}
			int num3 = int_5 / 8;
			if (num3 > 0)
			{
				vmethod_15(null, num3);
				int_5 %= 8;
			}
			if (int_5 > 0)
			{
				vmethod_10(int_5);
			}
		}

		public virtual int vmethod_6()
		{
			while (int_3 <= 0)
			{
				method_0();
			}
			int result = (((int)byte_1[int_1] & 128 >> int_2) != 0) ? 1 : 0;
			int_2++;
			if (int_2 == 8)
			{
				short_0 = Class150.smethod_0(byte_1[int_1], short_0);
				int_1++;
				int_2 = 0;
			}
			int_3--;
			int_4++;
			return result;
		}

		public virtual int vmethod_7(int int_5)
		{
			while (int_3 <= 0)
			{
				method_0();
			}
			int_5 <<= 1;
			int_5 |= ((((int)byte_1[int_1] & 128 >> int_2) != 0) ? 1 : 0);
			int_2++;
			if (int_2 == 8)
			{
				short_0 = Class150.smethod_0(byte_1[int_1], short_0);
				int_1++;
				int_2 = 0;
			}
			int_3--;
			int_4++;
			return int_5;
		}

		public virtual int vmethod_8(int int_5, int int_6)
		{
			while (int_6 >= int_3)
			{
				method_0();
			}
			int_5 <<= 1;
			if (int_2 + int_6 >= 8)
			{
				int_6 = (int_2 + int_6) % 8;
				int_5 |= ((((int)byte_1[int_1 + 1] & 128 >> int_6) != 0) ? 1 : 0);
			}
			else
			{
				int_5 |= ((((int)byte_1[int_1] & 128 >> int_2 + int_6) != 0) ? 1 : 0);
			}
			return int_5;
		}

		public virtual long vmethod_9(long long_0)
		{
			while (int_3 <= 0)
			{
				method_0();
			}
			long_0 <<= 1;
			long_0 |= ((((int)byte_1[int_1] & 128 >> int_2) != 0) ? 1L : 0L);
			int_2++;
			if (int_2 == 8)
			{
				short_0 = Class150.smethod_0(byte_1[int_1], short_0);
				int_1++;
				int_2 = 0;
			}
			int_3--;
			int_4++;
			return long_0;
		}

		public virtual int vmethod_10(int int_5)
		{
			int num = 0;
			for (int i = 0; i < int_5; i++)
			{
				num = vmethod_7(num);
			}
			return num;
		}

		public virtual int vmethod_11(int int_5)
		{
			int num = 0;
			for (int i = 0; i < int_5; i++)
			{
				num = vmethod_8(num, i);
			}
			return num;
		}

		public virtual int vmethod_12(int int_5)
		{
			if (int_5 == 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < int_5; i++)
			{
				num = vmethod_7(num);
			}
			int num2 = 32 - int_5;
			int num3;
			if (num2 != 0)
			{
				num <<= num2;
				num3 = num;
				num3 >>= num2;
			}
			else
			{
				num3 = num;
			}
			return num3;
		}

		public virtual long vmethod_13(int int_5)
		{
			long num = 0L;
			for (int i = 0; i < int_5; i++)
			{
				num = vmethod_9(num);
			}
			return num;
		}

		public virtual int vmethod_14()
		{
			int num = vmethod_10(8);
			int num2 = vmethod_10(8);
			num |= num2 << 8;
			num2 = vmethod_10(8);
			num |= num2 << 16;
			num2 = vmethod_10(8);
			return num | num2 << 24;
		}

		public virtual void vmethod_15(byte[] byte_2, int int_5)
		{
			int num = int_5;
			while (int_5 > 0)
			{
				int num2 = Math.Min(int_5, int_0 - int_1);
				if (num2 == 0)
				{
					method_0();
				}
				else
				{
					if (byte_2 != null)
					{
						Buffer.BlockCopy(byte_1, int_1, byte_2, num - int_5, num2);
					}
					int_5 -= num2;
					int_1 += num2;
					int_3 -= num2 << 3;
					int_4 += num2 << 3;
				}
			}
		}

		public virtual int vmethod_16()
		{
			int num = 0;
			while (true)
			{
				int num2 = vmethod_6();
				if (num2 != 0)
				{
					break;
				}
				num++;
			}
			return num;
		}

		public virtual void vmethod_17(int[] int_5, int int_6, int int_7, int int_8)
		{
			int i = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (int_7 == 0)
			{
				return;
			}
			int num6 = int_1;
			long num7 = int_1 * 8 + int_2;
			if (int_2 > 0)
			{
				byte b2;
				byte b = b2 = byte_1[num6];
				num = int_2;
				b = (byte)(b << (byte)num);
				int num9;
				while (true)
				{
					if (num5 == 0)
					{
						if (b == 0)
						{
							goto IL_13D;
						}
						int num8 = 0;
						while ((b & byte_0) == 0)
						{
							b = (byte)(b << 1);
							num8++;
						}
						num3 += num8;
						b = (byte)(b << 1);
						num8++;
						num += num8;
						num2 = 0;
						num4 = int_8;
						num5++;
						if (num == 8)
						{
							goto Block_8;
						}
					}
					else
					{
						num9 = 8 - num;
						if (num4 >= num9)
						{
							goto IL_15C;
						}
						num2 <<= num4;
						num2 |= (b & 255) >> 8 - num4;
						b = (byte)(b << (byte)num4);
						num += num4;
						num2 |= num3 << int_8;
						if ((num2 & 1) != 0)
						{
							int_5[int_6 + i++] = -(num2 >> 1) - 1;
						}
						else
						{
							int_5[int_6 + i++] = num2 >> 1;
						}
						if (i == int_7)
						{
							break;
						}
						num3 = 0;
						num5 = 0;
					}
				}
				num6--;
				goto IL_1D5;
				Block_8:
				num = 0;
				short_0 = Class150.smethod_0(b2, short_0);
				goto IL_1D5;
				IL_13D:
				num3 += 8 - num;
				num = 0;
				short_0 = Class150.smethod_0(b2, short_0);
				goto IL_1D5;
				IL_15C:
				num2 <<= num9;
				num2 |= (b & 255) >> num;
				num = 0;
				short_0 = Class150.smethod_0(b2, short_0);
				if (num4 == num9)
				{
					num2 |= num3 << int_8;
					if ((num2 & 1) != 0)
					{
						int_5[int_6 + i++] = -(num2 >> 1) - 1;
					}
					else
					{
						int_5[int_6 + i++] = num2 >> 1;
					}
					if (i == int_7)
					{
						goto IL_1D5;
					}
					num3 = 0;
					num5 = 0;
				}
				num4 -= num9;
				IL_1D5:
				num6++;
				int_1 = num6;
				int_2 = num;
			}
			while (i < int_7)
			{
				while (num6 < int_0 && i < int_7)
				{
					byte b2;
					byte b = b2 = byte_1[num6];
					num = 0;
					int num10;
					while (true)
					{
						if (num5 == 0)
						{
							if (b == 0)
							{
								goto IL_2EA;
							}
							int num8 = 0;
							while ((b & byte_0) == 0)
							{
								b = (byte)(b << 1);
								num8++;
							}
							num3 += num8;
							b = (byte)(b << 1);
							num8++;
							num += num8;
							num2 = 0;
							num4 = int_8;
							num5++;
							if (num == 8)
							{
								goto Block_19;
							}
						}
						else
						{
							num10 = 8 - num;
							if (num4 >= num10)
							{
								goto IL_309;
							}
							num2 <<= num4;
							num2 |= (b & 255) >> 8 - num4;
							b = (byte)(b << (byte)num4);
							num += num4;
							num2 |= num3 << int_8;
							if ((num2 & 1) != 0)
							{
								int_5[int_6 + i++] = -(num2 >> 1) - 1;
							}
							else
							{
								int_5[int_6 + i++] = num2 >> 1;
							}
							if (i == int_7)
							{
								goto Block_16;
							}
							num3 = 0;
							num5 = 0;
						}
					}
					IL_382:
					num6++;
					continue;
					Block_16:
					num6--;
					goto IL_382;
					Block_19:
					num = 0;
					short_0 = Class150.smethod_0(b2, short_0);
					goto IL_382;
					IL_2EA:
					num3 += 8 - num;
					num = 0;
					short_0 = Class150.smethod_0(b2, short_0);
					goto IL_382;
					IL_309:
					num2 <<= num10;
					num2 |= (b & 255) >> num;
					num = 0;
					short_0 = Class150.smethod_0(b2, short_0);
					if (num4 == num10)
					{
						num2 |= num3 << int_8;
						if ((num2 & 1) != 0)
						{
							int_5[int_6 + i++] = -(num2 >> 1) - 1;
						}
						else
						{
							int_5[int_6 + i++] = num2 >> 1;
						}
						if (i == int_7)
						{
							goto IL_382;
						}
						num3 = 0;
						num5 = 0;
					}
					num4 -= num10;
					goto IL_382;
				}
				int_1 = num6;
				int_2 = num;
				if (i < int_7)
				{
					long num11 = int_1 * 8 + int_2;
					int_4 = (int)(int_4 + num11 - num7);
					int_3 = (int)(int_3 - (num11 - num7));
					method_0();
					num6 = 0;
					num7 = int_1 * 8 + int_2;
				}
			}
			long num12 = int_1 * 8 + int_2;
			int_4 = (int)(int_4 + num12 - num7);
			int_3 = (int)(int_3 - (num12 - num7));
		}

		public virtual int vmethod_18(Class152 class152_0)
		{
			int num = vmethod_10(8);
			if (class152_0 != null)
			{
				class152_0.vmethod_1((byte)num);
			}
			int num2;
			int i;
			if ((num & 128) == 0)
			{
				num2 = num;
				i = 0;
			}
			else if ((num & 192) != 0 && (num & 32) == 0)
			{
				num2 = (num & 31);
				i = 1;
			}
			else if ((num & 224) != 0 && (num & 16) == 0)
			{
				num2 = (num & 15);
				i = 2;
			}
			else if ((num & 240) != 0 && (num & 8) == 0)
			{
				num2 = (num & 7);
				i = 3;
			}
			else if ((num & 248) != 0 && (num & 4) == 0)
			{
				num2 = (num & 3);
				i = 4;
			}
			else
			{
				if ((num & 252) == 0 || (num & 2) != 0)
				{
					return -1;
				}
				num2 = (num & 1);
				i = 5;
			}
			while (i > 0)
			{
				num = vmethod_11(8);
				if ((num & 128) == 0 || (num & 64) != 0)
				{
					return -1;
				}
				num = vmethod_10(8);
				if (class152_0 != null)
				{
					class152_0.vmethod_1((byte)num);
				}
				num2 <<= 6;
				num2 |= (num & 63);
				i--;
			}
			return num2;
		}

		public virtual long vmethod_19(Class152 class152_0)
		{
			int num = vmethod_10(8);
			if (class152_0 != null)
			{
				class152_0.vmethod_1((byte)num);
			}
			long num2;
			int i;
			if ((num & 128) == 0)
			{
				num2 = num;
				i = 0;
			}
			else if ((num & 192) != 0 && (num & 32) == 0)
			{
				num2 = num & 31;
				i = 1;
			}
			else if ((num & 224) != 0 && (num & 16) == 0)
			{
				num2 = num & 15;
				i = 2;
			}
			else if ((num & 240) != 0 && (num & 8) == 0)
			{
				num2 = num & 7;
				i = 3;
			}
			else if ((num & 248) != 0 && (num & 4) == 0)
			{
				num2 = num & 3;
				i = 4;
			}
			else if ((num & 252) != 0 && (num & 2) == 0)
			{
				num2 = num & 1;
				i = 5;
			}
			else
			{
				if ((num & 254) == 0 || (num & 1) != 0)
				{
					return -1L;
				}
				num2 = 0L;
				i = 6;
			}
			while (i > 0)
			{
				num = vmethod_11(8);
				if ((num & 128) == 0 || (num & 64) != 0)
				{
					return -1L;
				}
				num = vmethod_10(8);
				if (class152_0 != null)
				{
					class152_0.vmethod_1((byte)num);
				}
				num2 <<= 6;
				num2 |= num & 63;
				i--;
			}
			return num2;
		}
	}
}
