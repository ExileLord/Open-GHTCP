using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class DecoderException : Mp3Exception
	{
		public readonly DecoderError Error;

		public DecoderException(string string0, Exception exception0) : base(string0, exception0)
		{
			Error = DecoderError.UnknownError;
		}

		public DecoderException(DecoderError decoderError0, Exception exception0) : this(smethod_0(decoderError0), exception0)
		{
			Error = decoderError0;
		}

		public static string smethod_0(DecoderError decoderError0)
		{
			return "Decoder error: " + decoderError0;
		}
	}
}
