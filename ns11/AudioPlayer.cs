using ns8;
using SharpAudio.ASC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns11
{
	public class AudioPlayer : IDisposable
	{
		[CompilerGenerated]
		private class VolumeListener
		{
			public AudioPlayer audioPlayer;

			public float Volume;

			public void StartListener(object object_0)
			{
				float num = 0f;
				float num2 = this.Volume;
				while (num < num2)
				{
					this.audioPlayer.SetVolume(num);
					num += 0.1f;
					Thread.Sleep(50);
				}
				this.audioPlayer.SetVolume(num2);
			}
		}

		[CompilerGenerated]
		private class Class161
		{
			public IntPtr intptr_0;

			public AudioPlayer class159_0;

			public void method_0(object object_0)
			{
				GC.KeepAlive(this.class159_0.delegate4_0);
				IntPtr intPtr = this.intptr_0;
				while (Class162.waveOutClose(intPtr) != Enum18.const_0)
				{
					Thread.Sleep(1000);
				}
			}
		}

		private IntPtr intptr_0;

		private Class165 class165_0;

		private Class165 class165_1;

		private Thread thread_0;

		private Delegate3 delegate3_0;

		private bool bool_0;

		private bool bool_1;

		private readonly byte byte_0;

		private bool bool_2;

		private readonly Class162.Delegate4 delegate4_0;

		private readonly object object_0;

		public AudioPlayer(int int_0, WaveFormat waveFormat_0, int int_1, float Volume, bool bool_3, Delegate3 delegate3_1) : base()
		{
			WaitCallback waitCallback = null;
			AudioPlayer.VolumeListener volumeListener = new AudioPlayer.VolumeListener();
			volumeListener.Volume = Volume;
            this.delegate4_0 = new Class162.Delegate4(Class165.smethod_0);
			this.object_0 = new object();
			//base..ctor();
			volumeListener.audioPlayer = this;
			this.bool_2 = bool_3;
            this.byte_0 = (byte)((waveFormat_0.short_2 == 8) ? 128 : 0);
			this.delegate3_0 = delegate3_1;
			Exception4.smethod_1(Class162.waveOutOpen(out this.intptr_0, int_0, waveFormat_0, this.delegate4_0, 0, Class162.Enum17.const_3), "waveOutOpen");
			this.method_7(waveFormat_0.method_0(int_1 / 5), 5);
			this.thread_0 = new Thread(new ThreadStart(this.method_6));
			this.SetVolume(0f);
			this.thread_0.Start();
			if (waitCallback == null)
			{
				waitCallback = new WaitCallback(volumeListener.StartListener);
			}
			ThreadPool.QueueUserWorkItem(waitCallback);
		}

		public int method_0()
		{
			Struct67 @struct = default(Struct67);
			@struct.enum14_0 = Enum14.const_2;
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutGetPosition(this.intptr_0, ref @struct, Marshal.SizeOf(@struct));
			}
			return @struct.int_2;
		}

		public float method_1()
		{
			int num = 0;
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutGetVolume(this.intptr_0, ref num);
			}
			return ((float)(num >> 16) / 65536f + (float)(num & 65535) / 65536f) / 2f;
		}

		public void SetVolume(float float_0)
		{
			int int_ = (int)(float_0 * 65535f) + ((int)(float_0 * 65535f) << 16);
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutSetVolume(this.intptr_0, int_);
			}
		}

		public void method_3()
		{
			Class162.waveOutRestart(this.intptr_0);
		}

		public void method_4()
		{
			Class162.waveOutPause(this.intptr_0);
		}

		public bool method_5()
		{
			return !this.bool_2 && this.bool_1;
		}

		~AudioPlayer()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			lock (this.object_0)
			{
				if (this.thread_0 != null)
				{
					try
					{
						this.bool_0 = true;
						if (this.intptr_0 != IntPtr.Zero)
						{
							Class162.waveOutReset(this.intptr_0);
						}
						this.thread_0.Join();
						this.delegate3_0 = null;
						this.method_8();
						if (this.intptr_0 != IntPtr.Zero)
						{
							AudioPlayer.Class161 @class = new AudioPlayer.Class161();
							@class.class159_0 = this;
							@class.intptr_0 = this.intptr_0;
							ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
						}
					}
					finally
					{
						this.thread_0 = null;
						this.intptr_0 = IntPtr.Zero;
					}
				}
			}
			GC.SuppressFinalize(this);
		}

		private void method_6()
		{
			while (!this.bool_0)
			{
				this.method_9();
				if (this.delegate3_0 != null && !this.bool_0)
				{
					this.delegate3_0(this, this.class165_1.method_1(), this.class165_1.method_0(), ref this.bool_0);
					if (this.bool_0 && this.bool_2)
					{
						this.bool_0 = false;
					}
				}
				else
				{
                    byte[] array = new byte[this.class165_1.method_0()];
					if (this.byte_0 != 0)
					{
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = this.byte_0;
						}
					}
					Marshal.Copy(array, 0, this.class165_1.method_1(), array.Length);
				}
				this.class165_1.method_2();
			}
			this.method_10();
			this.bool_1 = true;
		}

		private void method_7(int int_0, int int_1)
		{
			this.method_8();
			if (int_1 > 0)
			{
				this.class165_0 = new Class165(this.intptr_0, int_0);
				Class165 @class = this.class165_0;
				try
				{
					for (int i = 1; i < int_1; i++)
					{
						Class165 class2 = new Class165(this.intptr_0, int_0);
						@class.class165_0 = class2;
						@class = class2;
					}
				}
				finally
				{
					@class.class165_0 = this.class165_0;
				}
			}
		}

		private void method_8()
		{
			this.class165_1 = null;
			if (this.class165_0 != null)
			{
				Class165 @class = this.class165_0;
				this.class165_0 = null;
				Class165 class2 = @class;
				do
				{
					Class165 class3 = class2.class165_0;
					class2.Dispose();
					class2 = class3;
				}
				while (class2 != @class);
			}
		}

		private void method_9()
		{
			this.class165_1 = ((this.class165_1 == null) ? this.class165_0 : this.class165_1.class165_0);
			this.class165_1.method_3();
		}

		private void method_10()
		{
			Class165 @class = this.class165_0;
			while (@class.class165_0 != this.class165_0)
			{
				@class.method_3();
				@class = @class.class165_0;
			}
		}
	}
}
