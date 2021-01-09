using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ASC.Mp3.Lame
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Size = 327)]
    public struct Lhv1
    {
        public const uint Mpeg1 = 1u;

        public const uint Mpeg2 = 0u;

        public uint dwStructVersion;

        public uint dwStructSize;

        public uint dwSampleRate;

        public uint dwReSampleRate;

        public MpegMode nMode;

        public uint dwBitrate;

        public uint dwMaxBitrate;

        public LameQualityPreset nPreset;

        public uint dwMpegVersion;

        public uint dwPsyModel;

        public uint dwEmphasis;

        public int bPrivate;

        public int bCRC;

        public int bCopyright;

        public int bOriginal;

        public int bWriteVBRHeader;

        public int bEnableVBR;

        public int nVBRQuality;

        public uint dwVbrAbr_bps;

        public VbrMethod nVbrMethod;

        public int bNoRes;

        public int bStrictIso;

        public ushort nQuality;

        public Lhv1(WaveFormat waveFormat0, uint uint0)
        {
            this = new Lhv1(waveFormat0, uint0, 0u);
        }

        public Lhv1(WaveFormat waveFormat0, uint uint0, uint uint1)
        {
            if (waveFormat0.waveFormatTag_0 != WaveFormatTag.Pcm)
            {
                throw new ArgumentOutOfRangeException("format", "Only PCM format supported");
            }
            if (waveFormat0.short_2 != 16)
            {
                throw new ArgumentOutOfRangeException("format", "Only 16 bits samples supported");
            }
            dwStructVersion = 1u;
            dwStructSize = (uint) Marshal.SizeOf(typeof(BeConfig));
            uint num = (uint) ((uint1 == 0u) ? waveFormat0.int_0 : ((int) uint1));
            if (num <= 24000u)
            {
                if (num == 16000u || num == 22050u || num == 24000u)
                {
                    dwMpegVersion = 0u;
                    goto IL_B6;
                }
            }
            else if (num == 32000u || num == 44100u || num == 48000u)
            {
                dwMpegVersion = 1u;
                goto IL_B6;
            }
            throw new ArgumentOutOfRangeException("format", "Unsupported sample rate");
            IL_B6:
            dwSampleRate = (uint) waveFormat0.int_0;
            dwReSampleRate = uint1;
            switch (waveFormat0.short_0)
            {
                case 1:
                    nMode = MpegMode.Mono;
                    break;
                case 2:
                    nMode = MpegMode.Stereo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("format", "Invalid number of channels");
            }
            if (uint0 <= 80u)
            {
                if (uint0 <= 32u)
                {
                    if (uint0 <= 16u)
                    {
                        if (uint0 != 8u && uint0 != 16u)
                        {
                            goto IL_1E5;
                        }
                    }
                    else if (uint0 != 24u)
                    {
                        if (uint0 != 32u)
                        {
                            goto IL_1E5;
                        }
                        goto IL_20E;
                    }
                }
                else if (uint0 <= 48u)
                {
                    if (uint0 != 40u && uint0 != 48u)
                    {
                        goto IL_1E5;
                    }
                    goto IL_20E;
                }
                else
                {
                    if (uint0 != 56u && uint0 != 64u && uint0 != 80u)
                    {
                        goto IL_1E5;
                    }
                    goto IL_20E;
                }
            }
            else if (uint0 <= 144u)
            {
                if (uint0 <= 112u)
                {
                    if (uint0 != 96u && uint0 != 112u)
                    {
                        goto IL_1E5;
                    }
                    goto IL_20E;
                }
                if (uint0 == 128u)
                {
                    goto IL_20E;
                }
                if (uint0 != 144u)
                {
                    goto IL_1E5;
                }
            }
            else
            {
                if (uint0 <= 192u)
                {
                    if (uint0 == 160u)
                    {
                        goto IL_20E;
                    }
                    if (uint0 != 192u)
                    {
                        goto IL_1E5;
                    }
                }
                else if (uint0 != 224u && uint0 != 256u)
                {
                    if (uint0 != 320u)
                    {
                        goto IL_1E5;
                    }
                }
                if (dwMpegVersion != 1u)
                {
                    throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
                }
                goto IL_20E;
            }
            if (dwMpegVersion != 0u)
            {
                throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
            }
            goto IL_20E;
            IL_1E5:
            throw new ArgumentOutOfRangeException("MpsBitRate", "Unsupported bit rate");
            IL_20E:
            dwBitrate = uint0;
            nPreset = LameQualityPreset.LqpNormalQuality;
            dwPsyModel = 0u;
            dwEmphasis = 0u;
            bOriginal = 1;
            bWriteVBRHeader = 0;
            bNoRes = 0;
            bCopyright = 0;
            bCRC = 0;
            bEnableVBR = 0;
            bPrivate = 0;
            bStrictIso = 0;
            dwMaxBitrate = 0u;
            dwVbrAbr_bps = 0u;
            nQuality = 0;
            nVbrMethod = VbrMethod.None;
            nVBRQuality = 0;
        }
    }
}