using System;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	public struct MP3
	{
		public uint dwSampleRate;

		public byte byMode;

		public ushort wBitrate;

		public int bPrivate;

		public int bCRC;

		public int bCopyright;

		public int bOriginal;
	}
}
