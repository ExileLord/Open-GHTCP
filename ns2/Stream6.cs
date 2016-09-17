using ns0;
using ns1;
using ns10;
using ns3;
using ns4;
using System;
using System.IO;

namespace ns2
{
	public class Stream6 : GenericAudioStream, IDisposable
	{
		private readonly Class16 class16_0;

		private readonly Class61 class61_0;

		private readonly Class78 class78_0;

		private readonly VorbisClass class75_0;

		private readonly Class33 class33_0;

		private readonly Class74 class74_0;

		public override bool CanRead
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool CanSeek
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool CanWrite
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override Class16 vmethod_1()
		{
			return this.class16_0;
		}

		public void method_0()
		{
			this.class78_0.method_1();
			this.class74_0.method_0();
			this.class33_0.method_0();
			this.class75_0.method_0();
			this.class61_0.method_0();
			Console.WriteLine("Done.");
			this.fileStream.Close();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException();
		}

		private void method_1(bool bool_0)
		{
			if (bool_0)
			{
				this.method_0();
			}
		}

		public new void Dispose()
		{
			this.method_1(true);
			GC.SuppressFinalize(this);
		}
	}
}
