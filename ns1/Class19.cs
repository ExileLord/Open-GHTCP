using System;
using System.Runtime.InteropServices;

namespace ns1
{
	public class Class19 : IDisposable
	{
		private readonly Class17 _class170;

		private readonly GCHandle _gchandle0;

		private readonly IntPtr _intptr0;

		public Class19(int int0)
		{
			_class170 = new Class17(int0);
			_class170.method_4(int0);
			_gchandle0 = GCHandle.Alloc(_class170.method_0(), GCHandleType.Pinned);
			_intptr0 = _gchandle0.AddrOfPinnedObject();
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

		public void method_0(bool bool0)
		{
			if (_gchandle0.IsAllocated)
			{
				_gchandle0.Free();
			}
		}

		public static short[] smethod_0(Class19 class190)
		{
			return Class17.smethod_0(class190._class170);
		}

		public static IntPtr smethod_1(Class19 class190)
		{
			return class190._intptr0;
		}
	}
}
