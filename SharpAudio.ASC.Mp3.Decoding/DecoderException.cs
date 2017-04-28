using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class DecoderException : Mp3Exception
	{
		public readonly DecoderError Error;

		public DecoderException(string string_0, Exception exception_0) : base(string_0, exception_0)
		{
			Error = DecoderError.UnknownError;
		}

		public DecoderException(DecoderError decoderError_0, Exception exception_0) : this(smethod_0(decoderError_0), exception_0)
		{
			Error = decoderError_0;
		}

		public static string smethod_0(DecoderError decoderError_0)
		{
			return "Decoder error: " + decoderError_0;
		}
	}
}
