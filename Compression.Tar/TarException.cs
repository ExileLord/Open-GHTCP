using System;
using System.Runtime.Serialization;

namespace Compression.Tar
{
	[Serializable]
	public class TarException : SharpZipBaseException
	{
		public TarException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0) : base(serializationInfo_0, streamingContext_0)
		{
		}

		public TarException()
		{
		}

		public TarException(string string_0) : base(string_0)
		{
		}
	}
}
