using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ASC.Mp3.Lame
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 327)]
	public struct LHV1
	{
		public const uint MPEG1 = 1u;

		public const uint MPEG2 = 0u;

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

		public LHV1(WaveFormat waveFormat_0, uint uint_0)
		{
			this = new LHV1(waveFormat_0, uint_0, 0u);
		}

		public LHV1(WaveFormat waveFormat_0, uint uint_0, uint uint_1)
		{
			if (waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM)
			{
				throw new ArgumentOutOfRangeException("format", "Only PCM format supported");
			}
			if (waveFormat_0.short_2 != 16)
			{
				throw new ArgumentOutOfRangeException("format", "Only 16 bits samples supported");
			}
			this.dwStructVersion = 1u;
			this.dwStructSize = (uint)Marshal.SizeOf(typeof(BE_CONFIG));
			uint num = (uint)((uint_1 == 0u) ? waveFormat_0.int_0 : ((int)uint_1));
			if (num <= 24000u)
			{
				if (num == 16000u || num == 22050u || num == 24000u)
				{
					this.dwMpegVersion = 0u;
					goto IL_B6;
				}
			}
			else if (num == 32000u || num == 44100u || num == 48000u)
			{
				this.dwMpegVersion = 1u;
				goto IL_B6;
			}
			throw new ArgumentOutOfRangeException("format", "Unsupported sample rate");
			IL_B6:
			this.dwSampleRate = (uint)waveFormat_0.int_0;
			this.dwReSampleRate = uint_1;
			switch (waveFormat_0.short_0)
			{
			case 1:
				this.nMode = MpegMode.Mono;
				break;
			case 2:
				this.nMode = MpegMode.Stereo;
				break;
			default:
				throw new ArgumentOutOfRangeException("format", "Invalid number of channels");
			}
			if (uint_0 <= 80u)
			{
				if (uint_0 <= 32u)
				{
					if (uint_0 <= 16u)
					{
						if (uint_0 != 8u && uint_0 != 16u)
						{
							goto IL_1E5;
						}
					}
					else if (uint_0 != 24u)
					{
						if (uint_0 != 32u)
						{
							goto IL_1E5;
						}
						goto IL_20E;
					}
				}
				else if (uint_0 <= 48u)
				{
					if (uint_0 != 40u && uint_0 != 48u)
					{
						goto IL_1E5;
					}
					goto IL_20E;
				}
				else
				{
					if (uint_0 != 56u && uint_0 != 64u && uint_0 != 80u)
					{
						goto IL_1E5;
					}
					goto IL_20E;
				}
			}
			else if (uint_0 <= 144u)
			{
				if (uint_0 <= 112u)
				{
					if (uint_0 != 96u && uint_0 != 112u)
					{
						goto IL_1E5;
					}
					goto IL_20E;
				}
				else
				{
					if (uint_0 == 128u)
					{
						goto IL_20E;
					}
					if (uint_0 != 144u)
					{
						goto IL_1E5;
					}
				}
			}
			else
			{
				if (uint_0 <= 192u)
				{
					if (uint_0 == 160u)
					{
						goto IL_20E;
					}
					if (uint_0 != 192u)
					{
						goto IL_1E5;
					}
				}
				else if (uint_0 != 224u && uint_0 != 256u)
				{
					if (uint_0 != 320u)
					{
						goto IL_1E5;
					}
				}
				if (this.dwMpegVersion != 1u)
				{
					throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
				}
				goto IL_20E;
			}
			if (this.dwMpegVersion != 0u)
			{
				throw new ArgumentOutOfRangeException("MpsBitRate", "Bit rate not compatible with input format");
			}
			goto IL_20E;
			IL_1E5:
			throw new ArgumentOutOfRangeException("MpsBitRate", "Unsupported bit rate");
			IL_20E:
			this.dwBitrate = uint_0;
			this.nPreset = LameQualityPreset.LqpNormalQuality;
			this.dwPsyModel = 0u;
			this.dwEmphasis = 0u;
			this.bOriginal = 1;
			this.bWriteVBRHeader = 0;
			this.bNoRes = 0;
			this.bCopyright = 0;
			this.bCRC = 0;
			this.bEnableVBR = 0;
			this.bPrivate = 0;
			this.bStrictIso = 0;
			this.dwMaxBitrate = 0u;
			this.dwVbrAbr_bps = 0u;
			this.nQuality = 0;
			this.nVbrMethod = VbrMethod.None;
			this.nVBRQuality = 0;
		}
	}
}
