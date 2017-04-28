using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ns0;
using ns1;
using SharpAudio.ASC;

namespace ns11
{
	public class MP3Output : IDisposable, PlayableAudio
	{
		private AudioPlayer class159_0;

		private readonly Class16 class16_0;

		private GenericAudioStream stream1_0;

		private readonly bool bool_0;

		private byte[] byte_0;

		private AudioStatus enum1_0;

		private float Volume = 1f;

		private int int_0;

		public MP3Output(GenericAudioStream stream1_1) : this(stream1_1, false)
		{
		}

		public MP3Output(GenericAudioStream stream1_1, bool bool_1)
		{
			if (stream1_1.Length <= 0L)
			{
				throw new Exception("WinMM2Player: Invalid Stream.");
			}
			class16_0 = stream1_1.vmethod_1();
			if (class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM && class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.IEEEFloat)
			{
				throw new Exception("WinMM2Player: Only PCM is supported.");
			}
			stream1_0 = stream1_1;
			bool_0 = bool_1;
			SetStartingTimeBasedOnSomeValue(0);
			enum1_0 = AudioStatus.ShouldStopAudio;
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromSeconds(vmethod_0() / (double)(class16_0.method_3() * class16_0.method_1()));
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(class16_0.method_3() * class16_0.method_1() * timeSpan_0.TotalSeconds));
		}

		public int vmethod_0()
		{
			if (enum1_0 != AudioStatus.ShouldStopAudio)
			{
				return int_0 + class159_0.method_0();
			}
			return (int)stream1_0.Position;
		}

		public void SetStartingTimeBasedOnSomeValue(int int_1)
		{
			var @enum = enum1_0;
			if (@enum != AudioStatus.ShouldStopAudio)
			{
				StopPlaying();
			}
			Stream arg_21_0 = stream1_0;
			int_0 = int_1;
			arg_21_0.Position = int_1;
			if (@enum == AudioStatus.ShouldStartAudio)
			{
				DifferentStartPlaying();
			}
		}

		public float vmethod_1()
		{
			if (class159_0 == null)
			{
				return Volume;
			}
			return class159_0.method_1();
		}

		public void SetVolume(float float_1)
		{
			Volume = float_1;
			if (class159_0 != null)
			{
				class159_0.SetVolume(Volume);
			}
		}

		public AudioStatus GetStatus()
		{
			return enum1_0;
		}

		public WaveFormat GetWaveFormat()
		{
			return class16_0.waveFormat_0;
		}

		public void DifferentStartPlaying()
		{
            WaitCallback waitCallback = null;
            //Error Case (Will never get called)
            if (enum1_0 == AudioStatus.ShouldStartAudio)
			{
				return;
			}
            //If song is already playing
            if (class159_0 != null && enum1_0 == AudioStatus.IsCurrentlyPlayingAudio && !class159_0.method_5())
			{
                enum1_0 = AudioStatus.ShouldStartAudio;
				class159_0.SetVolume(0f);
				class159_0.method_3();
                if (waitCallback == null)
				{
					waitCallback = method_2;
				}
				ThreadPool.QueueUserWorkItem(waitCallback);
				return;
			}
            StopPlaying();
			enum1_0 = AudioStatus.ShouldStartAudio;
            class159_0 = new AudioPlayer(-1, class16_0.waveFormat_0, 200, Volume, bool_0, method_0);
        }

		public void StartPlaying()
		{
			if (class159_0 != null)
			{
				if (enum1_0 == AudioStatus.ShouldStartAudio)
				{
					enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
                    class159_0.method_4();
				}
			}
		}

		public void StopPlaying()
		{
			if (class159_0 != null && enum1_0 != AudioStatus.ShouldStopAudio)
			{
				enum1_0 = AudioStatus.ShouldStopAudio;
				try
				{
					class159_0.Dispose();
				}
				finally
				{
					class159_0 = null;
				}
			}
		}

		private void method_0(AudioPlayer class159_1, IntPtr intptr_0, int int_1, ref bool bool_1)
		{
			WaitCallback waitCallback = null;
			if (byte_0 == null || byte_0.Length < int_1)
			{
				byte_0 = new byte[int_1];
			}
			if (stream1_0 != null && class159_1 == class159_0)
			{
                lock (stream1_0)
				{
					var num = stream1_0.vmethod_3(intptr_0, int_1);
					if (num < int_1)
					{
                        bool_1 = true;
						if (waitCallback == null)
						{
							waitCallback = method_3;
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
					return;
				}
			}
			Marshal.Copy(byte_0, 0, intptr_0, int_1);
		}

		public void method_1(bool bool_1)
		{
			StopPlaying();
			if (bool_1 && stream1_0 != null)
			{
				try
				{
					stream1_0.Dispose();
				}
				finally
				{
					stream1_0 = null;
				}
			}
		}

		public void Dispose()
		{
			method_1(true);
			GC.SuppressFinalize(this);
		}

		~MP3Output()
		{
			method_1(false);
		}

		[CompilerGenerated]
		private void method_2(object object_0)
		{
			var num = vmethod_1();
            while (num < Volume)
			{
                if (enum1_0 != AudioStatus.ShouldStartAudio)
				{
					break;
				}
				class159_0.SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
            if (enum1_0 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			class159_0.SetVolume(Volume);
		}

		[CompilerGenerated]
		private void method_3(object object_0)
		{
			if (class159_0 != null)
			{
				while (!class159_0.method_5())
				{
				}
			}
			StopPlaying();
			SetStartingTimeBasedOnSomeValue(0);
		}
	}
}
