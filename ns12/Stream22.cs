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
		private string password;

		private ICryptoTransform icryptoTransform_0;

		private byte[] byte_0;

		public Class194 class194_0;

		public Stream stream_0;

		private bool bool_0;

		private bool bool_1 = true;

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
				return stream_0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return stream_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return stream_0.Position;
			}
			set
			{
				throw new NotSupportedException("Position property not supported");
			}
		}

		public Stream22(Stream stream_1, Class194 class194_1) : this(stream_1, class194_1, 512)
		{
		}

		public Stream22(Stream stream_1, Class194 class194_1, int int_0)
		{
			if (stream_1 == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!stream_1.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (class194_1 == null)
			{
				throw new ArgumentNullException("deflater");
			}
			if (int_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			stream_0 = stream_1;
			byte_0 = new byte[int_0];
			class194_0 = class194_1;
		}

		public virtual void vmethod_0()
		{
			class194_0.method_3();
			while (!class194_0.method_4())
			{
				int num = class194_0.method_9(byte_0, 0, byte_0.Length);
				if (num <= 0)
				{
					break;
				}
				if (icryptoTransform_0 != null)
				{
					method_3(byte_0, 0, num);
				}
				stream_0.Write(byte_0, 0, num);
			}
			if (!class194_0.method_4())
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			stream_0.Flush();
			if (icryptoTransform_0 != null)
			{
				icryptoTransform_0.Dispose();
				icryptoTransform_0 = null;
			}
		}

		public bool method_0()
		{
			return stream_0.CanSeek;
		}

		public string method_1()
		{
			return password;
		}

		public void method_2(string password)
		{
			if (password != null && password.Length == 0)
			{
				this.password = null;
				return;
			}
			this.password = password;
		}

		public void method_3(byte[] byte_1, int int_0, int int_1)
		{
			icryptoTransform_0.TransformBlock(byte_1, 0, int_1, byte_1, 0);
		}

		public void method_4(string string_1)
		{
			Class208 @class = new Class208();
			byte[] rgbKey = Class207.smethod_0(Class186.smethod_3(string_1));
			icryptoTransform_0 = @class.CreateEncryptor(rgbKey, null);
		}

		public void method_5()
		{
			while (!class194_0.method_5())
			{
				int num = class194_0.method_9(byte_0, 0, byte_0.Length);
				if (num <= 0)
				{
					break;
				}
				if (icryptoTransform_0 != null)
				{
					method_3(byte_0, 0, num);
				}
				stream_0.Write(byte_0, 0, num);
			}
			if (!class194_0.method_5())
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
			class194_0.method_2();
			method_5();
			stream_0.Flush();
		}

		public override void Close()
		{
			if (!bool_0)
			{
				bool_0 = true;
				try
				{
					vmethod_0();
					if (icryptoTransform_0 != null)
					{
						icryptoTransform_0.Dispose();
						icryptoTransform_0 = null;
					}
				}
				finally
				{
					if (bool_1)
					{
						stream_0.Close();
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
			class194_0.method_6(buffer, offset, count);
			method_5();
		}
	}
}
