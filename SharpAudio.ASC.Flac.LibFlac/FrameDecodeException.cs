using System;

namespace SharpAudio.ASC.Flac.LibFlac
{
    [Serializable]
    public class FrameDecodeException : Exception
    {
        public FrameDecodeException()
        {
        }

        public FrameDecodeException(string string0) : base(string0)
        {
        }
    }
}