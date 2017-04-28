using System;
using System.Runtime.InteropServices;
using System.Threading;
using GHNamespaceM;

namespace GHNamespace4
{
	public class Class165 : IDisposable
	{
		public Class165 Class1650;

		private readonly AutoResetEvent _autoResetEvent0 = new AutoResetEvent(false);

		private readonly IntPtr _intptr0;

		private Struct66 _struct660;

		private readonly byte[] _byte0;

		private GCHandle _gchandle0;

		private GCHandle _gchandle1;

		private bool _bool0;

		private readonly object _object0 = new object();

		public static void smethod_0(IntPtr intptr1, Class162.Enum16 enum160, int int0, ref Struct66 struct661, int int1)
		{
			if (enum160 == Class162.Enum16.Const1)
			{
				try
				{
					var @class = (Class165)((GCHandle)struct661.Intptr1).Target;
					@class.method_4();
				}
				catch
				{
				}
			}
		}

		public Class165(IntPtr intptr1, int int0)
		{
			_intptr0 = intptr1;
			_gchandle0 = GCHandle.Alloc(_struct660, GCHandleType.Pinned);
			_struct660.Intptr1 = (IntPtr)GCHandle.Alloc(this);
			_byte0 = new byte[int0];
			_gchandle1 = GCHandle.Alloc(_byte0, GCHandleType.Pinned);
			_struct660.Intptr0 = _gchandle1.AddrOfPinnedObject();
			_struct660.Int0 = int0;
			Exception4.smethod_1(Class162.waveOutPrepareHeader(_intptr0, ref _struct660, Marshal.SizeOf(_struct660)), "waveOutPrepareHeader");
		}

		~Class165()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (_struct660.Intptr0 != IntPtr.Zero)
			{
				Class162.waveOutUnprepareHeader(_intptr0, ref _struct660, Marshal.SizeOf(_struct660));
				_gchandle0.Free();
				_struct660.Intptr0 = IntPtr.Zero;
			}
			_autoResetEvent0.Close();
			if (_gchandle1.IsAllocated)
			{
				_gchandle1.Free();
			}
			GC.SuppressFinalize(this);
		}

		public int method_0()
		{
			return _struct660.Int0;
		}

		public IntPtr method_1()
		{
			return _struct660.Intptr0;
		}

		public bool method_2()
		{
			lock (_object0)
			{
				_autoResetEvent0.Reset();
				_bool0 = (Class162.waveOutWrite(_intptr0, ref _struct660, Marshal.SizeOf(_struct660)) == Enum18.Const0);
			}
			return _bool0;
		}

		public void method_3()
		{
			if (_bool0)
			{
				_bool0 = _autoResetEvent0.WaitOne();
				return;
			}
			Thread.Sleep(0);
		}

		public void method_4()
		{
			_autoResetEvent0.Set();
			_bool0 = false;
		}
	}
}
