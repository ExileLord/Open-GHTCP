using System;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	public struct ACC
	{
		public uint dwSampleRate;

		public byte byMode;

		public ushort wBitrate;

		public byte byEncodingMethod;
	}
}
