using System;
using System.IO;

namespace ns22
{
	public class Class351 : IDisposable
	{
		private int int_0;

		private readonly int int_1;

		private readonly Stream stream_0;

		public static void smethod_0(Stream stream_1, int int_2, long long_0)
		{
			long position = stream_1.Position;
			stream_1.Seek(long_0 + 4L, SeekOrigin.Begin);
			BinaryWriter binaryWriter = new BinaryWriter(stream_1);
			binaryWriter.Write((uint)(38 + int_2));
			stream_1.Seek(long_0 + 42L, SeekOrigin.Begin);
			binaryWriter.Write((uint)int_2);
			stream_1.Seek(position, SeekOrigin.Begin);
		}

		public void Dispose()
		{
			if (this.int_1 < 1)
			{
				Class351.smethod_0(this.stream_0, this.int_0 * 2, 0L);
			}
		}
	}
}
