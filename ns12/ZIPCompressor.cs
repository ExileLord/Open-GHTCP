using System;
using System.IO;
using Compression.Zip;
using ns13;
using ns14;

namespace ns12
{
	public class ZipCompressor : Stream19
	{
		private delegate int Delegate5(byte[] b, int offset, int length);

		private Delegate5 _delegate50;

		private Class192 _class1920 = new Class192();

		private Class193 _class1930;

		private long _long1;

		private int _int0;

		private int _int1;

		private string _password;

		public override long Length
		{
			get
			{
				if (_class1930 == null)
				{
					throw new InvalidOperationException("No current entry");
				}
				if (_class1930.method_21() < 0L)
				{
					throw new ZipException("Length not available for the current entry");
				}
				return _class1930.method_21();
			}
		}

		public ZipCompressor(Stream stream1) : base(stream1, new Class196(true))
		{
			_delegate50 = method_9;
		}

		public void method_3(string password)
		{
			this._password = password;
		}

		public bool method_4()
		{
			return _class1930 != null && _class1930.method_12();
		}

		public Class193 method_5()
		{
			if (_class1920 == null)
			{
				throw new InvalidOperationException("Closed.");
			}
			if (_class1930 != null)
			{
				method_8();
			}
			var num = Class2010.method_10();
			if (num != 33639248 && num != 101010256 && num != 84233040 && num != 117853008)
			{
				if (num != 101075792)
				{
					if (num == 808471376 || num == 134695760)
					{
						num = Class2010.method_10();
					}
					if (num != 67324752)
					{
						throw new ZipException("Wrong Local header signature: 0x" + string.Format("{0:X}", num));
					}
					var int_ = (short)Class2010.method_9();
					_int1 = Class2010.method_9();
					_int0 = Class2010.method_9();
					var num2 = (uint)Class2010.method_10();
					var num3 = Class2010.method_10();
					Long0 = Class2010.method_10();
					_long1 = Class2010.method_10();
					var num4 = Class2010.method_9();
					var num5 = Class2010.method_9();
					var flag = (_int1 & 1) == 1;
					var array = new byte[num4];
					Class2010.method_5(array);
					var string_ = Class186.smethod_2(_int1, array);
					_class1930 = new Class193(string_, int_);
					_class1930.method_5(_int1);
					_class1930.method_28((Enum31)_int0);
					if ((_int1 & 8) == 0)
					{
						_class1930.method_26(num3 & 4294967295L);
						_class1930.method_22(_long1 & 4294967295L);
						_class1930.method_24(Long0 & 4294967295L);
						_class1930.method_3((byte)(num3 >> 24 & 255));
					}
					else
					{
						if (num3 != 0)
						{
							_class1930.method_26(num3 & 4294967295L);
						}
						if (_long1 != 0L)
						{
							_class1930.method_22(_long1 & 4294967295L);
						}
						if (Long0 != 0L)
						{
							_class1930.method_24(Long0 & 4294967295L);
						}
						_class1930.method_3((byte)(num2 >> 8 & 255u));
					}
					_class1930.method_18(num2);
					if (num5 > 0)
					{
						var array2 = new byte[num5];
						Class2010.method_5(array2);
						_class1930.method_30(array2);
					}
					_class1930.method_31(true);
					if (_class1930.method_23() >= 0L)
					{
						Long0 = _class1930.method_23();
					}
					if (_class1930.method_21() >= 0L)
					{
						_long1 = _class1930.method_21();
					}
					if (_int0 == 0 && ((!flag && Long0 != _long1) || (flag && Long0 - 12L != _long1)))
					{
						throw new ZipException("Stored, but compressed != uncompressed");
					}
					if (_class1930.method_34())
					{
						_delegate50 = method_11;
					}
					else
					{
						_delegate50 = method_10;
					}
					return _class1930;
				}
			}
			Close();
			return null;
		}

		private void method_6()
		{
			if (Class2010.method_10() != 134695760)
			{
				throw new ZipException("Data descriptor signature not found");
			}
			_class1930.method_26(Class2010.method_10() & 4294967295L);
			if (_class1930.method_15())
			{
				Long0 = Class2010.method_11();
				_long1 = Class2010.method_11();
			}
			else
			{
				Long0 = Class2010.method_10();
				_long1 = Class2010.method_10();
			}
			_class1930.method_24(Long0);
			_class1930.method_22(_long1);
		}

		private void method_7(bool bool2)
		{
			method_1();
			if ((_int1 & 8) != 0)
			{
				method_6();
			}
			_long1 = 0L;
			if (bool2 && (_class1920.vmethod_0() & 4294967295L) != _class1930.method_25() && _class1930.method_25() != -1L)
			{
				throw new ZipException("CRC mismatch");
			}
			_class1920.vmethod_1();
			if (_int0 == 8)
			{
				Class1960.method_0();
			}
			_class1930 = null;
		}

		public void method_8()
		{
			if (_class1920 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (_class1930 == null)
			{
				return;
			}
			if (_int0 == 8)
			{
				if ((_int1 & 8) != 0)
				{
					var array = new byte[2048];
					while (Read(array, 0, array.Length) > 0)
					{
					}
					return;
				}
				Long0 -= Class1960.method_12();
				var expr67 = Class2010;
				expr67.method_2(expr67.method_1() + Class1960.method_13());
			}
			if (Class2010.method_1() > Long0 && Long0 >= 0L)
			{
				Class2010.method_2((int)(Class2010.method_1() - Long0));
			}
			else
			{
				Long0 -= Class2010.method_1();
				Class2010.method_2(0);
				while (Long0 != 0L)
				{
					var num = (int)method_0(Long0 & 4294967295L);
					if (num <= 0)
					{
						throw new ZipException("Zip archive ends early.");
					}
					Long0 -= num;
				}
			}
			method_7(false);
		}

		public override int ReadByte()
		{
			var array = new byte[1];
			if (Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return array[0] & 255;
		}

		private int method_9(byte[] byte0, int int2, int int3)
		{
			throw new InvalidOperationException("Unable to read from this stream");
		}

		private int method_10(byte[] byte0, int int2, int int3)
		{
			throw new ZipException("The compression method for this entry is not supported");
		}

		private int method_11(byte[] byte0, int int2, int int3)
		{
			if (!method_4())
			{
				throw new ZipException("Library cannot extract this entry. Version required is (" + _class1930.method_11() + ")");
			}
			if (_class1930.method_0())
			{
				if (_password == null)
				{
					throw new ZipException("No password set.");
				}
				var @class = new Class208();
				var rgbKey = Class207.smethod_0(Class186.smethod_3(_password));
				Class2010.method_12(@class.CreateDecryptor(rgbKey, null));
				var array = new byte[12];
				Class2010.method_7(array, 0, 12);
				if (array[11] != _class1930.method_2())
				{
					throw new ZipException("Invalid password");
				}
				if (Long0 >= 12L)
				{
					Long0 -= 12L;
				}
				else if ((_class1930.method_4() & 8) == 0)
				{
					throw new ZipException(string.Format("Entry compressed size {0} too small for encryption", Long0));
				}
			}
			else
			{
				Class2010.method_12(null);
			}
			if (_int0 == 8 && Class2010.method_1() > 0)
			{
				Class2010.method_3(Class1960);
			}
			_delegate50 = method_12;
			return method_12(byte0, int2, int3);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Invalid offset/count combination");
			}
			return _delegate50(buffer, offset, count);
		}

		private int method_12(byte[] byte0, int int2, int int3)
		{
			if (_class1920 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (_class1930 == null || int3 <= 0)
			{
				return 0;
			}
			if (int2 + int3 > byte0.Length)
			{
				throw new ArgumentException("Offset + count exceeds buffer size");
			}
			var flag = false;
			var num = _int0;
			if (num != 0)
			{
				if (num == 8)
				{
					int3 = base.Read(byte0, int2, int3);
					if (int3 <= 0)
					{
						if (!Class1960.method_10())
						{
							throw new ZipException("Inflater not finished!");
						}
						Class2010.method_2(Class1960.method_13());
						if ((_int1 & 8) == 0 && (Class1960.method_12() != Long0 || Class1960.method_11() != _long1))
						{
							throw new ZipException(string.Concat("Size mismatch: ", Long0, ";", _long1, " <-> ", Class1960.method_12(), ";", Class1960.method_11()));
						}
						Class1960.method_0();
						flag = true;
					}
				}
			}
			else
			{
				if (int3 > Long0 && Long0 >= 0L)
				{
					int3 = (int)Long0;
				}
				if (int3 > 0)
				{
					int3 = Class2010.method_7(byte0, int2, int3);
					if (int3 > 0)
					{
						Long0 -= int3;
						_long1 -= int3;
					}
				}
				if (Long0 == 0L)
				{
					flag = true;
				}
				else if (int3 < 0)
				{
					throw new ZipException("EOF in stored block");
				}
			}
			if (int3 > 0)
			{
				_class1920.vmethod_3(byte0, int2, int3);
			}
			if (flag)
			{
				method_7(true);
			}
			return int3;
		}

		public override void Close()
		{
			_delegate50 = method_9;
			_class1920 = null;
			_class1930 = null;
			base.Close();
		}
	}
}
