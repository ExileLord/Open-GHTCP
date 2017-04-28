using System;
using System.IO;
using System.Security.Cryptography;
using Compression;
using Compression.Zip;

namespace ns13
{
	public class Class201
	{
		private int int_0;

		private readonly byte[] byte_0;

		private int int_1;

		private byte[] byte_1;

		private byte[] byte_2;

		private int int_2;

		private ICryptoTransform icryptoTransform_0;

		private readonly Stream stream_0;

		public Class201(Stream stream_1, int int_3)
		{
			stream_0 = stream_1;
			if (int_3 < 1024)
			{
				int_3 = 1024;
			}
			byte_0 = new byte[int_3];
			byte_1 = byte_0;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_2;
		}

		public void method_2(int int_3)
		{
			int_2 = int_3;
		}

		public void method_3(Class196 class196_0)
		{
			if (int_2 > 0)
			{
				class196_0.method_6(byte_1, int_1 - int_2, int_2);
				int_2 = 0;
			}
		}

		public void method_4()
		{
			int_0 = 0;
			var i = byte_0.Length;
			while (i > 0)
			{
				var num = stream_0.Read(byte_0, int_0, i);
				if (num > 0)
				{
					int_0 += num;
					i -= num;
				}
				else
				{
					if (int_0 == 0)
					{
						throw new SharpZipBaseException("Unexpected EOF");
					}
                    goto IL_5A;

				}
			}
			IL_5A:
            if (icryptoTransform_0 != null)
			{
				int_1 = icryptoTransform_0.TransformBlock(byte_0, 0, int_0, byte_1, 0);
			}
			else
			{
				int_1 = int_0;
			}
			int_2 = int_1;
		}

		public int method_5(byte[] byte_3)
		{
			return method_6(byte_3, 0, byte_3.Length);
		}

		public int method_6(byte[] byte_3, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			var num = int_3;
			var i = int_4;
			while (i > 0)
			{
				if (int_2 <= 0)
				{
					method_4();
					if (int_2 <= 0)
					{
						return 0;
					}
				}
				var num2 = Math.Min(i, int_2);
				Array.Copy(byte_0, int_0 - int_2, byte_3, num, num2);
				num += num2;
				i -= num2;
				int_2 -= num2;
			}
			return int_4;
		}

		public int method_7(byte[] byte_3, int int_3, int int_4)
		{
			if (int_4 < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			var num = int_3;
			var i = int_4;
			while (i > 0)
			{
				if (int_2 <= 0)
				{
					method_4();
					if (int_2 <= 0)
					{
						return 0;
					}
				}
				var num2 = Math.Min(i, int_2);
				Array.Copy(byte_1, int_1 - int_2, byte_3, num, num2);
				num += num2;
				i -= num2;
				int_2 -= num2;
			}
			return int_4;
		}

		public int method_8()
		{
			if (int_2 <= 0)
			{
				method_4();
				if (int_2 <= 0)
				{
					throw new ZipException("EOF in header");
				}
			}
            var result = (byte)(byte_0[int_0 - int_2] & 255);
			int_2--;
			return result;
		}

		public int method_9()
		{
			return method_8() | method_8() << 8;
		}

		public int method_10()
		{
			return method_9() | method_9() << 16;
		}

		public long method_11()
		{
			return (long)((ulong)method_10() | (ulong)method_10() << 32);
		}

		public void method_12(ICryptoTransform icryptoTransform_1)
		{
			icryptoTransform_0 = icryptoTransform_1;
			if (icryptoTransform_0 != null)
			{
				if (byte_0 == byte_1)
				{
					if (byte_2 == null)
					{
						byte_2 = new byte[4096];
					}
					byte_1 = byte_2;
				}
				int_1 = int_0;
				if (int_2 > 0)
				{
					icryptoTransform_0.TransformBlock(byte_0, int_0 - int_2, int_2, byte_1, int_0 - int_2);
				}
			}
			else
			{
				byte_1 = byte_0;
				int_1 = int_0;
			}
		}
	}
}
