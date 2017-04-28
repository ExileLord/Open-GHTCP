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
		public Lhv1 lhv1;

		[FieldOffset(0)]
		public Acc acc;

		public Format(WaveFormat waveFormat0, uint uint0)
		{
			lhv1 = new Lhv1(waveFormat0, uint0);
		}

		public Format(WaveFormat waveFormat0, uint uint0, uint uint1)
		{
			lhv1 = new Lhv1(waveFormat0, uint0, uint1);
		}
	}
}
