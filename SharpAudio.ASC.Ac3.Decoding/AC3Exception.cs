using System;
using AVTools.MpegUtils;

namespace SharpAudio.ASC.Ac3.Decoding
{
    [Serializable]
    public class Ac3Exception : FfMpegException
    {
        public Ac3Exception(string string0) : base(string0)
        {
        }
    }
}