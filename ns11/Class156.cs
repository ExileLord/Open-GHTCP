using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ns11
{
	public class Class156 : IDisposable
	{
		public Class156 class156_0;

		private readonly AutoResetEvent autoResetEvent_0;

		private readonly IntPtr intptr_0;

		private Struct66 struct66_0;

		private GCHandle gchandle_0;

		private GCHandle gchandle_1;

		private bool bool_0;

		~Class156()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (struct66_0.intptr_0 != IntPtr.Zero)
			{
				Class162.waveInUnprepareHeader(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0));
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

		public void method_0()
		{
			if (bool_0)
			{
				bool_0 = autoResetEvent_0.WaitOne();
				return;
			}
			Thread.Sleep(0);
		}
	}
}
