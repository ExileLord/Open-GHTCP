using System;
using System.IO;
using Compression.Tar;

namespace ns13
{
	public class Class206
	{
		private Stream _stream0;

		private Stream _stream1;

		private byte[] _byte0;

		private int _int0;

		private int _int1;

		private readonly int _int2 = 10240;

		private readonly int _int3 = 20;

		public int method_0()
		{
			return _int2;
		}

		public int method_1()
		{
			return _int3;
		}

	    public byte[] method_2()
		{
			if (_stream0 == null)
			{
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			if (_int0 >= method_1() && !method_3())
			{
				throw new TarException("Failed to read a record");
			}
			var array = new byte[512];
			Array.Copy(_byte0, _int0 * 512, array, 0, 512);
			_int0++;
			return array;
		}

		private bool method_3()
		{
			if (_stream0 == null)
			{
				throw new TarException("no input stream stream defined");
			}
			_int0 = 0;
			var num = 0;
			long num2;
			for (var i = method_0(); i > 0; i -= (int)num2)
			{
				num2 = _stream0.Read(_byte0, num, i);
				if (num2 <= 0L)
				{
					break;
				}
				num += (int)num2;
			}
			_int1++;
			return true;
		}

		public void method_4(byte[] byte1)
		{
			if (byte1 == null)
			{
				throw new ArgumentNullException("block");
			}
			if (_stream1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
			if (byte1.Length != 512)
			{
				var string_ = string.Format("TarBuffer.WriteBlock - block to write has length '{0}' which is not the block size of '{1}'", byte1.Length, 512);
				throw new TarException(string_);
			}
			if (_int0 >= method_1())
			{
				method_6();
			}
			Array.Copy(byte1, 0, _byte0, _int0 * 512, 512);
			_int0++;
		}

		public void method_5(byte[] byte1, int int4)
		{
			if (byte1 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (_stream1 == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (int4 < 0 || int4 >= byte1.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (int4 + 512 > byte1.Length)
			{
				var string_ = string.Format("TarBuffer.WriteBlock - record has length '{0}' with offset '{1}' which is less than the record size of '{2}'", byte1.Length, int4, _int2);
				throw new TarException(string_);
			}
			if (_int0 >= method_1())
			{
				method_6();
			}
			Array.Copy(byte1, int4, _byte0, _int0 * 512, 512);
			_int0++;
		}

		private void method_6()
		{
			if (_stream1 == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			_stream1.Write(_byte0, 0, method_0());
			_stream1.Flush();
			_int0 = 0;
			_int1++;
		}

		private void method_7()
		{
			if (_stream1 == null)
			{
				throw new TarException("TarBuffer.Flush no output stream defined");
			}
			if (_int0 > 0)
			{
				var num = _int0 * 512;
				Array.Clear(_byte0, num, method_0() - num);
				method_6();
			}
			_stream1.Flush();
		}

		public void method_8()
		{
			if (_stream1 != null)
			{
				method_7();
				_stream1.Close();
				_stream1 = null;
				return;
			}
			if (_stream0 != null)
			{
				_stream0.Close();
				_stream0 = null;
			}
		}
	}
}
