using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace ns11
{
	public class Class162
	{
		public enum Enum16
		{
			const_0 = 956,
			const_1,
			const_2 = 955
		}

		public enum Enum17
		{
			const_0,
			const_1 = 65536,
			const_2 = 131072,
			const_3 = 196608,
			const_4 = 196608
		}

		public delegate void Delegate4(IntPtr hdrvr, Enum16 uMsg, int dwUser, ref Struct66 wavhdr, int dwParam2);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInClose(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInUnprepareHeader(IntPtr intptr_0, ref Struct66 struct66_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInReset(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutPrepareHeader(IntPtr intptr_0, ref Struct66 struct66_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutUnprepareHeader(IntPtr intptr_0, ref Struct66 struct66_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutWrite(IntPtr intptr_0, ref Struct66 struct66_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutOpen(out IntPtr hWaveOut, int uDeviceID, WaveFormat lpFormat, Delegate4 dwCallback, int dwInstance, Enum17 dwFlags);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutClose(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutReset(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutPause(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutRestart(IntPtr intptr_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutGetPosition(IntPtr intptr_0, ref Struct67 struct67_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutSetVolume(IntPtr intptr_0, int int_0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutGetVolume(IntPtr intptr_0, ref int int_0);
	}
}
