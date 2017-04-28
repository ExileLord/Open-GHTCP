using System;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	public struct MP3
	{
		public uint DwSampleRate;

		public byte ByMode;

		public ushort WBitrate;

		public int BPrivate;

		public int BCrc;

		public int BCopyright;

		public int BOriginal;
	}
}
