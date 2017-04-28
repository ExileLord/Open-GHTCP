using System.Collections;
using System.Collections.Generic;

namespace GHNamespace9
{
    public class ZzDictionary242<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>,
        ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IEnumerable
    {
        private readonly ZzMap243<TKey, TValue> _class2430 = new ZzMap243<TKey, TValue>();

        public TValue this[TKey key]
        {
            get
            {
                if (!_class2430.Contains(key))
                {
                    return default(TValue);
                }
                return _class2430[key].Value;
            }
            set
            {
                if (_class2430.Contains(key))
                {
                    Remove(key);
                }
                Add(key, value);
            }
        }

        public TValue this[int int0]
        {
            get
            {
                if (_class2430.Count <= int0)
                {
                    return default(TValue);
                }
                return _class2430[int0].Value;
            }
            set
            {
                if (_class2430.Count > int0)
                {
                    _class2430[int0] = new KeyValuePair<TKey, TValue>(_class2430[int0].Key, value);
                }
            }
        }

        public int Count => _class2430.Count;

        public bool IsReadOnly => false;

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> collection = new List<TKey>();
                foreach (var current in _class2430)
                {
                    collection.Add(current.Key);
                }
                return collection;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> collection = new List<TValue>();
                foreach (var current in _class2430)
                {
                    collection.Add(current.Value);
                }
                return collection;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return _class2430.Contains(key);
        }

        public void Add(TKey key, TValue value)
        {
            _class2430.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            if (!_class2430.Contains(key))
            {
                return false;
            }
            _class2430.Remove(key);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!_class2430.Contains(key))
            {
                value = default(TValue);
                return false;
            }
            value = _class2430[key].Value;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return _class2430.GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _class2430.Add(item);
        }

        public void Add(ICollection<KeyValuePair<TKey, TValue>> icollection0)
        {
            foreach (var current in icollection0)
            {
                _class2430.Add(current);
            }
        }

        public void Clear()
        {
            _class2430.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _class2430.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            _class2430.CopyTo(array, index);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _class2430.Remove(item);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return _class2430.GetEnumerator();
        }
    }
}