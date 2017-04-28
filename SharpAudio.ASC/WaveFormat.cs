using System;
using System.Runtime.InteropServices;
using GHNamespace1;
using GHNamespace2;

namespace SharpAudio.ASC
{
	[StructLayout(LayoutKind.Sequential)]
	public class WaveFormat
	{
		public WaveFormatTag waveFormatTag_0;

		public short short_0;

		public int int_0;

		public int int_1;

		public short short_1;

		public short short_2;

		public short short_3;

		public WaveFormat() : this(44100, 16, 2)
		{
		}

		public WaveFormat(int int2, int int3, int int4)
		{
			if (int4 < 1)
			{
				throw new ArgumentOutOfRangeException("Channels must be 1 or greater.", "channels");
			}
			waveFormatTag_0 = WaveFormatTag.Pcm;
			short_0 = (short)int4;
			int_0 = int2;
			short_2 = (short)int3;
			short_3 = 0;
			short_1 = (short)(int4 * (int3 / 8));
			int_1 = int_0 * short_1;
		}

		public WaveFormat(int int2, int int3)
		{
			waveFormatTag_0 = WaveFormatTag.IeeeFloat;
			short_0 = (short)int3;
			short_2 = 32;
			int_0 = int2;
			short_1 = (short)(4 * int3);
			int_1 = int2 * short_1;
			short_3 = 0;
		}

		public override string ToString()
		{
			var waveFormatTag = waveFormatTag_0;
			if (waveFormatTag != WaveFormatTag.Pcm)
			{
				if (waveFormatTag != WaveFormatTag.Extensible)
				{
					return waveFormatTag_0.ToString();
				}
			}
			return string.Format("{0} bit PCM: {1}kHz {2} channels", short_2, int_0 / 1000, short_0);
		}

		public override bool Equals(object obj)
		{
			var waveFormat = obj as WaveFormat;
			return waveFormat != null && (waveFormatTag_0 == waveFormat.waveFormatTag_0 && short_0 == waveFormat.short_0 && int_0 == waveFormat.int_0 && int_1 == waveFormat.int_1 && short_1 == waveFormat.short_1) && short_2 == waveFormat.short_2;
		}

		public override int GetHashCode()
		{
			return (int)(waveFormatTag_0 ^ (WaveFormatTag)short_0) ^ int_0 ^ int_1 ^ short_1 ^ short_2;
		}

		public static WaveFormat smethod_0(IntPtr intptr0)
		{
			var waveFormat = (WaveFormat)Marshal.PtrToStructure(intptr0, typeof(WaveFormat));
			var waveFormatTag = waveFormat.waveFormatTag_0;
			switch (waveFormatTag)
			{
			case WaveFormatTag.Pcm:
				waveFormat.short_3 = 0;
				break;
			case WaveFormatTag.Adpcm:
				waveFormat = (Form2)Marshal.PtrToStructure(intptr0, typeof(Form2));
				break;
			default:
				if (waveFormatTag != WaveFormatTag.Extensible)
				{
					if (waveFormat.short_3 > 0)
					{
						waveFormat = (Form0)Marshal.PtrToStructure(intptr0, typeof(Form0));
					}
				}
				else
				{
					waveFormat = (Form1)Marshal.PtrToStructure(intptr0, typeof(Form1));
				}
				break;
			}
			return waveFormat;
		}

		public static IntPtr smethod_1(WaveFormat waveFormat0)
		{
			var cb = Marshal.SizeOf(waveFormat0);
			var intPtr = Marshal.AllocHGlobal(cb);
			Marshal.StructureToPtr(waveFormat0, intPtr, false);
			return intPtr;
		}

		public int method_0(int int2)
		{
			var num = (int)(int_1 / 1000.0 * int2);
			if (num % short_1 != 0)
			{
				return num + short_1 - num % short_1;
			}
			return num;
		}

		public int method_1(TimeSpan timeSpan0)
		{
			return (int)(int_0 * timeSpan0.TotalSeconds);
		}
	}
}
