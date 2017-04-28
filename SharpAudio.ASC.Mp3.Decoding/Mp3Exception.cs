using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
    [Serializable]
    public class Mp3Exception : Exception
    {
        private readonly Exception _exception;

        public Mp3Exception()
        {
        }

        public Mp3Exception(string string0) : base(string0)
        {
        }

        public Mp3Exception(string string0, Exception exception0) : base(string0)
        {
            _exception = exception0;
        }
    }
}