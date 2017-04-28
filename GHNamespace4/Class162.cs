using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace GHNamespace4
{
	public class Class162
	{
		public enum Enum16
		{
			Const0 = 956,
			Const1,
			Const2 = 955
		}

		public enum Enum17
		{
			Const0,
			Const1 = 65536,
			Const2 = 131072,
			Const3 = 196608,
			Const4 = 196608
		}

		public delegate void Delegate4(IntPtr hdrvr, Enum16 uMsg, int dwUser, ref Struct66 wavhdr, int dwParam2);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInClose(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInUnprepareHeader(IntPtr intptr0, ref Struct66 struct660, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveInReset(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutPrepareHeader(IntPtr intptr0, ref Struct66 struct660, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutUnprepareHeader(IntPtr intptr0, ref Struct66 struct660, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutWrite(IntPtr intptr0, ref Struct66 struct660, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutOpen(out IntPtr hWaveOut, int uDeviceId, WaveFormat lpFormat, Delegate4 dwCallback, int dwInstance, Enum17 dwFlags);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutClose(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutReset(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutPause(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutRestart(IntPtr intptr0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutGetPosition(IntPtr intptr0, ref Struct67 struct670, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutSetVolume(IntPtr intptr0, int int0);

		[DllImport("winmm.dll")]
		public static extern Enum18 waveOutGetVolume(IntPtr intptr0, ref int int0);
	}
}
