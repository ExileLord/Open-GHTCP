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
	public class WaveOutput : PlayableAudio
	{
		private class Class164
		{
			private readonly Enum19 enum19_0;

			private readonly object object_0;

			public Class164(Enum19 enum19_1, object object_1)
			{
				enum19_0 = enum19_1;
				object_0 = object_1;
			}

			public Enum19 method_0()
			{
				return enum19_0;
			}

			public object method_1()
			{
				return object_0;
			}
		}

		private enum Enum19
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7
		}

		private IntPtr intptr_0;

		private Class158[] class158_0;

		private readonly Queue<Class158> queue_0;

		private GenericAudioStream stream1_0;

		private int int_0;

		private readonly double double_0;

		private AudioStatus enum1_0;

		private readonly Class162.Delegate4 delegate4_0;

		private readonly int int_1;

		private readonly int int_2;

		private float float_0 = 1f;

		private bool bool_0;

		private readonly Thread thread_0;

		private readonly Queue<Class164> queue_1;

		private readonly AutoResetEvent autoResetEvent_0;

		private readonly object object_0;

		private bool bool_1;

		private readonly Stopwatch stopwatch_0 = new Stopwatch();

		private int int_3;

		private EventHandler eventHandler_0;

		public WaveOutput(GenericAudioStream stream1_1) : this(stream1_1, -1, 300)
		{
		}

		public WaveOutput(GenericAudioStream stream1_1, int int_4, int int_5)
		{
			stream1_0 = stream1_1;
			int_1 = int_4;
			int_2 = int_5;
			double_0 = stream1_1.vmethod_0().int_0 * (double)stream1_1.vmethod_0().short_1 / 1000.0;
			delegate4_0 = method_2;
			queue_1 = new Queue<Class164>();
			queue_0 = new Queue<Class158>(5);
			autoResetEvent_0 = new AutoResetEvent(false);
			object_0 = new object();
			thread_0 = new Thread(method_1);
			thread_0.Start();
			enum1_0 = AudioStatus.ShouldStopAudio;
			method_0(stream1_1);
		}

		public void method_0(GenericAudioStream stream1_1)
		{
			if (Thread.CurrentThread.ManagedThreadId != thread_0.ManagedThreadId)
			{
				lock (queue_1)
				{
					queue_1.Enqueue(new Class164(Enum19.const_0, stream1_0));
					autoResetEvent_0.Set();
				}
				return;
			}
			stream1_0 = stream1_1;
			int_0 = stream1_1.vmethod_0().method_0(int_2 / 5);
			Exception4.smethod_1(Class162.waveOutOpen(out intptr_0, int_1, stream1_0.vmethod_0(), delegate4_0, 0, Class162.Enum17.const_3), "waveOutOpen");
			stream1_0.Position = vmethod_0();
			class158_0 = new Class158[5];
			for (int i = 0; i < 5; i++)
			{
				class158_0[i] = new Class158(intptr_0, int_0, stream1_0, object_0);
			}
			bool_0 = false;
		}

		private void method_1()
		{
			while (true)
			{
				autoResetEvent_0.WaitOne();
				bool flag = true;
				while (flag)
				{
					Class164 @class = null;
					lock (queue_1)
					{
						if (queue_1.Count > 0)
						{
							@class = queue_1.Dequeue();
						}
					}
					if (@class != null)
					{
						try
						{
							switch (@class.method_0())
							{
							case Enum19.const_0:
								method_0((GenericAudioStream)@class.method_1());
								break;
							case Enum19.const_1:
								StopPlaying();
								break;
							case Enum19.const_2:
								method_3((Class158)@class.method_1());
								break;
							case Enum19.const_3:
								method_5();
								break;
							case Enum19.const_4:
								method_6();
								break;
							case Enum19.const_5:
								method_9((int)@class.method_1());
								break;
							case Enum19.const_6:
								method_7();
								return;
							case Enum19.const_7:
								method_8((int)@class.method_1());
								break;
							}
							continue;
						}
						catch (Exception4 exception)
						{
							exception.ToString();
							if (@class.method_0() == Enum19.const_6)
							{
								return;
							}
							if (exception.method_0() == Enum18.const_23)
							{
								method_7();
								GC.Collect();
								method_0(stream1_0);
								method_5();
							}
							continue;
						}
					}
					flag = false;
				}
			}
		}

		private void method_2(IntPtr intptr_1, Class162.Enum16 enum16_0, int int_4, ref Struct66 struct66_0, int int_5)
		{
			if (enum16_0 == Class162.Enum16.const_1)
			{
				Class158 object_ = (Class158)((GCHandle)struct66_0.intptr_1).Target;
				lock (queue_1)
				{
					queue_1.Enqueue(new Class164(Enum19.const_2, object_));
					autoResetEvent_0.Set();
				}
			}
		}

		private void method_3(Class158 class158_1)
		{
			if (enum1_0 == AudioStatus.ShouldStartAudio && !class158_1.method_1())
			{
				StopPlaying();
				method_4();
				return;
			}
			if (class158_1.method_2())
			{
				int_3 += class158_1.method_3().method_3();
				stopwatch_0.Reset();
				stopwatch_0.Start();
				if (queue_0.Count == 5)
				{
					queue_0.Dequeue();
				}
				queue_0.Enqueue(class158_1);
			}
		}

		private void method_4()
		{
			SetStartingTimeBasedOnSomeValue(0);
			stopwatch_0.Reset();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		public void DifferentStartPlaying()
		{
			if (enum1_0 != AudioStatus.ShouldStartAudio)
			{
				enum1_0 = AudioStatus.ShouldStartAudio;
				if (Thread.CurrentThread.ManagedThreadId != thread_0.ManagedThreadId)
				{
					lock (queue_1)
					{
						queue_1.Enqueue(new Class164(Enum19.const_3, null));
						autoResetEvent_0.Set();
					}
					return;
				}
				method_5();
			}
		}

		private void method_5()
		{
			if (!bool_0)
			{
				enum1_0 = AudioStatus.ShouldStartAudio;
				for (int i = 0; i < 5; i++)
				{
					class158_0[i].method_1();
				}
				bool_0 = true;
			}
			method_6();
		}

		public void StartPlaying()
		{
			if (enum1_0 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			int num = vmethod_0();
			StopPlaying();
			stream1_0.Position = int_3 = num;
			enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
		}

		public void method_6()
		{
			if (Thread.CurrentThread.ManagedThreadId != thread_0.ManagedThreadId)
			{
				lock (queue_1)
				{
					queue_1.Enqueue(new Class164(Enum19.const_4, null));
					autoResetEvent_0.Set();
				}
				return;
			}
			method_9(0);
			Enum18 @enum;
			lock (object_0)
			{
				@enum = Class162.waveOutRestart(intptr_0);
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutRestart");
			}
			if (!stopwatch_0.IsRunning)
			{
				stopwatch_0.Start();
			}
			if (!bool_1)
			{
				ThreadPool.QueueUserWorkItem(method_11);
			}
		}

		public void method_7()
		{
			if (intptr_0 != IntPtr.Zero)
			{
				StopPlaying();
				Class162.waveOutClose(intptr_0);
				intptr_0 = IntPtr.Zero;
			}
			if (class158_0 != null)
			{
				for (int i = 0; i < 5; i++)
				{
					class158_0[i].Dispose();
				}
				class158_0 = null;
			}
		}

		public void StopPlaying()
		{
			if (Thread.CurrentThread.ManagedThreadId != thread_0.ManagedThreadId)
			{
				lock (queue_1)
				{
					queue_1.Enqueue(new Class164(Enum19.const_1, null));
					autoResetEvent_0.Set();
				}
				return;
			}
			enum1_0 = AudioStatus.ShouldStopAudio;
			bool_0 = false;
			Enum18 @enum;
			lock (object_0)
			{
				@enum = Class162.waveOutReset(intptr_0);
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutReset");
			}
			stopwatch_0.Reset();
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(int_3 / double_0 + stopwatch_0.ElapsedMilliseconds);
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(double_0 * timeSpan_0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (enum1_0 != AudioStatus.ShouldStopAudio)
			{
				return int_3 + (int)(double_0 * stopwatch_0.ElapsedMilliseconds);
			}
			return int_3;
		}

		public void SetStartingTimeBasedOnSomeValue(int int_4)
		{
			int_3 = int_4;
			lock (queue_1)
			{
				queue_1.Enqueue(new Class164(Enum19.const_7, int_4));
				autoResetEvent_0.Set();
			}
		}

		private void method_8(int int_4)
		{
			WaitCallback waitCallback = null;
			AudioStatus @enum = enum1_0;
			if (@enum == AudioStatus.IsCurrentlyPlayingAudio)
			{
				StopPlaying();
			}
			lock (object_0)
			{
				Stream arg_35_0 = stream1_0;
				int_3 = int_4;
				arg_35_0.Position = int_4;
				if (@enum == AudioStatus.ShouldStartAudio)
				{
					int count = queue_0.Count;
					float num = 1f / (int_0 * count / (float)GetWaveFormat().short_1);
					float num2 = 0f;
					float num3 = 1f;
					if (GetWaveFormat().waveFormatTag_0 == WaveFormatTag.IEEEFloat)
					{
						float[] array = new float[int_0 >> 2];
						using (Queue<Class158>.Enumerator enumerator = queue_0.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Class158 current = enumerator.Current;
								float[] array2 = current.method_3().method_1();
								int num4 = stream1_0.vmethod_4(array, 0, array.Length);
								if (num4 == 0)
								{
									break;
								}
								int i = 0;
								int num5 = 0;
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
					if (GetWaveFormat().waveFormatTag_0 == WaveFormatTag.PCM)
					{
						using (Class19 @class = new Class19(int_0))
						{
							foreach (Class158 current2 in queue_0)
							{
								short[] array3 = current2.method_3().method_2();
								short[] array4 = Class19.smethod_0(@class);
								int num6 = stream1_0.vmethod_3(Class19.smethod_1(@class), int_0) >> 1;
								if (num6 == 0)
								{
									break;
								}
								int j = 0;
								int num7 = 0;
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
					stopwatch_0.Reset();
					method_9(0);
					if (!bool_1)
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
			return enum1_0;
		}

		public WaveFormat GetWaveFormat()
		{
			return stream1_0.vmethod_0();
		}

		public void SetVolume(float float_1)
		{
			float_0 = float_1;
			float num = float_0;
			float num2 = float_0;
			int num3 = (int)(num * 65535f) + ((int)(num2 * 65535f) << 16);
			lock (queue_1)
			{
				queue_1.Enqueue(new Class164(Enum19.const_5, num3));
				autoResetEvent_0.Set();
			}
		}

		private void method_9(int int_4)
		{
			lock (object_0)
			{
				Exception4.smethod_1(Class162.waveOutSetVolume(intptr_0, int_4), "waveOutSetVolume");
			}
		}

		public void Dispose()
		{
			method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool_2)
		{
			lock (queue_1)
			{
				queue_1.Clear();
				queue_1.Enqueue(new Class164(Enum19.const_6, null));
				autoResetEvent_0.Set();
			}
			thread_0.Join();
			if (bool_2)
			{
				stream1_0.Dispose();
			}
		}

		~WaveOutput()
		{
			method_10(false);
		}

		[CompilerGenerated]
		private void method_11(object object_1)
		{
			bool_1 = true;
			float num = 0f;
			float num2 = float_0;
			while (num < num2)
			{
				SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			SetVolume(num2);
			bool_1 = false;
		}

		[CompilerGenerated]
		private void method_12(object object_1)
		{
			bool_1 = true;
			float num = 0f;
			float num2 = float_0;
			while (num < num2)
			{
				SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			SetVolume(num2);
			bool_1 = false;
		}
	}
}
