using System;
using GHNamespace3;

namespace GHNamespaceH
{
	public class Class56
	{
		private byte[] _byte0;

		private int _int0;

		private int _int1;

		private int _int2;

		private int[] _int3;

		private long[] _long0;

		private int _int4;

		private int _int5;

		private int _int6;

		private int _int7;

		private readonly byte[] _byte1 = new byte[282];

		private int _int8;

		public int Int9;

		private int _int10;

		private int _int11;

		private int _int12;

		private long _long1;

		private long _long2;

		public Class56()
		{
			method_0();
		}

		~Class56()
		{
			method_2();
		}

		private void method_0()
		{
			_int0 = 16384;
			_byte0 = new byte[_int0];
			_int4 = 1024;
			_int3 = new int[_int4];
			_long0 = new long[_int4];
		}

		public void method_1(int int13)
		{
			if (_byte0 == null)
			{
				method_0();
			}
			else
			{
				for (var i = 0; i < _byte0.Length; i++)
				{
					_byte0[i] = 0;
				}
				for (var j = 0; j < _int3.Length; j++)
				{
					_int3[j] = 0;
				}
				for (var k = 0; k < _long0.Length; k++)
				{
					_long0[k] = 0L;
				}
			}
			_int11 = int13;
		}

		public void method_2()
		{
			_byte0 = null;
			_int3 = null;
			_long0 = null;
		}

		private void method_3(int int13)
		{
			if (_int0 <= _int1 + int13)
			{
				_int0 += int13 + 1024;
				var dst = new byte[_int0];
				Buffer.BlockCopy(_byte0, 0, dst, 0, _byte0.Length);
				_byte0 = dst;
			}
		}

		private void method_4(int int13)
		{
			if (_int4 <= _int5 + int13)
			{
				_int4 += int13 + 32;
				var dst = new int[_int4];
				Buffer.BlockCopy(_int3, 0, dst, 0, _int3.Length << 2);
				_int3 = dst;
				var dst2 = new long[_int4];
				Buffer.BlockCopy(_long0, 0, dst2, 0, _long0.Length << 3);
				_long0 = dst2;
			}
		}

		public int method_5(Class67 class670)
		{
			var num = _int7;
			if (_int6 <= num)
			{
				return 0;
			}
			if ((_int3[num] & 1024) != 0)
			{
				_int7++;
				_long1 += 1L;
				return -1;
			}
			var num2 = _int3[num] & 255;
			class670.Byte0 = _byte0;
			class670.Int0 = _int2;
			class670.Int3 = (_int3[num] & 512);
			class670.Int2 = (_int3[num] & 256);
			var num3 = 0 + num2;
			while (num2 == 255)
			{
				var num4 = _int3[++num];
				num2 = (num4 & 255);
				if ((num4 & 512) != 0)
				{
					class670.Int3 = 512;
				}
				num3 += num2;
			}
			class670.Long1 = _long1;
			class670.Long0 = _long0[num];
			class670.Int1 = num3;
			_int2 += num3;
			_int7 = num + 1;
			_long1 += 1L;
			return 1;
		}

		public bool method_6(Class48 class480)
		{
			var array = class480.Byte0;
			var num = class480.Int0;
			var src = class480.Byte1;
			var num2 = class480.Int2;
			var num3 = class480.Int3;
			var i = 0;
			var num4 = class480.method_0();
			var num5 = class480.method_1();
			var num6 = class480.method_2();
			var num7 = class480.method_3();
			var num8 = class480.method_4();
			var num9 = class480.method_5();
			var num10 = class480.method_6();
			var num11 = array[num + 26] & 255;
			var num12 = _int7;
			var num13 = _int2;
			if (num13 != 0)
			{
				_int1 -= num13;
				if (_int1 != 0)
				{
					Buffer.BlockCopy(_byte0, num13, _byte0, 0, _int1);
				}
				_int2 = 0;
			}
			if (num12 != 0)
			{
				if (_int5 - num12 != 0)
				{
					Buffer.BlockCopy(_int3, num12 << 2, _int3, 0, _int5 - num12 << 2);
					Buffer.BlockCopy(_long0, num12 << 3, _long0, 0, _int5 - num12 << 3);
				}
				_int5 -= num12;
				_int6 -= num12;
				_int7 = 0;
			}
			if (num9 != _int11)
			{
				return false;
			}
			if (num4 > 0)
			{
				return false;
			}
			method_4(num11 + 1);
			if (num10 != _int12)
			{
				for (var j = _int6; j < _int5; j++)
				{
					_int1 -= (_int3[j] & 255);
				}
				_int5 = _int6;
				if (_int12 != -1)
				{
					_int3[_int5++] = 1024;
					_int6++;
				}
				if (num5 != 0)
				{
					num6 = 0;
					while (i < num11)
					{
						var num14 = array[num + 27 + i] & 255;
						num2 += num14;
						num3 -= num14;
						if (num14 < 255)
						{
							i++;
							break;
						}
						i++;
					}
				}
			}
			if (num3 != 0)
			{
				method_3(num3);
				Buffer.BlockCopy(src, num2, _byte0, _int1, num3);
				_int1 += num3;
			}
			var num15 = -1;
			while (i < num11)
			{
				var num16 = array[num + 27 + i] & 255;
				_int3[_int5] = num16;
				_long0[_int5] = -1L;
				if (num6 != 0)
				{
					_int3[_int5] |= 256;
					num6 = 0;
				}
				if (num16 < 255)
				{
					num15 = _int5;
				}
				_int5++;
				i++;
				if (num16 < 255)
				{
					_int6 = _int5;
				}
			}
			if (num15 != -1)
			{
				_long0[num15] = num8;
			}
			if (num7 != 0)
			{
				Int9 = 1;
				if (_int5 > 0)
				{
					_int3[_int5 - 1] |= 512;
				}
			}
			_int12 = num10 + 1;
			return true;
		}

		public bool method_7()
		{
			_int1 = 0;
			_int2 = 0;
			_int5 = 0;
			_int6 = 0;
			_int7 = 0;
			_int8 = 0;
			Int9 = 0;
			_int10 = 0;
			_int12 = -1;
			_long1 = 0L;
			_long2 = 0L;
			return true;
		}
	}
}
