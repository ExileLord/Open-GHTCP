using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ns0;
using ns1;
using ns8;
using SharpAudio.ASC;

namespace ns11
{
	public class WaveOutput : IPlayableAudio
	{
		private class Class164
		{
			private readonly Enum19 _enum190;

			private readonly object _object0;

			public Class164(Enum19 enum191, object object1)
			{
				_enum190 = enum191;
				_object0 = object1;
			}

			public Enum19 method_0()
			{
				return _enum190;
			}

			public object method_1()
			{
				return _object0;
			}
		}

		private enum Enum19
		{
			Const0,
			Const1,
			Const2,
			Const3,
			Const4,
			Const5,
			Const6,
			Const7
		}

		private IntPtr _intptr0;

		private Class158[] _class1580;

		private readonly Queue<Class158> _queue0;

		private GenericAudioStream _stream10;

		private int _int0;

		private readonly double _double0;

		private AudioStatus _enum10;

		private readonly Class162.Delegate4 _delegate40;

		private readonly int _int1;

		private readonly int _int2;

		private float _float0 = 1f;

		private bool _bool0;

		private readonly Thread _thread0;

		private readonly Queue<Class164> _queue1;

		private readonly AutoResetEvent _autoResetEvent0;

		private readonly object _object0;

		private bool _bool1;

		private readonly Stopwatch _stopwatch0 = new Stopwatch();

		private int _int3;

		private EventHandler _eventHandler0;

		public WaveOutput(GenericAudioStream stream11) : this(stream11, -1, 300)
		{
		}

		public WaveOutput(GenericAudioStream stream11, int int4, int int5)
		{
			_stream10 = stream11;
			_int1 = int4;
			_int2 = int5;
			_double0 = stream11.vmethod_0().int_0 * (double)stream11.vmethod_0().short_1 / 1000.0;
			_delegate40 = method_2;
			_queue1 = new Queue<Class164>();
			_queue0 = new Queue<Class158>(5);
			_autoResetEvent0 = new AutoResetEvent(false);
			_object0 = new object();
			_thread0 = new Thread(method_1);
			_thread0.Start();
			_enum10 = AudioStatus.ShouldStopAudio;
			method_0(stream11);
		}

		public void method_0(GenericAudioStream stream11)
		{
			if (Thread.CurrentThread.ManagedThreadId != _thread0.ManagedThreadId)
			{
				lock (_queue1)
				{
					_queue1.Enqueue(new Class164(Enum19.Const0, _stream10));
					_autoResetEvent0.Set();
				}
				return;
			}
			_stream10 = stream11;
			_int0 = stream11.vmethod_0().method_0(_int2 / 5);
			Exception4.smethod_1(Class162.waveOutOpen(out _intptr0, _int1, _stream10.vmethod_0(), _delegate40, 0, Class162.Enum17.Const3), "waveOutOpen");
			_stream10.Position = vmethod_0();
			_class1580 = new Class158[5];
			for (var i = 0; i < 5; i++)
			{
				_class1580[i] = new Class158(_intptr0, _int0, _stream10, _object0);
			}
			_bool0 = false;
		}

		private void method_1()
		{
			while (true)
			{
				_autoResetEvent0.WaitOne();
				var flag = true;
				while (flag)
				{
					Class164 @class = null;
					lock (_queue1)
					{
						if (_queue1.Count > 0)
						{
							@class = _queue1.Dequeue();
						}
					}
					if (@class != null)
					{
						try
						{
							switch (@class.method_0())
							{
							case Enum19.Const0:
								method_0((GenericAudioStream)@class.method_1());
								break;
							case Enum19.Const1:
								StopPlaying();
								break;
							case Enum19.Const2:
								method_3((Class158)@class.method_1());
								break;
							case Enum19.Const3:
								method_5();
								break;
							case Enum19.Const4:
								method_6();
								break;
							case Enum19.Const5:
								method_9((int)@class.method_1());
								break;
							case Enum19.Const6:
								method_7();
								return;
							case Enum19.Const7:
								method_8((int)@class.method_1());
								break;
							}
							continue;
						}
						catch (Exception4 exception)
						{
							exception.ToString();
							if (@class.method_0() == Enum19.Const6)
							{
								return;
							}
							if (exception.method_0() == Enum18.Const23)
							{
								method_7();
								GC.Collect();
								method_0(_stream10);
								method_5();
							}
							continue;
						}
					}
					flag = false;
				}
			}
		}

		private void method_2(IntPtr intptr1, Class162.Enum16 enum160, int int4, ref Struct66 struct660, int int5)
		{
			if (enum160 == Class162.Enum16.Const1)
			{
				var object_ = (Class158)((GCHandle)struct660.Intptr1).Target;
				lock (_queue1)
				{
					_queue1.Enqueue(new Class164(Enum19.Const2, object_));
					_autoResetEvent0.Set();
				}
			}
		}

		private void method_3(Class158 class1581)
		{
			if (_enum10 == AudioStatus.ShouldStartAudio && !class1581.method_1())
			{
				StopPlaying();
				method_4();
				return;
			}
			if (class1581.method_2())
			{
				_int3 += class1581.method_3().method_3();
				_stopwatch0.Reset();
				_stopwatch0.Start();
				if (_queue0.Count == 5)
				{
					_queue0.Dequeue();
				}
				_queue0.Enqueue(class1581);
			}
		}

		private void method_4()
		{
			SetStartingTimeBasedOnSomeValue(0);
			_stopwatch0.Reset();
			if (_eventHandler0 != null)
			{
				_eventHandler0(this, EventArgs.Empty);
			}
		}

		public void DifferentStartPlaying()
		{
			if (_enum10 != AudioStatus.ShouldStartAudio)
			{
				_enum10 = AudioStatus.ShouldStartAudio;
				if (Thread.CurrentThread.ManagedThreadId != _thread0.ManagedThreadId)
				{
					lock (_queue1)
					{
						_queue1.Enqueue(new Class164(Enum19.Const3, null));
						_autoResetEvent0.Set();
					}
					return;
				}
				method_5();
			}
		}

		private void method_5()
		{
			if (!_bool0)
			{
				_enum10 = AudioStatus.ShouldStartAudio;
				for (var i = 0; i < 5; i++)
				{
					_class1580[i].method_1();
				}
				_bool0 = true;
			}
			method_6();
		}

		public void StartPlaying()
		{
			if (_enum10 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			var num = vmethod_0();
			StopPlaying();
			_stream10.Position = _int3 = num;
			_enum10 = AudioStatus.IsCurrentlyPlayingAudio;
		}

		public void method_6()
		{
			if (Thread.CurrentThread.ManagedThreadId != _thread0.ManagedThreadId)
			{
				lock (_queue1)
				{
					_queue1.Enqueue(new Class164(Enum19.Const4, null));
					_autoResetEvent0.Set();
				}
				return;
			}
			method_9(0);
			Enum18 @enum;
			lock (_object0)
			{
				@enum = Class162.waveOutRestart(_intptr0);
			}
			if (@enum != Enum18.Const0)
			{
				throw new Exception4(@enum, "waveOutRestart");
			}
			if (!_stopwatch0.IsRunning)
			{
				_stopwatch0.Start();
			}
			if (!_bool1)
			{
				ThreadPool.QueueUserWorkItem(method_11);
			}
		}

		public void method_7()
		{
			if (_intptr0 != IntPtr.Zero)
			{
				StopPlaying();
				Class162.waveOutClose(_intptr0);
				_intptr0 = IntPtr.Zero;
			}
			if (_class1580 != null)
			{
				for (var i = 0; i < 5; i++)
				{
					_class1580[i].Dispose();
				}
				_class1580 = null;
			}
		}

		public void StopPlaying()
		{
			if (Thread.CurrentThread.ManagedThreadId != _thread0.ManagedThreadId)
			{
				lock (_queue1)
				{
					_queue1.Enqueue(new Class164(Enum19.Const1, null));
					_autoResetEvent0.Set();
				}
				return;
			}
			_enum10 = AudioStatus.ShouldStopAudio;
			_bool0 = false;
			Enum18 @enum;
			lock (_object0)
			{
				@enum = Class162.waveOutReset(_intptr0);
			}
			if (@enum != Enum18.Const0)
			{
				throw new Exception4(@enum, "waveOutReset");
			}
			_stopwatch0.Reset();
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(_int3 / _double0 + _stopwatch0.ElapsedMilliseconds);
		}

		public void SetStartingTime(TimeSpan timeSpan0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(_double0 * timeSpan0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (_enum10 != AudioStatus.ShouldStopAudio)
			{
				return _int3 + (int)(_double0 * _stopwatch0.ElapsedMilliseconds);
			}
			return _int3;
		}

		public void SetStartingTimeBasedOnSomeValue(int int4)
		{
			_int3 = int4;
			lock (_queue1)
			{
				_queue1.Enqueue(new Class164(Enum19.Const7, int4));
				_autoResetEvent0.Set();
			}
		}

		private void method_8(int int4)
		{
			WaitCallback waitCallback = null;
			var @enum = _enum10;
			if (@enum == AudioStatus.IsCurrentlyPlayingAudio)
			{
				StopPlaying();
			}
			lock (_object0)
			{
				Stream arg350 = _stream10;
				_int3 = int4;
				arg350.Position = int4;
				if (@enum == AudioStatus.ShouldStartAudio)
				{
					var count = _queue0.Count;
					var num = 1f / (_int0 * count / (float)GetWaveFormat().short_1);
					var num2 = 0f;
					var num3 = 1f;
					if (GetWaveFormat().waveFormatTag_0 == WaveFormatTag.IeeeFloat)
					{
						var array = new float[_int0 >> 2];
						using (var enumerator = _queue0.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								var current = enumerator.Current;
								var array2 = current.method_3().method_1();
								var num4 = _stream10.vmethod_4(array, 0, array.Length);
								if (num4 == 0)
								{
									break;
								}
								var i = 0;
								var num5 = 0;
								while (i < num4)
								{
									array2[i] = num3 * array2[i] + num2 * array[i];
									num5++;
									if (num5 == GetWaveFormat().short_0)
									{
										num2 += num;
										num3 -= num;
										num5 = 0;
									}
									i++;
								}
								Array.Clear(array2, num4, current.method_3().method_5() - num4);
								current.method_3().method_6(num4);
							}
							goto IL_27D;
						}
					}
					if (GetWaveFormat().waveFormatTag_0 == WaveFormatTag.Pcm)
					{
						using (var @class = new Class19(_int0))
						{
							foreach (var current2 in _queue0)
							{
								var array3 = current2.method_3().method_2();
								var array4 = Class19.smethod_0(@class);
								var num6 = _stream10.vmethod_3(Class19.smethod_1(@class), _int0) >> 1;
								if (num6 == 0)
								{
									break;
								}
								var j = 0;
								var num7 = 0;
								while (j < num6)
								{
									array3[j] = (short)(num3 * array3[j] + num2 * array4[j]);
									num7++;
									if (num7 == GetWaveFormat().short_0)
									{
										num2 += num;
										num3 -= num;
										num7 = 0;
									}
									j++;
								}
								Array.Clear(array3, num6, current2.method_3().method_7() - num6);
								current2.method_3().method_8(num6);
							}
						}
					}
					IL_27D:
					GC.Collect();
					_stopwatch0.Reset();
					method_9(0);
					if (!_bool1)
					{
						if (waitCallback == null)
						{
							waitCallback = method_12;
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
				}
			}
		}

		public AudioStatus GetStatus()
		{
			return _enum10;
		}

		public WaveFormat GetWaveFormat()
		{
			return _stream10.vmethod_0();
		}

		public void SetVolume(float float1)
		{
			_float0 = float1;
			var num = _float0;
			var num2 = _float0;
			var num3 = (int)(num * 65535f) + ((int)(num2 * 65535f) << 16);
			lock (_queue1)
			{
				_queue1.Enqueue(new Class164(Enum19.Const5, num3));
				_autoResetEvent0.Set();
			}
		}

		private void method_9(int int4)
		{
			lock (_object0)
			{
				Exception4.smethod_1(Class162.waveOutSetVolume(_intptr0, int4), "waveOutSetVolume");
			}
		}

		public void Dispose()
		{
			method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool2)
		{
			lock (_queue1)
			{
				_queue1.Clear();
				_queue1.Enqueue(new Class164(Enum19.Const6, null));
				_autoResetEvent0.Set();
			}
			_thread0.Join();
			if (bool2)
			{
				_stream10.Dispose();
			}
		}

		~WaveOutput()
		{
			method_10(false);
		}

		[CompilerGenerated]
		private void method_11(object object1)
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

		[CompilerGenerated]
		private void method_12(object object1)
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
