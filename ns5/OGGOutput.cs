using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.DirectX.DirectSound;
using ns0;
using ns1;

namespace ns5
{
	public class OGGOutput : PlayableAudio
	{
		private AudioStatus enum1_0;

		private readonly GenericAudioStream stream1_0;

		private readonly int int_0;

		private readonly int int_1;

		private Device device_0;

		private readonly bool bool_0;

		private SecondaryBuffer secondaryBuffer_0;

		private int int_2;

		private bool bool_1;

		private readonly double double_0;

		private long long_0;

		private readonly BufferPositionNotify[] bufferPositionNotify_0 = new BufferPositionNotify[5];

		private readonly AutoResetEvent autoResetEvent_0;

		private readonly BufferPositionNotify[] bufferPositionNotify_1 = new BufferPositionNotify[1];

		private Notify notify_0;

		private Thread thread_0;

		private bool bool_2;

		private int int_3;

		private int int_4;

		private readonly byte[] byte_0;

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		public OGGOutput(GenericAudioStream stream1_1) : this(stream1_1, null, 500)
		{
		}

		public OGGOutput(GenericAudioStream stream1_1, Device device_1, int int_5)
		{
			stream1_0 = new Stream4(stream1_1, 16);
			int_1 = stream1_0.vmethod_0().method_0(int_5);
			int_1 -= int_1 % 5;
			int_0 = int_1 / 5;
			double_0 = stream1_0.vmethod_0().int_0 * (double)stream1_0.vmethod_0().short_1 / 1000.0;
			byte_0 = new byte[int_0];
			device_0 = device_1;
			if (device_0 == null)
			{
				device_0 = new Device();
				device_0.SetCooperativeLevel(GetDesktopWindow(), CooperativeLevel.Normal);
				bool_0 = true;
			}
			secondaryBuffer_0 = new SecondaryBuffer(new BufferDescription
			{
				BufferBytes = int_1,
				ControlPositionNotify = true,
				CanGetCurrentPosition = true,
				ControlVolume = true,
				GlobalFocus = true,
				StickyFocus = true,
				Format = smethod_0(stream1_0.vmethod_0())
			}, device_0);
			secondaryBuffer_0.SetCurrentPosition(0);
			int_2 = 0;
			secondaryBuffer_0.Volume = 0;
			autoResetEvent_0 = new AutoResetEvent(false);
			bufferPositionNotify_1[0].EventNotifyHandle = autoResetEvent_0.Handle;
			enum1_0 = AudioStatus.ShouldStopAudio;
		}

		private static WaveFormat smethod_0(SharpAudio.ASC.WaveFormat waveFormat_0)
		{
			return new WaveFormat
			{
				AverageBytesPerSecond = waveFormat_0.int_1,
				BitsPerSample = waveFormat_0.short_2,
				BlockAlign = waveFormat_0.short_1,
				Channels = waveFormat_0.short_0,
				FormatTag = (WaveFormatTag)waveFormat_0.waveFormatTag_0,
				SamplesPerSecond = waveFormat_0.int_0
			};
		}

		public void DifferentStartPlaying()
		{
			if (enum1_0 == AudioStatus.IsCurrentlyPlayingAudio)
			{
				method_0();
				return;
			}
			if (enum1_0 == AudioStatus.ShouldStopAudio)
			{
				method_9();
				method_2(5);
				long_0 = 0L;
				int_2 = 0;
				secondaryBuffer_0.SetCurrentPosition(0);
				method_4();
				for (var i = 0; i < 5; i++)
				{
					method_7();
				}
				secondaryBuffer_0.SetCurrentPosition(0);
				secondaryBuffer_0.Volume = 0;
				secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
				enum1_0 = AudioStatus.ShouldStartAudio;
			}
		}

		public void StartPlaying()
		{
			if (enum1_0 == AudioStatus.ShouldStartAudio)
			{
				secondaryBuffer_0.Stop();
				enum1_0 = AudioStatus.IsCurrentlyPlayingAudio;
			}
		}

		private void method_0()
		{
			if (enum1_0 == AudioStatus.IsCurrentlyPlayingAudio)
			{
				secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
				enum1_0 = AudioStatus.ShouldStartAudio;
			}
		}

		public void StopPlaying()
		{
			secondaryBuffer_0.Volume = -10000;
			method_0();
			method_9();
			secondaryBuffer_0.Stop();
			enum1_0 = AudioStatus.ShouldStopAudio;
		}

		public TimeSpan AudioLength()
		{
			return TimeSpan.FromMilliseconds(vmethod_0() / double_0);
		}

		public void SetStartingTime(TimeSpan timeSpan_0)
		{
			SetStartingTimeBasedOnSomeValue(Convert.ToInt32(double_0 * timeSpan_0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (enum1_0 != AudioStatus.ShouldStopAudio)
			{
				return (int)(long_0 - int_1 + method_1());
			}
			return (int)long_0;
		}

		public void SetStartingTimeBasedOnSomeValue(int int_5)
		{
			StartPlaying();
			stream1_0.Position = (long_0 = int_5);
			method_0();
		}

		private int method_1()
		{
			var playPosition = secondaryBuffer_0.PlayPosition;
			if (playPosition >= int_2)
			{
				return playPosition - int_2;
			}
			return playPosition + int_1 - int_2;
		}

		public AudioStatus GetStatus()
		{
			return enum1_0;
		}

		public SharpAudio.ASC.WaveFormat GetWaveFormat()
		{
			return stream1_0.vmethod_0();
		}

		public void SetVolume(float float_0)
		{
			secondaryBuffer_0.Volume = (int)(50f * Class15.smethod_0(float_0));
		}

		private void method_2(int int_5)
		{
			for (var i = 0; i < int_5; i++)
			{
				bufferPositionNotify_0[i].Offset = (i + 1) * int_0 - 1;
				bufferPositionNotify_0[i].EventNotifyHandle = autoResetEvent_0.Handle;
			}
			notify_0 = new Notify(secondaryBuffer_0);
			notify_0.SetNotificationPositions(bufferPositionNotify_0);
		}

		private void method_3(int int_5)
		{
			bufferPositionNotify_1[0].Offset = int_5;
			secondaryBuffer_0.Stop();
			notify_0.SetNotificationPositions(bufferPositionNotify_1);
			secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
		}

		private void method_4()
		{
			if (thread_0 != null)
			{
				throw new Exception("CreateDataTransferThread() saw thread non-null.");
			}
			bool_2 = false;
			int_3 = 0;
			int_4 = 0;
			thread_0 = new Thread(method_5);
			thread_0.Name = "DataTransferThread";
			thread_0.Priority = ThreadPriority.Highest;
			thread_0.Start();
		}

		private void method_5()
		{
			var num = 0;
			while (bool_1)
			{
				if (bool_2)
				{
					return;
				}
				autoResetEvent_0.WaitOne(-1, true);
				if (!method_6())
				{
					num = int_2 / int_0;
					bool_1 = method_7();
				}
			}
			Array.Clear(byte_0, 0, byte_0.Length);
			var flag = true;
			while (flag)
			{
				autoResetEvent_0.WaitOne(-1, true);
				flag = method_6();
			}
			var num2 = int_2 / int_0;
			method_8();
			var int_ = (int)(long_0 % int_1);
			method_3(int_);
			var flag2 = false;
			while (!flag2)
			{
				autoResetEvent_0.WaitOne(-1, true);
				var num3 = secondaryBuffer_0.PlayPosition / int_0;
				if (!(flag2 = (num3 == num | num3 == num2)))
				{
					int_3++;
				}
			}
			secondaryBuffer_0.Stop();
			enum1_0 = AudioStatus.ShouldStopAudio;
		}

		private bool method_6()
		{
			var num = int_2 / int_0;
			var num2 = secondaryBuffer_0.PlayPosition / int_0;
			if (num != num2)
			{
				return false;
			}
			int_3++;
			return true;
		}

		private bool method_7()
		{
			var num = stream1_0.Read(byte_0, 0, byte_0.Length);
			bool_1 = (num > 0);
			long_0 += num;
			method_8();
			int_4++;
			return num >= int_0;
		}

		private void method_8()
		{
			secondaryBuffer_0.Write(int_2, byte_0, LockFlag.None);
			int_2 += int_0;
			int_2 %= int_1;
		}

		private void method_9()
		{
			if (thread_0 == null)
			{
				return;
			}
			if (thread_0.IsAlive)
			{
				bool_2 = true;
				thread_0.Join();
			}
			thread_0 = null;
		}

		public void Dispose()
		{
			method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool_3)
		{
			StopPlaying();
			method_9();
			if (autoResetEvent_0 != null)
			{
				autoResetEvent_0.Close();
			}
			if (secondaryBuffer_0 != null)
			{
				secondaryBuffer_0.Dispose();
				secondaryBuffer_0 = null;
			}
			if (bool_0 && device_0 != null)
			{
				device_0.Dispose();
				device_0 = null;
			}
			if (bool_3)
			{
				stream1_0.Dispose();
			}
		}

		~OGGOutput()
		{
			method_10(false);
		}
	}
}
