using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ns0;
using ns1;
using SharpAudio.ASC;

namespace ns6
{
	public class Class117 : IDisposable, PlayableAudio
	{
		private readonly GenericAudioStream stream1_0;

		private readonly Class120 class120_0;

		private readonly IntPtr intptr_0;

		private readonly Enum12 enum12_0;

		private readonly int int_0;

		private readonly double double_0;

		private readonly int int_1;

		private readonly int int_2;

		private readonly IntPtr intptr_1;

		private readonly IntPtr[] intptr_2;

		private AudioStatus enum1_0;

		private bool bool_0;

		private float float_0 = 1f;

		private int int_3;

		private bool bool_1;

		private readonly Stopwatch stopwatch_0 = new Stopwatch();

		private Thread thread_0;

		public Class117(GenericAudioStream stream1_1)
		{
			stream1_0 = stream1_1;
			class120_0 = (Class120.smethod_2() ?? new Class120());
			enum12_0 = Class119.smethod_10(stream1_1.vmethod_0());
			int_0 = stream1_1.vmethod_0().int_0;
			double_0 = stream1_1.vmethod_0().int_0 * (double)stream1_1.vmethod_0().short_1 / 1000.0;
			int_1 = stream1_1.vmethod_0().method_0(80);
			int_2 = 5;
			intptr_0 = Marshal.AllocHGlobal(int_1);
			intptr_1 = Class119.smethod_2();
			intptr_2 = Class119.smethod_8(int_2);
			enum1_0 = AudioStatus.ShouldStopAudio;
		}

		public void method_0()
		{
			if (thread_0 != null)
			{
				thread_0.Abort();
			}
			thread_0 = new Thread(method_1);
			thread_0.Start();
		}

		private void method_1()
		{
			bool flag = false;
			while (enum1_0 != AudioStatus.ShouldStopAudio && !flag)
			{
				if (bool_0)
				{
					bool_0 = false;
					Class119.alSourcef(intptr_1, Enum10.const_4, float_0);
				}
				if (enum1_0 != AudioStatus.IsCurrentlyPlayingAudio)
				{
					int num = 0;
					int num2;
					do
					{
						Class119.alGetSourcei(intptr_1, Enum11.const_6, out num2);
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
						IntPtr intPtr = Class119.smethod_6(intptr_1);
						int num3;
						lock (stream1_0)
						{
							num3 = stream1_0.vmethod_3(intptr_0, int_1);
						}
						if (num3 < int_1)
						{
							flag = true;
						}
						Class119.alBufferData(intPtr, enum12_0, intptr_0, num3, int_0);
						Class119.smethod_5(intptr_1, ref intPtr);
						int_3 += int_1;
						stopwatch_0.Reset();
						stopwatch_0.Start();
					}
					int num4;
					Class119.alGetSourcei(intptr_1, Enum11.const_5, out num4);
					if (num4 <= 0)
					{
						break;
					}
					if (Class119.smethod_4(intptr_1, Enum11.const_4) != 4114)
					{
						Class119.alSourcePlay(intptr_1);
					}
				}
			}
			if (!flag)
			{
				return;
			}
			while (Class119.smethod_4(intptr_1, Enum11.const_6) != int_2)
			{
			}
			Stream arg_188_0 = stream1_0;
			int_3 = 0;
			arg_188_0.Position = 0L;
			enum1_0 = AudioStatus.ShouldStopAudio;
			Class119.alSourceStop(intptr_1);
			stopwatch_0.Reset();
			Class119.smethod_7(intptr_1, intptr_2.Length);
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(int_3 / double_0 + stopwatch_0.ElapsedMilliseconds);
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(double_0 * timeSpan_0.TotalMilliseconds));
		}

		public void SetStartingTimeBasedOnSomeValue(int int_4)
		{
			AudioStatus @enum = enum1_0;
			if (@enum != AudioStatus.ShouldStopAudio)
			{
				StopPlaying();
			}
			Stream arg_21_0 = stream1_0;
			int_3 = int_4;
			arg_21_0.Position = int_4;
			stopwatch_0.Reset();
			if (@enum == AudioStatus.ShouldStartAudio)
			{
				DifferentStartPlaying();
			}
			GC.Collect();
		}

		public WaveFormat GetWaveFormat()
		{
			return stream1_0.vmethod_0();
		}

		public void SetVolume(float float_1)
		{
			bool_0 = true;
			float_0 = float_1;
		}

		public AudioStatus GetStatus()
		{
			return enum1_0;
		}

		public void DifferentStartPlaying()
		{
			switch (enum1_0)
			{
			case AudioStatus.ShouldStartAudio:
				return;
			case AudioStatus.IsCurrentlyPlayingAudio:
				Class119.alSourcePlay(intptr_1);
				stopwatch_0.Start();
				enum1_0 = AudioStatus.ShouldStartAudio;
				return;
			default:
			{
				while (Class119.smethod_4(intptr_1, Enum11.const_5) > 0)
				{
					Class119.smethod_6(intptr_1);
				}
				IntPtr[] array = intptr_2;
				for (int i = 0; i < array.Length; i++)
				{
					IntPtr intPtr = array[i];
					int num;
					lock (stream1_0)
					{
						num = stream1_0.vmethod_3(intptr_0, int_1);
					}
					Class119.alBufferData(intPtr, enum12_0, intptr_0, num, int_0);
				}
				Class119.alSourceQueueBuffers(intptr_1, intptr_2.Length, intptr_2);
				if (!bool_1)
				{
					ThreadPool.QueueUserWorkItem(method_3);
				}
				Class119.alSourcef(intptr_1, Enum10.const_4, 0f);
				Class119.alSourcePlay(intptr_1);
				stopwatch_0.Start();
				enum1_0 = AudioStatus.ShouldStartAudio;
				method_0();
				return;
			}
			}
		}

		public void StartPlaying()
		{
			Class119.alSourcePause(intptr_1);
			stopwatch_0.Stop();
			enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
		}

		public void StopPlaying()
		{
			thread_0.Abort();
			enum1_0 = AudioStatus.ShouldStopAudio;
			Class119.alSourceStop(intptr_1);
			stopwatch_0.Reset();
			Class119.smethod_7(intptr_1, intptr_2.Length);
		}

		public void Dispose()
		{
			method_2(true);
			GC.SuppressFinalize(this);
		}

		public void method_2(bool bool_2)
		{
			if (bool_2)
			{
				stream1_0.Dispose();
			}
			if (thread_0 != null)
			{
				thread_0.Abort();
			}
			try
			{
				Marshal.FreeHGlobal(intptr_0);
			}
			catch
			{
			}
			Class119.alSourceStop(intptr_1);
			Class119.smethod_3(intptr_1);
			Class119.smethod_9(intptr_2);
			class120_0.Dispose();
		}

		~Class117()
		{
			method_2(false);
		}

		[CompilerGenerated]
		private void method_3(object object_0)
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
