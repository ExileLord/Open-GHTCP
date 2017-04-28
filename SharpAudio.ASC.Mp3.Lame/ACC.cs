using System;

namespace SharpAudio.ASC.Mp3.Lame
{
    [Serializable]
    public struct Acc
    {
        public uint DwSampleRate;

        public byte ByMode;

        public ushort WBitrate;

        public byte ByEncodingMethod;
    }
}