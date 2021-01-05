using System;

namespace AVTools.MpegUtils
{
    [Serializable]
    public class FfMpegException : Exception
    {
        public FfMpegException(string string0) : base(string0)
        {
        }
    }
}