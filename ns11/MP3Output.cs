using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using GHNamespace1;
using ns1;
using SharpAudio.ASC;

namespace ns11
{
	public class Mp3Output : IDisposable, IPlayableAudio
	{
		private AudioPlayer _class1590;

		private readonly Class16 _class160;

		private GenericAudioStream _stream10;

		private readonly bool _bool0;

		private byte[] _byte0;

		private AudioStatus _enum10;

		private float _volume = 1f;

		private int _int0;

		public Mp3Output(GenericAudioStream stream11) : this(stream11, false)
		{
		}

		public Mp3Output(GenericAudioStream stream11, bool bool1)
		{
			if (stream11.Length <= 0L)
			{
				throw new Exception("WinMM2Player: Invalid Stream.");
			}
			_class160 = stream11.vmethod_1();
			if (_class160.WaveFormat0.waveFormatTag_0 != WaveFormatTag.Pcm && _class160.WaveFormat0.waveFormatTag_0 != WaveFormatTag.IeeeFloat)
			{
				throw new Exception("WinMM2Player: Only PCM is supported.");
			}
			_stream10 = stream11;
			_bool0 = bool1;
			SetStartingTimeBasedOnSomeValue(0);
			_enum10 = AudioStatus.ShouldStopAudio;
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromSeconds(vmethod_0() / (double)(_class160.method_3() * _class160.method_1()));
		}

		public void SetStartingTime(TimeSpan timeSpan0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(_class160.method_3() * _class160.method_1() * timeSpan0.TotalSeconds));
		}

		public int vmethod_0()
		{
			if (_enum10 != AudioStatus.ShouldStopAudio)
			{
				return _int0 + _class1590.method_0();
			}
			return (int)_stream10.Position;
		}

		public void SetStartingTimeBasedOnSomeValue(int int1)
		{
			var @enum = _enum10;
			if (@enum != AudioStatus.ShouldStopAudio)
			{
				StopPlaying();
			}
			Stream arg210 = _stream10;
			_int0 = int1;
			arg210.Position = int1;
			if (@enum == AudioStatus.ShouldStartAudio)
			{
				DifferentStartPlaying();
			}
		}

		public float vmethod_1()
		{
			if (_class1590 == null)
			{
				return _volume;
			}
			return _class1590.method_1();
		}

		public void SetVolume(float float1)
		{
			_volume = float1;
			if (_class1590 != null)
			{
				_class1590.SetVolume(_volume);
			}
		}

		public AudioStatus GetStatus()
		{
			return _enum10;
		}

		public WaveFormat GetWaveFormat()
		{
			return _class160.WaveFormat0;
		}

		public void DifferentStartPlaying()
		{
            WaitCallback waitCallback = null;
            //Error Case (Will never get called)
            if (_enum10 == AudioStatus.ShouldStartAudio)
			{
				return;
			}
            //If song is already playing
            if (_class1590 != null && _enum10 == AudioStatus.IsCurrentlyPlayingAudio && !_class1590.method_5())
			{
                _enum10 = AudioStatus.ShouldStartAudio;
				_class1590.SetVolume(0f);
				_class1590.method_3();
                if (waitCallback == null)
				{
					waitCallback = method_2;
				}
				ThreadPool.QueueUserWorkItem(waitCallback);
				return;
			}
            StopPlaying();
			_enum10 = AudioStatus.ShouldStartAudio;
            _class1590 = new AudioPlayer(-1, _class160.WaveFormat0, 200, _volume, _bool0, method_0);
        }

		public void StartPlaying()
		{
			if (_class1590 != null)
			{
				if (_enum10 == AudioStatus.ShouldStartAudio)
				{
					_enum10 = AudioStatus.IsCurrentlyPlayingAudio;
                    _class1590.method_4();
				}
			}
		}

		public void StopPlaying()
		{
			if (_class1590 != null && _enum10 != AudioStatus.ShouldStopAudio)
			{
				_enum10 = AudioStatus.ShouldStopAudio;
				try
				{
					_class1590.Dispose();
				}
				finally
				{
					_class1590 = null;
				}
			}
		}

		private void method_0(AudioPlayer class1591, IntPtr intptr0, int int1, ref bool bool1)
		{
			WaitCallback waitCallback = null;
			if (_byte0 == null || _byte0.Length < int1)
			{
				_byte0 = new byte[int1];
			}
			if (_stream10 != null && class1591 == _class1590)
			{
                lock (_stream10)
				{
					var num = _stream10.vmethod_3(intptr0, int1);
					if (num < int1)
					{
                        bool1 = true;
						if (waitCallback == null)
						{
							waitCallback = method_3;
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
					return;
				}
			}
			Marshal.Copy(_byte0, 0, intptr0, int1);
		}

		public void method_1(bool bool1)
		{
			StopPlaying();
			if (bool1 && _stream10 != null)
			{
				try
				{
					_stream10.Dispose();
				}
				finally
				{
					_stream10 = null;
				}
			}
		}

		public void Dispose()
		{
			method_1(true);
			GC.SuppressFinalize(this);
		}

		~Mp3Output()
		{
			method_1(false);
		}

		[CompilerGenerated]
		private void method_2(object object0)
		{
			var num = vmethod_1();
            while (num < _volume)
			{
                if (_enum10 != AudioStatus.ShouldStartAudio)
				{
					break;
				}
				_class1590.SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
            if (_enum10 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			_class1590.SetVolume(_volume);
		}

		[CompilerGenerated]
		private void method_3(object object0)
		{
			if (_class1590 != null)
			{
				while (!_class1590.method_5())
				{
				}
			}
			StopPlaying();
			SetStartingTimeBasedOnSomeValue(0);
		}
	}
}
