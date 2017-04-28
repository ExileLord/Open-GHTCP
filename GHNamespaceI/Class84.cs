using System;

namespace GHNamespaceI
{
	public class Class84
	{
		private readonly int[] _int0;

		private readonly int _int1;

		private readonly int _int2;

		private readonly float[][] _float0;

		private int _int3;

		private int _int4;

		public int method_0()
		{
			return _int4 - _int3;
		}

		public Class84(int int5)
		{
			_int1 = int5;
			_int2 = _int1 << 2;
			_int0 = new int[_int1];
			_float0 = new float[_int1][];
			for (var i = 0; i < _int1; i++)
			{
				_float0[i] = new float[1152];
			}
			method_6();
		}

		public int method_1(float[] float1, int int5, int int6)
		{
			int6 <<= 2;
			var num = method_0();
			var num2 = (int6 > num) ? num : (int6 - int6 % _int2);
			if (_int1 == 1)
			{
				Buffer.BlockCopy(_float0[0], _int3, float1, int5 << 2, num2);
			}
			else
			{
				var num3 = _int3 / _int2;
				var num4 = num2 / _int2 + num3;
				for (var i = 0; i < _int1; i++)
				{
					var array = _float0[i];
					var j = num3;
					var num5 = int5 + i;
					while (j < num4)
					{
						float1[num5] = array[j];
						j++;
						num5 += _int1;
					}
				}
			}
			_int3 += num2;
			return num2 >> 2;
		}

		public int method_2(byte[] byte0, int int5, int int6)
		{
			var num = method_0();
			var num2 = (int6 > num) ? num : int6;
			if (_int1 == 1)
			{
				Buffer.BlockCopy(_float0[0], _int3, byte0, int5, num2);
			}
			else
			{
				var array = new float[num2 >> 2];
				method_1(array, 0, array.Length);
				Buffer.BlockCopy(array, 0, byte0, int5, num2);
			}
			_int3 += num2;
			return num2;
		}

		public int method_3(float[][] float1, int int5, int int6)
		{
			int5 <<= 2;
			int6 <<= 2;
			var num = method_0();
			var num2 = (int6 > num) ? num : (int6 - int6 % _int2);
			if (_int1 == 1)
			{
				Buffer.BlockCopy(_float0[0], _int3, float1[0], int5, num2);
			}
			else
			{
				var srcOffset = _int3 / _int1;
				var count = num2 / _int1;
				int5 /= _int1;
				for (var i = 0; i < float1.Length; i++)
				{
					Buffer.BlockCopy(_float0[i], srcOffset, float1[i], int5, count);
				}
			}
			_int3 += num2;
			return num2 >> 2;
		}

		public void method_4(int int5, float[] float1)
		{
			if (int5 < _int1 && _int0[int5] < 4608)
			{
				Buffer.BlockCopy(float1, 0, _float0[int5], _int0[int5], 128);
				_int0[int5] += 128;
			}
		}

		public void method_5()
		{
			_int3 = 0;
			_int4 = _int0[0] * _int1;
		}

		public void method_6()
		{
			_int3 = 0;
			_int4 = 0;
			Array.Clear(_int0, 0, _int1);
		}
	}
}
