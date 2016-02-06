using System;
using System.IO;

namespace ns8
{
	public class Class168 : IDisposable
	{
		public string string_0;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public Enum22 enum22_0;

		public int int_0;

		public ushort ushort_0;

		public short short_0;

		public float float_0 = -1f;

		public float float_1 = 1f;

		public ushort ushort_1;

		public uint uint_3;

		public float float_2;

		public float float_3;

		public int int_1;

		public short short_1;

		public short short_2;

		public Stream stream_0;

		public Stream stream_1;

		public Class168()
		{
			this.string_0 = "";
			this.uint_0 = 0u;
			this.uint_1 = 0u;
			this.uint_2 = 0u;
			this.enum22_0 = Enum22.flag_33;
			this.int_0 = 0;
			this.ushort_0 = 255;
			this.short_0 = -1;
			this.ushort_1 = 128;
			this.uint_3 = 2u;
			this.float_2 = 1f;
			this.float_3 = 10000f;
			this.int_1 = 0;
			this.short_1 = 0;
			this.short_2 = 0;
			this.stream_0 = Stream.Null;
			this.stream_1 = Stream.Null;
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"FsbSubFile:\nName = ",
				this.string_0,
				"\nNumSamples = ",
				this.uint_0,
				"\nLoopStartPoint = ",
				this.uint_1,
				"\nLoopEndPoint = ",
				this.uint_2,
				"\nFlags = ",
				this.enum22_0,
				"\nFrequency = ",
				this.int_0,
				"\nVolume = ",
				this.ushort_0,
				"\nPan = ",
				this.short_0,
				"\nPriority = ",
				this.ushort_1,
				"\nNumChannels = ",
				this.uint_3,
				"\nMinDistance = ",
				this.float_2,
				"\nMaxDistance = ",
				this.float_3,
				"\nFrequencyVariation = ",
				this.int_1,
				"\nVolumeVariation = ",
				this.short_1,
				"\nPanVariation = ",
				this.short_2,
				"\nExtraData.Length = ",
				this.stream_0.Length,
				"\nAudioData.Length = ",
				this.stream_1.Length,
				"\n"
			});
		}

		~Class168()
		{
			this.method_0(false);
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		public void method_0(bool bool_0)
		{
			if (bool_0)
			{
				this.stream_0.Dispose();
				this.stream_1.Dispose();
			}
		}
	}
}
