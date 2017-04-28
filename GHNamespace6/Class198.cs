using System;
using Compression;
using GHNamespace5;

namespace GHNamespace6
{
	public class Class198
	{
		private static readonly int[] Int0 = {
			3,
			3,
			11
		};

		private static readonly int[] Int1 = {
			2,
			3,
			7
		};

		private static readonly int[] Int2 = {
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

		private byte[] _byte0;

		private byte[] _byte1;

		private Class197 _class1970;

		private int _int3;

		private int _int4;

		private int _int5;

		private int _int6;

		private int _int7;

		private int _int8;

		private byte _byte2;

		private int _int9;

		public bool method_0(Class187 class1870)
		{
			while (true)
			{
				switch (_int3)
				{
				case 0:
					_int4 = class1870.method_0(5);
					if (_int4 >= 0)
					{
						_int4 += 257;
						class1870.method_1(5);
						_int3 = 1;
						goto IL_1FD;
					}
					return false;
				case 1:
					goto IL_1FD;
				case 2:
					goto IL_1AF;
				case 3:
					goto IL_176;
				case 4:
					break;
				case 5:
					goto IL_2C;
				default:
					continue;
				}
				IL_F4:
				int num;
				while (((num = _class1970.method_1(class1870)) & -16) == 0)
				{
					_byte1[_int9++] = (_byte2 = (byte)num);
					if (_int9 == _int7)
					{
						return true;
					}
				}
				if (num >= 0)
				{
					if (num >= 17)
					{
						_byte2 = 0;
					}
					else if (_int9 == 0)
					{
						goto IL_2A6;
					}
					_int8 = num - 16;
					_int3 = 5;
					goto IL_2C;
				}
				return false;
				IL_176:
				while (_int9 < _int6)
				{
					var num2 = class1870.method_0(3);
					if (num2 < 0)
					{
						return false;
					}
					class1870.method_1(3);
					_byte0[Int2[_int9]] = (byte)num2;
					_int9++;
				}
				_class1970 = new Class197(_byte0);
				_byte0 = null;
				_int9 = 0;
				_int3 = 4;
				goto IL_F4;
				IL_2C:
				var num3 = Int1[_int8];
				var num4 = class1870.method_0(num3);
				if (num4 < 0)
				{
					return false;
				}
				class1870.method_1(num3);
				num4 += Int0[_int8];
				if (_int9 + num4 > _int7)
				{
					break;
				}
				while (num4-- > 0)
				{
					_byte1[_int9++] = _byte2;
				}
				if (_int9 == _int7)
				{
					return true;
				}
				_int3 = 4;
				continue;
				IL_1AF:
				_int6 = class1870.method_0(4);
				if (_int6 >= 0)
				{
					_int6 += 4;
					class1870.method_1(4);
					_byte0 = new byte[19];
					_int9 = 0;
					_int3 = 3;
					goto IL_176;
				}
				return false;
				IL_1FD:
				_int5 = class1870.method_0(5);
				if (_int5 >= 0)
				{
					_int5++;
					class1870.method_1(5);
					_int7 = _int4 + _int5;
					_byte1 = new byte[_int7];
					_int3 = 2;
					goto IL_1AF;
				}
				return false;
			}
			throw new SharpZipBaseException();
			IL_2A6:
			throw new SharpZipBaseException();
		}

		public Class197 method_1()
		{
			var destinationArray = new byte[_int4];
			Array.Copy(_byte1, 0, destinationArray, 0, _int4);
			return new Class197(destinationArray);
		}

		public Class197 method_2()
		{
			var destinationArray = new byte[_int5];
			Array.Copy(_byte1, _int4, destinationArray, 0, _int5);
			return new Class197(destinationArray);
		}
	}
}
