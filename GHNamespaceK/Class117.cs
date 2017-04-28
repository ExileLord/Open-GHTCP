using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using GHNamespace1;
using GHNamespace2;
using SharpAudio.ASC;

namespace GHNamespaceK
{
	public class Class117 : IDisposable, IPlayableAudio
	{
		private readonly GenericAudioStream _stream10;

		private readonly Class120 _class1200;

		private readonly IntPtr _intptr0;

		private readonly Enum12 _enum120;

		private readonly int _int0;

		private readonly double _double0;

		private readonly int _int1;

		private readonly int _int2;

		private readonly IntPtr _intptr1;

		private readonly IntPtr[] _intptr2;

		private AudioStatus _enum10;

		private bool _bool0;

		private float _float0 = 1f;

		private int _int3;

		private bool _bool1;

		private readonly Stopwatch _stopwatch0 = new Stopwatch();

		private Thread _thread0;

		public Class117(GenericAudioStream stream11)
		{
			_stream10 = stream11;
			_class1200 = (Class120.smethod_2() ?? new Class120());
			_enum120 = Class119.smethod_10(stream11.vmethod_0());
			_int0 = stream11.vmethod_0().int_0;
			_double0 = stream11.vmethod_0().int_0 * (double)stream11.vmethod_0().short_1 / 1000.0;
			_int1 = stream11.vmethod_0().method_0(80);
			_int2 = 5;
			_intptr0 = Marshal.AllocHGlobal(_int1);
			_intptr1 = Class119.smethod_2();
			_intptr2 = Class119.smethod_8(_int2);
			_enum10 = AudioStatus.ShouldStopAudio;
		}

		public void method_0()
		{
			if (_thread0 != null)
			{
				_thread0.Abort();
			}
			_thread0 = new Thread(method_1);
			_thread0.Start();
		}

		private void method_1()
		{
			var flag = false;
			while (_enum10 != AudioStatus.ShouldStopAudio && !flag)
			{
				if (_bool0)
				{
					_bool0 = false;
					Class119.alSourcef(_intptr1, Enum10.Const4, _float0);
				}
				if (_enum10 != AudioStatus.IsCurrentlyPlayingAudio)
				{
					var num = 0;
					int num2;
					do
					{
						Class119.alGetSourcei(_intptr1, Enum11.Const6, out num2);
						if (num > 50)
						{
							Thread.Sleep(1);
						}
						else
						{
							num++;
						}
					}
					while (num2 == 0);
					while (num2-- != 0)
					{
						var intPtr = Class119.smethod_6(_intptr1);
						int num3;
						lock (_stream10)
						{
							num3 = _stream10.vmethod_3(_intptr0, _int1);
						}
						if (num3 < _int1)
						{
							flag = true;
						}
						Class119.alBufferData(intPtr, _enum120, _intptr0, num3, _int0);
						Class119.smethod_5(_intptr1, ref intPtr);
						_int3 += _int1;
						_stopwatch0.Reset();
						_stopwatch0.Start();
					}
					int num4;
					Class119.alGetSourcei(_intptr1, Enum11.Const5, out num4);
					if (num4 <= 0)
					{
						break;
					}
					if (Class119.smethod_4(_intptr1, Enum11.Const4) != 4114)
					{
						Class119.alSourcePlay(_intptr1);
					}
				}
			}
			if (!flag)
			{
				return;
			}
			while (Class119.smethod_4(_intptr1, Enum11.Const6) != _int2)
			{
			}
			Stream arg1880 = _stream10;
			_int3 = 0;
			arg1880.Position = 0L;
			_enum10 = AudioStatus.ShouldStopAudio;
			Class119.alSourceStop(_intptr1);
			_stopwatch0.Reset();
			Class119.smethod_7(_intptr1, _intptr2.Length);
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(_int3 / _double0 + _stopwatch0.ElapsedMilliseconds);
		}

		public void SetStartingTime(TimeSpan timeSpan0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(_double0 * timeSpan0.TotalMilliseconds));
		}

		public void SetStartingTimeBasedOnSomeValue(int int4)
		{
			var @enum = _enum10;
			if (@enum != AudioStatus.ShouldStopAudio)
			{
				StopPlaying();
			}
			Stream arg210 = _stream10;
			_int3 = int4;
			arg210.Position = int4;
			_stopwatch0.Reset();
			if (@enum == AudioStatus.ShouldStartAudio)
			{
				DifferentStartPlaying();
			}
			GC.Collect();
		}

		public WaveFormat GetWaveFormat()
		{
			return _stream10.vmethod_0();
		}

		public void SetVolume(float float1)
		{
			_bool0 = true;
			_float0 = float1;
		}

		public AudioStatus GetStatus()
		{
			return _enum10;
		}

		public void DifferentStartPlaying()
		{
			switch (_enum10)
			{
			case AudioStatus.ShouldStartAudio:
				return;
			case AudioStatus.IsCurrentlyPlayingAudio:
				Class119.alSourcePlay(_intptr1);
				_stopwatch0.Start();
				_enum10 = AudioStatus.ShouldStartAudio;
				return;
			default:
			{
				while (Class119.smethod_4(_intptr1, Enum11.Const5) > 0)
				{
					Class119.smethod_6(_intptr1);
				}
				var array = _intptr2;
				for (var i = 0; i < array.Length; i++)
				{
					var intPtr = array[i];
					int num;
					lock (_stream10)
					{
						num = _stream10.vmethod_3(_intptr0, _int1);
					}
					Class119.alBufferData(intPtr, _enum120, _intptr0, num, _int0);
				}
				Class119.alSourceQueueBuffers(_intptr1, _intptr2.Length, _intptr2);
				if (!_bool1)
				{
					ThreadPool.QueueUserWorkItem(method_3);
				}
				Class119.alSourcef(_intptr1, Enum10.Const4, 0f);
				Class119.alSourcePlay(_intptr1);
				_stopwatch0.Start();
				_enum10 = AudioStatus.ShouldStartAudio;
				method_0();
				return;
			}
			}
		}

		public void StartPlaying()
		{
			Class119.alSourcePause(_intptr1);
			_stopwatch0.Stop();
			_enum10 = AudioStatus.IsCurrentlyPlayingAudio;
		}

		public void StopPlaying()
		{
			_thread0.Abort();
			_enum10 = AudioStatus.ShouldStopAudio;
			Class119.alSourceStop(_intptr1);
			_stopwatch0.Reset();
			Class119.smethod_7(_intptr1, _intptr2.Length);
		}

		public void Dispose()
		{
			method_2(true);
			GC.SuppressFinalize(this);
		}

		public void method_2(bool bool2)
		{
			if (bool2)
			{
				_stream10.Dispose();
			}
			if (_thread0 != null)
			{
				_thread0.Abort();
			}
			try
			{
				Marshal.FreeHGlobal(_intptr0);
			}
			catch
			{
			}
			Class119.alSourceStop(_intptr1);
			Class119.smethod_3(_intptr1);
			Class119.smethod_9(_intptr2);
			_class1200.Dispose();
		}

		~Class117()
		{
			method_2(false);
		}

		[CompilerGenerated]
		private void method_3(object object0)
		{
			_bool1 = true;
			var num = 0f;
			var num2 = _float0;
			while (num < num2)
			{
				SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			SetVolume(num2);
			_bool1 = false;
		}
	}
}
