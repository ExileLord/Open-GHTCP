using System;
using System.IO;

namespace ns8
{
	public static class Class166
	{
		private static byte[] byte_0 = new byte[16384];

		public static void smethod_0(Stream stream_0, Stream stream_1)
		{
			stream_1.Position = 0L;
			int num;
			do
			{
				num = stream_1.Read(Class166.byte_0, 0, Class166.byte_0.Length);
				stream_0.Write(Class166.byte_0, 0, num);
			}
			while (num != 0);
		}
	}
}
