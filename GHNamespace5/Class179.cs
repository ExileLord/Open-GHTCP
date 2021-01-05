using System;
using System.Collections;
using System.IO;
using GHNamespace6;
using GHNamespace7;

namespace GHNamespace5
{
    public class Class179 : IEnumerable, IDisposable
    {
        private enum Enum28
        {
            Const0,
            Const1,
            Const2
        }

        private class Class180 : IComparer
        {
            public int Compare(object x, object y)
            {
                var @class = x as Class181;
                var class2 = y as Class181;
                int num;
                if (@class == null)
                {
                    if (class2 == null)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = -1;
                    }
                }
                else if (class2 == null)
                {
                    num = 1;
                }
                else
                {
                    var num2 = (@class.method_1() == Enum28.Const0 || @class.method_1() == Enum28.Const1) ? 0 : 1;
                    var num3 = (class2.method_1() == Enum28.Const0 || class2.method_1() == Enum28.Const1) ? 0 : 1;
                    num = num2 - num3;
                    if (num == 0)
                    {
                        var num4 = @class.method_0().method_6() - class2.method_0().method_6();
                        if (num4 < 0L)
                        {
                            num = -1;
                        }
                        else if (num4 == 0L)
                        {
                            num = 0;
                        }
                        else
                        {
                            num = 1;
                        }
                    }
                }
                return num;
            }
        }

        private class Class181
        {
            private Class193 _class1930;

            private Enum28 _enum280;

            public Class193 method_0()
            {
                return _class1930;
            }

            public Enum28 method_1()
            {
                return _enum280;
            }
        }

        private class Class182 : IEnumerator
        {
            private readonly Class193[] _class1930;

            private int _int0 = -1;

            public object Current => _class1930[_int0];

            public Class182(Class193[] class1931)
            {
                _class1930 = class1931;
            }

            public void Reset()
            {
                _int0 = -1;
            }

            public bool MoveNext()
            {
                return ++_int0 < _class1930.Length;
            }
        }

        private bool _bool0;

        private Stream _stream0;

        private bool _bool1;

        private Class193[] _class1930;

        private bool _bool2;

        private Enum30 _enum300 = Enum30.Const2;

        private int _int0 = 4096;

        private INterface9 _interface90 = new Class212();

        private string _string0 = string.Empty;

        public Class193 this[int int1] => (Class193) _class1930[int1].Clone();

        public Class179()
        {
            _class1930 = new Class193[0];
            _bool2 = true;
        }

        ~Class179()
        {
            vmethod_0(false);
        }

        public void method_0()
        {
            method_2(true);
            GC.SuppressFinalize(this);
        }

        public bool method_1()
        {
            return _bool1;
        }

        public IEnumerator GetEnumerator()
        {
            if (_class1930 == null)
            {
                throw new InvalidOperationException("ZipFile has closed");
            }
            return new Class182(_class1930);
        }

        void IDisposable.Dispose()
        {
            method_0();
        }

        private void method_2(bool bool3)
        {
            if (!_bool0)
            {
                _bool0 = true;
                _class1930 = null;
                if (method_1() && _stream0 != null)
                {
                    lock (_stream0)
                    {
                        _stream0.Close();
                    }
                }
            }
        }

        public virtual void vmethod_0(bool bool3)
        {
            method_2(bool3);
        }
    }
}