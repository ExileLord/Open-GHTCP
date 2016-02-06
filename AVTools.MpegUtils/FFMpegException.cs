using System;

namespace AVTools.MpegUtils
{
	[Serializable]
	public class FFMpegException : Exception
	{
		public FFMpegException(string string_0) : base(string_0)
		{
		}
	}
}
