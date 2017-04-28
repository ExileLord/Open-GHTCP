using System;
using System.IO;
using ns11;

namespace ns7
{
	public class Class144
	{
		private static readonly byte Byte0 = 128;

		private readonly byte[] _byte1 = new byte[1024];

		private int _int0;

		private int _int1;

		private int _int2;

		private int _int3;

		private int _int4;

		private short _short0;

		private readonly Stream _stream0;

		public virtual short vmethod_0()
		{
			return _short0;
		}

		public virtual bool vmethod_1()
		{
			return (_int2 & 7) == 0;
		}

		public Class144(Stream stream1)
		{
			_stream0 = stream1;
		}

		private int method_0()
		{
			if (_int1 > 0 && _int0 > _int1)
			{
				Buffer.BlockCopy(_byte1, _int1, _byte1, 0, _int0 - _int1);
			}
			_int0 -= _int1;
			_int1 = 0;
			var num = _byte1.Length - _int0;
			num = _stream0.Read(_byte1, _int0, num);
			if (num <= 0)
			{
				throw new EndOfStreamException();
			}
			_int0 += num;
			_int3 += num << 3;
			return num;
		}

		public virtual void vmethod_2()
		{
			_int1 = 0;
			_int2 = 0;
			_int0 = 0;
			_int3 = 0;
		}

		public virtual void vmethod_3(short short1)
		{
			_short0 = short1;
		}

		public virtual int vmethod_4()
		{
			return 8 - (_int2 & 7);
		}

		public virtual void vmethod_5(int int5)
		{
			if (int5 == 0)
			{
				return;
			}
			var num = _int2 & 7;
			if (num != 0)
			{
				var num2 = Math.Min(8 - num, int5);
				vmethod_10(num2);
				int5 -= num2;
			}
			var num3 = int5 / 8;
			if (num3 > 0)
			{
				vmethod_15(null, num3);
				int5 %= 8;
			}
			if (int5 > 0)
			{
				vmethod_10(int5);
			}
		}

		public virtual int vmethod_6()
		{
			while (_int3 <= 0)
			{
				method_0();
			}
			var result = (((int)_byte1[_int1] & 128 >> _int2) != 0) ? 1 : 0;
			_int2++;
			if (_int2 == 8)
			{
				_short0 = Class150.smethod_0(_byte1[_int1], _short0);
				_int1++;
				_int2 = 0;
			}
			_int3--;
			_int4++;
			return result;
		}

		public virtual int vmethod_7(int int5)
		{
			while (_int3 <= 0)
			{
				method_0();
			}
			int5 <<= 1;
			int5 |= ((((int)_byte1[_int1] & 128 >> _int2) != 0) ? 1 : 0);
			_int2++;
			if (_int2 == 8)
			{
				_short0 = Class150.smethod_0(_byte1[_int1], _short0);
				_int1++;
				_int2 = 0;
			}
			_int3--;
			_int4++;
			return int5;
		}

		public virtual int vmethod_8(int int5, int int6)
		{
			while (int6 >= _int3)
			{
				method_0();
			}
			int5 <<= 1;
			if (_int2 + int6 >= 8)
			{
				int6 = (_int2 + int6) % 8;
				int5 |= ((((int)_byte1[_int1 + 1] & 128 >> int6) != 0) ? 1 : 0);
			}
			else
			{
				int5 |= ((((int)_byte1[_int1] & 128 >> _int2 + int6) != 0) ? 1 : 0);
			}
			return int5;
		}

		public virtual long vmethod_9(long long0)
		{
			while (_int3 <= 0)
			{
				method_0();
			}
			long0 <<= 1;
			long0 |= ((((int)_byte1[_int1] & 128 >> _int2) != 0) ? 1L : 0L);
			_int2++;
			if (_int2 == 8)
			{
				_short0 = Class150.smethod_0(_byte1[_int1], _short0);
				_int1++;
				_int2 = 0;
			}
			_int3--;
			_int4++;
			return long0;
		}

		public virtual int vmethod_10(int int5)
		{
			var num = 0;
			for (var i = 0; i < int5; i++)
			{
				num = vmethod_7(num);
			}
			return num;
		}

		public virtual int vmethod_11(int int5)
		{
			var num = 0;
			for (var i = 0; i < int5; i++)
			{
				num = vmethod_8(num, i);
			}
			return num;
		}

		public virtual int vmethod_12(int int5)
		{
			if (int5 == 0)
			{
				return 0;
			}
			var num = 0;
			for (var i = 0; i < int5; i++)
			{
				num = vmethod_7(num);
			}
			var num2 = 32 - int5;
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

		public virtual long vmethod_13(int int5)
		{
			var num = 0L;
			for (var i = 0; i < int5; i++)
			{
				num = vmethod_9(num);
			}
			return num;
		}

		public virtual int vmethod_14()
		{
			var num = vmethod_10(8);
			var num2 = vmethod_10(8);
			num |= num2 << 8;
			num2 = vmethod_10(8);
			num |= num2 << 16;
			num2 = vmethod_10(8);
			return num | num2 << 24;
		}

		public virtual void vmethod_15(byte[] byte2, int int5)
		{
			var num = int5;
			while (int5 > 0)
			{
				var num2 = Math.Min(int5, _int0 - _int1);
				if (num2 == 0)
				{
					method_0();
				}
				else
				{
					if (byte2 != null)
					{
						Buffer.BlockCopy(_byte1, _int1, byte2, num - int5, num2);
					}
					int5 -= num2;
					_int1 += num2;
					_int3 -= num2 << 3;
					_int4 += num2 << 3;
				}
			}
		}

		public virtual int vmethod_16()
		{
			var num = 0;
			while (true)
			{
				var num2 = vmethod_6();
				if (num2 != 0)
				{
					break;
				}
				num++;
			}
			return num;
		}

		public virtual void vmethod_17(int[] int5, int int6, int int7, int int8)
		{
			var i = 0;
			var num = 0;
			var num2 = 0;
			var num3 = 0;
			var num4 = 0;
			var num5 = 0;
			if (int7 == 0)
			{
				return;
			}
			var num6 = _int1;
			long num7 = _int1 * 8 + _int2;
			if (_int2 > 0)
			{
				byte b2;
				var b = b2 = _byte1[num6];
				num = _int2;
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
						var num8 = 0;
						while ((b & Byte0) == 0)
						{
							b = (byte)(b << 1);
							num8++;
						}
						num3 += num8;
						b = (byte)(b << 1);
						num8++;
						num += num8;
						num2 = 0;
						num4 = int8;
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
						num2 |= num3 << int8;
						if ((num2 & 1) != 0)
						{
							int5[int6 + i++] = -(num2 >> 1) - 1;
						}
						else
						{
							int5[int6 + i++] = num2 >> 1;
						}
						if (i == int7)
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
				_short0 = Class150.smethod_0(b2, _short0);
				goto IL_1D5;
				IL_13D:
				num3 += 8 - num;
				num = 0;
				_short0 = Class150.smethod_0(b2, _short0);
				goto IL_1D5;
				IL_15C:
				num2 <<= num9;
				num2 |= (b & 255) >> num;
				num = 0;
				_short0 = Class150.smethod_0(b2, _short0);
				if (num4 == num9)
				{
					num2 |= num3 << int8;
					if ((num2 & 1) != 0)
					{
						int5[int6 + i++] = -(num2 >> 1) - 1;
					}
					else
					{
						int5[int6 + i++] = num2 >> 1;
					}
					if (i == int7)
					{
						goto IL_1D5;
					}
					num3 = 0;
					num5 = 0;
				}
				num4 -= num9;
				IL_1D5:
				num6++;
				_int1 = num6;
				_int2 = num;
			}
			while (i < int7)
			{
				while (num6 < _int0 && i < int7)
				{
					byte b2;
					var b = b2 = _byte1[num6];
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
							var num8 = 0;
							while ((b & Byte0) == 0)
							{
								b = (byte)(b << 1);
								num8++;
							}
							num3 += num8;
							b = (byte)(b << 1);
							num8++;
							num += num8;
							num2 = 0;
							num4 = int8;
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
							num2 |= num3 << int8;
							if ((num2 & 1) != 0)
							{
								int5[int6 + i++] = -(num2 >> 1) - 1;
							}
							else
							{
								int5[int6 + i++] = num2 >> 1;
							}
							if (i == int7)
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
					_short0 = Class150.smethod_0(b2, _short0);
					goto IL_382;
					IL_2EA:
					num3 += 8 - num;
					num = 0;
					_short0 = Class150.smethod_0(b2, _short0);
					goto IL_382;
					IL_309:
					num2 <<= num10;
					num2 |= (b & 255) >> num;
					num = 0;
					_short0 = Class150.smethod_0(b2, _short0);
					if (num4 == num10)
					{
						num2 |= num3 << int8;
						if ((num2 & 1) != 0)
						{
							int5[int6 + i++] = -(num2 >> 1) - 1;
						}
						else
						{
							int5[int6 + i++] = num2 >> 1;
						}
						if (i == int7)
						{
							goto IL_382;
						}
						num3 = 0;
						num5 = 0;
					}
					num4 -= num10;
					goto IL_382;
				}
				_int1 = num6;
				_int2 = num;
				if (i < int7)
				{
					long num11 = _int1 * 8 + _int2;
					_int4 = (int)(_int4 + num11 - num7);
					_int3 = (int)(_int3 - (num11 - num7));
					method_0();
					num6 = 0;
					num7 = _int1 * 8 + _int2;
				}
			}
			long num12 = _int1 * 8 + _int2;
			_int4 = (int)(_int4 + num12 - num7);
			_int3 = (int)(_int3 - (num12 - num7));
		}

		public virtual int vmethod_18(Class152 class1520)
		{
			var num = vmethod_10(8);
			if (class1520 != null)
			{
				class1520.vmethod_1((byte)num);
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
				if (class1520 != null)
				{
					class1520.vmethod_1((byte)num);
				}
				num2 <<= 6;
				num2 |= (num & 63);
				i--;
			}
			return num2;
		}

		public virtual long vmethod_19(Class152 class1520)
		{
			var num = vmethod_10(8);
			if (class1520 != null)
			{
				class1520.vmethod_1((byte)num);
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
				if (class1520 != null)
				{
					class1520.vmethod_1((byte)num);
				}
				num2 <<= 6;
				num2 |= num & 63;
				i--;
			}
			return num2;
		}
	}
}
