using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using GHNamespaceM;
using SharpAudio.ASC;

namespace GHNamespace4
{
    public class AudioPlayer : IDisposable
    {
        [CompilerGenerated]
        private class VolumeListener
        {
            public AudioPlayer AudioPlayer;

            public float Volume;

            public void StartListener(object object0)
            {
                float num = 0f;
                float num2 = Volume;
                while (num < num2)
                {
                    AudioPlayer.SetVolume(num);
                    num += 0.1f;
                    Thread.Sleep(50);
                }
                AudioPlayer.SetVolume(num2);
            }
        }

        [CompilerGenerated]
        private class Class161
        {
            public IntPtr Intptr0;

            public AudioPlayer Class1590;

            public void method_0(object object0)
            {
                GC.KeepAlive(Class1590._delegate40);
                IntPtr intPtr = Intptr0;
                while (Class162.waveOutClose(intPtr) != Enum18.Const0)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private IntPtr _intptr0;

        private Class165 _class1650;

        private Class165 _class1651;

        private Thread _thread0;

        private Delegate3 _delegate30;

        private bool _bool0;

        private bool _bool1;

        private readonly byte _byte0;

        private readonly bool _bool2;

        private readonly Class162.Delegate4 _delegate40;

        private readonly object _object0;

        public AudioPlayer(int int0, WaveFormat waveFormat0, int int1, float volume, bool bool3, Delegate3 delegate31)
        {
            WaitCallback waitCallback = null;
            VolumeListener volumeListener = new VolumeListener
            {
                Volume = volume
            };
            _delegate40 = Class165.smethod_0;
            _object0 = new object();
            //base..ctor();
            volumeListener.AudioPlayer = this;
            _bool2 = bool3;
            _byte0 = (byte) ((waveFormat0.short_2 == 8) ? 128 : 0);
            _delegate30 = delegate31;
            Exception4.smethod_1(
                Class162.waveOutOpen(out _intptr0, int0, waveFormat0, _delegate40, 0, Class162.Enum17.Const3),
                "waveOutOpen");
            method_7(waveFormat0.method_0(int1 / 5), 5);
            _thread0 = new Thread(method_6);
            SetVolume(0f);
            _thread0.Start();
            if (waitCallback == null)
            {
                waitCallback = volumeListener.StartListener;
            }
            ThreadPool.QueueUserWorkItem(waitCallback);
        }

        public int method_0()
        {
            Struct67 @struct = default(Struct67);
            @struct.enum14_0 = Enum14.Const2;
            if (_intptr0 != IntPtr.Zero)
            {
                Class162.waveOutGetPosition(_intptr0, ref @struct, Marshal.SizeOf(@struct));
            }
            return @struct.int_2;
        }

        public float method_1()
        {
            int num = 0;
            if (_intptr0 != IntPtr.Zero)
            {
                Class162.waveOutGetVolume(_intptr0, ref num);
            }
            return ((num >> 16) / 65536f + (num & 65535) / 65536f) / 2f;
        }

        public void SetVolume(float float0)
        {
            int int_ = (int) (float0 * 65535f) + ((int) (float0 * 65535f) << 16);
            if (_intptr0 != IntPtr.Zero)
            {
                Class162.waveOutSetVolume(_intptr0, int_);
            }
        }

        public void method_3()
        {
            Class162.waveOutRestart(_intptr0);
        }

        public void method_4()
        {
            Class162.waveOutPause(_intptr0);
        }

        public bool method_5()
        {
            return !_bool2 && _bool1;
        }

        ~AudioPlayer()
        {
            Dispose();
        }

        public void Dispose()
        {
            lock (_object0)
            {
                if (_thread0 != null)
                {
                    try
                    {
                        _bool0 = true;
                        if (_intptr0 != IntPtr.Zero)
                        {
                            Class162.waveOutReset(_intptr0);
                        }
                        _thread0.Join();
                        _delegate30 = null;
                        method_8();
                        if (_intptr0 != IntPtr.Zero)
                        {
                            Class161 @class = new Class161
                            {
                                Class1590 = this,
                                Intptr0 = _intptr0
                            };
                            ThreadPool.QueueUserWorkItem(@class.method_0);
                        }
                    }
                    finally
                    {
                        _thread0 = null;
                        _intptr0 = IntPtr.Zero;
                    }
                }
            }
            GC.SuppressFinalize(this);
        }

        private void method_6()
        {
            while (!_bool0)
            {
                method_9();
                if (_delegate30 != null && !_bool0)
                {
                    _delegate30(this, _class1651.method_1(), _class1651.method_0(), ref _bool0);
                    if (_bool0 && _bool2)
                    {
                        _bool0 = false;
                    }
                }
                else
                {
                    byte[] array = new byte[_class1651.method_0()];
                    if (_byte0 != 0)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = _byte0;
                        }
                    }
                    Marshal.Copy(array, 0, _class1651.method_1(), array.Length);
                }
                _class1651.method_2();
            }
            method_10();
            _bool1 = true;
        }

        private void method_7(int int0, int int1)
        {
            method_8();
            if (int1 > 0)
            {
                _class1650 = new Class165(_intptr0, int0);
                Class165 @class = _class1650;
                try
                {
                    for (int i = 1; i < int1; i++)
                    {
                        Class165 class2 = new Class165(_intptr0, int0);
                        @class.Class1650 = class2;
                        @class = class2;
                    }
                }
                finally
                {
                    @class.Class1650 = _class1650;
                }
            }
        }

        private void method_8()
        {
            _class1651 = null;
            if (_class1650 != null)
            {
                Class165 @class = _class1650;
                _class1650 = null;
                Class165 class2 = @class;
                do
                {
                    Class165 class3 = class2.Class1650;
                    class2.Dispose();
                    class2 = class3;
                } while (class2 != @class);
            }
        }

        private void method_9()
        {
            _class1651 = ((_class1651 == null) ? _class1650 : _class1651.Class1650);
            _class1651.method_3();
        }

        private void method_10()
        {
            Class165 @class = _class1650;
            while (@class.Class1650 != _class1650)
            {
                @class.method_3();
                @class = @class.Class1650;
            }
        }
    }
}