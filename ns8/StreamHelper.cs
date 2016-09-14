using System;
using System.IO;

namespace ns8
{
	public static class StreamHelper
	{
		private static byte[] _buffer = new byte[16384];

		public static void CopyStream(Stream destination, Stream source)
		{
			source.Position = 0L;
			int bytesRead;
			do
			{
				bytesRead = source.Read(StreamHelper._buffer, 0, StreamHelper._buffer.Length);
				destination.Write(StreamHelper._buffer, 0, bytesRead);
			}
			while (bytesRead != 0);
		}
	}
}
