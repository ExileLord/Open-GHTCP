using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace GHNamespace2
{
	[StructLayout(LayoutKind.Sequential)]
	public class Form2 : WaveFormat
	{
		public short short_4;

		public short short_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
		public short[] short_6;

		private Form2() : this(8000, 1)
		{
		}

		public Form2(int int2, int int3) : base(int2, 0, int3)
		{
			waveFormatTag_0 = WaveFormatTag.Adpcm;
			short_3 = 32;
			var int4 = int_0;
			if (int4 <= 11025)
			{
				if (int4 == 8000 || int4 == 11025)
				{
					short_1 = 256;
					goto IL_6E;
				}
			}
			else
			{
				if (int4 == 22050)
				{
					short_1 = 512;
					goto IL_6E;
				}
				if (int4 != 44100)
				{
				}
			}
			short_1 = 1024;
			IL_6E:
			short_2 = 4;
			short_4 = (short)((short_1 - 7 * int3) * 8 / (short_2 * int3) + 2);
			int_1 = int_0 * short_1 / short_4;
			short_5 = 7;
			short_6 = new short[]
			{
				256,
				0,
				512,
				-256,
				0,
				0,
				192,
				64,
				240,
				0,
				460,
				-208,
				392,
				-232
			};
		}

		public override string ToString()
		{
			return string.Format("Microsoft ADPCM {0} Hz {1} channels {2} bits per sample {3} samples per block", int_0, short_0, short_2, short_4);
		}
	}
}
