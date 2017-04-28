using System;
using SharpAudio.ASC;

namespace ns1
{
	public interface IPlayableAudio
	{
		TimeSpan AudioLength();

		void SetStartingTime(TimeSpan timeSpan0);

		void SetStartingTimeBasedOnSomeValue(int int0);

		void DifferentStartPlaying();

		void StartPlaying();

		void StopPlaying();

		AudioStatus GetStatus();

		WaveFormat GetWaveFormat();

		void SetVolume(float float0);

		void Dispose();
	}
}
