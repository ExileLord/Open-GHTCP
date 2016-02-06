using Compression.Tar;
using System;
using System.IO;

namespace ns13
{
	public class Class206
	{
		private Stream stream_0;

		private Stream stream_1;

		private byte[] byte_0;

		private int int_0;

		private int int_1;

		private int int_2 = 10240;

		private int int_3 = 20;

		public int method_0()
		{
			return this.int_2;
		}

		public int method_1()
		{
			return this.int_3;
		}

		public Class206()
		{
		}

		public byte[] method_2()
		{
			if (this.stream_0 == null)
			{
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			if (this.int_0 >= this.method_1() && !this.method_3())
			{
				throw new TarException("Failed to read a record");
			}
			byte[] array = new byte[512];
			Array.Copy(this.byte_0, this.int_0 * 512, array, 0, 512);
			this.int_0++;
			return array;
		}

		private bool method_3()
		{
			if (this.stream_0 == null)
			{
				throw new TarException("no input stream stream defined");
			}
			this.int_0 = 0;
			int num = 0;
			long num2;
			for (int i = this.method_0(); i > 0; i -= (int)num2)
			{
				num2 = (long)this.stream_0.Read(this.byte_0, num, i);
				if (num2 <= 0L)
				{
					break;
				}
				num += (int)num2;
			}
			this.int_1++;
			return true;
		}

		public void method_4(byte[] byte_1)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (this.stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
			if (byte_1.Length != 512)
			{
				string string_ = string.Format("TarBuffer.WriteBlock - block to write has length '{0}' which is not the block size of '{1}'", byte_1.Length, 512);
				throw new TarException(string_);
			}
			if (this.int_0 >= this.method_1())
			{
				this.method_6();
			}
			Array.Copy(byte_1, 0, this.byte_0, this.int_0 * 512, 512);
			this.int_0++;
		}

		public void method_5(byte[] byte_1, int int_4)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (this.stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (int_4 < 0 || int_4 >= byte_1.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int_4 + 512 > byte_1.Length)
			{
				string string_ = string.Format("TarBuffer.WriteBlock - record has length '{0}' with offset '{1}' which is less than the record size of '{2}'", byte_1.Length, int_4, this.int_2);
				throw new TarException(string_);
			}
			if (this.int_0 >= this.method_1())
			{
				this.method_6();
			}
			Array.Copy(byte_1, int_4, this.byte_0, this.int_0 * 512, 512);
			this.int_0++;
		}

		private void method_6()
		{
			if (this.stream_1 == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			this.stream_1.Write(this.byte_0, 0, this.method_0());
			this.stream_1.Flush();
			this.int_0 = 0;
			this.int_1++;
		}

		private void method_7()
		{
			if (this.stream_1 == null)
			{
				throw new TarException("TarBuffer.Flush no output stream defined");
			}
			if (this.int_0 > 0)
			{
				int num = this.int_0 * 512;
				Array.Clear(this.byte_0, num, this.method_0() - num);
				this.method_6();
			}
			this.stream_1.Flush();
		}

		public void method_8()
		{
			if (this.stream_1 != null)
			{
				this.method_7();
				this.stream_1.Close();
				this.stream_1 = null;
				return;
			}
			if (this.stream_0 != null)
			{
				this.stream_0.Close();
				this.stream_0 = null;
			}
		}
	}
}
