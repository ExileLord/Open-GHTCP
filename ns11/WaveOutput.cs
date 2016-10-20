using ns0;
using ns1;
using ns8;
using SharpAudio.ASC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns11
{
	public class WaveOutput : PlayableAudio
	{
		private class Class164
		{
			private readonly WaveOutput.Enum19 enum19_0;

			private readonly object object_0;

			public Class164(WaveOutput.Enum19 enum19_1, object object_1)
			{
				this.enum19_0 = enum19_1;
				this.object_0 = object_1;
			}

			public WaveOutput.Enum19 method_0()
			{
				return this.enum19_0;
			}

			public object method_1()
			{
				return this.object_0;
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

		private readonly Queue<WaveOutput.Class164> queue_1;

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
			this.stream1_0 = stream1_1;
			this.int_1 = int_4;
			this.int_2 = int_5;
			this.double_0 = (double)stream1_1.vmethod_0().int_0 * (double)stream1_1.vmethod_0().short_1 / 1000.0;
			this.delegate4_0 = new Class162.Delegate4(this.method_2);
			this.queue_1 = new Queue<WaveOutput.Class164>();
			this.queue_0 = new Queue<Class158>(5);
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.object_0 = new object();
			this.thread_0 = new Thread(new ThreadStart(this.method_1));
			this.thread_0.Start();
			this.enum1_0 = AudioStatus.ShouldStopAudio;
			this.method_0(stream1_1);
		}

		public void method_0(GenericAudioStream stream1_1)
		{
			if (Thread.CurrentThread.ManagedThreadId != this.thread_0.ManagedThreadId)
			{
				lock (this.queue_1)
				{
					this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_0, this.stream1_0));
					this.autoResetEvent_0.Set();
				}
				return;
			}
			this.stream1_0 = stream1_1;
			this.int_0 = stream1_1.vmethod_0().method_0(this.int_2 / 5);
			Exception4.smethod_1(Class162.waveOutOpen(out this.intptr_0, this.int_1, this.stream1_0.vmethod_0(), this.delegate4_0, 0, Class162.Enum17.const_3), "waveOutOpen");
			this.stream1_0.Position = (long)this.vmethod_0();
			this.class158_0 = new Class158[5];
			for (int i = 0; i < 5; i++)
			{
				this.class158_0[i] = new Class158(this.intptr_0, this.int_0, this.stream1_0, this.object_0);
			}
			this.bool_0 = false;
		}

		private void method_1()
		{
			while (true)
			{
				this.autoResetEvent_0.WaitOne();
				bool flag = true;
				while (flag)
				{
					WaveOutput.Class164 @class = null;
					lock (this.queue_1)
					{
						if (this.queue_1.Count > 0)
						{
							@class = this.queue_1.Dequeue();
						}
					}
					if (@class != null)
					{
						try
						{
							switch (@class.method_0())
							{
							case WaveOutput.Enum19.const_0:
								this.method_0((GenericAudioStream)@class.method_1());
								break;
							case WaveOutput.Enum19.const_1:
								this.StopPlaying();
								break;
							case WaveOutput.Enum19.const_2:
								this.method_3((Class158)@class.method_1());
								break;
							case WaveOutput.Enum19.const_3:
								this.method_5();
								break;
							case WaveOutput.Enum19.const_4:
								this.method_6();
								break;
							case WaveOutput.Enum19.const_5:
								this.method_9((int)@class.method_1());
								break;
							case WaveOutput.Enum19.const_6:
								this.method_7();
								return;
							case WaveOutput.Enum19.const_7:
								this.method_8((int)@class.method_1());
								break;
							}
							continue;
						}
						catch (Exception4 exception)
						{
							exception.ToString();
							if (@class.method_0() == WaveOutput.Enum19.const_6)
							{
								return;
							}
							if (exception.method_0() == Enum18.const_23)
							{
								this.method_7();
								GC.Collect();
								this.method_0(this.stream1_0);
								this.method_5();
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
				lock (this.queue_1)
				{
					this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_2, object_));
					this.autoResetEvent_0.Set();
				}
			}
		}

		private void method_3(Class158 class158_1)
		{
			if (this.enum1_0 == AudioStatus.ShouldStartAudio && !class158_1.method_1())
			{
				this.StopPlaying();
				this.method_4();
				return;
			}
			if (class158_1.method_2())
			{
				this.int_3 += class158_1.method_3().method_3();
				this.stopwatch_0.Reset();
				this.stopwatch_0.Start();
				if (this.queue_0.Count == 5)
				{
					this.queue_0.Dequeue();
				}
				this.queue_0.Enqueue(class158_1);
			}
		}

		private void method_4()
		{
			this.SetStartingTimeBasedOnSomeValue(0);
			this.stopwatch_0.Reset();
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		public void DifferentStartPlaying()
		{
			if (this.enum1_0 != AudioStatus.ShouldStartAudio)
			{
				this.enum1_0 = AudioStatus.ShouldStartAudio;
				if (Thread.CurrentThread.ManagedThreadId != this.thread_0.ManagedThreadId)
				{
					lock (this.queue_1)
					{
						this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_3, null));
						this.autoResetEvent_0.Set();
					}
					return;
				}
				this.method_5();
			}
		}

		private void method_5()
		{
			if (!this.bool_0)
			{
				this.enum1_0 = AudioStatus.ShouldStartAudio;
				for (int i = 0; i < 5; i++)
				{
					this.class158_0[i].method_1();
				}
				this.bool_0 = true;
			}
			this.method_6();
		}

		public void StartPlaying()
		{
			if (this.enum1_0 != AudioStatus.ShouldStartAudio)
			{
				return;
			}
			int num = this.vmethod_0();
			this.StopPlaying();
			this.stream1_0.Position = (long)(this.int_3 = num);
			this.enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
		}

		public void method_6()
		{
			if (Thread.CurrentThread.ManagedThreadId != this.thread_0.ManagedThreadId)
			{
				lock (this.queue_1)
				{
					this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_4, null));
					this.autoResetEvent_0.Set();
				}
				return;
			}
			this.method_9(0);
			Enum18 @enum;
			lock (this.object_0)
			{
				@enum = Class162.waveOutRestart(this.intptr_0);
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutRestart");
			}
			if (!this.stopwatch_0.IsRunning)
			{
				this.stopwatch_0.Start();
			}
			if (!this.bool_1)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.method_11));
			}
		}

		public void method_7()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.StopPlaying();
				Class162.waveOutClose(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
			if (this.class158_0 != null)
			{
				for (int i = 0; i < 5; i++)
				{
					this.class158_0[i].Dispose();
				}
				this.class158_0 = null;
			}
		}

		public void StopPlaying()
		{
			if (Thread.CurrentThread.ManagedThreadId != this.thread_0.ManagedThreadId)
			{
				lock (this.queue_1)
				{
					this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_1, null));
					this.autoResetEvent_0.Set();
				}
				return;
			}
			this.enum1_0 = AudioStatus.ShouldStopAudio;
			this.bool_0 = false;
			Enum18 @enum;
			lock (this.object_0)
			{
				@enum = Class162.waveOutReset(this.intptr_0);
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutReset");
			}
			this.stopwatch_0.Reset();
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds((double)this.int_3 / this.double_0 + (double)this.stopwatch_0.ElapsedMilliseconds);
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			this.SetStartingTimeBasedOnSomeValue(Convert.ToInt32(this.double_0 * timeSpan_0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (this.enum1_0 != AudioStatus.ShouldStopAudio)
			{
				return this.int_3 + (int)(this.double_0 * (double)this.stopwatch_0.ElapsedMilliseconds);
			}
			return this.int_3;
		}

		public void SetStartingTimeBasedOnSomeValue(int int_4)
		{
			this.int_3 = int_4;
			lock (this.queue_1)
			{
				this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_7, int_4));
				this.autoResetEvent_0.Set();
			}
		}

		private void method_8(int int_4)
		{
			WaitCallback waitCallback = null;
			AudioStatus @enum = this.enum1_0;
			if (@enum == AudioStatus.IsCurrentlyPlayingAudio)
			{
				this.StopPlaying();
			}
			lock (this.object_0)
			{
				Stream arg_35_0 = this.stream1_0;
				this.int_3 = int_4;
				arg_35_0.Position = (long)int_4;
				if (@enum == AudioStatus.ShouldStartAudio)
				{
					int count = this.queue_0.Count;
					float num = 1f / ((float)(this.int_0 * count) / (float)this.GetWaveFormat().short_1);
					float num2 = 0f;
					float num3 = 1f;
					if (this.GetWaveFormat().waveFormatTag_0 == WaveFormatTag.IEEEFloat)
					{
						float[] array = new float[this.int_0 >> 2];
						using (Queue<Class158>.Enumerator enumerator = this.queue_0.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Class158 current = enumerator.Current;
								float[] array2 = current.method_3().method_1();
								int num4 = this.stream1_0.vmethod_4(array, 0, array.Length);
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
									if (num5 == (int)this.GetWaveFormat().short_0)
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
					if (this.GetWaveFormat().waveFormatTag_0 == WaveFormatTag.PCM)
					{
						using (Class19 @class = new Class19(this.int_0))
						{
							foreach (Class158 current2 in this.queue_0)
							{
								short[] array3 = current2.method_3().method_2();
								short[] array4 = Class19.smethod_0(@class);
								int num6 = this.stream1_0.vmethod_3(Class19.smethod_1(@class), this.int_0) >> 1;
								if (num6 == 0)
								{
									break;
								}
								int j = 0;
								int num7 = 0;
								while (j < num6)
								{
									array3[j] = (short)(num3 * (float)array3[j] + num2 * (float)array4[j]);
									num7++;
									if (num7 == (int)this.GetWaveFormat().short_0)
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
					this.stopwatch_0.Reset();
					this.method_9(0);
					if (!this.bool_1)
					{
						if (waitCallback == null)
						{
							waitCallback = new WaitCallback(this.method_12);
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
				}
			}
		}

		public AudioStatus GetStatus()
		{
			return this.enum1_0;
		}

		public WaveFormat GetWaveFormat()
		{
			return this.stream1_0.vmethod_0();
		}

		public void SetVolume(float float_1)
		{
			this.float_0 = float_1;
			float num = this.float_0;
			float num2 = this.float_0;
			int num3 = (int)(num * 65535f) + ((int)(num2 * 65535f) << 16);
			lock (this.queue_1)
			{
				this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_5, num3));
				this.autoResetEvent_0.Set();
			}
		}

		private void method_9(int int_4)
		{
			lock (this.object_0)
			{
				Exception4.smethod_1(Class162.waveOutSetVolume(this.intptr_0, int_4), "waveOutSetVolume");
			}
		}

		public void Dispose()
		{
			this.method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool_2)
		{
			lock (this.queue_1)
			{
				this.queue_1.Clear();
				this.queue_1.Enqueue(new WaveOutput.Class164(WaveOutput.Enum19.const_6, null));
				this.autoResetEvent_0.Set();
			}
			this.thread_0.Join();
			if (bool_2)
			{
				this.stream1_0.Dispose();
			}
		}

		~WaveOutput()
		{
			this.method_10(false);
		}

		[CompilerGenerated]
		private void method_11(object object_1)
		{
			this.bool_1 = true;
			float num = 0f;
			float num2 = this.float_0;
			while (num < num2)
			{
				this.SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			this.SetVolume(num2);
			this.bool_1 = false;
		}

		[CompilerGenerated]
		private void method_12(object object_1)
		{
			this.bool_1 = true;
			float num = 0f;
			float num2 = this.float_0;
			while (num < num2)
			{
				this.SetVolume(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			this.SetVolume(num2);
			this.bool_1 = false;
		}
	}
}
