using System;
using System.Runtime.InteropServices;
using System.Threading;
using ns8;

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
					var @class = (Class165)((GCHandle)struct66_1.intptr_1).Target;
					@class.method_4();
				}
				catch
				{
				}
			}
		}

		public Class165(IntPtr intptr_1, int int_0)
		{
			intptr_0 = intptr_1;
			gchandle_0 = GCHandle.Alloc(struct66_0, GCHandleType.Pinned);
			struct66_0.intptr_1 = (IntPtr)GCHandle.Alloc(this);
			byte_0 = new byte[int_0];
			gchandle_1 = GCHandle.Alloc(byte_0, GCHandleType.Pinned);
			struct66_0.intptr_0 = gchandle_1.AddrOfPinnedObject();
			struct66_0.int_0 = int_0;
			Exception4.smethod_1(Class162.waveOutPrepareHeader(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0)), "waveOutPrepareHeader");
		}

		~Class165()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (struct66_0.intptr_0 != IntPtr.Zero)
			{
				Class162.waveOutUnprepareHeader(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0));
				gchandle_0.Free();
				struct66_0.intptr_0 = IntPtr.Zero;
			}
			autoResetEvent_0.Close();
			if (gchandle_1.IsAllocated)
			{
				gchandle_1.Free();
			}
			GC.SuppressFinalize(this);
		}

		public int method_0()
		{
			return struct66_0.int_0;
		}

		public IntPtr method_1()
		{
			return struct66_0.intptr_0;
		}

		public bool method_2()
		{
			lock (object_0)
			{
				autoResetEvent_0.Reset();
				bool_0 = (Class162.waveOutWrite(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0)) == Enum18.const_0);
			}
			return bool_0;
		}

		public void method_3()
		{
			if (bool_0)
			{
				bool_0 = autoResetEvent_0.WaitOne();
				return;
			}
			Thread.Sleep(0);
		}

		public void method_4()
		{
			autoResetEvent_0.Set();
			bool_0 = false;
		}
	}
}
