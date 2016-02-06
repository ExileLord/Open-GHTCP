using SharpAudio.ASC;
using System;
using System.Runtime.InteropServices;

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
			return string.Format("{0} wBitsPerSample:{1} dwChannelMask:{2} SubFormat:{3} extraSize:{4}", new object[]
			{
				base.ToString(),
				this.short_4,
				this.enum2_0,
				this.guid_0,
				this.short_3
			});
		}
	}
}
