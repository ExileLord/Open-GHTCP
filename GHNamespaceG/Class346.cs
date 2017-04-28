using System;

namespace GHNamespaceG
{
    public class Class346<T> : IDisposable
    {
        public T[] Gparam0;

        public int Int0;

        public int Int1;

        public Class346() : this(65536)
        {
        }

        public Class346(int int2)
        {
            Gparam0 = new T[int2];
        }

        public void Dispose()
        {
            Int0 = 0;
            Int1 = 0;
            Gparam0 = new T[0];
        }
    }
}