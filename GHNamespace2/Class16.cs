using System;
using SharpAudio.ASC;

namespace GHNamespace2
{
	public class Class16
	{
		public readonly short Short0;

		public readonly int Int0;

		public readonly uint Uint0;

		public readonly TimeSpan TimeSpan0;

		public readonly uint Uint1;

		public readonly uint Uint2;

		public readonly uint Uint3;

		public readonly WaveFormat WaveFormat0;

		public short method_0()
		{
			return WaveFormat0.short_0;
		}

		public short method_1()
		{
			return WaveFormat0.short_1;
		}

		public short method_2()
		{
			return WaveFormat0.short_2;
		}

		public int method_3()
		{
			return WaveFormat0.int_0;
		}

		public Class16(WaveFormat waveFormat1, uint uint4, uint uint5, int int1)
		{
			WaveFormat0 = waveFormat1;
			Short0 = (short)(method_1() / method_0());
			Int0 = int1;
			TimeSpan0 = TimeSpan.FromSeconds((uint5 - uint4) / (int1 / 8.0));
			Uint0 = Convert.ToUInt32(method_3() * TimeSpan0.TotalSeconds);
			Uint1 = uint4;
			Uint3 = Uint0 * (uint)method_1();
			Uint2 = uint5 - Uint1;
		}

		public Class16(WaveFormat waveFormat1, uint uint4, uint uint5)
		{
			WaveFormat0 = waveFormat1;
			Short0 = (short)(method_1() / method_0());
			Int0 = method_0() * method_3() * method_2();
			Uint0 = Convert.ToUInt32((long)(uint5 / (ulong)method_1()));
			TimeSpan0 = TimeSpan.FromSeconds(Uint0 / (double)method_3());
			Uint1 = uint4;
			Uint3 = uint5 - Uint1;
			Uint2 = 0u;
		}
	}
}
