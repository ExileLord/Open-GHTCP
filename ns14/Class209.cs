using System;
using ns13;

namespace ns14
{
	public class Class209
	{
		private uint[] _uint0;

		public byte method_0()
		{
			var num = (_uint0[2] & 65535u) | 2u;
			return (byte)(num * (num ^ 1u) >> 8);
		}

		public void method_1(byte[] byte0)
		{
			if (byte0 == null)
			{
				throw new ArgumentNullException("keyData");
			}
			if (byte0.Length != 12)
			{
				throw new InvalidOperationException("Key length is not valid");
			}
			_uint0 = new uint[3];
			_uint0[0] = (uint)(byte0[3] << 24 | byte0[2] << 16 | byte0[1] << 8 | byte0[0]);
			_uint0[1] = (uint)(byte0[7] << 24 | byte0[6] << 16 | byte0[5] << 8 | byte0[4]);
			_uint0[2] = (uint)(byte0[11] << 24 | byte0[10] << 16 | byte0[9] << 8 | byte0[8]);
		}

		public void method_2(byte byte0)
		{
			_uint0[0] = Class192.smethod_0(_uint0[0], byte0);
			_uint0[1] = _uint0[1] + (byte)_uint0[0];
			_uint0[1] = _uint0[1] * 134775813u + 1u;
			_uint0[2] = Class192.smethod_0(_uint0[2], (byte)(_uint0[1] >> 24));
		}

		public void method_3()
		{
			_uint0[0] = 0u;
			_uint0[1] = 0u;
			_uint0[2] = 0u;
		}
	}
}
