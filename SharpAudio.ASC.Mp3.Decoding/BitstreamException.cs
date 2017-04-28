using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class BitstreamException : Exception
	{
		public readonly BitstreamError Error;

		public BitstreamException(string string0, Exception exception0) : base(string0, exception0)
		{
			Error = BitstreamError.UnknownError;
		}

		public BitstreamException(BitstreamError bitstreamError0) : this(bitstreamError0, null)
		{
		}

		public BitstreamException(BitstreamError bitstreamError0, Exception exception0) : this(smethod_0(bitstreamError0), exception0)
		{
			Error = bitstreamError0;
		}

		public static string smethod_0(BitstreamError bitstreamError0)
		{
			return "Bitstream error: " + bitstreamError0;
		}
	}
}
