using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ns8;
using SharpAudio.ASC;

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
				var num = 0f;
				var num2 = Volume;
				while (num < num2)
				{
					audioPlayer.SetVolume(num);
					num += 0.1f;
					Thread.Sleep(50);
				}
				audioPlayer.SetVolume(num2);
			}
		}

		[CompilerGenerated]
		private class Class161
		{
			public IntPtr intptr_0;

			public AudioPlayer class159_0;

			public void method_0(object object_0)
			{
				GC.KeepAlive(class159_0.delegate4_0);
				var intPtr = intptr_0;
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

		private readonly bool bool_2;

		private readonly Class162.Delegate4 delegate4_0;

		private readonly object object_0;

		public AudioPlayer(int int_0, WaveFormat waveFormat_0, int int_1, float Volume, bool bool_3, Delegate3 delegate3_1)
		{
			WaitCallback waitCallback = null;
			var volumeListener = new VolumeListener();
			volumeListener.Volume = Volume;
            delegate4_0 = Class165.smethod_0;
			object_0 = new object();
			//base..ctor();
			volumeListener.audioPlayer = this;
			bool_2 = bool_3;
            byte_0 = (byte)((waveFormat_0.short_2 == 8) ? 128 : 0);
			delegate3_0 = delegate3_1;
			Exception4.smethod_1(Class162.waveOutOpen(out intptr_0, int_0, waveFormat_0, delegate4_0, 0, Class162.Enum17.const_3), "waveOutOpen");
			method_7(waveFormat_0.method_0(int_1 / 5), 5);
			thread_0 = new Thread(method_6);
			SetVolume(0f);
			thread_0.Start();
			if (waitCallback == null)
			{
				waitCallback = volumeListener.StartListener;
			}
			ThreadPool.QueueUserWorkItem(waitCallback);
		}

		public int method_0()
		{
			var @struct = default(Struct67);
			@struct.enum14_0 = Enum14.const_2;
			if (intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutGetPosition(intptr_0, ref @struct, Marshal.SizeOf(@struct));
			}
			return @struct.int_2;
		}

		public float method_1()
		{
			var num = 0;
			if (intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutGetVolume(intptr_0, ref num);
			}
			return ((num >> 16) / 65536f + (num & 65535) / 65536f) / 2f;
		}

		public void SetVolume(float float_0)
		{
			var int_ = (int)(float_0 * 65535f) + ((int)(float_0 * 65535f) << 16);
			if (intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutSetVolume(intptr_0, int_);
			}
		}

		public void method_3()
		{
			Class162.waveOutRestart(intptr_0);
		}

		public void method_4()
		{
			Class162.waveOutPause(intptr_0);
		}

		public bool method_5()
		{
			return !bool_2 && bool_1;
		}

		~AudioPlayer()
		{
			Dispose();
		}

		public void Dispose()
		{
			lock (object_0)
			{
				if (thread_0 != null)
				{
					try
					{
						bool_0 = true;
						if (intptr_0 != IntPtr.Zero)
						{
							Class162.waveOutReset(intptr_0);
						}
						thread_0.Join();
						delegate3_0 = null;
						method_8();
						if (intptr_0 != IntPtr.Zero)
						{
							var @class = new Class161();
							@class.class159_0 = this;
							@class.intptr_0 = intptr_0;
							ThreadPool.QueueUserWorkItem(@class.method_0);
						}
					}
					finally
					{
						thread_0 = null;
						intptr_0 = IntPtr.Zero;
					}
				}
			}
			GC.SuppressFinalize(this);
		}

		private void method_6()
		{
			while (!bool_0)
			{
				method_9();
				if (delegate3_0 != null && !bool_0)
				{
					delegate3_0(this, class165_1.method_1(), class165_1.method_0(), ref bool_0);
					if (bool_0 && bool_2)
					{
						bool_0 = false;
					}
				}
				else
				{
                    var array = new byte[class165_1.method_0()];
					if (byte_0 != 0)
					{
						for (var i = 0; i < array.Length; i++)
						{
							array[i] = byte_0;
						}
					}
					Marshal.Copy(array, 0, class165_1.method_1(), array.Length);
				}
				class165_1.method_2();
			}
			method_10();
			bool_1 = true;
		}

		private void method_7(int int_0, int int_1)
		{
			method_8();
			if (int_1 > 0)
			{
				class165_0 = new Class165(intptr_0, int_0);
				var @class = class165_0;
				try
				{
					for (var i = 1; i < int_1; i++)
					{
						var class2 = new Class165(intptr_0, int_0);
						@class.class165_0 = class2;
						@class = class2;
					}
				}
				finally
				{
					@class.class165_0 = class165_0;
				}
			}
		}

		private void method_8()
		{
			class165_1 = null;
			if (class165_0 != null)
			{
				var @class = class165_0;
				class165_0 = null;
				var class2 = @class;
				do
				{
					var class3 = class2.class165_0;
					class2.Dispose();
					class2 = class3;
				}
				while (class2 != @class);
			}
		}

		private void method_9()
		{
			class165_1 = ((class165_1 == null) ? class165_0 : class165_1.class165_0);
			class165_1.method_3();
		}

		private void method_10()
		{
			var @class = class165_0;
			while (@class.class165_0 != class165_0)
			{
				@class.method_3();
				@class = @class.class165_0;
			}
		}
	}
}
