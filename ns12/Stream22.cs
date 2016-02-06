using Compression;
using ns13;
using ns14;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ns12
{
	public class Stream22 : Stream
	{
		private string string_0;

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
				return this.stream_0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this.stream_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.stream_0.Position;
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
			this.stream_0 = stream_1;
			this.byte_0 = new byte[int_0];
			this.class194_0 = class194_1;
		}

		public virtual void vmethod_0()
		{
			this.class194_0.method_3();
			while (!this.class194_0.method_4())
			{
				int num = this.class194_0.method_9(this.byte_0, 0, this.byte_0.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.icryptoTransform_0 != null)
				{
					this.method_3(this.byte_0, 0, num);
				}
				this.stream_0.Write(this.byte_0, 0, num);
			}
			if (!this.class194_0.method_4())
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			this.stream_0.Flush();
			if (this.icryptoTransform_0 != null)
			{
				this.icryptoTransform_0.Dispose();
				this.icryptoTransform_0 = null;
			}
		}

		public bool method_0()
		{
			return this.stream_0.CanSeek;
		}

		public string method_1()
		{
			return this.string_0;
		}

		public void method_2(string string_1)
		{
			if (string_1 != null && string_1.Length == 0)
			{
				this.string_0 = null;
				return;
			}
			this.string_0 = string_1;
		}

		public void method_3(byte[] byte_1, int int_0, int int_1)
		{
			this.icryptoTransform_0.TransformBlock(byte_1, 0, int_1, byte_1, 0);
		}

		public void method_4(string string_1)
		{
			Class208 @class = new Class208();
			byte[] rgbKey = Class207.smethod_0(Class186.smethod_3(string_1));
			this.icryptoTransform_0 = @class.CreateEncryptor(rgbKey, null);
		}

		public void method_5()
		{
			while (!this.class194_0.method_5())
			{
				int num = this.class194_0.method_9(this.byte_0, 0, this.byte_0.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.icryptoTransform_0 != null)
				{
					this.method_3(this.byte_0, 0, num);
				}
				this.stream_0.Write(this.byte_0, 0, num);
			}
			if (!this.class194_0.method_5())
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
			this.class194_0.method_2();
			this.method_5();
			this.stream_0.Flush();
		}

		public override void Close()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				try
				{
					this.vmethod_0();
					if (this.icryptoTransform_0 != null)
					{
						this.icryptoTransform_0.Dispose();
						this.icryptoTransform_0 = null;
					}
				}
				finally
				{
					if (this.bool_1)
					{
						this.stream_0.Close();
					}
				}
			}
		}

		public override void WriteByte(byte value)
		{
			this.Write(new byte[]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.class194_0.method_6(buffer, offset, count);
			this.method_5();
		}
	}
}
