using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace GHNamespace9
{
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    public class ZzCollection1<T> : IEnumerable, ICollection<T>, IEnumerable<T>
    {
        public struct Struct81
        {
            public int Int0;

            public int Int1;
        }

        public struct Struct82 : IEnumerator, IEnumerator<T>, IDisposable
        {
            private ZzCollection1<T> _class2360;

            private int _int0;

            private readonly int _int1;

            private T _gparam0;

            public T Current => _gparam0;

            object IEnumerator.Current
            {
                get
                {
                    method_0();
                    if (_int0 <= 0)
                    {
                        throw new InvalidOperationException("Current is not valid");
                    }
                    return _gparam0;
                }
            }

            public Struct82(ZzCollection1<T> class2361)
            {
                this = default(Struct82);
                _class2360 = class2361;
                _int1 = class2361._int5;
            }

            public bool MoveNext()
            {
                method_0();
                if (_int0 < 0)
                {
                    return false;
                }
                while (_int0 < _class2360._int1)
                {
                    var num = _int0++;
                    if (_class2360.method_4(num) != 0)
                    {
                        _gparam0 = _class2360._gparam0[num];
                        return true;
                    }
                }
                _int0 = -1;
                return false;
            }

            void IEnumerator.Reset()
            {
                method_0();
                _int0 = 0;
            }

            public void Dispose()
            {
                _class2360 = null;
            }

            private void method_0()
            {
                if (_class2360 == null)
                {
                    throw new ObjectDisposedException(null);
                }
                if (_class2360._int5 != _int1)
                {
                    throw new InvalidOperationException("HashSet have been modified while it was iterated over");
                }
            }
        }

        private static class Class237
        {
            private static readonly int[] OddPrimeSequence =
            {
                11,
                19,
                37,
                73,
                109,
                163,
                251,
                367,
                557,
                823,
                1237,
                1861,
                2777,
                4177,
                6247,
                9371,
                14057,
                21089,
                31627,
                47431,
                71143,
                106721,
                160073,
                240101,
                360163,
                540217,
                810343,
                1215497,
                1823231,
                2734867,
                4102283,
                6153409,
                9230113,
                13845163
            };

            private static bool smethod_0(int int1)
            {
                if ((int1 & 1) != 0)
                {
                    var num = (int) Math.Sqrt(int1);
                    for (var i = 3; i < num; i += 2)
                    {
                        if (int1 % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return int1 == 2;
            }

            private static int smethod_1(int int1)
            {
                for (var i = (int1 & -2) - 1; i < Int32.MaxValue; i += 2)
                {
                    if (smethod_0(i))
                    {
                        return i;
                    }
                }
                return int1;
            }

            public static int smethod_2(int int1)
            {
                for (var i = 0; i < OddPrimeSequence.Length; i++)
                {
                    if (int1 <= OddPrimeSequence[i])
                    {
                        return OddPrimeSequence[i];
                    }
                }
                return smethod_1(int1);
            }
        }

        private int[] _int0;

        private Struct81[] _struct810;

        private T[] _gparam0;

        private int _int1;

        private int _int2;

        private int _int3;

        private int _int4;

        private IEqualityComparer<T> _iequalityComparer0;

        private int _int5;

        public int Count => _int3;

        bool ICollection<T>.IsReadOnly => false;

        public ZzCollection1()
        {
            method_0(10, null);
        }

        public ZzCollection1(IEqualityComparer<T> iequalityComparer1)
        {
            method_0(10, iequalityComparer1);
        }

        public ZzCollection1(IEnumerable<T> ienumerable0) : this(ienumerable0, null)
        {
        }

        public ZzCollection1(IEnumerable<T> ienumerable0, IEqualityComparer<T> iequalityComparer1)
        {
            if (ienumerable0 == null)
            {
                throw new ArgumentNullException("collection");
            }
            var int_ = 0;
            var collection = ienumerable0 as ICollection<T>;
            if (collection != null)
            {
                int_ = collection.Count;
            }
            method_0(int_, iequalityComparer1);
            foreach (var current in ienumerable0)
            {
                vmethod_0(current);
            }
        }

        private void method_0(int int6, IEqualityComparer<T> iequalityComparer1)
        {
            if (int6 < 0)
            {
                throw new ArgumentOutOfRangeException("capacity");
            }
            _iequalityComparer0 = (iequalityComparer1 ?? EqualityComparer<T>.Default);
            if (int6 == 0)
            {
                int6 = 10;
            }
            int6 = (int) (int6 / 0.9f) + 1;
            method_1(int6);
            _int5 = 0;
        }

        private void method_1(int int6)
        {
            _int0 = new int[int6];
            _struct810 = new Struct81[int6];
            _int2 = -1;
            _gparam0 = new T[int6];
            _int1 = 0;
            _int4 = (int) (_int0.Length * 0.9f);
            if (_int4 == 0 && _int0.Length > 0)
            {
                _int4 = 1;
            }
        }

        public void CopyTo(T[] gparam1, int int6)
        {
            method_2(gparam1, int6, _int3);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        public void method_2(T[] gparam1, int int6, int int7)
        {
            if (gparam1 == null)
            {
                throw new ArgumentNullException("array");
            }
            if (int6 < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (int6 > gparam1.Length)
            {
                throw new ArgumentException("index larger than largest valid index of array");
            }
            if (gparam1.Length - int6 < int7)
            {
                throw new ArgumentException("Destination array cannot hold the requested elements!");
            }
            var num = 0;
            var num2 = int6 + int7;
            while (num < _int1 && int6 < num2)
            {
                if (method_4(num) != 0)
                {
                    gparam1[int6++] = _gparam0[num];
                }
                num++;
            }
        }

        public void Clear()
        {
            _int3 = 0;
            Array.Clear(_int0, 0, _int0.Length);
            Array.Clear(_gparam0, 0, _gparam0.Length);
            Array.Clear(_struct810, 0, _struct810.Length);
            _int2 = -1;
            _int1 = 0;
            _int5++;
        }

        private void method_3()
        {
            var num = Class237.smethod_2(_int0.Length << 1 | 1);
            var array = new int[num];
            var array2 = new Struct81[num];
            for (var i = 0; i < _int0.Length; i++)
            {
                for (var num2 = _int0[i] - 1; num2 != -1; num2 = _struct810[num2].Int1)
                {
                    var num3 = array2[num2].Int0 = method_5(_gparam0[num2]);
                    var num4 = (num3 & 2147483647) % num;
                    array2[num2].Int1 = array[num4] - 1;
                    array[num4] = num2 + 1;
                }
            }
            _int0 = array;
            _struct810 = array2;
            var destinationArray = new T[num];
            Array.Copy(_gparam0, 0, destinationArray, 0, _int1);
            _gparam0 = destinationArray;
            _int4 = (int) (num * 0.9f);
        }

        public int method_4(int int6)
        {
            return _struct810[int6].Int0 & -2147483648;
        }

        public int method_5(T gparam1)
        {
            if (gparam1 != null)
            {
                return _iequalityComparer0.GetHashCode(gparam1) | -2147483648;
            }
            return -2147483648;
        }

        void ICollection<T>.Add(T item)
        {
            vmethod_0(item);
        }

        public bool vmethod_0(T gparam1)
        {
            var num = method_5(gparam1);
            var num2 = (num & 2147483647) % _int0.Length;
            if (method_6(num2, num, gparam1))
            {
                return false;
            }
            if (++_int3 > _int4)
            {
                method_3();
                num2 = (num & 2147483647) % _int0.Length;
            }
            var num3 = _int2;
            if (num3 == -1)
            {
                num3 = _int1++;
            }
            else
            {
                _int2 = _struct810[num3].Int1;
            }
            _struct810[num3].Int0 = num;
            _struct810[num3].Int1 = _int0[num2] - 1;
            _int0[num2] = num3 + 1;
            _gparam0[num3] = gparam1;
            _int5++;
            return true;
        }

        public bool Contains(T item)
        {
            var num = method_5(item);
            var int_ = (num & 2147483647) % _int0.Length;
            return method_6(int_, num, item);
        }

        private bool method_6(int int6, int int7, T gparam1)
        {
            Struct81 @struct;
            for (var num = _int0[int6] - 1; num != -1; num = @struct.Int1)
            {
                @struct = _struct810[num];
                if (@struct.Int0 == int7 && ((int7 != -2147483648 || (gparam1 != null && _gparam0[num] != null))
                        ? _iequalityComparer0.Equals(gparam1, _gparam0[num])
                        : (gparam1 == null && null == _gparam0[num])))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T item)
        {
            var num = method_5(item);
            var num2 = (num & 2147483647) % _int0.Length;
            var num3 = _int0[num2] - 1;
            if (num3 == -1)
            {
                return false;
            }
            var num4 = -1;
            do
            {
                var @struct = _struct810[num3];
                if (@struct.Int0 == num)
                {
                    if ((num != -2147483648 || (item != null && _gparam0[num3] != null))
                        ? _iequalityComparer0.Equals(_gparam0[num3], item)
                        : (item == null && null == _gparam0[num3]))
                    {
                        break;
                    }
                }
                num4 = num3;
                num3 = @struct.Int1;
            } while (num3 != -1);
            if (num3 == -1)
            {
                return false;
            }
            _int3--;
            if (num4 == -1)
            {
                _int0[num2] = _struct810[num3].Int1 + 1;
            }
            else
            {
                _struct810[num4].Int1 = _struct810[num3].Int1;
            }
            _struct810[num3].Int1 = _int2;
            _int2 = num3;
            _struct810[num3].Int0 = 0;
            _gparam0[num3] = default(T);
            _int5++;
            return true;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Struct82(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Struct82(this);
        }
    }
}