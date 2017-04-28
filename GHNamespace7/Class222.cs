using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace GHNamespace7
{
    public class Class222<T> : IEnumerable, ICollection<T>, IEnumerable<T>, ICollection
    {
        public struct Struct76 : IEnumerator, IEnumerator<T>, IDisposable
        {
            private Class225.Struct77 _struct770;

            private readonly IComparer<T> _icomparer0;

            private T _gparam0;

            private readonly T _gparam1;

            public T Current => _gparam0;

            object IEnumerator.Current
            {
                get
                {
                    _struct770.method_1();
                    return ((Class227) _struct770.Current).Gparam0;
                }
            }

            public Struct76(Class222<T> class2220)
            {
                this = default(Struct76);
                _struct770 = class2220._class2250.method_14();
            }

            public Struct76(Class222<T> class2220, T gparam2, T gparam3)
            {
                this = default(Struct76);
                _struct770 = class2220._class2250.method_15(gparam2);
                _icomparer0 = class2220.method_1();
                _gparam1 = gparam3;
            }

            public bool MoveNext()
            {
                if (!_struct770.MoveNext())
                {
                    return false;
                }
                _gparam0 = ((Class227) _struct770.Current).Gparam0;
                return _icomparer0 == null || _icomparer0.Compare(_gparam1, _gparam0) >= 0;
            }

            public void Dispose()
            {
                _struct770.Dispose();
            }

            void IEnumerator.Reset()
            {
                _struct770.Reset();
            }
        }

        private class Class227 : Class225.Class226
        {
            public T Gparam0;

            public Class227(T gparam1)
            {
                Gparam0 = gparam1;
            }

            public override void vmethod_0(Class225.Class226 class2262)
            {
                var @class = (Class227) class2262;
                var t = Gparam0;
                Gparam0 = @class.Gparam0;
                @class.Gparam0 = t;
            }
        }

        private class Class223 : Class225.INterface10<T>
        {
            private static readonly Class223 Class2230 = new Class223(Comparer<T>.Default);

            public readonly IComparer<T> Icomparer0;

            public int imethod_0(T gparam0, Class225.Class226 class2260)
            {
                return Icomparer0.Compare(gparam0, ((Class227) class2260).Gparam0);
            }

            public Class225.Class226 imethod_1(T gparam0)
            {
                return new Class227(gparam0);
            }

            private Class223(IComparer<T> icomparer1)
            {
                Icomparer0 = icomparer1;
            }

            public static Class223 smethod_0(IComparer<T> icomparer1)
            {
                if (icomparer1 != null)
                {
                    if (icomparer1 != Comparer<T>.Default)
                    {
                        return new Class223(icomparer1);
                    }
                }
                return Class2230;
            }
        }

        private object _object0;

        private readonly Class225 _class2250;

        private readonly Class223 _class2230;

        public int Count => vmethod_0();

        bool ICollection<T>.IsReadOnly => false;

        bool ICollection.IsSynchronized => false;

        object ICollection.SyncRoot
        {
            get
            {
                if (_object0 == null)
                {
                    Interlocked.CompareExchange(ref _object0, new object(), null);
                }
                return _object0;
            }
        }

        public Class222() : this(Comparer<T>.Default)
        {
        }

        public Class222(IEnumerable<T> ienumerable0) : this(ienumerable0, Comparer<T>.Default)
        {
        }

        public Class222(IEnumerable<T> ienumerable0, IComparer<T> icomparer0) : this(icomparer0)
        {
            if (ienumerable0 == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var current in ienumerable0)
            {
                vmethod_1(current);
            }
        }

        public Class222(IComparer<T> icomparer0)
        {
            _class2230 = Class223.smethod_0(icomparer0);
            _class2250 = new Class225(_class2230);
        }

        public virtual int vmethod_0()
        {
            return _class2250.method_4();
        }

        private T method_0(int int0)
        {
            return ((Class227) _class2250[int0]).Gparam0;
        }

        public virtual void Clear()
        {
            _class2250.method_0();
        }

        void ICollection<T>.Add(T item)
        {
            vmethod_1(item);
        }

        public bool vmethod_1(T gparam0)
        {
            return vmethod_2(gparam0);
        }

        public virtual bool vmethod_2(T gparam0)
        {
            var @class = new Class227(gparam0);
            return _class2250.method_1(gparam0, @class) == @class;
        }

        public virtual bool Contains(T item)
        {
            return _class2250.method_3(item) != null;
        }

        public bool Remove(T item)
        {
            return vmethod_3(item);
        }

        public virtual bool vmethod_3(T gparam0)
        {
            return _class2250.method_2(gparam0) != null;
        }

        public IComparer<T> method_1()
        {
            return _class2230.Icomparer0;
        }

        public void method_2(T[] gparam0, int int0, int int1)
        {
            if (gparam0 == null)
            {
                throw new ArgumentNullException("array");
            }
            if (int0 < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (int0 > gparam0.Length)
            {
                throw new ArgumentException("index larger than largest valid index of array");
            }
            if (gparam0.Length - int0 < int1)
            {
                throw new ArgumentException("destination array cannot hold the requested elements");
            }
            using (var @struct = _class2250.method_14())
            {
                while (@struct.MoveNext())
                {
                    var @class = (Class227) @struct.Current;
                    if (int1-- == 0)
                    {
                        break;
                    }
                    gparam0[int0++] = @class.Gparam0;
                }
            }
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            method_2(array, arrayIndex, Count);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (Count == 0)
            {
                return;
            }
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index >= 0 && array.Length > index)
            {
                if (array.Length - index < Count)
                {
                    throw new ArgumentException();
                }
                using (var @struct = _class2250.method_14())
                {
                    while (@struct.MoveNext())
                    {
                        var @class = (Class227) @struct.Current;
                        array.SetValue(@class.Gparam0, index++);
                    }
                    return;
                }
            }
            throw new ArgumentOutOfRangeException("index");
        }

        public Struct76 method_3()
        {
            return vmethod_4();
        }

        public virtual Struct76 vmethod_4()
        {
            return new Struct76(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return method_3();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return method_3();
        }
    }
}