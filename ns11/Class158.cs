using ns0;
using ns1;
using ns8;
using System;
using System.Runtime.InteropServices;

namespace ns11
{
	public class Class158 : IDisposable
	{
		private Struct66 struct66_0;

		private readonly int int_0;

		private readonly Class17 class17_0;

		private GCHandle gchandle_0;

		private IntPtr intptr_0;

		private GCHandle gchandle_1;

		private GCHandle gchandle_2;

		private readonly Stream1 stream1_0;

		private readonly object object_0;

		public Class158(IntPtr intptr_1, int int_1, Stream1 stream1_1, object object_1)
		{
			this.int_0 = int_1;
			this.class17_0 = new Class17(int_1);
			this.gchandle_0 = GCHandle.Alloc(this.class17_0.method_0(), GCHandleType.Pinned);
			this.intptr_0 = intptr_1;
			this.stream1_0 = stream1_1;
			this.object_0 = object_1;
			this.struct66_0 = default(Struct66);
			this.gchandle_1 = GCHandle.Alloc(this.struct66_0);
			this.struct66_0.intptr_0 = this.gchandle_0.AddrOfPinnedObject();
			this.struct66_0.int_0 = int_1;
			this.struct66_0.int_2 = 1;
			this.gchandle_2 = GCHandle.Alloc(this);
			this.struct66_0.intptr_1 = (IntPtr)this.gchandle_2;
			lock (object_1)
			{
				Exception4.smethod_1(Class162.waveOutPrepareHeader(intptr_1, ref this.struct66_0, Marshal.SizeOf(this.struct66_0)), "waveOutPrepareHeader");
			}
		}

		~Class158()
		{
			this.method_0(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			this.method_0(true);
		}

		public void method_0(bool bool_0)
		{
			if (this.gchandle_1.IsAllocated)
			{
				this.gchandle_1.Free();
			}
			if (this.gchandle_0.IsAllocated)
			{
				this.gchandle_0.Free();
			}
			if (this.gchandle_2.IsAllocated)
			{
				this.gchandle_2.Free();
			}
			if (this.intptr_0 != IntPtr.Zero)
			{
				lock (this.object_0)
				{
					Class162.waveOutUnprepareHeader(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0));
				}
				this.intptr_0 = IntPtr.Zero;
			}
		}

		public bool method_1()
		{
			int num;
			lock (this.stream1_0)
			{
				Stream1 arg_39_0 = this.stream1_0;
				IntPtr arg_39_1 = this.struct66_0.intptr_0;
				int int_;
				this.class17_0.method_4(int_ = this.class17_0.method_0().Length);
				num = arg_39_0.vmethod_3(arg_39_1, int_);
			}
			if (num == 0)
			{
				return false;
			}
			Array.Clear(this.class17_0.method_0(), num, this.class17_0.method_3() - num);
			this.method_4();
			return true;
		}

		public bool method_2()
		{
			return (this.struct66_0.enum15_0 & Enum15.flag_3) == Enum15.flag_3;
		}

		public Class17 method_3()
		{
			return this.class17_0;
		}

		private void method_4()
		{
			Enum18 @enum;
			lock (this.object_0)
			{
				@enum = Class162.waveOutWrite(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0));
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutWrite");
			}
			GC.KeepAlive(this);
		}
	}
}
