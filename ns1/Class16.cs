using SharpAudio.ASC;
using System;

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
			return this.waveFormat_0.short_0;
		}

		public short method_1()
		{
			return this.waveFormat_0.short_1;
		}

		public short method_2()
		{
			return this.waveFormat_0.short_2;
		}

		public int method_3()
		{
			return this.waveFormat_0.int_0;
		}

		public Class16(WaveFormat waveFormat_1, uint uint_4, uint uint_5, int int_1)
		{
			this.waveFormat_0 = waveFormat_1;
			this.short_0 = (short)(this.method_1() / this.method_0());
			this.int_0 = int_1;
			this.timeSpan_0 = TimeSpan.FromSeconds((uint_5 - uint_4) / ((double)int_1 / 8.0));
			this.uint_0 = Convert.ToUInt32((double)this.method_3() * this.timeSpan_0.TotalSeconds);
			this.uint_1 = uint_4;
			this.uint_3 = this.uint_0 * (uint)this.method_1();
			this.uint_2 = uint_5 - this.uint_1;
		}

		public Class16(WaveFormat waveFormat_1, uint uint_4, uint uint_5)
		{
			this.waveFormat_0 = waveFormat_1;
			this.short_0 = (short)(this.method_1() / this.method_0());
			this.int_0 = (int)this.method_0() * this.method_3() * (int)this.method_2();
			this.uint_0 = Convert.ToUInt32((long)((ulong)uint_5 / (ulong)((long)this.method_1())));
			this.timeSpan_0 = TimeSpan.FromSeconds(this.uint_0 / (double)this.method_3());
			this.uint_1 = uint_4;
			this.uint_3 = uint_5 - this.uint_1;
			this.uint_2 = 0u;
		}
	}
}
