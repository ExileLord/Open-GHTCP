using System;
using GHNamespace6;

namespace GHNamespace5
{
	public class Class184 : Class183
	{
		private int _int6;

		private readonly short[] _short0;

		private readonly short[] _short1;

		private int _int7;

		private int _int8;

		private bool _bool0;

		private int _int9;

		private int _int10;

		private int _int11;

		private readonly byte[] _byte0;

		private Enum29 _enum290;

		private int _int12;

		private int _int13;

		private int _int14;

		private int _int15;

		private int _int16;

		private byte[] _byte1;

		private int _int17;

		private int _int18;

		private int _int19;

		private readonly Class189 _class1890;

		private readonly Class190 _class1900;

		private readonly Class200 _class2000;

		public Class184(Class189 class1891)
		{
			_class1890 = class1891;
			_class1900 = new Class190(class1891);
			_class2000 = new Class200();
			_byte0 = new byte[65536];
			_short0 = new short[32768];
			_short1 = new short[32768];
			_int10 = 1;
			_int9 = 1;
		}

		public bool method_0(bool bool1, bool bool2)
		{
			while (true)
			{
				method_7();
				var bool3 = bool1 && _int18 == _int19;
				bool flag;
				switch (_int16)
				{
				case 0:
					flag = method_12(bool3, bool2);
					goto IL_45;
				case 1:
					flag = method_13(bool3, bool2);
					goto IL_45;
				case 2:
					flag = method_14(bool3, bool2);
					goto IL_45;
				}
				break;
				IL_45:
				if (!_class1890.method_7())
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

		public void method_1(byte[] byte2, int int20, int int21)
		{
			if (byte2 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (int20 < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int21 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (_int18 < _int19)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			var num = int20 + int21;
			if (int20 > num || num > byte2.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			_byte1 = byte2;
			_int18 = int20;
			_int19 = num;
		}

		public bool method_2()
		{
			return _int19 == _int18;
		}

		public void method_3()
		{
			_class1900.method_0();
			_class2000.vmethod_1();
			_int10 = 1;
			_int9 = 1;
			_int11 = 0;
			_int17 = 0;
			_bool0 = false;
			_int8 = 2;
			for (var i = 0; i < 32768; i++)
			{
				_short0[i] = 0;
			}
			for (var j = 0; j < 32768; j++)
			{
				_short1[j] = 0;
			}
		}

		public void ResetAdler()
		{
			_class2000.vmethod_1();
		}

		public int method_4()
		{
			return (int)_class2000.vmethod_0();
		}

		public void method_5(Enum29 enum291)
		{
			_enum290 = enum291;
		}

		public void method_6(int int20)
		{
			if (int20 >= 0 && int20 <= 9)
			{
				_int15 = Int1[int20];
				_int13 = Int2[int20];
				_int14 = Int3[int20];
				_int12 = Int4[int20];
				if (Int5[int20] != _int16)
				{
					switch (_int16)
					{
					case 0:
						if (_int10 > _int9)
						{
							_class1900.method_3(_byte0, _int9, _int10 - _int9, false);
							_int9 = _int10;
						}
						method_8();
						break;
					case 1:
						if (_int10 > _int9)
						{
							_class1900.method_4(_byte0, _int9, _int10 - _int9, false);
							_int9 = _int10;
						}
						break;
					case 2:
						if (_bool0)
						{
							_class1900.method_6(_byte0[_int10 - 1] & 255);
						}
						if (_int10 > _int9)
						{
							_class1900.method_4(_byte0, _int9, _int10 - _int9, false);
							_int9 = _int10;
						}
						_bool0 = false;
						_int8 = 2;
						break;
					}
					_int16 = Int5[int20];
				}
				return;
			}
			throw new ArgumentOutOfRangeException("level");
		}

		public void method_7()
		{
			if (_int10 >= 65274)
			{
				method_10();
			}
			while (_int11 < 262 && _int18 < _int19)
			{
				var num = 65536 - _int11 - _int10;
				if (num > _int19 - _int18)
				{
					num = _int19 - _int18;
				}
				Array.Copy(_byte1, _int18, _byte0, _int10 + _int11, num);
				_class2000.vmethod_2(_byte1, _int18, num);
				_int18 += num;
				_int17 += num;
				_int11 += num;
			}
			if (_int11 >= 3)
			{
				method_8();
			}
		}

		private void method_8()
		{
			_int6 = (_byte0[_int10] << 5 ^ _byte0[_int10 + 1]);
		}

		private int method_9()
		{
			var num = (_int6 << 5 ^ _byte0[_int10 + 2]) & 32767;
			var num2 = _short1[_int10 & 32767] = _short0[num];
			_short0[num] = (short)_int10;
			_int6 = num;
			return num2 & 65535;
		}

		private void method_10()
		{
			Array.Copy(_byte0, 32768, _byte0, 0, 32768);
			_int7 -= 32768;
			_int10 -= 32768;
			_int9 -= 32768;
			for (var i = 0; i < 32768; i++)
			{
				var num = _short0[i] & 65535;
				_short0[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
			for (var j = 0; j < 32768; j++)
			{
				var num2 = _short1[j] & 65535;
				_short1[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
			}
		}

		private bool method_11(int int20)
		{
			var num = _int12;
			var num2 = _int14;
			var array = _short1;
			var num3 = _int10;
			var num4 = _int10 + _int8;
			var num5 = Math.Max(_int8, 2);
			var num6 = Math.Max(_int10 - 32506, 0);
			var num7 = _int10 + 258 - 1;
			var b = _byte0[num4 - 1];
			var b2 = _byte0[num4];
			if (num5 >= _int15)
			{
				num >>= 2;
			}
			if (num2 > _int11)
			{
				num2 = _int11;
			}
			do
			{
				if (_byte0[int20 + num5] == b2 && _byte0[int20 + num5 - 1] == b && _byte0[int20] == _byte0[num3] && _byte0[int20 + 1] == _byte0[num3 + 1])
				{
					var num8 = int20 + 2;
					num3 += 2;
					while (_byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && _byte0[++num3] == _byte0[++num8] && num3 < num7)
					{
					}
					if (num3 > num4)
					{
						_int7 = int20;
						num4 = num3;
						num5 = num3 - _int10;
						if (num5 >= num2)
						{
							break;
						}
						b = _byte0[num4 - 1];
						b2 = _byte0[num4];
					}
					num3 = _int10;
				}
				if ((int20 = (array[int20 & 32767] & 65535)) <= num6)
				{
					break;
				}
			}
			while (--num != 0);
			_int8 = Math.Min(num5, _int11);
			return _int8 >= 3;
		}

		private bool method_12(bool bool1, bool bool2)
		{
			if (!bool1 && _int11 == 0)
			{
				return false;
			}
			_int10 += _int11;
			_int11 = 0;
			var num = _int10 - _int9;
			if (num < Int0 && (_int9 >= 32768 || num < 32506) && !bool1)
			{
				return true;
			}
			var flag = bool2;
			if (num > Int0)
			{
				num = Int0;
				flag = false;
			}
			_class1900.method_3(_byte0, _int9, num, flag);
			_int9 += num;
			return !flag;
		}

		private bool method_13(bool bool1, bool bool2)
		{
			if (_int11 < 262 && !bool1)
			{
				return false;
			}
			while (_int11 >= 262 || bool1)
			{
				if (_int11 == 0)
				{
					_class1900.method_4(_byte0, _int9, _int10 - _int9, bool2);
					_int9 = _int10;
					return false;
				}
				if (_int10 > 65274)
				{
					method_10();
				}
				int num;
				if (_int11 >= 3 && (num = method_9()) != 0 && _enum290 != Enum29.Const2 && _int10 - num <= 32506 && method_11(num))
				{
					var flag = _class1900.method_7(_int10 - _int7, _int8);
					_int11 -= _int8;
					if (_int8 <= _int13 && _int11 >= 3)
					{
						while (--_int8 > 0)
						{
							_int10++;
							method_9();
						}
						_int10++;
					}
					else
					{
						_int10 += _int8;
						if (_int11 >= 2)
						{
							method_8();
						}
					}
					_int8 = 2;
					if (!flag)
					{
						continue;
					}
				}
				else
				{
					_class1900.method_6(_byte0[_int10] & 255);
					_int10++;
					_int11--;
				}
				if (_class1900.method_5())
				{
					var flag2 = bool2 && _int11 == 0;
					_class1900.method_4(_byte0, _int9, _int10 - _int9, flag2);
					_int9 = _int10;
					return !flag2;
				}
			}
			return true;
		}

		private bool method_14(bool bool1, bool bool2)
		{
			if (_int11 < 262 && !bool1)
			{
				return false;
			}
			while (_int11 >= 262 || bool1)
			{
				if (_int11 == 0)
				{
					if (_bool0)
					{
						_class1900.method_6(_byte0[_int10 - 1] & 255);
					}
					_bool0 = false;
					_class1900.method_4(_byte0, _int9, _int10 - _int9, bool2);
					_int9 = _int10;
					return false;
				}
				if (_int10 >= 65274)
				{
					method_10();
				}
				var num = _int7;
				var num2 = _int8;
				if (_int11 >= 3)
				{
					var num3 = method_9();
					if (_enum290 != Enum29.Const2 && num3 != 0 && _int10 - num3 <= 32506 && method_11(num3) && _int8 <= 5 && (_enum290 == Enum29.Const1 || (_int8 == 3 && _int10 - _int7 > 4096)))
					{
						_int8 = 2;
					}
				}
				if (num2 >= 3 && _int8 <= num2)
				{
					_class1900.method_7(_int10 - 1 - num, num2);
					num2 -= 2;
					do
					{
						_int10++;
						_int11--;
						if (_int11 >= 3)
						{
							method_9();
						}
					}
					while (--num2 > 0);
					_int10++;
					_int11--;
					_bool0 = false;
					_int8 = 2;
				}
				else
				{
					if (_bool0)
					{
						_class1900.method_6(_byte0[_int10 - 1] & 255);
					}
					_bool0 = true;
					_int10++;
					_int11--;
				}
				if (_class1900.method_5())
				{
					var num4 = _int10 - _int9;
					if (_bool0)
					{
						num4--;
					}
					var flag = bool2 && _int11 == 0 && !_bool0;
					_class1900.method_4(_byte0, _int9, num4, flag);
					_int9 += num4;
					return !flag;
				}
			}
			return true;
		}
	}
}
