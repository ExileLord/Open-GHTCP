using ns0;
using ns1;
using System;
using System.Runtime.InteropServices;

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

		public WaveFormat(int int_2, int int_3, int int_4)
		{
			if (int_4 < 1)
			{
				throw new ArgumentOutOfRangeException("Channels must be 1 or greater.", "channels");
			}
			this.waveFormatTag_0 = WaveFormatTag.PCM;
			this.short_0 = (short)int_4;
			this.int_0 = int_2;
			this.short_2 = (short)int_3;
			this.short_3 = 0;
			this.short_1 = (short)(int_4 * (int_3 / 8));
			this.int_1 = this.int_0 * (int)this.short_1;
		}

		public WaveFormat(int int_2, int int_3)
		{
			this.waveFormatTag_0 = WaveFormatTag.IEEEFloat;
			this.short_0 = (short)int_3;
			this.short_2 = 32;
			this.int_0 = int_2;
			this.short_1 = (short)(4 * int_3);
			this.int_1 = int_2 * (int)this.short_1;
			this.short_3 = 0;
		}

		public override string ToString()
		{
			WaveFormatTag waveFormatTag = this.waveFormatTag_0;
			if (waveFormatTag != WaveFormatTag.PCM)
			{
				if (waveFormatTag != WaveFormatTag.Extensible)
				{
					return this.waveFormatTag_0.ToString();
				}
			}
			return string.Format("{0} bit PCM: {1}kHz {2} channels", this.short_2, this.int_0 / 1000, this.short_0);
		}

		public override bool Equals(object obj)
		{
			WaveFormat waveFormat = obj as WaveFormat;
			return waveFormat != null && (this.waveFormatTag_0 == waveFormat.waveFormatTag_0 && this.short_0 == waveFormat.short_0 && this.int_0 == waveFormat.int_0 && this.int_1 == waveFormat.int_1 && this.short_1 == waveFormat.short_1) && this.short_2 == waveFormat.short_2;
		}

		public override int GetHashCode()
		{
			return (int)(this.waveFormatTag_0 ^ (WaveFormatTag)this.short_0) ^ this.int_0 ^ this.int_1 ^ (int)this.short_1 ^ (int)this.short_2;
		}

		public static WaveFormat smethod_0(IntPtr intptr_0)
		{
			WaveFormat waveFormat = (WaveFormat)Marshal.PtrToStructure(intptr_0, typeof(WaveFormat));
			WaveFormatTag waveFormatTag = waveFormat.waveFormatTag_0;
			switch (waveFormatTag)
			{
			case WaveFormatTag.PCM:
				waveFormat.short_3 = 0;
				break;
			case WaveFormatTag.Adpcm:
				waveFormat = (Form2)Marshal.PtrToStructure(intptr_0, typeof(Form2));
				break;
			default:
				if (waveFormatTag != WaveFormatTag.Extensible)
				{
					if (waveFormat.short_3 > 0)
					{
						waveFormat = (Form0)Marshal.PtrToStructure(intptr_0, typeof(Form0));
					}
				}
				else
				{
					waveFormat = (Form1)Marshal.PtrToStructure(intptr_0, typeof(Form1));
				}
				break;
			}
			return waveFormat;
		}

		public static IntPtr smethod_1(WaveFormat waveFormat_0)
		{
			int cb = Marshal.SizeOf(waveFormat_0);
			IntPtr intPtr = Marshal.AllocHGlobal(cb);
			Marshal.StructureToPtr(waveFormat_0, intPtr, false);
			return intPtr;
		}

		public int method_0(int int_2)
		{
			int num = (int)((double)this.int_1 / 1000.0 * (double)int_2);
			if (num % (int)this.short_1 != 0)
			{
				return num + (int)this.short_1 - num % (int)this.short_1;
			}
			return num;
		}

		public int method_1(TimeSpan timeSpan_0)
		{
			return (int)((double)this.int_0 * timeSpan_0.TotalSeconds);
		}
	}
}
