using System;
using System.IO;

namespace ns22
{
	public class StreamClass2 : IDisposable
	{
		private int int_0;

		private readonly int int_1;

		private readonly Stream stream_0;

		public static void smethod_0(Stream stream_1, int int_2, long long_0)
		{
			var position = stream_1.Position;
			stream_1.Seek(long_0 + 4L, SeekOrigin.Begin);
			var binaryWriter = new BinaryWriter(stream_1);
			binaryWriter.Write((uint)(38 + int_2));
			stream_1.Seek(long_0 + 42L, SeekOrigin.Begin);
			binaryWriter.Write((uint)int_2);
			stream_1.Seek(position, SeekOrigin.Begin);
		}

		public void Dispose()
		{
			if (int_1 < 1)
			{
				smethod_0(stream_0, int_0 * 2, 0L);
			}
		}
	}
}
