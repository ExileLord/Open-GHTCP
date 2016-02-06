using ns8;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns11
{
	public class Class165 : IDisposable
	{
		public Class165 class165_0;

		private readonly AutoResetEvent autoResetEvent_0 = new AutoResetEvent(false);

		private readonly IntPtr intptr_0;

		private Struct66 struct66_0;

		private readonly byte[] byte_0;

		private GCHandle gchandle_0;

		private GCHandle gchandle_1;

		private bool bool_0;

		private readonly object object_0 = new object();

		public static void smethod_0(IntPtr intptr_1, Class162.Enum16 enum16_0, int int_0, ref Struct66 struct66_1, int int_1)
		{
			if (enum16_0 == Class162.Enum16.const_1)
			{
				try
				{
					Class165 @class = (Class165)((GCHandle)struct66_1.intptr_1).Target;
					@class.method_4();
				}
				catch
				{
				}
			}
		}

		public Class165(IntPtr intptr_1, int int_0)
		{
			this.intptr_0 = intptr_1;
			this.gchandle_0 = GCHandle.Alloc(this.struct66_0, GCHandleType.Pinned);
			this.struct66_0.intptr_1 = (IntPtr)GCHandle.Alloc(this);
			this.byte_0 = new byte[int_0];
			this.gchandle_1 = GCHandle.Alloc(this.byte_0, GCHandleType.Pinned);
			this.struct66_0.intptr_0 = this.gchandle_1.AddrOfPinnedObject();
			this.struct66_0.int_0 = int_0;
			Exception4.smethod_1(Class162.waveOutPrepareHeader(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0)), "waveOutPrepareHeader");
		}

		~Class165()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.struct66_0.intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutUnprepareHeader(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0));
				this.gchandle_0.Free();
				this.struct66_0.intptr_0 = IntPtr.Zero;
			}
			this.autoResetEvent_0.Close();
			if (this.gchandle_1.IsAllocated)
			{
				this.gchandle_1.Free();
			}
			GC.SuppressFinalize(this);
		}

		public int method_0()
		{
			return this.struct66_0.int_0;
		}

		public IntPtr method_1()
		{
			return this.struct66_0.intptr_0;
		}

		public bool method_2()
		{
			lock (this.object_0)
			{
				this.autoResetEvent_0.Reset();
				this.bool_0 = (Class162.waveOutWrite(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0)) == Enum18.const_0);
			}
			return this.bool_0;
		}

		public void method_3()
		{
			if (this.bool_0)
			{
				this.bool_0 = this.autoResetEvent_0.WaitOne();
				return;
			}
			Thread.Sleep(0);
		}

		public void method_4()
		{
			this.autoResetEvent_0.Set();
			this.bool_0 = false;
		}
	}
}
