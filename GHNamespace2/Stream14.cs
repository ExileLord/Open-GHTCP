using System;
using System.IO;
using SharpAudio.ASC;

namespace GHNamespace2
{
    public abstract class Stream14 : Stream, IDisposable
    {
        public Stream Stream0;

        public WaveFormat WaveFormat0;

        private static int _int0 = 368;

        private static int _int1 = 264;

        public virtual int vmethod_0()
        {
            return WaveFormat0.int_1 / 10;
        }

        public int method_0()
        {
            return vmethod_0();
        }

        public virtual Stream vmethod_1()
        {
            Flush();
            return Stream0;
        }

        public override void Close()
        {
            Dispose(true);
        }

        public override void Flush()
        {
            Stream0.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stream0.Close();
            }
        }

        public new virtual void Dispose()
        {
            Dispose(true);
        }
    }
}