using System;
using System.IO;
using System.Security.Cryptography;
using Compression;
using ns13;
using ns14;

namespace ns12
{
	public class Stream22 : Stream
	{
		private string _password;

		private ICryptoTransform _icryptoTransform0;

		private readonly byte[] _byte0;

		public Class194 Class1940;

		public Stream Stream0;

		private bool _bool0;

		private readonly bool _bool1 = true;

		public override bool CanRead
		{
			get
			{
				return false;
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
				return Stream0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return Stream0.Length;
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
				throw new NotSupportedException("Position property not supported");
			}
		}

		public Stream22(Stream stream1, Class194 class1941) : this(stream1, class1941, 512)
		{
		}

		public Stream22(Stream stream1, Class194 class1941, int int0)
		{
			if (stream1 == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!stream1.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (class1941 == null)
			{
				throw new ArgumentNullException("deflater");
			}
			if (int0 <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			Stream0 = stream1;
			_byte0 = new byte[int0];
			Class1940 = class1941;
		}

		public virtual void vmethod_0()
		{
			Class1940.method_3();
			while (!Class1940.method_4())
			{
				var num = Class1940.method_9(_byte0, 0, _byte0.Length);
				if (num <= 0)
				{
					break;
				}
				if (_icryptoTransform0 != null)
				{
					method_3(_byte0, 0, num);
				}
				Stream0.Write(_byte0, 0, num);
			}
			if (!Class1940.method_4())
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			Stream0.Flush();
			if (_icryptoTransform0 != null)
			{
				_icryptoTransform0.Dispose();
				_icryptoTransform0 = null;
			}
		}

		public bool method_0()
		{
			return Stream0.CanSeek;
		}

		public string method_1()
		{
			return _password;
		}

		public void method_2(string password)
		{
			if (password != null && password.Length == 0)
			{
				_password = null;
				return;
			}
			_password = password;
		}

		public void method_3(byte[] byte1, int int0, int int1)
		{
			_icryptoTransform0.TransformBlock(byte1, 0, int1, byte1, 0);
		}

		public void method_4(string string1)
		{
			var @class = new Class208();
			var rgbKey = Class207.smethod_0(Class186.smethod_3(string1));
			_icryptoTransform0 = @class.CreateEncryptor(rgbKey, null);
		}

		public void method_5()
		{
			while (!Class1940.method_5())
			{
				var num = Class1940.method_9(_byte0, 0, _byte0.Length);
				if (num <= 0)
				{
					break;
				}
				if (_icryptoTransform0 != null)
				{
					method_3(_byte0, 0, num);
				}
				Stream0.Write(_byte0, 0, num);
			}
			if (!Class1940.method_5())
			{
				throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

		public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("BeginWrite is not supported");
		}

		public override void Flush()
		{
			Class1940.method_2();
			method_5();
			Stream0.Flush();
		}

		public override void Close()
		{
			if (!_bool0)
			{
				_bool0 = true;
				try
				{
					vmethod_0();
					if (_icryptoTransform0 != null)
					{
						_icryptoTransform0.Dispose();
						_icryptoTransform0 = null;
					}
				}
				finally
				{
					if (_bool1)
					{
						Stream0.Close();
					}
				}
			}
		}

		public override void WriteByte(byte value)
		{
			Write(new[]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			Class1940.method_6(buffer, offset, count);
			method_5();
		}
	}
}
