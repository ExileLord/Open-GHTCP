using System;
using System.IO;
using SharpAudio.ASC;

namespace ns1
{
	public abstract class Stream14 : Stream, IDisposable
	{
		public Stream stream_0;

		public WaveFormat waveFormat_0;

		private static int int_0 = 368;

		private static int int_1 = 264;

		public virtual int vmethod_0()
		{
			return waveFormat_0.int_1 / 10;
		}

		public int method_0()
		{
			return vmethod_0();
		}

		public virtual Stream vmethod_1()
		{
			Flush();
			return stream_0;
		}

		public override void Close()
		{
			Dispose(true);
		}

		public override void Flush()
		{
			stream_0.Flush();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				stream_0.Close();
			}
		}

		public new virtual void Dispose()
		{
			Dispose(true);
		}
	}
}
