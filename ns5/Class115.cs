using System;

namespace ns5
{
	public class Class115
	{
		private byte[] _byte0 = new byte[2048];

		private int _int0;

		private int _int1;

		public virtual int vmethod_0()
		{
			return _int0;
		}

		public virtual bool vmethod_1()
		{
			return (_byte0[_int0 >> 3] << (_int0++ & 7) & 128) != 0;
		}

		public virtual void vmethod_2(byte[] byte1, int int2, int int3)
		{
			if (vmethod_0() > 4096)
			{
				method_0((vmethod_0() - 4096) / 8);
			}
			if (_byte0.Length - _int1 / 8 < int3 + 8)
			{
				var dst = new byte[(_byte0.Length + int3) * 2];
				Buffer.BlockCopy(_byte0, 0, dst, 0, _int1 / 8);
				Buffer.BlockCopy(byte1, int2, dst, _int1 / 8, int3);
				_byte0 = dst;
			}
			else
			{
				Buffer.BlockCopy(byte1, int2, _byte0, _int1 / 8, int3);
			}
			_int1 += int3 * 8;
		}

		public void method_0(int int2)
		{
			Buffer.BlockCopy(_byte0, int2, _byte0, 0, _byte0.Length - int2);
			_int1 -= int2 * 8;
			_int0 -= int2 * 8;
		}

		public virtual void vmethod_3(int int2)
		{
			_int0 = int2;
		}

		public int method_1()
		{
			return _int1 - _int0;
		}

		public int method_2(int int2)
		{
			var num = _int0 >> 3;
			int num2 = _byte0[num++];
			int i;
			for (i = int2 - (8 - (_int0 & 7)); i > 0; i -= 8)
			{
				num2 = (num2 << 8 | _byte0[num++] & 255);
			}
			num2 = (num2 >> -i & (1 << int2) - 1);
			_int0 += int2;
			if (method_1() < 0)
			{
				throw new ApplicationException("Buffer underflow");
			}
			return num2;
		}

		public int method_3(int int2)
		{
			var num = _int0 >> 3;
			int num2 = _byte0[num++];
			int i;
			for (i = int2 - (8 - (_int0 & 7)); i > 0; i -= 8)
			{
				num2 = (num2 << 8 | _byte0[num++] & 255);
			}
			return num2 >> -i & (1 << int2) - 1;
		}
	}
}
