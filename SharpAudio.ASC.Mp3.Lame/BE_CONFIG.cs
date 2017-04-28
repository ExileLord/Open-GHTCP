using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class BE_CONFIG
	{
		public const uint BE_CONFIG_MP3 = 0u;

		public const uint BE_CONFIG_LAME = 256u;

		public uint dwConfig;

		public Format format;

		public BE_CONFIG(WaveFormat waveFormat_0, uint uint_0, uint uint_1)
		{
			dwConfig = 256u;
			format = new Format(waveFormat_0, uint_0, uint_1);
		}

		public BE_CONFIG(WaveFormat waveFormat_0, uint uint_0)
		{
			dwConfig = 256u;
			format = new Format(waveFormat_0, uint_0);
		}
	}
}
