using System;

namespace SharpAudio.ASC.Flac.LibFlac.frame
{
	[Serializable]
	public class BadHeaderException : Exception
	{
		public BadHeaderException()
		{
		}

		public BadHeaderException(string string_0) : base(string_0)
		{
		}
	}
}
