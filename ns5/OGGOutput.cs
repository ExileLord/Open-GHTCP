using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.DirectX.DirectSound;
using ns0;
using ns1;

namespace ns5
{
	public class OggOutput : IPlayableAudio
	{
		private AudioStatus _enum10;

		private readonly GenericAudioStream _stream10;

		private readonly int _int0;

		private readonly int _int1;

		private Device _device0;

		private readonly bool _bool0;

		private SecondaryBuffer _secondaryBuffer0;

		private int _int2;

		private bool _bool1;

		private readonly double _double0;

		private long _long0;

		private readonly BufferPositionNotify[] _bufferPositionNotify0 = new BufferPositionNotify[5];

		private readonly AutoResetEvent _autoResetEvent0;

		private readonly BufferPositionNotify[] _bufferPositionNotify1 = new BufferPositionNotify[1];

		private Notify _notify0;

		private Thread _thread0;

		private bool _bool2;

		private int _int3;

		private int _int4;

		private readonly byte[] _byte0;

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		public OggOutput(GenericAudioStream stream11) : this(stream11, null, 500)
		{
		}

		public OggOutput(GenericAudioStream stream11, Device device1, int int5)
		{
			_stream10 = new Stream4(stream11, 16);
			_int1 = _stream10.vmethod_0().method_0(int5);
			_int1 -= _int1 % 5;
			_int0 = _int1 / 5;
			_double0 = _stream10.vmethod_0().int_0 * (double)_stream10.vmethod_0().short_1 / 1000.0;
			_byte0 = new byte[_int0];
			_device0 = device1;
			if (_device0 == null)
			{
				_device0 = new Device();
				_device0.SetCooperativeLevel(GetDesktopWindow(), CooperativeLevel.Normal);
				_bool0 = true;
			}
			_secondaryBuffer0 = new SecondaryBuffer(new BufferDescription
			{
				BufferBytes = _int1,
				ControlPositionNotify = true,
				CanGetCurrentPosition = true,
				ControlVolume = true,
				GlobalFocus = true,
				StickyFocus = true,
				Format = smethod_0(_stream10.vmethod_0())
			}, _device0);
			_secondaryBuffer0.SetCurrentPosition(0);
			_int2 = 0;
			_secondaryBuffer0.Volume = 0;
			_autoResetEvent0 = new AutoResetEvent(false);
			_bufferPositionNotify1[0].EventNotifyHandle = _autoResetEvent0.Handle;
			_enum10 = AudioStatus.ShouldStopAudio;
		}

		private static WaveFormat smethod_0(SharpAudio.ASC.WaveFormat waveFormat0)
		{
			return new WaveFormat
			{
				AverageBytesPerSecond = waveFormat0.int_1,
				BitsPerSample = waveFormat0.short_2,
				BlockAlign = waveFormat0.short_1,
				Channels = waveFormat0.short_0,
				FormatTag = (WaveFormatTag)waveFormat0.waveFormatTag_0,
				SamplesPerSecond = waveFormat0.int_0
			};
		}

		public void DifferentStartPlaying()
		{
			if (_enum10 == AudioStatus.IsCurrentlyPlayingAudio)
			{
				method_0();
				return;
			}
			if (_enum10 == AudioStatus.ShouldStopAudio)
			{
				method_9();
				method_2(5);
				_long0 = 0L;
				_int2 = 0;
				_secondaryBuffer0.SetCurrentPosition(0);
				method_4();
				for (var i = 0; i < 5; i++)
				{
					method_7();
				}
				_secondaryBuffer0.SetCurrentPosition(0);
				_secondaryBuffer0.Volume = 0;
				_secondaryBuffer0.Play(0, BufferPlayFlags.Looping);
				_enum10 = AudioStatus.ShouldStartAudio;
			}
		}

		public void StartPlaying()
		{
			if (_enum10 == AudioStatus.ShouldStartAudio)
			{
				_secondaryBuffer0.Stop();
				_enum10 = AudioStatus.IsCurrentlyPlayingAudio;
			}
		}

		private void method_0()
		{
			if (_enum10 == AudioStatus.IsCurrentlyPlayingAudio)
			{
				_secondaryBuffer0.Play(0, BufferPlayFlags.Looping);
				_enum10 = AudioStatus.ShouldStartAudio;
			}
		}

		public void StopPlaying()
		{
			_secondaryBuffer0.Volume = -10000;
			method_0();
			method_9();
			_secondaryBuffer0.Stop();
			_enum10 = AudioStatus.ShouldStopAudio;
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(vmethod_0() / _double0);
		}

		public void SetStartingTime(TimeSpan timeSpan0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(_double0 * timeSpan0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (_enum10 != AudioStatus.ShouldStopAudio)
			{
				return (int)(_long0 - _int1 + method_1());
			}
			return (int)_long0;
		}

		public void SetStartingTimeBasedOnSomeValue(int int5)
		{
			StartPlaying();
			_stream10.Position = (_long0 = int5);
			method_0();
		}

		private int method_1()
		{
			var playPosition = _secondaryBuffer0.PlayPosition;
			if (playPosition >= _int2)
			{
				return playPosition - _int2;
			}
			return playPosition + _int1 - _int2;
		}

		public AudioStatus GetStatus()
		{
			return _enum10;
		}

		public SharpAudio.ASC.WaveFormat GetWaveFormat()
		{
			return _stream10.vmethod_0();
		}

		public void SetVolume(float float0)
		{
			_secondaryBuffer0.Volume = (int)(50f * Class15.smethod_0(float0));
		}

		private void method_2(int int5)
		{
			for (var i = 0; i < int5; i++)
			{
				_bufferPositionNotify0[i].Offset = (i + 1) * _int0 - 1;
				_bufferPositionNotify0[i].EventNotifyHandle = _autoResetEvent0.Handle;
			}
			_notify0 = new Notify(_secondaryBuffer0);
			_notify0.SetNotificationPositions(_bufferPositionNotify0);
		}

		private void method_3(int int5)
		{
			_bufferPositionNotify1[0].Offset = int5;
			_secondaryBuffer0.Stop();
			_notify0.SetNotificationPositions(_bufferPositionNotify1);
			_secondaryBuffer0.Play(0, BufferPlayFlags.Looping);
		}

		private void method_4()
		{
			if (_thread0 != null)
			{
				throw new Exception("CreateDataTransferThread() saw thread non-null.");
			}
			_bool2 = false;
			_int3 = 0;
			_int4 = 0;
			_thread0 = new Thread(method_5);
			_thread0.Name = "DataTransferThread";
			_thread0.Priority = ThreadPriority.Highest;
			_thread0.Start();
		}

		private void method_5()
		{
			var num = 0;
			while (_bool1)
			{
				if (_bool2)
				{
					return;
				}
				_autoResetEvent0.WaitOne(-1, true);
				if (!method_6())
				{
					num = _int2 / _int0;
					_bool1 = method_7();
				}
			}
			Array.Clear(_byte0, 0, _byte0.Length);
			var flag = true;
			while (flag)
			{
				_autoResetEvent0.WaitOne(-1, true);
				flag = method_6();
			}
			var num2 = _int2 / _int0;
			method_8();
			var int_ = (int)(_long0 % _int1);
			method_3(int_);
			var flag2 = false;
			while (!flag2)
			{
				_autoResetEvent0.WaitOne(-1, true);
				var num3 = _secondaryBuffer0.PlayPosition / _int0;
				if (!(flag2 = (num3 == num | num3 == num2)))
				{
					_int3++;
				}
			}
			_secondaryBuffer0.Stop();
			_enum10 = AudioStatus.ShouldStopAudio;
		}

		private bool method_6()
		{
			var num = _int2 / _int0;
			var num2 = _secondaryBuffer0.PlayPosition / _int0;
			if (num != num2)
			{
				return false;
			}
			_int3++;
			return true;
		}

		private bool method_7()
		{
			var num = _stream10.Read(_byte0, 0, _byte0.Length);
			_bool1 = (num > 0);
			_long0 += num;
			method_8();
			_int4++;
			return num >= _int0;
		}

		private void method_8()
		{
			_secondaryBuffer0.Write(_int2, _byte0, LockFlag.None);
			_int2 += _int0;
			_int2 %= _int1;
		}

		private void method_9()
		{
			if (_thread0 == null)
			{
				return;
			}
			if (_thread0.IsAlive)
			{
				_bool2 = true;
				_thread0.Join();
			}
			_thread0 = null;
		}

		public void Dispose()
		{
			method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool3)
		{
			StopPlaying();
			method_9();
			if (_autoResetEvent0 != null)
			{
				_autoResetEvent0.Close();
			}
			if (_secondaryBuffer0 != null)
			{
				_secondaryBuffer0.Dispose();
				_secondaryBuffer0 = null;
			}
			if (_bool0 && _device0 != null)
			{
				_device0.Dispose();
				_device0 = null;
			}
			if (bool3)
			{
				_stream10.Dispose();
			}
		}

		~OggOutput()
		{
			method_10(false);
		}
	}
}
