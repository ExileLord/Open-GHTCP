using System;
using System.Runtime.InteropServices;

namespace ns1
{
	public class Class19 : IDisposable
	{
		private readonly Class17 class17_0;

		private readonly GCHandle gchandle_0;

		private readonly IntPtr intptr_0;

		public Class19(int int_0)
		{
			class17_0 = new Class17(int_0);
			class17_0.method_4(int_0);
			gchandle_0 = GCHandle.Alloc(class17_0.method_0(), GCHandleType.Pinned);
			intptr_0 = gchandle_0.AddrOfPinnedObject();
		}

		~Class19()
		{
			method_0(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			method_0(true);
		}

		public void method_0(bool bool_0)
		{
			if (gchandle_0.IsAllocated)
			{
				gchandle_0.Free();
			}
		}

		public static short[] smethod_0(Class19 class19_0)
		{
			return Class17.smethod_0(class19_0.class17_0);
		}

		public static IntPtr smethod_1(Class19 class19_0)
		{
			return class19_0.intptr_0;
		}
	}
}
