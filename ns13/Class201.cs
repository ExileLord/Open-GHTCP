using Compression;
using Compression.Zip;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ns13
{
	public class Class201
	{
		private int int_0;

		private byte[] byte_0;

		private int int_1;

		private byte[] byte_1;

		private byte[] byte_2;

		private int int_2;

		private ICryptoTransform icryptoTransform_0;

		private Stream stream_0;

		public Class201(Stream stream_1, int int_3)
		{
			this.stream_0 = stream_1;
			if (int_3 < 1024)
			{
				int_3 = 1024;
			}
			this.byte_0 = new byte[int_3];
			this.byte_1 = this.byte_0;
		}

		public int method_0()
		{
			return this.int_0;
		}

		public int method_1()
		{
			return this.int_2;
		}

		public void method_2(int int_3)
		{
			this.int_2 = int_3;
		}

		public void method_3(Class196 class196_0)
		{
			if (this.int_2 > 0)
			{
				class196_0.method_6(this.byte_1, this.int_1 - this.int_2, this.int_2);
				this.int_2 = 0;
			}
		}

		public void method_4()
		{
			this.int_0 = 0;
			int i = this.byte_0.Length;
			while (i > 0)
			{
				int num = this.stream_0.Read(this.byte_0, this.int_0, i);
				if (num > 0)
				{
					this.int_0 += num;
					i -= num;
				}
				else
				{
					if (this.int_0 == 0)
					{
						throw new SharpZipBaseException("Unexpected EOF");
					}
                    goto IL_5A;

				}
			}
			IL_5A:
            if (this.icryptoTransform_0 != null)
			{
				this.int_1 = this.icryptoTransform_0.TransformBlock(this.byte_0, 0, this.int_0, this.byte_1, 0);
			}
			else
			{
				this.int_1 = this.int_0;
			}
			this.int_2 = this.int_1;
			return;
		}

		public int method_5(byte[] byte_3)
		{
			return this.method_6(byte_3, 0, byte_3.Length);
		}

		public int method_6(byte[] byte_3, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = int_3;
			int i = int_4;
			while (i > 0)
			{
				if (this.int_2 <= 0)
				{
					this.method_4();
					if (this.int_2 <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.int_2);
				Array.Copy(this.byte_0, this.int_0 - this.int_2, byte_3, num, num2);
				num += num2;
				i -= num2;
				this.int_2 -= num2;
			}
			return int_4;
		}

		public int method_7(byte[] byte_3, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = int_3;
			int i = int_4;
			while (i > 0)
			{
				if (this.int_2 <= 0)
				{
					this.method_4();
					if (this.int_2 <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.int_2);
				Array.Copy(this.byte_1, this.int_1 - this.int_2, byte_3, num, num2);
				num += num2;
				i -= num2;
				this.int_2 -= num2;
			}
			return int_4;
		}

		public int method_8()
		{
			if (this.int_2 <= 0)
			{
				this.method_4();
				if (this.int_2 <= 0)
				{
					throw new ZipException("EOF in header");
				}
			}
            byte result = (byte)(this.byte_0[this.int_0 - this.int_2] & (byte)255);
			this.int_2--;
			return (int)result;
		}

		public int method_9()
		{
			return this.method_8() | this.method_8() << 8;
		}

		public int method_10()
		{
			return this.method_9() | this.method_9() << 16;
		}

		public long method_11()
		{
			return (long)((ulong)this.method_10() | (ulong)((ulong)((long)this.method_10()) << 32));
		}

		public void method_12(ICryptoTransform icryptoTransform_1)
		{
			this.icryptoTransform_0 = icryptoTransform_1;
			if (this.icryptoTransform_0 != null)
			{
				if (this.byte_0 == this.byte_1)
				{
					if (this.byte_2 == null)
					{
						this.byte_2 = new byte[4096];
					}
					this.byte_1 = this.byte_2;
				}
				this.int_1 = this.int_0;
				if (this.int_2 > 0)
				{
					this.icryptoTransform_0.TransformBlock(this.byte_0, this.int_0 - this.int_2, this.int_2, this.byte_1, this.int_0 - this.int_2);
					return;
				}
			}
			else
			{
				this.byte_1 = this.byte_0;
				this.int_1 = this.int_0;
			}
		}
	}
}
