using AVTools.MpegUtils;
using System;

namespace SharpAudio.ASC.Ac3.Decoding
{
	[Serializable]
	public class AC3Exception : FFMpegException
	{
		public AC3Exception(string string_0) : base(string_0)
		{
		}
	}
}
