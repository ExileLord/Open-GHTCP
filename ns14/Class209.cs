using ns13;
using System;

namespace ns14
{
	public class Class209
	{
		private uint[] uint_0;

		public byte method_0()
		{
			uint num = (this.uint_0[2] & 65535u) | 2u;
			return (byte)(num * (num ^ 1u) >> 8);
		}

		public void method_1(byte[] byte_0)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("keyData");
			}
			if (byte_0.Length != 12)
			{
				throw new InvalidOperationException("Key length is not valid");
			}
			this.uint_0 = new uint[3];
			this.uint_0[0] = (uint)((int)byte_0[3] << 24 | (int)byte_0[2] << 16 | (int)byte_0[1] << 8 | (int)byte_0[0]);
			this.uint_0[1] = (uint)((int)byte_0[7] << 24 | (int)byte_0[6] << 16 | (int)byte_0[5] << 8 | (int)byte_0[4]);
			this.uint_0[2] = (uint)((int)byte_0[11] << 24 | (int)byte_0[10] << 16 | (int)byte_0[9] << 8 | (int)byte_0[8]);
		}

		public void method_2(byte byte_0)
		{
			this.uint_0[0] = Class192.smethod_0(this.uint_0[0], byte_0);
			this.uint_0[1] = this.uint_0[1] + (uint)((byte)this.uint_0[0]);
			this.uint_0[1] = this.uint_0[1] * 134775813u + 1u;
			this.uint_0[2] = Class192.smethod_0(this.uint_0[2], (byte)(this.uint_0[1] >> 24));
		}

		public void method_3()
		{
			this.uint_0[0] = 0u;
			this.uint_0[1] = 0u;
			this.uint_0[2] = 0u;
		}
	}
}
