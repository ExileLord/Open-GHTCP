using System;
using System.Runtime.InteropServices;
using GHNamespace1;
using GHNamespace2;
using GHNamespaceM;

namespace GHNamespace4
{
    public class Class158 : IDisposable
    {
        private Struct66 _struct660;

        private readonly int _int0;

        private readonly Class17 _class170;

        private GCHandle _gchandle0;

        private IntPtr _intptr0;

        private GCHandle _gchandle1;

        private GCHandle _gchandle2;

        private readonly GenericAudioStream _stream10;

        private readonly object _object0;

        public Class158(IntPtr intptr1, int int1, GenericAudioStream stream11, object object1)
        {
            _int0 = int1;
            _class170 = new Class17(int1);
            _gchandle0 = GCHandle.Alloc(_class170.method_0(), GCHandleType.Pinned);
            _intptr0 = intptr1;
            _stream10 = stream11;
            _object0 = object1;
            _struct660 = default(Struct66);
            _gchandle1 = GCHandle.Alloc(_struct660);
            _struct660.Intptr0 = _gchandle0.AddrOfPinnedObject();
            _struct660.Int0 = int1;
            _struct660.Int2 = 1;
            _gchandle2 = GCHandle.Alloc(this);
            _struct660.Intptr1 = (IntPtr) _gchandle2;
            lock (object1)
            {
                Exception4.smethod_1(Class162.waveOutPrepareHeader(intptr1, ref _struct660, Marshal.SizeOf(_struct660)),
                    "waveOutPrepareHeader");
            }
        }

        ~Class158()
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
            if (_gchandle1.IsAllocated)
            {
                _gchandle1.Free();
            }
            if (_gchandle0.IsAllocated)
            {
                _gchandle0.Free();
            }
            if (_gchandle2.IsAllocated)
            {
                _gchandle2.Free();
            }
            if (_intptr0 != IntPtr.Zero)
            {
                lock (_object0)
                {
                    Class162.waveOutUnprepareHeader(_intptr0, ref _struct660, Marshal.SizeOf(_struct660));
                }
                _intptr0 = IntPtr.Zero;
            }
        }

        public bool method_1()
        {
            int num;
            lock (_stream10)
            {
                var arg390 = _stream10;
                var arg391 = _struct660.Intptr0;
                int int_;
                _class170.method_4(int_ = _class170.method_0().Length);
                num = arg390.vmethod_3(arg391, int_);
            }
            if (num == 0)
            {
                return false;
            }
            Array.Clear(_class170.method_0(), num, _class170.method_3() - num);
            method_4();
            return true;
        }

        public bool method_2()
        {
            return (_struct660.Enum150 & Enum15.Flag3) == Enum15.Flag3;
        }

        public Class17 method_3()
        {
            return _class170;
        }

        private void method_4()
        {
            Enum18 @enum;
            lock (_object0)
            {
                @enum = Class162.waveOutWrite(_intptr0, ref _struct660, Marshal.SizeOf(_struct660));
            }
            if (@enum != Enum18.Const0)
            {
                throw new Exception4(@enum, "waveOutWrite");
            }
            GC.KeepAlive(this);
        }
    }
}