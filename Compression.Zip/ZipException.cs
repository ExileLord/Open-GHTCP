using System;
using System.Runtime.Serialization;

namespace Compression.Zip
{
    [Serializable]
    public class ZipException : SharpZipBaseException
    {
        public ZipException(SerializationInfo serializationInfo0, StreamingContext streamingContext0) : base(
            serializationInfo0, streamingContext0)
        {
        }

        public ZipException()
        {
        }

        public ZipException(string string0) : base(string0)
        {
        }
    }
}