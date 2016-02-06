using Compression.Zip;
using System;
using System.IO;

namespace ns13
{
	public class Class202 : IDisposable
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private MemoryStream memoryStream_0;

		private byte[] byte_0;

		public Class202()
		{
			this.method_1();
		}

		public Class202(byte[] byte_1)
		{
			if (byte_1 == null)
			{
				this.byte_0 = new byte[0];
				return;
			}
			this.byte_0 = byte_1;
		}

		public byte[] method_0()
		{
			if (this.method_2() > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			return (byte[])this.byte_0.Clone();
		}

		public void method_1()
		{
			if (this.byte_0 == null || this.byte_0.Length != 0)
			{
				this.byte_0 = new byte[0];
			}
		}

		public int method_2()
		{
			return this.byte_0.Length;
		}

		public int method_3()
		{
			return this.int_2;
		}

		public int method_4()
		{
			return this.int_0;
		}

		public int method_5()
		{
			if (this.int_1 > this.byte_0.Length || this.int_1 < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			return this.int_1 + this.int_2 - this.int_0;
		}

		public bool method_6(int int_3)
		{
			this.int_1 = this.byte_0.Length;
			this.int_2 = 0;
			this.int_0 = 0;
			int num = this.int_1;
			int num2 = int_3 - 1;
			while (num2 != int_3 && this.int_0 < this.byte_0.Length - 3)
			{
				num2 = this.method_20();
				num = this.method_20();
				if (num2 != int_3)
				{
					this.int_0 += num;
				}
			}
			bool result;
			if (result = (num2 == int_3 && this.int_0 + num <= this.byte_0.Length))
			{
				this.int_1 = this.int_0;
				this.int_2 = num;
			}
			return result;
		}

		public void method_7(int int_3, byte[] byte_1)
		{
			if (int_3 > 65535 || int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("headerID");
			}
			int num = (byte_1 == null) ? 0 : byte_1.Length;
			if (num > 65535)
			{
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
			}
			int num2 = this.byte_0.Length + num + 4;
			if (this.method_6(int_3))
			{
				num2 -= this.method_3() + 4;
			}
			if (num2 > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			this.method_13(int_3);
			byte[] array = new byte[num2];
			this.byte_0.CopyTo(array, 0);
			int index = this.byte_0.Length;
			this.byte_0 = array;
			this.method_21(ref index, int_3);
			this.method_21(ref index, num);
			if (byte_1 != null)
			{
				byte_1.CopyTo(array, index);
			}
		}

		public void method_8()
		{
			this.memoryStream_0 = new MemoryStream();
		}

		public void method_9(int int_3)
		{
			byte[] byte_ = this.memoryStream_0.ToArray();
			this.memoryStream_0 = null;
			this.method_7(int_3, byte_);
		}

		public void method_10(int int_3)
		{
			this.memoryStream_0.WriteByte((byte)int_3);
			this.memoryStream_0.WriteByte((byte)(int_3 >> 8));
		}

		public void method_11(int int_3)
		{
			this.method_10((int)((short)int_3));
			this.method_10((int)((short)(int_3 >> 16)));
		}

		public void method_12(long long_0)
		{
			this.method_11((int)(long_0 & 4294967295L));
			this.method_11((int)(long_0 >> 32));
		}

		public bool method_13(int int_3)
		{
			bool result = false;
			if (this.method_6(int_3))
			{
				result = true;
				int num = this.int_1 - 4;
				byte[] destinationArray = new byte[this.byte_0.Length - (this.method_3() + 4)];
				Array.Copy(this.byte_0, 0, destinationArray, 0, num);
				int num2 = num + this.method_3() + 4;
				Array.Copy(this.byte_0, num2, destinationArray, num, this.byte_0.Length - num2);
				this.byte_0 = destinationArray;
			}
			return result;
		}

		public long method_14()
		{
			this.method_19(8);
			return ((long)this.method_15() & 4294967295L) | (long)this.method_15() << 32;
		}

		public int method_15()
		{
			this.method_19(4);
			int result = (int)this.byte_0[this.int_0] + ((int)this.byte_0[this.int_0 + 1] << 8) + ((int)this.byte_0[this.int_0 + 2] << 16) + ((int)this.byte_0[this.int_0 + 3] << 24);
			this.int_0 += 4;
			return result;
		}

		public int method_16()
		{
			this.method_19(2);
			int result = (int)this.byte_0[this.int_0] + ((int)this.byte_0[this.int_0 + 1] << 8);
			this.int_0 += 2;
			return result;
		}

		public int method_17()
		{
			int result = -1;
			if (this.int_0 < this.byte_0.Length && this.int_1 + this.int_2 > this.int_0)
			{
				result = (int)this.byte_0[this.int_0];
				this.int_0++;
			}
			return result;
		}

		public void method_18(int int_3)
		{
			this.method_19(int_3);
			this.int_0 += int_3;
		}

		private void method_19(int int_3)
		{
			if (this.int_1 > this.byte_0.Length || this.int_1 < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			if (this.int_0 > this.int_1 + this.int_2 - int_3)
			{
				throw new ZipException("End of extra data");
			}
		}

		private int method_20()
		{
			if (this.int_0 > this.byte_0.Length - 2)
			{
				throw new ZipException("End of extra data");
			}
			int result = (int)this.byte_0[this.int_0] + ((int)this.byte_0[this.int_0 + 1] << 8);
			this.int_0 += 2;
			return result;
		}

		private void method_21(ref int int_3, int int_4)
		{
			this.byte_0[int_3] = (byte)int_4;
			this.byte_0[int_3 + 1] = (byte)(int_4 >> 8);
			int_3 += 2;
		}

		public void Dispose()
		{
			if (this.memoryStream_0 != null)
			{
				this.memoryStream_0.Close();
			}
		}
	}
}
