using System;
using System.IO;

namespace ns22
{
	public class UnusedStreamClass : IDisposable
	{
		private static readonly byte[] byte_0 = {
			0,
			0,
			1,
			186
		};

		private static readonly byte[] byte_1 = {
			0,
			0,
			1,
			187
		};

		private static readonly byte[] byte_2 = {
			0,
			0,
			1,
			224
		};

		private static readonly byte[] byte_3 = {
			0,
			0,
			1,
			189
		};

		private static readonly byte[] byte_4 = {
			0,
			0,
			1,
			190
		};

		private static readonly byte[] byte_5 = {
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
				stream_0.Close();
			}
			catch
			{
			}
			bool_0 = true;
		}
	}
}
