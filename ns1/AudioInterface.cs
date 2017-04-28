using System;
using SharpAudio.ASC;

namespace ns1
{
	public interface PlayableAudio
	{
		TimeSpan AudioLength();

		void SetStartingTime(TimeSpan timeSpan_0);

		void SetStartingTimeBasedOnSomeValue(int int_0);

		void DifferentStartPlaying();

		void StartPlaying();

		void StopPlaying();

		AudioStatus GetStatus();

		WaveFormat GetWaveFormat();

		void SetVolume(float float_0);

		void Dispose();
	}
}
