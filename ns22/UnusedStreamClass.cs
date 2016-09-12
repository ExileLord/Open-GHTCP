using System;
using System.IO;

namespace ns22
{
	public class UnusedStreamClass : IDisposable
	{
		private static readonly byte[] byte_0 = new byte[]
		{
			0,
			0,
			1,
			186
		};

		private static readonly byte[] byte_1 = new byte[]
		{
			0,
			0,
			1,
			187
		};

		private static readonly byte[] byte_2 = new byte[]
		{
			0,
			0,
			1,
			224
		};

		private static readonly byte[] byte_3 = new byte[]
		{
			0,
			0,
			1,
			189
		};

		private static readonly byte[] byte_4 = new byte[]
		{
			0,
			0,
			1,
			190
		};

		private static readonly byte[] byte_5 = new byte[]
		{
			0,
			0,
			1,
			185
		};

		private bool bool_0;

		private readonly Stream stream_0;

		public void Dispose()
		{
			try
			{
				this.stream_0.Close();
			}
			catch
			{
			}
			this.bool_0 = true;
		}
	}
}
