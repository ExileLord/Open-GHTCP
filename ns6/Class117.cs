using ns0;
using ns1;
using SharpAudio.ASC;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns6
{
	public class Class117 : IDisposable, Interface6
	{
		private readonly Stream1 stream1_0;

		private readonly Class120 class120_0;

		private readonly IntPtr intptr_0;

		private readonly Enum12 enum12_0;

		private readonly int int_0;

		private readonly double double_0;

		private readonly int int_1;

		private readonly int int_2;

		private readonly IntPtr intptr_1;

		private readonly IntPtr[] intptr_2;

		private Enum1 enum1_0;

		private bool bool_0;

		private float float_0 = 1f;

		private int int_3;

		private bool bool_1;

		private readonly Stopwatch stopwatch_0 = new Stopwatch();

		private Thread thread_0;

		public Class117(Stream1 stream1_1)
		{
			this.stream1_0 = stream1_1;
			this.class120_0 = (Class120.smethod_2() ?? new Class120());
			this.enum12_0 = Class119.smethod_10(stream1_1.vmethod_0());
			this.int_0 = stream1_1.vmethod_0().int_0;
			this.double_0 = (double)stream1_1.vmethod_0().int_0 * (double)stream1_1.vmethod_0().short_1 / 1000.0;
			this.int_1 = stream1_1.vmethod_0().method_0(80);
			this.int_2 = 5;
			this.intptr_0 = Marshal.AllocHGlobal(this.int_1);
			this.intptr_1 = Class119.smethod_2();
			this.intptr_2 = Class119.smethod_8(this.int_2);
			this.enum1_0 = Enum1.const_0;
		}

		public void method_0()
		{
			if (this.thread_0 != null)
			{
				this.thread_0.Abort();
			}
			this.thread_0 = new Thread(new ThreadStart(this.method_1));
			this.thread_0.Start();
		}

		private void method_1()
		{
			bool flag = false;
			while (this.enum1_0 != Enum1.const_0 && !flag)
			{
				if (this.bool_0)
				{
					this.bool_0 = false;
					Class119.alSourcef(this.intptr_1, Enum10.const_4, this.float_0);
				}
				if (this.enum1_0 != Enum1.const_2)
				{
					int num = 0;
					int num2;
					do
					{
						Class119.alGetSourcei(this.intptr_1, Enum11.const_6, out num2);
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
						IntPtr intPtr = Class119.smethod_6(this.intptr_1);
						int num3;
						lock (this.stream1_0)
						{
							num3 = this.stream1_0.vmethod_3(this.intptr_0, this.int_1);
						}
						if (num3 < this.int_1)
						{
							flag = true;
						}
						Class119.alBufferData(intPtr, this.enum12_0, this.intptr_0, num3, this.int_0);
						Class119.smethod_5(this.intptr_1, ref intPtr);
						this.int_3 += this.int_1;
						this.stopwatch_0.Reset();
						this.stopwatch_0.Start();
					}
					int num4;
					Class119.alGetSourcei(this.intptr_1, Enum11.const_5, out num4);
					if (num4 <= 0)
					{
						break;
					}
					if (Class119.smethod_4(this.intptr_1, Enum11.const_4) != 4114)
					{
						Class119.alSourcePlay(this.intptr_1);
					}
				}
			}
			if (!flag)
			{
				return;
			}
			while (Class119.smethod_4(this.intptr_1, Enum11.const_6) != this.int_2)
			{
			}
			Stream arg_188_0 = this.stream1_0;
			this.int_3 = 0;
			arg_188_0.Position = 0L;
			this.enum1_0 = Enum1.const_0;
			Class119.alSourceStop(this.intptr_1);
			this.stopwatch_0.Reset();
			Class119.smethod_7(this.intptr_1, this.intptr_2.Length);
		}

		public TimeSpan imethod_0()
		{
			return TimeSpan.FromMilliseconds((double)this.int_3 / this.double_0 + (double)this.stopwatch_0.ElapsedMilliseconds);
		}

		public void imethod_1(TimeSpan timeSpan_0)
		{
			this.imethod_2(Convert.ToInt32(this.double_0 * timeSpan_0.TotalMilliseconds));
		}

		public void imethod_2(int int_4)
		{
			Enum1 @enum = this.enum1_0;
			if (@enum != Enum1.const_0)
			{
				this.imethod_5();
			}
			Stream arg_21_0 = this.stream1_0;
			this.int_3 = int_4;
			arg_21_0.Position = (long)int_4;
			this.stopwatch_0.Reset();
			if (@enum == Enum1.const_1)
			{
				this.imethod_3();
			}
			GC.Collect();
		}

		public WaveFormat imethod_7()
		{
			return this.stream1_0.vmethod_0();
		}

		public void imethod_8(float float_1)
		{
			this.bool_0 = true;
			this.float_0 = float_1;
		}

		public Enum1 imethod_6()
		{
			return this.enum1_0;
		}

		public void imethod_3()
		{
			switch (this.enum1_0)
			{
			case Enum1.const_1:
				return;
			case Enum1.const_2:
				Class119.alSourcePlay(this.intptr_1);
				this.stopwatch_0.Start();
				this.enum1_0 = Enum1.const_1;
				return;
			default:
			{
				while (Class119.smethod_4(this.intptr_1, Enum11.const_5) > 0)
				{
					Class119.smethod_6(this.intptr_1);
				}
				IntPtr[] array = this.intptr_2;
				for (int i = 0; i < array.Length; i++)
				{
					IntPtr intPtr = array[i];
					int num;
					lock (this.stream1_0)
					{
						num = this.stream1_0.vmethod_3(this.intptr_0, this.int_1);
					}
					Class119.alBufferData(intPtr, this.enum12_0, this.intptr_0, num, this.int_0);
				}
				Class119.alSourceQueueBuffers(this.intptr_1, this.intptr_2.Length, this.intptr_2);
				if (!this.bool_1)
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.method_3));
				}
				Class119.alSourcef(this.intptr_1, Enum10.const_4, 0f);
				Class119.alSourcePlay(this.intptr_1);
				this.stopwatch_0.Start();
				this.enum1_0 = Enum1.const_1;
				this.method_0();
				return;
			}
			}
		}

		public void imethod_4()
		{
			Class119.alSourcePause(this.intptr_1);
			this.stopwatch_0.Stop();
			this.enum1_0 = Enum1.const_2;
		}

		public void imethod_5()
		{
			this.thread_0.Abort();
			this.enum1_0 = Enum1.const_0;
			Class119.alSourceStop(this.intptr_1);
			this.stopwatch_0.Reset();
			Class119.smethod_7(this.intptr_1, this.intptr_2.Length);
		}

		public void Dispose()
		{
			this.method_2(true);
			GC.SuppressFinalize(this);
		}

		public void method_2(bool bool_2)
		{
			if (bool_2)
			{
				this.stream1_0.Dispose();
			}
			if (this.thread_0 != null)
			{
				this.thread_0.Abort();
			}
			try
			{
				Marshal.FreeHGlobal(this.intptr_0);
			}
			catch
			{
			}
			Class119.alSourceStop(this.intptr_1);
			Class119.smethod_3(this.intptr_1);
			Class119.smethod_9(this.intptr_2);
			this.class120_0.Dispose();
		}

		~Class117()
		{
			this.method_2(false);
		}

		[CompilerGenerated]
		private void method_3(object object_0)
		{
			this.bool_1 = true;
			float num = 0f;
			float num2 = this.float_0;
			while (num < num2)
			{
				this.imethod_8(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			this.imethod_8(num2);
			this.bool_1 = false;
		}
	}
}
