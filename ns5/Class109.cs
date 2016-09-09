using Microsoft.DirectX.DirectSound;
using ns0;
using ns1;
using SharpAudio.ASC;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns5
{
	public class Class109 : Interface6
	{
		private Enum1 enum1_0;

		private GenericAudioStream stream1_0;

		private int int_0;

		private int int_1;

		private Device device_0;

		private bool bool_0;

		private SecondaryBuffer secondaryBuffer_0;

		private int int_2;

		private bool bool_1;

		private readonly double double_0;

		private long long_0;

		private BufferPositionNotify[] bufferPositionNotify_0 = new BufferPositionNotify[5];

		private AutoResetEvent autoResetEvent_0;

		private BufferPositionNotify[] bufferPositionNotify_1 = new BufferPositionNotify[1];

		private Notify notify_0;

		private Thread thread_0;

		private bool bool_2;

		private int int_3;

		private int int_4;

		private byte[] byte_0;

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		public Class109(GenericAudioStream stream1_1) : this(stream1_1, null, 500)
		{
		}

		public Class109(GenericAudioStream stream1_1, Device device_1, int int_5)
		{
			this.stream1_0 = new Stream4(stream1_1, 16);
			this.int_1 = this.stream1_0.vmethod_0().method_0(int_5);
			this.int_1 -= this.int_1 % 5;
			this.int_0 = this.int_1 / 5;
			this.double_0 = (double)this.stream1_0.vmethod_0().int_0 * (double)this.stream1_0.vmethod_0().short_1 / 1000.0;
			this.byte_0 = new byte[this.int_0];
			this.device_0 = device_1;
			if (this.device_0 == null)
			{
				this.device_0 = new Device();
				this.device_0.SetCooperativeLevel(Class109.GetDesktopWindow(), CooperativeLevel.Normal);
				this.bool_0 = true;
			}
			this.secondaryBuffer_0 = new SecondaryBuffer(new BufferDescription
			{
				BufferBytes = this.int_1,
				ControlPositionNotify = true,
				CanGetCurrentPosition = true,
				ControlVolume = true,
				GlobalFocus = true,
				StickyFocus = true,
				Format = Class109.smethod_0(this.stream1_0.vmethod_0())
			}, this.device_0);
			this.secondaryBuffer_0.SetCurrentPosition(0);
			this.int_2 = 0;
			this.secondaryBuffer_0.Volume = 0;
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.bufferPositionNotify_1[0].EventNotifyHandle = this.autoResetEvent_0.Handle;
			this.enum1_0 = Enum1.const_0;
		}

		private static Microsoft.DirectX.DirectSound.WaveFormat smethod_0(SharpAudio.ASC.WaveFormat waveFormat_0)
		{
			return new Microsoft.DirectX.DirectSound.WaveFormat
			{
				AverageBytesPerSecond = waveFormat_0.int_1,
				BitsPerSample = waveFormat_0.short_2,
				BlockAlign = waveFormat_0.short_1,
				Channels = waveFormat_0.short_0,
				FormatTag = (Microsoft.DirectX.DirectSound.WaveFormatTag)waveFormat_0.waveFormatTag_0,
				SamplesPerSecond = waveFormat_0.int_0
			};
		}

		public void imethod_3()
		{
			if (this.enum1_0 == Enum1.const_2)
			{
				this.method_0();
				return;
			}
			if (this.enum1_0 == Enum1.const_0)
			{
				this.method_9();
				this.method_2(5);
				this.long_0 = 0L;
				this.int_2 = 0;
				this.secondaryBuffer_0.SetCurrentPosition(0);
				this.method_4();
				for (int i = 0; i < 5; i++)
				{
					this.method_7();
				}
				this.secondaryBuffer_0.SetCurrentPosition(0);
				this.secondaryBuffer_0.Volume = 0;
				this.secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
				this.enum1_0 = Enum1.const_1;
			}
		}

		public void imethod_4()
		{
			if (this.enum1_0 == Enum1.const_1)
			{
				this.secondaryBuffer_0.Stop();
				this.enum1_0 = Enum1.const_2;
			}
		}

		private void method_0()
		{
			if (this.enum1_0 == Enum1.const_2)
			{
				this.secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
				this.enum1_0 = Enum1.const_1;
			}
		}

		public void imethod_5()
		{
			this.secondaryBuffer_0.Volume = -10000;
			this.method_0();
			this.method_9();
			this.secondaryBuffer_0.Stop();
			this.enum1_0 = Enum1.const_0;
		}

		public TimeSpan imethod_0()
		{
			return TimeSpan.FromMilliseconds((double)this.vmethod_0() / this.double_0);
		}

		public void imethod_1(TimeSpan timeSpan_0)
		{
			this.imethod_2(Convert.ToInt32(this.double_0 * timeSpan_0.TotalMilliseconds));
		}

		public int vmethod_0()
		{
			if (this.enum1_0 != Enum1.const_0)
			{
				return (int)(this.long_0 - (long)this.int_1 + (long)this.method_1());
			}
			return (int)this.long_0;
		}

		public void imethod_2(int int_5)
		{
			this.imethod_4();
			this.stream1_0.Position = (this.long_0 = (long)int_5);
			this.method_0();
		}

		private int method_1()
		{
			int playPosition = this.secondaryBuffer_0.PlayPosition;
			if (playPosition >= this.int_2)
			{
				return playPosition - this.int_2;
			}
			return playPosition + this.int_1 - this.int_2;
		}

		public Enum1 imethod_6()
		{
			return this.enum1_0;
		}

		public SharpAudio.ASC.WaveFormat imethod_7()
		{
			return this.stream1_0.vmethod_0();
		}

		public void imethod_8(float float_0)
		{
			this.secondaryBuffer_0.Volume = (int)(50f * Class15.smethod_0(float_0));
		}

		private void method_2(int int_5)
		{
			for (int i = 0; i < int_5; i++)
			{
				this.bufferPositionNotify_0[i].Offset = (i + 1) * this.int_0 - 1;
				this.bufferPositionNotify_0[i].EventNotifyHandle = this.autoResetEvent_0.Handle;
			}
			this.notify_0 = new Notify(this.secondaryBuffer_0);
			this.notify_0.SetNotificationPositions(this.bufferPositionNotify_0);
		}

		private void method_3(int int_5)
		{
			this.bufferPositionNotify_1[0].Offset = int_5;
			this.secondaryBuffer_0.Stop();
			this.notify_0.SetNotificationPositions(this.bufferPositionNotify_1);
			this.secondaryBuffer_0.Play(0, BufferPlayFlags.Looping);
		}

		private void method_4()
		{
			if (this.thread_0 != null)
			{
				throw new Exception("CreateDataTransferThread() saw thread non-null.");
			}
			this.bool_2 = false;
			this.int_3 = 0;
			this.int_4 = 0;
			this.thread_0 = new Thread(new ThreadStart(this.method_5));
			this.thread_0.Name = "DataTransferThread";
			this.thread_0.Priority = ThreadPriority.Highest;
			this.thread_0.Start();
		}

		private void method_5()
		{
			int num = 0;
			while (this.bool_1)
			{
				if (this.bool_2)
				{
					return;
				}
				this.autoResetEvent_0.WaitOne(-1, true);
				if (!this.method_6())
				{
					num = this.int_2 / this.int_0;
					this.bool_1 = this.method_7();
				}
			}
			Array.Clear(this.byte_0, 0, this.byte_0.Length);
			bool flag = true;
			while (flag)
			{
				this.autoResetEvent_0.WaitOne(-1, true);
				flag = this.method_6();
			}
			int num2 = this.int_2 / this.int_0;
			this.method_8();
			int int_ = (int)(this.long_0 % (long)this.int_1);
			this.method_3(int_);
			bool flag2 = false;
			while (!flag2)
			{
				this.autoResetEvent_0.WaitOne(-1, true);
				int num3 = this.secondaryBuffer_0.PlayPosition / this.int_0;
				if (!(flag2 = (num3 == num | num3 == num2)))
				{
					this.int_3++;
				}
			}
			this.secondaryBuffer_0.Stop();
			this.enum1_0 = Enum1.const_0;
		}

		private bool method_6()
		{
			int num = this.int_2 / this.int_0;
			int num2 = this.secondaryBuffer_0.PlayPosition / this.int_0;
			if (num != num2)
			{
				return false;
			}
			this.int_3++;
			return true;
		}

		private bool method_7()
		{
			int num = this.stream1_0.Read(this.byte_0, 0, this.byte_0.Length);
			this.bool_1 = (num > 0);
			this.long_0 += (long)num;
			this.method_8();
			this.int_4++;
			return num >= this.int_0;
		}

		private void method_8()
		{
			this.secondaryBuffer_0.Write(this.int_2, this.byte_0, LockFlag.None);
			this.int_2 += this.int_0;
			this.int_2 %= this.int_1;
		}

		private void method_9()
		{
			if (this.thread_0 == null)
			{
				return;
			}
			if (this.thread_0.IsAlive)
			{
				this.bool_2 = true;
				this.thread_0.Join();
			}
			this.thread_0 = null;
		}

		public void Dispose()
		{
			this.method_10(true);
			GC.SuppressFinalize(this);
		}

		public void method_10(bool bool_3)
		{
			this.imethod_5();
			this.method_9();
			if (this.autoResetEvent_0 != null)
			{
				this.autoResetEvent_0.Close();
			}
			if (this.secondaryBuffer_0 != null)
			{
				this.secondaryBuffer_0.Dispose();
				this.secondaryBuffer_0 = null;
			}
			if (this.bool_0 && this.device_0 != null)
			{
				this.device_0.Dispose();
				this.device_0 = null;
			}
			if (bool_3)
			{
				this.stream1_0.Dispose();
			}
		}

		~Class109()
		{
			this.method_10(false);
		}
	}
}
