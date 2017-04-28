using System;
using System.IO;

namespace ns8
{
	public class Class168 : IDisposable
	{
		public string FileName;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public FSBFlags2 enum22_0;

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
			FileName = "";
			uint_0 = 0u;
			uint_1 = 0u;
			uint_2 = 0u;
			enum22_0 = FSBFlags2.flag_33;
			int_0 = 0;
			ushort_0 = 255;
			short_0 = -1;
			ushort_1 = 128;
			uint_3 = 2u;
			float_2 = 1f;
			float_3 = 10000f;
			int_1 = 0;
			short_1 = 0;
			short_2 = 0;
			stream_0 = Stream.Null;
			stream_1 = Stream.Null;
		}

		public override string ToString()
		{
			return string.Concat("FsbSubFile:\nName = ", FileName, "\nNumSamples = ", uint_0, "\nLoopStartPoint = ", uint_1, "\nLoopEndPoint = ", uint_2, "\nFlags = ", enum22_0, "\nFrequency = ", int_0, "\nVolume = ", ushort_0, "\nPan = ", short_0, "\nPriority = ", ushort_1, "\nNumChannels = ", uint_3, "\nMinDistance = ", float_2, "\nMaxDistance = ", float_3, "\nFrequencyVariation = ", int_1, "\nVolumeVariation = ", short_1, "\nPanVariation = ", short_2, "\nExtraData.Length = ", stream_0.Length, "\nAudioData.Length = ", stream_1.Length, "\n");
		}

		~Class168()
		{
			method_0(false);
		}

		public void Dispose()
		{
			method_0(true);
			GC.SuppressFinalize(this);
		}

		public void method_0(bool bool_0)
		{
			if (bool_0)
			{
				stream_0.Dispose();
				stream_1.Dispose();
			}
		}
	}
}
