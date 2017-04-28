using System.IO;

namespace ns8
{
	public static class StreamHelper
	{
		private static readonly byte[] _buffer = new byte[16384];

		public static void CopyStream(Stream destination, Stream source)
		{
			source.Position = 0L;
			int bytesRead;
			do
			{
				bytesRead = source.Read(_buffer, 0, _buffer.Length);
				destination.Write(_buffer, 0, bytesRead);
			}
			while (bytesRead != 0);
		}
	}
}
