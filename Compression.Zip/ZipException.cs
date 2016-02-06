using System;
using System.Runtime.Serialization;

namespace Compression.Zip
{
	[Serializable]
	public class ZipException : SharpZipBaseException
	{
		public ZipException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0) : base(serializationInfo_0, streamingContext_0)
		{
		}

		public ZipException()
		{
		}

		public ZipException(string string_0) : base(string_0)
		{
		}
	}
}
