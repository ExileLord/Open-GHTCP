using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class Mp3Exception : Exception
	{
		private readonly Exception exception;

		public Mp3Exception()
		{
		}

		public Mp3Exception(string string_0) : base(string_0)
		{
		}

		public Mp3Exception(string string_0, Exception exception_0) : base(string_0)
		{
			exception = exception_0;
		}
	}
}
