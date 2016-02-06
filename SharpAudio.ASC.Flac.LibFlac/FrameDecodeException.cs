using System;

namespace SharpAudio.ASC.Flac.LibFlac
{
	[Serializable]
	public class FrameDecodeException : Exception
	{
		public FrameDecodeException()
		{
		}

		public FrameDecodeException(string string_0) : base(string_0)
		{
		}
	}
}
