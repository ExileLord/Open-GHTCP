using System;
using System.IO;
using GHNamespace1;
using GHNamespace2;
using GHNamespace3;
using GHNamespaceH;
using GHNamespaceI;

namespace GHNamespaceD
{
	public class Stream6 : GenericAudioStream, IDisposable
	{
		private readonly Class16 _class160;

		private readonly Class61 _class610;

		private readonly Class78 _class780;

		private readonly VorbisClass _class750;

		private readonly Class33 _class330;

		private readonly Class74 _class740;

		public override bool CanRead => throw new NotImplementedException();

	    public override bool CanSeek => throw new NotImplementedException();

	    public override bool CanWrite => throw new NotImplementedException();

	    public override long Length => throw new NotImplementedException();

	    public override long Position
		{
			get => throw new NotImplementedException();
		    set => throw new NotImplementedException();
		}

		public override Class16 vmethod_1()
		{
			return _class160;
		}

		public void method_0()
		{
			_class780.method_1();
			_class740.method_0();
			_class330.method_0();
			_class750.method_0();
			_class610.method_0();
			Console.WriteLine("Done.");
			FileStream.Close();
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

		private void method_1(bool bool0)
		{
			if (bool0)
			{
				method_0();
			}
		}

		public new void Dispose()
		{
			method_1(true);
			GC.SuppressFinalize(this);
		}
	}
}
