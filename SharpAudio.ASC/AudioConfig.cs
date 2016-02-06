using System;
using System.Runtime.Serialization;

namespace SharpAudio.ASC
{
	[Serializable]
	public class AudioConfig : ISerializable
	{
		public WaveFormat m_Format;

		public AudioConfig(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			int @int = serializationInfo_0.GetInt32("Format.Rate");
			int int2 = serializationInfo_0.GetInt32("Format.Bits");
			int int3 = serializationInfo_0.GetInt32("Format.Channels");
			this.m_Format = new WaveFormat(@int, int2, int3);
		}

		public AudioConfig(WaveFormat waveFormat_0)
		{
			this.m_Format = new WaveFormat(waveFormat_0.int_0, (int)waveFormat_0.short_2, (int)waveFormat_0.short_0);
		}

		public AudioConfig() : this(new WaveFormat(44100, 16, 2))
		{
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Format.Rate", this.m_Format.int_0);
			info.AddValue("Format.Bits", this.m_Format.short_2);
			info.AddValue("Format.Channels", this.m_Format.short_0);
		}
	}
}
