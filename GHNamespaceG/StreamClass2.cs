using System;
using System.IO;

namespace GHNamespaceG
{
	public class StreamClass2 : IDisposable
	{
		private int _int0;

		private readonly int _int1;

		private readonly Stream _stream0;

		public static void smethod_0(Stream stream1, int int2, long long0)
		{
			var position = stream1.Position;
			stream1.Seek(long0 + 4L, SeekOrigin.Begin);
			var binaryWriter = new BinaryWriter(stream1);
			binaryWriter.Write((uint)(38 + int2));
			stream1.Seek(long0 + 42L, SeekOrigin.Begin);
			binaryWriter.Write((uint)int2);
			stream1.Seek(position, SeekOrigin.Begin);
		}

		public void Dispose()
		{
			if (_int1 < 1)
			{
				smethod_0(_stream0, _int0 * 2, 0L);
			}
		}
	}
}
