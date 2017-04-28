using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace GHNamespace4
{
    public class Class156 : IDisposable
    {
        public Class156 Class1560;

        private readonly AutoResetEvent _autoResetEvent0;

        private readonly IntPtr _intptr0;

        private Struct66 _struct660;

        private GCHandle _gchandle0;

        private GCHandle _gchandle1;

        private bool _bool0;

        ~Class156()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_struct660.Intptr0 != IntPtr.Zero)
            {
                Class162.waveInUnprepareHeader(_intptr0, ref _struct660, Marshal.SizeOf(_struct660));
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

        public void method_0()
        {
            if (_bool0)
            {
                _bool0 = _autoResetEvent0.WaitOne();
                return;
            }
            Thread.Sleep(0);
        }
    }
}