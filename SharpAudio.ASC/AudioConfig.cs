using System;
using System.Runtime.Serialization;

namespace SharpAudio.ASC
{
	[Serializable]
	public class AudioConfig : ISerializable
	{
		public WaveFormat MFormat;

		public AudioConfig(SerializationInfo serializationInfo0, StreamingContext streamingContext0)
		{
			var @int = serializationInfo0.GetInt32("Format.Rate");
			var int2 = serializationInfo0.GetInt32("Format.Bits");
			var int3 = serializationInfo0.GetInt32("Format.Channels");
			MFormat = new WaveFormat(@int, int2, int3);
		}

		public AudioConfig(WaveFormat waveFormat0)
		{
			MFormat = new WaveFormat(waveFormat0.int_0, waveFormat0.short_2, waveFormat0.short_0);
		}

		public AudioConfig() : this(new WaveFormat(44100, 16, 2))
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Format.Rate", MFormat.int_0);
			info.AddValue("Format.Bits", MFormat.short_2);
			info.AddValue("Format.Channels", MFormat.short_0);
		}
	}
}
