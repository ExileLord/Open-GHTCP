using System;
using System.IO;
using Compression;
using Compression.Zip;
using ns13;

namespace ns12
{
	public class Stream19 : Stream
	{
		public Class196 Class1960;

		public Class201 Class2010;

		public Stream Stream0;

		public long Long0;

		private bool _bool0;

		private readonly bool _bool1 = true;

		public override bool CanRead
		{
			get
			{
				return Stream0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				return Class2010.method_0();
			}
		}

		public override long Position
		{
			get
			{
				return Stream0.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		public Stream19(Stream stream1, Class196 class1961) : this(stream1, class1961, 4096)
		{
		}

		public Stream19(Stream stream1, Class196 class1961, int int0)
		{
			if (stream1 == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (class1961 == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (int0 <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			Stream0 = stream1;
			Class1960 = class1961;
			Class2010 = new Class201(stream1, int0);
		}

		public long method_0(long long1)
		{
			if (long1 < 0L)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (Stream0.CanSeek)
			{
				Stream0.Seek(long1, SeekOrigin.Current);
				return long1;
			}
			var num = 2048;
			if (long1 < 2048L)
			{
				num = (int)long1;
			}
			var array = new byte[num];
			return Stream0.Read(array, 0, array.Length);
		}

		public void method_1()
		{
			Class2010.method_12(null);
		}

		public void method_2()
		{
			Class2010.method_4();
			Class2010.method_3(Class1960);
		}

		public override void Flush()
		{
			Stream0.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		public override void Close()
		{
			if (!_bool0)
			{
				_bool0 = true;
				if (_bool1)
				{
					Stream0.Close();
				}
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (Class1960.method_9())
			{
				throw new SharpZipBaseException("Need a dictionary");
			}
			var num = count;
			while (true)
			{
				var num2 = Class1960.method_7(buffer, offset, num);
				offset += num2;
				num -= num2;
				if (num == 0 || Class1960.method_10())
				{
					goto IL_69;
				}
				if (Class1960.method_8())
				{
					method_2();
				}
				else if (num2 == 0)
				{
					break;
				}
			}
			throw new ZipException("Dont know what to do");
			IL_69:
			return count - num;
		}
	}
}
