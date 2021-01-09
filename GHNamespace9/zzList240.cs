using System;
using System.Collections;

namespace GHNamespace9
{
    public class ZzList240 : IEnumerable, ICloneable, ICollection, IList
    {
        private class MyComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                IComparable comparable = x as IComparable;
                return comparable.CompareTo(y);
            }
        }

        private ArrayList _arrayList0;

        private IComparer _icomparer0;

        private bool _bool0;

        private bool _bool1;

        private bool _bool2;

        private bool _bool3;

        public object this[int index]
        {
            get
            {
                if (index >= _arrayList0.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index is less than zero or Index is greater than Count.");
                }
                return _arrayList0[index];
            }
            set
            {
                if (_bool2)
                {
                    throw new InvalidOperationException(
                        "[] operator cannot be used to set a value if KeepSorted property is set to true.");
                }
                if (index < _arrayList0.Count && index >= 0)
                {
                    if (method_0(value))
                    {
                        object obj = (index > 0) ? _arrayList0[index - 1] : null;
                        object obj2 = (index < Count - 1) ? _arrayList0[index + 1] : null;
                        if ((obj != null && _icomparer0.Compare(obj, value) > 0) ||
                            (obj2 != null && _icomparer0.Compare(value, obj2) > 0))
                        {
                            _bool1 = false;
                        }
                        _arrayList0[index] = value;
                    }
                    return;
                }
                throw new ArgumentOutOfRangeException("Index is less than zero or Index is greater than Count.");
            }
        }

        public int Count => _arrayList0.Count;

        public object SyncRoot => _arrayList0.SyncRoot;

        public bool IsSynchronized => _arrayList0.IsSynchronized;

        public bool IsReadOnly => _arrayList0.IsReadOnly;

        public bool IsFixedSize => _arrayList0.IsFixedSize;

        public ZzList240()
        {
            method_1(null, 0);
        }

        public ZzList240(IComparer icomparer1, int int0)
        {
            method_1(icomparer1, int0);
        }

        public int Add(object value)
        {
            int result = -1;
            if (method_0(value))
            {
                if (_bool2)
                {
                    int num = IndexOf(value);
                    int num2 = (num >= 0) ? num : (-num - 1);
                    if (num2 >= Count)
                    {
                        _arrayList0.Add(value);
                    }
                    else
                    {
                        _arrayList0.Insert(num2, value);
                    }
                    result = num2;
                }
                else
                {
                    _bool1 = false;
                    result = _arrayList0.Add(value);
                }
            }
            return result;
        }

        public bool Contains(object value)
        {
            if (!_bool1)
            {
                return _arrayList0.Contains(value);
            }
            return _arrayList0.BinarySearch(value, _icomparer0) >= 0;
        }

        public int IndexOf(object value)
        {
            int num;
            if (_bool1)
            {
                num = _arrayList0.BinarySearch(value, _icomparer0);
                while (num > 0 && _arrayList0[num - 1].Equals(value))
                {
                    num--;
                }
            }
            else
            {
                num = _arrayList0.IndexOf(value);
            }
            return num;
        }

        public void Insert(int index, object value)
        {
            if (_bool2)
            {
                throw new InvalidOperationException(
                    "Insert method cannot be called if KeepSorted property is set to true.");
            }
            if (index < _arrayList0.Count && index >= 0)
            {
                if (method_0(value))
                {
                    object obj = _arrayList0[index];
                    object obj2 = (index > 0) ? _arrayList0[index - 1] : null;
                    if ((obj2 != null && _icomparer0.Compare(obj2, value) > 0) ||
                        (obj != null && _icomparer0.Compare(value, obj) > 0))
                    {
                        _bool1 = false;
                    }
                    _arrayList0.Insert(index, value);
                }
                return;
            }
            throw new ArgumentOutOfRangeException("index is less than zero or index is greater than Count.");
        }

        public void Remove(object value)
        {
            _arrayList0.Remove(value);
        }

        public void RemoveAt(int index)
        {
            _arrayList0.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            _arrayList0.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _arrayList0.GetEnumerator();
        }

        public void Clear()
        {
            _arrayList0.Clear();
        }

        public object Clone()
        {
            return new ZzList240(_icomparer0, _arrayList0.Capacity)
            {
                _arrayList0 = (ArrayList) _arrayList0.Clone(),
                _bool3 = _bool3,
                _bool1 = _bool1,
                _bool2 = _bool2
            };
        }

        public override string ToString()
        {
            string text = "{";
            for (int i = 0; i < _arrayList0.Count; i++)
            {
                text = text + _arrayList0[i] + ((i != _arrayList0.Count - 1) ? "; " : "}");
            }
            return text;
        }

        public override bool Equals(object obj)
        {
            ZzList240 @class = (ZzList240) obj;
            if (@class.Count != Count)
            {
                return false;
            }
            for (int i = 0; i < Count; i++)
            {
                if (!@class[i].Equals(this[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return _arrayList0.GetHashCode();
        }

        private bool method_0(object object0)
        {
            if (_bool0 && !(object0 is IComparable))
            {
                throw new ArgumentException(
                    "The SortableArrayList is set to use the IComparable interface of objects, and the object to add does not implement the IComparable interface.");
            }
            return _bool3 || !Contains(object0);
        }

        private void method_1(IComparer icomparer1, int int0)
        {
            if (icomparer1 != null)
            {
                _icomparer0 = icomparer1;
                _bool0 = false;
            }
            else
            {
                _icomparer0 = new MyComparer();
                _bool0 = true;
            }
            _arrayList0 = ((int0 > 0) ? new ArrayList(int0) : new ArrayList());
            _bool1 = true;
            _bool2 = true;
            _bool3 = true;
        }
    }
}