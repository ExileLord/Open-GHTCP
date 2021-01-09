using System.Collections;
using System.Collections.Generic;

namespace GHNamespace7
{
    public class ZzCollection214<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>,
        ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IEnumerable
    {
        private readonly Dictionary<TKey, TValue> _dictionary0 = new Dictionary<TKey, TValue>();

        private readonly List<TKey> _list0 = new List<TKey>();

        private readonly List<TValue> _list1 = new List<TValue>();

        public TValue this[TKey key]
        {
            get
            {
                if (_dictionary0.ContainsKey(key))
                {
                    return _dictionary0[key];
                }
                return default(TValue);
            }
            set
            {
                if (_dictionary0.ContainsKey(key))
                {
                    List<TValue> arg300 = _list1;
                    int arg301 = _list0.IndexOf(key);
                    _dictionary0[key] = value;
                    arg300[arg301] = value;
                    return;
                }
                Add(key, value);
            }
        }

        public TValue this[int int0]
        {
            get
            {
                if (_dictionary0.Count > int0)
                {
                    return _list1[int0];
                }
                return default(TValue);
            }
            set
            {
                if (_dictionary0.Count > int0)
                {
                    Dictionary<TKey, TValue> arg300 = _dictionary0;
                    TKey arg301 = _list0[int0];
                    _list1[int0] = value;
                    arg300[arg301] = value;
                }
            }
        }

        public TKey this[TValue gparam0]
        {
            get => method_0(gparam0);
            set
            {
                if (_dictionary0.ContainsKey(value))
                {
                    List<TValue> arg300 = _list1;
                    int arg301 = _list0.IndexOf(value);
                    _dictionary0[value] = gparam0;
                    arg300[arg301] = gparam0;
                    return;
                }
                Add(value, gparam0);
            }
        }

        public int Count => _dictionary0.Count;

        public bool IsReadOnly => false;

        public ICollection<TKey> Keys => _list0;

        public ICollection<TValue> Values => _list1;

        public bool ContainsKey(TKey key)
        {
            return _dictionary0.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary0.Add(key, value);
            _list0.Add(key);
            _list1.Add(value);
        }

        public bool Remove(TKey key)
        {
            if (!_dictionary0.ContainsKey(key))
            {
                return false;
            }
            _list0.Remove(key);
            _list1.Remove(_dictionary0[key]);
            return _dictionary0.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!_dictionary0.ContainsKey(key))
            {
                value = default(TValue);
                return false;
            }
            value = _dictionary0[key];
            return true;
        }

        public TKey method_0(TValue gparam0)
        {
            if (_list1.Contains(gparam0))
            {
                return _list0[_list1.IndexOf(gparam0)];
            }
            return default(TKey);
        }

        public IEnumerator GetEnumerator()
        {
            return new Class215<TKey, TValue>(_list0, _list1);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(ICollection<KeyValuePair<TKey, TValue>> icollection0)
        {
            foreach (KeyValuePair<TKey, TValue> current in icollection0)
            {
                Add(current);
            }
        }

        public void Clear()
        {
            _dictionary0.Clear();
            _list0.Clear();
            _list1.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (_dictionary0.ContainsKey(item.Key))
            {
                TValue tValue = _dictionary0[item.Key];
                return tValue.Equals(item.Value);
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            for (int i = 0; i < _dictionary0.Count; i++)
            {
                array[index + i] = new KeyValuePair<TKey, TValue>(_list0[i], _list1[i]);
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Contains(item) && Remove(item.Key);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return new Class215<TKey, TValue>(_list0, _list1);
        }
    }
}