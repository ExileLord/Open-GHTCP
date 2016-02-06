using ns0;
using ns1;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns11
{
	public class Class155 : IDisposable, Interface6
	{
		private Class159 class159_0;

		private readonly Class16 class16_0;

		private Stream1 stream1_0;

		private readonly bool bool_0;

		private byte[] byte_0;

		private Enum1 enum1_0;

		private float float_0 = 1f;

		private int int_0;

		public Class155(Stream1 stream1_1) : this(stream1_1, false)
		{
		}

		public Class155(Stream1 stream1_1, bool bool_1)
		{
			if (stream1_1.Length <= 0L)
			{
				throw new Exception("WinMM2Player: Invalid Stream.");
			}
			this.class16_0 = stream1_1.vmethod_1();
			if (this.class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.PCM && this.class16_0.waveFormat_0.waveFormatTag_0 != WaveFormatTag.IEEEFloat)
			{
				throw new Exception("WinMM2Player: Only PCM is supported.");
			}
			this.stream1_0 = stream1_1;
			this.bool_0 = bool_1;
			this.imethod_2(0);
			this.enum1_0 = Enum1.const_0;
		}

		public TimeSpan imethod_0()
		{
			return TimeSpan.FromSeconds((double)this.vmethod_0() / (double)(this.class16_0.method_3() * (int)this.class16_0.method_1()));
		}

		public void imethod_1(TimeSpan timeSpan_0)
		{
			this.imethod_2(Convert.ToInt32((double)(this.class16_0.method_3() * (int)this.class16_0.method_1()) * timeSpan_0.TotalSeconds));
		}

		public int vmethod_0()
		{
			if (this.enum1_0 != Enum1.const_0)
			{
				return this.int_0 + this.class159_0.method_0();
			}
			return (int)this.stream1_0.Position;
		}

		public void imethod_2(int int_1)
		{
			Enum1 @enum = this.enum1_0;
			if (@enum != Enum1.const_0)
			{
				this.imethod_5();
			}
			Stream arg_21_0 = this.stream1_0;
			this.int_0 = int_1;
			arg_21_0.Position = (long)int_1;
			if (@enum == Enum1.const_1)
			{
				this.imethod_3();
			}
		}

		public float vmethod_1()
		{
			if (this.class159_0 == null)
			{
				return this.float_0;
			}
			return this.class159_0.method_1();
		}

		public void imethod_8(float float_1)
		{
			this.float_0 = float_1;
			if (this.class159_0 != null)
			{
				this.class159_0.method_2(this.float_0);
			}
		}

		public Enum1 imethod_6()
		{
			return this.enum1_0;
		}

		public WaveFormat imethod_7()
		{
			return this.class16_0.waveFormat_0;
		}

		public void imethod_3()
		{
			WaitCallback waitCallback = null;
			if (this.enum1_0 == Enum1.const_1)
			{
				return;
			}
			if (this.class159_0 != null && this.enum1_0 == Enum1.const_2 && !this.class159_0.method_5())
			{
				this.enum1_0 = Enum1.const_1;
				this.class159_0.method_2(0f);
				this.class159_0.method_3();
				if (waitCallback == null)
				{
					waitCallback = new WaitCallback(this.method_2);
				}
				ThreadPool.QueueUserWorkItem(waitCallback);
				return;
			}
			this.imethod_5();
			this.enum1_0 = Enum1.const_1;
			this.class159_0 = new Class159(-1, this.class16_0.waveFormat_0, 200, this.float_0, this.bool_0, new Delegate3(this.method_0));
		}

		public void imethod_4()
		{
			if (this.class159_0 != null)
			{
				if (this.enum1_0 == Enum1.const_1)
				{
					this.enum1_0 = Enum1.const_2;
					this.class159_0.method_4();
					return;
				}
			}
		}

		public void imethod_5()
		{
			if (this.class159_0 != null && this.enum1_0 != Enum1.const_0)
			{
				this.enum1_0 = Enum1.const_0;
				try
				{
					this.class159_0.Dispose();
				}
				finally
				{
					this.class159_0 = null;
				}
				return;
			}
		}

		private void method_0(Class159 class159_1, IntPtr intptr_0, int int_1, ref bool bool_1)
		{
			WaitCallback waitCallback = null;
			if (this.byte_0 == null || this.byte_0.Length < int_1)
			{
				this.byte_0 = new byte[int_1];
			}
			if (this.stream1_0 != null && class159_1 == this.class159_0)
			{
				lock (this.stream1_0)
				{
					int num = this.stream1_0.vmethod_3(intptr_0, int_1);
					if (num < int_1)
					{
						bool_1 = true;
						if (waitCallback == null)
						{
							waitCallback = new WaitCallback(this.method_3);
						}
						ThreadPool.QueueUserWorkItem(waitCallback);
					}
					return;
				}
			}
			Marshal.Copy(this.byte_0, 0, intptr_0, int_1);
		}

		public void method_1(bool bool_1)
		{
			this.imethod_5();
			if (bool_1 && this.stream1_0 != null)
			{
				try
				{
					this.stream1_0.Dispose();
				}
				finally
				{
					this.stream1_0 = null;
				}
			}
		}

		public void Dispose()
		{
			this.method_1(true);
			GC.SuppressFinalize(this);
		}

		~Class155()
		{
			this.method_1(false);
		}

		[CompilerGenerated]
		private void method_2(object object_0)
		{
			float num = this.vmethod_1();
			while (num < this.float_0)
			{
				if (this.enum1_0 != Enum1.const_1)
				{
					break;
				}
				this.class159_0.method_2(num);
				num += 0.1f;
				Thread.Sleep(50);
			}
			if (this.enum1_0 != Enum1.const_1)
			{
				return;
			}
			this.class159_0.method_2(this.float_0);
		}

		[CompilerGenerated]
		private void method_3(object object_0)
		{
			if (this.class159_0 != null)
			{
				while (!this.class159_0.method_5())
				{
				}
			}
			this.imethod_5();
			this.imethod_2(0);
		}
	}
}
