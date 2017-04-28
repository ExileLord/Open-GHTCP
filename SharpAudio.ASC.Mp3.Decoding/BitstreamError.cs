namespace SharpAudio.ASC.Mp3.Decoding
{
	public enum BitstreamError
	{
		UnknownError = 256,
		UnknownSampleRate,
		StreamError,
		UnexpectedEOF,
		StreamEOF,
		InvalidFrame,
		BitStreamLast = 511
	}
}
