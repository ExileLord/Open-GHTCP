using ns0;
using ns1;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

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
			this.class16_0 = stream1_1.vmethod_1();
			if (this.class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM && this.class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.IEEEFloat)
			{
				throw new Exception("WinMM2Player: Only PCM is supported.");
			}
			this.stream1_0 = stream1_1;
			this.bool_0 = bool_1;
			this.SetStartingTimeBasedOnSomeValue(0);
			this.enum1_0 = AudioStatus.ShouldStopAudio;
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromSeconds((double)this.vmethod_0() / (double)(this.class16_0.method_3() * (int)this.class16_0.method_1()));
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			this.SetStartingTimeBasedOnSomeValue(Convert.ToInt32((double)(this.class16_0.method_3() * (int)this.class16_0.method_1()) * timeSpan_0.TotalSeconds));
		}

		public int vmethod_0()
		{
			if (this.enum1_0 != AudioStatus.ShouldStopAudio)
			{
				return this.int_0 + this.class159_0.method_0();
			}
			return (int)this.stream1_0.Position;
		}

		public void SetStartingTimeBasedOnSomeValue(int int_1)
		{
			AudioStatus @enum = this.enum1_0;
			if (@enum != AudioStatus.ShouldStopAudio)
			{
				this.StopPlaying();
			}
			Stream arg_21_0 = this.stream1_0;
			this.int_0 = int_1;
			arg_21_0.Position = (long)int_1;
			if (@enum == AudioStatus.ShouldStartAudio)
			{
				this.DifferentStartPlaying();
			}
		}

		public float vmethod_1()
		{
			if (this.class159_0 == null)
			{
				return this.Volume;
			}
			return this.class159_0.method_1();
		}

		public void SetVolume(float float_1)
		{
			this.Volume = float_1;
			if (this.class159_0 != null)
			{
				this.class159_0.SetVolume(this.Volume);
			}
		}

		public AudioStatus GetStatus()
		{
			return this.enum1_0;
		}

		public WaveFormat GetWaveFormat()
		{
			return this.class16_0.waveFormat_0;
		}

		public void DifferentStartPlaying()
		{
            WaitCallback waitCallback = null;
            //Error Case (Will never get called)
            if (this.enum1_0 == AudioStatus.ShouldStartAudio)
			{
				return;
			}
            //If song is already playing
            if (this.class159_0 != null && this.enum1_0 == AudioStatus.IsCurrentlyPlayingAudio && !this.class159_0.method_5())
			{
                this.enum1_0 = AudioStatus.ShouldStartAudio;
				this.class159_0.SetVolume(0f);
				this.class159_0.method_3();
                if (waitCallback == null)
				{
					waitCallback = new WaitCallback(this.method_2);
				}
				ThreadPool.QueueUserWorkItem(waitCallback);
				return;
			}
            this.StopPlaying();
			this.enum1_0 = AudioStatus.ShouldStartAudio;
            this.class159_0 = new AudioPlayer(-1, this.class16_0.waveFormat_0, 200, this.Volume, this.bool_0, new Delegate3(this.method_0));
        }

		public void StartPlaying()
		{
			if (this.class159_0 != null)
			{
				if (this.enum1_0 == AudioStatus.ShouldStartAudio)
				{
					this.enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
                    this.class159_0.method_4();
					return;
				}
			}
		}

		public void StopPlaying()
		{
			if (this.class159_0 != null && this.enum1_0 != AudioStatus.ShouldStopAudio)
			{
				this.enum1_0 = AudioStatus.ShouldStopAudio;
				try
				{
					this.class159_0.Dispose();
				}
				finally
				{
					this.class159_0 = null;
				}
				return;
			}
		}

		private void method_0(AudioPlayer class159_1, IntPtr intptr_0, int int_1, ref bool bool_1)
		{
			WaitCallback waitCallback = null;
			if (this.byte_0 == null || this.byte_0.Length < int_1)
			{
				this.byte_0 = new byte[int_1];
			}
			if (this.stream1_0 != null && class159_1 == this.class159_0)
			{
                lock (this.stream1_0)
				{
					int num = this.stream1_0.vmethod_3(intptr_0, int_1);
					if (num < int_1)
					{
                        bool_1 = true;
						if (waitCallback == null)
						{
							waitCallback = new WaitCallback(this.method_3);
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
					return;
				}
			}
			Marshal.Copy(this.byte_0, 0, intptr_0, int_1);
		}

		public void method_1(bool bool_1)
		{
			this.StopPlaying();
			if (bool_1 && this.stream1_0 != null)
			{
				try
				{
					this.stream1_0.Dispose();
				}
				finally
				{
					this.stream1_0 = null;
				}
			}
		}

		public void Dispose()
		{
			this.method_1(true);
			GC.SuppressFinalize(this);
		}

		~MP3Output()
		{
			this.method_1(false);
		}

		[CompilerGenerated]
		private void method_2(object object_0)
		{
			float num = this.vmethod_1();
            while (num < this.Volume)
			{
                if (this.enum1_0 != AudioStatus.ShouldStartAudio)
				{
					break;
				}
				this.class159_0.SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
            if (this.enum1_0 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			this.class159_0.SetVolume(this.Volume);
		}

		[CompilerGenerated]
		private void method_3(object object_0)
		{
			if (this.class159_0 != null)
			{
				while (!this.class159_0.method_5())
				{
				}
			}
			this.StopPlaying();
			this.SetStartingTimeBasedOnSomeValue(0);
		}
	}
}
