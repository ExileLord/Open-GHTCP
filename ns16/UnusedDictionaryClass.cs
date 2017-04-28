using System.Collections;
using System.Collections.Generic;

namespace ns16
{
	public class zzDictionary242<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IEnumerable
	{
		private readonly zzMap243<TKey, TValue> class243_0 = new zzMap243<TKey, TValue>();

		public TValue this[TKey key]
		{
			get
			{
				if (!class243_0.Contains(key))
				{
					return default(TValue);
				}
				return class243_0[key].Value;
			}
			set
			{
				if (class243_0.Contains(key))
				{
					Remove(key);
				}
				Add(key, value);
			}
		}

		public TValue this[int int_0]
		{
			get
			{
				if (class243_0.Count <= int_0)
				{
					return default(TValue);
				}
				return class243_0[int_0].Value;
			}
			set
			{
				if (class243_0.Count > int_0)
				{
					class243_0[int_0] = new KeyValuePair<TKey, TValue>(class243_0[int_0].Key, value);
				}
			}
		}

		public int Count
		{
			get
			{
				return class243_0.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				ICollection<TKey> collection = new List<TKey>();
				foreach (var current in class243_0)
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
				foreach (var current in class243_0)
				{
					collection.Add(current.Value);
				}
				return collection;
			}
		}

		public bool ContainsKey(TKey key)
		{
			return class243_0.Contains(key);
		}

		public void Add(TKey key, TValue value)
		{
			class243_0.Add(new KeyValuePair<TKey, TValue>(key, value));
		}

		public bool Remove(TKey key)
		{
			if (!class243_0.Contains(key))
			{
				return false;
			}
			class243_0.Remove(key);
			return true;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!class243_0.Contains(key))
			{
				value = default(TValue);
				return false;
			}
			value = class243_0[key].Value;
			return true;
		}

		public IEnumerator GetEnumerator()
		{
			return class243_0.GetEnumerator();
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			class243_0.Add(item);
		}

		public void Add(ICollection<KeyValuePair<TKey, TValue>> icollection_0)
		{
			foreach (var current in icollection_0)
			{
				class243_0.Add(current);
			}
		}

		public void Clear()
		{
			class243_0.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return class243_0.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			class243_0.CopyTo(array, index);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return class243_0.Remove(item);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return class243_0.GetEnumerator();
		}
	}
}
