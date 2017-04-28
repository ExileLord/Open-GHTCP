namespace SharpAudio.ASC.Mp3.Decoding
{
    public enum BitstreamError
    {
        UnknownError = 256,
        UnknownSampleRate,
        StreamError,
        UnexpectedEof,
        StreamEof,
        InvalidFrame,
        BitStreamLast = 511
    }
}