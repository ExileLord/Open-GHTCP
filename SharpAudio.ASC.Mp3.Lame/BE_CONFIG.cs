using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ASC.Mp3.Lame
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class BeConfig
    {
        public const uint BeConfigMp3 = 0u;

        public const uint BeConfigLame = 256u;

        public uint dwConfig;

        public Format format;

        public BeConfig(WaveFormat waveFormat0, uint uint0, uint uint1)
        {
            dwConfig = 256u;
            format = new Format(waveFormat0, uint0, uint1);
        }

        public BeConfig(WaveFormat waveFormat0, uint uint0)
        {
            dwConfig = 256u;
            format = new Format(waveFormat0, uint0);
        }
    }
}