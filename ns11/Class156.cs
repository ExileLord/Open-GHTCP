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
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.struct66_0.intptr_0 != IntPtr.Zero)
			{
				Class162.waveInUnprepareHeader(this.intptr_0, ref this.struct66_0, Marshal.SizeOf(this.struct66_0));
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

		public void method_0()
		{
			if (this.bool_0)
			{
				this.bool_0 = this.autoResetEvent_0.WaitOne();
				return;
			}
			Thread.Sleep(0);
		}
	}
}
