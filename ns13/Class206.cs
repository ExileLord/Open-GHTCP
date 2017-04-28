using System;
using System.IO;
using Compression.Tar;

namespace ns13
{
	public class Class206
	{
		private Stream stream_0;

		private Stream stream_1;

		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private readonly int int_2 = 10240;

		private readonly int int_3 = 20;

		public int method_0()
		{
			return int_2;
		}

		public int method_1()
		{
			return int_3;
		}

	    public byte[] method_2()
		{
			if (stream_0 == null)
			{
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			if (int_0 >= method_1() && !method_3())
			{
				throw new TarException("Failed to read a record");
			}
			var array = new byte[512];
			Array.Copy(byte_0, int_0 * 512, array, 0, 512);
			int_0++;
			return array;
		}

		private bool method_3()
		{
			if (stream_0 == null)
			{
				throw new TarException("no input stream stream defined");
			}
			int_0 = 0;
			var num = 0;
			long num2;
			for (var i = method_0(); i > 0; i -= (int)num2)
			{
				num2 = stream_0.Read(byte_0, num, i);
				if (num2 <= 0L)
				{
					break;
				}
				num += (int)num2;
			}
			int_1++;
			return true;
		}

		public void method_4(byte[] byte_1)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
			if (byte_1.Length != 512)
			{
				var string_ = string.Format("TarBuffer.WriteBlock - block to write has length '{0}' which is not the block size of '{1}'", byte_1.Length, 512);
				throw new TarException(string_);
			}
			if (int_0 >= method_1())
			{
				method_6();
			}
			Array.Copy(byte_1, 0, byte_0, int_0 * 512, 512);
			int_0++;
		}

		public void method_5(byte[] byte_1, int int_4)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (int_4 < 0 || int_4 >= byte_1.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_4 + 512 > byte_1.Length)
			{
				var string_ = string.Format("TarBuffer.WriteBlock - record has length '{0}' with offset '{1}' which is less than the record size of '{2}'", byte_1.Length, int_4, int_2);
				throw new TarException(string_);
			}
			if (int_0 >= method_1())
			{
				method_6();
			}
			Array.Copy(byte_1, int_4, byte_0, int_0 * 512, 512);
			int_0++;
		}

		private void method_6()
		{
			if (stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			stream_1.Write(byte_0, 0, method_0());
			stream_1.Flush();
			int_0 = 0;
			int_1++;
		}

		private void method_7()
		{
			if (stream_1 == null)
			{
				throw new TarException("TarBuffer.Flush no output stream defined");
			}
			if (int_0 > 0)
			{
				var num = int_0 * 512;
				Array.Clear(byte_0, num, method_0() - num);
				method_6();
			}
			stream_1.Flush();
		}

		public void method_8()
		{
			if (stream_1 != null)
			{
				method_7();
				stream_1.Close();
				stream_1 = null;
				return;
			}
			if (stream_0 != null)
			{
				stream_0.Close();
				stream_0 = null;
			}
		}
	}
}
