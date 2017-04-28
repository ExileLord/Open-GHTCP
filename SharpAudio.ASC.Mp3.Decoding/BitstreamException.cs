using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class BitstreamException : Exception
	{
		public readonly BitstreamError Error;

		public BitstreamException(string string_0, Exception exception_0) : base(string_0, exception_0)
		{
			Error = BitstreamError.UnknownError;
		}

		public BitstreamException(BitstreamError bitstreamError_0) : this(bitstreamError_0, null)
		{
		}

		public BitstreamException(BitstreamError bitstreamError_0, Exception exception_0) : this(smethod_0(bitstreamError_0), exception_0)
		{
			Error = bitstreamError_0;
		}

		public static string smethod_0(BitstreamError bitstreamError_0)
		{
			return "Bitstream error: " + bitstreamError_0;
		}
	}
}
