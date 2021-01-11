using System;
using System.Runtime.Serialization;

namespace Compression
{
    [Serializable]
    public class SharpZipBaseException : ApplicationException
    {
        public SharpZipBaseException(SerializationInfo serializationInfo0, StreamingContext streamingContext0) : base(
            serializationInfo0, streamingContext0)
        {
        }

        public SharpZipBaseException()
        {
        }

        public SharpZipBaseException(string string0) : base(string0)
        {
        }
    }
}