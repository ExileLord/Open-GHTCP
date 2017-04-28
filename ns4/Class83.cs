namespace ns4
{
	public class Class83
	{
		private readonly byte[] _byte0;

		private readonly int[] _int0;

		private readonly int _int1;

		public int Int2;

		private readonly double _double0;

		public Class83(byte[] byte1, int int3)
		{
			_byte0 = byte1;
			Int2 = int3;
			_double0 = 1.0 / byte1.Length;
		}

		public Class83(int[] int3, short short0)
		{
			_int0 = int3;
			_int1 = short0;
			_double0 = 1.0 / int3.Length;
		}

		public int method_0(double double1)
		{
			var num = 0;
			var num2 = 0;
			var num3 = 0.0;
			if (_byte0 == null)
			{
				while (num3 <= double1)
				{
					num2 += _int0[num++];
					num3 += _double0;
				}
				return num2 - (int)(_int0[num - 1] * ((num3 - double1) / _double0 + 0.5 / _int1));
			}
			if (double1 == 0.0)
			{
				return 0;
			}
			if (double1 == 1.0)
			{
				return Int2;
			}
			num3 = double1 * 100.0;
			num = (int)num3;
			if (num >= _byte0.Length - 1)
			{
				return (int)(_byte0[_byte0.Length - 1] / 256.0 * Int2);
			}
			if (num == num3)
			{
				return (int)(_byte0[num] / 256.0 * Int2);
			}
			return (int)((_byte0[num] + (num3 - num) * (_byte0[num + 1] - _byte0[num])) / 256.0 * Int2);
		}
	}
}
