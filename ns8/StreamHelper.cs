using System.IO;

namespace ns8
{
	public static class StreamHelper
	{
		private static readonly byte[] Buffer = new byte[16384];

		public static void CopyStream(Stream destination, Stream source)
		{
			source.Position = 0L;
			int bytesRead;
			do
			{
				bytesRead = source.Read(Buffer, 0, Buffer.Length);
				destination.Write(Buffer, 0, bytesRead);
			}
			while (bytesRead != 0);
		}
	}
}
