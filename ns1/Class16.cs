using System;
using SharpAudio.ASC;

namespace ns1
{
	public class Class16
	{
		public readonly short short_0;

		public readonly int int_0;

		public readonly uint uint_0;

		public readonly TimeSpan timeSpan_0;

		public readonly uint uint_1;

		public readonly uint uint_2;

		public readonly uint uint_3;

		public readonly WaveFormat waveFormat_0;

		public short method_0()
		{
			return waveFormat_0.short_0;
		}

		public short method_1()
		{
			return waveFormat_0.short_1;
		}

		public short method_2()
		{
			return waveFormat_0.short_2;
		}

		public int method_3()
		{
			return waveFormat_0.int_0;
		}

		public Class16(WaveFormat waveFormat_1, uint uint_4, uint uint_5, int int_1)
		{
			waveFormat_0 = waveFormat_1;
			short_0 = (short)(method_1() / method_0());
			int_0 = int_1;
			timeSpan_0 = TimeSpan.FromSeconds((uint_5 - uint_4) / (int_1 / 8.0));
			uint_0 = Convert.ToUInt32(method_3() * timeSpan_0.TotalSeconds);
			uint_1 = uint_4;
			uint_3 = uint_0 * (uint)method_1();
			uint_2 = uint_5 - uint_1;
		}

		public Class16(WaveFormat waveFormat_1, uint uint_4, uint uint_5)
		{
			waveFormat_0 = waveFormat_1;
			short_0 = (short)(method_1() / method_0());
			int_0 = method_0() * method_3() * method_2();
			uint_0 = Convert.ToUInt32((long)(uint_5 / (ulong)method_1()));
			timeSpan_0 = TimeSpan.FromSeconds(uint_0 / (double)method_3());
			uint_1 = uint_4;
			uint_3 = uint_5 - uint_1;
			uint_2 = 0u;
		}
	}
}
