using System;
using System.IO;
using Compression.Zip;

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
			method_1();
		}

		public Class202(byte[] byte_1)
		{
			if (byte_1 == null)
			{
				byte_0 = new byte[0];
				return;
			}
			byte_0 = byte_1;
		}

		public byte[] method_0()
		{
			if (method_2() > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			return (byte[])byte_0.Clone();
		}

		public void method_1()
		{
			if (byte_0 == null || byte_0.Length != 0)
			{
				byte_0 = new byte[0];
			}
		}

		public int method_2()
		{
			return byte_0.Length;
		}

		public int method_3()
		{
			return int_2;
		}

		public int method_4()
		{
			return int_0;
		}

		public int method_5()
		{
			if (int_1 > byte_0.Length || int_1 < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			return int_1 + int_2 - int_0;
		}

		public bool method_6(int int_3)
		{
			int_1 = byte_0.Length;
			int_2 = 0;
			int_0 = 0;
			var num = int_1;
			var num2 = int_3 - 1;
			while (num2 != int_3 && int_0 < byte_0.Length - 3)
			{
				num2 = method_20();
				num = method_20();
				if (num2 != int_3)
				{
					int_0 += num;
				}
			}
			bool result;
			if (result = (num2 == int_3 && int_0 + num <= byte_0.Length))
			{
				int_1 = int_0;
				int_2 = num;
			}
			return result;
		}

		public void method_7(int int_3, byte[] byte_1)
		{
			if (int_3 > 65535 || int_3 < 0)
			{
				throw new ArgumentOutOfRangeException("headerID");
			}
			var num = (byte_1 == null) ? 0 : byte_1.Length;
			if (num > 65535)
			{
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
			}
			var num2 = byte_0.Length + num + 4;
			if (method_6(int_3))
			{
				num2 -= method_3() + 4;
			}
			if (num2 > 65535)
			{
				throw new ZipException("Data exceeds maximum length");
			}
			method_13(int_3);
			var array = new byte[num2];
			byte_0.CopyTo(array, 0);
			var index = byte_0.Length;
			byte_0 = array;
			method_21(ref index, int_3);
			method_21(ref index, num);
			if (byte_1 != null)
			{
				byte_1.CopyTo(array, index);
			}
		}

		public void method_8()
		{
			memoryStream_0 = new MemoryStream();
		}

		public void method_9(int int_3)
		{
			var byte_ = memoryStream_0.ToArray();
			memoryStream_0 = null;
			method_7(int_3, byte_);
		}

		public void method_10(int int_3)
		{
			memoryStream_0.WriteByte((byte)int_3);
			memoryStream_0.WriteByte((byte)(int_3 >> 8));
		}

		public void method_11(int int_3)
		{
			method_10((short)int_3);
			method_10((short)(int_3 >> 16));
		}

		public void method_12(long long_0)
		{
			method_11((int)(long_0 & 4294967295L));
			method_11((int)(long_0 >> 32));
		}

		public bool method_13(int int_3)
		{
			var result = false;
			if (method_6(int_3))
			{
				result = true;
				var num = int_1 - 4;
				var destinationArray = new byte[byte_0.Length - (method_3() + 4)];
				Array.Copy(byte_0, 0, destinationArray, 0, num);
				var num2 = num + method_3() + 4;
				Array.Copy(byte_0, num2, destinationArray, num, byte_0.Length - num2);
				byte_0 = destinationArray;
			}
			return result;
		}

		public long method_14()
		{
			method_19(8);
			return (method_15() & 4294967295L) | (long)method_15() << 32;
		}

		public int method_15()
		{
			method_19(4);
			var result = byte_0[int_0] + (byte_0[int_0 + 1] << 8) + (byte_0[int_0 + 2] << 16) + (byte_0[int_0 + 3] << 24);
			int_0 += 4;
			return result;
		}

		public int method_16()
		{
			method_19(2);
			var result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
			int_0 += 2;
			return result;
		}

		public int method_17()
		{
			var result = -1;
			if (int_0 < byte_0.Length && int_1 + int_2 > int_0)
			{
				result = byte_0[int_0];
				int_0++;
			}
			return result;
		}

		public void method_18(int int_3)
		{
			method_19(int_3);
			int_0 += int_3;
		}

		private void method_19(int int_3)
		{
			if (int_1 > byte_0.Length || int_1 < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			if (int_0 > int_1 + int_2 - int_3)
			{
				throw new ZipException("End of extra data");
			}
		}

		private int method_20()
		{
			if (int_0 > byte_0.Length - 2)
			{
				throw new ZipException("End of extra data");
			}
			var result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
			int_0 += 2;
			return result;
		}

		private void method_21(ref int int_3, int int_4)
		{
			byte_0[int_3] = (byte)int_4;
			byte_0[int_3 + 1] = (byte)(int_4 >> 8);
			int_3 += 2;
		}

		public void Dispose()
		{
			if (memoryStream_0 != null)
			{
				memoryStream_0.Close();
			}
		}
	}
}
