using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public class Format
	{
		[FieldOffset(0)]
		public MP3 mp3;

		[FieldOffset(0)]
		public LHV1 lhv1;

		[FieldOffset(0)]
		public ACC acc;

		public Format(WaveFormat waveFormat_0, uint uint_0)
		{
			this.lhv1 = new LHV1(waveFormat_0, uint_0);
		}

		public Format(WaveFormat waveFormat_0, uint uint_0, uint uint_1)
		{
			this.lhv1 = new LHV1(waveFormat_0, uint_0, uint_1);
		}
	}
}
