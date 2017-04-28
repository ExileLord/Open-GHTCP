using System;
using System.Runtime.Serialization;

namespace Compression.Tar
{
	[Serializable]
	public class TarException : SharpZipBaseException
	{
		public TarException(SerializationInfo serializationInfo0, StreamingContext streamingContext0) : base(serializationInfo0, streamingContext0)
		{
		}

		public TarException()
		{
		}

		public TarException(string string0) : base(string0)
		{
		}
	}
}
