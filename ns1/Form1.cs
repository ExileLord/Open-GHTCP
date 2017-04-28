using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace ns1
{
	[StructLayout(LayoutKind.Sequential)]
	public class Form1 : WaveFormat
	{
		public short short_4;

		public Enum2 enum2_0;

		public Guid guid_0;

		public override string ToString()
		{
			return string.Format("{0} wBitsPerSample:{1} dwChannelMask:{2} SubFormat:{3} extraSize:{4}", base.ToString(), short_4, enum2_0, guid_0, short_3);
		}
	}
}
