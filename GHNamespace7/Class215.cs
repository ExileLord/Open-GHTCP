using System;
using System.Collections;
using System.Collections.Generic;

namespace GHNamespace7
{
    public class Class215<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
    {
        private List<TKey> _list0;

        private List<TValue> _list1;

        private int _int0 = -1;

        public KeyValuePair<TKey, TValue> Current => new KeyValuePair<TKey, TValue>(_list0[_int0], _list1[_int0]);

        object IEnumerator.Current => Current;

        public Class215(List<TKey> list2, List<TValue> list3)
        {
            _list0 = list2;
            _list1 = list3;
        }

        public void Dispose()
        {
            _list0 = null;
            _list1 = null;
        }

        public bool MoveNext()
        {
            _int0++;
            return _int0 < _list0.Count;
        }

        public void Reset()
        {
            _int0 = -1;
        }
    }
}