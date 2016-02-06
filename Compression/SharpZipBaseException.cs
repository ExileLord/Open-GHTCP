using System;
using System.Runtime.Serialization;

namespace Compression
{
	[Serializable]
	public class SharpZipBaseException : ApplicationException
	{
		public SharpZipBaseException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0) : base(serializationInfo_0, streamingContext_0)
		{
		}

		public SharpZipBaseException()
		{
		}

		public SharpZipBaseException(string string_0) : base(string_0)
		{
		}
	}
}
